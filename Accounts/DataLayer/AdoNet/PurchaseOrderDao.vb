Imports System.Data.SqlClient
Imports System.Web.UI.WebControls.Expressions
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.DataLayer.AdoNet.Db
Imports AATM.Libraries.GlobalFuncNSub
Imports Microsoft.Office.Interop.Excel

Namespace DataLayer.AdoNet
    ' Data access object for PurchaseOrder
    ' ** DAO Pattern

    Public Class PurchaseOrderDao
        Inherits AccountsDao
        Implements IDao(Of PurchaseOrder), IDaoAutoReference(Of Int32)


        Private Const FieldList = "Amount," &
                                  "Cancelled," &
                                  "DateCreated," &
                                  "IdNo," &
                                  "Notes," &
                                  "Posted," &
                                  "ReferenceNo," &
                                  "SupplierIdNo," &
                                  "TransactionDate," &
                                  "UserIdNo," &
                                  "WarehouseIdNo," &
                                  "SupplierIdNo"

        ' ReSharper disable once InconsistentNaming
        Private ReadOnly Db As New Db()

        Public Function GetRecordByIdNo(idNo) As PurchaseOrder _
        Implements IDao(Of PurchaseOrder).GetRecordByIdNo
            Dim sql As String = " Select " & FieldList & " from PurchaseOrder " & " where IdNo = @IdNo and BranchIdNo = @BranchIdNo"
            Dim params() As Object = {"@IdNo", idNo, "@BranchIdNo", GlobalVariables.BranchIdNo}
            Dim data = Db.Read(sql, Make, params).FirstOrDefault()
            If data IsNot Nothing Then
                Dim itDao = New PurchaseOrderDetailDao
                data.PurchaseOrderDetails = itDao.GetRecordsWithGroupIdNo(idNo, "Sequence")
            End If
            Return data
        End Function

        Public Function UpdateRecord(ByRef PurchaseOrder As PurchaseOrder) As Integer _
            Implements IDao(Of PurchaseOrder).UpdateRecord
            Dim retVal As Int32 = 0
            Dim sql As String =
                    "UPDATE [PurchaseOrder] Set " &
                    "Amount = @Amount," &
                    "Cancelled = @Cancelled," &
                    "Notes = @Notes," &
                    "Posted = @Posted," &
                    "ReferenceNo = @ReferenceNo," &
                    "SupplierIdNo = @SupplierIdNo," &
                    "TransactionDate = @TransactionDate," &
                    "UserIdNo = @UserIdNo," &
                    "WarehouseIdNo = @WarehouseIdNo " &
                    "WHERE IdNo = @IdNo"
            retVal = Db.Update(sql, Take(PurchaseOrder))
            If retVal > 0 Then
                UpdateReferenceNumber(PurchaseOrder.IdNo)
            End If
            Return retVal
        End Function

        Public Function AddRecord(ByRef PurchaseOrder As PurchaseOrder) As Integer _
            Implements IDao(Of PurchaseOrder).AddRecord
            Dim retVal As Int32 = 0
            Dim sql As String =
                    " INSERT INTO [PurchaseOrder] " &
                    " (Amount,BranchIdNo,Cancelled,Notes,Posted,ReferenceNo,SupplierIdNo,TransactionDate,UserIdNo,WarehouseIdNo)" &
                    " VALUES (@Amount,@BranchIdNo,@Cancelled,@Notes,@Posted,@SupplierIdNo,@ReferenceNo,@TransactionDate,@UseridNo,@WarehouseIdNo)"
            retVal = Db.Insert(sql, Take(PurchaseOrder))
            If retVal > 0 Then
                UpdateReferenceNumber(retVal)
            End If
            Return retVal
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PurchaseOrder) =
                                    Function(reader) _
            New PurchaseOrder() With {.Amount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Amount")),
                                  .Cancelled = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Cancelled")),
                                  .IdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("IdNo")),
                                  .Notes = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Notes")),
                                  .Posted = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Posted")),
                                  .ReferenceNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ReferenceNo")),
                                  .SupplierIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("SupplierIdNo")),
                                  .TransactionDate = AATM.DataLayer.AdoNet.Extensions.AsDate(reader("TransactionDate")),
                                  .UserIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("UserIdNo")),
                                  .WarehouseIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("WarehouseIdNo"))
                                }

        Private Function Take(PurchaseOrder As PurchaseOrder) As Object()
            Return New Object() {
                                    "Amount", PurchaseOrder.Amount,
                                    "BranchIdNo", GlobalVariables.BranchIdNo,
                                    "Cancelled", PurchaseOrder.Cancelled,
                                    "IdNo", PurchaseOrder.IdNo,
                                    "Notes", PurchaseOrder.Notes,
                                    "Posted", PurchaseOrder.Posted,
                                    "ReferenceNo", PurchaseOrder.ReferenceNo,
                                    "SupplierIdNo", PurchaseOrder.SupplierIdNo,
                                    "TransactionDate", PurchaseOrder.TransactionDate,
                                    "UserIdNo", PurchaseOrder.UserIdNo,
                                    "WarehouseIdNo", PurchaseOrder.WarehouseIdNo
                                 }
        End Function

        Public Function UpdateReferenceNumber(ByRef idNo As Int32) As Integer Implements IDaoAutoReference(Of Int32).UpdateReferenceNumber
            Dim retVal As Integer
            Dim sql1 As String
            Dim sql2 As String
            Dim series = "PurchaseOrder"
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
            sql2 = "Update [PurchaseOrder] set ReferenceNo = RIGHT(Concat(Replicate('0'," & maxlength & "),(select value from series where seriesName = '" & series & "'))," & maxlength & ") where IdNo = " & idNo
            retVal = Db.ExecuteSqlTransaction("UpdateInvReferenceNumber", sql1, sql2)
            Return retVal
        End Function

    End Class



End Namespace