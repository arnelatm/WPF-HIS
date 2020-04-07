Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class ApJournalPresenter
        Inherits AccountsPresenter(Of IApJournalView, ApJournalModel)

        Private ReadOnly _apOpenInvoiceModel As New ModelAccounts("ApOpenInvoice")

        Public Sub New(view As IApJournalView)
            MyBase.New(view)
            ModelPresenter = New ModelAccounts("ApJournal")
            TableName = "ApJournal"
            SortOrderKey = "IdNo"
            OriginalModel = New ApJournalModel()
            DataModel = New ApJournalModel
            GlobalVariables.EventAggregator.SubscribeEvent(Me)

        End Sub

        Public Property JournalItemsPresenter As ApJournalItemsPresenter

        Public Function UpdateGlReferenceNumber() As String
            Dim retValue As String
            GlobalVariables.Mapper.Map(View, DataModel)
            retValue = ModelPresenter.UpdateGlReferenceNumber(DataModel)
            Return retValue
        End Function

        Public Function UpdateOpenInvoice(ByRef journalItem As JournalItemModel, ByVal addBalance As Decimal) As String
            Dim retValue As String
            Dim openInvoiceModel As New ApOpenInvoiceModel
            openInvoiceModel.DiscountTaken = journalItem.DiscountTaken
            openInvoiceModel.PaidAmount = journalItem.PaidAmount
            openInvoiceModel.IdNo = journalItem.IdNo
            openInvoiceModel.JournalItemIdNo = journalItem.IdNo
            retValue = _apOpenInvoiceModel.UpdateRecord(Of ApOpenInvoiceModel)(openInvoiceModel)
            Return retValue
        End Function



        'Public Sub OnBeforeSave() Handles NewUserRequested
        '    If AddMode Then
        '        IdNo = passedValue
        '    End If
        '    If DtInsertTable IsNot Nothing Then
        '        DtInsertTable.Clear()
        '    End If
        '    If DtUpdateTable IsNot Nothing Then
        '        DtUpdateTable.Clear()
        '    End If
        '    Dim oldJournalItem As List(Of JournalItemModel)
        '    If Not AddMode Then
        '        oldJournalItem = PresenterObj.GetRecordsWithIdNo(Of JournalItemModel)(IdNo, "Sequence")
        '    Else
        '        oldJournalItem = Nothing
        '    End If
        '    Dim nRowCount = 1
        '    For Each ji In bsJournalItems
        '        Dim workRow As DataRow
        '        If ji.IdNo <= 0 Then
        '            workRow = DtInsertTable.NewRow()
        '        Else
        '            workRow = DtUpdateTable.NewRow()
        '            workRow("IdNo") = ji.IdNo
        '        End If
        '        workRow("JournalIdNo") = IdNo
        '        workRow("Sequence") = nRowCount
        '        workRow("AccountIdNo") = ji.AccountIdNo
        '        workRow("Debit") = ji.Debit
        '        workRow("Credit") = ji.Credit
        '        workRow("ProfitCenterIdNo") = ji.ProfitCenterIdNo
        '        workRow("Notes") = If(ji.Notes, "")
        '        If ji.IdNo <= 0 Then
        '            DtInsertTable.Rows.Add(workRow)
        '        Else
        '            DtUpdateTable.Rows.Add(workRow)
        '        End If
        '        nRowCount = nRowCount + 1
        '    Next
        '    PresenterObj.JournalItemsPresenter.Save(DtInsertTable, DtUpdateTable, IdNo)
        '    Dim newJournalItem As List(Of JournalItemModel)
        '    If AddMode Then
        '        newJournalItem = PresenterObj.JournalItemsPresenter.ModelPresenter.GetRecordsWithIdNo(Of JournalItemModel)(IdNo, "Sequence")
        '        For Each item In newJournalItem
        '            If PresenterObj.JournalItemsPresenter.IsAccountsPayableAccount(item.AccountIdNo) Then
        '                PresenterObj.AddApOpenInvoice(item, "AP")
        '            End If
        '        Next
        '    Else
        '        newJournalItem = PresenterObj.JournalItemsPresenter.ModelPresenter.GetRecordsWithIdNo(Of JournalItemModel)(IdNo, "Sequence")
        '        Dim newItem
        '        Dim oldItem
        '        Dim newIsAp
        '        Dim oldIsAp
        '        For Each oldItem In oldJournalItem
        '            ' deletion of paid A.P. entries not allowed (see UserDeletingRow - sub  below) therefore all entries here are unpaid
        '            ' so no problem on deletion
        '            oldIsAp = PresenterObj.JournalItemsPresenter.IsAccountsPayableAccount(oldItem.AccountIdNo)
        '            If oldIsAp Then
        '                ' this item is AP
        '                newItem = newJournalItem.Find(Function(c) c.IdNo = oldItem.IdNo)
        '                If newItem Is Nothing Then
        '                    ' item was deleted
        '                    PresenterObj.DeleteApOpenInvoice(oldItem.OpenInvoiceIdNo)
        '                Else
        '                    ' item is found
        '                    newIsAp = PresenterObj.JournalItemsPresenter.IsAccountsPayableAccount(newItem.AccountIdNo)
        '                    If newIsAp Then
        '                        ' nothing to do
        '                    Else
        '                        ' new is changed from AP to non-AP
        '                        PresenterObj.DeleteApOpenInvoice(oldItem.OpenInvoiceIdNo)
        '                    End If
        '                End If
        '            Else
        '                ' this item is Non-AP
        '                newItem = newJournalItem.Find(Function(c) c.IdNo = oldItem.IdNo)
        '                If newItem Is Nothing Then
        '                    ' item is deleted just ignore Non-AP
        '                Else
        '                    ' old item still in new
        '                    newIsAp = PresenterObj.JournalItemsPresenter.IsAccountsPayableAccount(newItem.AccountIdNo)
        '                    If newIsAp Then
        '                        PresenterObj.AddApOpenInvoice(newItem, "AP")
        '                    Else
        '                        ' new is also Non-AP
        '                        ' nothing to do
        '                    End If
        '                End If
        '            End If
        '        Next
        '        For Each newItem In newJournalItem
        '            newIsAp = PresenterObj.JournalItemsPresenter.IsAccountsPayableAccount(newItem.AccountIdNo)
        '            oldItem = oldJournalItem.Find(Function(c) c.IdNo = newItem.IdNo)
        '            If oldItem Is Nothing Then
        '                ' this item is new
        '                If newIsAp Then
        '                    ' this new item is an AP
        '                    PresenterObj.AddApOpenInvoice(newItem, "AP")
        '                Else
        '                    ' non - AP nothing to do
        '                End If
        '            Else
        '                ' old item, already taken off in first (oldItem) for-loop
        '            End If
        '        Next
        '    End If

        'End Sub

    End Class

End Namespace