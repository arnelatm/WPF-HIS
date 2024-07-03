Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Views
Imports AATM.ServicesLayer.Services
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries
Imports System.Globalization
Imports System.Windows.Forms

Public Class PresenterB(Of TV As IViewNew, TM As New)

    Public Service As Object

    Public Property View As TV
    Public MyErrorProvider As New ErrorProviderExtended
    Protected DataFilter As String = Nothing
    Protected OriginalModel
    Protected DefaultFieldValueService As New DefaultFieldValueService
    Public Property ViewDefaultFieldValues As List(Of DefaultFieldValueModel)

    Public Property TableName As String

    Protected Sub New()
        Service = New Service()
    End Sub

    Public Sub New(itemView As IViewNew)
        If itemView IsNot Nothing Then
            Me.View = itemView
            Me.DataFilter = View.DataFilter
            'Me.Model = New TM
            MyErrorProvider = GetErrorProvider()
            OriginalModel = Activator.CreateInstance(GetType(TM))
            Dim systemViewName As String
            If itemView.ViewDisplayName IsNot Nothing Then
                systemViewName = itemView.ViewDisplayName.Trim()
                If systemViewName Is Nothing Or systemViewName = "" Then
                    systemViewName = DirectCast(itemView, System.Windows.Forms.Control).Name.Trim()
                End If
            Else
                systemViewName = DirectCast(itemView, System.Windows.Forms.Control).Name.Trim()
            End If
            Dim data As List(Of DefaultFieldValue) = DefaultFieldValueService.GetDefaultFieldValues(systemViewName)
            ViewDefaultFieldValues = New List(Of DefaultFieldValueModel)
            GlobalVariables.Mapper.Map(data, ViewDefaultFieldValues)
        End If
    End Sub

    Protected Function GetErrorProvider() As Object
        Return Invoker.GetField(View, "MyErrorProvider")
    End Function


    Public Function MakeDataTable(ByRef dataTableSpecs As Object) As DataTable
        Dim dtl As New DataLookupSpecs
        Const LookupTableName As Int32 = 0
        Const LookupFieldNames As Int32 = 1
        Const LookupFilter As Int32 = 2
        Const LookupSortKey As Int32 = 3
        Const ValueMember As Int32 = 4
        Const DisplayMember As Int32 = 5
        Const Ascending As Int32 = 6
        dtl.TableName = dataTableSpecs(LookupTableName)
        dtl.Ascending = True
        If dataTableSpecs.Length - 1 > 0 Then
            dtl.LuFields = dataTableSpecs(LookupFieldNames)
        End If
        If dataTableSpecs.Length - 1 > 1 Then
            dtl.Filter = dataTableSpecs(LookupFilter)
        End If
        If dataTableSpecs.Length - 1 > 2 Then
            dtl.SortKey = dataTableSpecs(LookupSortKey)
        End If
        If dataTableSpecs.Length - 1 > 3 Then
            dtl.ValueMember = dataTableSpecs(ValueMember)
        End If
        If dataTableSpecs.Length - 1 > 4 Then
            dtl.DisplayMember = dataTableSpecs(DisplayMember)
        End If
        If dataTableSpecs.Length - 1 > 5 Then
            dtl.Ascending = dataTableSpecs(Ascending)
        End If
        ComposeLookupProperties(dtl)
        Return GetDtRecords(dtl.TableName, dtl.LuFields, dtl.Filter, dtl.SortKey)
    End Function

    Public Function GetDtRecords(ByVal pTableName As String, ByVal fieldNames As String(), Optional filter As String = Nothing, Optional sortKey As String = Nothing, Optional ascending As Boolean = True)
        Return Service.GetDtRecords(pTableName, fieldNames, filter, sortKey, ascending)
    End Function

    Public Function GetDtRecords(ByVal pTableName As String, ByVal fieldNames As String, Optional filter As String = Nothing, Optional sortKey As String = Nothing, Optional ascending As Boolean = True)
        Return Service.GetDtRecords(pTableName, fieldNames, filter, sortKey, ascending)
    End Function

    Private Function LookupDataTableCreator(dtl As DataLookupSpecs) As DataTable
        Dim cd As New DataCreator(Service)
        Dim data As DataTable = cd.CreateDataTable(dtl)
        cd = Nothing
        Return data
    End Function

    Private Sub ComposeLookupProperties(dtl As DataTableLookupSpec)
        Dim RightToLeftFormat = GlobalFunctions.IsRightToLeft(CultureInfo.CurrentCulture.ToString())
        If dtl.LuFields Is Nothing Then
            dtl.NameFieldOrig = dtl.TableName + "Name"
            dtl.NameField = TranslateNameField(dtl.TableName, dtl.NameFieldOrig)
            dtl.NameDisplayValue = dtl.NameField + "+'-'+" + dtl.TableName + "Code"
            If dtl.ValueMember Is Nothing Then
                dtl.ValueMember = "IdNo"
            End If
            If dtl.DisplayMember Is Nothing Then
                dtl.DisplayMember = "Name"
            End If
            dtl.LuFields = "IdNo, " + dtl.NameDisplayValue + " COLLATE SQL_Latin1_General_CP1_CI_AS As Name"
            If dtl.SortKey Is Nothing Then
                dtl.SortKey = dtl.NameField
            End If
        Else
            Dim fieldNames = dtl.LuFields.Split(",")
            If fieldNames.Count() = 1 Then
                dtl.NameFieldOrig = fieldNames(0)
                dtl.NameField = TranslateNameField(dtl.TableName, dtl.NameFieldOrig)
                dtl.NameDisplayValue = dtl.NameField
                dtl.ValueMember = "Name"
                dtl.DisplayMember = "Name"
                dtl.LuFields = dtl.NameField + " as Name"
                If dtl.SortKey Is Nothing Then
                    dtl.SortKey = fieldNames(0)
                End If
            ElseIf fieldNames.Count() = 2 Then
                ' assumed the first field is the value member and the second field as the display Value
                dtl.NameFieldOrig = fieldNames(1)
                dtl.NameField = TranslateNameField(dtl.TableName, dtl.NameFieldOrig)
                dtl.NameDisplayValue = "Concat(" + dtl.NameField + " COLLATE SQL_Latin1_General_CP1_CI_AS,'-'," + fieldNames(0) + ") COLLATE SQL_Latin1_General_CP1_CI_AS"
                If dtl.ValueMember Is Nothing Then
                    dtl.ValueMember = "IdNo"
                End If
                If dtl.DisplayMember Is Nothing Then
                    dtl.NameDisplayValue = "Concat(" + dtl.NameField + " COLLATE SQL_Latin1_General_CP1_CI_AS,'-'," + fieldNames(0) + ") COLLATE SQL_Latin1_General_CP1_CI_AS"
                    dtl.DisplayMember = "Name"
                End If
                dtl.LuFields = fieldNames(0) + " as IdNo," + dtl.NameDisplayValue + " as Name"
                If dtl.SortKey Is Nothing Then
                    dtl.SortKey = dtl.NameField
                End If
            ElseIf fieldNames.Count() = 3 Then
                dtl.NameField = fieldNames(1).Trim()
                dtl.NameDisplayValue = "Concat(" + TranslateNameField(dtl.TableName, dtl.NameField) + " COLLATE SQL_Latin1_General_CP1_CI_AS,'-'," + fieldNames(2) + ") COLLATE SQL_Latin1_General_CP1_CI_AS"
                If dtl.ValueMember Is Nothing Then
                    dtl.ValueMember = "IdNo"
                End If
                If dtl.DisplayMember Is Nothing Then
                    dtl.DisplayMember = "Name"
                End If
                dtl.LuFields = fieldNames(0) + " As IdNo," + dtl.NameDisplayValue + " as Name," + fieldNames(2).ToString() + " as Code"
                If dtl.SortKey Is Nothing Then
                    dtl.SortKey = dtl.NameField
                End If
            ElseIf fieldNames.Count() = 4 Then
                dtl.NameField = fieldNames(1).Trim()
                dtl.NameDisplayValue = "Concat(" + TranslateNameField(dtl.TableName, dtl.NameField) + " COLLATE SQL_Latin1_General_CP1_CI_AS,'-'," + fieldNames(2) + ") COLLATE SQL_Latin1_General_CP1_CI_AS"
                If dtl.ValueMember Is Nothing Then
                    dtl.ValueMember = "IdNo"
                End If
                If dtl.DisplayMember Is Nothing Then
                    dtl.DisplayMember = "Name"
                End If
                dtl.LuFields = fieldNames(0) + " As IdNo," + dtl.NameDisplayValue + " as Name," + fieldNames(2).ToString() + " as Code" + ", " + fieldNames(3)
                If dtl.SortKey Is Nothing Then
                    dtl.SortKey = dtl.NameField
                End If
            Else
                MessageBox.Show("Too much parameters passed!")
                Debugger.Break()
            End If
        End If
    End Sub

    Private Function TranslateNameField(tableName As String, fieldName As String) As String
        Dim retValue As String = fieldName
        If GlobalFunctions.IsRightToLeft(CultureInfo.CurrentCulture.ToString()) Then
            Dim nameFieldArabic As String = fieldName + "Ara"
            If Service.FieldExistInTable(tableName, nameFieldArabic) Then
                retValue = fieldName + "Ara"
            End If
        End If
        Return retValue
    End Function

End Class
