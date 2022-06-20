' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class PayElementItem
        Inherits AATM.BusinessLayer.BusinessObject
        'Implements IDataErrorInfo

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateContent("FactorValue", 0, ValidationOperator.NotEqual, ValidationDataType.Decimal))
            End If
        End Sub

        Public Property FactorValue As Decimal
        Public Property FactorType As String
        Public Property IdNo As Int16
        Public Property ParentIdNo As Int16
        Public Property PayElementIdNo As Int16
        Public Property Sequence As Int16

    End Class

End Namespace