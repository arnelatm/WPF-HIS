Namespace DataLayer.AdoNet

    Public Class CashReceiptJournalItemDao
        Inherits JournalItemDao

        Public Sub New()
            TableOrViewName = "CashReceiptJournalItem_View"
            DboTvpUpdateName = "dbo.UpdateCashReceiptJournalItemTVP"
            DboTvpInsertName = "dbo.InsertCashReceiptJournalItemTVP"
        End Sub

    End Class

End Namespace