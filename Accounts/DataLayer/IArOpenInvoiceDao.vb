Imports AATM.Accounts.BusinessLayer

Namespace DataLayer


' defines methods to access OpenInvoices.
' this is a database-independent interface. Implementations are database specific
' ** DAO Pattern

    Public Interface IArOpenInvoiceDao

        ' gets a specific ArOpenInvoice
        Function GetRecordById(idNo As Integer) As ArOpenInvoice

        ' gets a sorted list of all OpenInvoices
        Function GetAll(Optional ByVal sortExpression As String = "IdNo") As List(Of ArOpenInvoice)

        ' Add a ArOpenInvoice
        Function AddRecord(ByRef arOpenInvoice As ArOpenInvoice) As Integer

        ' gets a specific ArOpenInvoice by JournalIdNo
        Function GetRecordByJournalItemIdNo(journalItemIdNo As Integer, journalCode As String) As ArOpenInvoice

        ' updates a ArOpenInvoice
        Function UpdateRecord(ByRef arOpenInvoice As ArOpenInvoice) As Integer

        Function AddInvoicePayment(ByVal idNo As Int32, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer

        Function RemoveInvoicePayment(ByVal idNo As Int32, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer

    End Interface
End NameSpace