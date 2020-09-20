Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class SalesCashItemView
        Implements ISalesCashItemView

        Private ReadOnly _vatRate As Decimal = GlobalFunctions.GetVatPercentage()
        Private _computedBankCharge As Decimal = 0D
        Private _computedBankChargeVat As Decimal = 0D
        Private _bankChargeDifference As Decimal = 0D
        Private _bankChargeVatDifference As Decimal = 0D
        Private ReadOnly _modelCashCode As New ModelAccounts("CashCode")
        Private ReadOnly _cashCodesModel As List(Of CashCodeModel) = _modelCashCode.GetAll(Of CashCodeModel)("CashName")
        Public Property ActualBankCharge As Decimal Implements ISalesCashItemView.ActualBankCharge

        Public Property ActualBankChargeVat As Decimal Implements ISalesCashItemView.ActualBankChargeVat

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

        Public Property CashCode As Char Implements ISalesCashItemView.CashCode

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

        Public Property SaleAmount As Decimal Implements ISalesCashItemView.SaleAmount

        Public Property SalesJournalIdNo As Integer Implements ISalesCashItemView.SalesJournalIdNo

        Public Property Sequence As Int16 Implements ISalesCashItemView.Sequence

        Public Property Errors As List(Of String) Implements IView.Errors

        'Public Function GetComputedBankCharge(pSaleAmount As Decimal, pRate As Decimal)
        '    Return Math.Round(pRate * pSaleAmount / 100, 2)
        'End Function

        'Public Function GetComputedBankChargeVat(pBankCharge)
        '    Return Math.Round(pBankCharge * _vatRate, 2)
        'End Function

    End Class

End Namespace