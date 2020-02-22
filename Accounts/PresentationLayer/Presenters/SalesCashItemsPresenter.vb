Imports System.Windows.Forms
Imports AATM.PresentationLayer.Models
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class SalesCashItemsPresenter
        Inherits AccountsPresenter(Of ISalesCashItemsView, SalesCashItem, SalesCashItemModel)

        Public ParentViewList As List(Of SalesCashItemModel)
        Private ReadOnly _vatRate As Decimal = GetVatPercentage()
        Private _cashCodesModel As List(Of CashCodeModel)

        Public Sub New(view As ISalesCashItemsView)
            MyBase.New(view)
            CurrentModel = New ModelSalesCashItem()
            TableName = "SalesCashItem"
            SortOrderKey = "Sequence"
            BizObject = New SalesCashItem
            DataModel = New SalesCashItemModel
            _cashCodesModel = GetCashCodesModel()
        End Sub

        Public Property ChangesMadeInSalesCashItem As Boolean = False

        Public Overloads Function DataIsValid(ByRef salesCashItems As List(Of SalesCashItemModel), ByRef dataGridView As DataGridView, ByVal appliedAmount As Decimal, ByVal unAppliedAmount As Decimal, ByVal totalBalance As Decimal)
            Dim retVal = True
            'For Each item In SalesCashItems
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
        ''''     Displays list of Ap SalesCash Items.
        '''' </summary>
        '''' <param name="salesCashIdNo">SalesCashIDNo id to display.</param>
        Public Shadows Sub Display(salesCashIdNo As Integer, Optional ByVal undoMode As Boolean = False)
            View.SalesCashItems = Model.GetRecordsWithIdNo(Of SalesCashItemModel)(salesCashIdNo, "Sequence")
            For Each salesCashItem In View.SalesCashItems
                Dim cashCode As CashCodeModel
                cashCode = _cashCodesModel.Find(Function(cc As CashCodeModel) cc.CashCode.Trim() = salesCashItem.CashCode.Trim())
                salesCashItem.Rate = cashCode.Rate
                salesCashItem.ActualBankCharge = GetActualBankCharge(salesCashItem.SaleAmount, salesCashItem.DepositAmount)
                salesCashItem.ActualBankChargeVat = GetActualBankChargeVat(salesCashItem.SaleAmount, salesCashItem.DepositAmount, salesCashItem.ActualBankCharge)
                salesCashItem.ComputedBankCharge = GetComputedBankCharge(salesCashItem.SaleAmount, cashCode.Rate)
                salesCashItem.ComputedBankChargeVat = GetComputedBankChargeVat(salesCashItem.ComputedBankCharge)
                salesCashItem.BankChargeDifference = salesCashItem.ActualBankCharge - salesCashItem.ComputedBankCharge
                salesCashItem.BankChargeVatDifference = salesCashItem.ActualBankChargeVat - salesCashItem.ComputedBankChargeVat
            Next
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

        Public Function GetSalesCashItems(salesCashIdNo As Integer) As List(Of SalesCashItemModel)
            Return Model.GetRecordsWithIdNo(Of SalesCashItemModel)(salesCashIdNo, "Sequence")
        End Function

        Public Function GetSupplierOpenInvoices(ByVal supplierIdNo As Integer) As List(Of SalesCashItemModel)
            Return CurrentModel.GetSupplierOpenInvoices(supplierIdNo)
        End Function

        Public Overloads Function Save(ByRef dtInsert As DataTable, ByRef dtUpdate As DataTable,
                                       salesCashIdNo As Integer)
            Dim insertReturnValue
            Dim updateReturnValue
            Dim retVal
            updateReturnValue = Model.DelUpdateTvp(dtUpdate, salesCashIdNo)
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

        'Private Sub RecomputeBankCharges(bsSalesCashItems As List(Of SalesCashItemModel), pCashCode As String, pSaleAmount As Decimal, pDepositAmount As Decimal)
        '    If pCashCode IsNot Nothing Then
        '        Dim nIndex As Integer = 0
        '        Dim cashCode As Object
        '        cashCode = _cashCodesModel.Find(Function(cc As CashCodeModel) cc.CashCode.Trim() = pCashCode.Trim())
        '        nIndex = selectedRow.Index
        '        bsSalesCashItems(nIndex).Rate = cashCode.Rate
        '        bsSalesCashItems(nIndex).ComputedBankCharge = Math.Round(cashCode.Rate * pSaleAmount / 100, 2)
        '        bsSalesCashItems(nIndex).ComputedBankChargeVat = Math.Round(bsSalesCashItems(nIndex).ComputedBankCharge * _vatRate, 2)
        '        bsSalesCashItems(nIndex).DepositAmount = pSaleAmount - bsSalesCashItems(nIndex).ComputedBankCharge - bsSalesCashItems(nIndex).ComputedBankChargeVat
        '        RecomputeActualBankCharges(selectedRow, pCashCode, pSaleAmount, bsSalesCashItems(nIndex).DepositAmount)
        '        DataGridViewSalesCashItems.Refresh()
        '    End If
        'End Sub

    End Class
End NameSpace