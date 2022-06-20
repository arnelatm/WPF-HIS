' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field

Namespace BusinessLayer

    Public Class PensionRate
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
        End Sub

        Public Property EmployeeShare As Decimal
        Public Property EmployerShare As Decimal
        Public Property HighRange As Decimal
        Public Property IdNo As Int32
        Public Property LowRange As Decimal
        Public Property MaxAmount As Decimal
        Public Property PensionSchemeIdNo As Int16
        Public Property Sequence As Int16
    End Class

End Namespace