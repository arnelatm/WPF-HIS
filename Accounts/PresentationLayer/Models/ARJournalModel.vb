Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class ArJournalModel

        Public Property AccountIdNo As Int16?
        Public Property Amount As Decimal
        Public Property Cancelled As Boolean
        Public Property CustomerIdNo As Int32?
        Public Property DateCreated As DateTime?
        Public Property DueDate As Date?
        Public Property Errors As List(Of String)
        Public Property IdNo As Int32
        Public Property InvoiceNo As String
        Public Property Notes As String
        Public Property Posted As Boolean
        Public Property ReferenceNo As String
        Public Property SettlementDiscount As Decimal
        Public Property SettlementDueDate As Date?
        Public Property TotalCredits As Decimal
        Public Property TotalDebits As Decimal
        Public Property TransactionDate As Date?
        Public Property TransactionType As String
        Public Property VatAmount As Decimal
        Public Property JournalItems As IList(Of JournalItemModel)
    End Class

End Namespace