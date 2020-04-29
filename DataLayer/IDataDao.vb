' defines methods to access records.
' this is a database-independent interface. Implementations are database specific
' ** DAO Pattern

Public Interface IDataDao

    ' gets a specific record data
    Function GetRecord(Of TBiz)(idNo As Int32) As TBiz

    ' gets a sorted list of all Documents
    Function GetAll(Of TBiz)(Optional ByVal sortExpression As String = Nothing) As List(Of TBiz)

    ' Add a recordData
    Function AddRecord(Of TBiz)(ByRef recordData As TBiz) As Integer

    ' updates a recordData
    Function UpdateRecord(Of TBiz)(ByRef recordData As TBiz) As Integer

End Interface