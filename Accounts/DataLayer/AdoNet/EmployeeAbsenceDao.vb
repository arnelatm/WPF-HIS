Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for EmployeeAbsence
    ' ** DAO Pattern

    Public Class EmployeeAbsenceDao
        Inherits CommonDao
        Implements IDaoAll(Of EmployeeAbsence)

        Private ReadOnly Db As New Db()
        Private FieldList As String = "AbsenceReason," &
                                      "AbsenceType," &
                                      "AddedByUser," &
                                      "DateCreated," &
                                      "EmployeeIdNo," &
                                      "EndDate," &
                                      "EquivalentHours," &
                                      "IdNo," &
                                      "PayrollIdNo," &
                                      "PayrollName," &
                                      "PayrollNameAra," &
                                      "StartDate," &
                                      "UserName"

        Public Function GetRecordByIdNo(idNo) As EmployeeAbsence Implements IDaoAll(Of EmployeeAbsence).GetRecordByIdNo
            Dim sql As String =
                    " SELECT " & FieldList &
                    " FROM [EmployeeAbsence_View]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of EmployeeAbsence) _
            Implements IDaoAll(Of EmployeeAbsence).GetAll
            If sortExpression = Nothing Then
                sortExpression = "StartDate ASC"
            End If
            Dim sql As String = "SELECT IdNo, EmployeeIdNo" &
                    " FROM [EmployeeAbsence] " & "order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef EmployeeAbsence As EmployeeAbsence) As Integer Implements IDaoAll(Of EmployeeAbsence).UpdateRecord
            Dim sql As String =
                    " UPDATE [EmployeeAbsence] SET " &
                    " AbsenceReason = @AbsenceReason," &
                    " AbsenceType = @AbsenceType," &
                    " AddedByUser = @AddedByUser," &
                    " EmployeeIdNo = @EmployeeIdNo," &
                    " EquivalentHours = @EquivalentHours," &
                    " PayrollIdNo = @PayrollIdNo" &
                    " WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(EmployeeAbsence))
        End Function

        Public Function AddRecord(ByRef EmployeeAbsence As EmployeeAbsence) As Integer Implements IDaoAll(Of EmployeeAbsence).AddRecord
            Dim sql As String =
                    " INSERT INTO [EmployeeAbsence] " &
                    " (AbsenceReason,AbsenceType,AddedByUser,EmployeeIdNo,EquivalentHours,PayrollIdNo)" &
                    " VALUES (@EmployeeAbsenceCode,@EmployeeAbsenceName,@EmployeeAbsenceNameAra,@StartDate,@EndDate,@PayCycleIdNo) "
            Return Db.Insert(sql, Take(EmployeeAbsence))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, EmployeeAbsence) =
                                    Function(reader) _
            New EmployeeAbsence() With {
            .AbsenceReason = Extensions.AsString(reader("AbsenceReason")),
            .AbsenceType = Extensions.AsChar(reader("AbsenceType")),
            .AddedByUser = Extensions.AsInt(Of Int16)(reader("AddedByUser")),
            .DateCreated = Extensions.AsDateTime(reader("DateCreated")),
            .EmployeeIdNo = Extensions.AsInt(Of Int32)(reader("EmployeeIdNo")),
            .EndDate = Extensions.AsDateTime(reader("EndDate")),
            .EquivalentHours = Extensions.AsDecimal(reader("EquivalentHours")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .PayrollIdNo = Extensions.AsId(Of Int16)(reader("PayrollIdNo")),
            .PayrollName = Extensions.AsString(reader("PayrollName")),
            .PayrollNameAra = Extensions.AsId(Of Int16)(reader("PayrollNameAra")),
            .StartDate = Extensions.AsDateTime(reader("StartDate")),
            .UserName = Extensions.AsString(reader("UserName"))
            }

        Private Function Take(EmployeeAbsence As EmployeeAbsence) As Object()
            Return New Object() {
                                 "@EndDate", EmployeeAbsence.EndDate,
                                 "@IdNo", EmployeeAbsence.IdNo,
                                 "@PayCycleIdNo", EmployeeAbsence.PayCycleIdNo,
                                 "@EmployeeAbsenceCode", EmployeeAbsence.EmployeeAbsenceCode,
                                 "@EmployeeAbsenceName", EmployeeAbsence.EmployeeAbsenceName,
                                 "@EmployeeAbsenceNameAra", EmployeeAbsence.EmployeeAbsenceNameAra,
                                 "@StartDate", EmployeeAbsence.StartDate
                                 }
        End Function

    End Class

End Namespace