Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class PurchaseModel

        Public Property Amount As Decimal
        Public Property Approved As Boolean
        Public Property BranchIdNo As Int16
        Public Property Cancelled As Boolean
        Public Property DateCreated As DateTime?
        Public Property Disaproved As Boolean
        Public Property DueDate As Date?
        Public Property Errors As List(Of String)
        Public Property IdNo As Int32
        Public Property InvoiceAmount As Decimal
        Public Property InvoiceDate As Date?
        Public Property InvoiceNo As String
        Public Property Notes As String
        Public Property Posted As Boolean
        Public Property PurchaseDetails As List(Of PurchaseDetailModel)
        Public Property PurchaseHistory As List(Of PurchaseHistoryModel)
        Public Property ReferenceNo As String
        Public Property SupplierIdNo As Int32?
        Public Property TransactionDate As Date?
        Public Property UserIdNo As Int16
        Public Property VatAmount As Decimal
        Public Property VatNumber As String
        Public Property WarehouseIdNo As Int16

    End Class

    Public Class PurchaseOrderApprovalModel

        Public Property UnpostedPurchaseOrders As List(Of PurchaseModel)
        Public Property WarehouseIdNo As Int16
        Public Property UserName As String

    End Class

End Namespace