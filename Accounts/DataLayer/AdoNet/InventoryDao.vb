Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub
Imports Extensions = AATM.DataLayer.AdoNet.Extensions

Namespace DataLayer.AdoNet
    ' Data access object for Inventory
    ' ** DAO Pattern

    Public Class InventoryDao
        Inherits CommonDao
        Implements IDao(Of Inventory)


        Private Const FieldList = "BatchNo," &
                                  "ExpiryDate," &
                                  "IdNo," &
                                  "TotalCost," &
                                  "ProductIdNo," &
                                  "TransactionIdNo," &
                                  "QtyOnHand," &
                                  "UnitCost," &
                                  "UnitSalesPrice," &
                                  "WarehouseIdNo"

        Private ReadOnly Db As New Db()

        Public Sub New()

        End Sub

        Public Function GetRecordByIdNo(idNo) As Inventory Implements IDao(Of Inventory).GetRecordByIdNo
            Dim sql As String = " SELECT " & FieldList & " FROM [Inventory]" & " WHERE IdNo = @IdNo and BranchIdNo = @BranchIdNo"
            Dim params() As Object = {"@IdNo", idNo, "@BranchIdNo", GlobalVariables.BranchIdNo}
            Dim data = Db.Read(sql, Make, params).FirstOrDefault()
            Return data
        End Function


        Private Shared ReadOnly Make As Func(Of IDataReader, Inventory) =
                                    Function(reader) _
            New Inventory() With {
            .BatchNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("BatchNo")),
            .ExpiryDate = AATM.DataLayer.AdoNet.Extensions.AsNullable(Of Date)(reader("ExpiryDate")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .TotalCost = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("TotalCost")),
            .ProductIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int16)(reader("ProductIdNo")),
            .QtyOnHand = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("QtyOnHand")),
            .TransactionIdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int16)(reader("TransactionIdNo")),
            .UnitCost = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("UnitCost")),
            .UnitSalesPrice = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("UnitSalesPrice")),
            .WarehouseIdNo = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("WarehouseIdNo"))
           }

        Public Function AddRecord(ByRef recordData As Inventory) As Integer Implements IDao(Of Inventory).AddRecord
            Return 0
            'Throw New NotImplementedException()
        End Function

        Public Function UpdateRecord(ByRef recordData As Inventory) As Integer Implements IDao(Of Inventory).UpdateRecord
            Return 0
            'Throw New NotImplementedException()
        End Function
    End Class

End Namespace