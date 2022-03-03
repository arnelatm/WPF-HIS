Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer

    Public Interface ICommonDao
        Inherits IBaseDao

        Function UpdateCode(db As Db, tableName As String, idFieldName As String, idNo As Integer)
        Function GetNextCode(tableName As String, idNo As Integer) As String

    End Interface

End Namespace