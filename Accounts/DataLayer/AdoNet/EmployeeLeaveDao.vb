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
        Implements IDaoAll(Of EmployeeLeave), IDaoGetRecords(Of EmployeeLeave)

        Private ReadOnly Db As New Db()

        Private Const FieldList = "AppliedBy," &
                                  "DateCreated," &
                                  "EmployeeIdNo," &
                                  "EndDate," &
                                  "FullDay," &
                                  "IdNo," &
                                  "LeaveIdNo," &
                                  "LeaveReason," &
                                  "LeaveStatus," &
                                  "StartDate," &
                                  "SupervisorIdNo"

        Public Function GetRecordByIdNo(idNo) As EmployeeLeave Implements IDaoAll(Of EmployeeLeave).GetRecordByIdNo
            Dim sql As String =
                    " SELECT " & FieldList &
                    "   FROM EmployeeLeave_View" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim employeeLeaveStatusDao = New EmployeeLeaveApprovalDao
            Dim data = Db.Read(sql, Make, params).FirstOrDefault()
            Dim leaveStatus As String = employeeLeaveStatusDao.GetLeaveStatus(data.IdNo)
            If leaveStatus IsNot Nothing Then
                data.LeaveStatus = leaveStatus
            Else
                data.LeaveStatus = GlobalFunctions.EnumToCode(LeaveStatusSelection.Submitted)
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
                    " SET AppliedBy = @AppliedBy," &
                    " EmployeeIdNo = @EmployeeIdNo," &
                    " EndDate = @EndDate," &
                    " FullDay = @FullDay," &
                    " LeaveIdNo = @LeaveIdNo," &
                    " LeaveReason = @LeaveReason," &
                    " StartDate = @StartDate" &
                    " WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(EmployeeLeave))
        End Function

        Public Function AddRecord(ByRef EmployeeLeave As EmployeeLeave) As Integer Implements IDaoAll(Of EmployeeLeave).AddRecord
            Dim sql As String =
                    " INSERT INTO [EmployeeLeave] " &
                    " (AppliedBy,EmployeeIdNo,EndDate,FullDay,LeaveIdNo,LeaveReason,StartDate) " &
                    " VALUES (@AppliedBy,@EmployeeIdNo,@EndDate,@FullDay,@LeaveIdNo,@LeaveReason,@StartDate)"
            Return Db.Insert(sql, Take(EmployeeLeave))
        End Function

        Public Function GetDaoRecords(Optional filter As String = Nothing) As List(Of EmployeeLeave) Implements IDaoGetRecords(Of EmployeeLeave).GetDaoRecords
            Dim sql As String = "SELECT " &
                                FieldList &
                                " FROM EmployeeLeaveLatestUpdate_View" &
                                IIf(filter Is Nothing, "", " WHERE " & filter)
            Return Db.Read(sql, Make).ToList()
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, EmployeeLeave) =
                                    Function(reader) _
            New EmployeeLeave() With {
            .AppliedBy = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("AppliedBy")),
            .DateCreated = AATM.DataLayer.AdoNet.Extensions.AsNullableDateTime(reader("DateCreated")),
            .EmployeeIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("EmployeeIdNo")),
            .EndDate = AATM.DataLayer.AdoNet.Extensions.AsDateTime(reader("EndDate")),
            .FullDay = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("FullDay")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .LeaveIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("LeaveIdNo")),
            .LeaveReason = AATM.DataLayer.AdoNet.Extensions.AsString(reader("LeaveReason")),
            .LeaveStatus = AATM.DataLayer.AdoNet.Extensions.AsString(reader("LeaveStatus")),
            .StartDate = AATM.DataLayer.AdoNet.Extensions.AsDateTime(reader("StartDate")),
            .SupervisorIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("SupervisorIdNo"))
            }

        Public Sub New()

        End Sub

        Private Function Take(employeeLeave As EmployeeLeave) As Object()
            Return New Object() {
                                    "@AppliedBy", employeeLeave.AppliedBy,
                                    "@EmployeeIdNo", employeeLeave.EmployeeIdNo,
                                    "@EndDate", employeeLeave.EndDate,
                                    "@FullDay", employeeLeave.FullDay,
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

    End Class

End Namespace