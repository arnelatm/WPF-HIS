Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class GeneralJournalModel

        'Public Property Amount As Decimal
        Public Property Cancelled As Boolean

        Public Property DateCreated As DateTime
        Public Property Errors As List(Of String)
        Public Property IdNo As Integer
        Public Property Notes As String
        Public Property Posted As Boolean
        Public Property ReferenceNo As String
        Public Property TotalCredits As Decimal
        Public Property TotalDebits As Decimal
        Public Property TransactionDate As Date?
    End Class

End Namespace