Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub

Public Class CDtpGregorianDate
    Private _DropDownClicked = False
    Public _EmptyMask As String
    Private OrigCulture As CultureInfo
    Private LTRCulture As CultureInfo
    Public MaxLength As Integer
    Private _ValueIsNullable As Boolean
    Private _displayOnly As Boolean = False
    Private _ReadOnlyDP As Boolean = False
    Private _DefaultValue As Date? = Nothing
    Private _DtpDefaultValue As Date? = Nothing
    Private _IsMandatory As Boolean
    Private _TextToSearch As String
    Private _SearchAnywhere As Boolean
    Private _SecurityKey As String
    Private _MinimumDate As Date?
    Private LastDate As Date? = Today()
    Private _OrigCultureStr As String
    Private _tmpValueChanged As Boolean = False
    Private _dtpDropCount As Integer = 0
    Private _programmaticChange As Boolean = False
    Private _initialized As Boolean = False
    Private curCulture As CultureInfo
    Private _cultureInfoDisplayName As String = ""
    Private _TargetCultureName As String = ""
    Private TargetCulture As CultureInfo
    Private _targetCalendar As GregorianCalendar = New GregorianCalendar()

    Public Sub New()
        _initialized = False
        ' This call is required by the designer.
        InitializeComponent()
        _initialized = True
        dtp.Refresh()
        SetCultureDisplay()
    End Sub

    Public Sub SetCultureDisplay()
        Dim DateMask As String
        Dim newDate As Date
        curCulture = Application.CurrentCulture
        newDate = #2018-12-31#
        TargetCulture = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name)
        TargetCulture.DateTimeFormat.Calendar = TargetCalendar
        DateMask = Regex.Replace(CalendarDateToShortDateString(newDate, TargetCulture), "\d", "0")
        _EmptyMask = Regex.Replace(DateMask, "\d", " ").TrimEnd
        txtDate.Mask = DateMask
        txtDate.EmptyMask = _EmptyMask
        ShowLongDate = False
        ShowTime = False
        MaxLength = Len(DateMask)
        txtDate.MaxLength = MaxLength
        CultureInfo.CurrentCulture = curCulture
    End Sub

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    <Description("The Default Value that this control will have if initialized or cleared.")>
    <Browsable(True)>
    Public Property DefaultValue As Date?
        Get
            Return _DefaultValue
        End Get
        Set
            _DefaultValue = Value
        End Set
    End Property

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    <Description("The Default Value that the datetimepicker control will show if value is empty or invalid date.")>
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
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    <Description("Set to True to specify that this control is read only.")>
    <Browsable(True)>
    Public Property DisplayOnly As Boolean
        Get
            Return _displayOnly
        End Get
        Set
            _displayOnly = Value
        End Set
    End Property

    '<Bindable(True)>
    '<Category("Properties")>
    '<DefaultValue(GetType(Boolean))>
    '<Description("Set to True to specify that this control is read only.")>
    '<Browsable(True)>
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
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    <Description("Set to True to specify that this control is mandatory.")>
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
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
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
    <Description("Are null (nothing) dates allowed?")>
    <Browsable(True)>
    Public Property ValueIsNullable As Boolean
        Get
            Return _ValueIsNullable
        End Get
        Set
            _ValueIsNullable = Value
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
            Return txtLongDate.Visible
        End Get
        Set
            If Value = False Then
                txtLongDate.Width = 0
                txtLongDate.Visible = False
                If txtTime.Visible Then
                    MinimumSize = New Size(150, 20)
                    MaximumSize = New Size(150, 20)
                    Width = 150
                    CFlowLayout1.Width = 150
                Else
                    Width = 85
                    MinimumSize = New Size(85, 20)
                    MaximumSize = New Size(85, 20)
                    CFlowLayout1.Width = 85
                End If
            Else
                txtLongDate.Width = 110
                txtLongDate.Visible = True
                If txtTime.Visible Then
                    MinimumSize = New Size(260, 20)
                    MaximumSize = New Size(260, 20)
                    Width = 260
                    CFlowLayout1.Width = 260
                Else
                    Width = 205
                    MinimumSize = New Size(205, 20)
                    MaximumSize = New Size(205, 20)
                    CFlowLayout1.Width = 205
                End If
            End If
        End Set
    End Property

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    <Description("Set to True to specify that this control will show the Time.")>
    <Browsable(True)>
    Public Property ShowTime As Boolean
        Get
            Return txtTime.Visible
        End Get
        Set
            Select Case txtLongDate.Visible
                Case True
                    txtTime.Width = 65
                    If Value = False Then
                        txtTime.Visible = False
                        Width = 150
                        MinimumSize = New Size(150, 20)
                        MaximumSize = New Size(150, 20)
                        CFlowLayout1.Width = 150
                    Else
                        txtTime.Visible = True
                        Width = 261
                        MinimumSize = New Size(260, 20)
                        MaximumSize = New Size(260, 20)
                        CFlowLayout1.Width = 261
                    End If
                Case False
                    txtTime.Width = 0
                    If Value = False Then
                        txtTime.Visible = False
                        Width = 85
                        MinimumSize = New Size(85, 20)
                        MaximumSize = New Size(85, 20)
                        CFlowLayout1.Width = 85
                    Else
                        txtTime.Visible = True
                        Width = 150
                        MinimumSize = New Size(150, 20)
                        MaximumSize = New Size(150, 20)
                        CFlowLayout1.Width = 150
                    End If
            End Select
            txtTime.TabStop = txtTime.Visible
        End Set
    End Property

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
                    Return CalendarDateToShortDateString(Value, TargetCulture) + " " + txtTime.Text
                Else
                    Return CalendarDateToShortDateString(Value, TargetCulture)
                End If
            Else
                Return Nothing
            End If
        End Get
        Set(MyValue As String)
            Value = Convert.ToDateTime(MyValue, TargetCulture)
        End Set
    End Property

    Public Property Value As DateTime?
        Get
            Dim retVal As DateTime?
            Try
                If txtDate.Text <> "" And txtDate.Text.TrimEnd() <> _EmptyMask Then
                    If txtTime.Visible Then
                        retVal = Convert.ToDateTime(txtDate.Text + " " + txtTime.Text, TargetCulture)
                    Else
                        retVal = Convert.ToDateTime(txtDate.Text, TargetCulture)
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
                        Dim dDate As New Date
                        dDate = dValue
                        txtDate.Text = PadWithZeroSingleDigitDate(CalendarDateToShortDateString(dValue, TargetCulture))
                        If txtTime.Visible Then
                            txtTime.Text = String.Format("{0:HH:mm:ss}", CType(Value, Date).TimeOfDay.ToString)
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
        LastDate = Value
        txtDate.InsertKeyMode = InsertKeyMode.Overwrite
        'If MouseButtons = MouseButtons.None Then
        txtDate.SelectAll()
        txtDateAlreadyFocused = True
        'End If
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
            If IsDateUsingCultureDisplay(txtDate.Text) Then Exit Sub
            e.Cancel = True
        Else
            e.Cancel = True
        End If
        Beep()
        ToolTip1.ToolTipTitle = "Input Rejected"
        ToolTip1.Show("You entry [" & txtDate.Text & "] is not a valid date.  Reverting to previous value!", txtDate,
                      0, 20, 5000)
        Dim dDate As Date? = LastDate
        If dDate Is Nothing Then
            txtDate.Text = ""
        Else
            txtDate.Text = PadWithZeroSingleDigitDate(CalendarDateToShortDateString(LastDate, TargetCulture))
        End If
        txtDate.Focus()
        e.Cancel = True
    End Sub

    Private Sub txtDate_Validated(sender As Object, e As EventArgs) Handles txtDate.Validated
        If Not txtDate.ReadOnly Then
            If txtDate.Text = "" OrElse txtDate.Text.TrimEnd() = _EmptyMask Then
                txtLongDate.Text = ""
                txtTime.Text = ""
                _programmaticChange = True
                'Me.'dtp.Value = Me.dtp.MinDate
                _programmaticChange = False
                Exit Sub
            End If
            Dim dDate As Date
            Dim sTime As String
            dDate = Convert.ToDateTime(txtDate.Text, TargetCulture)
            Try
                'dtp.Value = dDate
            Catch ex As Exception
                'dtp.Value = dtp.MinDate
            End Try
            txtLongDate.Text = dDate.ToLongDateString
            sTime = dDate.TimeOfDay.ToString
            txtTime.Text = String.Format("{0:HH:mm:ss}", sTime)
        End If
    End Sub

    Private Function IsDateUsingCultureDisplay(strDate As String) As Boolean
        Dim curCulture = CultureInfo.CurrentCulture
        Dim retVal As Boolean
        CultureInfo.CurrentCulture = TargetCulture
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
            Dim dDate As Date = Value
            txtLongDate.Text = dDate.ToLongDateString
            txtLongDate.Focus()
            e.Cancel = True
        End Try
    End Sub

    Private Sub txtLongDate_Validated(sender As Object, e As EventArgs) Handles txtLongDate.Validated
        If txtLongDate.Text.Trim = "" Then Exit Sub
        Dim tDate As String = txtLongDate.Text
        Dim curCulture = CultureInfo.CurrentCulture
        CultureInfo.CurrentCulture = TargetCulture
        txtDate.Text = PadWithZeroSingleDigitDate(Date.Parse(tDate).ToShortDateString)
        CultureInfo.CurrentCulture = curCulture
    End Sub

    Private Sub dtp_Click(sender As Object, e As EventArgs) Handles dtp.Click
        Dim CalendarForm = New CCalendarGregorian(Value)
        CalendarForm.RightToLeftLayout = GlobalVariables.RightToLeftLayout
        SetCalendarLocation(CalendarForm)
        Dim retVal = CalendarForm.ShowDialog()
        If (Not ReadOnlyDP) And retVal = DialogResult.OK Then
            txtDate.Text = PadWithZeroSingleDigitDate(CalendarForm.ReturnedDateString)
        End If
        CalendarForm.Dispose()
    End Sub

    Private Sub SetCalendarLocation(ByRef CalendarForm As Form)
        Dim pnt As Point
        Dim formLocation As Point
        Dim screenRectangle As Rectangle
        Dim myForm = FindForm()
        screenRectangle = Screen.PrimaryScreen.WorkingArea
        CalendarForm.StartPosition = FormStartPosition.Manual
        pnt = myForm.PointToScreen(Location)
        Dim myParent As Point = Parent.Location
        If GlobalVariables.RightToLeftLayout Then
            formLocation = New Point(pnt.X - CalendarForm.Width - txtLongDate.Width - txtDate.Width,
                                     pnt.Y + dtp.Height)
            If formLocation.X < 0 Then
                formLocation.X = pnt.X - txtLongDate.Width - txtDate.Width
            End If
        Else
            formLocation = New Point(pnt.X + txtLongDate.Width + txtDate.Width, pnt.Y + dtp.Height)
            If formLocation.X + CalendarForm.Width > screenRectangle.Width Then
                formLocation.X = pnt.X - CalendarForm.Width + txtLongDate.Width + txtDate.Width
            End If
        End If
        If formLocation.Y + CalendarForm.Height > screenRectangle.Height Then
            formLocation.Y = pnt.Y - CalendarForm.Height
        End If
        CalendarForm.Location = formLocation
    End Sub

End Class