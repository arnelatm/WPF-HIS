Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.Drawing.Design
'Version 1.0 9-09

<System.Diagnostics.DebuggerStepThrough()> _
<ToolboxItem(False)> _
Public Class gTimeBox
    Inherits System.Windows.Forms.TextBox

#Region "NULL"

    Private _NullText As String = "NULL"
    <Category("Appearance NULL")> _
    <Description("Text to display when NULL")> _
    <DefaultValue("NULL")> _
    Public Property NullText() As String
        Get
            Return _NullText
        End Get
        Set(ByVal value As String)
            _NullText = value
            Invalidate()
        End Set
    End Property

    Private _NullTextInFront As Boolean
    <Category("Appearance NULL")> _
    <Description("Should the NULL text appear in front of the Hatch Fill")> _
    <DefaultValue(True)> _
    Public Property NullTextInFront() As Boolean
        Get
            Return _NullTextInFront
        End Get
        Set(ByVal value As Boolean)
            _NullTextInFront = value
            Invalidate()
        End Set
    End Property

    Private _NullTextColor As Color = Color.Black
    <Category("Appearance NULL")> _
    <Description("Color for the NULL Text")> _
    <DefaultValue("Black")> _
    Public Property NullTextColor() As Color
        Get
            Return _NullTextColor
        End Get
        Set(ByVal value As Color)
            _NullTextColor = value
            Invalidate()
        End Set
    End Property

    Private _NullHatchStyle As HatchStyle = Drawing2D.HatchStyle.WideDownwardDiagonal

    <Editor(GetType(HatchStyleEditor), GetType(UITypeEditor))> _
    <Category("Appearance NULL")> _
    <Description("Choose the HatchStyle")> _
    <DefaultValue("WideDownwardDiagonal")> _
    Public Property NullHatchStyle() As HatchStyle
        Get
            Return _NullHatchStyle
        End Get
        Set(ByVal value As HatchStyle)
            _NullHatchStyle = value
            Invalidate()
        End Set
    End Property

    Private _NullColorA As Color = Color.LightSteelBlue
    <Category("Appearance NULL")> _
    <Description("Color A for the HatchStyle")> _
    <DefaultValue("LightSteelBlue")> _
    Public Property NullColorA() As Color
        Get
            Return _NullColorA
        End Get
        Set(ByVal value As Color)
            _NullColorA = value
            Invalidate()
        End Set
    End Property

    Private _NullColorB As Color = Color.White
    <Category("Appearance NULL")> _
    <Description("Color B for the HatchStyle")> _
    <DefaultValue("White")> _
    Public Property NullColorB() As Color
        Get
            Return _NullColorB
        End Get
        Set(ByVal value As Color)
            _NullColorB = value
            Invalidate()
        End Set
    End Property

    Private _NullAlpha As Integer = 150
    <Category("Appearance NULL")> _
    <Description("Alpha Value for HatchStyle so you can see the NULL Text through it")> _
    <DefaultValue(150)> _
    Public Property NullAlpha() As Integer
        Get
            Return _NullAlpha
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then value = 0
            If value > 255 Then value = 255
            _NullAlpha = value
            Invalidate()
        End Set
    End Property

#End Region

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)

        MyBase.WndProc(m)
        Const WM_PAINT As Integer = &HF
        If m.Msg = WM_PAINT Then

            If Text.Length <> 0 Then
                Return
            End If
            Using g As Graphics = CreateGraphics()
                g.SmoothingMode = SmoothingMode.AntiAlias
                g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
                g.Clear(BackColor)
                If Not _NullTextInFront Then _
                    g.DrawString(_NullText, New Font(Font.Name, Font.Size, FontStyle.Bold), _
                    New SolidBrush(_NullTextColor), 0, 0)
                g.FillRectangle(New HatchBrush(_NullHatchStyle, Color.FromArgb(_NullAlpha, _NullColorA), _
                    Color.FromArgb(_NullAlpha, _NullColorB)), ClientRectangle)
                If _NullTextInFront Then _
                    g.DrawString(_NullText, New Font(Font.Name, Font.Size, FontStyle.Bold), _
                    New SolidBrush(_NullTextColor), 0, 0)
            End Using
        End If
    End Sub

    Private Sub gTimeBox_MouseDoubleClick(ByVal sender As Object, _
      ByVal e As System.Windows.Forms.MouseEventArgs) _
      Handles Me.MouseDoubleClick
        Text = String.Format("{0:0#}:{1:0#}", Now.Hour, Now.Minute)
        Invalidate()
    End Sub

    Private Sub gTimeBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.TextChanged
        If Text = "" Or Text.Length = 1 Then Invalidate()
    End Sub
End Class

