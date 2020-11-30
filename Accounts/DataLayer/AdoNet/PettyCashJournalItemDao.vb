Namespace DataLayer.AdoNet

    Public Class PcJournalItemDao
        Inherits JournalItemDao

        Public Sub New()
            _tableOrViewName = "PcJournalItem_View"
            _dboTvpUpdateName = "dbo.UpdatePcJournalItemTVP"
            _dboTvpInsertName = "dbo.InsertPcJournalItemTVP"
        End Sub

    End Class

End Namespace