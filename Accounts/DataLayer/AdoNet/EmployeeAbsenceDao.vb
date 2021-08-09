Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for EmployeeAbsence
    ' ** DAO Pattern

    Public Class EmployeeAbsenceDao
        Inherits CommonDao
        Implements IDaoAll(Of EmployeeAbsence)

        Private ReadOnly Db As New Db()
        Private FieldList As String = "AbsenceReason," &
                                      "AbsenceType," &
                                      "AddedByUser," &
                                      "DateCreated," &
                                      "EmployeeIdNo," &
                                      "EquivalentHours," &
                                      "IdNo," &
                                      "PayrollIdNo," &
                                      "UserName"

        Public Function GetRecordByIdNo(idNo) As EmployeeAbsence Implements IDaoAll(Of EmployeeAbsence).GetRecordByIdNo
            Dim sql As String =
                    " SELECT " & FieldList &
                    " FROM [EmployeeAbsence_View]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of EmployeeAbsence) _
            Implements IDaoAll(Of EmployeeAbsence).GetAll
            If sortExpression = Nothing Then
                sortExpression = "StartDate ASC"
            End If
            Dim sql As String = "SELECT IdNo, EmployeeIdNo" &
                " FROM [EmployeeAbsence] " & "order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function
        Public Function UpdateRecord(ByRef EmployeeAbsence As EmployeeAbsence) As Integer Implements IDaoAll(Of EmployeeAbsence).UpdateRecord
            Dim sql As String =
                    " UPDATE [EmployeeAbsence] SET " &
                    " AbsenceReason = @AbsenceReason," &
                    " AbsenceType = @AbsenceType," &
                    " AddedByUser = @AddedByUser," &
                    " EmployeeIdNo = @EmployeeIdNo," &
                    " EquivalentHours = @EquivalentHours," &
                    " PayrollIdNo = @PayrollIdNo" &
                    " WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(EmployeeAbsence))
        End Function
        Public Function AddRecord(ByRef EmployeeAbsence As EmployeeAbsence) As Integer Implements IDaoAll(Of EmployeeAbsence).AddRecord
            Dim sql As String = " INSERT INTO [EmployeeAbsence] " &
                    " (AbsenceReason,AbsenceType,AddedByUser,EmployeeIdNo,EquivalentHours,PayrollIdNo)" &
                    " VALUES (@AbsenceReason,@AbsenceType,@AddedByUser,@EmployeeIdNo,@EquivalentHours,@PayrollIdNo) "
            Return Db.Insert(sql, Take(EmployeeAbsence))

        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, EmployeeAbsence) =
                                    Function(reader) _
            New EmployeeAbsence() With {
            .AbsenceReason = Extensions.AsString(reader("AbsenceReason")),
            .AbsenceType = Extensions.AsChar(reader("AbsenceType")),
            .AddedByUser = Extensions.AsInt(Of Int16)(reader("AddedByUser")),
            .DateCreated = Extensions.AsDateTime(reader("DateCreated")),
            .EmployeeIdNo = Extensions.AsInt(Of Int32)(reader("EmployeeIdNo")),
            .EquivalentHours = Extensions.AsDecimal(reader("EquivalentHours")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .PayrollIdNo = Extensions.AsId(Of Int16)(reader("PayrollIdNo")),
            .UserName = Extensions.AsString(reader("UserName"))
            }

        Private Function Take(EmployeeAbsence As EmployeeAbsence) As Object()
            Return New Object() {
                            "AbsenceReason", EmployeeAbsence.AbsenceReason,
                            "AbsenceType", EmployeeAbsence.AbsenceType,
                            "AddedByUser", EmployeeAbsence.AddedByUser,
                            "DateCreated", EmployeeAbsence.DateCreated,
                            "EmployeeIdNo", EmployeeAbsence.EmployeeIdNo,
                            "EquivalentHours", EmployeeAbsence.EquivalentHours,
                            "IdNo", EmployeeAbsence.IdNo,
                            "PayrollIdNo", EmployeeAbsence.PayrollIdNo,
                            "UserName", EmployeeAbsence.UserName
                            }
        End Function

    End Class

End Namespace