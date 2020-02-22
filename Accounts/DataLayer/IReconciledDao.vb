' defines methods to access OpenInvoices.
' this is a database-independent interface. Implementations are database specific
' ** DAO Pattern
Namespace DataLayer
    Public Interface IReconciledDao

        ' Add a Reconciled
        Function InsertTvp(ByRef tvpTable As DataTable) As Integer

    End Interface
End NameSpace