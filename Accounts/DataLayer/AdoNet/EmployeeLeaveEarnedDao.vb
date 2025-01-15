Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub


Namespace DataLayer.AdoNet
    ' Data access object for EmployeeLeaveEarned
    ' ** DAO Pattern

    Public Class EmployeeLeaveEarnedDao
        Inherits CommonDao
        Implements IDao(Of EmployeeLeaveEarned)

        Private ReadOnly Db As New Db()

        Private Const FieldList = "ApprovalNote," &
                                  "Approved," &
                                  "ApprovedBy," &
                                  "DateCreated," &
                                  "DaysEarned," &
                                  "EmployeeIdNo," &
                                  "EndDate," &
                                  "EnteredBy," &
                                  "IdNo," &
                                  "LeaveIdNo," &
                                  "Reason," &
                                  "StartDate"
        Public Function GetRecordByIdNo(idNo) As EmployeeLeaveEarned Implements IDao(Of EmployeeLeaveEarned).GetRecordByIdNo
            Dim sql As String = "SELECT " & FieldList &
                    " FROM EmployeeLeaveEarned_View" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim data = Db.Read(sql, Make, params).FirstOrDefault()
            Return data
        End Function

        Public Function UpdateRecord(ByRef EmployeeLeaveEarned As EmployeeLeaveEarned) As Integer Implements IDao(Of EmployeeLeaveEarned).UpdateRecord
            Dim sql As String =
                    "UPDATE [EmployeeLeaveEarned] " &
                    "SET DaysEarned = @DaysEarned," &
                    "EmployeeIdNo = @EmployeeIdNo," &
                    "EndDate = @EndDate," &
                    "EnteredBy = @EnteredBy," &
                    "LeaveIdNo = @LeaveIdNo," &
                    "Reason = @Reason," &
                    "StartDate = @StartDate " &
                    "WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(EmployeeLeaveEarned))
        End Function

        Public Function AddRecord(ByRef EmployeeLeaveEarned As EmployeeLeaveEarned) As Integer Implements IDao(Of EmployeeLeaveEarned).AddRecord
            Dim sql As String =
                    " INSERT INTO [EmployeeLeaveEarned] " &
                    " (DaysEarned,EmployeeIdNo,EndDate,EnteredBy,LeaveIdNo,Reason,StartDate) " &
                    " VALUES (@DaysEarned,@EmployeeIdNo,@EndDate,@EnteredBy,@LeaveIdNo,@Reason,@StartDate)"
            Return Db.Insert(sql, Take(EmployeeLeaveEarned))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, EmployeeLeaveEarned) =
                                    Function(reader) _
            New EmployeeLeaveEarned() With {
            .ApprovalNote = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ApprovalNote")),
            .Approved = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Approved")),
            .ApprovedBy = AATM.DataLayer.AdoNet.Extensions.AsNullable(Of Int32?)(reader("ApprovedBy")),
            .DateCreated = AATM.DataLayer.AdoNet.Extensions.AsNullableDateTime(reader("DateCreated")),
            .DaysEarned = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("DaysEarned")),
            .EmployeeIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("EmployeeIdNo")),
            .EndDate = AATM.DataLayer.AdoNet.Extensions.AsNullableDate(reader("EndDate")),
            .EnteredBy = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("EnteredBy")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .LeaveIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("LeaveIdNo")),
            .Reason = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Reason")),
            .StartDate = AATM.DataLayer.AdoNet.Extensions.AsNullableDate(reader("StartDate"))
            }

        Private Function Take(EmployeeLeaveEarned As EmployeeLeaveEarned) As Object()
            Return New Object() {
                                    "@DaysEarned", EmployeeLeaveEarned.DaysEarned,
                                    "@EmployeeIdNo", EmployeeLeaveEarned.EmployeeIdNo,
                                    "@EndDate", EmployeeLeaveEarned.EndDate,
                                    "@EnteredBy", EmployeeLeaveEarned.EnteredBy,
                                    "@IdNo", EmployeeLeaveEarned.IdNo,
                                    "@LeaveIdNo", EmployeeLeaveEarned.LeaveIdNo,
                                    "@Reason", EmployeeLeaveEarned.Reason,
                                    "@StartDate", EmployeeLeaveEarned.StartDate
                                }
        End Function

        Public Function GetOverlappingEarnedLeave(employeeIdNo As Int32, beginningDate As Date, endingDate As Date, leaveIdNo As Int16) As EmployeeLeaveEarned
            Dim sql As String
            sql = "Select " & FieldList & " From EmployeeLeaveEarned_View " &
                  "where EmployeeIdNo = @employeeIdNo and " &
                  "(@BeginningDate <= EndDate) and (@EndingDate >= StartDate) and LeaveIdNo = @leaveIdNo"
            Dim params() As Object = {"@employeeIdNo", employeeIdNo, "@BeginningDate", beginningDate, "@EndingDate", endingDate, "@LeaveIdNo", leaveIdNo}
            Dim data = Db.Read(sql, Make, params).FirstOrDefault()
            Return data
        End Function

    End Class

End Namespace