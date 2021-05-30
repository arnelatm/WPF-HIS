Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class GeneralJournalModel

        'Public Property Amount As Decimal
        Public Property Approved As Boolean
        Public Property Cancelled As Boolean

        Public Property ClosingJournal As Boolean
        Public Property DateCreated As DateTime?
        Public Property Errors As List(Of String)
        Public Property IdNo As Int32
        Public Property Notes As String
        Public Property Posted As Boolean
        Public Property ReferenceNo As String
        Public Property TotalDebits As Decimal
        Public Property TotalCredits As Decimal
        Public Property TransactionDate As Date?
        Public Property JournalItems As IList(Of JournalItemModel)
    End Class

End Namespace