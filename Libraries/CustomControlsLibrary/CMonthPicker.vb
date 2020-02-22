Imports System.ComponentModel
Imports System.Globalization
Imports AATM.Libraries.GlobalFuncNSub

Public Class CMonthPicker
    Private _targetCalendar As Calendar
    Private _mMaximumYear As Integer = 9999
    Private _mMinimumYear As Integer = 1
    Private _initializing As Boolean = True
    Private _originalCulture As CultureInfo
    Private _targetCulture As CultureInfo = New CultureInfo(CultureInfo.CurrentCulture.Name)
    Private _maximumYear As Integer = 9999
    Private _minimumYear As Integer = 1

    Private Sub CMonthPicker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim m As Integer
        _originalCulture = CultureInfo.CurrentCulture
        SetCalendarType(CalendarToUse.Gregorian)
        cboMonths.Items.Clear()
        For m = 1 To 12
            cboMonths.Items.Add(GetMonthNameInCulture(m, _targetCulture, _originalCulture))
        Next
        cboMonths.MaxDropDownItems = 12
        cboMonths.IntegralHeight = True
        LoadCalendar()
        _initializing = False
    End Sub

    Private Sub SetCalendarType(calendarType As CalendarToUse)
        Select Case calendarType
            Case CalendarToUse.UmAlQura
                _targetCalendar = New UmAlQuraCalendar
                If Not CultureSupportUmAlQura(_targetCulture) Then
                    _targetCulture = CultureInfo.CreateSpecificCulture("ar-SA")
                End If
            Case CalendarToUse.Hijri
                _targetCalendar = New HijriCalendar
                If Not CultureSupportHijri(_targetCulture) Then
                    _targetCulture = CultureInfo.CreateSpecificCulture("ar-SA")
                    _targetCalendar = New HijriCalendar()
                End If
            Case Else
                _targetCalendar = New GregorianCalendar
        End Select
        _targetCulture.DateTimeFormat.Calendar = _targetCalendar
        CultureInfo.CurrentCulture = _targetCulture
        Dim dMaxDate = _targetCalendar.MaxSupportedDateTime
        Dim dMinDate = _targetCalendar.MinSupportedDateTime
        _maximumYear = _targetCalendar.GetYear(dMaxDate)
        _minimumYear = _targetCalendar.GetYear(dMinDate)
        If _originalCulture.TextInfo.IsRightToLeft Then
            RightToLeft = RightToLeft.Yes
        Else
            RightToLeft = RightToLeft.No
        End If
    End Sub

    Private Sub LoadCalendar()
        Dim curCulture = CultureInfo.CurrentCulture
        CultureInfo.CurrentCulture = New CultureInfo("En-GB", False)
        If Not IsNothing(Value) Then
            Dim dateToday As Date = Now
            Dim nMonth As Integer = dateToday.Month
            If nMonth = 1 Then
                Value = DateSerial(dateToday.Year - 1, 12, 1)
            Else
                Value = DateSerial(dateToday.Year, dateToday.Month - 1, 1)
            End If
        End If
        cboMonths.SelectedIndex = Value.Month - 1
        spnYear.Value = Value.Year
        spnYear.Minimum = _minimumYear
        spnYear.Maximum = _maximumYear
        CultureInfo.CurrentCulture = curCulture
    End Sub

    Public Property Value As Date = Now

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNextMonth.Click
        Value = Value.AddMonths(1)
        spnYear.Value = Value.Year
        cboMonths.SelectedIndex = Value.Month - 1
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevMonth.Click
        Value = Value.AddMonths(-1)
        spnYear.Value = Value.Year
        cboMonths.SelectedIndex = Value.Month - 1
    End Sub

    Private Sub txtYear_ValueChanged(sender As Object, e As EventArgs) Handles spnYear.ValueChanged
        If (Not _initializing) Then
            Value = GbDateSerial(spnYear.Value, Value.Month, 1)
        End If
    End Sub

    Private Sub cboMonths_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMonths.SelectedIndexChanged
        Value = GbDateSerial(Value.Year, cboMonths.SelectedIndex + 1, 1)
    End Sub

    Private Sub txtYear_Validating(sender As Object, e As CancelEventArgs) Handles spnYear.Validating
        If spnYear.Value < _mMinimumYear Then
            e.Cancel = True
        End If
        If spnYear.Value > _mMaximumYear Then
            e.Cancel = True
        End If
    End Sub

End Class