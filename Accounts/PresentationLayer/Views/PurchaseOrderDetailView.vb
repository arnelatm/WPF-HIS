Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class PurchaseOrderDetailView
        Implements IPurchaseOrderDetailView

        Public Property BaseUnitIdNo As Int16 Implements IPurchaseOrderDetailView.BaseUnitIdNo
        Public Property CategoryIdNo As Short Implements IPurchaseOrderDetailView.CategoryIdNo
        Public Property IdNo As Int32 Implements IPurchaseOrderDetailView.IdNo
        Public Property NetAmount As Decimal Implements IPurchaseOrderDetailView.NetAmount
        Public Property ProductCode As String Implements IPurchaseOrderDetailView.ProductCode
        Public Property ProductIdNo As Int32 Implements IPurchaseOrderDetailView.ProductIdNo
        Public Property ProductName As String Implements IPurchaseOrderDetailView.ProductName
        Public Property ProductNameAra As String Implements IPurchaseOrderDetailView.ProductNameAra
        Public Property Quantity As Decimal Implements IPurchaseOrderDetailView.Quantity
        Public Property Sequence As Int16 Implements IPurchaseOrderDetailView.Sequence
        Public Property UnitCost As Decimal Implements IPurchaseOrderDetailView.UnitCost
        Public Property UnitCount As Int16 Implements IPurchaseOrderDetailView.UnitCount
        Public Property UnitIdNo As Int16 Implements IPurchaseOrderDetailView.UnitIdNo
        Public Property PurchaseOrderIdNo As Integer Implements IPurchaseOrderDetailView.PurchaseOrderIdNo
        Public Property DataFilter As String Implements IView.DataFilter
        Public Property Errors As List(Of String) Implements IView.Errors



    End Class

    Public Class PurchaseOrderApprovalDetailView
        Inherits InvTransactionDetailView
        Implements IPurchaseOrderApprovalDetailView

        Public Property BaseUnitName As String Implements IPurchaseOrderApprovalDetailView.BaseUnitName
        Public Property QtyApproved As Decimal Implements IPurchaseOrderApprovalDetailView.QtyApproved
        Public Property QtyOnHand As Decimal Implements IPurchaseOrderApprovalDetailView.QtyOnHand
        Public Property QtySupplied As Decimal Implements IPurchaseOrderApprovalDetailView.QtySupplied
        Public Property UnitName As String Implements IPurchaseOrderApprovalDetailView.UnitName


    End Class


End Namespace