Imports System.Data.SqlClient

Namespace AdoNet

    Public Class DataRetriever
        Implements IDataPageRetriever

        Private ReadOnly _tableName As String
        Private ReadOnly _command As SqlCommand
        Private ReadOnly _columnList As String
        Private ReadOnly _db
        Private ReadOnly _dataFilter As String
        Private ReadOnly _columnsToSortBy As String()
        Private _sortkey As String

        Public Sub New()

        End Sub

        Public Sub New(tableName As String, Optional pColumnList As String = Nothing, Optional connectionName As String = Nothing, Optional dataFilter As String = Nothing, Optional columnToSortBy As String = Nothing)
            _db = New Db(connectionName)
            Dim connection As New SqlConnection(_db.GetConnectionString())
            connection.Open()
            _command = connection.CreateCommand()
            Me._tableName = tableName
            _columnList = pColumnList
            _dataFilter = dataFilter
            _columnsToSortBy = columnToSortBy.Split(",")
            _sortkey = columnToSortBy
        End Sub

        Private rowCountValue As Integer = -1

        Public ReadOnly Property RowCount() As Integer
            Get
                ' Return the existing value if it has already been determined.
                If Not rowCountValue = -1 Then
                    Return rowCountValue
                End If

                ' Retrieve the row count from the database.
                _command.CommandText = "SELECT COUNT(*) FROM " & _tableName
                rowCountValue = CInt(_command.ExecuteScalar())
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
                ' "Primary_Key,Item_Code,GTin,ItemNameEnglish,Price_Cash,Pack1,Pack2,Pack3"
                _command.CommandText = "SELECT " & _columnList & " FROM " & _tableName & IIf(_dataFilter Is Nothing, "", " where " & _dataFilter)
                Dim adapter As New SqlDataAdapter()
                adapter.SelectCommand = _command
                Dim table As New DataTable()
                table.Locale = System.Globalization.CultureInfo.InvariantCulture
                adapter.FillSchema(table, SchemaType.Source)
                columnsValue = table.Columns
                Return columnsValue
            End Get
        End Property

        Private commaSeparatedListOfColumnNamesValue As String = _columnList

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
                    If column.ColumnName.Contains(" ") Then
                        commaSeparatedColumnNames.Append("[" & column.ColumnName & "]")
                    Else
                        commaSeparatedColumnNames.Append(column.ColumnName)
                    End If

                    firstColumn = False
                Next

                commaSeparatedListOfColumnNamesValue =
                    commaSeparatedColumnNames.ToString()
                Return commaSeparatedListOfColumnNamesValue
            End Get
        End Property

        ' Declare variables to be reused by the SupplyPageOfData method.

        Private adapter As New SqlDataAdapter()

        Public Function SupplyPageOfData(ByVal lowerPageBoundary As Integer, ByVal rowsPerPage As Integer) As DataTable Implements IDataPageRetriever.SupplyPageOfData

            ' Store the name of the ID column. This column must contain unique
            ' values so the SQL below will work properly.
            Dim sortFields As String = ""
            For Each item In _columnsToSortBy
                sortFields = sortFields & "[" & item & "]+"
            Next
            sortFields = Left(sortFields, Len(sortFields) - 1)
            '_columnToSortBy = Me.Columns(0).ColumnName

            'If Not Me.Columns(columnToSortBy).Unique Then
            '    Throw New InvalidOperationException(String.Format(
            '        "Column {0} must contain unique values.", columnToSortBy))
            'End If

            ' Retrieve the specified number of rows from the database, starting
            ' with the row specified by the lowerPageBoundary parameter.
            _command.CommandText = "Select Top " & rowsPerPage & " " &
                                   CommaSeparatedListOfColumnNames & " From " & _tableName &
                                   " WHERE " & _sortkey & " NOT IN (SELECT TOP " &
                                   lowerPageBoundary & " " & _sortkey & " From [" &
                                   _tableName & "] Order by " & _sortkey &
                                   ") Order By " & _sortkey

            adapter.SelectCommand = _command
            Dim table As New DataTable()
            table.Locale = System.Globalization.CultureInfo.InvariantCulture
            adapter.Fill(table)
            Return table

        End Function

    End Class

End Namespace