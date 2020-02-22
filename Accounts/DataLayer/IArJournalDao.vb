Imports AATM.Accounts.BusinessLayer

Namespace DataLayer


' defines methods to access Journals.
' this is a database-independent interface. Implementations are database specific
' ** DAO Pattern

    Public Interface IArJournalDao

        ' gets a specific ArJournal
        Function GetRecordById(idNo As Integer) As ArJournal

        ' gets a sorted list of all Journals
        Function GetAll(Optional ByVal sortExpression As String = "IdNo") As List(Of ArJournal)

        ' Add a ArJournal
        Function AddRecord(ByRef arJournal As ArJournal) As Integer

        ' updates a ApJournal
        Function UpdateRecord(ByRef arJournal As ArJournal) As Integer

        Function UpdateGlReferenceNumber(ByRef model) As Integer

    End Interface
End NameSpace