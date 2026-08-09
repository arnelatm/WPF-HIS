Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Design
Imports System.Windows.Forms

'Version 1.0 9-09
'Version 1.1 7-10 Minor bug fixes to the Nullable value
'Version 1.2 11-19 Added RaiseEvent ValueOrNullChanged to Delete Key Pressed

<ToolboxItem(True), ToolboxBitmap(GetType(DateTimePicker))>
<DefaultEvent("ValueOrNullChanged")>
<System.Diagnostics.DebuggerStepThrough()>
Public Class gDateTimePicker
    Inherits System.Windows.Forms.DateTimePicker
    Private WithEvents Clear As New ContextMenuStrip

    Public Event ValueOrNullChanged(ByVal sender As Object)

#Region "New"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Clear.Items.Add("Clear Date")
        ContextMenuStrip = Clear
        Format = DateTimePickerFormat.Custom
        CustomFormat = "MM/dd/yyyy"

    End Sub

#End Region

#Region "Value & Format"

    Private _gValue As Nullable(Of DateTime) = Today

    <Editor(GetType(NullableDateTimeTypeEditor), GetType(UITypeEditor))>
    <Bindable(True)>
    <Category("Appearance")>
    Public Property gValue() As Nullable(Of DateTime)
        Get
            Return _gValue
        End Get

        Set(ByVal value As Nullable(Of DateTime))
            CheckFormat(value)
            Dim changed As Boolean = Not _gValue.Equals(value) And value.HasValue
            _gValue = value
            If _gValue.HasValue Then
                MyBase.Value = CDate(_gValue)
            End If
            If changed Then RaiseEvent ValueOrNullChanged(Me)
        End Set
    End Property

    Public Function ValueToString(Optional ByVal Format As DateTimePickerFormat = Nothing) As String
        If _gValue.HasValue Then
            If Format = Nothing Then Format = _gFormat
            Select Case Format
                Case DateTimePickerFormat.Custom
                    Return MyBase.Value.ToString(_gFormatString)
                Case DateTimePickerFormat.Long
                    Return MyBase.Value.ToLongDateString
                Case DateTimePickerFormat.Short
                    Return MyBase.Value.ToShortDateString
                Case Else
                    Return MyBase.Value.ToString
            End Select
        Else
            Return Nothing
        End If
    End Function

    Private _gFormatString As String = "MM/dd/yyyy"

    <Category("Appearance")>
    Public Property gFormatString() As String
        Get
            Return _gFormatString
        End Get
        Set(ByVal value As String)
            Try
                _gFormatString = value
                CheckFormat(_gValue)
                Invalidate()
            Catch ex As Exception

            End Try
        End Set
    End Property

    Private _gFormat As DateTimePickerFormat = DateTimePickerFormat.Custom

    <Category("Appearance")>
    Public Property gFormat() As DateTimePickerFormat
        Get
            Return _gFormat
        End Get
        Set(ByVal value As DateTimePickerFormat)
            Try
                _gFormat = value
                CheckFormat(_gValue)
                Invalidate()
            Catch ex As Exception

            End Try
        End Set
    End Property

    Sub CheckFormat(ByVal value As Nullable(Of DateTime))

        If Not value.HasValue Then
            Format = DateTimePickerFormat.Custom
            CustomFormat = " "
        Else
            Format = _gFormat
            CustomFormat = _gFormatString
        End If
    End Sub

#End Region

#Region "Hidden"

    <Browsable(False)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    <EditorBrowsable(EditorBrowsableState.Never)>
    Public Shadows Property Value() As DateTime
        Get
            Return MyBase.Value
        End Get
        Set(ByVal value As DateTime)
            MyBase.Value = value
        End Set
    End Property

    <Browsable(False)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    <EditorBrowsable(EditorBrowsableState.Never)>
    Public Shadows Property Format() As DateTimePickerFormat
        Get
            Return MyBase.Format
        End Get
        Set(ByVal value As DateTimePickerFormat)
            MyBase.Format = value
        End Set
    End Property

    <Browsable(False)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    <EditorBrowsable(EditorBrowsableState.Never)>
    Public Shadows Property CustomFormat() As String
        Get
            Return MyBase.CustomFormat
        End Get
        Set(ByVal value As String)
            MyBase.CustomFormat = value
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
            Invalidate()
        End Set
    End Property

    Private _BackFillColor As Color = SystemColors.Window

    <Category("Appearance")>
    Public Property BackFillColor() As Color
        Get
            Return _BackFillColor
        End Get
        Set(ByVal value As Color)
            _BackFillColor = value
            Invalidate()
        End Set
    End Property

#End Region

#Region "Overrides"

    Protected Overrides Sub OnCloseUp(ByVal eventargs As EventArgs)
        If Control.MouseButtons = MouseButtons.None Or Control.MouseButtons = Windows.Forms.MouseButtons.Left Then
            Dim Raise As Boolean = (Not _gValue.HasValue)
            gValue = MyBase.Value
            If Raise Then RaiseEvent ValueOrNullChanged(Me)
        End If
        MyBase.OnCloseUp(eventargs)
    End Sub

    Protected Overloads Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)
        MyBase.OnKeyDown(e)

        If e.KeyCode = Keys.Delete Then
            gValue = Nothing
            RaiseEvent ValueOrNullChanged(Me)
        End If

    End Sub

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)

        MyBase.WndProc(m)
        Const WM_ERASEBKGND As Integer = &H14
        If m.Msg = WM_ERASEBKGND Then
            Using g As Graphics = CreateGraphics()
                g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
                g.SmoothingMode = SmoothingMode.AntiAlias
                If Not _gValue.HasValue Then
                    'Reduce the ClientRectangle so the dropdown button won't get
                    'erased when something else covers part of the control
                    Dim meRect As Rectangle = New Rectangle(ClientRectangle.X, ClientRectangle.Y,
                        ClientRectangle.Width - 18, ClientRectangle.Height)
                    Using backBrush As New SolidBrush(_BackFillColor),
                        nullTextFont As New Font(Font.Name, Font.Size, FontStyle.Bold),
                        nullTextBrush As New SolidBrush(_NullTextColor),
                        hatchBrush As New HatchBrush(_NullHatchStyle,
                                                     Color.FromArgb(_NullAlpha, _NullColorA),
                                                     Color.FromArgb(_NullAlpha, _NullColorB))
                        g.FillRectangle(backBrush, meRect)
                        If Not _NullTextInFront Then
                            g.DrawString(_NullText, nullTextFont, nullTextBrush, 0, 0)
                        End If
                        g.FillRectangle(hatchBrush, meRect)
                        If _NullTextInFront Then
                            g.DrawString(_NullText, nullTextFont, nullTextBrush, 0, 0)
                        End If
                    End Using
                End If
            End Using
            Return
        End If

    End Sub

    Protected Overrides Sub OnValueChanged(ByVal eventargs As System.EventArgs)
        MyBase.OnValueChanged(eventargs)

        _gValue = MyBase.Value
        RaiseEvent ValueOrNullChanged(Me)

    End Sub

#End Region

#Region "Context menu"

    Private Sub Clear_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles Clear.ItemClicked
        If gValue.HasValue Then
            gValue = Nothing
            RaiseEvent ValueOrNullChanged(Me)
        End If

    End Sub

#End Region

End Class
