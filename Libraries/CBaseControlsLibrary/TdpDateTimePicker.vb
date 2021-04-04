Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub

Public Class TdpDateTimePicker
    Private _DropDownClicked = False
    Public _EmptyMask As String
    Private OrigCulture As CultureInfo
    Private LTRCulture As CultureInfo
    Public MaxLength As Integer
    Private _ValueIsNull As Boolean
    Private _displayOnly As Boolean = False
    Private _ReadOnlyDP As Boolean = False
    Private _DefaultValue As Date? = Nothing
    Private _DtpDefaultValue As Date? = Nothing
    Private _IsMandatory As Boolean
    Private _TextToSearch As String
    Private _SearchAnywhere As Boolean
    Private _SecurityKey As String
    Private _MinimumDate As Date?
    Private LastDate As Date = Today()
    Private _OrigCultureStr As String
    Private _tmpValueChanged As Boolean = False
    Private _dtpDropCount As Integer = 0
    Private _programmaticChange As Boolean = False
    Private _DisplayDateInGregorian As Boolean

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Dim date1 = #6/20/2011#
        Dim curThreadCulture As CultureInfo = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name)
        Dim myOptCals As Calendar() = New CultureInfo(curThreadCulture.Name).OptionalCalendars
        Dim defCalendar As Calendar = myOptCals(0)
        curThreadCulture.DateTimeFormat.Calendar = defCalendar
        Thread.CurrentThread.CurrentCulture = curThreadCulture
        Dim DateMask As String
        Dim newDate As Date
        newDate = #2000-12-31#
        DateMask = Regex.Replace(newDate.ToShortDateString, "\d", "0")
        _EmptyMask = Regex.Replace(DateMask, "\d", " ").TrimEnd
        txtDate.Mask = DateMask
        txtDate.EmptyMask = _EmptyMask
        ShowLongDate = False
        ShowTime = False
        MaxLength = Len(DateMask)
        txtDate.MaxLength = MaxLength
    End Sub

    Private Sub DisplayCurrentInfo()
        MessageBox.Show("Current Culture: " & CultureInfo.CurrentCulture.Name)
        MessageBox.Show("Current Calendar: " & DateTimeFormatInfo.CurrentInfo.Calendar.ToString())
    End Sub

    Private Function CalendarExists(culture As CultureInfo,
                                    cal As Calendar) As Boolean
        For Each optionalCalendar As Calendar In culture.OptionalCalendars
            If cal.ToString().Equals(optionalCalendar.ToString()) Then Return True
        Next
        Return False
    End Function

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("If you want to display date in Gregorian Date in textbox set this Value to True? ")>
    <Browsable(True)>
    Public Property DisplayDateInGregorian As Boolean
        Get
            Return _DisplayDateInGregorian
        End Get
        Set
            _DisplayDateInGregorian = Value
        End Set
    End Property

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("The Default Value that this control will have if initialized Or cleared.")>
    <Browsable(True)>
    Public Property DefaultValue As Date?
        Get
            Return _DefaultValue
        End Get
        Set
            _DefaultValue = Value
            dtp.DefaultValue = Value
        End Set
    End Property

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("The Default Value that the datetimepicker control will show if value Is empty Or invalid date.")>
    <Browsable(True)>
    Public Property DtpDefaultValue As Date?
        Get
            Return _DtpDefaultValue
        End Get
        Set
            _DtpDefaultValue = Value
        End Set
    End Property

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to specify that this control Is read only.")>
    <Browsable(True)>
    Public Property DisplayOnly As Boolean
        Get
            Return _displayOnly
        End Get
        Set
            _displayOnly = Value
        End Set
    End Property

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to specify that this control Is read only.")>
    <Browsable(True)>
    Public Property ReadOnlyDP As Boolean
        Get
            Return _ReadOnlyDP
        End Get
        Set
            _ReadOnlyDP = Value
            txtDate.DisplayOnly = Value
        End Set
    End Property

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to specify that this control Is mandatory.")>
    <Browsable(True)>
    Public Property ValueIsMandatory As Boolean
        Get
            Return _IsMandatory
        End Get
        Set
            _IsMandatory = Value
        End Set
    End Property

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Security Key to use for this control.")>
    <Browsable(True)>
    Public Property SecurityKey As String
        Get
            Return _SecurityKey
        End Get
        Set
            _SecurityKey = Value
        End Set
    End Property

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to specify that this control will show the Long date.")>
    <Browsable(True)>
    Public Property ShowLongDate As Boolean
        Get
            Return txtLongDate.Visible
        End Get
        Set
            If Value = False Then
                txtLongDate.Visible = False
                txtDate.Left = 0
                dtp.Left = 66
                txtTime.Left = 86
                If txtTime.Visible Then
                    MinimumSize = New Size(150, 20)
                    MaximumSize = New Size(150, 20)
                    Width = 150
                Else
                    Width = 85
                    MinimumSize = New Size(85, 20)
                    MaximumSize = New Size(85, 20)
                End If
            Else
                If txtTime.Visible Then
                    MinimumSize = New Size(260, 20)
                    MaximumSize = New Size(260, 20)
                    Width = 260
                Else
                    Width = 205
                    MinimumSize = New Size(205, 20)
                    MaximumSize = New Size(205, 20)
                End If
                txtDate.Left = 111
                dtp.Left = 176
                txtTime.Left = 195
                txtLongDate.Visible = True
            End If
        End Set
    End Property

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to specify that this control will show the Time.")>
    <Browsable(True)>
    Public Property ShowTime As Boolean
        Get
            Return txtTime.Visible
        End Get
        Set
            Select Case txtLongDate.Visible
                Case True
                    If Value = False Then
                        txtTime.Visible = False
                        Width = 150
                        MinimumSize = New Size(150, 20)
                        MaximumSize = New Size(150, 20)
                    Else
                        txtTime.Visible = True
                        Width = 261
                        MinimumSize = New Size(260, 20)
                        MaximumSize = New Size(260, 20)
                    End If
                Case False
                    If Value = False Then
                        txtTime.Visible = False
                        Width = 85
                        MinimumSize = New Size(85, 20)
                        MaximumSize = New Size(85, 20)
                    Else
                        txtTime.Visible = True
                        Width = 150
                        MinimumSize = New Size(150, 20)
                        MaximumSize = New Size(150, 20)
                    End If
            End Select
            txtTime.TabStop = txtTime.Visible
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
                    Return ConvertToShortDateStr(Value) + " " + txtTime.Text
                Else
                    Return ConvertToShortDateStr(Value)
                End If
            Else
                Return Nothing
            End If
        End Get
        Set(MyValue As String)
            Try
                If MyValue Is Nothing OrElse MyValue = _EmptyMask Then
                    Value = Nothing
                Else
                    Value = ConvertShortDateStrToDate(MyValue)
                End If
            Catch ex As Exception
                Value = Nothing
            End Try
        End Set
    End Property

    Public Property Value As Date?
        Get
            Dim retVal As Date?
            Try
                If txtDate.Text <> "" And txtDate.Text.TrimEnd() <> _EmptyMask Then
                    If txtTime.Visible Then
                        retVal = ConvertShortDateStrToDate(txtDate.Text + " " + txtTime.Text)
                    Else
                        retVal = ConvertShortDateStrToDate(txtDate.Text)
                    End If
                Else
                    retVal = Nothing
                End If
            Catch ex As Exception
                retVal = Nothing
            End Try
            Return retVal
        End Get
        Set(dValue As Date?)
            Try
                If Not IsNothing(dValue) Then
                    If dValue Is Nothing Then
                        dtp.Value = Nothing
                    Else
                        Dim dDate As New Date
                        dDate = dValue
                        txtDate.Text = ConvertToShortDateStr(dDate)
                        If txtTime.Visible Then
                            txtTime.Text = String.Format("{0: HH:mm:ss}", CType(Value, Date).TimeOfDay.ToString)
                        End If
                        dtp.Value = dValue
                    End If
                Else
                    txtDate.Text = ""
                    txtTime.Text = ""
                    dtp.Value = dValue
                End If
                Refresh()
            Catch ex As Exception
                Beep()
                dtp.Value = dtp.MinDate
                txtDate.Text = Nothing
            End Try
        End Set
    End Property

    Private Sub txtTime_GotFocus(sender As Object, e As EventArgs) Handles txtTime.GotFocus
        If txtDate.Text <> "" And txtDate.Text <> _EmptyMask Then
            If txtTime.Text = "" OrElse txtTime.Text = "  :  :" Then
                txtTime.Text = "000000"
            End If
        End If
        txtTime.SelectionStart = 0
        txtTime.SelectionLength = 8
    End Sub

    Private Sub txtTime_Validating(sender As Object, e As CancelEventArgs) Handles txtTime.Validating
        If _
            (txtDate.Text = "" Or txtDate.Text.TrimEnd = _EmptyMask) AndAlso
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

    Private txtDateAlreadyFocused As Boolean

    Private Sub txtDate_OnGotFocus(sender As Object, e As EventArgs) Handles txtDate.GotFocus
        ' Select all text only if the mouse isn't down.
        ' This makes tabbing to the textbox give focus.
        txtDate.InsertKeyMode = InsertKeyMode.Overwrite
        If MouseButtons = MouseButtons.None Then
            txtDate.SelectAll()
            txtDateAlreadyFocused = True
        End If
    End Sub

    Private Sub txtDate_Leave(sender As Object, e As EventArgs) Handles txtDate.Leave
        txtDateAlreadyFocused = False
        txtDate.InsertKeyMode = InsertKeyMode.Default
    End Sub

    Private Sub txtDate_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDate.KeyDown
        ' The balloon tip is visible for five seconds; if the user types any data before it disappears, collapse it ourselves.
        ToolTip1.Hide(txtDate)
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub

    Private Sub txtDate_Validating(sender As Object, e As CancelEventArgs) Handles txtDate.Validating
        If txtDate.Text = "" OrElse txtDate.Text.TrimEnd() = _EmptyMask Then Exit Sub
        If txtDate.Text.Length = MaxLength Then
            If IsDateUsingOrigCulture(txtDate.Text) Then Exit Sub
            e.Cancel = True
        Else
            e.Cancel = True
        End If
        ToolTip1.ToolTipTitle = "Input Rejected"
        ToolTip1.Show("You entry [" & txtDate.Text & "] is not a valid date.  Reverting to previous value!", txtDate,
                      0, 20, 5000)
        Dim dDate As Date = dtp.Value
        txtDate.Text = ConvertToShortDateStr(dDate)
        txtDate.Focus()
        e.Cancel = True
    End Sub

    Private Sub txtDate_Validated(sender As Object, e As EventArgs) Handles txtDate.Validated, dtp.Enter
        If Not txtDate.ReadOnly Then
            If txtDate.Text = "" OrElse txtDate.Text.TrimEnd() = _EmptyMask Then
                txtLongDate.Text = ""
                txtTime.Text = ""
                _programmaticChange = True
                dtp.Value = dtp.MinDate
                _programmaticChange = False
                Exit Sub
            End If
            Dim dDate As Date
            Dim sTime As String
            dDate = ConvertShortDateStrToDate(txtDate.Text)
            Try
                dtp.Value = dDate
            Catch ex As Exception
                dtp.Value = dtp.MinDate
            End Try

            txtLongDate.Text = dDate.ToLongDateString
            sTime = dDate.TimeOfDay.ToString
            txtTime.Text = String.Format("{0:HH:mm:ss}", sTime)
        End If
    End Sub

    Private Function IsDateUsingOrigCulture(strDate As String) As Boolean
        Dim curCulture = CultureInfo.CurrentCulture
        Dim retVal As Boolean
        CultureInfo.CurrentCulture = GlobalVariables.OriginalCultureInfo
        If IsDate(strDate) Then
            retVal = True
        Else
            retVal = False
        End If
        CultureInfo.CurrentCulture = curCulture
        Return retVal
    End Function

    Private Sub txtLongDate_Validating(sender As Object, e As CancelEventArgs) Handles txtLongDate.Validating
        Dim tDate As String = txtLongDate.Text
        Try
            If tDate.Trim() = "" Then
                txtTime.Text = ""
                txtDate.Text = ""
                Exit Sub
            End If
            txtDate.Text = PadWithZeroSingleDigitDate(Date.Parse(tDate).ToShortDateString())
            If IsDate(txtDate.Text) Then Exit Sub
            e.Cancel = True
        Catch
            MessageBox.Show("The Value you [" & tDate & "] entered is invalid. Reverting to previous value!")
            Dim dDate As Date = dtp.Value
            txtLongDate.Text = dDate.ToLongDateString
            txtLongDate.Focus()
            e.Cancel = True
        End Try
    End Sub

    Private Sub txtLongDate_Validated(sender As Object, e As EventArgs) Handles txtLongDate.Validated
        If txtLongDate.Text.Trim = "" Then Exit Sub
        Dim tDate As String = txtLongDate.Text
        Dim curCulture = CultureInfo.CurrentCulture
        CultureInfo.CurrentCulture = GlobalVariables.OriginalCultureInfo
        txtDate.Text = PadWithZeroSingleDigitDate(Date.Parse(tDate).ToShortDateString)
        CultureInfo.CurrentCulture = curCulture
    End Sub

    Private Sub txtDate_MouseUp(sender As Object, e As MouseEventArgs) Handles txtDate.MouseUp
        ' Web browsers like Google Chrome select the text on mouse up.
        ' They only do it if the textbox isn't already focused,
        ' and if the user hasn't selected all text.
        txtDate.InsertKeyMode = InsertKeyMode.Overwrite
        If Not txtDateAlreadyFocused AndAlso txtDate.SelectionLength = 0 Then
            txtDateAlreadyFocused = True
            txtDate.SelectAll()
        End If
    End Sub

    Private Sub dtp_DropDown(sender As Object, e As EventArgs) Handles dtp.DropDown
        If dtp.ReadOnlyDp Then
            ' ignore entry
        Else
            If _dtpDropCount = 0 And (txtDate.Text = "" OrElse txtDate.Text.TrimEnd() = _EmptyMask) Then
                ' if empty date, the displayed datetimepicker calendar on dropdown will be the minimum date (since current value is empty)
                ' And when current value is empty the dtp.Value is equal to the dtp.mindate
                ' I want to change this behavior to display a Default Datetimepicker calendar assigned to the dtp.DefaultValue
                ' however you can't change the displayed calendar without changing the value of the datetimepicker.
                ' so to accomplish this i will temporary change the date value to the datetimepicker default date.
                ' and when the calendar picker closes, I will check if the user selected a date, if the user never selected a date
                ' revert the date to the original (empty value).
                _programmaticChange = True
                ' _programmaticChange will tell this control not to trigger the dtp.Value 'set' code
                'dtp.Value = ConvertShortDateStrToDate( Me.DtpDefaultValue)
                If DtpDefaultValue Is Nothing Then
                    dtp.Value = DateTime.Now()
                Else
                    dtp.Value = DtpDefaultValue
                End If

                _tmpValueChanged = False
                dtp.Select()
                _dtpDropCount += 1
                ' changing the value within the dropdown doesn't yet change the display calendar, so the need to programmatically
                ' trigger dropdown again using the next code so that in the next dropdown the calendar displayed is already updated.
                SendKeys.Send("%{DOWN}")
                dtp.Refresh()
                _programmaticChange = False
            Else
                If _dtpDropCount = 1 And (txtDate.Text = "" OrElse txtDate.Text.TrimEnd() = _EmptyMask) Then
                    ' if the control's current value is empty and I will be using the a default date for empty dates - see notes above
                    ' I found a problem with the program wherein if you selected the default date on the displayed calendar datetimepicker
                    ' (No problem for other dates other than the default date)
                    ' say if default date is 2018/12/31 and you clicked the datetimecalendar conrol with the same date say 2018/12/31
                    ' it will not trigger a dtp.ValueChanged event thus the date will revert to empty date.
                    ' To solve this problem, I need to change the dtp.Value again to the original value (minimum date for empty dates) so
                    ' any selected date will trigger the dtp.ValueChange event
                    _programmaticChange = True
                    dtp.Value = dtp.MinDate
                    _programmaticChange = False
                End If
                _dtpDropCount = 0
            End If
        End If
    End Sub

    Private Sub dtpDate_ValueChanged(sender As Object, e As EventArgs) Handles dtp.ValueChanged
        If dtp.ReadOnlyDp Then
            ' ignore entry
        ElseIf Not _programmaticChange Then
            Dim sTime As String = dtp.Value.TimeOfDay.ToString
            Dim curCulture As CultureInfo = Application.CurrentCulture
            txtDate.Text = ConvertToShortDateStr(dtp.Value)
            txtTime.Text = String.Format("{0:HH:mm:ss}", sTime)
            Refresh()
            txtTime.Focus()
            txtTime.SelectionStart = 0
            txtTime.SelectionLength = 8
            Try
                Dim dDate As Date
                dDate = ConvertShortDateStrToDate(txtDate.Text)
                txtLongDate.Text = dDate.ToLongDateString
            Catch ex As Exception
                Beep()
                MessageBox.Show("Invalid Date Entered!")
            End Try
            _tmpValueChanged = True
        End If
    End Sub

    Private Sub dtp_CloseUp(sender As Object, e As EventArgs) Handles dtp.CloseUp
        'MessageBox.Show(dtp.Value.ToShortDateString + " inside closeup")
        If dtp.ReadOnlyDp OrElse _dtpDropCount = 1 Then
            ' ignore entry if in edit mode or first drop when value is empty date
            ' dtp.Value = ConvertShortDateStrToDate(txtDate.Text)
        Else
            Refresh()
            If _tmpValueChanged Then
                '
            Else
                ' user did not change the value
                ' so revert to the old value (which is empty date)
                dtp.Value = ConvertShortDateStrToDate(dtp.MinDate)
                txtDate.Text = Nothing
            End If
        End If
    End Sub

    'Private Function PadWithZeroSingleDigitDate(ByVal shortDate As String) As String
    '    ' appends zero to single digit no. say 1/1/200 will be changed to 01/01/2000
    '    Dim newShortDate As String
    '    newShortDate = Regex.Replace(shortDate, "\b\d\b", "0$&")
    '    Return newShortDate
    'End Function

    Private Function ConvertToShortDateStr(dateValue As Date) As String
        'Dim curUICulture = CultureInfo.CurrentUICulture
        Dim retDateStr As String
        Try
            retDateStr = PadWithZeroSingleDigitDate(dateValue.ToShortDateString())
        Catch ex As Exception
            retDateStr = ""
        End Try
        Return retDateStr
    End Function

    Private Function ConvertShortDateStrToDate(dateValueStr As String) As Date?
        Dim retDate As Date?
        Try
            retDate = DateTime.Parse((dateValueStr))
        Catch ex As Exception
            If retDate Is Nothing Then
                _programmaticChange = True
                retDate = dtp.MinDate
                _programmaticChange = False
            Else
                retDate = Nothing
            End If
        End Try
        Return retDate
    End Function

End Class