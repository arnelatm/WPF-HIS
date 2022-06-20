Namespace BusinessLayer

    Public Class EmployeeId
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
        End Sub

        Public Property IdNo As Int32
        Public Property EmployeeName As String
        Public Property NationalIdNo As String
        Public Property Picture As Image

    End Class

End Namespace