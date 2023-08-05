' InvTransType business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class InvTransType
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            If GetRules().Count() = 0 Then
                ' establish business rules
                AddRule(New ValidateRequired("InvTransTypeName"))
            End If
        End Sub

        Public Property AccountIdNo As Int16?
        Public Property Active As Boolean
        Public Property InventoryAction As String
        Public Property IdNo As Int16
        Public Property InvTransTypeCode As String
        Public Property InvTransTypeName As String
        Public Property InvTransTypeNameAra As String
        Public Property Notes As String

    End Class

End Namespace