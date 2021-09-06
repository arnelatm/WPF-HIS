Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class PcClosingJournalView
        Implements IPcClosingJournalView

        Public Sub New()
        End Sub

        'Public Property Ea As EventAggregator
        Public Property Amount As Decimal Implements IPcClosingJournalView.Amount

        Public Property CdJournalIdNo As Int32 Implements IPcClosingJournalView.CdJournalIdNo
        Public Property Errors As List(Of String) Implements IView.Errors
        Public Property IdNo As Integer Implements IPcClosingJournalView.IdNo
        Public Property Notes As String Implements IPcClosingJournalView.Notes
        Public Property PayeeName As String Implements IPcClosingJournalView.PayeeName
        Public Property PayeeNameAra As String Implements IPcClosingJournalView.PayeeNameAra
        Public Property PaymentType As String Implements IPcClosingJournalView.PaymentType
        Public Property PayType As String Implements IPcClosingJournalView.PayType
        Public Property PcClosed As Boolean Implements IPcClosingJournalView.PcClosed
        Public Property ReferenceNo As String Implements IPcClosingJournalView.ReferenceNo
        Public Property TransactionDate As Date? Implements IPcClosingJournalView.TransactionDate
    End Class

End Namespace