Imports AATM.Libraries

Public Interface IPresenter

    Function MakeEnumComboList(Of TE)()

    Function GetFieldWithIdNo(idNo As Object, tableName As String, returnFieldName As String)

    'Function GetLookup(listName As String, Optional filter As String = Nothing) As List(Of Lookup.LookupData)

    'Function GetLookup(lookupTableToGet As String, lookUpSortExpression As String, lookupFieldsToShow As String(), Optional filter As String = Nothing) As List(Of Lookup.LookupData)

End Interface