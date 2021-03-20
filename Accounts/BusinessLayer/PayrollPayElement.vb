' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class PayrollPayElement
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
        End Sub

        Public Property Amount As Decimal
        Public Property EmployeeIdNo As Int32
        Public Property IdNo As Int32
        Public Property PayElementIdNo As Int16
        Public Property PayrollDetailIdNo As Int32
        Public Property PayrollIdNo As Int16

    End Class

End Namespace