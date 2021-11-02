Imports System.ComponentModel
Imports System.Drawing
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Transactions
Imports System.Windows.Forms
Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.Libraries
Imports AATM.Libraries.AatmInterfaces
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Views
Imports AATM.ServicesLayer.Services
Imports AutoMapper
Imports KellermanSoftware.CompareNetObjects

''' <summary>
'''     Base class for all presenter classes. Keeps track of Service and View classes.
'''     Notice that Service is static and View is set in the constructor.
''' </summary>
''' <remarks>
'''     MV Patterns: MVP design pattern.
''' </remarks>
''' <typeparam name="TV">Type of itemView.</typeparam>
Public MustInherit Class Presenter(Of TV As IView, TM As New)
    Inherits PresenterBase(Of TV, TM)
    Implements ISubscriber(Of ViewButtonClicked),
               ISubscriber(Of FindFieldRequested),
               ISubscriber(Of EntryFormLoaded),
               ISubscriber(Of SaveDataRequested),
               ISubscriber(Of GetDataSource),
               ISubscriber(Of GetLookupDataRequested),
               ISubscriber(Of LanguageChanged)

    Private _tableDefaultFieldValueList As List(Of DefaultFieldValueModel)

    Private ReadOnly _debugSwitch As Byte = 0
    Private ReadOnly _tableColumnPropertyList As List(Of TblColPropModel)
    Private _addMode As Boolean = False
    Private _editMode As Boolean = False
    Private _errorList As String = ""
    Private _recordPositionNumber As Integer = 0
    Private _targetIdNo As Int32 = 0

    'Private _recordCount As Int32 = 0
    Private _undoMode As Boolean = False

    Private _ea As EventAggregator
    Private _dataErrors As String = ""

    'Private _withTreeView As Boolean = False

    Public Sub New(itemView As IView)
        If itemView IsNot Nothing Then
            Me.View = itemView
            'Me.Model = New TM
            MyErrorProvider = GetErrorProvider()
            If Ea IsNot Nothing Then
                Ea.SubscribeEvent(Me)
            End If
            InitializeTreeViewIfPresent()
            OriginalModel = Activator.CreateInstance(GetType(TM))
            Dim systemViewName As String
            If DirectCast(itemView, AATM.Libraries.CBaseControlsLibrary.CForm).ViewDisplayName IsNot Nothing Then
                systemViewName = DirectCast(itemView, AATM.Libraries.CBaseControlsLibrary.CForm).ViewDisplayName.Trim()
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
        WithTreeView = True
    End Sub

    Private Sub InitializeTreeViewIfPresent()
        Dim pi As PropertyInfo = View.GetType().GetProperty("FormTreeView")
        If pi IsNot Nothing Then
            _WithTreeView = True
            FormTreeView = pi.GetValue(View)
        End If
    End Sub

    Private Function GetErrorProvider() As Object
        Return Invoker.GetField(View, "MyErrorProvider")
    End Function

    Public Property WithTreeView As Boolean

    Public Shadows Event BeforeDelete()

    Public Shadows Event BeforeEdit()

    Public Shadows Event AfterDelete(retVal As Integer)

    Public Overridable Shadows Function GoDeleteRecord() As Integer
        Dim record As New TM
        GlobalVariables.Mapper.Map(Of IView, TM)(View, record)
        Dim retValue = 0
        Dim currentIdNo = Invoker.GetProperty(View, IdFieldName)
        If IsOkToDeleteRecord() Then
            If Messaging.Show(True, "AskIfDeleteRecord", "Are you sure you want to delete this record?", "Please Confirm Delete!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                RaiseEvent BeforeDelete()
                If _WithTreeView Then
                    TreeViewBeforeDelete()
                End If
                retValue = DeleteRecord(currentIdNo)
                If retValue <= 0 Then
                    Messaging.Show(True, "MsgDeleteRecordFailed", "This record was not deleted because of an error. Please try again later or ask Database Administrator for help.", "Deletion Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    Messaging.Show(True, "MsgRecordSuccessfullyDeleted", "Record was successfully deleted.", "Record Deleted")
                    ' if deleted stay on that given RecordPositionNumber
                    ' which in this case will be the next record after the deleted record
                    TargetIdNo = GetIdNoOfSortedPositionNumber(RecordPositionNumber)
                    If TargetIdNo = 0 Then
                        ' last record deleted
                        GoLastRecord()
                    End If
                End If
                RaiseEvent AfterDelete(retValue)
                If _WithTreeView Then
                    TreeViewAfterDelete(retValue)
                End If
                'UpdateViewDisplay(TargetIdNo)
            End If
        End If
        Return retValue
    End Function

    Private Sub GoEditRecord()
        If IsOkToEditRecord() Then
            RaiseEvent BeforeEdit()
            If CancelEdit Then
                CancelEdit = False
            Else
                EditMode = True
            End If
        End If
    End Sub

    Public Shadows Event BeforeSave()

    Public Shadows Event AfterSave()

    Public Overridable Shadows Function Save(ByRef viewControl As Control)
        RaiseEvent BeforeSave()
        Dim record As New TM
        GlobalVariables.Mapper.Map(Of IView, TM)(View, record)
        Dim retVal As Integer = InitiateSave()
        If retVal < 0 Then
            Messaging.Show(True, "MsgSaveRecordFailed", "Something went wrong during saving, saving record failed", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If _WithTreeView Then
                TreeViewAfterSave()
            End If
            RaiseEvent AfterSave()
        End If
        If retVal < 0 Then
        Else
            Messaging.Show(True, "MsgRecordSuccessfullySaved")
            If AddMode Then
                RecordPositionNumber = GetSortedRecordPosition(retVal)
            Else
                RecordPositionNumber = GetSortedRecordPosition(TargetIdNo)
            End If
            AddMode = False
            EditMode = False
            UpdateViewData(TargetIdNo)
            ClearAllErrorMessages()
        End If
        Return retVal
    End Function

    Public Shadows Event BeforeMappingData(dataModel As TM)

    Public Overridable Shadows Sub UpdateViewData(idNo As Int32)
        If idNo <> 0 Then
            Dim modelData As TM
            RecordDateTimeStampValue = GetRecordDateTimeStamp(TargetIdNo)
            modelData = Service.GetRecordByIdNo(Of TM)(idNo)
            'RaiseEvent AfterRecordRetrieval(modelData)
            RaiseEvent BeforeMappingData(modelData)
            GlobalVariables.Mapper.Map(Of TM, TV)(modelData, View)
            For Each child In ChildPresenters
                child.UpdateViewDisplay(idNo)
            Next
            If _WithTreeView Then
                TreeViewUpdateViewDisplay(idNo)
            End If
            ClearAllErrorMessages()
        End If
    End Sub

    Private Sub FormatError(ctrl As Object, ctrlError As String)
        If DirectCast(ctrl, Control).Dock = DockStyle.Fill Then
            If TypeOf ctrl Is CaComboBox Then
                MyErrorProvider.SetIconPadding(ctrl, -27)
            Else
                MyErrorProvider.SetIconPadding(ctrl, -16)
            End If
        End If
        If GlobalVariables.RightToLeftLayout Then
            MyErrorProvider.SetIconAlignment(ctrl, ErrorIconAlignment.TopLeft)
        Else
            MyErrorProvider.SetIconAlignment(ctrl, ErrorIconAlignment.TopRight)
        End If
        Dim controlError As String
        controlError = MyErrorProvider.GetError(ctrl)
        If controlError Is Nothing OrElse controlError = "" Then
            controlError = ctrlError
        Else
            controlError += Environment.NewLine & ctrlError
        End If
        MyErrorProvider.SetError(ctrl, controlError)
        _dataErrors += Environment.NewLine + ctrlError
    End Sub

    Public Shadows Event RecordAddedSuccessfully(ByRef idNoOfRecord As Integer)

    Public Shadows Event RecordUpdatedSuccessfully(ByRef idNoOfRecord As Integer)

    Private Function InitiateSave() As Integer
        Dim retValue As Integer
        Try
            Dim record As New TM
            GlobalVariables.Mapper.Map(Of IView, TM)(View, record)
            Using scope As New TransactionScope(TransactionScopeOption.Required, New TimeSpan(0, 1, 0))
                If AddMode Then
                    retValue = SaveAddedRecord(record)
                    If retValue > 0 Then
                        Dim retVal As Integer = retValue
                        RaiseEvent RecordAddedSuccessfully(retVal)
                        If retVal < 0 Then
                            retValue = retVal
                        End If
                    End If
                Else
                    retValue = UpdateRecord(record)
                    If retValue >= 0 Then
                        Dim retVal As Integer = retValue
                        RaiseEvent RecordUpdatedSuccessfully(retVal)
                        If retVal < 0 Then
                            retValue = retVal
                        Else
                            retValue += retVal
                        End If
                    End If
                End If
                If retValue >= 0 Then
                    scope.Complete()
                End If
            End Using
        Catch ex As TransactionAbortedException
            retValue = -1
            MessageBox.Show(ex.Message, $"Transaction Aborted")
        Catch oEx As Exception

            If oEx.Message.Contains("Timeout Expired") Then
                retValue = -1
            Else
                MsgBox("Error:   " + oEx.Message)
                retValue = -1
            End If
            Debugger.Break()

        End Try

        Return retValue
    End Function

    Private Function RecordHasChanged(idNo As Int32, timeStampedValue As Object) As Boolean
        Dim retValue = False
        Try
            If timeStampedValue IsNot Nothing Then
                Dim newDateTimeStamp As Object
                newDateTimeStamp = Service.GetRecordDateTimeStamp(idNo, TableName, DateTimeStampField)
                If newDateTimeStamp IsNot Nothing Then
                    For i = 0 To 7
                        If timeStampedValue(i) <> newDateTimeStamp(i) Then
                            retValue = True
                            Exit For
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            Return Nothing
        End Try
        Return retValue
    End Function

    Public Sub OnFindFieldRequested_EventHandler(ByRef eventType As FindFieldRequested) Implements ISubscriber(Of FindFieldRequested).OnEventHandler
        Dim idNo = Service.FindFieldNew(TableName, eventType.FindableControl, SortOrderKey, DataFilter)
        If idNo <> 0 Then
            RecordPositionNumber = GetSortedRecordPosition(idNo)
        Else
            Messaging.Show(True, "MsgNoMatchingRecordFound")
        End If
    End Sub

    Public Overrides Sub OnViewButtonClicked_EventHandler(ByRef eventType As ViewButtonClicked) Implements ISubscriber(Of ViewButtonClicked).OnEventHandler
        Select Case eventType.SelectedButton
            Case ButtonClicked.First
                GoFirstRecord()
            Case ButtonClicked.Next
                GoNextRecord()
            Case ButtonClicked.Previous
                GoPreviousRecord()
            Case ButtonClicked.Last
                GoLastRecord()
            Case ButtonClicked.Find
                GoFindRecord()
            Case ButtonClicked.Undo
                GoUndoChanges()
            Case ButtonClicked.Add
                GoAddRecord()
            Case ButtonClicked.Delete
                GoDeleteRecord()
            Case ButtonClicked.Edit
                GoEditRecord()
            'Case ButtonClicked.Save
            '    GoSaveRecord()
            Case ButtonClicked.Print
                GoPrintRecord()
            Case ButtonClicked.Quit
                GoQuit()
            Case ButtonClicked.Translate
                GoTranslate()
            Case ButtonClicked.Filter
                GoFilter()
        End Select
    End Sub

    Public Shadows Sub OnEntryFormLoaded_EventHandler(ByRef eventType As EntryFormLoaded) Implements ISubscriber(Of EntryFormLoaded).OnEventHandler
        If _WithTreeView Then
            DisplayTree()
        End If
    End Sub

    Private Function CheckForDataErrors(eventType As SaveDataRequested) As Boolean
        Dim validated As Boolean = True
        For Each item In MainFieldsDictionary
            Dim cCtrl = item.Value
            Dim fldName = item.Key
            'If fldName = "CreditLimit" Then
            '    Debugger.Break()
            'End If
            If CheckForNumericValue(cCtrl) Then
                If TypeOf cCtrl Is CTextBox Then
                    Dim cTextTextBox As CTextBox = cCtrl
                    If cTextTextBox.ValueIsNumeric Then
                        If Not IsNumberValid(eventType.ViewControl, cCtrl) Then
                            validated = False
                        End If
                    End If
                End If
            End If
            If CheckForUniqueness(cCtrl) Then
                If Not ValueIsUnique(cCtrl) Then
                    If GetPropertyValue(cCtrl, "ValueIsUniqueBlanksAllowed") Then
                        If cCtrl IsNot Nothing AndAlso cCtrl.Text <> "" Then
                            validated = False
                        End If
                    Else
                        validated = False
                    End If
                End If
            End If
        Next
        Return validated
    End Function

    Private Sub PreValidate()
        For Each item In MainFieldsDictionary
            If TypeOf item.Value Is CTextBoxArabic Then
                UpdateArabicControl(item.Value)
            End If
        Next
    End Sub

    Private Sub UpdateArabicControl(cCtrl As CTextBoxArabic)
        If cCtrl.EnglishControl Is Nothing Then
            MessageBox.Show($"EnglishControl for  CTextBoxArabic control <{cCtrl.Name}> not set.")
        End If
        Dim originalValue As String = GetOriginalValue(cCtrl.EnglishControl)
        Dim englishText As String = GetPropertyValue(cCtrl.EnglishControl, "Text")
        If cCtrl.AutoFill And String.IsNullOrEmpty(cCtrl.Text) OrElse cCtrl.Text.Trim() = originalValue Then
            cCtrl.Text = englishText
        End If
    End Sub

    'Public Sub OnEventHandler(ByRef eventType As ValidateViewRequested) Implements ISubscriber(Of ValidateViewRequested).OnEventHandler
    '    Dim validationsPassed As Boolean
    '    validationsPassed = True
    '    Dim allControls As New List(Of Control)
    '    Dim originalValue As String
    '    Dim cForm As Control
    '    cForm = eventType.ViewControl
    '    For Each cCtrl As Control In FindControlRecursive(allControls, cForm)
    '        If TypeOf cCtrl Is IEntryControl Then
    '            If TypeOf cCtrl Is CTextBoxIdNo Then
    '                ' no validations for this type of control. These are Identity Columns and are filled automatically
    '                ' by the Data Server.
    '            ElseIf TypeOf cCtrl Is CTextBox AndAlso GetPropertyValue(cCtrl, "ComputedValue") Then
    '                ' ignore this also computed values don't need to be validated for empty values
    '            ElseIf TypeOf cCtrl Is CTextBoxArabic Then
    '                Dim thisControl As CTextBoxArabic
    '                thisControl = cCtrl
    '                If thisControl.EnglishControl Is Nothing Then
    '                    MessageBox.Show($"EnglishControl for  CTextBoxArabic control <{thisControl.Name}> not set.")
    '                End If
    '                originalValue = GetOriginalValue(thisControl.EnglishControl)
    '                Dim englishText As String = GetPropertyValue(thisControl.EnglishControl, "Text")
    '                If thisControl.AutoFill And String.IsNullOrEmpty(cCtrl.Text) OrElse cCtrl.Text.Trim() = originalValue Then
    '                    thisControl.Text = englishText
    '                End If
    '            ElseIf TypeOf cCtrl Is CTextBox Then 'OrElse TypeOf cCtrl Is CTextBoxArabic Then
    '                ' check for duplicate values
    '                Dim thisControl As CTextBox = cCtrl
    '                If thisControl.ValueIsNumeric Then
    '                    If Not IsNumberValid(eventType.ViewControl, cCtrl) Then
    '                        validationsPassed = False
    '                    End If
    '                End If
    '                If validationsPassed AndAlso GetPropertyValue(cCtrl, "ValueIsUnique") Then
    '                    validationsPassed = ValueIsUnique(cCtrl, validationsPassed)
    '                End If
    '                If validationsPassed AndAlso GetPropertyValue(cCtrl, "ValueIsUniqueBlanksAllowed") Then
    '                    If cCtrl IsNot Nothing AndAlso cCtrl.Text <> "" Then
    '                        validationsPassed = ValueIsUnique(cCtrl, validationsPassed)
    '                    End If
    '                End If
    '            End If

    '        End If
    '    Next
    '    'AutoValidationsPassed = validationsPassed
    '    eventType.ValidView = validationsPassed
    'End Sub

    Private Function ValueIsUnique(cCtrl As Control) As Boolean
        Dim fldName As String = cCtrl.Name.Substring(3)
        Dim recordIsNotUnique = False
        If AddMode Then
            If IsRecordNotUnique(cCtrl, fldName) Then
                recordIsNotUnique = True
            End If
        Else
            Dim originalValue As String
            originalValue = GetOriginalValue(cCtrl)
            ' if value did not change no need to check for duplicate values.
            If cCtrl.Text <> originalValue Then
                If IsRecordNotUnique(cCtrl, fldName) Then
                    recordIsNotUnique = True
                End If
            End If
        End If
        If recordIsNotUnique Then
            Dim errorMessage = Messaging.GetParametrizedMessage(True, "MsgDuplicateValuesNotAllowed", {"fieldValue", cCtrl.Text, "fieldDescription", ControlDescription(cCtrl)})
            FormatError(cCtrl, errorMessage)
            Return False
        End If
        Return True
    End Function

    Private Function CheckForUniqueness(cCtrl As Control) As Boolean
        If GetPropertyValue(cCtrl, "ValueIsUnique") IsNot Nothing Then
            If GetPropertyValue(cCtrl, "ValueIsUnique") Then
                Return True
            End If
        End If
        Return False
    End Function

    Private Function CheckForNumericValue(cCtrl As Control) As Boolean
        If GetPropertyValue(cCtrl, "ValueIsNumeric") IsNot Nothing Then
            Return True
        End If
        Return False
    End Function

    Private Sub SetAllControlsDynamicProperties(viewControl As Control)
        If Not (LicenseManager.UsageMode = LicenseUsageMode.Designtime) Then
            ResetMenuSecurity(viewControl)
        End If
    End Sub

    Private Sub ClearAllErrorMessages()
        Dim myDict = MainFieldsDictionary
        For Each cCtrl As Control In myDict.Values
            MyErrorProvider.SetError(cCtrl, "")
        Next
    End Sub

    Private Sub SetControlDynamicProperties(ByRef cCtrl As Control)
        'Dim myView = cCtrl.FindForm()
        If TypeOf cCtrl Is IEntryControl Then
            ' get FieldName from control : by convention when using this system
            ' all DataBoundControls TextBox & Combobox that will hold field variables are named by convention in this format
            ' textboxes  = txt<FieldName>
            ' combobox   = cbo<FieldName>
            ' datetimePicker = dtp<FieldName>
            ' so to get the field name just get the characters from the control starting at the 4th character onwards
            Dim fldName As String
            fldName = cCtrl.Name.Substring(3) ' get control name starting from the 3rd character (0 based)

            For Each row In TableProperties
                If fldName.ToLower() = row.FldName.ToLower Then
                    If TypeOf cCtrl Is CTextBox Or TypeOf cCtrl Is CMaskedTextBox OrElse TypeOf cCtrl Is CTextBoxArabic Then
                        If row.FldType.ToLower = "int" OrElse
                            row.FldType.ToLower = "smallint" OrElse
                            row.FldType.ToLower = "money" OrElse
                            row.FldType.ToLower = "decimal" OrElse
                            row.FldType.ToLower = "bigint" OrElse
                            row.FldType.ToLower = "tinyint" OrElse
                            row.FldType.ToLower = $"smallmoney" OrElse
                            row.FldType.ToLower = "real" OrElse
                            row.FldType.ToLower = "float" OrElse
                            row.FldType.ToLower = "numeric" Then
                            Select Case row.FldType.ToLower
                                Case "int"
                                    SetPropertyValue(cCtrl, "MinimumValue", -2147483648D)
                                    SetPropertyValue(cCtrl, "MaximumValue", 2147483648D)
                                Case "tinyint"
                                    SetPropertyValue(cCtrl, "MinimumValue", 0D)
                                    SetPropertyValue(cCtrl, "MaximumValue", 255D)
                                Case "smallint"
                                    SetPropertyValue(cCtrl, "MinimumValue", -32768D)
                                    SetPropertyValue(cCtrl, "MaximumValue", 32767D)
                                Case "bigint"
                                    SetPropertyValue(cCtrl, "MinimumValue", -922337236854775808D)
                                    SetPropertyValue(cCtrl, "MaximumValue", 922337236854775807D)
                                Case "money"
                                    SetPropertyValue(cCtrl, "MinimumValue", -922337203685477.5808D)
                                    SetPropertyValue(cCtrl, "MaximumValue", 922337203685477.5807D)
                                Case $"smallmoney"
                                    SetPropertyValue(cCtrl, "MinimumValue", -214748.3647D)
                                    SetPropertyValue(cCtrl, "MaximumValue", 214748.3647D)
                            End Select
                            SetPropertyValue(cCtrl, "ValueIsNumeric", True)
                        Else
                            SetPropertyValue(cCtrl, "Maxlength", If(row.fldType.ToLower() = "nvarchar", Convert.ToInt16(row.MaxLength / 2), row.MaxLength))
                            SetPropertyValue(cCtrl, "ValueIsNullable", row.IsNullable)
                            If (Not row.IsIdentity) And (Not row.IsNullable) Then
                                If GetPropertyValue(cCtrl, "IgnoreNullCheck") Then
                                    MyErrorProvider.Controls.AddMandatory(cCtrl, ControlDescription(cCtrl))
                                End If
                            End If
                        End If
                        Exit For
                    ElseIf TypeOf cCtrl Is CaComboBox OrElse TypeOf cCtrl Is CComboBox Then
                        '
                        '
                    ElseIf TypeOf cCtrl Is CCustomDateTimePicker OrElse TypeOf cCtrl Is CDateTimePicker OrElse
                        TypeOf cCtrl Is CDTPHijriDate OrElse TypeOf cCtrl Is tdpGregorian OrElse
                        TypeOf cCtrl Is CDtpGregorianDate Then
                        SetPropertyValue(cCtrl, "ValueIsNullable", row.IsNullable)
                        If Not row.IsNullable Then
                            'Add this controls to the Mandatory fields error provider.
                            MyErrorProvider.Controls.AddMandatory(cCtrl, cCtrl.Name)
                        End If
                        Exit For
                    End If
                    'If TypeOf cCtrl Is IFindableControl And Not (TypeOf cCtrl Is CForm) Then
                    '    Dim thisControl As IFindableControl = cCtrl
                    '    If thisControl.FindEnabled Then
                    '        thisControl = cCtrl
                    '        thisControl.FindDataType = GetObjectDataType(GetFieldType(cCtrl.Name.Substring(3)))
                    '    End If
                    'End If
                End If
            Next
        End If
    End Sub

    Private Sub SetControlVisibility(ByRef cCtrl As Control, controlVisible As Boolean)
        ' if Visible is false, Don't show the controls content by masking content with '*' asterisk
        If Not controlVisible Then
            'If TypeOf cCtrl Is CTextBox OrElse TypeOf cCtrl Is TextBox Then
            '    SetPropertyValue(cCtrl, "PasswordChar", Convert.ToChar("*"))
            If TypeOf cCtrl Is CTabPage Then
                Dim tabControlObj As CTabControl
                Dim tabPageObj As CTabPage
                tabControlObj = cCtrl.Parent
                tabPageObj = cCtrl
                tabControlObj.TabPages.Remove(cCtrl)
            Else
                SetPropertyValue(cCtrl, "Visible", False)
            End If
        End If
    End Sub

    Private Sub SetControlEditability(ByRef cCtrl As Control, ByRef editable As Boolean)
        ' if Editable is False, make the control readonly property so that it can't be edited
        If Not editable Then
            SetPropertyValue(cCtrl, "DisplayOnly", True)
        End If
    End Sub

    Private Function GetControlSecurityValues(ByRef controlSecurityKey As String, Optional menu As Boolean = False) As ArrayList
        Dim controlSecurityObjectIdNo As Int32
        controlSecurityObjectIdNo = GetControlSecurityIdNo(controlSecurityKey, menu)
        Return GetUserSecurity(controlSecurityObjectIdNo, GlobalVariables.SecurityGroupIdNo)
    End Function

    Private Function GetCdControlSecurityValues(ByRef controlSecurityKey As String, Optional menu As Boolean = False) As ArrayList
        Dim controlSecurityObjectIdNo As Int32
        controlSecurityObjectIdNo = GetControlSecurityIdNo(controlSecurityKey, menu)
        Return GetUserSecurity(controlSecurityObjectIdNo, GlobalVariables.SecurityGroupIdNo)
    End Function

    Private Function GetControlSecurityKey(ByRef cCtrl As Control)
        If Not (LicenseManager.UsageMode = LicenseUsageMode.Designtime) Then
            If cCtrl.GetType().GetProperty("SecurityKey") IsNot Nothing Then
                Return GetPropertyValue(cCtrl, "SecurityKey")
            End If
        End If
        Return ""
    End Function

    Private Sub SetMenuSecurity(cControl As Object, controlSecurityKey As String)
        If GlobalVariables.UserName = $"Arnel" Then
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
                controlSecurityValues = GetUserSecurity(Convert.ToInt16(securityIdNo), GlobalVariables.SecurityGroupIdNo)
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
                isVisible = True
                isSelectable = True
            End If
            cControl.Enabled = isSelectable
            If cControl.Visible Then
                cControl.Visible = isVisible
            End If
        End If
    End Sub

    Private Sub SetMenuStripItemsNew(dropDownItems As ToolStripItemCollection, pParentMenuName As String)
        For Each dropDownItem As Object In dropDownItems
            Dim subMenu = TryCast(dropDownItem, ToolStripMenuItem)
            If subMenu IsNot Nothing Then
                Dim parentMenuName = pParentMenuName
                ApplyMenuSecurityNew(dropDownItem, parentMenuName)
                If subMenu.HasDropDown Then
                    Dim childSubMenuName As String = pParentMenuName + " > " + Mid(dropDownItem.Name, 18)
                    SetMenuStripItemsNew(subMenu.DropDownItems, childSubMenuName)
                End If
            End If
        Next
    End Sub

    Private Sub ApplyMenuSecurityNew(ByRef obj As ToolStripMenuItem, ByRef subMenuName As String)
        Dim toolStripMenuItem As ToolStripMenuItem = obj
        Dim controlSecurityKey = subMenuName + " > " + Mid(toolStripMenuItem.Name, 18)
        If GlobalVariables.IsUserLoggedIn Then
            SetMenuSecurity(toolStripMenuItem, controlSecurityKey)
        Else
            toolStripMenuItem.Enabled = False
            toolStripMenuItem.Visible = True
        End If
    End Sub

    Private Sub SetToolStripItemsNew(dropDownItems As ToolStripItemCollection, subMenuName As String)
        For Each obj As Object In dropDownItems
            ' ReSharper disable once VBPossibleMistakenCallToGetType.2
            If obj.GetType().ToString() = "System.Windows.Forms.ToolStripButton" Then
                Dim toolStripButton As ToolStripButton = obj
                Dim controlSecurityKey = Mid(toolStripButton.Name, 16).TrimEnd()
                If GlobalVariables.IsUserLoggedIn Then
                    Dim controlSecurityValues As ArrayList
                    Dim isSelectable As Boolean
                    Dim isVisible As Boolean
                    Dim securityIdNo As Int32 = GetControlSecurityIdNo(subMenuName + " > " + controlSecurityKey, True)
                    If securityIdNo <> 0 Then
                        If GlobalVariables.SecurityGroupIdNo <> 0 Then
                            controlSecurityValues = GetUserSecurity(securityIdNo, GlobalVariables.SecurityGroupIdNo)
                            If controlSecurityValues.Count > 0 Then
                                ' Visible property stored in first element of the array
                                isVisible = controlSecurityValues(0)
                                ' Editable property stored in third element of the array
                                isSelectable = controlSecurityValues(1)
                            Else
                                isVisible = False
                                isSelectable = False
                            End If
                        Else
                            isVisible = True
                            isSelectable = False
                        End If
                    Else
                        isVisible = True
                        isSelectable = True
                    End If
                    toolStripButton.Enabled = isSelectable
                    toolStripButton.Visible = isVisible
                Else
                    If obj.Name = "ToolStripButtonLogin" Then
                        toolStripButton.Enabled = True
                        toolStripButton.Visible = True
                    Else
                        toolStripButton.Enabled = False
                        toolStripButton.Visible = True
                    End If
                End If
            Else
                obj.Enabled = True
                obj.Visible = True
            End If
        Next

    End Sub

#Region "TreeView"

    Protected TreeViewList
    Protected TreeViewMainField As String
    Protected TreeViewSecondaryField As String
    Protected ParentFieldName As String = ""
    Protected WithEvents FormTreeView As TreeView
    Protected NodeToDelete As TreeNode

    'Public Sub NewTreeView()
    '    FormTreeView = CallByName(View, "FormTreeView", CallType.Get)
    'End Sub

    'Public Sub OnTvEntryFormLoaded_EventHandler(ByRef eventType As EntryFormLoaded) Implements ISubscriber(Of EntryFormLoaded).OnEventHandler
    '    DisplayTree()
    'End Sub

    Protected Sub DisplayTree()
        Dim root As TreeNode = FormTreeView.Nodes(0)
        root.Nodes.Clear()
        Dim treeViewData As Object = GetTreeViewData()
        root.Text = Messaging.TranslateCaption(TableName)
        If ParentFieldName Is Nothing OrElse ParentFieldName = "" Then
            For Each dataNode In treeViewData
                AddRecordToTree(dataNode)
            Next
        Else
            For Each dataNode In treeViewData
                AddRecordToTreeHierarchical(dataNode, True, FormTreeView)
            Next
        End If
        FormTreeView.ExpandAll()
        GotoRecordInTreeView()
    End Sub

    Public Function GetTreeViewData()
        Dim cModel As New TM
        'Dim newSortOrderKey As String = GetTranslatedSortOrderKey(Of TM)(SortOrderKey, cModel)
        'Dim treeMainFieldName = TranslateField(Of TM)(TreeViewMainField, cModel)
        Dim lookupObj As New Lookup(TableName, DataFilter)
        lookupObj.NameField = TreeViewMainField
        If TreeViewSecondaryField IsNot Nothing Then
            lookupObj.CodeField = TreeViewSecondaryField
        End If
        If SortOrderKey IsNot Nothing Then
            lookupObj.SortKey = SortOrderKey
        End If
        'lookupObj.FieldsToShow = {"IdNo", lookupObj.NameField, lookupObj.CodeField}
        If ParentFieldName Is Nothing OrElse ParentFieldName = "" Then
            If String.IsNullOrEmpty(TreeViewSecondaryField) Then
                lookupObj.FieldsToShow = {IdFieldName, TreeViewMainField}
            Else
                lookupObj.FieldsToShow = {IdFieldName, TreeViewMainField, TreeViewSecondaryField}
            End If
            Return Service.GetLookup(lookupObj)
        Else
            lookupObj.SortKey = "SortKey"
            If String.IsNullOrEmpty(TreeViewSecondaryField) Then
                lookupObj.FieldsToShow = {IdFieldName, TreeViewMainField, ParentFieldName}
            Else
                lookupObj.FieldsToShow = {IdFieldName, TreeViewMainField, TreeViewSecondaryField, ParentFieldName}
            End If
            Return Service.GetHLookup(lookupObj)
        End If
    End Function

    Protected Overloads Sub AddRecordToTreeHierarchical(dataNode As Object, parentChanged As Boolean, treeViewTableName As TreeView)
        Dim parentIdValue As Integer? = GetPropertyValue(dataNode, ParentFieldName)
        If parentIdValue Is Nothing OrElse parentIdValue = 0 Then
            AddRecordToTree(dataNode) ', "Name")
        Else
            Dim idNo As Int32 = GetPropertyValue(dataNode, "IdNo")
            Dim mainValue As String = GetPropertyValue(dataNode, "Name")
            Dim secondaryValue As String = GetPropertyValue(dataNode, "Code")
            Dim treeNode As TreeNode = MakeTreeNode(mainValue, secondaryValue, idNo)
            If parentIdValue Is Nothing OrElse parentIdValue = 0 Then
                If parentChanged Then
                    treeViewTableName.Nodes(treeViewTableName.Nodes.Count - 1).Nodes.Add(treeNode)
                Else
                    treeViewTableName.Nodes(0).Nodes.Add(treeNode)
                End If
            Else
                If parentChanged Then
                    Dim foundNode As TreeNode() = treeViewTableName.Nodes.Find(parentIdValue.ToString(), True)
                    If foundNode.Length <> 0 Then
                        foundNode(0).Nodes.Add(treeNode)
                    End If
                End If
            End If
        End If
    End Sub

    Protected Overloads Sub AddRecordToTree(dataNode As Object) ', mainFieldName As String)
        Dim idNo As Int32 = GetPropertyValue(dataNode, IdFieldName)
        Dim mainValue As String = GetPropertyValue(dataNode, "Name")
        Dim secondaryValue As String = GetPropertyValue(dataNode, "Code")
        Dim treeNode As TreeNode = MakeTreeNode(mainValue, secondaryValue, idNo)
        FormTreeView.Nodes(0).Nodes.Add(treeNode)
    End Sub

    Protected Function MakeTreeNode(mainFieldValue As String, secondaryFieldValue As String, idNo As Int32) _
        As TreeNode
        Dim treeTextDisplay As String
        treeTextDisplay = TreeNodeTextDisplay(mainFieldValue, secondaryFieldValue)
        Return New TreeNode With {
            .Text = treeTextDisplay,
            .Tag = idNo,
            .Name = idNo
            }
    End Function

    Protected Overridable Function TreeNodeTextDisplay(tvName As String, ByVal Optional tvAdditionalText As String = "") _
        As String
        Return tvName.Trim() + If(String.IsNullOrEmpty(tvAdditionalText), "", " (" + tvAdditionalText.ToString().Trim() + ")")
    End Function

    Private Sub GotoRecordInTreeView()
        Dim found As TreeNode() = FormTreeView.Nodes.Find(TargetIdNo, True)
        If found.Length <> 0 Then
            With FormTreeView
                .SelectedNode = found(0)
                .HideSelection = False
                .Select()
            End With
        End If
        If FormTreeView.SelectedNode IsNot Nothing AndAlso FormTreeView.SelectedNode.IsVisible Then
            FormTreeView.SelectedNode.EnsureVisible()
        End If
    End Sub

    Public Function GetTreeNodeText()
        Dim cModel As New TM
        Dim cText As String
        Dim treeMainFieldName = TranslateField(Of TM)(TreeViewMainField, cModel)
        If String.IsNullOrEmpty(TreeViewSecondaryField) Then
            cText = Invoker.GetProperty(View, treeMainFieldName).Trim() + " | " + CType(Invoker.GetProperty(View, IdFieldName), String).Trim()
        Else
            Dim addText = Invoker.GetProperty(View, TreeViewSecondaryField)
            cText = Invoker.GetProperty(View, treeMainFieldName).Trim() + " | " + CType(Invoker.GetProperty(View, IdFieldName), String).Trim() +
                    If(String.IsNullOrEmpty(addText), "", " (" + addText.ToString().Trim() + ")")
        End If
        Return cText
    End Function

    Public Sub TreeViewUpdateViewDisplay(idNo As Int32)
        GotoRecordInTreeView()
    End Sub

    Protected Sub BfTvEntry_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles FormTreeView.AfterSelect
        Select Case e.Action
            Case TreeViewAction.ByKeyboard
                    'MessageBox.Show("You like the keyboard!")

            Case TreeViewAction.ByMouse
                'MessageBox.Show("You like the mouse!")
            Case Else
                ' A problem here is causing a windows handle error when executing the below code.
                ' Therefore since this is just a selection change during initialization no need
                ' to execute the codes below so just exit the sub. This will also make initialization
                ' faster because no more need to move the database anyway at initialization the
                ' first record will be the one to be shown.
                Exit Sub
        End Select
        Dim nTag As Integer
        FormTreeView.ImageIndex = 1
        If FormTreeView.SelectedNode.Tag Is Nothing Then
            RecordPositionNumber = 1
        Else
            nTag = FormTreeView.SelectedNode.Tag
            RecordPositionNumber = GetSortedRecordPosition(nTag)
        End If
        If Not FormTreeView.SelectedNode.IsVisible Then
            FormTreeView.SelectedNode.EnsureVisible()
        End If
    End Sub

    Private Sub FormTreeViewBeforeSelect(ByVal sender As Object, ByVal e As TreeViewCancelEventArgs) Handles FormTreeView.BeforeSelect
        If EditMode Or AddMode Then
            If e.Action = TreeViewAction.ByKeyboard Or e.Action = TreeViewAction.ByMouse Then
                'MessageBox.Show("You like the keyboard!")
                MessagingLibrary.Messaging.Show(True, "MsgTvSelectionNotAllowed")
            End If
            e.Cancel = True
        End If
    End Sub

    Public Sub TreeViewBeforeDelete()
        NodeToDelete = FormTreeView.SelectedNode()
    End Sub

    Public Sub TreeViewAfterDelete(retVal As Integer)
        If retVal > 0 Then
            FormTreeView.Nodes.Remove(NodeToDelete)
        End If
    End Sub

    Private Sub TreeViewAfterSave()
        DisplayTree()
    End Sub

    Public Shadows Sub OnLanguageChangedEventHandler(ByRef eventType As LanguageChanged) Implements ISubscriber(Of LanguageChanged).OnEventHandler
        If _WithTreeView Then
            DisplayTree()
        End If
        Dim idNo = CallByName(View, IdFieldName, CallType.Get)
        TargetIdNo = idNo
        RecordPositionNumber = GetSortedRecordPosition(idNo)
        UpdateViewDisplay()
    End Sub

#End Region

End Class