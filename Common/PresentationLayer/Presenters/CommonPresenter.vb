' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.ServiceLayer
Imports AATM.Libraries
Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views
Imports AATM.ServicesLayer.Services
Imports AutoMapper

Namespace PresentationLayer.Presenters

    Public MustInherit Class CommonPresenter(Of TV As IView, TM As New)
        Inherits Presenter(Of TV, TM)

        Public Sub New()
            MyBase.New()
        End Sub

        'Shared Sub New()
        '    DefaultFieldValueService = New Service("DefaultFieldValue")
        'End Sub

        Public Sub New(itemView As IView)
            MyBase.New(itemView)
        End Sub

        'Protected Sub New()
        '    MyBase.New()
        'End Sub

        'Public Shared Property ModelDefaultFieldValue As IModelDefaultFieldValue

        Public Overrides Sub GoAddRecord()
            MyBase.GoAddRecord()
            MakeDefaultValues()
        End Sub

        Protected Sub CreateDataSourceThread(dataSourceNames As Array)
            Dim tasks As New List(Of Object)
            Dim itemCount As Int32 = dataSourceNames.Length
            For i = 0 To UBound(dataSourceNames, 1)
                Dim tableName As String = dataSourceNames(i, 0)
                Dim fieldName As String = dataSourceNames(i, 1)
                Dim sTask = {Task(Of DataTable).Factory.StartNew(Function() LookupDataTableCreator(tableName)), fieldName}
                tasks.Add(sTask)
            Next
            For Each taskItem In tasks
                Invoker.SetPropertyR(GetControlName2(taskItem(1)), "DataSource", taskItem(0).Result)                
            Next
        End Sub

        Private Shared Function LookupDataTableCreator(ByVal tableName As String) As DataTable
            Dim cd As New DataCreator()
            Dim data As DataTable = cd.CreateDataTable(tableName)
            cd = Nothing
            Return data
        End Function

        Private Shared Function LookupDataCreator(ByVal tableName As String)
            Dim cd As New DataCreator()
            Dim data As List(Of Lookup.LookupData) = cd.CreateData(tableName)
            cd = Nothing
            Return data
        End Function

    End Class

    Public Class DataCreator

        Public Function CreateDataTable(tableName As String) As DataTable
            Dim sv = New CommonService()
            Dim fieldNames = {"IdNo",tableName + "Name", tableName + "Code"}
            Return sv.GetDtRecords(tableName,tableName + "Name",  fieldNames)
        End Function

        Public Function CreateData(dataTableName As String) As List(Of Lookup.LookupData)
            Dim lookupObj
            Dim data As List(Of Lookup.LookupData)
            Dim sv = New CommonService()
            lookupObj = SetLookupObject(dataTableName)
            data = sv.GetLookup(lookupObj)
            Return data
        End Function

        Public Function SetLookupObject(dataTableName As String, Optional dataFields As String() = Nothing, Optional sortKey As String = Nothing, Optional filter As String = Nothing) As Lookup
            Dim lookupObj As New Lookup(dataTableName)
            If dataFields IsNot Nothing Then
                lookupObj.FieldsToShow = dataFields
            End If
            If Not (sortKey Is Nothing OrElse sortKey = "") Then
                lookupObj.SortKey = sortKey
            End If
            'If Not (Filter() Is Nothing OrElse Filter() = "") Then
            '    lookupObj.FilterKey = Filter()
            'End If
            Return lookupObj
        End Function

    End Class
End Namespace