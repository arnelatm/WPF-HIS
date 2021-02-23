Imports System.ComponentModel
Imports System.Globalization
Imports System.Threading
Imports AATM.Libraries.GlobalFuncNSub

Public Class CCalendar
    Private TargetCalendar As Calendar
    Private ReadOnly DaysOfWeek As Label() = New Label(6) {}
    Private Days As Label()
    Private _Day, _Month, _Year As Integer
    Private m_iPreviousDay, m_iPreviousMonth, m_iPreviousYear As Integer
    Private m_iDaysInMonth As Integer
    Private m_MAXIMUM_YEAR As Integer = 9999
    Private m_MINIMUM_YEAR As Integer = 1
    Private ReadOnly _initializing As Boolean = True
    Private _programmaticChange As Boolean = False
    Private strValue As String = ""
    Private ReadOnly passedDate As DateTime?
    Private originalCulture As CultureInfo
    Private targetCulture As CultureInfo = New CultureInfo(CultureInfo.CurrentCulture.Name)
    Private formCalendarType As CalendarToUse
    Private _todayCmdClicked As Boolean = False

    Public Sub New(dDate As DateTime?, calendarType As CalendarToUse)

        originalCulture = CultureInfo.CurrentCulture
        _initializing = True
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        passedDate = dDate
        SetCalendarType(calendarType)
        SetCalendarLabels()
        _initializing = False
    End Sub

    Private Sub SetCalendarType(CalendarType As CalendarToUse)
        Select Case CalendarType
            'Case CalendarToUse.Gregorian
            '    TargetCalendar = New Globalization.GregorianCalendar
            '    formCalendarType = CalendarToUse.Gregorian
            '    m_MAXIMUM_YEAR = 9999
            '    m_MINIMUM_YEAR = 1
            Case CalendarToUse.UmAlQura
                TargetCalendar = New UmAlQuraCalendar
                If Not CultureSupportUmAlQura(targetCulture) Then
                    targetCulture = CultureInfo.CreateSpecificCulture("ar-SA")
                    targetCulture.DateTimeFormat.ShortDatePattern = "dd/mm/yyyy"
                End If
                formCalendarType = CalendarToUse.UmAlQura
            Case CalendarToUse.Hijri
                TargetCalendar = New HijriCalendar
                If Not CultureSupportHijri(targetCulture) Then
                    targetCulture = CultureInfo.CreateSpecificCulture("ar-SA")
                    TargetCalendar = New HijriCalendar()
                    targetCulture.DateTimeFormat.ShortDatePattern = "dd/mm/yyyy"
                End If
                formCalendarType = CalendarToUse.Hijri
            Case Else
                TargetCalendar = New GregorianCalendar
                formCalendarType = CalendarToUse.Gregorian
        End Select
        targetCulture.DateTimeFormat.Calendar = TargetCalendar
        CultureInfo.CurrentCulture = targetCulture
        Dim dMaxDate = TargetCalendar.MaxSupportedDateTime
        Dim dMinDate = TargetCalendar.MinSupportedDateTime
        m_MAXIMUM_YEAR = TargetCalendar.GetYear(dMaxDate)
        m_MINIMUM_YEAR = TargetCalendar.GetYear(dMinDate)
        If originalCulture.TextInfo.IsRightToLeft Then
            Me.RightToLeftLayout = True
            Me.RightToLeft = RightToLeft.Yes
        Else
            Me.RightToLeftLayout = False
            Me.RightToLeft = RightToLeft.No
        End If
    End Sub

    Private Sub SetCalendarLabels()
        lblSunday.Text = originalCulture.DateTimeFormat.ShortestDayNames(0)
        lblMonday.Text = originalCulture.DateTimeFormat.ShortestDayNames(1)
        lblTuesday.Text = originalCulture.DateTimeFormat.ShortestDayNames(2)
        lblWednesday.Text = originalCulture.DateTimeFormat.ShortestDayNames(3)
        lblThursday.Text = originalCulture.DateTimeFormat.ShortestDayNames(4)
        lblFriday.Text = originalCulture.DateTimeFormat.ShortestDayNames(5)
        lblSaturday.Text = originalCulture.DateTimeFormat.ShortestDayNames(6)
        DaysOfWeek(0) = lblSunday
        DaysOfWeek(1) = lblMonday
        DaysOfWeek(2) = lblTuesday
        DaysOfWeek(3) = lblWednesday
        DaysOfWeek(4) = lblThursday
        DaysOfWeek(5) = lblFriday
        DaysOfWeek(6) = lblSaturday
    End Sub

    Private Sub CCalendar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.cboCalendars.Items.Add(CalendarToUse.Gregorian)
        Me.cboCalendars.Items.Add(CalendarToUse.Hijri)
        Me.cboCalendars.Items.Add(CalendarToUse.UmAlQura)
        _programmaticChange = True
        Me.cboCalendars.SelectedIndex = formCalendarType
        _programmaticChange = False
        LoadCalendar()
    End Sub

    Private Sub LoadCalendar()
        Dim HDate As String
        Dim dDate As DateTime

        If passedDate Is Nothing Then
            HDate = DateTime.Now.ToShortDateString()
            dDate = DateTime.Now()
        Else
            dDate = passedDate
            HDate = dDate.ToShortDateString()
        End If
        _Month = TargetCalendar.GetMonth(dDate)
        _Year = TargetCalendar.GetYear(dDate)
        _Day = TargetCalendar.GetDayOfMonth(dDate)

        For m = 1 To 12
            Me.cboMonths.Items.Add(GetMonthNameInCulture(m, targetCulture, originalCulture))
        Next

        _programmaticChange = True
        Me.cboMonths.SelectedIndex = _Month - 1
        Me.YearsEdit.Value = _Year
        Me.YearsEdit.Minimum = m_MINIMUM_YEAR
        Me.YearsEdit.Maximum = m_MAXIMUM_YEAR
        FormatToday()
        BuildDays(_Month, _Year, _Day)
        _programmaticChange = False
    End Sub

    Private Sub BuildDays(iMonth As Integer, iYear As Integer, Optional ByVal iDay As Integer = 1)
        'If _Year = m_iPreviousYear AndAlso _Month = m_iPreviousMonth Then
        '    If _Day <> m_iPreviousDay Then
        '        _programmaticChange = True
        '        SelectDay(Days(_Day - 1), Nothing)
        '        _programmaticChange = False
        '        m_iPreviousDay = _Day
        '    End If
        '    Return
        'End If
        If Days IsNot Nothing Then
            For i = 0 To Days.Count - 1 ' m_iDaysInMonth - 1
                Days(i).Dispose()
            Next
        End If
        Dim tempDate = New Date(iYear, iMonth, 1, TargetCalendar)
        Dim strFirstDay As String
        strFirstDay = tempDate.ToShortDateString()
        'Dim strMonth As String
        'strMonth = GetMonthName(iMonth, True)
        Dim iDayOfWeek As DayOfWeek = tempDate.DayOfWeek
        Dim rcSaturday As Rectangle = DaysOfWeek(6).Bounds
        rcSaturday.Offset(0, rcSaturday.Height)
        Dim rcDay As Rectangle = DaysOfWeek(CInt(iDayOfWeek)).Bounds
        rcDay.Inflate(-5, 0)
        rcDay.Offset(-1, rcSaturday.Height)
        Dim iRows = 0
        m_iDaysInMonth = TargetCalendar.GetDaysInMonth(iYear, iMonth)
        Days = New Label(m_iDaysInMonth - 1) {}
        Me.SuspendLayout()

        For i = 0 To m_iDaysInMonth - 1
            Days(i) = New Label()
            Days(i).Bounds = rcDay
            Days(i).Name = Convert.ToString(i + 1)
            Days(i).Text = Convert.ToString(i + 1)
            Days(i).Visible = True
            AddHandler Days(i).Click, New EventHandler(AddressOf Me.SelectDay)
            AddHandler Days(i).Paint, New PaintEventHandler(AddressOf Me.DayPaint)
            Days(i).TextAlign = ContentAlignment.MiddleCenter
            Days(i).Parent = Me

            If iDayOfWeek = DayOfWeek.Saturday Then
                iDayOfWeek = DayOfWeek.Sunday
                rcDay = rcSaturday
                rcDay.Width -= 10
                iRows += 1
                rcDay.Offset(-176, iRows * rcSaturday.Height)
            Else

                If iDayOfWeek = DayOfWeek.Saturday Then
                    iDayOfWeek = DayOfWeek.Sunday
                Else
                    iDayOfWeek += 1
                End If

                rcDay.Offset(rcSaturday.Width, 0)
            End If
        Next

        Me.ResumeLayout()
        m_iPreviousMonth = _Month
        m_iPreviousYear = _Year
        lblTodayMark.Size = Days(0).Size
        RaiseEvent DateChanged(Me, New EventArgs())
    End Sub

    Private Function IsSelectedDay(iDay As Integer, iMonth As Integer, iYear As Integer) As Boolean
        If iDay = _Day And iMonth = _Month And iYear = _Year Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function IsToday(iDay As Integer, iMonth As Integer, iYear As Integer) As Boolean
        Dim dToday As DateTime = DateTime.Now()
        Dim newDate = New Date(iYear, iMonth, iDay, TargetCalendar)
        If dToday.ToShortDateString() = newDate.ToShortDateString() Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub SelectDay(sender As Object, e As EventArgs)
        Try
            Dim Day = TryCast(sender, Label)
            _Day = Convert.ToInt32(Day.Name)

            For i = 0 To m_iDaysInMonth - 1
                Days(i).Invalidate()
            Next

            m_iPreviousDay = _Day
            RaiseEvent DateChanged(Me, New EventArgs())
            If Not _programmaticChange Then
                Me.DialogResult = DialogResult.OK
                Me.Hide()
            End If
        Catch exc As Exception
            Throw exc
        End Try
    End Sub

    Private Sub DayPaint(sender As Object, e As PaintEventArgs)
        Try
            Dim Day = TryCast(sender, Label)

            If IsToday(Convert.ToInt32(Day.Name), _Month, _Year) Then
                Dim RedPen = New Pen(Color.Red, 1)
                e.Graphics.DrawRectangle(RedPen, New Rectangle(0, 0, Day.Width - 1, Day.Height - 1))
            End If

            If IsSelectedDay(Convert.ToInt32(Day.Name), _Month, _Year) Then
                Day.BackColor = SystemColors.ActiveCaption
                Day.ForeColor = Color.White
            Else
                Day.BackColor = Color.White
                Day.ForeColor = SystemColors.ControlText
            End If
        Catch exc As Exception
            Throw exc
        End Try
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNextMonth.Click
        If _Month < 12 Then
            _Month += 1
        Else
            _Month = 1
            _Year += 1
        End If
        CreateCalendar()
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevMonth.Click
        If _Month > 1 Then
            _Month -= 1
        Else
            _Month = 12
            _Year -= 1
        End If
        CreateCalendar()
    End Sub

    Private Sub CreateCalendar()
        If _Year <= 0 Then
            _Year = 1
        End If
        Me.YearsEdit.Value = Math.Max(_Year, 1)
        Me.cboMonths.SelectedIndex = _Month - 1
        SetCalendarDay()
        BuildDays(_Month, _Year)
    End Sub

    Private Sub SetCalendarDay()
        Dim daysInThisMonth As Integer = TargetCalendar.GetDaysInMonth(_Year, _Month)
        If daysInThisMonth <= _Day Then
            _Day = daysInThisMonth
        Else
            If _todayCmdClicked Then
                ''
            Else
                Dim dPassedDate As Date
                If passedDate Is Nothing Then
                    dPassedDate = DateTime.Now()
                Else
                    dPassedDate = passedDate
                End If
                _Day = TargetCalendar.GetDayOfMonth(dPassedDate)
            End If
        End If
    End Sub

    Private Sub YearsEdit_ValueChanged(sender As Object, e As EventArgs) Handles YearsEdit.ValueChanged
        If (Not _initializing) Then
            If (Not _todayCmdClicked) Then
                _Year = CInt(YearsEdit.Value)
                SetCalendarDay()
                BuildDays(_Month, _Year)
            End If
        End If
    End Sub

    Private Sub FormatToday()
        Dim dToday As DateTime = DateTime.Now()
        lblToday.Tag = dToday.ToShortDateString()

        If Mid(originalCulture.Name.ToLower(), 1, 2) = "ar" Then
            lblToday.Text = " اليوم : " & dToday.ToString("dd MMM yyyy", targetCulture)
        Else
            If TypeOf targetCulture.Calendar Is HijriCalendar OrElse TypeOf targetCulture.Calendar Is UmAlQuraCalendar _
                Then
                lblToday.Text = " Today : " & dToday.ToString("dd ") &
                                GetMonthNameInCulture(targetCulture.Calendar.GetMonth(dToday), targetCulture,
                                                      originalCulture) & dToday.ToString(" yyyy")
            Else
                lblToday.Text = " Today : " & dToday.ToString("dd MMM yyyy", targetCulture)
            End If
        End If
    End Sub

    Private Sub lblTodayMark_Paint(sender As Object, e As PaintEventArgs) Handles lblTodayMark.Paint
        Dim Mark = TryCast(sender, Label)
        Dim RedPen = New Pen(Color.Red, 1)
        e.Graphics.DrawRectangle(RedPen, New Rectangle(0, 0, Mark.Width - 1, Mark.Height - 1))
    End Sub

    Public Delegate Sub DateChangedHandler(sender As Object, e As EventArgs)

    <Category("Action")>
    <Description("Fires when the date changed.")>
    Public Event DateChanged As DateChangedHandler

    <Category("Date")>
    <Description("Gets or sets days")>
    Public Property Day As Integer
        Get
            Return _Day
        End Get
        Set
            _Day = Value
            If Not _initializing Then
                BuildDays(_Month, _Year)
            End If
        End Set
    End Property

    <Category("Date")>
    <Description("Gets or sets months")>
    Public Property Month As Integer
        Get
            Return _Month
        End Get
        Set
            _Month = Value
            If Not _initializing Then
                SetCalendarDay()
                BuildDays(_Month, _Year)
            End If
        End Set
    End Property

    <Category("Date")>
    <Description("Gets or sets years")>
    Public Property Year As Integer
        Get
            Return _Year
        End Get
        Set
            _Year = Value
            If Not _initializing Then
                SetCalendarDay()
                BuildDays(_Month, _Year)
            End If
        End Set
    End Property

    <Category("Date")>
    <Description("Gets Days In Month")>
    Public ReadOnly Property DaysInMonth As Integer
        Get
            Return m_iDaysInMonth
        End Get
    End Property

    Private Sub lblToday_Click(sender As Object, e As EventArgs) Handles lblToday.Click
        Dim dToday As DateTime = DateTime.Now()
        _programmaticChange = True
        _todayCmdClicked = True
        _Day = TargetCalendar.GetDayOfMonth(dToday)
        _Month = TargetCalendar.GetMonth(dToday)
        _programmaticChange = False
        _Year = TargetCalendar.GetYear(dToday)
        Me.YearsEdit.Value = Me.Year
        Me.cboMonths.SelectedIndex = Me.Month - 1
        SetCalendarDay()
        BuildDays(_Month, _Year)
        RaiseEvent DateChanged(sender, e)
    End Sub

    Private Sub btnQuit_Click(sender As Object, e As EventArgs)
        Me.Hide()
    End Sub

    Private Sub gregDatePicker_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Me.Size = New Size(225, 225)
    End Sub

    Private Sub cboMonths_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMonths.SelectedIndexChanged
        _Month = cboMonths.SelectedIndex + 1
        If Not _initializing Then
            If Not _todayCmdClicked Then
                SetCalendarDay()
                BuildDays(_Month, _Year)
            End If
        End If
    End Sub

    Private Sub cboCalendars_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboCalendars.SelectedIndexChanged
        If Not _programmaticChange Then
            Me.DialogResult = DialogResult.Retry
            Me.Hide()
        End If
    End Sub

    Private Sub btnCalendarOk_Click(sender As Object, e As EventArgs) Handles btnCalendarOk.Click
        Me.Hide()
    End Sub

    Private Sub CCalendar_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Not Me.Visible Then
            CultureInfo.CurrentCulture = originalCulture
        End If
    End Sub

    Private Sub YearsEdit_Validating(sender As Object, e As CancelEventArgs) Handles YearsEdit.Validating
        If Me.YearsEdit.Value < m_MINIMUM_YEAR Then
            e.Cancel = True
        End If
        If Me.YearsEdit.Value > m_MAXIMUM_YEAR Then
            e.Cancel = True
        End If
    End Sub

    'Private Sub btnCalSwitch_Click(sender As Object, e As EventArgs)
    '    If formCalendarType = CalendarToUse.Gregorian Then
    '        SwitchCalendar(CalendarToUse.UmAlQura)
    '        btnCalSwitch.Text = "Um Al Qura"
    '    ElseIf formCalendarType = CalendarToUse.Hijri Then
    '        SwitchCalendar(CalendarToUse.Gregorian)
    '        btnCalSwitch.Text = "Gregorian"
    '    ElseIf formCalendarType = CalendarToUse.UmAlQura Then
    '        SwitchCalendar(CalendarToUse.Hijri)
    '        btnCalSwitch.Text = "Hijri"
    '    Else
    '        SwitchCalendar(CalendarToUse.Gregorian)
    '        btnCalSwitch.Text = "Gregorian"
    '    End If
    '    LoadCalendar()
    'End Sub

    Private Sub gregDatePicker_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        Me.Size = New Size(225, 225)
    End Sub

    Private Sub CCalendar_DateChanged(sender As Object, e As EventArgs) Handles Me.DateChanged
        Dim daysInMonths As Integer = TargetCalendar.GetDaysInMonth(Me.Year, Me.Month)
        Dim selectedDay As Integer
        If _todayCmdClicked Then
            _todayCmdClicked = False
            selectedDay = Me.Day
        Else
            If daysInMonths <= Me.Day Then
                selectedDay = daysInMonths
            Else
                selectedDay = Me.Day
            End If
        End If

        Me.strValue = New Date(Me.Year, Me.Month, selectedDay, TargetCalendar).ToShortDateString()
    End Sub

    <Category("Date")>
    <Description("return a date")>
    Public Property ReturnedDateString As String
        Get
            Dim retDateStr As String
            If strValue Is Nothing OrElse strValue = "" Then
                retDateStr = Nothing
            Else
                Dim dDate As Date?
                Try
                    dDate = Convert.ToDateTime(strValue, targetCulture)
                Catch ex As Exception
                    dDate = Nothing
                End Try
                If dDate Is Nothing Then
                    retDateStr = Nothing
                Else
                    Dim newDate As DateTime = dDate
                    retDateStr = PadWithZeroSingleDigitDate(CalendarDateToShortDateString(newDate, targetCulture))
                End If
            End If
            Return retDateStr
        End Get
        Set
            'passedDateStr = value
        End Set
    End Property

    'Private Function GetMonthName(ByVal iMonth As Integer, Optional ByVal ShowMonthNumber As Boolean = False) As String
    '    Return CultureInfo.CurrentCulture.DateTimeFormat.MonthGenitiveNames(iMonth - 1)
    'End Function
End Class