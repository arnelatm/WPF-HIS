Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for EmployeeDeduction
    ' ** DAO Pattern

    Public Class EmployeeDeductionDao
        Inherits AccountsDao
        Implements IDaoChild(Of EmployeeDeduction)

        Private ReadOnly _db As New Db()

        Public Function GetRecordsWithIdNo(idNo, Optional sortExpression = Nothing) As List(Of EmployeeDeduction) Implements IDaoChild(Of EmployeeDeduction).GetRecordsWithIdNo
            If sortExpression Is Nothing Then
                sortExpression = "Sequence"
            End If
            Dim filter = "DeductionType='" + GlobalFunctions.EnumToCode(DeductionTypeSelection.Regular) + "'"
            Dim sql As String =
                    " SELECT " &
                    "Amount," &
                    "DeductionCode," &
                    "DeductionIdNo," &
                    "DeductionName," &
                    "DeductionNameAra," &
                    "DeductionType," &
                    "EmployeeIdNo," &
                    "IdNo," &
                    "Sequence" &
                    " FROM [EmployeeDeduction_View]" &
                    " WHERE EmployeeIdNo = @IdNo And " & filter &
                    " ORDER BY " & sortExpression
            Dim params() As Object = {"@IdNo", idNo}
            Return _db.Read(sql, Make, params).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Integer) As Integer Implements IDaoChild(Of EmployeeDeduction).DelUpdateTvp
            Return _db.DelUpdateTvp("UpdateEmployeeDeductionTVP", tvpTable, "@MParam", groupIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of EmployeeDeduction).InsertTvp
            Return _db.InsertTvp("InsertEmployeeDeductionTVP", tvpTable)
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, EmployeeDeduction) =
                                    Function(reader) _
            New EmployeeDeduction() With {
            .Amount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Amount")),
            .DeductionCode = AATM.DataLayer.AdoNet.Extensions.AsString(reader("DeductionCode")),
            .DeductionIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int16)(reader("DeductionIdNo")),
            .DeductionName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("DeductionCode")),
            .DeductionNameAra = AATM.DataLayer.AdoNet.Extensions.AsString(reader("DeductionNameAra")),
            .DeductionType = AATM.DataLayer.AdoNet.Extensions.AsChar(reader("DeductionType")),
            .EmployeeIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("EmployeeIdNo")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .Sequence = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("Sequence"))
            }

    End Class

End Namespace