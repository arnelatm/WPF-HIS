Namespace DataLayer.AdoNet
    ' Data access object for ApJournalItem
    ' ** DAO Pattern

    Public Class ErJournalItemDao
        Inherits JournalItemDao

        Public Sub New()
            TableFileName = "ErJournalItem_View"
            DboTvpUpdateFileName = "dbo.UpdateErJournalItemTVP"
            DboTvpInsertFileName = "dbo.InsertErJournalItemTVP"
        End Sub

    End Class

End Namespace