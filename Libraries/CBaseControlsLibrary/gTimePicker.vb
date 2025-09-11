Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms.Design
Imports System.Drawing.Design
Imports System.Windows.Forms
Imports AATM.Libraries.CBaseControlsLibrary.gTimePickerCntrl
Imports System.Text.RegularExpressions
Imports System.Diagnostics.Eventing.Reader
Imports AATM.DataLayer.AdoNet

'Version 1.0 8-09
'version 1.1 8-09 Fixed 24 hour time
'version 1.2 8-09 Added AM PM button
'version 1.3 8-09 Threw the Time, TimeAMPM and HR24 Property code out and started over.
'   It was becoming to Patchworky.
'version 1.4 9-09 Nullable value
'version 1.5 7-10 Added Dropdown and Contextmenu open events, and renamed gTextBox gTimeBox because of a naming conflict
'version 1.6 02-12
'   Removed Redundent property code
'   Right click hour to 00 minutes
'   Added Null button and fixed nullable behavior
'   Replaced Link Numbers with numbers drawn directly on Graphics surface
'   Removed bottom mid-minutes box and added direct minute selection with the mouse

<ToolboxItem(True), ToolboxBitmap(GetType(gTimePicker), "gTimePickerControl.gTimePicker.bmp")>
<Designer(GetType(gTimePickerDesigner))>
<DefaultEvent("TimePicked")>
Public Class gTimePicker

#Region "Declarations"

    Private ReadOnly _rectDropDownButtonWidth = 16
    Private rectDropDownButton As Rectangle = New Rectangle(Me.Width - _rectDropDownButtonWidth + 4, 0, _rectDropDownButtonWidth + 4, Me.Height)
    Private ReadOnly _rectAmPmWidth = 20
    Private rectAMPM As Rectangle = New Rectangle(0, 0, _rectAmPmWidth, Me.Height)
    Private ReadOnly popup As New ToolStripDropDown()
    Private host As ToolStripControlHost
    Private IsPopupOpen As Boolean
    Private ReadOnly gTime As New gTimePickerCntrl()
    Private WithEvents Clear As New ContextMenuStrip
    Private tTime As String = String.Empty

    Public Event TimePicked(ByVal sender As Object)

    Public Event DropDown(ByVal sender As Object, ByVal IsOpen As Boolean)

    Public Event ContextOpen(ByVal sender As Object, ByVal IsOpen As Boolean)

#End Region

#Region "Initialize"

    Private Sub gTimePicker_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        host = New ToolStripControlHost(gTime)

        host.Margin = Padding.Empty
        host.Padding = Padding.Empty
        host.AutoSize = False
        host.Size = gTime.Size

        popup.Size = gTime.Size
        popup.Items.Add(host)

        AddHandler popup.Opening, AddressOf popup_Opening
        AddHandler popup.Closed, AddressOf popup_Closed
        AddHandler popup.Closing, AddressOf popup_Closing
        txbTime.Text = Time
        Clear.Items.Add("Clear Time")
        ContextMenuStrip = Clear
        txbTime.ContextMenuStrip = Clear
        oldTimeAmPM = TimeAMPM
    End Sub

#End Region

#Region "Properties"

#Region "Hidden"

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
    Public Shadows Property BorderStyle() As Boolean
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

    <Browsable(False)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Shadows Property ForeColor() As Boolean
        Get
            Return False 'always false
        End Get
        Set(ByVal value As Boolean) 'empty
        End Set
    End Property

#End Region

#Region "Time Control Colors"

    <Editor(GetType(TimeColorsUIEditor), GetType(UITypeEditor))>
    <Category("Appearance Color")>
    <Description("Get or Set Color Scheme for the control")>
    Public Property TimeColors() As TimeColors
        Get
            Return gTime.TimeColors
        End Get
        Set(ByVal value As TimeColors)
            gTime.TimeColors = value
        End Set
    End Property

#End Region

#Region "gTimePickerCntrl Properties"

    <Bindable(True)>
    <Editor(GetType(TimeUIEditor), GetType(UITypeEditor))>
    <Category("Appearance gTime")>
    <Description("Get or Set The Time value")>
    <RefreshProperties(RefreshProperties.All)>
    Public Property Time() As String
        Get
            Return gTime.Time
        End Get
        Set(ByVal value As String)
            tTime = gTime.Time
            gTime.Time = value
            txbTime.Text = Time
            If tTime <> gTime.Time Then RaiseEvent TimePicked(Me)
            Invalidate()
        End Set
    End Property

    Private Sub InformUserOfInvalidTime()
        'ToolTip1.ToolTipTitle = "Input Rejected"
        'Dim calendarName As String = MessagingService.TranslateCaption(CalendarNameInEnglish(_targetCulture))
        'Dim cText = txtDate.Text
        'Dim cCalendarName As String = calendarName
        'ToolTip1.ToolTipTitle = "Input Rejected"
        'MessagingService.ShowPmMessage(True, "MsgErroneousDate", {"enteredDate", cText, "calendarName", cCalendarName})
        MessageBox.Show("Invalid time entered!")
    End Sub

    Public Sub SetTime(lMilitaryTime As String)
        If lMilitaryTime < "12:00" Then
            SetAmPm(eTimeAMPM.am)
        Else
            SetAmPm(eTimeAMPM.pm)
        End If
        gTime.Time = lMilitaryTime
        tTime = lMilitaryTime
        txbTime.Text = Time
        oldTimeAmPM = gTime.TimeAMPM
    End Sub

    Public Function GetMilitaryTime() As String
        Dim cText As String
        If gTime.TimeAMPM = eTimeAMPM.pm Then
            Dim mHour As Int16
            mHour = gTime.Hour()
            If mHour < 12 Then
                mHour = gTime.Hour + 12
            End If
            cText = mHour.ToString().Trim().PadLeft(2, "0") + gTime.Time.Substring(2)
        Else
            Dim mHour As Int16
            mHour = gTime.Hour()
            If mHour = 12 Then
                cText = "00" + gTime.Time.Substring(2)
            Else
                cText = gTime.Time
            End If
        End If
        Return cText
    End Function

    Public Sub SetAmPm(lAmPm As gTimePickerCntrl.eTimeAMPM, Optional force As Boolean = True)
        If txbTime.EditingMode Or force Then
            gTime.TimeAMPM = lAmPm
            Invalidate()
        End If
    End Sub

    Public Property oldTimeAmPM As gTimePickerCntrl.eTimeAMPM

    <Category("Appearance gTime")>
    <Description("Get or Set Time as am or pm")>
    Public Property TimeAMPM() As gTimePickerCntrl.eTimeAMPM
        Get
            Return gTime.TimeAMPM
        End Get
        Set(ByVal value As gTimePickerCntrl.eTimeAMPM)
            tTime = Time
            gTime.TimeAMPM = value
            txbTime.Text = gTime.Time
            Invalidate()
            If tTime <> gTime.Time Then RaiseEvent TimePicked(Me)
        End Set
    End Property

    <Category("Appearance gTime")>
    <Description("Get or Set Time as 12 or 24 hour")>
    Public Property Hr24() As Boolean
        Get
            Return gTime.Hr24
        End Get
        Set(ByVal value As Boolean)
            gTime.Hr24 = value
            txbTime.Text = gTime.Time
            Invalidate()
        End Set
    End Property

    <Category("Appearance gTime")>
    <Description("Get or Set if the Hour hand shows true clock position or stays pointing at the chosen hour regardless of the minute.")>
    Public Property TrueHour() As Boolean
        Get
            Return gTime.TrueHour
        End Get
        Set(ByVal value As Boolean)
            gTime.TrueHour = value
        End Set
    End Property

    <Category("Appearance gTime")>
    <Description("Get or Set if the dots between fifth minutes show")>
    Public Property ShowMidMins() As Boolean
        Get
            Return gTime.ShowMidMins
        End Get
        Set(ByVal Value As Boolean)
            gTime.ShowMidMins = Value
        End Set
    End Property

    Public Function ToStringAMPM() As String
        If Time = "" Then
            Return ""
        Else
            Return gTime.ToStringAMPM
        End If
    End Function

    Public Function ToDate() As DateTime
        If Time = "" Then
            Return Nothing
        Else
            Return gTime.ToDate
        End If
    End Function

    Public Function Hour() As Integer
        Return gTime.Hour()
    End Function

    Public Function Minute() As Integer
        Return gTime.Minute()
    End Function

    Public Sub TimeInMinutes(ByVal minutes As Integer)
        gTime.TimeInMinutes(minutes)
        txbTime.Text = Time

    End Sub

#End Region

#Region "gTimeBox Properties"

    Private _TextBackColor As Color = Color.White

    <Category("Appearance gTime")>
    <Description("Get or Set BackColor for Text")>
    Public Property TextBackColor() As Color
        Get
            Return _TextBackColor

        End Get
        Set(ByVal value As Color)
            _TextBackColor = value
            txbTime.BackColor = _TextBackColor
        End Set
    End Property

    Private _TextForeColor As Color = Color.Black

    <Category("Appearance gTime")>
    <Description("Get or Set ForeColor for Text")>
    Public Property TextForeColor() As Color
        Get
            Return _TextForeColor

        End Get
        Set(ByVal value As Color)
            _TextForeColor = value
            txbTime.ForeColor = _TextForeColor
        End Set
    End Property

    Private _TextAlign As HorizontalAlignment

    <Category("Appearance gTime")>
    <Description("Get or Set HorizontalAlignment for Text")>
    Public Property TextAlign() As HorizontalAlignment
        Get
            Return _TextAlign

        End Get
        Set(ByVal value As HorizontalAlignment)
            _TextAlign = value
            txbTime.TextAlign = value
        End Set
    End Property

    Private _Font As Font = New Font("Arial", 10)

    <Category("Appearance gTime")>
    <Description("Get or Set TextBox Font")>
    Public Property TextFont() As Font
        Get
            Return _Font
        End Get
        Set(ByVal value As Font)
            _Font = value
            txbTime.Font = _Font
            ResizeMe()
            Invalidate()
        End Set
    End Property

    Private _EnterTabsOut As Boolean = True

    <Category("Behavior")>
    <Description("Get or Set if pressing Enter tabs out of the control")>
    <DefaultValue(True)>
    Public Property EnterTabsOut() As Boolean
        Get
            Return _EnterTabsOut
        End Get
        Set(ByVal value As Boolean)
            _EnterTabsOut = value
        End Set
    End Property

#End Region

#Region "Button"

    Private _ButtonForeColor As Color = Color.DarkSlateBlue

    <Category("Appearance Button")>
    <Description("Get or Set the color of the Arrow on the DropDown Button")>
    <DefaultValue(GetType(Color), "DarkSlateGray")>
    Public Property ButtonForeColor() As Color
        Get
            Return _ButtonForeColor
        End Get
        Set(ByVal value As Color)
            _ButtonForeColor = value
            Invalidate()
        End Set
    End Property

    Private _ButtonBackColor As Color = Color.LightSteelBlue

    <Category("Appearance Button")>
    <Description("Get or Set the base color of the DropDown Button")>
    <DefaultValue(GetType(Color), "LightSteelBlue")>
    Public Property ButtonBackColor() As Color
        Get
            Return _ButtonBackColor
        End Get
        Set(ByVal value As Color)
            _ButtonBackColor = value
            Invalidate()
        End Set
    End Property

    Private _ButtonHighlight As Color = Color.White

    <Category("Appearance Button")>
    <Description("Get or Set the Highlight color of the DropDown Button")>
    <DefaultValue(GetType(Color), "White")>
    Public Property ButtonHighlight() As Color
        Get
            Return _ButtonHighlight
        End Get
        Set(ByVal value As Color)
            _ButtonHighlight = value
            Invalidate()
        End Set
    End Property

    Private _ButtonBorder As Color = Color.SlateGray

    <Category("Appearance Button")>
    <Description("Get or Set the Border Color of the DropDown Button")>
    <DefaultValue(GetType(Color), "SlateGray")>
    Public Property ButtonBorder() As Color
        Get
            Return _ButtonBorder
        End Get
        Set(ByVal value As Color)
            _ButtonBorder = value
            Invalidate()
        End Set
    End Property

#End Region

#Region "NULL"

    Private _NullText As String = "NULL"

    <Category("Appearance NULL")>
    <Description("Text to display when NULL")>
    <DefaultValue("NULL")>
    Public Property NullText() As String
        Get
            Return _NullText
        End Get
        Set(ByVal value As String)
            _NullText = value
            txbTime.NullText = value
            Invalidate()
        End Set
    End Property

    Private _NullTextInFront As Boolean

    <Category("Appearance NULL")>
    <Description("Should the NULL text appear in front of the Hatch Fill")>
    <DefaultValue(True)>
    Public Property NullTextInFront() As Boolean
        Get
            Return _NullTextInFront
        End Get
        Set(ByVal value As Boolean)
            _NullTextInFront = value
            txbTime.NullTextInFront = value
            Invalidate()
        End Set
    End Property

    Private _NullTextColor As Color = Color.Black

    <Category("Appearance NULL")>
    <Description("Color for the NULL Text")>
    <DefaultValue("Black")>
    Public Property NullTextColor() As Color
        Get
            Return _NullTextColor
        End Get
        Set(ByVal value As Color)
            _NullTextColor = value
            txbTime.NullTextColor = value
            Invalidate()
        End Set
    End Property

    Private _NullHatchStyle As HatchStyle = Drawing2D.HatchStyle.WideDownwardDiagonal

    <Editor(GetType(HatchStyleEditor), GetType(UITypeEditor))>
    <Category("Appearance NULL")>
    <Description("Choose the HatchStyle")>
    <DefaultValue("WideDownwardDiagonal")>
    Public Property NullHatchStyle() As HatchStyle
        Get
            Return _NullHatchStyle
        End Get
        Set(ByVal value As HatchStyle)
            _NullHatchStyle = value
            txbTime.NullHatchStyle = value
            Invalidate()
        End Set
    End Property

    Private _NullColorA As Color = Color.LightSteelBlue

    <Category("Appearance NULL")>
    <Description("Color A for the HatchStyle")>
    <DefaultValue("LightSteelBlue")>
    Public Property NullColorA() As Color
        Get
            Return _NullColorA
        End Get
        Set(ByVal value As Color)
            _NullColorA = value
            txbTime.NullColorA = value
            Invalidate()
        End Set
    End Property

    Private _NullColorB As Color = Color.White

    <Category("Appearance NULL")>
    <Description("Color B for the HatchStyle")>
    <DefaultValue("White")>
    Public Property NullColorB() As Color
        Get
            Return _NullColorB
        End Get
        Set(ByVal value As Color)
            _NullColorB = value
            txbTime.NullColorB = value
            Invalidate()
        End Set
    End Property

    Private _NullAlpha As Integer = 150

    <Category("Appearance NULL")>
    <Description("Alpha Value for HatchStyle so you can see the NULL Text through it")>
    <DefaultValue(150)>
    Public Property NullAlpha() As Integer
        Get
            Return _NullAlpha
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then value = 0
            If value > 255 Then value = 255
            _NullAlpha = value
            txbTime.NullAlpha = value
            Invalidate()
        End Set
    End Property

#End Region

#End Region

#Region "Mouse Event"

    Private Sub gTimePicker_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If rectDropDownButton.Contains(e.Location) Then
                ButtonHighlightAdjust.X = rectDropDownButton.Width - 4
                ButtonHighlightAdjust.Y = rectDropDownButton.Height - 5

                If IsPopupOpen Then
                    popup.Hide()
                    IsPopupOpen = False
                Else

                    popup.Show(Me, txbTime.Left + 10, txbTime.Bottom)
                    popup.BackColor = gTime.TimeColors.BackGround

                    IsPopupOpen = True
                End If
                Invalidate(rectDropDownButton)

            ElseIf rectAMPM.Contains(e.Location) Then
                AMPMHighlightAdjust.X = rectAMPM.Width - 4
                AMPMHighlightAdjust.Y = rectAMPM.Height - 5
                If TimeAMPM = gTimePickerCntrl.eTimeAMPM.am Then
                    TimeAMPM = gTimePickerCntrl.eTimeAMPM.pm
                Else
                    TimeAMPM = gTimePickerCntrl.eTimeAMPM.am
                End If

                Invalidate(rectAMPM)
            End If
        End If
    End Sub

    Private Sub gTimePicker_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Then

            ButtonHighlightAdjust = New Point(4, 4)
            AMPMHighlightAdjust = New Point(4, 4)

            Invalidate(Rectangle.Union(rectDropDownButton, rectAMPM))
        End If

    End Sub

#End Region

#Region "Popup"

    Private Sub popup_Opening(ByVal sender As Object, ByVal e As CancelEventArgs)
        tTime = Time
        RaiseEvent DropDown(Me, True)
    End Sub

    Private Sub popup_Closing(ByVal sender As Object,
      ByVal e As ToolStripDropDownClosingEventArgs)
        'Workaround Focus loss
        Try
            If (Not rectDropDownButton.Contains(PointToClient(Control.MousePosition)) _
                Or (e.CloseReason = ToolStripDropDownCloseReason.Keyboard)) Then
                IsPopupOpen = False
            End If
            RaiseEvent DropDown(Me, False)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub popup_Closed(ByVal sender As Object,
  ByVal e As ToolStripDropDownClosedEventArgs)
        If txbTime.EditingMode Then
            txbTime.Text = Time
            If tTime <> gTime.Time Then RaiseEvent TimePicked(Me)
        End If
        Invalidate()
    End Sub

#End Region

#Region "Key Event"

    Private Sub txbTime_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txbTime.KeyDown

        Select Case e.KeyCode
            Case Keys.Enter
                Time = txbTime.Text
                If _EnterTabsOut Then SendKeys.Send(Chr(9))
            Case Keys.Up
                e.Handled = True
                If e.Shift Then
                    AdjustHour()
                Else
                    AdjustMinute()
                End If
            Case Keys.Down
                e.Handled = True
                If e.Shift Then
                    AdjustHour(-1)
                Else
                    AdjustMinute(-1)
                End If

        End Select
    End Sub

    Public Sub AdjustHour(Optional ByVal HowMuch As Integer = 1)
        If IsNothing(Time) Or Time = String.Empty Then Exit Sub
        Dim tm As Integer = CInt(Val(Time.Substring(0, 2)) + HowMuch)
        Dim maxhour As Integer = CInt(IIf(Hr24, 23, 12))
        If tm > maxhour Then
            tm = CInt(IIf(Hr24, 0, 1))
            If Hr24 Then TimeAMPM = gTimePickerCntrl.eTimeAMPM.am
        ElseIf tm < CInt(IIf(Hr24, 0, 1)) Then
            tm = maxhour
            If Hr24 Then TimeAMPM = gTimePickerCntrl.eTimeAMPM.pm
        End If

        Time = String.Concat(Format(tm, "00").ToString, Time.Remove(0, 2))

    End Sub

    Public Sub AdjustMinute(Optional ByVal HowMuch As Integer = 1)
        If IsNothing(Time) Or Time = String.Empty Then Exit Sub
        Dim tm As Integer = CInt(Val(Time.Substring(3, 2)) + HowMuch)
        If tm > 59 Then
            tm = 0
            Time = String.Concat(Time.Remove(3, 2), Format(tm, "00").ToString)
            AdjustHour()
        ElseIf tm < 0 Then
            tm = 59
            Time = String.Concat(Time.Remove(3, 2), Format(tm, "00").ToString)
            AdjustHour(-1)
        Else
            Time = String.Concat(Time.Remove(3, 2), Format(tm, "00").ToString)

        End If
    End Sub

#End Region

#Region "Paint"

    Private Sub gTimePicker_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles Me.Paint
        DrawDropDownAndAmPmButton(e.Graphics)
    End Sub

    Private ButtonHighlightAdjust As Point = New Point(4, 4)
    Private AMPMHighlightAdjust As Point = New Point(4, 4)

    Public Sub DrawDropDownAndAmPmButton(ByRef g As Graphics)
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
        Dim sColor, hColor, bcolor, fcolor As Color
        If Enabled Then
            sColor = _ButtonBackColor
            hColor = _ButtonHighlight
            bcolor = _ButtonBorder
            fcolor = _ButtonForeColor
        Else
            sColor = Color.LightGray
            hColor = Color.White
            bcolor = Color.Gray
            fcolor = Color.Gray
        End If

        Using pn As Pen = New Pen(fcolor, 2)
            pn.StartCap = LineCap.Round
            pn.EndCap = LineCap.Round

            Dim gp As New GraphicsPath
            Dim gpButton As New GraphicsPath
            Dim gpAMPM As New GraphicsPath
            gpButton.AddRectangle(rectDropDownButton)
            gpAMPM.AddRectangle(rectAMPM)
            If IsPopupOpen Then
                gp.AddLine(rectDropDownButton.X + 5,
                           CInt(rectDropDownButton.Y + (rectDropDownButton.Height / 2) + 2),
                           CInt(rectDropDownButton.X + (rectDropDownButton.Width / 2)),
                           CInt(rectDropDownButton.Y + (rectDropDownButton.Height / 2) - 2))
                gp.AddLine(CInt(rectDropDownButton.X + (rectDropDownButton.Width / 2)),
                           CInt(rectDropDownButton.Y + (rectDropDownButton.Height / 2) - 2),
                           rectDropDownButton.X + rectDropDownButton.Width - 5,
                           CInt(rectDropDownButton.Y + (rectDropDownButton.Height / 2) + 2))
            Else
                gp.AddLine(rectDropDownButton.X + 5,
                           CInt(rectDropDownButton.Y + (rectDropDownButton.Height / 2) - 2),
                           CInt(rectDropDownButton.X + (rectDropDownButton.Width / 2)),
                           CInt(rectDropDownButton.Y + (rectDropDownButton.Height / 2) + 2))
                gp.AddLine(CInt(rectDropDownButton.X + (rectDropDownButton.Width / 2)),
                           CInt(rectDropDownButton.Y + (rectDropDownButton.Height / 2) + 2),
                           rectDropDownButton.X + rectDropDownButton.Width - 5,
                           CInt(rectDropDownButton.Y + (rectDropDownButton.Height / 2) - 2))
            End If
            Using pgbr As PathGradientBrush = New PathGradientBrush(gpButton)
                pgbr.CenterColor = hColor
                pgbr.CenterPoint = New PointF(rectDropDownButton.X + ButtonHighlightAdjust.X,
                                              rectDropDownButton.Y + ButtonHighlightAdjust.Y)
                pgbr.SurroundColors = New Color() {sColor}
                g.FillPath(pgbr, gpButton)
            End Using
            Using pgbr As PathGradientBrush = New PathGradientBrush(gpAMPM)
                pgbr.CenterColor = hColor
                pgbr.CenterPoint = New PointF(CSng(rectAMPM.X + AMPMHighlightAdjust.X),
                                              CSng(rectAMPM.Y + AMPMHighlightAdjust.Y))
                pgbr.SurroundColors = New Color() {sColor}
                g.FillPath(pgbr, gpAMPM)

            End Using
            g.DrawPath(pn, gp)
            g.DrawPath(New Pen(bcolor), gpButton)
            g.DrawPath(New Pen(bcolor), gpAMPM)
            Dim cAmPm As String
            cAmPm = TimeAMPM.ToString()
            If txbTime.EditingMode Then
                cAmPm = TimeAMPM.ToString()
            Else
                cAmPm = oldTimeAmPM.ToString()
            End If
            'oldTimeAmPM = TimeAMPM
            DrawRotatedText(g, IIf(_Font.Size < 10, cAmPm.Chars(0),
                                   cAmPm.ToString).ToString,
                            New Rectangle(Width - _rectDropDownButtonWidth - _rectAmPmWidth - 2, 0, rectAMPM.Height, rectAMPM.Width),
                            0, New Font("Arial", 10, FontStyle.Bold), fcolor)
            'DrawRotatedText(g, IIf(_Font.Size < 10, cAmPm.Chars(0),
            '    cAmPm.ToString).ToString,
            '    New Rectangle(0, 0, rectAMPM.Height, rectAMPM.Width),
            '    0, New Font("Arial", 10, FontStyle.Bold), fcolor)
            'New Rectangle(1, rectAMPM.Height, rectAMPM.Height, rectAMPM.Width),
            '-50, New Font("Arial", 10, FontStyle.Bold), fcolor)

            gpButton.Dispose()
            gpAMPM.Dispose()
            gp.Dispose()
        End Using

    End Sub

    Public Shared Sub DrawRotatedText(ByRef g As Graphics, ByVal TheString As String, ByVal rect As Rectangle, ByVal angle As Single, ByVal UseFont As Font, ByVal inColor As Color)
        ' Make a GraphicsPath that draws the text at (x, y).
        Dim sf As New StringFormat
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center
        Using graphics_path As New Drawing2D.GraphicsPath(Drawing.Drawing2D.FillMode.Winding)
            graphics_path.AddString(TheString, UseFont.FontFamily, UseFont.Style, UseFont.Size,
            rect, sf)
            ' Make a rotation matrix representing rotation around the point (x, y).
            Using rotation_matrix As New Drawing2D.Matrix()
                rotation_matrix.RotateAt(angle, New PointF(rect.X, rect.Y))
                ' Transform the GraphicsPath.
                graphics_path.Transform(rotation_matrix)
                ' Draw the text.
                Using thePen As Pen = New Pen(inColor)
                    g.FillPath(thePen.Brush, graphics_path)
                End Using

            End Using
        End Using
    End Sub

    Public Shared Sub DrawRotatedText(ByRef g As Graphics, ByVal TheString As String, ByVal x As Single, ByVal y As Single, ByVal angle As Single, ByVal UseFont As Font, ByVal inColor As Color)
        ' Make a GraphicsPath that draws the text at (x, y).
        Using graphics_path As New Drawing2D.GraphicsPath(Drawing.Drawing2D.FillMode.Winding)
            graphics_path.AddString(TheString, UseFont.FontFamily, UseFont.Style, UseFont.Size,
            New Point(CInt(x), CInt(y)), StringFormat.GenericDefault)
            ' Make a rotation matrix representing rotation around the point (x, y).
            Using rotation_matrix As New Drawing2D.Matrix()
                rotation_matrix.RotateAt(angle, New PointF(x, y))
                ' Transform the GraphicsPath.
                graphics_path.Transform(rotation_matrix)
                ' Draw the text.
                Using thePen As Pen = New Pen(inColor)
                    g.FillPath(thePen.Brush, graphics_path)
                End Using

            End Using
        End Using
    End Sub

#End Region

#Region "Resize"

    Private Sub gTimePicker_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Resize
        ResizeMe()
    End Sub

    Private Sub ResizeMe()
        Dim g As Graphics = CreateGraphics()
        Dim tsz As SizeF = g.MeasureString(txbTime.Text, txbTime.Font)
        If Width < (_rectAmPmWidth + _rectDropDownButtonWidth + tsz.Width + 2) Then
            Width = CInt(_rectAmPmWidth + _rectDropDownButtonWidth + tsz.Width + 2)
        End If
        Height = txbTime.Height
        txbTime.Left = 1
        txbTime.Width = Width - _rectAmPmWidth - _rectDropDownButtonWidth
        rectDropDownButton = New Rectangle(Width - _rectDropDownButtonWidth - 1, 0, _rectDropDownButtonWidth, Height - 1)
        rectAMPM = New Rectangle(Width - _rectDropDownButtonWidth - _rectAmPmWidth, 0, _rectAmPmWidth, Height - 1)
        Invalidate()

        'Dim g As Graphics = CreateGraphics()
        'Dim tsz As SizeF = g.MeasureString(txbTime.Text, txbTime.Font)
        'If Width < (_rectAmPmWidth + _rectDropDownButtonWidth + tsz.Width + 8) Then
        '    Width = CInt(_rectAmPmWidth + _rectDropDownButtonWidth + tsz.Width + 8)
        'End If
        'Height = txbTime.Height
        'txbTime.Left = _rectAmPmWidth + 1
        'txbTime.Width = Width - _rectAmPmWidth - _rectDropDownButtonWidth
        'rectDropDownButton = New Rectangle(Width - _rectDropDownButtonWidth - 1, 0, _rectDropDownButtonWidth, Height - 1)
        'rectAMPM = New Rectangle(0, 0, _rectAmPmWidth, Height - 1)
        'Invalidate()
    End Sub

#End Region

#Region "txbTime"

    Private Sub txbTime_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txbTime.KeyPress
        'Eliminate Beep
        If e.KeyChar = vbCr Then e.Handled = True : Time = txbTime.Text
    End Sub

    Private Sub txbTime_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles txbTime.Leave
        Time = txbTime.Text
    End Sub

    Private Sub txbTime_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txbTime.LostFocus
        If Time <> txbTime.Text Then
            If validateTime(txbTime.Text) Then
                Time = txbTime.Text
            Else
                txbTime.Text = Time
            End If
            'Dim retVal As Boolean = True
            ''If Not (cText = $"  :  :" Or cText = "") Then
            'If Not (txbTime.Text = $"  :  :" Or txbTime.Text = "") Then
            '    Dim sPattern = "([0-1]\d|2[0-3]):([0-5]\d)$"
            '    '"([0-1]\d|2[0-3]):([0-5]\d)$"
            '    Dim match As New Regex(sPattern)
            '    Dim bIsMatch As Boolean = match.IsMatch(txbTime.Text)
            '    If bIsMatch = False Then
            '        InformUserOfInvalidTime()
            '        txbTime.Text = gTime.Time
            '        'tTime = gTime.Time
            '        Time = gTime.Time
            '    Else
            '        Time = txbTime.Text
            '    End If
            'Else
            '    Time = txbTime.Text
            'End If
        End If
    End Sub

    Private Function validateTime(strTime As String) As Boolean
        Dim retVal As Boolean = True
        If strTime Is Nothing OrElse strTime = $"  :  :  " OrElse strTime = $"  :  " OrElse strTime = "" Then
            Return False
        End If
        'Dim sPattern = "^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$"
        Dim sPattern = "^(?:0?[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$"
        Dim match As New Regex(sPattern)
        Dim bIsMatch As Boolean = match.IsMatch(txbTime.Text)
        If bIsMatch = False Then
            InformUserOfInvalidTime()
            Return False
        End If
        Return True
    End Function

#End Region

#Region "Context menu"

    Private Sub Clear_Opening(ByVal sender As Object, ByVal e As CancelEventArgs) Handles Clear.Opening
        RaiseEvent ContextOpen(Me, True)
    End Sub

    Private Sub Clear_ItemClicked(ByVal sender As Object, ByVal e As ToolStripItemClickedEventArgs) Handles Clear.ItemClicked
        Time = Nothing
    End Sub

    Private Sub Clear_Closed(ByVal sender As Object, ByVal e As ToolStripDropDownClosedEventArgs) Handles Clear.Closed
        RaiseEvent ContextOpen(Me, False)
    End Sub

#End Region

End Class

Class gTimePickerDesigner
    Inherits ControlDesigner

    Public Overrides ReadOnly Property SelectionRules() _
  As SelectionRules
        Get
            Return SelectionRules.LeftSizeable _
                   Or SelectionRules.RightSizeable _
                   Or Windows.Forms.Design.SelectionRules.Visible _
                   Or Windows.Forms.Design.SelectionRules.Moveable
        End Get
    End Property

End Class