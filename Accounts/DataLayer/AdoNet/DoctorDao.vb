Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for Doctor
    ' ** DAO Pattern

    Public Class DoctorDao
        Inherits CommonDao
        Implements IDao(Of Doctor)

        Private ReadOnly Db As New Db()

        Public Function GetRecordByIdNo(idNo) As Doctor Implements IDao(Of Doctor).GetRecordByIdNo
            Dim sql As String =
                    " SELECT a.DoctorCode, a.DoctorName, a.DoctorNameAra, a.EmployeeIdNo, a.IdNo, a.SpecialtyIdNo" &
                    "   FROM [Doctor_View] a left join Employee e on a.EmployeeIdNo = e.IdNo" &
                    " WHERE a.IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function UpdateRecord(ByRef Doctor As Doctor) As Integer Implements IDao(Of Doctor).UpdateRecord
            Dim sql As String =
                    " UPDATE [Doctor]" &
                    "    SET DoctorCode = @DoctorCode," &
                    "        EmployeeIdNo = @EmployeeIdNo," &
                    "        SpecialtyIdNo = @SpecialtyIdNo" &
                    "  WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(Doctor))
        End Function

        Public Function AddRecord(ByRef Doctor As Doctor) As Integer Implements IDao(Of Doctor).AddRecord
            Dim sql As String =
                    " INSERT INTO [Doctor] " &
                    " (DoctorCode,EmployeeIdNo,SpecialtyIdNo) " &
                    " VALUES (@DoctorCode,@EmployeeIdNo,@SpecialtyIdNo) "
            Return Db.Insert(sql, Take(Doctor))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Doctor) =
                                    Function(reader) _
            New Doctor() With {
            .DoctorCode = Extensions.AsString(reader("DoctorCode")),
            .DoctorName = Extensions.AsString(reader("DoctorName")),
            .DoctorNameAra = Extensions.AsString(reader("DoctorNameAra")),
            .EmployeeIdNo = Extensions.AsString(reader("EmployeeIdNo")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .SpecialtyIdNo = Extensions.AsInt(Of Int16)(reader("SpecialtyIdNo"))
            }

        Private Function Take(Doctor As Doctor) As Object()
            Return New Object() {
                                    "@DoctorCode", Doctor.DoctorCode,
                                    "@DoctorName", Doctor.DoctorName,
                                    "@DoctorNameAra", Doctor.DoctorNameAra,
                                    "@EmployeeIdNo", Doctor.EmployeeIdNo,
                                    "@IdNo", Doctor.IdNo,
                                    "@SpecialtyIdNo", Doctor.SpecialtyIdNo
                                }
        End Function

    End Class

End Namespace