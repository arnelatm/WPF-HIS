Imports System.Data
Imports System.Data.SqlClient
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Libraries.GlobalFuncNSub

Namespace ServiceLayer
    Public Class ArJournalTransactionService
        Public Sub UpdateExisting(model As ArJournalModel)
            Dim items = CreateItems(model)
            Using cn As New SqlConnection(GlobalVariables.DacConnectionString), cmd As New SqlCommand("dbo.UpdateArJournalAtomic",cn)
                cmd.CommandType=CommandType.StoredProcedure
                Add(cmd,"@JournalIdNo",model.IdNo): Add(cmd,"@CustomerIdNo",model.CustomerIdNo.Value): Add(cmd,"@TransactionDate",model.TransactionDate.Value)
                Add(cmd,"@ReferenceNo",Db(model.ReferenceNo)): Add(cmd,"@TransactionType",Db(model.TransactionType)): Add(cmd,"@Amount",model.Amount): Add(cmd,"@AccountIdNo",If(model.AccountIdNo.HasValue,CObj(model.AccountIdNo.Value),CObj(0)))
                Add(cmd,"@DueDate",Db(model.DueDate)): Add(cmd,"@SettlementDueDate",Db(model.SettlementDueDate)): Add(cmd,"@SettlementDiscount",model.SettlementDiscount): Add(cmd,"@InvoiceNo",model.InvoiceNo): Add(cmd,"@Notes",model.Notes): Add(cmd,"@VatAmount",model.VatAmount): Add(cmd,"@Approved",model.Approved): Add(cmd,"@Posted",model.Posted)
                Dim tp=cmd.Parameters.AddWithValue("@Items",items): tp.SqlDbType=SqlDbType.Structured: tp.TypeName="dbo.JournalItemInsert"
                cn.Open(): cmd.ExecuteNonQuery()
            End Using
        End Sub

        Public Function DeleteExisting(idNo As Integer) As Integer
            Using cn As New SqlConnection(GlobalVariables.DacConnectionString), cmd As New SqlCommand("dbo.DeleteArJournalAtomic",cn)
                cmd.CommandType=CommandType.StoredProcedure: Add(cmd,"@JournalIdNo",idNo): cn.Open(): Return cmd.ExecuteNonQuery()
            End Using
        End Function

        Private Shared Function CreateItems(model As ArJournalModel) As DataTable
            Dim t As New DataTable()
            For Each c In {"AccountIdNo","Credit","Debit","JournalIDNo","Notes","PayIdNo","RevCostCenterIdNo","Sequence"}
                t.Columns.Add(c,If(c="Notes",GetType(String),If(c="Credit" OrElse c="Debit",GetType(Decimal),GetType(Integer))))
            Next
            For Each i In model.JournalItems
                t.Rows.Add(If(i.AccountIdNo.HasValue,CObj(i.AccountIdNo.Value),CObj(0)),i.Credit,i.Debit,0,If(i.Notes Is Nothing,String.Empty,i.Notes),CObj(i.PayIdNo),i.RevCostCenterIdNo,i.Sequence)
            Next
            Return t
        End Function
        Public Function SaveNew(model As ArJournalModel) As Integer
            If model Is Nothing OrElse Not model.TransactionDate.HasValue OrElse Not model.CustomerIdNo.HasValue Then
                Throw New InvalidOperationException("AR customer and transaction date are required.")
            End If
            Dim items As New DataTable()
            For Each c In {"AccountIdNo", "Credit", "Debit", "JournalIDNo", "Notes", "PayIdNo", "RevCostCenterIdNo", "Sequence"}
                items.Columns.Add(c, If(c="Notes", GetType(String), If(c="Credit" OrElse c="Debit", GetType(Decimal), GetType(Integer))))
            Next
            For Each item In model.JournalItems
                items.Rows.Add(If(item.AccountIdNo.HasValue,CObj(item.AccountIdNo.Value),CObj(0)),item.Credit,item.Debit,0,If(item.Notes Is Nothing,String.Empty,item.Notes),CObj(item.PayIdNo),item.RevCostCenterIdNo,item.Sequence)
            Next
            Using cn As New SqlConnection(GlobalVariables.DacConnectionString), cmd As New SqlCommand("dbo.SaveArJournalAtomic",cn)
                cmd.CommandType=CommandType.StoredProcedure
                Add(cmd,"@CustomerIdNo",model.CustomerIdNo.Value): Add(cmd,"@TransactionDate",model.TransactionDate.Value)
                Add(cmd,"@ReferenceNo",Db(model.ReferenceNo)): Add(cmd,"@TransactionType",Db(model.TransactionType))
                Add(cmd,"@Amount",model.Amount): Add(cmd,"@AccountIdNo",If(model.AccountIdNo.HasValue,CObj(model.AccountIdNo.Value),CObj(0)))
                Add(cmd,"@DueDate",Db(model.DueDate)): Add(cmd,"@SettlementDueDate",Db(model.SettlementDueDate))
                Add(cmd,"@SettlementDiscount",model.SettlementDiscount): Add(cmd,"@InvoiceNo",model.InvoiceNo)
                Add(cmd,"@VatAmount",model.VatAmount): Add(cmd,"@Notes",model.Notes)
                Add(cmd,"@Approved",model.Approved): Add(cmd,"@Posted",model.Posted)
                Dim tp=cmd.Parameters.AddWithValue("@Items",items): tp.SqlDbType=SqlDbType.Structured: tp.TypeName="dbo.JournalItemInsert"
                Dim op=cmd.Parameters.Add("@JournalIdNo",SqlDbType.Int): op.Direction=ParameterDirection.Output
                cn.Open(): cmd.ExecuteNonQuery(): Return Convert.ToInt32(op.Value)
            End Using
        End Function
        Private Shared Function Db(v As Object) As Object
            Return If(v Is Nothing, DBNull.Value, v)
        End Function

        Private Shared Sub Add(c As SqlCommand, n As String, v As Object)
            c.Parameters.AddWithValue(n, Db(v))
        End Sub
    End Class
End Namespace
