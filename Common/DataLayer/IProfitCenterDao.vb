Imports AATM.Common.BusinessLayer

Namespace DataLayer
    ' defines methods to access ProfitCenter.
    ' this is a database-independent interface. Implementations are database specific
    ' ** DAO Pattern

    Public Interface IProfitCenterDao

        ' gets a specific ProfitCenter
        Function GetRecordById(idNo As Integer) As ProfitCenter

        ' gets a sorted list of all ProfitCenter
        Function GetAll(Optional ByVal sortExpression As String = "SortKey") As List(Of ProfitCenter)

        ' Add a ProfitCenter
        Function AddRecord(ByRef profitCenter As ProfitCenter) As Integer

        ' updates a ProfitCenter
        Function UpdateRecord(ByRef profitCenter As ProfitCenter) As Integer

    End Interface

End Namespace