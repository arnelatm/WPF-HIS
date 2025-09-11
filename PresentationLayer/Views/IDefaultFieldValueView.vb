Imports AATM.Presentation.Views

Public Interface IDefaultFieldValueView
    Inherits IView
    Property DataType As Byte
    Property DecimalPart As Byte
    Property DefaultValue As String
    Property FieldName As String
    Property IdNo As Int16
    Property Length As Byte
    Property LinkedField As String
    Property LinkedTable As String
    Property SystemViewIdNo As Int16
    Property SystemViewName As String
    Property SystemViewNameAra As String

End Interface