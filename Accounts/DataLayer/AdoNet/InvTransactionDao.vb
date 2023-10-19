
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls.Expressions
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.DataLayer.AdoNet.Db
Imports AATM.Libraries.GlobalFuncNSub
Imports Microsoft.Office.Interop.Excel

Namespace DataLayer.AdoNet
    ' Data access object for InvTransaction
    ' ** DAO Pattern

    Public Class InvTransactionDao
        Inherits AccountsDao
        Implements IDao(Of InvTransaction), IDaoPosting, IDaoChild(Of Inventory), IDaoAutoReference(Of Int32), IDaoGetRecordsWithParams(Of Inventory)


        Private Const FieldList = "Amount," &
                                  "Cancelled," &
                                  "DateCreated," &
                                  "IdNo," &
                                  "InvTransTypeIdNo," &
                                  "Notes," &
                                  "Posted," &
                                  "ReferenceNo," &
                                  "TransactionDate," &
                                  "UserIdNo," &
                                  "WarehouseIdNo," &
                                  "WarehouseToIdNo"

        ' ReSharper disable once InconsistentNaming
        Private ReadOnly Db As New Db()

        Public Function GetRecordByIdNo(idNo) As InvTransaction _
        Implements IDao(Of InvTransaction).GetRecordByIdNo
            Dim sql As String = " Select " & FieldList & " from InvTransaction " & " where IdNo = @IdNo and BranchIdNo = @BranchIdNo"
            Dim params() As Object = {"@IdNo", idNo, "@BranchIdNo", GlobalVariables.BranchIdNo}
            Dim data = Db.Read(sql, Make, params).FirstOrDefault()
            If data IsNot Nothing Then
                Dim itDao = New InvTransactionDetailDao
                data.InvTransactionDetails = itDao.GetRecordsWithGroupIdNo(idNo, "Sequence")
            End If
            Return data
        End Function

        Public Function UpdateRecord(ByRef InvTransaction As InvTransaction) As Integer _
            Implements IDao(Of InvTransaction).UpdateRecord
            Dim retVal As Int32 = 0
            Dim sql As String =
                    "UPDATE [InvTransaction] Set " &
                    "Amount = @Amount," &
                    "Cancelled = @Cancelled," &
                    "InvTransTypeIdNo = @InvTransTypeIdNo," &
                    "Notes = @Notes," &
                    "Posted = @Posted," &
                    "ReferenceNo = @ReferenceNo," &
                    "TransactionDate = @TransactionDate," &
                    "UserIdNo = @UserIdNo," &
                    "WarehouseIdNo = @WarehouseIdNo, " &
                    "WarehouseToIdNo = @WarehouseToIdNo " &
                    "WHERE IdNo = @IdNo"
            retVal = Db.Update(sql, Take(InvTransaction))
            If retVal > 0 Then
                UpdateReferenceNumber(InvTransaction.IdNo)
            End If
            Return retVal
        End Function

        Public Function AddRecord(ByRef InvTransaction As InvTransaction) As Integer _
            Implements IDao(Of InvTransaction).AddRecord
            Dim retVal As Int32 = 0
            Dim sql As String =
                    " INSERT INTO [InvTransaction] " &
                    " (Amount,BranchIdNo,Cancelled,InvTransTypeIdNo,Notes,Posted,ReferenceNo,TransactionDate,UserIdNo,WarehouseIdNo,WarehouseToIdNo)" &
                    " VALUES (@Amount,@BranchIdNo,@Cancelled,@InvTransTypeIdNo,@Notes,@Posted,@ReferenceNo,@TransactionDate,@UseridNo,@WarehouseIdNo,@WarehouseToIdNo)"
            retVal = Db.Insert(sql, Take(InvTransaction))
            If retVal > 0 Then
                UpdateReferenceNumber(retVal)
            End If
            Return retVal
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, InvTransaction) =
                                    Function(reader) _
            New InvTransaction() With {.Amount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Amount")),
                                  .Cancelled = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Cancelled")),
                                  .IdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("IdNo")),
                                  .InvTransTypeIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("InvTransTypeIdNo")),
                                  .Notes = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Notes")),
                                  .Posted = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Posted")),
                                  .ReferenceNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ReferenceNo")),
                                  .TransactionDate = AATM.DataLayer.AdoNet.Extensions.AsDate(reader("TransactionDate")),
                                  .UserIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("UserIdNo")),
                                  .WarehouseIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("WarehouseIdNo")),
                                  .WarehouseToIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("WarehouseToIdNo"))
                                }

        Private Function Take(InvTransaction As InvTransaction) As Object()
            Return New Object() {
                                    "Amount", InvTransaction.Amount,
                                    "BranchIdNo", GlobalVariables.BranchIdNo,
                                    "Cancelled", InvTransaction.Cancelled,
                                    "InvTransTypeIdNo", InvTransaction.InvTransTypeIdNo,
                                    "IdNo", InvTransaction.IdNo,
                                    "Notes", InvTransaction.Notes,
                                    "Posted", InvTransaction.Posted,
                                    "ReferenceNo", InvTransaction.ReferenceNo,
                                    "TransactionDate", InvTransaction.TransactionDate,
                                    "UserIdNo", InvTransaction.UserIdNo,
                                    "WarehouseIdNo", InvTransaction.WarehouseIdNo,
                                    "WarehouseToIdNo", InvTransaction.WarehouseToIdNo
                                 }
        End Function

        Public Function PostData(idNo As Integer) As Boolean Implements IDaoPosting.PostData
            Dim retVal As Boolean
            Dim commands As New List(Of DaoCommand)
            Dim invTransDetails As List(Of InvTransactionDetail)
            Dim itDao = New InvTransactionDetailDao
            invTransDetails = itDao.GetRecordsWithGroupIdNo(idNo)
            Dim InvTrans As InvTransaction = GetRecordByIdNo(idNo)
            Dim InventoryAction As String
            Dim warehouseToIdNo As Int16
            Dim sqls As New List(Of String)
            InventoryAction = GetField(Of String, Int16)(InvTrans.InvTransTypeIdNo, "InvTransType", "IdNo", "InventoryAction")
            warehouseToIdNo = InvTrans.WarehouseToIdNo
            Dim connection As New Db
            Dim transactionObj As New TransactionObject()
            transactionObj.CreateConnection("PostInvTransDetailTransfer", Db.GetConnectionString)
            Dim parameters As Object = {"@InvTransactionIdNo", idNo}
            Dim x As Int16 = Db.RunSqlStoredProcedure("spPostInvTransaction", parameters)
            retVal = IIf(x = 1, True, False)
            'retVal = IIf(Db.RunSqlStoredProcedure("spPostInvTransaction", parameters) = 1, True, False)
            Db.CloseTransaction(transactionObj, retVal)
            If Not retVal Then
                If InventoryAction = EnumToCode(InventoryActionSelection.Deduct) Or InventoryAction = EnumToCode(InventoryActionSelection.Transfer) Then
                    MessageBox.Show("Sorry, either quantity is zero or cannot find item in the inventory, no item(s) posted.")
                ElseIf InventoryAction = EnumToCode(InventoryActionSelection.Add) Then
                    MessageBox.Show("Sorry, cannot post these items, either product does not exist or quantity is zero, no item(s) posted.")
                End If
            End If
            Return retVal
        End Function

        'Private Function ConvertToBaseUnitPrice(product As ProductModel, invTransactionDetail As InvTransactionDetailView)
        '    Dim baseUnitPrice As Decimal
        '    If invTransactionDetail.UnitIdNo = product.BaseUnitIdNo Then
        '        baseUnitPrice = invTransactionDetail.UnitCost
        '    Else
        '        Dim productUnitIdNo As Int32 = GetRecordFieldWith2KeyG(Of Int32, Int16, Int32)(product.IdNo, invTransactionDetail.UnitIdNo, "ProductUnit", "ProductIdNo", "UnitIdNo", "IdNo")
        '        Dim pUnitInfo = GetFieldsWithIdNo(productUnitIdNo, "ProductUnit", "UnitQty,BaseQty")
        '        baseUnitPrice = IIf(pUnitInfo.BaseQty = 0, 0, invTransactionDetail.UnitCost * pUnitInfo.BaseQty / pUnitInfo.UnitQty)
        '    End If
        '    Return baseUnitPrice
        'End Function

        Private Shared ReadOnly MakeInventory As Func(Of IDataReader, Inventory) =
                                    Function(reader) _
            New Inventory() With {
                                  .BatchNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("BatchNo")),
                                  .ExpiryDate = AATM.DataLayer.AdoNet.Extensions.AsDate(reader("ExpiryDate")),
                                  .IdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("IdNo")),
                                  .ProductIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("ProductIdNo")),
                                  .QtyOnHand = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("QtyOnHand")),
                                  .TotalCost = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("TotalCost")),
                                  .TransactionIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("TransactionIdNo")),
                                  .UnitCost = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("UnitCost")),
                                  .UnitSalesPrice = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("UnitSalesPrice")),
                                  .WarehouseIdNo = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("WarehouseIdNo"))
                                  }


        'Public Function GetRecordsWithGroupIdNo(idNo, Optional sortExpression = Nothing) As List(Of Inventory) Implements IDaoChild(Of Inventory).GetRecordsWithGroupIdNo
        '    If sortExpression Is Nothing Then
        '        sortExpression = "IdNo"
        '    End If
        '    Dim sql As String =
        '            "select GroupAccess.IdNo , GroupAccess.SecurityGroupIdNo ,  SecurityObject.IdNo as 'SecurityObjectIdNo' , SecurityObject.SecurityObjectName, GroupAccess.Visible, GroupAccess.Editable from SecurityObject  " &
        '            "left join groupAccess " &
        '            "on SecurityObject.IdNo = GroupAccess.SecurityObjectIdNo  and SecurityGroupIdNo = @SecurityGroupIdNo " &
        '            "Order By " & sortExpression & " ASC "
        '    Dim params() As Object = {"@SecurityGroupIdNo", idNo}
        '    Return Db.Read(sql, Make, params).ToList()
        'End Function

        Public Function UpdateReferenceNumber(ByRef idNo As Int32) As Integer Implements IDaoAutoReference(Of Int32).UpdateReferenceNumber
            Dim retVal As Integer
            Dim sql1 As String
            Dim sql2 As String
            Dim series = "InventoryTransaction"
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
                                          "@Description", "Inventory Transaction Series"
                                         }
                retVal = Db.Insert(sql, params)
                If retVal < 0 Then
                    Return retVal
                End If
            Else
                maxlength = Db.Scalar("Select MaxLength from Series where SeriesName = '" & series & "'")
            End If
            sql1 = "Update [Series] set Value = Value + 1 where SeriesName = '" & series & "'"
            sql2 = "Update [InvTransaction] set ReferenceNo = RIGHT(Concat(Replicate('0'," & maxlength & "),(select value from series where seriesName = '" & series & "'))," & maxlength & ") where IdNo = " & idNo
            retVal = Db.ExecuteSqlTransaction("UpdateInvReferenceNumber", sql1, sql2)
            Return retVal
        End Function

        Public Function GetRecordsWithParams(parameters As Object) As List(Of Inventory) Implements IDaoGetRecordsWithParams(Of Inventory).GetRecordsWithParams
            Dim sortExpression As String = ""
            Dim filter As String = ""
            If parameters.InventoryAction = EnumToCode(InventoryActionSelection.Deduct) Or
               parameters.InventoryAction = EnumToCode(InventoryActionSelection.Transfer) Or
               parameters.InventoryAction = EnumToCode(InventoryActionSelection.Request) Then
                sortExpression = "ExpiryDate"
                filter = "ProductIdNo = @ProductIdNo and QtyOnHand <> 0 and WarehouseIdNo = @WarehouseIdNo"
            ElseIf parameters.InventoryAction = EnumToCode(InventoryActionSelection.Add) Then
                sortExpression = "ExpiryDate Desc"
                filter = "ProductIdNo = @ProductIdNo and WarehouseIdNo = @WarehouseIdNo and ExpiryDate > CAST( GETDATE() AS Date )"
            End If
            Dim sql As String = "select BatchNo, ExpiryDate, IdNo, TotalCost, ProductIdNo, TransactionIdNo, QtyOnHand, UnitCost, UnitSalesPrice, WarehouseIdNo from Inventory_View " &
                    "where " & filter & " Order By " + sortExpression
            Dim params() As Object = {"@ProductIdNo", parameters.ProductIdNo, "@WarehouseIdNo", parameters.WarehouseIdNo}
            Return Db.Read(sql, MakeInventory, params).ToList()
        End Function

        Public Function GetRecordsWithGroupIdNo(idNo As Object, Optional sortExpression As Object = Nothing) As List(Of Inventory) Implements IDaoChild(Of Inventory).GetRecordsWithGroupIdNo
            If sortExpression Is Nothing Then
                sortExpression = "IdNo"
            End If
            Dim sql As String = "select BatchNo, ExpiryDate, IdNo, TotalCost, ProductIdNo, TransactionIdNo, QtyOnHand, UnitCost, UnitSalesPrice, WarehouseIdNo from Inventory_View " &
                    "where ProductIdNo = @ProductIdNo And QtyOnHand <> 0 And BranchIdNo = @BranchIdNo and WarehouseIdNo = @WarehouseIdNo Order By " + sortExpression
            Dim params() As Object = {"@ProductIdNo", idNo, "@BranchIdNo", GlobalVariables.BranchIdNo}
            Return Db.Read(sql, MakeInventory, params).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As Data.DataTable, groupIdNo As Integer) As Integer Implements IDaoChild(Of Inventory).DelUpdateTvp
            Throw New NotImplementedException()
        End Function

        Public Function InsertTvp(ByRef tvpTable As Data.DataTable) As Integer Implements IDaoChild(Of Inventory).InsertTvp
            Throw New NotImplementedException()
        End Function

    End Class

    Public Class InvRequestDao
        Inherits AccountsDao
        Implements IDaoParametrized(Of InvRequest)

        Private ReadOnly _db As New Db()

        Public Overrides Function GetDB()
            Return _db
        End Function


        Public Function GetParametrized(Of TM)(parameter As Object, Optional sortExpression As String = Nothing) As InvRequest Implements IDaoParametrized(Of InvRequest).GetParametrized
            Dim warehouseIdNo As Int16 = parameter(0)
            Dim sql As String = "SELECT WarehouseCode, WarehouseName from Warehouse where WarehouseIdNo = '" + warehouseIdNo.ToString() + "'"
            Dim data As New InvRequest
            Dim params() As Object = {"@WarehouseIdNo", warehouseIdNo, "@BranchIdNo", GlobalVariables.BranchIdNo}
            sql = $"SELECT IdNo,ReferenceNo,TransactionDate,WarehouseIdNo,WarehouseToIdNo,Amount,Notes,Posted,Cancelled,DateCreated,UserIdNo,InvTransTypeIdNo from InvTransaction where WarehouseIdNo = @WarehouseIdNo and InvTransTypeIdNo = 15 and BranchIdNo = @BranchIdNo and Posted = 0"
            _db.SetConnectionString("ISPDATA")
            data.InvTransactionRequests = _db.Read(sql, MakeInvTransRequests, params).ToList()
            Return data
        End Function


        Private Shared ReadOnly Make As Func(Of IDataReader, PmrInvestigation) = Function(reader) New PmrInvestigation() With
            {
            .DoctorName = AATM.DataLayer.AdoNet.Extensions.AsString(reader("EmpNameEnglish"))
            }

        Private Shared ReadOnly MakeInvTransRequests As Func(Of IDataReader, InvTransaction) = Function(reader) New InvTransaction() With
                                {.Amount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Amount")),
                                  .Cancelled = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Cancelled")),
                                  .DateCreated = AATM.DataLayer.AdoNet.Extensions.AsDate(reader("DateCreated")),
                                  .IdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("IdNo")),
                                  .InvTransTypeIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("InvTransTypeIdNo")),
                                  .Notes = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Notes")),
                                  .Posted = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Posted")),
                                  .ReferenceNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ReferenceNo")),
                                  .TransactionDate = AATM.DataLayer.AdoNet.Extensions.AsDate(reader("TransactionDate")),
                                  .UserIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("UserIdNo")),
                                  .WarehouseIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("WarehouseIdNo")),
                                  .WarehouseToIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("WarehouseToIdNo"))
                                }

    End Class

End Namespace