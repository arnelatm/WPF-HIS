Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class ErJournalModel

        Public Property AccountIdNo As Int16?
        Public Property Approved As Boolean
        Public Property Amount As Decimal
        Public Property Cancelled As Boolean
        Public Property EmployeeIdNo As Int32?
        Public Property DateCreated As DateTime?
        Public Property Errors As List(Of String)
        Public Property IdNo As Int32
        Public Property Notes As String
        Public Property Posted As Boolean
        Public Property ReferenceNo As String
        Public Property TotalCredits As Decimal
        Public Property TotalDebits As Decimal
        Public Property TransactionDate As Date?
        Public Property TransactionType As String
        Public Property JournalItems As IList(Of JournalItemModel)
    End Class

End Namespace