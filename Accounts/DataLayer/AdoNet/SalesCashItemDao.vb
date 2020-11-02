Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for SalesCashItem
    ' ** DAO Pattern

    Public Class SalesCashItemDao
        Inherits CommonDao
        Implements IDaoChild(Of SalesCashItem)

        Private Shared ReadOnly Db As New Db()
        Protected TableFileName As String = "SalesCashItem"
        Protected DboTvpUpdateFileName As String = "dbo.UpdateSalesCashItemTVP"
        Protected DboTvpInsertFileName As String = "dbo.InsertSalesCashItemTVP"

        Public Function GetRecordsWithIdNo(idNo As Int32, Optional sortExpression As String = Nothing) _
            As List(Of SalesCashItem) Implements IDaoChild(Of SalesCashItem).GetRecordsWithIdNo
            If sortExpression Is Nothing Then
                sortExpression = "Sequence"
            End If
            Dim sql As String =
                    "SELECT " &
                    "DepositAmount," &
                    "CashCodeIdNo," &
                    "IdNo," &
                    "Rate," &
                    "SaleAmount," &
                    "SalesJournalIdNo," &
                    "Sequence" &
                    " FROM SalesCashItem_View" &
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
            Implements IDaoChild(Of SalesCashItem).DelUpdateTvp
            Return Db.DelUpdateTvp(DboTvpUpdateFileName, tvpTable, "@MParam", salesJournalIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of SalesCashItem).InsertTvp
            Return Db.InsertTvp(DboTvpInsertFileName, tvpTable, "@MParam")
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, SalesCashItem) =
                                    Function(reader) _
            New SalesCashItem() With {
            .DepositAmount = Extensions.AsDecimal(reader("DepositAmount")),
            .CashCodeIdNo = Extensions.AsInt(Of Int16)(reader("CashCodeIdNo")),
            .SaleAmount = Extensions.AsDecimal(reader("SaleAmount")),
            .SalesJournalIdNo = Extensions.AsString(reader("SalesJournalIdNo")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .Rate = Extensions.AsDecimal(reader("Rate")),
            .Sequence = Extensions.AsInt(Of Int16)(reader("sequence"))
            }

    End Class

End Namespace