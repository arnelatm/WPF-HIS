Public Interface IDao(Of TBiz)
    ' gets a specific record data
    Function GetRecordById(idNo As Integer) As TBiz

    ' gets a sorted list of all Documents
    Function GetAll(Optional ByVal sortExpression As String = nothing) As List(Of TBiz)

    ' Add a recordData
    Function AddRecord(ByRef recordData As TBiz) As Integer

    ' updates a recordData
    Function UpdateRecord(ByRef recordData As TBiz) As Integer

End Interface
