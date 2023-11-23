Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for EmployeeLeaveEarnedApproval
    ' ** DAO Pattern

    Public Class EmployeeLeaveEarnedApprovalHistoryDao
        Inherits AccountsDao
        Implements IDao(Of EmployeeLeaveEarnedApprovalHistory), IDaoGetRecords(Of EmployeeLeaveEarnedApprovalHistory)

        Private ReadOnly _db As New Db()

        Private ReadOnly _fieldList As String = "DateCreated," &
                                      "EnteredBy," &
                                      "IdNo"

        Private Shared ReadOnly Make As Func(Of IDataReader, EmployeeLeaveEarnedApprovalHistory) =
                                    Function(reader) _
            New EmployeeLeaveEarnedApprovalHistory() With {
            .DateCreated = Extensions.AsDateTime(reader("DateCreated")),
            .EnteredBy = Extensions.AsInt(Of Int32)(reader("EnteredBy")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo"))
            }

        Public Function GetRecordByIdNo(idNo As Object) As EmployeeLeaveEarnedApprovalHistory Implements IDao(Of EmployeeLeaveEarnedApprovalHistory).GetRecordByIdNo
            Dim sql As String =
                    " SELECT " & _fieldList &
                    " FROM [EmployeeLeaveEarnedApproval]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return _db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetLeaveEarnedStatus(idNo As Object) As String
            Dim sql As String =
                    " SELECT [Status] from [EmployeeLeaveEarnedApproval_view]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return _db.Scalar(sql, params)
        End Function

        Public Function AddRecord(ByRef employeeLeaveEarnedApproval As EmployeeLeaveEarnedApprovalHistory) As Integer Implements IDao(Of EmployeeLeaveEarnedApprovalHistory).AddRecord
            Dim sql As String =
                    " INSERT INTO [EmployeeLeaveEarnedApproval] " &
                    " (EnteredBy) VALUES (@EnteredBy)"
            Return _db.Insert(sql, Take(employeeLeaveEarnedApproval))
        End Function

        Public Function UpdateRecord(ByRef employeeLeaveEarnedApproval As EmployeeLeaveEarnedApprovalHistory) As Integer Implements IDao(Of EmployeeLeaveEarnedApprovalHistory).UpdateRecord
            Dim sql As String =
                    " UPDATE [EmployeeLeaveEarnedApproval] SET " &
                    " EnteredBy = @EnteredBy," &
                    " WHERE IdNo = @IdNo"
            Return _db.Update(sql, Take(employeeLeaveEarnedApproval))
        End Function

        Public Function GetDaoRecords(Optional filter As String = Nothing) As List(Of EmployeeLeaveEarnedApprovalHistory) Implements IDaoGetRecords(Of EmployeeLeaveEarnedApprovalHistory).GetDaoRecords
            Dim sql As String = "SELECT " &
                                "AppliedBy," &
                                "ApprovalDate," &
                                "DateCreated," &
                                "DaysEarned," &
                                "EmployeeIdNo," &
                                "EndDate," &
                                "IdNo," &
                                "LeaveEarnedIdNo," &
                                "LeaveEarnedReason," &
                                "LeaveEarnedStatus," &
                                "StartDate," &
                                "SupervisorIdNo" &
                                " FROM EmployeeLeaveEarnedLatestApproval_View" &
                                IIf(filter Is Nothing, "", " WHERE " & filter)
            Return _db.Read(sql, MakeApprovalHistory).ToList()
        End Function

        Private Shared ReadOnly MakeApprovalHistory As Func(Of IDataReader, EmployeeLeaveEarnedApprovalHistory) =
                                    Function(reader) _
            New EmployeeLeaveEarned() With {
            .AppliedBy = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("AppliedBy")),
            .ApprovalDate = AATM.DataLayer.AdoNet.Extensions.AsNullableDateTime(reader("ApprovalDate")),
            .DaysEarned = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("DaysEarned")),
            .EmployeeIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("EmployeeIdNo")),
            .EndDate = AATM.DataLayer.AdoNet.Extensions.AsDateTime(reader("EndDate")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .LeaveEarnedIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("LeaveEarnedIdNo")),
            .Reason = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Reason")),
            .Status = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Status")),
            .StartDate = AATM.DataLayer.AdoNet.Extensions.AsDateTime(reader("StartDate")),
            .SupervisorIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("SupervisorIdNo"))
            }

        Private Function Take(employeeLeaveEarnedApproval As EmployeeLeaveEarnedApproval) As Object()
            Return New Object() {"@EnteredBy", employeeLeaveEarnedApproval.EnteredBy,
                                 "@IdNo", employeeLeaveEarnedApproval.IdNo
                                }
        End Function

        Public Function GetLeaveEarnedHistory(ByVal employeeLeaveEarnedIdNo As Int32) As List(Of EmployeeLeaveEarnedApprovalHistory)
            Dim sql As String = "SELECT " &
                                "ApprovalDate," &
                                "ApprovalNote," &
                                "EnteredBy," &
                                "IdNo," &
                                "Status" &
                                " FROM EmployeeLeaveEarnedApproval_View" &
                                " WHERE EmployeeLeaveEarnedIdNo = " & employeeLeaveEarnedIdNo.ToString()
            Return _db.Read(sql, MakeApprovalHistory).ToList()
        End Function

        Private Shared ReadOnly MakeApprovalHistory As Func(Of IDataReader, EmployeeLeaveEarnedApprovalHistory) =
                                    Function(reader) _
            New EmployeeLeaveEarnedApprovalHistory() With {
            .ApprovalDate = AATM.DataLayer.AdoNet.Extensions.AsNullableDateTime(reader("ApprovalDate")),
            .ApprovalNote = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ApprovalNote")),
            .EnteredBy = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("EnteredBy")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .Status = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Status"))
            }

    End Class

End Namespace