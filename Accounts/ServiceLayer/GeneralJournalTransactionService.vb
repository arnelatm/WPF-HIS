Imports System.Data
Imports System.Data.SqlClient
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Libraries.GlobalFuncNSub

Namespace ServiceLayer
    Public Class GeneralJournalTransactionService
        Public Function SaveNew(m As GeneralJournalModel) As Integer
            If m Is Nothing OrElse Not m.TransactionDate.HasValue Then Throw New InvalidOperationException("General journal transaction date is required.")
            Using cn As New SqlConnection(GlobalVariables.DacConnectionString),cmd As New SqlCommand("dbo.SaveGjJournalAtomic",cn)
                cmd.CommandType=CommandType.StoredProcedure : AddModel(cmd,m)
                Dim p=cmd.Parameters.AddWithValue("@Items",CreateItems(m)) : p.SqlDbType=SqlDbType.Structured : p.TypeName="dbo.JournalItemInsert"
                Dim id=cmd.Parameters.Add("@JournalIdNo",SqlDbType.Int) : id.Direction=ParameterDirection.Output
                cn.Open() : cmd.ExecuteNonQuery() : Return Convert.ToInt32(id.Value)
            End Using
        End Function
        Public Sub UpdateExisting(m As GeneralJournalModel)
            If m Is Nothing OrElse m.IdNo<=0 OrElse Not m.TransactionDate.HasValue Then Throw New InvalidOperationException("General journal ID and transaction date are required.")
            Using cn As New SqlConnection(GlobalVariables.DacConnectionString),cmd As New SqlCommand("dbo.UpdateGjJournalAtomic",cn)
                cmd.CommandType=CommandType.StoredProcedure : AddModel(cmd,m) : Add(cmd,"@JournalIdNo",m.IdNo)
                Dim p=cmd.Parameters.AddWithValue("@Items",CreateItems(m)) : p.SqlDbType=SqlDbType.Structured : p.TypeName="dbo.JournalItemInsert"
                cn.Open() : cmd.ExecuteNonQuery()
            End Using
        End Sub
        Public Function DeleteExisting(idNo As Integer) As Integer
            Using cn As New SqlConnection(GlobalVariables.DacConnectionString),cmd As New SqlCommand("dbo.DeleteGjJournalAtomic",cn)
                cmd.CommandType=CommandType.StoredProcedure : Add(cmd,"@JournalIdNo",idNo) : cn.Open() : cmd.ExecuteNonQuery() : Return 1
            End Using
        End Function
        Private Shared Sub AddModel(c As SqlCommand,m As GeneralJournalModel)
            Add(c,"@TransactionDate",m.TransactionDate.Value):Add(c,"@ReferenceNo",m.ReferenceNo):Add(c,"@Notes",m.Notes):Add(c,"@Approved",m.Approved):Add(c,"@Posted",m.Posted):Add(c,"@ClosingJournal",m.ClosingJournal):Add(c,"@Cancelled",m.Cancelled)
        End Sub
        Private Shared Function CreateItems(m As GeneralJournalModel) As DataTable
            Dim t As New DataTable():For Each n In {"AccountIdNo","Credit","Debit","JournalIDNo","Notes","PayIdNo","RevCostCenterIdNo","Sequence"}:t.Columns.Add(n,If(n="Notes",GetType(String),If(n="Credit" OrElse n="Debit",GetType(Decimal),GetType(Integer)))):Next
            For Each i In If(m.JournalItems,New List(Of JournalItemModel)):t.Rows.Add(If(i.AccountIdNo.HasValue,CObj(i.AccountIdNo.Value),0),i.Credit,i.Debit,0,If(i.Notes,String.Empty),i.PayIdNo,CObj(i.RevCostCenterIdNo),i.Sequence):Next:Return t
        End Function
        Private Shared Sub Add(c As SqlCommand,n As String,v As Object)
            c.Parameters.AddWithValue(n,If(v Is Nothing,DBNull.Value,v))
        End Sub
    End Class
End Namespace
