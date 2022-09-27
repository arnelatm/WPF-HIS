Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.GlobalResources
Imports AATM.Libraries.MessagingLibrary

Public Class CCustomDateTimePicker
    Implements IEntryControl, ILinkedLabel

    Private _dropDownClicked = False
    Public EmptyMask As String
    Private _value As DateTime?
    Private ReadOnly _origCulture As CultureInfo
    Private _ltrCulture As CultureInfo
    Public MaxLength As Integer
    Private _displayOnly As Boolean = False
    Private _translatable As Boolean = False
    Private _readOnlyDp As Boolean = False
    Private _isMandatory As Boolean
    Private _textToSearch As String
    Private _searchPlace As Char
    Private _minimumDate As DateTime?
    Private _lastDate As DateTime? = Today()
    Private _origCultureStr As String
    Private _tmpValueChanged As Boolean = False
    Private _dtpDropCount As Integer = 0
    Private _initialized As Boolean = False
    Private _curCulture As CultureInfo
    Private _cultureInfoDisplayName As String = ""
    Private _targetCultureName As String = ""
    Private _targetCulture As CultureInfo
    Private _calendarType As GlobalSubs.CalendarToUse = CalendarToUse.Gregorian
    Private _longDateWidth As Integer = 110
    Private _dateWidth As Integer = 76
    Private _totalWidth As Integer = 0
    Private _buttonWidth As Integer = 21
    Private _btnCalendarTypeWidth As Integer = 15
    Private _timeWidth As Integer = 76
    Private _showTime As Boolean = False
    Private _showLongDate As Boolean = False
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
        txtDate.DateTimePickerParent = Me
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

    Private _calendarCulture As CultureInfo

    Public Property CalendarCulture As CultureInfo
        Get
            Dim cCalendarCulture As CultureInfo
            Select Case btnCalendarType.Text
                Case Strings.HijriCalendarMarker
                    cCalendarCulture = CultureInfo.CreateSpecificCulture("ar-SA")
                Case Strings.UmAlQuraCalendarMarker
                    cCalendarCulture = CultureInfo.CreateSpecificCulture("ar-SA")
                Case Else
                    cCalendarCulture = CultureInfo.CreateSpecificCulture("en-GB")
            End Select
            Return cCalendarCulture
        End Get
        Set(tValue As CultureInfo)
            _calendarCulture = tValue
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

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    <Description("The Default Value that the datetimepicker control will show if value is empty or invalid date.")>
    <Browsable(True)>
    Public Property DtpDefaultValue As DateTime?

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
            ReadOnlyDp = Value
            If _displayOnly Then
                dtp.Visible = False
            Else
                dtp.Visible = True
            End If
            If ShowTime Then
                txtTime.Visible = True
                txtTime.Width = _timeWidth
            Else
                txtTime.Visible = False
                txtTime.Width = 0
            End If
            If ShowLongDate Then
                txtLongDate.Visible = True
                txtDate.Visible = False
            Else
                txtLongDate.Visible = False
                txtDate.Visible = True
            End If
        End Set
    End Property

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to specify that this control is read only.")>
    <Browsable(True)>
    Public Property ReadOnlyDp As Boolean
        Get
            Return _readOnlyDp
        End Get
        Set
            _readOnlyDp = Value
            txtDate.DisplayOnly = Value
            txtLongDate.DisplayOnly = Value
            txtTime.txbTime.DisplayOnly = Value
            Refresh()

        End Set
    End Property

    Public Property EditingMode As Boolean Implements IEntryControl.EditingMode
        Get
            Return _editingMode
        End Get
        Set
            _editingMode = Value
            'txtTime.EditingMode = Value
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

    Public Property Translatable As Boolean Implements IEntryControl.Translatable
        Get
            Return False
        End Get
        Set(tValue As Boolean)
            _translatable = tValue
        End Set
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

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Are null (nothing) dates allowed?")>
    <Browsable(True)>
    Public Property ValueIsNullable As Boolean

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
    Public Property LinkedLabel As CLabel Implements ILinkedLabel.LinkedLabel

    Public Function GetControlDescription(Optional defaultDescription As String = Nothing) Implements ILinkedLabel.GetControlDescription
        Dim description As String
        If LinkedLabel Is Nothing OrElse LinkedLabel.Text Is Nothing OrElse LinkedLabel.Text = "" Then
            description = If(defaultDescription Is Nothing OrElse defaultDescription = "", Name, defaultDescription)
        Else
            description = LinkedLabel.Text
        End If
        Return description
    End Function

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
        If ShowLongDate Then
            txtLongDate.Width = _longDateWidth
            txtLongDate.Visible = True
            txtLongDate.TabStop = True
        Else
            txtLongDate.Width = 0
            txtLongDate.Visible = False
            txtLongDate.TabStop = False
        End If
        If ShowTime Then
            txtTime.TabStop = True
            txtTime.Width = _timeWidth
            txtTime.Visible = True
            txtTime.Width = _timeWidth
            If Value IsNot Nothing Then
                txtTime.Text = String.Format("{0:HH:mm}", Value)
            End If
        Else
            txtTime.TabStop = False
            txtTime.Width = 0
            txtTime.Visible = False
        End If
        Dim totalWidth As Integer = 7 + If(ShowLongDate, _longDateWidth, 0) + txtDate.Width + IIf(DisplayOnly, 0, dtp.Width) + If(ShowTime, _timeWidth, 0) + btnCalendarType.Width
        Width = totalWidth
        floDatePicker.Width = totalWidth
    End Sub

    Public Property TargetCalendar As Calendar

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
            If _value.HasValue Then
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
            _value = Convert.ToDateTime(myValue, _targetCulture)
        End Set
    End Property

    Public Property Value As DateTime?
        Get
            Dim retVal As DateTime?
            Try
                If Not ShowLongDate Then
                    If txtDate.Text Is Nothing OrElse txtDate.Text = "" OrElse txtDate.Text.TrimEnd() = EmptyMask Then
                        txtTime.Text = ""
                        txtLongDate.Text = ""
                        retVal = Nothing
                    Else
                        Dim cText As String
                        cText = PadWithZeroSingleDigitDate(DateTime.Parse(txtDate.Text).ToShortDateString())
                        If ShowTime Then
                            cText += " " + txtTime.GetMilitaryTime()
                        End If
                        retVal = Convert.ToDateTime(cText, _targetCulture)
                    End If
                Else
                    Dim cText As String
                    If txtLongDate.Text Is Nothing OrElse txtLongDate.Text.Trim() = "" Then
                        txtTime.Text = ""
                        txtDate.Text = ""
                        retVal = Nothing
                    ElseIf ShowTime Then
                        cText = PadWithZeroSingleDigitDate(DateTime.Parse(txtLongDate.Text).ToShortDateString()) + " " + txtTime.GetMilitaryTime()
                        retVal = Convert.ToDateTime(cText, _targetCulture)
                    Else
                        retVal = Convert.ToDateTime(PadWithZeroSingleDigitDate(DateTime.Parse(txtLongDate.Text).ToShortDateString()), _targetCulture)
                    End If
                End If
            Catch ex As Exception
                retVal = Nothing
            End Try
            Return retVal
        End Get

        Set(dValue As DateTime?)
            If Not IsNothing(dValue) Then
                txtDate.Text = PadWithZeroSingleDigitDate(CalendarDateToShortDateString(dValue, _targetCulture))
                Dim cTime As String = String.Format("{0:HH:mm}", dValue)
                txtTime.SetTime(cTime)
                If cTime < "12:00" Then
                    txtTime.Text = IIf(cTime.Substring(0, 2) = "00", "12" + cTime.Substring(2), cTime)
                Else
                    Dim cPmTime = (Int(cTime.Substring(0, 2)) - 12).ToString().PadLeft(2, "0") + cTime.Substring(2)
                    txtTime.Text = IIf(cPmTime.Substring(0, 2) = "00", "12" + cPmTime.Substring(2), cPmTime)
                End If
            Else
                txtDate.Text = ""
                txtTime.Text = ""
                txtLongDate.Text = ""
            End If
            _value = dValue
        End Set
    End Property

    Public Sub InformUserOfInvalidDate()
        ToolTip1.ToolTipTitle = "Input Rejected"
        Dim calendarName As String = Messaging.TranslateCaption(CalendarNameInEnglish(_targetCulture))
        Dim cText = txtDate.Text
        Dim cCalendarName As String = calendarName
        ToolTip1.ToolTipTitle = "Input Rejected"
        Messaging.ShowPmMessage(True, "MsgErroneousDate", {"enteredDate", cText, "calendarName", cCalendarName})
    End Sub

    Private Sub InformUserOfInvalidTime()
        ToolTip1.ToolTipTitle = "Input Rejected"
        Messaging.Show(True, "MsgErroneousTime")
    End Sub

    Public Function CalendarNameInEnglish(targetCulture As CultureInfo)
        Dim calendarName As String = ""
        If targetCulture.DateTimeFormat.NativeCalendarName = "تقويم ام القرى" Then
            calendarName = $"Umm al-Qura Calendar"
        ElseIf targetCulture.DateTimeFormat.NativeCalendarName = "التقويم الهجري" Then
            calendarName = $"Hijri Calendar"
        Else
            calendarName = targetCulture.DateTimeFormat.NativeCalendarName
        End If
        Return calendarName
    End Function

    Public Function GetTime()
        Return txtTime.Text
    End Function

    Public Sub SetCurrentTime(cTime As String)
        txtTime.SetTime(cTime)
    End Sub

    Private Sub OnDtp_Enter(sender As Object, e As EventArgs) Handles MyBase.Enter
        If txtDate.Text Is Nothing OrElse txtDate.Text = "" OrElse txtDate.Text.TrimEnd() = EmptyMask Then
            _lastDate = Nothing
        Else
            Dim dDate As DateTime?
            If txtTime.Visible Then
                Dim cText As String = txtDate.Text + " " + txtTime.GetMilitaryTime()
                Try
                    dDate = Convert.ToDateTime(cText, _targetCulture)
                    _lastDate = dDate
                Catch ex As Exception
                    ' do not assign
                End Try
            Else
                Try
                    dDate = Convert.ToDateTime(txtDate.Text, _targetCulture)
                    _lastDate = dDate
                Catch ex As Exception
                    ' don't assign invalid values use the last value
                End Try
            End If
        End If
        txtDate.SetPosition()
    End Sub

    Public Sub CDtpPicker_Validating(sender As Object, e As CancelEventArgs) Handles txtDate.Validating, txtLongDate.Validating, txtTime.Validating
        If Not ShowLongDate Then
            If txtDate.Text Is Nothing OrElse txtDate.Text = EmptyMask OrElse txtDate.Text = "" Then
                If ShowTime Then
                    txtTime.Text = Nothing
                End If
            Else
                Dim cText As String = txtDate.Text
                Try
                    Dim dDateTime = Convert.ToDateTime(cText, _targetCulture)
                    If ShowTime Then
                        If Not IsValidTime(txtTime.Text) Then
                            e.Cancel = True
                            Exit Sub
                        End If
                    End If
                Catch ex As Exception
                    e.Cancel = True
                    InformUserOfInvalidDate()
                    Exit Sub
                End Try
            End If
        Else
            If txtLongDate.Text Is Nothing OrElse txtLongDate.Text = "" Then
                If ShowTime Then
                    txtTime.Text = ""
                    txtDate.Text = ""
                End If
                e.Cancel = False
            Else
                Dim cText As String = txtLongDate.Text
                Try
                    Dim dDateTime = Convert.ToDateTime(cText, _targetCulture)
                    If ShowTime Then
                        If Not IsValidTime(cText) Then
                            e.Cancel = True
                            Exit Sub
                        End If
                    End If
                Catch ex As Exception
                    e.Cancel = True
                    InformUserOfInvalidDate()
                    Exit Sub
                End Try
            End If
        End If
        e.Cancel = False
    End Sub

    Public Function IsValidTime(cText As String) As Boolean
        Dim retVal As Boolean = True
        If Not (cText = $"  :  :" Or cText = "") Then
            Dim sPattern = "([0-1]\d|2[0-3]):([0-5]\d)(:([0-5]\d))$"
            Dim match As New Regex(sPattern)
            Dim bIsMatch As Boolean = match.IsMatch(cText)
            If bIsMatch = False Then
                InformUserOfInvalidTime()
                retVal = False
            End If
        End If
        Return retVal
    End Function

    Private Sub OnDtp_Validated(sender As Object, e As EventArgs) Handles txtDate.Validated, txtLongDate.Validated, txtTime.Validated
        If Not ShowLongDate Then
            If Not txtDate.ReadOnly Then
                If txtDate.Text Is Nothing OrElse txtDate.Text = "" OrElse txtDate.Text.TrimEnd() = EmptyMask Then
                    txtLongDate.Text = ""
                    txtTime.Text = ""
                Else
                    txtDate.Text = PadWithZeroSingleDigitDate(DateTime.Parse(txtDate.Text).ToShortDateString())
                End If
            End If
        Else
            Dim tDate As String = txtLongDate.Text
            If tDate Is Nothing OrElse tDate.Trim() = "" Then
                txtTime.Text = ""
                txtDate.Text = ""
            End If
        End If

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

    Private Sub BtnCalendarType_Click(sender As Object, e As EventArgs) Handles btnCalendarType.Click
        ToggleTargetCulture()
    End Sub

    Protected Overridable Sub OnValueChanged(sender As Object, e As EventArgs) Handles txtLongDate.TextChanged, txtDate.TextChanged
        RaiseEvent ValueChanged(sender, e)
    End Sub

    Private Sub dtpReconciliationDate_EnabledChanged(sender As Object, e As EventArgs) Handles MyBase.EnabledChanged
        txtDate.Enabled = Me.Enabled
        txtLongDate.Enabled = Me.Enabled
        txtTime.Enabled = Me.Enabled
    End Sub

    Public Sub Undo()
        Value = _lastDate
    End Sub

    Private Sub CCustomDateTimePicker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtDate.FieldName = Name.Substring(3)
        txtDate.DateField = True
    End Sub

    Private Sub CCustomDateTimePicker_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDate.KeyDown, txtLongDate.KeyDown, txtTime.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        ElseIf e.Control AndAlso e.KeyCode = Keys.Z Then
            e.Handled = True
            Value = _lastDate
        End If
    End Sub

End Class