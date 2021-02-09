Imports AATM.BusinessLayer
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class DefaultFieldValue
        Inherits BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("SystemViewIdNo"))
                AddRule(New ValidateRequired("FieldName"))
                AddRule(New ValidateRequired("DefaultValue"))
            End If
        End Sub

        Public Property IdNo As Int16
        Public Property SystemViewIdNo As Int16
        Public Property SystemViewName As String
        Public Property SystemViewNameAra As String
        Public Property FieldName As String
        Public Property DataType As Byte
        Public Property Length As Byte
        Public Property DecimalPart As Byte
        Public Property LinkedTable As String
        Public Property LinkedField As String
        Public Property DefaultValue As String

    End Class

End Namespace