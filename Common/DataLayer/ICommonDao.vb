Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer

    Public Interface ICommonDao
        Inherits IBaseDao

        Function UpdateCode(tableName As String, codeFieldName As String, idFieldName As String, idNo As Integer, Optional BranchIdNo As Int16 = 0) As Object
        Function GetNextCode(tableName As String, idNo As Integer) As String
        

    End Interface

End Namespace