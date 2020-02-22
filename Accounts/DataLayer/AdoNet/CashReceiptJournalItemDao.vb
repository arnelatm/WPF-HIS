Namespace DataLayer.AdoNet

    Public Class CashReceiptJournalItemDao
        Inherits JournalItemDao

        Public Sub New()
            TableFileName = "CashReceiptJournalItem_View"
            DboTvpUpdateFileName = "dbo.UpdateCashReceiptJournalItemTVP"
            DboTvpInsertFileName = "dbo.InsertCashReceiptJournalItemTVP"
        End Sub

    End Class

End Namespace