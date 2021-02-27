Public Interface IDao(Of TBiz)

    ' gets a specific record data
    Function GetRecordById(idNo) As TBiz

    ' Add a recordData
    Function AddRecord(ByRef recordData As TBiz) As Integer

    ' updates a recordData
    Function UpdateRecord(ByRef recordData As TBiz) As Integer

End Interface

Public Interface IDaoGetRecordByIdNo(Of TBiz)

    ' gets a specific record data
    Function GetRecordByIdNo(idNo) As List(Of TBiz)

End Interface

Public Interface IDaoRead(Of TBiz)

    ' gets a specific record data
    Function GetRecordById(idNo) As TBiz

    Function GetAll(Optional ByVal sortExpression As String = Nothing) As List(Of TBiz)

End Interface

Public Interface IDaoAll(Of TBiz)
    Inherits IDao(Of TBiz)

    ' gets a specific record data
    Function GetAll(Optional ByVal sortExpression As String = Nothing) As List(Of TBiz)

End Interface

Public Interface IDaoChild(Of TBiz)
    ' gets a specific record data

    Function GetRecordsWithGroupIdNo(idNo, Optional ByVal sortExpression = Nothing) As List(Of TBiz)

    Function DelUpdateTvp(ByRef tvpTable As DataTable, ByVal groupIdNo As Integer) As Integer

    Function InsertTvp(ByRef tvpTable As DataTable) As Integer

End Interface

Public Interface IDaoTvp(Of TBiz)
    ' gets a specific record data

    Function UpdateInsertTvp(ByRef updateTvpTable As DataTable, ByRef insertTvpTable As DataTable, ByVal groupIdNo As Integer) As Integer

End Interface