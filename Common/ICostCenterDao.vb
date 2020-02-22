Imports AATM.HIS.Common.BusinessLayer

Namespace DataLayer
    ' defines methods to access CostCenter.
    ' this is a database-independent interface. Implementations are database specific
    ' ** DAO Pattern

    Public Interface ICostCenterDao

        ' gets a specific CostCenter
        Function GetRecordById(idNo As Integer) As CostCenter

        ' gets a sorted list of all CostCenter
        Function GetAll(Optional ByVal sortExpression As String = "SortKey") As List(Of CostCenter)

        ' Add a CostCenter
        Function AddRecord(ByRef costCenter As CostCenter) As Integer

        ' updates a CostCenter
        Function UpdateRecord(ByRef costCenter As CostCenter) As Integer

    End Interface

End Namespace