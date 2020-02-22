Namespace DataLayer.AdoNet

    Public Class SalesJournalItemDao
        Inherits JournalItemDao

        Public Sub New()
            TableFileName = "SalesJournalItem_View"
            DboTvpUpdateFileName = "dbo.UpdateSalesJournalItemTVP"
            DboTvpInsertFileName = "dbo.InsertSalesJournalItemTVP"
        End Sub

    End Class

End Namespace