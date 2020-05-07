Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.ServicesLayer.Services

Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class ModelDefaultFieldValue
        Implements IModelDefaultFieldValue

        Private Shared ReadOnly DefaultFieldValueService = New DefaultFieldValueService()

        'Public Function GetControlDefaultFieldValuesIdNo(searchValue As String) As String _
        '    Implements IModelDefaultFieldValues.GetControlDefaultFieldValuesIdNo
        '    Return DefaultFieldValuesService.GetControlDefaultFieldValuesIdNo(searchValue)
        'End Function

        'Public Function GetUserDefaultFieldValues(DefaultFieldValuesObjectIdNo As Int32, DefaultFieldValuesGroupIdNo As Int32) As ArrayList _
        '    Implements IModelDefaultFieldValues.GetUserDefaultFieldValues
        '    Return DefaultFieldValuesService.GetUserDefaultFieldValues(DefaultFieldValuesObjectIdNo, DefaultFieldValuesGroupIdNo)
        'End Function

        'Public Function GetMainTableColumnProperties(tableName As String) As List(Of DefaultFieldValueModel) Implements IModelDefaultFieldValue.GetDefaultFieldValue
        '    Return DefaultFieldValueService.GetDefaultFieldValue(tableName)
        'End Function

        Public Function GetDefaultFieldValues(tableName As String) As List(Of DefaultFieldValueModel) _
            Implements IModelDefaultFieldValue.GetDefaultFieldValue
            Dim dfvService = New DefaultFieldValueService
            Dim data = dfvService.GetDefaultFieldValues(tableName)
            Dim result = New List(Of DefaultFieldValueModel)
            For Each item In data
                Dim dM = New DefaultFieldValueModel
                MapObject(item, dM)
                result.Add(dM)
            Next
            Return result
        End Function

    End Class

End Namespace