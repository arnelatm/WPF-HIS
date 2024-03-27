Imports System.Globalization
Imports System.Reflection

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
        Inherits DataTable

        Public Property IdNo
        Public Property Name As String
        Public Property Code As String
        Public Property Index

        'Public Sub New()
        '    Dim x = 0
        '    x = x + 1
        'End Sub

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

    Public Shared Function ToDataTable(Of T)(ByVal items As List(Of T)) As DataTable
        Dim dataTable As DataTable = New DataTable(GetType(T).Name)
        Dim Props As PropertyInfo() = GetType(T).GetProperties(BindingFlags.[Public] Or BindingFlags.Instance)

        For Each prop As PropertyInfo In Props
            dataTable.Columns.Add(prop.Name)
        Next

        For Each item As T In items
            Dim values = New Object(Props.Length - 1) {}

            For i As Integer = 0 To Props.Length - 1
                values(i) = Props(i).GetValue(item, Nothing)
            Next

            dataTable.Rows.Add(values)
        Next

        Return dataTable
    End Function
End Class