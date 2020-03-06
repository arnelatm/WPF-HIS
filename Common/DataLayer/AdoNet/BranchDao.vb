Imports AATM.DataLayer.AdoNet
Imports AATM.Common.BusinessLayer

Namespace DataLayer.AdoNet
    ' Data access object for Branch
    ' ** DAO Pattern

    Public Class BranchDao
        Inherits CommonDao
        Implements IBranchDao

        Private Shared ReadOnly Db As New Db()

        Public Function GetRecordById(idNo As Integer) As Branch Implements IBranchDao.GetRecordById
            Dim sql As String =
                    " SELECT IDNo, BranchCode, BranchName, BranchNameAra, Notes" &
                    "   FROM [Branch]" &
                    " WHERE IDNo = @IDNo"
            Dim params() As Object = {"@IDNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = "BranchName") As List(Of Branch) Implements IBranchDao.GetAll
            Dim sql As String =
                    " SELECT IDNo, BranchCode, BranchName, BranchNameAra, Notes" &
                    "   FROM [Branch] " & "order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef branch As Branch) As Integer Implements IBranchDao.UpdateRecord
            Dim sql As String =
                    " UPDATE [Branch]" &
                    "    SET BranchCode = @BranchCode," &
                    "        BranchName = @BranchName," &
                    "        BranchNameAra = @BranchNameAra," &
                    "        Notes = @Notes" &
                    "  WHERE IDNo = @IDNo"

            Return Db.Update(sql, Take(branch))
        End Function

        Public Function AddRecord(ByRef branch As Branch) As Integer Implements IBranchDao.AddRecord
            Dim sql As String =
                    " INSERT INTO [Branch] " &
                    " (BranchCode,BranchName,BranchNameAra,Notes) " &
                    " VALUES (@BranchCode,@BranchName,@BranchNameAra,@Notes) "
            Return Db.Insert(sql, Take(branch))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Branch) =
                                    Function(reader) _
            New Branch() With {
            .IdNo = Extensions.AsId(reader("IDNo")),
            .BranchCode = Extensions.AsString(reader("BranchCode")),
            .BranchName = Extensions.AsString(reader("BranchName")),
            .BranchNameAra = Extensions.AsString(reader("BranchNameAra")),
            .Notes = Extensions.AsString(reader("Notes"))
            }

        Private Function Take(branch As Branch) As Object()
            Return New Object() {
                                    "@IDNo", branch.IdNo,
                                    "@BranchCode", branch.BranchCode,
                                    "@BranchName", branch.BranchName,
                                    "@BranchNameAra", branch.BranchNameAra,
                                    "@Notes", branch.Notes
                                }
        End Function

    End Class

End Namespace