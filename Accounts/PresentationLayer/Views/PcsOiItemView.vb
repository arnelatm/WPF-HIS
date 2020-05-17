Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class PcsOiItemView
        Implements IPcsOiItemView

        Public Property AccountIdNo As Int32? Implements IPcsOiItemView.AccountIdNo

        Public Property Amount As Decimal Implements IPcsOiItemView.Amount

        Public Property Balance As Decimal Implements IPcsOiItemView.Balance

        Public Property PcsIdNo As Integer Implements IPcsOiItemView.PcsIdNo

        Public Property DiscountTaken As Decimal Implements IPcsOiItemView.DiscountTaken

        Public Property IdNo As Integer Implements IPcsOiItemView.IdNo

        Public Property InvoiceNo As String Implements IPcsOiItemView.InvoiceNo

        Public Property JournalCode As String Implements IPcsOiItemView.JournalCode

        Public Property JournalIdNo As Integer Implements IPcsOiItemView.JournalIdNo

        Public Property JournalItemIdNo As Integer Implements IPcsOiItemView.JournalItemIdNo

        Public Property OpenInvoiceIdNo As Integer Implements IPcsOiItemView.OpenInvoiceIdNo

        Public Property PreviousBalance As Decimal Implements IPcsOiItemView.PreviousBalance

        Public Property Sequence As Integer Implements IPcsOiItemView.Sequence

        Public Property TransactionDate As Date? Implements IPcsOiItemView.TransactionDate

        Public Property Errors As List(Of String) Implements IView.Errors

    End Class

End Namespace