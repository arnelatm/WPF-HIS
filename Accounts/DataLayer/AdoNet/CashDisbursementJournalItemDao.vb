Namespace DataLayer.AdoNet

    Public Class CashDisbursementJournalItemDao
        Inherits JournalItemDao

        Public Sub New()
            TableFileName = "CashDisbursementJournalItem_View"
            DboTvpUpdateFileName = "dbo.UpdateCashDisbursementJournalItemTVP"
            DboTvpInsertFileName = "dbo.InsertCashDisbursementJournalItemTVP"
        End Sub

    End Class

End Namespace