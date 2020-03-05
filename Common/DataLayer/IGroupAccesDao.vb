' defines methods to access groupAccesss.
' this is a database-independent interface. Implementations are database specific
' ** DAO Pattern
Imports AATM.BusinessLayer.BusinessObjects

Namespace DataLayer

    Public Interface IGroupAccessDao

        ' gets an specific groupAccess

        Function GetRecordById(idNo As Integer) As GroupAccess

        ' gets a sorted list of all GroupAccesses
        Function GetAll(Optional ByVal sortExpression As String = "IdNo") As List(Of GroupAccess)

        ' updates a GroupAccess
        Function DelUpdateTvp(ByRef tvpTable As DataTable, journalIdNo As Integer) As Integer

        Function InsertTvp(ByRef tvpTable As DataTable) As Integer

    End Interface

End Namespace