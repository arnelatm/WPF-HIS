Namespace DataLayer.AdoNet
    ' Data access object for ApJournalItem
    ' ** DAO Pattern

    Public Class CdJournalItemDao
        Inherits JournalItemDao

        Public Sub New()
            TableOrViewName = "CdJournalItem_View"
            DboTvpUpdateName = "dbo.UpdateCdJournalItemTVP"
            DboTvpInsertName = "dbo.InsertCdJournalItemTVP"
        End Sub

    End Class

End Namespace