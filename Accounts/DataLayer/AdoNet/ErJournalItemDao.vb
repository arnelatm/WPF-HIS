Namespace DataLayer.AdoNet
    ' Data access object for ApJournalItem
    ' ** DAO Pattern

    Public Class ErJournalItemDao
        Inherits JournalItemDao

        Public Sub New()
            _tableOrViewName = "ErJournalItem_View"
            _dboTvpUpdateName = "dbo.UpdateErJournalItemTVP"
            _dboTvpInsertName = "dbo.InsertErJournalItemTVP"
        End Sub

    End Class

End Namespace