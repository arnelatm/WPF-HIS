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
        Implements IDao(Of Purchase), IPurchaseDao, IDaoPosting, IDaoAutoReference(Of Int32)

        Private _fieldList As String
        Private _tableName As String

        ' ReSharper disable once InconsistentNaming
        Private ReadOnly Db As New Db()
        Private ReadOnly _purchaseOrder As Boolean

        Public Sub New(parameter As Object)
            _purchaseOrder = parameter(0)
            If _purchaseOrder Then
                _tableName = "PurchaseOrder"
                _fieldList = "Amount,Approved,Cancelled,DateCreated,Disapproved,IdNo,TransactionDate,ReferenceNo,SupplierIdNo,TransactionDate,UserIdNo,VatAmount,VatNumber,WarehouseIdNo"
            Else
                _tableName = "Purchase"
                _fieldList = "Amount,Cancelled,DateCreated,DueDate,IdNo,InvoiceDate,InvoiceNo,Posted,ReferenceNo,SupplierIdNo,TransactionDate,UserIdNo,VatAmount,VatNumber,WarehouseIdNo"
            End If
        End Sub

        Public Function GetRecordByIdNo(idNo) As Purchase _
        Implements IDao(Of Purchase).GetRecordByIdNo
            Dim sql As String = " SELECT " & _fieldList & " FROM " & _tableName & " WHERE IdNo = @IdNo And BranchIdNo = @BranchIdNo"
            Dim params() As Object = {"@IdNo", idNo, "@BranchIdNo", GlobalVariables.BranchIdNo}
            Dim data
            If _purchaseOrder Then
                data = Db.Read(sql, MakePo, params).FirstOrDefault()
            Else
                data = Db.Read(sql, Make, params).FirstOrDefault()
            End If
            If data IsNot Nothing Then
                Dim purchaseDetailDao
                If _purchaseOrder Then
                    purchaseDetailDao = New PurchaseDetailDao({True, "UpdatePurchaseOrderDetailTVP", "InsertPurchaseOrderDetailTVP"})
                Else
                    purchaseDetailDao = New PurchaseDetailDao({False, "UpdatePurchaseDetailTVP", "InsertPurchaseDetailTVP"})
                End If
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
            Dim retVal As Int32 = 0
            Dim sql As String
            If _purchaseOrder Then
                sql = "UPDATE [PurchaseOrder] Set " &
                    "Amount = @Amount," &
                    "Approved = @Approved," &
                    "Cancelled = @Cancelled," &
                    "Disapproved = @Disapproved," &
                    "ReferenceNo = @ReferenceNo," &
                    "SupplierIdNo = @SupplierIdNo," &
                    "TransactionDate = @TransactionDate," &
                    "UserIdNo = @UserIdNo," &
                    "VatAmount = @VatAmount," &
                    "VatNumber = @VatNumber, " &
                    "WarehouseIdNo = @WarehouseIdNo " &
                    "WHERE IdNo = @IdNo"
                retVal = Db.Update(sql, TakePo(Purchase))
            Else
                sql = "UPDATE [Purchase] Set " &
                    "Amount = @Amount," &
                    "Cancelled = @Cancelled," &
                    "DueDate = @DueDate," &
                    "InvoiceDate = @InvoiceDate," &
                    "InvoiceNo = @InvoiceNo," &
                    "Posted = @Posted," &
                    "ReferenceNo = @ReferenceNo," &
                    "SupplierIdNo = @SupplierIdNo," &
                    "TransactionDate = @TransactionDate," &
                    "UserIdNo = @UserIdNo," &
                    "VatAmount = @VatAmount," &
                    "VatNumber = @VatNumber, " &
                    "WarehouseIdNo = @WarehouseIdNo " &
                    "WHERE IdNo = @IdNo"
                retVal = Db.Update(sql, Take(Purchase))
            End If
            If retVal > 0 Then
                UpdateReferenceNumber(Purchase.IdNo)
            End If
            Return retVal
        End Function

        Public Function AddRecord(ByRef Purchase As Purchase) As Integer _
            Implements IDao(Of Purchase).AddRecord
            Dim sql As String
            If _purchaseOrder Then
                sql = "INSERT INTO [PurchaseOrder] " &
                    " (Amount,Approved,BranchIdNo,Cancelled,Disapproved,ReferenceNo,SupplierIdNo,TransactionDate,UserIdNo,VatAmount,VatNumber,WarehouseIdNo)" &
                    " VALUES (@Amount,@Approved,@BranchIdNo,@Cancelled,@Disapproved,@ReferenceNo,@SupplierIdNo,@TransactionDate,@UseridNo,@VatAmount,@VatNumber,@WarehouseIdNo)"
                Return Db.Insert(sql, TakePo(Purchase))
            Else
                sql = "INSERT INTO [Purchase] " &
                    " (Amount,BranchIdNo,Cancelled,DueDate,InvoiceDate,InvoiceNo,Posted,ReferenceNo,SupplierIdNo,TransactionDate,UserIdNo,VatAmount,VatNumber,WarehouseIdNo)" &
                    " VALUES (@Amount,@BranchIdNo,@Cancelled,@DueDate,@InvoiceDate,@InvoiceNo,@Posted,@ReferenceNo,@SupplierIdNo,@TransactionDate,@UseridNo,@VatAmount,@VatNumber,@WarehouseIdNo)"
                Return Db.Insert(sql, Take(Purchase))
            End If

        End Function

        Private ReadOnly Make As Func(Of IDataReader, Purchase) =
                                    Function(reader) _
            New Purchase({_purchaseOrder}) With {.Amount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Amount")),
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

        Private ReadOnly MakePo As Func(Of IDataReader, Purchase) =
                                    Function(reader) _
            New Purchase({_purchaseOrder}) With {.Amount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Amount")),
                                  .Approved = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Approved")),
                                  .Cancelled = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Cancelled")),
                                  .Disapproved = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Disapproved")),
                                  .IdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("IdNo")),
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

        Private Function TakePo(Purchase As Purchase) As Object()
            Return New Object() {
                                    "Amount", Purchase.Amount,
                                    "Approved", Purchase.Approved,
                                    "BranchIdNo", GlobalVariables.BranchIdNo,
                                    "Cancelled", Purchase.Cancelled,
                                    "Disapproved", Purchase.Disapproved,
                                    "IdNo", Purchase.IdNo,
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
            command1.Add("Insert into Inventory (BranchIdNo,TransactionIdNo,ProductIdNo,QtyOnHand,UnitCost,TotalCost,BatchNo,ExpiryDate,WarehouseIdNo,TransactionType,UnitSalesPrice) " &
                         "Select @BranchIdNo,a.IdNo,a.ProductIdNo,IIf(c.UnitQty=0,0,Cast(a.Quantity+a.BonusQuantity As Decimal(12,2)) * c.BaseQty / c.UnitQty)," &
                         "a.NetAmount / (cast((a.Quantity+a.BonusQuantity) As Decimal(12,2)) * c.BaseQty / c.UnitQty), a.NetAmount , a.BatchNo, a.ExpiryDate, b.WarehouseIdNo, 'P' ," &
                         "IIf(c.BaseQty = 0, 0, a.UnitSalesPrice * c.UnitQty / c.BaseQty) " &
                         "From PurchaseDetail a Left Join Purchase b On a.PurchaseIdNo = b.IdNo " &
                         "Left Join ProductUnit_View c On a.ProductIdNo = c.ProductIdNo And a.UnitIdNo = c.UnitIdNo " &
                         "where a.PurchaseIdNo = @IdNo", {"@IdNo", idNo, "@BranchIdNo", GlobalVariables.BranchIdNo})
            commands.Add(command1)
            command2.Add("Update Purchase set Posted = 1 where IdNo = @IdNo", {"@IdNo", idNo})
            commands.Add(command2)
            retVal = Db.ExecuteNonQueryCommands("PostPurchase", commands)
            Return retVal
        End Function



        Public Function UpdateReferenceNumber(ByRef idNo As Int32) As Integer Implements IDaoAutoReference(Of Int32).UpdateReferenceNumber
            Dim retVal As Integer
            Dim sql1 As String
            Dim sql2 As String
            Dim series = IIf(_purchaseOrder, "PurchaseOrder", "Purchase")
            Dim maxlength As Int16
            If Db.Scalar("Select Count(*) from Series where SeriesName = '" & series & "'") < 1 Then
                maxlength = 6
                Dim sql As String = "INSERT INTO [Series] " &
                    " (SeriesName,Value,MaxLength,Prefix,Description)" &
                    " VALUES (@SeriesName,@Value,@MaxLength,@Prefix,@Description)"
                Dim params() As Object = {"@SeriesName", series,
                                          "@Value", 0,
                                          "@MaxLength", maxlength,
                                          "@Prefix", "",
                                          "@Description", IIf(_purchaseOrder, "Purchase Order Series", "Purchase Series")
                                         }
                retVal = Db.Insert(sql, params)
                If retVal < 0 Then
                    Return retVal
                End If
            Else
                maxlength = Db.Scalar("Select MaxLength from Series where SeriesName = '" & series & "'")
            End If
            sql1 = "Update [Series] set Value = Value + 1 where SeriesName = '" & series & "'"
            sql2 = "Update " & IIf(_purchaseOrder, "PurchaseOrder", "Purchase") & " set ReferenceNo = RIGHT(Concat(Replicate('0'," & maxlength & "),(select value from series where seriesName = '" & series & "'))," & maxlength & ") where IdNo = " & idNo
            retVal = Db.ExecuteSqlTransaction("UpdatePurchaseReferenceNumber", sql1, sql2)
            Return retVal
        End Function

    End Class

End Namespace