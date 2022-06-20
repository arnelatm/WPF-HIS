Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class AccountReconciliationItemModel

        Public Property AccountIdNo As Int16?
        Public Property AccountReconciliationIdNo As Int32
        Public Property Cleared As Boolean
        Public Property Credit As Decimal
        Public Property Debit As Decimal
        Public Property DocumentNumber As String
        Public Property Errors As List(Of String)
        Public Property IdNo As Int32
        Public Property JournalCode As String
        Public Property JournalIdNo As Int32
        Public Property JournalItemIdNo As Int32
        Public Property PayDescription As String
        Public Property PayDescriptionAra As String
        Public Property ReferenceNo As String
        Public Property Sequence As Int32
        Public Property TransactionDate As Date?

    End Class

End Namespace