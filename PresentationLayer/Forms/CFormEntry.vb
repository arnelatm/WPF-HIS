Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.Runtime.Remoting
Imports System.Threading
Imports System.Transactions
Imports System.Windows.Forms
Imports AATM.Libraries
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.CustomControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.Languages
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Presenters

Public Class CFormEntry
    Inherits BfMain
    Implements ISubscriber(Of RecordPositionChanged), ISubscriber(Of EditModeChanged), ISubscriber(Of AddModeChanged), ISubscriber(Of ValidatingData), ISubscriber(Of PassErrorList)

    Public FieldsDictionary As New Dictionary(Of String, Object)
    Public GotoTargetRecordWorker As BackgroundWorker(Of String)
    Public ShowWaitForm As BackgroundWorker(Of String)
    Protected Const TurnOff As Boolean = False
    Protected Shared _resetEvent As AutoResetEvent = New AutoResetEvent(False)

    Protected FirstControl As Control
    Protected ParentFieldName As String = ""
    Protected RecordDateTimeStampValue As Object
    Private Const TurnOn As Boolean = True
    Private ReadOnly _currentCulture As CultureInfo = GlobalVariables.AppCurrentCultureInfo
    Private _debugSwitch As Byte = 0

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        KeyPreview = True
        GlobalVariables.EventAggregator.SubscribeEvent(Me)

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Delegate Sub SafeCallDelegate(ByRef controlObject As Control, textString As String)

    Public Event AfterLoad()

    Public Event InputsTurnedOff()

    Public Event InputsTurnedOn()

    Private Declare Function SetProcessWorkingSetSize Lib "kernel32.dll" (hProcess As IntPtr,
                                                                          dwMinimumWorkingSetSize As Int32,
                                                                          dwMaximumWorkingSetSize As Int32) As Int32
    'Private Declare Auto Function SendMessage Lib "user32" ( ByVal hwnd As IntPtr, ByVal wMsg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr ) As IntPtr

    'Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
    '    SendMessage(Me.Handle, msg.Msg, msg.WParam, msg.LParam)
    '    Return MyBase.ProcessCmdKey(msg, keyData)
    'End Function

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Type here the Child Table name if any, otherwise leave it blank.")>
    <Browsable(True)>
    Public Property ChildTableName As String = ""

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Type here the Table name usually the Master (Parent) Table name as shown in the Database ")>
    <Browsable(True)>
    Public Property MainTableName As String = ""

    Public Property TableProperties As Array

    Protected Property FormTitleCaption As String = ""

    Private Property RecordCount As Integer

    Public Function ValidateView()
        Dim validationsPassed As Boolean
        validationsPassed = True
        Dim allControls As New List(Of Control)
        Dim originalValue As String
        For Each cCtrl As Control In FindControlRecursive(allControls, Me)
            If TypeOf cCtrl Is IEntryControl Then
                If TypeOf cCtrl Is CTextBoxIdNo Then
                    ' no validations for this type of control. These are Identity Columns and are filled automatically
                    ' by the Data Server.
                ElseIf TypeOf cCtrl Is CTextBox AndAlso GetPropertyValue(cCtrl, "ComputedValue") Then
                    ' ignore this also computed values don't need to be validated for empty values
                ElseIf TypeOf cCtrl Is CTextBoxArabic Then
                    Dim thisControl As CTextBoxArabic
                    thisControl = cCtrl
                    If thisControl.EnglishControl Is Nothing Then
                        MessageBox.Show($"EnglishControl for  CTextBoxArabic control <{thisControl.Name}> not set.")
                    End If
                    originalValue = PresenterObj.GetOriginalValue(thisControl.EnglishControl)
                    Dim englishText As String = GetPropertyValue(thisControl.EnglishControl, "Text")
                    If thisControl.AutoFill And String.IsNullOrEmpty(cCtrl.Text) OrElse cCtrl.Text.Trim() = originalValue Then
                        thisControl.Text = englishText
                    End If
                ElseIf TypeOf cCtrl Is CTextBox OrElse TypeOf cCtrl Is CTextBoxArabic Then
                    ' check for duplicate values
                    If GetPropertyValue(cCtrl, "ValueIsUnique") Then
                        Dim fldName As String = cCtrl.Name.Substring(3)
                        Dim fieldDescription As String
                        If GetPropertyValue(cCtrl, "LinkedLabel") Is Nothing Then
                            fieldDescription = fldName
                        Else
                            Dim cTextCtrl As CTextBox
                            cTextCtrl = cCtrl
                            fieldDescription = GetPropertyValue(cTextCtrl.LinkedLabel, "Text")
                        End If
                        Dim recordIsNotUnique = False
                        If PresenterObj.AddMode Then
                            If PresenterObj.IsRecordNotUnique(cCtrl, fldName) Then
                                recordIsNotUnique = True
                            End If
                        Else
                            originalValue = PresenterObj.GetOriginalValue(cCtrl)
                            ' if value did not change no need to check for duplicate values.
                            If cCtrl.Text <> originalValue Then
                                If PresenterObj.IsRecordNotUnique(cCtrl, fldName) Then
                                    recordIsNotUnique = True
                                End If
                            End If
                        End If
                        If recordIsNotUnique Then
                            _MBUniqueConstraintViolated.Show(Me, {cCtrl.Text, fieldDescription})
                            validationsPassed = False
                        End If
                    End If
                End If
            End If
        Next
        PresenterObj.AutoValidationsPassed = validationsPassed
        Return validationsPassed
    End Function

    Public Sub CheckDataChanges()
    End Sub

    Public Sub gotoTargetRecordWorker_DoWorkHandler(sender As Object, e As DoWorkEventArgs(Of String))
        If GotoTargetRecordWorker.CancellationPending Then
            e.Cancel = True
            Return
        End If
        PresenterObj.TargetIdNo = e.Argument
        PresenterObj.RecordPositionNumber = PresenterObj.GetSortedRecordPosition(PresenterObj.TargetIdNo)
        PresenterObj.TargetIdNo = PresenterObj.GetIdNoOfSortedPositionNumber(PresenterObj.RecordPositionNumber)
        PresenterObj.UpdateViewDisplay(PresenterObj.TargetIdNo)
        DoPaintEvents()
    End Sub

    Public Sub showWaitForm_DoWorkHandler(sender As Object, e As DoWorkEventArgs(Of String))
        'Dim progress As Int32 = 0
        'Dim IdNoTarget as Int32 = 0
        'waitMessageSetter.RunWorkerAsync(e.Argument)
        'Debugger.Break()
        'Do While IdNoTarget = 0
        If ShowWaitForm.CancellationPending Then
            e.Cancel = True
            Return
        End If
        'Thread.Sleep(10)
        'showWaitForm.ReportProgress(progress)
        'Debugger.Break()
        e.Result = PresenterObj.GetIdNoOfSortedPositionNumber(PresenterObj.RecordPositionNumber)
        '_resetEvent.Set()
        'Thread.Sleep(10)
        'loop
        'showWaitForm.ReportProgress(progress)
    End Sub

    Protected Overridable Sub AddMandatoryFieldCHeck()
    End Sub

    Protected Overridable Function ChangesMade()
        Return PresenterObj.ChangesMade()
    End Function

    Protected Overridable Sub DisplayView(idNo As Integer)
        Debugger.Break()
    End Sub

    Protected Sub UpdateButtonDisplays(editing As Boolean, adding As Boolean)
        If RecordCount = 0 Then
            btnFirst.Enabled = False
            btnPrev.Enabled = False
            btnNext.Enabled = False
            btnLast.Enabled = False
            btnEdit.Enabled = False
            btnDelete.Enabled = False
            btnUndo.Enabled = False
            btnSave.Enabled = False
            btnFind.Enabled = False
            PresenterObj.RecordPositionNumber = 0
            If Not PresenterObj.AddMode Then
                btnUndo.Enabled = False
                btnSave.Enabled = False
                Messaging.Show(True, "MsgNoRecordsFound", "No records found for this table!", "Empty Table")
            Else
                btnSave.Enabled = True
                btnUndo.Enabled = True
            End If
        Else
            If PresenterObj.RecordPositionNumber = 1 Then
                btnFirst.Enabled = False
                btnPrev.Enabled = False
                btnLast.Enabled = True
                btnNext.Enabled = True
            Else
                btnFirst.Enabled = True
                btnPrev.Enabled = True
                btnLast.Enabled = True
                btnNext.Enabled = True
            End If
            If PresenterObj.RecordPositionNumber = RecordCount Then
                btnLast.Enabled = False
                btnNext.Enabled = False
                btnFirst.Enabled = True
                btnPrev.Enabled = True
            Else
                btnLast.Enabled = True
                btnNext.Enabled = True
            End If
            If editing OrElse adding Then
                btnEdit.Enabled = False
                btnAdd.Enabled = False
                btnDelete.Enabled = False
                btnUndo.Enabled = True
                btnSave.Enabled = True
            Else
                btnEdit.Enabled = True
                btnDelete.Enabled = True
                btnAdd.Enabled = True
                btnUndo.Enabled = False
                btnSave.Enabled = False
            End If
        End If
    End Sub

    Private Shared Sub SetControlVisibility(ByRef cCtrl As Control, controlVisible As Boolean)
        ' if Visible is false, Don't show the controls content by masking content with '*' asterisk
        If Not controlVisible Then
            SetPropertyValue(cCtrl, "PasswordChar", Convert.ToChar("*"))
        End If
    End Sub

    Private Sub btnArabic_Click(sender As Object, e As EventArgs) Handles btnArabic.Click
        SwitchUiLanguage(False)
    End Sub

    Private Sub btnOriginal_Click(sender As Object, e As EventArgs) Handles btnOriginal.Click
        SwitchUiLanguage(True)
    End Sub

    Private Sub btnTranslate_Click(sender As Object, e As EventArgs) Handles btnTranslate.Click
        If _debugSwitch Then
            Debugger.Break()
        End If
        Dim frm As New TranslationTableManager()
        frm.FormIdNoToTranslate = FormIdNo
        frm.AppDataDAC = AppDataDAC
        frm.TranslatorDAC = TranslatorDAC
        frm.Show()
    End Sub

    Private Sub CFormEntry_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing
        If CancelClose Then
            e.Cancel = True
        Else
            CancelClose = False
        End If
    End Sub

    Private Sub CFormEntry_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        CloseForm()
    End Sub

    Private Sub CFormEntry_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F10 Then
            If btnSave.Enabled Then
                e.SuppressKeyPress = True
                e.Handled = True
                PresenterObj.Save()
            Else
                Beep()
            End If
        ElseIf e.KeyCode = Keys.F2 Then
            If btnSave.Enabled Then
                e.SuppressKeyPress = True
                e.Handled = True
                PresenterObj.EditData()
            Else
                Beep()
            End If
            'Else
            '    e.Handled = False
        End If
    End Sub

    Private Sub CFormEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime) Then

            AddHandler TextDisplayLanguageChanged, AddressOf OnTextDisplayLanguageChanged
            TextDisplayLanguage = CultureInfo.CurrentCulture.Name
            CreateDataSources()
            CreateFieldsDictionary()
            TurnOffInputs()

            Try
                PresenterObj.RecordPositionNumber = PresenterObj.GetRecordCount()
                'If PresenterObj.RecordPositionNumber <> 0 Then
                '    'PresenterObj.TargetIdNo = PresenterObj.GetIdNoOfSortedPositionNumber(PresenterObj.RecordPositionNumber)
                '    'PresenterObj.UpdateViewDisplay(PresenterObj.TargetIdNo)
                '    'RaiseEvent DisplayedRecordChanged()
                'Else
                '    UpdateButtonDisplays(False, False)
                'End If
            Catch ex As Exception
                MessageBox.Show(ex.Message + Name)
                Debugger.Break()
            End Try

            'TableDefaultFieldValues = PresenterObj.GetDefaultFieldValues()
            Dim rules = PresenterObj.GetBizObjectRules()
            For Each rule In rules
                Dim control As Control = Nothing
                FieldsDictionary.TryGetValue(rule.Property, control)
                MyErrorProvider.Controls.AddValidation(control, rule.Property, rule.Error)
            Next
            SetAllControlsDynamicProperties()
            RaiseEvent AfterLoad()
            AddMandatoryFieldCHeck()
            If GlobalVariables.RightToLeftLayout Then
                btnArabic.Visible = False
                btnOriginal.Visible = True
            Else
                btnArabic.Visible = True
                btnOriginal.Visible = False
            End If
            FirstControl.Focus()
        End If
    End Sub

    Private Sub ClearData()
        Dim allCtrl As New List(Of Control)
        Dim initValue = ""
        For Each cCtrl As Control In FindControlRecursive(allCtrl, Me)
            Try
                If TypeOf cCtrl Is CTextBox OrElse TypeOf cCtrl Is CMaskedTextBox Then
                    Try
                        initValue = GetPropertyValue(cCtrl, "DefaultValue")
                    Catch ex As Exception
                        '' ignore error if no 'DefaultValue' property
                    End Try
                    cCtrl.Text = initValue
                ElseIf TypeOf cCtrl Is TxtComboBox Then
                    CallByName(cCtrl, "MakeDefault", CallType.Method)
                ElseIf TypeOf cCtrl Is CComboBox Or TypeOf cCtrl Is CaComboBox Then
                    'SetPropertyValue(cCtrl, "Text", "")
                    SetPropertyValue(cCtrl, "SelectedItem", Nothing)
                    SetPropertyValue(cCtrl, "SelectedIndex", -1)
                    SetPropertyValue(cCtrl, "Text", "")
                ElseIf _
                    TypeOf cCtrl Is CCustomDateTimePicker OrElse TypeOf cCtrl Is CDTPHijriDate OrElse
                    TypeOf cCtrl Is tdpGregorian OrElse TypeOf cCtrl Is CDtpGregorianDate Then
                    SetPropertyValue(cCtrl, "Value", Nothing)
                End If
            Catch ' ignore fields that don't have a column to bind to
                ''
            End Try
        Next
    End Sub

    Private Sub CloseForm()

        If PresenterObj.OkToMove() Then
            CancelClose = False
            'Close()
            If GlobalVariables.AppCurrentCultureInfo.Name <> TextDisplayLanguage Then
                TextDisplayLanguage = GlobalVariables.AppCurrentCultureInfo.Name
            End If
            GC.Collect()
            GC.WaitForPendingFinalizers()
            If (Environment.OSVersion.Platform = PlatformID.Win32NT) Then
                SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1)
            End If
            Dispose()
        Else
            CancelClose = True
        End If
    End Sub

    Private Sub SetControlDynamicProperties(ByRef cCtrl As Control)
        'If cCtrl.GetType().GetProperty("DataBoundControl") IsNot Nothing Then
        If TypeOf cCtrl Is IEntryControl Then
            ' get FieldName from control : by convention when using this system
            ' all DataBoundControls TextBox & Combobox that will hold field variables are named by convention in this format
            ' textboxes  = txt<FieldName>
            ' combobox   = cbo<FieldName>
            ' datetimepicker = dtp<FieldName>
            ' so to get the field name just get the characters from the control starting at the 4th character onwards
            Dim fldName As String
            fldName = cCtrl.Name.Substring(3) ' get control name starting from the 3rd character (0 based)

            For Each row In TableProperties
                'If fldName.ToLower() = "amount" Then
                '    Debugger.Break()
                'End If
                If fldName.ToLower() = row.FldName.ToLower Then
                    If TypeOf cCtrl Is CTextBox OrElse TypeOf cCtrl Is CComboBox OrElse TypeOf cCtrl Is CMaskedTextBox OrElse
                       TypeOf cCtrl Is CTextBoxArabic Then
                        'Dim mm As TextBox = CCtrl
                        If row.FldType.ToLower = "int" OrElse row.FldType.ToLower = "numeric" OrElse row.FldType.ToLower = "decimal" OrElse row.FldType.ToLower = "single" OrElse row.FldType.ToLower = "money" Then
                            If row.FldType.ToLower = "money" Then
                                SetPropertyValue(cCtrl, "Maxlength", 19)
                            Else
                                SetPropertyValue(cCtrl, "Maxlength", row.MaxLength)
                            End If

                            SetPropertyValue(cCtrl, "ValueIsNumeric", True)
                            'If CommonDaoOld.IsFieldUnique(MainTableName, fldName) Then
                            '    If TypeOf cCtrl Is CTextBox Or TypeOf cCtrl Is CTextBoxArabic Then
                            '        SetPropertyValue(cCtrl, "ValueIsUnique", True)
                            '    End If
                            'Else
                            '    If TypeOf cCtrl Is CTextBox Or TypeOf cCtrl Is CTextBoxArabic Then
                            '        SetPropertyValue(cCtrl, "ValueIsUnique", False)
                            '    End If
                            'End If
                        Else
                            'If cCtrl.Name.ToLower() = "txtnotes" then
                            '    debugger.Break()
                            'End If
                            SetPropertyValue(cCtrl, "Maxlength", If(row.fldType.ToLower() = "nvarchar", Convert.ToInt16(row.MaxLength / 2), row.MaxLength))
                            SetPropertyValue(cCtrl, "ValueIsNullable", row.IsNullable)
                            If (Not row.IsIdentity) And (Not row.IsNullable) Then
                                'Add this controls in error provider for mandatory fields.
                                'MyErrorProvider.Controls.AddMandatory(CCtrl, CCtrl.Name)
                                'Dim thisCtrl As CTextBox
                                'thisCtrl = cCtrl
                                If GetPropertyValue(cCtrl, "IgnoreNullCheck") Then
                                    'If Not thisCtrl.IgnoreNullCheck Then
                                    If GetPropertyValue(cCtrl, "LinkedLabel") Is Nothing Then
                                        ''If thisCtrl.LinkedLabel Is Nothing Then
                                        MyErrorProvider.Controls.AddMandatory(cCtrl, cCtrl.Name)
                                    Else
                                        MyErrorProvider.Controls.AddMandatory(cCtrl, GetPropertyValue(cCtrl, "LinkedLabel"))
                                        'MyErrorProvider.Controls.AddMandatory(cCtrl, thisCtrl.LinkedLabel.Text)
                                    End If
                                End If
                                'If CommonDaoOld.IsFieldUnique(MainTableName, fldName) Then
                                '    If TypeOf cCtrl Is CTextBox Or TypeOf cCtrl Is CTextBoxArabic Then
                                '        SetPropertyValue(cCtrl, "ValueIsUnique", True)
                                '    End If
                                'Else
                                '    If TypeOf cCtrl Is CTextBox Or TypeOf cCtrl Is CTextBoxArabic Then
                                '        SetPropertyValue(cCtrl, "ValueIsUnique", False)
                                '    End If
                                'End If
                            End If
                        End If
                        Exit For
                    ElseIf _
                        TypeOf cCtrl Is CCustomDateTimePicker OrElse TypeOf cCtrl Is CDateTimePicker OrElse
                        TypeOf cCtrl Is CDTPHijriDate OrElse TypeOf cCtrl Is tdpGregorian OrElse
                        TypeOf cCtrl Is CDtpGregorianDate Then
                        SetPropertyValue(cCtrl, "ValueIsNullable", row.IsNullable)
                        If Not row.IsNullable Then
                            'Add this controls to the Mandatory fields error provider.
                            MyErrorProvider.Controls.AddMandatory(cCtrl, cCtrl.Name)
                        End If
                        Exit For
                    End If

                End If
            Next
        End If
    End Sub

    Private Sub SetControlEditability(ByRef cCtrl As Control, ByRef editable As Boolean)
        ' if Editable is False, make the control readonly property so that it can't be edited
        If Not editable Then
            SetPropertyValue(cCtrl, "DisplayOnly", True)
        End If
    End Sub

    Private Sub SwitchUiLanguage(originalUi As Boolean)
        If _debugSwitch Then
            Debugger.Break()
        End If
        If originalUi Then
            TextDisplayLanguage = GlobalVariables.DefaultUnmirroredCultureInfoStr
        Else
            TextDisplayLanguage = GlobalVariables.DefaultMirroredCultureInfoStr
        End If
        TranslateForm()
        UpdateRecordCounter()
        If PresenterObj.EditMode Or PresenterObj.AddMode Then
            PresenterObj.Undo()
        End If
        btnArabic.Visible = originalUi
        btnOriginal.Visible = Not originalUi
        PresenterObj.UpdateViewDisplay(PresenterObj.TargetIdNo)
    End Sub

#Region "OK PubsSubs"

    Public Sub FindField(txtControl As Control)
        Dim fieldName As String = txtControl.Name.Substring(3)
        Dim searchString As String
        Dim searchAnywhere As Boolean
        searchString = CallByName(txtControl, "GetTextToSearch", CallType.Get)
        searchAnywhere = CallByName(txtControl, "GetSearchAnywhere", CallType.Get)
        PresenterObj.FindField(fieldName, searchString, searchAnywhere)
    End Sub

    Public Function GetFieldsDictionary()
        Return FieldsDictionary
    End Function

    Public Sub HideButton(button As ToolStripButton)
        button.Visible = False
    End Sub

    Public Sub SetFormTitleCaption()
        lblFormDescription.Text = Text
        lblFormDescription.Left = 0
        lblFormDescription.Width = Me.Width
        lblFormDescription.TextAlign = ContentAlignment.MiddleCenter
    End Sub

    Public Sub ShowFormTitle()
        lblFormDescription.Text = FormTitleCaption
        lblFormDescription.Width = Me.Width
        lblFormDescription.Left = 0
        lblFormDescription.TextAlign = ContentAlignment.MiddleCenter
    End Sub

    Public Sub TurnOffInputs()
        Inputs(False)
        RaiseEvent InputsTurnedOff()
    End Sub

    Public Sub TurnOnInputs()
        Inputs(True)
        RaiseEvent InputsTurnedOn()
    End Sub

    Protected Overridable Sub CreateDataSources()
        '
    End Sub

    Protected Overridable Sub CreateFieldsDictionary()
        '
    End Sub

    Protected Overridable Sub OnTextDisplayLanguageChanged() Handles Me.TextDisplayLanguageChanged
        CultureInfo.CurrentCulture = New CultureInfo(TextDisplayLanguage, False)
        If CultureInfo.CurrentCulture.TextInfo.IsRightToLeft Then
            GlobalVariables.RightToLeftLayout = True
        Else
            GlobalVariables.RightToLeftLayout = False
        End If
        CreateDataSources()
    End Sub

    Private Sub btnDebug_Click(sender As Object, e As EventArgs) Handles btnDebug.Click
        If _debugSwitch = 0 Then
            _debugSwitch = 1
            btnDebug.Checked = False
        Else
            _debugSwitch = 0
            btnDebug.Checked = True
        End If
    End Sub

    Private Sub CopyToolStripButton_Click(sender As Object, e As EventArgs) Handles CopyToolStripButton.Click
        CopyText()
    End Sub

    Private Sub CutToolStripButton_Click(sender As Object, e As EventArgs) Handles CutToolStripButton.Click
        CutText()
    End Sub

    Private Function GetControlSecurityIdNo(ByRef controlSecurityKey As String) As Int64
        Return SecurityPresenterObj.GetControlSecurityIdNo(controlSecurityKey)
    End Function

    Private Function GetControlSecurityKey(ByRef cCtrl As Control)
        If Not (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime) Then
            If cCtrl.GetType().GetProperty("SecurityKey") IsNot Nothing Then
                Return GetPropertyValue(cCtrl, "SecurityKey")
            End If
        End If
        Return ""
    End Function

    Private Function GetControlSecurityValues(ByRef controlSecurityKey As String) As ArrayList
        Dim controlSecurityObjectIdNo As Int32
        controlSecurityObjectIdNo = GetControlSecurityIdNo(controlSecurityKey)
        Return SecurityPresenterObj.GetUserSecurity(controlSecurityObjectIdNo, GlobalVariables.SecurityGroupIdNo)
    End Function

    Private Sub Inputs(onOff As Boolean)
        Dim allCtrl As New List(Of Control)
        Dim ctrl As Control
        For Each ctrl In FindControlRecursive(allCtrl, Me)
            If TypeOf ctrl Is IEntryControl Then
                SetPropertyValue(ctrl, "EditingMode", Not onOff)
            End If
        Next
        FirstControl.Focus()
    End Sub

    Private Sub OnBeforeLoad() Handles MyBase.BeforeLoad
        SetFormTitleCaption()
    End Sub

    Private Sub PasteToolStripButton_Click(sender As Object, e As EventArgs) Handles PasteToolStripButton.Click
        PasteText()
    End Sub

    Private Sub SetAllControlsDynamicProperties()
        If Not (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime) Then
            Dim allControls As New List(Of Control)
            Dim resources = New ComponentResourceManager(Me.GetType())
            TableProperties = PresenterObj.TableProperties
            For Each cCtrl As Control In FindControlRecursive(allControls, Me)
                SetControlDynamicProperties(cCtrl)
                SetControlSecurity(cCtrl)
            Next
        End If
    End Sub

    Private Sub BtnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        RunButtonRoutine(ButtonClicked.First)
    End Sub

    Private Sub BtnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        RunButtonRoutine(ButtonClicked.Previous)
    End Sub

    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        RunButtonRoutine(ButtonClicked.Next)
    End Sub

    Private Sub BtnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        RunButtonRoutine(ButtonClicked.Last)
    End Sub

    Private Sub BtnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        RunButtonRoutine(ButtonClicked.Find)
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        RunButtonRoutine(ButtonClicked.Delete)
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        RunButtonRoutine(ButtonClicked.Edit)
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        RunButtonRoutine(ButtonClicked.Save)
    End Sub

    Private Sub BtnUndo_Click(sender As Object, e As EventArgs) Handles btnUndo.Click
        RunButtonRoutine(ButtonClicked.Quit)
    End Sub

    Private Sub BtnQuit_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
        RunButtonRoutine(ButtonClicked.Quit)
    End Sub

    Private Sub RunButtonRoutine(ByVal clickedButton As ButtonClicked)
        If GlobalVariables.EventAggregator IsNot Nothing Then
            GlobalVariables.EventAggregator.PublishEvent(New SelectedButton(clickedButton))
        End If
    End Sub

    Private Sub UpdateRecordCounter()
        RecordCount = PresenterObj.GetRecordCount()
        RecordDateTimeStampValue = PresenterObj.GetRecordDateTimeStamp(PresenterObj.TargetIdNo)
        tsbCurrentRecord.Text = PresenterObj.RecordPositionNumber
        tsbTotalRecords.Text = RecordCount
    End Sub

    Public Sub OnEventHandler(e As RecordPositionChanged) Implements ISubscriber(Of RecordPositionChanged).OnEventHandler
        UpdateRecordCounter()
        UpdateButtonDisplays(False, False)
        MyErrorProvider.ClearAllErrorMessages()
        MyErrorProvider.Clear()
        TurnOffInputs()
        Refresh()
    End Sub

    Public Sub OnEventHandler(e As EditModeChanged) Implements ISubscriber(Of EditModeChanged).OnEventHandler
        If e.EditMode Then
            TurnOnInputs()
            UpdateButtonDisplays(True, False)
        Else
            TurnOffInputs()
            UpdateButtonDisplays(False, False)
        End If
    End Sub

    Public Sub OnEventHandler(e As AddModeChanged) Implements ISubscriber(Of AddModeChanged).OnEventHandler
        If e.AddMode Then
            TurnOnInputs()
            ClearData()
            UpdateButtonDisplays(False, True)
        Else
            TurnOffInputs()
            UpdateButtonDisplays(False, False)
        End If
    End Sub

    Public Sub OnEventHandler(e As ValidatingData) Implements ISubscriber(Of ValidatingData).OnEventHandler
        If ValidateView() Then
            e.Validated = True
        Else
            e.Validated = False
        End If
    End Sub

    Public Sub OnEventHandler(e As PassErrorList) Implements ISubscriber(Of PassErrorList).OnEventHandler
        MyErrorProvider.ClearAllErrorMessages()
        For Each _err In e.Errors
            For Each ctrl In MyErrorProvider.Controls
                If ctrl.errormessage = _err Then
                    MyErrorProvider.SetError(ctrl.ControlObj, _err)
                End If
            Next
        Next

    End Sub

#End Region

End Class