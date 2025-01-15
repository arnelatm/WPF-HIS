Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for InvTransactionDetail
    ' ** DAO Pattern

    Public Class InvTransactionDetailDao
        Inherits AccountsDao
        Implements IDaoChild(Of InvTransactionDetail), IDaoGetListByIdNo(Of InvTransactionDetail), IDaoGetRecords(Of InvTransactionDetail), IDaoGetRecord(Of InvTransactionDetail)

        Private ReadOnly Db As New Db()

        Const FieldList As String = "BaseUnitIdNo," &
                                    "BatchNo," &
                                    "CategoryIdNo," &
                                    "ExpiryDate," &
                                    "IdNo," &
                                    "InventoryIdNo," &
                                    "NeedsExpiryDate," &
                                    "NetAmount," &
                                    "ProductCode," &
                                    "ProductIdNo," &
                                    "ProductName," &
                                    "ProductNameAra," &
                                    "InvTransactionIdNo," &
                                    "Quantity," &
                                    "Sequence," &
                                    "UnitCount," &
                                    "UnitIdNo," &
                                    "UnitCost"

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
            .BaseUnitIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("BaseUnitIdNo")),
            .BatchNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("BatchNo")),
            .ExpiryDate = AATM.DataLayer.AdoNet.Extensions.AsNullable(Of Date?)(reader("ExpiryDate")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .InventoryIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("InventoryIdNo")),
            .NetAmount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("NetAmount")),
            .ProductCode = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ProductCode")),
            .ProductIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("ProductIdNo")),
            .ProductName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ProductName")),
            .ProductNameAra = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ProductNameAra")),
            .InvTransactionIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("InvTransactionIdNo")),
            .Quantity = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Quantity")),
            .Sequence = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("Sequence")),
            .UnitIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("UnitIdNo")),
            .UnitCost = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("UnitCost"))
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