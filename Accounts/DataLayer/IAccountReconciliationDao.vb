' defines methods to access Journals.
' this is a database-independent interface. Implementations are database specific
' ** DAO Pattern
Imports AATM.Accounts.BusinessLayer

Namespace DataLayer

    Public Interface IAccountReconciliationDao

        ' gets a specific AccountReconciliation
        Function GetRecordById(idNo As Integer) As AccountReconciliation

        ' gets a sorted list of all Journals
        Function GetAll(Optional ByVal sortExpression As String = "IdNo") As List(Of AccountReconciliation)

        ' Add a AccountReconciliation
        Function AddRecord(ByRef accountReconciliation As AccountReconciliation) As Integer

        ' updates a AccountReconciliation
        Function UpdateRecord(ByRef accountReconciliation As AccountReconciliation) As Integer

    End Interface
End NameSpace