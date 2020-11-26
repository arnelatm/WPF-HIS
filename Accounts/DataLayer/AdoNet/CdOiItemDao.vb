Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for CkdOiItem
    ' ** DAO Pattern

    Public Class CdOiItemDao
        Inherits DjOiItemDao
        Implements IDaoChild(Of DjOiItem), IDaoOiItem(Of DjOiItem)

        Private Shared ReadOnly Db As New Db()

        Private Sub New()
            TableName = "CdOiItem_View"
            DboTvpUpdateName = "dbo.UpdateCdOiItemTVP"
            DboTvpInsertName = "dbo.InsertCdOiItemTVP"
        End Sub

        Public Function GetRecordsWithIdNo(idNo, Optional sortExpression = Nothing) _
            As List(Of DjOiItem) Implements IDaoChild(Of DjOiItem).GetRecordsWithIdNo
            Return CdGetRecordsWithIdNo(idNo)
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, djIdNo As Int32) As Integer Implements IDaoChild(Of DjOiItem).DelUpdateTvp
            Return Db.DelUpdateTvp(DboTvpUpdateName, tvpTable, "@MParam", djIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of DjOiItem).InsertTvp
            Return Db.InsertTvp(DboTvpInsertName, tvpTable, "@MParam")
        End Function

        Public Function GetOpenInvoices(idNo As Int32) As List(Of DjOiItem) Implements IDaoOiItem(Of DjOiItem).GetOpenInvoices
            Return CdGetOpenInvoices(idNo)
        End Function

    End Class

End Namespace