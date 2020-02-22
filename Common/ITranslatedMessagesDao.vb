Imports AATM.HIS.Common.BusinessLayer

Namespace DataLayer
    ' defines methods to access TranslatedMessageses.
    ' this is a database-independent interface. Implementations are database specific
    ' ** DAO Pattern

    Public Interface ITranslatedMessagesDao

        ' gets a specific TranslatedMessages
        Function GetRecordById(idNo As Integer) As TranslatedMessages

        ' gets a sorted list of all TranslatedMessages
        Function GetAll(Optional ByVal sortExpression As String = "IdNo") As List(Of TranslatedMessages)

        ' Add a TranslatedMessages
        Function AddRecord(ByRef translatedMessages As TranslatedMessages) As Integer

        ' updates a TranslatedMessages
        Function UpdateRecord(ByRef translatedMessages As TranslatedMessages) As Integer

    End Interface

End Namespace