Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class SalesDepositView
        Implements ISalesDepositView, ISelfDuplicating

        Private ReadOnly _vatRate As Decimal = GlobalFunctions.GetVatPercentage()
        Private _computedBankCharge As Decimal = 0D
        Private _computedBankChargeVat As Decimal = 0D
        Private _bankChargeDifference As Decimal = 0D
        Private _bankChargeVatDifference As Decimal = 0D
        Private ReadOnly _modelPaymentType As New ModelAccounts("PaymentType")
        Private ReadOnly _paymentTypesModel As List(Of PaymentTypeModel) = _modelPaymentType.GetAll(Of PaymentTypeModel)("PaymentTypeName")
        Public Property ActualBankCharge As Decimal Implements ISalesDepositView.ActualBankCharge

        Public Property ActualBankChargeVat As Decimal Implements ISalesDepositView.ActualBankChargeVat

        Public Property BankChargeDifference As Decimal Implements ISalesDepositView.BankChargeDifference
            Get
                Return ActualBankCharge - ComputedBankCharge
            End Get
            Set(value As Decimal)
                _bankChargeDifference = value
            End Set
        End Property

        Public Property BankChargeVatDifference As Decimal Implements ISalesDepositView.BankChargeVatDifference
            Get
                Return ActualBankChargeVat - ComputedBankChargeVat
            End Get
            Set(value As Decimal)
                _bankChargeVatDifference = value
            End Set
        End Property

        Public Property DepositAmount As Decimal Implements ISalesDepositView.DepositAmount

        Public Property PaymentTypeIdNo As Int16 Implements ISalesDepositView.PaymentTypeIdNo

        Public Property ComputedBankCharge As Decimal Implements ISalesDepositView.ComputedBankCharge
            Get
                Return Math.Round(Rate * SaleAmount / 100, 2)
            End Get
            Set(value As Decimal)
                _computedBankCharge = value
            End Set
        End Property

        Public Property ComputedBankChargeVat As Decimal Implements ISalesDepositView.ComputedBankChargeVat
            Get
                Return Math.Round(ComputedBankCharge * _vatRate, 2)
            End Get
            Set(value As Decimal)
                _computedBankChargeVat = value
            End Set
        End Property

        Public Property IdNo As Integer Implements ISalesDepositView.IdNo

        Public Property Rate As Decimal Implements ISalesDepositView.Rate

        Public Property SaleAmount As Decimal Implements ISalesDepositView.SaleAmount

        Public Property SalesJournalIdNo As Integer Implements ISalesDepositView.SalesJournalIdNo

        Public Property Sequence As Int16 Implements ISalesDepositView.Sequence

        Public Property Errors As List(Of String) Implements IView.Errors

        'Public Function GetComputedBankCharge(pSaleAmount As Decimal, pRate As Decimal)
        '    Return Math.Round(pRate * pSaleAmount / 100, 2)
        'End Function

        'Public Function GetComputedBankChargeVat(pBankCharge)
        '    Return Math.Round(pBankCharge * _vatRate, 2)
        'End Function

        Public Function BlankCopy() As Object Implements ISelfDuplicating.BlankCopy
            Return New SalesDepositView
        End Function

    End Class

End Namespace