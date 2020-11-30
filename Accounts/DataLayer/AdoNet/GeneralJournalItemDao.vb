Namespace DataLayer.AdoNet
    ' Data access object for GeneralJournalItem
    ' ** DAO Pattern

    Public Class GeneralJournalItemDao
        Inherits JournalItemDao

        Public Sub New()
            _tableOrViewName = "GeneralJournalItem_View"
            _dboTvpUpdateName = "dbo.UpdateGeneralJournalItemTVP"
            _dboTvpInsertName = "dbo.InsertGeneralJournalItemTVP"
        End Sub

    End Class

End Namespace