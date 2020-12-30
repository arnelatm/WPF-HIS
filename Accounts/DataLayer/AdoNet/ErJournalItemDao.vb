Namespace DataLayer.AdoNet
    ' Data access object for ApJournalItem
    ' ** DAO Pattern

    Public Class ErJournalItemDao
        Inherits JournalItemDao

        Public Sub New()
            TableOrViewName = "ErJournalItem_View"
            DboTvpUpdateName = "dbo.UpdateErJournalItemTVP"
            DboTvpInsertName = "dbo.InsertErJournalItemTVP"
        End Sub

    End Class

End Namespace