Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for EmployeeLeaveApproval
    ' ** DAO Pattern

    Public Class EmployeeLeaveApprovalDao
        Inherits AccountsDao
        Implements IDao(Of EmployeeLeaveApproval), IDaoGetRecords(Of EmployeeLeaveApprovalItem)

        Private ReadOnly _db As New Db()

        Private ReadOnly _fieldList As String = "DateCreated," &
                                      "ApprovedBy," &
                                      "IdNo"

        Private Shared ReadOnly Make As Func(Of IDataReader, EmployeeLeaveApproval) =
                                    Function(reader) _
            New EmployeeLeaveApproval() With {
            .DateCreated = Extensions.AsDateTime(reader("DateCreated")),
            .ApprovedBy = Extensions.AsInt(Of Int32)(reader("ApprovedBy")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo"))
            }

        Public Function GetRecordByIdNo(idNo As Object) As EmployeeLeaveApproval Implements IDao(Of EmployeeLeaveApproval).GetRecordByIdNo
            Dim sql As String =
                    " SELECT " & _fieldList &
                    " FROM [EmployeeLeaveApproval]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim data = _db.Read(sql, Make, params).FirstOrDefault()
            If data IsNot Nothing Then
                Dim employeeLeaveApprovalItemDao = New EmployeeLeaveApprovalItemDao
                data.EmployeeLeaveApprovalItems = employeeLeaveApprovalItemDao.GetRecordsWithGroupIdNo(idNo, "EmployeeLeaveIdNo")
            End If
            Return data
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
                    " (ApprovedBy) VALUES (@ApprovedBy)"
            Return _db.Insert(sql, Take(employeeLeaveApproval))
        End Function

        Public Function UpdateRecord(ByRef employeeLeaveApproval As EmployeeLeaveApproval) As Integer Implements IDao(Of EmployeeLeaveApproval).UpdateRecord
            Dim sql As String =
                    " UPDATE [EmployeeLeaveApproval] SET " &
                    " ApprovedBy = @ApprovedBy," &
                    " WHERE IdNo = @IdNo"
            Return _db.Update(sql, Take(employeeLeaveApproval))
        End Function

        Public Function GetDaoRecords(Optional filter As String = Nothing) As List(Of EmployeeLeaveApprovalItem) Implements IDaoGetRecords(Of EmployeeLeaveApprovalItem).GetDaoRecords
            Dim sql As String = "SELECT " &
                                "EmployeeLeaveIdNo," &
                                "EmployeeIdNo," &
                                "EndDate," &
                                "EnteredBy," &
                                "FullDay," &
                                "IdNo," &
                                "LeaveDate," &
                                "LeaveIdNo," &
                                "LeaveReason," &
                                "LeaveStatus," &
                                "StartDate," &
                                "SupervisorIdNo" &
                                " FROM [EmployeeLeave_View]" &
                                IIf(filter Is Nothing, "", " where (" & filter & ")")
            Return _db.Read(sql, MakeApproval).ToList()
        End Function

        Private Shared ReadOnly MakeApproval As Func(Of IDataReader, EmployeeLeaveApprovalItem) =
                                    Function(reader) _
            New EmployeeLeaveApprovalItem() With {
            .EmployeeLeaveIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("EmployeeLeaveIdNo")),
            .EmployeeIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("EmployeeIdNo")),
            .EndDate = AATM.DataLayer.AdoNet.Extensions.AsDateTime(reader("EndDate")),
            .EnteredBy = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("EnteredBy")),
            .FullDay = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("FullDay")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .LeaveDate = AATM.DataLayer.AdoNet.Extensions.AsNullableDateTime(reader("LeaveDate")),
            .LeaveIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("LeaveIdNo")),
            .LeaveReason = AATM.DataLayer.AdoNet.Extensions.AsString(reader("")),
            .LeaveStatus = AATM.DataLayer.AdoNet.Extensions.AsString(reader("LeaveStatus")),
            .StartDate = AATM.DataLayer.AdoNet.Extensions.AsDateTime(reader("StartDate")),
            .SupervisorIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("SupervisorIdNo"))
            }

        Private Function Take(employeeLeaveApproval As EmployeeLeaveApproval) As Object()
            Return New Object() {"@ApprovedBy", employeeLeaveApproval.ApprovedBy,
                                 "@IdNo", employeeLeaveApproval.IdNo
                                }
        End Function

        Public Function GetLeaveHistory(ByVal employeeLeaveIdNo As Int32) As List(Of EmployeeLeaveApprovalHistory)
            Dim sql As String = "SELECT " &
                                "ApprovalIdNo," &
                                "ApprovalNote," &
                                "ApprovalDate," &
                                "ApprovedBy," &
                                "ApprovedByName," &
                                "IdNo," &
                                "Status" &
                                " FROM EmployeeLeaveApproval_View" &
                                " WHERE EmployeeLeaveIdNo = " & employeeLeaveIdNo.ToString()
            Return _db.Read(sql, MakeApprovalHistory).ToList()
        End Function

        Private Shared ReadOnly MakeApprovalHistory As Func(Of IDataReader, EmployeeLeaveApprovalHistory) =
                                    Function(reader) _
            New EmployeeLeaveApprovalHistory() With {
            .ApprovalIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32?)(reader("ApprovalIdNo")),
            .ApprovalNote = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ApprovalNote")),
            .ApprovalDate = AATM.DataLayer.AdoNet.Extensions.AsNullableDateTime(reader("ApprovalDate")),
            .ApprovedBy = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32?)(reader("ApprovedBy")),
            .ApprovedByName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ApprovedByName")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .LeaveStatus = AATM.DataLayer.AdoNet.Extensions.AsString(reader("LeaveStatus"))
            }

    End Class

End Namespace