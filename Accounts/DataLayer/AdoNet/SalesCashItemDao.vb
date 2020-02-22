Imports AATM.DataLayer.AdoNet
Imports AATM.Accounts.BusinessLayer

Namespace DataLayer.AdoNet
    ' Data access object for SalesCashItem
    ' ** DAO Pattern

    Public Class SalesCashItemDao
        Inherits CommonDao
        Implements ISalesCashItemDao

        Private Shared ReadOnly Db As New Db()
        Protected TableFileName As String = "SalesCashItem"
        Protected DboTvpUpdateFileName As String = "dbo.UpdateSalesCashItemTVP"
        Protected DboTvpInsertFileName As String = "dbo.InsertSalesCashItemTVP"

        Public Function GetAll(Optional sortExpression As String = "IdNo") As List(Of SalesCashItem) _
            Implements ISalesCashItemDao.GetAll
            Dim sql As String =
                    " SELECT IDNo, Amount " &
                    "   FROM [SalesCashItem] " & "order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function GetRecordById(idNo As Integer) As SalesCashItem _
                        Implements ISalesCashItemDao.GetRecordById
            Dim sql As String =
                    " SELECT " &
                    "DepositAmount," &
                    "CashCode," &
                    "IdNo," &
                    "SaleAmount," &
                    "SalesJournalIdNo," &
                    "Sequence" &
                    " FROM " & TableFileName &
                    " WHERE IDNo = @IDNo"
            Dim params() As Object = {"@IDNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetRecordsWithIdNo(idNo As Integer, Optional sortExpression As String = "Sequence") _
            As List(Of SalesCashItem)
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
            Implements ISalesCashItemDao.DelUpdateTvp
            Return Db.TvpDelUpdate(DboTvpUpdateFileName, tvpTable, "@MParam", salesJournalIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements ISalesCashItemDao.InsertTvp
            Return Db.TvpInsert(DboTvpInsertFileName, tvpTable, "@MParam")
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