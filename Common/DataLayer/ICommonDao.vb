Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer

    Public Interface ICommonDao
        Inherits IBaseDao

        Function UpdateCode(db As Db, tableName As String, codeFieldName As String, idFieldName As String, idNo As Integer)

    End Interface

End Namespace