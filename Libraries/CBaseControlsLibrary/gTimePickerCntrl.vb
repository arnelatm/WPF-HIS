Imports System.Text.RegularExpressions
Imports System.Drawing.Drawing2D
Imports System.Drawing.Design
Imports System.Windows.Forms.Design
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

<ToolboxItem(True), ToolboxBitmap(GetType(gTimePickerCntrl), "gTimePickerControl.gTimePickerCntrl.bmp")> _
<Designer(GetType(gTimePickerCtrlDesigner))> _
<DefaultEvent("TimePicked")> _
Public Class gTimePickerCntrl

#Region "Initialize"
    Public Event TimePicked(ByVal sender As Object)

    Private ReadOnly sf As New StringFormat()
    Private ReadOnly Center As Point
    Private ReadOnly FaceRect As Rectangle
    Private IsHourRadius As Boolean

    Public cBlue As TimeColors = New TimeColors("RoyalBlue", "LightBlue", "DarkBlue", "SkyBlue", _
                "AliceBlue", "Gold", "PaleGoldenrod", "Lavender", "LightGray", "CornflowerBlue", _
                 "DarkBlue", "CornflowerBlue", "RoyalBlue", "LightCyan")
    Public cRed As TimeColors = New TimeColors("Red", "LightCoral", "Coral", "MistyRose", "Brown", _
                "Maroon", "Red", "Brown", "Firebrick", "IndianRed", "MistyRose", "RosyBrown", _
                "MistyRose", "MistyRose")
    Public cGreen As TimeColors = New TimeColors("DarkGreen", "PaleGreen", "PaleGreen", "Honeydew", _
                "Honeydew", "SeaGreen", "DarkGreen", "Green", "ForestGreen", "DarkSeaGreen", _
                 "DarkGreen", "DarkSeaGreen", "ForestGreen", "DarkSeaGreen")
    Public cYellow As TimeColors = New TimeColors("DarkGoldenrod", "LemonChiffon", "Khaki", "Ivory", _
                "LemonChiffon", "Sienna", "Sienna", "DarkGoldenrod", "DarkGoldenrod", "BurlyWood", _
                "Sienna", "Tan", "Sienna", "Ivory")

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center
        FaceRect = New Rectangle(14, 16, Width - 28, Width - 28)
        Center = New Point(CInt((Width) / 2) + 1, CInt(Width / 2) + 1)
    End Sub

#End Region

#Region "Properties"

#Region "Hidden"

    <Browsable(False)> _
<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
Public Shadows Property BackColor() As Boolean
        Get
            Return False 'always false 
        End Get
        Set(ByVal value As Boolean) 'empty 
        End Set
    End Property

    <Browsable(False)> _
<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
Public Shadows Property ForeColor() As Boolean
        Get
            Return False 'always false 
        End Get
        Set(ByVal value As Boolean) 'empty 
        End Set
    End Property

    <Browsable(False)> _
<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
Public Shadows Property Font() As Boolean
        Get
            Return False 'always false 
        End Get
        Set(ByVal value As Boolean) 'empty 
        End Set
    End Property

    <Browsable(False)> _
<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
Public Shadows Property BackgroundImage() As Boolean
        Get
            Return False 'always false 
        End Get
        Set(ByVal value As Boolean) 'empty 
        End Set
    End Property

    <Browsable(False)> _
<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
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
    <Editor(GetType(TimeUIEditor), GetType(UITypeEditor))> _
    <Category("Appearance gTime")> _
    <Description("Get or Set The Time value")> _
    <RefreshProperties(RefreshProperties.All)> _
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
                        ap = eTimeAMPM.PM
                    Else
                        ap = eTimeAMPM.AM
                    End If
                    value = Format(Val(value.Replace(":", String.Empty)), "0000")
                Else
                    ap = _TimeAMPM

                    'Check if a P, PM, A or AM is on the End 
                    'Update TimeAMPM Prop and remove from value
                    If value.ToUpper.EndsWith("P") Or value.ToUpper.EndsWith("PM") Then
                        value = value.ToUpper.Trim(CChar("M")).Trim(CChar("P")).Trim
                        ap = eTimeAMPM.PM
                    ElseIf value.ToUpper.EndsWith("A") Or value.ToUpper.EndsWith("AM") Then
                        value = value.ToUpper.Trim(CChar("M")).Trim(CChar("A")).Trim
                        ap = eTimeAMPM.AM
                    End If
                End If

                'Check if value is a valid time with or without a colon 
                If Regex.IsMatch(value, "^(([0-9])|([0-1][0-9])|([2][0-3])):?([0-5][0-9])$") Then
                    'Check and add leading '0'
                    If Regex.IsMatch(value, "^(([0-9])):?([0-5][0-9])$") Then value = "0" & value
                    'Add a Colon if missing
                    If Regex.IsMatch(value, "^(([0-1][0-9])|([2][0-3]))([0-5][0-9])$") Then
                        _Time = String.Format("{0}:{1}", value.Substring(0, 2), _
                            value.Substring(2, 2))
                    Else
                        _Time = value
                    End If

                    If Not IsNothing(ap) Then TimeAMPM = ap

                    'Adjust for 12 or 24 hour time
                    If Hr24 Then
                        If Hour() >= 12 Then
                            TimeAMPM = eTimeAMPM.PM
                        Else
                            TimeAMPM = eTimeAMPM.AM
                        End If
                    Else
                        If Hour() > 12 Then
                            _Time = String.Format("{0:0#}:{1:0#}", _
                                Hour() - 12, Minute)
                            TimeAMPM = eTimeAMPM.PM
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
        AM
        PM
    End Enum

    Private _TimeAMPM As eTimeAMPM = eTimeAMPM.AM

    Private _OldTimeAMPM As eTimeAMPM = eTimeAMPM.AM

    <Category("Appearance gTime")> _
    <Description("Get or Set The AM PM value")> _
    Public Property TimeAMPM() As eTimeAMPM
        Get
            Return _TimeAMPM
        End Get
        Set(ByVal value As eTimeAMPM)
            Dim tTime As eTimeAMPM = _TimeAMPM

            _TimeAMPM = value
            If _Hr24 Then
                If _TimeAMPM = eTimeAMPM.AM AndAlso Hour() >= 12 Then
                    _Time = String.Format("{0:0#}:{1:0#}", Hour() - 12, Minute)
                ElseIf _TimeAMPM = eTimeAMPM.PM AndAlso Hour() < 12 Then
                    _Time = String.Format("{0:0#}:{1:0#}", Hour() + 12, Minute)
                End If
            End If
            If _TimeAMPM = eTimeAMPM.AM Then
                AM()
            Else
                PM()
            End If
            If tTime <> _TimeAMPM Then RaiseEvent TimePicked(Me)

            Invalidate()
        End Set
    End Property

    Private _Hr24 As Boolean = True
    <Category("Appearance gTime")> _
   <Description("Get or Set Time as 12 or 24 hour")> _
    Public Property Hr24() As Boolean
        Get
            Return _Hr24
        End Get
        Set(ByVal value As Boolean)
            Dim tTime As String = _Time
            _Hr24 = value
            If _Hr24 Then
                If _TimeAMPM = eTimeAMPM.AM AndAlso Hour() >= 12 Then
                    _Time = String.Format("{0:0#}:{1:0#}", Hour() - 12, Minute)
                ElseIf _TimeAMPM = eTimeAMPM.PM AndAlso Hour() < 12 Then
                    _Time = String.Format("{0:0#}:{1:0#}", Hour() + 12, Minute)
                End If
            Else
                If Hour() > 12 Then
                    _Time = String.Format("{0:0#}:{1:0#}", Hour() - 12, Minute)
                    _TimeAMPM = eTimeAMPM.PM
                ElseIf Hour() = 0 Then
                    _Time = String.Format("12:{0:0#}", Minute)
                End If
            End If
            If _TimeAMPM = eTimeAMPM.AM Then
                AM()
            Else
                PM()
            End If
            If tTime <> _Time Then RaiseEvent TimePicked(Me)
            Invalidate()
        End Set
    End Property

    Private _TrueHour As Boolean = True
    <Category("Appearance gTime")> _
   <Description("Get or Set if the Hour hand shows true clock position or stays pointing at the chosen hour regardless of the minute.")> _
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
    <Category("Appearance gTime")> _
    <Description("Get or Set if the dots between fifth minutes show")> _
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
    <Editor(GetType(TimeColorsUIEditor), GetType(UITypeEditor))> _
    <Category("Appearance Color")> _
    <Description("Get or Set Color Scheme for the control")> _
    <RefreshProperties(RefreshProperties.Repaint)> _
    Public Property TimeColors() As TimeColors
        Get
            Return _TimeColors
        End Get
        Set(ByVal value As TimeColors)
            _TimeColors = value
            lklNow.LinkColor = _TimeColors.TimeAMPM_ON
            lklNull.LinkColor = _TimeColors.TimeAMPM_ON

            If _TimeAMPM = eTimeAMPM.AM Then
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

    Private Sub gTimePickerCntrl_MouseDown(ByVal sender As Object, _
      ByVal e As MouseEventArgs) Handles Me.MouseDown

        'Determine how far from center
        Dim radius As Integer = CInt( _
            Math.Round( _
            Math.Sqrt( _
                Math.Pow(CDbl(Center.X - e.Location.X), 2) + _
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
                    hr += (CInt(TimeAMPM = eTimeAMPM.PM) * -12)
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

    Private Shared Function GetAngle(ByVal Origin As PointF, _
                                ByVal XYPoint As PointF) As Integer

        Dim angleRadians As Double = Math.Atan2( _
                                        (-(XYPoint.Y - Origin.Y)), _
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

    Public Shared Function GetPoint(ByVal ptCenter As Point, _
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
        DrawRect(e.Graphics, New Rectangle(88, 2, 36, 20), _
             New PointF(0.2, 0), _
            New Single() { _
            0, _
            0.15, _
            0.32, _
            0.35, _
            1})

        'Time
        DrawRect(e.Graphics, New Rectangle(3, 2, 69, 30), _
            New PointF(0.5, 0), _
            New Single() { _
            0, _
            0.1, _
            0.32, _
            0.35, _
            1})

        'AMPM
        DrawRect(e.Graphics, New Rectangle(Width - 74, _
                                 2, _
                                 68 + CInt(IIf(BorderStyle = _
                                    Windows.Forms.BorderStyle.None, 2, 0)), _
                                 30), _
            New PointF(0.5, 0), _
            New Single() { _
            0, _
            0.1, _
            0.32, _
            0.35, _
            1})

        'Null
        DrawRect(e.Graphics, New Rectangle(lklNull.Left - 2, _
                                 lklNull.Top - 3, _
                                 lklNull.Width + 2, _
                                 lklNull.Height + 6), _
             New PointF(0.4, 0), _
            New Single() { _
            0, _
            0.15, _
            0.32, _
            0.35, _
            1})

        DrawClockFace(e.Graphics, FaceRect)

        DrawHours(e.Graphics)

        DrawMinutes(e.Graphics)

        'Draw Hands
        Using HrPen As New Pen(TimeColors.HourHand, 4), _
            MinPen As New Pen(TimeColors.MinuteHand, 2)

            HrPen.StartCap = Drawing2D.LineCap.RoundAnchor
            HrPen.EndCap = Drawing2D.LineCap.Triangle
            MinPen.StartCap = Drawing2D.LineCap.RoundAnchor
            MinPen.EndCap = Drawing2D.LineCap.Triangle

            If _Time = String.Empty Then
                e.Graphics.FillEllipse(New SolidBrush(HrPen.Color), Center.X - 4, Center.Y - 4, 8, 8)
                e.Graphics.FillEllipse(New SolidBrush(MinPen.Color), Center.X - 2, Center.Y - 2, 4, 4)
            Else

                Dim HourAngle As Single = 90 - (CSng(30 * (Val(_Time.Substring(0, 2))) + _
                    CSng(IIf(TrueHour, Val(_Time.Substring(3, 2)) / 2, 0))))
                Dim MinAngle As Single = 90 - CSng(6 * Val(_Time.Substring(3, 2)))

                e.Graphics.DrawLine(HrPen, Center, GetPoint(Center, 35, HourAngle))
                e.Graphics.DrawLine(MinPen, Center, GetPoint(Center, 60, MinAngle))

                e.Graphics.DrawString(_Time, New Font("Arial", 14, FontStyle.Bold), _
                    New SolidBrush(TimeColors.DisplayTime), New Rectangle(7, 8, 59, 21), sf)
            End If

        End Using

    End Sub

#End Region

#Region "Draw"

    Sub DrawHours(ByRef g As Graphics)
        For h As Integer = 1 To 12
            Dim hText As String = CStr(h + (CInt(Hr24 And TimeAMPM = eTimeAMPM.PM) * -12))
            Dim HourAngle As Single = 90 - CSng(30 * h)

            If Hr24 And h = 12 Then
                hText = CStr(Val(hText) - 12)
            End If

            DrawClockNumber(g, _
                hText, _
                47, _
                HourAngle, _
                TimeColors.Hour, 10)
        Next
    End Sub

    Sub DrawMinutes(ByRef g As Graphics)

        If _showMidMins Then

            For Each i As Integer In New Integer() { _
                1, 2, 3, 4, 6, 7, 8, 9, 11, 12, _
                13, 14, 16, 17, 18, 19, 21, 22, 23, 24, _
                26, 27, 28, 29, 31, 32, 33, 34, 36, 37, _
                38, 39, 41, 42, 43, 44, 46, 47, 48, 49, _
                51, 52, 53, 54, 56, 57, 58, 59}

                Dim pt As Point = GetPoint(Center, 70, 90 - CSng(6 * i))

                Using br As New SolidBrush(TimeColors.MinutePlus)
                    g.FillEllipse(br, New Rectangle(pt.X - 1, pt.Y - 1, 3, 3))
                End Using

            Next
        End If

        For Each i As Integer In New Integer() {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11}
            DrawClockNumber(g, _
                CStr(i * 5), _
                70, _
                90 - CSng(30 * i), _
                TimeColors.Minute, 10)
        Next


    End Sub

    Public Sub DrawClockNumber(ByRef g As Graphics, ByVal NumberText As String, ByVal radius As Integer, ByVal nAngle As Single, ByVal nColor As Color, ByVal FontSize As Integer)
        Using fn As New Font("Arial", FontSize, FontStyle.Bold)
            Dim pt As Point = GetPoint(Center, radius, nAngle)
            TextRenderer.DrawText(g, _
                NumberText, _
                fn, _
                New Rectangle( _
                    CInt(pt.X - 8), _
                    CInt(pt.Y - 7), _
                    18, _
                    16), _
                nColor, _
                TextFormatFlags.HorizontalCenter)

        End Using
    End Sub

    Sub DrawClockFace(ByRef g As Graphics, ByVal rect As Rectangle)

        'Simple Breakdown of creating a ColorBlend from scratch
        g.SmoothingMode = SmoothingMode.AntiAlias

        Dim blend As ColorBlend = New ColorBlend()

        'Add the Array of Color
        Dim bColors As Color() = New Color() { _
            TimeColors.FrameOuter, _
            TimeColors.FrameInner, _
            TimeColors.FrameOuter, _
            TimeColors.FaceOuter, _
            TimeColors.FaceInner}
        blend.Colors = bColors

        'Add the Array Single (0-1) colorpoints to place each Color
        Dim bPts As Single() = New Single() { _
            0, _
            0.0408, _
            0.082, _
            0.109, _
            1}
        blend.Positions = bPts

        ' Create a PathGradientBrush
        Dim gp As New GraphicsPath
        gp.AddEllipse(rect)
        Using br As New PathGradientBrush(gp)

            'Blend the colors into the Brush
            br.InterpolationColors = blend

            'Fill the rect with the blend
            g.FillEllipse(br, rect)
            g.DrawEllipse(New Pen(TimeColors.FrameOuter), rect)

        End Using
        gp.Dispose()
    End Sub

    Private Sub DrawRect(ByRef g As Graphics, ByVal rect As Rectangle, ByVal FocusScale As PointF, ByVal bPts As Single())
        'Simple Breakdown of creating a ColorBlend from scratch
        g.SmoothingMode = SmoothingMode.AntiAlias

        Dim blend As ColorBlend = New ColorBlend()

        'Add the Array of Color
        Dim bColors As Color() = New Color() { _
            TimeColors.FrameOuter, _
            TimeColors.FrameInner, _
            TimeColors.FrameOuter, _
            TimeColors.Box, _
            TimeColors.Box}
        blend.Colors = bColors

        'Add the Array Single (0-1) colorpoints to place each Color
        blend.Positions = bPts

        ' Create a PathGradientBrush
        Dim gp As New GraphicsPath
        gp.AddRectangle(rect) '(New Rectangle(rect.X, rect.Y, rect.Width, rect.Height + 2))

        Using br As New PathGradientBrush(gp)

            'Blend the colors into the Brush
            br.InterpolationColors = blend
            br.FocusScales = FocusScale

            'Fill the rect with the blend
            g.FillRectangle(br, rect)
            g.DrawRectangle(New Pen(TimeColors.FrameOuter), rect)

        End Using
        gp.Dispose()
    End Sub

#End Region

#Region "LinkLables"

    Private Sub lklNow_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) Handles lklNow.LinkClicked

        Time = String.Format("{0:0#}:{1:0#}", Now.Hour, Now.Minute)
        If Now.Hour < 12 Then
            TimeAMPM = eTimeAMPM.AM
        Else
            TimeAMPM = eTimeAMPM.PM
        End If

    End Sub

    Private Sub lklNull_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) Handles lklNull.LinkClicked

        Time = String.Empty

    End Sub

    Private Sub lklAM_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) Handles lklAM.LinkClicked
        TimeAMPM = eTimeAMPM.AM
    End Sub

    Private Sub lklPM_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) Handles lklPM.LinkClicked
        TimeAMPM = eTimeAMPM.PM
    End Sub

    Private Sub AM()
        lklAM.LinkColor = TimeColors.TimeAMPM_ON
        lklPM.LinkColor = TimeColors.TimeAMPM_OFF
    End Sub

    Private Sub PM()
        lklAM.LinkColor = TimeColors.TimeAMPM_OFF
        lklPM.LinkColor = TimeColors.TimeAMPM_ON
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

