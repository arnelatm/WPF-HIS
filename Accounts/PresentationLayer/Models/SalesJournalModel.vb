Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class SalesJournalModel

        Public Property AccountIdNo as Int32
        Public Property Cancelled As Boolean
        Public Property DateCreated As DateTime
        Public Property Errors As List(Of String)
        Public Property IdNo As Int32
        Public Property Notes As String
        Public Property Posted As Boolean
        Public Property ReferenceNo As String
        Public Property TotalBankCharges As Decimal
        Public Property TotalCredits As Decimal
        Public Property TotalDebits As Decimal
        Public Property TotalDeposits As Decimal
        Public Property TotalBankChargesVat As Decimal
        Public Property TotalSales As Decimal
        Public Property TransactionDate As Date?
    End Class

End Namespace