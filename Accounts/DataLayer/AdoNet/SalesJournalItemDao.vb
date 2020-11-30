Namespace DataLayer.AdoNet

    Public Class SalesJournalItemDao
        Inherits JournalItemDao

        Public Sub New()
            _tableOrViewName = "SalesJournalItem_View"
            _dboTvpUpdateName = "dbo.UpdateSalesJournalItemTVP"
            _dboTvpInsertName = "dbo.InsertSalesJournalItemTVP"
        End Sub

    End Class

End Namespace