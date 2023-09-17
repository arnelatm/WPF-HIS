Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for InvRequestDetail
    ' ** DAO Pattern

    Public Class InvRequestDetailDao
        Inherits AccountsDao
        Implements IDaoChild(Of InvRequestDetail), IDaoGetListByIdNo(Of InvRequestDetail), IDaoGetRecords(Of InvRequestDetail), IDaoGetRecord(Of InvRequestDetail)

        Private ReadOnly Db As New Db()

        Const FieldList As String =
                                    "BaseUnitName," &
                                    "IdNo," &
                                    "InvTransactionIdNo," &
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
                                    "UnitName"

        Public Function GetRecordsWithGroupIdNo(idNo, Optional sortExpression = Nothing) As List(Of InvRequestDetail) Implements IDaoChild(Of InvRequestDetail).GetRecordsWithGroupIdNo
            If sortExpression Is Nothing Then
                sortExpression = "Sequence"
            End If
            Dim sql As String =
                    " SELECT " & FieldList &
                    " FROM [InvRequestDetail_View]" &
                    " WHERE InvTransactionIdNo = @IdNo  " &
                    " ORDER BY " & sortExpression
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Integer) As Integer Implements IDaoChild(Of InvRequestDetail).DelUpdateTvp
            Return Db.DelUpdateTvp("UpdateInvRequestDetailTVP", tvpTable, "@MParam", groupIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of InvRequestDetail).InsertTvp
            Return Db.InsertTvp("InsertInvRequestDetailTVP", tvpTable)
        End Function

        Public Function GetListByIdNo(idNo As Object) As List(Of InvRequestDetail) Implements IDaoGetListByIdNo(Of InvRequestDetail).GetListByIdNo
            Dim sql As String =
                    "SELECT Top 1 " & FieldList &
                    " FROM [InvRequestDetail_View]" &
                    " WHERE IdNo = @IdNo "
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).ToList()
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, InvRequestDetail) =
                                    Function(reader) _
            New InvRequestDetail() With {
            .BaseUnitIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .BaseUnitName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("BaseUnitName")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .InvTransactionIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("InvTransactionIdNo")),
            .NetAmount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("NetAmount")),
            .ProductCode = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ProductCode")),
            .ProductIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int16)(reader("ProductIdNo")),
            .ProductName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ProductName")),
            .ProductNameAra = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ProductNameAra")),
            .QtyOnHand = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("QtyOnHand")),
            .QtySupplied = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("QtySupplied")),
            .Quantity = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("Quantity")),
            .Sequence = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("Sequence")),
            .UnitName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("UnitName")),
            .UnitCost = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("UnitCost"))
        }

        Public Function GetDaoRecords(Optional filter As String = Nothing) As List(Of InvRequestDetail) Implements IDaoGetRecords(Of InvRequestDetail).GetDaoRecords
            Dim sql As String = "SELECT " &
                                FieldList &
                                " FROM [InvRequestDetail_View]" &
                                IIf(filter Is Nothing, "", " WHERE " & filter)
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function GetDaoRecord(Optional filter As String = Nothing) As InvRequestDetail Implements IDaoGetRecord(Of InvRequestDetail).GetDaoRecord
            Dim sql As String = "SELECT " & FieldList &
                                " FROM [InvRequestDetail_View]" &
                                IIf(filter Is Nothing, "", " WHERE " & filter)
            Dim x As InvRequestDetail = Db.Read(sql, Make).FirstOrDefault()
            Return x
        End Function

    End Class

End Namespace
