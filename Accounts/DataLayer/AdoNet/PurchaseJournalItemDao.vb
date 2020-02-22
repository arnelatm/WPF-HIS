Namespace DataLayer.AdoNet
    ' Data access object for PurchaseJournalItem
    ' ** DAO Pattern

    Public Class PurchaseJournalItemDao
        Inherits JournalItemDao

        Public Sub New()
            TableFileName = "PurchaseJournalItem_View"
            DboTvpUpdateFileName = "dbo.UpdatePurchaseJournalItemTVP"
            DboTvpInsertFileName = "dbo.InsertPurchaseJournalItemTVP"
        End Sub
 
    End Class

End Namespace