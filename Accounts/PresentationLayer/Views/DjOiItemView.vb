Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class DjOiItemView
        Implements IDjOiItemView

        Public Property AccountIdNo As Int16? Implements IDjOiItemView.AccountIdNo
        Public Property Amount As Decimal Implements IDjOiItemView.Amount
        Public Property ApOpenInvoiceIdNo As Int32 Implements IDjOiItemView.ApOpenInvoiceIdNo
        Public Property Balance As Decimal Implements IDjOiItemView.Balance
        Public Property DjIdNo As Int32 Implements IDjOiItemView.DjIdNo
        Public Property DiscountTaken As Decimal Implements IDjOiItemView.DiscountTaken
        Public Property IdNo As Int32 Implements IDjOiItemView.IdNo
        Public Property InvoiceNo As String Implements IDjOiItemView.InvoiceNo
        Public Property JournalCode As String Implements IDjOiItemView.JournalCode
        Public Property JournalIdNo As Int32 Implements IDjOiItemView.JournalIdNo
        Public Property PreviousBalance As Decimal Implements IDjOiItemView.PreviousBalance
        Public Property Sequence As Int16 Implements IDjOiItemView.Sequence
        Public Property TransactionDate As Date? Implements IDjOiItemView.TransactionDate
        Public Property Errors As List(Of String) Implements IView.Errors

    End Class

End Namespace