Public Interface IDaoWithAll(Of TBiz)
    Inherits IDao(of TBiz)
    ' gets a specific record data
    ' gets a sorted list of all Documents
    Function GetAll(Optional ByVal sortExpression As String = nothing) As List(Of TBiz)
    
End Interface
