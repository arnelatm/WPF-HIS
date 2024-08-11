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
Imports System.ComponentModel

Public Class PresenterB(Of TV As IViewNew, TM As New)

    Public MyErrorProvider As New ErrorProviderExtended
    Protected DataFilter As String = Nothing
    Protected DefaultFieldValueService As New DefaultFieldValueService
    Protected OriginalModel
    Protected Service As Object
    Protected SortOrderKey As String = "IdNo"
    Protected TranslationDac As Dac
    Protected Sub New()
    End Sub

    Protected Sub New(itemView As IViewNew)
        If itemView IsNot Nothing Then
            View = itemView
            Service = New Service()
            AddHandler View.OrigLanguageDisplayRequested, AddressOf OnOrigLanguageDisplayRequested
            AddHandler View.ArabicDisplayRequested, AddressOf OnArabicDisplayRequested
            AddHandler View.FormCaptionTranslator, AddressOf OnFormCaptionTranslator
            AddHandler View.FormLoaded, AddressOf OnFormLoaded
            AddHandler View.MakeDataRequested, AddressOf OnMakeDataRequested
            MyErrorProvider = GetErrorProvider()
            OriginalModel = Activator.CreateInstance(GetType(TM))
            Dim data As List(Of DefaultFieldValue) = DefaultFieldValueService.GetDefaultFieldValues(View.ViewDisplayName)
            ViewDefaultFieldValues = New List(Of DefaultFieldValueModel)
            GlobalFunctions.ManualMap(data, ViewDefaultFieldValues)
        End If
    End Sub



    Protected Overridable Sub OnMakeDataRequested(tableName As String, ByRef variableName As DataTable)
        variableName = MakeDataTable({tableName})
    End Sub

    Protected Property TableName As String

    Protected Property View As TV

    Protected Property ViewDefaultFieldValues As List(Of DefaultFieldValueModel)

    Protected Function GetControlSecurityIdNo(searchValue As String, Optional menu As Boolean = False) As String
        Try
            Return Service.GetControlSecurityIdNo(searchValue, menu)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Protected Function GetControlSecurityValues(ByRef controlSecurityKey As String, Optional menu As Boolean = False) As ArrayList
        Dim controlSecurityObjectIdNo As Int32
        controlSecurityObjectIdNo = GetControlSecurityIdNo(controlSecurityKey, menu)
        Return GetUserSecurity(controlSecurityObjectIdNo, GlobalVariables.SecurityGroupIdNo, GlobalVariables.UserIdNo)
    End Function

    Protected Function GetDtRecords(ByVal pTableName As String, ByVal fieldNames As String(), Optional filter As String = Nothing, Optional sortKey As String = Nothing, Optional ascending As Boolean = True)
        Return Service.GetDtRecords(pTableName, fieldNames, filter, sortKey, ascending)
    End Function

    Protected Function GetDtRecords(ByVal pTableName As String, ByVal fieldNames As String, Optional filter As String = Nothing, Optional sortKey As String = Nothing, Optional ascending As Boolean = True)
        Return Service.GetDtRecords(pTableName, fieldNames, filter, sortKey, ascending)
    End Function

    Protected Function GetErrorProvider() As Object
        Return Invoker.GetField(View, "MyErrorProvider")
    End Function

    Protected Function GetFieldOnMaxField(searchFieldName As String, tableName As String, returnFieldName As String, Optional filter As String = Nothing) As Object
        Return Service.GetFieldOnMaxField(searchFieldName, tableName, returnFieldName, filter)
    End Function

    Protected Function GetRecordFieldWithKey(searchValue As String, cTableName As String, searchFieldName As String,
                                           returnFieldName As String) _
     As String
        Try
            Return Service.GetRecordFieldWithKey(searchValue, cTableName, searchFieldName, returnFieldName)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Protected Function GetTranslatedField(Of TX)(dataSortOrder As String, ByRef dModel As TX) As String
        Dim translatedSortOrder As String = dataSortOrder
        If LicenseManager.UsageMode <> LicenseUsageMode.Designtime Then
            If GlobalVariables.RightToLeftLayout Then
                Dim stringLength = dataSortOrder.Length
                Dim suffix = ""
                Dim nameOfField As String = dataSortOrder
                If stringLength > 4 And
                   (dataSortOrder.Substring(stringLength - 4).ToLower() = " asc" OrElse
                    dataSortOrder.Substring(stringLength - 4).ToLower() = " des") Then
                    suffix = dataSortOrder.Substring(stringLength - 4)
                    nameOfField = dataSortOrder.Substring(0, stringLength - 4)
                End If
                If PropertyExists(dModel, nameOfField + "ara") Then
                    nameOfField += "Ara"
                    translatedSortOrder = nameOfField + suffix
                End If
            End If
        End If
        Return translatedSortOrder
    End Function

    Protected Function GetTranslatedSortOrderKey(Of TX)(sortKey As String, ByRef dModel As TX) As String
        If LicenseManager.UsageMode <> LicenseUsageMode.Designtime Then
            If GlobalVariables.RightToLeftLayout Then
                Dim stringLength = SortOrderKey.Length
                Dim suffix = ""
                Dim nameOfField As String = sortKey
                If stringLength > 4 And
                   (SortOrderKey.Substring(stringLength - 4).ToLower() = " asc" OrElse
                    SortOrderKey.Substring(stringLength - 4).ToLower() = " des") Then
                    suffix = SortOrderKey.Substring(stringLength - 4)
                    nameOfField = SortOrderKey.Substring(0, stringLength - 4)
                End If
                nameOfField = GetTranslatedField(Of TX)(nameOfField, dModel)
                sortKey = nameOfField + suffix
            End If
        End If
        Return sortKey
    End Function

    Protected Function GetUserSecurity(securityObjectIdNo As Int32, securityGroupIdNo As Int16, userIdNo As Int16) As ArrayList
        Return Service.GetUserSecurity(securityObjectIdNo, securityGroupIdNo, userIdNo)
    End Function

    Protected Function MakeDataTable(ByRef dataTableSpecs As Object) As DataTable
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

    Protected Overridable Sub OnArabicDisplayRequested()
    End Sub

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
    Protected Sub OnFormCaptionTranslate(ByVal nSystemViewIdNo As Int16, frm As Object)
        Dim appDataDac As New Dac
        Dim translatorDac As New Dac
        'Dim frm As New TranslationTableManager()
        frm.SystemViewIdNoToTranslate = nSystemViewIdNo
        frm.AppDataDAC = appDataDac
        frm.TranslatorDAC = translatorDac
        frm.Show()
    End Sub

    Protected Sub OnFormCaptionTranslator(translatorForm As Object, form As Object)
        Using translatorForm
            translatorForm.SystemViewIdNoToTranslate = form.VSystemViewIdNo
            translatorForm.AppDataDAC = New Dac
            translatorForm.TranslatorDAC = New Dac
            translatorForm.ShowDialog()
        End Using
    End Sub

    Protected Sub OnFormLoaded(sender As Object, captionCollection As Collection, AllControls As List(Of Control))
        If GlobalVariables.TranslationMode Then
            GetNSaveCaptions(sender, captionCollection, AllControls)
        End If
    End Sub

    Protected Overridable Sub OnOrigLanguageDisplayRequested()
    End Sub

    Protected Function UserHasAccess(securityKey As String, Optional inform As Boolean = False) As Boolean
        Dim hasAccess As Boolean
        If UserIsASuperAdmin() Then
            hasAccess = True
        Else
            Dim controlSecurityValues As ArrayList
            Dim controlSecurityObjectIdNo As Int32
            controlSecurityObjectIdNo = GetControlSecurityIdNo(securityKey)
            If controlSecurityObjectIdNo = 0 Then
                hasAccess = True
            Else
                controlSecurityValues = GetUserSecurity(controlSecurityObjectIdNo, GlobalVariables.SecurityGroupIdNo, GlobalVariables.UserIdNo)
                If controlSecurityValues.Count > 0 Then
                    hasAccess = controlSecurityValues(1)
                Else
                    hasAccess = False
                End If
            End If
            If inform Then
                Dim securityKeyMessage = Messaging.TranslateCaption(securityKey)
                Dim message = Messaging.GetParametrizedMessage(True, "MsgNoAccessToSecurity", {"securityKey", securityKeyMessage})
                Messaging.Show(message)
            End If
        End If
        Return hasAccess
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

    Private Function LookupDataTableCreator(dtl As DataLookupSpecs) As DataTable
        Dim cd As New DataCreator(Service)
        Dim data As DataTable = cd.CreateDataTable(dtl)
        cd = Nothing
        Return data
    End Function

    Private Function SetControlSecurityValue(securityIdNo As Integer) As ArrayList
        Dim controlSecurityValues As ArrayList
        controlSecurityValues = GetUserSecurity(Convert.ToInt16(securityIdNo), GlobalVariables.SecurityGroupIdNo, GlobalVariables.UserIdNo)
        Return controlSecurityValues
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
