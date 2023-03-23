Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for Purchase
    ' ** DAO Pattern

    Public Class PurchaseDao
        Inherits AccountsDao
        Implements IDao(Of Purchase)


        
        Private Const FieldList = "Amount," &
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
                                  "VatNumber"                   


        ' ReSharper disable once InconsistentNaming
        Private ReadOnly Db As New Db()

        Public Function GetRecordByIdNo(idNo) As Purchase _
        Implements IDao(Of Purchase).GetRecordByIdNo
            Dim sql As String = " SELECT Amount,Cancelled,DateCreated,DueDate,IdNo,InvoiceDate,InvoiceNo,Posted,SupplierIdNo,TransactionDate,VatAmount,VatNumber" &
                    " FROM [Purchase]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function UpdateRecord(ByRef Purchase As Purchase) As Integer _
            Implements IDao(Of Purchase).UpdateRecord
            Dim sql As String =
                    "UPDATE [Purchase] Set " &
                    "Amount = @Amount," &
                    "Cancelled = @Cancelled," &
                    "DueDate = @DueDate," &
                    "IdNo = @IdNo," &
                    "InvoiceDate = @InvoiceDate," &
                    "InvoiceNo = @InvoiceNo," &
                    "Posted = @Posted," &
                    "SupplierIdNo = @SupplierIdNo," &
                    "TransactionDate = @TransactionDate," &
                    "VatAmount = @VatAmount," &
                    "VatNumber = @VatNumber" &
                    "WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(Purchase))
        End Function

        Public Function AddRecord(ByRef Purchase As Purchase) As Integer _
            Implements IDao(Of Purchase).AddRecord
            Dim sql As String =
                    " INSERT INTO [Purchase] " &
                    " (Amount,Cancelled,DueDate,IdNo,InvoiceDate,InvoiceNo,Posted,SupplierIdNo,TransactionDate,VatAmount,VatNumber)" &
                    " VALUES (@Amount,@Cancelled,@DueDate,@IdNo,@InvoiceDate,@InvoiceNo,@Posted,@SupplierIdNo,@TransactionDate,@VatAmount,@VatNumber)"
            Return Db.Insert(sql, Take(Purchase))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Purchase) =
                                    Function(reader) _
            New Purchase() With { .Amount = Extensions.AsDecimal(reader("Amount")),
                                  .Cancelled = Extensions.AsBool(reader("Cancelled")),
                                  .DueDate = Extensions.AsDate(reader("DueDate")),
                                  .IdNo = Extensions.AsInt(of Int32)(reader("IdNo")),
                                  .InvoiceDate = Extensions.AsDate(reader("InvoiceDate")),
                                  .InvoiceNo = Extensions.AsInt(of Int32)(reader("InvoiceNo")),
                                  .Posted = Extensions.AsBool(reader("Posted")),
                                  .SupplierIdNo = Extensions.AsInt(of Int32)(reader("SupplierIdNo")),
                                  .TransactionDate = Extensions.AsDate(reader("TransactionDate")),
                                  .VatAmount = Extensions.AsDecimal(reader("VatAmount")),
                                  .VatNumber = Extensions.AsString(reader("VatNumber"))
                                }

        Private Function Take(Purchase As Purchase) As Object()
            Return New Object() {
                                    "Amount", Purchase.Amount,
                                    "Cancelled", Purchase.Cancelled,
                                    "DueDate", Purchase.DueDate,
                                    "InvoiceDate", Purchase.InvoiceDate,
                                    "InvoiceNo", Purchase.InvoiceNo,
                                    "Posted", Purchase.Posted,
                                    "SupplierIdNo", Purchase.SupplierIdNo,
                                    "TransactionDate", Purchase.TransactionDate,
                                    "VatAmount", Purchase.VatAmount,
                                    "VatNumber", Purchase.VatNumber
                                 }
        End Function

    End Class

End Namespace