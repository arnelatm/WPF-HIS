Imports AATM.Accounts.BusinessLayer

Namespace DataLayer


' defines methods to access Journals.
' this is a database-independent interface. Implementations are database specific
' ** DAO Pattern

    Public Interface IGeneralJournalDao

        ' gets a specific GeneralJournal
        Function GetRecordById(idNo As Integer) As GeneralJournal

        ' gets a sorted list of all Journals
        Function GetAll(Optional ByVal sortExpression As String = "IdNo") As List(Of GeneralJournal)

        ' Add a GeneralJournal
        Function AddRecord(ByRef generalJournal As GeneralJournal) As Integer

        ' updates a GeneralJournal
        Function UpdateRecord(ByRef generalJournal As GeneralJournal) As Integer

        Function UpdateGlReferenceNumber(ByRef model) As Integer

    End Interface
End NameSpace