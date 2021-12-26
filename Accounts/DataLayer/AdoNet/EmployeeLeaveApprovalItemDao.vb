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
                    "EmployeeLeaveApprovalIdNo," &
                    "EmployeeLeaveIdNo," &
                    "IdNo," &
                    "Note," &
                    "Status" &
                    " FROM [EmployeeLeaveApprovalItem]" &
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
            .EmployeeLeaveApprovalIdNo = Extensions.AsId(Of Int32)(reader("EmployeeLeaveIdNo")),
            .EmployeeLeaveIdNo = Extensions.AsId(Of Int32)(reader("EmployeeLeaveIdNo")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .Note = Extensions.AsString(reader("Note")),
            .Status = Extensions.AsString(reader("Status"))
           }

    End Class

End Namespace