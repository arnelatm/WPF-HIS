
Imports AATM.DataLayer.AdoNet
Imports AATM.Common.BusinessLayer

Namespace DataLayer.AdoNet
    ' Data access object for Religion
    ' ** DAO Pattern

    Public Class ReligionDao
        Inherits CommonDaoOld
        Implements IReligionDao

        Private Shared ReadOnly Db As New Db()

        Public Sub New()
            DbCommon = Db
        End Sub

        Public Function GetRecordById(idNo As Integer) As Religion Implements IReligionDao.GetRecordById
            Dim sql As String =
                    " SELECT IDNo, ReligionCode, ReligionName, ReligionNameAra, Notes" &
                    "   FROM [Religion]" &
                    " WHERE IDNo = @IDNo"
            Dim params() As Object = {"@IDNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = "ReligionName") As List(Of Religion) Implements IReligionDao.GetAll
            Dim sql As String =
                    " SELECT IDNo, ReligionCode, ReligionName, ReligionNameAra, Notes" &
                    "   FROM [Religion] " & "order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef religion As Religion) As Integer Implements IReligionDao.UpdateRecord
            Dim sql As String =
                    " UPDATE [Religion]" &
                    "    SET ReligionCode = @ReligionCode," &
                    "        ReligionName = @ReligionName," &
                    "        ReligionNameAra = @ReligionNameAra," &
                    "        Notes = @Notes" &
                    "  WHERE IDNo = @IDNo"

            Return Db.Update(sql, Take(religion))
        End Function

        Public Function AddRecord(ByRef religion As Religion) As Integer Implements IReligionDao.AddRecord
            Dim sql As String =
                    " INSERT INTO [Religion] " &
                    " (ReligionCode,ReligionName,ReligionNameAra,Notes) " &
                    " VALUES (@ReligionCode,@ReligionName,@ReligionNameAra,@Notes) "
            Return Db.Insert(sql, Take(religion))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Religion) =
                                    Function(reader) _
            New Religion() With {
            .IdNo = Extensions.AsId(reader("IDNo")),
            .ReligionCode = Extensions.AsString(reader("ReligionCode")),
            .ReligionName = Extensions.AsString(reader("ReligionName")),
            .ReligionNameAra = Extensions.AsString(reader("ReligionNameAra")),
            .Notes = Extensions.AsString(reader("Notes"))
            }

        Private Function Take(religion As Religion) As Object()
            Return New Object() {
                                    "@IDNo", religion.IdNo,
                                    "@ReligionCode", religion.ReligionCode,
                                    "@ReligionName", religion.ReligionName,
                                    "@ReligionNameAra", religion.ReligionNameAra,
                                    "@Notes", religion.Notes
                                }
        End Function

    End Class

End Namespace