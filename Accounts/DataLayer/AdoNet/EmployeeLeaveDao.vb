Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for EmployeeLeave
    ' ** DAO Pattern

    Public Class EmployeeLeaveDao
        Inherits CommonDao
        Implements IDaoAll(Of EmployeeLeave), IDaoGetRecords(Of EmployeeLeave)

        Private ReadOnly Db As New Db()

        Private Const FieldList = "DateCreated," &
                                  "EmployeeIdNo," &
                                  "EndDate," &
                                  "FullDay," &
                                  "IdNo," &
                                  "LeaveIdNo," &
                                  "LeaveReason," &
                                  "LeaveStatus," &
                                  "StartDate"

        Public Function GetRecordByIdNo(idNo) As EmployeeLeave Implements IDaoAll(Of EmployeeLeave).GetRecordByIdNo
            Dim sql As String =
                    " SELECT " & FieldList &
                    "   FROM EmployeeLeave" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of EmployeeLeave) _
            Implements IDaoAll(Of EmployeeLeave).GetAll
            If sortExpression = Nothing Then
                sortExpression = " ASC"
            End If
            Dim sql As String =
                    " SELECT IdNo, EmployeeIdNo" &
                    "   FROM [EmployeeLeave] " & "order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef EmployeeLeave As EmployeeLeave) As Integer Implements IDaoAll(Of EmployeeLeave).UpdateRecord
            Dim sql As String =
                    " UPDATE [EmployeeLeave]" &
                    " SET EmployeeIdNo = @EmployeeIdNo," &
                    " EndDate = @EndDate" &
                    " FullDay = @FullDay," &
                    " LeaveIdNo = @LeaveIdNo," &
                    " LeaveReason = @LeaveReason," &
                    " LeaveStatus = @LeaveStatus," &
                    " StartDate = @StartDate," &
                    " WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(EmployeeLeave))
        End Function

        Public Function AddRecord(ByRef EmployeeLeave As EmployeeLeave) As Integer Implements IDaoAll(Of EmployeeLeave).AddRecord
            Dim sql As String =
                    " INSERT INTO [EmployeeLeave] " &
                    " (EmployeeIdNo,EndDate,FullDay,LeaveIdNo,LeaveReason,LeaveStatus,StartDate) " &
                    " VALUES (@EmployeeIdNo,@EndDate,@FullDay,@LeaveIdNo,@LeaveReason,@LeaveStatus,@StartDate)"
            Return Db.Insert(sql, Take(EmployeeLeave))
        End Function

        Public Function GetDaoRecords(Optional filter As String = Nothing) As List(Of EmployeeLeave) Implements IDaoGetRecords(Of EmployeeLeave).GetDaoRecords
            Dim sql As String = "SELECT " &
                                FieldList &
                                " FROM EmployeeLeave" &
                                IIf(filter Is Nothing, "", " WHERE " & filter)
            Return Db.Read(sql, Make).ToList()
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, EmployeeLeave) =
                                    Function(reader) _
            New EmployeeLeave() With {
            .DateCreated = Extensions.AsNullableDateTime(reader("DateCreated")),
            .EmployeeIdNo = Extensions.AsId(Of Int32)(reader("EmployeeIdNo")),
            .EndDate = Extensions.AsDateTime(reader("EndDate")),
            .FullDay = Extensions.AsBool(reader("FullDay")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .LeaveIdNo = Extensions.AsInt(Of Int16)(reader("LeaveIdNo")),
            .LeaveReason = Extensions.AsString(reader("LeaveReason")),
            .LeaveStatus = Extensions.AsChar(reader("LeaveStatus")),
            .StartDate = Extensions.AsDateTime(reader("StartDate")),
            }

        Public Sub New()

        End Sub

        Private Function Take(EmployeeLeave As EmployeeLeave) As Object()
            Return New Object() {
                                    "@IdNo", EmployeeLeave.IdNo,
                                    "@EndDate", EmployeeLeave.EndDate,
                                    "@EmployeeIdNo", EmployeeLeave.EmployeeIdNo,
                                    "@StartDate", EmployeeLeave.StartDate,
                                    "@LeaveIdNo", EmployeeLeave.LeaveIdNo,
                                    "@EndDate", EmployeeLeave.EndDate
                                }
        End Function

    End Class

End Namespace