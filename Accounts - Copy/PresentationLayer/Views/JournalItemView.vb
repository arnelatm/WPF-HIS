Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class JournalItemView
        Implements IJournalItemView

        Private _debit As Decimal
        Private _credit As Decimal
        Private _lastRow As Integer
        Private _sequence As Integer

        Public Sub New()
        End Sub

        'Public Property Ea As EventAggregator

        Public Property AccountIdNo As Int16? Implements IJournalItemView.AccountIdNo

        Public Property AccountName As String Implements IJournalItemView.AccountName

        Public Property Cancelled As Boolean Implements IJournalItemView.Cancelled

        Public Property Credit As Decimal Implements IJournalItemView.Credit
            Get
                Return _credit
            End Get
            Set(value As Decimal)
                If value > 0 Then
                    _credit = value
                    Debit = 0
                ElseIf value < 0 Then
                    _credit = 0
                    Debit = Math.Abs(value)
                Else
                    _credit = 0
                End If
            End Set
        End Property

        Public Property Debit As Decimal Implements IJournalItemView.Debit
            Get
                Return _debit
            End Get
            Set(value As Decimal)
                If value > 0 Then
                    _debit = value
                    Credit = 0
                ElseIf value < 0 Then
                    _debit = 0
                    Credit = Math.Abs(value)
                Else
                    _debit = 0
                End If
            End Set
        End Property

        Public Property DiscountTaken As Decimal Implements IJournalItemView.DiscountTaken

        Public Property IdNo As Int32 Implements IJournalItemView.IdNo

        Public Property JournalIdNo As Int32 Implements IJournalItemView.JournalIdNo
        Public Property Notes As String Implements IJournalItemView.Notes

        Public Property OpenInvoiceIdNo As Int32 Implements IJournalItemView.OpenInvoiceIdNo

        Public Property OriginalAmount As Decimal Implements IJournalItemView.OriginalAmount
        Public Property PaidAmount As Decimal Implements IJournalItemView.PaidAmount

        Public Property PayeeType As String Implements IJournalItemView.PayeeType
        Public Property PayIdNo As Int32 Implements IJournalItemView.PayIdNo

        Public Property RevCostCenterIdNo As Int16 Implements IJournalItemView.RevCostCenterIdNo

        Public Property Sequence As Int16 Implements IJournalItemView.Sequence
            Get
                Return _sequence
            End Get
            Set(value As Int16)
                _sequence = value
                If value > _lastRow Then
                    _lastRow = value + 1
                End If
            End Set
        End Property

        Public Property SpecialAccount As String Implements IJournalItemView.SpecialAccount

        Public Property Errors As List(Of String) Implements IView.Errors

    End Class

End Namespace