Namespace DataLayer.AdoNet
    ' Data access object for ApJournalItem
    ' ** DAO Pattern

    Public Class ArJournalItemDao
        Inherits JournalItemDao

        Public Sub New()
            _tableOrViewName = "ArJournalItem_View"
            _dboTvpUpdateName = "dbo.UpdateArJournalItemTVP"
            _dboTvpInsertName = "dbo.InsertArJournalItemTVP"
        End Sub

    End Class

End Namespace