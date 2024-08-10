' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class EmployeePayElement
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("EmployeePayElementName"))
                AddRule(New ValidateRequired("EmployeePayElementCode"))
            End If
        End Sub

        Public Property Amount As Decimal
        Public Property PayElementCode As String
        Public Property PayElementIdNo As Int16
        Public Property PayElementKind As String
        Public Property PayElementName As String
        Public Property PayElementNameAra As String
        Public Property PayElementType As Char
        Public Property EmployeeIdNo As Int32
        Public Property IdNo As Int32
        Public Property Rate As Decimal
        Public Property Unit As String
        Public Property Sequence As Int16

    End Class

End Namespace