Namespace DataLayer.AdoNet

    Public Class SalesJournalItemDao
        Inherits JournalItemDao

        Public Sub New()
            TableOrViewName = "SalesJournalItem_View"
            DboTvpUpdateName = "dbo.UpdateSalesJournalItemTVP"
            DboTvpInsertName = "dbo.InsertSalesJournalItemTVP"
        End Sub

    End Class

End Namespace