Imports System.Data
Imports AATM.DataLayer.AdoNet
Imports System.Linq
Imports System.Collections.Generic

Namespace DataLayer.AdoNet
    Public Class TableViewerDao
        Private ReadOnly _db As New Db()

        Public Function GetTables() As DataTable
            Return _db.ExecuteReader("SELECT s.name AS SchemaName, t.name AS TableName, " &
                                     "QUOTENAME(s.name) + '.' + QUOTENAME(t.name) AS DisplayName " &
                                     "FROM sys.tables t INNER JOIN sys.schemas s ON s.schema_id = t.schema_id " &
                                     "WHERE t.is_ms_shipped = 0 ORDER BY s.name, t.name")
        End Function

        Public Function GetRecords(schemaName As String, tableName As String, Optional isArabic As Boolean = False) As DataTable
            Dim tables = GetTables()
            Dim found As Boolean = False
            For Each row As DataRow In tables.Rows
                If String.Equals(CStr(row("SchemaName")), schemaName, StringComparison.Ordinal) AndAlso
                   String.Equals(CStr(row("TableName")), tableName, StringComparison.Ordinal) Then
                    found = True
                    Exit For
                End If
            Next
            If Not found Then Throw New ArgumentException("The selected table is no longer available.")
            ' Identifiers come only from server metadata and are still quoted individually.
            Dim metadata = _db.ExecuteReader(
                "SELECT s.name SchemaName, t.name TableName, c.name ColumnName, c.system_type_id TypeId, " &
                "CASE WHEN EXISTS (SELECT 1 FROM sys.indexes i INNER JOIN sys.index_columns ic ON ic.object_id=i.object_id AND ic.index_id=i.index_id " &
                "WHERE i.object_id=t.object_id AND i.is_unique=1 AND i.has_filter=0 AND ic.column_id=c.column_id AND ic.key_ordinal=1 " &
                "AND NOT EXISTS (SELECT 1 FROM sys.index_columns x WHERE x.object_id=i.object_id AND x.index_id=i.index_id AND x.key_ordinal>1)) THEN 1 ELSE 0 END IsUnique " &
                "FROM sys.tables t INNER JOIN sys.schemas s ON s.schema_id=t.schema_id INNER JOIN sys.columns c ON c.object_id=t.object_id WHERE t.is_ms_shipped=0")
            Dim foreignKeys = _db.ExecuteReader(
                "SELECT pc.name SourceColumn, rs.name TargetSchema, rt.name TargetTable, rc.name TargetColumn " &
                "FROM sys.foreign_key_columns f INNER JOIN sys.tables pt ON pt.object_id=f.parent_object_id " &
                "INNER JOIN sys.schemas ps ON ps.schema_id=pt.schema_id INNER JOIN sys.columns pc ON pc.object_id=pt.object_id AND pc.column_id=f.parent_column_id " &
                "INNER JOIN sys.tables rt ON rt.object_id=f.referenced_object_id INNER JOIN sys.schemas rs ON rs.schema_id=rt.schema_id " &
                "INNER JOIN sys.columns rc ON rc.object_id=rt.object_id AND rc.column_id=f.referenced_column_id " &
                "WHERE ps.name=@Schema AND pt.name=@Table AND NOT EXISTS (SELECT 1 FROM sys.foreign_key_columns x WHERE x.constraint_object_id=f.constraint_object_id AND x.constraint_column_id>1)",
                "@Schema", schemaName, "@Table", tableName)
            Return _db.ExecuteReader(BuildRecordsSql(metadata, foreignKeys, schemaName, tableName, isArabic))
        End Function

        Friend Shared Function BuildRecordsSql(metadata As DataTable, foreignKeys As DataTable, schemaName As String, tableName As String, isArabic As Boolean) As String
            Dim sourceColumns = metadata.Rows.Cast(Of DataRow)().Where(Function(row) CStr(row("SchemaName")) = schemaName AndAlso CStr(row("TableName")) = tableName).ToList()
            Dim fields = sourceColumns.Select(Function(row) "src." & Quote(CStr(row("ColumnName")))).ToList()
            For index = 0 To sourceColumns.Count - 1
                Dim source = sourceColumns(index)
                Dim column = CStr(source("ColumnName"))
                ' The table's own name is already displayed beside its code.
                If column.Equals(tableName & "Code", StringComparison.OrdinalIgnoreCase) AndAlso
                    sourceColumns.Any(Function(row) CStr(row("ColumnName")).Equals(tableName & "Name", StringComparison.OrdinalIgnoreCase) OrElse
                                                    CStr(row("ColumnName")).Equals(tableName & "NameAra", StringComparison.OrdinalIgnoreCase)) Then Continue For
                Dim targetSchema = schemaName
                Dim targetTable As String = Nothing
                Dim targetColumn As String = Nothing
                Dim fk = foreignKeys.Rows.Cast(Of DataRow)().Where(Function(row) CStr(row("SourceColumn")) = column).ToList()
                If fk.Count = 1 Then
                    targetSchema = CStr(fk(0)("TargetSchema"))
                    targetTable = CStr(fk(0)("TargetTable"))
                    targetColumn = CStr(fk(0)("TargetColumn"))
                ElseIf fk.Count = 0 Then
                    ' Established Accounts conventions; do not guess enum/status meanings.
                    If column.Equals("NationalityCode", StringComparison.OrdinalIgnoreCase) OrElse column.Equals("NationalityId", StringComparison.OrdinalIgnoreCase) Then
                        targetTable = "Country"
                        targetColumn = "CountryCode"
                    ElseIf column.EndsWith("IdNo", StringComparison.OrdinalIgnoreCase) AndAlso column.Length > 4 Then
                        targetTable = column.Substring(0, column.Length - 4)
                        targetColumn = "IdNo"
                    ElseIf column.EndsWith("Code", StringComparison.OrdinalIgnoreCase) AndAlso column.Length > 4 Then
                        targetTable = column.Substring(0, column.Length - 4)
                        targetColumn = column
                    ElseIf column.EndsWith("Id", StringComparison.OrdinalIgnoreCase) AndAlso column.Length > 2 Then
                        targetTable = column.Substring(0, column.Length - 2)
                        targetColumn = If(New Integer() {167, 175, 231, 239}.Contains(CInt(source("TypeId"))), targetTable & "Code", "IdNo")
                    End If
                End If
                If targetTable Is Nothing Then Continue For
                Dim target = metadata.Rows.Cast(Of DataRow)().Where(Function(row) CStr(row("SchemaName")).Equals(targetSchema, StringComparison.OrdinalIgnoreCase) AndAlso CStr(row("TableName")).Equals(targetTable, StringComparison.OrdinalIgnoreCase)).ToList()
                Dim key = target.FirstOrDefault(Function(row) CStr(row("ColumnName")).Equals(targetColumn, StringComparison.OrdinalIgnoreCase))
                If key Is Nothing Then Continue For
                Dim stringTypes As Integer() = {167, 175, 231, 239}
                If fk.Count = 0 AndAlso CInt(key("TypeId")) <> CInt(source("TypeId")) AndAlso
                    Not (stringTypes.Contains(CInt(key("TypeId"))) AndAlso stringTypes.Contains(CInt(source("TypeId")))) Then Continue For
                Dim english = target.FirstOrDefault(Function(row) CStr(row("ColumnName")).Equals(targetTable & "Name", StringComparison.OrdinalIgnoreCase))
                Dim arabic = target.FirstOrDefault(Function(row) CStr(row("ColumnName")).Equals(targetTable & "NameAra", StringComparison.OrdinalIgnoreCase))
                If targetTable.Equals("Country", StringComparison.OrdinalIgnoreCase) AndAlso column.StartsWith("Nationality", StringComparison.OrdinalIgnoreCase) Then
                    english = If(target.FirstOrDefault(Function(row) CStr(row("ColumnName")).Equals("Nationality", StringComparison.OrdinalIgnoreCase)), english)
                    arabic = If(target.FirstOrDefault(Function(row) CStr(row("ColumnName")).Equals("NationalityAra", StringComparison.OrdinalIgnoreCase)), arabic)
                End If
                If english Is Nothing AndAlso arabic Is Nothing Then Continue For
                Dim preferred = If(isArabic, If(arabic, english), If(english, arabic))
                Dim alternate = If(isArabic, If(english, arabic), If(arabic, english))
                ' CONVERT preserves a column's collation; both COALESCE branches must agree.
                Dim label = "COALESCE(NULLIF(CONVERT(nvarchar(max),lk." & Quote(CStr(preferred("ColumnName"))) & ") COLLATE DATABASE_DEFAULT,N''), CONVERT(nvarchar(max),lk." & Quote(CStr(alternate("ColumnName"))) & ") COLLATE DATABASE_DEFAULT)"
                Dim code = target.FirstOrDefault(Function(row) CStr(row("ColumnName")).Equals(targetTable & "Code", StringComparison.OrdinalIgnoreCase))
                Dim codeExpression = "CONVERT(nvarchar(max),lk." & Quote(CStr(If(code, key)("ColumnName"))) & ") COLLATE DATABASE_DEFAULT"
                Dim display = "COALESCE(NULLIF(" & codeExpression & ",N'') + N' - ',N'') + NULLIF(" & label & ",N'')"
                Dim comparison = "lk." & Quote(CStr(key("ColumnName"))) & " = src." & Quote(column)
                If New Integer() {167, 175, 231, 239}.Contains(CInt(source("TypeId"))) Then
                    comparison = "CONVERT(nvarchar(4000),lk." & Quote(CStr(key("ColumnName"))) & ") COLLATE DATABASE_DEFAULT = CONVERT(nvarchar(4000),src." & Quote(column) & ") COLLATE DATABASE_DEFAULT"
                End If
                ' Unconstrained legacy codes must resolve to exactly one row before showing a name.
                If CInt(key("IsUnique")) <> 1 Then display = "CASE WHEN COUNT(*) = 1 THEN MAX(" & display & ") END"
                fields(index) = "COALESCE((SELECT " & display & " FROM " & Quote(targetSchema) & "." & Quote(targetTable) & " lk WHERE " & comparison & "), CONVERT(nvarchar(max),src." & Quote(column) & ") COLLATE DATABASE_DEFAULT) AS " & Quote(column)
            Next
            Return "SELECT " & String.Join(", ", fields) & " FROM " & Quote(schemaName) & "." & Quote(tableName) & " src"
        End Function

        Private Shared Function Quote(identifier As String) As String
            Return "[" & identifier.Replace("]", "]]") & "]"
        End Function
    End Class
End Namespace
