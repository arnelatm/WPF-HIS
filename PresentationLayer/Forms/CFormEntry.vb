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
    Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat
    Private _translationRepo As ITranslationRepository
    Private _translationCache As TranslationCache
    Private _formTranslator As FormTranslationService
    Private _systemViewIdProvider As SystemViewIdProvider

    Private _localizer As IUiLocalizationService

    Private _inputTurnedOn As Boolean

    ' --- Events ---
    Public Event AfterUpdateView()
    Public Property AddOnOpen As Boolean
    Public Event AfterSave()
    Public Event InputsTurnedOn()
    Public Event InputsTurnedOff()
    Public Event AfterChangeRecord()
    Public Event BeforeChangeRecord()

    ' --- Constructors ---
    Public Sub New()
        InitializeComponent()
        DoubleBuffered = True
        _inputTurnedOn = False
        ' If repo/cache will be created later in Load, do nothing here.
    End Sub

    Public Sub New(repo As ITranslationRepository, cache As TranslationCache)
        InitializeComponent()
        DoubleBuffered = True
        _translationRepo = repo
        _translationCache = cache
        _formTranslator = New FormTranslationService(Me, _translationRepo, _translationCache)
        _localizer = TryCast(_formTranslator, IUiLocalizationService)
        HookLocalization()
    End Sub

    ' --- Helper: safe publish via Event Aggregator (Ea) ---
    Private Sub PublishEventSafe(evt As Object)
        If Ea Is Nothing Then
            Debugger.Break()
        End If
        Ea?.PublishEvent(evt)
    End Sub

    Protected EditingMode As Boolean = False
    Protected AddingMode As Boolean = False
    Private _displayOnly As Boolean = False
    Private _translatable As Boolean = True
    Private _firstLoadSwitch As UInt16 = 0

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


    ' ADD: Wrapper property to unify system view id usage
    Private ReadOnly Property CurrentSystemViewId As Integer
        Get
            EnsureSystemViewIdProvider()
            Return _systemViewIdProvider.GetId()
        End Get
    End Property

    Public ReadOnly Property FormIsRtl As Boolean
        Get
            Return If(_localizer?.IsRtl, False)
        End Get
    End Property

    Public Property QuitOnSave As Boolean Implements IViewDataEntry.QuitOnSave

    Private Sub CFormEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If LicenseManager.UsageMode = LicenseUsageMode.Designtime Then Exit Sub

        ' Respect constructor‑injected repo/cache if provided
        If _translationRepo Is Nothing OrElse _translationCache Is Nothing Then
            _translationRepo = New TranslationRepository(TranslatorDAC)
            _translationCache = New TranslationCache(_translationRepo)
        End If

        If _formTranslator Is Nothing Then
            _formTranslator = New FormTranslationService(Me, _translationRepo, _translationCache)
        End If


        ' Assign localization interface & hook (only once)
        If _localizer Is Nothing Then
            _localizer = TryCast(_formTranslator, IUiLocalizationService)
            HookLocalization()
        End If

        ' Preload translations
        _formTranslator.Preload(
            {GlobalVariables.DefaultUnmirroredCultureInfoStr, GlobalVariables.DefaultMirroredCultureInfoStr},
            {CurrentSystemViewId}
        )

        ' Initial translation 
        _localizer?.Translate()

        TextDisplayLanguage = _localizer.CurrentCulture.Name
        CreateMainFieldsDictionary()

        Dim formLoaded As New EntryFormLoaded(Me)
        Ea?.PublishEvent(formLoaded)
        EditingAllowed = formLoaded.EditingAllowed
        AddingAllowed = formLoaded.AddingAllowed
        DeletingAllowed = formLoaded.DeletingAllowed

        Inputs(False)

        If SingleData Or HideNavigatorButtons Then
            HideNavigatorVisuals()
        End If

        If FirstControl IsNot Nothing Then FirstControl.Focus()
        If Not UserIsASuperAdmin() Then HideButton(btnDebug)
        If AddOnOpen Then
            btnAdd.PerformClick()
            FirstControl.Select()
        End If
    End Sub

    Private Sub OnCFormEntryNewShown() Handles MyBase.Shown
        If _shownInitialized Then Return   ' guard against accidental re-entry
        Me.Activate()
        PublishClickedButton(ButtonClicked.Last)
        SetFormTitleCaption()
        _shownInitialized = True
    End Sub

    ' --- UI Helpers ---
    Private Sub HideNavigatorVisuals()
        btnFirst.Visible = False
        btnNext.Visible = False
        btnLast.Visible = False
        btnPrev.Visible = False
        tsbCurrentRecord.Visible = False
        tsbTotalRecords.Visible = False
        tssNavigator2.Visible = False
        tssnavigator1.Visible = False
        btnOf.Visible = False
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

    ' --- Navigation / Mode ---
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
    End Sub

    Protected Sub UpdateNavigationButtonDisplay(editing As Boolean, adding As Boolean,
                                            recordPositionNumber As Integer, recordCount As Integer)
        If SingleData Then
            btnAdd.Visible = False
            btnFind.Visible = False
            HideNavigatorButtons = True
            If adding Or editing Then
                btnQuit.Enabled = False
                btnSave.Enabled = Not DisallowSaves
                btnUndo.Enabled = True
            Else
                btnEdit.Enabled = True
                btnQuit.Enabled = True
                btnSave.Enabled = False
                btnUndo.Enabled = False
            End If
        Else
            If adding Or editing Then
                SetNavigatorEnabled(False)
                btnSave.Enabled = Not DisallowSaves
                btnUndo.Enabled = True
            Else
                SetNavigatorEnabled(True)
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
                    btnSave.Enabled = Not DisallowSaves
                    btnUndo.Enabled = True
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

        If Not EditingAllowed Then btnEdit.Visible = False
        If Not AddingAllowed Then btnAdd.Visible = False
        If Not DeletingAllowed Then btnDelete.Visible = False
    End Sub

    Private Sub SetNavigatorEnabled(enabled As Boolean)
        btnFirst.Enabled = enabled
        btnPrev.Enabled = enabled
        btnNext.Enabled = enabled
        btnLast.Enabled = enabled
        btnEdit.Enabled = enabled
        btnAdd.Enabled = enabled
        btnDelete.Enabled = enabled
        btnPrint.Enabled = enabled
        btnFind.Enabled = enabled
        btnQuit.Enabled = enabled
        btnFilter.Enabled = enabled
    End Sub


    Public Overridable Sub TurnOffInputs()
        If _inputTurnedOn Then
            Inputs(False)
            _inputTurnedOn = False
        End If
    End Sub

    Public Overridable Sub TurnOnInputs()
        If Not _inputTurnedOn Then
            Inputs(True)
            _inputTurnedOn = True
        End If
    End Sub

    Public Sub Inputs(onOff As Boolean)
        Dim allCtrl As New List(Of Control)
        For Each ctrl In FindControlRecursive(allCtrl, Me)
            If TypeOf ctrl Is IEntryControl Then
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
        If FirstControl IsNot Nothing Then FirstControl.Focus()
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

    ' --- Translation ---
    Protected Overridable Sub CreateMainFieldsDictionary()
    End Sub

    Public Sub RefreshTranslation()
        _localizer?.Translate()
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


    Public Sub SwitchUiLanguage(originalUi As Boolean)
        _localizer?.SwitchLanguage(originalUi)
    End Sub

    '' preferred path first overload
    'Protected Overridable Sub TranslateFormControls(control1 As Control,
    '                                                control2 As Control,
    '                                                container As Control)
    '    ' Collect non-null controls
    '    Dim list As New List(Of Control)
    '    If control1 IsNot Nothing Then list.Add(control1)
    '    If control2 IsNot Nothing Then list.Add(control2)
    '    If list.Count = 0 Then Exit Sub

    '    ' Preferred path – ensures RTL/layout/image translations
    '    If _formTranslator IsNot Nothing Then
    '        _formTranslator.TranslateSpecificControls(list)
    '        Exit Sub
    '    End If

    '    ' Fallback
    '    If _translationRepo Is Nothing OrElse _translationCache Is Nothing Then Exit Sub
    '    Dim dict = CType(_translationCache.GetOrAdd(CultureInfo.CurrentCulture.Name, GetSystemViewIdSafe()), IDictionary(Of String, String))
    '    For Each c In list
    '        ApplyControlTranslation(c, dict)
    '    Next
    'End Sub

    Protected Overridable Sub TranslateFormControls(container As Control,
                                                ParamArray controls() As Control)
        If controls Is Nothing OrElse controls.Length = 0 Then Exit Sub
        If _formTranslator IsNot Nothing Then
            _formTranslator.TranslateSpecificControls(controls.Where(Function(x) x IsNot Nothing))
            Exit Sub
        End If
        If _translationRepo Is Nothing OrElse _translationCache Is Nothing Then Exit Sub
        Dim dict = CType(_translationCache.GetOrAdd(CultureInfo.CurrentCulture.Name, GetSystemViewIdSafe()), IDictionary(Of String, String))
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

    ' --- Localization event hook ---
    Private Sub HookLocalization()
        If _localizer Is Nothing Then Return
        RemoveHandler _localizer.UiLanguageChanged, AddressOf OnUiLanguageChanged
        AddHandler _localizer.UiLanguageChanged, AddressOf OnUiLanguageChanged
        ' Initialize button state
        OnUiLanguageChanged(_localizer.CurrentCulture, _localizer.IsRtl)
    End Sub

    Private Sub OnUiLanguageChanged(c As CultureInfo, isRtl As Boolean)
        btnArabic.Visible = Not isRtl
        btnArabic.Enabled = True
        btnOriginal.Visible = isRtl
        btnOriginal.Enabled = True
    End Sub

    ' --- Event / publish wrappers ---
    Public Sub FindFieldNew(findableControl As IFindableControl)
        PublishEventSafe(New FindFieldRequested(findableControl))
    End Sub

    Protected Overridable Sub PublishClickedButton(buttonClicked As ButtonClicked)
        PublishEventSafe(New ViewButtonClicked(buttonClicked))
    End Sub

    ' --- Buttons ---
    Protected Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If _debugSwitch = 1 Then Debugger.Break()
        AddingMode = True
        BeforeAdd()
        PublishClickedButton(ButtonClicked.Add)
        AfterAdd()
    End Sub

    Private Sub BtnArabic_Click(sender As Object, e As EventArgs) Handles btnArabic.Click
        _localizer?.SwitchLanguage(False)
    End Sub

    Private Sub BtnOriginal_Click(sender As Object, e As EventArgs) Handles btnOriginal.Click
        _localizer?.SwitchLanguage(True)
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If _debugSwitch = 1 Then Debugger.Break()
        EditingMode = True
        PublishClickedButton(ButtonClicked.Edit)
        BeforeEdit()
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If _debugSwitch = 1 Then Debugger.Break()
        PublishClickedButton(ButtonClicked.Delete)
    End Sub

    Private Sub BtnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        If _debugSwitch = 1 Then Debugger.Break()
        PublishClickedButton(ButtonClicked.Find)
    End Sub

    Private Sub BtnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        If _debugSwitch = 1 Then Debugger.Break()
        PublishClickedButton(ButtonClicked.First)
    End Sub

    Private Sub BtnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        If _debugSwitch = 1 Then Debugger.Break()
        PublishClickedButton(ButtonClicked.Previous)
    End Sub

    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If _debugSwitch = 1 Then Debugger.Break()
        PublishClickedButton(ButtonClicked.Next)
    End Sub

    Private Sub BtnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        If _debugSwitch = 1 Then Debugger.Break()
        PublishClickedButton(ButtonClicked.Last)
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If _debugSwitch = 1 Then Debugger.Break()
        PublishClickedButton(ButtonClicked.Print)
    End Sub

    Private Sub BtnUndo_Click(sender As Object, e As EventArgs) Handles btnUndo.Click
        If _debugSwitch Then Debugger.Break()
        EditingMode = False
        AddingMode = False
        PublishClickedButton(ButtonClicked.Undo)
    End Sub

    Private Sub BtnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        PublishClickedButton(ButtonClicked.Filter)
    End Sub

    Private Sub BtnTranslate_Click(sender As Object, e As EventArgs) Handles btnTranslate.Click
        If _debugSwitch = 1 Then Debugger.Break()
        RunTranslator(VSystemViewIdNo)
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If _debugSwitch = 1 Then Debugger.Break()
        ForceLooseFocusOnCurrentControl()
        ForceEndEditForAllGridControls()
        Dim saveData As New SaveDataRequested(Me)
        PublishEventSafe(saveData)
        If saveData.ValidData Then
            RaiseEvent AfterSave()
            If QuitOnSave Then
                Close()
            ElseIf AutoAddOnSave Then
                btnAdd.PerformClick()
            End If
        End If
        EditingMode = False
        AddingMode = False
    End Sub

    Private Sub BtnQuit_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
        If _debugSwitch = 1 Then Debugger.Break()
        Close()
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
    End Sub

    ' --- Save / Close / Misc ---
    Private Sub CFormEntry_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing
        PublishClickedButton(ButtonClicked.Quit)
        e.Cancel = CancelClose
    End Sub

    Private Sub CFormEntry_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        CloseForm()
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

    Public Shared Sub CenterForm(frm As Form, Optional parent As Form = Nothing)
        Dim r As Rectangle = If(parent IsNot Nothing,
                            parent.RectangleToScreen(parent.ClientRectangle),
                            Screen.FromPoint(frm.Location).WorkingArea)
        Dim x = r.Left + (r.Width - frm.Width) \ 2
        Dim y = r.Top + (r.Height - frm.Height) \ 2
        frm.Location = New Point(x, y)
    End Sub

    ' --- Clipboard helpers (placeholders) ---
    Private Sub CopyToolStripButton_Click(sender As Object, e As EventArgs) Handles CopyToolStripButton.Click
        CopyText()
    End Sub

    Private Sub CutToolStripButton_Click(sender As Object, e As EventArgs) Handles CutToolStripButton.Click
        CutText()
    End Sub

    ' --- Extension points ---
    Protected Overridable Sub BeforeEdit()
    End Sub
    Protected Overridable Sub AfterEdit()
    End Sub
    Protected Overridable Sub BeforeAdd()
    End Sub
    Protected Overridable Sub AfterAdd()
    End Sub
    Public Overridable Sub DoCustomSub()
    End Sub

    Protected Sub RunBeforeChangeRecord()
        RaiseEvent BeforeChangeRecord()
    End Sub
    Protected Sub RunAfterChangeRecord()
        RaiseEvent AfterChangeRecord()
    End Sub

    Protected Overridable Sub OnTextDisplayLanguageChanged() Handles Me.TextDisplayLanguageChanged
        PublishEventSafe(New LanguageChanged(Me))
    End Sub

    Public Sub HideButton(button As ToolStripButton)
        button.Visible = False
    End Sub

    Private Sub PasteToolStripButton_Click(sender As Object, e As EventArgs) Handles PasteToolStripButton.Click
        PasteText()
    End Sub

    Private Function TryFindControl(name As String) As Control
        If String.IsNullOrEmpty(name) Then Return Nothing
        Dim arr = Me.Controls.Find(name, True)
        If arr Is Nothing OrElse arr.Length = 0 Then Return Nothing
        Return arr(0)
    End Function

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Type here the Child Table name if any, otherwise leave it blank.")>
    <Browsable(True)>
    Public Property ChildTableName As String = ""
    Public Property TableProperties As Array

    Protected Property FormTitleCaption As String = ""

    Public Sub CheckDataChanges()
    End Sub

    Public Function GetMainFieldsDictionary()
        Return MainFieldsDictionary
    End Function

    'Public Sub OnEventHandler(ByRef eventType As ViewButtonChanged) Implements ISubscriber(Of ViewButtonChanged).OnEventHandler
    '    Throw New NotImplementedException()
    'End Sub

    'Public Sub OnEventHandler(ByRef eventType As SaveDataRequested) Implements ISubscriber(Of SaveDataRequested).OnEventHandler
    '    Throw New NotImplementedException()
    'End Sub

    'Public Sub OnEventHandler(ByRef eventType As LanguageChanged) Implements ISubscriber(Of LanguageChanged).OnEventHandler
    '    Throw New NotImplementedException()
    'End Sub

    'Public Sub OnEventHandler(ByRef eventType As EntryFormLoaded) Implements ISubscriber(Of EntryFormLoaded).OnEventHandler
    '    Throw New NotImplementedException()
    'End Sub
End Class