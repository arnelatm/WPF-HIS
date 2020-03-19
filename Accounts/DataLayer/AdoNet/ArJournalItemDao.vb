Namespace DataLayer.AdoNet
    ' Data access object for ApJournalItem
    ' ** DAO Pattern

    Public Class ArJournalItemDao
        Inherits JournalItemDao

        Public Sub New()
            TableFileName = "ArJournalItem_View"
            DboTvpUpdateFileName = "dbo.UpdateArJournalItemTVP"
            DboTvpInsertFileName = "dbo.InsertArJournalItemTVP"
        End Sub

    End Class

End Namespace