Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.PresentationLayer.Models

Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class PurchaseOrderModel


        Public Property Amount As Decimal
        Public Property Cancelled As Boolean
        Public Property DateCreated As Date
        Public Property IdNo As Int32
        Public Property Notes As String
        Public Property Posted As Boolean
        Public Property ReferenceNo As String
        Public Property SupplierIdNo As Int32
        Public Property TransactionDate As Date?
        Public Property UserIdNo As Int16
        Public Property WarehouseIdNo As Int16
        Public Property PurchaseOrderDetails As List(Of PurchaseOrderDetailModel)

    End Class

End Namespace