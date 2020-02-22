Imports System.Windows.Forms

Namespace AdoNet
    Public Class CommonDaoOld
        Implements ICommonDao

        Private Shared ReadOnly Db As New Db()

        Public DbCommon As Db
        Private _lastFindQuery As String
        Private _lastFindParms As Object

        Public Sub New()
            DbCommon = Db
        End Sub

        Public Function GetUserSecurity(securityObjectIdNo As Integer, securityGroupIdNo As Integer) As ArrayList _
            Implements ICommonDao.GetUserSecurity
            Dim params() As Object =
                    {"@SecurityObjectIDNo", securityObjectIdNo, "@SecurityGroupIDNo", securityGroupIdNo}
            Dim sql =
                    " SELECT top 1 Visible, Selectable, Viewable, Editable FROM GroupAccess where SecurityObjectIDNo = @SecurityObjectIDNo and SecurityGroupIDNo = @SecurityGroupIDNo"
            Return DbCommon.SqlRead(sql, params)
        End Function

        Public Function GetFilteredRecords(filterExpression As String, sortKey As String) As Object _
            Implements ICommonDao.GetFilteredRecords
            Throw New NotImplementedException
        End Function

        Public Function GetFilteredRecords(searchValue As String, tableName As String, searchField As String,
                                           returnFieldsArray As Array) As ArrayList _
            Implements ICommonDao.GetFilteredRecords
            Dim params() As Object = {"@SearchValue", searchValue}
            Dim returnFields = ""
            Dim retVal As ArrayList
            Dim sql As String = " SELECT " & returnFields & " FROM " & tableName & " where " & searchField &
                                " = @SearchValue "
            retVal = DbCommon.SqlRead(sql, params)
            Return retVal
        End Function

        'Public  Function GetRecordValues(ByVal SearchValue As String, TableName As String, ByVal SearchString As String, ReturnFieldsArray As Array) As ArrayList
        '    Dim params() As Object = {"@SearchValue", SearchValue}
        '    Dim returnFields As String = ""
        '    Dim retVal As ArrayList
        '    Dim sql As String =
        '        " SELECT top 1 " & returnFields & " FROM " & TableName & " where " & SearchString & " = @SearchValue "
        '    retVal = DbCommon.SqlRead(sql, params)
        '    '' select top 1 * from securitygroupobject
        '    Return retVal
        'End Function

        Public Function GetSortedRecordNumber(recordNo As Integer, tableName As String, sortOrder As String) As Integer _
            Implements ICommonDao.GetSortedRecordNumber
            Dim sql As String =
                    " Select IDNo FROM [" & tableName & "] order by " & sortOrder &
                    " OFFSET " & recordNo - 1 & " ROWS fetch Next 1 ROWS ONLY"
            Dim x As Object
            x = DbCommon.Scalar(sql)
            If x Is DBNull.Value Then
                Return 0
            End If
            If TypeOf x Is Integer Then
                Return DirectCast(x, Integer)
            ElseIf TypeOf x Is Short Then
                Return DirectCast(x, Short)
            ElseIf TypeOf x Is Object Then
                Return CInt(x)
            Else
                Return 0
            End If
        End Function

        Public Function GetSortedRecordPosition(idNo As Integer, tableName As String, sortOrder As String) As Integer _
            Implements ICommonDao.GetSortedRecordPosition
            Dim sql As String =
                    " Select count(*) From [" & tableName &
                    "] where " & sortOrder & " <= (Select " & sortOrder &
                    " from [" & tableName & "] where IDNo = " & idNo & ")"
            Return DbCommon.Scalar(sql)
        End Function

        Public Function GetRecordCount(tableName As String) As Integer _
            Implements ICommonDao.GetRecordCount
            Dim sql As String =
                    " Select Count(*) FROM [" & tableName & "] "
            Return DbCommon.Scalar(sql)
        End Function

        Public Function GetRecordFieldWith2Key(searchValue1 As String, searchValue2 As String, tableName As String,
                                               searchFieldName1 As String, searchFieldName2 As String,
                                               returnFieldName As String) As String _
            Implements ICommonDao.GetRecordFieldWith2Key
            Throw New NotImplementedException
        End Function

        Public Function GetRecordPosition(tableName As String, idNo As Integer) As Integer _
            Implements ICommonDao.GetRecordPosition
            Dim sql As String =
                    " Select Count(*) FROM [" & tableName & "] " &
                    " Where IDNo < " & idNo
            Return DbCommon.Scalar(sql)
        End Function

        Public Function GetRecordPositionByName(tableName As String, sortField As String, nameValue As String) _
            As Integer _
            Implements ICommonDao.GetRecordPositionByName
            Dim sql As String =
                    " Select Count(*) FROM [" & tableName & "] " &
                    " Where " & sortField & "< '" & nameValue & "'"
            Return DbCommon.Scalar(sql)
        End Function

        Public Function FindField(tableName As String, fieldName As String, searchString As String,
                                  Optional searchAnywhere As Boolean = False) As Integer _
            Implements ICommonDao.FindField
            Dim retVal As Integer
            Dim sql As String =
                    " SELECT IDNo FROM [" & tableName & "] " &
                    " Where "
            If searchAnywhere Then
                searchString = "%" & searchString.Trim() & "%"
                sql = sql & fieldName & " Like @SearchString "
            Else
                searchString = searchString.Trim() & "%"
                sql = sql & fieldName & " Like @SearchString "
            End If

            Dim params() As Object = {"@SearchString", searchString}
            _lastFindQuery = sql
            _lastFindParms = params
            retVal = DbCommon.Scalar(sql & " order by IDNo ", params)
            Return retVal
        End Function

        Public Function FindFieldContinue(tableName As String, lastIdNo As Integer) _
            Implements ICommonDao.FindFieldContinue
            Dim retVal As Integer
            If _lastFindQuery Is Nothing Then
                MessageBox.Show(
                    "No Previous search was done. Nothing to find. To initiate a find right click anywhere on the field you want to search and type the text you want to search.")
                retVal = lastIdNo
            Else
                Dim sql As String
                sql = _lastFindQuery + " and IDNo > " + lastIdNo.ToString() + " order by IDNo "
                Dim params() As Object = _lastFindParms
                retVal = DbCommon.Scalar(sql, params)
                'If RetVal = 0 Then
                '    MessageBox.Show("This is already the last matching record or no record was found with the last entered search string!")
                '    '' stay on the current record
                '    RetVal = LastIDNo
                'End If
            End If
            Return retVal
        End Function

        Public Function DeleteRecord(idNo As Integer, tableName As String) As Int16 _
            Implements ICommonDao.DeleteRecord
            Dim sql As String =
                    " Delete FROM [" & tableName & "] " &
                    " Where IDNo = " & idNo
            Return DbCommon.Delete(sql)
        End Function

        'Public  Function GetFirstDependentRecord(ByVal SearchValue As String, ByVal TableName As String, ByVal SearchFieldName As String, ByVal ReturnFieldName As String) As Integer
        '    Dim sql As String =
        '        " Select Top 1 " & ReturnFieldName & " FROM [" & TableName & "] " &
        '        " Where " & SearchFieldName & " = '" & SearchValue & "'"
        '    Return DbCommon.Scalar(sql)
        'End Function

        Public Function GetRecordFieldWithKey(searchValue As String, tableName As String, searchFieldName As String,
                                              returnFieldName As String) As String _
            Implements ICommonDao.GetRecordFieldWithKey
            Dim sql As String =
                    " Select Top 1 " & returnFieldName & " FROM [" & tableName & "] " &
                    " Where " & searchFieldName & " = @SearchValue "
            Dim params() As Object = {"@SearchValue", searchValue}
            Dim retVal = DbCommon.Scalar(sql, params)
            If retVal Is Nothing Then
                Return Nothing
            End If
            Return retVal.ToString()
        End Function

        Public Function CountRecordWithKey(searchValue As String, tableName As String, searchFieldName As String) _
            As Integer _
            Implements ICommonDao.CountRecordWithKey
            Dim sql As String =
                    " Select Count(*) FROM [" & tableName & "] " &
                    " Where " & searchFieldName & " = @SearchValue "
            Dim params() As Object = {"@SearchValue", searchValue}
            Return DbCommon.Scalar(sql, params)
        End Function

        Public Function CountRecordWith2Key(searchValue1 As Integer, searchValue2 As String,
                                            tableName As String, searchFieldName1 As String,
                                            searchFieldName2 As String) As Integer _
            Implements ICommonDao.CountRecordWith2Key
            Dim sql As String =
                    " Select Count(*) FROM [" & tableName & "] " &
                    " Where " & searchFieldName1 & " = @SearchValue1 and " & searchFieldName2 & " = '" & searchValue2 &
                    "'"
            Dim params() As Object = {"@SearchValue1", searchValue1, "@SearchValue2", searchValue2}
            Return DbCommon.Scalar(sql, params).ToString()
        End Function

        Public Function CheckIfUnique(searchValue As String, tableName As String, searchFieldName As String,
                                      currentIdNo As Int64) As String _
            Implements ICommonDao.CheckIfUnique
            Dim sql As String =
                    " Select count(*) FROM [" & tableName & "] " &
                    " Where " & searchFieldName & " = @SearchValue " &
                    " and IDNo <> @currentIDNo "
            Dim params() As Object = {"@SearchValue", searchValue, "@currentIdNo", currentIdNo}
            Dim nCount = DbCommon.Scalar(sql, params)
            Return Not nCount > 0
        End Function

        Public Function GetRecordWithIdNo(idNo As Integer, tableName As String, returnFieldName As String) As String _
            Implements ICommonDao.GetRecordWithIdNo
            Dim sql As String =
                    " Select top 1 " & returnFieldName & " FROM [" & tableName & "] " &
                    " Where IDNO = @IDNo "
            Dim params() As Object = {"@IDNo", idNo}
            Return DbCommon.Scalar(sql, params).ToString()
        End Function

        Public Function GetRecordDateTimeStamp(idNo As Integer, tableName As String, dateTimeStampField As String) _
            As Object _
            Implements ICommonDao.GetRecordDateTimeStamp
            Dim sql As String =
                    " Select top 1 " & dateTimeStampField & " FROM [" & tableName & "] " &
                    " Where IdNo = @IdNo "
            Dim params() As Object = {"@IDNo", idNo}
            Dim retValue As Object
            retValue = DbCommon.Scalar(sql, params)
            Return retValue
            'Return System.Text.Encoding.ASCII.GetString(retValue)
        End Function

        Public Function IsFieldUnique(tableName As String, fieldName As String) As Boolean _
            Implements ICommonDao.IsFieldUnique
            Dim sql As String
            sql = "SELECT count(*) " &
                  "FROM sys.indexes i " &
                  "inner join sys.index_columns ic " &
                  "ON i.object_id = ic.object_id And i.index_id = ic.index_id " &
                  "inner join sys.columns c ON " &
                  "ic.object_id = c.object_id AND c.column_id = ic.column_id " &
                  "WHERE i.object_ID = OBJECT_ID(@TableName) and c.name = @FieldName and i.is_unique = 1 "
            'Dim sql As String = "Select count(*) from information_schema.table_constraints TC " &
            '    "inner join information_schema.constraint_column_usage CC on TC.Constraint_Name = CC.Constraint_Name " &
            '    "where TC.constraint_type = 'Unique' and cc.TABLE_NAME = @TableName and cc.COLUMN_NAME = @FieldName "
            Dim params() As Object = {"@TableName", tableName, "@FieldName", fieldName}
            Dim nCount As Integer
            nCount = DbCommon.Scalar(sql, params)
            If nCount > 0 Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Function GetSqlValue (Of TType)(sqlStatement As String, tableName As String, condition As String) _
            As TType Implements ICommonDao.GetSqlValue
            Throw New NotImplementedException
        End Function

        Public Function UpdateRecordWithIdNo (Of T)(idNo As Integer, tableName As String, fieldName As String,
                                                    value As T) As Integer Implements ICommonDao.UpdateRecordWithIdNo
            Throw New NotImplementedException
        End Function

        Public Function HasRecordChanged(idNo As Integer, tableName As String, timeStampValue As Byte,
                                         Optional ByVal timeStampedField As String = "DateTimeStamp") As Boolean _
            Implements ICommonDao.HasRecordChanged
            Dim sql As String = " Select count(*) FROM [" & tableName & "] " &
                                " Where IdNo = @IdNo and timeStampedField = @timeStampValue "
            Dim params() As Object = {"@IDNo", idNo, "@timeStampValue", timeStampValue}
            Dim nCount = DbCommon.Scalar(sql, params)
            Return Not nCount > 0
        End Function

        Public Function GetLastSortKey(searchValue As String, tableName As String) As String _
            Implements ICommonDao.GetLastSortKey
            Dim sql As String
            If searchValue Is Nothing OrElse searchValue = "" Then
                sql = " Select Top 1 SortKey FROM " & tableName &
                      " Where len(RTrim(SortKey)) <= 4" &
                      " order by SortKey DESC "
                Dim cResult = DbCommon.Scalar(sql)
                If cResult Is Nothing Then
                    Return ""
                End If
                Return cResult
            Else
                searchValue = searchValue.Trim()
                sql = "Select Top 1 SortKey FROM " & tableName &
                      " Where SortKey Like @SearchValue + '%' and len(RTrim(SortKey)) <= " &
                      searchValue.Trim().Length + 4 &
                      " order by SortKey DESC "
                Dim parms() As Object = {"@SearchValue", searchValue}
                Return DbCommon.Scalar(sql, parms)
            End If
        End Function

        'Private Sub ExecuteSqlTransaction(ByVal connectionString As String)
        '    Using connection As New SqlConnection(connectionString)
        '        connection.Open()

        '        Dim command As SqlCommand = connection.CreateCommand()
        '        Dim transaction As SqlTransaction

        '        ' Start a local transaction
        '        transaction = connection.BeginTransaction("SampleTransaction")

        '        ' Must assign both transaction object and connection
        '        ' to Command object for a pending local transaction.
        '        command.Connection = connection
        '        command.Transaction = transaction

        '        Try
        '            command.CommandText =
        '                "Insert into Region (RegionID, RegionDescription) VALUES (100, 'Description')"
        '            command.ExecuteNonQuery()
        '            command.CommandText =
        '                "Insert into Region (RegionID, RegionDescription) VALUES (101, 'Description')"

        '            command.ExecuteNonQuery()

        '            ' Attempt to commit the transaction.
        '            transaction.Commit()
        '            Console.WriteLine("Both records are written to database.")

        '        Catch ex As Exception
        '            Console.WriteLine("Commit Exception Type: {0}", ex.GetType())
        '            Console.WriteLine("  Message: {0}", ex.Message)

        '            ' Attempt to roll back the transaction.
        '            Try
        '                transaction.Rollback()

        '            Catch ex2 As Exception
        '                ' This catch block will handle any errors that may have occurred
        '                ' on the server that would cause the rollback to fail, such as
        '                ' a closed connection.
        '                Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType())
        '                Console.WriteLine("  Message: {0}", ex2.Message)
        '            End Try
        '        End Try
        '    End Using
        'End Sub

        'Private Sub ExecuteSqlTransaction(ByVal connectionString As String)
        '    Using connection As New SqlConnection(connectionString)
        '        connection.Open()

        '        Dim command As SqlCommand = connection.CreateCommand()
        '        Dim transaction As SqlTransaction

        '        ' Start a local transaction
        '        transaction = connection.BeginTransaction("SampleTransaction")

        '        ' Must assign both transaction object and connection
        '        ' to Command object for a pending local transaction.
        '        command.Connection = connection
        '        command.Transaction = transaction

        '        Try
        '            command.CommandText =
        '                "Insert into Region (RegionID, RegionDescription) VALUES (100, 'Description')"
        '            command.ExecuteNonQuery()
        '            command.CommandText =
        '                "Insert into Region (RegionID, RegionDescription) VALUES (101, 'Description')"

        '            command.ExecuteNonQuery()

        '            ' Attempt to commit the transaction.
        '            transaction.Commit()
        '            Console.WriteLine("Both records are written to database.")

        '        Catch ex As Exception
        '            Console.WriteLine("Commit Exception Type: {0}", ex.GetType())
        '            Console.WriteLine("  Message: {0}", ex.Message)

        '            ' Attempt to roll back the transaction.
        '            Try
        '                transaction.Rollback()

        '            Catch ex2 As Exception
        '                ' This catch block will handle any errors that may have occurred
        '                ' on the server that would cause the rollback to fail, such as
        '                ' a closed connection.
        '                Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType())
        '                Console.WriteLine("  Message: {0}", ex2.Message)
        '            End Try
        '        End Try
        '    End Using
        'End Sub

        Public Function GetRecords(tableName As String, sortKey As String, ByVal ParamArray fieldNames() As String) _
            Implements ICommonDao.GetRecords
            Dim fields = String.Join(",", fieldNames)
            Dim sql = " SELECT " & fields & " from [" & tableName & "] order by " & sortKey
            Return DbCommon.SqlRead(sql)
        End Function

        Public Function GetRecordsFiltered(tableName As String, sortKey As String, filterKey As String,
                                           ByVal ParamArray fieldNames() As String) _
            Implements ICommonDao.GetRecordsFiltered
            Dim fields = String.Join(",", fieldNames)
            Dim sql = " SELECT " & fields & " from [" & tableName & "] where " & filterKey & " order by " & sortKey
            Return DbCommon.SqlRead(sql)
        End Function
    End Class
End Namespace