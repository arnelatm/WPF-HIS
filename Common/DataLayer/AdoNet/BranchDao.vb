Imports AATM.Common.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for Branch
    ' ** DAO Pattern

    Public Class BranchDao
        Inherits CommonDao
        Implements iDao(Of Branch)

        Private ReadOnly _db As New Db()

        Public Function GetRecordByIdNo(idNo) As Branch Implements iDao(Of Branch).GetRecordByIdNo
            Dim sql As String =
                    " SELECT IdNo, BranchCode, BranchName, BranchNameAra, Notes" &
                    "   FROM [Branch]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return _db.Read(sql, Make, params).FirstOrDefault()
        End Function


        Public Function UpdateRecord(ByRef branch As Branch) As Integer Implements iDao(Of Branch).UpdateRecord
            Dim sql As String =
                    " UPDATE [Branch]" &
                    "    SET BranchCode = @BranchCode," &
                    "        BranchName = @BranchName," &
                    "        BranchNameAra = @BranchNameAra," &
                    "        Notes = @Notes" &
                    "  WHERE IdNo = @IdNo"

            Return _db.Update(sql, Take(branch))
        End Function

        Public Function AddRecord(ByRef branch As Branch) As Integer Implements iDao(Of Branch).AddRecord
            Dim sql As String =
                    " INSERT INTO [Branch] " &
                    " (BranchCode,BranchName,BranchNameAra,Notes) " &
                    " VALUES (@BranchCode,@BranchName,@BranchNameAra,@Notes) "
            Return _db.Insert(sql, Take(branch))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Branch) =
                                    Function(reader) _
            New Branch() With {
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .BranchCode = Extensions.AsString(reader("BranchCode")),
            .BranchName = Extensions.AsString(reader("BranchName")),
            .BranchNameAra = Extensions.AsString(reader("BranchNameAra")),
            .Notes = Extensions.AsString(reader("Notes"))
            }

        Private Function Take(branch As Branch) As Object()
            Return New Object() {
                                    "@IdNo", branch.IdNo,
                                    "@BranchCode", branch.BranchCode,
                                    "@BranchName", branch.BranchName,
                                    "@BranchNameAra", branch.BranchNameAra,
                                    "@Notes", branch.Notes
                                }
        End Function

    End Class

End Namespace