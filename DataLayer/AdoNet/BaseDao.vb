Imports System.Data.SqlClient
Imports System.Dynamic
Imports System.Globalization
Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.Libraries.AatmInterfaces
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace AdoNet

    Public Class BaseDao
        Implements IBaseDao

        Private Const ConnectionNameConstant As String = "ISPDATA"
        Private ReadOnly _db As New Db()

        Private _lastFindParms As Object
        Private _lastFindQuery As String
        Private _withParams As Boolean

        Public Sub New()
        End Sub

        Public ReadOnly Property BaseDb As Db
            Get
                Return _db
            End Get
        End Property

        Public Overridable Function GetDb()
            Return _db
        End Function

        Public Overridable Function GetDb(connectionString As String)
            SetConnectionString(connectionString)
            Return _db
        End Function

        Public Overridable Function GetPrimaryFieldName()
            Return "IdNo"
        End Function

        Public Function CheckIfUnique(searchValue As String, tableName As String, searchFieldName As String,
                                      currentIdNo As Int64) As String _
            Implements IBaseDao.CheckIfUnique
            Dim sql As String =
                    " Select count(*) FROM [" & tableName & "] " &
                    " Where " & searchFieldName & " = @SearchValue " &
                    " and " & GetPrimaryFieldName() & " <> @currentIdNo "
            Dim params() As Object = {"@SearchValue", searchValue, "@currentIdNo", currentIdNo}
            Dim nCount = GetDb().Scalar(sql, params)
            Return Not nCount > 0
        End Function

        Public Function CountRecordWith3Key(Of TS1, TS2, TS3)(tableName As String, searchFieldName1 As String, searchFieldName2 As String, searchFieldName3 As String, searchValue1 As TS1, searchValue2 As TS2, searchValue3 As TS3) As Integer Implements IBaseDao.CountRecordWith3Key
            Dim searchVal1 As String = ConvertToString(Of TS1)(searchValue1)
            Dim searchVal2 As String = ConvertToString(Of TS2)(searchValue2)
            Dim searchVal3 As String = ConvertToString(Of TS3)(searchValue3)
            Dim sql As String = " Select COUNT(*) FROM [" & tableName & "] " &
                    " Where " & searchFieldName1 & " = @SearchVal1 and " & searchFieldName2 & " = @SearchVal2 and " & searchFieldName3 & " = @SearchVal3 "
            Dim params() As Object = {"@SearchVal1", searchVal1, "@SearchVal2", searchVal2, "@SearchVal3", searchVal3}
            Return GetDb().Scalar(sql, params)
        End Function

        Public Function CountRecordWith2Key(Of TS1, TS2)(tableName As String, searchFieldName1 As String, searchFieldName2 As String, searchValue1 As TS1, searchValue2 As TS2) As Integer Implements IBaseDao.CountRecordWith2Key
            Dim searchVal1 As String = ConvertToString(Of TS1)(searchValue1)
            Dim searchVal2 As String = ConvertToString(Of TS2)(searchValue2)

            Dim sql As String = " Select COUNT(*) FROM [" & tableName & "] " &
                                " Where " & searchFieldName1 & " = @SearchVal1 and " & searchFieldName2 & " = @SearchVal2 "
            Dim params() As Object = {"@SearchVal1", searchVal1, "@SearchVal2", searchVal2}
            Return GetDb().Scalar(sql, params)
        End Function

        Public Function CountRecordWithKey(Of TS1)(tableName As String, searchFieldName As String, searchValue As TS1) As Integer Implements IBaseDao.CountRecordWithKey
            Dim searchVal As String = ConvertToString(Of TS1)(searchValue)
            Dim sql As String =
                    " Select Count(*) FROM [" & tableName & "] " &
                    " Where " & searchFieldName & " = @searchVal "
            Dim params() As Object = {"@searchVal", searchVal}
            Return GetDb().Scalar(sql, params)
        End Function

        Public Function DeleteRecord(Of T)(keyFieldValue As T, tableName As String, keyFieldName As String) As Integer Implements IBaseDao.DeleteRecord
            Dim params() As Object = {"keyFieldValue", keyFieldValue, "keyFieldName", keyFieldName}
            'Dim cTableName = GetPhysicalTableName(tableName)
            If tableName.Right(5) = "_View" Then
                Dim l As Int16 = Len(tableName)
                Dim sql As String = "Delete FROM [" & Left(tableName, Len(tableName) - 5) & "] " & " Where @keyFieldName = @keyFieldName"
                Return GetDb().scalar(sql, params)
            Else
                Dim sql As String = "Delete FROM [" & tableName & "] " & " Where @keyFieldName = @keyFieldName"
                Return GetDb().Scalar(sql, params)
            End If
        End Function

        Public Function DeleteRecords(Of T)(keyFieldValue As T, tableName As String, keyFieldName As String) As Int32 _
            Implements IBaseDao.DeleteRecords
            Dim sql As String = " Delete FROM [" & tableName & "] " &
                " Where " & keyFieldName & " = @keyFieldValue"
            Dim db = GetDb()
            Dim params() As Object = {"@keyFieldValue", keyFieldValue}
            Return GetDb().Scalar(sql, params)
        End Function

        'Private Shared Function GetPhysicalTableName(pTableName As String) As String
        '    Dim physicalTableName As String = pTableName
        '    If Strings.Right(pTableName, 5).ToLower() = "_view" Then
        '        physicalTableName = Strings.Left(pTableName, Strings.Len(pTableName) - 5)
        '    End If
        '    Return physicalTableName
        'End Function

        'Public Function FindField(tableName As String, fieldName As String, searchString As String, Optional searchPlace As Char = "A", Optional filter As String = Nothing) As Integer Implements IBaseDao.FindField
        '    Dim retVal As Integer
        '    Dim sql As String =
        '                " SELECT IdNo FROM [" & tableName & "] " &
        '                " Where "
        '    If Not (filter Is Nothing OrElse filter = "") Then
        '        sql = sql & filter.Trim() & " and "
        '    End If
        '    If searchString Is Nothing OrElse searchString = "" Then
        '        sql = sql & " (" & fieldName & " Is Null or " & fieldName & " = '') "
        '    Else
        '        If searchPlace = "A" Then
        '            searchString = "%" & searchString.Trim() & "%"
        '            sql = sql & fieldName & " Like @SearchString "
        '        ElseIf searchPlace = "S" Then
        '            searchString = searchString.Trim() & "%"
        '            sql = sql & fieldName & " Like @SearchString "
        '        ElseIf searchPlace = "E" Then
        '            searchString = searchString.Trim()
        '            sql = sql & fieldName & " = @SearchString "
        '        End If
        '    End If
        '    Dim params() As Object = {"@SearchString", searchString}
        '    _lastFindQuery = sql
        '    _lastFindParms = params
        '    retVal = GetDb().Scalar(sql & " order by IdNo ", params)
        '    Return retVal
        'End Function

        Public Function FindFieldNew(tableName As String, findableControl As IFindableControl, sortOrderKey As String, Optional filter As String = Nothing) As Integer Implements IBaseDao.FindFieldNew
            Dim retVal As Integer
            Dim sql As String = " SELECT " & GetPrimaryFieldName() & " FROM [" & tableName & "] " & " Where "
            Dim params As String() = Nothing
            Dim searchString As String
            If findableControl.SearchMode = IFindableControl.SearchModeEnum.ComboBox Then
                sql &= GetActualFieldName(findableControl.FieldName).Trim() & " = @SearchString"
                searchString = findableControl.BegFindValue
                params = {"@SearchString", searchString}
            ElseIf findableControl.FindDataType = IFindableControl.DataTypeEnum.String Then
                If findableControl.BegFindValue Is Nothing OrElse findableControl.BegFindValue = "" Then
                    sql &= " (" & GetActualFieldName(findableControl.FieldName) & " Is Null or " & GetActualFieldName(findableControl.FieldName) & " = '') "
                Else
                    If Not (filter Is Nothing OrElse filter = "") Then
                        sql &= "(" & filter.Trim() & ")" & " and " & GetActualFieldName(findableControl.FieldName).Trim() & " "
                    Else
                        Dim fName As String = findableControl.FieldName
                        If fName = "Name" Or fName = "Code" Then
                            fName = Trim(tableName) + fName
                            sql &= fName
                        Else
                            sql &= GetActualFieldName(findableControl.FieldName).Trim()
                        End If
                        'sql &= GetActualFieldName(findableControl.FieldName).Trim()
                    End If
                    If findableControl.SearchPlace = IFindableControl.SearchPlaceEnum.AnywhereOnField Then
                        searchString = "%" & RTrim(findableControl.BegFindValue) + "%"
                        sql &= " Like @searchString "
                    ElseIf findableControl.SearchPlace = IFindableControl.SearchPlaceEnum.StartOfField Then
                        searchString = RTrim(findableControl.BegFindValue) + "%"
                        sql &= " Like @searchString "
                    Else  ' findableControl.searchPlace = IFindableControl.SearchPlaceEnum.ExactValue
                        searchString = RTrim(findableControl.BegFindValue)
                        sql &= " = @searchString"
                    End If
                    params = {"@searchString", searchString}
                End If
            ElseIf findableControl.FindDataType = IFindableControl.DataTypeEnum.Date Then
                If Not (filter Is Nothing OrElse filter = "") Then
                    sql &= "(" & filter.Trim() & ") and " & GetActualFieldName(findableControl.FieldName).Trim() & " "
                End If
                sql &= GetActualFieldName(findableControl.FieldName).Trim()
                retVal = FindDateField(tableName, findableControl, GetActualFieldName(sortOrderKey), filter)
                Return retVal
            ElseIf findableControl.FindDataType = IFindableControl.DataTypeEnum.Integer Or
                   findableControl.FindDataType = IFindableControl.DataTypeEnum.Decimal Then
                If Not (filter Is Nothing OrElse filter = "") Then
                    sql &= "(" & filter.Trim() & ") and " '& GetActualFieldName(findableControl.FieldName).Trim() & " "
                End If
                If findableControl.BegFindValue Is Nothing Then ' Or findableControl.BegFindValue = "" Then
                    sql &= " " & GetActualFieldName(findableControl.FieldName) & " Is Null or "
                    searchString = findableControl.EndFindValue
                    sql &= GetActualFieldName(findableControl.FieldName).Trim() & " <= @searchString"
                    params = {"@SearchString", searchString, "@sortOrderKey", GetActualFieldName(sortOrderKey)}
                ElseIf findableControl.EndFindValue Is Nothing Or findableControl.EndFindValue = "" Then
                    sql &= GetActualFieldName(findableControl.FieldName).Trim()
                    searchString = findableControl.BegFindValue
                    sql &= " >= @searchString "
                    params = {"@SearchString", searchString}
                Else
                    searchString = findableControl.BegFindValue
                    Dim searchString2 = findableControl.EndFindValue
                    sql &= GetActualFieldName(findableControl.FieldName).Trim() & ">= @searchString and " & GetActualFieldName(findableControl.FieldName).Trim() & " <= @searchString2"
                    params = {"@SearchString", searchString, "@searchString2", searchString2, "@sortOrderKey", GetActualFieldName(sortOrderKey)}
                End If
            ElseIf findableControl.SearchMode = IFindableControl.SearchModeEnum.CheckBox Then
                sql &= GetActualFieldName(findableControl.FieldName).Trim() & " = @SearchString"
                searchString = IIf(findableControl.BegFindValue, "1", "0")
                params = {"@SearchString", searchString}
            End If
            retVal = GetDb().Scalar(sql & " order by " & GetActualFieldName(sortOrderKey), params)
            _lastFindQuery = sql
            _lastFindParms = params
            Return retVal
        End Function

        Public Function FindDateField(tableName As String, findableControl As IFindableControl, sortOrderKey As String, Optional filter As String = Nothing) As Integer Implements IBaseDao.FindDateField
            Dim retVal As Integer
            Dim searchString As String
            Dim sql As String = " SELECT " & GetPrimaryFieldName() & " FROM [" & tableName & "] Where "
            If Not (filter Is Nothing OrElse filter = "") Then
                sql = sql & "(" & filter.Trim() & ") and "
            End If
            Dim dBegDate As Date? = findableControl.BegFindValue
            Dim dEndDate As Date? = findableControl.EndFindValue
            If dBegDate Is Nothing Then
                If dEndDate IsNot Nothing Then
                    Dim dEDate As Date = Convert.ToDateTime(dEndDate)
                    dEDate = DateAndTime.DateAdd(DateInterval.Day, 1, dEDate)
                    searchString = GetActualFieldName(findableControl.FieldName) & " < '" & dEDate.ToString("yyyyMMdd", CultureInfo.InvariantCulture) & "'"
                Else
                    searchString = GetActualFieldName(findableControl.FieldName) & " Is Null"
                End If
            Else
                Dim dBDate As Date = Convert.ToDateTime(dBegDate)
                Dim dEDate As Date
                If dEndDate Is Nothing Then
                    'dEDate = DateAndTime.DateAdd(DateInterval.Day, 1, dBDate)
                    searchString = GetActualFieldName(findableControl.FieldName) & " >= '" & dBDate.ToString("yyyyMMdd", CultureInfo.InvariantCulture) & "'"
                Else
                    dEDate = DateAndTime.DateAdd(DateInterval.Day, 1, Convert.ToDateTime(dEndDate))
                    searchString = GetActualFieldName(findableControl.FieldName) & " >= '" & dBDate.ToString("yyyyMMdd", CultureInfo.InvariantCulture) & "' and " & findableControl.FieldName & " < '" & dEDate.ToString("yyyMMdd", CultureInfo.InvariantCulture) & "'"
                End If
            End If
            sql = sql & searchString
            _lastFindQuery = sql
            retVal = GetDb().Scalar(sql & " order by " & sortOrderKey)
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
        '        retVal = GetDb().Scalar(sql & " order by IdNo ", params)
        '    End If
        '    Return retVal
        'End Function

        Public Function FindFieldContinue(tableName As String, lastIdNo As Int32, sortOrderKey As String) _
            Implements IBaseDao.FindFieldContinue
            Dim retVal As Integer
            If _lastFindQuery Is Nothing Then
                Messaging.Show(True, "MsgNoPrevSearchFindInvalid")
                retVal = lastIdNo
            Else
                Dim sql As String
                Dim sortValue As Object
                sql = "Select " & sortOrderKey & " from " & tableName & " where  " & GetPrimaryFieldName() & " = " & lastIdNo.ToString()
                sortValue = GetDb().Scalar(sql)
                sql = _lastFindQuery
                Dim params As String()
                If _lastFindParms Is Nothing Then
                    params = {"@sortValue", sortValue}
                Else
                    params = _lastFindParms
                    Array.Resize(params, params.Length + 1)
                    params(params.Length - 1) = "@sortValue"
                    Array.Resize(params, params.Length + 1)
                    params(params.Length - 1) = sortValue
                End If
                If lastIdNo > 0 Then
                    retVal = GetDb().Scalar(sql & " and " & sortOrderKey & "> @sortValue order by " & sortOrderKey, params)
                Else
                    retVal = GetDb().Scalar(sql & " order by " & sortOrderKey, params)
                End If
            End If
            Return retVal
        End Function

        Public Function GetControlSecurityIdNo(searchValue As String, Optional menu As Boolean = False) As String Implements IBaseDao.GetControlSecurityIdNo
            Dim sql As String
            If menu Then
                sql = "Select Top 1 IdNo FROM SecurityObject_View1 Where FullPathName = @SearchValue"
            Else
                sql = "Select Top 1 IdNo FROM SecurityObject_View1 Where SecurityObjectName = @SearchValue"
            End If
            Dim params() As Object = {"@SearchValue", searchValue}
            Dim retVal = _db.SecurityScalar(sql, params)
            If retVal Is Nothing Then
                Return Nothing
            End If
            Return retVal.ToString()
        End Function

        Public Function GetField(searchValue As String, tableName As String, searchFieldName As String, returnFieldName As String) As Object Implements IBaseDao.GetField
            Dim sql As String =
                    " Select " & returnFieldName & " FROM [" & tableName & "] " &
                    " Where " & searchFieldName & " = @SearchValue "
            Dim params() As Object = {"@SearchValue", searchValue}
            Dim retVal = GetDb().Scalar(sql, params)
            If retVal Is Nothing Or IsDBNull(retVal) Then
                Return Nothing
            End If
            Return retVal
        End Function

        'Public Function GetField(Of TR, TS)(searchValue As TS, tableName As String, searchFieldName As String, returnFieldName As String, Optional filter As String = Nothing) As TR Implements IBaseDao.GetField
        '    Dim sql As String
        '    Dim params() As Object
        '    Dim tType As Type = searchValue.GetType
        '    If tType = GetType(String) OrElse tType = GetType(Decimal) OrElse tType = GetType(Int32) OrElse tType = GetType(Int16) OrElse tType = GetType(Int64) OrElse
        '                                      tType = GetType(UInt16) OrElse tType = GetType(UInt32) OrElse tType = GetType(UInt64) Then
        '        params = {"@SearchValue", searchValue}
        '        sql = " Select " & returnFieldName & " FROM [" & tableName & "] Where " & searchFieldName & " = @SearchValue "
        '    ElseIf tType = GetType(Boolean) Then
        '        Dim boolSearch As Boolean = Convert.ToBoolean(searchValue)
        '        If boolSearch Then
        '            boolSearch = 1
        '        Else
        '            boolSearch = 0
        '        End If
        '        params = {"@SearchValue", boolSearch}
        '        sql = " Select " & returnFieldName & " FROM [" & tableName & "] Where " & searchFieldName & " = @SearchValue "
        '    ElseIf tType = GetType(Date) Then
        '        Dim dDate = Convert.ToDateTime(searchValue)
        '        Dim dateSearch1 As String = dDate.ToString("yyyyMMdd", CultureInfo.InvariantCulture)
        '        dDate = DateAndTime.DateAdd(DateInterval.Day, 1, dDate)
        '        Dim dateSearch2 As String = dDate.ToString("yyyyMMdd", CultureInfo.InvariantCulture)
        '        params = {"@dateSearch1", dateSearch1, "@dateSearch2", dateSearch1}
        '        sql = " Select " & returnFieldName & " FROM [" & tableName & "] Where " & searchFieldName & " >= @dateSearch1 and " & searchFieldName & "< @dateSearch2"
        '    Else
        '        params = {"@SearchValue", searchValue}
        '        sql = " Select " & returnFieldName & " FROM [" & tableName & "] Where " & searchFieldName & " = @SearchValue "
        '    End If
        '    If filter IsNot Nothing Then
        '        sql = sql & " and (" & filter & ")"
        '    End If
        '    Dim retVal = GetDb().Scalar(sql, params)
        '    If retVal Is Nothing Or IsDBNull(retVal) Then
        '        Return Nothing
        '    End If
        '    Return retVal
        'End Function

        Public Function GetField(Of TR, TS)(searchValue As TS, tableName As String, searchFieldName As String, returnFieldName As String, Optional filter As String = Nothing) As TR Implements IBaseDao.GetField
            Dim sql As String = "Select " & returnFieldName & " FROM [" & tableName & "] Where "
            Dim condition As String = ""
            Dim params() As Object = ComposeSqlCommand(Of TS)(searchValue, searchFieldName, condition)
            sql += condition
            If filter IsNot Nothing Then
                sql = sql & " and (" & filter & ")"
            End If
            Dim retVal = GetDb().Scalar(sql, params)
            If retVal Is Nothing Or IsDBNull(retVal) Then
                Return Nothing
            End If
            Return retVal
        End Function


        Public Function GetField(Of TR, TS1, TS2)(searchValue1 As TS1, searchValue2 As TS2, tableName As String, searchFieldName1 As String, searchFieldName2 As String, returnFieldName As String, Optional filter As String = Nothing) As TR Implements IBaseDao.GetField
            Dim sql As String = "Select " & returnFieldName & " FROM [" & tableName & "] Where "
            Dim condition1 As String = ""
            Dim condition2 As String = ""
            Dim obj1 As Object = ComposeSqlCommand(Of TS1)(searchValue1, searchFieldName1, condition1)
            Dim obj2 As Object = ComposeSqlCommand(Of TS2)(searchValue2, searchFieldName2, condition2)
            Dim params() As Object = {obj1(0), obj1(1), obj2(0), obj2(1)}
            sql += condition1 & " and " & condition2
            If filter IsNot Nothing Then
                sql = sql & " and (" & filter & ")"
            End If
            Dim retVal = GetDb().Scalar(sql, params)
            If retVal Is Nothing Or IsDBNull(retVal) Then
                Return Nothing
            End If
            Return retVal
        End Function

        Public Function GetField(Of TR, TS1, TS2, TS3)(searchValue1 As TS1, searchValue2 As TS2, searchValue3 As TS3,
                                                       tableName As String,
                                                       searchFieldName1 As String, searchFieldName2 As String, searchFieldName3 As String,
                                                       returnFieldName As String, Optional filter As String = Nothing) As TR Implements IBaseDao.GetField
            Dim sql As String = "Select " & returnFieldName & " FROM [" & tableName & "] Where "
            Dim condition1 As String = ""
            Dim condition2 As String = ""
            Dim condition3 As String = ""
            Dim obj1 As Object = ComposeSqlCommand(Of TS1)(searchValue1, searchFieldName1, condition1)
            Dim obj2 As Object = ComposeSqlCommand(Of TS2)(searchValue2, searchFieldName2, condition2)
            Dim obj3 As Object = ComposeSqlCommand(Of TS2)(searchValue2, searchFieldName2, condition2)
            Dim params() As Object = {obj1(0), obj1(1), obj2(0), obj2(1), obj3(0), obj3(1)}
            sql += condition1 & " and " & condition2
            If filter IsNot Nothing Then
                sql = sql & " and (" & filter & ")"
            End If
            Dim retVal = GetDb().Scalar(sql, params)
            If retVal Is Nothing Or IsDBNull(retVal) Then
                Return Nothing
            End If
            Return retVal
        End Function

        Private Shared Function ComposeSqlCommand(Of TS)(searchValue As TS, searchFieldName As String, ByRef sql As String) As Array
            Dim arrayParameter As Object
            Dim tType As Type = searchValue.GetType
            Dim searchParameterName As String = "@" + searchFieldName
            If tType = GetType(String) OrElse tType = GetType(Decimal) OrElse tType = GetType(Int32) OrElse tType = GetType(Int16) OrElse tType = GetType(Int64) OrElse
                                              tType = GetType(UInt16) OrElse tType = GetType(UInt32) OrElse tType = GetType(UInt64) Then
                arrayParameter = {searchParameterName, searchValue}
                sql += searchFieldName & " = " & searchParameterName
            ElseIf tType = GetType(Boolean) Then
                Dim boolSearch As Boolean = Convert.ToBoolean(searchValue)
                If boolSearch Then
                    boolSearch = 1
                Else
                    boolSearch = 0
                End If
                arrayParameter = {searchParameterName, boolSearch}
                sql += searchFieldName & " = " & searchParameterName
            ElseIf tType = GetType(Date) Then
                Dim dDate = Convert.ToDateTime(searchValue)
                Dim dateSearch1 As String = dDate.ToString("yyyyMMdd", CultureInfo.InvariantCulture)
                dDate = DateAndTime.DateAdd(DateInterval.Day, 1, dDate)
                Dim dateSearch2 As String = dDate.ToString("yyyyMMdd", CultureInfo.InvariantCulture)
                arrayParameter = {"@dateSearch1", dateSearch1, "@dateSearch2", dateSearch1}
                sql += searchFieldName & " >= @dateSearch1 and " & searchFieldName & "< @dateSearch2"
            Else
                arrayParameter = {searchParameterName, searchValue}
                sql += searchFieldName & " = " & searchParameterName
            End If
            Return arrayParameter
        End Function

        Public Function ConvertToString(Of T1)(value As T1) As String
            Dim tType As Type = value.GetType
            Dim result As String = ""
            If tType = GetType(String) Then
                result = value.ToString()
            ElseIf tType = GetType(Boolean) Then
                Dim boolSearch As Boolean = Convert.ToBoolean(value)
                If boolSearch Then
                    boolSearch = 1
                Else
                    boolSearch = 0
                End If
                result = boolSearch
            ElseIf tType = GetType(Date) Then
                Dim dDate As DateTime = Convert.ToDateTime(value)
                Dim dateSearch1 As String = dDate.ToString()
            Else 'OrElse tType = GetType(Decimal) OrElse tType = GetType(Int32) OrElse tType = GetType(Int16) OrElse tType = GetType(Int64) OrElse
                '   tType = GetType(UInt16) OrElse tType = GetType(UInt32) OrElse tType = GetType(UInt64) Then
                result = value.ToString()
            End If
            Return result
        End Function

        Public Function GetFieldWithIdNo(idNo As Object, tableName As String, returnFieldName As String) As Object Implements IBaseDao.GetFieldWithIdNo
            Dim sql As String =
                    " Select " & returnFieldName & " FROM [" & tableName & "] " &
                    " Where " & GetPrimaryFieldName() & " = @IdNo "
            Dim params() As Object = {"@IdNo", idNo}
            Return GetDb().Scalar(sql, params)
        End Function

        Public Function GetFieldsWithIdNo(idNo As Object, tableName As String, fieldsList As String, Optional primaryFieldName As String = Nothing) As ExpandoObject Implements IBaseDao.GetFieldsWithIdNo
            If primaryFieldName Is Nothing Then
                primaryFieldName = GetPrimaryFieldName()
            End If
            Dim sql As String = " Select top 1 " & fieldsList & " FROM [" & tableName & "] " & " Where " & primaryFieldName & " = @IdNo "
            Dim params() As Object = {"@IdNo", idNo}
            Dim values As Object
            values = GetDb().SqlRead(sql, params)
            If values.Count() > 0 Then
                Dim fields = fieldsList.Split(",")
                Dim obj As New ExpandoObject
                Dim i As Int16 = 0
                For Each item In fields
                    CreateDynamicObject(obj, item, values(i))
                    i = i + 1
                Next
                Return obj
            End If
            Return Nothing
        End Function

        Public Function GetRecordFieldsFiltered(tableName As String, fieldList As String, filter As String) As ExpandoObject Implements IBaseDao.GetRecordFieldsFiltered
            Dim sql As String =
                    " Select Top 1 " & fieldList & " FROM [" & tableName & "] " &
                    " Where " & filter
            Dim values As Object
            values = GetDb().SqlRead(sql)
            Return SqlReadToExpandoObject(values, fieldList)
        End Function

        Public Function GetRecordFieldsFiltered(tableName As String, fieldList As String, filter As String, parameter As Object) As ExpandoObject Implements IBaseDao.GetRecordFieldsFiltered
            Dim sql As String =
                    " Select Top 1 " & fieldList & " FROM [" & tableName & "] " &
                    " Where " & filter
            Dim values As Object = GetDb().SqlRead(sql, parameter)
            Return SqlReadToExpandoObject(values, fieldList)
        End Function


        Public Function GetRecordFieldsFiltered(tableName As String, fieldList As String, filter As String, parameter As Object, sortKey As String) As ExpandoObject Implements IBaseDao.GetRecordFieldsFiltered
            Dim sql As String =
                    " Select Top 1 " & fieldList & " FROM [" & tableName & "] " &
                    " Where " & filter & " order by " & sortKey
            Dim values As Object = GetDb().SqlRead(sql, parameter)
            Return SqlReadToExpandoObject(values, fieldList)
        End Function

        Private Function SqlReadToExpandoObject(values As Object, fieldList As String) As ExpandoObject
            If values.Count() > 0 Then
                Dim fields = fieldList.Split(",")
                Dim obj As Object
                obj = New ExpandoObject
                Dim i As Int16 = 0
                For Each item In fields
                    CreateDynamicObject(obj, item, values(i))
                    i = i + 1
                Next
                Return obj
            Else
                Return Nothing
            End If
        End Function


        Public Function GetTopOneFields(tableName As String, fieldList As String, filter As String, order As String, orderAscending As Boolean) As ExpandoObject Implements IBaseDao.GetTopOneFields
            Dim sql As String =
                    " Select Top 1 " & fieldList & " FROM [" & tableName & "] " + IIf(filter Is Nothing, "", " Where " & filter) +
                    IIf(order Is Nothing, "", " order by " & order) + IIf(orderAscending, "", " DESC")
            Dim values As Object
            values = GetDb().SqlRead(sql)
            Dim obj As Object = New ExpandoObject
            If values.Count() <> 0 Then
                Dim fields = fieldList.Split(",")
                Dim i As Int16 = 0
                For Each item In fields
                    CreateDynamicObject(obj, item, values(i))
                    i = i + 1
                Next
            Else
                obj = Nothing
            End If
            Return obj
        End Function

        Public Function GetIdNoWithKey(Of T)(tableName As String, KeyValue As String, Optional keyFieldName As String = Nothing, Optional idFieldName As String = Nothing) As T Implements IBaseDao.GetIdNoWithKey
            If idFieldName Is Nothing Then
                idFieldName = "IdNo"
            End If
            If keyFieldName Is Nothing Then
                keyFieldName = tableName + "Name"
            End If
            Dim sql As String = "Select Top 1 " & idFieldName & " FROM " & tableName & " where " & keyFieldName & " =  @FieldValue"
            Dim params() As Object = {"@FieldValue", KeyValue}
            Return GetDb().Scalar(sql, params)
        End Function

        Public Function GetIcIdNoWithName(codeGroupSelection As CodeGroupSelection, fieldValue As String, Optional fieldName As String = Nothing, Optional idFieldName As String = Nothing) As Int32 Implements IBaseDao.GetIcIdNoWithName
            Dim codeGroupIdNo = Convert.ToInt32(codeGroupSelection)
            Dim sql As String = "Select Top 1 IdNo from ItemCode where IdNo = @FieldValue and CodeGroupIdNo = @CodeGroupIdNo"
            Dim params() As Object = {"@FieldValue", fieldValue, "@CodeGroupIdNo", codeGroupIdNo}
            Return GetDb().Scalar(sql, params)
        End Function

        Public Function GetIcNameWithIdNo(codeGroupSelection As CodeGroupSelection, fieldValue As Int32, Optional fieldName As String = Nothing, Optional idFieldName As String = Nothing) As String Implements IBaseDao.GetIcNameWithIdNo
            Dim codeGroupIdNo = Convert.ToInt32(codeGroupSelection)
            Dim sql As String = "Select Top 1 ItemCodeName from ItemCode where IdNo = @FieldValue and CodeGroupIdNo = @CodeGroupIdNo"
            Dim params() As Object = {"@FieldValue", fieldValue, "@CodeGroupIdNo", codeGroupIdNo}
            Return GetDb().Scalar(sql, params)
        End Function

        Public Function GetPrintJobIdNo(reportFileName As String) As Int32 Implements IBaseDao.GetPrintJobIdNo
            Dim sql As String = "Select Top 1 PrintJobIdNo from Report where ReportFileName = @reportFileName"
            Dim params() As Object = {"@ReportFileName", reportFileName}
            Return GetDb().Scalar(sql, params)
        End Function

        'Public Function GetRecords(tableName As String, fieldList As String, filter As String) As ExpandoObject Implements IBaseDao.GetRecords
        '    Dim sql As String =
        '            " Select " & fieldList & " FROM [" & tableName & "] " &
        '            " Where " & filter
        '    Dim values As Object
        '    values = GetDb().SqlRead(sql)
        '    Dim fields2 = fieldList.Split(",")
        '    Dim dataCount = Values.Count()
        '    Dim fieldCount = fields2.Count()
        '    Dim data = New ExpandoObject
        '    For number As Integer = 1 To dataCount Step fieldCount

        '    Next

        '    'Dim fields = New List(Of Field)() From {
        '    '        New Field("EmployeeID", GetType(Integer)),
        '    '        New Field("EmployeeName", GetType(String)),
        '    '        New Field("Designation", GetType(String))
        '    '        }
        '    'Dim obj As dynamic = New DynamicClass(fields)
        '    'obj.EmployeeID = 123456
        '    'obj.EmployeeName = "John"
        '    'obj.Designation = "Tech Lead"
        '    'obj.Age = 25
        '    'obj.EmployeeName = 666
        '    'Console.WriteLine(obj.EmployeeID)
        '    'Console.WriteLine(obj.EmployeeName)
        '    'Console.WriteLine(obj.Designation)

        '    'Dim obj As Object
        '    'obj = New ExpandoObject
        '    'Dim i As Int16 = 0
        '    'For Each item In fields
        '    '    CreateDynamicObject(obj, item, values(i))
        '    '    i = i + 1
        '    'Next
        '    'for each item In values()

        '    'Next
        '    Return obj
        'End Function

        Public Function GetSpRecords(spName As String, fieldList As String, sortKey As String, filter As String, ParamArray parameters As Array()) As Object Implements IBaseDao.GetSpRecords
            'Dim fields as String = fieldList.Split(",")
            Dim sql As String = " Select " & fieldList & " From " & spName & " (" & filter & ") Order By " & sortKey
            If sortKey Is Nothing Or sortKey = "" Then
                sql = " Select " & fieldList & " From " & spName & " (" & filter & ")"
            Else
                sql = " Select " & fieldList & " From " & spName & " (" & filter & ") Order By " & sortKey
            End If
            Return GetDb().SqlRead(sql)
        End Function

        'Public Function GetParametrizedSpRecords(spName As String, ParamArray parameters As Array()) As Object Implements IBaseDao.GetParametrizedSpRecords
        '    'Dim fields as String = fieldList.Split(",")
        '    For each item in parameters

        '    Next
        '    Dim sql As String = " Select * From " & spName &
        '    If sortKey Is Nothing Or sortKey = "" Then
        '        sql = " Select " & fieldList & " From " & spName & " (" & filter & ")"
        '    Else
        '        sql = " Select " & fieldList & " From " & spName & " (" & filter & ") Order By " & sortKey
        '    End If
        '    Return GetDb().SqlRead(sql)
        'End Function

        Public Sub CreateDynamicObject(ByRef obj As ExpandoObject, ByVal propertyName As String, ByVal propertyValue As Object)
            Dim name As String = propertyName.Replace(" ", "")
            name = name.Replace("[", "")
            name = name.Replace("]", "")
            CType(obj, IDictionary(Of String, Object))(name) = propertyValue
        End Sub

        Public Function GetIdNoOfSortedPositionNumber(recordNo As Integer, tableName As String, sortOrder As String, Optional filter As String = Nothing) As Integer Implements IBaseDao.GetIdNoOfSortedPositionNumber
            Dim filterKey As String
            If filter Is Nothing Or filter = "" Then
                filterKey = ""
            Else
                filterKey = " where " & filter
            End If
            If recordNo = 0 Then
                Return 0
            Else
                Dim sql As String =
                        " Select " & GetPrimaryFieldName() & " FROM [" & tableName & "] " & filterKey & " order by " & sortOrder &
                        " OFFSET " & recordNo - 1 & " ROWS fetch Next 1 ROWS ONLY"
                Dim x As Object
                x = GetDb().Scalar(sql)
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
                        sql = "Select TOP 1 " & GetPrimaryFieldName() & " FROM [" & tableName & "] " & filterKey & " order by " & sortOrder
                        x = GetDb().Scalar(sql)
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
                Dim cResult = GetDb().Scalar(sql)
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
                Return GetDb().Scalar(sql, parms)
            End If
        End Function

        Public Function GetFieldOnMaxField(searchFieldName As String, tableName As String, returnFieldName As String, Optional filter As String = Nothing) As Object Implements IBaseDao.GetFieldOnMaxField
            Dim sql As String
            If filter Is Nothing Or filter = "" Then
                sql = " SELECT Top 1 " & returnFieldName & " from " & tableName & " order by " & searchFieldName & " Desc"
            Else
                sql = " SELECT Top 1 " & returnFieldName & " from " & tableName & " where " & filter & " order by " & searchFieldName & " Desc"
            End If
            Return GetDb().Scalar(sql)
        End Function

        Public Function GetRecordCount(tableName As String, Optional filter As String = Nothing) As Integer _
            Implements IBaseDao.GetRecordCount
            Dim sql As String = ""
            If filter Is Nothing Or filter = "" Then
                sql = "Select Count(*) FROM [" & tableName & "]"
            Else
                sql = "Select Count(*) FROM [" & tableName & "] " + IIf(filter Is Nothing, "", " where " & filter)
            End If
            Return GetDb().Scalar(sql)
        End Function

        Public Function GetRecordDateTimeStamp(idNo As Int32, tableName As String, dateTimeStampField As String) _
            As Object _
            Implements IBaseDao.GetRecordDateTimeStamp
            Dim retValue As Object
            Try
                Dim sql As String =
                    " Select top 1 " & dateTimeStampField & " FROM [" & tableName & "] " &
                    " Where " & GetPrimaryFieldName() & " = @IdNo "
                Dim params() As Object = {"@IdNo", idNo}
                retValue = GetDb().Scalar(sql, params)
            Catch ex As Exception
                retValue = Nothing
            End Try
            Return retValue
            'Return System.Text.Encoding.ASCII.GetString(retValue)
        End Function

        Public Function GetRecordField(tableName As String, returnFieldName As String) As Object Implements IBaseDao.GetRecordField
            Dim sql As String = " Select Top 1 " & returnFieldName & " FROM [" & tableName & "] "
            Dim retVal = GetDb().Scalar(sql)
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
            Dim retVal = GetDb().Scalar(sql, params)
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
            Dim retVal = GetDb().Scalar(sql, params)
            If retVal Is Nothing Or IsDBNull(retVal) Then
                Return Nothing
            End If
            Return retVal.ToString()
        End Function

        Public Function GetRecordFieldWith2KeyG(Of T1, T2, T3)(searchValue1 As T1, searchValue2 As T2, tableName As String,
                                       searchFieldName1 As String, searchFieldName2 As String,
                                       returnFieldName As String) As T3 Implements IBaseDao.GetRecordFieldWith2KeyG
            Dim searchVal1 As String = ConvertToString(Of T1)(searchValue1)
            Dim searchVal2 As String = ConvertToString(Of T2)(searchValue2)
            Dim sql As String = " Select Top 1 " & returnFieldName & " FROM [" & tableName & "] " &
                    " Where " & searchFieldName1 & " = @SearchVal1 and " & searchFieldName2 & " = @SearchVal2 "
            Dim params() As Object = {"@SearchVal1", searchVal1, "@SearchVal2", searchVal2}

            Dim retVal = GetDb().Scalar(sql, params)
            If retVal Is Nothing Or IsDBNull(retVal) Then
                Return Nothing
            End If
            Return retVal
        End Function

        Public Function GetRecordFieldWith3KeyG(Of S1, S2, S3, R1)(tableName As String, searchValue1 As S1, searchValue2 As S2, searchValue3 As S3,
                                       searchFieldName1 As String, searchFieldName2 As String, searchFieldName3 As String, returnFieldName As String) As R1 Implements IBaseDao.GetRecordFieldWith3KeyG
            Dim searchVal1 As String = ConvertToString(Of S1)(searchValue1)
            Dim searchVal2 As String = ConvertToString(Of S2)(searchValue2)
            Dim searchVal3 As String = ConvertToString(Of S3)(searchValue3)
            Dim sql As String = " Select Top 1 " & returnFieldName & " FROM [" & tableName & "] " &
                    " Where " & searchFieldName1 & " = @SearchVal1 and " & searchFieldName2 & " = @SearchVal2 and " & searchFieldName3 & " = @SearchVal3 "
            Dim params() As Object = {"@searchVal1", searchVal1, "@searchVal2", searchVal2, "@searchVal3", searchVal3}
            Dim retVal = GetDb().Scalar(sql, params)
            If retVal Is Nothing Or IsDBNull(retVal) Then
                Return Nothing
            End If
            Return retVal
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
            Dim retVal = GetDb().Scalar(sql, params)
            If retVal Is Nothing Or IsDBNull(retVal) Then
                Return Nothing
            End If
            Return retVal
        End Function

        Public Function GetRecordFieldWithKeyG(Of TR, TS)(searchValue As TS, tableName As String, searchFieldName As String, returnFieldName As String) As TR _
            Implements IBaseDao.GetRecordFieldWithKeyG
            Dim sql As String =
                    " Select Top 1 " & returnFieldName & " FROM [" & tableName & "] " &
                    " Where " & searchFieldName & " = @SearchValue "
            Dim params() As Object = {"@SearchValue", searchValue}
            Dim retVal = GetDb().Scalar(sql, params)
            If retVal Is Nothing Or IsDBNull(retVal) Then
                Return Nothing
            End If
            Return retVal
        End Function

        Public Function GetRecordPosition(tableName As String, idNo As Int32, Optional IdFieldName As String = Nothing) As Integer Implements IBaseDao.GetRecordPosition
            Dim fieldName As String = IIf(IdFieldName Is Nothing, "IdNo", IdFieldName)
            Dim sql As String =
                    " Select Count(*) FROM [" & tableName & "] " &
                    " Where " & fieldName & " < " & idNo
            Return GetDb().Scalar(sql)
        End Function


        Public Function GetRecordPositionByKey(Of T)(keyValue As T, tableName As String, sortKey As String, keyFieldName As String) As Integer Implements IBaseDao.GetRecordPositionByKey
            'Dim sql As String = "Select count(*) from [" & tableName & "] where [" & sortKey & "] < (select [" & sortKey & "] from [" & tableName & "] where [" & keyFieldName & "] = " & keyValue.ToString() & ")"
            Dim sql As String = "SELECT RowNr FROM ( SELECT  ROW_NUMBER() OVER (ORDER BY [" & sortKey & "]) AS RowNr, " & keyFieldName & " FROM [" & tableName & "]) sub WHERE sub." & keyFieldName & " = " & keyValue.ToString()
            Return GetDb().Scalar(sql)
        End Function

        Public Function GetRecordPositionByName(tableName As String, sortField As String, nameValue As String) _
            As Integer _
            Implements IBaseDao.GetRecordPositionByName
            Dim sql As String =
                    " Select Count(*) FROM [" & tableName & "] " &
                    " Where " & sortField & "< '" & nameValue & "'"
            Return GetDb().Scalar(sql)
        End Function

        Public Function GetRecords(tableName As String, sortKey As String, Optional fieldNames As String() = Nothing, Optional filterKey As String = Nothing) As Object Implements IBaseDao.GetRecords
            Dim fields As String
            If fieldNames Is Nothing Then
                fields = "*"
            Else
                fields = String.Join(",", fieldNames)
            End If
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
            Return GetDb().SqlRead(sql)
        End Function

        Public Function GetDtRecords(tableName As String, fieldNames As String, filterKey As String, sortKey As String) As DataTable Implements IBaseDao.GetDtRecords
            Dim sql As String
            If filterKey Is Nothing Or filterKey = "" Then
                If sortKey Is Nothing Or sortKey = "" Then
                    sql = " SELECT " & fieldNames & " from [" & tableName & "]"
                Else
                    sql = " SELECT " & fieldNames & " from [" & tableName & "] order by " & sortKey
                End If
            Else
                If sortKey Is Nothing Or sortKey = "" Then
                    sql = " SELECT " & fieldNames & " from [" & tableName & "] where " & filterKey
                Else
                    sql = " SELECT " & fieldNames & " from [" & tableName & "] where " & filterKey & " order by " & sortKey
                End If
            End If
            Return GetDb().SqlReadDataTable(sql)
        End Function

        'Public Function GetRecordsDataTable(tableName As String, sortKey As String, Optional fieldNames As String() = Nothing, Optional filterKey As String = Nothing) As Object Implements IBaseDao.GetRecordsDataTable
        '    'Dim fields As String
        '    'If fieldNames Is Nothing Then
        '    '    fields = "*"
        '    'Else
        '    '    fields = String.Join(",", fieldNames)
        '    'End If
        '    Dim sql As String
        '    If filterKey Is Nothing Or filterKey = "" Then
        '        If sortKey Is Nothing Or sortKey = "" Then
        '            sql = " SELECT " & fields & " from [" & tableName & "]"
        '        Else
        '            sql = " SELECT " & fields & " from [" & tableName & "] order by " & sortKey
        '        End If
        '    Else
        '        If sortKey Is Nothing Or sortKey = "" Then
        '            sql = " SELECT " & fields & " from [" & tableName & "] where " & filterKey
        '        Else
        '            sql = " SELECT " & fields & " from [" & tableName & "] where " & filterKey & " order by " & sortKey
        '        End If
        '    End If
        '    Return CreateDataTable(sql)
        'End Function

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
        '    Return GetDb().SqlRead(sql)
        'End Function

        Public Function FieldExistInTable(tableName As String, fieldName As String) As Boolean Implements IBaseDao.FieldExistInTable
            Dim retValue As Boolean
            retValue = GetDb().FieldExistInTable(tableName, fieldName)
            Return retValue
        End Function

        'Public Function GetFields(tableName As String, sortKey As String, ByVal ParamArray fieldNames() As String) Implements IBaseDao.GetFields
        '    Dim fields = String.Join(",", fieldNames)
        '    If Strings.Right(fields, 1) = "," Then
        '        fields = Strings.Left(fields, Len(fields) - 1)
        '    End If
        '    Dim sql = " SELECT " & fields & " from [" & tableName & "] order by " & sortKey
        '    Return GetDb().SqlRead(sql)
        'End Function

        'Public Function GetFieldsFiltered(tableName As String, sortKey As String, filter As String, ByVal ParamArray fieldNames() As String) Implements IBaseDao.GetFieldsFiltered
        '    Dim fields = String.Join(",", fieldNames)
        '    If Strings.Right(fields, 1) = "," Then
        '        fields = Strings.Left(fields, Len(fields) - 1)
        '    End If
        '    Dim sql = " SELECT " & fields & " from [" & tableName & "] order by " & sortKey & " where " & filter
        '    Return GetDb().SqlRead(sql)
        'End Function

        Public Function GetSortedRecordPosition(idNo As Int32, tableName As String, sortOrder As String, Optional filter As String = Nothing) As Integer Implements IBaseDao.GetSortedRecordPosition
            Dim filterKey As String
            If filter Is Nothing Or filter = "" Then
                filterKey = ""
            Else
                filterKey = filter
            End If
            Dim sql As String = " Select count(*) From [" & tableName & "] where " & IIf(filterKey = "", "", "(" & filterKey & ") and ") _
                                                & " " & sortOrder & " <= (Select " & sortOrder & " from [" & tableName & "] where " &
                                                IIf(filterKey = "", "", "(" & filterKey & ") and ") & GetPrimaryFieldName() & " = " & idNo & ") "
            Dim recordPosition = GetDb().Scalar(sql) ' + 1
            Dim recCount = GetRecordCount(tableName, filterKey)
            If recordPosition > recCount Then
                recordPosition = recCount
            Else
                If recordPosition < 0 Then
                    recordPosition = 0
                End If
            End If
            Return recordPosition
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
            Dim x = GetDb().Scalar(sql)
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
            Return _db.SqlReadSecurity(sql, params)
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
            Return _db.SqlReadSecurity(sql, params)
        End Function

        Public Function AddSecurityObject(securityObject As SecurityObject) As Integer Implements IBaseDao.AddSecurityObject
            Dim sql = "Insert into SecurityObject (securityObjectName,systemViewIdNo,parentIdNo) VALUES (@SecurityObjectName,@SystemViewIdNo,@ParentIdNo)"
            Return GetDb().Insert(sql, TakeSecurityObject(securityObject))
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
                                {sql1 & "(8, N'8', N'Translators', NULL, NULL, NULL, 0, NULL)"},
                                {sql1 & "(9, N'9', N'ApproveTransactions', NULL, NULL, NULL, 0, NULL)"},
                                {"SET IDENTITY_INSERT [SecurityObject] OFF "}}
            Return _db.ExecuteCommands("SecurityObjectCreate", commandArray)
        End Function

        Public Function HasRecordChanged(idNo As Int32, tableName As String, timeStampValue As Byte,
                                                 Optional ByVal timeStampedField As String = "DateTimeStamp") As Boolean _
                    Implements IBaseDao.HasRecordChanged
            Dim sql As String = " Select count(*) FROM [" & tableName & "] " &
                                " Where " & GetPrimaryFieldName() & " = @IdNo and timeStampedField = @timeStampValue "
            Dim params() As Object = {"@IdNo", idNo, "@timeStampValue", timeStampValue}
            Dim nCount = GetDb().Scalar(sql, params)
            Return Not nCount > 0
        End Function

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
            nCount = GetDb().Scalar(sql, params)
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
                    " where " & GetPrimaryFieldName() & " = " & idNo
            Return GetDb().Update(sql, {"@Value", value})
        End Function

        Public Function GenericUpdateRecordWithIdNo(Of T)(idNo As Int32, tableName As String, fieldName As String, value As T, Optional primaryKeyFieldName As String = "IdNo") As Integer _
            Implements IBaseDao.GenericUpdateRecordWithIdNo
            Dim primaryKey = IIf(primaryKeyFieldName Is Nothing, GetPrimaryFieldName(), primaryKeyFieldName)
            Dim sql As String =
                    " Update [" & tableName & "] " &
                    " Set " & fieldName & " = @Value" &
                    " where " & primaryKey & " = " & idNo
            Return GetDb().Update(sql, {"@Value", value})
        End Function

        Public Function GetFieldType(tableName As String, fieldName As String) As Object Implements IBaseDao.GetFieldType
            Dim value As Object
            Dim sql As String = "Select DATA_TYPE From INFORMATION_SCHEMA.COLUMNS Where TABLE_NAME = @tableName AND COLUMN_NAME = @fieldName"
            Dim params() As Object = {"@TableName", tableName, "@FieldName", fieldName}
            value = GetDb().Scalar(sql, params)
            Return value
        End Function

        Public Function UpdateRecordWithKey(Of T1, T2)(tableName As String, keyFieldName As String, keyFieldValue As T1, fieldNameToReplace As String, replaceValue As T2) As Integer _
            Implements IBaseDao.UpdateRecordWithKey
            Dim sql As String =
                    " Update " & tableName &
                    " Set " & fieldNameToReplace & " = @replaceValue" &
                    " where " & keyFieldName & " = @keyFieldValue"
            Return GetDb().Update(sql, {"@keyFieldValue", keyFieldValue, "@replaceValue", replaceValue})
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

        Public Function GetLastSeriesNumber(seriesName As String) As Integer Implements IBaseDao.GetLastSeriesNumber
            Dim retValue As Integer
            retValue = 0
            Dim transactionName = seriesName
            Using connection As New SqlConnection(GetDb().GetConnectionString)
                connection.Open()

                Dim command As SqlCommand = connection.CreateCommand()
                Dim transaction As SqlTransaction

                ' Start a local transaction
                transaction = connection.BeginTransaction(transactionName)

                ' Must assign both transaction object and connection
                ' to Command object for a pending local transaction.
                command.Connection = connection
                command.Transaction = transaction

                Try
                    Dim sqlText1 As String = "Update [Series] set Value = Value + 1 where SeriesName = '" & seriesName & "'"
                    command.CommandText = sqlText1
                    Dim sqlText2 As String = "Select Value from Series where SeriesName = '" & seriesName & "'"
                    command.ExecuteNonQuery()
                    command.CommandText = sqlText2
                    retValue = command.ExecuteScalar()

                    ' Attempt to commit the transaction.
                    transaction.Commit()
                Catch ex As Exception
                    MessageBox.Show("Commit Exception Type: " & ex.GetType().ToString())
                    MessageBox.Show("  Message: {0}", ex.Message)

                    ' Attempt to roll back the transaction.
                    Try
                        transaction.Rollback()
                    Catch ex2 As Exception
                        ' This catch block will handle any errors that may have occurred
                        ' on the server that would cause the rollback to fail, such as
                        ' a closed connection.
                        Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType())
                        Console.WriteLine("  Message: {0}", ex2.Message)
                    End Try
                    retValue = -1
                End Try
            End Using
            Return retValue
        End Function

        Public Function GetNextSeries(ByVal seriesName As String) As Int32 Implements IBaseDao.GetNextSeries
            Dim retVal As Integer
            Dim sql As String
            sql = "SELECT NEXT VALUE FOR " & seriesName.Trim() ' & ".CountBy1"
            retVal = GetDb().Scalar(sql)
            Return retVal
        End Function

        Public Function GetNextSeries(ByVal schemaName As String, ByVal seriesName As String) As Int32 Implements IBaseDao.GetNextSeries
            Dim retVal As Integer
            Dim sql As String
            sql = "SELECT NEXT VALUE FOR " & seriesName.Trim() ' & ".CountBy1"
            retVal = GetDb().Scalar(sql)
            Return retVal
        End Function

        'Execute a Table Valued Parameter Stored Procedure
        Public Function ExecuteTvpSp(ByRef procedureName As String, dataTable As DataTable) As Int32 Implements IBaseDao.ExecuteTvpSp
            Return GetDb().InsertTvp(procedureName, dataTable)
        End Function

        'Public Overloads Function GetDataSet(ByVal storedProcedureName As String, ByVal paramList As Dictionary(Of String, String)) As DataSet Implements IBaseDao.GetDataSet
        '    Using conn As SqlConnection = New SqlConnection(GetDb().GetConnectionString)
        '        Dim cmd As SqlCommand = New SqlCommand()
        '        cmd.CommandType = CommandType.StoredProcedure
        '        cmd.CommandText = storedProcedureName
        '        cmd.Connection = conn

        '        For Each key As String In paramList.Keys
        '            cmd.Parameters.AddWithValue(key, paramList(key))
        '        Next
        '        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
        '        Dim ds As DataSet = New DataSet()
        '        da.Fill(ds)
        '        cmd = Nothing
        '        da = Nothing
        '        Return ds
        '    End Using
        'End Function

        Public Function GetDataSet(ByVal storedProcedureName As String, parameters As Object) As DataSet Implements IBaseDao.GetDataSet
            Using conn As SqlConnection = New SqlConnection(GetDb().GetConnectionString)
                Dim cmd As SqlCommand = New SqlCommand()
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = storedProcedureName
                cmd.Connection = conn
                For i = 1 To parameters.Length Step 2
                    cmd.Parameters.AddWithValue(parameters(i - 1).ToString(), parameters(i))
                Next
                Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
                Dim ds As DataSet = New DataSet()
                da.Fill(ds)
                Return ds
            End Using
        End Function

        Public Function GetMasterList(tableName As String, sortKey As String, fieldNames As String(), Optional filterKey As String = Nothing) As Object Implements IBaseDao.GetMasterList
            Dim fields As String
            If Len(fieldNames) <> 3 Then
                Debugger.Break()
            End If
            fields = fieldNames(1) & " As Name" + ", " & fieldNames(2) & " As Code" & fieldNames(3) & " As IdNo"
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
            Return GetDb().Read(sql, MakeMasterList).ToList()
        End Function

        Public Sub SaveConnectionString()
            GetDb().SaveConnectionString()
        End Sub

        Public Sub RestoreConnectionString()
            GetDb().RestoreConnectionString()
        End Sub

        Public Sub SetConnectionString(Optional connectionName As String = ConnectionNameConstant)
            GetDb().SetConnectionString(connectionName)
        End Sub

        Private Shared ReadOnly MakeMasterList As Func(Of IDataReader, GenericData) = Function(reader) New GenericData() With {
            .Code = Extensions.AsString(reader("Code")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .Name = Extensions.AsString(reader("Name"))}

        Public Function InsertRecord(tableName As String, fields As Object(), fieldTypes As Object(), ParamArray values() As Object) As Integer Implements IBaseDao.InsertRecord
            Dim fieldList As String = String.Join(",", fields)
            Dim valuesList As String = ""
            Dim parameters As New List(Of Object)
            Dim i As Int16
            For Each value In values
                If i > 0 Then
                    valuesList = valuesList + ","
                End If
                valuesList = valuesList + "@" + fields(i)

                parameters.Add("@" + fields(i))
                If fieldTypes(i) = "String" Then
                    parameters.Add(values(i))
                ElseIf fieldTypes(i) = "Date" Then
                    parameters.Add(Date.Parse(value))
                ElseIf fieldTypes(i) = "DateTime" Then
                    parameters.Add(DateTime.Parse(value))
                ElseIf fieldTypes(i) = "Decimal" Then
                    parameters.Add(Decimal.Parse(value))
                ElseIf fieldTypes(i) = "Integer" OrElse fieldTypes(i) = "Int32" OrElse fieldTypes(i) = "Int16" Then
                    parameters.Add(Integer.Parse(value))
                Else
                    Messaging.Show("Invalid data Type <" & fieldTypes(i) & ">.")
                    Debugger.Break()
                End If

                i = i + 1
            Next
            'For Each value In values
            '    If i > 0 Then
            '        valuesList = valuesList + ","
            '    End If
            '    If fieldTypes(i) = "String" Then
            '        valuesList = valuesList + "'" + value + "'"
            '    ElseIf fieldTypes(i) = "Date" Or fieldTypes(i) = "DateTime" Then
            '        valuesList = valuesList + "@" + fields(i)
            '        parameters = parameters + "@"+fields(i)
            '    Else
            '        valuesList = valuesList + value.ToString()
            '    End If
            '    valuesList = valuesList
            '    i = i + 1
            'Next
            Dim array As Object() = parameters.ToArray()
            Dim sql As String = "Insert into " & tableName & " (" & fieldList & ") values (" & valuesList & ")"
            Return GetDb().Scalar(sql, array)
        End Function

        Public Overridable Function GetActualFieldName(fieldName As String)
            Return fieldName
        End Function

        Public Function GetDataTable(ByVal sqlCommand As String) As DataTable
            Return CreateDataTable(sqlCommand)
        End Function

        Public Function GetDataTable(tableName As String, Optional sortField As String = Nothing, Optional fieldsList As String = Nothing, Optional filter As String = Nothing) As DataTable Implements IBaseDao.GetDataTable
            Dim dataConnection As SqlConnection = New SqlConnection(GetDb().GetConnectionString)
            Dim sqlCommand As String
            If fieldsList Is Nothing Then
                sqlCommand = "Select * from " + tableName
            Else
                sqlCommand = "Select " + fieldsList + " from " + tableName
            End If
            If filter IsNot Nothing Then
                sqlCommand = sqlCommand + " where " + filter
            End If
            If sortField IsNot Nothing Then
                sqlCommand = sqlCommand + " order by " + sortField
            End If
            Return CreateDataTable(sqlCommand)
        End Function

        Private Function CreateDataTable(sqlCommand As String) As DataTable
            Dim dataConnection As SqlConnection = New SqlConnection(GetDb().GetConnectionString)
            Dim command As New SqlCommand(sqlCommand, dataConnection)
            Dim adapter As SqlDataAdapter = New SqlDataAdapter()
            adapter.SelectCommand = command
            Dim table As New DataTable
            table.Locale = System.Globalization.CultureInfo.InvariantCulture
            adapter.Fill(table)
            Return table
        End Function

        Public Function GetDataValue(sqlCommand As String) As Object
            Return GetDb().Scalar(sqlCommand)
        End Function

        Public Function RunStoredProcedure(storedProcedureName As String, parameters As Object) As Object Implements IBaseDao.RunStoredProcedure
            Return GetDb().RunSqlStoredProcedure(storedProcedureName, parameters)
        End Function

        Public Function PerformUtility(utilityName As String, Optional parameters As Object = Nothing) As Object Implements IBaseDao.PerformUtility
            Dim retVal As Int16
            Dim storedProcedureName As String
            If parameters.StoredProcedure Then
                storedProcedureName = "sp" + utilityName
                retVal = GetDb().RunStoredProcedure(storedProcedureName, parameters)
            Else

            End If
            Return retVal
        End Function


        Public Function DeleteRecord(idNo As Integer, tableName As String) As Integer Implements IBaseDao.DeleteRecord
            Dim params() As Object = {"@IdNo", idNo}
            Dim sql As String
            'Dim cTableName = GetPhysicalTableName(tableName)
            If tableName.Length >= 5 AndAlso tableName.Right(5) = "_View" Then
                Dim l As Int16 = Len(tableName)
                sql = "Delete From [" & Left(tableName, Len(tableName) - 5) & "] " & " Where IdNo = " & idNo
                Return GetDb().scalar(sql, params)
            Else
                sql = "Delete From [" & tableName & "] " & " Where IdNo = @IdNo"
            End If
            Return GetDb().Scalar(sql, params)
        End Function

    End Class

    Public Class DaoCommand

        Public Property CommandText As String
        Public Property Parameters As Array

        Public Sub Add(commandText As String, parameters As Object())
            Me.CommandText = commandText
            Me.Parameters = parameters
        End Sub

    End Class

End Namespace