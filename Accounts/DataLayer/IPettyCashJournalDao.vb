Imports AATM.Accounts.BusinessLayer

Namespace DataLayer


' defines methods to access Journals.
' this is a database-independent interface. Implementations are database specific
' ** DAO Pattern

    Public Interface IPettyCashJournalDao

        ' gets a specific PettyCashJournal
        Function GetRecordById(idNo As Integer) As PettyCashJournal

        ' gets a sorted list of all Journals
        Function GetAll(Optional ByVal sortExpression As String = "IdNo") As List(Of PettyCashJournal)

        ' Add a PettyCashJournal
        Function AddRecord(ByRef pettyCashJournal As PettyCashJournal) As Integer

        ' updates a PettyCashJournal
        Function UpdateRecord(ByRef pettyCashJournal As PettyCashJournal) As Integer

        Function UpdateGlReferenceNumber(ByRef model) As Integer

    End Interface
End NameSpace