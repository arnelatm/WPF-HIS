Imports AATM.Accounts.BusinessLayer

Namespace DataLayer

' defines methods to access OpenInvoices.
' this is a database-independent interface. Implementations are database specific
' ** DAO Pattern

    Public Interface ISalesCashItemDao

        ' gets a specific SalesCashItem
        Function GetRecordById(idNo As Integer) As SalesCashItem

        ' gets a sorted list of all SalesCashItem
        Function GetAll(Optional ByVal sortExpression As String = "IdNo") As List(Of SalesCashItem)

        Function DelUpdateTvp(ByRef tvpTable As DataTable, journalIdNo As Integer) As Integer

        Function InsertTvp(ByRef tvpTable As DataTable) As Integer

    End Interface
End NameSpace