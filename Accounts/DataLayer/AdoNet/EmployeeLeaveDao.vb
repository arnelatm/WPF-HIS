Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for EmployeeLeave
    ' ** DAO Pattern

    Public Class EmployeeLeaveDao
        Inherits CommonDao
        Implements IDaoAll(Of EmployeeLeave)

        Private ReadOnly Db As New Db()

        Private Const FieldList = "EnteredBy," &
                                  "DateCreated," &
                                  "EmployeeIdNo," &
                                  "EndDate," &
                                  "FullDay," &
                                  "HolidayIdNo," &
                                  "IdNo," &
                                  "LeaveIdNo," &
                                  "LeaveReason," &
                                  "LeaveStatus," &
                                  "StartDate," &
                                  "SupervisorIdNo"

        Public Function GetRecordByIdNo(idNo) As EmployeeLeave Implements IDaoAll(Of EmployeeLeave).GetRecordByIdNo
            Dim sql As String = "SELECT " & FieldList &
                    " FROM EmployeeLeave_View" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim data = Db.Read(sql, Make, params).FirstOrDefault()
            If data IsNot Nothing Then
                data.ApprovalHistory = GetEmployeeLeaveHistory(idNo)
            End If
            Return data
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of EmployeeLeave) _
            Implements IDaoAll(Of EmployeeLeave).GetAll
            If sortExpression = Nothing Then
                sortExpression = " ASC"
            End If
            Dim sql As String =
                    " SELECT IdNo, EmployeeIdNo" &
                    "   FROM [EmployeeLeave_View] " & "order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef EmployeeLeave As EmployeeLeave) As Integer Implements IDaoAll(Of EmployeeLeave).UpdateRecord
            Dim sql As String =
                    " UPDATE [EmployeeLeave]" &
                    " SET EnteredBy = @EnteredBy," &
                    " EmployeeIdNo = @EmployeeIdNo," &
                    " EndDate = @EndDate," &
                    " FullDay = @FullDay," &
                    " HolidayIdNo = @HolidayIdNo," &
                    " LeaveIdNo = @LeaveIdNo," &
                    " LeaveReason = @LeaveReason," &
                    " StartDate = @StartDate" &
                    " WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(EmployeeLeave))
        End Function

        Public Function AddRecord(ByRef EmployeeLeave As EmployeeLeave) As Integer Implements IDaoAll(Of EmployeeLeave).AddRecord
            Dim sql As String =
                    " INSERT INTO [EmployeeLeave] " &
                    " (EnteredBy,EmployeeIdNo,EndDate,FullDay,HolidayIdNo,LeaveIdNo,LeaveReason,StartDate) " &
                    " VALUES (@EnteredBy,@EmployeeIdNo,@EndDate,@FullDay,@HolidayIdNo,@LeaveIdNo,@LeaveReason,@StartDate)"
            Return Db.Insert(sql, Take(EmployeeLeave))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, EmployeeLeave) =
                                    Function(reader) _
            New EmployeeLeave() With {
            .EnteredBy = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("EnteredBy")),
            .DateCreated = AATM.DataLayer.AdoNet.Extensions.AsNullableDateTime(reader("DateCreated")),
            .EmployeeIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("EmployeeIdNo")),
            .EndDate = AATM.DataLayer.AdoNet.Extensions.AsDateTime(reader("EndDate")),
            .FullDay = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("FullDay")),
            .HolidayIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("HolidayIdNo")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .LeaveIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("LeaveIdNo")),
            .LeaveReason = AATM.DataLayer.AdoNet.Extensions.AsString(reader("LeaveReason")),
            .LeaveStatus = AATM.DataLayer.AdoNet.Extensions.AsString(reader("LeaveStatus")),
            .StartDate = AATM.DataLayer.AdoNet.Extensions.AsDateTime(reader("StartDate")),
            .SupervisorIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("SupervisorIdNo"))
            }

        Private Function Take(employeeLeave As EmployeeLeave) As Object()
            Return New Object() {
                                    "@EnteredBy", employeeLeave.EnteredBy,
                                    "@EmployeeIdNo", employeeLeave.EmployeeIdNo,
                                    "@EndDate", employeeLeave.EndDate,
                                    "@FullDay", employeeLeave.FullDay,
                                    "@HolidayIdNo", employeeLeave.HolidayIdNo,
                                    "@IdNo", employeeLeave.IdNo,
                                    "@LeaveIdNo", employeeLeave.LeaveIdNo,
                                    "@LeaveReason", employeeLeave.LeaveReason,
                                    "@StartDate", employeeLeave.StartDate
                                }
        End Function

        Public Function GetEmployeeLeaveList(Optional sortExpression As String = Nothing) As List(Of EmployeeLeave)
            If sortExpression Is Nothing Then
                sortExpression = "EmployeeName ASC"
            End If
            Dim sql As String = " SELECT " & FieldList & " From EmployeeLeave Order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function GetEmployeeLeaveHistory(ByVal idNo As Int32) As List(Of EmployeeLeaveApprovalHistory)
            Dim sql As String = "SELECT " &
                                "ApprovedBy," &
                                "EmployeeLeaveApprovalIdNo," &
                                "DateCreated," &
                                "EmployeeLeaveIdNo," &
                                "IdNo," &
                                "Note," &
                                "Status" &
                                " From LeaveApproval_View where EmployeeLeaveIdNo = " & idNo.ToString()
            Return Db.Read(sql, MakeLeaveApprovalHistory).ToList()
        End Function

        Public Function GetEmployeeHolidayLeaves(employeeIdNo As Int32, holidayIdNo As Int16)
            Dim sql As String = "SELECT " & FieldList & 'IdNo, EmployeeIdNo" &
                  " FROM [EmployeeLeave_View] where EmployeeIdNo = @employeeIdNo and HolidayIdNo = @holidayIdNo and LeaveStatus in (" &
                  EnumToCode(LeaveStatusSelection.SupervisorApproved) & "," &
                  EnumToCode(LeaveStatusSelection.Approved) & "," &
                  EnumToCode(LeaveStatusSelection.Submitted) & ")"
            Dim params() As Object = {"@employeeIdNo", employeeIdNo, "@HolidayIdNo", holidayIdNo}
            Dim data = Db.Read(sql, Make, params).ToList()
            Return data
        End Function

        Public Function GetEmployeeLeaves(employeeIdNo As Int32, leaveIdNo As Int16)
            Dim sql As String = "SELECT " & FieldList &
                                " FROM [EmployeeLeave_View] where EmployeeIdNo = @employeeIdNo and LeaveIdNo = @leaveIdNo and LeaveStatus in (" &
                                EnumToCode(LeaveStatusSelection.SupervisorApproved) & "," &
                                EnumToCode(LeaveStatusSelection.Approved) & "," &
                                EnumToCode(LeaveStatusSelection.Submitted) & ")"
            Dim params() As Object = {"@employeeIdNo", employeeIdNo, "@LeaveIdNo", leaveIdNo}
            Dim data = Db.Read(sql, Make, params).ToList()
            Return data
        End Function

        Private Shared ReadOnly MakeLeaveApprovalHistory As Func(Of IDataReader, EmployeeLeaveApprovalHistory) =
                                    Function(reader) _
            New EmployeeLeaveApprovalHistory() With {
            .ApprovedBy = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("ApprovedBy")),
            .ApprovalIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("EmployeeLeaveApprovalIdNo")),
            .DateCreated = AATM.DataLayer.AdoNet.Extensions.AsNullableDateTime(reader("DateCreated")),
            .EmployeeLeaveIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("EmployeeLeaveIdNo")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .Note = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Note")),
            .Status = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Status"))
            }

    End Class

End Namespace