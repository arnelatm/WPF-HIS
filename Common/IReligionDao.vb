Imports AATM.HIS.Common.BusinessLayer

Namespace DataLayer
    ' defines methods to access Religions.
    ' this is a database-independent interface. Implementations are database specific
    ' ** DAO Pattern

    Public Interface IReligionDao

        ' gets a specific Religion
        Function GetRecordById(idNo As Integer) As Religion

        ' gets a sorted list of all Religions
        Function GetAll(Optional ByVal sortExpression As String = "ReligionName") As List(Of Religion)

        ' Add a Religion
        Function AddRecord(ByRef religion As Religion) As Integer

        ' updates a Religion
        Function UpdateRecord(ByRef religion As Religion) As Integer

    End Interface

End Namespace