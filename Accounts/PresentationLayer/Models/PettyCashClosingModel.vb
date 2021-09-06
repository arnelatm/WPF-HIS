Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class PettyCashClosingModel

        Public Property AccountIdNo As Int16?
        Public Property Amount As Decimal
        Public Property Applied As Decimal
        Public Property Cancelled As Boolean
        Public Property CheckDate As Date?
        Public Property CheckNumber As String
        Public Property DateCreated As DateTime?
        Public Property Errors As List(Of String)
        Public Property IdNo As Int32
        Public Property Notes As String
        Public Property PayeeIdNo As Int32?
        Public Property PayeeName As String
        Public Property PaymentType As String
        Public Property PayType As String
        Public Property PcAccountIdNo As Int16?
        Public Property PcClosed As Boolean
        Public Property Posted As Boolean
        Public Property ReferenceNo As String
        Public Property TotalCredits As Decimal
        Public Property TotalDebits As Decimal
        Public Property TransactionDate As Date?
        Public Property PcClosingJournals As List(Of PcClosingJournalModel)

    End Class

End Namespace