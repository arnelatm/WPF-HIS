Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interface

    Public Interface IDefaultFieldValueView
        Inherits IView
        Property IdNo As Int16
        Property SystemViewIdNo As Int16
        Property SystemViewName As String
        Property SystemViewNameAra As String
        Property FieldName As String
        Property DataType As Byte
        Property Length As Byte
        Property DecimalPart As Byte
        Property LinkedTable As String
        Property LinkedField As String
        Property DefaultValue As String

    End Interface

End Namespace