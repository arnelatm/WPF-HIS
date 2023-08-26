Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for PurchaseOrderDetail
    ' ** DAO Pattern

    Public Class PurchaseOrderDetailDao
        Inherits AccountsDao
        Implements IDaoChild(Of PurchaseOrderDetail), IDaoGetListByIdNo(Of PurchaseOrderDetail), IDaoGetRecords(Of PurchaseOrderDetail), IDaoGetRecord(Of PurchaseOrderDetail)

        Private ReadOnly Db As New Db()

        Const FieldList As String = "BaseUnitIdNo," &
                                    "CategoryIdNo," &
                                    "IdNo," &
                                    "NetAmount," &
                                    "ProductCode," &
                                    "ProductIdNo," &
                                    "ProductName," &
                                    "ProductNameAra," &
                                    "PurchaseOrderIdNo," &
                                    "Quantity," &
                                    "Sequence," &
                                    "UnitCount," &
                                    "UnitIdNo," &
                                    "UnitCost"

        Public Function GetRecordsWithGroupIdNo(idNo, Optional sortExpression = Nothing) As List(Of PurchaseOrderDetail) Implements IDaoChild(Of PurchaseOrderDetail).GetRecordsWithGroupIdNo
            If sortExpression Is Nothing Then
                sortExpression = "Sequence"
            End If
            Dim sql As String =
                    " SELECT " & FieldList &
                    " FROM [PurchaseOrderDetail_View]" &
                    " WHERE PurchaseOrderIdNo = @IdNo  " &
                    " ORDER BY " & sortExpression
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Integer) As Integer Implements IDaoChild(Of PurchaseOrderDetail).DelUpdateTvp
            Return Db.DelUpdateTvp("UpdatePurchaseOrderDetailTVP", tvpTable, "@MParam", groupIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of PurchaseOrderDetail).InsertTvp
            Return Db.InsertTvp("InsertPurchaseOrderDetailTVP", tvpTable)
        End Function

        Public Function GetListByIdNo(idNo As Object) As List(Of PurchaseOrderDetail) Implements IDaoGetListByIdNo(Of PurchaseOrderDetail).GetListByIdNo
            Dim sql As String =
                    "SELECT Top 1 " & FieldList &
                    " FROM [PurchaseOrderDetail_View]" &
                    " WHERE IdNo = @IdNo "
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).ToList()
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PurchaseOrderDetail) =
                                    Function(reader) _
            New PurchaseOrderDetail() With {
            .BaseUnitIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("BaseUnitIdNo")),
            .CategoryIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("CategoryIdNo")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .NetAmount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("NetAmount")),
            .ProductCode = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ProductCode")),
            .ProductIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int16)(reader("ProductIdNo")),
            .ProductName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ProductName")),
            .ProductNameAra = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ProductNameAra")),
            .PurchaseOrderIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("PurchaseOrderIdNo")),
            .Quantity = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("Quantity")),
            .Sequence = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("Sequence")),
            .UnitCount = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("UnitIdNo")),
            .UnitIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("UnitIdNo")),
            .UnitCost = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("UnitCost"))
        }

        Public Function GetDaoRecords(Optional filter As String = Nothing) As List(Of PurchaseOrderDetail) Implements IDaoGetRecords(Of PurchaseOrderDetail).GetDaoRecords
            Dim sql As String = "SELECT " &
                                FieldList &
                                " FROM [PurchaseOrderDetail_View]" &
                                IIf(filter Is Nothing, "", " WHERE " & filter)
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function GetDaoRecord(Optional filter As String = Nothing) As PurchaseOrderDetail Implements IDaoGetRecord(Of PurchaseOrderDetail).GetDaoRecord
            Dim sql As String = "SELECT " & FieldList &
                                " FROM [PurchaseOrderDetail_View]" &
                                IIf(filter Is Nothing, "", " WHERE " & filter)
            Dim x As PurchaseOrderDetail = Db.Read(sql, Make).FirstOrDefault()
            Return x
        End Function

    End Class

End Namespace