' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessObjects

    Public Class DefaultFieldValue
        Inherits BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            AddRule(New ValidateRequired("SystemViewName"))
            AddRule(New ValidateRequired("FieldName"))
        End Sub

        Public Property IdNo As Int16
        Public Property SystemViewIdNo As Int16
        Public Property SystemViewName As String
        Public Property SystemViewNameAra As String
        Public Property FieldName As String
        Public Property DataType As Byte
        Public Property Length As Byte
        Public Property DecimalPart As Byte
        Public Property DefaultValue As String
        Public Property LinkedTable As String
        Public Property LinkedField As String
    End Class

End Namespace