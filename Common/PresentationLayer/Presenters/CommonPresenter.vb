' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports System.Drawing.Printing
Imports System.Globalization
Imports AATM.Common.ServiceLayer
Imports AATM.Libraries
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views
Imports AATM.ServicesLayer.Services

Namespace PresentationLayer.Presenters

    Public MustInherit Class CommonPresenter(Of TV As IView, TM As New)
        Inherits Presenter(Of TV, TM)

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(itemView As IView)
            MyBase.New(itemView)
        End Sub

        Public Overrides Sub GoAddRecord()
            MyBase.GoAddRecord()
            MakeDefaultValues()
        End Sub

    End Class

    'Public Class DataLookup
    '    Public Property TableName As String
    '    Public Property PropertyName As String
    '    Public Property PropertyControl As CtComboBox
    '    Public Property LuFields As String
    '    Public Property SortKey As String
    '    Public Property Filter As String
    '    Public Property ValueMember As String
    '    Public Property DisplayMember As String
    '    Public Property Data As DataTable
    '    Public Property NameField As String
    '    Public Property NameFieldOrig As String
    '    Public Property NameDisplayValue As String
    '    Public Property LookUpTask As Task(Of DataTable)
    '    Public Property NameFieldToUse As String
    '    Public Property Ascending As Boolean
    'End Class

    'Public Class DataCreator

    '    Private Shared _sv As Service

    '    Public Sub New(svc As Service)
    '        _sv = svc
    '    End Sub

    '    Public Function CreateDataTable(dtl As DataLookup) As DataTable
    '        Return _sv.GetDtRecords(dtl.TableName, dtl.LuFields, dtl.Filter, dtl.SortKey, dtl.Ascending)
    '    End Function

    '    Public Function CreateData(dataTableName As String) As List(Of Lookup.LookupData)
    '        Dim lookupObj
    '        Dim data As List(Of Lookup.LookupData)
    '        lookupObj = SetLookupObject(dataTableName)
    '        data = _sv.GetLookup(lookupObj)
    '        Return data
    '    End Function

    '    Public Function SetLookupObject(dataTableName As String, Optional dataFields As String() = Nothing, Optional sortKey As String = Nothing, Optional filter As String = Nothing) As Lookup
    '        Dim lookupObj As New Lookup(dataTableName)
    '        If dataFields IsNot Nothing Then
    '            lookupObj.FieldsToShow = dataFields
    '        End If
    '        If Not (sortKey Is Nothing OrElse sortKey = "") Then
    '            lookupObj.SortKey = sortKey
    '        End If
    '        'If Not (Filter() Is Nothing OrElse Filter() = "") Then
    '        '    lookupObj.FilterKey = Filter()
    '        'End If
    '        Return lookupObj
    '    End Function

    '    'Public Function CreateDataSourceThread(tableName, variableName, fields, filter)
    '    '    Dim data As New ArrayList
    '    '    data.Add({"Bank", "BankIdNo", Nothing, Nothing})
    '    '    data.Add({"Country", "CountryCode", "CountryCode,CountryName", Nothing})
    '    '    data.Add({"Department", "DepartmentIdNo", Nothing, Nothing})
    '    '    data.Add({"Designation", "DesignationIdNo", Nothing, Nothing})
    '    '    data.Add({"Country", "NationalityCode", "CountryCode,CountryName", Nothing})
    '    '    data.Add({"Religion", "ReligionIdNo", Nothing, Nothing})
    '    '    data.Add({"PayCycle", "PayCycleIdNo", Nothing, Nothing})
    '    '    data.Add({"PayGroup", "PayGroupIdNo", Nothing, Nothing})
    '    '    data.Add({"Employee", "SupervisorIdNo", Nothing, "Supervisor=1"})
    '    '    Return CreateDataSourceThread(data)
    '    'End Function

    'End Class

End Namespace