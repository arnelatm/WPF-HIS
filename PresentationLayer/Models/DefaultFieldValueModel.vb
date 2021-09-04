' DefaultFieldValue business object as seen by the Service client.
Public Class DefaultFieldValueModel
    Public Property DataType As Byte
    Public Property DecimalPart As Byte
    Public Property DefaultValue As String
    Public Property Errors As List(Of String)
    Public Property FieldName As String
    Public Property IdNo As Int16
    Public Property Length As Byte
    Public Property LinkedField As String
    Public Property LinkedTable As String
    Public Property SystemViewIdNo As Int16
    Public Property SystemViewName As String
    Public Property SystemViewNameAra As String
End Class