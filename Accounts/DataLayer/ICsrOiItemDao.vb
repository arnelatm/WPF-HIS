Imports AATM.Accounts.BusinessLayer

Namespace DataLayer


' defines methods to access OpenInvoices.
' this is a database-independent interface. Implementations are database specific
' ** DAO Pattern

    Public Interface ICsrOiItemDao

        ' gets a specific CsrOiItem
        Function GetRecordById(idNo As Integer) As CsrOiItem

        ' gets a sorted list of all CsrOiItem
        Function GetAll(Optional ByVal sortExpression As String = "IdNo") As List(Of CsrOiItem)

        Function DelUpdateTvp(ByRef tvpTable As DataTable, journalIdNo As Integer) As Integer

        Function InsertTvp(ByRef tvpTable As DataTable) As Integer

        Function GetCustomerOpenInvoices(idNo As Integer) As List(Of CsrOiItem)

    End Interface
End NameSpace