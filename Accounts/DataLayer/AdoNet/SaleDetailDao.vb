Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for SaleDetail
    ' ** DAO Pattern

    Public Class SaleDetailDao
        Inherits AccountsDao
        Implements IDaoChild(Of SaleDetail), IDaoGetListByIdNo(Of SaleDetail), IDaoGetRecords(Of SaleDetail), IDaoGetRecord(Of SaleDetail)

        Private ReadOnly Db As New Db()

        Const FieldList As String = "AmtBefVat," &
                                    "BaseUnitIdNo," &
                                    "BatchNo," &
                                    "CategoryIdNo," &
                                    "DiscountAmount," &
                                    "DiscountPercent," &
                                    "ExpiryDate," &
                                    "GrossAmount," &
                                    "IdNo," &
                                    "NeedsExpiryDate," &
                                    "NetAmount," &
                                    "Price," &
                                    "ProductCode," &
                                    "ProductIdNo," &
                                    "ProductName," &
                                    "ProductNameAra," &
                                    "SaleIdNo," &
                                    "Quantity," &
                                    "Sequence," &
                                    "UnitCount," &
                                    "UnitIdNo," &
                                    "UnitCost," &
                                    "VatAmount," &
                                    "VatPercent"

        Public Function GetRecordsWithGroupIdNo(idNo, Optional sortExpression = Nothing) As List(Of SaleDetail) Implements IDaoChild(Of SaleDetail).GetRecordsWithGroupIdNo
            If sortExpression Is Nothing Then
                sortExpression = "Sequence"
            End If
            Dim sql As String =
                    " SELECT " & FieldList &
                    " FROM [SaleDetail_View]" &
                    " WHERE SaleIdNo = @IdNo  " &
                    " ORDER BY " & sortExpression
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Integer) As Integer Implements IDaoChild(Of SaleDetail).DelUpdateTvp
            Return Db.DelUpdateTvp("UpdateSaleDetailTVP", tvpTable, "@MParam", groupIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of SaleDetail).InsertTvp
            Return Db.InsertTvp("InsertSaleDetailTVP", tvpTable)
        End Function

        Public Function GetListByIdNo(idNo As Object) As List(Of SaleDetail) Implements IDaoGetListByIdNo(Of SaleDetail).GetListByIdNo
            Dim sql As String =
                    "SELECT Top 1 " & FieldList &
                    " FROM [SaleDetail_View]" &
                    " WHERE IdNo = @IdNo "
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).ToList()
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, SaleDetail) =
                                    Function(reader) _
            New SaleDetail() With {
            .AmtBefVat = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("AmtBefVat")),
            .BaseUnitIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("BaseUnitIdNo")),
            .BatchNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("BatchNo")),
            .CategoryIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("CategoryIdNo")),
            .DiscountAmount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("DiscountAmount")),
            .DiscountPercent = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("DiscountPercent")),
            .ExpiryDate = AATM.DataLayer.AdoNet.Extensions.AsNullable(Of Date?)(reader("ExpiryDate")),
            .GrossAmount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("GrossAmount")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .NeedsExpiryDate = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("NetAmount")),
            .NetAmount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("NetAmount")),
            .Price = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Price")),
            .ProductCode = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ProductCode")),
            .ProductIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("ProductIdNo")),
            .ProductName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ProductName")),
            .ProductNameAra = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ProductNameAra")),
            .SaleIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("SaleIdNo")),
            .Quantity = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Quantity")),
            .Sequence = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("Sequence")),
            .UnitCount = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("UnitIdNo")),
            .UnitIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("UnitIdNo")),
            .UnitCost = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("UnitCost")),
            .VatAmount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("VatAmount")),
            .VatPercent = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("VatPercent"))
           }

        Public Function GetDaoRecords(Optional filter As String = Nothing) As List(Of SaleDetail) Implements IDaoGetRecords(Of SaleDetail).GetDaoRecords
            Dim sql As String = "SELECT " &
                                FieldList &
                                " FROM [SaleDetail_View]" &
                                IIf(filter Is Nothing, "", " WHERE " & filter)
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function GetDaoRecord(Optional filter As String = Nothing) As SaleDetail Implements IDaoGetRecord(Of SaleDetail).GetDaoRecord
            Dim sql As String = "SELECT " & FieldList &
                                " FROM [SaleDetail_View]" &
                                IIf(filter Is Nothing, "", " WHERE " & filter)
            Dim x As SaleDetail = Db.Read(sql, Make).FirstOrDefault()
            Return x
        End Function

    End Class

End Namespace