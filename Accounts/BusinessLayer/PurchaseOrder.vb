' InvTransType business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class PurchaseOrder
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            If GetRules().Count() = 0 Then
                ' establish business rules
                AddRule(New ValidateRequired("WarehouseIdNo"))
                AddRule(New ValidateRequired("TransactionDate"))
                AddRule(New ValidateRequired("SupplierIdNo"))
            End If
        End Sub

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
        Public Property PurchaseOrderDetails As List(Of PurchaseOrderDetail)

    End Class

End Namespace