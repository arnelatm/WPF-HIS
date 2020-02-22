Imports AATM.Accounts.BusinessLayer

Namespace DataLayer


' defines methods to access Journals.
' this is a database-independent interface. Implementations are database specific
' ** DAO Pattern

    Public Interface ICashReceiptJournalDao

        ' gets a specific CashReceiptJournal
        Function GetRecordById(idNo As Integer) As CashReceiptJournal

        ' gets a sorted list of all Journals
        Function GetAll(Optional ByVal sortExpression As String = "IdNo") As List(Of CashReceiptJournal)

        ' Add a CashReceiptJournal
        Function AddRecord(ByRef cashReceiptJournal As CashReceiptJournal) As Integer

        ' updates a CashReceiptJournal
        Function UpdateRecord(ByRef cashReceiptJournal As CashReceiptJournal) As Integer

        Function UpdateGlReferenceNumber(ByRef model) As Integer

    End Interface
End NameSpace