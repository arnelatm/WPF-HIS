Namespace DataLayer.AdoNet
    ' Data access object for GeneralJournalItem
    ' ** DAO Pattern

    Public Class GeneralJournalItemDao
        Inherits JournalItemDao

        Public Sub New()
            TableFileName = "GeneralJournalItem_View"
            DboTvpUpdateFileName = "dbo.UpdateGeneralJournalItemTVP"
            DboTvpInsertFileName = "dbo.InsertGeneralJournalItemTVP"
        End Sub

    End Class

End Namespace