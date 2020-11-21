Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for CkdOiItem
    ' ** DAO Pattern

    Public Class PcOiItemDao
        Inherits CjOiItemDao
        Implements IDaoChild(Of CjOiItem), IDaoOiItem(Of CjOiItem)

        Private Shared ReadOnly Db As New Db()
        Protected TableFileName As String = "PcOiItem_View"
        Protected DboTvpUpdateFileName As String = "dbo.UpdatePcOiItemTVP"
        Protected DboTvpInsertFileName As String = "dbo.InsertPcOiItemTVP"

        Public Function GetRecordsWithIdNo(idNo, Optional sortExpression = Nothing) _
            As List(Of CjOiItem) Implements IDaoChild(Of CjOiItem).GetRecordsWithIdNo
            Return CdGetRecordsWithIdNo(idNo)
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, cjIdNo As Int32) As Integer Implements IDaoChild(Of CjOiItem).DelUpdateTvp
            Return Db.DelUpdateTvp(DboTvpUpdateFileName, tvpTable, "@MParam", cjIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of CjOiItem).InsertTvp
            Return Db.InsertTvp(DboTvpInsertFileName, tvpTable, "@MParam")
        End Function

        Public Function GetOpenInvoices(idNo As Int32) As List(Of CjOiItem) Implements IDaoOiItem(Of CjOiItem).GetOpenInvoices
            Return CdGetOpenInvoices(idNo)
        End Function

    End Class

End Namespace