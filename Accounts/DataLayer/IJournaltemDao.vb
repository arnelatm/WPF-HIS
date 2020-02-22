Imports AATM.Accounts.BusinessLayer

Namespace DataLayer

' defines methods to access JournalItems.
' this is a database-independent interface. Implementations are database specific
' ** DAO Pattern

    Public Interface IJournalItemDao

        ' gets a specific JournalItem

        Function GetRecordById(idNo As Integer) As JournalItem

        ' gets a sorted list of all JournalItems
        Function GetAll(Optional ByVal sortExpression As String = "IdNo") As List(Of JournalItem)

        ' updates a JournalItem
        Function DelUpdateTvp(ByRef tvpTable As DataTable, journalIdNo As Integer) As Integer

        Function InsertTvp(ByRef tvpTable As DataTable) As Integer

    End Interface
End NameSpace