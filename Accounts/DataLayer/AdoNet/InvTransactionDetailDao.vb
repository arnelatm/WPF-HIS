Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for InvTransactionDetail
    ' ** DAO Pattern

    Public Class InvTransactionDetailDao
        Inherits AccountsDao
        Implements IDaoChild(Of InvTransactionDetail), IDaoGetListByIdNo(Of InvTransactionDetail), IDaoGetRecords(Of InvTransactionDetail), IDaoGetRecord(Of InvTransactionDetail)

        Private ReadOnly Db As New Db()

        Const FieldList As String = "AmtBefVat," &
                                    "BaseUnitIdNo," &
                                    "BatchNo," &
                                    "BonusQuantity," &
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
                                    "InvTransactionIdNo," &
                                    "Quantity," &
                                    "Sequence," &
                                    "UnitCount," &
                                    "UnitIdNo," &
                                    "UnitSalesPrice," &
                                    "UnitCost," &
                                    "VatAmount," &
                                    "VatPercent"

        Public Function GetRecordsWithGroupIdNo(idNo, Optional sortExpression = Nothing) As List(Of InvTransactionDetail) Implements IDaoChild(Of InvTransactionDetail).GetRecordsWithGroupIdNo
            If sortExpression Is Nothing Then
                sortExpression = "Sequence"
            End If
            Dim sql As String =
                    " SELECT " & FieldList &
                    " FROM [InvTransactionDetail_View]" &
                    " WHERE InvTransactionIdNo = @IdNo  " &
                    " ORDER BY " & sortExpression
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Integer) As Integer Implements IDaoChild(Of InvTransactionDetail).DelUpdateTvp
            Return Db.DelUpdateTvp("UpdateInvTransactionDetailTVP", tvpTable, "@MParam", groupIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of InvTransactionDetail).InsertTvp
            Return Db.InsertTvp("InsertInvTransactionDetailTVP", tvpTable)
        End Function

        Public Function GetListByIdNo(idNo As Object) As List(Of InvTransactionDetail) Implements IDaoGetListByIdNo(Of InvTransactionDetail).GetListByIdNo
            Dim sql As String =
                    "SELECT Top 1 " & FieldList &
                    " FROM [InvTransactionDetail_View]" &
                    " WHERE IdNo = @IdNo "
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).ToList()
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, InvTransactionDetail) =
                                    Function(reader) _
            New InvTransactionDetail() With {
            .AmtBefVat = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Decimal)(reader("AmtBefVat")),
            .BaseUnitIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("BaseUnitIdNo")),
            .BatchNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("BatchNo")),
            .BonusQuantity = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("BonusQuantity")),
            .CategoryIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("CategoryIdNo")),
            .DiscountAmount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("DiscountAmount")),
            .DiscountPercent = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("DiscountPercent")),
            .ExpiryDate = AATM.DataLayer.AdoNet.Extensions.AsNullable(Of Date)(reader("ExpiryDate")),
            .GrossAmount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("GrossAmount")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .NeedsExpiryDate = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("NetAmount")),
            .NetAmount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("NetAmount")),
            .Price = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Price")),
            .ProductCode = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ProductCode")),
            .ProductIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int16)(reader("ProductIdNo")),
            .ProductName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ProductName")),
            .ProductNameAra = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ProductNameAra")),
            .InvTransactionIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("InvTransactionIdNo")),
            .Quantity = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("Quantity")),
            .Sequence = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("Sequence")),
            .UnitCount = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("UnitIdNo")),
            .UnitIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("UnitIdNo")),
            .UnitCost = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("UnitCost")),
            .UnitSalesPrice = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("UnitSalesPrice")),
            .VatAmount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("VatAmount")),
            .VatPercent = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("VatPercent"))
           }

        Public Function GetDaoRecords(Optional filter As String = Nothing) As List(Of InvTransactionDetail) Implements IDaoGetRecords(Of InvTransactionDetail).GetDaoRecords
            Dim sql As String = "SELECT " &
                                FieldList &
                                " FROM [InvTransactionDetail_View]" &
                                IIf(filter Is Nothing, "", " WHERE " & filter)
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function GetDaoRecord(Optional filter As String = Nothing) As InvTransactionDetail Implements IDaoGetRecord(Of InvTransactionDetail).GetDaoRecord
            Dim sql As String = "SELECT " & FieldList &
                                " FROM [InvTransactionDetail_View]" &
                                IIf(filter Is Nothing, "", " WHERE " & filter)
            Dim x As InvTransactionDetail = Db.Read(sql, Make).FirstOrDefault()
            Return x
        End Function

    End Class

End Namespace