Imports System.Data
Imports System.Data.SqlClient
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Libraries.GlobalFuncNSub
Namespace ServiceLayer
 Public Class SalesJournalTransactionService
  Public Function SaveNew(m As SalesJournalModel) As Integer
   Using cn As New SqlConnection(GlobalVariables.DacConnectionString),cmd As New SqlCommand("dbo.SaveSjJournalAtomic",cn)
    cmd.CommandType=CommandType.StoredProcedure:Add(cmd,"@TransactionDate",m.TransactionDate.Value):Add(cmd,"@AccountIdNo",m.AccountIdNo.Value):Add(cmd,"@ReferenceNo",m.ReferenceNo):Add(cmd,"@Notes",m.Notes):Add(cmd,"@Approved",m.Approved):Add(cmd,"@Posted",m.Posted):Add(cmd,"@Cancelled",m.Cancelled):AddTvps(cmd,m)
    Dim id=cmd.Parameters.Add("@JournalIdNo",SqlDbType.Int):id.Direction=ParameterDirection.Output:cn.Open():cmd.ExecuteNonQuery():Return Convert.ToInt32(id.Value)
   End Using
  End Function
  Public Sub UpdateExisting(m As SalesJournalModel)
   Using cn As New SqlConnection(GlobalVariables.DacConnectionString),cmd As New SqlCommand("dbo.UpdateSjJournalAtomic",cn):cmd.CommandType=CommandType.StoredProcedure:Add(cmd,"@JournalIdNo",m.IdNo):Add(cmd,"@TransactionDate",m.TransactionDate.Value):Add(cmd,"@AccountIdNo",m.AccountIdNo.Value):Add(cmd,"@ReferenceNo",m.ReferenceNo):Add(cmd,"@Notes",m.Notes):Add(cmd,"@Approved",m.Approved):Add(cmd,"@Posted",m.Posted):Add(cmd,"@Cancelled",m.Cancelled):AddTvps(cmd,m):cn.Open():cmd.ExecuteNonQuery():End Using
  End Sub
  Public Function DeleteExisting(idNo As Integer) As Integer
   Using cn As New SqlConnection(GlobalVariables.DacConnectionString),cmd As New SqlCommand("dbo.DeleteSjJournalAtomic",cn):cmd.CommandType=CommandType.StoredProcedure:Add(cmd,"@JournalIdNo",idNo):cn.Open():cmd.ExecuteNonQuery():Return 1:End Using
  End Function
  Private Shared Sub AddTvps(c As SqlCommand,m As SalesJournalModel)
   Dim t As New DataTable():For Each n In {"AccountIdNo","Credit","Debit","JournalIDNo","Notes","PayIdNo","RevCostCenterIdNo","Sequence"}:t.Columns.Add(n,If(n="Notes",GetType(String),If(n="Credit" OrElse n="Debit",GetType(Decimal),GetType(Integer)))):Next:For Each i In If(m.JournalItems,New List(Of JournalItemModel)):t.Rows.Add(If(i.AccountIdNo.HasValue,CObj(i.AccountIdNo.Value),0),i.Credit,i.Debit,0,If(i.Notes,String.Empty),i.PayIdNo,CObj(i.RevCostCenterIdNo),i.Sequence):Next:Dim p=c.Parameters.AddWithValue("@Items",t):p.SqlDbType=SqlDbType.Structured:p.TypeName="dbo.JournalItemInsert"
   Dim d As New DataTable():For Each n In {"DepositTypeIdNo","DepositAmount","SaleAmount","SalesJournalIdNo","Sequence","VatAmount"}:d.Columns.Add(n,If(n="DepositAmount" OrElse n="SaleAmount" OrElse n="VatAmount",GetType(Decimal),GetType(Integer))):Next:For Each x In If(m.SalesDeposits,New List(Of SalesDepositModel)):d.Rows.Add(x.DepositTypeIdNo,x.DepositAmount,x.SaleAmount,0,x.Sequence,x.VatAmount):Next:p=c.Parameters.AddWithValue("@Deposits",d):p.SqlDbType=SqlDbType.Structured:p.TypeName="dbo.SalesDepositInsert"
  End Sub
  Private Shared Sub Add(c As SqlCommand,n As String,v As Object)
   c.Parameters.AddWithValue(n,If(v Is Nothing,DBNull.Value,v))
  End Sub
 End Class
End Namespace
