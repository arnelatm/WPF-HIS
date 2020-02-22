Imports AATM.Common.BusinessLayer

Namespace DataLayer
    ' defines methods to access RevenueGroup.
    ' this is a database-independent interface. Implementations are database specific
    ' ** DAO Pattern

    Public Interface IRevenueGroupDao

        ' gets a specific RevenueGroup
        Function GetRecordById(idNo As Integer) As RevenueGroup

        ' gets a sorted list of all RevenueGroup
        Function GetAll(Optional ByVal sortExpression As String = "SortKey") As List(Of RevenueGroup)

        ' Add a RevenueGroup
        Function AddRecord(ByRef revenueGroup As RevenueGroup) As Integer

        ' updates a RevenueGroup
        Function UpdateRecord(ByRef revenueGroup As RevenueGroup) As Integer

    End Interface

End Namespace