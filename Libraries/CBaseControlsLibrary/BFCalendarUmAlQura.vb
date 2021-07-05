Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.Text
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub

Public Class BfCalendarUmAlQura
    Private ReadOnly HijriDate As HijriDates = New HijriDates()
    Private ReadOnly Cal As UmAlQuraCalendar = New UmAlQuraCalendar()
    Private ReadOnly Cul As CultureInfo = New CultureInfo("ar-SA")

    Private ReadOnly _
        allFormats As String() =
            {"yyyy/MM/dd", "yyyy/M/d", "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "yyyy-MM-dd", "yyyy-M-d",
             "dd-MM-yyyy", "d-M-yyyy", "dd-M-yyyy", "d-MM-yyyy", "yyyy MM dd", "yyyy M d", "dd MM yyyy", "d M yyyy",
             "dd M yyyy", "d MM yyyy"}

    Private ReadOnly DaysOfWeek As Label() = New Label(6) {}
    Private Days As Label()
    Private m_iDay, m_iMonth, m_iYear As Integer
    Private m_iPreviousDay, m_iPreviousMonth, m_iPreviousYear As Integer
    Private m_iDaysInMonth As Integer
    Private Const MAXIMUM_YEAR As Integer = 1800
    Private Const MINIMUM_YEAR As Integer = 1200
    Private ReadOnly _initializing As Boolean = True
    Private _programmaticChange As Boolean = False
    Private strValue As String = ""
    Private passedDateStr As String
    Private ReadOnly curDate As DateTime?

    Public Sub New()
        _initializing = True
        Dim CurCul = CultureInfo.CurrentCulture
        InitializeComponent()
        _initializing = False
        Cul.DateTimeFormat.Calendar = Cal
        lblSunday.Text = CurCul.DateTimeFormat.DayNames(0)
        lblMonday.Text = CurCul.DateTimeFormat.DayNames(1)
        lblTuesday.Text = CurCul.DateTimeFormat.DayNames(2)
        lblWednesday.Text = CurCul.DateTimeFormat.DayNames(3)
        lblThursday.Text = CurCul.DateTimeFormat.DayNames(4)
        lblFriday.Text = CurCul.DateTimeFormat.DayNames(5)
        lblSaturday.Text = CurCul.DateTimeFormat.DayNames(6)
        DaysOfWeek(0) = lblSunday
        DaysOfWeek(1) = lblMonday
        DaysOfWeek(2) = lblTuesday
        DaysOfWeek(3) = lblWednesday
        DaysOfWeek(4) = lblThursday
        DaysOfWeek(5) = lblFriday
        DaysOfWeek(6) = lblSaturday
    End Sub

    Public Sub New(dDate As DateTime?)
        _initializing = True
        InitializeComponent()
        _initializing = False
        curDate = dDate
        Dim CurCul = CultureInfo.CurrentCulture
        If CultureInfo.CurrentCulture.TextInfo.IsRightToLeft Then
            RightToLeftLayout = True
            RightToLeft = RightToLeft.Yes
        Else
            RightToLeftLayout = False
            RightToLeft = RightToLeft.No
        End If
        Cul.DateTimeFormat.Calendar = Cal
        lblSunday.Text = CurCul.DateTimeFormat.DayNames(0)
        lblMonday.Text = CurCul.DateTimeFormat.DayNames(1)
        lblTuesday.Text = CurCul.DateTimeFormat.DayNames(2)
        lblWednesday.Text = CurCul.DateTimeFormat.DayNames(3)
        lblThursday.Text = CurCul.DateTimeFormat.DayNames(4)
        lblFriday.Text = CurCul.DateTimeFormat.DayNames(5)
        lblSaturday.Text = CurCul.DateTimeFormat.DayNames(6)
        DaysOfWeek(0) = lblSunday
        DaysOfWeek(1) = lblMonday
        DaysOfWeek(2) = lblTuesday
        DaysOfWeek(3) = lblWednesday
        DaysOfWeek(4) = lblThursday
        DaysOfWeek(5) = lblFriday
        DaysOfWeek(6) = lblSaturday
        Dim cMenu = ""
        Dim i = 0
        For Each menuItem As ToolStripMenuItem In MenuMonths.Items()
            Dim cMenuName As String = "ToolStripMenuItem" & i.ToString().Trim()
            i += 1
            'CallByName(menuItem, "Text", CallType.Set, GetMonthName(i, True))
            LateBinding.SetProperty(menuItem, "Text", {GetMonthName(i, True)})
        Next
    End Sub

    Private Sub HijriDatePicker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim HDate As String
        If curDate Is Nothing Then
            HDate = DateTime.Now.ToString("dd/MM/yyyy", Cul.DateTimeFormat)
        Else
            Dim dDate As DateTime
            dDate = curDate
            HDate = dDate.ToString("dd/MM/yyyy", Cul.DateTimeFormat)
        End If

        m_iMonth = Convert.ToInt32(HDate.Substring(3, 2))
        m_iYear = Convert.ToInt32(HDate.Substring(6, 4))
        m_iDay = Convert.ToInt32(HDate.Substring(0, 2))
        If m_iDay = 30 And HijriDate.Is29(m_iMonth, m_iYear) Then
            m_iDay = 1
            m_iMonth += 1
            If m_iMonth = 13 Then
                m_iMonth = 1
                m_iYear += 1
            End If
        End If
        'm_iDay = Convert.ToInt32(HDate.Substring(0, 2))
        'm_iMonth = Convert.ToInt32(HDate.Substring(3, 2))
        'm_iYear = Convert.ToInt32(HDate.Substring(6, 4))
        FormatToday()
        BuildDays(m_iMonth, m_iYear)
    End Sub

    Private Sub BuildDays(iMonth As Integer, iYear As Integer)
        If m_iYear = m_iPreviousYear AndAlso m_iMonth = m_iPreviousMonth Then

            If m_iDay <> m_iPreviousDay Then
                _programmaticChange = True
                SelectDay(Days(m_iDay - 1), Nothing)
                _programmaticChange = False
                m_iPreviousDay = m_iDay
            End If

            Return
        End If
        SuspendLayout()
        If Days IsNot Nothing Then

            For i = 0 To m_iDaysInMonth - 1
                Days(i).Dispose()
            Next
        End If

        Dim HFirstDay = New StringBuilder()
        HFirstDay.AppendFormat("1/{0}/{1}", iMonth, iYear)
        Dim tempDate As DateTime = DateTime.ParseExact(HFirstDay.ToString(), allFormats, Cul.DateTimeFormat,
                                                       DateTimeStyles.AllowWhiteSpaces)
        Dim strMonth As String  '= HijriDate.FormatHijri(HFirstDay.ToString(), "MMM")
        strMonth = GetMonthName(iMonth, True)
        lblMonth.Text = strMonth
        lblYear.Text = Convert.ToString(iYear)
        Dim iDayOfWeek As DayOfWeek = tempDate.DayOfWeek
        Dim rcSaturday As Rectangle = DaysOfWeek(6).Bounds
        rcSaturday.Offset(0, rcSaturday.Height)
        Dim rcDay As Rectangle = DaysOfWeek(CInt(iDayOfWeek)).Bounds
        rcDay.Inflate(-5, 0)
        rcDay.Offset(-1, rcSaturday.Height)
        Dim iRows = 0
        m_iDaysInMonth = If(HijriDate.Is29(iMonth, iYear) = 1, 29, 30)
        Days = New Label(m_iDaysInMonth - 1) {}

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
        m_iPreviousMonth = m_iMonth
        m_iPreviousYear = m_iYear
        lblTodayMark.Size = Days(0).Size
        RaiseEvent DateChanged(Me, New EventArgs())
        ResumeLayout()
    End Sub

    Private Function IsSelectedDay(iDay As Integer, iMonth As Integer, iYear As Integer) As Boolean
        Try
            Dim HCurrentDate = New StringBuilder()
            Dim HSelected = New StringBuilder()
            HCurrentDate.AppendFormat("{0}/{1}/{2}", iDay, iMonth, iYear)
            HSelected.AppendFormat("{0}/{1}/{2}", m_iDay, m_iMonth, m_iYear)
            Return If(HijriDate.Compare(HCurrentDate.ToString(), HSelected.ToString()) = 0, True, False)
        Catch e As Exception
            Throw e
        End Try
    End Function

    Private Function IsToday(iDay As Integer, iMonth As Integer, iYear As Integer) As Boolean
        Try
            Dim HCurrentDate = New StringBuilder()
            Dim HToday As String = HijriDate.HDateNow("dd/MM/yyyy")
            HCurrentDate.AppendFormat("{0}/{1}/{2}", iDay, iMonth, iYear)
            Return If(HijriDate.Compare(HCurrentDate.ToString(), HToday) = 0, True, False)
        Catch e As Exception
            Throw e
        End Try
    End Function

    Private Sub SelectDay(sender As Object, e As EventArgs)
        Try
            HideYearEdit()
            Dim Day = TryCast(sender, Label)
            m_iDay = Convert.ToInt32(Day.Name)

            For i = 0 To m_iDaysInMonth - 1
                Days(i).Invalidate()
            Next

            m_iPreviousDay = m_iDay
            RaiseEvent DateChanged(Me, New EventArgs())
            If Not _programmaticChange Then
                Hide()
            End If
        Catch exc As Exception
            Throw exc
        End Try
    End Sub

    Private Sub DayPaint(sender As Object, e As PaintEventArgs)
        Try
            Dim Day = TryCast(sender, Label)

            If IsToday(Convert.ToInt32(Day.Name), m_iMonth, m_iYear) Then
                Dim RedPen = New Pen(Color.Red, 1)
                e.Graphics.DrawRectangle(RedPen, New Rectangle(0, 0, Day.Width - 1, Day.Height - 1))
            End If

            If IsSelectedDay(Convert.ToInt32(Day.Name), m_iMonth, m_iYear) Then
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

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Try
            HideYearEdit()

            If m_iMonth < 12 Then
                m_iMonth += 1
            Else
                m_iMonth = 1
                m_iYear += 1
            End If

            BuildDays(m_iMonth, m_iYear)
        Catch exc As Exception
            Throw exc
        End Try
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        Try
            HideYearEdit()

            If m_iMonth > 1 Then
                m_iMonth -= 1
            Else
                m_iMonth = 12
                m_iYear -= 1
            End If

            BuildDays(m_iMonth, m_iYear)
        Catch exc As Exception
            Throw exc
        End Try
    End Sub

    Private Sub YearsEdit_Leave(sender As Object, e As EventArgs)
        YearsEdit.Visible = False
        YearsEdit.SendToBack()
    End Sub

    Private Sub YearsEdit_ValueChanged(sender As Object, e As EventArgs) Handles YearsEdit.ValueChanged
        If Not _initializing Then
            m_iYear = CInt(YearsEdit.Value)
            BuildDays(m_iMonth, m_iYear)
        End If
    End Sub

    Private Sub YearsEdit_Validated(sender As Object, e As EventArgs)
        HideYearEdit()
    End Sub

    Private Sub HijriDatePicker_Click(sender As Object, e As EventArgs)
        HideYearEdit()
    End Sub

    Private Sub HideYearEdit()
        If YearsEdit.Visible = True Then
            YearsEdit.Visible = False
            YearsEdit.SendToBack()
        End If
    End Sub

    Private Sub FormatToday()
        Dim HToday As String = HijriDate.HDateNow("dd/MM/yyyy")
        If CultureInfo.CurrentCulture.Name.ToLower().Remove(2) = "ar" Then
            lblToday.Text = HijriDate.FormatHijri(HToday, " اليوم : dd MMM  yyyy")
        Else
            'Dim monthString As String = HijriDate.FormatHijri(HToday, "ddMMyyyy")
            lblToday.Text = " Today : " & HijriDate.FormatHijri(HToday, "dd") & " " &
                            HijriMonthInEnglish(Int(HijriDate.FormatHijri(HToday, "MM"))) & " " &
                            HijriDate.FormatHijri(HToday, "yyyy")
        End If
        lblToday.Tag = HijriDate.FormatHijri(HToday, "dd/MM/yyyy")
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        m_iMonth = 1
        ToolStripMenuItem1.Text = GetMonthName(m_iMonth, True)
        BuildDays(m_iMonth, m_iYear)
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        m_iMonth = 2
        ToolStripMenuItem2.Text = GetMonthName(m_iMonth, True)
        BuildDays(m_iMonth, m_iYear)
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        m_iMonth = 3
        ToolStripMenuItem3.Text = GetMonthName(m_iMonth, True)
        BuildDays(m_iMonth, m_iYear)
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        m_iMonth = 4
        ToolStripMenuItem4.Text = GetMonthName(m_iMonth, True)
        BuildDays(m_iMonth, m_iYear)
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        m_iMonth = 5
        ToolStripMenuItem5.Text = GetMonthName(m_iMonth, True)
        BuildDays(m_iMonth, m_iYear)
    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
        m_iMonth = 6
        ToolStripMenuItem6.Text = GetMonthName(m_iMonth, True)
        BuildDays(m_iMonth, m_iYear)
    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem7.Click
        m_iMonth = 7
        ToolStripMenuItem7.Text = GetMonthName(m_iMonth, True)
        BuildDays(m_iMonth, m_iYear)
    End Sub

    Private Sub ToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem8.Click
        m_iMonth = 8
        ToolStripMenuItem8.Text = GetMonthName(m_iMonth, True)
        BuildDays(m_iMonth, m_iYear)
    End Sub

    Private Sub ToolStripMenuItem9_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem9.Click
        m_iMonth = 9
        ToolStripMenuItem9.Text = GetMonthName(m_iMonth, True)
        BuildDays(m_iMonth, m_iYear)
    End Sub

    Private Sub ToolStripMenuItem10_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem10.Click
        m_iMonth = 10
        ToolStripMenuItem10.Text = GetMonthName(m_iMonth, True)
        BuildDays(m_iMonth, m_iYear)
    End Sub

    Private Sub ToolStripMenuItem11_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem11.Click
        m_iMonth = 11
        ToolStripMenuItem11.Text = GetMonthName(m_iMonth, True)
        BuildDays(m_iMonth, m_iYear)
    End Sub

    Private Sub ToolStripMenuItem12_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem12.Click
        m_iMonth = 12
        ToolStripMenuItem12.Text = GetMonthName(m_iMonth, True)
        BuildDays(m_iMonth, m_iYear)
    End Sub

    Private Sub lblYear_Click(sender As Object, e As EventArgs) Handles lblYear.Click
        YearsEdit.Value = m_iYear
        YearsEdit.Visible = True
        YearsEdit.BringToFront()
    End Sub

    Private Sub lblMonth_Click(sender As Object, e As EventArgs) Handles lblMonth.Click
        HideYearEdit()
        Dim rcMenu As Rectangle = MenuMonths.Bounds
        Dim Pos As Point = lblMonth.PointToScreen(New Point(lblMonth.Width / 2 - (rcMenu.Width / 2),
                                                            lblMonth.Height / 2 - (rcMenu.Height / 2)))
        MenuMonths.Show(Pos)
    End Sub

    Private Sub lblTodayMark_Paint(sender As Object, e As PaintEventArgs)
        Dim Mark = TryCast(sender, Label)
        Dim RedPen = New Pen(Color.Red, 1)
        e.Graphics.DrawRectangle(RedPen, New Rectangle(0, 0, Mark.Width - 1, Mark.Height - 1))
    End Sub

    Private Function IsValidHijri(iDay As Integer, iMonth As Integer, iYear As Integer) As Boolean
        Try
            Dim HCurrentDate = New StringBuilder()
            HCurrentDate.AppendFormat("{0}/{1}/{2}", iDay, iMonth, iYear)
            Return If(HijriDate.IsHijri(HCurrentDate.ToString()), True, False)
        Catch e As Exception
            Throw e
        End Try
    End Function

    Public Delegate Sub DateChangedHandler(sender As Object, e As EventArgs)

    <Category("Action")>
    <Description("Fires when the date changed.")>
    Public Event DateChanged As DateChangedHandler

    <Category("Date")>
    <Description("Gets or sets days")>
    Public Property Day As Integer
        Get
            Return m_iDay
        End Get
        Set

            If Value <= 30 AndAlso Value > 0 AndAlso Value <= m_iDaysInMonth Then

                If IsValidHijri(Value, m_iMonth, m_iYear) Then
                    m_iDay = Value
                    BuildDays(m_iMonth, m_iYear)
                End If
            End If
        End Set
    End Property

    <Category("Date")>
    <Description("Gets or sets months")>
    Public Property Month As Integer
        Get
            Return m_iMonth
        End Get
        Set

            If Value <= 12 AndAlso Value > 0 Then

                If IsValidHijri(m_iDay, Value, m_iYear) Then
                    m_iMonth = Value
                    BuildDays(m_iMonth, m_iYear)
                End If
            End If
        End Set
    End Property

    <Category("Date")>
    <Description("Gets or sets years")>
    Public Property Year As Integer
        Get
            Return m_iYear
        End Get
        Set

            If Value <= MAXIMUM_YEAR AndAlso Value > MINIMUM_YEAR Then

                If IsValidHijri(m_iDay, m_iMonth, Value) Then
                    m_iYear = Value
                    BuildDays(m_iMonth, m_iYear)
                End If
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
        Dim strTag As String = lblToday.Tag.ToString()
        Day = Int(strTag.Substring(0, 2))
        Month = Int(strTag.Substring(3, 2))
        Year = Int(strTag.Substring(6, 4))
        RaiseEvent DateChanged(sender, e)
    End Sub

    Private Sub btnQuit_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
        Hide()
    End Sub

    Private Sub HijriDatePicker_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Size = New Size(221, 196)
    End Sub

    Private Sub HijriDatePicker_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        Size = New Size(221, 196)
    End Sub

    Private Sub HijriDate_DateChanged(sender As Object, e As EventArgs) Handles Me.DateChanged
        Dim strDate = New StringBuilder()
        strDate.AppendFormat("{0}/{1}/{2}", Day, Month, Year)
        strValue = strDate.ToString()
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
                    dDate = Convert.ToDateTime(strValue, CultureInfo.CreateSpecificCulture("ar-SA"))
                Catch ex As Exception
                    Try
                        If Day = 30 Then
                            ' if error is just caused by an invalid date where day is 30 just
                            ' return the next day.
                            Day = 1
                            If Month = 12 Then
                                Month = 1
                                Year += 1
                            Else
                                Month += 1
                            End If
                            dDate = Convert.ToDateTime(strValue, CultureInfo.CreateSpecificCulture("ar-SA"))
                        End If
                    Catch ex2 As Exception
                        Beep()
                        MessageBox.Show("Invalid Date")
                        dDate = Nothing
                    End Try
                End Try
                If dDate Is Nothing Then
                    retDateStr = Nothing
                Else
                    retDateStr = DateToSpecificCultureShortDateString(dDate, CultureInfo.CreateSpecificCulture("ar-SA"))
                End If
            End If
            Return retDateStr
        End Get
        Set
            passedDateStr = Value
        End Set
    End Property

    Private Function GetMonthName(iMonth As Integer, Optional ByVal ShowMonthNumber As Boolean = False) As String
        Dim strMonth As String
        If CultureInfo.CurrentCulture.Name.ToLower().Remove(2) = "ar" Then
            strMonth = Cul.DateTimeFormat.MonthGenitiveNames(iMonth - 1)
        Else
            strMonth = HijriMonthInEnglish(iMonth)
        End If
        Return strMonth + If(ShowMonthNumber, " (" + iMonth.ToString.Trim() + ")", "")
    End Function

End Class