Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for EmployeeLeaveApprovalItem
    ' ** DAO Pattern

    Public Class EmployeeLeaveApprovalItemDao
        Inherits AccountsDao
        Implements IDaoChild(Of EmployeeLeaveApprovalItem)

        Private ReadOnly Db As New Db()

        Public Function GetRecordsWithGroupIdNo(idNo, Optional sortExpression = Nothing) As List(Of EmployeeLeaveApprovalItem) Implements IDaoChild(Of EmployeeLeaveApprovalItem).GetRecordsWithGroupIdNo
            If sortExpression Is Nothing Then
                sortExpression = "Sequence"
            End If
            Dim sql As String = "SELECT " &
                    "ApprovalNote," &
                    "DateCreated," &
                    "EmployeeLeaveIdNo," &
                    "EmployeeIdNo," &
                    "EmployeeName," &
                    "EmployeeNameAra," &
                    "EndDate," &
                    "EnteredBy," &
                    "FullDay," &
                    "IdNo," &
                    "LeaveIdNo," &
                    "LeaveName," &
                    "LeaveNameAra," &
                    "NoOfDays," &
                    "Reason," &
                    "Status," &
                    "StartDate," &
                    "SupervisorIdNo" &
                    " FROM [EmployeeLeaveApprovalItem_View]" &
                    " WHERE EmployeeLeaveApprovalIdNo = @IdNo" &
                    " ORDER BY " & sortExpression
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Integer) As Integer Implements IDaoChild(Of EmployeeLeaveApprovalItem).DelUpdateTvp
            Return Db.DelUpdateTvp("UpdateEmployeeLeaveApprovalItemTVP", tvpTable, "@MParam", groupIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of EmployeeLeaveApprovalItem).InsertTvp
            Return Db.InsertTvp("InsertEmployeeLeaveApprovalItemTVP", tvpTable)
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, EmployeeLeaveApprovalItem) =
                                    Function(reader) _
            New EmployeeLeaveApprovalItem() With {
            .ApprovalNote = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ApprovalNote")),
            .DateCreated = AATM.DataLayer.AdoNet.Extensions.AsDateTime(reader("DateCreated")),
            .EmployeeLeaveIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("EmployeeLeaveIdNo")),
            .EmployeeIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("EmployeeIdNo")),
            .EmployeeName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("EmployeeName")),
            .EmployeeNameAra = AATM.DataLayer.AdoNet.Extensions.AsString(reader("EmployeeNameAra")),
            .EndDate = AATM.DataLayer.AdoNet.Extensions.AsDateTime(reader("EndDate")),
            .EnteredBy = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("EnteredBy")),
            .FullDay = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("FullDay")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .LeaveIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("LeaveIdNo")),
            .LeaveName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("LeaveName")),
            .LeaveNameAra = AATM.DataLayer.AdoNet.Extensions.AsString(reader("LeaveNameAra")),
            .NoOfDays = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("NoOfDays")),
            .Reason = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Reason")),
            .Status = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Status")),
            .StartDate = AATM.DataLayer.AdoNet.Extensions.AsDateTime(reader("StartDate")),
            .SupervisorIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("SupervisorIdNo"))
           }

    End Class

End Namespace