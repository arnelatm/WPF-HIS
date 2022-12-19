Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for Designation
    ' ** DAO Pattern

    Public Class DesignationDao
        Inherits CommonDao
        Implements iDao(Of Designation), IDaoAutoCode

        Private ReadOnly Db As New Db()

        Public Function GetRecordByIdNo(idNo) As Designation Implements iDao(Of Designation).GetRecordByIdNo
            Dim sql As String =
                    " SELECT IdNo, DesignationCode, DesignationName, DesignationNameFemale, DesignationNameAra, DesignationNameFemaleAra, Notes" &
                    "   FROM [Designation]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function UpdateRecord(ByRef designation As Designation) As Integer Implements iDao(Of Designation).UpdateRecord
            Dim sql As String =
                    " UPDATE [Designation]" &
                    "    SET DesignationCode = @DesignationCode," &
                    "        DesignationName = @DesignationName," &
                    "        DesignationNameFemale = @DesignationNameFemale," &
                    "        DesignationNameAra = @DesignationNameAra," &
                    "        DesignationNameFemaleAra = @DesignationNameFemaleAra," &
                    "        Notes = @Notes" &
                    "  WHERE IdNo = @IdNo"

            Return Db.Update(sql, Take(designation))
        End Function

        Public Function AddRecord(ByRef designation As Designation) As Integer Implements iDao(Of Designation).AddRecord
            Dim sql As String =
                    " INSERT INTO [Designation] " &
                    " (DesignationCode,DesignationName,DesignationNameFemale,DesignationNameAra,DesignationNameFemaleAra,Notes) " &
                    " VALUES (@DesignationCode,@DesignationName,@DesignationNameFemale,@DesignationNameAra,@DesignationNameFemaleAra,@Notes) "
            Return Db.Insert(sql, Take(designation))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Designation) =
                                    Function(reader) _
            New Designation() With {
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .DesignationCode = Extensions.AsString(reader("DesignationCode")),
            .DesignationName = Extensions.AsString(reader("DesignationName")),
            .DesignationNameFemale = Extensions.AsString(reader("DesignationNameFemale")),
            .DesignationNameAra = Extensions.AsString(reader("DesignationNameAra")),
            .DesignationNameFemaleAra = Extensions.AsString(reader("DesignationNameFemaleAra")),
            .Notes = Extensions.AsString(reader("Notes"))
            }

        Private Function Take(designation As Designation) As Object()
            Return New Object() {
                                    "@IdNo", designation.IdNo,
                                    "@DesignationCode", designation.DesignationCode,
                                    "@DesignationName", designation.DesignationName,
                                    "@DesignationNameFemale", designation.DesignationNameFemale,
                                    "@DesignationNameAra", designation.DesignationNameAra,
                                    "@DesignationNameFemaleAra", designation.DesignationNameFemaleAra,
                                    "@Notes", designation.Notes
                                }
        End Function

        Public Function GenerateCode(idNo As Integer) As String Implements IDaoAutoCode.GenerateCode
            Return UpdateCode("Designation", "DesignationCode", "IdNo", idNo)
        End Function

    End Class

End Namespace