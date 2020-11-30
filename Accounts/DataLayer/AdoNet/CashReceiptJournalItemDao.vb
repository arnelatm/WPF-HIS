Namespace DataLayer.AdoNet

    Public Class CashReceiptJournalItemDao
        Inherits JournalItemDao

        Public Sub New()
            _tableOrViewName = "CashReceiptJournalItem_View"
            _dboTvpUpdateName = "dbo.UpdateCashReceiptJournalItemTVP"
            _dboTvpInsertName = "dbo.InsertCashReceiptJournalItemTVP"
        End Sub

    End Class

End Namespace