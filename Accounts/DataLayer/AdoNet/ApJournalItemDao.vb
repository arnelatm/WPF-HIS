Namespace DataLayer.AdoNet
    ' Data access object for ApJournalItem
    ' ** DAO Pattern

    Public Class ApJournalItemDao
        Inherits JournalItemDao

        Public Sub New()
            _tableOrViewName = "ApJournalItem_View"
            _dboTvpUpdateName = "dbo.UpdateApJournalItemTVP"
            _dboTvpInsertName = "dbo.InsertApJournalItemTVP"
        End Sub

    End Class

End Namespace