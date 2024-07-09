Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Views
Imports AATM.ServicesLayer.Services
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries
Imports System.Globalization
Imports System.Windows.Forms
Imports AATM.Libraries.MessagingLibrary

Public Class PresenterB(Of TV As IViewNew, TM As New)

    Public Service As Object


    Public Property View As TV
    Public MyErrorProvider As New ErrorProviderExtended
    Protected DataFilter As String = Nothing
    Protected OriginalModel
    Protected DefaultFieldValueService As New DefaultFieldValueService
    Protected TranslationDac As Dac

    Public Property ViewDefaultFieldValues As List(Of DefaultFieldValueModel)

    Public Property TableName As String

    Protected Sub New()
        Service = New Service()
        AddHandler View.OrigLanguageDisplayRequested, AddressOf OnOrigLanguageDisplayRequested
        AddHandler View.ArabicDisplayRequested, AddressOf OnArabicDisplayRequested
        AddHandler View.FormTranslating, AddressOf OnFormTranslating
        AddHandler View.FormLoaded, AddressOf OnFormLoaded
    End Sub

    Private Sub OnFormLoaded(sender As Object, captionCollection As Collection)

    End Sub

    Private Sub OnFormTranslating(form As Object)
        TranslateForm(form)
    End Sub

    Public Overridable Sub OnArabicDisplayRequested()
    End Sub

    Public Overridable Sub OnOrigLanguageDisplayRequested()
    End Sub

    Public Sub New(itemView As IViewNew)
        If itemView IsNot Nothing Then
            Me.View = itemView
            MyErrorProvider = GetErrorProvider()
            OriginalModel = Activator.CreateInstance(GetType(TM))
            Dim systemViewName As String
            If itemView.ViewDisplayName IsNot Nothing Then
                systemViewName = itemView.ViewDisplayName.Trim()
                If systemViewName Is Nothing Or systemViewName = "" Then
                    systemViewName = View.FormName.Trim()
                End If
            Else
                systemViewName = View.FormName.Trim()
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

    Public Function GetControlSecurityValues(ByRef controlSecurityKey As String, Optional menu As Boolean = False) As ArrayList
        Dim controlSecurityObjectIdNo As Int32
        controlSecurityObjectIdNo = GetControlSecurityIdNo(controlSecurityKey, menu)
        Return GetUserSecurity(controlSecurityObjectIdNo, GlobalVariables.SecurityGroupIdNo, GlobalVariables.UserIdNo)
    End Function

    Public Function GetRecordFieldWithKey(searchValue As String, cTableName As String, searchFieldName As String,
                                       returnFieldName As String) _
     As String
        Try
            Return Service.GetRecordFieldWithKey(searchValue, cTableName, searchFieldName, returnFieldName)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    Public Function GetUserSecurity(securityObjectIdNo As Int32, securityGroupIdNo As Int16, userIdNo As Int16) As ArrayList
        Return Service.GetUserSecurity(securityObjectIdNo, securityGroupIdNo, userIdNo)
    End Function

    Private Sub SetMenuSecurity(cControl As Object, controlSecurityKey As String)
        If UserIsASuperAdmin() Then
            ' make all editable and visible regardless of security values
            cControl.Enabled = True
            cControl.Visible = True
        Else
            Dim securityIdNo As Integer
            Dim controlSecurityValues As ArrayList
            Dim isSelectable As Boolean
            Dim isVisible As Boolean

            securityIdNo = GetControlSecurityIdNo(controlSecurityKey, True)

            If securityIdNo <> 0 Then
                controlSecurityValues = SetControlSecurityValue(securityIdNo)
                If controlSecurityValues.Count > 0 Then
                    ' Visible property stored in first element of the array
                    isVisible = controlSecurityValues(0)
                    isSelectable = controlSecurityValues(1)
                    ' Editable property stored in second element of the array
                Else
                    isVisible = False
                    isSelectable = False
                End If
            Else
                isVisible = False
                isSelectable = False
            End If
            cControl.Enabled = isSelectable
            cControl.Visible = isVisible
        End If
    End Sub

    Private Function SetControlSecurityValue(securityIdNo As Integer) As ArrayList
        Dim controlSecurityValues As ArrayList
        controlSecurityValues = GetUserSecurity(Convert.ToInt16(securityIdNo), GlobalVariables.SecurityGroupIdNo, GlobalVariables.UserIdNo)
        Return controlSecurityValues
    End Function

    'Private Function GetControlSecurityIdNo(ByRef controlSecurityKey As String, Optional objIsMenu As Boolean = False) As Int64
    '    If objIsMenu Then
    '        Return GetRecordFieldWithKey(controlSecurityKey, "SecurityObject_View1", "FullPathName", "IdNo")
    '    Else
    '        Dim idNo As Int32 = GetRecordFieldWithKey(controlSecurityKey, "SecurityObject", "SecurityObjectName", "IdNo")
    '        Dim retVal As Integer
    '        If Not Integer.TryParse(idNo, retVal) Then
    '            Return retVal
    '        Else
    '            Return 0
    '        End If
    '    End If
    'End Function


    Public Function GetControlSecurityIdNo(searchValue As String, Optional menu As Boolean = False) As String
        Try
            Return Service.GetControlSecurityIdNo(searchValue, menu)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function



End Class
