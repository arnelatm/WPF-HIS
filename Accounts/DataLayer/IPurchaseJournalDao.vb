Imports AATM.Accounts.BusinessLayer

Namespace DataLayer

' defines methods to access Journals.
' this is a database-independent interface. Implementations are database specific
' ** DAO Pattern

    Public Interface IPurchaseJournalDao

        ' gets a specific PurchaseJournal
        Function GetRecordById(idNo As Integer) As PurchaseJournal

        ' gets a sorted list of all Journals
        Function GetAll(Optional ByVal sortExpression As String = "IdNo") As List(Of PurchaseJournal)

        ' Add a PurchaseJournal
        Function AddRecord(ByRef purchaseJournal As PurchaseJournal) As Integer

        ' updates a PurchaseJournal
        Function UpdateRecord(ByRef purchaseJournal As PurchaseJournal) As Integer

        Function UpdateGlReferenceNumber(ByRef model) As Integer

    End Interface
End NameSpace