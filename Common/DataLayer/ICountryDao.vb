Imports AATM.Common.BusinessLayer

Namespace DataLayer
    ' defines methods to access Countries.
    ' this is a database-independent interface. Implementations are database specific
    ' ** DAO Pattern

    Public Interface ICountryDao

        ' gets a specific Country
        Function GetRecordById(idNo As Integer) As Country

        ' gets a sorted list of all Countries
        Function GetAll(Optional ByVal sortExpression As String = "CountryName") As List(Of Country)

        ' Add a Country
        Function AddRecord(ByRef country As Country) As Integer

        ' updates a Country
        Function UpdateRecord(ByRef country As Country) As Integer

    End Interface

End Namespace