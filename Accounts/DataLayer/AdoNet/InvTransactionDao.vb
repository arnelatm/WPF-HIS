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
        Implements IDao(Of InvTransaction), IDaoPosting

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
                    "ReferenceNo = @Reference," &
                    "TransactionDate = @TransactionDate," &
                    "UserIdNo = @UserIdNo," &
                    "WarehouseIdNo = @WarehouseIdNo " &
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
                                  .InvTransTypeIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("TransTypeIdNo")),
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
    End Class

End Namespace