Imports AATM.Accounts.BusinessLayer

Namespace DataLayer


' defines methods to access Journals.
' this is a database-independent interface. Implementations are database specific
' ** DAO Pattern

    Public Interface ICashDisbursementJournalDao

        ' gets a specific CashDisbursementJournal
        Function GetRecordById(idNo As Integer) As CashDisbursementJournal

        ' gets a sorted list of all Journals
        Function GetAll(Optional ByVal sortExpression As String = "IdNo") As List(Of CashDisbursementJournal)

        ' Add a CashDisbursementJournal
        Function AddRecord(ByRef cashDisbursementJournal As CashDisbursementJournal) As Integer

        ' updates a CashDisbursementJournal
        Function UpdateRecord(ByRef cashDisbursementJournal As CashDisbursementJournal) As Integer

        Function UpdateGlReferenceNumber(ByRef model) As Integer

    End Interface
End NameSpace