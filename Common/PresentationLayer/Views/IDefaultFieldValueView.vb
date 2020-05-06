Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface IDefaultFieldValueView
        Inherits IView
        Property IdNo As Int32
        Property TableName As String
        Property FieldName As String
        Property DataType As Byte
        Property Length As UShort
        Property DecimalPart As Byte
        Property LinkedTableName As String
        Property LinkedFieldName As String
        Property DefaultValue As String

    End Interface

End Namespace