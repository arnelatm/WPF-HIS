
Namespace PresentationLayer.Models
    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class AccountReconciliationItemModel

        Public Property AccountIdNo As Integer
        Public Property AccountReconciliationIdNo As Integer
        Public Property Cleared As Boolean
        Public Property Credit As Decimal
        Public Property Debit As Decimal
        Public Property DocumentNumber As String
        Public Property Errors As List(Of String)
        Public Property IdNo As Integer
        Public Property JournalCode As String
        Public Property JournalIdNo As Integer
        Public Property JournalItemIdNo As Integer
        Public Property PayDescription As String
        Public Property PayDescriptionAra As String
        Public Property ReferenceNo As String
        Public Property TransactionDate As Date?
        Public Property Sequence As Integer

    End Class
End NameSpace