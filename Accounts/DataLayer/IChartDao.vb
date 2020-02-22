Imports AATM.Accounts.BusinessLayer

Namespace DataLayer

' defines methods to access Charts.
' this is a database-independent interface. Implementations are database specific
' ** DAO Pattern

    Public Interface IChartDao

        ' gets a specific Chart
        Function GetRecordById(idNo As Integer) As Chart

        ' gets a sorted list of all Charts
        Function GetAll(Optional ByVal sortExpression As String = "AccountName ASC") As List(Of Chart)

        ' Add a Chart
        Function AddRecord(ByRef chart As Chart) As Integer

        ' updates a Chart
        Function UpdateRecord(ByRef chart As Chart) As Integer

        Function GetDetailAccounts(Optional sortExpression As String = "AccountName") As List(Of Chart)

    End Interface
End NameSpace