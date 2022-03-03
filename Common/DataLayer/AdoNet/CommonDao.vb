Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet

    Public Class CommonDao
        Inherits BaseDao
        Implements ICommonDao

        Public Sub New()
        End Sub

        Public Function UpdateCode(db As Db, tableName As String, idFieldName As String, idNo As Integer) As Object Implements ICommonDao.UpdateCode
            Throw New NotImplementedException()
        End Function

        Protected Function UpdateCode(db As Db, tableName As String, codeFieldName As String, idFieldName As String, idNo As Integer) Implements ICommonDao.UpdateCode
            Dim sql1 As String
            Dim sql2 As String
            Dim retVal As Integer
            Dim series = tableName
            Dim maxlength As Int16
            Dim prefix As String
            
            If BaseDb.Scalar("Select Count(*) from Series where SeriesName = '" & series & "'") < 1 Then
                'nothing to set no data.
            Else
                Dim x = BaseDb.Scalar("select prefix from series where seriesName = '" & series & "'")
                If IsDBNull(x) Then
                    prefix = ""
                Else
                    prefix = x
                End If
                maxlength = BaseDb.Scalar("Select MaxLength from Series where SeriesName = '" & series & "'")
                Dim nValue = BaseDb.Scalar("Select Value from Series where SeriesName = '" & series & "'")
                If Not IsDBNull(nValue) Then
                    sql1 = "Update [Series] set Value = Value + 1 where SeriesName = '" & tableName & "'"
                    sql2 = "Update [" & tableName & "] set " & codeFieldName & " = (select value from series where seriesName = '" & tableName & "') where " & idFieldName & " = " & idNo
                    retVal = BaseDb.ExecuteSqlTransaction("GenerateCode" + tableName, sql1, sql2)
                Else
                    ' use IdNo as code
                    Dim code As String
                    code = prefix & Right(StrDup(maxlength, "0") & idNo.ToString().Trim(), maxlength)
                    sql1 = "Update " & tableName & " set " & codeFieldName & " = '" & code & "' where IdNo = " & idNo
                    retVal = db.Scalar(sql1)
                End If
            End If
            Return retVal
        End Function

        Protected Function GetNextCode(tableName As String, idNo As Integer) As String Implements ICommonDao.GetNextCode
            Dim sql1 As String
            Dim series = tableName
            Dim maxlength As Int16
            Dim prefix As String
            Dim code As String = Nothing
            If BaseDb.Scalar("Select Count(*) from Series where SeriesName = '" & series & "'") < 1 Then
                'nothing to set no data.
            Else
                Dim x = BaseDb.Scalar("select prefix from series where seriesName = '" & series & "'")
                If IsDBNull(x) Then
                    prefix = ""
                Else
                    prefix = x
                End If
                maxlength = BaseDb.Scalar("Select MaxLength from Series where SeriesName = '" & series & "'")
                Dim nValue = BaseDb.Scalar("Select Value from Series where SeriesName = '" & series & "'")
                If Not IsDBNull(nValue) Then
                    sql1 = "select value from series where seriesName = '" & tableName & "'"
                    code = BaseDb.Scalar(sql1)
                    sql1 = "Update [Series] set Value = Value + 1 where SeriesName = '" & tableName & "'"
                    BaseDb.Scalar(sql1)
                    'sql2 = "Update [" & tableName & "] set " & codeFieldName & " = (select value from series where seriesName = '" & tableName & "') where " & idFieldName & " = " & idNo
                    'retVal = BaseDb.ExecuteSqlTransaction("GenerateCode" + tableName, sql1, sql2)
                Else
                    code = prefix & Right(StrDup(maxlength, "0") & idNo.ToString().Trim(), maxlength)
                End If
            End If
            Return code
        End Function

    End Class

End Namespace