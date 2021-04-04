Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.Text
Imports System.Windows.Forms
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.CustomControlsLibrary

Public Class HijriCalendarForm
    Private ReadOnly HijriDate As HijriDates = New HijriDates()
    Private ReadOnly Cal As HijriCalendar = New HijriCalendar()
    Private ReadOnly Cul As CultureInfo = New CultureInfo("Ar-sa")

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

    Public Sub New()
        _initializing = True
        InitializeComponent()
        _initializing = False
        Cul.DateTimeFormat.Calendar = Cal
        DaysOfWeek(0) = lblSunday
        DaysOfWeek(1) = lblMonday
        DaysOfWeek(2) = lblTuesday
        DaysOfWeek(3) = lblWednesday
        DaysOfWeek(4) = lblThursday
        DaysOfWeek(5) = lblFriday
        DaysOfWeek(6) = lblSaturday
    End Sub

    Private Sub HijriDatePicker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim HDate As String = DateTime.Now.ToString("dd/MM/yyyy", Cul.DateTimeFormat)
        m_iDay = Convert.ToInt32(HDate.Substring(0, 2))
        m_iMonth = Convert.ToInt32(HDate.Substring(3, 2))
        m_iYear = Convert.ToInt32(HDate.Substring(6, 4))
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

        If Days IsNot Nothing Then

            For i = 0 To m_iDaysInMonth - 1
                Days(i).Dispose()
            Next
        End If

        Dim HFirstDay = New StringBuilder()
        HFirstDay.AppendFormat("1/{0}/{1}", iMonth, iYear)
        Dim tempDate As DateTime = DateTime.ParseExact(HFirstDay.ToString(), allFormats, Cul.DateTimeFormat,
                                                       DateTimeStyles.AllowWhiteSpaces)
        Dim strMonth As String = HijriDate.FormatHijri(HFirstDay.ToString(), "MMM")
        lblMonth.Text = strMonth
        lblYear.Text = Convert.ToString(iYear)
        Dim iDayOfWeek As DayOfWeek = tempDate.DayOfWeek
        Dim rcSaturday As Rectangle = DaysOfWeek(6).Bounds
        rcSaturday.Offset(0, rcSaturday.Height)
        Dim rcDay As Rectangle = DaysOfWeek(CInt(iDayOfWeek)).Bounds
        rcDay.Inflate(-5, 0)
        rcDay.Offset(-1, rcSaturday.Height)
        Dim iRows = 0
        m_iDaysInMonth = If(HijriDate.Is29(iMonth, m_iDay) = 1, 29, 30)
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

            If iDayOfWeek = DayOfWeek.Friday Then
                iDayOfWeek = DayOfWeek.Saturday
                rcDay = rcSaturday
                rcDay.Width -= 10
                iRows += 1
                rcDay.Offset(0, iRows * rcSaturday.Height)
            Else

                If iDayOfWeek = DayOfWeek.Saturday Then
                    iDayOfWeek = DayOfWeek.Sunday
                Else
                    iDayOfWeek += 1
                End If

                rcDay.Offset(-rcSaturday.Width, 0)
            End If
        Next

        Me.ResumeLayout()
        m_iPreviousMonth = m_iMonth
        m_iPreviousYear = m_iYear
        lblTodayMark.Size = Days(0).Size
        RaiseEvent DateChanged(Me, New EventArgs())
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
                Me.Hide()
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
        lblToday.Text = HijriDate.FormatHijri(HToday, " اليوم : dd MMM  yyyy")
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        m_iMonth = 1
        BuildDays(m_iMonth, m_iYear)
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs)
        m_iMonth = 2
        BuildDays(m_iMonth, m_iYear)
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs)
        m_iMonth = 3
        BuildDays(m_iMonth, m_iYear)
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs)
        m_iMonth = 4
        BuildDays(m_iMonth, m_iYear)
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs)
        m_iMonth = 5
        BuildDays(m_iMonth, m_iYear)
    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs)
        m_iMonth = 6
        BuildDays(m_iMonth, m_iYear)
    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs)
        m_iMonth = 7
        BuildDays(m_iMonth, m_iYear)
    End Sub

    Private Sub ToolStripMenuItem8_Click(sender As Object, e As EventArgs)
        m_iMonth = 8
        BuildDays(m_iMonth, m_iYear)
    End Sub

    Private Sub ToolStripMenuItem9_Click(sender As Object, e As EventArgs)
        m_iMonth = 9
        BuildDays(m_iMonth, m_iYear)
    End Sub

    Private Sub ToolStripMenuItem10_Click(sender As Object, e As EventArgs)
        m_iMonth = 10
        BuildDays(m_iMonth, m_iYear)
    End Sub

    Private Sub ToolStripMenuItem11_Click(sender As Object, e As EventArgs)
        m_iMonth = 11
        BuildDays(m_iMonth, m_iYear)
    End Sub

    Private Sub ToolStripMenuItem12_Click(sender As Object, e As EventArgs)
        m_iMonth = 12
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

    Private Sub lblTodayMark_Click(sender As Object, e As EventArgs)
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

    Private Sub HijriDatePicker_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Me.Size = New Size(220, 174)
    End Sub

    Private Sub HijriDatePicker_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        Me.Size = New Size(220, 174)
    End Sub

End Class