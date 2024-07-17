Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class CsrOiItemView
        Implements ICsrOiItemView
        Public Property AccountIdNo As Int16? Implements ICsrOiItemView.AccountIdNo
        Public Property Amount As Decimal Implements ICsrOiItemView.Amount
        Public Property ArOpenInvoiceIdNo As Integer Implements ICsrOiItemView.ArOpenInvoiceIdNo
        Public Property Balance As Decimal Implements ICsrOiItemView.Balance
        Public Property CsrIdNo As Integer Implements ICsrOiItemView.CsrIdNo
        Public Property DiscountTaken As Decimal Implements ICsrOiItemView.DiscountTaken
        Public Property IdNo As Integer Implements ICsrOiItemView.IdNo
        Public Property InvoiceNo As String Implements ICsrOiItemView.InvoiceNo
        Public Property JournalCode As String Implements ICsrOiItemView.JournalCode
        Public Property JournalIdNo As Integer Implements ICsrOiItemView.JournalIdNo
        Public Property PreviousBalance As Decimal Implements ICsrOiItemView.PreviousBalance
        Public Property Sequence As Int16 Implements ICsrOiItemView.Sequence
        Public Property TransactionDate As Date? Implements ICsrOiItemView.TransactionDate
        Public Property DataFilter As String Implements IView.DataFilter
        Public Property Errors As List(Of String) Implements IView.Errors


    End Class

End Namespace