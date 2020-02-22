Imports AATM.Accounts.BusinessLayer

Namespace DataLayer


' defines methods to access DistributionSchemeItems.
' this is a database-independent interface. Implementations are database specific
' ** DAO Pattern

    Public Interface IDistributionSchemeItemDao

        ' gets a specific DistributionSchemeItem

        Function GetRecordById(idNo As Integer) As DistributionSchemeItem

        ' gets a sorted list of all DistributionSchemeItems
        Function GetAll(Optional ByVal sortExpression As String = "IdNo") As List(Of DistributionSchemeItem)

        ' updates a DistributionSchemeItem
        Function DelUpdateTvp(ByRef tvpTable As DataTable, distributionSchemeIdNo As Integer) As Integer

        Function InsertTvp(ByRef tvpTable As DataTable) As Integer

    End Interface
End NameSpace