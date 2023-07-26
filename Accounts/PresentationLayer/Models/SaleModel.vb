Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class SaleModel

        Public Property Amount As Decimal
        Public Property Cancelled As Boolean
        Public Property CustomerIdNo As Int32?
        Public Property DateCreated As DateTime?
        Public Property DueDate As Date?
        Public Property Errors As List(Of String)
        Public Property IdNo As Int32
        Public Property InvoiceNo As String
        Public Property Notes As String
        Public Property PatientIdNo As Int32?
        Public Property PatientName As String
        Public Property Posted As Boolean
        Public Property SaleDetails As List(Of SaleDetailModel)
        Public Property TransactionDate As Date?
        Public Property UserIdNo As Int16
        Public Property VatAmount As Decimal
        Public Property WarehouseIdNo As Int16

    End Class

End Namespace