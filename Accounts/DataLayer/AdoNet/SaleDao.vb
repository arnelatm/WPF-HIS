Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for Sale
    ' ** DAO Pattern

    Public Class SaleDao
        Inherits AccountsDao
        Implements IDao(Of Sale)

        Private Const FieldList = "Amount," &
                                  "Cancelled," &
                                  "CustomerIdNo," &
                                  "DateCreated," &
                                  "DueDate," &
                                  "IdNo," &
                                  "InvoiceDate," &
                                  "InvoiceNo," &
                                  "Posted," &
                                  "PatientIdNo," &
                                  "TransactionDate," &
                                  "VatAmount," &
                                  "VatNumber," &
                                  "WarehouseIdNo"


        ' ReSharper disable once InconsistentNaming
        Private ReadOnly Db As New Db()

        Public Function GetRecordByIdNo(idNo) As Sale _
        Implements IDao(Of Sale).GetRecordByIdNo
            Dim sql As String = " SELECT Amount,Cancelled,DateCreated,DueDate,IdNo,InvoiceDate,InvoiceNo,Posted,CustomerIdNo,TransactionDate,VatAmount,VatNumber,WarehouseIdNo" &
                    " FROM [Sale]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim data = Db.Read(sql, Make, params).FirstOrDefault()
            If data IsNot Nothing Then
                Dim SaleDetailDao = New SaleDetailDao
                data.SaleDetails = SaleDetailDao.GetRecordsWithGroupIdNo(idNo, "sequence")
            End If
            Return data
        End Function

        Public Function UpdateRecord(ByRef Sale As Sale) As Integer _
            Implements IDao(Of Sale).UpdateRecord
            Dim sql As String =
                    "UPDATE [Sale] Set " &
                    "Amount = @Amount," &
                    "Cancelled = @Cancelled," &
                    "DueDate = @DueDate," &
                    "InvoiceDate = @InvoiceDate," &
                    "InvoiceNo = @InvoiceNo," &
                    "Posted = @Posted," &
                    "CustomerIdNo = @CustomerIdNo," &
                    "TransactionDate = @TransactionDate," &
                    "VatAmount = @VatAmount," &
                    "VatNumber = @VatNumber, " &
                    "WarehouseIdNo = @WarehouseIdNo " &
                    "WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(Sale))
        End Function

        Public Function AddRecord(ByRef Sale As Sale) As Integer _
            Implements IDao(Of Sale).AddRecord
            Dim sql As String =
                    " INSERT INTO [Sale] " &
                    " (Amount,Cancelled,DueDate,InvoiceDate,InvoiceNo,Posted,CustomerIdNo,TransactionDate,VatAmount,VatNumber,WarehouseIdNo)" &
                    " VALUES (@Amount,@Cancelled,@DueDate,@InvoiceDate,@InvoiceNo,@Posted,@CustomerIdNo,@TransactionDate,@VatAmount,@VatNumber,@WarehouseIdNo)"
            Return Db.Insert(sql, Take(Sale))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Sale) =
                                    Function(reader) _
            New Sale() With {.Amount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Amount")),
                                  .Cancelled = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Cancelled")),
                                  .CustomerIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("CustomerIdNo")),
                                  .DueDate = AATM.DataLayer.AdoNet.Extensions.AsDate(reader("DueDate")),
                                  .IdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("IdNo")),
                                  .PatientIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("PatientIdNo")),
                                  .Posted = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Posted")),
                                  .TransactionDate = AATM.DataLayer.AdoNet.Extensions.AsDate(reader("TransactionDate")),
                                  .VatAmount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("VatAmount")),
                                  .VatNumber = AATM.DataLayer.AdoNet.Extensions.AsString(reader("VatNumber")),
                                  .WarehouseIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("WarehouseIdNo"))
                                }

        Private Function Take(Sale As Sale) As Object()
            Return New Object() {
                                    "Amount", Sale.Amount,
                                    "Cancelled", Sale.Cancelled,
                                    "CustomerIdNo", Sale.CustomerIdNo,
                                    "DueDate", Sale.DueDate,
                                    "IdNo", Sale.IdNo,
                                    "PatientIdNo", Sale.PatientIdNo,
                                    "Posted", Sale.Posted,
                                    "TransactionDate", Sale.TransactionDate,
                                    "VatAmount", Sale.VatAmount,
                                    "VatNumber", Sale.VatNumber,
                                    "WarehouseIdNo", Sale.WarehouseIdNo
                                 }
        End Function

    End Class

End Namespace