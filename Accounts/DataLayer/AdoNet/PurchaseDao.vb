Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub
Imports Microsoft.Office.Interop.Excel

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
        Private ReadOnly _purchaseReturn As Boolean

        Public Sub New()

        End Sub

        Public Sub New(ParamArray parameter As Object())
            _purchaseOrder = parameter(0)(0)
            _purchaseReturn = parameter(0)(1)
            If _purchaseOrder Then
                _tableName = "PurchaseOrder"
                _fieldList = "Amount,Approved,Cancelled,DateCreated,Disapproved,IdNo,Notes,Posted,ReferenceNo,SupplierIdNo,TransactionDate,UserIdNo,VatAmount,VatNumber,WarehouseIdNo"
            Else
                _tableName = "Purchase"
                _fieldList = "Amount,Cancelled,DateCreated,DueDate,IdNo,InvoiceDate,InvoiceNo,Notes,Posted,PurchaseReturn,ReferenceNo,SupplierIdNo,TransactionDate,UserIdNo,VatAmount,VatNumber,WarehouseIdNo"
            End If
        End Sub

        Public Function GetRecordByIdNo(idNo) As Purchase _
        Implements IDao(Of Purchase).GetRecordByIdNo
            Dim sql As String
            Dim params() As Object = {"@IdNo", idNo, "@BranchIdNo", GlobalVariables.BranchIdNo}
            If _purchaseOrder Then
                sql = " SELECT " & _fieldList & " FROM " & _tableName & " WHERE IdNo = @IdNo And BranchIdNo = @BranchIdNo"
                params = {"@IdNo", idNo, "@BranchIdNo", GlobalVariables.BranchIdNo}
            Else
                sql = " SELECT " & _fieldList & " FROM " & _tableName & " WHERE IdNo = @IdNo And BranchIdNo = @BranchIdNo And PurchaseReturn = @PurchaseReturn"
                params = {"@IdNo", idNo, "@BranchIdNo", GlobalVariables.BranchIdNo, "@PurchaseReturn", _purchaseReturn}
            End If

            Dim data
            If _purchaseOrder Then
                data = Db.Read(sql, MakePo, params).FirstOrDefault()
            Else
                data = Db.Read(sql, Make, params).FirstOrDefault()
            End If
            If data IsNot Nothing Then
                Dim purchaseDetailDao
                If _purchaseOrder Then
                    purchaseDetailDao = New PurchaseDetailDao({True, False}) ' "UpdatePurchaseOrderDetailTVP", "InsertPurchaseOrderDetailTVP"})
                Else
                    If _purchaseReturn Then
                        purchaseDetailDao = New PurchaseDetailDao({False, True})
                    Else
                        purchaseDetailDao = New PurchaseDetailDao({False, False})
                    End If
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
                    "Notes = @Notes," &
                    "Posted = @Posted," &
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
                    "Notes = @Notes," &
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
            Dim retVal As Int32
            If _purchaseOrder Then
                sql = "INSERT INTO [PurchaseOrder] " &
                    " (Amount,Approved,BranchIdNo,Cancelled,Disapproved,Notes,Posted,ReferenceNo,SupplierIdNo,TransactionDate,UserIdNo,VatAmount,VatNumber,WarehouseIdNo)" &
                    " VALUES (@Amount,@Approved,@BranchIdNo,@Cancelled,@Disapproved,@Notes,@Posted,@ReferenceNo,@SupplierIdNo,@TransactionDate,@UseridNo,@VatAmount,@VatNumber,@WarehouseIdNo)"
                retVal = Db.Insert(sql, TakePo(Purchase))
            Else
                sql = "INSERT INTO [Purchase] " &
                    " (Amount,BranchIdNo,Cancelled,DueDate,InvoiceDate,InvoiceNo,Notes,Posted,PurchaseReturn,ReferenceNo,SupplierIdNo,TransactionDate,UserIdNo,VatAmount,VatNumber,WarehouseIdNo)" &
                    " VALUES (@Amount,@BranchIdNo,@Cancelled,@DueDate,@InvoiceDate,@InvoiceNo,@Notes,@Posted,@PurchaseReturn,@ReferenceNo,@SupplierIdNo,@TransactionDate,@UseridNo,@VatAmount,@VatNumber,@WarehouseIdNo)"
                retVal = Db.Insert(sql, Take(Purchase))
            End If
            If retVal > 0 Then
                UpdateReferenceNumber(retVal)
            End If
            Return retVal
        End Function

        'Private mkParam As Object = {{_purchaseOrder, _purchaseReturn}}

        Private ReadOnly Make As Func(Of IDataReader, Purchase) =
                                    Function(reader) _
            New Purchase({{_purchaseOrder, _purchaseReturn}}) With {.Amount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Amount")),
                                  .Cancelled = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Cancelled")),
                                  .DueDate = AATM.DataLayer.AdoNet.Extensions.AsDate(reader("DueDate")),
                                  .IdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("IdNo")),
                                  .InvoiceDate = AATM.DataLayer.AdoNet.Extensions.AsDate(reader("InvoiceDate")),
                                  .InvoiceNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("InvoiceNo")),
                                  .Notes = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Notes")),
                                  .Posted = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Posted")),
                                  .PurchaseReturn = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("PurchaseReturn")),
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
            New Purchase({{_purchaseOrder, _purchaseReturn}}) With {.Amount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Amount")),
                                  .Approved = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Approved")),
                                  .Cancelled = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Cancelled")),
                                  .Disapproved = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Disapproved")),
                                  .IdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("IdNo")),
                                  .Notes = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Notes")),
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
                                    "Notes", Purchase.Notes,
                                    "Posted", Purchase.Posted,
                                    "PurchaseReturn", _purchaseReturn,
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
                                    "Notes", Purchase.Notes,
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
            Dim purchaseReturn As Boolean
            Dim retVal As Boolean
            Dim spResult As Integer

            purchaseReturn = GetField(Of Boolean, Int32)(idNo, "Purchase", "IdNo", "PurchaseReturn")
            If purchaseReturn Then
                Dim purchase As Purchase = GetRecordByIdNo(idNo)
                Dim parameters As Object = {"@PurchaseIdNo", purchase.IdNo,
                                        "@BranchIdNo", GlobalVariables.BranchIdNo,
                                        "@WarehouseIdNo", purchase.WarehouseIdNo}
                'spResult = RunSpWithRollBack("spPostPurchaseReturn", parameters)
                spResult = Db.RunSqlSpWithRollBack("spPostPurchaseReturn", parameters)
            Else
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
                spResult = Db.ExecuteNonQueryCommands("PostPurchase", commands)
            End If
            If spResult > 0 Then
                retVal = True
            Else
                retVal = False
            End If
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
                                          "@Description", IIf(_purchaseOrder, "Purchase Order Series", IIf(_purchaseReturn, "Purchase Return Series", "Purchase Series"))
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

    Public Class PurchaseOrderApprovalDao
        Inherits AccountsDao
        Implements IDaoParametrized(Of PurchaseOrderApproval)

        Private ReadOnly _db As New Db()

        Public Overrides Function GetDB()
            Return _db
        End Function


        Public Function GetParametrized(Of TM)(parameter As Object, Optional sortExpression As String = Nothing) As PurchaseOrderApproval Implements IDaoParametrized(Of PurchaseOrderApproval).GetParametrized
            Dim sql As String
            Dim data As New PurchaseOrderApproval
            Dim params() As Object = {"@BranchIdNo", GlobalVariables.BranchIdNo}
            sql = $"SELECT IdNo,ReferenceNo,TransactionDate,WarehouseIdNo,Amount,Notes,Posted,SupplierIdNo,Cancelled,DateCreated,UserIdNo from PurchaseOrder where BranchIdNo = @BranchIdNo and Posted = 0 and Approved = 0"
            _db.SetConnectionString("ISPDATA")
            data.UnpostedPurchaseOrders = _db.Read(sql, Make, params).ToList()
            Return data
        End Function


        Private Shared ReadOnly Make As Func(Of IDataReader, Purchase) = Function(reader) New Purchase() With
                                {.Amount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Amount")),
                                  .Cancelled = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Cancelled")),
                                  .DateCreated = AATM.DataLayer.AdoNet.Extensions.AsDate(reader("DateCreated")),
                                  .IdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("IdNo")),
                                  .Notes = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Notes")),
                                  .ReferenceNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ReferenceNo")),
                                  .TransactionDate = AATM.DataLayer.AdoNet.Extensions.AsDate(reader("TransactionDate")),
                                  .UserIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("UserIdNo")),
                                  .SupplierIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("SupplierIdNo")),
                                  .WarehouseIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("WarehouseIdNo"))
                                }

    End Class


End Namespace