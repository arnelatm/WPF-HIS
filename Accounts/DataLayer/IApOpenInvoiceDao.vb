Imports AATM.Accounts.BusinessLayer

Namespace DataLayer

' defines methods to access OpenInvoices.
' this is a database-independent interface. Implementations are database specific
' ** DAO Pattern

    Public Interface IApOpenInvoiceDao

        ' gets a specific ApOpenInvoice
        Function GetRecordById(idNo As Integer) As ApOpenInvoice

        ' gets a sorted list of all OpenInvoices
        Function GetAll(Optional ByVal sortExpression As String = "IdNo") As List(Of ApOpenInvoice)

        ' Add a ApOpenInvoice
        Function AddRecord(ByRef apOpenInvoice As ApOpenInvoice) As Integer

        ' gets a specific ApOpenInvoice by JournalIdNo
        Function GetRecordByJournalItemIdNo(journalItemIdNo As Integer, journalCode As String) As ApOpenInvoice

        ' updates a ApOpenInvoice
        Function UpdateRecord(ByRef apOpenInvoice As ApOpenInvoice) As Integer

        Function AddInvoicePayment(ByVal idNo As Int32, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer

        Function RemoveInvoicePayment(ByVal idNo As Int32, ByVal amount As Decimal, ByVal discountTaken As Decimal) As Integer

    End Interface
End NameSpace