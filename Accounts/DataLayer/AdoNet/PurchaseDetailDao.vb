Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for PurchaseDetail
    ' ** DAO Pattern

    Public Class PurchaseDetailDao
        Inherits AccountsDao
        Implements IDaoChild(Of PurchaseDetail), IDaoGetListByIdNo(Of PurchaseDetail), IDaoGetRecords(Of PurchaseDetail), IDaoGetRecord(Of PurchaseDetail)

        Private ReadOnly Db As New Db()

        Const FieldList As String = "BaseUnitIdNo," &
                                    "BonusQuantity," &
                                    "CategoryIdNo," &
                                    "DiscountAmount," &
                                    "IdNo," &
                                    "NetAmount," &
                                    "Price," &
                                    "ProductCode," &
                                    "ProductIdNo," &
                                    "ProductName," &
                                    "ProductNameAra," &
                                    "PurchaseIdNo," &
                                    "Quantity," &
                                    "Sequence," &
                                    "UnitCount," &
                                    "UnitIdNo," &
                                    "UnitSalesPrice," &
                                    "VatAmount," &
                                    "VatPercent"

        Public Function GetRecordsWithGroupIdNo(idNo, Optional sortExpression = Nothing) As List(Of PurchaseDetail) Implements IDaoChild(Of PurchaseDetail).GetRecordsWithGroupIdNo
            If sortExpression Is Nothing Then
                sortExpression = "Sequence"
            End If
            Dim sql As String =
                    " SELECT " & FieldList &
                    " FROM [PurchaseDetail_View]" &
                    " WHERE PurchaseIdNo = @IdNo  " &
                    " ORDER BY " & sortExpression
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Integer) As Integer Implements IDaoChild(Of PurchaseDetail).DelUpdateTvp
            Return Db.DelUpdateTvp("UpdatePurchaseDetailTVP", tvpTable, "@MParam", groupIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of PurchaseDetail).InsertTvp
            Return Db.InsertTvp("InsertPurchaseDetailTVP", tvpTable)
        End Function

        Public Function GetListByIdNo(idNo As Object) As List(Of PurchaseDetail) Implements IDaoGetListByIdNo(Of PurchaseDetail).GetListByIdNo
            Dim sql As String =
                    "SELECT Top 1 " & FieldList &
                    " FROM [PurchaseDetail_View]" &
                    " WHERE IdNo = @IdNo "
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).ToList()
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PurchaseDetail) =
                                    Function(reader) _
            New PurchaseDetail() With {
            .BaseUnitIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("BaseUnitIdNo")),
            .BonusQuantity = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("BonusQuantity")),
            .CategoryIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("CategoryIdNo")),
            .DiscountAmount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("DiscountAmount")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .NetAmount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("NetAmount")),
            .Price = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Price")),
            .ProductCode = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ProductCode")),
            .ProductIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int16)(reader("ProductIdNo")),
            .ProductName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ProductName")),
            .ProductNameAra = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ProductNameAra")),
            .PurchaseIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("PurchaseIdNo")),
            .Quantity = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("Quantity")),
            .Sequence = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("Sequence")),
            .UnitCount = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("UnitIdNo")),
            .UnitIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("UnitIdNo")),
            .UnitSalesPrice = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("UnitSalesPrice")),
            .VatAmount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("VatAmount")),
            .VatPercent = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("VatPercent"))
           }

        Public Function GetDaoRecords(Optional filter As String = Nothing) As List(Of PurchaseDetail) Implements IDaoGetRecords(Of PurchaseDetail).GetDaoRecords
            Dim sql As String = "SELECT " &
                                FieldList &
                                " FROM [PurchaseDetail_View]" &
                                IIf(filter Is Nothing, "", " WHERE " & filter)
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function GetDaoRecord(Optional filter As String = Nothing) As PurchaseDetail Implements IDaoGetRecord(Of PurchaseDetail).GetDaoRecord
            Dim sql As String = "SELECT " & FieldList &
                                " FROM [PurchaseDetail_View]" &
                                IIf(filter Is Nothing, "", " WHERE " & filter)
            Dim x As PurchaseDetail = Db.Read(sql, Make).FirstOrDefault()
            Return x
        End Function

    End Class

End Namespace