Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for EmployeeAbsence
    ' ** DAO Pattern

    Public Class EmployeeAbsenceDao
        Inherits CommonDao
        Implements iDao(Of EmployeeAbsence), IDaoChild(Of EmployeeAbsence)

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

        Public Function GetRecordByIdNo(idNo) As EmployeeAbsence Implements iDao(Of EmployeeAbsence).GetRecordByIdNo
            Dim sql As String =
                    " SELECT " & FieldList &
                    " FROM [EmployeeAbsence_View]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function UpdateRecord(ByRef EmployeeAbsence As EmployeeAbsence) As Integer Implements iDao(Of EmployeeAbsence).UpdateRecord
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

        Public Function AddRecord(ByRef EmployeeAbsence As EmployeeAbsence) As Integer Implements iDao(Of EmployeeAbsence).AddRecord
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

        Public Function GetRecordsWithGroupIdNo(payrollIdNo, Optional sortExpression = Nothing) As List(Of EmployeeAbsence) Implements IDaoChild(Of EmployeeAbsence).GetRecordsWithGroupIdNo
            If sortExpression Is Nothing Then
                sortExpression = "Sequence"
            End If
            Dim sql As String =
                    "SELECT " & FieldList &
                    " FROM EmployeeAbsence_View" &
                    " WHERE PayrollIdNo = @PayrollIdNo" &
                    " ORDER BY " & sortExpression.ToString()
            Dim params() As Object = {"@PayrollIdNo", payrollIdNo}
            Return Db.Read(sql, Make, params).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Integer) As Integer Implements IDaoChild(Of EmployeeAbsence).DelUpdateTvp
            Throw New NotImplementedException()
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of EmployeeAbsence).InsertTvp
            Throw New NotImplementedException()
        End Function

    End Class

End Namespace