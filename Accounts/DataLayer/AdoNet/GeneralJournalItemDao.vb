Namespace DataLayer.AdoNet
    ' Data access object for GeneralJournalItem
    ' ** DAO Pattern

    Public Class GeneralJournalItemDao
        Inherits JournalItemDao

        Public Sub New()
            TableOrViewName = "GeneralJournalItem_View"
            DboTvpUpdateName = "dbo.UpdateGeneralJournalItemTVP"
            DboTvpInsertName = "dbo.InsertGeneralJournalItemTVP"
        End Sub

    End Class

End Namespace