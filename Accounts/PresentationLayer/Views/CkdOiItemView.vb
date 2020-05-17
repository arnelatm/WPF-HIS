Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class CkdOiItemView
        Implements ICkdOiItemView

        Public Property AccountIdNo As Int32? Implements ICkdOiItemView.AccountIdNo

        Public Property Amount As Decimal Implements ICkdOiItemView.Amount

        Public Property Balance As Decimal Implements ICkdOiItemView.Balance

        Public Property CkdIdNo As Integer Implements ICkdOiItemView.CkdIdNo

        Public Property DiscountTaken As Decimal Implements ICkdOiItemView.DiscountTaken

        Public Property IdNo As Integer Implements ICkdOiItemView.IdNo

        Public Property InvoiceNo As String Implements ICkdOiItemView.InvoiceNo

        Public Property JournalCode As String Implements ICkdOiItemView.JournalCode

        Public Property JournalIdNo As Integer Implements ICkdOiItemView.JournalIdNo

        Public Property JournalItemIdNo As Integer Implements ICkdOiItemView.JournalItemIdNo

        Public Property OpenInvoiceIdNo As Integer Implements ICkdOiItemView.OpenInvoiceIdNo

        Public Property PreviousBalance As Decimal Implements ICkdOiItemView.PreviousBalance

        Public Property Sequence As Integer Implements ICkdOiItemView.Sequence

        Public Property TransactionDate As Date? Implements ICkdOiItemView.TransactionDate

        Public Property Errors As List(Of String) Implements IView.Errors

    End Class

End Namespace