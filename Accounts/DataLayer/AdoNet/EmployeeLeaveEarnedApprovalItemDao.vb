Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for EmployeeLeaveEarnedApprovalItem
    ' ** DAO Pattern

    Public Class EmployeeLeaveEarnedApprovalItemDao
        Inherits AccountsDao
        Implements IDaoChild(Of EmployeeLeaveEarnedApprovalItem)

        Private ReadOnly Db As New Db()

        Public Function GetRecordsWithGroupIdNo(idNo, Optional sortExpression = Nothing) As List(Of EmployeeLeaveEarnedApprovalItem) Implements IDaoChild(Of EmployeeLeaveEarnedApprovalItem).GetRecordsWithGroupIdNo
            If sortExpression Is Nothing Then
                sortExpression = "Sequence"
            End If
            Dim sql As String = "SELECT " &
                    "DateCreated," &
                    "DaysEarned," &
                    "ApprovalNote," &
                    "EmployeeLeaveEarnedIdNo," &
                    "EmployeeIdNo," &
                    "EmployeeName," &
                    "EmployeeNameAra," &
                    "EndDate," &
                    "EnteredBy," &
                    "IdNo," &
                    "LeaveIdNo," &
                    "LeaveName," &
                    "LeaveNameAra," &
                    "Reason," &
                    "Status," &
                    "StartDate," &
                    "SupervisorIdNo" &
                    " FROM [EmployeeLeaveEarnedApprovalItem_View]" &
                    " WHERE EmployeeLeaveEarnedApprovalIdNo = @IdNo" &
                    " ORDER BY " & sortExpression
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Integer) As Integer Implements IDaoChild(Of EmployeeLeaveEarnedApprovalItem).DelUpdateTvp
            Return Db.DelUpdateTvp("UpdateEmployeeLeaveEarnedApprovalItemTVP", tvpTable, "@MParam", groupIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of EmployeeLeaveEarnedApprovalItem).InsertTvp
            Return Db.InsertTvp("InsertEmployeeLeaveEarnedApprovalItemTVP", tvpTable)
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, EmployeeLeaveEarnedApprovalItem) =
                                    Function(reader) _
            New EmployeeLeaveEarnedApprovalItem() With {
            .ApprovalNote = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ApprovalNote")),
            .DaysEarned = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("DaysEarned")),
            .EmployeeLeaveEarnedIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("EmployeeLeaveEarnedIdNo")),
            .EmployeeIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("EmployeeIdNo")),
            .EmployeeName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("EmployeeName")),
            .EmployeeNameAra = AATM.DataLayer.AdoNet.Extensions.AsString(reader("EmployeeNameAra")),
            .EndDate = AATM.DataLayer.AdoNet.Extensions.AsDateTime(reader("EndDate")),
            .EnteredBy = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("EnteredBy")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .LeaveIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("LeaveIdNo")),
            .LeaveName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("LeaveName")),
            .LeaveNameAra = AATM.DataLayer.AdoNet.Extensions.AsString(reader("LeaveNameAra")),
            .Reason = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Reason")),
            .Status = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Status")),
            .StartDate = AATM.DataLayer.AdoNet.Extensions.AsDateTime(reader("StartDate")),
            .SupervisorIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("SupervisorIdNo"))
           }

    End Class

End Namespace