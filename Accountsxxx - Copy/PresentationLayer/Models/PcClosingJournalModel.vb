Namespace PresentationLayer.Models

    Public Class PcClosingJournalModel

        Public Sub New()
        End Sub

        Public Property Amount As Decimal
        Public Property CdJournalIdNo As Int32
        Public Property IdNo As Int32
        Public Property Notes As String
        Public Property PayeeName As String
        Public Property PayeeNameAra As String
        Public Property PaymentType As String
        Public Property PayType As String
        Public Property PcClosed As Boolean
        Public Property ReferenceNo As String
        Public Property TransactionDate As Date?

    End Class

End Namespace