Imports System.Collections.Generic
Imports System.Linq
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Forms
Imports AATM.Accounts.ServiceLayer

Namespace PresentationLayer.Presenters

    Public Class OpenInvoiceCorrectionPresenter

        Private Const AmountTolerance As Decimal = 0.005D

        Private ReadOnly _view As OpenInvoiceCorrectionForm
        Private ReadOnly _service As New OpenInvoiceCorrectionService()
        Private _items As New List(Of OpenInvoiceCorrectionItem)

        Public Sub New(view As OpenInvoiceCorrectionForm)
            _view = view
        End Sub

        Public Sub Initialize()
            LoadContacts(_view.LedgerCode)
        End Sub

        Public Sub LedgerChanged()
            If _view.LedgerCode <> String.Empty Then
                LoadContacts(_view.LedgerCode)
            End If
        End Sub

        Public Sub ContactChanged()
            If _view.SelectedContactIdNo > 0 Then
                LoadOpenInvoices()
            End If
        End Sub

        Public Sub AutoApply()
            If _items.Count = 0 Then
                _view.ShowError("There are no open invoices for the selected contact.", "Open Invoice Correction")
                Return
            End If

            _service.ApplyNegativeFirst(_items)
            'Rebind the grid so the calculated proposed and projected values are
            'displayed immediately without reloading the original balances.
            _view.SetItems(_items)
            UpdateViewSummary()
            _view.SetStatus("Preview prepared. No database changes have been made.")
        End Sub

        Public Sub Preview()
            If _items.Count = 0 Then
                _view.ShowError("Load a customer or supplier first.", "Open Invoice Correction")
                Return
            End If

            Dim negativeTotal = _service.GetNegativeBalanceTotal(_items)
            Dim positiveUsed = _service.GetPositiveAmountUsed(_items)
            Dim remainingNegative = _service.GetRemainingNegativeBalance(_items)
            Dim message = String.Format("Contact: {0}{1}Open invoices: {2}{1}Negative balances: {3:N2}{1}Positive amount used: {4:N2}{1}Remaining negative balance: {5:N2}{1}{1}This is a preview only. No database changes have been made.",
                                        _view.SelectedContactName,
                                        Environment.NewLine,
                                        _items.Count,
                                        negativeTotal,
                                        positiveUsed,
                                        remainingNegative)
            _view.ShowInformation(message, "Open Invoice Correction Preview")
        End Sub

        Public Sub PostCorrection()
            If _items.Count = 0 Then
                _view.ShowError("Load a customer or supplier first.", "Open Invoice Correction")
                Return
            End If

            Dim contact = _view.SelectedContact
            If contact Is Nothing Then
                _view.ShowError("Select a customer or supplier first.", "Open Invoice Correction")
                Return
            End If
            If Not contact.ControlAccountIdNo.HasValue OrElse contact.ControlAccountIdNo.Value = 0 Then
                _view.ShowError("The selected contact has no AR/AP control account.", "Open Invoice Correction")
                Return
            End If
            If _view.CorrectionDate.Date > Date.Today Then
                _view.ShowError("The correction date cannot be in the future.", "Open Invoice Correction")
                Return
            End If

            Dim lastPostingDate As Date?
            Try
                lastPostingDate = _service.GetLastPostingDate(_view.LedgerCode)
            Catch ex As Exception
                _view.ShowError(ex.Message, "Unable to verify closed period")
                Return
            End Try
            If lastPostingDate.HasValue AndAlso _view.CorrectionDate.Date <= lastPostingDate.Value.Date Then
                _view.ShowError(String.Format("The correction date must be after the closed period ending {0:d}.", lastPostingDate.Value),
                                "Closed Accounting Period")
                Return
            End If

            Dim proposedTotal = Decimal.Round(_items.Sum(Function(item) item.ProposedAmount), 2)
            If Math.Abs(proposedTotal) > AmountTolerance Then
                _view.ShowError(String.Format("The proposed correction is not zero-balanced. Net amount: {0:N2}.", proposedTotal),
                                "Open Invoice Correction")
                Return
            End If

            If Not _items.Any(Function(item) Math.Abs(item.ProposedAmount) > AmountTolerance) Then
                _view.ShowError("Click Auto Apply before posting a correction.", "Open Invoice Correction")
                Return
            End If

            Dim balancesChanged As Boolean
            Try
                balancesChanged = CurrentBalancesChanged(contact.IdNo)
            Catch ex As Exception
                _view.ShowError(ex.Message, "Unable to verify open invoice balances")
                Return
            End Try
            If balancesChanged Then
                _view.ShowError("The open invoices changed after they were loaded. The preview was discarded; reload and apply again.",
                                "Open Invoice Correction")
                LoadOpenInvoices()
                Return
            End If

            Dim notes = _view.Notes.Trim()
            If notes.Length = 0 Then
                notes = "Open invoice offset correction"
            End If
            notes = notes + " | Negative-first automatic allocation"

            Dim remainingNegative = _service.GetRemainingNegativeBalance(_items)
            Dim confirmation = String.Format("Create the {0} correction journal for {1}?{2}{2}It has zero cash amount and will apply only the negative balance covered by positive invoices through allocation lines.{2}Remaining negative balance after this correction: {3:N2}.{2}{2}The journal will be saved unposted for the normal approval/posting workflow.",
                                              If(_view.LedgerCode = OpenInvoiceCorrectionService.AccountsReceivable, "AR", "AP"),
                                              contact.DisplayName,
                                              Environment.NewLine,
                                              remainingNegative)
            If _view.Confirm(confirmation) <> DialogResult.Yes Then Return

            Try
                Dim journalIdNo As Int32
                If _view.LedgerCode = OpenInvoiceCorrectionService.AccountsReceivable Then
                    journalIdNo = _service.SaveArCorrection(contact, _view.CorrectionDate, notes, _items)
                Else
                    journalIdNo = _service.SaveApCorrection(contact, _view.CorrectionDate, notes, _items)
                End If

                If journalIdNo <= 0 Then
                    Throw New InvalidOperationException("The correction journal was not created.")
                End If

                _view.ShowInformation(String.Format("Correction journal {0} was created successfully.", journalIdNo),
                                      "Open Invoice Correction")
                LoadOpenInvoices()
                _view.SetStatus(String.Format("Correction journal {0} created. The open-invoice list has been refreshed.", journalIdNo))
            Catch ex As Exception
                _view.ShowError(ex.Message, "Open Invoice Correction")
            End Try
        End Sub

        Private Sub LoadContacts(ledgerCode As String)
            Try
                Dim contacts = _service.GetContacts(ledgerCode)
                _view.SetContacts(contacts)
                _items = New List(Of OpenInvoiceCorrectionItem)
                _view.SetItems(_items)
                UpdateViewSummary()
                If _view.SelectedContactIdNo > 0 Then
                    LoadOpenInvoices()
                Else
                    _view.SetStatus(String.Format("Select a {0}.", If(ledgerCode = OpenInvoiceCorrectionService.AccountsReceivable, "customer", "supplier")))
                End If
            Catch ex As Exception
                _view.SetContacts(New List(Of OpenInvoiceCorrectionContact))
                _items = New List(Of OpenInvoiceCorrectionItem)
                _view.SetItems(_items)
                UpdateViewSummary()
                _view.ShowError(ex.Message, "Unable to load contacts")
            End Try
        End Sub

        Private Sub LoadOpenInvoices()
            Try
                _items = _service.GetOpenInvoices(_view.LedgerCode, _view.SelectedContactIdNo)
                _view.SetItems(_items)
                UpdateViewSummary()
                _view.SetStatus(String.Format("Loaded {0} non-zero open invoice balance(s). Click Auto Apply to prepare the correction.", _items.Count))
            Catch ex As Exception
                _items = New List(Of OpenInvoiceCorrectionItem)
                _view.SetItems(_items)
                UpdateViewSummary()
                _view.ShowError(ex.Message, "Unable to load open invoices")
            End Try
        End Sub

        Private Function CurrentBalancesChanged(contactIdNo As Int32) As Boolean
            Dim currentItems = _service.GetOpenInvoices(_view.LedgerCode, contactIdNo)
            If currentItems.Count <> _items.Count Then Return True

            For Each item As OpenInvoiceCorrectionItem In _items
                Dim currentItem = currentItems.FirstOrDefault(Function(candidate) candidate.OpenInvoiceIdNo = item.OpenInvoiceIdNo)
                If currentItem Is Nothing OrElse Math.Abs(currentItem.CurrentBalance - item.CurrentBalance) > AmountTolerance Then Return True
            Next
            Return False
        End Function

        Private Sub UpdateViewSummary()
            Dim negativeTotal = _service.GetNegativeBalanceTotal(_items)
            Dim positiveUsed = _service.GetPositiveAmountUsed(_items)
            Dim remainingNegative = _service.GetRemainingNegativeBalance(_items)
            Dim canPost = _items.Any(Function(item) Math.Abs(item.ProposedAmount) > AmountTolerance) AndAlso
                          Math.Abs(Decimal.Round(_items.Sum(Function(item) item.ProposedAmount), 2)) <= AmountTolerance
            _view.SetSummary(negativeTotal, positiveUsed, remainingNegative, canPost)
        End Sub

    End Class

End Namespace
