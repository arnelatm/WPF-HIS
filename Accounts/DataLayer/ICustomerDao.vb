Imports AATM.Accounts.BusinessLayer

Namespace DataLayer


' defines methods to access Customers.
' this is a database-independent interface. Implementations are database specific
' ** DAO Pattern

    Public Interface ICustomerDao

        ' gets a specific Customer
        Function GetRecordById(idNo As Integer) As Customer

        ' gets a sorted list of all Customers
        Function GetAll(Optional ByVal sortExpression As String = "CustomerName ASC") As List(Of Customer)

        ' Add a Customer
        Function AddRecord(ByRef customer As Customer) As Integer

        ' updates a Customer
        Function UpdateRecord(ByRef customer As Customer) As Integer

    End Interface
End NameSpace