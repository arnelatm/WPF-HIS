Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for InvTransaction
    ' ** DAO Pattern

    Public Class InvTransactionDao
        Inherits AccountsDao
        Implements IDao(Of InvTransaction), IDaoPosting, IDaoChild(Of Inventory), IDaoAutoReference(Of Inventory)


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
            Return Db.Update(sql, Take(InvTransaction))
        End Function

        Public Function AddRecord(ByRef InvTransaction As InvTransaction) As Integer _
            Implements IDao(Of InvTransaction).AddRecord
            Dim sql As String =
                    " INSERT INTO [InvTransaction] " &
                    " (Amount,BranchIdNo,Cancelled,InvTransTypeIdNo,Notes,Posted,ReferenceNo,TransactionDate,UserIdNo,WarehouseIdNo,WarehouseToIdNo)" &
                    " VALUES (@Amount,@BranchIdNo,@Cancelled,@InvTransTypeIdNo,@Notes,@Posted,@ReferenceNo,@TransactionDate,@UseridNo,@WarehouseIdNo,@WarehouseToIdNo)"
            Return Db.Insert(sql, Take(InvTransaction))
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
            'Dim commands As New List(Of DaoCommand)
            'Dim command1, command2 As New DaoCommand
            'command1.Add("Select Case a.IdNo,a.ProductIdNo,(a.Quantity+a.BonusQuantity) * c.BaseQty / c.UnitQty,b.WarehouseIdNo " &
            '             "From InvTransactionDetail a Left Join InvTransaction b On a.InvTransactionIdNo = b.IdNo " &
            '             "Left Join ProductUnit_View c On a.ProductIdNo = c.ProductIdNo And a.UnitIdNo = c.UnitIdNo ", {"@IdNo", idNo})
            'commands.Add(command1)
            'command2.Add("Update InvTransaction set Posted = 1 where IdNo = @IdNo", {"@IdNo", idNo})
            'commands.Add(command2)
            'retVal = Db.ExecuteNonQueryCommands("PostInvTransaction", commands)
            Return retVal
        End Function

        Public Function GetRecordsWithGroupIdNo(idNo As Object, Optional sortExpression As Object = Nothing) As List(Of Inventory) Implements IDaoChild(Of Inventory).GetRecordsWithGroupIdNo
            If sortExpression Is Nothing Then
                sortExpression = "IdNo"
            End If
            Dim sql As String = "select BatchNo, ExpiryDate, IdNo, TotalCost, ProductIdNo, TransactionIdNo, QtyOnHand, UnitCost from Inventory_View " &
                    "where ProductIdNo = @IdNo and QtyOnHand <> 0 and BranchIdNo = @BranchIdNo Order By " + sortExpression
            Dim params() As Object = {"@IdNo", idNo, "@BranchIdNo", GlobalVariables.BranchIdNo}
            Return Db.Read(sql, MakeInventory, params).ToList()
        End Function


        Private Shared ReadOnly MakeInventory As Func(Of IDataReader, Inventory) =
                                    Function(reader) _
            New Inventory() With {.BatchNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("BatchNo")),
                                  .ExpiryDate = AATM.DataLayer.AdoNet.Extensions.AsDate(reader("ExpiryDate")),
                                  .IdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("IdNo")),
                                  .NetAmount = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("TotalCost")),
                                  .ProductIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("ProductIdNo")),
                                  .PurchaseDetailIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("TransactionIdNo")),
                                  .QtyOnHand = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("QtyOnHand")),
                                  .UnitCost = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("UnitCost"))
                                  }

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Integer) As Integer Implements IDaoChild(Of Inventory).DelUpdateTvp
            Throw New NotImplementedException()
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of Inventory).InsertTvp
            Throw New NotImplementedException()
        End Function


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
        '    Return Nothing ' Db.Read(sql, Make, params).ToList()
        'End Function

        Public Function UpdateReferenceNumber(ByRef bizObj As Inventory) As Integer Implements IDaoAutoReference(Of Inventory).UpdateReferenceNumber
            Dim retVal As Integer
            Dim sql1 As String
            Dim sql2 As String
            Dim series = "InventoryTransaction"
            Dim maxlength As Int16
            If Db.Scalar("Select Count(*) from Series where SeriesName = '" & series & "'") < 1 Then
                Dim sql As String = "INSERT INTO [Series] " &
                    " (SeriesName,Value,MaxLength,Prefix,Description)" &
                    " VALUES (@SeriesName,@Value,@MaxLength,@Prefix,@Description)"
                Dim params() As Object = {"@SeriesName", series,
                                          "@Value", 0,
                                          "@MaxLength", 6,
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
            sql2 = "Update [InvTransaction] set ReferenceNo = Concat(RIGHT(Concat(Replicate('0'," & maxlength & "),(select value from series where seriesName = '" & series & "'))," & maxlength &
                   ")) where IdNo = " & bizObj.IdNo
            retVal = Db.ExecuteSqlTransaction("UpdateInvReferenceNumber", sql1, sql2)
            Return retVal
        End Function


    End Class

End Namespace