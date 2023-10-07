Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for PurchaseOrderApprovalDetail
    ' ** DAO Pattern

    Public Class PurchaseOrderApprovalDetailDao
        Inherits AccountsDao
        Implements IDaoChild(Of PurchaseOrderApprovalDetail), IDaoGetListByIdNo(Of PurchaseOrderApprovalDetail), IDaoGetRecords(Of PurchaseOrderApprovalDetail), IDaoGetRecord(Of PurchaseOrderApprovalDetail)

        Private ReadOnly Db As New Db()

        Const FieldList As String =
                                    "BaseUnitName," &
                                    "BonusQuantity," &
                                    "DiscountAmount," &
                                    "DiscountPercent," &
                                    "IdNo," &
                                    "PurchaseOrderIdNo," &
                                    "NetAmount," &
                                    "ProductCode," &
                                    "ProductIdNo," &
                                    "ProductName," &
                                    "ProductNameAra," &
                                    "QtyOnHand," &
                                    "QtySupplied," &
                                    "Quantity," &
                                    "Sequence," &
                                    "UnitCost," &
                                    "UnitIdNo," &
                                    "UnitName," &
                                    "VatAmount," &
                                    "VatPercent"


        Public Function GetRecordsWithGroupIdNo(idNo, Optional sortExpression = Nothing) As List(Of PurchaseOrderApprovalDetail) Implements IDaoChild(Of PurchaseOrderApprovalDetail).GetRecordsWithGroupIdNo
            If sortExpression Is Nothing Then
                sortExpression = "Sequence"
            End If
            Dim sql As String =
                    " SELECT " & FieldList &
                    " FROM [PurchaseOrderApprovalDetail_View]" &
                    " WHERE PurchaseOrderIdNo = @IdNo  " &
                    " ORDER BY " & sortExpression
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Integer) As Integer Implements IDaoChild(Of PurchaseOrderApprovalDetail).DelUpdateTvp
            Return Db.DelUpdateTvp("UpdatePurchaseOrderApprovalDetailTVP", tvpTable, "@MParam", groupIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of PurchaseOrderApprovalDetail).InsertTvp
            Return Db.InsertTvp("InsertPurchaseOrderApprovalDetailTVP", tvpTable)
        End Function

        Public Function GetListByIdNo(idNo As Object) As List(Of PurchaseOrderApprovalDetail) Implements IDaoGetListByIdNo(Of PurchaseOrderApprovalDetail).GetListByIdNo
            Dim sql As String =
                    "SELECT Top 1 " & FieldList &
                    " FROM [PurchaseOrderApprovalDetail_View]" &
                    " WHERE IdNo = @IdNo "
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).ToList()
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PurchaseOrderApprovalDetail) =
                                    Function(reader) _
            New PurchaseOrderApprovalDetail() With {
            .BaseUnitIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .BaseUnitName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("BaseUnitName")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .NetAmount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("NetAmount")),
            .ProductCode = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ProductCode")),
            .ProductIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int16)(reader("ProductIdNo")),
            .ProductName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ProductName")),
            .ProductNameAra = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ProductNameAra")),
            .QtyOnHand = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("QtyOnHand")),
            .QtySupplied = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("QtySupplied")),
            .Quantity = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("Quantity")),
            .Sequence = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("Sequence")),
            .UnitName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("UnitName")),
            .UnitCost = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("UnitCost"))
        }

        Public Function GetDaoRecords(Optional filter As String = Nothing) As List(Of PurchaseOrderApprovalDetail) Implements IDaoGetRecords(Of PurchaseOrderApprovalDetail).GetDaoRecords
            Dim sql As String = "SELECT " &
                                FieldList &
                                " FROM [PurchaseOrderApprovalDetail_View]" &
                                IIf(filter Is Nothing, "", " WHERE " & filter)
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function GetDaoRecord(Optional filter As String = Nothing) As PurchaseOrderApprovalDetail Implements IDaoGetRecord(Of PurchaseOrderApprovalDetail).GetDaoRecord
            Dim sql As String = "SELECT " & FieldList &
                                " FROM [PurchaseOrderApprovalDetail_View]" &
                                IIf(filter Is Nothing, "", " WHERE " & filter)
            Dim x As PurchaseOrderApprovalDetail = Db.Read(sql, Make).FirstOrDefault()
            Return x
        End Function

    End Class

End Namespace
