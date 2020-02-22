' defines methods to access DefaultFieldValues.
' this is a database-independent interface. Implementations are database specific
' ** DAO Pattern
Imports AATM.BusinessLayer.BusinessObjects

Public Interface IDefaultFieldValueDao
    ' gets a specific DefaultFieldValue
    Function GetRecordById(idNo As Integer) As DefaultFieldValue

    ' gets a sorted list of all DefaultFieldValues
    Function GetAll(Optional ByVal sortExpression As String = "TableName") As List(Of DefaultFieldValue)

    ' Add a DefaultFieldValue
    Function AddRecord(ByRef defaultFieldValue As DefaultFieldValue) As Integer

    ' updates a DefaultFieldValue
    Function UpdateRecord(ByRef defaultFieldValue As DefaultFieldValue) As Integer

    Function GetTableDefaultValues(tableName As String) As List(Of DefaultFieldValue)
End Interface