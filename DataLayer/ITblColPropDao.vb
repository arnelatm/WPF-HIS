' defines methods to access Table Column Properties.
' this is a database-independent interface. Implementations are database specific
' ** DAO Pattern

Public Interface ITblColPropDao
    ' gets a Table Column Properties
    Function GetMainTableColumnProperties(tableName As String) As List(Of TblColProp)
End Interface