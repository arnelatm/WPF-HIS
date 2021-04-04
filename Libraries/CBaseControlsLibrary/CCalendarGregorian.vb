Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms

Public Class CCalendarGregorian
    Private ReadOnly TargetCalendar As GregorianCalendar = New GregorianCalendar()
    Private ReadOnly DaysOfWeek As Label() = New Label(6) {}
    Private Days As Label()
    Private _Day, _Month, _Year As Integer
    Private m_iPreviousDay, m_iPreviousMonth, m_iPreviousYear As Integer
    Private m_iDaysInMonth As Integer
    Private Const MAXIMUM_YEAR As Integer = 9999
    Private Const MINIMUM_YEAR As Integer = 1
    Private ReadOnly _initializing As Boolean = True
    Private _programmaticChange As Boolean = False
    Private strValue As String = ""
    Private ReadOnly passedDate As DateTime?
    Private ReadOnly currentCulture As CultureInfo = CultureInfo.CurrentCulture
    Private ReadOnly targetCulture As CultureInfo = New CultureInfo(CultureInfo.CurrentCulture.Name)

    Public Sub New(dDate As DateTime?)
        _initializing = True
        InitializeComponent()
        _initializing = False
        passedDate = dDate
        targetCulture.DateTimeFormat.Calendar = TargetCalendar
        CultureInfo.CurrentCulture = targetCulture
        If CultureInfo.CurrentCulture.TextInfo.IsRightToLeft Then
            RightToLeftLayout = True
            RightToLeft = RightToLeft.Yes
            'TargetCalendar.CalendarType = GregorianCalendarTypes.TransliteratedEnglish
        Else
            RightToLeftLayout = False
            RightToLeft = RightToLeft.No
        End If

        SetCalendarLabels()
    End Sub

    Private Sub SetCalendarLabels()
        lblSunday.Text = CultureInfo.CurrentCulture.DateTimeFormat.DayNames(0)
        lblMonday.Text = CultureInfo.CurrentCulture.DateTimeFormat.DayNames(1)
        lblTuesday.Text = CultureInfo.CurrentCulture.DateTimeFormat.DayNames(2)
        lblWednesday.Text = CultureInfo.CurrentCulture.DateTimeFormat.DayNames(3)
        lblThursday.Text = CultureInfo.CurrentCulture.DateTimeFormat.DayNames(4)
        lblFriday.Text = CultureInfo.CurrentCulture.DateTimeFormat.DayNames(5)
        lblSaturday.Text = CultureInfo.CurrentCulture.DateTimeFormat.DayNames(6)
        DaysOfWeek(0) = lblSunday
        DaysOfWeek(1) = lblMonday
        DaysOfWeek(2) = lblTuesday
        DaysOfWeek(3) = lblWednesday
        DaysOfWeek(4) = lblThursday
        DaysOfWeek(5) = lblFriday
        DaysOfWeek(6) = lblSaturday
    End Sub

    Private Sub DatePicker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            cboMonths.Items.Add(CultureInfo.CurrentCulture.DateTimeFormat.MonthGenitiveNames(m - 1))
        Next
        cboMonths.SelectedIndex = _Month - 1
        YearsEdit.Value = _Year

        FormatToday()
        BuildDays(_Month, _Year, _Day)
    End Sub

    Private Sub BuildDays(iMonth As Integer, iYear As Integer, Optional ByVal iDay As Integer = 1)
        If _Year = m_iPreviousYear AndAlso _Month = m_iPreviousMonth Then
            If _Day <> m_iPreviousDay Then
                _programmaticChange = True
                SelectDay(Days(_Day - 1), Nothing)
                _programmaticChange = False
                m_iPreviousDay = _Day
            End If
            Return
        End If
        If Days IsNot Nothing Then
            For i = 0 To m_iDaysInMonth - 1
                Days(i).Dispose()
            Next
        End If
        Dim tempDate = New Date(iYear, iMonth, 1, TargetCalendar)
        Dim strFirstDay As String
        strFirstDay = tempDate.ToShortDateString()
        Dim strMonth As String
        strMonth = GetMonthName(iMonth, True)
        Dim iDayOfWeek As DayOfWeek = tempDate.DayOfWeek
        Dim rcSaturday As Rectangle = DaysOfWeek(6).Bounds
        rcSaturday.Offset(0, rcSaturday.Height)
        Dim rcDay As Rectangle = DaysOfWeek(CInt(iDayOfWeek)).Bounds
        rcDay.Inflate(-5, 0)
        rcDay.Offset(-1, rcSaturday.Height)
        Dim iRows = 0
        m_iDaysInMonth = TargetCalendar.GetDaysInMonth(iYear, iMonth)
        Days = New Label(m_iDaysInMonth - 1) {}
        SuspendLayout()

        For i = 0 To m_iDaysInMonth - 1
            Days(i) = New Label()
            Days(i).Bounds = rcDay
            Days(i).Name = Convert.ToString(i + 1)
            Days(i).Text = Convert.ToString(i + 1)
            Days(i).Visible = True
            AddHandler Days(i).Click, New EventHandler(AddressOf SelectDay)
            AddHandler Days(i).Paint, New PaintEventHandler(AddressOf DayPaint)
            Days(i).TextAlign = ContentAlignment.MiddleCenter
            Days(i).Parent = Me

            If iDayOfWeek = DayOfWeek.Saturday Then
                iDayOfWeek = DayOfWeek.Sunday
                rcDay = rcSaturday
                rcDay.Width -= 10
                iRows += 1
                rcDay.Offset(-177, iRows * rcSaturday.Height)
            Else

                If iDayOfWeek = DayOfWeek.Saturday Then
                    iDayOfWeek = DayOfWeek.Sunday
                Else
                    iDayOfWeek += 1
                End If

                rcDay.Offset(rcSaturday.Width, 0)
            End If
        Next

        ResumeLayout()
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
        If dToday = New Date(iYear, iMonth, iDay, TargetCalendar) Then
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
                DialogResult = DialogResult.OK
                CultureInfo.CurrentCulture = currentCulture
                Hide()
            End If
        Catch exc As Exception
            Throw exc
        End Try
    End Sub

    Private Sub DayPaint(sender As Object, e As PaintEventArgs)
        Try
            Dim day = TryCast(sender, Label)

            If IsToday(Convert.ToInt32(day.Name), _Month, _Year) Then
                Dim redPen = New Pen(Color.Red, 1)
                e.Graphics.DrawRectangle(redPen, New Rectangle(0, 0, day.Width - 1, day.Height - 1))
            End If

            If IsSelectedDay(Convert.ToInt32(day.Name), _Month, _Year) Then
                day.BackColor = SystemColors.ActiveCaption
                day.ForeColor = Color.White
            Else
                day.BackColor = Color.White
                day.ForeColor = SystemColors.ControlText
            End If
        Catch exc As Exception
            Throw exc
        End Try
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNextMonth.Click
        Try
            If _Month < 12 Then
                _Month += 1
            Else
                _Month = 1
                _Year += 1
            End If
            YearsEdit.Value = _Year
            cboMonths.SelectedIndex = _Month - 1

            Dim newMonth = New Date(_Year, _Month, 1, TargetCalendar)
            Dim daysInThisMonth As Integer = DateTime.DaysInMonth(_Year, _Month)
            If daysInThisMonth < _Day Then
                _Day = daysInThisMonth
            Else
                Dim dayOfPassedDate As Date = passedDate
                _Day = dayOfPassedDate.Day()
            End If

            BuildDays(_Month, _Year)
        Catch exc As Exception
            Throw exc
        End Try
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevMonth.Click
        Try

            If _Month > 1 Then
                _Month -= 1
            Else
                _Month = 12
                _Year -= 1
            End If
            YearsEdit.Value = _Year
            cboMonths.SelectedIndex = _Month - 1
            Dim newMonth = New Date(_Year, _Month, 1, TargetCalendar)
            Dim daysInThisMonth As Integer = DateTime.DaysInMonth(_Year, _Month)
            If daysInThisMonth < _Day Then
                _Day = daysInThisMonth
            Else
                Dim dayOfPassedDate As Date = passedDate
                _Day = dayOfPassedDate.Day()
            End If
            BuildDays(_Month, _Year)
        Catch exc As Exception

            Throw exc
        End Try
    End Sub

    Private Sub YearsEdit_ValueChanged(sender As Object, e As EventArgs) Handles YearsEdit.ValueChanged
        If Not _initializing Then
            _Year = CInt(YearsEdit.Value)
            BuildDays(_Month, _Year)
        End If
    End Sub

    Private Sub FormatToday()
        Dim dToday As DateTime = DateTime.Now()
        lblToday.Tag = dToday.ToShortDateString()
        If CultureInfo.CurrentCulture.Name.ToLower().Remove(2) = "ar" Then
            lblToday.Text = " اليوم : " & dToday.ToString("dd MMM yyyy", targetCulture)
        Else
            lblToday.Text = " Today : " & dToday.ToString("dd MMM yyyy", targetCulture)
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
            BuildDays(_Month, _Year)
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
            BuildDays(_Month, _Year)
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
            BuildDays(_Month, _Year)
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
        Day = dToday.Day()
        Month = dToday.Month()
        Year = dToday.Year()
        YearsEdit.Value = dToday.Year()
        cboMonths.SelectedIndex = dToday.Month() - 1
        RaiseEvent DateChanged(sender, e)
    End Sub

    Private Sub btnQuit_Click(sender As Object, e As EventArgs)
        CultureInfo.CurrentCulture = currentCulture
        Hide()
    End Sub

    Private Sub gregDatePicker_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Size = New Size(225, 225)
    End Sub

    Private Sub cboMonths_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMonths.SelectedIndexChanged
        _Month = cboMonths.SelectedIndex + 1
        BuildDays(_Month, _Year)
    End Sub

    Private Sub btnCalendarCancel_Click(sender As Object, e As EventArgs) Handles btnCalendarCancel.Click
        CultureInfo.CurrentCulture = currentCulture
        Hide()
    End Sub

    Private Sub btnCalendarOk_Click(sender As Object, e As EventArgs) Handles btnCalendarOk.Click
        CultureInfo.CurrentCulture = currentCulture
        Hide()
    End Sub

    Private Sub gregDatePicker_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        Size = New Size(225, 225)
    End Sub

    Private Sub gregDate_DateChanged(sender As Object, e As EventArgs) Handles Me.DateChanged
        Dim daysInMonths As Integer = DateTime.DaysInMonth(Year, Month)
        Dim selectedDay As Integer
        If daysInMonths <= Day Then
            selectedDay = daysInMonths
        Else
            'Dim tempDate As DateTime = passedDate
            selectedDay = Day
        End If

        strValue = New Date(Year, Month, selectedDay, TargetCalendar).ToShortDateString()
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
                    retDateStr = newDate.ToString(targetCulture)
                End If
            End If
            Return retDateStr
        End Get
        Set
            '
        End Set
    End Property

    Private Function GetMonthName(iMonth As Integer, Optional ByVal ShowMonthNumber As Boolean = False) As String
        Return CultureInfo.CurrentCulture.DateTimeFormat.MonthGenitiveNames(iMonth - 1)
    End Function

End Class