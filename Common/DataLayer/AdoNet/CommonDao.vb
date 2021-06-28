Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet

    Public Class CommonDao
        Inherits BaseDao
        Implements ICommonDao

        Public Sub New()
        End Sub

        Protected Function UpdateCode(db As Db, tableName As String, codeFieldName As String, idFieldName As String, idNo As Integer) Implements ICommonDao.UpdateCode
            Dim sql1 As String
            Dim sql2 As String
            Dim retVal As Integer
            Dim series = tableName
            Dim maxlength As Int16
            Dim prefix As String
            If db.Scalar("Select Count(*) from Series where SeriesName = '" & series & "'") < 1 Then
                'nothing to set no data.
            Else
                Dim x = db.Scalar("select prefix from series where seriesName = '" & series & "'")
                If IsDBNull(x) Then
                    prefix = ""
                Else
                    prefix = x
                End If
                maxlength = db.Scalar("Select MaxLength from Series where SeriesName = '" & series & "'")
                Dim nValue = db.Scalar("Select Value from Series where SeriesName = '" & series & "'")
                If Not IsDBNull(nValue) Then
                    sql1 = "Update [Series] set Value = Value + 1 where SeriesName = '" & tableName & "'"
                    sql2 = "Update [" & tableName & "] set " & codeFieldName & " = (select value from series where seriesName = '" & tableName & "') where " & idFieldName & " = " & idNo
                    retVal = db.ExecuteSqlTransaction("GenerateCode" + tableName, sql1, sql2)
                Else
                    Dim code As String
                    code = prefix & Right(StrDup(maxlength, "0") & idNo.ToString().Trim(), maxlength)
                    sql1 = "Update " & tableName & " set " & codeFieldName & " = '" & code & "' where IdNo = " & idNo
                    retVal = db.Scalar(sql1)
                End If
            End If
            Return retVal
        End Function

    End Class

End Namespace