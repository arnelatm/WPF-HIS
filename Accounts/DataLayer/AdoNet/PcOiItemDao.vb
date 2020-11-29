Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for CkdOiItem
    ' ** DAO Pattern

    Public Class PcOiItemDao
        Inherits DjOiItemDao
        Implements IDaoChild(Of DjOiItem), IDaoOiItem(Of DjOiItem)

        Private Shared ReadOnly Db As New Db()

        Public Sub New()
            TableName = "PcOiItem_View"
            DboTvpUpdateName = "dbo.UpdatePcOiItemTVP"
            DboTvpInsertName = "dbo.InsertPcOiItemTVP"
        End Sub

        Public Function GetRecordsWithIdNo(idNo, Optional sortExpression = Nothing) _
            As List(Of DjOiItem) Implements IDaoChild(Of DjOiItem).GetRecordsWithIdNo
            Return DjGetRecordsWithIdNo(idNo)
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, djIdNo As Int32) As Integer Implements IDaoChild(Of DjOiItem).DelUpdateTvp
            Return Db.DelUpdateTvp(DboTvpUpdateName, tvpTable, "@MParam", djIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of DjOiItem).InsertTvp
            Return Db.InsertTvp(DboTvpInsertName, tvpTable)
        End Function

        Public Function GetOpenInvoices(idNo As Int32) As List(Of DjOiItem) Implements IDaoOiItem(Of DjOiItem).GetOpenInvoices
            Return DjGetOpenInvoices(idNo)
        End Function

    End Class

End Namespace