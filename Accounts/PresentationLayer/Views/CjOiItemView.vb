Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class CjOiItemView
        Implements ICjOiItemView

        Public Property AccountIdNo As Int16? Implements ICjOiItemView.AccountIdNo
        Public Property Amount As Decimal Implements ICjOiItemView.Amount
        Public Property ApOpenInvoiceIdNo As Int32 Implements ICjOiItemView.ApOpenInvoiceIdNo
        Public Property Balance As Decimal Implements ICjOiItemView.Balance
        Public Property CjIdNo As Int32 Implements ICjOiItemView.CjIdNo
        Public Property DiscountTaken As Decimal Implements ICjOiItemView.DiscountTaken
        Public Property IdNo As Int32 Implements ICjOiItemView.IdNo
        Public Property InvoiceNo As String Implements ICjOiItemView.InvoiceNo
        Public Property JournalCode As String Implements ICjOiItemView.JournalCode
        Public Property JournalIdNo As Int32 Implements ICjOiItemView.JournalIdNo
        Public Property PreviousBalance As Decimal Implements ICjOiItemView.PreviousBalance
        Public Property Sequence As Int16 Implements ICjOiItemView.Sequence
        Public Property TransactionDate As Date? Implements ICjOiItemView.TransactionDate
        Public Property Errors As List(Of String) Implements IView.Errors

    End Class

End Namespace