Imports System.Data
Imports System.Data.SqlClient
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace ServiceLayer
    Public Class CashReceiptJournalTransactionService
        Public Sub UpdateExisting(model As CashReceiptJournalModel)
            If model Is Nothing OrElse model.IdNo <= 0 OrElse Not model.TransactionDate.HasValue Then Throw New InvalidOperationException("Cash receipt ID and transaction date are required.")
            Using cn As New SqlConnection(GlobalVariables.DacConnectionString), cmd As New SqlCommand("dbo.UpdateCashReceiptJournalAtomic", cn)
                cmd.CommandType=CommandType.StoredProcedure
                Add(cmd,"@JournalIdNo",model.IdNo) : Add(cmd,"@TransactionDate",model.TransactionDate.Value) : Add(cmd,"@ReferenceNo",model.ReferenceNo) : Add(cmd,"@Amount",model.Amount) : Add(cmd,"@AccountIdNo",If(model.AccountIdNo.HasValue,CObj(model.AccountIdNo.Value),0))
                Add(cmd,"@PayorType",model.PayorType) : Add(cmd,"@PayorIdNo",model.PayorIdNo) : Add(cmd,"@PayorName",model.PayorName) : Add(cmd,"@CheckNumber",model.CheckNumber) : Add(cmd,"@CheckDate",model.CheckDate) : Add(cmd,"@ORNumber",model.OrNumber)
                Add(cmd,"@DiscountTaken",model.DiscountTaken) : Add(cmd,"@DiscountAccountIdNo",model.DiscountAccountIdNo) : Add(cmd,"@Applied",model.Applied) : Add(cmd,"@UnApplied",model.UnApplied) : Add(cmd,"@VatAmount",model.VatAmount) : Add(cmd,"@VatNumber",model.VatNumber) : Add(cmd,"@Notes",model.Notes) : Add(cmd,"@Posted",model.Posted) : Add(cmd,"@Approved",model.Approved) : Add(cmd,"@Cancelled",model.Cancelled)
                Dim p=cmd.Parameters.AddWithValue("@Items",CreateItems(model)) : p.SqlDbType=SqlDbType.Structured : p.TypeName="dbo.JournalItemInsert"
                p=cmd.Parameters.AddWithValue("@OiItems",CreateOiItems(model)) : p.SqlDbType=SqlDbType.Structured : p.TypeName="dbo.CsrOiItemInsert"
                cn.Open() : cmd.ExecuteNonQuery()
            End Using
        End Sub

        Public Function DeleteExisting(journalIdNo As Integer) As Integer
            Using cn As New SqlConnection(GlobalVariables.DacConnectionString), cmd As New SqlCommand("dbo.DeleteCashReceiptJournalAtomic", cn)
                cmd.CommandType=CommandType.StoredProcedure
                Add(cmd,"@JournalIdNo",journalIdNo)
                cn.Open()
                cmd.ExecuteNonQuery()
                'SET NOCOUNT ON makes ExecuteNonQuery return -1 even after a
                'successful transaction. Return an explicit success value.
                Return 1
            End Using
        End Function

        Public Function SaveNew(model As CashReceiptJournalModel) As Integer
            If model Is Nothing OrElse Not model.TransactionDate.HasValue Then Throw New InvalidOperationException("Cash receipt transaction date is required.")
            Dim items = New DataTable()
            For Each c In {New With {.N="AccountIdNo",.T=GetType(Integer)},New With {.N="Credit",.T=GetType(Decimal)},New With {.N="Debit",.T=GetType(Decimal)},New With {.N="JournalIDNo",.T=GetType(Integer)},New With {.N="Notes",.T=GetType(String)},New With {.N="PayIdNo",.T=GetType(Integer)},New With {.N="RevCostCenterIdNo",.T=GetType(Integer)},New With {.N="Sequence",.T=GetType(Integer)}} : items.Columns.Add(c.N,c.T) : Next
            For Each i In If(model.JournalItems, New List(Of JournalItemModel))
                items.Rows.Add(If(i.AccountIdNo.HasValue,CObj(i.AccountIdNo.Value),0),i.Credit,i.Debit,0,If(i.Notes, String.Empty),i.PayIdNo,CObj(i.RevCostCenterIdNo),i.Sequence)
            Next
            Dim oi = New DataTable()
            For Each c In {New With {.N="Amount",.T=GetType(Decimal)},New With {.N="ArOpenInvoiceIdNo",.T=GetType(Integer)},New With {.N="CsrIdNo",.T=GetType(Integer)},New With {.N="DiscountTaken",.T=GetType(Decimal)},New With {.N="Sequence",.T=GetType(Integer)}} : oi.Columns.Add(c.N,c.T) : Next
            For Each i In If(model.CsrOiItems, New List(Of CsrOiItemModel)) : oi.Rows.Add(i.Amount,i.ArOpenInvoiceIdNo,0,i.DiscountTaken,i.Sequence) : Next
            Using cn As New SqlConnection(GlobalVariables.DacConnectionString), cmd As New SqlCommand("dbo.SaveCashReceiptJournalAtomic",cn)
                cmd.CommandType=CommandType.StoredProcedure
                Add(cmd,"@TransactionDate",model.TransactionDate.Value) : Add(cmd,"@ReferenceNo",model.ReferenceNo) : Add(cmd,"@Amount",model.Amount) : Add(cmd,"@AccountIdNo",If(model.AccountIdNo.HasValue,CObj(model.AccountIdNo.Value),0))
                Add(cmd,"@PayorType",model.PayorType) : Add(cmd,"@PayorIdNo",model.PayorIdNo) : Add(cmd,"@PayorName",model.PayorName) : Add(cmd,"@CheckNumber",model.CheckNumber) : Add(cmd,"@CheckDate",model.CheckDate) : Add(cmd,"@ORNumber",model.OrNumber)
                Add(cmd,"@DiscountTaken",model.DiscountTaken) : Add(cmd,"@DiscountAccountIdNo",model.DiscountAccountIdNo) : Add(cmd,"@Applied",model.Applied) : Add(cmd,"@UnApplied",model.UnApplied) : Add(cmd,"@VatAmount",model.VatAmount) : Add(cmd,"@VatNumber",model.VatNumber) : Add(cmd,"@Notes",model.Notes) : Add(cmd,"@Posted",model.Posted) : Add(cmd,"@Approved",model.Approved) : Add(cmd,"@Cancelled",model.Cancelled)
                Dim p=cmd.Parameters.AddWithValue("@Items",items) : p.SqlDbType=SqlDbType.Structured : p.TypeName="dbo.JournalItemInsert"
                p=cmd.Parameters.AddWithValue("@OiItems",oi) : p.SqlDbType=SqlDbType.Structured : p.TypeName="dbo.CsrOiItemInsert"
                Dim id=cmd.Parameters.Add("@JournalIdNo",SqlDbType.Int) : id.Direction=ParameterDirection.Output
                cn.Open() : cmd.ExecuteNonQuery() : Return Convert.ToInt32(id.Value)
            End Using
        End Function
        Private Shared Sub Add(c As SqlCommand, n As String, v As Object)
            c.Parameters.AddWithValue(n, If(v Is Nothing, DBNull.Value, v))
        End Sub

        Private Shared Function CreateItems(model As CashReceiptJournalModel) As DataTable
            Dim t As New DataTable()
            For Each c In {New With {.N="AccountIdNo",.T=GetType(Integer)},New With {.N="Credit",.T=GetType(Decimal)},New With {.N="Debit",.T=GetType(Decimal)},New With {.N="JournalIDNo",.T=GetType(Integer)},New With {.N="Notes",.T=GetType(String)},New With {.N="PayIdNo",.T=GetType(Integer)},New With {.N="RevCostCenterIdNo",.T=GetType(Integer)},New With {.N="Sequence",.T=GetType(Integer)}} : t.Columns.Add(c.N,c.T) : Next
            For Each i In If(model.JournalItems, New List(Of JournalItemModel)) : t.Rows.Add(If(i.AccountIdNo.HasValue,CObj(i.AccountIdNo.Value),0),i.Credit,i.Debit,0,If(i.Notes,String.Empty),i.PayIdNo,CObj(i.RevCostCenterIdNo),i.Sequence) : Next
            Return t
        End Function

        Private Shared Function CreateOiItems(model As CashReceiptJournalModel) As DataTable
            Dim t As New DataTable()
            For Each c In {New With {.N="Amount",.T=GetType(Decimal)},New With {.N="ArOpenInvoiceIdNo",.T=GetType(Integer)},New With {.N="CsrIdNo",.T=GetType(Integer)},New With {.N="DiscountTaken",.T=GetType(Decimal)},New With {.N="Sequence",.T=GetType(Integer)}} : t.Columns.Add(c.N,c.T) : Next
            For Each i In If(model.CsrOiItems, New List(Of CsrOiItemModel)) : t.Rows.Add(i.Amount,i.ArOpenInvoiceIdNo,0,i.DiscountTaken,i.Sequence) : Next
            Return t
        End Function
    End Class
End Namespace
