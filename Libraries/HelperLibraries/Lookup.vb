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
    Public Property Ascending As Boolean

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
        If Right(TableName, 5) = "_View" Then
            NameField = Left(TableName, TableName.Length - 5) + "Name"
            If CodeField Is Nothing Then
                CodeField = Left(TableName, TableName.Length - 5) + "Code"
            End If
        Else
            NameField = TableName + "Name"
            If CodeField Is Nothing Then
                CodeField = TableName + "Code"
            End If
        End If
        If SortKey Is Nothing Then
            SortKey = NameField
        End If

        If TableName = "List" Then
            FieldsToShow = {"IdNo", NameField}
        Else
            If CodeField = "" Then
                FieldsToShow = {"IdNo", NameField}
            Else
                FieldsToShow = {"IdNo", NameField, CodeField}
            End If
        End If
        FilterKey = filter
    End Sub

End Class

Public Class LookupTable

    Public Property FieldsToShow As String()
    Public Property FilterKey As String = Nothing
    Public Property SortKey As String
    Public Property TableName As String
    Public Property CodeField As String
    Public Property NameField As String
    Public Property NameFieldOriginal As String
    Public Property NameFieldArabic As String
    Public Property Ascending As Boolean

    Public Sub New(tableName As String, Optional filter As String = Nothing, Optional sortKey As String = Nothing, Optional ascending As Boolean = True)
        Me.TableName = tableName
        ComposeDefaultLookupValues(filter, sortKey, ascending)
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

    Private Sub ComposeDefaultLookupValues(Optional filter As String = Nothing, Optional sortOrderKey As String = Nothing, Optional ascendingOrder As Boolean = True)
        If Right(TableName, 5) = "_View" Then
            NameField = Left(TableName, TableName.Length - 5) + "Name"
            CodeField = Left(TableName, TableName.Length - 5) + "Code"
        Else
            NameField = TableName + "Name"
            CodeField = TableName + "Code"
        End If
        SortKey = NameField
        If TableName = "List" Then
            FieldsToShow = {"IdNo", NameField}
        Else
            FieldsToShow = {"IdNo", NameField, CodeField}
        End If
        FilterKey = filter
        SortKey = sortOrderKey
        Ascending = ascendingOrder
    End Sub

End Class