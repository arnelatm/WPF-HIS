Namespace DataLayer.AdoNet

    Public Class CkJournalItemDao
        Inherits JournalItemDao

        Public Sub New()
            TableFileName = "CkJournalItem_View"
            DboTvpUpdateFileName = "dbo.UpdateCkJournalItemTVP"
            DboTvpInsertFileName = "dbo.InsertCkJournalItemTVP"
        End Sub

    End Class

End Namespace