Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for EmployeeLeaveStatus
    ' ** DAO Pattern

    Public Class EmployeeLeaveStatusDao
        Inherits AccountsDao
        Implements IDao(Of EmployeeLeaveStatus)

        Private ReadOnly _db As New Db()

        Private ReadOnly _fieldList As String = "DateCreated," &
                                      "EmployeeLeaveIdNo," &
                                      "EnteredBy," &
                                      "IdNo," &
                                      "Note," &
                                      "Status"

        'Public Function GetRecordsWithGroupIdNo(idNo, Optional sortExpression = Nothing) As List(Of EmployeeLeaveStatus) Implements IDao(Of EmployeeLeaveStatus).GetRecordsWithGroupIdNo
        '    Dim sql As String =
        '            "SELECT " & FieldList &
        '            " FROM [EmployeeLeaveStatus_View]" &
        '            " WHERE LeaveIdNo = @IdNo" &
        '            " ORDER BY " & sortExpression
        '    Dim params() As Object = {"@IdNo", idNo}
        '    Return Db.Read(sql, Make, params).ToList()
        'End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, EmployeeLeaveStatus) =
                                    Function(reader) _
            New EmployeeLeaveStatus() With {
            .DateCreated = Extensions.AsDateTime(reader("DateCreated")),
            .EmployeeLeaveIdNo = Extensions.AsId(Of Int32)(reader("EmployeeLeaveIdNo")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .EnteredBy = Extensions.AsInt(Of Int32)(reader("EnteredBy")),
            .Notes = Extensions.AsString(reader("Note"))
           }

        Public Function GetRecordByIdNo(idNo As Object) As EmployeeLeaveStatus Implements IDao(Of EmployeeLeaveStatus).GetRecordByIdNo
            Dim sql As String =
                    " SELECT " & _fieldList &
                    " FROM [EmployeeLeaveStatus]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return _db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetLeaveStatus(idNo As Object) As String
            Dim sql As String =
                    " SELECT [Status] from [EmployeeLeaveStatus_view]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return _db.Scalar(sql, params)
        End Function

        Public Function AddRecord(ByRef employeeLeaveStatus As EmployeeLeaveStatus) As Integer Implements IDao(Of EmployeeLeaveStatus).AddRecord
            Dim sql As String =
                    " INSERT INTO [Leave] " &
                    " (EmployeeLeaveIdNo,EnteredBy,Note,Status)" &
                    " VALUES (@EmployeeLeaveIdNo,@EnteredBy,@Note,@Status)"
            Return _db.Insert(sql, Take(employeeLeaveStatus))
        End Function

        Public Function UpdateRecord(ByRef employeeLeaveStatus As EmployeeLeaveStatus) As Integer Implements IDao(Of EmployeeLeaveStatus).UpdateRecord
            Dim sql As String =
                    " UPDATE [Leave] SET " &
                    " EmployeeLeaveIdNo = @EmployeeLeaveIdNo," &
                    " EnteredBy = @EnteredBy," &
                    " Note = @Note," &
                    " Status = @Status" &
                    " WHERE IdNo = @IdNo"
            Return _db.Update(sql, Take(employeeLeaveStatus))
        End Function

        Private Function Take(employeeLeaveStatus As EmployeeLeaveStatus) As Object()
            Return New Object() {
                                    "@EnteredBy", employeeLeaveStatus.EnteredBy,
                                    "@EmployeeLeaveIdNo", employeeLeaveStatus.EmployeeLeaveIdNo,
                                    "@EnteredBy", employeeLeaveStatus.EnteredBy,
                                    "@IdNo", employeeLeaveStatus.IdNo,
                                    "@Notes", employeeLeaveStatus.Notes,
                                    "@Status", employeeLeaveStatus.Status
                                }
        End Function

    End Class

End Namespace