Imports System.Data
Imports System.Data.SqlClient
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Libraries.GlobalFuncNSub

Namespace ServiceLayer
    Public Class ErJournalTransactionService
        Public Sub UpdateExisting(m As ErJournalModel)
            If m Is Nothing OrElse m.IdNo<=0 OrElse Not m.TransactionDate.HasValue OrElse Not m.EmployeeIdNo.HasValue Then Throw New InvalidOperationException("Employee reimbursement ID and employee are required.")
            Dim t As New DataTable()
            For Each n In {"AccountIdNo","Credit","Debit","JournalIDNo","Notes","PayIdNo","RevCostCenterIdNo","Sequence"}:t.Columns.Add(n,If(n="Notes",GetType(String),If(n="Credit" OrElse n="Debit",GetType(Decimal),GetType(Integer)))):Next
            For Each i In If(m.JournalItems,New List(Of JournalItemModel)):t.Rows.Add(If(i.AccountIdNo.HasValue,CObj(i.AccountIdNo.Value),0),i.Credit,i.Debit,0,If(i.Notes,String.Empty),i.PayIdNo,CObj(i.RevCostCenterIdNo),i.Sequence):Next
            Using cn As New SqlConnection(GlobalVariables.DacConnectionString),cmd As New SqlCommand("dbo.UpdateErJournalAtomic",cn)
                cmd.CommandType=CommandType.StoredProcedure:Add(cmd,"@JournalIdNo",m.IdNo):Add(cmd,"@EmployeeIdNo",m.EmployeeIdNo.Value):Add(cmd,"@TransactionDate",m.TransactionDate.Value):Add(cmd,"@ReferenceNo",m.ReferenceNo):Add(cmd,"@TransactionType",m.TransactionType):Add(cmd,"@Amount",m.Amount):Add(cmd,"@AccountIdNo",If(m.AccountIdNo.HasValue,CObj(m.AccountIdNo.Value),0)):Add(cmd,"@Notes",m.Notes):Add(cmd,"@Approved",m.Approved):Add(cmd,"@Posted",m.Posted):Add(cmd,"@Cancelled",m.Cancelled)
                Dim p=cmd.Parameters.AddWithValue("@Items",t):p.SqlDbType=SqlDbType.Structured:p.TypeName="dbo.JournalItemInsert":cn.Open():cmd.ExecuteNonQuery()
            End Using
        End Sub
        Public Function DeleteExisting(idNo As Integer) As Integer
            Using cn As New SqlConnection(GlobalVariables.DacConnectionString),cmd As New SqlCommand("dbo.DeleteErJournalAtomic",cn)
                cmd.CommandType=CommandType.StoredProcedure:Add(cmd,"@JournalIdNo",idNo):cn.Open():cmd.ExecuteNonQuery():Return 1
            End Using
        End Function

        Public Function SaveNew(m As ErJournalModel) As Integer
            If m Is Nothing OrElse Not m.TransactionDate.HasValue OrElse Not m.EmployeeIdNo.HasValue Then Throw New InvalidOperationException("Employee and transaction date are required.")
            Dim t As New DataTable()
            For Each n In {"AccountIdNo","Credit","Debit","JournalIDNo","Notes","PayIdNo","RevCostCenterIdNo","Sequence"}:t.Columns.Add(n,If(n="Notes",GetType(String),If(n="Credit" OrElse n="Debit",GetType(Decimal),GetType(Integer)))):Next
            For Each i In If(m.JournalItems,New List(Of JournalItemModel)):t.Rows.Add(If(i.AccountIdNo.HasValue,CObj(i.AccountIdNo.Value),0),i.Credit,i.Debit,0,If(i.Notes,String.Empty),i.PayIdNo,CObj(i.RevCostCenterIdNo),i.Sequence):Next
            Using cn As New SqlConnection(GlobalVariables.DacConnectionString),cmd As New SqlCommand("dbo.SaveErJournalAtomic",cn)
                cmd.CommandType=CommandType.StoredProcedure:Add(cmd,"@EmployeeIdNo",m.EmployeeIdNo.Value):Add(cmd,"@TransactionDate",m.TransactionDate.Value):Add(cmd,"@ReferenceNo",m.ReferenceNo):Add(cmd,"@TransactionType",m.TransactionType):Add(cmd,"@Amount",m.Amount):Add(cmd,"@AccountIdNo",If(m.AccountIdNo.HasValue,CObj(m.AccountIdNo.Value),0)):Add(cmd,"@Notes",m.Notes):Add(cmd,"@Approved",m.Approved):Add(cmd,"@Posted",m.Posted):Add(cmd,"@Cancelled",m.Cancelled)
                Dim p=cmd.Parameters.AddWithValue("@Items",t)
                p.SqlDbType=SqlDbType.Structured
                p.TypeName="dbo.JournalItemInsert"
                Dim id=cmd.Parameters.Add("@JournalIdNo",SqlDbType.Int)
                id.Direction=ParameterDirection.Output
                cn.Open():cmd.ExecuteNonQuery():Return Convert.ToInt32(id.Value)
            End Using
        End Function
        Private Shared Sub Add(c As SqlCommand,n As String,v As Object)
            c.Parameters.AddWithValue(n,If(v Is Nothing,DBNull.Value,v))
        End Sub
    End Class
End Namespace
