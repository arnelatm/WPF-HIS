Namespace DataLayer.AdoNet
    ' Data access object for CadOiItem
    ' ** DAO Pattern

    Public Class CdOiItemDao
        Inherits CjOiItemDao

        Public Sub New()
            TableName = "CdOiItem_View"
            DboTvpUpdateName = "dbo.UpdateCdOiItemTVP"
            DboTvpInsertName = "dbo.InsertCdOiItemTVP"
        End Sub

    End Class

End Namespace