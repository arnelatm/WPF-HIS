Imports AATM.Accounts.BusinessLayer

Namespace DataLayer


' defines methods to access Journals.
' this is a database-independent interface. Implementations are database specific
' ** DAO Pattern

    Public Interface IChequeDisbursementJournalDao

        ' gets a specific ChequeDisbursementJournal
        Function GetRecordById(idNo As Integer) As ChequeDisbursementJournal

        ' gets a sorted list of all Journals
        Function GetAll(Optional ByVal sortExpression As String = "IdNo") As List(Of ChequeDisbursementJournal)

        ' Add a ChequeDisbursementJournal
        Function AddRecord(ByRef chequeDisbursementJournal As ChequeDisbursementJournal) As Integer

        ' updates a ChequeDisbursementJournal
        Function UpdateRecord(ByRef chequeDisbursementJournal As ChequeDisbursementJournal) As Integer

        Function UpdateGlReferenceNumber(ByRef model) As Integer

    End Interface
End NameSpace