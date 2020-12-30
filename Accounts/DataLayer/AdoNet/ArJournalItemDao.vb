Namespace DataLayer.AdoNet
    ' Data access object for ApJournalItem
    ' ** DAO Pattern

    Public Class ArJournalItemDao
        Inherits JournalItemDao

        Public Sub New()
            TableOrViewName = "ArJournalItem_View"
            DboTvpUpdateName = "dbo.UpdateArJournalItemTVP"
            DboTvpInsertName = "dbo.InsertArJournalItemTVP"
        End Sub

    End Class

End Namespace