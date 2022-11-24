Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Windows.Forms

Public Class TestForm3
    Inherits System.Windows.Forms.Form

    Private WithEvents dataGridView1 As New DataGridView()
    Private memoryCache As Cache

    ' Specify a connection string. Replace the given value with a
    ' valid connection string for a Northwind SQL Server sample
    ' database accessible to your system.
    Private connectionString As String = ConfigurationManager.ConnectionStrings("IGroupClinic").ConnectionString

    Private table As String = "ItemDetails"

    Private Sub VirtualJustInTimeDemo_Load(
        ByVal sender As Object, ByVal e As EventArgs) _
        Handles Me.Load

        ' Initialize the form.
        With Me
            .AutoSize = True
            .Controls.Add(Me.dataGridView1)
            .Text = "DataGridView virtual-mode just-in-time demo"
        End With

        ' Complete the initialization of the DataGridView.
        With Me.dataGridView1
            .Size = New Size(800, 250)
            .Dock = DockStyle.Fill
            .VirtualMode = True
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToOrderColumns = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With

        ' Create a DataRetriever and use it to create a Cache object
        ' and to initialize the DataGridView columns and rows.
        Try
            Dim retriever As New DataRetriever(connectionString, table)
            memoryCache = New Cache(retriever, 16)
            For Each column As DataColumn In retriever.Columns
                dataGridView1.Columns.Add(
                    column.ColumnName, column.ColumnName)
            Next
            Me.dataGridView1.RowCount = retriever.RowCount
        Catch ex As SqlException
            MessageBox.Show("Connection could not be established. " &
                "Verify that the connection string is valid.")
            Application.Exit()
        End Try

        ' Adjust the column widths based on the displayed values.
        Me.dataGridView1.AutoResizeColumns(
            DataGridViewAutoSizeColumnsMode.DisplayedCells)

    End Sub

    Private Sub dataGridView1_CellValueNeeded(
        ByVal sender As Object, ByVal e As DataGridViewCellValueEventArgs) _
        Handles dataGridView1.CellValueNeeded

        e.Value = memoryCache.RetrieveElement(e.RowIndex, e.ColumnIndex)

    End Sub

End Class

Public Interface IDataPageRetriever

    Function SupplyPageOfData(ByVal lowerPageBoundary As Integer, ByVal rowsPerPage As Integer) As DataTable

End Interface

Public Class DataRetriever
    Implements IDataPageRetriever

    Private tableName As String
    Private command As SqlCommand

    Public Sub New(ByVal connectionString As String, ByVal tableName As String)

        Dim connection As New SqlConnection(connectionString)
        connection.Open()
        command = connection.CreateCommand()
        Me.tableName = tableName

    End Sub

    Private rowCountValue As Integer = -1

    Public ReadOnly Property RowCount() As Integer
        Get
            ' Return the existing value if it has already been determined.
            If Not rowCountValue = -1 Then
                Return rowCountValue
            End If

            ' Retrieve the row count from the database.
            command.CommandText = "SELECT COUNT(*) FROM " & tableName
            rowCountValue = CInt(command.ExecuteScalar())
            Return rowCountValue
        End Get
    End Property

    Private columnsValue As DataColumnCollection

    Public ReadOnly Property Columns() As DataColumnCollection
        Get
            ' Return the existing value if it has already been determined.
            If columnsValue IsNot Nothing Then
                Return columnsValue
            End If

            ' Retrieve the column information from the database.
            command.CommandText = "SELECT " & "Primary_Key,Item_Code,GTin,ItemNameEnglish,Price_Cash,Pack1,Pack2,Pack3" & " FROM " & tableName
            Dim adapter As New SqlDataAdapter()
            adapter.SelectCommand = command
            Dim table As New DataTable()
            table.Locale = System.Globalization.CultureInfo.InvariantCulture
            adapter.FillSchema(table, SchemaType.Source)
            columnsValue = table.Columns
            Return columnsValue
        End Get
    End Property

    Private commaSeparatedListOfColumnNamesValue As String = "Primary_Key,Item_Code,GTin,ItemNameEnglish,Price_Cash,Pack1,Pack2,Pack3"

    Private ReadOnly Property CommaSeparatedListOfColumnNames() As String
        Get
            ' Return the existing value if it has already been determined.
            If commaSeparatedListOfColumnNamesValue IsNot Nothing Then
                Return commaSeparatedListOfColumnNamesValue
            End If

            ' Store a list of column names for use in the
            ' SupplyPageOfData method.
            Dim commaSeparatedColumnNames As New System.Text.StringBuilder()
            Dim firstColumn As Boolean = True
            For Each column As DataColumn In Columns
                If Not firstColumn Then
                    commaSeparatedColumnNames.Append(", ")
                End If
                commaSeparatedColumnNames.Append(column.ColumnName)
                firstColumn = False
            Next

            commaSeparatedListOfColumnNamesValue =
                commaSeparatedColumnNames.ToString()
            Return commaSeparatedListOfColumnNamesValue
        End Get
    End Property

    ' Declare variables to be reused by the SupplyPageOfData method.
    Private columnToSortBy As String

    Private adapter As New SqlDataAdapter()

    Public Function SupplyPageOfData(ByVal lowerPageBoundary As Integer, ByVal rowsPerPage As Integer) As DataTable Implements IDataPageRetriever.SupplyPageOfData

        ' Store the name of the ID column. This column must contain unique
        ' values so the SQL below will work properly.
        If columnToSortBy Is Nothing Then
            columnToSortBy = Me.Columns(0).ColumnName
        End If

        If Not Me.Columns(columnToSortBy).Unique Then
            Throw New InvalidOperationException(String.Format(
                "Column {0} must contain unique values.", columnToSortBy))
        End If

        ' Retrieve the specified number of rows from the database, starting
        ' with the row specified by the lowerPageBoundary parameter.
        command.CommandText =
            "Select Top " & rowsPerPage & " " &
            CommaSeparatedListOfColumnNames & " From " & tableName &
            " WHERE " & columnToSortBy & " NOT IN (SELECT TOP " &
            lowerPageBoundary & " " & columnToSortBy & " From " &
            tableName & " Order By " & columnToSortBy &
            ") Order By " & columnToSortBy
        adapter.SelectCommand = command

        Dim table As New DataTable()
        table.Locale = System.Globalization.CultureInfo.InvariantCulture
        adapter.Fill(table)
        Return table

    End Function

End Class

Public Class Cache

    Private Shared RowsPerPage As Integer

    ' Represents one page of data.
    Public Structure DataPage

        Public table As DataTable
        Private lowestIndexValue As Integer
        Private highestIndexValue As Integer

        Public Sub New(ByVal table As DataTable, ByVal rowIndex As Integer)

            Me.table = table
            lowestIndexValue = MapToLowerBoundary(rowIndex)
            highestIndexValue = MapToUpperBoundary(rowIndex)
            System.Diagnostics.Debug.Assert(lowestIndexValue >= 0)
            System.Diagnostics.Debug.Assert(highestIndexValue >= 0)

        End Sub

        Public ReadOnly Property LowestIndex() As Integer
            Get
                Return lowestIndexValue
            End Get
        End Property

        Public ReadOnly Property HighestIndex() As Integer
            Get
                Return highestIndexValue
            End Get
        End Property

        Public Shared Function MapToLowerBoundary(ByVal rowIndex As Integer) As Integer

            ' Return the lowest index of a page containing the given index.
            Return (rowIndex \ RowsPerPage) * RowsPerPage

        End Function

        Private Shared Function MapToUpperBoundary(ByVal rowIndex As Integer) As Integer

            ' Return the highest index of a page containing the given index.
            Return MapToLowerBoundary(rowIndex) + RowsPerPage - 1

        End Function

    End Structure

    Private cachePages As DataPage()
    Private dataSupply As IDataPageRetriever

    Public Sub New(ByVal dataSupplier As IDataPageRetriever,
        ByVal rowsPerPage As Integer)

        dataSupply = dataSupplier
        Cache.RowsPerPage = rowsPerPage
        LoadFirstTwoPages()

    End Sub

    ' Sets the value of the element parameter if the value is in the cache.
    Private Function IfPageCached_ThenSetElement(ByVal rowIndex As Integer, ByVal columnIndex As Integer, ByRef element As String) As Boolean

        If IsRowCachedInPage(0, rowIndex) Then
            Try
                element = cachePages(0).table.Rows(rowIndex Mod RowsPerPage).Item(columnIndex).ToString()
            Catch ex As Exception
                Return False
            End Try
            Return True
        ElseIf IsRowCachedInPage(1, rowIndex) Then
            Try
                element = cachePages(1).table.Rows(rowIndex Mod RowsPerPage).Item(columnIndex).ToString()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End If

        Return False

    End Function

    Public Function RetrieveElement(ByVal rowIndex As Integer, ByVal columnIndex As Integer) As String

        Dim element As String = Nothing
        If IfPageCached_ThenSetElement(rowIndex, columnIndex, element) Then
            Return element
        Else
            Return RetrieveData_CacheIt_ThenReturnElement(rowIndex, columnIndex)
        End If

    End Function

    Private Sub LoadFirstTwoPages()

        cachePages = New DataPage() {
            New DataPage(dataSupply.SupplyPageOfData(DataPage.MapToLowerBoundary(0), RowsPerPage), 0),
            New DataPage(dataSupply.SupplyPageOfData(DataPage.MapToLowerBoundary(RowsPerPage), RowsPerPage), RowsPerPage)
        }

    End Sub

    Private Function RetrieveData_CacheIt_ThenReturnElement(ByVal rowIndex As Integer, ByVal columnIndex As Integer) As String

        ' Retrieve a page worth of data containing the requested value.
        Dim table As DataTable = dataSupply.SupplyPageOfData(DataPage.MapToLowerBoundary(rowIndex), RowsPerPage)

        ' Replace the cached page furthest from the requested cell
        ' with a new page containing the newly retrieved data.
        cachePages(GetIndexToUnusedPage(rowIndex)) = New DataPage(table, rowIndex)
        Return RetrieveElement(rowIndex, columnIndex)

    End Function

    ' Returns the index of the cached page most distant from the given index
    ' and therefore least likely to be reused.
    Private Function GetIndexToUnusedPage(ByVal rowIndex As Integer) As Integer

        If rowIndex > cachePages(0).HighestIndex AndAlso rowIndex > cachePages(1).HighestIndex Then
            Dim offsetFromPage0 As Integer = rowIndex - cachePages(0).HighestIndex
            Dim offsetFromPage1 As Integer = rowIndex - cachePages(1).HighestIndex
            If offsetFromPage0 < offsetFromPage1 Then
                Return 1
            End If
            Return 0
        Else
            Dim offsetFromPage0 As Integer = cachePages(0).LowestIndex - rowIndex
            Dim offsetFromPage1 As Integer = cachePages(1).LowestIndex - rowIndex
            If offsetFromPage0 < offsetFromPage1 Then
                Return 1
            End If
            Return 0
        End If

    End Function

    ' Returns a value indicating whether the given row index is contained
    ' in the given DataPage.
    Private Function IsRowCachedInPage(ByVal pageNumber As Integer, ByVal rowIndex As Integer) As Boolean
        Return rowIndex <= cachePages(pageNumber).HighestIndex AndAlso rowIndex >= cachePages(pageNumber).LowestIndex
    End Function

End Class