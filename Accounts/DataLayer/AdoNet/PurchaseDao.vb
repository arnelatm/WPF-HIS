Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for Purchase
    ' ** DAO Pattern

    Public Class PurchaseDao
        Inherits AccountsDao
        Implements IDao(Of Purchase), IPurchaseDao

        Private Const FieldList = "Amount," &
                                  "BranchIdNo," &
                                  "Cancelled," &
                                  "DateCreated," &
                                  "DueDate," &
                                  "IdNo," &
                                  "InvoiceDate," &
                                  "InvoiceNo," &
                                  "Posted," &
                                  "SupplierIdNo," &
                                  "TransactionDate," &
                                  "VatAmount," &
                                  "VatNumber," &
                                  "WarehouseIdNo"


        ' ReSharper disable once InconsistentNaming
        Private ReadOnly Db As New Db()

        Public Function GetRecordByIdNo(idNo) As Purchase _
        Implements IDao(Of Purchase).GetRecordByIdNo
            Dim sql As String = " SELECT " & FieldList & " FROM [Purchase]" & " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim data = Db.Read(sql, Make, params).FirstOrDefault()
            If data IsNot Nothing Then
                Dim purchaseDetailDao = New PurchaseDetailDao
                data.PurchaseDetails = purchaseDetailDao.GetRecordsWithGroupIdNo(idNo, "sequence")
                Dim productIdNo As Int32 = data.PurchaseDetails(0).ProductIdNo
                data.PurchaseHistory = GetPurchaseHistory(productIdNo)
            End If
            Return data
        End Function

        Public Function GetPurchaseHistory(productIdNo As Int32) As List(Of PurchaseHistory) Implements IPurchaseDao.GetPurchaseHistory
            Dim purchaseHistoryDao = New PurchaseHistoryDao
            Return purchaseHistoryDao.GetRecordsWithGroupIdNo(productIdNo)
        End Function

        Public Function UpdateRecord(ByRef Purchase As Purchase) As Integer _
            Implements IDao(Of Purchase).UpdateRecord
            Dim sql As String =
                    "UPDATE [Purchase] Set " &
                    "Amount = @Amount," &
                    "BranchIdNo = @BranchIdNo," &
                    "Cancelled = @Cancelled," &
                    "DueDate = @DueDate," &
                    "InvoiceDate = @InvoiceDate," &
                    "InvoiceNo = @InvoiceNo," &
                    "Posted = @Posted," &
                    "SupplierIdNo = @SupplierIdNo," &
                    "TransactionDate = @TransactionDate," &
                    "VatAmount = @VatAmount," &
                    "VatNumber = @VatNumber, " &
                    "WarehouseIdNo = @WarehouseIdNo " &
                    "WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(Purchase))
        End Function

        Public Function AddRecord(ByRef Purchase As Purchase) As Integer _
            Implements IDao(Of Purchase).AddRecord
            Dim sql As String =
                    " INSERT INTO [Purchase] " &
                    " (Amount,BranchIdNo,Cancelled,DueDate,InvoiceDate,InvoiceNo,Posted,SupplierIdNo,TransactionDate,VatAmount,VatNumber,WarehouseIdNo)" &
                    " VALUES (@Amount,@BranchIdNo,@Cancelled,@DueDate,@InvoiceDate,@InvoiceNo,@Posted,@SupplierIdNo,@TransactionDate,@VatAmount,@VatNumber,@WarehouseIdNo)"
            Return Db.Insert(sql, Take(Purchase))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Purchase) =
                                    Function(reader) _
            New Purchase() With {.Amount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Amount")),
                                  .BranchIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("BranchIdNo")),
                                  .Cancelled = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Cancelled")),
                                  .DueDate = AATM.DataLayer.AdoNet.Extensions.AsDate(reader("DueDate")),
                                  .IdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("IdNo")),
                                  .InvoiceDate = AATM.DataLayer.AdoNet.Extensions.AsDate(reader("InvoiceDate")),
                                  .InvoiceNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("InvoiceNo")),
                                  .Posted = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Posted")),
                                  .SupplierIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("SupplierIdNo")),
                                  .TransactionDate = AATM.DataLayer.AdoNet.Extensions.AsDate(reader("TransactionDate")),
                                  .VatAmount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("VatAmount")),
                                  .VatNumber = AATM.DataLayer.AdoNet.Extensions.AsString(reader("VatNumber")),
                                  .WarehouseIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("WarehouseIdNo"))
                                }

        Private Function Take(Purchase As Purchase) As Object()
            Return New Object() {
                                    "Amount", Purchase.Amount,
                                    "BranchIdNo", Purchase.BranchIdNo,
                                    "Cancelled", Purchase.Cancelled,
                                    "DueDate", Purchase.DueDate,
                                    "IdNo", Purchase.IdNo,
                                    "InvoiceDate", Purchase.InvoiceDate,
                                    "InvoiceNo", Purchase.InvoiceNo,
                                    "Posted", Purchase.Posted,
                                    "SupplierIdNo", Purchase.SupplierIdNo,
                                    "TransactionDate", Purchase.TransactionDate,
                                    "VatAmount", Purchase.VatAmount,
                                    "VatNumber", Purchase.VatNumber,
                                    "WarehouseIdNo", Purchase.WarehouseIdNo
                                 }
        End Function

    End Class

    Public Interface IPurchaseDao
        Function GetPurchaseHistory(productIdNo As Integer) As List(Of PurchaseHistory)

    End Interface

End Namespace