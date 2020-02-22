Public Class CommonService
    Public Overloads Function GetRecords(ByVal tableName As String, ByVal sortKey As String, ByVal ParamArray fields() As String) As Object Implements IServiceNew.GetHRecords
        Dim data = CommonDao.GetRecords(tableName, sortKey, fields)
        Return data
    End Function

End Class