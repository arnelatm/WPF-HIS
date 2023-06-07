Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class PurchaseModel

        Public Property Amount As Decimal
        Public Property BranchIdNo As Int16
        Public Property Cancelled As Boolean
        Public Property DateCreated As DateTime?
        Public Property DueDate As Date?
        Public Property Errors As List(Of String)
        Public Property IdNo As Int32
        Public Property InvoiceDate As Date?
        Public Property InvoiceNo As String
        Public Property Notes As String
        Public Property Posted As Boolean
        Public Property SupplierIdNo As Int32?
        Public Property TransactionDate As Date?
        Public Property VatAmount As Decimal
        Public Property VatNumber As String
        Public Property WarehouseIdNo As Int16
        Public Property PurchaseDetails As List(Of PurchaseDetailModel)
        Public Property PurchaseHistory As List(Of PurchaseHistoryModel)
    End Class

End Namespace