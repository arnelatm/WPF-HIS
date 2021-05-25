Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.Threading
Imports System.Windows.Forms
Imports AATM.Libraries
Imports AATM.Libraries.AatmInterfaces
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events
Imports AATM.PresentationLayer.Presenters

Public Class CFormEntryNew
    Implements IViewDataEntry

    Public MainFieldsDictionary As New Dictionary(Of String, Object)
    Public GotoTargetRecordWorker As BackgroundWorker(Of String)
    Public ShowWaitForm As BackgroundWorker(Of String)
    Protected Const TurnOff As Boolean = False
    Protected Shared _resetEvent As AutoResetEvent = New AutoResetEvent(False)
    Protected FirstControl As Control
    Protected ParentFieldName As String = ""
    Protected RecordDateTimeStampValue As Object
    Protected SortOrderKey As String = "IdNo"
    Protected SingleData As Boolean = False
    Private _debugSwitch As Byte = 0
    Private _addMode As Boolean = False
    Private _editMode As Boolean = False
    Private _recordCount As Int32 = 0
    Private _recordPositionNumber As Int32 = 0
    Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat
    Public Ea As EventAggregator

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        KeyPreview = True
        DoubleBuffered = True
        Ea = New EventAggregator
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Delegate Sub SafeCallDelegate(ByRef controlObject As Control, textString As String)

    Private Declare Function SetProcessWorkingSetSize Lib "kernel32.dll" (hProcess As IntPtr,
                                                                         dwMinimumWorkingSetSize As Int32,
                                                                          dwMaximumWorkingSetSize As Int32) As Int32

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

    Public Property RecordCount As Integer Implements IViewDataEntry.RecordCount
        Get
            Return _recordCount
        End Get
        Set(value As Integer)
            _recordCount = value
            tsbTotalRecords.Text = value
            UpdateNavigationButtonDisplay(False, False)
        End Set
    End Property

    Public Property RecordPositionNumber As Integer Implements IViewDataEntry.RecordPositionNumber
        Get
            Return _recordPositionNumber
        End Get
        Set(value As Integer)
            _recordPositionNumber = value
            tsbCurrentRecord.Text = value
            UpdateNavigationButtonDisplay(False, False)
        End Set
    End Property

    Public Property QuitOnSave As Boolean Implements IViewDataEntry.QuitOnSave

    Public Sub CheckDataChanges()
    End Sub

    Public Function GetEventAggregator() As EventAggregator
        Return Ea
    End Function

    Public Property AddMode As Boolean
        Get
            Return _addMode
        End Get
        Set(value As Boolean)
            _addMode = value
            UpdateNavigationButtonDisplay(EditMode, value)
        End Set
    End Property

    Public Property EditMode As Boolean
        Get
            Return _editMode
        End Get
        Set(value As Boolean)
            _editMode = value
            UpdateNavigationButtonDisplay(value, AddMode)
        End Set
    End Property

    Public Sub FindFieldNew(findableControl As IFindableControl)
        Ea.PublishEvent(New FindFieldRequested(findableControl))
    End Sub

    Public Function GetMainFieldsDictionary()
        Return MainFieldsDictionary
    End Function

    'Public Sub GotoTargetRecordWorker_DoWorkHandler(sender As Object, e As DoWorkEventArgs(Of String))
    '    If GotoTargetRecordWorker.CancellationPending Then
    '        e.Cancel = True
    '        Return
    '    End If
    '    PresenterObj.TargetIdNo = e.Argument
    '    PresenterObj.RecordPositionNumber = PresenterObj.GetSortedRecordPosition(PresenterObj.TargetIdNo)
    '    PresenterObj.TargetIdNo = PresenterObj.GetIdNoOfSortedPositionNumber(PresenterObj.RecordPositionNumber)
    '    PresenterObj.UpdateViewDisplay(PresenterObj.TargetIdNo)
    '    DoPaintEvents()
    'End Sub

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

    'Public Sub ShowWaitForm_DoWorkHandler(sender As Object, e As DoWorkEventArgs(Of String))
    '    If ShowWaitForm.CancellationPending Then
    '        e.Cancel = True
    '        Return
    '    End If
    '    e.Result = PresenterObj.GetIdNoOfSortedPositionNumber(PresenterObj.RecordPositionNumber)
    'End Sub

    Protected Sub TurnOffInputs()
        Inputs(False)
        InputsTurnedOff()
    End Sub

    Protected Sub TurnOnInputs()
        Inputs(True)
        InputsTurnedOn()
        If FirstControl IsNot Nothing Then
            FirstControl.Focus()
        End If
    End Sub

    Protected Overridable Sub InputsTurnedOn()
    End Sub

    Protected Overridable Sub InputsTurnedOff()
    End Sub

    'Public Overridable Function ValidateView()
    '    Ea.PublishEvent(New )
    '    Dim validationsPassed As Boolean
    '    validationsPassed = True
    '    Dim allControls As New List(Of Control)
    '    Dim originalValue As String
    '    For Each cCtrl As Control In FindControlRecursive(allControls, Me)
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
    '                originalValue = PresenterObj.GetOriginalValue(thisControl.EnglishControl)
    '                Dim englishText As String = GetPropertyValue(thisControl.EnglishControl, "Text")
    '                If thisControl.AutoFill And String.IsNullOrEmpty(cCtrl.Text) OrElse cCtrl.Text.Trim() = originalValue Then
    '                    thisControl.Text = englishText
    '                End If
    '            ElseIf TypeOf cCtrl Is CTextBox Then 'OrElse TypeOf cCtrl Is CTextBoxArabic Then
    '                ' check for duplicate values
    '                Dim thisControl As CTextBox = cCtrl
    '                If thisControl.ValueIsNumeric Then
    '                    If Not ValidateNumber(cCtrl) Then
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
    '    PresenterObj.AutoValidationsPassed = validationsPassed
    '    Return validationsPassed
    'End Function

    'Protected Overridable Function ChangesMade()
    '    Return PresenterObj.ChangesMade()
    'End Function

    Protected Overridable Sub CreateDataSources()
        '
    End Sub

    Protected Overridable Sub CreateMainFieldsDictionary()
        '
    End Sub

    Protected Overridable Sub DisplayView(idNo As Int32)
        Debugger.Break()
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

    Protected Overridable Sub RecordPositionChanged(ByRef e As RecordPositionChanged)
    End Sub

    Protected Overridable Sub RecordSaved(ByRef e As RecordSaved)
    End Sub

    Protected Overridable Sub BeforeAssignment()
    End Sub

    Protected Sub UpdateNavigationButtonDisplay(editing As Boolean, adding As Boolean)
        If SingleData Then
            btnAdd.Visible = False
            btnFind.Visible = False
            HideNavigatorButtons = True
        Else
            If AddMode Or EditMode Then
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
                btnSave.Enabled = True
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
                btnSave.Enabled = False
                btnUndo.Enabled = False
            End If
            If RecordCount = 0 Then
                btnFirst.Enabled = False
                btnPrev.Enabled = False
                btnNext.Enabled = False
                btnLast.Enabled = False
                btnEdit.Enabled = False
                btnAdd.Enabled = True
                btnDelete.Enabled = False
                btnFind.Enabled = False
                btnPrint.Enabled = False
                btnUndo.Enabled = False
                btnSave.Enabled = False
            ElseIf RecordPositionNumber = 1 Then
                btnFirst.Enabled = False
                btnPrev.Enabled = False
                If RecordCount = 1 Then
                    btnNext.Enabled = False
                    btnLast.Enabled = False
                End If
            ElseIf RecordPositionNumber = RecordCount Then
                btnNext.Enabled = False
                btnLast.Enabled = False
            End If
        End If
    End Sub

    'Protected Sub UpdateRecordCounter()
    '    RecordCount = PresenterObj.GetRecordCount()
    '    RecordDateTimeStampValue = PresenterObj.GetRecordDateTimeStamp(PresenterObj.TargetIdNo)
    '    tsbCurrentRecord.Text = PresenterObj.RecordPositionNumber
    '    tsbTotalRecords.Text = RecordCount
    'End Sub

    Private Shared Sub SetControlVisibility(ByRef cCtrl As Control, controlVisible As Boolean)
        ' if Visible is false, Don't show the controls content by masking content with '*' asterisk
        If Not controlVisible Then
            SetPropertyValue(cCtrl, "PasswordChar", Convert.ToChar("*"))
        End If
    End Sub

    Protected Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If _debugSwitch = 1 Then
            Debugger.Break()
        End If
        AddMode = True
        PublishClickedButton(ButtonClicked.Add)
        Inputs(True)
        UpdateNavigationButtonDisplay(False, True)
    End Sub

    Private Sub BtnArabic_Click(sender As Object, e As EventArgs) Handles btnArabic.Click
        SwitchUiLanguage(False)
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

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If _debugSwitch = 1 Then
            Debugger.Break()
        End If
        PublishClickedButton(ButtonClicked.Delete)
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If _debugSwitch = 1 Then
            Debugger.Break()
        End If
        PublishClickedButton(ButtonClicked.Edit)
        If EditMode Then
            TurnOnInputs()
        End If
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
        If _debugSwitch = 1 Then
            Debugger.Break()
        End If
        SwitchUiLanguage(True)
    End Sub

    Private Sub BtnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        If _debugSwitch = 1 Then
            Debugger.Break()
        End If
        PublishClickedButton(ButtonClicked.Previous)
    End Sub

    Private Sub BtnQuit_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
        If _debugSwitch = 1 Then
            Debugger.Break()
        End If
        Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim adding As Boolean
        If AddMode Then
            adding = True
        Else
            adding = False
        End If
        If _debugSwitch = 1 Then
            Debugger.Break()
        End If
        Dim allControls As New List(Of Control)
        For Each cCtrl As Control In FindControlRecursive(allControls, Me)
            If TypeOf cCtrl Is DataGridView Then
                Dim cGrid As DataGridView = cCtrl
                cGrid.EndEdit()
                GridValidator()
            End If
        Next
        If Ea IsNot Nothing Then
            Ea.PublishEvent(New SaveDataRequested(Me))
        End If
        If EditMode Or AddMode Then
            TurnOnInputs()
        Else
            TurnOffInputs()
            UpdateNavigationButtonDisplay(False, False)
            If adding Then
                If Messaging.Show(True, "AskAddAnotherRecord", "Do you want to add another record?",
                "Please confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    AddMode = True
                    PublishClickedButton(ButtonClicked.Add)
                    Inputs(True)
                    UpdateNavigationButtonDisplay(False, True)
                End If
            End If
        End If
        If QuitOnSave Then
            Close()
        End If
    End Sub

    Private Sub PublishClickedButton(buttonClicked As ButtonClicked)

        If Ea IsNot Nothing Then
            Ea.PublishEvent(New ViewButtonClicked(buttonClicked))
        End If
    End Sub

    Protected Overridable Sub GridValidator()
        '
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If _debugSwitch = 1 Then
            Debugger.Break()
        End If
        PublishClickedButton(ButtonClicked.Print)
    End Sub

    Private Sub BtnTranslate_Click(sender As Object, e As EventArgs) Handles btnTranslate.Click
        If _debugSwitch Then
            Debugger.Break()
        End If

        RunTranslator(VSystemViewIdNo)

    End Sub

    Private Sub BtnUndo_Click(sender As Object, e As EventArgs) Handles btnUndo.Click
        PublishClickedButton(ButtonClicked.Undo)
        If EditMode Or AddMode Then
            TurnOnInputs()
        Else
            TurnOffInputs()
        End If
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

    Private Sub CFormEntry_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F10 Then
            If btnSave.Enabled Then
                e.SuppressKeyPress = True
                e.Handled = True
                PublishClickedButton(ButtonClicked.Save)
                If EditMode Or AddMode Then
                    TurnOnInputs()
                Else
                    TurnOffInputs()
                End If
            Else
                Beep()
            End If
        ElseIf e.KeyCode = Keys.F2 Then
            If btnSave.Enabled Then
                e.SuppressKeyPress = True
                e.Handled = True
                PublishClickedButton(ButtonClicked.Edit)
            Else
                Beep()
            End If
        ElseIf e.KeyCode = Keys.Enter Then

            e.Handled = False
        End If
    End Sub

    Private Sub CFormEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not (LicenseManager.UsageMode = LicenseUsageMode.Designtime) Then

            AddHandler TextDisplayLanguageChanged, AddressOf OnTextDisplayLanguageChanged
            TextDisplayLanguage = CultureInfo.CurrentCulture.Name
            CreateDataSources()
            CreateMainFieldsDictionary()
            PublishClickedButton(ButtonClicked.Last)
            Inputs(False)

            'Try
            '    If Not SingleData Then
            '        RecordCount = PresenterObj.GetRecordCount()
            '        PresenterObj.RecordPositionNumber = RecordCount
            '    End If
            'Catch ex As Exception
            '    MessageBox.Show(ex.Message + Name)
            '    Debugger.Break()
            'End Try
            ' add bizObject rules to controls

            If Ea IsNot Nothing Then
                Ea.PublishEvent(New EntryFormLoaded(Me))
            End If

            If GlobalVariables.RightToLeftLayout Then
                btnArabic.Visible = False
                btnOriginal.Visible = True
            Else
                btnArabic.Visible = True
                btnOriginal.Visible = False
            End If
            If FirstControl IsNot Nothing Then
                FirstControl.Focus()
            End If
            If GlobalVariables.UserName.ToLower() <> $"arnel" Then
                HideButton(btnDebug)
            End If
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
            UpdateNavigationButtonDisplay(False, False)
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
                ElseIf TypeOf cCtrl Is CaComboBox Or TypeOf cCtrl Is CComboBox Then
                    SetPropertyValue(cCtrl, "SelectedItem", Nothing)
                    SetPropertyValue(cCtrl, "SelectedIndex", -1)
                    SetPropertyValue(cCtrl, "Text", "")
                ElseIf TypeOf cCtrl Is CDataGridView Then
                    'CType(cCtrl, CDataGridView).Rows.Clear()
                ElseIf TypeOf cCtrl Is CCustomDateTimePicker OrElse TypeOf cCtrl Is CDTPHijriDate OrElse
                TypeOf cCtrl Is tdpGregorian OrElse TypeOf cCtrl Is CDtpGregorianDate Then
                    SetPropertyValue(cCtrl, "Value", Nothing)
                End If
            Catch ' ignore fields that don't have a column to bind to
                ''
            End Try
        Next
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
                SetPropertyValue(ctrl, "EditingMode", onOff)
            End If
        Next
        If onOff Then
            InputsTurnedOn()
        Else
            InputsTurnedOff()
        End If
        If FirstControl IsNot Nothing Then
            FirstControl.Focus()
        End If
    End Sub

    Private Sub OnBeforeLoad() Handles MyBase.BeforeLoad
        SetFormTitleCaption()
    End Sub

    Private Sub PasteToolStripButton_Click(sender As Object, e As EventArgs) Handles PasteToolStripButton.Click
        PasteText()
    End Sub

    'Private Sub SetAllControlsDynamicProperties()
    '    If Not (LicenseManager.UsageMode = LicenseUsageMode.Designtime) Then
    '        Dim allControls As New List(Of Control)
    '        Dim resources = New ComponentResourceManager(Me.GetType())
    '        TableProperties = PresenterObj.TableProperties
    '        For Each cCtrl As Control In FindControlRecursive(allControls, Me)
    '            SetControlDynamicProperties(cCtrl)
    '            SetObjectSecurityNew(cCtrl)
    '        Next
    '    End If
    'End Sub

    'Private Sub SetControlDynamicProperties(ByRef cCtrl As Control)
    '    Dim myForm = FindForm()
    '    If TypeOf cCtrl Is IEntryControl Then
    '        ' get FieldName from control : by convention when using this system
    '        ' all DataBoundControls TextBox & Combobox that will hold field variables are named by convention in this format
    '        ' textboxes  = txt<FieldName>
    '        ' combobox   = cbo<FieldName>
    '        ' datetimePicker = dtp<FieldName>
    '        ' so to get the field name just get the characters from the control starting at the 4th character onwards
    '        Dim fldName As String
    '        fldName = cCtrl.Name.Substring(3) ' get control name starting from the 3rd character (0 based)

    '        For Each row In TableProperties
    '            If fldName.ToLower() = row.FldName.ToLower Then
    '                If TypeOf cCtrl Is CTextBox Or TypeOf cCtrl Is CMaskedTextBox OrElse TypeOf cCtrl Is CTextBoxArabic Then
    '                    If row.FldType.ToLower = "int" OrElse
    '                        row.FldType.ToLower = "smallint" OrElse
    '                        row.FldType.ToLower = "money" OrElse
    '                        row.FldType.ToLower = "decimal" OrElse
    '                        row.FldType.ToLower = "bigint" OrElse
    '                        row.FldType.ToLower = "tinyint" OrElse
    '                        row.FldType.ToLower = "smallmoney" OrElse
    '                        row.FldType.ToLower = "real" OrElse
    '                        row.FldType.ToLower = "float" OrElse
    '                        row.FldType.ToLower = "numeric" Then
    '                        Select Case row.FldType.ToLower
    '                            Case "int"
    '                                SetPropertyValue(cCtrl, "MinimumValue", -2147483648D)
    '                                SetPropertyValue(cCtrl, "MaximumValue", 2147483648D)
    '                            Case "tinyint"
    '                                SetPropertyValue(cCtrl, "MinimumValue", 0D)
    '                                SetPropertyValue(cCtrl, "MaximumValue", 255D)
    '                            Case "smallint"
    '                                SetPropertyValue(cCtrl, "MinimumValue", -32768D)
    '                                SetPropertyValue(cCtrl, "MaximumValue", 32767D)
    '                            Case "bigint"
    '                                SetPropertyValue(cCtrl, "MinimumValue", -922337236854775808D)
    '                                SetPropertyValue(cCtrl, "MaximumValue", 922337236854775807D)
    '                        End Select
    '                        SetPropertyValue(cCtrl, "ValueIsNumeric", True)
    '                    Else
    '                        SetPropertyValue(cCtrl, "Maxlength", If(row.fldType.ToLower() = "nvarchar", Convert.ToInt16(row.MaxLength / 2), row.MaxLength))
    '                        SetPropertyValue(cCtrl, "ValueIsNullable", row.IsNullable)
    '                        If (Not row.IsIdentity) And (Not row.IsNullable) Then
    '                            If GetPropertyValue(cCtrl, "IgnoreNullCheck") Then
    '                                If GetPropertyValue(cCtrl, "LinkedLabel") Is Nothing Then
    '                                    MyErrorProvider.Controls.AddMandatory(cCtrl, cCtrl.Name)
    '                                Else
    '                                    MyErrorProvider.Controls.AddMandatory(cCtrl, GetPropertyValue(cCtrl, "LinkedLabel"))
    '                                End If
    '                            End If
    '                        End If
    '                    End If
    '                    Exit For
    '                ElseIf TypeOf cCtrl Is CaComboBox OrElse TypeOf cCtrl Is CComboBox Then
    '                    '
    '                    '
    '                ElseIf TypeOf cCtrl Is CCustomDateTimePicker OrElse TypeOf cCtrl Is CDateTimePicker OrElse
    '                    TypeOf cCtrl Is CDTPHijriDate OrElse TypeOf cCtrl Is tdpGregorian OrElse
    '                    TypeOf cCtrl Is CDtpGregorianDate Then
    '                    SetPropertyValue(cCtrl, "ValueIsNullable", row.IsNullable)
    '                    If Not row.IsNullable Then
    '                        'Add this controls to the Mandatory fields error provider.
    '                        MyErrorProvider.Controls.AddMandatory(cCtrl, cCtrl.Name)
    '                    End If
    '                    Exit For
    '                End If
    '                If TypeOf cCtrl Is IFindableControl And Not (TypeOf cCtrl Is CForm) Then
    '                    Dim thisControl As IFindableControl = cCtrl
    '                    If thisControl.FindEnabled Then
    '                        thisControl = cCtrl
    '                        thisControl.FindDataType = GetObjectDataType(GetFieldType(Name.Substring(3)))
    '                    End If
    '                End If
    '            End If
    '        Next
    '    End If
    'End Sub

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
        PublishClickedButton(ButtonClicked.Undo)
        btnArabic.Visible = originalUi
        btnOriginal.Visible = Not originalUi
        RecordPositionNumber = RecordPositionNumber
    End Sub

    Protected Overridable Function DataIsValid() As Boolean
        Debugger.Break()
        Return False
    End Function

    Public Shared Sub EnableDoubleBuff(ByVal cont As System.Windows.Forms.Control)
        Dim DemoProp As System.Reflection.PropertyInfo = GetType(System.Windows.Forms.Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic Or System.Reflection.BindingFlags.Instance)
        DemoProp.SetValue(cont, True, Nothing)
    End Sub

    'Public Function GetFieldType(fieldName As String) As Type
    '    Return CallByName(Me, fieldName, CallType.Get).GetType
    'End Function

    Public Property HideNavigatorButtons As Boolean
    Public Property IgnoreTextBoxNumParserMessage As Boolean
    Public Property DataErrorsFound As Boolean

    Protected Function TextBoxNumParser(Of T As Structure)(ByRef control As CTextBox) As T
        Dim retValue As T
        Try
            retValue = Parser(Of T).Parser(control.Text)
            Text = retValue.ToString()
        Catch ex As Exception
            If Not IgnoreTextBoxNumParserMessage Then
                If control.LinkedLabel IsNot Nothing Then
                    Messaging.ShowParametrizedMessage(True, "MsgInvalidNumericValue", {"controlName", control.LinkedLabel.Text})
                Else
                    Messaging.ShowParametrizedMessage(True, "MsgInvalidNumericValue", {"controlName", control.Name})
                End If
            End If
            retValue = Parser(Of T).Parser("0")
            DataErrorsFound = True
        End Try
        Return retValue
    End Function

End Class