Namespace DataLayer.AdoNet
    ' Data access object for PurchaseJournalItem
    ' ** DAO Pattern

    Public Class PurchaseJournalItemDao
        Inherits JournalItemDao

        Public Sub New()
            _tableOrViewName = "PurchaseJournalItem_View"
            _dboTvpUpdateName = "dbo.UpdatePurchaseJournalItemTVP"
            _dboTvpInsertName = "dbo.InsertPurchaseJournalItemTVP"
        End Sub

    End Class

End Namespace