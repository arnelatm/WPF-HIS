Imports AATM.Accounts.BusinessLayer

Namespace DataLayer


' defines methods to access Journals.
' this is a database-independent interface. Implementations are database specific
' ** DAO Pattern

    Public Interface ISalesJournalDao

        ' gets a specific SalesJournal
        Function GetRecordById(idNo As Integer) As SalesJournal

        ' gets a sorted list of all Journals
        Function GetAll(Optional ByVal sortExpression As String = "IdNo") As List(Of SalesJournal)

        ' Add a SalesJournal
        Function AddRecord(ByRef salesJournal As SalesJournal) As Integer

        ' updates a SalesJournal
        Function UpdateRecord(ByRef salesJournal As SalesJournal) As Integer

        Function UpdateGlReferenceNumber(ByRef model) As Integer

    End Interface
End NameSpace