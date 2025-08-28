Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.Threading
Imports System.Windows.Forms
Imports AATM.Libraries
Imports AATM.Libraries.AatmInterfaces
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.Localization
Imports AATM.Libraries.Localization.Core
Imports AATM.Libraries.Localization.Services
Imports AATM.PresentationLayer.Events
Imports AATM.PresentationLayer.Forms.Services.SystemView
Imports AATM.PresentationLayer.Presenters

Public Class CFormEntry
    Implements IViewDataEntry

    Public MainFieldsDictionary As New Dictionary(Of String, Object)
    Public GotoTargetRecordWorker As BackgroundWorker(Of String)
    Public ShowWaitForm As BackgroundWorker(Of String)
    Public DisallowSaves As Boolean = False
    Protected Const TurnOff As Boolean = False
    Protected Shared _resetEvent As AutoResetEvent = New AutoResetEvent(False)
    Public FirstControl As Control
    Protected ParentFieldName As String = ""
    Protected RecordDateTimeStampValue As Object
    Protected SingleData As Boolean = False
    Protected AutoAddOnSave As Boolean = False
    Protected EditingAllowed As Boolean = False
    Protected AddingAllowed As Boolean = False
    Protected DeletingAllowed As Boolean = False
    Private _debugSwitch As Byte = 0
    Private _shownInitialized As Boolean
    Private _currentFormCulture As CultureInfo = CultureInfo.CurrentCulture
    Private _formIsRtl As Boolean = CultureInfo.CurrentCulture.TextInfo.IsRightToLeft

    'Private _addMode As Boolean = False
    'Private _editMode As Boolean = False
    'Private _recordCount As Int32 = 0
    'Private _recordPositionNumber As Int32 = 0
    Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat
    Private _translationRepo As ITranslationRepository
    Private _translationCache As TranslationCache
    Private _formTranslator As FormTranslationService
    Private _systemViewIdProvider As SystemViewIdProvider


    Public Sub New(repo As ITranslationRepository, cache As TranslationCache)
        InitializeComponent()
        DoubleBuffered = True
        _translationRepo = repo
        _translationCache = cache
        _formTranslationService = New FormTranslationService(Me, _translationRepo, _translationCache)
    End Sub

    Protected EditingMode As Boolean = False
    Protected AddingMode As Boolean = False
    Private _displayOnly As Boolean = False
    Private _translatable As Boolean = True
    Private _firstLoadSwitch As UInt16 = 0

    Public Event AfterUpdateView()
    Public Property AddOnOpen As Boolean = False

    Public Event AfterSave()

    Public Event InputsTurnedOn()

    Public Event InputsTurnedOff()

    Public Event AfterChangeRecord()
    Public Event BeforeChangeRecord()

    Public Sub New()
        'MyBase.New()
        ' This call is required by the designer.
        InitializeComponent()
        DoubleBuffered = True
        _inputTurnedOn = False
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Delegate Sub SafeCallDelegate(ByRef controlObject As Control, textString As String)

    Private Declare Function SetProcessWorkingSetSize Lib "kernel32.dll" (hProcess As IntPtr,
                                                                         dwMinimumWorkingSetSize As Int32,
                                                                          dwMaximumWorkingSetSize As Int32) As Int32

    ' Ensure provider re-usable & safe
    Private Sub EnsureSystemViewIdProvider()
        If _systemViewIdProvider Is Nothing Then
            _systemViewIdProvider = New SystemViewIdProvider(
                    translatorDac:=TranslatorDAC,
                    viewNameFunc:=Function() If(String.IsNullOrWhiteSpace(ViewDisplayName), Me.Name, ViewDisplayName)
                )
        End If
    End Sub



    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Type here the Child Table name if any, otherwise leave it blank.")>
    <Browsable(True)>
    Public Property ChildTableName As String = ""
    Public Property TableProperties As Array

    Protected Property FormTitleCaption As String = ""

    Public ReadOnly Property CurrentFormCulture As CultureInfo
        Get
            Return _CurrentFormCulture
        End Get
    End Property

    Public ReadOnly Property FormIsRtl As Boolean
        Get
            Return _formIsRtl
        End Get
    End Property

    Private Sub OnCFormEntryNewShown() Handles MyBase.Shown
        If _shownInitialized Then Return   ' guard against accidental re-entry

        ' Decide initial UI direction based on current thread culture (read-only)
        Dim rtl = CultureInfo.CurrentCulture.TextInfo.IsRightToLeft
        _currentFormCulture = CultureInfo.CurrentCulture
        _formIsRtl = rtl
        SwitchUiLanguage(originalUi:=Not rtl) ' originalUi=True means default LTR language (will not change globals)

        Me.Activate()

        PublishClickedButton(ButtonClicked.Last)
        SetFormTitleCaption()
        _shownInitialized = True
    End Sub

    'Private Sub OnCFormEntryNewShown() Handles MyBase.Shown
    '    'SuspendDrawing()
    '    If CultureInfo.CurrentCulture.TextInfo.IsRightToLeft Then
    '        If btnArabic.Enabled Then
    '            'btnArabic.PerformClick()
    '            SwitchUiLanguage(False)
    '        End If
    '    Else
    '        If Not btnArabic.Enabled Then
    '            'btnOriginal.PerformClick()
    '            SwitchUiLanguage(True)
    '        End If
    '    End If
    '    Me.Activate()
    '    'Dim allCtrl As New List(Of Control)
    '    'allCtrl = FindControlRecursive(allCtrl, Me)
    '    'For Each control In allCtrl
    '    '    If TypeOf control Is CtDataGridView Then
    '    '        Dim dgv As CtDataGridView
    '    '        dgv = DirectCast(control, CtDataGridView)
    '    '        dgv.MakeGridSearchable()
    '    '    End If
    '    'Next
    '    FormShown = True
    '    PublishClickedButton(ButtonClicked.Last)
    '    SetFormTitleCaption()
    '    'ResumeDrawing()
    'End Sub

    'Public Property RecordCount As Integer Implements IViewDataEntry.RecordCount
    '    Get
    '        Return _recordCount
    '    End Get
    '    Set(value As Integer)
    '        _recordCount = value
    '        tsbTotalRecords.Text = value
    '        UpdateNavigationButtonDisplay(False, False)
    '    End Set
    'End Property

    'Public Property RecordPositionNumber As Integer Implements IViewDataEntry.RecordPositionNumber
    '    Get
    '        Return _recordPositionNumber
    '    End Get
    '    Set(value As Integer)
    '        _recordPositionNumber = value
    '        tsbCurrentRecord.Text = value
    '        UpdateNavigationButtonDisplay(False, False)
    '    End Set
    'End Property

    Public Overridable Sub UpdateViewDisplay(editMode As Boolean, addMode As Boolean, recordPositionNumber As Integer, targetIdNo As Integer, recordCount As Integer)
        'Me.SuspendDrawingNew()
        If Not HideNavigatorButtons Then
            tsbCurrentRecord.Text = recordPositionNumber.ToString()
            tsbTotalRecords.Text = recordCount.ToString()
            Application.DoEvents()
            UpdateNavigationButtonDisplay(editMode, addMode, recordPositionNumber, recordCount)
        End If
        If addMode Or editMode Then
            TurnOnInputs()
        Else
            TurnOffInputs()
        End If
        RaiseEvent AfterUpdateView()
        'Me.ResumeDrawingNew
    End Sub

    'Protected Overridable Sub OnAfterRecordChanged() Handles Me.AfterUpdateView
    'End Sub

    Public Property QuitOnSave As Boolean Implements IViewDataEntry.QuitOnSave

    'Public Property DataFilter As String Implements IViewDataEntry.DataFilter

    Public Sub CheckDataChanges()
    End Sub

    'Public Function GetEventAggregator() As EventAggregator
    '    Return Ea
    'End Function

    'Public Property AddMode As Boolean
    '    Get
    '        Return _addMode
    '    End Get
    '    Set(value As Boolean)
    '        _addMode = value
    '        UpdateNavigationButtonDisplay(EditMode, value)
    '    End Set
    'End Property

    'Public Property EditMode As Boolean
    '    Get
    '        Return _editMode
    '    End Get
    '    Set(value As Boolean)
    '        _editMode = value
    '        UpdateNavigationButtonDisplay(value, AddMode)
    '    End Set
    'End Property

    Public Sub FindFieldNew(findableControl As IFindableControl)
        Ea.PublishEvent(New FindFieldRequested(findableControl))
    End Sub

    Public Function GetMainFieldsDictionary()
        Return MainFieldsDictionary
    End Function

    Public Sub HideButton(button As ToolStripButton)
        button.Visible = False
    End Sub

    Public Sub SetFormTitleCaption()
        lblFormDescription.Text = Text
        lblFormDescription.Left = 0
        lblFormDescription.Width = Width
        lblFormDescription.TextAlign = ContentAlignment.MiddleCenter
    End Sub

    Public Sub ShowFormTitle()
        lblFormDescription.Text = FormTitleCaption
        lblFormDescription.Width = Width
        lblFormDescription.Left = 0
        lblFormDescription.TextAlign = ContentAlignment.MiddleCenter
    End Sub

    Private _inputTurnedOn As Boolean = False

    Public Overridable Sub TurnOffInputs()
        If _inputTurnedOn Then
            Inputs(False)
            _inputTurnedOn = False
        End If
        'RaiseEvent InputsTurnedOff()
    End Sub

    Public Overridable Sub TurnOnInputs()
        If Not _inputTurnedOn Then
            Inputs(True)
            _inputTurnedOn = True
        End If
        'RaiseEvent InputsTurnedOn()
        'If FirstControl IsNot Nothing Then
        '    FirstControl.Focus()
        'End If
    End Sub

    'Protected Overridable Sub CreateDataSources()
    '    '
    'End Sub

    Protected Overridable Sub CreateMainFieldsDictionary()
        '
    End Sub

    Protected Overridable Sub OnTextDisplayLanguageChanged() Handles Me.TextDisplayLanguageChanged
        PublishEvent(New LanguageChanged(Me))
    End Sub

    Protected Sub UpdateNavigationButtonDisplay(editing As Boolean, adding As Boolean, recordPositionNumber As Integer, recordCount As Integer)
        If SingleData Then
            btnAdd.Visible = False
            btnFind.Visible = False
            HideNavigatorButtons = True
            If adding Or editing Then
                btnQuit.Enabled = False
                If Not DisallowSaves Then
                    btnSave.Enabled = True
                End If
                btnUndo.Enabled = True
            Else
                btnEdit.Enabled = True
                btnQuit.Enabled = True
                btnSave.Enabled = False
                btnUndo.Enabled = False
            End If
        Else
            If adding Or editing Then
                btnFirst.Enabled = False
                btnPrev.Enabled = False
                btnNext.Enabled = False
                btnLast.Enabled = False
                btnEdit.Enabled = False
                btnAdd.Enabled = False
                btnDelete.Enabled = False
                btnPrint.Enabled = False
                btnFind.Enabled = False
                btnQuit.Enabled = False
                btnFilter.Enabled = False
                If Not DisallowSaves Then
                    btnSave.Enabled = True
                End If
                btnUndo.Enabled = True
            Else
                btnFirst.Enabled = True
                btnPrev.Enabled = True
                btnNext.Enabled = True
                btnLast.Enabled = True
                btnEdit.Enabled = True
                btnAdd.Enabled = True
                btnDelete.Enabled = True
                btnPrint.Enabled = True
                btnFind.Enabled = True
                btnQuit.Enabled = True
                btnFilter.Enabled = True
                btnSave.Enabled = False
                btnUndo.Enabled = False
            End If
            If recordCount = 0 Then
                btnFirst.Enabled = False
                btnPrev.Enabled = False
                btnNext.Enabled = False
                btnLast.Enabled = False
                btnEdit.Enabled = False
                btnAdd.Enabled = True
                btnDelete.Enabled = False
                btnFind.Enabled = False
                btnPrint.Enabled = False
                If adding Or editing Then
                    If Not DisallowSaves Then
                        btnSave.Enabled = True
                    End If
                    btnUndo.Enabled = True
                Else
                    btnSave.Enabled = False
                    btnUndo.Enabled = False
                End If
            ElseIf recordPositionNumber = 1 Then
                btnFirst.Enabled = False
                btnPrev.Enabled = False
                If recordCount = 1 Then
                    btnNext.Enabled = False
                    btnLast.Enabled = False
                End If
            ElseIf recordPositionNumber = recordCount Then
                btnNext.Enabled = False
                btnLast.Enabled = False
            End If
        End If
        If Not EditingAllowed Then
            btnEdit.Visible = False
        End If
        If Not AddingAllowed Then
            btnAdd.Visible = False
        End If
        If Not DeletingAllowed Then
            btnDelete.Visible = False
        End If



    End Sub

    'Private Shared Sub SetControlVisibility(ByRef cCtrl As Control, controlVisible As Boolean)
    '    ' if Visible is false, Don't show the controls content by masking content with '*' asterisk
    '    If Not controlVisible Then
    '        If TypeOf cCtrl Is CTextBox OrElse TypeOf cCtrl Is TextBox Then

    '        End If
    '        SetPropertyValue(cCtrl, "PasswordChar", Convert.ToChar("*"))
    '    End If
    'End Sub

    Protected Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If _debugSwitch = 1 Then
            Debugger.Break()
        End If

        AddingMode = True

        BeforeAdd()
        PublishClickedButton(ButtonClicked.Add)

        AfterAdd()
        'UpdateNavigationButtonDisplay(False, True)
    End Sub

    Private Sub BtnArabic_Click(sender As Object, e As EventArgs) Handles btnArabic.Click
        SwitchUiLanguage(False) ' False => mirrored (RTL) culture (e.g., Arabic)
    End Sub

    Private Sub BtnDebug_Click(sender As Object, e As EventArgs) Handles btnDebug.Click
        If _debugSwitch = 0 Then
            _debugSwitch = 1
            Debugger.Break()
            btnDebug.Checked = False
        Else
            _debugSwitch = 0
            btnDebug.Checked = True
        End If
        DoCustomSub()
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If _debugSwitch = 1 Then
            Debugger.Break()
        End If
        PublishClickedButton(ButtonClicked.Delete)
    End Sub

    Protected Overridable Sub BeforeEdit()
    End Sub

    Protected Overridable Sub AfterEdit()
    End Sub

    Protected Overridable Sub BeforeAdd()
    End Sub

    Protected Overridable Sub AfterAdd()
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If _debugSwitch = 1 Then
            Debugger.Break()
        End If
        EditingMode = True
        PublishClickedButton(ButtonClicked.Edit)
        BeforeEdit()
        'If EditMode Then
        '    TurnOnInputs()
        'End If
    End Sub

    Private Sub BtnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        If _debugSwitch = 1 Then
            Debugger.Break()
        End If
        PublishClickedButton(ButtonClicked.Find)
    End Sub

    Private Sub BtnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        If _debugSwitch = 1 Then
            Debugger.Break()
        End If
        PublishClickedButton(ButtonClicked.First)
    End Sub

    Private Sub BtnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        If _debugSwitch = 1 Then
            Debugger.Break()
        End If
        PublishClickedButton(ButtonClicked.Last)
    End Sub

    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If _debugSwitch = 1 Then
            Debugger.Break()
        End If
        PublishClickedButton(ButtonClicked.Next)
    End Sub

    Private Sub BtnOriginal_Click(sender As Object, e As EventArgs) Handles btnOriginal.Click
        SwitchUiLanguage(True)  ' True => original unmirrored (LTR) culture
    End Sub

    Private Sub BtnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        If _debugSwitch = 1 Then
            Debugger.Break()
        End If
        PublishClickedButton(ButtonClicked.Previous)
    End Sub

    Public Sub RefreshTranslation()
        FlickerFreeTranslateForm()
    End Sub

    Public Sub TranslateSpecificControls(newButton, newLabel, myRuntimePanel)
        TranslateFormControls(newButton, newLabel, myRuntimePanel)
    End Sub

    ' Translate one button + one label that were created at runtime and placed inside a panel.
    ' Usage example:
    '    Dim pnl = New Panel()
    '    Dim btn = New Button() With {.Name = "btnApprove", .Tag = "Approve"}    ' Tag (or Name) acts as translation key
    '    Dim lbl = New Label() With {.Name = "lblStatus", .Tag = "Status"}
    '    pnl.Controls.AddRange({btn, lbl})
    '    Me.Controls.Add(pnl)
    '    'Ask form to translate only these new controls
    '    TranslateSpecificControls(btn, lbl, pnl)
    '
    Public Sub TranslateSpecificControls(newButton As Button,
                                         newLabel As Label,
                                         myRuntimePanel As Panel)
        If newButton Is Nothing AndAlso newLabel Is Nothing Then Exit Sub
        If myRuntimePanel Is Nothing Then
            ' Fall back to Me if no container supplied
            TranslateFormControls(newButton, newLabel, Me)
        Else
            TranslateFormControls(newButton, newLabel, myRuntimePanel)
        End If
    End Sub

    ' Overload allowing an arbitrary set of controls.
    Public Sub TranslateSpecificControls(container As Control, ParamArray controls() As Control)
        If container Is Nothing Then container = Me
        For Each c In controls
            If c IsNot Nothing Then
                TranslateFormControls(c, Nothing, container)
            End If
        Next
    End Sub

    Private Sub BtnQuit_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
        If _debugSwitch = 1 Then
            Debugger.Break()
        End If
        Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If _debugSwitch = 1 Then
            Debugger.Break()
        End If
        ForceLooseFocusOnCurrentControl()
        ForceEndEditForAllGridControls()
        Dim saveData As New SaveDataRequested(Me)
        If Ea IsNot Nothing Then
            Ea.PublishEvent(saveData)
        End If
        If saveData.ValidData Then
            RaiseEvent AfterSave()
            If QuitOnSave Then
                Close()
            Else
                If AutoAddOnSave Then
                    btnAdd.PerformClick()
                End If
            End If
        End If
        EditingMode = False
        AddingMode = False
    End Sub

    Protected Overridable Sub PublishClickedButton(buttonClicked As ButtonClicked)
        'Me.SuspendDrawingNew()
        'RaiseEvent BeforeChangeRecord()
        If Ea IsNot Nothing Then
            Ea.PublishEvent(New ViewButtonClicked(buttonClicked))
        End If
        'RaiseEvent AfterChangeRecord()
        'Me.ResumeDrawingNew()
    End Sub

    Protected Sub RunAfterChangeRecord()
        RaiseEvent AfterChangeRecord()
    End Sub

    Protected Sub RunBeforeChangeRecord()
        RaiseEvent BeforeChangeRecord()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If _debugSwitch = 1 Then
            Debugger.Break()
        End If
        PublishClickedButton(ButtonClicked.Print)
    End Sub

    Public Overridable Sub DoCustomSub()
        ' run any custom sub here
    End Sub

    Private Sub BtnTranslate_Click(sender As Object, e As EventArgs) Handles btnTranslate.Click
        If _debugSwitch Then
            Debugger.Break()
        End If

        RunTranslator(VSystemViewIdNo)

    End Sub


    Protected Sub RunTranslator(ByVal nSystemViewIdNo)
        Dim frm As New TranslationTableManager()
        frm.SystemViewIdNoToTranslate = nSystemViewIdNo
        frm.AppDataDAC = AppDataDAC
        frm.TranslatorDAC = TranslatorDAC
        frm.Show()
    End Sub

    Private Sub BtnUndo_Click(sender As Object, e As EventArgs) Handles btnUndo.Click
        If _debugSwitch Then
            Debugger.Break()
        End If
        EditingMode = False
        AddingMode = False
        PublishClickedButton(ButtonClicked.Undo)
    End Sub

    Private Sub BtnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        PublishClickedButton(ButtonClicked.Filter)
    End Sub

    Private Sub CFormEntry_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing
        PublishClickedButton(ButtonClicked.Quit)
        If CancelClose Then
            e.Cancel = True
        Else
            e.Cancel = False
        End If
    End Sub

    Private Sub CFormEntry_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        CloseForm()
    End Sub

    'Private Sub CFormEntry_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
    '    If e.KeyCode = Keys.F10 Then
    '        If btnSave.Enabled Then
    '            e.SuppressKeyPress = True
    '            e.Handled = True
    '            PublishClickedButton(ButtonClicked.Save)
    '        Else
    '            Beep()
    '        End If
    '    ElseIf e.KeyCode = Keys.F2 Then
    '        If btnSave.Enabled Then
    '            e.SuppressKeyPress = True
    '            e.Handled = True
    '            PublishClickedButton(ButtonClicked.Edit)
    '        Else
    '            Beep()
    '        End If
    '    ElseIf e.KeyCode = Keys.Enter Then

    '        e.Handled = False
    '    End If
    'End Sub

    ' ADD: Wrapper property to unify system view id usage
    Private ReadOnly Property CurrentSystemViewId As Integer
        Get
            EnsureSystemViewIdProvider()
            Return _systemViewIdProvider.GetId()
        End Get
    End Property

    Private Sub CFormEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _translationRepo = New TranslationRepository(TranslatorDAC)
        _translationCache = New TranslationCache(_translationRepo)
        _formTranslator = New FormTranslationService(Me, _translationRepo, _translationCache)


        ' Preload the two core cultures for this view id
        _formTranslator.Preload(
                {GlobalVariables.DefaultUnmirroredCultureInfoStr, GlobalVariables.DefaultMirroredCultureInfoStr},
                {CurrentSystemViewId}
            )

        '{GetSystemViewIdNo()}


        ' Initial translation pass (allows UI to start in correct language/RTL)
        _formTranslator.TranslateCurrentForm()

        If _formTranslationService Is Nothing Then
            _formTranslationService = New FormTranslationService(Me, _translationRepo, _translationCache)
            'TranslatorAccessor.TranslatorDACV?.Repository,
            '                                                 New TranslationCache())
        End If
        'If _firstLoadSwitch = 0 Then
        '    GetNSaveCaptions()
        '    _firstLoadSwitch = 1
        'End If
        If Not (LicenseManager.UsageMode = LicenseUsageMode.Designtime) Then
            'AddHandler TextDisplayLanguageChanged, AddressOf OnTextDisplayLanguageChanged
            TextDisplayLanguage = CultureInfo.CurrentCulture.Name
            'CreateDataSources()
            CreateMainFieldsDictionary()
            Dim formLoaded As New EntryFormLoaded(Me)
            If Ea IsNot Nothing Then
                Ea.PublishEvent(formLoaded)
            End If
            If formLoaded.EditingAllowed Then
                EditingAllowed = True
            Else
                EditingAllowed = False
            End If
            If formLoaded.AddingAllowed Then
                AddingAllowed = True
            Else
                AddingAllowed = False
            End If
            If formLoaded.DeletingAllowed Then
                DeletingAllowed = True
            Else
                DeletingAllowed = False
            End If
            'Debugger.Break()
            'PublishClickedButton(ButtonClicked.First)
            Inputs(False)
            If SingleData Or HideNavigatorButtons Then
                btnFirst.Visible = False
                btnNext.Visible = False
                btnLast.Visible = False
                btnPrev.Visible = False
                tsbCurrentRecord.Visible = False
                tsbTotalRecords.Visible = False
                tssNavigator2.Visible = False
                tssnavigator1.Visible = False
                btnOf.Visible = False
            End If
            If FormIsRtl Then
                btnArabic.Visible = False
                btnOriginal.Visible = True
                btnOriginal.Enabled = True
            Else
                btnArabic.Visible = True
                btnOriginal.Visible = False
                btnArabic.Enabled = True
            End If
            If FirstControl IsNot Nothing Then
                FirstControl.Focus()
            End If
            If Not UserIsASuperAdmin() Then
                HideButton(btnDebug)
            End If
            If AddOnOpen Then
                btnAdd.PerformClick()
                FirstControl.Select()
            End If
            'PublishClickedButton(ButtonClicked.Last)
            'PublishClickedButton(ButtonClicked.Last)
            'CenterForm(Me)
            'UpdateViewDisplay(editMode, addMode:=, recordPositionNumber:=, targetIdNo, recordCount)
        End If
        'Refresh()
    End Sub

    Public Shared Sub CenterForm(ByVal frm As Form, Optional ByVal parent As Form = Nothing)
        '' Note: call this from frm's Load event!
        Dim r As Rectangle
        If parent IsNot Nothing Then
            r = parent.RectangleToScreen(parent.ClientRectangle)
        Else
            r = Screen.FromPoint(frm.Location).WorkingArea
        End If

        Dim x = r.Left + (r.Width - frm.Width) \ 2
        Dim y = r.Top + (r.Height - frm.Height) \ 2
        frm.Location = New Point(x, y)
    End Sub

    Private Sub CloseForm()
        If GlobalVariables.AppCurrentCultureInfo.Name <> TextDisplayLanguage Then
            TextDisplayLanguage = GlobalVariables.AppCurrentCultureInfo.Name
        End If
        GC.Collect()
        GC.WaitForPendingFinalizers()
        If (Environment.OSVersion.Platform = PlatformID.Win32NT) Then
            SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1)
        End If
        Dispose()
    End Sub

    Private Sub CopyToolStripButton_Click(sender As Object, e As EventArgs) Handles CopyToolStripButton.Click
        CopyText()
    End Sub

    Private Sub CutToolStripButton_Click(sender As Object, e As EventArgs) Handles CutToolStripButton.Click
        CutText()
    End Sub

    Public Sub Inputs(onOff As Boolean)
        Dim allCtrl As New List(Of Control)
        Dim ctrl As Control
        For Each ctrl In FindControlRecursive(allCtrl, Me)
            If TypeOf ctrl Is IEntryControl Then
                'If TypeOf ctrl Is CtDataGridView Then 'And ctrl.Name = "dgvAccountIdNo" Then ' = "cboAccountIdNo" Then
                '    Dim cx As CtComboBoxColumn
                '    For Each column In ctrl

                '    Next
                'End If
                'If TypeOf ctrl Is CheckBox Then 'And ctrl.Name = "dgvAccountIdNo" Then ' = "cboAccountIdNo" Then
                '    Debugger.Break()
                'End If
                'If ctrl.Name.ToLower() = "dgvaccountidno" Then ' = "cboAccountIdNo" Then
                '    Debugger.Break()
                'End If
                If TypeOf ctrl Is DataGridView Then
                    Dim x As DataGridView = ctrl
                    DirectCast(x, DataGridView).EndEdit()
                End If

                SetPropertyValue(ctrl, "EditingMode", onOff, True)
            End If
        Next
        If onOff Then
            RaiseEvent InputsTurnedOn()
        Else
            RaiseEvent InputsTurnedOff()
        End If
        UnselectTextOnCtComboboxes(allCtrl)
        If FirstControl IsNot Nothing Then
            FirstControl.Focus()
        End If
    End Sub

    Public Sub UnselectTextOnCtComboboxes(Optional allCtrl As List(Of Control) = Nothing)
        If allCtrl Is Nothing Then
            FindControlRecursive(allCtrl, Me)
        End If
        ' i don't want text to be selected on comboboxes this sub will make sure to unselect the text for CtCombobox's
        For Each ctrl In allCtrl
            If TypeOf ctrl Is CtComboBox Then
                DirectCast(ctrl, CtComboBox).SelectionLength = 0
            End If
        Next
    End Sub

    'Private Sub OnBeforeLoad() Handles MyBase.BeforeLoad
    '    SetFormTitleCaption()
    'End Sub

    Private Sub PasteToolStripButton_Click(sender As Object, e As EventArgs) Handles PasteToolStripButton.Click
        PasteText()
    End Sub

#Region "Flicker-safe UI language switch"

    Private Class RedrawScope
        Implements IDisposable
        Private ReadOnly _root As Control
        Private Const WM_SETREDRAW As Integer = &HB

        <Runtime.InteropServices.DllImport("user32.dll")>
        Private Shared Function SendMessage(hWnd As IntPtr, msg As Integer, wParam As Boolean, lParam As Integer) As IntPtr
        End Function

        Public Sub New(root As Control)
            _root = root
            SuspendAll(root)
        End Sub

        Private Sub SuspendAll(c As Control)
            If c.IsHandleCreated Then SendMessage(c.Handle, WM_SETREDRAW, False, 0)
            c.SuspendLayout()
            For Each child As Control In c.Controls
                SuspendAll(child)
            Next
        End Sub

        Private Sub ResumeAll(c As Control)
            For Each child As Control In c.Controls
                ResumeAll(child)
            Next
            c.ResumeLayout(False)
            If c.IsHandleCreated Then SendMessage(c.Handle, WM_SETREDRAW, True, 0)
            c.Invalidate()
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            If _root Is Nothing Then Return
            ResumeAll(_root)
            _root.Refresh()
        End Sub
    End Class

    Protected Shadows Sub SwitchUiLanguage(originalUi As Boolean)
        If LicenseManager.UsageMode = LicenseUsageMode.Designtime Then Return

        ' Delegate to centralized service; adjust buttons after translation
        _formTranslator.SwitchUiLanguage(originalUi,
                                     allowFallback:=True,
                                     Nothing)

        'Using New RedrawScope(Me)
        '    ' Per-form culture (do NOT touch GlobalFunctions.SetCulture or GlobalVariables.RightToLeftLayout)
        '    _currentFormCulture = New CultureInfo(targetCultureName, False)
        '    _formIsRtl = _currentFormCulture.TextInfo.IsRightToLeft
        '    TextDisplayLanguage = _currentFormCulture.Name   ' keep legacy listeners satisfied

        '    ' Translation (pass explicit culture if overload exists)
        '    If _formTranslationService IsNot Nothing Then
        '        _formTranslationService.TranslateCurrentForm(_currentFormCulture)
        '    Else
        '        FlickerFreeTranslateForm()
        '    End If

        '    ' Apply RTL only to this form (and chosen child containers)
        '    Dim desiredRTLEnum = If(_formIsRtl, RightToLeft.Yes, RightToLeft.No)
        '    If Me.RightToLeft <> desiredRTLEnum Then Me.RightToLeft = desiredRTLEnum
        '    Dim frm = TryCast(Me, Form)
        '    If frm IsNot Nothing AndAlso frm.RightToLeftLayout <> _formIsRtl Then
        '        frm.RightToLeftLayout = _formIsRtl
        '    End If



        '    ToggleLanguageButtons(originalUi)

        '    ' Notify listeners (form-scoped)
        '    If Ea IsNot Nothing Then
        '        Ea.PublishEvent(New LanguageChanged(Me))
        '    End If
        'End Using
    End Sub

    'Protected Shadows Sub SwitchUiLanguage(originalUi As Boolean)
    '    If LicenseManager.UsageMode = LicenseUsageMode.Designtime Then Return

    '    ' 0. Determine target culture for requested mode
    '    Dim targetCulture As String =
    '        If(originalUi,
    '           GlobalVariables.DefaultUnmirroredCultureInfoStr,
    '           GlobalVariables.DefaultMirroredCultureInfoStr)

    '    ' FAST EXIT: If already on the requested culture (case-insensitive), do nothing heavy.
    '    ' (Assumes no forced re-translate needed; call RefreshTranslation if you need a manual retrigger.)
    '    If String.Equals(TextDisplayLanguage, targetCulture, StringComparison.OrdinalIgnoreCase) Then
    '        ' Just make sure language buttons reflect current mode.
    '        btnArabic.Visible = originalUi
    '        btnArabic.Enabled = originalUi
    '        btnOriginal.Visible = Not originalUi
    '        btnOriginal.Enabled = Not originalUi
    '        Return
    '    End If

    '    Using New RedrawScope(Me)

    '        Dim cultureChanged As Boolean = Not String.Equals(TextDisplayLanguage, targetCulture, StringComparison.OrdinalIgnoreCase)

    '        If cultureChanged Then
    '            TextDisplayLanguage = targetCulture
    '            GlobalFunctions.SetCulture(targetCulture)
    '            GlobalVariables.AppCurrentCultureInfo = CultureInfo.CurrentCulture
    '            GlobalVariables.RightToLeftLayout = CultureInfo.CurrentCulture.TextInfo.IsRightToLeft
    '        End If

    '        ' Translate via service (preferred) or fallback
    '        If _formTranslationService IsNot Nothing Then
    '            _formTranslationService.TranslateCurrentForm()
    '        Else
    '            FlickerFreeTranslateForm()
    '        End If

    '        ' Apply RTL properties after translation while drawing suspended
    '        Dim shouldBeRtl As Boolean = CultureInfo.CurrentCulture.TextInfo.IsRightToLeft
    '        Dim desiredRTLEnum As RightToLeft = If(shouldBeRtl, Windows.Forms.RightToLeft.Yes, Windows.Forms.RightToLeft.No)

    '        If Me.RightToLeft <> desiredRTLEnum Then
    '            Me.RightToLeft = desiredRTLEnum
    '        End If

    '        If TypeOf Me Is Form Then
    '            Dim frm = DirectCast(Me, Form)
    '            If frm.RightToLeftLayout <> shouldBeRtl Then
    '                frm.RightToLeftLayout = shouldBeRtl
    '            End If
    '        End If

    '        ' Toggle language buttons
    '        btnArabic.Visible = originalUi
    '        btnArabic.Enabled = originalUi
    '        btnOriginal.Visible = Not originalUi
    '        btnOriginal.Enabled = Not originalUi

    '        If cultureChanged AndAlso Ea IsNot Nothing Then
    '            Ea.PublishEvent(New LanguageChanged(Me))
    '        End If
    '    End Using
    'End Sub

#End Region

#Region "Services injection / translation fallback"

    Private _formTranslationService As FormTranslationService
    Public Property FormTranslationService As FormTranslationService
        Get
            Return _formTranslationService
        End Get
        Set(value As FormTranslationService)
            _formTranslationService = value
        End Set
    End Property


    Public Sub InitializeTranslationFallback(repo As AATM.Libraries.Localization.Core.ITranslationRepository,
                                             cache As AATM.Libraries.Localization.Core.TranslationCache)
        _translationRepo = repo
        _translationCache = cache
    End Sub

    ' ---- Implementation expected by existing calls: (control1, control2, container) ----
    Protected Overridable Sub TranslateFormControls(control1 As Control,
                                                    control2 As Control,
                                                    container As Control)
        ' Collect non-null controls
        Dim list As New List(Of Control)
        If control1 IsNot Nothing Then list.Add(control1)
        If control2 IsNot Nothing Then list.Add(control2)
        If list.Count = 0 Then Exit Sub

        ' Preferred path: use injected FormTranslationService (handles layout + images)
        If _formTranslationService IsNot Nothing Then
            _formTranslationService.TranslateSpecificControls(list)
            Exit Sub
        End If

        ' Fallback path: minimal direct translation using repo + cache
        If _translationRepo Is Nothing OrElse _translationCache Is Nothing Then Exit Sub

        Dim viewId = GetSystemViewIdSafe()
        Dim dict = CType(_translationCache.GetOrAdd(CultureInfo.CurrentCulture.Name, viewId),
                         IDictionary(Of String, String))

        For Each c In list
            ApplyControlTranslation(c, dict)
        Next
    End Sub

    ' ---- Convenience overload: container + arbitrary controls ----
    Protected Overridable Sub TranslateFormControls(container As Control,
                                                    ParamArray controls() As Control)
        If controls Is Nothing OrElse controls.Length = 0 Then Exit Sub
        If _formTranslationService IsNot Nothing Then
            _formTranslationService.TranslateSpecificControls(controls.Where(Function(x) x IsNot Nothing))
            Exit Sub
        End If

        If _translationRepo Is Nothing OrElse _translationCache Is Nothing Then Exit Sub
        Dim viewId = GetSystemViewIdSafe()
        Dim dict = CType(_translationCache.GetOrAdd(CultureInfo.CurrentCulture.Name, viewId),
                         IDictionary(Of String, String))

        For Each c In controls
            If c IsNot Nothing Then ApplyControlTranslation(c, dict)
        Next
    End Sub

    ' ---- Helper: apply translation to a single control ----
    Private Sub ApplyControlTranslation(ctrl As Control, dict As IDictionary(Of String, String))
        ' Key strategy: try Tag, then Name, then existing Text
        Dim key As String = Nothing
        If TypeOf ctrl.Tag Is String Then key = CStr(ctrl.Tag)
        If String.IsNullOrWhiteSpace(key) Then key = ctrl.Name
        If String.IsNullOrWhiteSpace(key) Then key = ctrl.Text

        If Not String.IsNullOrWhiteSpace(key) AndAlso dict.ContainsKey(key) Then
            ctrl.Text = dict(key)
        End If

        ' Handle ToolStripItem containers (if ever passed)
        If TypeOf ctrl Is ToolStrip Then
            For Each item As ToolStripItem In DirectCast(ctrl, ToolStrip).Items
                Dim iKey = If(TryCast(item.Tag, String), If(item.Name, item.Text))
                If Not String.IsNullOrWhiteSpace(iKey) AndAlso dict.ContainsKey(iKey) Then
                    item.Text = dict(iKey)
                End If
            Next
        End If
    End Sub

    ' ---- Safe view id acquisition (mirrors logic in FormTranslationService but tolerant if DAC not set) ----
    Private Function GetSystemViewIdSafe() As Integer
        Try
            Dim dac = TranslatorAccessor.TranslatorDACV
            If dac Is Nothing Then Return 0
            Dim sql = "SELECT IdNo FROM SystemView WHERE SystemViewName = '" & Me.Name.Replace("'", "''") & "'"
            Return dac.ExecScalar(Of Integer)(sql)
        Catch
            Return 0
        End Try
    End Function

    Private Sub ToggleLanguageButtons(originalUi As Boolean)
        btnArabic.Visible = originalUi
        btnArabic.Enabled = originalUi
        btnOriginal.Visible = Not originalUi
        btnOriginal.Enabled = Not originalUi
    End Sub

    Private Sub ApplyPerFormRtlToContainers(flowlayoutControlList)
        ' List any flow panels or custom containers you want mirrored
        For Each n In flowlayoutControlList
            Dim c = TryFindControl(n)
            If c Is Nothing Then Continue For
            If TypeOf c Is FlowLayoutPanel Then
                Dim fl = DirectCast(c, FlowLayoutPanel)
                fl.RightToLeft = If(_formIsRtl, RightToLeft.Yes, RightToLeft.No)
            Else
                c.RightToLeft = If(_formIsRtl, RightToLeft.Yes, RightToLeft.No)
            End If
        Next
    End Sub


    Private Function TryFindControl(name As String) As Control
        If String.IsNullOrEmpty(name) Then Return Nothing
        Dim arr = Me.Controls.Find(name, True)
        If arr Is Nothing OrElse arr.Length = 0 Then Return Nothing
        Return arr(0)
    End Function

#End Region
End Class