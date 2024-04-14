' SupplierProduct business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class SupplierProduct
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            If GetRules().Count() = 0 Then
                ' establish business rules
                AddRule(New ValidateRequired("SupplierProductCode"))
            End If
        End Sub


        Public Property IdNo As Int32
        Public Property ProductIdNo As Int32
        Public Property SupplierIdNo As Int32
        Public Property SupplierProductCode As String
        Public Property SupplierProductName As String
        Public Property SupplierProductNameAra As String
    End Class

End Namespace
