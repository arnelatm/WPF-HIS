' <summary>
'     The Model in MVP design pattern.
'     Implements IModel and communicates with WCF Service.
' </summary>
Namespace PresentationLayer.Models

    Public Class DefaultFieldValueModel

        Public Property Errors As List(Of String)
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