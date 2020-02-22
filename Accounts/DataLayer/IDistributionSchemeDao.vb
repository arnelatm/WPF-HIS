Imports AATM.Accounts.BusinessLayer

Namespace DataLayer


' defines methods to access Journals.
' this is a database-independent interface. Implementations are database specific
' ** DAO Pattern

    Public Interface IDistributionSchemeDao

        ' gets a specific DistributionScheme
        Function GetRecordById(idNo As Integer) As DistributionScheme

        ' gets a sorted list of all Journals
        Function GetAll(Optional ByVal sortExpression As String = "IdNo") As List(Of DistributionScheme)

        ' Add a DistributionScheme
        Function AddRecord(ByRef distributionScheme As DistributionScheme) As Integer

        ' updates a DistributionScheme
        Function UpdateRecord(ByRef distributionScheme As DistributionScheme) As Integer

    End Interface
End NameSpace