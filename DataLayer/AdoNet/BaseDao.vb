Imports System.Dynamic
Imports System.Globalization
Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.Libraries.AatmInterfaces

Namespace AdoNet

    Public Class BaseDao
        Implements IBaseDao

        Private ReadOnly _db As New Db()

        Private _lastFindParms As Object
        Private _lastFindQuery As String

        Public Sub New()
        End Sub

        Public Function CheckIfUnique(searchValue As String, tableName As String, searchFieldName As String,
                                      currentIdNo As Int64) As String _
            Implements IBaseDao.CheckIfUnique
            Dim sql As String =
                    " Select count(*) FROM [" & tableName & "] " &
                    " Where " & searchFieldName & " = @SearchValue " &
                    " and IdNo <> @currentIdNo "
            Dim params() As Object = {"@SearchValue", searchValue, "@currentIdNo", currentIdNo}
            Dim nCount = _db.Scalar(sql, params)
            Return Not nCount > 0
        End Function

        Public Function CountRecordWith2Key(searchValue1 As Integer, searchValue2 As String,
                                            tableName As String, searchFieldName1 As String,
                                            searchFieldName2 As String) As Integer _
            Implements IBaseDao.CountRecordWith2Key
            Dim sql As String =
                    " Select Count(*) FROM [" & tableName & "] " &
                    " Where " & searchFieldName1 & " = @SearchValue1 and " & searchFieldName2 & " = '" & searchValue2 &
                    "'"
            Dim params() As Object = {"@SearchValue1", searchValue1, "@SearchValue2", searchValue2}
            Return _db.Scalar(sql, params).ToString()
        End Function

        Public Function CountRecordWithKey(searchValue As String, tableName As String, searchFieldName As String) _
            As Integer _
            Implements IBaseDao.CountRecordWithKey
            Dim sql As String =
                    " Select Count(*) FROM [" & tableName & "] " &
                    " Where " & searchFieldName & " = @SearchValue "
            Dim params() As Object = {"@SearchValue", searchValue}
            Return _db.Scalar(sql, params)
        End Function

        Public Function DeleteRecord(idNo As Int32, tableName As String) As Int32 _
            Implements IBaseDao.DeleteRecord
            If Strings.Right(tableName, 5).ToLower() = "_view" Then
                tableName = Strings.Left(tableName, Strings.Len(tableName) - 5)
            End If
            Dim sql As String =
                    " Delete FROM [" & tableName & "] " &
                    " Where IdNo = " & idNo
            Return _db.Delete(sql)
        End Function

        Public Function FindField(tableName As String, fieldName As String, searchString As String, Optional searchPlace As Char = "A", Optional filter As String = Nothing) As Integer Implements IBaseDao.FindField
            Dim retVal As Integer
            Dim sql As String =
                        " SELECT IdNo FROM [" & tableName & "] " &
                        " Where "
            If Not (filter Is Nothing OrElse filter = "") Then
                sql = sql & filter.Trim() & " and "
            End If
            If searchString Is Nothing OrElse searchString = "" Then
                sql = sql & " (" & fieldName & " Is Null or " & fieldName & " = '') "
            Else
                If searchPlace = "A" Then
                    searchString = "%" & searchString.Trim() & "%"
                    sql = sql & fieldName & " Like @SearchString "
                ElseIf searchPlace = "S" Then
                    searchString = searchString.Trim() & "%"
                    sql = sql & fieldName & " Like @SearchString "
                ElseIf searchPlace = "E" Then
                    searchString = searchString.Trim()
                    sql = sql & fieldName & " = @SearchString "
                End If
            End If
            Dim params() As Object = {"@SearchString", searchString}
            _lastFindQuery = sql
            _lastFindParms = params
            retVal = _db.Scalar(sql & " order by IdNo ", params)
            Return retVal
        End Function

        Public Function FindFieldNew(tableName As String, findableControl As IFindableControl, Optional filter As String = Nothing) As Integer Implements IBaseDao.FindFieldNew
            Dim retVal As Integer
            Dim sql As String = " SELECT IdNo FROM [" & tableName & "] " & " Where "
            Dim searchString As String

            If Not (filter Is Nothing OrElse filter = "") Then
                sql &= filter.Trim() & " and " & findableControl.FieldName.Trim() & " "
            End If
            If findableControl.FindDataType = IFindableControl.DataTypeEnum.String Then
                If findableControl.BegFindValue Is Nothing OrElse findableControl.BegFindValue = "" Then
                    sql &= " (" & findableControl.FieldName & " Is Null or " & findableControl.FieldName & " = '') "
                    retVal = _db.Scalar(sql & " order by IdNo ")
                Else
                    sql &= findableControl.FieldName.Trim()
                    If findableControl.SearchPlace = IFindableControl.SearchPlaceEnum.AnywhereOnField Then
                        searchString = "%" & RTrim(findableControl.BegFindValue) + "%"
                        sql &= " Like @searchString"
                    ElseIf findableControl.SearchPlace = IFindableControl.SearchPlaceEnum.StartOfField Then
                        searchString = RTrim(findableControl.BegFindValue) + "%"
                        sql &= " Like @searchString"
                    Else  ' findableControl.searchPlace = IFindableControl.SearchPlaceEnum.ExactValue
                        searchString = RTrim(findableControl.BegFindValue)
                        sql &= " = @searchString"
                    End If
                    Dim params() As Object = {"@SearchString", searchString}
                    _lastFindQuery = sql
                    _lastFindParms = params
                    retVal = _db.Scalar(sql & " order by IdNo ", params)
                End If
            ElseIf findableControl.FindDataType = IFindableControl.DataTypeEnum.Date Then
                sql &= findableControl.FieldName.Trim()
                retVal = FindDateField(tableName, findableControl, filter)
            ElseIf findableControl.FindDataType = IFindableControl.DataTypeEnum.Integer Or
                   findableControl.FindDataType = IFindableControl.DataTypeEnum.Decimal Then
                If findableControl.BegFindValue Is Nothing Then
                    sql &= " " & findableControl.FieldName & " Is Null "
                    _lastFindQuery = sql
                    retVal = _db.Scalar(sql & " order by IdNo ")
                ElseIf findableControl.EndFindValue Is Nothing Then
                    sql &= findableControl.FieldName.Trim()
                    searchString = findableControl.BegFindValue
                    sql &= " = @searchString"
                    Dim params() As Object = {"@SearchString", searchString}
                    _lastFindParms = params
                    retVal = _db.Scalar(sql & " order by IdNo ", params)
                Else
                    searchString = findableControl.BegFindValue
                    Dim searchString2 = findableControl.EndFindValue
                    sql &= findableControl.FieldName.Trim() & ">= @searchString and " & findableControl.FieldName.Trim() & " <= @searchString2"
                    Dim params() As Object = {"@SearchString", searchString, "@searchString2", searchString2}
                    _lastFindParms = params
                    retVal = _db.Scalar(sql & " order by IdNo ", params)
                End If
            ElseIf findableControl.SearchMode = IFindableControl.SearchModeEnum.CheckBox Then
                sql &= findableControl.FieldName.Trim()
                searchString = IIf(findableControl.BegFindValue, "1", "0")
                sql &= " = @searchString"
                Dim params() As Object = {"@SearchString", searchString}
                _lastFindQuery = sql
                _lastFindParms = params
                retVal = _db.Scalar(sql & " order by IdNo ", params)
            End If
            Return retVal
        End Function

        Public Function FindDateField(tableName As String, findableControl As IFindableControl, Optional filter As String = Nothing) As Integer Implements IBaseDao.FindDateField
            Dim retVal As Integer
            Dim searchString As String
            Dim sql As String = " SELECT IdNo FROM [" & tableName & "] Where "
            If Not (filter Is Nothing OrElse filter = "") Then
                sql = sql & filter.Trim() & " and "
            End If
            Dim dBegDate As Date? = findableControl.BegFindValue
            Dim dEndDate As Date? = findableControl.EndFindValue
            If dBegDate Is Nothing Then
                searchString = findableControl.FieldName & " Is Null"
            Else
                Dim dBDate As Date = Convert.ToDateTime(dBegDate)
                Dim dEDate As Date
                If dEndDate Is Nothing Then
                    dEDate = DateAndTime.DateAdd(DateInterval.Day, 1, dBDate)
                    searchString = findableControl.FieldName & " >= '" & dBDate.ToString("yyyyMMdd", CultureInfo.InvariantCulture) & "' and " & findableControl.FieldName & " < '" & dEDate.ToString("yyyMMdd", CultureInfo.InvariantCulture) & "'"
                Else
                    dEDate = DateAndTime.DateAdd(DateInterval.Day, 1, Convert.ToDateTime(dEndDate))
                    'dBDate = Convert.ToDateTime(dBegDate)
                    'dEDate = DateAndTime.DateAdd(DateInterval.Day, 1, dEDate)
                    searchString = findableControl.FieldName & " >= '" & dBDate.ToString("yyyyMMdd", CultureInfo.InvariantCulture) & "' and " & findableControl.FieldName & " < '" & dEDate.ToString("yyyMMdd", CultureInfo.InvariantCulture) & "'"
                End If
            End If
            sql = sql & searchString
            _lastFindQuery = sql
            retVal = _db.Scalar(sql & " order by IdNo ")
            Return retVal
        End Function

        'Public Function FindField(tableName As String, fieldName As String, searchString As String, Optional searchPlace As Char = "A", Optional filter As String = Nothing) As Integer Implements IBaseDao.FindField
        '    Dim retVal As Integer
        '    If searchString Is Nothing Or searchString = "" Then
        '        retVal = 0
        '    Else
        '        Dim sql As String =
        '                " SELECT IdNo FROM [" & tableName & "] " &
        '                " Where "
        '        If Not (filter Is Nothing OrElse filter = "") Then
        '            sql = sql & filter.Trim() & " and "
        '        End If
        '        If searchPlace = "A" Then
        '            searchString = "%" & searchString.Trim() & "%"
        '            sql = sql & fieldName & " Like @SearchString "
        '        Else
        '            searchString = searchString.Trim() & "%"
        '            sql = sql & fieldName & " Like @SearchString "
        '        End If

        '        Dim params() As Object = {"@SearchString", searchString}
        '        _lastFindQuery = sql
        '        _lastFindParms = params
        '        retVal = _db.Scalar(sql & " order by IdNo ", params)
        '    End If
        '    Return retVal
        'End Function

        Public Function FindFieldContinue(tableName As String, lastIdNo As Int32) _
            Implements IBaseDao.FindFieldContinue
            Dim retVal As Integer
            If _lastFindQuery Is Nothing Then
                MessageBox.Show(
                    "No Previous search was done. Nothing to find. To initiate a find right click anywhere on the field you want to search and type the text you want to search.")
                retVal = lastIdNo
            Else
                Dim sql As String
                sql = _lastFindQuery + " and IdNo > " + lastIdNo.ToString() + " order by IdNo "
                Dim params() As Object = _lastFindParms
                retVal = _db.Scalar(sql, params)
                'If RetVal = 0 Then
                '    MessageBox.Show("This is already the last matching record or no record was found with the last entered search string!")
                '    '' stay on the current record
                '    RetVal = LastIdNo
                'End If
            End If
            Return retVal
        End Function

        Public Function GetControlSecurityIdNo(searchValue As String) As String Implements IBaseDao.GetControlSecurityIdNo
            Dim sql As String =
                    " Select Top 1 IdNo FROM SecurityObject_View1 " &
                    " Where FullPathName = @SearchValue "
            Dim params() As Object = {"@SearchValue", searchValue}
            Dim retVal = _db.Scalar(sql, params)
            If retVal Is Nothing Then
                Return Nothing
            End If
            Return retVal.ToString()
        End Function

        Public Function GetField(searchValue As String, tableName As String, searchFieldName As String, returnFieldName As String) As Object Implements IBaseDao.GetField
            Dim sql As String =
                    " Select Top 1 " & returnFieldName & " FROM [" & tableName & "] " &
                    " Where " & searchFieldName & " = @SearchValue "
            Dim params() As Object = {"@SearchValue", searchValue}
            Dim retVal = _db.Scalar(sql, params)
            If retVal Is Nothing Or IsDBNull(retVal) Then
                Return Nothing
            End If
            Return retVal
        End Function

        Public Function GetFieldWithIdNo(idNo As Object, tableName As String, returnFieldName As String) As Object Implements IBaseDao.GetFieldWithIdNo
            Dim sql As String =
                    " Select top 1 " & returnFieldName & " FROM [" & tableName & "] " &
                    " Where IdNo = @IdNo "
            Dim params() As Object = {"@IdNo", idNo}
            Return _db.Scalar(sql, params)
        End Function

        Public Function GetFieldsWithIdNo(idNo As Object, tableName As String, fieldsList As String) As ExpandoObject Implements IBaseDao.GetFieldsWithIdNo
            Dim sql As String = " Select top 1 " & fieldsList & " FROM [" & tableName & "] " & " Where IdNo = @IdNo "
            Dim params() As Object = {"@IdNo", idNo}
            Dim values As Object
            values = _db.SqlRead(sql, params)
            Dim fields = fieldsList.Split(",")
            Dim obj As New ExpandoObject
            Dim i As Int16 = 0
            For Each item In fields
                CreateDynamicObject(obj, item, values(i))
                i = i + 1
            Next
            Return obj
        End Function

        Public Function GetRecordFieldsFiltered(tableName As String, fieldList As String, filter As String) As ExpandoObject Implements IBaseDao.GetRecordFieldsFiltered
            Dim sql As String =
                    " Select " & fieldList & " FROM [" & tableName & "] " &
                    " Where " & filter
            Dim values As Object
            values = _db.SqlRead(sql)
            Dim fields = fieldList.Split(",")
            Dim obj As Object
            obj = New ExpandoObject
            Dim i As Int16 = 0
            For Each item In fields
                CreateDynamicObject(obj, item, values(i))
                i = i + 1
            Next
            Return obj
        End Function

        Public Sub CreateDynamicObject(ByRef obj As ExpandoObject, ByVal propertyName As String, ByVal propertyValue As Object)
            CType(obj, IDictionary(Of String, Object))(propertyName) = propertyValue
        End Sub

        Public Function GetIdNoOfSortedPositionNumber(recordNo As Integer, tableName As String, sortOrder As String, Optional filter As String = Nothing) As Integer Implements IBaseDao.GetIdNoOfSortedPositionNumber
            Dim filterKey As String
            If filter Is Nothing Then
                filterKey = ""
            Else
                filterKey = " where " & filter
            End If
            If recordNo = 0 Then
                Return 0
            Else
                Dim sql As String =
                        " Select IdNo FROM [" & tableName & "] " & filterKey & " order by " & sortOrder &
                        " OFFSET " & recordNo - 1 & " ROWS fetch Next 1 ROWS ONLY"
                Dim x As Object
                x = _db.Scalar(sql)
                If x Is DBNull.Value Then
                    If recordNo > 0 Then
                        ' return the last record
                        If sortOrder.Trim().IndexOf(" DESC", StringComparison.OrdinalIgnoreCase) Then
                            sortOrder = Replace(sortOrder, " DESC", " ASC")
                        ElseIf sortOrder.Trim().IndexOf(" ASC", StringComparison.OrdinalIgnoreCase) Then
                            sortOrder = Replace(sortOrder, " DESC", " ASC")
                        Else
                            sortOrder = sortOrder.Trim() + " DESC"
                        End If
                        sortOrder = Replace(sortOrder, " DESC", " ASC", )
                        sql = "Select TOP 1 IdNo FROM [" & tableName & "] " & filterKey & " order by " & sortOrder
                        x = _db.Scalar(sql)
                    Else
                        Return 0
                    End If
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
            End If
        End Function

        Public Function GetLastSortKey(searchValue As String, tableName As String) As String _
            Implements IBaseDao.GetLastSortKey
            Dim sql As String
            If searchValue Is Nothing OrElse searchValue = "" Then
                sql = " Select Top 1 SortKey FROM " & tableName &
                      " Where len(RTrim(SortKey)) <= 4" &
                      " order by SortKey DESC "
                Dim cResult = _db.Scalar(sql)
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
                Return _db.Scalar(sql, parms)
            End If
        End Function

        Public Function GetFieldOnMaxField(searchFieldName As String, tableName As String, returnFieldName As String, Optional filter As String = Nothing) As Object Implements IBaseDao.GetFieldOnMaxField
            Dim sql As String
            If filter Is Nothing Or filter = "" Then
                sql = " SELECT Top 1 " & returnFieldName & " from " & tableName & " order by " & searchFieldName & " Desc"
            Else
                sql = " SELECT Top 1 " & returnFieldName & " from " & tableName & " where " & filter & " order by " & searchFieldName & " Desc"
            End If
            Return _db.Scalar(sql)
        End Function

        Public Function GetRecordCount(tableName As String, Optional filter As String = Nothing) As Integer _
            Implements IBaseDao.GetRecordCount
            Dim sql As String = "Select Count(*) FROM [" & tableName & "] " + IIf(filter Is Nothing, "", " where " & filter)
            Return _db.Scalar(sql)
        End Function

        Public Function GetRecordDateTimeStamp(idNo As Int32, tableName As String, dateTimeStampField As String) _
            As Object _
            Implements IBaseDao.GetRecordDateTimeStamp
            Dim sql As String =
                    " Select top 1 " & dateTimeStampField & " FROM [" & tableName & "] " &
                    " Where IdNo = @IdNo "
            Dim params() As Object = {"@IdNo", idNo}
            Dim retValue As Object
            retValue = _db.Scalar(sql, params)
            Return retValue
            'Return System.Text.Encoding.ASCII.GetString(retValue)
        End Function

        Public Function GetRecordField(tableName As String, returnFieldName As String) As Object Implements IBaseDao.GetRecordField
            Dim sql As String = " Select Top 1 " & returnFieldName & " FROM [" & tableName & "] "
            Dim retVal = _db.Scalar(sql)
            Return retVal
        End Function

        Public Function GetRecordFieldWith2Key(searchValue1 As String, searchValue2 As String, tableName As String,
                                               searchFieldName1 As String, searchFieldName2 As String,
                                               returnFieldName As String) As String _
            Implements IBaseDao.GetRecordFieldWith2Key
            Dim sql As String =
                    " Select Top 1 " & returnFieldName & " FROM [" & tableName & "] " &
                    " Where " & searchFieldName1 & " = @SearchValue1 and " & searchFieldName2 & " = @SearchValue2 "
            Dim params() As Object = {"@SearchValue1", searchValue1, "@SearchValue2", searchValue2}
            Dim retVal = _db.Scalar(sql, params)
            If retVal Is Nothing Or IsDBNull(retVal) Then
                Return Nothing
            End If
            Return retVal.ToString()
        End Function

        Public Function GetRecordFieldWithKey(searchValue As String, tableName As String, searchFieldName As String,
                                              returnFieldName As String) As String _
            Implements IBaseDao.GetRecordFieldWithKey
            Dim sql As String =
                    " Select Top 1 " & returnFieldName & " FROM [" & tableName & "] " &
                    " Where " & searchFieldName & " = @SearchValue "
            Dim params() As Object = {"@SearchValue", searchValue}
            Dim retVal = _db.Scalar(sql, params)
            If retVal Is Nothing Or IsDBNull(retVal) Then
                Return Nothing
            End If
            Return retVal.ToString()
        End Function

        'Public  Function GetFirstDependentRecord(ByVal SearchValue As String, ByVal TableName As String, ByVal SearchFieldName As String, ByVal ReturnFieldName As String) As Integer
        '    Dim sql As String =
        '        " Select Top 1 " & ReturnFieldName & " FROM [" & TableName & "] " &
        '        " Where " & SearchFieldName & " = '" & SearchValue & "'"
        '    Return Db.Scalar(sql)
        'End Function
        Public Function GetRecordFieldWithKeyG(Of T)(searchValue As String, tableName As String, searchFieldName As String,
                                              returnFieldName As String) As T _
            Implements IBaseDao.GetRecordFieldWithKeyG
            Dim sql As String =
                    " Select Top 1 " & returnFieldName & " FROM [" & tableName & "] " &
                    " Where " & searchFieldName & " = @SearchValue "
            Dim params() As Object = {"@SearchValue", searchValue}
            Dim retVal = _db.Scalar(sql, params)
            If retVal Is Nothing Or IsDBNull(retVal) Then
                Return Nothing
            End If
            Return retVal
        End Function

        Public Function GetRecordPosition(tableName As String, idNo As Int32) As Integer _
            Implements IBaseDao.GetRecordPosition
            Dim sql As String =
                    " Select Count(*) FROM [" & tableName & "] " &
                    " Where IdNo < " & idNo
            Return _db.Scalar(sql)
        End Function

        Public Function GetRecordPositionByName(tableName As String, sortField As String, nameValue As String) _
            As Integer _
            Implements IBaseDao.GetRecordPositionByName
            Dim sql As String =
                    " Select Count(*) FROM [" & tableName & "] " &
                    " Where " & sortField & "< '" & nameValue & "'"
            Return _db.Scalar(sql)
        End Function

        Public Function GetRecords(tableName As String, sortKey As String, fieldNames As String(), Optional filterKey As String = Nothing) As Object Implements IBaseDao.GetRecords
            Dim fields = String.Join(",", fieldNames)
            Dim sql As String
            If filterKey Is Nothing Or filterKey = "" Then
                If sortKey Is Nothing Or sortKey = "" Then
                    sql = " SELECT " & fields & " from [" & tableName & "]"
                Else
                    sql = " SELECT " & fields & " from [" & tableName & "] order by " & sortKey
                End If
            Else
                If sortKey Is Nothing Or sortKey = "" Then
                    sql = " SELECT " & fields & " from [" & tableName & "] where " & filterKey
                Else
                    sql = " SELECT " & fields & " from [" & tableName & "] where " & filterKey & " order by " & sortKey

                End If
            End If
            Return _db.SqlRead(sql)
        End Function

        'Public Function GetRecordsByField(tableName As String, sortKey As String, fieldNames As String(), Optional filter As String = Nothing) As Object Implements IBaseDao.GetRecordsByField
        '    Dim fields = String.Join(",", fieldNames)
        '    Dim filterKey As String = ""
        '    If Strings.Right(fields, 1) = "," Then
        '        fields = Strings.Left(fields, Len(fields) - 1)
        '    End If
        '    Dim sql As String
        '    If filter Is Nothing Then
        '        filterKey = ""
        '    Else
        '        filterKey = " where " & filter
        '    End If
        '    If sortKey Is Nothing Or sortKey = "" Then
        '        sql = " SELECT " & fields & " from [" & tableName & "]" & filterKey
        '    Else
        '        sql = " SELECT " & fields & " from [" & tableName & "] " & filterKey & " order by " & sortKey
        '    End If
        '    Return _db.SqlRead(sql)
        'End Function

        Public Function FieldExistsInTable(tableName As String, fieldName As String) As Boolean Implements IBaseDao.FieldExistInTable
            Dim retValue As Boolean
            retValue = _db.FieldExistInTable(tableName, fieldName)
            Return retValue
        End Function

        'Public Function GetFields(tableName As String, sortKey As String, ByVal ParamArray fieldNames() As String) Implements IBaseDao.GetFields
        '    Dim fields = String.Join(",", fieldNames)
        '    If Strings.Right(fields, 1) = "," Then
        '        fields = Strings.Left(fields, Len(fields) - 1)
        '    End If
        '    Dim sql = " SELECT " & fields & " from [" & tableName & "] order by " & sortKey
        '    Return _db.SqlRead(sql)
        'End Function

        'Public Function GetFieldsFiltered(tableName As String, sortKey As String, filter As String, ByVal ParamArray fieldNames() As String) Implements IBaseDao.GetFieldsFiltered
        '    Dim fields = String.Join(",", fieldNames)
        '    If Strings.Right(fields, 1) = "," Then
        '        fields = Strings.Left(fields, Len(fields) - 1)
        '    End If
        '    Dim sql = " SELECT " & fields & " from [" & tableName & "] order by " & sortKey & " where " & filter
        '    Return _db.SqlRead(sql)
        'End Function

        Public Function GetSortedRecordPosition(idNo As Int32, tableName As String, sortOrder As String, Optional filter As String = Nothing) As Integer Implements IBaseDao.GetSortedRecordPosition
            Dim filterKey As String
            If filter Is Nothing Then
                filterKey = ""
            Else
                filterKey = filter & " and "
            End If
            Dim sql As String = " Select count(*) From [" & tableName &
                    "] where " & filterKey & " " & sortOrder & " <= (Select " & sortOrder &
                    " from [" & tableName & "] where " & filterKey & " IdNo = " & idNo & ") "
            Return _db.Scalar(sql)
        End Function

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

        Public Function GetFieldValue(Of TType)(returnFieldName As String, tableName As String, condition As String) _
            As TType _
            Implements IBaseDao.GetFieldValue
            Dim sql As String =
                    " Select " & returnFieldName & " FROM [" & tableName & "] " &
                    " Where " & condition
            Dim x = _db.Scalar(sql)
            If IsDBNull(x) Or x Is Nothing Then
                Return Nothing
            End If
            Return Convert.ChangeType(x, GetType(TType))
        End Function

        '            ' Attempt to roll back the transaction.
        '            Try
        '                transaction.Rollback()
        Public Function GetUserSecurity(securityObjectIdNo As Int32, securityGroupIdNo As Int16) As ArrayList _
            Implements IBaseDao.GetUserSecurity
            Dim params() As Object =
                    {"@SecurityObjectIdNo", securityObjectIdNo, "@SecurityGroupIdNo", securityGroupIdNo}
            Dim sql =
                    " SELECT top 1 Visible, Editable FROM GroupAccess where SecurityObjectIdNo = @SecurityObjectIdNo and SecurityGroupIdNo = @SecurityGroupIdNo"
            Return _db.SqlRead(sql, params)
        End Function

        '        Catch ex As Exception
        '            Console.WriteLine("Commit Exception Type: {0}", ex.GetType())
        '            Console.WriteLine("  Message: {0}", ex.Message)
        Public Function GetUserSecurityForKey(securityObjectName As String, securityGroupIdNo As Int16) As ArrayList Implements IBaseDao.GetUserSecurityForKey
            Dim params() As Object =
                    {"@SecurityObjectName", securityObjectName, "@SecurityGroupIdNo", securityGroupIdNo}
            Dim sql = "SELECT top 1 Visible, Editable FROM GroupAccess " &
                      "Left Join SecurityObject " &
                      "on GroupAccess.SecurityObjectIdNo = SecurityObject.IdNo " &
                      "where SecurityObject.SecurityObjectName = @securityObjectName and GroupAccess.SecurityGroupIdNo = @SecurityGroupIdNo"
            Return _db.SqlRead(sql, params)
        End Function

        Public Function AddSecurityObject(securityObject As SecurityObject) As Integer Implements IBaseDao.AddSecurityObject
            Dim sql = "Insert into SecurityObject (securityObjectName,systemViewIdNo,parentIdNo) VALUES (@SecurityObjectName,@SystemViewIdNo,@ParentIdNo)"
            Return _db.Insert(sql, TakeSecurityObject(securityObject))
        End Function

        Public Function InitializeSecurityObject() As Integer Implements IBaseDao.InitializeSecurityObject
            Dim sql1 = "INSERT [SecurityObject] ([IdNo], [SecurityObjectCode], [SecurityObjectName], [SecurityObjectNameAra], [ParentIdNo], [SystemViewIdNo], [ManuallyAdded], [Notes]) VALUES "
            Dim commandArray = {{"SET IDENTITY_INSERT [SecurityObject] ON"},
                                {sql1 & "(1, N'1', N'_SuperAdministrator', NULL, NULL, NULL, 0, NULL)"},
                                {sql1 & "(2, N'2', N'_Administrator', NULL, NULL, NULL, 0, NULL)"},
                                {sql1 & "(3, N'3', N'_Manager', NULL, NULL, NULL, 0, NULL)"},
                                {sql1 & "(4, N'4', N'_Supervisor', NULL, NULL, NULL, 0, NULL)"},
                                {sql1 & "(5, N'5', N'_PowerUser', NULL, NULL, NULL, 0, NULL)"},
                                {sql1 & "(6, N'6', N'_User', NULL, NULL, NULL, 0, NULL)"},
                                {sql1 & "(7, N'7', N'_Guest', NULL, NULL, NULL, 0, NULL)"},
                                {"SET IDENTITY_INSERT [SecurityObject] OFF "}}
            Return _db.ExecuteCommands("SecurityObjectCreate", commandArray)
        End Function

        Public Function HasRecordChanged(idNo As Int32, tableName As String, timeStampValue As Byte,
                                                 Optional ByVal timeStampedField As String = "DateTimeStamp") As Boolean _
                    Implements IBaseDao.HasRecordChanged
            Dim sql As String = " Select count(*) FROM [" & tableName & "] " &
                                " Where IdNo = @IdNo and timeStampedField = @timeStampValue "
            Dim params() As Object = {"@IdNo", idNo, "@timeStampValue", timeStampValue}
            Dim nCount = _db.Scalar(sql, params)
            Return Not nCount > 0
        End Function

        'Public Function GetField(searchValue As String, tableName As String, searchFieldName As String, returnFieldName As String) Implements IBaseDao.GetRecordFieldWithKeyG
        '    Dim sql As String =
        '            " Select Top 1 " & returnFieldName & " FROM [" & tableName & "] " &
        '            " Where " & searchFieldName & " = @SearchValue "
        '    Dim params() As Object = {"@SearchValue", searchValue}
        '    Dim retVal = _db.Scalar(sql, params)
        '    If retVal Is Nothing Or IsDBNull(retVal) Then
        '        Return Nothing
        '    End If
        '    Return retVal
        'End Function
        Public Function IsFieldUnique(tableName As String, fieldName As String) As Boolean _
            Implements IBaseDao.IsFieldUnique
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
            nCount = _db.Scalar(sql, params)
            If nCount > 0 Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Function UpdateRecordWithIdNo(Of T)(idNo As Int32, tableName As String, fieldName As String,
                                                    value As T) As Integer _
            Implements IBaseDao.UpdateRecordWithIdNo
            Dim sql As String =
                    " Update [" & tableName & "] " &
                    " Set " & fieldName & " = @Value" &
                    " where IdNo = " & idNo
            Return _db.Update(sql, {"@Value", value})
        End Function

        Public Function GenericUpdateRecordWithIdNo(Of T)(idNo As Int32, tableName As String, fieldName As String, value As T) As Integer _
            Implements IBaseDao.GenericUpdateRecordWithIdNo
            Dim sql As String =
                    " Update [" & tableName & "] " &
                    " Set " & fieldName & " = @Value" &
                    " where IdNo = " & idNo
            Return _db.Update(sql, {"@Value", value})
        End Function

        Public Function GetFieldType(tableName As String, fieldName As String) As Object Implements IBaseDao.GetFieldType
            Dim value As Object
            Dim sql As String = "Select DATA_TYPE From INFORMATION_SCHEMA.COLUMNS Where TABLE_NAME = @tableName AND COLUMN_NAME = @fieldName"
            Dim params() As Object = {"@TableName", tableName, "@FieldName", fieldName}
            value = _db.Scalar(sql, params)
            Return value
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

        Private Function TakeSecurityObject(securityObject As SecurityObject) As Object()
            Return New Object() {"@SecurityObjectName", securityObject.SecurityObjectName,
                                 "@SystemViewIdNo", securityObject.SystemViewIdNo,
                                 "@ParentIdNo", securityObject.ParentIdNo}
        End Function

    End Class

End Namespace