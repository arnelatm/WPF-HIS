Namespace DataLayer.AdoNet

    Public Class CdJournalItemDao
        Inherits JournalItemDao

        Public Sub New()
            TableFileName = "CdJournalItem_View"
            DboTvpUpdateFileName = "dbo.UpdateCdJournalItemTVP"
            DboTvpInsertFileName = "dbo.InsertCdJournalItemTVP"
        End Sub

    End Class

End Namespace