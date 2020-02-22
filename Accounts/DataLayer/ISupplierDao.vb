Imports AATM.Accounts.BusinessLayer

Namespace DataLayer

' defines methods to access Suppliers.
' this is a database-independent interface. Implementations are database specific
' ** DAO Pattern

    Public Interface ISupplierDao

        ' gets a specific Supplier
        Function GetRecordById(idNo As Integer) As Supplier

        ' gets a sorted list of all Suppliers
        Function GetAll(Optional ByVal sortExpression As String = "SupplierName ASC") As List(Of Supplier)

        ' Add a Supplier
        Function AddRecord(ByRef supplier As Supplier) As Integer

        ' updates a Supplier
        Function UpdateRecord(ByRef supplier As Supplier) As Integer

    End Interface
End NameSpace