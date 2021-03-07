Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.Reflection
Imports System.Threading
Imports System.Windows.Forms
Imports AATM.Libraries
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.CustomControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

Public Class CFormEntry
    Implements ISubscriber(Of RecordPositionChanged),
               ISubscriber(Of EditModeChanged),
               ISubscriber(Of AddModeChanged),
               ISubscriber(Of ValidatingData),
               ISubscriber(Of PassErrorList),
               ISubscriber(Of QuitView),
               ISubscriber(Of RecordSaved),
               ISubscriber(Of BeforeAssignment)
    '          ISubscriber(Of RecordDeleted),

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

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        KeyPreview = True
        DoubleBuffered = True

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Delegate Sub SafeCallDelegate(ByRef controlObject As Control, textString As String)

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

    Public Property Ea As EventAggregator

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Type here the Table name usually the Master (Parent) Table name as shown in the Database ")>
    <Browsable(True)>
    Public Property MainTableName As String = ""

    Public Property TableProperties As Array

    Protected Property FormTitleCaption As String = ""

    Protected Property RecordCount As Integer

    Public Sub CheckDataChanges()
    End Sub

    Public Sub FindField(txtControl As Control)
        Dim fieldName As String = txtControl.Name.Substring(3)
        Dim searchString As String
        Dim searchAnywhere As Boolean
        searchString = CallByName(txtControl, "GetTextToSearch", CallType.Get)
        searchAnywhere = CallByName(txtControl, "GetSearchAnywhere", CallType.Get)
        PresenterObj.FindField(fieldName, searchString, searchAnywhere)
    End Sub

    Public Function GetMainFieldsDictionary()
        Return MainFieldsDictionary
    End Function

    Public Sub GotoTargetRecordWorker_DoWorkHandler(sender As Object, e As DoWorkEventArgs(Of String))
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

    Public Sub HideButton(button As ToolStripButton)
        button.Visible = False
    End Sub

    Public Sub OnEventHandlerAddModeChanged(ByRef e As AddModeChanged) Implements ISubscriber(Of AddModeChanged).OnEventHandler
        If e.AddMode Then
            Inputs(True)
            UpdateButtonDisplays(False, True)
        Else
            Inputs(False)
            UpdateButtonDisplays(False, False)
        End If
    End Sub

    Public Sub OnEventHandlerEditModeChanged(ByRef e As EditModeChanged) Implements ISubscriber(Of EditModeChanged).OnEventHandler
        If e.EditMode Then
            Inputs(True)
            UpdateButtonDisplays(True, False)
        Else
            Inputs(False)
            UpdateButtonDisplays(False, False)
        End If
    End Sub

    Public Sub OnEventHandlerPassErrorList(ByRef e As PassErrorList) Implements ISubscriber(Of PassErrorList).OnEventHandler
        MyErrorProvider.ClearAllErrorMessages()
        For Each _err In e.Errors
            For Each ctrl In MyErrorProvider.Controls
                If ctrl.errormessage = _err Then
                    If DirectCast(ctrl.controlobj, System.Windows.Forms.Control).Dock = DockStyle.Fill Then
                        MyErrorProvider.SetIconPadding(ctrl.ControlObj, -18)
                    End If
                    If GlobalVariables.RightToLeftLayout Then
                        MyErrorProvider.SetIconAlignment(ctrl.ControlObj, ErrorIconAlignment.TopLeft)
                    Else
                        MyErrorProvider.SetIconAlignment(ctrl.ControlObj, ErrorIconAlignment.TopRight)
                    End If
                    MyErrorProvider.SetError(ctrl.ControlObj, _err)
                End If
            Next
        Next
    End Sub

    Public Sub OnEventHandlerQuitView(ByRef e As QuitView) Implements ISubscriber(Of QuitView).OnEventHandler
        CancelClose = False
        Close()
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

    Public Sub OnEventHandlerRecordPositionChanged(ByRef e As RecordPositionChanged) Implements ISubscriber(Of RecordPositionChanged).OnEventHandler
        If Not SingleData Then
            UpdateRecordCounter()
            UpdateButtonDisplays(False, False)
            MyErrorProvider.ClearAllErrorMessages()
            MyErrorProvider.Clear()
            Inputs(False)
            RecordPositionChanged(e)
        End If
    End Sub

    Public Sub OnEventHandlerSavedRecord(ByRef e As RecordSaved) Implements ISubscriber(Of RecordSaved).OnEventHandler
        RecordSaved(e)
    End Sub

    'Public Sub OnEventHandlerDeletedRecord(ByRef e As RecordDeleted) Implements ISubscriber(Of RecordDeleted).OnEventHandler
    '    RecordDeleted(e)
    'End Sub

    Public Sub OnEventHandlerAddedRecord(ByRef e As BeforeAssignment) Implements ISubscriber(Of BeforeAssignment).OnEventHandler
        BeforeAssignment()
    End Sub

    Public Sub OnEventHandlerValidatingData(ByRef e As ValidatingData) Implements ISubscriber(Of ValidatingData).OnEventHandler
        If ValidateView() Then
            e.Validated = True
        Else
            e.Validated = False
        End If
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

    Public Sub ShowWaitForm_DoWorkHandler(sender As Object, e As DoWorkEventArgs(Of String))
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

    Protected Sub TurnOffInputs()
        Inputs(False)
        InputsTurnedOff()
    End Sub

    Protected Sub TurnOnInputs()
        Inputs(True)
        InputsTurnedOn()
        FirstControl.Focus()
    End Sub

    Protected Overridable Sub InputsTurnedOn()
    End Sub

    Protected Overridable Sub InputsTurnedOff()
    End Sub

    Public Function ValidateNumericValues()
        Dim validationsPassed As Boolean
        validationsPassed = True
        Dim allControls As New List(Of Control)
        For Each cCtrl As Control In FindControlRecursive(allControls, Me)
            If TypeOf cCtrl Is IEntryControl Then
                If TypeOf cCtrl Is CTextBox Then
                    Dim thisControl As CTextBox = cCtrl
                    If thisControl.ValueIsNumeric Then
                        If Not ValidateNumber(cCtrl) Then
                            validationsPassed = False
                            Exit For
                        End If
                    End If
                End If
            End If
        Next
        Return validationsPassed
    End Function

    Public Overridable Function ValidateView()
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
                ElseIf TypeOf cCtrl Is CTextBox Then 'OrElse TypeOf cCtrl Is CTextBoxArabic Then
                    ' check for duplicate values
                    Dim thisControl As CTextBox = cCtrl
                    If thisControl.ValueIsNumeric Then
                        If Not ValidateNumber(cCtrl) Then
                            validationsPassed = False
                        End If
                    End If
                    If validationsPassed AndAlso GetPropertyValue(cCtrl, "ValueIsUnique") Then
                        validationsPassed = ValueIsUnique(cCtrl, validationsPassed)
                    End If
                    If validationsPassed AndAlso GetPropertyValue(cCtrl, "ValueIsUniqueBlanksAllowed") Then
                        If cCtrl IsNot Nothing AndAlso cCtrl.Text <> "" Then
                            validationsPassed = ValueIsUnique(cCtrl, validationsPassed)
                        End If
                    End If
                End If

            End If
        Next
        PresenterObj.AutoValidationsPassed = validationsPassed
        Return validationsPassed
    End Function

    Private Function ValueIsUnique(cCtrl As Control, validationsPassed As Boolean) As Boolean
        Dim originalValue As String

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
            Messaging.ShowParametrizedMessage(True, "MsgDuplicateValuesNotAllowed", {"fieldName", cCtrl.Text, "fieldDescription", fieldDescription})
            validationsPassed = False
            Return validationsPassed
        End If
        Return validationsPassed
    End Function

    Public Function ValidateNumber(ByRef obj As Object)
        Dim objName = Strings.Mid(obj.Name, 4)
        'If objName.ToLower() = "length" Or objName.ToLower() = "decimalpart" Then
        '    Debugger.Break()
        'End If
        Dim targetValue = obj.Text
        Dim y As PropertyInfo = [GetType]().GetProperty(objName, BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.IgnoreCase)
        If y IsNot Nothing Then
            Dim x As Type = y.PropertyType
            Dim u As Type = Nullable.GetUnderlyingType(x)
            If targetValue Is Nothing OrElse targetValue.Equals(DBNull.Value) OrElse String.IsNullOrWhiteSpace(targetValue) Then
                Return True
                'If u IsNot Nothing Then
                '    Return True
                'Else
                '    If Type.GetTypeCode(x) = TypeCode.String Then
                '        Return True
                '    Else
                '        MessageBox.Show($"Empty values not allowed for " & obj.Name & ".")
                '        Return True
                '    End If
                'End If
            Else
                Dim num As Double
                Dim isNumeric As Boolean = Decimal.TryParse(targetValue, num)
                If Not isNumeric Then
                    MessageBox.Show($"The entered value for " & obj.Name & "<" & obj.Text & $"> must be a number (numeric operations not allowed)!")
                    Return False
                End If
                Dim nMinValue As Double
                Dim nMaxValue As Double
                Dim typeCode As TypeCode = Type.GetTypeCode(x)
                Dim underlyingTypeCode As TypeCode = Type.GetTypeCode(u)
                If u Is Nothing Then
                    nMinValue = GlobalFunctions.GetMinMaxValue(typeCode, nMaxValue)
                Else
                    typeCode = Type.GetTypeCode(u)
                    nMinValue = GlobalFunctions.GetMinMaxValue(underlyingTypeCode, nMaxValue)
                End If
                If num < nMinValue OrElse num > nMaxValue Then
                    MessageBox.Show($"The entered value for " & obj.Name & $" must be between " & nMinValue.ToString() & " to " & nMaxValue.ToString())
                    Return False
                End If
                Dim isInteger As Boolean = False
                If u Is Nothing Then
                    If NumTypeIsInteger(typeCode) Then
                        isInteger = True
                    End If
                Else
                    If NumTypeIsInteger(underlyingTypeCode) Then
                        isInteger = True
                    End If
                End If
                If isInteger Then
                    If Not Math.Abs(num Mod 1) <= (Double.Epsilon * 100) Then
                        MessageBox.Show($"The entered value for " & obj.Name & $" must be a whole number (Integer)!")
                        Return False
                    End If
                End If
                Return True
            End If
        Else
            Return True
        End If

    End Function

    'Public Function GetObjMinMaxValue(obj As Object, ByRef nMaxValue As Double) As Double
    '    Dim objName = Strings.Mid(obj.Name, 4)
    '    Dim targetValue = obj.Text
    '    Dim y As PropertyInfo = [GetType]().GetProperty(objName)
    '    Dim x As Type = y.PropertyType
    '    Dim u As Type = Nullable.GetUnderlyingType(x)
    '    Dim typeCode As TypeCode
    '    Dim nMinValue As Double
    '    If u Is Nothing Then
    '        typeCode = Type.GetTypeCode(x)
    '        nMinValue = GetMinMaxValue(typeCode, nMaxValue)
    '    Else
    '        typeCode = Type.GetTypeCode(u)
    '        nMinValue = GetMinMaxValue(typeCode, nMaxValue)
    '    End If
    '    Return nMinValue
    'End Function

    'Public Function GetMinMaxValue(typeCode As TypeCode, ByRef nMaxValue As Double) As Double
    '    Dim nMinValue As Double
    '    Select Case typeCode
    '        Case TypeCode.Byte
    '            nMinValue = Byte.MinValue
    '            nMaxValue = Byte.MaxValue
    '        Case TypeCode.Int16
    '            nMinValue = Int16.MinValue
    '            nMaxValue = Int16.MaxValue
    '        Case TypeCode.Int32
    '            nMinValue = Int32.MinValue
    '            nMaxValue = Int32.MaxValue
    '        Case TypeCode.Int64
    '            nMinValue = Int64.MinValue
    '            nMaxValue = Int64.MaxValue
    '        Case TypeCode.UInt16
    '            nMinValue = UInt16.MinValue
    '            nMaxValue = UInt16.MaxValue
    '        Case TypeCode.UInt32
    '            nMinValue = UInt32.MinValue
    '            nMaxValue = UInt32.MaxValue
    '        Case TypeCode.UInt64
    '            nMinValue = UInt64.MinValue
    '            nMaxValue = UInt64.MaxValue
    '        Case TypeCode.Single
    '            nMinValue = Single.MinValue
    '            nMaxValue = Single.MaxValue
    '        Case TypeCode.Decimal
    '            nMinValue = Decimal.MinValue
    '            nMaxValue = Decimal.MaxValue
    '        Case TypeCode.DBNull
    '            nMinValue = 0
    '            nMaxValue = 0
    '        Case Else
    '            nMinValue = Double.MinValue
    '            nMaxValue = Double.MaxValue
    '    End Select
    '    Return nMinValue
    'End Function

    Protected Overridable Sub AddMandatoryFieldCHeck()
    End Sub

    Protected Overridable Function ChangesMade()
        Return PresenterObj.ChangesMade()
    End Function

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

    'Protected Overridable Sub RecordDeleted(ByRef e As RecordDeleted)
    'End Sub

    Protected Overridable Sub BeforeAssignment()
    End Sub

    Protected Sub UpdateButtonDisplays(editing As Boolean, adding As Boolean)
        If SingleData Then
            btnAdd.Visible = False
            btnFind.Visible = False
            HideNavigatorButtons = True
        Else
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
                btnPrint.Enabled = False
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
                Else
                    btnFirst.Enabled = True
                    btnPrev.Enabled = True
                End If
                If PresenterObj.RecordPositionNumber >= RecordCount Then
                    btnLast.Enabled = False
                    btnNext.Enabled = False
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
                    btnPrint.Enabled = False
                Else
                    btnEdit.Enabled = True
                    btnDelete.Enabled = True
                    btnAdd.Enabled = True
                    btnUndo.Enabled = False
                    btnSave.Enabled = False
                    btnPrint.Enabled = True
                End If
            End If
        End If
    End Sub

    Protected Sub UpdateRecordCounter()
        RecordCount = PresenterObj.GetRecordCount()
        RecordDateTimeStampValue = PresenterObj.GetRecordDateTimeStamp(PresenterObj.TargetIdNo)
        tsbCurrentRecord.Text = PresenterObj.RecordPositionNumber
        tsbTotalRecords.Text = RecordCount
    End Sub

    Private Shared Sub SetControlVisibility(ByRef cCtrl As Control, controlVisible As Boolean)
        ' if Visible is false, Don't show the controls content by masking content with '*' asterisk
        If Not controlVisible Then
            SetPropertyValue(cCtrl, "PasswordChar", Convert.ToChar("*"))
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        RunButtonRoutine(ButtonClicked.Add)
    End Sub

    Private Sub BtnArabic_Click(sender As Object, e As EventArgs) Handles btnArabic.Click
        SwitchUiLanguage(False)
    End Sub

    Private Sub BtnDebug_Click(sender As Object, e As EventArgs) Handles btnDebug.Click
        If _debugSwitch = 0 Then
            _debugSwitch = 1
            'Debugger.Break()
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
        RunButtonRoutine(ButtonClicked.Delete)
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If _debugSwitch = 1 Then
            Debugger.Break()
        End If
        'RaiseEvent BeforeEdit()
        RunButtonRoutine(ButtonClicked.Edit)
    End Sub

    Private Sub BtnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        If _debugSwitch = 1 Then
            Debugger.Break()
        End If
        RunButtonRoutine(ButtonClicked.Find)
    End Sub

    Private Sub BtnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        If _debugSwitch = 1 Then
            Debugger.Break()
        End If
        RunButtonRoutine(ButtonClicked.First)
    End Sub

    Private Sub BtnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        If _debugSwitch = 1 Then
            Debugger.Break()
        End If
        RunButtonRoutine(ButtonClicked.Last)
    End Sub

    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If _debugSwitch = 1 Then
            Debugger.Break()
        End If
        RunButtonRoutine(ButtonClicked.Next)
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
        RunButtonRoutine(ButtonClicked.Previous)
    End Sub

    Private Sub BtnQuit_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
        If _debugSwitch = 1 Then
            Debugger.Break()
        End If
        RunButtonRoutine(ButtonClicked.Quit)
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
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
        If ValidateNumericValues() Then
            RunButtonRoutine(ButtonClicked.Save)
        End If
        If PresenterObj.SaveSuccessful AndAlso PresenterObj.QuitOnSave Then
            PresenterObj.GoQuit()
        End If
    End Sub

    Protected Overridable Sub GridValidator()
        '
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If _debugSwitch = 1 Then
            Debugger.Break()
        End If
        RunButtonRoutine(ButtonClicked.Print)
    End Sub

    Private Sub BtnTranslate_Click(sender As Object, e As EventArgs) Handles btnTranslate.Click
        If _debugSwitch Then
            Debugger.Break()
        End If

        RunTranslator(VSystemViewIdNo)

    End Sub

    Private Sub BtnUndo_Click(sender As Object, e As EventArgs) Handles btnUndo.Click
        RunButtonRoutine(ButtonClicked.Undo)
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
                PresenterObj.GoSaveRecord()
            Else
                Beep()
            End If
        ElseIf e.KeyCode = Keys.F2 Then
            If btnSave.Enabled Then
                e.SuppressKeyPress = True
                e.Handled = True
                PresenterObj.GoEditRecord()
            Else
                Beep()
            End If
        ElseIf e.KeyCode = Keys.Enter Then

            e.Handled = False
        End If
    End Sub

    'Private Sub CFormEntry_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
    '    If e.KeyChar = ChrW(Keys.F10) Then
    '        e.Handled = True
    '    ElseIf e.KeyChar = ChrW(Keys.F2) Then
    '        e.Handled = True
    '    Else
    '        e.Handled = False
    '    End If
    'End Sub

    Private Sub CFormEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not (LicenseManager.UsageMode = LicenseUsageMode.Designtime) Then

            AddHandler TextDisplayLanguageChanged, AddressOf OnTextDisplayLanguageChanged
            TextDisplayLanguage = CultureInfo.CurrentCulture.Name
            CreateDataSources()
            CreateMainFieldsDictionary()
            Inputs(False)

            Try
                If Not SingleData Then
                    RecordCount = PresenterObj.GetRecordCount()
                    PresenterObj.RecordPositionNumber = RecordCount
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message + Name)
                Debugger.Break()
            End Try
            ' add bizObject rules to controls
            Dim rules = PresenterObj.GetBizObjectRules()
            For Each rule In rules
                Dim control As Control = Nothing
                MainFieldsDictionary.TryGetValue(rule.Property, control)
                'If control.GetType() Is DataGridView Then

                'Else
                MyErrorProvider.Controls.AddValidation(control, rule.Property, rule.Error)
                'End If
            Next

            SetAllControlsDynamicProperties()
            AddMandatoryFieldCHeck()
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
            'UpdateButtonDisplays(False, False)
            Dim controlSecurityValues = PresenterObj.GetUserSecurityForKey("_Developer", GlobalVariables.SecurityGroupIdNo)
            If Not (controlSecurityValues IsNot Nothing AndAlso controlSecurityValues.Count > 0 AndAlso controlSecurityValues(0)) Then
                ' Visible property stored in first element of the array
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
            UpdateButtonDisplays(False, False)
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
                    'SetPropertyValue(cCtrl, "Text", "")
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

    Private Sub CopyToolStripButton_Click(sender As Object, e As EventArgs) Handles CopyToolStripButton.Click
        CopyText()
    End Sub

    Private Sub CutToolStripButton_Click(sender As Object, e As EventArgs) Handles CutToolStripButton.Click
        CutText()
    End Sub

    'Private Function GetControlSecurityIdNo(ByRef controlSecurityKey As String) As Int64
    '    Return PresenterObj.GetControlSecurityIdNo(controlSecurityKey)
    'End Function

    Private Function GetControlSecurityKey(ByRef cCtrl As Control)
        If Not (LicenseManager.UsageMode = LicenseUsageMode.Designtime) Then
            If cCtrl.GetType().GetProperty("SecurityKey") IsNot Nothing Then
                Return GetPropertyValue(cCtrl, "SecurityKey")
            End If
        End If
        Return ""
    End Function

    Private Function GetControlSecurityValues(ByRef controlSecurityKey As String) As ArrayList
        Dim controlSecurityObjectIdNo As Int16
        controlSecurityObjectIdNo = PresenterObj.GetControlSecurityIdNo(controlSecurityKey)
        Return PresenterObj.GetUserSecurity(controlSecurityObjectIdNo, GlobalVariables.SecurityGroupIdNo)
    End Function

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

    Private Sub RunButtonRoutine(ByVal clickedButton As ButtonClicked)
        If _debugSwitch = 1 Then
            Debugger.Break()
        End If
        If Ea IsNot Nothing Then
            Ea.PublishEvent(New SelectedButton(clickedButton))
        End If
    End Sub

    Private Sub SetAllControlsDynamicProperties()
        If Not (LicenseManager.UsageMode = LicenseUsageMode.Designtime) Then
            Dim allControls As New List(Of Control)
            Dim resources = New ComponentResourceManager(Me.GetType())
            TableProperties = PresenterObj.TableProperties
            For Each cCtrl As Control In FindControlRecursive(allControls, Me)
                SetControlDynamicProperties(cCtrl)
                SetControlSecurity(cCtrl)
            Next
        End If
    End Sub

    Private Sub SetControlDynamicProperties(ByRef cCtrl As Control)
        'If cCtrl.GetType().GetProperty("DataBoundControl") IsNot Nothing Then
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
                'If fldName.ToLower() = "amount" Then
                '    Debugger.Break()
                'End If
                If fldName.ToLower() = row.FldName.ToLower Then
                    If TypeOf cCtrl Is CTextBox OrElse TypeOf cCtrl Is CComboBox OrElse TypeOf cCtrl Is CMaskedTextBox OrElse
                       TypeOf cCtrl Is CTextBoxArabic Then
                        If row.FldType.ToLower = "int" OrElse
                            row.FldType.ToLower = "smallint" OrElse
                            row.FldType.ToLower = "money" OrElse
                            row.FldType.ToLower = "decimal" OrElse
                            row.FldType.ToLower = "bigint" OrElse
                            row.FldType.ToLower = "tinyint" OrElse
                            row.FldType.ToLower = "smallmoney" OrElse
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
                            End Select

                            SetPropertyValue(cCtrl, "ValueIsNumeric", True)
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
                                    End If
                                End If
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

    Protected Overridable Function DataIsValid() As Boolean
        Debugger.Break()
        Return False
    End Function

    Public Shared Sub EnableDoubleBuff(ByVal cont As System.Windows.Forms.Control)
        Dim DemoProp As System.Reflection.PropertyInfo = GetType(System.Windows.Forms.Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic Or System.Reflection.BindingFlags.Instance)
        DemoProp.SetValue(cont, True, Nothing)
    End Sub

    Public Property HideNavigatorButtons As Boolean

    Public Function ValidateDataBoundGrid(Of TV As New, TM As New)(viewProperty As Object, dataGridView As DataGridView, dictionary As Dictionary(Of String, Object), Optional tabPage As TabPage = Nothing)
        Dim errorFound As Boolean = False
        Dim rules = PresenterObj.GetBizRules(viewProperty)
        Dim bo = PresenterObj.GetBizObject(viewProperty)
        For Each rule In rules
            For Each col In dataGridView.Columns()
                Dim colName = col.DataPropertyName
                If rule.Property = colName Then
                    For Each row As DataGridViewRow In dataGridView.Rows
                        Dim model As New TM
                        If row.Index() < dataGridView.RowCount() - 1 Then
                            GlobalVariables.Mapper.Map(viewProperty(row.Index()), model)
                            GlobalVariables.Mapper.Map(model, bo)
                            If Not bo.IsRuleValid(rule) Then
                                Dim obj As New Object
                                dictionary.TryGetValue(rule.Property, obj)
                                row.Cells(obj.Name).ErrorText = rule.Error
                                errorFound = True
                            End If
                        End If
                    Next
                End If
            Next
        Next
        If errorFound Then
            If tabPage IsNot Nothing Then
                tabPage.ImageIndex = 0
            Else
                tabPage.ImageIndex = -1
            End If
        Else
            If tabPage IsNot Nothing Then
                tabPage.ImageIndex = -1
            End If
        End If
        Return Not errorFound
    End Function

    '#Region "Temporary Events"

    '    Public Event InputsTurnedOff()

    '    Public Event InputsTurnedOn()

    '#End Region

    'Public Shared Function FormIsValid(ByRef objForm As Form) As Boolean

    '    Dim valid As Boolean = True
    '    ValidateControls(objForm, objForm.Controls, valid)

    '    objForm.Focus()
    '    If Not objForm.Validate Then valid = False

    '    Return valid

    'End Function

    'Public Shared Function FormIsValid(ByRef objForm As Form, ByRef topLevelControl As Control) As Boolean

    '    Dim valid As Boolean = True
    '    ValidateControls(objForm, topLevelControl.Controls, valid)

    '    objForm.Focus()
    '    If Not objForm.Validate Then valid = False

    '    Return valid

    'End Function

    'Private Shared Sub ValidateControls(ByRef objForm As Form, ByRef objControls As System.Windows.Forms.Control.ControlCollection, ByRef valid As Boolean)

    '    For Each objControl As Control In objControls

    '        If TypeOf objControl IsNot RadioButton Then

    '            objControl.Focus()
    '            If Not objForm.Validate() Then valid = False

    '            If TypeOf objControl Is TabControl Then

    '                Dim tabControl As TabControl = objControl
    '                Dim index As Integer = tabControl.SelectedIndex

    '                For Each objTab As TabPage In tabControl.TabPages
    '                    tabControl.SelectedTab = objTab
    '                    ValidateControls(objForm, objTab.Controls, valid)
    '                Next

    '            ElseIf objControl.HasChildren Then

    '                ValidateControls(objForm, objControl.Controls, valid)

    '            End If

    '        End If

    '    Next

    'End Sub

End Class