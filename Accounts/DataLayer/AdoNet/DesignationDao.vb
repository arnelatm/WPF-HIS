Imports AATM.DataLayer.AdoNet
Imports AATM.Accounts.BusinessLayer

Namespace DataLayer.AdoNet
    ' Data access object for Designation
    ' ** DAO Pattern

    Public Class DesignationDao
        Inherits CommonDaoOld
        Implements IDesignationDao

        Private Shared ReadOnly Db As New Db()

        Public Sub New()
            DbCommon = Db
        End Sub

        Public Function GetRecordById(idNo As Integer) As Designation Implements IDesignationDao.GetRecordById
            Dim sql As String =
                    " SELECT IDNo, DesignationCode, DesignationName, DesignationNameAra, Notes" &
                    "   FROM [Designation]" &
                    " WHERE IDNo = @IDNo"
            Dim params() As Object = {"@IDNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = "DesignationName ASC") As List(Of Designation) Implements IDesignationDao.GetAll
            Dim sql As String =
                    " SELECT IDNo, DesignationCode, DesignationName, DesignationNameAra, Notes" &
                    "   FROM [Designation] " & "order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef designation As Designation) As Integer Implements IDesignationDao.UpdateRecord
            Dim sql As String =
                    " UPDATE [Designation]" &
                    "    SET DesignationCode = @DesignationCode," &
                    "        DesignationName = @DesignationName," &
                    "        DesignationNameAra = @DesignationNameAra," &
                    "        Notes = @Notes" &
                    "  WHERE IDNo = @IDNo"

            Return Db.Update(sql, Take(designation))
        End Function

        Public Function AddRecord(ByRef designation As Designation) As Integer Implements IDesignationDao.AddRecord
            Dim sql As String =
                    " INSERT INTO [Designation] " &
                    " (DesignationCode,DesignationName,DesignationNameAra,Notes) " &
                    " VALUES (@DesignationCode,@DesignationName,@DesignationNameAra,@Notes) "
            Return Db.Insert(sql, Take(designation))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Designation) =
                                    Function(reader) _
            New Designation() With {
            .IdNo = Extensions.AsId(reader("IDNo")),
            .DesignationCode = Extensions.AsString(reader("DesignationCode")),
            .DesignationName = Extensions.AsString(reader("DesignationName")),
            .DesignationNameAra = Extensions.AsString(reader("DesignationNameAra")),
            .Notes = Extensions.AsString(reader("Notes"))
            }

        Private Function Take(designation As Designation) As Object()
            Return New Object() {
                                    "@IDNo", designation.IdNo,
                                    "@DesignationCode", designation.DesignationCode,
                                    "@DesignationName", designation.DesignationName,
                                    "@DesignationNameAra", designation.DesignationNameAra,
                                    "@Notes", designation.Notes
                                }
        End Function

    End Class

End Namespace