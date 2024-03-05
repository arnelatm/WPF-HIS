Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for EmployeeLeave
    ' ** DAO Pattern

    Public Class EmployeeLeaveDao
        Inherits CommonDao
        Implements IDao(Of EmployeeLeave)

        Private ReadOnly Db As New Db()

        Private Const FieldList = "EnteredBy," &
                                  "DateCreated," &
                                  "EmployeeIdNo," &
                                  "EndDate," &
                                  "FullDay," &
                                  "Holiday," &
                                  "HolidayIdNo," &
                                  "IdNo," &
                                  "LeaveIdNo," &
                                  "NoOfDays," &
                                  "Reason," &
                                  "Status," &
                                  "StartDate," &
                                  "SupervisorIdNo"

        Public Function GetRecordByIdNo(idNo) As EmployeeLeave Implements IDao(Of EmployeeLeave).GetRecordByIdNo
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

        Public Function UpdateRecord(ByRef EmployeeLeave As EmployeeLeave) As Integer Implements IDao(Of EmployeeLeave).UpdateRecord
            Dim sql As String =
                    " UPDATE [EmployeeLeave]" &
                    " SET EnteredBy = @EnteredBy," &
                    " EmployeeIdNo = @EmployeeIdNo," &
                    " EndDate = @EndDate," &
                    " FullDay = @FullDay," &
                    " HolidayIdNo = @HolidayIdNo," &
                    " LeaveIdNo = @LeaveIdNo," &
                    " NoOfDays = @NoOfDays," &
                    " Reason = @Reason," &
                    " StartDate = @StartDate" &
                    " WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(EmployeeLeave))
        End Function

        Public Function AddRecord(ByRef EmployeeLeave As EmployeeLeave) As Integer Implements IDao(Of EmployeeLeave).AddRecord
            Dim sql As String =
                    " INSERT INTO [EmployeeLeave] " &
                    " (EnteredBy,EmployeeIdNo,EndDate,FullDay,HolidayIdNo,LeaveIdNo,NoOfDays,Reason,StartDate) " &
                    " VALUES (@EnteredBy,@EmployeeIdNo,@EndDate,@FullDay,@HolidayIdNo,@LeaveIdNo,@NoOfDays,@Reason,@StartDate)"
            Return Db.Insert(sql, Take(EmployeeLeave))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, EmployeeLeave) =
                                    Function(reader) _
            New EmployeeLeave() With {
            .EnteredBy = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("EnteredBy")),
            .DateCreated = AATM.DataLayer.AdoNet.Extensions.AsNullableDateTime(reader("DateCreated")),
            .EmployeeIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("EmployeeIdNo")),
            .EndDate = AATM.DataLayer.AdoNet.Extensions.AsDate(reader("EndDate")),
            .FullDay = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("FullDay")),
            .Holiday = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Holiday")),
            .HolidayIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("HolidayIdNo")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .LeaveIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("LeaveIdNo")),
            .NoOfDays = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("NoOfDays")),
            .Reason = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Reason")),
            .Status = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Status")),
            .StartDate = AATM.DataLayer.AdoNet.Extensions.AsDate(reader("StartDate")),
            .SupervisorIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32?)(reader("SupervisorIdNo"))
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
                                    "@NoOfDays", employeeLeave.NoOfDays,
                                    "@Reason", employeeLeave.Reason,
                                    "@StartDate", employeeLeave.StartDate
                                }
        End Function

        'Public Function GetEmployeeLeaveList(Optional sortExpression As String = Nothing) As List(Of EmployeeLeave) Implements IDaoList(Of EmployeeLeave).GetList
        '    If sortExpression Is Nothing Then
        '        sortExpression = "EmployeeName ASC"
        '    End If
        '    Dim sql As String = " SELECT " & FieldList & " From EmployeeLeave Order by " & sortExpression
        '    Return Db.Read(sql, Make).ToList()
        'End Function

        'Public Function GetAllEmployeeLeaves(employeeIdNo As Int32, leaveIdNo As Int16) As List(Of EmployeeLeave) 
        '    Dim sql As String = "SELECT " & FieldList &
        '                        " FROM [EmployeeLeave_View] where EmployeeIdNo = @employeeIdNo and LeaveIdNo = @leaveIdNo "
        '    Dim params() As Object = {"@employeeIdNo", employeeIdNo, "@LeaveIdNo", leaveIdNo}
        '    Dim data = Db.Read(sql, Make, params).ToList()
        '    Return data
        'End Function

        Public Function GetEmployeeLeaveHistory(ByVal idNo As Int32) As List(Of EmployeeLeaveApprovalHistory)
            Dim sql As String = "SELECT " &
                                "ApprovedBy," &
                                "ApprovedByName," &
                                "ApprovalDate," &
                                "ApprovalNote," &
                                "EmployeeLeaveApprovalIdNo," &
                                "EmployeeLeaveIdNo," &
                                "IdNo," &
                                "Status" &
                                " From LeaveApproval_View where EmployeeLeaveIdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim data = Db.Read(sql, MakeLeaveApprovalHistory, params).ToList()
            'If data Is Nothing OrElse data.Count() = 0 Then
            '    Return Nothing
            'End If
            Return data
        End Function

        Public Function GetEmployeeHolidayLeaves(employeeIdNo As Int32, holidayIdNo As Int16)
            Dim sql As String = "SELECT EnteredBy,DateCreated,EmployeeIdNo,EndDate,FullDay,Holiday,HolidayIdNo,IdNo,LeaveIdNo,Reason,Status,StartDate,SupervisorIdNo " &
                  " FROM [EmployeeLeave_View] where EmployeeIdNo = @employeeIdNo and HolidayIdNo = @holidayIdNo and Status in (" &
                  EnumToCode(LeaveStatusSelection.SupervisorApproved) & "," &
                  EnumToCode(LeaveStatusSelection.Approved) & "," &
                  EnumToCode(LeaveStatusSelection.Submitted) & ")"
            Dim params() As Object = {"@employeeIdNo", employeeIdNo, "@HolidayIdNo", holidayIdNo}
            Dim data = Db.Read(sql, Make, params).ToList()
            Return data
        End Function

        Public Function GetEmployeeLeaves(employeeIdNo As Int32, leaveIdNo As Short, Optional filterSelection As String = "", Optional leaveYear As Short = 0) As List(Of EmployeeLeave)
            Dim sql As String
            Dim params() As Object
            sql = "SELECT " & FieldList & " FROM [EmployeeLeave_View] where EmployeeIdNo = @employeeIdNo and LeaveIdNo = @leaveIdNo"
            If filterSelection = "All" Then
                sql += " and Status in (" &
                       EnumToCode(LeaveStatusSelection.SupervisorApproved) & "," &
                       EnumToCode(LeaveStatusSelection.Approved) & "," &
                       EnumToCode(LeaveStatusSelection.Used) & "," &
                       EnumToCode(LeaveStatusSelection.Submitted) & ")"
                params = {"@employeeIdNo", employeeIdNo, "@LeaveIdNo", leaveIdNo}
                Return Db.Read(sql, Make, params).ToList()
            ElseIf filterSelection = "ActiveYear" Then
                sql += " and Status in (" &
                       EnumToCode(LeaveStatusSelection.SupervisorApproved) & "," &
                       EnumToCode(LeaveStatusSelection.Approved) & "," &
                       EnumToCode(LeaveStatusSelection.Used) & "," &
                       EnumToCode(LeaveStatusSelection.Submitted) & ")" &
                       " and Year(StartDate) = @LeaveYear "
                params = {"@employeeIdNo", employeeIdNo, "@LeaveIdNo", leaveIdNo, "@LeaveYear", leaveYear}
                Return Db.Read(sql, Make, params).ToList()
            ElseIf filterSelection = "Active" Then
                sql += " and Status in (" &
                       EnumToCode(LeaveStatusSelection.SupervisorApproved) & "," &
                       EnumToCode(LeaveStatusSelection.Approved) & "," &
                       EnumToCode(LeaveStatusSelection.Used) & "," &
                       EnumToCode(LeaveStatusSelection.Submitted) & ")"
                params = {"@employeeIdNo", employeeIdNo, "@LeaveIdNo", leaveIdNo}
                Return Db.Read(sql, Make, params).ToList()
            ElseIf filterSelection = "Pending" Then
                sql += " and Status in (" &
                       EnumToCode(LeaveStatusSelection.SupervisorApproved) & "," &
                       EnumToCode(LeaveStatusSelection.Submitted) & ")"
                params = {"@employeeIdNo", employeeIdNo, "@LeaveIdNo", leaveIdNo}
                Return Db.Read(sql, Make, params).ToList()
            End If
            Return Nothing
        End Function

        Public Function GetOverlappingLeave(employeeIdNo As Int32, beginningDate As Date, endingDate As Date) As EmployeeLeave
            Dim sql As String
            sql = "Select " & FieldList & " From [EmployeeLeave_View] " &
                  "where EmployeeIdNo = @employeeIdNo and " &
                  "(@BeginningDate <= EndDate) and (@EndingDate >= StartDate) and " &
                  "Status in (" &
                       EnumToCode(LeaveStatusSelection.SupervisorApproved) & "," &
                       EnumToCode(LeaveStatusSelection.Approved) & "," &
                       EnumToCode(LeaveStatusSelection.Used) & "," &
                       EnumToCode(LeaveStatusSelection.Submitted) & ")"
            Dim params() As Object = {"@employeeIdNo", employeeIdNo, "@BeginningDate", beginningDate, "@EndingDate", endingDate}
            Dim data = Db.Read(sql, Make, params).FirstOrDefault()
            Return data
        End Function


        Private Shared ReadOnly MakeLeaveApprovalHistory As Func(Of IDataReader, EmployeeLeaveApprovalHistory) =
                                    Function(reader) _
            New EmployeeLeaveApprovalHistory() With {
            .ApprovedBy = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32?)(reader("ApprovedBy")),
            .ApprovedByName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ApprovedByName")),
            .ApprovalDate = AATM.DataLayer.AdoNet.Extensions.AsNullableDateTime(reader("ApprovalDate")),
            .ApprovalNote = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ApprovalNote")),
            .ApprovalIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32?)(reader("EmployeeLeaveApprovalIdNo")),
            .EmployeeLeaveIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("EmployeeLeaveIdNo")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .Status = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Status"))
            }

    End Class

End Namespace