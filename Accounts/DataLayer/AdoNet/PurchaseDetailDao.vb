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

        Private _tableName As String
        Private _purchaseOrder As Boolean
        Private _purchaseReturn As Boolean
        Private _fieldList As String
        Protected DboTvpUpdateName As String = ""
        Protected DboTvpInsertName As String = ""

        Public Sub New()

        End Sub

        Public Sub New(parameter As Object)
            _purchaseOrder = parameter(0)
            _purchaseReturn = parameter(1)
            If _purchaseOrder Then
                _tableName = "PurchaseOrder"
                _fieldList = "AmtBefVat,BaseUnitIdNo,BonusQuantity,CategoryIdNo,DiscountAmount,DiscountPercent,GrossAmount," &
                             "IdNo,NetAmount,Price,ProductCode,ProductIdNo,ProductName,ProductNameAra,PurchaseOrderIdNo,Quantity," &
                             "Sequence,UnitCount,UnitIdNo,VatAmount,VatPercent"
                DboTvpUpdateName = "UpdatePurchaseOrderDetailTVP"
                DboTvpInsertName = "InsertPurchaseOrderDetailTVP"
            Else
                _tableName = "Purchase"
                _fieldList = "AmtBefVat,BaseUnitIdNo,BatchNo,BonusQuantity,CategoryIdNo,DiscountAmount,DiscountPercent,ExpiryDate," &
                             "GrossAmount,IdNo,NeedsExpiryDate,NetAmount,Price,ProductCode,ProductIdNo,ProductName,ProductNameAra," &
                             "PurchaseIdNo,Quantity,Sequence,UnitCount,UnitIdNo,UnitSalesPrice,UnitCost,VatAmount,VatPercent"
                DboTvpUpdateName = "UpdatePurchaseDetailTVP"
                DboTvpInsertName = "InsertPurchaseDetailTVP"
            End If
        End Sub

        Public Function GetRecordsWithGroupIdNo(idNo, Optional sortExpression = Nothing) As List(Of PurchaseDetail) Implements IDaoChild(Of PurchaseDetail).GetRecordsWithGroupIdNo
            If sortExpression Is Nothing Then
                sortExpression = "Sequence"
            End If
            Dim sql As String =
                    " SELECT " & _fieldList &
                    " FROM " & _tableName & "Detail_View" &
                    " WHERE " & _tableName & "IdNo = @IdNo  " &
                    " ORDER BY " & sortExpression
            Dim params() As Object = {"@IdNo", idNo}
            If _purchaseOrder Then
                Return Db.Read(sql, MakePo, params).ToList()
            Else
                Return Db.Read(sql, Make, params).ToList()
            End If

        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Integer) As Integer Implements IDaoChild(Of PurchaseDetail).DelUpdateTvp
            'Return Db.DelUpdateTvp("UpdatePurchaseOrderDetailTVP", tvpTable, "@MParam", groupIdNo)
            If _purchaseOrder Then
                Return Db.DelUpdateTvp("UpdatePurchaseOrderDetailTVP", tvpTable, "@MParam", groupIdNo)
            Else
                Return Db.DelUpdateTvp("UpdatePurchaseDetailTVP", tvpTable, "@MParam", groupIdNo)
            End If

        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of PurchaseDetail).InsertTvp
            If _purchaseOrder Then
                Return Db.InsertTvp("InsertPurchaseOrderDetailTVP", tvpTable)
            Else
                Return Db.InsertTvp("InsertPurchaseDetailTVP", tvpTable)
            End If
        End Function

        Public Function GetListByIdNo(idNo As Object) As List(Of PurchaseDetail) Implements IDaoGetListByIdNo(Of PurchaseDetail).GetListByIdNo
            Dim sql As String =
                    "SELECT Top 1 " & _fieldList &
                    " FROM " & _tableName & "Detail_View]" &
                    " WHERE IdNo = @IdNo "
            Dim params() As Object = {"@IdNo", idNo}
            If _purchaseOrder Then
                Return Db.Read(sql, MakePo, params).ToList()
            Else
                Return Db.Read(sql, Make, params).ToList()
            End If

        End Function

        Private ReadOnly Make As Func(Of IDataReader, PurchaseDetail) =
                                    Function(reader) _
            New PurchaseDetail({_purchaseOrder}) With {
            .AmtBefVat = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Decimal)(reader("AmtBefVat")),
            .BaseUnitIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("BaseUnitIdNo")),
            .BatchNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("BatchNo")),
            .BonusQuantity = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("BonusQuantity")),
            .CategoryIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("CategoryIdNo")),
            .DiscountAmount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("DiscountAmount")),
            .DiscountPercent = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("DiscountPercent")),
            .ExpiryDate = AATM.DataLayer.AdoNet.Extensions.AsNullable(Of Date?)(reader("ExpiryDate")),
            .GrossAmount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("GrossAmount")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .NeedsExpiryDate = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("NeedsExpiryDate")),
            .NetAmount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("NetAmount")),
            .Price = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Price")),
            .ProductCode = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ProductCode")),
            .ProductIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("ProductIdNo")),
            .ProductName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ProductName")),
            .ProductNameAra = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ProductNameAra")),
            .PurchaseIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("PurchaseIdNo")),
            .Quantity = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Quantity")),
            .Sequence = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("Sequence")),
            .UnitCount = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("UnitIdNo")),
            .UnitIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("UnitIdNo")),
            .UnitCost = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("UnitCost")),
            .UnitSalesPrice = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("UnitSalesPrice")),
            .VatAmount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("VatAmount")),
            .VatPercent = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("VatPercent"))
           }


        Private ReadOnly MakePo As Func(Of IDataReader, PurchaseDetail) =
                                    Function(reader) _
            New PurchaseDetail({_purchaseOrder}) With {
            .AmtBefVat = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Decimal)(reader("AmtBefVat")),
            .BaseUnitIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("BaseUnitIdNo")),
            .BonusQuantity = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("BonusQuantity")),
            .CategoryIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("CategoryIdNo")),
            .DiscountAmount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("DiscountAmount")),
            .DiscountPercent = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("DiscountPercent")),
            .GrossAmount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("GrossAmount")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .NetAmount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("NetAmount")),
            .Price = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Price")),
            .ProductCode = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ProductCode")),
            .ProductIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("ProductIdNo")),
            .ProductName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ProductName")),
            .ProductNameAra = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ProductNameAra")),
            .PurchaseIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("PurchaseOrderIdNo")),
            .Quantity = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Quantity")),
            .Sequence = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("Sequence")),
            .UnitCount = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("UnitIdNo")),
            .UnitIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("UnitIdNo")),
            .VatAmount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("VatAmount")),
            .VatPercent = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("VatPercent"))
           }


        Public Function GetDaoRecords(Optional filter As String = Nothing) As List(Of PurchaseDetail) Implements IDaoGetRecords(Of PurchaseDetail).GetDaoRecords
            Dim sql As String = "SELECT " &
                                _fieldList &
                                " FROM " & _tableName & "Detail_View" &
                                IIf(filter Is Nothing, "", " WHERE " & filter)
            If _purchaseOrder Then
                Return Db.Read(sql, MakePo).ToList()
            Else
                Return Db.Read(sql, Make).ToList()
            End If

        End Function

        Public Function GetDaoRecord(Optional filter As String = Nothing) As PurchaseDetail Implements IDaoGetRecord(Of PurchaseDetail).GetDaoRecord
            Dim sql As String = "SELECT " & _fieldList &
                                " FROM " & _tableName & "Detail_View" &
                                IIf(filter Is Nothing, "", " WHERE " & filter)
            Dim x As PurchaseDetail
            If _purchaseOrder Then
                x = Db.Read(sql, MakePo).FirstOrDefault()
            Else
                x = Db.Read(sql, Make).FirstOrDefault()
            End If
            Return x
        End Function

    End Class

End Namespace