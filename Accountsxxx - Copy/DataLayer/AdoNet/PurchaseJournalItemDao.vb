Namespace DataLayer.AdoNet
    ' Data access object for PurchaseJournalItem
    ' ** DAO Pattern

    Public Class PurchaseJournalItemDao
        Inherits JournalItemDao

        Public Sub New()
            TableOrViewName = "PurchaseJournalItem_View"
            DboTvpUpdateName = "dbo.UpdatePurchaseJournalItemTVP"
            DboTvpInsertName = "dbo.InsertPurchaseJournalItemTVP"
        End Sub

    End Class

End Namespace