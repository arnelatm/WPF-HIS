Imports System.Windows.Forms
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class AccountReconciliationItemsPresenter
        Inherits AccountsPresenter(Of IAccountReconciliationItemsView, AccountReconciliationItemModel)

        Public ParentViewList As List(Of AccountReconciliationItemModel)
        Private ReadOnly _vatRate As Decimal = GetVatPercentage()
        Private _cashCodesModel As List(Of CashCodeModel)
        Private _modelReconciled

        Public Sub New(view As IAccountReconciliationItemsView)
            MyBase.New(view)
            ModelPresenter = New ModelAccounts("AccountReconciliationItem")
            TableName = "AccountReconciliationItem"
            SortOrderKey = "Sequence"
            DataModel = New AccountReconciliationItemModel
            _cashCodesModel = GetCashCodesModel()
            _modelReconciled = New ModelAccounts("Reconciled")
        End Sub

        Public Property ChangesMadeInAccountReconciliationItems As Boolean = False

        Public Overloads Function DataIsValid(ByRef accountReconciliationItem As List(Of AccountReconciliationItemModel), ByRef dataGridView As DataGridView, ByVal appliedAmount As Decimal, ByVal unAppliedAmount As Decimal, ByVal totalBalance As Decimal)
            Dim retVal = True
            'For Each item In AccountReconciliationItem
            '    If item.Amount <> 0 Or item.DiscountTaken <> 0 Then
            '        If (item.Amount + item.DiscountTaken > item.PreviousBalance And item.PreviousBalance > 0) Or
            '           (item.Amount + item.DiscountTaken < item.PreviousBalance And item.PreviousBalance < 0) Then
            '            Dim errorMsg = String.Format("Error in line {0:N0}. Applied amount and discount exceeds balance.", item.Sequence.ToString())
            '            MessageBox.Show(errorMsg)
            '            dataGridView.Rows(item.Sequence - 1).ErrorText = errorMsg
            '            retVal = False
            '            Exit For
            '        Else
            '            ' clear error message
            '            dataGridView.Rows(item.Sequence - 1).ErrorText = ""
            '        End If
            '    End If
            'Next
            'If retVal Then
            '    If unAppliedAmount <> 0 Then
            '        If totalBalance > 0 Then
            '            If unAppliedAmount > 0 Then
            '                MessageBox.Show($"Payment not yet fully applied. Cannot save entry unless amount is fully applied.")
            '                retVal = False
            '            Else
            '                MessageBox.Show($"Payment is over applied. Cannot save entry please reduce the applied payment.")
            '                retVal = False
            '            End If
            '        Else
            '            If MessageBox.Show($"Amount not yet fully applied or no more unpaid invoices for this supplier. Do you want to make the excess payment as an advance payment?", $"Save Advance Payment",
            '                               MessageBoxButtons.YesNo,
            '                               MessageBoxIcon.Warning,
            '                               MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            '                retVal = True
            '            Else
            '                retVal = False
            '            End If
            '        End If
            '    Else
            '        retVal = True
            '    End If
            'End If
            Return retVal
        End Function

        '''' <summary>
        ''''     Displays list of Ap AccountReconciliation Items.
        '''' </summary>
        '''' <param name="accountIdNo">Account Id to display.</param>
        Public Overloads Sub Display(ByVal accountIdNo As Integer, ByVal reconciliationDate As Date, ByVal addMode As Boolean, ByVal editMode As Boolean, ByVal idNo As Integer, Optional ByVal sortOrder As String = Nothing)
            View.AccountReconciliationItems = GetAcctReconItems(accountIdNo, reconciliationDate, addMode, editMode, idNo, "TransactionDate")
        End Sub

        Public Function GetAcctReconItems(ByVal accountIdNo As Integer, ByVal reconciliationDate As Date, ByVal addMode As Boolean, ByVal editMode As Boolean, ByVal idNo As Integer, ByVal Optional sortOrder As String = Nothing) As List(Of AccountReconciliationItemModel)
            Dim acctReconItems As New List(Of AccountReconciliationItemModel)
            Dim nSeq As Integer = 0
            'If addMode Or editMode Then
            Dim allAcctReconItems = DataModel.GetAcctReconItems(accountIdNo, reconciliationDate, sortOrder)
            If addMode Then
                For Each acctReconItem In allAcctReconItems
                    AddNewItem(acctReconItem, acctReconItems, nSeq)
                Next
            Else 'If editMode Then
                Dim oldReconciliationItems As New List(Of AccountReconciliationItemModel)
                oldReconciliationItems = ModelPresenter.GetRecordsWithIdNo(Of AccountReconciliationItemModel)(idNo, "TransactionDate")
                For Each acctReconItem In allAcctReconItems
                    Dim found As Boolean = False
                    For Each item As AccountReconciliationItemModel In oldReconciliationItems
                        If item.JournalCode = acctReconItem.JournalCode And
                           item.JournalItemIdNo = acctReconItem.JournalItemIdNo Then
                            found = True
                            Exit For
                        End If
                    Next
                    nSeq = nSeq + 1
                    If Not found Then
                        AddNewItem(acctReconItem, acctReconItems, nSeq)
                    End If
                Next
                'Dim oldUnreconciledAcctReconItems As New List(Of AccountReconciliationItemModel)
                'Dim oldReconciledAcctReconItems As New List(Of AccountReconciliationItemModel)
                For Each reconciledItem As AccountReconciliationItemModel In oldReconciliationItems
                    AddNewItem(reconciledItem, acctReconItems, nSeq)
                    nSeq = nSeq + 1
                Next
                'oldUnreconciledAcctReconItems = Model.GetReconciledRecordsWithIdNo(False, idNo, sortOrder)
                'oldReconciledAcctReconItems = Model.GetReconciledRecordsWithIdNo(True, idNo, sortOrder)
                'Dim newAcctReconItem As New AccountReconciliationItemModel
                'Dim oldAcctReconItem As New AccountReconciliationItemModel
                'For Each reconciledItem As AccountReconciliationItemModel In oldReconciledAcctReconItems
                '    AddNewItem(reconciledItem, acctReconItems, nSeq)
                '    nSeq = nSeq + 1
                'Next
                'oldReconciledAcctReconItems.Clear()
                'For Each acctReconItem In allAcctReconItems
                '    Dim found As Boolean = False
                '    For Each item As AccountReconciliationItemModel In oldUnreconciledAcctReconItems
                '        If item.JournalCode = acctReconItem.JournalCode And
                '           item.JournalItemIdNo = acctReconItem.JournalItemIdNo Then
                '            found = True
                '            oldAcctReconItem = item
                '            Exit For
                '        End If
                '    Next
                '    nSeq = nSeq + 1
                '    If found Then
                '        AddNewItem(oldAcctReconItem, acctReconItems, nSeq)
                '    Else
                '        AddNewItem(acctReconItem, acctReconItems, nSeq)
                '    End If
                'Next
            End If
            'Else
            '    acctReconItems = Model.GetRecordsWithIdNo(Of AccountReconciliationItemModel)(idNo, sortOrder)
            'End If
            Return acctReconItems
        End Function

        Private Sub AddNewItem(acctReconItem As AccountReconciliationItemModel, actualReconItems As List(Of AccountReconciliationItemModel), nSeq As Integer)
            Dim item As New AccountReconciliationItemModel With {
                    .AccountIdNo = acctReconItem.AccountIdNo,
                    .AccountReconciliationIdNo = acctReconItem.AccountReconciliationIdNo,
                    .Cleared = acctReconItem.Cleared,
                    .Credit = acctReconItem.Credit,
                    .Debit = acctReconItem.Debit,
                    .DocumentNumber = acctReconItem.DocumentNumber,
                    .IdNo = acctReconItem.IdNo,
                    .JournalCode = acctReconItem.JournalCode,
                    .JournalIdNo = acctReconItem.JournalIdNo,
                    .JournalItemIdNo = acctReconItem.JournalItemIdNo,
                    .PayDescription = IIf(GlobalVariables.RightToLeftLayout, acctReconItem.PayDescriptionAra, acctReconItem.PayDescription),
                    .PayDescriptionAra = acctReconItem.PayDescriptionAra,
                    .ReferenceNo = acctReconItem.ReferenceNo,
                    .TransactionDate = acctReconItem.TransactionDate,
                    .Sequence = nSeq}
            actualReconItems.Add(item)
        End Sub

        Public Function GetComputedBankCharge(ByRef saleAmount As Decimal, ByRef rate As Decimal)
            Return Math.Round(rate * saleAmount / 100, 2)
        End Function

        Public Function GetComputedBankChargeVat(computedBankCharge)
            Return Math.Round(computedBankCharge * _vatRate, 2)
        End Function

        Public Function GetActualBankCharge(ByVal saleAmount As Decimal, ByVal depositAmount As Decimal) As Decimal
            Return Math.Round((saleAmount - depositAmount) / (1D + _vatRate), 2)
        End Function

        Public Function GetActualBankChargeVat(saleAmount As Decimal, depositAmount As Decimal, actualBankCharge As Decimal) As Decimal
            Return (saleAmount - depositAmount - actualBankCharge)
        End Function

        Public Overloads Function Save(ByRef dtInsert As DataTable, ByRef dtUpdate As DataTable,
                                       accountReconciliationIdNo As Integer)
            Dim insertReturnValue
            Dim updateReturnValue
            Dim retVal
            updateReturnValue = Model.DelUpdateTvp(dtUpdate, accountReconciliationIdNo)
            If updateReturnValue >= 0 AndAlso dtInsert.Rows.Count > 0 Then
                insertReturnValue = Model.InsertTvp(dtInsert)
                If insertReturnValue >= 0 Then
                    retVal = updateReturnValue + insertReturnValue
                Else
                    retVal = insertReturnValue
                End If
            Else
                retVal = updateReturnValue
            End If
            Return retVal
        End Function

        Public Overloads Function SaveReconciliation(ByRef dtInsert As DataTable, ByVal accountReconciliationIdNo As Integer)
            Dim insertReturnValue
            Dim retVal = -1
            If dtInsert.Rows.Count > 0 Then
                insertReturnValue = _modelReconciled.InsertTvp(dtInsert)
                If insertReturnValue >= 0 Then
                    retVal = insertReturnValue
                Else
                    retVal = insertReturnValue
                End If
            Else
                Return 0
            End If
            Return retVal
        End Function

        'Private Sub RecomputeBankCharges(bsAccountReconciliationItem As List(Of AccountReconciliationItemModel), pCashCode As String, pSaleAmount As Decimal, pDepositAmount As Decimal)
        '    If pCashCode IsNot Nothing Then
        '        Dim nIndex As Integer = 0
        '        Dim cashCode As Object
        '        cashCode = _cashCodesModel.Find(Function(cc As CashCodeModel) cc.CashCode.Trim() = pCashCode.Trim())
        '        nIndex = selectedRow.Index
        '        bsAccountReconciliationItem(nIndex).Rate = cashCode.Rate
        '        bsAccountReconciliationItem(nIndex).ComputedBankCharge = Math.Round(cashCode.Rate * pSaleAmount / 100, 2)
        '        bsAccountReconciliationItem(nIndex).ComputedBankChargeVat = Math.Round(bsAccountReconciliationItem(nIndex).ComputedBankCharge * _vatRate, 2)
        '        bsAccountReconciliationItem(nIndex).DepositAmount = pSaleAmount - bsAccountReconciliationItem(nIndex).ComputedBankCharge - bsAccountReconciliationItem(nIndex).ComputedBankChargeVat
        '        RecomputeActualBankCharges(selectedRow, pCashCode, pSaleAmount, bsAccountReconciliationItem(nIndex).DepositAmount)
        '        DataGridViewAccountReconciliationItem.Refresh()
        '    End If
        'End Sub

    End Class

End Namespace