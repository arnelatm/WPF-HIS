Imports System.Text.RegularExpressions
Imports System.Drawing.Drawing2D
Imports System.Drawing.Design
Imports System.Windows.Forms.Design
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles

<ToolboxItem(True), ToolboxBitmap(GetType(gTimePickerCntrl), "gTimePickerControl.gTimePickerCntrl.bmp")>
<Designer(GetType(gTimePickerCtrlDesigner))>
<DefaultEvent("TimePicked")>
Public Class gTimePickerCntrl

#Region "Initialize"

    Public Event TimePicked(ByVal sender As Object)

    Private ReadOnly sf As New StringFormat()
    Private ReadOnly Center As Point
    Private ReadOnly FaceRect As Rectangle
    Private IsHourRadius As Boolean

    Public cBlue As TimeColors = New TimeColors("RoyalBlue", "LightBlue", "DarkBlue", "SkyBlue",
                "AliceBlue", "Gold", "PaleGoldenrod", "Lavender", "LightGray", "CornflowerBlue",
                 "DarkBlue", "CornflowerBlue", "RoyalBlue", "LightCyan")

    Public cRed As TimeColors = New TimeColors("Red", "LightCoral", "Coral", "MistyRose", "Brown",
                "Maroon", "Red", "Brown", "Firebrick", "IndianRed", "MistyRose", "RosyBrown",
                "MistyRose", "MistyRose")

    Public cGreen As TimeColors = New TimeColors("DarkGreen", "PaleGreen", "PaleGreen", "Honeydew",
                "Honeydew", "SeaGreen", "DarkGreen", "Green", "ForestGreen", "DarkSeaGreen",
                 "DarkGreen", "DarkSeaGreen", "ForestGreen", "DarkSeaGreen")

    Public cYellow As TimeColors = New TimeColors("DarkGoldenrod", "LemonChiffon", "Khaki", "Ivory",
                "LemonChiffon", "Sienna", "Sienna", "DarkGoldenrod", "DarkGoldenrod", "BurlyWood",
                "Sienna", "Tan", "Sienna", "Ivory")

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center
        FaceRect = New Rectangle(30, 30, Width - 60, Width - 60)
        'FaceRect = New Rectangle(26, 26, Width - 52, Width - 52)
        Center = New Point(CInt((Width) / 2) + 1, CInt(Width / 2) + 1)
    End Sub

#End Region

#Region "Properties"

#Region "Hidden"

    <Browsable(False)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Shadows Property BackColor() As Boolean
        Get
            Return False 'always false
        End Get
        Set(ByVal value As Boolean) 'empty
        End Set
    End Property

    <Browsable(False)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Shadows Property ForeColor() As Boolean
        Get
            Return False 'always false
        End Get
        Set(ByVal value As Boolean) 'empty
        End Set
    End Property

    <Browsable(False)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Shadows Property Font() As Boolean
        Get
            Return False 'always false
        End Get
        Set(ByVal value As Boolean) 'empty
        End Set
    End Property

    <Browsable(False)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Shadows Property BackgroundImage() As Boolean
        Get
            Return False 'always false
        End Get
        Set(ByVal value As Boolean) 'empty
        End Set
    End Property

    <Browsable(False)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Shadows Property BackgroundImageLayout() As Boolean
        Get
            Return False 'always false
        End Get
        Set(ByVal value As Boolean) 'empty
        End Set
    End Property

#End Region

#Region "Time"

    Private _Time As String = "07:00"

    <Editor(GetType(TimeUIEditor), GetType(UITypeEditor))>
    <Category("Appearance gTime")>
    <Description("Get or Set The Time value")>
    <RefreshProperties(RefreshProperties.All)>
    Public Property Time() As String
        Get
            Return _Time
        End Get
        Set(ByVal value As String)
            Dim tTime As String = _Time

            If Not IsNothing(value) And value <> String.Empty Then

                'Check if value is just the hour
                If Regex.IsMatch(value, "^[0-9]{1}$|^[0-1]{1}[0-9]{1}$|^[2]{1}[0-3]{1}$") Then
                    value = value & ":00"
                End If

                Dim ap As eTimeAMPM

                If Hr24 Then
                    If Val(value.Replace(":", String.Empty)) >= 1200 Then
                        ap = eTimeAMPM.pm
                    Else
                        ap = eTimeAMPM.am
                    End If
                    value = Format(Val(value.Replace(":", String.Empty)), "0000")
                Else
                    ap = _TimeAMPM

                    'Check if a P, PM, A or AM is on the End
                    'Update TimeAMPM Prop and remove from value
                    If value.ToUpper.EndsWith("P") Or value.ToUpper.EndsWith("PM") Then
                        value = value.ToUpper.Trim(CChar("M")).Trim(CChar("P")).Trim
                        ap = eTimeAMPM.pm
                    ElseIf value.ToUpper.EndsWith("A") Or value.ToUpper.EndsWith("AM") Then
                        value = value.ToUpper.Trim(CChar("M")).Trim(CChar("A")).Trim
                        ap = eTimeAMPM.am
                    End If
                End If

                'Check if value is a valid time with or without a colon
                If Regex.IsMatch(value, "^(([0-9])|([0-1][0-9])|([2][0-3])):?([0-5][0-9])$") Then
                    'Check and add leading '0'
                    If Regex.IsMatch(value, "^(([0-9])):?([0-5][0-9])$") Then value = "0" & value
                    'Add a Colon if missing
                    If Regex.IsMatch(value, "^(([0-1][0-9])|([2][0-3]))([0-5][0-9])$") Then
                        _Time = String.Format("{0}:{1}", value.Substring(0, 2),
                            value.Substring(2, 2))
                    Else
                        _Time = value
                    End If

                    If Not IsNothing(ap) Then TimeAMPM = ap

                    'Adjust for 12 or 24 hour time
                    If Hr24 Then
                        If Hour() >= 12 Then
                            TimeAMPM = eTimeAMPM.pm
                        Else
                            TimeAMPM = eTimeAMPM.am
                        End If
                    Else
                        If Hour() > 12 Then
                            _Time = String.Format("{0:0#}:{1:0#}",
                                Hour() - 12, Minute)
                            TimeAMPM = eTimeAMPM.pm
                        ElseIf Hour() = 0 Then
                            _Time = String.Format("12:{0:0#}", Minute)

                        End If

                    End If
                End If
            Else
                _Time = String.Empty

            End If
            If tTime <> _Time Then RaiseEvent TimePicked(Me)

            Invalidate()
        End Set
    End Property

    Public Function Hour() As Integer
        Try
            Return CInt(_Time.Substring(0, 2))
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function MilitaryHour() As Integer
        Try
            Return CInt(_Time.Substring(0, 2))
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function Minute() As Integer
        Try
            Return CInt(_Time.Substring(3, 2))
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Sub TimeInMinutes(ByVal minutes As Integer)
        If minutes > 1439 Then minutes = 1439
        If minutes < 0 Then minutes = 0
        Time = Format(minutes \ 60, "00") & Format(minutes Mod 60, "00")
    End Sub

    Enum eTimeAMPM
        am
        pm
    End Enum

    Private _TimeAMPM As eTimeAMPM = eTimeAMPM.am

    Private _OldTimeAMPM As eTimeAMPM = eTimeAMPM.am

    <Category("Appearance gTime")>
    <Description("Get or Set The AM PM value")>
    Public Property TimeAMPM() As eTimeAMPM
        Get
            Return _TimeAMPM
        End Get
        Set(ByVal value As eTimeAMPM)
            Dim tTime As eTimeAMPM = _TimeAMPM

            _TimeAMPM = value
            If _Hr24 Then
                If _TimeAMPM = eTimeAMPM.am AndAlso Hour() >= 12 Then
                    _Time = String.Format("{0:0#}:{1:0#}", Hour() - 12, Minute)
                ElseIf _TimeAMPM = eTimeAMPM.pm AndAlso Hour() < 12 Then
                    _Time = String.Format("{0:0#}:{1:0#}", Hour() + 12, Minute)
                End If
            End If
            If _TimeAMPM = eTimeAMPM.am Then
                AM()
            Else
                PM()
            End If
            If tTime <> _TimeAMPM Then RaiseEvent TimePicked(Me)

            Invalidate()
        End Set
    End Property

    Private _Hr24 As Boolean = True

    <Category("Appearance gTime")>
    <Description("Get or Set Time as 12 or 24 hour")>
    Public Property Hr24() As Boolean
        Get
            Return _Hr24
        End Get
        Set(ByVal value As Boolean)
            Dim tTime As String = _Time
            _Hr24 = value
            If _Hr24 Then
                If _TimeAMPM = eTimeAMPM.am AndAlso Hour() >= 12 Then
                    _Time = String.Format("{0:0#}:{1:0#}", Hour() - 12, Minute)
                ElseIf _TimeAMPM = eTimeAMPM.pm AndAlso Hour() < 12 Then
                    _Time = String.Format("{0:0#}:{1:0#}", Hour() + 12, Minute)
                End If
            Else
                If Hour() > 12 Then
                    _Time = String.Format("{0:0#}:{1:0#}", Hour() - 12, Minute)
                    _TimeAMPM = eTimeAMPM.pm
                ElseIf Hour() = 0 Then
                    _Time = String.Format("12:{0:0#}", Minute)
                End If
            End If
            If _TimeAMPM = eTimeAMPM.am Then
                AM()
            Else
                PM()
            End If
            If tTime <> _Time Then RaiseEvent TimePicked(Me)
            Invalidate()
        End Set
    End Property

    Private _TrueHour As Boolean = True

    <Category("Appearance gTime")>
    <Description("Get or Set if the Hour hand shows true clock position or stays pointing at the chosen hour regardless of the minute.")>
    Public Property TrueHour() As Boolean
        Get
            Return _TrueHour
        End Get
        Set(ByVal value As Boolean)
            _TrueHour = value
            Invalidate()
        End Set
    End Property

    Public Function ToStringAMPM() As String
        If _Time = "" Then
            Return ""
        Else
            Return String.Format("{0} {1}", _Time, _TimeAMPM)
        End If
    End Function

    Public Function ToDate() As DateTime
        If _Time = "" Then
            Return Nothing
        Else
            Return CDate(String.Format("{0} {1}", _Time, _TimeAMPM))
        End If
    End Function

    Private _showMidMins As Boolean = True

    <Category("Appearance gTime")>
    <Description("Get or Set if the dots between fifth minutes show")>
    Public Property ShowMidMins() As Boolean
        Get
            Return _showMidMins
        End Get
        Set(ByVal Value As Boolean)
            _showMidMins = Value
            Invalidate()
        End Set
    End Property

#End Region

#Region "TimeColors"

    Private _TimeColors As TimeColors = New TimeColors

    <Editor(GetType(TimeColorsUIEditor), GetType(UITypeEditor))>
    <Category("Appearance Color")>
    <Description("Get or Set Color Scheme for the control")>
    <RefreshProperties(RefreshProperties.Repaint)>
    Public Property TimeColors() As TimeColors
        Get
            Return _TimeColors
        End Get
        Set(ByVal value As TimeColors)
            _TimeColors = value
            lklNow.LinkColor = _TimeColors.TimeAMPM_ON
            lklNull.LinkColor = _TimeColors.TimeAMPM_ON

            If _TimeAMPM = eTimeAMPM.am Then
                AM()
            Else
                PM()
            End If
            Invalidate()
        End Set
    End Property

#End Region

#End Region

#Region "Mouse"

    Private Sub gTimePickerCntrl_MouseDown(ByVal sender As Object,
      ByVal e As MouseEventArgs) Handles Me.MouseDown

        'Determine how far from center
        Dim radius As Integer = CInt(
            Math.Round(
            Math.Sqrt(
                Math.Pow(CDbl(Center.X - e.Location.X), 2) +
                Math.Pow(CDbl(Center.Y - e.Location.Y), 2)) _
                , 2))
        If radius <= 55 Then
            IsHourRadius = True
        Else
            IsHourRadius = False
        End If
        UpdateTime(e)

    End Sub

    Private Sub gTimePickerCntrl_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseMove

        UpdateTime(e)

    End Sub

    Private Sub UpdateTime(ByRef e As MouseEventArgs)
        Dim ang As Integer = GetAngle(Center, e.Location)
        If IsHourRadius Then
            Dim mn As String
            If e.Button = Windows.Forms.MouseButtons.Left _
                Or e.Button = Windows.Forms.MouseButtons.Right Then

                If _Time = String.Empty Or e.Button = Windows.Forms.MouseButtons.Right Then
                    mn = "00"
                Else
                    mn = _Time.Remove(0, 2).Trim(":"c)
                End If

                Dim hr As Integer = CInt(ang / 30)
                If hr = 12 Then hr = 0
                If Hr24 Then
                    hr += (CInt(TimeAMPM = eTimeAMPM.pm) * -12)
                End If
                Time = String.Format("{0:0#}:{1:0#}", hr, mn)
            End If
        Else
            IsHourRadius = False
            If e.Button = Windows.Forms.MouseButtons.Left Then
                Dim hr As String
                If _Time = String.Empty Then
                    hr = "00"
                Else
                    hr = _Time.Remove(3, 2).Trim(":"c)
                End If
                Time = String.Format("{0:0#}:{1:0#}", hr, CInt(ang / 6))
            End If
        End If
    End Sub

#End Region

#Region "Position Helpers"

    Private Shared Function GetAngle(ByVal Origin As PointF,
                                ByVal XYPoint As PointF) As Integer

        Dim angleRadians As Double = Math.Atan2(
                                        (-(XYPoint.Y - Origin.Y)),
                                        ((XYPoint.X - Origin.X)))
        Dim translatedAngle As Integer
        Dim angle As Integer = CInt(Math.Round(angleRadians * (180 / Math.PI)))

        'Translate to orient o degrees to the North
        If angle <= 90 Then
            translatedAngle = 90 - angle
        Else
            translatedAngle = 450 - angle
        End If

        Return translatedAngle

    End Function

    Public Shared Function GetPoint(ByVal ptCenter As Point,
        ByVal nRadius As Integer, ByVal fAngle As Single) As Point

        Dim x As Single = CSng(Math.Cos(2 * Math.PI * fAngle / 360)) * nRadius + ptCenter.X
        Dim y As Single = -CSng(Math.Sin(2 * Math.PI * fAngle / 360)) * nRadius + ptCenter.Y
        Return New Point(CInt(Fix(x)), CInt(Fix(y)))

    End Function

#End Region

#Region "Paint"

    Private Sub gTimePicker_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles Me.Paint
        e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        e.Graphics.Clear(_TimeColors.BackGround)

        'Now
        DrawRect(e.Graphics, New Rectangle(lklNow.Left - 2, lklNow.Top - 5, lklNow.Width + 2, lklNow.Height + 6),
             New PointF(0.1, 0),
            New Single() {
            0,
            0.1,
            0.1,
            0.1,
            1})

        'Time
        DrawRect(e.Graphics, New Rectangle(1, 1, 65, 30),
            New PointF(0.1, 0),
            New Single() {
            0,
            0.1,
            0.1,
            0.1,
            1})

        'AM PM
        DrawRect(e.Graphics, New Rectangle(lklAM.Left - 1, lklAM.Top - 3, lklAM.Width + 2, lklAM.Height + lklPM.Height + 2),
            New PointF(0.1, 0),
            New Single() {
            0,
            0.1,
            0.1,
            0.1,
            1})

        ''PM
        'DrawRect(e.Graphics, New Rectangle(lklPM.Left - 2, lklPM.Top - 5, lklPM.Width + 2, lklPM.Height + 6), _
        '    New PointF(0.5, 0), _
        '    New Single() { _
        '    0, _
        '    0.1, _
        '    0.32, _
        '    0.35, _
        '    1})

        'DrawRect(e.Graphics, New Rectangle(lklAM.Left -2, _
        '                        lklAM.Top - 5, _
        '                        lklPM.Right - lklAM.Left + 10, _
        '                        lklAM.Height + 6), _
        '   New PointF(0.5, 0), _
        '   New Single() { _
        '   0, _
        '   0.1, _
        '   0.32, _
        '   0.35, _
        '   1})

        'Null
        DrawRect(e.Graphics, New Rectangle(lklNull.Left - 2,
                                 lklNull.Top - 5,
                                 lklNull.Width + 2,
                                 lklNull.Height + 6),
             New PointF(0.4, 0),
            New Single() {
            0,
            0.1,
            0.1,
            0.1,
            1})

        'OK
        DrawRect(e.Graphics, New Rectangle(lklOK.Left - 2,
                                 lklOK.Top - 5,
                                 lklOK.Width + 2,
                                 lklOK.Height + 6),
            New PointF(0.5, 0),
            New Single() {
            0,
            0.1,
            0.1,
            0.1,
            1})

        DrawClockFace(e.Graphics, FaceRect)

        DrawHours(e.Graphics)

        DrawMinutes(e.Graphics)

        'Draw Hands
        Using HrPen As New Pen(TimeColors.HourHand, 4),
            MinPen As New Pen(TimeColors.MinuteHand, 2)

            HrPen.StartCap = Drawing2D.LineCap.RoundAnchor
            HrPen.EndCap = Drawing2D.LineCap.Triangle
            MinPen.StartCap = Drawing2D.LineCap.RoundAnchor
            MinPen.EndCap = Drawing2D.LineCap.Triangle

            If _Time = String.Empty Then
                Using hourBrush As New SolidBrush(HrPen.Color),
                    minuteBrush As New SolidBrush(MinPen.Color)
                    e.Graphics.FillEllipse(hourBrush, Center.X - 4, Center.Y - 4, 8, 8)
                    e.Graphics.FillEllipse(minuteBrush, Center.X - 2, Center.Y - 2, 4, 4)
                End Using
            Else

                Dim HourAngle As Single = 90 - (CSng(30 * (Val(_Time.Substring(0, 2))) +
                    CSng(IIf(TrueHour, Val(_Time.Substring(3, 2)) / 2, 0))))
                Dim MinAngle As Single = 90 - CSng(6 * Val(_Time.Substring(3, 2)))

                e.Graphics.DrawLine(HrPen, Center, GetPoint(Center, 35, HourAngle))
                e.Graphics.DrawLine(MinPen, Center, GetPoint(Center, 60, MinAngle))

                Using displayFont As New Font("Arial", 14, FontStyle.Bold),
                    displayBrush As New SolidBrush(TimeColors.DisplayTime)
                    e.Graphics.DrawString(_Time, displayFont, displayBrush, New Rectangle(7, 8, 59, 21), sf)
                End Using
            End If

        End Using

    End Sub

#End Region

#Region "Draw"

    Sub DrawHours(ByRef g As Graphics)
        For h As Integer = 1 To 12
            Dim hText As String = CStr(h + (CInt(Hr24 And TimeAMPM = eTimeAMPM.pm) * -12))
            Dim HourAngle As Single = 90 - CSng(30 * h)

            If Hr24 And h = 12 Then
                hText = CStr(Val(hText) - 12)
            End If

            DrawClockNumber(g,
                hText,
                47,
                HourAngle,
                TimeColors.Hour, 10)
        Next
    End Sub

    Sub DrawMinutes(ByRef g As Graphics)

        If _showMidMins Then

            For Each i As Integer In New Integer() {
                1, 2, 3, 4, 6, 7, 8, 9, 11, 12,
                13, 14, 16, 17, 18, 19, 21, 22, 23, 24,
                26, 27, 28, 29, 31, 32, 33, 34, 36, 37,
                38, 39, 41, 42, 43, 44, 46, 47, 48, 49,
                51, 52, 53, 54, 56, 57, 58, 59}

                Dim pt As Point = GetPoint(Center, 70, 90 - CSng(6 * i))

                Using br As New SolidBrush(TimeColors.MinutePlus)
                    g.FillEllipse(br, New Rectangle(pt.X - 1, pt.Y - 1, 3, 3))
                End Using

            Next
        End If

        For Each i As Integer In New Integer() {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11}
            DrawClockNumber(g,
                CStr(i * 5),
                70,
                90 - CSng(30 * i),
                TimeColors.Minute, 10)
        Next

    End Sub

    Public Sub DrawClockNumber(ByRef g As Graphics, ByVal NumberText As String, ByVal radius As Integer, ByVal nAngle As Single, ByVal nColor As Color, ByVal FontSize As Integer)
        Using fn As New Font("Arial", FontSize, FontStyle.Bold)
            Dim pt As Point = GetPoint(Center, radius, nAngle)
            TextRenderer.DrawText(g,
                NumberText,
                fn,
                New Rectangle(
                    CInt(pt.X - 8),
                    CInt(pt.Y - 7),
                    18,
                    16),
                nColor,
                TextFormatFlags.HorizontalCenter)

        End Using
    End Sub

    Sub DrawClockFace(ByRef g As Graphics, ByVal rect As Rectangle)

        'Simple Breakdown of creating a ColorBlend from scratch
        g.SmoothingMode = SmoothingMode.AntiAlias

        Dim blend As ColorBlend = New ColorBlend()

        'Add the Array of Color
        Dim bColors As Color() = New Color() {
            TimeColors.FrameOuter,
            TimeColors.FrameInner,
            TimeColors.FrameOuter,
            TimeColors.FaceOuter,
            TimeColors.FaceInner}
        blend.Colors = bColors

        'Add the Array Single (0-1) colorpoints to place each Color
        Dim bPts As Single() = New Single() {
            0,
            0.0408,
            0.082,
            0.109,
            1}
        blend.Positions = bPts

        ' Create a PathGradientBrush
        Using gp As New GraphicsPath
            gp.AddEllipse(rect)
            Using br As New PathGradientBrush(gp),
                framePen As New Pen(TimeColors.FrameOuter)

                'Blend the colors into the Brush
                br.InterpolationColors = blend

                'Fill the rect with the blend
                g.FillEllipse(br, rect)
                g.DrawEllipse(framePen, rect)

            End Using
        End Using
    End Sub

    Private Sub DrawRect(ByRef g As Graphics, ByVal rect As Rectangle, ByVal FocusScale As PointF, ByVal bPts As Single())
        'Simple Breakdown of creating a ColorBlend from scratch
        g.SmoothingMode = SmoothingMode.AntiAlias

        Dim blend As ColorBlend = New ColorBlend()

        'Add the Array of Color
        Dim bColors As Color() = New Color() {
            TimeColors.FrameOuter,
            TimeColors.FrameInner,
            TimeColors.FrameOuter,
            TimeColors.Box,
            TimeColors.Box}
        blend.Colors = bColors

        'Add the Array Single (0-1) colorpoints to place each Color
        blend.Positions = bPts

        ' Create a PathGradientBrush
        Using gp As New GraphicsPath
            gp.AddRectangle(rect) '(New Rectangle(rect.X, rect.Y, rect.Width, rect.Height + 2))
            Using br As New PathGradientBrush(gp),
                framePen As New Pen(TimeColors.FrameOuter)

                'Blend the colors into the Brush
                br.InterpolationColors = blend
                br.FocusScales = FocusScale

                'Fill the rect with the blend
                g.FillRectangle(br, rect)
                g.DrawRectangle(framePen, rect)

            End Using
        End Using
    End Sub

#End Region

#Region "LinkLabels"

    Private Sub lklNow_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) Handles lklNow.LinkClicked

        Time = String.Format("{0:0#}:{1:0#}", Now.Hour, Now.Minute)
        If Now.Hour < 12 Then
            TimeAMPM = eTimeAMPM.am
        Else
            TimeAMPM = eTimeAMPM.pm
        End If

    End Sub

    Private Sub lklNull_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) Handles lklNull.LinkClicked

        Time = String.Empty

    End Sub

    Private Sub lklAM_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) Handles lklAM.LinkClicked
        TimeAMPM = eTimeAMPM.am
    End Sub

    Private Sub lklPM_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) Handles lklPM.LinkClicked
        TimeAMPM = eTimeAMPM.pm
    End Sub

    Private Sub AM()
        lklAM.LinkColor = TimeColors.TimeAMPM_ON
        lklPM.LinkColor = TimeColors.TimeAMPM_OFF
    End Sub

    Private Sub PM()
        lklAM.LinkColor = TimeColors.TimeAMPM_OFF
        lklPM.LinkColor = TimeColors.TimeAMPM_ON
    End Sub

    Private Sub lklOk_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) Handles lklOK.LinkClicked
        'My.Computer.Keyboard.SendKeys(Chr(27), False)
        SendKeys.Send("{ESC}")
    End Sub

#End Region

End Class

Class gTimePickerCtrlDesigner
    Inherits ControlDesigner

    Public Overrides ReadOnly Property SelectionRules() _
  As System.Windows.Forms.Design.SelectionRules
        Get
            Return Windows.Forms.Design.SelectionRules.Visible _
                   Or Windows.Forms.Design.SelectionRules.Moveable
        End Get
    End Property

End Class
