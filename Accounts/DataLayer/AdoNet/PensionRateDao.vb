Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for PensionRate
    ' ** DAO Pattern

    Public Class PensionRateDao
        Inherits DaoAccounts
        Implements IDaoChild(Of PensionRate)

        Private ReadOnly _db As New Db()
        Protected TableFileName As String = "PensionRate"
        Protected DboTvpUpdateFileName As String = "UpdatePensionRateTvp"
        Protected DboTvpInsertFileName As String = "InsertPensionRateTvp"

        Public Function GetRecordsWithIdNo(pensionSchemeIdNo As Int32, Optional sortKey As String = Nothing) As List(Of PensionRate) Implements IDaoChild(Of PensionRate).GetRecordsWithIdNo
            If sortKey Is Nothing Then
                sortKey = "Sequence"
            End If
            Dim sql As String =
                    "SELECT " &
                    "EmployeeShare," &
                    "EmployerShare," &
                    "HighRange," &
                    "IdNo," &
                    "LowRange," &
                    "MaxAmount," &
                    "PensionSchemeIdNo," &
                    "Sequence" &
                    " FROM " & TableFileName &
                    " WHERE PensionSchemeIdNo = @PensionSchemeIdNo" &
                    " ORDER BY " & sortKey
            Dim params() As Object = {"@PensionSchemeIdNo", pensionSchemeIdNo}
            Return _db.Read(sql, Make, params).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, pensionRateIdNo As Int32) As Integer _
            Implements IDaoChild(Of PensionRate).DelUpdateTvp
            Return _db.DelUpdateTvp(DboTvpUpdateFileName, tvpTable, "@MParam", pensionRateIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer _
            Implements IDaoChild(Of PensionRate).InsertTvp
            Return _db.InsertTvp(DboTvpInsertFileName, tvpTable, "@MParam")
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PensionRate) =
                                    Function(reader) _
            New PensionRate() With {
            .EmployeeShare = Extensions.AsDecimal(reader("EmployeeShare")),
            .EmployerShare = Extensions.AsDecimal(reader("EmployerShare")),
            .HighRange = Extensions.AsDecimal(reader("HighRange")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .LowRange = Extensions.AsDecimal(reader("LowRange")),
            .MaxAmount = Extensions.AsDecimal(reader("MaxAmount")),
            .PensionSchemeIdNo = Extensions.AsInt(Of Integer)(reader("PensionSchemeIdNo")),
            .Sequence = Extensions.AsInt(Of Int16)(reader("sequence"))
            }

    End Class

End Namespace