Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class PurchaseOrderDetailModel

        Public Property BaseUnitIdNo As Int16
        Public Property CategoryIdNo As Int16
        Public Property IdNo As Int32
        Public Property PurchaseOrderIdNo As Int32
        Public Property NetAmount As Decimal
        Public Property ProductCode As String
        Public Property ProductIdNo As Int32
        Public Property ProductName As String
        Public Property ProductNameAra As String
        Public Property Quantity As Int16
        Public Property Sequence As Int16
        Public Property UnitCost As Decimal
        Public Property UnitCount As Int16
        Public Property UnitIdNo As Int16


    End Class

    Public Class PurchaseOrderApprovalDetailModel
        Inherits PurchaseOrderDetailModel

        Public Property BaseUnitName As String
        Public Property QtyOnHand As Decimal
        Public Property QtySupplied As Decimal
        Public Property QtyApproved As Decimal
        Public Property UnitName As String


    End Class


End Namespace