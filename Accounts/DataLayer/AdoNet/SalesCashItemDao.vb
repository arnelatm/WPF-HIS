Imports AATM.DataLayer.AdoNet
Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer

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

        Public Function GetRecordsWithIdNo(idNo As Integer, Optional sortExpression As String = Nothing) _
            As List(Of SalesCashItem) Implements IDaoChild(Of SalesCashItem).GetRecordsWithIdNo
            If sortExpression Is Nothing Then
                sortExpression = "Sequence"
            End If
            Dim sql As String =
                    "SELECT " &
                    "DepositAmount," &
                    "CashCode," &
                    "IdNo," &
                    "SaleAmount," &
                    "SalesJournalIdNo," &
                    "Sequence" &
                    " FROM " & TableFileName &
                    " WHERE SalesJournalIdNo = " & idNo &
                    " ORDER BY " & sortExpression
            Dim x = Db.Read(sql, Make).ToList()
            Return x
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, salesJournalIdNo As Integer) As Integer _
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
            .CashCode = Extensions.AsString(reader("CashCode")),
            .SaleAmount = Extensions.AsDecimal(reader("SaleAmount")),
            .SalesJournalIdNo = Extensions.AsString(reader("SalesJournalIdNo")),
            .IdNo = Extensions.AsId(reader("IdNo")),
            .Sequence = Extensions.AsInt(Of Integer)(reader("Sequence"))
            }

    End Class

End Namespace