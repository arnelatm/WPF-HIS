Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for CadOiItem
    ' ** DAO Pattern

    Public Class CadOiItemDao
        Inherits CjOiItemDao

        Public Sub New()
            TableName = "CdOiItem_View"
            DboTvpUpdateName = "dbo.UpdateCdOiItemTVP"
            DboTvpInsertName = "dbo.InsertCdOiItemTVP"
        End Sub

    End Class

End Namespace