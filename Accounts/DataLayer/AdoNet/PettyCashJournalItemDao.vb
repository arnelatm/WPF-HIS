Namespace DataLayer.AdoNet

    Public Class PettyCashJournalItemDao
        Inherits JournalItemDao

        Public Sub New()
            TableFileName = "PettyCashJournalItem_View"
            DboTvpUpdateFileName = "dbo.UpdatePettyCashJournalItemTVP"
            DboTvpInsertFileName = "dbo.InsertPettyCashJournalItemTVP"
        End Sub

    End Class

End Namespace