Imports AATM.DataLayer.AdoNet
Imports log4net

Namespace DataLayer.AdoNet

    Public Class CommonDao
        Inherits BaseDao
        Implements ICommonDao

        Public Sub New()
        End Sub

        'Protected Function UpdateCode(tableName As String, codeFieldName As String, idFieldName As String, idNo As Integer, Optional branchIdNo As Int16 = 0) Implements ICommonDao.UpdateCode
        '    Dim sql1 As String
        '    Dim sql2 As String
        '    Dim retVal As Integer
        '    Dim series = tableName
        '    'Dim maxlength As Int16
        '    Dim prefix As String
        '    Dim oMaxLength
        '    If BaseDb.Scalar("Select Count(*) from Series where SeriesName = '" & series & "'") < 1 Then
        '        ' use identity key as the code
        '        Dim params() As Object = {"@code", idNo.ToString()}
        '        sql1 = "Update [" & tableName & "] set " & codeFieldName & " = '" & idNo.ToString() & "'" & " where IdNo = " & idNo
        '        retVal = BaseDb.Scalar(sql1, params)
        '    Else
        '        Dim x = BaseDb.Scalar("select prefix from series where seriesName = '" & series & "'")
        '        If IsDBNull(x) Then
        '            prefix = ""
        '        Else
        '            prefix = x
        '        End If
        '        Dim nValue = BaseDb.Scalar("Select Value from Series where SeriesName = '" & series & "'")
        '        oMaxLength = BaseDb.Scalar("Select MaxLength from Series where SeriesName = '" & series & "'")
        '        If Not IsDBNull(nValue) Then
        '            sql1 = "Update [Series] set Value = Value + 1 where SeriesName = '" & tableName & "'"
        '            sql2 = "Update [" & tableName & "] set " & codeFieldName & " = (select value from series where seriesName = '" & tableName & "') where " & idFieldName & " = " & idNo
        '            retVal = BaseDb.ExecuteSqlTransaction("UpdateCode" + tableName, sql1, sql2)
        '        Else
        '            ' use IdNo as code
        '            Dim code As String
        '            If Not IsDBNull(oMaxLength) Then
        '                code = prefix & Right(StrDup(CInt(oMaxLength), "0") & idNo.ToString().Trim(), oMaxLength)
        '            Else
        '                code = prefix & idNo.ToString().Trim()
        '            End If
        '            sql1 = "Update " & tableName & " set " & codeFieldName & " = '" & code & "' where IdNo = " & idNo
        '            retVal = GetDb().Scalar(sql1)
        '        End If
        '    End If
        '    Return retVal
        'End Function

    End Class

End Namespace