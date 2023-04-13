' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class ProductUnit
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("ProductIdNo"))
                AddRule(New ValidateRange("Multiplier", 1, 32768, ValidationDataType.Integer))
                AddRule(New ValidateRange("BaseQty", 1, 32768, ValidationDataType.Integer))
            End If
        End Sub

        Public Property BaseQty As Int16
        Public Property IdNo As Int32
        Public Property Multiplier As Int16
        Public Property ProductIdNo As Int16
        Public Property UnitIdNo As Int16

    End Class

End Namespace