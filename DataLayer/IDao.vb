Public Interface IDao(Of TBiz)

    ' gets a specific record data
    Function GetRecordByIdNo(idNo) As TBiz

    ' Add a recordData
    Function AddRecord(ByRef recordData As TBiz) As Integer

    ' updates a recordData
    Function UpdateRecord(ByRef recordData As TBiz) As Integer

End Interface

Public Interface IDaoCRUD(Of TBiz)

    ' gets a specific record data
    Function GetRecordByIdNo(idNo) As TBiz

    ' Add a recordData
    Function AddRecord(ByRef recordData As TBiz) As Integer

    ' updates a recordData
    Function UpdateRecord(ByRef recordData As TBiz) As Integer

    Function DeleteRecord(ByRef recordData As TBiz) As Integer

End Interface

Public Interface IDaoReadOnly(Of TBiz)

    ' gets a specific record data
    Function GetRecordByIdNo(idNo) As TBiz

End Interface

Public Interface IDaoGetListByIdNo(Of TBiz)

    ' gets a specific record data
    Function GetListByIdNo(idNo) As List(Of TBiz)

End Interface

'Public Interface IDaoRead(Of TBiz)

'    ' gets a specific record data
'    Function GetRecordByIdNo(idNo) As TBiz

'End Interface

'Public Interface IDaoAllOnly(Of TBiz)

'    ' gets a specific record data
'    Function GetAll(Optional ByVal sortExpression As String = Nothing) As List(Of TBiz)

'End Interface

Public Interface IDaoGetAll(Of TBiz)

    ' gets a specific record data
    Function GetAll(Of TM)(sortExpression As String) As List(Of TBiz)

End Interface

Public Interface IDaoList(Of TBiz)

    ' gets a specific record data
    Function GetList(Optional ByVal sortExpression As String = Nothing) As List(Of TBiz)

End Interface

Public Interface IDaoListParametrized(Of TBiz)

    Function GetListParametrized(parameter As Object, Optional ByVal sortExpression As String = Nothing) As List(Of TBiz)

End Interface

Public Interface IDaoParametrized(Of TBiz)

    Function GetParametrized(Of T)(parameter As Object, Optional ByVal sortExpression As String = Nothing) As TBiz

End Interface

Public Interface IDaoChild(Of TBiz)
    ' gets a specific record data

    Function GetRecordsWithGroupIdNo(idNo, Optional ByVal sortExpression = Nothing) As List(Of TBiz)

    Function DelUpdateTvp(ByRef tvpTable As DataTable, ByVal groupIdNo As Integer) As Integer

    Function InsertTvp(ByRef tvpTable As DataTable) As Integer

End Interface

Public Interface IDaoStoredProcedure

    Function RunSpWithRollBack(ByRef storedProcedureName As String, parameter As Object) As Object

End Interface

Public Interface IDaoGetRecordsWithParams(Of TM)
    Function GetRecordsWithParams(parameters As Object) As List(Of TM)
End Interface

Public Interface IDaoChildUpdateOnly(Of TBiz)
    ' gets a specific record data

    Function GetRecordsWithGroupIdNo(idNo, Optional ByVal sortExpression = Nothing) As List(Of TBiz)

    'Function DelUpdateTvp(ByRef tvpTable As DataTable, ByVal groupIdNo As Integer) As Integer

End Interface

Public Interface IGetRecordsWithGroupIdNo(Of TBiz)
    ' gets a group of records with specific id no.

    Function GetRecordsWithGroupIdNo(idNo, Optional ByVal sortExpression = Nothing) As List(Of TBiz)

End Interface

Public Interface IDaoTvp(Of TBiz)
    ' gets a specific record data

    Function UpdateInsertTvp(ByRef updateTvpTable As DataTable, ByRef insertTvpTable As DataTable, ByVal groupIdNo As Integer) As Integer

End Interface

Public Interface IDaoUpdateDataTable

    ' updae the table given the DataTable
    Function UpdateTable(Of T)(data As Object(), groupKey As T) As Integer


End Interface


Public Interface IDaoUpdateTable(Of TBiz)

    ' updae the table given the DataTable
    Function UpdateTable(Of T)(data As List(Of TBiz), groupKey As T) As Integer


End Interface