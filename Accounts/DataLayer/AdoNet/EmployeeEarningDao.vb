Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for EmployeeEarning
    ' ** DAO Pattern

    Public Class EmployeeEarningDao
        Inherits DaoAccounts
        Implements IDaoChild(Of EmployeeEarning)

        Private ReadOnly Db As New Db()

        Public Function GetRecordsWithIdNo(idNo As Integer, Optional sortExpression As String = Nothing) As List(Of EmployeeEarning) Implements IDaoChild(Of EmployeeEarning).GetRecordsWithIdNo
            If sortExpression Is Nothing Then
                sortExpression = "Sequence"
            End If
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
                    " WHERE EmployeeIdNo = @IdNo" &
                    " ORDER BY " & sortExpression
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Integer) As Integer Implements IDaoChild(Of EmployeeEarning).DelUpdateTvp
            Return Db.DelUpdateTvp("UpdateEmployeeEarningTVP", tvpTable, "@MParam", groupIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of EmployeeEarning).InsertTvp
            Return Db.InsertTvp("InsertEmployeeEarningTVP", tvpTable, "@MParam")
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, EmployeeEarning) =
                                    Function(reader) _
            New EmployeeEarning() With {
            .Amount = Extensions.AsDecimal(reader("Amount")),
            .EarningCode = Extensions.AsString(reader("EarningCode")),
            .EarningIdNo = Extensions.AsId(Of Int16)(reader("EarningIdNo")),
            .EarningName = Extensions.AsString(reader("EarningCode")),
            .EarningNameAra = Extensions.AsString(reader("EarningNameAra")),
            .EarningType = Extensions.AsChar(reader("EarningType")),
            .EmployeeIdNo = Extensions.AsId(Of Int32)(reader("EmployeeIdNo")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .Sequence = Extensions.AsInt(Of Int16)(reader("Sequence"))
           }

    End Class

End Namespace