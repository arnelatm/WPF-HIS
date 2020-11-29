Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for EmployeeEarning
    ' ** DAO Pattern

    Public Class EmployeeEarningDao
        Inherits DaoAccounts
        Implements IDaoChild(Of EmployeeEarning)

        Private ReadOnly Db As New Db()

        Public Function GetRecordsWithIdNo(idNo, Optional sortExpression = Nothing) As List(Of EmployeeEarning) Implements IDaoChild(Of EmployeeEarning).GetRecordsWithIdNo
            If sortExpression Is Nothing Then
                sortExpression = "Sequence"
            End If
            Dim filter = "EarningType='" + GlobalFunctions.EnumToCode(EarningTypeSelection.Regular) + "'"
            Dim sql As String =
                    " SELECT " &
                    "Amount," &
                    "EarningCode," &
                    "EarningIdNo," &
                    "EarningName," &
                    "EarningNameAra," &
                    "EarningType," &
                    "EmployeeIdNo," &
                    "IdNo," &
                    "Sequence" &
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
            .Sequence = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("Sequence"))
           }

    End Class

End Namespace