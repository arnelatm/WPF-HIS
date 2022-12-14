' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports System.Globalization
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.ServiceLayer
Imports AATM.Libraries
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
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

        Public Sub New(itemView As IView)
            MyBase.New(itemView)
        End Sub

        Public Overrides Sub GoAddRecord()
            MyBase.GoAddRecord()
            MakeDefaultValues()
        End Sub

        Protected Sub CreateDataSourceThread(dataSourceNames As Object)
            Dim luItems As List(Of DataLookup)
            luItems = CreateDataLookups(dataSourceNames)
            For Each luItem As DataLookup In luItems
                luItem.PropertyControl = GetFieldControlName(luItem.PropertyName)
                luItem.Data = luItem.LookUpTask.Result
                Invoker.SetPropertyR(luItem.PropertyControl, "DataSource", luItem.Data)
                Invoker.SetPropertyR(luItem.PropertyControl, "DisplayMember", luItem.Data.Columns(0).ColumnName)
                Invoker.SetPropertyR(luItem.PropertyControl, "ValueMember", luItem.ValueMember)
            Next
        End Sub

        Private Shared Function CreateDataLookups(dataSourceNames As Object) As List(Of DataLookup)
            Const LookupTableName As Int32 = 0
            Const PropertyFieldName As Int32 = 1
            Const LookupFieldNames As Int32 = 2
            Const LookupFilter As Int32 = 3
            Const LookupSortKey As Int32 = 4
            Dim lookups As New List(Of DataLookup)
            For i = 0 To UBound(dataSourceNames, 1)
                Dim dtl As New DataLookup
                dtl.TableName = dataSourceNames(i, LookupTableName)
                dtl.PropertyName = dataSourceNames(i, PropertyFieldName)
                If UBound(dataSourceNames, 2) > 1 Then
                    dtl.LuFields = dataSourceNames(i, LookupFieldNames)
                End If
                If UBound(dataSourceNames, 2) > 2 Then
                    dtl.Filter = dataSourceNames(i, LookupFilter)
                End If
                If UBound(dataSourceNames, 2) > 3 Then
                    dtl.SortKey = dataSourceNames(i, LookupSortKey)
                End If
                ComposeLookupProperties(dtl)
                dtl.LookUpTask = Task(Of DataTable).Factory.StartNew(Function() LookupDataTableCreator(dtl))
                lookups.Add(dtl)
            Next
            Return lookups
        End Function

        Private Shared Sub ComposeLookupProperties(dtl As DataLookup)
            Dim RightToLeftFormat = GlobalFunctions.IsRightToLeft(CultureInfo.CurrentCulture.ToString())
            dtl.NameFieldOrig = dtl.TableName + "Name"
            If dtl.LuFields Is Nothing Then
                dtl.NameField = TranslateNameField(dtl.TableName, dtl.NameFieldOrig)
                dtl.NameDisplayValue = dtl.NameField + "+'-'+" + dtl.TableName + "Code"
                dtl.ValueMember = "IdNo"
                dtl.LuFields = dtl.NameDisplayValue + " COLLATE SQL_Latin1_General_CP1_CI_AS, IdNo"
                dtl.SortKey = dtl.NameField
            Else
                Dim fieldNames = dtl.LuFields.Split(",")
                If fieldNames.Count() = 1 Then
                    dtl.NameField = TranslateNameField(dtl.TableName, dtl.NameFieldOrig)
                    dtl.NameDisplayValue = dtl.NameField
                    dtl.ValueMember = fieldNames(0).Trim()
                    dtl.LuFields = dtl.NameDisplayValue + " COLLATE SQL_Latin1_General_CP1_CI_AS"
                    dtl.SortKey = dtl.NameField
                ElseIf fieldNames.Count() = 2 Then
                    dtl.NameField = TranslateNameField(dtl.TableName, dtl.NameFieldOrig)
                    dtl.NameDisplayValue = dtl.NameField + "+'-'+" + fieldNames(1) + " COLLATE SQL_Latin1_General_CP1_CI_AS"
                    dtl.ValueMember = fieldNames(1).Trim()
                    dtl.LuFields = dtl.NameDisplayValue + "," + fieldNames(1)
                    dtl.SortKey = dtl.NameField
                ElseIf fieldNames.Count() = 3 Then
                    dtl.NameField = fieldNames(0).Trim()
                    dtl.NameDisplayValue = TranslateNameField(dtl.TableName, dtl.NameField) + "+'-'+" + fieldNames(2) + " COLLATE SQL_Latin1_General_CP1_CI_AS"
                    dtl.LuFields = dtl.NameDisplayValue + "," + fieldNames(1)
                    dtl.ValueMember = fieldNames(1).Trim()
                    dtl.SortKey = dtl.NameField
                Else
                    MessageBox.Show("Too much parameters passed!")
                    Debugger.Break()
                End If
            End If
            'TranslateFields(dtl)
        End Sub

        Private Shared Function TranslateNameField(tableName As String, fieldName As String) As String
            Dim retValue As String = fieldName
            If GlobalFunctions.IsRightToLeft(CultureInfo.CurrentCulture.ToString()) Then
                Dim nameFieldArabic As String = fieldName + "Ara"
                Dim svc As New CommonService
                If svc.FieldExistInTable(tableName, nameFieldArabic) Then
                    retValue = fieldName + "Ara"
                    'If Dtl.SortKey = Dtl.NameField Then
                    '    Dtl.SortKey = nameFieldArabic
                    'End If
                    'Dtl.NameFieldToUse = nameFieldArabic
                    'Dtl.DisplayMember = nameFieldArabic
                    'dim luFields = dtl.LuFields.Split(",")
                    'if luFields(0) = Dtl.NameField
                    '    luFields(0) = nameFieldArabic
                    '    dtl.LuFields = nameFieldArabic + if(luFields.Length > 1, "," + luFields(1), "") + if(luFields.Length > 2, "," + luFields(2), "")
                    'End If
                End If
            End If
            Return retValue
        End Function

        Private Shared Function LookupDataTableCreator(dtl As DataLookup) As DataTable
            Dim cd As New DataCreator()
            Dim data As DataTable = cd.CreateDataTable(dtl)
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

    Public Class DataLookup
        Public Property TableName As String
        Public Property PropertyName As String
        Public Property PropertyControl As CtComboBox
        Public Property LuFields As String
        Public Property SortKey As String
        Public Property Filter As String
        Public Property ValueMember As String
        Public Property DisplayMember As String
        Public Property Data As DataTable
        Public Property NameField As String
        Public Property NameFieldOrig As String
        Public Property NameDisplayValue As String
        Public Property LookUpTask As Task(Of DataTable)
        Public Property NameFieldToUse As String
    End Class

    Public Class DataCreator

        Private Shared ReadOnly _sv = New CommonService()

        Public Function CreateDataTable(dtl As DataLookup) As DataTable
            Return _sv.GetDtRecords(dtl.TableName, dtl.LuFields, dtl.Filter, dtl.SortKey)
        End Function

        Public Function CreateData(dataTableName As String) As List(Of Lookup.LookupData)
            Dim lookupObj
            Dim data As List(Of Lookup.LookupData)
            lookupObj = SetLookupObject(dataTableName)
            data = _sv.GetLookup(lookupObj)
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