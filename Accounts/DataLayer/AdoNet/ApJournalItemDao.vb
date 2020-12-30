Namespace DataLayer.AdoNet
    ' Data access object for ApJournalItem
    ' ** DAO Pattern

    Public Class ApJournalItemDao
        Inherits JournalItemDao

        Public Sub New()
            TableOrViewName = "ApJournalItem_View"
            DboTvpUpdateName = "dbo.UpdateApJournalItemTVP"
            DboTvpInsertName = "dbo.InsertApJournalItemTVP"
        End Sub

    End Class

End Namespace