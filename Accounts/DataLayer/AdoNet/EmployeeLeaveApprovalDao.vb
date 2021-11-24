Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for EmployeeLeaveApproval
    ' ** DAO Pattern

    Public Class EmployeeLeaveApprovalDao
        Inherits AccountsDao
        Implements IDao(Of EmployeeLeaveApproval), IDaoGetRecords(Of EmployeeLeave)

        Private ReadOnly _db As New Db()

        Private ReadOnly _fieldList As String = "DateCreated," &
                                      "EnteredBy," &
                                      "IdNo"

        Private Shared ReadOnly Make As Func(Of IDataReader, EmployeeLeaveApproval) =
                                    Function(reader) _
            New EmployeeLeaveApproval() With {
            .DateCreated = Extensions.AsDateTime(reader("DateCreated")),
            .EnteredBy = Extensions.AsInt(Of Int32)(reader("EnteredBy")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo"))
            }

        Public Function GetRecordByIdNo(idNo As Object) As EmployeeLeaveApproval Implements IDao(Of EmployeeLeaveApproval).GetRecordByIdNo
            Dim sql As String =
                    " SELECT " & _fieldList &
                    " FROM [EmployeeLeaveApproval]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return _db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetLeaveStatus(idNo As Object) As String
            Dim sql As String =
                    " SELECT [Status] from [EmployeeLeaveApproval_view]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return _db.Scalar(sql, params)
        End Function

        Public Function AddRecord(ByRef employeeLeaveApproval As EmployeeLeaveApproval) As Integer Implements IDao(Of EmployeeLeaveApproval).AddRecord
            Dim sql As String =
                    " INSERT INTO [EmployeeLeaveApproval] " &
                    " (EnteredBy) VALUES (@EnteredBy)"
            Return _db.Insert(sql, Take(employeeLeaveApproval))
        End Function

        Public Function UpdateRecord(ByRef employeeLeaveApproval As EmployeeLeaveApproval) As Integer Implements IDao(Of EmployeeLeaveApproval).UpdateRecord
            Dim sql As String =
                    " UPDATE [EmployeeLeaveApproval] SET " &
                    " EnteredBy = @EnteredBy," &
                    " WHERE IdNo = @IdNo"
            Return _db.Update(sql, Take(employeeLeaveApproval))
        End Function

        Public Function GetDaoRecords(Optional filter As String = Nothing) As List(Of EmployeeLeave) Implements IDaoGetRecords(Of EmployeeLeave).GetDaoRecords
            Dim sql As String = "SELECT " &
                                "AppliedBy," &
                                "DateCreated," &
                                "EmployeeIdNo," &
                                "EndDate," &
                                "FullDay," &
                                "IdNo," &
                                "LeaveIdNo," &
                                "LeaveReason," &
                                "LeaveStatus," &
                                "StartDate," &
                                "SupervisorIdNo" &
                                " FROM EmployeeLeaveLatestApproval_View" &
                                IIf(filter Is Nothing, "", " WHERE " & filter)
            Return _db.Read(sql, MakeApproval).ToList()
        End Function

        Private Shared ReadOnly MakeApproval As Func(Of IDataReader, EmployeeLeave) =
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

        Private Function Take(employeeLeaveApproval As EmployeeLeaveApproval) As Object()
            Return New Object() {"@EnteredBy", employeeLeaveApproval.EnteredBy,
                                 "@IdNo", employeeLeaveApproval.IdNo
                                }
        End Function

        Public Function GetLeaveHistory(ByVal employeeLeaveIdNo As Int32) As List(Of EmployeeLeaveApprovalHistory)
            Dim sql As String = "SELECT " &
                                "ApprovalIdNo," &
                                "DateCreated," &
                                "EmployeeIdNo," &
                                "EnteredBy," &
                                "IdNo," &
                                "Note," &
                                "Status" &
                                " FROM EmployeeLeaveApproval_View" &
                                " WHERE EmployeeLeaveIdNo = " & employeeLeaveIdNo.ToString()
            Return _db.Read(sql, MakeApprovalHistory).ToList()
        End Function

        Private Shared ReadOnly MakeApprovalHistory As Func(Of IDataReader, EmployeeLeaveApprovalHistory) =
                                    Function(reader) _
            New EmployeeLeaveApprovalHistory() With {
            .DateCreated = AATM.DataLayer.AdoNet.Extensions.AsNullableDateTime(reader("DateCreated")),
            .EnteredBy = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("EnteredBy")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .Status = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Status")),
            .Note = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Note"))
            }

    End Class

End Namespace