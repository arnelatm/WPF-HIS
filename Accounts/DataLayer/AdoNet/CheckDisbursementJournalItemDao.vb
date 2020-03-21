Namespace DataLayer.AdoNet

    Public Class CheckDisbursementJournalItemDao
        Inherits JournalItemDao

        Public Sub New()
            TableFileName = "CheckDisbursementJournalItem_View"
            DboTvpUpdateFileName = "dbo.UpdateCheckDisbursementJournalItemTVP"
            DboTvpInsertFileName = "dbo.InsertCheckDisbursementJournalItemTVP"
        End Sub

    End Class

End Namespace