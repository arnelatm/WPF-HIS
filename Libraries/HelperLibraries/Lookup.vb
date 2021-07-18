Imports System.Globalization

Public Class Lookup

    Public Property FieldsToShow As String()
    Public Property FilterKey As String = Nothing
    Public Property SortKey As String
    Public Property TableName As String
    Public Property CodeField As String
    Public Property NameField As String
    Public Property NameFieldOriginal As String
    Public Property NameFieldArabic As String

    Public Sub New(tableName As String, Optional filter As String = Nothing)
        Me.TableName = tableName
        ComposeDefaultLookupValues(filter)
    End Sub

    Public Class HLookupData
        Property IdNo
        Property Name As String
        Property ParentIdNo
        Property Code As String
    End Class

    Public Class LookupData
        Public Property IdNo
        Public Property Name As String
        Public Property Code As String
        Public Property Index

        Public Overrides Function ToString() As String
            Return Name.ToString()
        End Function

    End Class

    Private Sub ComposeDefaultLookupValues(Optional filter As String = Nothing)
        NameField = TableName + "Name"
        CodeField = TableName + "Code"
        SortKey = NameField
        FieldsToShow = {"IdNo", NameField, CodeField}
        FilterKey = filter
    End Sub

End Class