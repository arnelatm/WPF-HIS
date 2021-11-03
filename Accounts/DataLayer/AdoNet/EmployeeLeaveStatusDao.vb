Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for EmployeeLeaveStatus
    ' ** DAO Pattern

    Public Class EmployeeLeaveStatusDao
        Inherits AccountsDao
        Implements IDaoChild(Of EmployeeLeaveStatus)

        Private ReadOnly Db As New Db()
        Private ReadOnly FieldList As String = "DateCreated," &
                                      "EmployeeLeaveIdNo," &
                                      "EnteredBy," &
                                      "IdNo," &
                                      "Note," &
                                      "Status"

        Public Function GetRecordsWithGroupIdNo(idNo, Optional sortExpression = Nothing) As List(Of EmployeeLeaveStatus) Implements IDaoChild(Of EmployeeLeaveStatus).GetRecordsWithGroupIdNo
            Dim sql As String =
                    "SELECT " & FieldList &
                    " FROM [EmployeeLeaveStatus_View]" &
                    " WHERE LeaveIdNo = @IdNo" &
                    " ORDER BY " & sortExpression
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).ToList()
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, EmployeeLeaveStatus) =
                                    Function(reader) _
            New EmployeeLeaveStatus() With {
            .DateCreated = Extensions.AsDateTime(reader("DateCreated")),
            .EmployeeLeaveIdNo = Extensions.AsId(Of Int32)(reader("EmployeeLeaveIdNo")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .EnteredBy = Extensions.AsInt(Of Int32)(reader("EnteredBy")),
            .Notes = Extensions.AsString(reader("Note"))
           }

    End Class

End Namespace