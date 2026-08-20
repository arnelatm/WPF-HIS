Imports System.Data
Imports System.Data.SqlClient
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace ServiceLayer

    ''' <summary>
    ''' Single-transaction persistence boundary for new AP journals.
    ''' The database procedure performs validation and rolls back the complete
    ''' header/detail/open-invoice/VAT operation on failure.
    ''' </summary>
    Public Class ApJournalTransactionService

        Public Function SaveNew(model As ApJournalModel) As Integer
            If model Is Nothing Then Throw New ArgumentNullException(NameOf(model))
            If Not model.TransactionDate.HasValue Then Throw New InvalidOperationException("AP transaction date is required.")
            If Not model.SupplierIdNo.HasValue Then Throw New InvalidOperationException("AP supplier is required.")
            If model.JournalItems Is Nothing Then Throw New InvalidOperationException("AP journal details are required.")

            Dim items As New DataTable()
            items.Columns.Add("AccountIdNo", GetType(Integer))
            items.Columns.Add("Credit", GetType(Decimal))
            items.Columns.Add("Debit", GetType(Decimal))
            items.Columns.Add("JournalIDNo", GetType(Integer))
            items.Columns.Add("Notes", GetType(String))
            items.Columns.Add("PayIdNo", GetType(Integer))
            items.Columns.Add("RevCostCenterIdNo", GetType(Integer))
            items.Columns.Add("Sequence", GetType(Integer))

            For Each item In model.JournalItems
                If (item.AccountIdNo.HasValue AndAlso item.AccountIdNo.Value <> 0) OrElse
                   item.Debit <> 0 OrElse item.Credit <> 0 Then
                    items.Rows.Add(If(item.AccountIdNo.HasValue, CObj(item.AccountIdNo.Value), CObj(0)), item.Credit, item.Debit, 0,
                                   If(item.Notes Is Nothing, String.Empty, item.Notes), DbValue(item.PayIdNo),
                                   item.RevCostCenterIdNo, item.Sequence)
                End If
            Next

            Using connection As New SqlConnection(GlobalVariables.DacConnectionString)
                Using command As New SqlCommand("dbo.SaveApJournalAtomic", connection)
                    command.CommandType = CommandType.StoredProcedure
                    AddParameter(command, "@SupplierIdNo", model.SupplierIdNo.Value)
                    AddParameter(command, "@TransactionDate", model.TransactionDate.Value)
                    AddParameter(command, "@ReferenceNo", DbValue(model.ReferenceNo))
                    AddParameter(command, "@TransactionType", DbValue(model.TransactionType))
                    AddParameter(command, "@Amount", model.Amount)
                    AddParameter(command, "@AccountIdNo", If(model.AccountIdNo.HasValue, CObj(model.AccountIdNo.Value), CObj(0)))
                    AddParameter(command, "@DueDate", DbValue(model.DueDate))
                    AddParameter(command, "@SettlementDueDate", DbValue(model.SettlementDueDate))
                    AddParameter(command, "@SettlementDiscount", model.SettlementDiscount)
                    AddParameter(command, "@InvoiceNo", model.InvoiceNo)
                    AddParameter(command, "@InvoiceDate", DbValue(model.InvoiceDate))
                    AddParameter(command, "@VatNumber", DbValue(model.VatNumber))
                    AddParameter(command, "@VatAmount", model.VatAmount)
                    AddParameter(command, "@Notes", model.Notes)
                    AddParameter(command, "@Approved", model.Approved)
                    AddParameter(command, "@Posted", model.Posted)

                    Dim itemParameter = command.Parameters.AddWithValue("@Items", items)
                    itemParameter.SqlDbType = SqlDbType.Structured
                    itemParameter.TypeName = "dbo.JournalItemInsert"

                    Dim idParameter = command.Parameters.Add("@JournalIdNo", SqlDbType.Int)
                    idParameter.Direction = ParameterDirection.Output

                    connection.Open()
                    command.ExecuteNonQuery()
                    Return Convert.ToInt32(idParameter.Value)
                End Using
            End Using
        End Function

        Public Sub UpdateExisting(model As ApJournalModel)
            If model Is Nothing OrElse model.IdNo <= 0 Then Throw New InvalidOperationException("AP journal ID is required.")
            Dim items As DataTable = CreateItems(model)
            Using connection As New SqlConnection(GlobalVariables.DacConnectionString)
                Using command As New SqlCommand("dbo.UpdateApJournalAtomic", connection)
                    command.CommandType = CommandType.StoredProcedure
                    AddModelParameters(command, model)
                    AddParameter(command, "@JournalIdNo", model.IdNo)
                    Dim itemParameter = command.Parameters.AddWithValue("@Items", items)
                    itemParameter.SqlDbType = SqlDbType.Structured
                    itemParameter.TypeName = "dbo.JournalItemInsert"
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
        End Sub

        Public Function DeleteExisting(journalIdNo As Integer) As Integer
            Using connection As New SqlConnection(GlobalVariables.DacConnectionString)
                Using command As New SqlCommand("dbo.DeleteApJournalAtomic", connection)
                    command.CommandType = CommandType.StoredProcedure
                    AddParameter(command, "@JournalIdNo", journalIdNo)
                    connection.Open()
                    Return command.ExecuteNonQuery()
                End Using
            End Using
        End Function

        Private Shared Function CreateItems(model As ApJournalModel) As DataTable
            Dim items As New DataTable()
            items.Columns.Add("AccountIdNo", GetType(Integer))
            items.Columns.Add("Credit", GetType(Decimal))
            items.Columns.Add("Debit", GetType(Decimal))
            items.Columns.Add("JournalIDNo", GetType(Integer))
            items.Columns.Add("Notes", GetType(String))
            items.Columns.Add("PayIdNo", GetType(Integer))
            items.Columns.Add("RevCostCenterIdNo", GetType(Integer))
            items.Columns.Add("Sequence", GetType(Integer))
            For Each item In model.JournalItems
                items.Rows.Add(If(item.AccountIdNo.HasValue, CObj(item.AccountIdNo.Value), CObj(0)), item.Credit, item.Debit, 0,
                                If(item.Notes Is Nothing, String.Empty, item.Notes), DbValue(item.PayIdNo), item.RevCostCenterIdNo, item.Sequence)
            Next
            Return items
        End Function

        Private Shared Sub AddModelParameters(command As SqlCommand, model As ApJournalModel)
            AddParameter(command, "@SupplierIdNo", model.SupplierIdNo.Value)
            AddParameter(command, "@TransactionDate", model.TransactionDate.Value)
            AddParameter(command, "@ReferenceNo", DbValue(model.ReferenceNo))
            AddParameter(command, "@TransactionType", DbValue(model.TransactionType))
            AddParameter(command, "@Amount", model.Amount)
            AddParameter(command, "@AccountIdNo", If(model.AccountIdNo.HasValue, CObj(model.AccountIdNo.Value), CObj(0)))
            AddParameter(command, "@DueDate", DbValue(model.DueDate))
            AddParameter(command, "@SettlementDueDate", DbValue(model.SettlementDueDate))
            AddParameter(command, "@SettlementDiscount", model.SettlementDiscount)
            AddParameter(command, "@InvoiceNo", model.InvoiceNo)
            AddParameter(command, "@InvoiceDate", DbValue(model.InvoiceDate))
            AddParameter(command, "@VatNumber", DbValue(model.VatNumber))
            AddParameter(command, "@VatAmount", model.VatAmount)
            AddParameter(command, "@Notes", model.Notes)
            AddParameter(command, "@Approved", model.Approved)
            AddParameter(command, "@Posted", model.Posted)
        End Sub

        Private Shared Sub AddParameter(command As SqlCommand, name As String, value As Object)
            command.Parameters.AddWithValue(name, If(value Is Nothing, DBNull.Value, value))
        End Sub

        Private Shared Function DbValue(value As Object) As Object
            Return If(value Is Nothing, DBNull.Value, value)
        End Function
    End Class
End Namespace
