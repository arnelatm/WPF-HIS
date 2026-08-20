Imports System.Data
Imports System.Data.SqlClient
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Libraries.GlobalFuncNSub

Namespace ServiceLayer
    Public Class PettyCashJournalTransactionService
        Public Function SaveNew(model As DisbursementJournalModel) As Integer
            If model Is Nothing OrElse Not model.TransactionDate.HasValue Then Throw New InvalidOperationException("Petty cash transaction date is required.")
            Using cn As New SqlConnection(GlobalVariables.DacConnectionString), cmd As New SqlCommand("dbo.SavePcJournalAtomic", cn)
                cmd.CommandType=CommandType.StoredProcedure : AddModelParameters(cmd,model)
                Dim p=cmd.Parameters.AddWithValue("@Items",CreateItems(model)) : p.SqlDbType=SqlDbType.Structured : p.TypeName="dbo.JournalItemInsert"
                p=cmd.Parameters.AddWithValue("@OiItems",CreateOiItems(model)) : p.SqlDbType=SqlDbType.Structured : p.TypeName="dbo.PcOiItemInsert"
                Dim id=cmd.Parameters.Add("@JournalIdNo",SqlDbType.Int) : id.Direction=ParameterDirection.Output
                cn.Open() : cmd.ExecuteNonQuery() : Return Convert.ToInt32(id.Value)
            End Using
        End Function
        Public Sub UpdateExisting(model As DisbursementJournalModel)
            If model Is Nothing OrElse model.IdNo<=0 OrElse Not model.TransactionDate.HasValue Then Throw New InvalidOperationException("Petty cash ID and transaction date are required.")
            Using cn As New SqlConnection(GlobalVariables.DacConnectionString), cmd As New SqlCommand("dbo.UpdatePcJournalAtomic",cn)
                cmd.CommandType=CommandType.StoredProcedure : AddModelParameters(cmd,model) : Add(cmd,"@JournalIdNo",model.IdNo)
                Dim p=cmd.Parameters.AddWithValue("@Items",CreateItems(model)) : p.SqlDbType=SqlDbType.Structured : p.TypeName="dbo.JournalItemInsert"
                p=cmd.Parameters.AddWithValue("@OiItems",CreateOiItems(model)) : p.SqlDbType=SqlDbType.Structured : p.TypeName="dbo.PcOiItemInsert"
                cn.Open() : cmd.ExecuteNonQuery()
            End Using
        End Sub
        Public Function DeleteExisting(idNo As Integer) As Integer
            Using cn As New SqlConnection(GlobalVariables.DacConnectionString), cmd As New SqlCommand("dbo.DeletePcJournalAtomic",cn)
                cmd.CommandType=CommandType.StoredProcedure : Add(cmd,"@JournalIdNo",idNo) : cn.Open() : cmd.ExecuteNonQuery() : Return 1
            End Using
        End Function
        Private Shared Sub AddModelParameters(c As SqlCommand,m As DisbursementJournalModel)
            Add(c,"@TransactionDate",m.TransactionDate.Value):Add(c,"@ReferenceNo",m.ReferenceNo):Add(c,"@Amount",m.Amount):Add(c,"@AccountIdNo",If(m.AccountIdNo.HasValue,CObj(m.AccountIdNo.Value),0)):Add(c,"@PaymentType",m.PaymentType):Add(c,"@PayType",m.PayType):Add(c,"@PayeeIdNo",m.PayeeIdNo):Add(c,"@PayeeName",m.PayeeName):Add(c,"@CheckNumber",m.CheckNumber):Add(c,"@CheckDate",m.CheckDate):Add(c,"@ORNumber",m.OrNumber):Add(c,"@DiscountTaken",m.DiscountTaken):Add(c,"@DiscountAccountIdNo",m.DiscountAccountIdNo):Add(c,"@Applied",m.Applied):Add(c,"@UnApplied",m.UnApplied):Add(c,"@VatNumber",m.VatNumber):Add(c,"@VatAmount",m.VatAmount):Add(c,"@Notes",m.Notes):Add(c,"@PcClosed",m.PcClosed):Add(c,"@Approved",m.Approved):Add(c,"@Posted",m.Posted):Add(c,"@Cancelled",m.Cancelled)
        End Sub
        Private Shared Function CreateItems(m As DisbursementJournalModel) As DataTable
            Dim t As New DataTable():For Each n In {"AccountIdNo","Credit","Debit","JournalIDNo","Notes","PayIdNo","RevCostCenterIdNo","Sequence"}:t.Columns.Add(n,If(n="Notes",GetType(String),If(n="Credit" OrElse n="Debit",GetType(Decimal),GetType(Integer)))):Next
            For Each i In If(m.JournalItems,New List(Of JournalItemModel)):t.Rows.Add(If(i.AccountIdNo.HasValue,CObj(i.AccountIdNo.Value),0),i.Credit,i.Debit,0,If(i.Notes,String.Empty),i.PayIdNo,CObj(i.RevCostCenterIdNo),i.Sequence):Next:Return t
        End Function
        Private Shared Function CreateOiItems(m As DisbursementJournalModel) As DataTable
            Dim t As New DataTable():For Each n In {"Amount","ApOpenInvoiceIdNo","DiscountTaken","DjIdNo","Sequence"}:t.Columns.Add(n,If(n="Amount" OrElse n="DiscountTaken",GetType(Decimal),GetType(Integer))):Next
            For Each i In If(m.DjOiItems,New List(Of DjOiItemModel)):t.Rows.Add(i.Amount,i.ApOpenInvoiceIdNo,i.DiscountTaken,0,i.Sequence):Next:Return t
        End Function
        Private Shared Sub Add(c As SqlCommand,n As String,v As Object)
            c.Parameters.AddWithValue(n,If(v Is Nothing,DBNull.Value,v))
        End Sub
    End Class
End Namespace
