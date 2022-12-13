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
            Const LookupTableName As Int32 = 0
            Const ControlFieldName As Int32 = 1
            Const LookupFieldNames As Int32 = 2
            Const LookupFilter As Int32 = 3
            Const LookupSortKey As Int32 = 4
            Dim control As CtComboBox
            For i = 0 To UBound(dataSourceNames, 1)
                Dim tableName As String = dataSourceNames(i, LookupTableName)
                Dim fieldName As String = dataSourceNames(i, ControlFieldName)
                Dim luFields As String = Nothing
                Dim filter As String = Nothing
                Dim sortKey As String = Nothing
                If UBound(dataSourceNames, 2) > 1 Then
                    luFields = dataSourceNames(i, LookupFieldNames)
                End If
                If UBound(dataSourceNames, 2) > 2 Then
                    filter = dataSourceNames(i, LookupFilter)
                End If
                If UBound(dataSourceNames, 2) > 3 Then
                    sortKey = dataSourceNames(i, LookupSortKey)
                End If
                If luFields Is Nothing Then
                    luFields = "IdNo" + "," + tableName + "Name" + "," + tableName + "Code"
                    sortKey = tableName + "Name"
                Else
                    Dim fieldNames = luFields.Split(",")
                    If fieldNames.Count() = 1 Then
                        sortKey = fieldNames(0)
                    Else
                        If sortKey Is Nothing Then
                            sortKey = fieldNames(1)
                        End If
                    End If
                End If
                If GlobalFunctions.IsRightToLeft(CultureInfo.CurrentCulture.ToString()) Then
                    Dim nameField As String = sortKey
                    Dim nameFieldArabic As String = sortKey + "Ara"
                    Dim newFields As String = ""
                    Dim svc As New CommonService
                    If svc.FieldExistInTable(tableName, nameFieldArabic) Then
                        Dim fieldNames = luFields.Split(",")
                        For Each item In fieldNames
                            If String.Compare(item, nameField, StringComparison.OrdinalIgnoreCase) = 0 Then
                                newFields += nameFieldArabic + ","
                            Else
                                newFields += item + ","
                            End If
                        Next
                        luFields = Left(newFields, Len(newFields) - 1)
                        sortKey = nameFieldArabic
                    End If
                End If
                control = GetFieldControlName(fieldName)
                Dim vMember As String = luFields.Split(",")(0).Trim()
                Dim dMember As String = sortKey.Trim()
                Dim sTask = {Task(Of DataTable).Factory.StartNew(Function() LookupDataTableCreator(tableName, luFields, filter, sortKey)), control, vMember, dMember}

                tasks.Add(sTask)
            Next
            For Each taskItem In tasks
                Dim dControl As CtComboBox = taskItem(1)
                Dim vMember As String = TaskItem(2)
                Dim dMember As String = taskItem(3)
                Invoker.SetPropertyR(dControl, "DataSource", taskItem(0).Result)
                dControl.Valuemember = vMember
                dControl.DisplayMember = dMember
            Next
        End Sub

        Private Shared Function LookupDataTableCreator(ByVal tableName As String, luFields As String, luFilter As String, sortKey As String) As DataTable
            Dim cd As New DataCreator()
            Dim data As DataTable = cd.CreateDataTable(tableName, luFields, luFilter, sortKey)
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

        Private Shared ReadOnly _sv = New CommonService()

        Public Function CreateDataTable(tableName As String, fieldNames As String, luFilter As String, sortKey As String) As DataTable
            'Dim luFields As String()
            'If fieldNames Is Nothing Then
            '    fieldNames = "IdNo" + "," + tableName + "Name" + "," + tableName + "Code"
            '    sortKey = tableName + "Name"
            'Else
            '    luFields = fieldNames.Split(",")
            '    If luFields.Count() = 1 Then
            '        sortKey = luFields(0)
            '    Else
            '        If sortKey Is Nothing Then
            '            sortKey = luFields(1)
            '        End If
            '    End If
            'End If
            Return _sv.GetDtRecords(tableName, fieldNames, luFilter, sortKey)
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