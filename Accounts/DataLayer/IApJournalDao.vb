Imports AATM.Accounts.BusinessLayer

Namespace DataLayer

' defines methods to access Journals.
' this is a database-independent interface. Implementations are database specific
' ** DAO Pattern

    Public Interface IApJournalDao

        ' gets a specific ApJournal
        Function GetRecordById(idNo As Integer) As ApJournal

        ' gets a sorted list of all Journals
        Function GetAll(Optional ByVal sortExpression As String = "IdNo") As List(Of ApJournal)

        ' Add a ApJournal
        Function AddRecord(ByRef apJournal As ApJournal) As Integer

        ' updates a ApJournal
        Function UpdateRecord(ByRef apJournal As ApJournal) As Integer

        Function UpdateGlReferenceNumber(ByRef model) As Integer

    End Interface
End NameSpace