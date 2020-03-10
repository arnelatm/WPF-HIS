Public Interface IDaoWithChildNAll(Of TBiz)
    Inherits IDaoWithAll(Of TBiz)
    ' gets a specific record data
    
    Function DelUpdateTvp(ByRef tvpTable As DataTable, groupAccessIdNo As Integer) As Integer
    Function InsertTvp(ByRef tvpTable As DataTable) As Integer 
    
End Interface
