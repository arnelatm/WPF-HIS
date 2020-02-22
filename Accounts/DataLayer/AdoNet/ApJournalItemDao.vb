Namespace DataLayer.AdoNet
    ' Data access object for ApJournalItem
    ' ** DAO Pattern

    Public Class ApJournalItemDao
        Inherits JournalItemDao

        Public Sub New()
            TableFileName = "ApJournalItem_View"
            DboTvpUpdateFileName = "dbo.UpdateApJournalItemTVP"
            DboTvpInsertFileName = "dbo.InsertApJournalItemTVP"
        End Sub

    End Class

End Namespace