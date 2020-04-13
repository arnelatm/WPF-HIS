Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Forms

    Public Class JournalItemView
        Implements IJournalItemView

        Private _debit As Decimal
        Private _credit As Decimal

        'Public Property Ea As EventAggregator

        Public Property AccountIdNo As Integer Implements IJournalItemView.AccountIdNo

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

        Public Property IdNo As Integer Implements IJournalItemView.IdNo

        Public Property JournalIdNo As Integer Implements IJournalItemView.JournalIdNo
        Public Property Notes As String Implements IJournalItemView.Notes

        Public Property OpenInvoiceIdNo As Integer Implements IJournalItemView.OpenInvoiceIdNo

        Public Property OriginalAmount As Decimal Implements IJournalItemView.OriginalAmount
        Public Property PaidAmount As Decimal Implements IJournalItemView.PaidAmount

        Public Property PayeeType As String Implements IJournalItemView.PayeeType

        Public Property ProfitCenterIdNo As Integer Implements IJournalItemView.ProfitCenterIdNo
        Public Property Sequence As Integer Implements IJournalItemView.Sequence

        Public Property SpecialAccount As String Implements IJournalItemView.SpecialAccount

        Public Property Errors As List(Of String) Implements IView.Errors

    End Class

    'Public Class GeneralJournalItemView
    '    Inherits JournalItemView

    '    Public Sub New()
    '        Ea = New EventAggregator()
    '    End Sub

    'End Class

    'Public Class DebitChanged

    '    Public Sub New(ByVal debit As Decimal)
    '        Me.Debit = debit
    '    End Sub

    '    Public Property Debit As Decimal

    'End Class

    'Public Class CreditChanged

    '    Public Sub New(ByVal credit As Decimal)
    '        Me.Credit = credit
    '    End Sub

    '    Public Property Credit As Decimal

    'End Class

End Namespace