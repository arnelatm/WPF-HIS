Namespace DataLayer.AdoNet

    Public Class CdJournalItemDao
        Inherits JournalItemDao

        Public Sub New()
            TableFileName = "CashDisbursementJournalItem_View"
            DboTvpUpdateFileName = "dbo.UpdateCashDisbursementJournalItemTVP"
            DboTvpInsertFileName = "dbo.InsertCashDisbursementJournalItemTVP"
        End Sub

    End Class

End Namespace