Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for EmployeeLeaveApproval
    ' ** DAO Pattern

    Public Class EmployeeLeaveApprovalDao
        Inherits AccountsDao
        Implements IDao(Of EmployeeLeaveApproval)

        Private ReadOnly _db As New Db()

        Private ReadOnly _fieldList As String = "DateCreated," &
                                      "EnteredBy," &
                                      "IdNo"

        'Public Function GetRecordsWithGroupIdNo(idNo, Optional sortExpression = Nothing) As List(Of EmployeeLeaveApproval) Implements IDao(Of EmployeeLeaveApproval).GetRecordsWithGroupIdNo
        '    Dim sql As String =
        '            "SELECT " & FieldList &
        '            " FROM [EmployeeLeaveStatus_View]" &
        '            " WHERE LeaveIdNo = @IdNo" &
        '            " ORDER BY " & sortExpression
        '    Dim params() As Object = {"@IdNo", idNo}
        '    Return Db.Read(sql, Make, params).ToList()
        'End Function

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
                    " SELECT [Status] from [EmployeeLeaveStatus_view]" &
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

        Private Function Take(employeeLeaveApproval As EmployeeLeaveApproval) As Object()
            Return New Object() {
                                    "@EnteredBy", employeeLeaveApproval.EnteredBy,
                                    "@IdNo", employeeLeaveApproval.IdNo
                                    }
        End Function

    End Class

End Namespace