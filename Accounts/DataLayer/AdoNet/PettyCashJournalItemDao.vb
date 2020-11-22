Namespace DataLayer.AdoNet

    Public Class PcJournalItemDao
        Inherits JournalItemDao

        Public Sub New()
            TableFileName = "PcJournalItem_View"
            DboTvpUpdateFileName = "dbo.UpdatePcJournalItemTVP"
            DboTvpInsertFileName = "dbo.InsertPcJournalItemTVP"
        End Sub

    End Class

End Namespace