Namespace PresentationLayer.Models

    Public Class OpenInvoiceCorrectionLedger
        Public Property Code As String
        Public Property DisplayName As String
    End Class

    Public Class OpenInvoiceCorrectionContact
        Public Property IdNo As Int32
        Public Property Code As String
        Public Property Name As String
        Public Property ControlAccountIdNo As Int16?

        Public ReadOnly Property DisplayName As String
            Get
                If String.IsNullOrWhiteSpace(Code) Then
                    Return Name
                End If
                Return Name + " - " + Code
            End Get
        End Property
    End Class

    Public Class OpenInvoiceCorrectionItem
        Public Property OpenInvoiceIdNo As Int32
        Public Property AccountIdNo As Int16?
        Public Property InvoiceNo As String
        Public Property JournalCode As String
        Public Property JournalIdNo As Int32
        Public Property TransactionDate As Date?
        Public Property CurrentBalance As Decimal
        Public Property ProposedAmount As Decimal
        Public Property ProjectedBalance As Decimal
    End Class

End Namespace
