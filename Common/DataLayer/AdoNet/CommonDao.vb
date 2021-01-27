Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet

    Public Class CommonDao
        Inherits BaseDao
        Implements ICommonDao

        Public Sub New()
        End Sub

        Protected Function GetCode(db As Db, tableName As String, codeFieldName As String, idFieldName As String, idNo As Integer)
            Dim sql1 As String
            Dim sql2 As String
            Dim retVal As Integer
            sql1 = "Update [Series] set Value = Value + 1 where SeriesName = '" & tableName & "'"
            sql2 = "Update [" & tableName & "] set " & codeFieldName & " = (select value from series where seriesName = '" & tableName & "') where " & idFieldName & " = " & idNo
            retVal = db.ExecuteSqlTransaction("GenerateCode" + tableName, sql1, sql2)
            Return retVal
        End Function

    End Class

End Namespace