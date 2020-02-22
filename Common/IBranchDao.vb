Imports AATM.HIS.Common.BusinessLayer

Namespace DataLayer
    ' defines methods to access Branches.
    ' this is a database-independent interface. Implementations are database specific
    ' ** DAO Pattern

    Public Interface IBranchDao

        ' gets a specific Branch
        Function GetRecordById(idNo As Integer) As Branch

        ' gets a sorted list of all Branches
        Function GetAll(Optional ByVal sortExpression As String = "BranchName") As List(Of Branch)

        ' Add a Branch
        Function AddRecord(ByRef branch As Branch) As Integer

        ' updates a Branch
        Function UpdateRecord(ByRef branch As Branch) As Integer

    End Interface

End Namespace