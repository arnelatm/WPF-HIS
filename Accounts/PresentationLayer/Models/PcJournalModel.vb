Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries

Namespace PresentationLayer.Models

    Public Class PcJournalModel

        Public Sub New()
        End Sub

        Public Property AccountIdNo As Int16?
        Public Property Amount As Decimal
        Public Property Applied As Decimal
        Public Property Cancelled As Boolean
        Public Property DateCreated As DateTime?
        Public Property IdNo As Int32
        Public Property Notes As String
        Public Property PayeeIdNo As Int32?
        Public Property PayeeName As String
        Public Property PayeeNameAra As String
        Public Property PaymentType As String
        Public Property PayType As String
        Public Property PcClosed As Boolean
        Public Property Posted As Boolean
        Public Property ReferenceNo As String
        Public Property TransactionDate As Date?

    End Class

End Namespace