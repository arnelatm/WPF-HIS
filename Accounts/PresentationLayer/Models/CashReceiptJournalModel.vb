' Cash Receipt Business object as seen by the Service client.
Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class CashReceiptJournalModel

        Public Property AccountIdNo As Int16?
        Public Property Amount As Decimal
        Public Property Applied As Decimal
        Public Property Approved As Boolean
        Public Property Cancelled As Boolean
        Public Property CheckDate As Date?
        Public Property CheckNumber As String
        Public Property ContactIdNo As Int32?
        Public Property CsrOiItems As List(Of CsrOiItemModel)
        Public Property DateCreated As DateTime?
        Public Property DiscountAccountIdNo As Int16?
        Public Property DiscountTaken As Decimal
        Public Property Errors As List(Of String)
        Public Property IdNo As Int32
        Public Property JournalItems As List(Of JournalItemModel)
        Public Property Notes As String
        Public Property OrNumber As String
        Public Property PayorName As String
        Public Property PayorType As String
        Public Property Posted As Boolean
        Public Property ReferenceNo As String
        Public Property TotalCredits As Decimal
        Public Property TotalDebits As Decimal
        Public Property TransactionDate As Date?
        Public Property UnApplied As Decimal
        Public Property VatAmount As Decimal
        Public Property VatNumber As String
    End Class

End Namespace