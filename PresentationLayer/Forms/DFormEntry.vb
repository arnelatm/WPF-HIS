Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.Threading
Imports System.Windows.Forms
Imports AATM.Libraries
Imports AATM.Libraries.AatmInterfaces
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Events
Imports AATM.PresentationLayer.Presenters

Public Class DFormEntry
    Implements IViewDFormEntry

    Protected Const TurnOff As Boolean = False
    Protected Shared _resetEvent As AutoResetEvent = New AutoResetEvent(False)
    Protected Property FormTitleCaption As String = ""
    Private _debugSwitch As Byte = 0
    Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat
    Private _displayOnly As Boolean = False
    Private _translatable As Boolean = True
    Private _firstLoadSwitch As UInt16 = 0


    Private Event AfterUpdateView As IViewDFormEntry.AfterUpdateViewEventHandler Implements IViewDFormEntry.AfterUpdateView
    Private Event AfterSave As IViewDFormEntry.AfterSaveEventHandler Implements IViewDFormEntry.AfterSave
    Private Event InputsTurnedOn As IViewDFormEntry.InputsTurnedOnEventHandler Implements IViewDFormEntry.InputsTurnedOn
    Private Event InputsTurnedOff As IViewDFormEntry.InputsTurnedOffEventHandler Implements IViewDFormEntry.InputsTurnedOff
    Private Event AfterChangeRecord As IViewDFormEntry.AfterChangeRecordEventHandler Implements IViewDFormEntry.AfterChangeRecord
    Private Event BeforeChangeRecord As IViewDFormEntry.BeforeChangeRecordEventHandler Implements IViewDFormEntry.BeforeChangeRecord

    Public Event RecordPositionChanged() Implements IViewDFormEntry.RecordPositionChanged

    Public Sub New()
        InitializeComponent()
        DoubleBuffered = True
        InputTurnedOn = False
        EditingMode = False
        AddingMode = False
    End Sub

    Delegate Sub SafeCallDelegate(ByRef controlObject As Control, textString As String)
    Private Declare Function SetProcessWorkingSetSize Lib "kernel32.dll" (hProcess As IntPtr, dwMinimumWorkingSetSize As Int32, dwMaximumWorkingSetSize As Int32) As Int32

    Public Property AddingAllowed As Boolean Implements IViewDFormEntry.AddingAllowed
    Public Property AddingMode As Boolean Implements IViewDFormEntry.AddingMode
    Public Property AddOnOpen As Boolean Implements IViewDFormEntry.AddOnOpen
    Public Property AutoAddOnSave As Boolean Implements IViewDFormEntry.AutoAddOnSave
    Public Property DeletingAllowed As Boolean Implements IViewDFormEntry.DeletingAllowed
    Public Property DisallowSaves As Boolean Implements IViewDFormEntry.DisallowSaves
    Public Property EditingAllowed As Boolean Implements IViewDFormEntry.EditingAllowed
    Public Property EditingMode As Boolean Implements IViewDFormEntry.EditingMode
    Public Property FirstControl As Control Implements IViewDFormEntry.FirstControl
    Public Property InputTurnedOn As Boolean Implements IViewDFormEntry.InputTurnedOn
    Public Property MainFieldsDictionary As Object Implements IViewDFormEntry.MainFieldsDictionary
    Public Property ParentFieldName As String Implements IViewDFormEntry.ParentFieldName
    Public Property QuitOnSave As Boolean Implements IViewDFormEntry.QuitOnSave
    Public Property RecordDateTimeStampValue As Object Implements IViewDFormEntry.RecordDateTimeStampValue
    Public Property RecordPositionNumber As Integer Implements IViewDFormEntry.RecordPositionNumber
    Public Property RecordCount As Integer Implements IViewDFormEntry.RecordCount
    Public Property ShowWaitForm As BackgroundWorker(Of String) Implements IViewDFormEntry.ShowWaitForm
    Public Property SingleData As Boolean Implements IViewDFormEntry.SingleData


    Private Sub OnDFormEntryNewShown() Handles MyBase.Shown
        If CultureInfo.CurrentCulture.TextInfo.IsRightToLeft Then
            If btnArabic.Enabled Then
                SwitchUiLanguage(False)
            End If
        Else
            If Not btnArabic.Enabled Then
                SwitchUiLanguage(True)
            End If
        End If
        Me.Activate()
        FormShown = True
        'PublishClickedButton(ButtonClicked.Last)
        SetFormTitleCaption()
    End Sub

    'Public Overridable Sub OnRecordPositionChanged()
    '    RaiseEvent RecordPositionChanged()

    '    'If Not HideNavigatorButtons Then
    '    '    tsbCurrentRecord.Text = RecordPositionNumber.ToString()
    '    '    tsbTotalRecords.Text = RecordCount.ToString()
    '    '    Application.DoEvents()
    '    '    UpdateNavigationButtonDisplay(editMode, addMode, RecordPositionNumber, RecordCount)
    '    'End If
    '    'If addMode Or editMode Then
    '    '    TurnOnInputs()
    '    'Else
    '    '    TurnOffInputs()
    '    'End If
    '    'RaiseEvent AfterUpdateView()
    'End Sub


    Public Sub CheckDataChanges()
    End Sub

    'Public Sub FindFieldNew(findableControl As IFindableControl)
    '    Ea.PublishEvent(New FindFieldRequested(findableControl))
    'End Sub

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

    Public Overridable Sub TurnOffInputs()
        If _InputTurnedOn Then
            Inputs(False)
            _InputTurnedOn = False
        End If
    End Sub

    Public Overridable Sub TurnOnInputs()
        If Not _inputTurnedOn Then
            Inputs(True)
            _inputTurnedOn = True
        End If
    End Sub

    Protected Overridable Sub CreateMainFieldsDictionary()
        '
    End Sub

    Protected Overridable Sub OnTextDisplayLanguageChanged() Handles Me.TextDisplayLanguageChanged
        CultureInfo.CurrentCulture = New CultureInfo(TextDisplayLanguage, False)
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

    'Protected Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
    '    If _debugSwitch = 1 Then
    '        Debugger.Break()
    '    End If
    '    If OkToAddHook() Then
    '        AddingMode = True
    '        PublishClickedButton(ButtonClicked.Add)
    '        AfterAddHook()
    '    End If
    'End Sub

    Private Sub BtnArabic_Click(sender As Object, e As EventArgs) Handles btnArabic.Click
        SwitchUiLanguage(False)
    End Sub

    'Private Sub BtnDebug_Click(sender As Object, e As EventArgs) Handles btnDebug.Click
    '    If _debugSwitch = 0 Then
    '        _debugSwitch = 1
    '        Debugger.Break()
    '        btnDebug.Checked = False
    '    Else
    '        _debugSwitch = 0
    '        btnDebug.Checked = True
    '    End If
    'End Sub

    'Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
    '    If _debugSwitch = 1 Then
    '        Debugger.Break()
    '    End If
    '    If OkToDeleteHook() Then
    '        PublishClickedButton(ButtonClicked.Delete)
    '        AfterDeleteHook()
    '    End If
    'End Sub

    'Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
    '    If _debugSwitch = 1 Then
    '        Debugger.Break()
    '    End If
    '    If OkToAddHook() Then
    '        EditingMode = True
    '        PublishClickedButton(ButtonClicked.Edit)
    '        AfterEditHook()
    '    End If
    'End Sub

    'Private Sub BtnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
    '    If _debugSwitch = 1 Then
    '        Debugger.Break()
    '    End If
    '    PublishClickedButton(ButtonClicked.Find)
    'End Sub

    'Private Sub BtnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
    '    If _debugSwitch = 1 Then
    '        Debugger.Break()
    '    End If
    '    PublishClickedButton(ButtonClicked.First)
    'End Sub

    'Private Sub BtnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
    '    If _debugSwitch = 1 Then
    '        Debugger.Break()
    '    End If
    '    PublishClickedButton(ButtonClicked.Last)
    'End Sub

    'Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
    '    If _debugSwitch = 1 Then
    '        Debugger.Break()
    '    End If
    '    PublishClickedButton(ButtonClicked.Next)
    'End Sub

    Private Sub BtnOriginal_Click(sender As Object, e As EventArgs) Handles btnOriginal.Click
        If _debugSwitch = 1 Then
            Debugger.Break()
        End If
        SwitchUiLanguage(True)
    End Sub

    'Private Sub BtnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
    '    If _debugSwitch = 1 Then
    '        Debugger.Break()
    '    End If
    '    PublishClickedButton(ButtonClicked.Previous)
    'End Sub

    Private Sub BtnQuit_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
        If _debugSwitch = 1 Then
            Debugger.Break()
        End If
        Close()
    End Sub

    'Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
    '    If _debugSwitch = 1 Then
    '        Debugger.Break()
    '    End If
    '    ForceLooseFocusOnCurrentControl()
    '    ForceEndEditForAllGridControls()
    '    If OkToSaveHook() Then
    '        Dim dataValidator As New DataValidator(Me)
    '        If Ea IsNot Nothing Then
    '            Ea.PublishEvent(dataValidator)
    '            If dataValidator.Valid Then
    '                AfterEditHook()
    '                EditingMode = False
    '                AddingMode = False
    '                If QuitOnSave Then
    '                    Close()
    '                Else
    '                    If AutoAddOnSave Then
    '                        btnAdd.PerformClick()
    '                    End If
    '                End If
    '            End If
    '        End If
    '    End If
    'End Sub

    Protected Overridable Function OkToEditHook()
        Return True
    End Function

    Protected Overridable Function OkToAddHook()
        Return True
    End Function

    Protected Overridable Function OkToSaveHook()
        Return True
    End Function

    Protected Overridable Function OkToDeleteHook()
        Return True
    End Function


    Protected Overridable Function OkToUndoHook()
        Return True
    End Function

    Protected Overridable Function AfterAddHook()
        Return True
    End Function

    Protected Overridable Function AfterEditHook()
        Return True
    End Function

    Protected Overridable Function AfterUndoHook()
        Return True
    End Function

    Protected Overridable Function AfterSaveHook()
        Return True
    End Function

    Protected Overridable Function AfterDeleteHook()
        Return True
    End Function

    'Protected Overridable Sub PublishClickedButton(buttonClicked As ButtonClicked)
    '    If Ea IsNot Nothing Then
    '        Ea.PublishEvent(New ViewButtonClicked(buttonClicked))
    '    End If
    'End Sub

    Protected Sub RunAfterChangeRecord()
        RaiseEvent AfterChangeRecord()
    End Sub

    Protected Sub RunBeforeChangeRecord()
        RaiseEvent BeforeChangeRecord()
    End Sub

    'Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
    '    If _debugSwitch = 1 Then
    '        Debugger.Break()
    '    End If
    '    PublishClickedButton(ButtonClicked.Print)
    'End Sub

    Private Sub BtnTranslate_Click(sender As Object, e As EventArgs) Handles btnTranslate.Click
        If _debugSwitch Then
            Debugger.Break()
        End If

        RunTranslator(VSystemViewIdNo)

    End Sub

    'Private Sub BtnUndo_Click(sender As Object, e As EventArgs) Handles btnUndo.Click
    '    If _debugSwitch Then
    '        Debugger.Break()
    '    End If
    '    If OkToUndoHook() Then
    '        EditingMode = False
    '        AddingMode = False
    '        PublishClickedButton(ButtonClicked.Undo)
    '        AfterUndoHook()
    '    End If
    'End Sub

    'Private Sub BtnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
    '    PublishClickedButton(ButtonClicked.Filter)
    'End Sub

    Private Sub DFormEntry_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing
        'PublishClickedButton(ButtonClicked.Quit)
        If CancelClose Then
            e.Cancel = True
        Else
            e.Cancel = False
        End If
    End Sub

    Private Sub DFormEntry_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        CloseForm()
    End Sub

    Private Sub DFormEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not (LicenseManager.UsageMode = LicenseUsageMode.Designtime) Then
            TextDisplayLanguage = CultureInfo.CurrentCulture.Name
            CreateMainFieldsDictionary()
            Dim formLoaded As New EntryFormLoaded(Me)
            'If Ea IsNot Nothing Then
            '    Ea.PublishEvent(formLoaded)
            'End If
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
            If GlobalVariables.RightToLeftLayout Then
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
        End If
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

    Private Sub PasteToolStripButton_Click(sender As Object, e As EventArgs) Handles PasteToolStripButton.Click
        PasteText()
    End Sub

    Protected Overrides Sub SwitchUiLanguage(originalUi As Boolean)
        If Not (LicenseManager.UsageMode = LicenseUsageMode.Designtime) Then
            Dim sw As Integer = 0
            If originalUi Then
                If TextDisplayLanguage <> GlobalVariables.DefaultUnmirroredCultureInfoStr Then
                    TextDisplayLanguage = GlobalVariables.DefaultUnmirroredCultureInfoStr
                    sw = 1
                End If
                GlobalVariables.RightToLeftLayout = True
                RightToLeft = RightToLeft.No
            Else
                If TextDisplayLanguage <> GlobalVariables.DefaultMirroredCultureInfoStr Then
                    TextDisplayLanguage = GlobalVariables.DefaultMirroredCultureInfoStr
                    sw = 1
                End If
                GlobalVariables.RightToLeftLayout = False
                RightToLeft = RightToLeft.Yes
            End If
            TranslateForm()
            If sw = 1 Then
                CultureInfo.CurrentCulture = New CultureInfo(TextDisplayLanguage, False)
                btnArabic.Visible = originalUi
                btnOriginal.Visible = Not originalUi
                btnArabic.Enabled = originalUi
                btnOriginal.Enabled = Not originalUi
                'If Ea IsNot Nothing Then
                '    Ea.PublishEvent(New LanguageChanged(Me))
                'End If
            End If
        End If
    End Sub

End Class