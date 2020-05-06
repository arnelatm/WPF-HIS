Imports AATM.BusinessLayer
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer
    Public Class DefaultFieldValueView
        Inherits BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("TableName"))
                AddRule(New ValidateRequired("FieldName"))
                AddRule(New ValidateRequired("DataTypeFieldName"))
            End If
        End Sub

        Public Property IdNo As Int32
        Public Property TableName As String
        Public Property FieldName As String
        Public Property DataType As Byte
        Public Property Length As UShort
        Public Property DecimalPart As Byte
        Public Property LinkedTable As String
        Public Property LinkedField As String
        Public Property DefaultValue As String

    End Class
End Namespace
