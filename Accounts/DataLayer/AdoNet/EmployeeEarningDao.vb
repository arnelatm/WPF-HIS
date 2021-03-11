Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for EmployeeEarning
    ' ** DAO Pattern

    Public Class EmployeeEarningDao
        Inherits AccountsDao
        Implements IDaoChild(Of EmployeeEarning), IDaoGetRecordByIdNo(Of EmployeeEarning), IDaoGetRecords(Of EmployeeEarning), IDaoGetRecord(Of EmployeeEarning)

        Private ReadOnly Db As New Db()

        Const FieldList As String = "Amount," &
                                    "EarningCode," &
                                    "EarningIdNo," &
                                    "EarningName," &
                                    "EarningNameAra," &
                                    "EarningType," &
                                    "EmployeeIdNo," &
                                    "IdNo," &
                                    "Rate," &
                                    "Sequence," &
                                    "Unit"

        Public Function GetRecordsWithGroupIdNo(idNo, Optional sortExpression = Nothing) As List(Of EmployeeEarning) Implements IDaoChild(Of EmployeeEarning).GetRecordsWithGroupIdNo
            If sortExpression Is Nothing Then
                sortExpression = "Sequence"
            End If
            Dim filter = "EarningType='" + GlobalFunctions.EnumToCode(EarningTypeSelection.Regular) + "'"
            Dim sql As String =
                    " SELECT " & FieldList &
                    " FROM [EmployeeEarning_View]" &
                    " WHERE EmployeeIdNo = @IdNo and " & filter &
                    " ORDER BY " & sortExpression
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Integer) As Integer Implements IDaoChild(Of EmployeeEarning).DelUpdateTvp
            Return Db.DelUpdateTvp("UpdateEmployeeEarningTVP", tvpTable, "@MParam", groupIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of EmployeeEarning).InsertTvp
            Return Db.InsertTvp("InsertEmployeeEarningTVP", tvpTable)
        End Function

        Public Function GetRecordByIdNo(idNo As Object) As List(Of EmployeeEarning) Implements IDaoGetRecordByIdNo(Of EmployeeEarning).GetRecordByIdNo
            Dim sql As String =
                    " SELECT Top 1 " & FieldList &
                    " FROM [EmployeeEarning_View]" &
                    " WHERE IdNo = @IdNo "
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).ToList()
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, EmployeeEarning) =
                                    Function(reader) _
            New EmployeeEarning() With {
            .Amount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Amount")),
            .EarningCode = AATM.DataLayer.AdoNet.Extensions.AsString(reader("EarningCode")),
            .EarningIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int16)(reader("EarningIdNo")),
            .EarningName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("EarningName")),
            .EarningNameAra = AATM.DataLayer.AdoNet.Extensions.AsString(reader("EarningNameAra")),
            .EarningType = AATM.DataLayer.AdoNet.Extensions.AsChar(reader("EarningType")),
            .EmployeeIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("EmployeeIdNo")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .Rate = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Rate")),
            .Sequence = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("Sequence")),
            .Unit = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Unit"))
           }

        Public Function GetRecords(Optional filter As String = Nothing) As List(Of EmployeeEarning) Implements IDaoGetRecords(Of EmployeeEarning).GetRecords
            Dim sql As String = "SELECT " &
                                FieldList &
                                " FROM [EmployeeEarning_View]" &
                                IIf(filter Is Nothing, "", " WHERE " & filter)
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function GetRecord(Optional filter As String = Nothing) As EmployeeEarning Implements IDaoGetRecord(Of EmployeeEarning).GetRecord
            Dim sql As String = "SELECT " &
                                FieldList &
                                " FROM [EmployeeEarning_View]" &
                                IIf(filter Is Nothing, "", " WHERE " & filter)
            Dim x As EmployeeEarning = Db.Read(sql, Make).FirstOrDefault()
            Return x
        End Function

    End Class

End Namespace