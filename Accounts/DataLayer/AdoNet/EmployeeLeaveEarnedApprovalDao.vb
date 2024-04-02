Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for EmployeeLeaveEarnedApproval
    ' ** DAO Pattern

    Public Class EmployeeLeaveEarnedApprovalDao
        Inherits AccountsDao
        Implements IDao(Of EmployeeLeaveEarnedApproval), IDaoGetRecords(Of EmployeeLeaveEarnedApprovalItem)

        Private ReadOnly _db As New Db()

        Private ReadOnly _fieldList As String = "DateCreated," &
                                      "ApprovedBy," &
                                      "IdNo"

        Private Shared ReadOnly Make As Func(Of IDataReader, EmployeeLeaveEarnedApproval) =
                                    Function(reader) _
            New EmployeeLeaveEarnedApproval() With {
            .DateCreated = Extensions.AsDateTime(reader("DateCreated")),
            .ApprovedBy = Extensions.AsInt(Of Int32)(reader("ApprovedBy")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo"))
            }

        Public Function GetRecordByIdNo(idNo As Object) As EmployeeLeaveEarnedApproval Implements IDao(Of EmployeeLeaveEarnedApproval).GetRecordByIdNo
            Dim sql As String =
                    " SELECT " & _fieldList &
                    " FROM [EmployeeLeaveEarnedApproval]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim data = _db.Read(sql, Make, params).FirstOrDefault()
            If data IsNot Nothing Then
                Dim EmployeeLeaveEarnedApprovalItemDao = New EmployeeLeaveEarnedApprovalItemDao
                data.EmployeeLeaveEarnedApprovalItems = EmployeeLeaveEarnedApprovalItemDao.GetRecordsWithGroupIdNo(idNo, "EmployeeLeaveEarnedIdNo")
            End If
            Return data
        End Function

        Public Function GetLeaveStatus(idNo As Object) As String
            Dim sql As String =
                    " SELECT [Status] from [EmployeeLeaveEarnedApproval_view]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return _db.Scalar(sql, params)
        End Function

        Public Function AddRecord(ByRef EmployeeLeaveEarnedApproval As EmployeeLeaveEarnedApproval) As Integer Implements IDao(Of EmployeeLeaveEarnedApproval).AddRecord
            Dim sql As String =
                    " INSERT INTO [EmployeeLeaveEarnedApproval] " &
                    " (ApprovedBy) VALUES (@ApprovedBy)"
            Return _db.Insert(sql, Take(EmployeeLeaveEarnedApproval))
        End Function

        Public Function UpdateRecord(ByRef EmployeeLeaveEarnedApproval As EmployeeLeaveEarnedApproval) As Integer Implements IDao(Of EmployeeLeaveEarnedApproval).UpdateRecord
            Dim sql As String =
                    " UPDATE [EmployeeLeaveEarnedApproval] SET " &
                    " ApprovedBy = @ApprovedBy," &
                    " WHERE IdNo = @IdNo"
            Return _db.Update(sql, Take(EmployeeLeaveEarnedApproval))
        End Function

        Public Function GetDaoRecords(Optional filter As String = Nothing) As List(Of EmployeeLeaveEarnedApprovalItem) Implements IDaoGetRecords(Of EmployeeLeaveEarnedApprovalItem).GetDaoRecords
            Dim sql As String = "SELECT " &
                                "DateCreated," &
                                "DaysEarned," &
                                "EmployeeLeaveEarnedIdNo," &
                                "EmployeeIdNo," &
                                "EndDate," &
                                "EnteredBy," &
                                "IdNo," &
                                "LeaveIdNo," &
                                "Reason," &
                                "StartDate," &
                                "SupervisorIdNo" &
                                " FROM [EmployeeLeaveEarned_View]" &
                                IIf(filter Is Nothing, "", " where (" & filter & ")")
            Return _db.Read(sql, MakeApproval).ToList()
        End Function

        Private Shared ReadOnly MakeApproval As Func(Of IDataReader, EmployeeLeaveEarnedApprovalItem) =
                                    Function(reader) _
            New EmployeeLeaveEarnedApprovalItem() With {
            .DateCreated = AATM.DataLayer.AdoNet.Extensions.AsNullableDateTime(reader("DateCreated")),
            .DaysEarned = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("DaysEarned")),
            .EmployeeLeaveEarnedIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("EmployeeLeaveEarnedIdNo")),
            .EmployeeIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("EmployeeIdNo")),
            .EndDate = AATM.DataLayer.AdoNet.Extensions.AsDateTime(reader("EndDate")),
            .EnteredBy = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("EnteredBy")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .LeaveIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("LeaveIdNo")),
            .Reason = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Reason")),
            .Status = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Status")),
            .StartDate = AATM.DataLayer.AdoNet.Extensions.AsDateTime(reader("StartDate")),
            .SupervisorIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("SupervisorIdNo"))
            }

        Private Function Take(EmployeeLeaveEarnedApproval As EmployeeLeaveEarnedApproval) As Object()
            Return New Object() {"@ApprovedBy", EmployeeLeaveEarnedApproval.ApprovedBy,
                                 "@IdNo", EmployeeLeaveEarnedApproval.IdNo
                                }
        End Function

        Public Function GetLeaveEarnedHistory(ByVal EmployeeLeaveEarnedIdNo As Int32) As List(Of EmployeeLeaveEarnedApprovalHistory)
            Dim sql As String = "SELECT " &
                                "ApprovalIdNo," &
                                "ApprovalNote," &
                                "ApprovalDate," &
                                "ApprovedBy," &
                                "ApprovedByName," &
                                "IdNo," &
                                "Status" &
                                " FROM EmployeeLeaveEarnedApproval_View" &
                                " WHERE EmployeeLeaveEarnedIdNo = " & EmployeeLeaveEarnedIdNo.ToString()
            Return _db.Read(sql, MakeApprovalHistory).ToList()
        End Function

        Private Shared ReadOnly MakeApprovalHistory As Func(Of IDataReader, EmployeeLeaveEarnedApprovalHistory) =
                                    Function(reader) _
            New EmployeeLeaveEarnedApprovalHistory() With {
            .ApprovalIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32?)(reader("ApprovalIdNo")),
            .ApprovalNote = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ApprovalNote")),
            .ApprovalDate = AATM.DataLayer.AdoNet.Extensions.AsNullableDateTime(reader("ApprovalDate")),
            .ApprovedBy = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32?)(reader("ApprovedBy")),
            .ApprovedByName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ApprovedByName")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .Status = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Status"))
            }

    End Class

End Namespace