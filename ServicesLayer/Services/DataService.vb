Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.AatmInterfaces
Imports AATM.Libraries.GlobalFuncNSub

Namespace Services

    Public Class DataService
        Inherits ServiceNew
        Implements IDataService

        Public Function AddRecord(ByRef model) As Integer Implements IDataService.AddRecord
            GlobalVariables.Mapper.Map(model, DataBo)
            Return DataDao.AddRecord(DataBo)
        End Function

        Public Function CheckIfUnique(textValue As String, tableName As String, fieldName As String, targetIdNo As Int32) As Boolean Implements IDataService.CheckIfUnique
            Return BaseDao.CheckIfUnique(textValue, tableName, fieldName, targetIdNo)
        End Function

        Public Function CountRecordWith2Key(searchValue1 As String, searchValue2 As String, tableName As String, searchFieldName1 As String, searchFieldName2 As String) As Integer Implements IDataService.CountRecordWith2Key
            Return BaseDao.CountRecordWith2Key(searchValue1, searchValue2, tableName, searchFieldName1, searchFieldName2)
        End Function

        Public Function CountRecordWithKey(searchValue As String, tableName As String, searchFieldName As String) As Integer Implements IDataService.CountRecordWithKey
            Return BaseDao.CountRecordWithKey(searchValue, tableName, searchFieldName)
        End Function

        Public Function DeleteRecord(idNo As Int32, tableName As String) As Integer _
            Implements IDataService.DeleteRecord
            Return BaseDao.DeleteRecord(idNo, tableName)
        End Function

        Public Function DelUpdateTvp(dtTable As DataTable, ByVal groupKey As Integer) As Integer Implements IDataService.DelUpdateTvp
            Return DataDao.DelUpdateTvp(dtTable, groupKey)
        End Function

        Public Function FieldExistInTable(ByVal tableName As String, fieldName As String) As Boolean Implements IDataService.FieldExistInTable
            Return BaseDao.FieldExistInTable(tableName, fieldName)
        End Function

        Public Function FindDateField(tableName As String, findableControl As IFindableControl, Optional filter As String = Nothing) As Integer Implements IDataService.FindDateField
            Return BaseDao.FindDateField(tableName, findableControl, filter)
        End Function

        Public Function FindFieldContinue(tableName As String, idNo As Int32, sortOrderKey As String) As Integer Implements IDataService.FindFieldContinue
            Return BaseDao.FindFieldContinue(tableName, idNo, sortOrderKey)
        End Function

        Public Function FindFieldNew(tableName As String, findableControl As IFindableControl, sortOrderKey As String, Optional filter As String = Nothing) As Integer Implements IDataService.FindFieldNew
            Return BaseDao.FindFieldNew(tableName, findableControl, sortOrderKey, filter)
        End Function

        Public Function GenericUpdateRecordWithIdNo(Of T)(idNo As Int32, tableName As String, fieldName As String, value As T) As Integer _
            Implements IDataService.GenericUpdateRecordWithIdNo
            Dim dDataDao = New BaseDao
            Return dDataDao.GenericUpdateRecordWithIdNo(idNo, tableName, fieldName, value)
        End Function

        Public Overloads Function GetAll(Optional ByRef sortKey As String = Nothing) Implements IDataService.GetAll
            Return DataDao.GetAll(sortKey)
        End Function

        Public Function GetDefaultFieldValues(ByVal systemViewName As String) Implements IDataService.GetDefaultFieldValues
            Return DefaultFieldValueDao.GetTableDefaultValues(systemViewName)
        End Function

        Public Function GetField(searchValue As String, tableName As String, searchFieldName As String, returnFieldName As String) As Object Implements IDataService.GetField
            Return BaseDao.GetField(searchValue, tableName, searchFieldName, returnFieldName)
        End Function

        Public Function GetField(Of TR, TS)(searchValue As TS, tableName As String, searchFieldName As String, returnFieldName As String, Optional filter As String = Nothing) As TR Implements IDataService.GetField
            Return BaseDao.GetField(Of TR, TS)(searchValue, tableName, searchFieldName, returnFieldName, filter)
        End Function

        Public Function GetFieldOnMaxField(searchFieldName As String, tableName As String, returnFieldName As String, Optional filter As String = Nothing) As Object Implements IDataService.GetFieldOnMaxField
            Return BaseDao.GetFieldOnMaxField(searchFieldName, tableName, returnFieldName, filter)
        End Function

        Public Function GetFieldsWithIdNo(idNo As Object, tableName As String, fields As String) As Object Implements IDataService.GetFieldsWithIdNo
            Return BaseDao.GetFieldsWithIdNo(idNo, tableName, fields)
        End Function

        Public Function GetFieldType(tableName As String, fieldName As String) As Object Implements IDataService.GetFieldType
            Return BaseDao.GetFieldType(tableName, fieldName)
        End Function

        Public Function GetFieldValue(Of TType)(sqlStatement As String, tableName As String, condition As String) As TType Implements IDataService.GetFieldValue
            Return BaseDao.GetFieldValue(Of TType)(sqlStatement, tableName, condition)
        End Function

        Public Function GetFieldWithIdNo(idNo As Object, tableName As String, returnFieldName As String) As Object Implements IDataService.GetFieldWithIdNo
            Return BaseDao.GetFieldWithIdNo(idNo, tableName, returnFieldName)
        End Function

        Public Function GetIdNoOfSortedPositionNumber(recordNo As Integer, tableName As String, sortOrder As String, Optional filter As String = Nothing) As Integer Implements IDataService.GetIdNoOfSortedPositionNumber
            Return BaseDao.GetIdNoOfSortedPositionNumber(recordNo, tableName, sortOrder, filter)
        End Function

        Public Function GetLastSortKey(ByVal searchValue As String, ByVal tableName As String) As String Implements IDataService.GetLastSortKey
            Return BaseDao.GetLastSortKey(searchValue, tableName)
        End Function

        Public Function GetMainTableColumnProperties(tableName As String) As List(Of TblColProp) Implements IDataService.GetMainTableColumnProperties
            Return TblColPropDao.GetMainTableColumnProperties(tableName)
        End Function

        Public Function GetRecordByIdNo(Of TM As New)(idNo As Int32) As TM Implements IDataService.GetRecordByIdNo
            Dim modelOfPresenter As New TM
            Dim record = DataDao.GetRecordByIdNo(Convert.ToInt32(idNo))
            If record IsNot Nothing Then
                GlobalVariables.Mapper.Map(record, modelOfPresenter)
            End If
            Return modelOfPresenter
        End Function

        Public Function GetRecordCount(tableName As String, Optional filter As String = Nothing) As Integer Implements IDataService.GetRecordCount
            Return BaseDao.GetRecordCount(tableName, filter)
        End Function

        Public Function GetRecordDateTimeStamp(idNo As Int32, tableName As String, Optional ByVal dateTimeStampField As String = "DateTimeStamp") As Object Implements IDataService.GetRecordDateTimeStamp
            Return BaseDao.GetRecordDateTimeStamp(idNo, tableName, dateTimeStampField)
        End Function

        Public Function GetRecordField(tableName As String, returnFieldName As String) As Object Implements IDataService.GetRecordField
            Return BaseDao.GetRecordField(tableName, returnFieldName)
        End Function

        Public Function GetRecordFieldWith2Key(searchValue1 As String, searchValue2 As String, tableName As String, searchFieldName1 As String, searchFieldName2 As String, returnFieldName As String) As String Implements IDataService.GetRecordFieldWith2Key
            Return BaseDao.GetRecordFieldWith2Key(searchValue1, searchValue2, tableName, searchFieldName1, searchFieldName2, returnFieldName)
        End Function

        Public Function GetRecordFieldWithKey(searchValue As String, tableName As String, searchFieldName As String, returnFieldName As String) As String Implements IDataService.GetRecordFieldWithKey
            Return BaseDao.GetRecordFieldWithKey(searchValue, tableName, searchFieldName, returnFieldName)
        End Function

        Public Function GetRecordFieldWithKeyG(Of T)(searchValue As String, tableName As String, searchFieldName As String, returnFieldName As String) As T Implements IDataService.GetRecordFieldWithKeyG
            Return BaseDao.GetRecordFieldWithKeyG(Of T)(searchValue, tableName, searchFieldName, returnFieldName)
        End Function

        Public Function GetRecordPosition(tableName As String, idNo As Int32) As Integer Implements IDataService.GetRecordPosition
            Return BaseDao.GetRecordPosition(tableName, idNo)
        End Function

        Public Function GetRecords(ByVal tableName As String, ByVal sortKey As String, ByVal fields As String(), Optional filterKey As String = Nothing) As Object Implements IDataService.GetRecords
            Return BaseDao.GetRecords(tableName, sortKey, fields, filterKey)
        End Function

        Public Function GetRecordsWithGroupIdNo(Of TM)(idNo, Optional ByRef sortKey = Nothing) As List(Of TM) Implements IDataService.GetRecordsWithGroupIdNo
            Dim bizData = DataDao.GetRecordsWithGroupIdNo(idNo, sortKey)
            Dim dataModel As New List(Of TM)
            GlobalVariables.Mapper.Map(bizData, dataModel)
            Return dataModel
        End Function

        Public Function GetSortedRecordPosition(idNo As Int32, tableName As String, sortOrder As String, Optional filter As String = Nothing) As Integer Implements IDataService.GetSortedRecordPosition
            Return BaseDao.GetSortedRecordPosition(idNo, tableName, sortOrder, filter)
        End Function

        Public Function HasRecordChanged(idNo As Int32, tableName As String, timeStampedValue As Object, Optional ByVal timeStampField As String = "DateTimeStamp") As Boolean Implements IDataService.HasRecordChanged
            Return BaseDao.HasRecordChanged(idNo, tableName, timeStampedValue, timeStampField)
        End Function

        'Public Shadows Function GetRecordByIdNo(idNo) Implements IDataService.GetRecordByIdNo
        '    Return DataDao.GetRecordByIdNo(Convert.ToInt32(idNo))
        'End Function
        Public Function InsertTvp(dtTable As DataTable) As Integer Implements IDataService.InsertTvp
            Return DataDao.InsertTvp(dtTable)
        End Function

        Public Function TransactionUpdate(Of TBiz)(ByRef model As TBiz) As Integer _
            Implements IDataService.TransactionUpdate
            Return DataDao.TransactionUpdate(model)
        End Function

        Public Function UpdateRecord(ByVal model) As Integer Implements IDataService.UpdateRecord
            GlobalVariables.Mapper.Map(model, DataBo)
            Return DataDao.UpdateRecord(DataBo)
        End Function

        Public Function UpdateRecordWithIdNo(Of T)(ByVal idNo As Int32, ByVal tableName As String, ByVal fieldName As String, ByRef value As T) As Integer Implements IDataService.UpdateRecordWithIdNo
            Return BaseDao.UpdateRecordWithIdNo(Of T)(idNo, tableName, fieldName, value)
        End Function

        Public Function UpdateTvp(dtTable As DataTable) As Integer Implements IDataService.UpdateTvp
            Return DataDao.UpdateTvp(dtTable)
        End Function

    End Class

End Namespace