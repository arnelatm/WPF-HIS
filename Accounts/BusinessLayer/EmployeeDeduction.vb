' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class EmployeeDeduction
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("DeductionIdNo"))
            End If
        End Sub

        Public Property Amount As Decimal
        Public Property DeductionCode As String
        Public Property DeductionIdNo As Int16
        Public Property DeductionName As String
        Public Property DeductionNameAra As String
        Public Property DeductionType As Char
        Public Property EmployeeIdNo As Int32
        Public Property IdNo As Int32
        Public Property Sequence As Int16
    End Class

End Namespace