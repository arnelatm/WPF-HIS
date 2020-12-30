Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for Basic
    ' ** DAO Pattern

    Public Class BasicDao
        Inherits CommonDao
        Implements IDaoAll(Of Basic)

        Private ReadOnly Db As New Db()
        Private ReadOnly _tableOrViewName As String

        Public Sub New(ByVal tableName As String)
            _tableOrViewName = tableName
        End Sub

        Public Function GetRecordById(idNo) As Basic Implements IDaoAll(Of Basic).GetRecordById
            Dim sql As String =
                    " SELECT IdNo, Code, Name, NameAra" &
                    "   FROM " & _tableOrViewName &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of Basic) _
            Implements IDaoAll(Of Basic).GetAll
            If sortExpression = Nothing Then
                sortExpression = "Name ASC"
            End If
            Dim sql As String =
                    " SELECT IdNo, Code, Name, NameAra" &
                    "   FROM " & _tableOrViewName & " order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef Basic As Basic) As Integer Implements IDaoAll(Of Basic).UpdateRecord
            Dim sql As String =
                    " UPDATE " & _tableOrViewName &
                    "    SET Code = @Code," &
                    "        Name = @Name," &
                    "        NameAra = @NameAra" &
                    "  WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(Basic))
        End Function

        Public Function AddRecord(ByRef Basic As Basic) As Integer Implements IDaoAll(Of Basic).AddRecord
            Dim sql As String =
                    " INSERT INTO " & _tableOrViewName &
                    " (Code,Name,NameAra) " &
                    " VALUES (@Code,@Name,@NameAra) "
            Return Db.Insert(sql, Take(Basic))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Basic) =
                                    Function(reader) _
            New Basic() With {
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .Code = Extensions.AsString(reader("Code")),
            .Name = Extensions.AsString(reader("Name")),
            .NameAra = Extensions.AsString(reader("NameAra"))
            }

        Private Function Take(Basic As Basic) As Object()
            Return New Object() {
                                    "@IdNo", Basic.IdNo,
                                    "@Code", Basic.Code,
                                    "@Name", Basic.Name,
                                    "@NameAra", Basic.NameAra
                                }
        End Function

    End Class

End Namespace