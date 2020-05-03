Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class SalesCashItemView
        Implements ISalesCashItemView

        Private ReadOnly _vatRate As Decimal = GlobalFunctions.GetVatPercentage()
        Private _actualBankCharge As Decimal = 0D
        Private _actualBankChargeVat As Decimal = 0D
        Private _computedBankCharge As Decimal = 0D
        Private _computedBankChargeVat As Decimal = 0D
        Private _bankChargeDifference As Decimal = 0D
        Private _bankChargeVatDifference As Decimal = 0D
        Private _saleAmount As Decimal = 0D

        'Private _depositAmount As Decimal = 0D
        Private _rate As Decimal = 0D

        Private ReadOnly _modelCashCode As New ModelAccounts("CashCode")

        Private ReadOnly _cashCodesModel As List(Of CashCodeModel) = _modelCashCode.GetAll(Of CashCodeModel)("CashName")

        Public Property ActualBankCharge As Decimal Implements ISalesCashItemView.ActualBankCharge
            Get
                Return Math.Round((SaleAmount - DepositAmount) / (1D + _vatRate), 2)
            End Get
            Set(value As Decimal)
                _actualBankCharge = value
            End Set
        End Property

        Public Property ActualBankChargeVat As Decimal Implements ISalesCashItemView.ActualBankChargeVat
            Get
                Return SaleAmount - DepositAmount - ActualBankCharge
            End Get
            Set(value As Decimal)
                _actualBankChargeVat = value
            End Set
        End Property

        Public Property BankChargeDifference As Decimal Implements ISalesCashItemView.BankChargeDifference
            Get
                Return ActualBankCharge - ComputedBankCharge
            End Get
            Set(value As Decimal)
                _bankChargeDifference = value
            End Set
        End Property

        Public Property BankChargeVatDifference As Decimal Implements ISalesCashItemView.BankChargeVatDifference
            Get
                Return ActualBankChargeVat - ComputedBankChargeVat
            End Get
            Set(value As Decimal)
                _bankChargeVatDifference = value
            End Set
        End Property

        Public Property DepositAmount As Decimal Implements ISalesCashItemView.DepositAmount
        '    Get
        '        Return SaleAmount - ActualBankCharge - ActualBankChargeVat
        '    End Get
        '    Set(value As Decimal)
        '        _depositAmount = value
        '    End Set
        'End Property

        Public Property CashCode As String Implements ISalesCashItemView.CashCode

        Public Property ComputedBankCharge As Decimal Implements ISalesCashItemView.ComputedBankCharge
            Get
                Return Math.Round(Rate * SaleAmount / 100, 2)
            End Get
            Set(value As Decimal)
                _computedBankCharge = value
            End Set
        End Property

        Public Property ComputedBankChargeVat As Decimal Implements ISalesCashItemView.ComputedBankChargeVat
            Get
                Return Math.Round(ComputedBankCharge * _vatRate, 2)
            End Get
            Set(value As Decimal)
                _computedBankChargeVat = value
            End Set
        End Property

        Public Property IdNo As Integer Implements ISalesCashItemView.IdNo

        Public Property Rate As Decimal Implements ISalesCashItemView.Rate
            Get
                Dim cCashCode As New CashCodeModel
                Dim nIndex As Integer = 0
                cCashCode = _cashCodesModel.Find(Function(cc As CashCodeModel) cc.CashCode.Trim() = CashCode.Trim())
                'If cCashCode IsNot Nothing Then
                Return cCashCode.Rate
                'Else
                'Return 0
                'End If
            End Get
            Set(value As Decimal)
                _rate = value
            End Set
        End Property

        Public Property SaleAmount As Decimal Implements ISalesCashItemView.SaleAmount
            Get
                Return _saleAmount
            End Get
            Set(value As Decimal)
                _saleAmount = value
                _computedBankCharge = ComputedBankCharge
                _actualBankCharge = _computedBankCharge
                _computedBankChargeVat = ComputedBankChargeVat
                _actualBankChargeVat = _computedBankChargeVat
                _DepositAmount = value - _actualBankCharge - _actualBankChargeVat
            End Set
        End Property

        Public Property SalesJournalIdNo As Integer Implements ISalesCashItemView.SalesJournalIdNo

        Public Property Sequence As Integer Implements ISalesCashItemView.Sequence

        Public Property Errors As List(Of String) Implements IView.Errors

        '''' <summary>
        ''''     Displays list of Ap SalesCash Items.
        '''' </summary>
        '''' <param name="salesCashIdNo">SalesCashIDNo id to display.</param>
        'Public Shadows Sub Display(salesCashIdNo As Int32)
        '    View.SalesCashItems = Model.GetRecordsWithIdNo(Of SalesCashItemModel)(salesCashIdNo, "Sequence")
        '    For Each salesCashItem In View.SalesCashItems
        '        Dim cashCode As CashCodeModel
        '        cashCode = _cashCodesModel.Find(Function(cc As CashCodeModel) cc.CashCode.Trim() = salesCashItem.CashCode.Trim())
        '        salesCashItem.Rate = cashCode.Rate
        '        salesCashItem.ActualBankCharge = GetActualBankCharge(salesCashItem.SaleAmount, salesCashItem.DepositAmount)
        '        salesCashItem.ActualBankChargeVat = GetActualBankChargeVat(salesCashItem.SaleAmount, salesCashItem.DepositAmount, salesCashItem.ActualBankCharge)
        '        salesCashItem.ComputedBankCharge = GetComputedBankCharge(salesCashItem.SaleAmount, cashCode.Rate)
        '        salesCashItem.ComputedBankChargeVat = GetComputedBankChargeVat(salesCashItem.ComputedBankCharge)
        '        salesCashItem.BankChargeDifference = salesCashItem.ActualBankCharge - salesCashItem.ComputedBankCharge
        '        salesCashItem.BankChargeVatDifference = salesCashItem.ActualBankChargeVat - salesCashItem.ComputedBankChargeVat
        '    Next
        'End Sub

        'Public Function GetComputedBankCharge(ByRef saleAmount As Decimal, ByRef rate As Decimal)
        '    Return Math.Round(rate * saleAmount / 100, 2)
        'End Function

        'Public Function GetComputedBankChargeVat(computedBankCharge)
        '    Return Math.Round(computedBankCharge * _vatRate, 2)
        'End Function

        'Public Function GetActualBankCharge(ByVal saleAmount As Decimal, ByVal depositAmount As Decimal) As Decimal
        '    Return Math.Round((saleAmount - depositAmount) / (1D + _vatRate), 2)
        'End Function

        'Public Function GetActualBankChargeVat(saleAmount As Decimal, depositAmount As Decimal, actualBankCharge As Decimal) As Decimal
        '    Return (saleAmount - depositAmount - actualBankCharge)
        'End Function

        'Public Function GetSupplierOpenInvoices(ByVal supplierIdNo As Int32) As List(Of SalesCashItemModel)
        '    Return ModelPresenter.GetSupplierOpenInvoices(supplierIdNo)
        'End Function

    End Class

End Namespace