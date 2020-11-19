Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for CadOiItem
    ' ** DAO Pattern

    Public Class CdOiItemDao
        Inherits CjOiItemDao

        Public Sub New()
            TableFileName = "CdOiItem_View"
            DboTvpUpdateFileName = "dbo.UpdateCdOiItemTVP"
            DboTvpInsertFileName = "dbo.InsertCdOiItemTVP"
        End Sub

    End Class

End Namespace