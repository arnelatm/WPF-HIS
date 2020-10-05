Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    ' Category business object
    ' ** Enterprise Design Pattern: Domain Model, Identity Field
    Public Class CountryTelCode
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
        End Sub

        Public Property IdNo As Int16
        Public Property CountryName As String
        Public Property CountryNameAra As String
        Public Property CountryTelCode As String
    End Class

End Namespace