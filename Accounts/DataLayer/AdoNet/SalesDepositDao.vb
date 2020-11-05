Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for SalesDeposit
    ' ** DAO Pattern

    Public Class SalesDepositDao
        Inherits CommonDao
        Implements IDaoChild(Of SalesDeposit)

        Private Shared ReadOnly Db As New Db()
        Protected TableFileName As String = "SalesDeposit"
        Protected DboTvpUpdateFileName As String = "dbo.UpdateSalesDepositTVP"
        Protected DboTvpInsertFileName As String = "dbo.InsertSalesDepositTVP"

        Public Function GetRecordsWithIdNo(idNo As Int32, Optional sortExpression As String = Nothing) _
            As List(Of SalesDeposit) Implements IDaoChild(Of SalesDeposit).GetRecordsWithIdNo
            If sortExpression Is Nothing Then
                sortExpression = "Sequence"
            End If
            Dim sql As String =
                    "SELECT " &
                    "DepositAmount," &
                    "DepositTypeIdNo," &
                    "IdNo," &
                    "Rate," &
                    "SaleAmount," &
                    "SalesJournalIdNo," &
                    "Sequence" &
                    " FROM SalesDeposit_View" &
                    " WHERE SalesJournalIdNo = " & idNo &
                    " ORDER BY " & sortExpression
            Dim x = Db.Read(sql, Make).ToList()
            For Each item In x
                item.ActualBankChargeVat = Math.Round((item.SaleAmount - item.DepositAmount) / 1.05D * 0.05, 2)
                item.ActualBankCharge = item.SaleAmount - item.DepositAmount - item.ActualBankChargeVat
            Next
            Return x
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, salesJournalIdNo As Int32) As Integer _
            Implements IDaoChild(Of SalesDeposit).DelUpdateTvp
            Return Db.DelUpdateTvp(DboTvpUpdateFileName, tvpTable, "@MParam", salesJournalIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of SalesDeposit).InsertTvp
            Return Db.InsertTvp(DboTvpInsertFileName, tvpTable, "@MParam")
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, SalesDeposit) =
                                    Function(reader) _
            New SalesDeposit() With {
            .DepositAmount = Extensions.AsDecimal(reader("DepositAmount")),
            .DepositTypeIdNo = Extensions.AsInt(Of Int16)(reader("DepositTypeIdNo")),
            .SaleAmount = Extensions.AsDecimal(reader("SaleAmount")),
            .SalesJournalIdNo = Extensions.AsString(reader("SalesJournalIdNo")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .Rate = Extensions.AsDecimal(reader("Rate")),
            .Sequence = Extensions.AsInt(Of Int16)(reader("sequence"))
            }

    End Class

End Namespace