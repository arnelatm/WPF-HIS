Imports AATM.Accounts.BusinessLayer

Namespace DataLayer


' defines methods to access OpenInvoices.
' this is a database-independent interface. Implementations are database specific
' ** DAO Pattern

    Public Interface IAccountReconciliationItemDao

        ' gets a specific AccountReconciliationItem
        Function GetRecordById(idNo As Integer) As AccountReconciliationItem

        ' gets a sorted list of all AccountReconciliationItem
        Function GetAll(Optional ByVal sortExpression As String = "IdNo") As List(Of AccountReconciliationItem)

        Function DelUpdateTvp(ByRef tvpTable As DataTable, accountReconciliationIdNo As Integer) As Integer

        Function InsertTvp(ByRef tvpTable As DataTable) As Integer

        Function GetAcctReconItems(accountIdNo As Integer, reconciliationDate As Date, Optional sortExpression As String = Nothing) As List(Of AccountReconciliationItem)

        'Function GetNewAcctReconItems(accountIdNo As Integer, reconciliationDate As Date, Optional sortExpression As String = Nothing) As List(Of AccountReconciliationItem)

        Function GetGlItems(accountIdNo As Integer, reconciliationDate As Date, Optional sortExpression As String = Nothing) As List(Of AccountReconciliationItem)

        Function GetRecordsWithIdNo(idNo As Integer, Optional sortExpression As String = Nothing) As List(Of AccountReconciliationItem)

        Function GetReconciledRecordsWithIdNo(reconciled As Boolean, idNo As Integer, Optional sortExpression As String = Nothing) As List(Of AccountReconciliationItem)

    End Interface
End NameSpace