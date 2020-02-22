Imports AATM.Accounts.BusinessLayer

Namespace DataLayer

' defines methods to access GlLedgerItems.
' this is a database-independent interface. Implementations are database specific
' ** DAO Pattern

    Public Interface IGlLedgerItemDao

        ' gets a specific GlLedgerItem

        Function GetRecordById(idNo As Integer) As GlLedgerItem

        ' gets a sorted list of all GlLedgerItems
        Function GetAll(Optional ByVal sortExpression As String = "IdNo") As List(Of GlLedgerItem)

        ' updates a GlLedgerItem
        Function DelUpdateTvp(ByRef tvpTable As DataTable, journalIdNo As Integer) As Integer

        Function InsertTvp(ByRef tvpTable As DataTable) As Integer

    End Interface
End NameSpace