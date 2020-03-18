Namespace DataLayer.AdoNet

    Public Class CheckDisbursementJournalItemDao
        Inherits JournalItemDao

        Public Sub New()
            TableFileName = "ChequeDisbursementJournalItem_View"
            DboTvpUpdateFileName = "dbo.UpdateChequeDisbursementJournalItemTVP"
            DboTvpInsertFileName = "dbo.InsertChequeDisbursementJournalItemTVP"
        End Sub

    End Class

End Namespace