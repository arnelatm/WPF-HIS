Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class SalesDepositView
        Implements ISalesDepositView

        Private ReadOnly _vatRate As Decimal = GlobalVariables.VatRate() / 100D
        Private _computedBankCharge As Decimal = 0D
        Private _computedBankChargeVat As Decimal = 0D
        Private _bankChargeDifference As Decimal = 0D
        Private _bankChargeVatDifference As Decimal = 0D
        Private _actualBankCharge As Decimal = 0D

        'Private _saleAmount As Decimal = 0D
        Private ReadOnly _modelDepositType As New ModelAccounts("DepositType")

        Public Property ActualBankCharge As Decimal Implements ISalesDepositView.ActualBankCharge
            Get
                Return (SaleAmount - DepositAmount - VatAmount)
            End Get
            Set(value As Decimal)
                _actualBankCharge = value
            End Set
        End Property

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
                Return VatAmount - ComputedBankChargeVat
            End Get
            Set(value As Decimal)
                _bankChargeVatDifference = value
            End Set
        End Property

        Public Property DepositAmount As Decimal Implements ISalesDepositView.DepositAmount

        Public Property DepositTypeIdNo As Int16 Implements ISalesDepositView.DepositTypeIdNo

        Public Property ComputedBankCharge As Decimal Implements ISalesDepositView.ComputedBankCharge
            Get
                Return Math.Round(Rate * SaleAmount / 100D, 2)
            End Get
            Set(value As Decimal)
                _computedBankCharge = value
            End Set
        End Property

        Public Property ComputedBankChargeVat As Decimal Implements ISalesDepositView.ComputedBankChargeVat
            Get
                Return Math.Round(Math.Floor(ComputedBankCharge * _vatRate * 100) / 100, 2)
            End Get
            Set(value As Decimal)
                _computedBankChargeVat = value
            End Set
        End Property

        Public Property IdNo As Integer Implements ISalesDepositView.IdNo

        Public Property Rate As Decimal Implements ISalesDepositView.Rate

        Public Property SaleAmount As Decimal Implements ISalesDepositView.SaleAmount
        '    Get
        '        Return _saleAmount
        '    End Get
        '    Set(value As Decimal)
        '        If value <> _saleAmount Then
        '            _saleAmount = value
        '            ComputedBankCharge = Math.Round(Rate * value / 100D, 2)
        '            ComputedBankChargeVat = Math.Floor(ComputedBankCharge * _vatRate) / 100D
        '            'ActualBankCharge = ComputedBankCharge
        '            'VatAmount = ComputedBankChargeVat
        '            'DepositAmount = value - ActualBankCharge - VatAmount
        '        End If
        '    End Set
        'End Property

        Public Property SalesJournalIdNo As Integer Implements ISalesDepositView.SalesJournalIdNo
        '    Get
        '        Return _saleAmount
        '    End Get
        '    Set(value As Integer)
        '        If value <> _saleAmount Then
        '            _saleAmount = value
        '            ComputedBankCharge = Math.Round(Rate * value / 100D, 2)
        '            ComputedBankChargeVat = Math.Floor(ComputedBankCharge * _vatRate) / 100D
        '            ActualBankCharge = ComputedBankCharge
        '            VatAmount = ComputedBankChargeVat
        '            DepositAmount = value - ActualBankCharge - VatAmount
        '        End If
        '    End Set
        'End Property

        Public Property Sequence As Int16 Implements ISalesDepositView.Sequence
        Public Property VatAmount As Decimal Implements ISalesDepositView.VatAmount

        Public Property Errors As List(Of String) Implements IView.Errors

        'Public Function GetComputedBankCharge(pSaleAmount As Decimal, pRate As Decimal)
        '    Return Math.Round(pRate * pSaleAmount / 100, 2)
        'End Function

        'Public Function GetComputedBankChargeVat(pBankCharge)
        '    Return Math.Round(pBankCharge * _vatRate, 2)
        'End Function

    End Class

End Namespace