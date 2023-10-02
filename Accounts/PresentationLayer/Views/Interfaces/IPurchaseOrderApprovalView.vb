Imports AATM.Accounts.BusinessLayer
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IPurchaseOrderApprovalView
        Inherits IView
        Property PurchaseOrders As List(Of PurchaseOrder)

    End Interface

End Namespace