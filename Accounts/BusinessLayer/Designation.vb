' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class Designation
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            AddRule(New ValidateRequired("DesignationName"))
        End Sub

        Public Property IdNo As Integer
        Public Property DesignationCode As String
        Public Property DesignationName As String
        Public Property DesignationNameAra As String
        Public Property Notes As String
    End Class

End Namespace