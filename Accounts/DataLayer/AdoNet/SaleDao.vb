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
                                  "InvoiceNo," &
                                  "JournalIdNo," &
                                  "PatientIdNo," &
                                  "Posted," &
                                  "TransactionDate," &
                                  "UserIdNo," &
                                  "VatAmount," &
                                  "WarehouseIdNo"


        ' ReSharper disable once InconsistentNaming
        Private ReadOnly Db As New Db()

        Public Function GetRecordByIdNo(idNo) As Sale _
        Implements IDao(Of Sale).GetRecordByIdNo
            Dim sql As String = " SELECT " & FieldList &
                    " FROM [Sale]" &
                    " WHERE IdNo = @IdNo and BranchIdNo = @BranchIdNo"
            Dim params() As Object = {"@IdNo", idNo, "@BranchIdNo", GlobalVariables.BranchIdNo}
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
                    "BranchIdNo = @BranchIdNo," &
                    "Cancelled = @Cancelled," &
                    "CustomerIdNo = @CustomerIdNo," &
                    "DueDate = @DueDate," &
                    "InvoiceNo = @InvoiceNo," &
                    "JournalIdNo = @JournalIdNo," &
                    "PatientIdNo = @PatientIdNo," &
                    "Posted = @Posted," &
                    "TransactionDate = @TransactionDate," &
                    "UserIdNo = @UserIdNo," &
                    "VatAmount = @VatAmount," &
                    "WarehouseIdNo = @WarehouseIdNo " &
                    "WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(Sale))
        End Function

        Public Function AddRecord(ByRef Sale As Sale) As Integer _
            Implements IDao(Of Sale).AddRecord
            Dim sql As String =
                    " INSERT INTO [Sale] " &
                    " (Amount,BranchIdNo,Cancelled,CustomerIdNo,DueDate,InvoiceNo,JournalIdNo,PatientIdNo,Posted,TransactionDate,UserIdNo,VatAmount,WarehouseIdNo)" &
                    " VALUES (@Amount,@BranchIdNo,@Cancelled,@CustomerIdNo,@DueDate,@InvoiceNo,@JournalIdNo,@PatientIdNo,@Posted,@TransactionDate,@UserIdNo,@VatAmount,@WarehouseIdNo)"
            Return Db.Insert(sql, Take(Sale))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Sale) =
                                    Function(reader) _
            New Sale() With {.Amount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Amount")),
                                  .Cancelled = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Cancelled")),
                                  .CustomerIdNo = AATM.DataLayer.AdoNet.Extensions.AsNullable(Of Int32)(reader("CustomerIdNo")),
                                  .DueDate = AATM.DataLayer.AdoNet.Extensions.AsDate(reader("DueDate")),
                                  .IdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("IdNo")),
                                  .InvoiceNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("InvoiceNo")),
                                  .JournalIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("JournalIdNo")),
                                  .PatientIdNo = AATM.DataLayer.AdoNet.Extensions.AsNullable(Of Int32)(reader("PatientIdNo")),
                                  .Posted = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Posted")),
                                  .TransactionDate = AATM.DataLayer.AdoNet.Extensions.AsDate(reader("TransactionDate")),
                                  .UserIdNo = AATM.DataLayer.AdoNet.Extensions.AsDate(reader("UserIdNo")),
                                  .VatAmount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("VatAmount")),
                                  .WarehouseIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("WarehouseIdNo"))
                                }

        Private Function Take(Sale As Sale) As Object()
            Return New Object() {
                                    "Amount", Sale.Amount,
                                    "BranchIdNo", GlobalVariables.BranchIdNo,
                                    "Cancelled", Sale.Cancelled,
                                    "CustomerIdNo", Sale.CustomerIdNo,
                                    "DueDate", Sale.DueDate,
                                    "IdNo", Sale.IdNo,
                                    "InvoiceNo", Sale.InvoiceNo,
                                    "JournalIdNo", Sale.JournalIdNo,
                                    "PatientIdNo", Sale.PatientIdNo,
                                    "Posted", Sale.Posted,
                                    "TransactionDate", Sale.TransactionDate,
                                    "UserIdNo", Sale.UserIdNo,
                                    "VatAmount", Sale.VatAmount,
                                    "WarehouseIdNo", Sale.WarehouseIdNo
                                 }
        End Function

    End Class

End Namespace