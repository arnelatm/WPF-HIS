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
        Implements IDao(Of Purchase), IPurchaseDao, IDaoPosting

        Private Const FieldList = "Amount," &
                                  "Cancelled," &
                                  "DateCreated," &
                                  "DueDate," &
                                  "IdNo," &
                                  "InvoiceDate," &
                                  "InvoiceNo," &
                                  "Posted," &
                                  "ReferenceNo," &
                                  "SupplierIdNo," &
                                  "TransactionDate," &
                                  "UserIdNo," &
                                  "VatAmount," &
                                  "VatNumber," &
                                  "WarehouseIdNo"


        ' ReSharper disable once InconsistentNaming
        Private ReadOnly Db As New Db()

        Public Function GetRecordByIdNo(idNo) As Purchase _
        Implements IDao(Of Purchase).GetRecordByIdNo
            Dim sql As String = " SELECT " & FieldList & " FROM [Purchase]" & " WHERE IdNo = @IdNo and BranchIdNo = @BranchIdNo"
            Dim params() As Object = {"@IdNo", idNo, "@BranchIdNo", GlobalVariables.BranchIdNo}
            Dim data = Db.Read(sql, Make, params).FirstOrDefault()
            If data IsNot Nothing Then
                Dim purchaseDetailDao = New PurchaseDetailDao
                data.PurchaseDetails = purchaseDetailDao.GetRecordsWithGroupIdNo(idNo, "sequence")
                If data.PurchaseDetails.Count() > 0 Then
                    Dim productIdNo As Int32 = data.PurchaseDetails(0).ProductIdNo
                    data.PurchaseHistory = GetPurchaseHistory(productIdNo)
                End If
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
                    "Cancelled = @Cancelled," &
                    "DueDate = @DueDate," &
                    "InvoiceDate = @InvoiceDate," &
                    "InvoiceNo = @InvoiceNo," &
                    "Posted = @Posted," &
                    "ReferenceNo = @Reference," &
                    "SupplierIdNo = @SupplierIdNo," &
                    "TransactionDate = @TransactionDate," &
                    "UserIdNo = @UserIdNo," &
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
                    " (Amount,BranchIdNo,Cancelled,DueDate,InvoiceDate,InvoiceNo,Posted,ReferenceNo,SupplierIdNo,TransactionDate,UserIdNo,VatAmount,VatNumber,WarehouseIdNo)" &
                    " VALUES (@Amount,@BranchIdNo,@Cancelled,@DueDate,@InvoiceDate,@InvoiceNo,@Posted,@ReferenceNo,@SupplierIdNo,@TransactionDate,@UseridNo,@VatAmount,@VatNumber,@WarehouseIdNo)"
            Return Db.Insert(sql, Take(Purchase))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Purchase) =
                                    Function(reader) _
            New Purchase() With {.Amount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Amount")),
                                  .Cancelled = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Cancelled")),
                                  .DueDate = AATM.DataLayer.AdoNet.Extensions.AsDate(reader("DueDate")),
                                  .IdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("IdNo")),
                                  .InvoiceDate = AATM.DataLayer.AdoNet.Extensions.AsDate(reader("InvoiceDate")),
                                  .InvoiceNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("InvoiceNo")),
                                  .Posted = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Posted")),
                                  .ReferenceNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ReferenceNo")),
                                  .SupplierIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("SupplierIdNo")),
                                  .TransactionDate = AATM.DataLayer.AdoNet.Extensions.AsDate(reader("TransactionDate")),
                                  .UserIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("UserIdNo")),
                                  .VatAmount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("VatAmount")),
                                  .VatNumber = AATM.DataLayer.AdoNet.Extensions.AsString(reader("VatNumber")),
                                  .WarehouseIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("WarehouseIdNo"))
                                }

        Private Function Take(Purchase As Purchase) As Object()
            Return New Object() {
                                    "Amount", Purchase.Amount,
                                    "BranchIdNo", GlobalVariables.BranchIdNo,
                                    "Cancelled", Purchase.Cancelled,
                                    "DueDate", Purchase.DueDate,
                                    "IdNo", Purchase.IdNo,
                                    "InvoiceDate", Purchase.InvoiceDate,
                                    "InvoiceNo", Purchase.InvoiceNo,
                                    "Posted", Purchase.Posted,
                                    "ReferenceNo", Purchase.ReferenceNo,
                                    "SupplierIdNo", Purchase.SupplierIdNo,
                                    "TransactionDate", Purchase.TransactionDate,
                                    "UserIdNo", Purchase.UserIdNo,
                                    "VatAmount", Purchase.VatAmount,
                                    "VatNumber", Purchase.VatNumber,
                                    "WarehouseIdNo", Purchase.WarehouseIdNo
                                 }
        End Function

        Public Function PostData(idNo As Integer) As Boolean Implements IDaoPosting.PostData

            Dim retVal As Boolean
            Dim commands As New List(Of DaoCommand)
            Dim command1, command2 As New DaoCommand
            command1.Add("Select Case a.IdNo,a.ProductIdNo,(a.Quantity+a.BonusQuantity) * c.BaseQty / c.UnitQty,b.WarehouseIdNo " &
                         "From PurchaseDetail a Left Join Purchase b On a.PurchaseIdNo = b.IdNo " &
                         "Left Join ProductUnit_View c On a.ProductIdNo = c.ProductIdNo And a.UnitIdNo = c.UnitIdNo ", {"@IdNo", idNo})
            'command1.Add("Insert into Inventory (PurchaseDetailIdNo,ProductIdNo,QtyOnHand,WarehouseIdNo) " &
            '            "select a.IdNo,a.ProductIdNo,a.Quantity+a.BonusQuantity,b.WarehouseIdNo from PurchaseDetail a " &
            '            "left join Purchase b on a.PurchaseIdNo = b.IdNo " &
            '            "where a.PurchaseIdNo = @IdNo", {"@IdNo", idNo})
            commands.Add(command1)
            command2.Add("Update Purchase set Posted = 1 where IdNo = @IdNo", {"@IdNo", idNo})
            commands.Add(command2)
            retVal = Db.ExecuteNonQueryCommands("PostPurchase", commands)
            Return retVal
        End Function
    End Class

End Namespace