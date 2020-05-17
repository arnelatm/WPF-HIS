Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class CadOiItemView
        Implements ICadOiItemView

        Public Property AccountIdNo As Int32? Implements ICadOiItemView.AccountIdNo

        Public Property Amount As Decimal Implements ICadOiItemView.Amount

        Public Property Balance As Decimal Implements ICadOiItemView.Balance

        Public Property CadIdNo As Int32 Implements ICadOiItemView.CadIdNo

        Public Property DiscountTaken As Decimal Implements ICadOiItemView.DiscountTaken

        Public Property IdNo As Int32 Implements ICadOiItemView.IdNo

        Public Property InvoiceNo As String Implements ICadOiItemView.InvoiceNo

        Public Property JournalCode As String Implements ICadOiItemView.JournalCode

        Public Property JournalIdNo As Int32 Implements ICadOiItemView.JournalIdNo

        Public Property JournalItemIdNo As Int32 Implements ICadOiItemView.JournalItemIdNo

        Public Property OpenInvoiceIdNo As Int32 Implements ICadOiItemView.OpenInvoiceIdNo

        Public Property PreviousBalance As Decimal Implements ICadOiItemView.PreviousBalance

        Public Property Sequence As Integer Implements ICadOiItemView.Sequence

        Public Property TransactionDate As Date? Implements ICadOiItemView.TransactionDate

        Public Property Errors As List(Of String) Implements IView.Errors

    End Class

End Namespace