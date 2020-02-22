Imports AATM.Accounts.BusinessLayer

Namespace DataLayer


' defines methods to access OpenInvoices.
' this is a database-independent interface. Implementations are database specific
' ** DAO Pattern

    Public Interface ICadOiItemDao

        ' gets a specific CadOiItem
        Function GetRecordById(idNo As Integer) As CadOiItem

        ' gets a sorted list of all CkdOiItem
        Function GetAll(Optional ByVal sortExpression As String = "IdNo") As List(Of CadOiItem)

        Function DelUpdateTvp(ByRef tvpTable As DataTable, journalIdNo As Integer) As Integer

        Function InsertTvp(ByRef tvpTable As DataTable) As Integer

        Function GetSupplierOpenInvoices(idNo As Integer) As List(Of CadOiItem)

    End Interface
End NameSpace