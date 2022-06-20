Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class AccountReconciliationItemsPresenter
        Inherits AccountsPresenterNew(Of IAccountReconciliationItemsView, AccountReconciliationItemModel)

        Public ParentViewList As List(Of AccountReconciliationItemModel)
        Private ReadOnly _vatRate As Decimal = GlobalVariables.VatRate() / 100D
        Private _modelReconciled

        Public Sub New(view As IAccountReconciliationItemsView)
            MyBase.New(view)
            Service = New AccountsService("AccountReconciliationItem")
            TableName = "AccountReconciliationItem"
            SortOrderKey = "Sequence"
            '_paymentTypesModel = GetPaymentTypesModel()
            _modelReconciled = New AccountsService("Reconciled")
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
        End Sub

        Public Property ChangesMadeInAccountReconciliationItems As Boolean = False

        'Public Overloads Function DataIsValid(ByRef accountReconciliationItem As List(Of AccountReconciliationItemModel), ByRef dataGridView As DataGridView, ByVal appliedAmount As Decimal, ByVal unAppliedAmount As Decimal, ByVal totalBalance As Decimal)
        '    Dim retVal = True
        '    'For Each item In AccountReconciliationItem
        '    '    If item.Amount <> 0 Or item.DiscountTaken <> 0 Then
        '    '        If (item.Amount + item.DiscountTaken > item.PreviousBalance And item.PreviousBalance > 0) Or
        '    '           (item.Amount + item.DiscountTaken < item.PreviousBalance And item.PreviousBalance < 0) Then
        '    '            Dim errorMsg = String.Format("Error in line {0:N0}. Applied amount and discount exceeds balance.", item.Sequence.ToString())
        '    '            MessageBox.Show(errorMsg)
        '    '            dataGridView.Rows(item.Sequence - 1).ErrorText = errorMsg
        '    '            retVal = False
        '    '            Exit For
        '    '        Else
        '    '            ' clear error message
        '    '            dataGridView.Rows(item.Sequence - 1).ErrorText = ""
        '    '        End If
        '    '    End If
        '    'Next
        '    'If retVal Then
        '    '    If unAppliedAmount <> 0 Then
        '    '        If totalBalance > 0 Then
        '    '            If unAppliedAmount > 0 Then
        '    '                MessageBox.Show($"Payment not yet fully applied. Cannot save entry unless amount is fully applied.")
        '    '                retVal = False
        '    '            Else
        '    '                MessageBox.Show($"Payment is over applied. Cannot save entry please reduce the applied payment.")
        '    '                retVal = False
        '    '            End If
        '    '        Else
        '    '            If MessageBox.Show($"Amount not yet fully applied or no more unpaid invoices for this supplier. Do you want to make the excess payment as an advance payment?", $"Save Advance Payment",
        '    '                               MessageBoxButtons.YesNo,
        '    '                               MessageBoxIcon.Warning,
        '    '                               MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
        '    '                retVal = True
        '    '            Else
        '    '                retVal = False
        '    '            End If
        '    '        End If
        '    '    Else
        '    '        retVal = True
        '    '    End If
        '    'End If
        '    Return retVal
        'End Function

        '''' <summary>
        ''''     Displays list of Ap AccountReconciliation Items.
        '''' </summary>
        '''' <param name="accountIdNo">Account Id to display.</param>
        Public Overloads Sub Display(ByVal AccountIdNo As Int16, ByVal reconciliationDate As Date, ByVal idNo As Int32, Optional ByVal sortOrder As String = Nothing)
            View.AccountReconciliationItems = GetAcctReconItems(AccountIdNo, reconciliationDate, idNo, "TransactionDate")
        End Sub

        Public Function GetAcctReconItems(ByVal AccountIdNo As Int16, ByVal reconciliationDate As Date, ByVal idNo As Int32, ByVal Optional sortOrder As String = Nothing) As List(Of AccountReconciliationItemModel)
            Dim acctReconItems As New List(Of AccountReconciliationItemModel)
            Dim nSeq As Integer = 0
            'If Presenter.AddMode Or Presenter.EditMode Then
            Dim allAcctReconItems = Service.GetAcctReconItems(Of AccountReconciliationItemModel)(AccountIdNo, reconciliationDate, sortOrder)
            If AddMode Then
                For Each acctReconItem In allAcctReconItems
                    AddNewItem(acctReconItem, acctReconItems, nSeq)
                Next
            Else
                Dim oldReconciliationItems As New List(Of AccountReconciliationItemModel)
                oldReconciliationItems = Service.GetRecordsWithGroupIdNo(Of AccountReconciliationItemModel)(idNo, "TransactionDate")
                For Each acctReconItem In allAcctReconItems
                    Dim found As Boolean = False
                    For Each item As AccountReconciliationItemModel In oldReconciliationItems
                        If item.JournalCode = acctReconItem.JournalCode And
                           item.JournalItemIdNo = acctReconItem.JournalItemIdNo Then
                            found = True
                            Exit For
                        End If
                    Next
                    nSeq += 1
                    If Not found Then
                        AddNewItem(acctReconItem, acctReconItems, nSeq)
                    End If
                Next
                For Each reconciledItem As AccountReconciliationItemModel In oldReconciliationItems
                    AddNewItem(reconciledItem, acctReconItems, nSeq)
                    nSeq += 1
                Next
            End If
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

        Public Overloads Function Save(ByRef dtInsert As DataTable, ByRef dtUpdate As DataTable,
                                       accountReconciliationIdNo As Int32)
            Dim insertReturnValue
            Dim updateReturnValue
            Dim retVal
            updateReturnValue = Service.DelUpdateTvp(dtUpdate, accountReconciliationIdNo)
            If updateReturnValue >= 0 Then
                If dtInsert.Rows.Count > 0 Then
                    insertReturnValue = Service.InsertTvp(dtInsert)
                    If insertReturnValue >= 0 Then
                        retVal = updateReturnValue + insertReturnValue
                    Else
                        retVal = insertReturnValue
                    End If
                Else
                    retVal = updateReturnValue
                End If
            Else
                retVal = updateReturnValue
            End If
            Return retVal
        End Function

        'Private Sub RecomputeBankCharges(bsAccountReconciliationItem As List(Of AccountReconciliationItemModel), pCashCode As String, pSaleAmount As Decimal, pDepositAmount As Decimal)
        '    If pCashCode IsNot Nothing Then
        '        Dim nIndex As Integer = 0
        '        Dim paymentType As Object
        '        paymentType = _paymentTypesModel.Find(Function(cc As DepositTypeModel) cc.CashCode.Trim() = pCashCode.Trim())
        '        nIndex = selectedRow.Index
        '        bsAccountReconciliationItem(nIndex).Rate = paymentType.Rate
        '        bsAccountReconciliationItem(nIndex).ComputedBankCharge = Math.Round(paymentType.Rate * pSaleAmount / 100, 2)
        '        bsAccountReconciliationItem(nIndex).ComputedBankChargeVat = Math.Round(bsAccountReconciliationItem(nIndex).ComputedBankCharge * _vatRate, 2)
        '        bsAccountReconciliationItem(nIndex).DepositAmount = pSaleAmount - bsAccountReconciliationItem(nIndex).ComputedBankCharge - bsAccountReconciliationItem(nIndex).ComputedBankChargeVat
        '        RecomputeActualBankCharges(selectedRow, pCashCode, pSaleAmount, bsAccountReconciliationItem(nIndex).DepositAmount)
        '        DataGridViewAccountReconciliationItem.Refresh()
        '    End If
        'End Sub

    End Class

End Namespace