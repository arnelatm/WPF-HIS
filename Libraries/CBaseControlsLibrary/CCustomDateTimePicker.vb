Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.GlobalResources

Public Class CCustomDateTimePicker
    Implements IEntryControl

    Private _dropDownClicked = False
    Public EmptyMask As String
    Private ReadOnly _origCulture As CultureInfo
    Private _ltrCulture As CultureInfo
    Public MaxLength As Integer
    Private _valueIsNullable As Boolean
    Private _displayOnly As Boolean = False
    Private _readOnlyDp As Boolean = False
    Private _defaultValue As DateTime? = Nothing
    Private _dtpDefaultValue As DateTime? = Nothing
    Private _isMandatory As Boolean
    Private _textToSearch As String
    Private _searchPlace As Char
    Private _securityKey As String
    Private _minimumDate As DateTime?
    Private _lastDate As DateTime? = Today()
    Private _origCultureStr As String
    Private _tmpValueChanged As Boolean = False
    Private _dtpDropCount As Integer = 0
    Private _programmaticChange As Boolean = False
    Private _initialized As Boolean = False
    Private _curCulture As CultureInfo
    Private _cultureInfoDisplayName As String = ""
    Private _targetCultureName As String = ""
    Private _targetCulture As CultureInfo
    Private _targetCalendar As Calendar
    Private _calendarType As GlobalSubs.CalendarToUse = CalendarToUse.Gregorian
    Private _longDateWidth As Integer = 110
    Private _dateWidth As Integer = 76
    Private _totalWidth As Integer = 0
    Private _buttonWidth As Integer = 21
    Private _btnCalendarTypeWidth As Integer = 15
    Private _timeWidth As Integer = 70
    Private _showTime As Boolean = False
    Private _showLongDate As Boolean = False
    Private _editsAllowed As Boolean = False
    Private _editingMode As Boolean = True

    Private WithEvents _contextMenuStrip1 As New ContextMenuStrip

    Public Event ValueChanged As EventHandler

    Public Sub New()
        _origCulture = CultureInfo.CurrentCulture
        _targetCulture = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name)
        _initialized = False
        ' This call is required by the designer.
        InitializeComponent()
        _initialized = True
        SetupCalendarDisplay()
        txtDate.Width = _dateWidth
        dtp.Width = _buttonWidth
        txtTime.Width = _timeWidth
        btnCalendarType.Width = _btnCalendarTypeWidth
        txtLongDate.Width = _longDateWidth
        SetupDisplayWidths()
        EditingMode = True
        txtDate.DateField = True
        'txtDate.FieldName = Name
    End Sub

#Region "Declarations#"

    ' Text Menu Captions
    Private ReadOnly _textFind = MessagingLibrary.Messaging.TranslateCaption("Find on this field")

    Private ReadOnly _textSelectAll = MessagingLibrary.Messaging.TranslateCaption("Select All Text")

#End Region

    Public Property CalendarType As CalendarToUse
        Get
            Return _calendarType
        End Get
        Set
            If _calendarType <> Value Then
                _calendarType = Value
                SetupCalendarDisplay()
            End If
        End Set
    End Property

    Public Sub SetupCalendarDisplay()
        SetTargetCulture()
        SetDateEntryMask()
    End Sub

    Public Sub SetDateEntryMask()
        Dim dateMask As String
        Dim tempDate As DateTime
        tempDate = #2018-12-31#
        If _targetCulture.Name = "ar-SA" Then
            dateMask = Regex.Replace(CalendarDateToShortDateString(tempDate, _targetCulture), "\d", "0")
        Else
            dateMask = Regex.Replace(CalendarDateToShortDateString(tempDate, _targetCulture), "\d", "0")
        End If
        EmptyMask = Regex.Replace(dateMask, "\d", " ").TrimEnd
        txtDate.Mask = dateMask
        txtDate.EmptyMask = EmptyMask
        MaxLength = Len(dateMask)
        txtDate.MaxLength = MaxLength
    End Sub

    Private Sub SetTargetCulture()
        Select Case CalendarType
            Case CalendarToUse.Hijri
                TargetCalendar = New HijriCalendar()
                If Not CultureSupportUmAlQura(_targetCulture) Then
                    _targetCulture = CultureInfo.CreateSpecificCulture("ar-SA")
                End If
                btnCalendarType.Text = Strings.HijriCalendarMarker
            Case CalendarToUse.UmAlQura
                TargetCalendar = New UmAlQuraCalendar()
                If Not CultureSupportUmAlQura(_targetCulture) Then
                    _targetCulture = CultureInfo.CreateSpecificCulture("ar-SA")
                End If
                btnCalendarType.Text = Strings.UmAlQuraCalendarMarker
            Case Else
                TargetCalendar = New GregorianCalendar()
                btnCalendarType.Text = Strings.GregorianCalendarMarker

        End Select
        _targetCulture.DateTimeFormat.Calendar = TargetCalendar
    End Sub

    Private Sub ToggleTargetCulture()
        Dim myValue = Value
        Select Case CalendarType
            Case CalendarToUse.Hijri
                CalendarType = CalendarToUse.Gregorian
                SetTargetCulture()
            Case CalendarToUse.UmAlQura
                CalendarType = CalendarToUse.Hijri
                SetTargetCulture()
            Case CalendarToUse.Gregorian
                CalendarType = CalendarToUse.UmAlQura
                SetTargetCulture()
            Case Else
                CalendarType = CalendarToUse.Gregorian
                SetTargetCulture()
        End Select
        Value = myValue
    End Sub

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    <Description("The Default Value that this control will have if initialized or cleared.")>
    <Browsable(True)>
    Public Property DefaultValue As DateTime?
        Get
            Return _defaultValue
        End Get
        Set
            _defaultValue = Value
        End Set
    End Property

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    <Description("The Default Value that the datetimepicker control will show if value is empty or invalid date.")>
    <Browsable(True)>
    Public Property DtpDefaultValue As DateTime?
        Get
            Return _dtpDefaultValue
        End Get
        Set
            _dtpDefaultValue = Value
        End Set
    End Property

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    <Description("Set to True to specify that this control is read only.")>
    <Browsable(True)>
    Public Property DisplayOnly As Boolean
        Get
            Return _displayOnly
        End Get
        Set
            _displayOnly = Value
            txtTime.DisplayOnly = Value
            txtDate.DisplayOnly = Value
            txtLongDate.DisplayOnly = Value
            If _displayOnly Then
                dtp.Visible = False
                btnCalendarType.Visible = False
            Else
                dtp.Visible = True
                btnCalendarType.Visible = True
            End If
        End Set
    End Property

    '<Bindable(True)>
    '<Category("Properties")>
    '<DefaultValue(GetType(Boolean))>
    '<Description("Set to True to specify that this control is read only.")>
    '<Browsable(True)>
    Public Property ReadOnlyDp As Boolean
        Get
            Return _readOnlyDp
        End Get
        Set
            _readOnlyDp = Value
            txtDate.DisplayOnly = Value
            txtLongDate.DisplayOnly = Value
            txtTime.DisplayOnly = Value
        End Set
    End Property

    Public Property EditingMode As Boolean Implements IEntryControl.EditingMode
        Get
            Return _editingMode
        End Get
        Set
            _editingMode = Value
            txtTime.EditingMode = Value
            txtDate.EditingMode = Value
            txtLongDate.EditingMode = Value
            If Value Then
                If DisplayOnly Then
                    ReadOnlyDp = True
                    ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
                    BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
                Else
                    ReadOnlyDp = False
                    ForeColor = GlobalVariables.DefaultFormControlForegroundColor
                    BackColor = GlobalVariables.DefaultFormControlBackgroundColor
                End If
            Else
                ReadOnlyDp = True
                ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
                BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
            End If
        End Set
    End Property

    Public ReadOnly Property Translatable As Boolean Implements IEntryControl.Translatable
        Get
            Return False
        End Get
    End Property

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    <Description("Set to True to specify that this control is mandatory.")>
    <Browsable(True)>
    Public Property ValueIsMandatory As Boolean
        Get
            Return _isMandatory
        End Get
        Set
            _isMandatory = Value
        End Set
    End Property

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    <Description("Security Key to use for this control.")>
    <Browsable(True)>
    Public Property SecurityKey As String
        Get
            Return _securityKey
        End Get
        Set
            _securityKey = Value
        End Set
    End Property

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Are null (nothing) dates allowed?")>
    <Browsable(True)>
    Public Property ValueIsNullable As Boolean
        Get
            Return _valueIsNullable
        End Get
        Set
            _valueIsNullable = Value
        End Set
    End Property

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    <Description("Set to True to specify that this control will show the Long date.")>
    <Browsable(True)>
    Public Property ShowLongDate As Boolean
        Get
            Return _showLongDate
        End Get
        Set(show As Boolean)
            _showLongDate = show
            SetupDisplayWidths()
        End Set
    End Property

    <Category("Custom Properties")>
    <Description("Select the label to which this control is linked.")>
    <Browsable(True)>
    Public Property LinkedLabel As CLabel

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    <Description("Set to True to specify that this control will show the Time.")>
    <Browsable(True)>
    Public Property ShowTime As Boolean
        Get
            Return _showTime
        End Get
        Set(show As Boolean)
            _showTime = show
            SetupDisplayWidths()
        End Set
    End Property

    Private Sub SetupDisplayWidths()
        'Dim padWidth As Integer = 0
        If ShowLongDate Then
            txtLongDate.Width = _longDateWidth
            txtLongDate.Visible = True
            txtLongDate.TabStop = True
            'padWidth = padWidth + 4
        Else
            txtLongDate.Width = 0
            txtLongDate.Visible = False
            txtLongDate.TabStop = False
            'padWidth = padWidth + 2
        End If
        If ShowTime Then
            'padWidth = padWidth + 4
            txtTime.TabStop = True
            txtTime.Width = _timeWidth
            txtTime.Visible = True
        Else
            'padWidth = padWidth + 2
            txtTime.TabStop = False
            txtTime.Width = 0
            txtTime.Visible = False
        End If
        Dim totalWidth As Integer = txtLongDate.Width + txtDate.Width + IIf(DisplayOnly, 0, dtp.Width) + txtTime.Width + IIf(DisplayOnly, 0, btnCalendarType.Width)
        Width = totalWidth
        floDatePicker.Width = totalWidth
    End Sub

    Public Property TargetCalendar As Calendar
        Get
            Return _targetCalendar
        End Get
        Set
            _targetCalendar = Value
        End Set
    End Property

    Public Overrides Property BackColor As Color
        Get
            Return txtDate.BackColor
        End Get
        Set
            txtDate.BackColor = Value
            txtTime.BackColor = Value
        End Set
    End Property

    Public Overrides Property Text As String
        Get
            If Value.HasValue Then
                If txtTime.Visible Then
                    Return CalendarDateToShortDateString(Value, _targetCulture) + " " + txtTime.Text
                Else
                    Return CalendarDateToShortDateString(Value, _targetCulture)
                End If
            Else
                Return Nothing
            End If
        End Get
        Set(myValue As String)
            Value = Convert.ToDateTime(myValue, _targetCulture)
        End Set
    End Property

    Public Property Value As DateTime?
        Get
            Dim retVal As DateTime?
            Try
                If txtDate.Text <> "" And txtDate.Text.TrimEnd() <> EmptyMask Then
                    If txtTime.Visible Then
                        retVal = Convert.ToDateTime(txtDate.Text + " " + txtTime.Text, _targetCulture)
                    Else
                        retVal = Convert.ToDateTime(txtDate.Text, _targetCulture)
                    End If
                Else
                    retVal = Nothing
                End If
            Catch ex As Exception
                retVal = Nothing
            End Try
            Return retVal
        End Get
        Set(dValue As DateTime?)
            Try
                If Not IsNothing(dValue) Then
                    If dValue Is Nothing Then
                        ''dtp.Value = Nothing
                    Else
                        txtDate.Text = PadWithZeroSingleDigitDate(CalendarDateToShortDateString(dValue, _targetCulture))
                        If txtTime.Visible Then
                            txtTime.Text = String.Format("{0:HH:mm:ss}", CType(dValue, DateTime).TimeOfDay.ToString)
                        Else
                            txtTime.Text = ""
                        End If
                        ''dtp.Value = dValue
                    End If
                Else
                    txtDate.Text = ""
                    txtTime.Text = ""
                    ''dtp.Value = dValue
                End If
                Refresh()
            Catch ex As Exception
                Beep()
                ''dtp.Value = dtp.MinDate
                txtDate.Text = Nothing
            End Try
        End Set
    End Property

    'Private Sub txtTime_GotFocus(sender As Object, e As EventArgs) Handles txtTime.GotFocus
    '    If txtDate.Text <> "" And txtDate.Text <> EmptyMask Then
    '        If txtTime.Text = "" OrElse txtTime.Text = "  :  :" Then
    '            txtTime.Text = "000000"
    '        End If
    '    End If
    '    txtTime.SelectionStart = 0
    '    txtTime.SelectionLength = 8
    'End Sub

    Private Sub TxtTime_Validating(sender As Object, e As CancelEventArgs) Handles txtTime.Validating
        If _
            (txtDate.Text = "" Or txtDate.Text.TrimEnd = EmptyMask) AndAlso
            (txtTime.Text = "  :  :" Or txtTime.Text = "") Then Exit Sub
        Dim sPattern = "([0-1]\d|2[0-3]):([0-5]\d)(:([0-5]\d))$"
        Dim match As New Regex(sPattern)
        Dim bIsMatch As Boolean = match.IsMatch(sender.text)
        If bIsMatch = False Then
            txtTime.SelectionStart = 0
            txtTime.SelectionLength = 8
            e.Cancel = True
        End If
    End Sub

    Private _txtDateAlreadyFocused As Boolean

    Private Sub TxtDate_OnGotFocus(sender As Object, e As EventArgs) Handles txtDate.GotFocus
        ' Select all text only if the mouse isn't down.
        ' This makes tabbing to the textbox give focus.
        _lastDate = Value
        txtDate.InsertKeyMode = InsertKeyMode.Overwrite
        'If MouseButtons = MouseButtons.None Then
        txtDate.SelectAll()
        _txtDateAlreadyFocused = True
        'End If
    End Sub

    Private Sub TxtDate_Leave(sender As Object, e As EventArgs) Handles txtDate.Leave
        _txtDateAlreadyFocused = False
        txtDate.InsertKeyMode = InsertKeyMode.Default
    End Sub

    Private Sub TxtDate_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDate.KeyDown
        ' The balloon tip is visible for five seconds; if the user types any data before it disappears, collapse it ourselves.
        ToolTip1.Hide(txtDate)
        'If e.KeyCode = Keys.Enter Then
        '    SendKeys.SendWait("{TAB}")
        '    e.Handled = True
        'End If
    End Sub

    Private Sub TxtDate_Validating(sender As Object, e As CancelEventArgs) Handles txtDate.Validating
        If txtDate.Text = "" OrElse txtDate.Text.TrimEnd() = EmptyMask Then Exit Sub
        If txtDate.Text.Length = MaxLength Then
            If IsDateValidForTargetCulture(txtDate.Text, _targetCulture) Then Exit Sub
            e.Cancel = True
        Else
            e.Cancel = True
        End If
        Beep()
        ToolTip1.ToolTipTitle = "Input Rejected"
        ToolTip1.Show(
            "You entry [" & txtDate.Text & "] is not a valid date for the " &
            CultureInfo.CurrentCulture.DateTimeFormat.NativeCalendarName() & ". Reverting to previous value!", txtDate, 0, 20, 5000)
        Dim dDate As DateTime? = _lastDate
        If dDate Is Nothing Then
            txtDate.Text = ""
        Else
            txtDate.Text = PadWithZeroSingleDigitDate(CalendarDateToShortDateString(_lastDate, _targetCulture))
        End If
        txtDate.Focus()
        e.Cancel = True
    End Sub

    Private Sub TxtDate_Validated(sender As Object, e As EventArgs) Handles txtDate.Validated
        If Not txtDate.ReadOnly Then
            If txtDate.Text = "" OrElse txtDate.Text.TrimEnd() = EmptyMask Then
                txtLongDate.Text = ""
                txtTime.Text = ""
                _programmaticChange = False
                Exit Sub
            End If
            Dim dDate As DateTime
            Dim sTime As String
            dDate = Convert.ToDateTime(txtDate.Text, _targetCulture)
            'Try
            '    'dtp.Value = dDate
            'Catch ex As Exception
            '    'dtp.Value = dtp.MinDate
            'End Try
            txtLongDate.Text = dDate.ToLongDateString
            sTime = dDate.TimeOfDay.ToString
            txtTime.Text = String.Format("{0:HH:mm:ss}", sTime)
        End If
    End Sub

    Private Sub TxtLongDate_Validating(sender As Object, e As CancelEventArgs) Handles txtLongDate.Validating
        Dim tDate As String = txtLongDate.Text
        Try
            If tDate.Trim() = "" Then
                txtTime.Text = ""
                txtDate.Text = ""
                Exit Sub
            End If
            txtDate.Text = PadWithZeroSingleDigitDate(DateTime.Parse(tDate).ToShortDateString())
            If IsDate(txtDate.Text) Then Exit Sub
            e.Cancel = True
        Catch
            MessageBox.Show("The Value you [" & tDate & "] entered is invalid. Reverting to previous value!")
            Dim dDate As DateTime = Value
            txtLongDate.Text = dDate.ToLongDateString
            txtLongDate.Focus()
            e.Cancel = True
        End Try
    End Sub

    Private Sub TxtLongDate_Validated(sender As Object, e As EventArgs) Handles txtLongDate.Validated
        If txtLongDate.Text.Trim = "" Then Exit Sub
        Dim tDate As String = txtLongDate.Text
        Dim curCulture = CultureInfo.CurrentCulture
        CultureInfo.CurrentCulture = _targetCulture
        txtDate.Text = PadWithZeroSingleDigitDate(DateTime.Parse(tDate).ToShortDateString)
        CultureInfo.CurrentCulture = curCulture
    End Sub

    Private Sub Dtp_Click(sender As Object, e As EventArgs) Handles dtp.Click
        Dim retVal As DialogResult
        Dim calendarForm = New CCalendar(Value, CalendarType) With {
                .RightToLeftLayout = GlobalVariables.RightToLeftLayout
                }
        Do While True

            SetCalendarLocation(calendarForm)
            retVal = calendarForm.ShowDialog()
            If ((Not EditingMode) Or DisplayOnly) And retVal <> DialogResult.Retry Then
                calendarForm.Dispose()
                Exit Do
            ElseIf retVal = DialogResult.OK Then
                txtDate.Text = PadWithZeroSingleDigitDate(calendarForm.ReturnedDateString)
                calendarForm.Dispose()
                Exit Do
            ElseIf retVal = DialogResult.Cancel Then
                calendarForm.Dispose()
                Exit Do
            ElseIf retVal = DialogResult.Retry Then
                Dim dNullableDate As DateTime?
                dNullableDate = Value
                ' need to save the value to a temporary variable
                ' because changing the CalendarType (in below code)
                ' clears the value of the current entered date stored in 'Value'
                Select Case calendarForm.cboCalendars.SelectedIndex
                    Case 1
                        TargetCalendar = New HijriCalendar
                        CalendarType = CalendarToUse.Hijri
                        If Not GlobalVariables.RightToLeftLayout Then
                            calendarForm.FixedLtrRtlLayout = True
                        End If
                    Case 2
                        TargetCalendar = New UmAlQuraCalendar
                        CalendarType = CalendarToUse.UmAlQura
                        If Not GlobalVariables.RightToLeftLayout Then
                            calendarForm.FixedLtrRtlLayout = True
                        End If
                    Case Else
                        TargetCalendar = New GregorianCalendar
                        CalendarType = CalendarToUse.Gregorian
                End Select
                ' restore previous Date value
                Value = dNullableDate
                SetTargetCulture()
                Refresh()
                calendarForm.Dispose()
                CultureInfo.CurrentCulture = _origCulture
                calendarForm = New CCalendar(Value, CalendarType)
            End If
        Loop
    End Sub

    Private Sub SetCalendarLocation(ByRef calendarForm As Form)
        Dim pnt As Point
        Dim formLocation As Point
        Dim screenRectangle As Rectangle
        Dim myForm = FindForm()
        screenRectangle = Screen.PrimaryScreen.WorkingArea
        calendarForm.StartPosition = FormStartPosition.Manual
        pnt = Parent.PointToScreen(Location)
        If GlobalVariables.RightToLeftLayout Then
            formLocation = New Point(pnt.X - calendarForm.Width - txtLongDate.Width - txtDate.Width,
                                     pnt.Y + dtp.Height)
            If formLocation.X < 0 Then
                formLocation.X = pnt.X - txtLongDate.Width - txtDate.Width
            End If
        Else
            formLocation = New Point(pnt.X + txtLongDate.Width + txtDate.Width, pnt.Y + dtp.Height)
            If formLocation.X + calendarForm.Width > screenRectangle.Width Then
                formLocation.X = pnt.X - calendarForm.Width + txtLongDate.Width + txtDate.Width
            End If
        End If
        If formLocation.Y + calendarForm.Height > screenRectangle.Height Then
            formLocation.Y = pnt.Y - calendarForm.Height
        End If
        calendarForm.Location = formLocation
    End Sub

    Public Property EditsAllowed As Boolean
        Get
            Return _editsAllowed
        End Get
        Set
            _editsAllowed = Value
        End Set
    End Property

    'Public Sub MakeEditable(editableControl As Boolean) Implements IEntryControl.MakeEditable
    '    EditsAllowed = Not editableControl
    'End Sub

    'Public Sub MakeVisible(visibleControl As Boolean) Implements IEntryControl.MakeVisible
    '    txtTime.MakeVisible(visibleControl)
    '    txtDate.MakeVisible(visibleControl)
    '    txtLongDate.MakeVisible(visibleControl)
    'End Sub

    Private Sub BtnCalendarType_Click(sender As Object, e As EventArgs) Handles btnCalendarType.Click
        ToggleTargetCulture()
    End Sub

    Private Sub OnValueChanged(sender As Object, e As EventArgs) Handles txtDate.TextChanged, txtTime.TextChanged, txtLongDate.TextChanged
        RaiseEvent ValueChanged(sender, e)
    End Sub

    Private Sub dtpReconciliationDate_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        txtDate.Enabled = Me.Enabled
        txtLongDate.Enabled = Me.Enabled
        txtTime.Enabled = Me.Enabled
    End Sub

    'Public Sub MakeViewable(ViewableControl As Boolean) Implements IEntryControl.MakeViewable
    '    ' not applicable
    'End Sub

    'Public Sub MakeSelectable(selectableControl As Boolean) Implements IEntryControl.MakeSelectable
    '    txtTime.MakeSelectable(selectableControl)
    '    txtDate.Enabled = selectableControl
    '    txtLongDate.MakeSelectable(selectableControl)
    'End Sub

    Public Sub Undo()
        Value = _lastDate
    End Sub

    Public Function DateChanged()
        If Value = _lastDate Then
            Return False
        End If
        Return True
    End Function

    Private Sub CCustomDateTimePicker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtDate.FieldName = Name.Substring(3)
        txtDate.DateField = True
    End Sub

    'Protected Sub ContextHandler(sender As Object, e As EventArgs)

    '    _contextMenuStrip1.Items.Clear()
    '    Dim menuItemFind As New ToolStripMenuItem With {
    '            .Text = TextFind
    '            }
    '    _contextMenuStrip1.Items.Add(menuItemFind)
    '    menuItemFind.ShortcutKeys = Keys.Control Or Keys.F
    '    ' ReSharper disable once LocalizableElement
    '    menuItemFind.ShortcutKeyDisplayString = "Ctrl-F"
    '    AddHandler menuItemFind.Click, AddressOf MenuItemFind_Click

    'End Sub

    'Private Sub MenuItemFind_Click()
    '    Dim myForm = FindForm()
    '    Dim pnt As Point
    '    Dim searchForm = New CFindForm(False)
    '    Dim screenRectangle As Rectangle
    '    Dim formLocation As Point
    '    screenRectangle = Screen.PrimaryScreen.WorkingArea
    '    searchForm.StartPosition = FormStartPosition.Manual
    '    pnt = myForm.PointToScreen(Location)
    '    If formLocation.Y + searchForm.Height > screenRectangle.Height Then
    '        formLocation.Y = pnt.Y - searchForm.Height + Height
    '    End If
    '    searchForm.Location = formLocation
    '    searchForm.ShowDialog()
    '    _textToSearch = searchForm.TextToSearch
    '    _searchPlace = Convert.ToBoolean(searchForm.GetSearchPlace)
    '    searchForm.Dispose()
    '    If _textToSearch <> "" Then

    '        CallByName(myForm, "FindField", CallType.Method, Me)

    '    End If
    'End Sub

End Class