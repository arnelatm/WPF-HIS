Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for Basic
    ' ** DAO Pattern

    Public Class BasicDao
        Inherits CommonDao
        Implements iDao(Of Basic)

        Private ReadOnly Db As New Db()
        Private ReadOnly _tableOrViewName As String

        Public Sub New(ByVal tableName As Object)
            _tableOrViewName = tableName.ToString()
        End Sub

        Public Function GetRecordByIdNo(idNo) As Basic Implements iDao(Of Basic).GetRecordByIdNo
            Dim sql As String =
                    " SELECT IdNo, " + _tableOrViewName + "Code ," + _tableOrViewName + "Name, " + _tableOrViewName + "NameAra" &
                    "   FROM " & _tableOrViewName &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function UpdateRecord(ByRef Basic As Basic) As Integer Implements iDao(Of Basic).UpdateRecord
            Dim sql As String =
                    " UPDATE " & _tableOrViewName &
                    "    SET " + _tableOrViewName + "Code = @Code," &
                    _tableOrViewName + "Name = @Name," &
                    _tableOrViewName + "NameAra = @NameAra" &
                    "  WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(Basic))
        End Function

        Public Function AddRecord(ByRef Basic As Basic) As Integer Implements iDao(Of Basic).AddRecord
            Dim sql As String =
                    " INSERT INTO " & _tableOrViewName &
                    " (" + _tableOrViewName + "Code," + _tableOrViewName + "Name," + _tableOrViewName + "NameAra) " &
                    " VALUES (@Code,@Name,@NameAra) "
            Return Db.Insert(sql, Take(Basic))
        End Function

        Private ReadOnly Make As Func(Of IDataReader, Basic) =
                                    Function(reader) _
            New Basic() With {
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .Code = Extensions.AsString(reader(_tableOrViewName + "Code")),
            .Name = Extensions.AsString(reader(_tableOrViewName + "Name")),
            .NameAra = Extensions.AsString(reader(_tableOrViewName + "NameAra"))
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