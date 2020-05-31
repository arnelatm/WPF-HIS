Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class PettyCashJournalModel

        Public Property AccountIdNo As Int32?
        Public Property Amount As Decimal
        Public Property Applied As Decimal
        Public Property Cancelled As Boolean
        Public Property DateCreated As DateTime?
        Public Property DiscountAccountIdNo As Int32?
        Public Property DiscountTaken As Decimal
        Public Property Errors As List(Of String)
        Public Property IdNo As Int32
        Public Property Notes As String
        Public Property OrNumber As String
        Public Property PayeeIdNo As Int32?
        Public Property PayeeName As String
        Public Property PaymentType As String
        Public Property Posted As Boolean
        Public Property ReferenceNo As String
        Public Property TotalCredits As Decimal
        Public Property TotalDebits As Decimal
        Public Property TransactionDate As Date?
        Public Property UnApplied As Decimal
        Public Property VatAmount As Decimal
        Public Property VatNumber As String
        Public Property JournalItems As List(Of JournalItemModel)
        Public Property PcsOiItems As List(Of PcsOiItemModel)

    End Class


End Namespace