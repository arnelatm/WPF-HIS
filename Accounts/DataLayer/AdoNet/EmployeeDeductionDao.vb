Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for EmployeeDeduction
    ' ** DAO Pattern

    Public Class EmployeeDeductionDao
        Inherits DaoAccounts
        Implements IDaoChild(Of EmployeeDeduction)

        Private ReadOnly _db As New Db()

        Public Function GetRecordsWithIdNo(idNo As Integer, Optional sortExpression As String = Nothing) As List(Of EmployeeDeduction) Implements IDaoChild(Of EmployeeDeduction).GetRecordsWithIdNo
            Dim sql As String =
                    " SELECT " &
                    "AccountIdNo" &
                    "AccountIdNo," &
                    "Amount," &
                    "DefaultFrequency," &
                    "DeductionCode," &
                    "DeductionIdNo," &
                    "DeductionName," &
                    "DeductionNameAra," &
                    "DeductionType," &
                    "EmployeeIdNo," &
                    "PayFrequency," &
                    "Percentage," &
                    " FROM [EmployeeDeduction_View]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return _db.Read(sql, Make, params).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Integer) As Integer Implements IDaoChild(Of EmployeeDeduction).DelUpdateTvp
            Return _db.DelUpdateTvp("UpdateEmployeeDeductionTVP", tvpTable, "@MParam", groupIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of EmployeeDeduction).InsertTvp
            Return _db.InsertTvp("InsertEmployeeDeductionTVP", tvpTable, "@MParam")
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, EmployeeDeduction) =
                                    Function(reader) _
            New EmployeeDeduction() With {
            .Amount = Extensions.AsDecimal(reader("Amount")),
            .DeductionCode = Extensions.AsString(reader("DeductionCode")),
            .DeductionIdNo = Extensions.AsId(Of Int16)(reader("DeductionIdNo")),
            .DeductionName = Extensions.AsString(reader("DeductionCode")),
            .DeductionNameAra = Extensions.AsString(reader("DeductionNameAra")),
            .DeductionType = Extensions.AsString(reader("DeductionType")),
            .EmployeeIdNo = Extensions.AsId(Of Int32)(reader("EmployeeIdNo"))
            }

    End Class

End Namespace