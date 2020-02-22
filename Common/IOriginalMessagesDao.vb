Imports AATM.HIS.Common.BusinessLayer

Namespace DataLayer
    ' defines methods to access OriginalMessageses.
    ' this is a database-independent interface. Implementations are database specific
    ' ** DAO Pattern

    Public Interface IOriginalMessagesDao

        ' gets a specific OriginalMessages
        Function GetRecordById(idNo As Integer) As OriginalMessages

        ' gets a sorted list of all OriginalMessages
        Function GetAll(Optional ByVal sortExpression As String = "MessageKey") As List(Of OriginalMessages)

        ' Add a OriginalMessages
        Function AddRecord(ByRef originalMessages As OriginalMessages) As Integer

        ' updates a OriginalMessages
        Function UpdateRecord(ByRef originalMessages As OriginalMessages) As Integer

    End Interface

End Namespace