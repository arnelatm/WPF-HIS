Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class PcJournalView
        Implements IPcJournalView

        Public Sub New()
        End Sub

        'Public Property Ea As EventAggregator

        Public Property Errors As List(Of String) Implements IView.Errors
        Public Property AccountIdNo As Short? Implements IPcJournalView.AccountIdNo
        Public Property Amount As Decimal Implements IPcJournalView.Amount
        Public Property Applied As Decimal Implements IPcJournalView.Applied
        Public Property Cancelled As Boolean Implements IPcJournalView.Cancelled
        Public Property DateCreated As Date? Implements IPcJournalView.DateCreated
        Public Property DiscountAccountIdNo As Short? Implements IPcJournalView.DiscountAccountIdNo
        Public Property DiscountTaken As Decimal Implements IPcJournalView.DiscountTaken
        Public Property IdNo As Integer Implements IPcJournalView.IdNo
        Public Property Notes As String Implements IPcJournalView.Notes
        Public Property OrNumber As String Implements IPcJournalView.OrNumber
        Public Property PayeeIdNo As Integer? Implements IPcJournalView.PayeeIdNo
        Public Property PayeeName As String Implements IPcJournalView.PayeeName
        Public Property PayeeNameAra As String Implements IPcJournalView.PayeeNameAra
        Public Property PaymentType As String Implements IPcJournalView.PaymentType
        Public Property PayType As String Implements IPcJournalView.PayType
        Public Property PcClosed As Boolean Implements IPcJournalView.PcClosed
        Public Property Posted As Boolean Implements IPcJournalView.Posted
        Public Property ReferenceNo As String Implements IPcJournalView.ReferenceNo
        Public Property TotalCredits As Decimal Implements IPcJournalView.TotalCredits
        Public Property TotalDebits As Decimal Implements IPcJournalView.TotalDebits
        Public Property TransactionDate As Date? Implements IPcJournalView.TransactionDate
        Public Property UnApplied As Decimal Implements IPcJournalView.UnApplied
        Public Property VatAmount As Decimal Implements IPcJournalView.VatAmount
        Public Property VatNumber As String Implements IPcJournalView.VatNumber
    End Class

End Namespace