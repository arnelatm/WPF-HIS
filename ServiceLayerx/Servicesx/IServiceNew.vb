Public Interface IServiceNew

    Function GetRecordById(idNo As Integer)

    Function GetAll(Optional ByRef sortKey As String = "")

    Function UpdateRecord(Of TBiz)(ByRef modelBiz As TBiz) As Integer

    Function AddRecord(ByRef modelBiz) As Integer

End Interface