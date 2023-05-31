Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for PurchaseHistory
    ' ** DAO Pattern

    Public Class PurchaseHistoryDao
        Inherits AccountsDao
        Implements IDaoChild(Of PurchaseHistory)

        Private ReadOnly Db As New Db()

        Const FieldList As String = "BatchNo," &
                                    "BonusQuantity," &
                                    "ExpiryDate," &
                                    "IdNo," &
                                    "PurchaseIdNo," &
                                    "Quantity," &
                                    "SupplierCode," &
                                    "SupplierName," &
                                    "SupplierNameAra," &
                                    "TransactionDate," &
                                    "UnitName," &
                                    "UnitSalesPrice," &
                                    "UnitCost"

        Public Function GetRecordsWithGroupIdNo(idNo, Optional sortExpression = Nothing) As List(Of PurchaseHistory) Implements IDaoChild(Of PurchaseHistory).GetRecordsWithGroupIdNo
            If sortExpression Is Nothing Then
                sortExpression = "TransactionDate"
            End If
            Dim sql As String =
                    " SELECT " & FieldList &
                    " FROM [PurchaseHistory_View]" &
                    " WHERE ProductIdNo = @IdNo  " &
                    " ORDER BY " & sortExpression & " Desc"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Integer) As Integer Implements IDaoChild(Of PurchaseHistory).DelUpdateTvp
            Throw New NotImplementedException()
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of PurchaseHistory).InsertTvp
            Throw New NotImplementedException()
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PurchaseHistory) =
                                    Function(reader) _
            New PurchaseHistory() With {
            .BatchNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("BatchNo")),
            .BonusQuantity = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("BonusQuantity")),
            .ExpiryDate = AATM.DataLayer.AdoNet.Extensions.AsNullable(Of Date)(reader("ExpiryDate")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .PurchaseIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("PurchaseIdNo")),
            .Quantity = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("Quantity")),
            .SupplierCode = AATM.DataLayer.AdoNet.Extensions.AsString(reader("SupplierCode")),
            .SupplierName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("SupplierName")),
            .TransactionDate = AATM.DataLayer.AdoNet.Extensions.AsDate(reader("TransactionDate")),
            .UnitName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("UnitName")),
            .UnitCost = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("UnitCost")),
            .UnitSalesPrice = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("UnitSalesPrice"))
           }

    End Class

End Namespace


