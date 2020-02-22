Namespace DataLayer.AdoNet

    Public Class ChequeDisbursementJournalItemDao
        Inherits JournalItemDao

        Public Sub New()
            TableFileName = "ChequeDisbursementJournalItem_View"
            DboTvpUpdateFileName = "dbo.UpdateChequeDisbursementJournalItemTVP"
            DboTvpInsertFileName = "dbo.InsertChequeDisbursementJournalItemTVP"
        End Sub

    End Class

End Namespace