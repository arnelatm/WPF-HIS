Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for EmployeeLeaveCredit
    ' ** DAO Pattern

    Public Class EmployeeLeaveCreditDao
        Inherits AccountsDao
        Implements IDaoChild(Of EmployeeLeaveCredit), IDaoGetRecordByIdNo(Of EmployeeLeaveCredit), IDaoGetRecords(Of EmployeeLeaveCredit), IDaoGetRecord(Of EmployeeLeaveCredit)

        Private ReadOnly Db As New Db()

        Private Const FieldList = "AccumulatedLeave," &
                                  "Cumulative," &
                                  "EmployeeIdNo," &
                                  "IdNo," &
                                  "LeaveAllowed," &
                                  "LeaveIdNo," &
                                  "MaxCarryOver," &
                                  "MaxLimit," &
                                  "PaidPercent," &
                                  "Sequence"

        
      Public Function GetRecordsWithGroupIdNo(idNo, Optional sortExpression = Nothing) As List(Of EmployeeLeaveCredit) Implements IDaoChild(Of EmployeeLeaveCredit).GetRecordsWithGroupIdNo
            If sortExpression Is Nothing Then
                sortExpression = "Sequence"
            End If
            Dim sql As String =
                    " SELECT " & FieldList &
                    " FROM [EmployeeLeaveCredit_View]" &
                    " WHERE EmployeeIdNo = @IdNo " & 
                    " ORDER BY " & sortExpression
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Integer) As Integer Implements IDaoChild(Of EmployeeLeaveCredit).DelUpdateTvp
            Return Db.DelUpdateTvp("UpdateEmployeeLeaveCreditTVP", tvpTable, "@MParam", groupIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of EmployeeLeaveCredit).InsertTvp
            Return Db.InsertTvp("InsertEmployeeLeaveCreditTVP", tvpTable)
        End Function

        Public Function GetRecordByIdNo(idNo As Object) As List(Of EmployeeLeaveCredit) Implements IDaoGetRecordByIdNo(Of EmployeeLeaveCredit).GetRecordByIdNo
            Dim sql As String =
                    "SELECT Top 1 " & FieldList &
                    " FROM [EmployeeLeaveCredit_View]" &
                    " WHERE IdNo = @IdNo "
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).ToList()
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, EmployeeLeaveCredit) =
                                    Function(reader) _
            New EmployeeLeaveCredit() With {
            .AccumulatedLeave = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("AccumulatedLeave")),
            .Cumulative = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Cumulative")),
            .EmployeeIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("EmployeeIdNo")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .LeaveAllowed = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("LeaveAllowed")),
            .LeaveIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("LeaveIdNo")),
            .MaxCarryOver = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("MaxCarryOver ")),
            .MaxLimit = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("MaxLimit")),
            .Sequence = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("Sequence"))
           }

        Public Function GetDaoRecords(Optional filter As String = Nothing) As List(Of EmployeeLeaveCredit) Implements IDaoGetRecords(Of EmployeeLeaveCredit).GetDaoRecords
            Dim sql As String = "SELECT " &
                                FieldList &
                                " FROM [EmployeeLeaveCredit_View]" &
                                IIf(filter Is Nothing, "", " WHERE " & filter)
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function GetDaoRecord(Optional filter As String = Nothing) As EmployeeLeaveCredit Implements IDaoGetRecord(Of EmployeeLeaveCredit).GetDaoRecord
            Dim sql As String = "SELECT " & FieldList &
                                " FROM [EmployeeLeaveCredit_View]" &
                                IIf(filter Is Nothing, "", " WHERE " & filter)
            Dim x As EmployeeLeaveCredit = Db.Read(sql, Make).FirstOrDefault()
            Return x
        End Function

    End Class

End Namespace