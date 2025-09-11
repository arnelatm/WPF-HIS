#Region "Imports"

Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Design
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports AATM.Libraries.Messaging

#End Region

'SSDiver2112
'May 2008
'July 2008
'   Added ButtonArea region detection and click event
'September 2008
'   Updated Poperties to use UITypeEditors and ControlDesigner
'   For a detailed Explanation on UITypeEditors Go Here http://www.codeproject.com/KB/miscctrl/UITypeEditorsDemo.aspx
'   Added Triangular Buttons
'September 2008
'   Button Area Click Fix
'October 2008
'   Added Enable/Disable Feature
'December 2008
'   Updated the Center and Focal Points to be edited directly on the control at Design Time.
'   Updated the FocalPoints and Corners Expandable classes to play nicer in the PropertyGrid
'   Activated Option Scrict ON
'January 2009
'   Added Mnemonic Keys based on NfErNo's suggestion.
'April 2009
'   Added SendMessage for click through non button area.
'November 2009
'   Added Key events based on getholdofphil's suggestion.
'   Fixed focus problem
'July 2010
'   switched the Disable Image routine to ControlPaint method
'   Added TextSmoothingMode property
'   Added SideImageClicked Event
'   Changed the ClickButtonArea EventArgs to MouseEventArgs to pass the mouse button easier
'December 2011
'   Added IButtonControl Interface for PerformClick and DialogResult
'   Added BlendItemsConverter to the cBlendItem Type
'January 2013
'Visual Studio 2012 Update
'March 2014
'Visual Studio 2013 Update
'March 2015
'Added ShowFocus property
'April 2015
'Updated the Designer with Adorners and Glyphs

#Region "CButton Class"

''' <summary>
''' Custom Button Control with Gradient Colors and Extra Image (VB.NET)
''' </summary>
''' <remarks>v3.5</remarks>
<ToolboxItem(True), ToolboxBitmap(GetType(CButton), "CButton.bmp")>
<DefaultEvent("ClickButtonArea")>
<Designer(GetType(CButtonDesigner))>
Public Class CButton
    Inherits Control
    Implements IButtonControl

    'Private _viewable As Boolean
    'Private _selectable As Boolean

#Region " IButtonControl Implementation "

    Private m_DialogResult As DialogResult
    Private m_IsDefault As Boolean

    <Browsable(False)>
    Public ReadOnly Property IsDefault() As Boolean
        Get
            Return m_IsDefault
        End Get
    End Property

    <Category("Behavior"), DefaultValue(GetType(DialogResult), "None"), Description("The dialog result produced in a modal form by clicking the button.")>
    Public Property DialogResult() As DialogResult Implements IButtonControl.DialogResult
        Get
            Return m_DialogResult
        End Get
        Set(ByVal Value As DialogResult)
            If [Enum].IsDefined(GetType(DialogResult), Value) Then
                m_DialogResult = Value
            End If
        End Set
    End Property

    Public Sub NotifyDefault(ByVal value As Boolean) Implements IButtonControl.NotifyDefault
        If m_IsDefault <> value Then
            m_IsDefault = value
        End If
        Invalidate()
    End Sub

    Public Sub PerformClick() Implements IButtonControl.PerformClick
        If CanSelect Then
            PerformClickButtonArea(Me, New MouseEventArgs(Windows.Forms.MouseButtons.Left, 1, CInt(ButtonArea.X), CInt(ButtonArea.Y), 0))
        End If
    End Sub

    Private Sub PerformClickButtonArea(ByVal Sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If m_DialogResult <> Windows.Forms.DialogResult.None Then
            If FindForm() IsNot Nothing Then
                FindForm.DialogResult = m_DialogResult
            End If
        End If
        If Not DisplayOnly Then
            RaiseEvent ClickButtonArea(Sender, e)
        Else
            Beep()
            MessagingService.Show(True, "MsgSecurityError")

        End If
    End Sub

#End Region

#Region "Declarations"

    Private _displayOnly As Boolean
    Private MouseDrawState As eMouseDrawState = eMouseDrawState.Up
    Private PressedOffset As Integer
    Private Imagept As PointF
    Public ButtonArea As RectangleF
    Public TextArea As RectangleF
    Private ImageArea As RectangleF
    Private ImageSizeUse As Size

    Private _HoverColorBlend As Color()
    Private _ClickColorBlend As Color()
    Private _DisabledBlend As Color()
    Private _HoverColorSolid As Color
    Private _ClickColorSolid As Color
    Private _DisabledSolid As Color
    Private rectSideImage As Rectangle

    'Add a new Click event for only when the ButtonArea or SideImage is Clicked
    Public Event ClickButtonArea(ByVal Sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

    Public Event ButtonAreaUP(ByVal Sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

    Public Event ButtonAreaDown(ByVal Sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

    Public Event SideImageClicked(ByVal Sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)

    'API to allow Click through on the space around buttonarea
    Private Const WM_LBUTTONDBLCLK As Integer = 515

    Private Const WM_LBUTTONDOWN As Integer = 513
    Private Const WM_LBUTTONUP As Integer = 514
    Private Const WM_MBUTTONDBLCLK As Integer = 521
    Private Const WM_MBUTTONDOWN As Integer = 519
    Private Const WM_MBUTTONUP As Integer = 520
    Private Const WM_MOUSEMOVE As Integer = 512
    Private Const WM_RBUTTONDBLCLK As Integer = 518
    Private Const WM_RBUTTONDOWN As Integer = 516
    Private Const WM_RBUTTONUP As Integer = 517

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    End Function

#End Region

#Region "New"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        SetStyle(ControlStyles.StandardClick Or ControlStyles.StandardDoubleClick Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.Selectable Or ControlStyles.DoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.UserPaint, True)

        Size = New Size(90, 25)
        ForeColor = Color.White
        Font = New Font("Arial", 10, FontStyle.Bold)
        SetAutoSizeMode(AutoSizeMode.GrowOnly)
        UpdateDimColors()
        UpdateDimBlends()

        'AddHandler DoubleClick, AddressOf ButtonDoubleClick
    End Sub

    'Public Sub ButtonDoubleClick(sender As Object, e As EventArgs)
    '    Debugger.Break()
    'End Sub

    'Public Shadows Sub OnMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '    Debugger.Break()
    'End Sub

    Public Sub New(ByVal text As String)
        MyBase.New(text)
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.Selectable Or ControlStyles.DoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.UserPaint, True)
        Size = New Size(90, 25)
        ForeColor = Color.White
        Font = New Font("Arial", 10, FontStyle.Bold)
        UpdateDimColors()
        UpdateDimBlends()
    End Sub

    Public Sub New(ByVal text As String, ByVal left As Integer, ByVal top As Integer, ByVal width As Integer, ByVal height As Integer)
        MyBase.New(text, left, top, width, height)
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.Selectable Or ControlStyles.DoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.UserPaint, True)
        Size = New Size(90, 25)
        ForeColor = Color.White
        Font = New Font("Arial", 10, FontStyle.Bold)
        UpdateDimColors()
        UpdateDimBlends()
    End Sub

    Public Sub New(ByVal parent As Control, ByVal text As String)
        MyBase.New(parent, text)
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.Selectable Or ControlStyles.DoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.UserPaint, True)
        Size = New Size(90, 25)
        ForeColor = Color.White
        Font = New Font("Arial", 10, FontStyle.Bold)
        UpdateDimColors()
        UpdateDimBlends()
    End Sub

    Public Sub New(ByVal parent As Control, ByVal text As String, ByVal left As Integer, ByVal top As Integer, ByVal width As Integer, ByVal height As Integer)
        MyBase.New(parent, text, left, top, width, height)
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.Selectable Or ControlStyles.DoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.SupportsTransparentBackColor Or ControlStyles.UserPaint, True)
        Size = New Size(90, 25)
        ForeColor = Color.White
        Font = New Font("Arial", 10, FontStyle.Bold)
        UpdateDimColors()
        UpdateDimBlends()
    End Sub

    <DefaultValue(GetType(Font), "Arial, 10pt, style=Bold")>
    Public Overrides Property Font() As Font
        Get
            Return (MyBase.Font)
        End Get
        Set(ByVal value As Font)
            MyBase.Font = value
        End Set
    End Property

    <DefaultValue(GetType(Color), "White")>
    Public Overrides Property ForeColor() As Color
        Get
            Return (MyBase.ForeColor)
        End Get
        Set(ByVal value As Color)
            MyBase.ForeColor = value
        End Set
    End Property

#End Region

#Region "Properties"

    Enum eMouseDrawState
        Over
        Down
        Up
    End Enum

    Public Property OriginalImageName As String

    '<Category("Custom Properties")>
    '<DefaultValue(False)>
    '<Description("Set to True to specify that this button cannot be selected or executed.")>
    '<Browsable(True)>
    'Public Property Selectable As Boolean
    '    Get
    '        Return _selectable
    '    End Get
    '    Set
    '        _selectable = Value
    '        Enabled = Value
    '    End Set
    'End Property

    <Category("Custom Properties")>
    <DefaultValue(False)>
    <Description("Set to True to specify that this control is Read Only .")>
    <Browsable(True)>
    Public Property DisplayOnly As Boolean
        Get
            Return _displayOnly
        End Get
        Set(value As Boolean)
            If _displayOnly = value Then Exit Property
            _displayOnly = value
        End Set
    End Property

    '<Category("Custom Properties")>
    '<DefaultValue(False)>
    '<Description("Set to True to specify that this control value will be shown.")>
    '<Browsable(True)>
    'Public Property Viewable As Boolean
    '    Get
    '        Return _viewable
    '    End Get
    '    Set
    '        _viewable = Value
    '        Visible = Value
    '    End Set
    'End Property

    <Category("Custom Properties")>
    <DefaultValue(False)>
    <Description("Set to True to specify that this control value will be shown.")>
    <Browsable(True)>
    Public Property Editable As Boolean

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    <Description("Security Key to use for this control.")>
    <Browsable(True)>
    Public Property SecurityKey As String = ""

#Region "Designer"

    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never)>
    Public Property DesignerSelected As Boolean

#End Region

#Region "Shape"

#Region "Corners Expandable Property"

    'Corners Property is defined in the Corners Converter Class
    'to use the ExpandableObjectConverter to simulate the Padding Property

    Private _Corners As CornersProperty = DefaultCorners()

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
    <Category("Appearance CButton"), Description("Get or Set the Corner Radii")>
    Public Property Corners() As CornersProperty
        Get
            Return _Corners
        End Get
        Set(ByVal Value As CornersProperty)
            _Corners = Value
            Invalidate()
        End Set
    End Property

    Private Function DefaultCorners() As CornersProperty
        Return New CornersProperty(0)
    End Function

#Region "Corners Default Value"

    Public Sub ResetCorners()
        Corners = DefaultCorners()
    End Sub

    Private Function ShouldSerializeCorners() As Boolean
        Return Not (_Corners.Equals(DefaultCorners))
    End Function

#End Region

#End Region 'Corners Expandable Property

    Enum eShape
        Ellipse
        Rectangle
        TriangleUp
        TriangleDown
        TriangleLeft
        TriangleRight
    End Enum

    Private _Shape As eShape = eShape.Rectangle

    ''' <summary>
    ''' The Shape of the Button as eShape choices (Ellipse, Rectangle, and Triangles)
    ''' </summary>
    <Category("Appearance CButton")>
    <Description("The Shape of the Button as eShape choices (Ellipse, Rectangle, and Triangles)")>
    <DefaultValue(GetType(eShape), "Rectangle")>
    Public Property Shape() As eShape
        Get
            Return _Shape
        End Get
        Set(ByVal value As eShape)
            _Shape = value
            Invalidate()
        End Set
    End Property

#End Region 'Shape

#Region "DimFactor"

    Private _DimFactorHover As Integer = 50

    ''' <summary>
    ''' Get or Set how much to dim the color on mouse rollover. Positive to Lighten and negative to Darken
    ''' </summary>
    <Category("Appearance CButton")>
    <Description("Get or Set how much to dim the color on mouse rollover. Positive to Lighten and negative to Darken")>
    <DefaultValue(50)>
    Public Property DimFactorHover() As Integer
        Get
            Return _DimFactorHover
        End Get
        Set(ByVal Value As Integer)
            _DimFactorHover = Value
            UpdateDimBlends()
            UpdateDimColors()
            Invalidate()
        End Set
    End Property

    Private _DimFactorClick As Integer = -25

    ''' <summary>
    ''' Get or Set how much to dim the color on mouse down. Positive to Lighten and negative to Darken
    ''' </summary>
    <Category("Appearance CButton")>
    <Description("Get or Set how much to dim the color on mouse down. Positive to Lighten and negative to Darken")>
    <DefaultValue(-25)>
    Public Property DimFactorClick() As Integer
        Get
            Return _DimFactorClick
        End Get
        Set(ByVal Value As Integer)
            _DimFactorClick = Value
            UpdateDimBlends()
            UpdateDimColors()
            Invalidate()
        End Set
    End Property

#End Region 'DimFactor

#Region "Border"

    Private _BorderColor As Color = Color.SteelBlue

    ''' <summary>
    ''' Get or Set the Border color
    ''' </summary>
    <Category("Appearance CButton")>
    <Description("Get or Set to show the Border")>
    <DefaultValue(GetType(Color), "SteelBlue")>
    Public Property BorderColor() As Color
        Get
            Return _BorderColor
        End Get
        Set(ByVal Value As Color)
            _BorderColor = Value
            Invalidate()
        End Set
    End Property

    Private _BorderShow As Boolean = True

    ''' <summary>
    ''' Get or Set whether to show the Border
    ''' </summary>
    <Category("Appearance CButton")>
    <Description("Get or Set whether to show the Border")>
    <DefaultValue(True)>
    Public Property BorderShow() As Boolean
        Get
            Return _BorderShow
        End Get
        Set(ByVal Value As Boolean)
            _BorderShow = Value
            Invalidate()
        End Set
    End Property

#End Region 'Border

#Region "Focus"

    Enum eFocus
        [Dot]
        [Dim]
        [None]
    End Enum

    Private _ShowFocus As eFocus = eFocus.Dot

    ''' <summary>
    ''' Get or Set the Focus queue
    ''' </summary>
    <Category("Appearance CButton")>
    <Description("Get or Set the Focus queue")>
    <DefaultValue(GetType(eFocus), "Dot")>
    Public Property ShowFocus() As eFocus
        Get
            Return _ShowFocus
        End Get
        Set(ByVal Value As eFocus)
            _ShowFocus = Value
            Invalidate()
        End Set
    End Property

#End Region 'Show Focus

#Region "Fill"

    Enum eFillType
        Solid
        GradientLinear
        GradientPath
    End Enum

    Private _FillType As eFillType = eFillType.GradientLinear

    ''' <summary>
    ''' The eFillType Fill Type to apply to the CButton
    ''' </summary>
    <Description("The Fill Type to apply to the CButton")>
    <Category("Appearance CButton")>
    <DefaultValue(GetType(eFillType), "GradientLinear")>
    Public Property FillType() As eFillType
        Get
            Return _FillType
        End Get
        Set(ByVal value As eFillType)
            _FillType = value
            Invalidate()
        End Set
    End Property

    Private _FillTypeLinear As LinearGradientMode = LinearGradientMode.Vertical

    ''' <summary>
    ''' The Linear Blend type
    ''' </summary>
    <Description("The Linear Blend type"), Category("Appearance CButton")>
    <DefaultValue(GetType(LinearGradientMode), "Vertical")>
    Public Property FillTypeLinear() As LinearGradientMode
        Get
            Return _FillTypeLinear
        End Get
        Set(ByVal value As LinearGradientMode)
            _FillTypeLinear = value
            Invalidate()
        End Set
    End Property

    Private _ColorFillSolid As Color = SystemColors.Control

    ''' <summary>
    ''' The Solid Color to fill the CButton
    ''' </summary>
    <Description("The Solid Color to fill the CButton"), Category("Appearance CButton")>
    <DefaultValue(GetType(Color), "Control")>
    Public Property ColorFillSolid() As Color
        Get
            Return _ColorFillSolid
        End Get
        Set(ByVal value As Color)
            _ColorFillSolid = value
            UpdateDimColors()
            Invalidate()
        End Set
    End Property

    Private _ColorFillBlend As cBlendItems = DefaultColorFillBlend()

    ''' <summary>
    ''' The ColorBlend used to fill the CButton
    ''' </summary>
    <Description("The ColorBlend used to fill the CButton"), Category("Appearance CButton"), RefreshProperties(RefreshProperties.All), Editor(GetType(BlendTypeEditor), GetType(UITypeEditor))>
    Public Property ColorFillBlend() As cBlendItems
        Get
            Return _ColorFillBlend
        End Get
        Set(ByVal value As cBlendItems)
            If value.iColor.Length = value.iPoint.Length Then
                value.iPoint(0) = 0
                value.iPoint(value.iPoint.Length - 1) = 1
                _ColorFillBlend = value
            Else
                MsgBox("The number of colors must match the number of positions. The blend will be reset")
                Exit Property
            End If
            UpdateDimBlends()
            Invalidate()
        End Set
    End Property

    Private Function DefaultColorFillBlend() As cBlendItems
        Return New cBlendItems(New Color() {Color.AliceBlue, Color.RoyalBlue, Color.Navy}, New Single() {0, 0.5, 1})
    End Function

#Region "ColorFillBlend Default Value"

    Public Sub ResetColorFillBlend()
        ColorFillBlend = DefaultColorFillBlend()
    End Sub

    Private Function ShouldSerializeColorFillBlend() As Boolean
        Return Not (_ColorFillBlend.Equals(DefaultColorFillBlend))
    End Function

#End Region

#End Region 'Fill

#Region "Text"

    Private _Text As String = "CButton"

    ''' <summary>
    ''' Get or Set the Button Text
    ''' </summary>
    <Category("Appearance CButton"), Description("Get or Set the Button Text"), DefaultValue("CButton")>
    Overrides Property Text() As String
        Get
            Return _Text
        End Get
        Set(ByVal value As String)
            _Text = value
            Invalidate()
        End Set
    End Property

    Private _TextSmoothingMode As Drawing.Text.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

    ''' <summary>
    ''' Get or Set the TextrenderingHint fot the button text
    ''' </summary>
    <Category("Appearance CButton"), Description("Get or Set if the text is rendered with a Smoothing technique"), DefaultValue(GetType(Drawing.Text.TextRenderingHint), "ClearTypeGridFit")>
    Public Property TextSmoothingMode() As Drawing.Text.TextRenderingHint
        Get
            Return _TextSmoothingMode
        End Get
        Set(ByVal Value As Drawing.Text.TextRenderingHint)
            _TextSmoothingMode = Value
            Invalidate()
        End Set
    End Property

    Private _TextAlign As ContentAlignment = ContentAlignment.MiddleCenter

    ''' <summary>
    ''' Get or Set the alignment for the text
    ''' </summary>
    <Category("Appearance CButton"), Description("Get or Set the alignment for the text"), DefaultValue(GetType(ContentAlignment), "MiddleCenter")>
    Public Property TextAlign() As ContentAlignment
        Get
            Return _TextAlign
        End Get
        Set(ByVal Value As ContentAlignment)
            _TextAlign = Value
            Invalidate()
        End Set
    End Property

    Private _TextMargin As Padding = New Padding(2)

    ''' <summary>
    ''' Get or Set the margion between the text and the button edge
    ''' </summary>
    <Category("Appearance CButton"), Description("Get or Set the margion between the text and the button edge"), DefaultValue(GetType(Padding), "2,2,2,2")>
    Public Property TextMargin() As Padding
        Get
            Return _TextMargin
        End Get
        Set(ByVal Value As Padding)
            _TextMargin = Value
            Invalidate()
        End Set
    End Property

    Private _TextImageRelation As TextImageRelation = TextImageRelation.Overlay

    ''' <summary>
    ''' Get or Set the Relationship of the Text to the Image
    ''' </summary>
    <Category("Appearance CButton"), Description("Get or Set the Relationship of the Text to the Image"), DefaultValue(GetType(TextImageRelation), "Overlay")>
    Public Property TextImageRelation() As TextImageRelation
        Get
            Return _TextImageRelation
        End Get
        Set(ByVal Value As TextImageRelation)
            _TextImageRelation = Value
            Invalidate()
        End Set
    End Property

    Private _TextShadowShow As Boolean = True

    ''' <summary>
    ''' Get or Set if the Text has a shadow
    ''' </summary>
    <Category("Appearance CButton"), Description("Get or Set if the Text has a shadow"), DefaultValue(True)>
    Public Property TextShadowShow() As Boolean
        Get
            Return _TextShadowShow
        End Get
        Set(ByVal Value As Boolean)
            _TextShadowShow = Value
            Invalidate()
        End Set
    End Property

    Private _TextShadow As Color = Color.MidnightBlue

    ''' <summary>
    ''' Get or Set the color of the Shadow Text
    ''' </summary>
    <Category("Appearance CButton"), Description("Get or Set the color of the Shadow Text"), DefaultValue(GetType(Color), "MidnightBlue")>
    Public Property TextShadow() As Color
        Get
            Return _TextShadow
        End Get
        Set(ByVal Value As Color)
            _TextShadow = Value
            Invalidate()
        End Set
    End Property

#End Region 'Text

#Region "Image"

    Private _Image As Image

    ''' <summary>
    ''' Get or Set the small Image next to text
    ''' </summary>
    <Category("Appearance CButton"), Description("Get or Set the small Image next to text")>
    <DefaultValue(GetType(Image), "none")>
    Public Property Image() As Image
        Get
            Return _Image
        End Get
        Set(ByVal Value As Image)
            _Image = Value
            Invalidate()
        End Set
    End Property

    Private _ImageAlign As ContentAlignment = ContentAlignment.MiddleCenter

    ''' <summary>
    ''' Get or Set the placement of the Image
    ''' </summary>
    <Category("Appearance CButton"), Description("Get or Set the placement of the Image"), DefaultValue(GetType(ContentAlignment), "MiddleCenter")>
    Public Property ImageAlign() As ContentAlignment
        Get
            Return _ImageAlign
        End Get
        Set(ByVal Value As ContentAlignment)
            _ImageAlign = Value
            Invalidate()
        End Set
    End Property

    Private _ImageSize As Size = New Size(16, 16)

    ''' <summary>
    ''' Get or Set the Size of the Image
    ''' </summary>
    <Category("Appearance CButton"), Description("Get or Set the Size of the Image"), DefaultValue(GetType(Size), "16, 16")>
    Public Property ImageSize() As Size
        Get
            Return _ImageSize
        End Get
        Set(ByVal Value As Size)
            _ImageSize = Value
            Invalidate()
        End Set
    End Property

    Private _Imagelist As New ImageList

    ''' <summary>
    ''' Get or Set the ImageList control
    ''' </summary>
    <Category("Appearance CButton"), Description("Get or Set the ImageList control")>
    Public Property Imagelist() As ImageList
        Get
            Return _Imagelist
        End Get
        Set(ByVal Value As ImageList)
            _Imagelist = Value
            Invalidate()
        End Set
    End Property

    Private _ImageIndex As Integer

    ''' <summary>
    ''' Get or Set the ImageList control
    ''' </summary>
    <Category("Appearance CButton"), Description("Get or Set the ImageList control")>
    Public Property ImageIndex() As Integer
        Get
            Return _ImageIndex
        End Get
        Set(ByVal Value As Integer)
            If Imagelist.Images.Count > 0 Then
                If Value >= 0 And Value < Imagelist.Images.Count Then
                    _ImageIndex = Value
                    Image = Imagelist.Images.Item(Value)
                    Invalidate()
                End If
            End If
        End Set
    End Property

#End Region 'Image

#Region "SideImage"

    Private _SideImage As Image

    ''' <summary>
    ''' Get or Set the Side Image
    ''' </summary>
    <Category("Appearance CButton"), Description("Get or Set the Side Image")>
    <DefaultValue(GetType(Image), "none")>
    Public Property SideImage() As Image
        Get
            Return _SideImage
        End Get
        Set(ByVal Value As Image)
            _SideImage = Value
            If Not Value Is Nothing Then
                _SideImageSize = Value.Size
            End If
            Invalidate()
        End Set
    End Property

    Private _SideImageSize As Size = New Size(48, 48)

    ''' <summary>
    ''' Get or Set the Size of the Side Image
    ''' </summary>
    <Category("Appearance CButton"), Description("Get or Set the Size of the Side Image"), DefaultValue(GetType(Size), "48, 48")>
    Public Property SideImageSize() As Size
        Get
            Return _SideImageSize
        End Get
        Set(ByVal Value As Size)
            _SideImageSize = Value
            Invalidate()
        End Set
    End Property

    Private _SideImageIsClickable As Boolean

    ''' <summary>
    ''' Get or Set if the Side Image raises its own click event
    ''' </summary>
    <Category("Appearance CButton"), Description("Get or Set if the Side Image raises its own click event"), DefaultValue(False)>
    Public Property SideImageIsClickable() As Boolean
        Get
            Return _SideImageIsClickable
        End Get
        Set(ByVal Value As Boolean)
            _SideImageIsClickable = Value
        End Set
    End Property

    Private _SideImageBehindText As Boolean = True

    ''' <summary>
    ''' Get or Set if the Side Image is in front or behind the Text
    ''' </summary>
    <Category("Appearance CButton"), Description("Get or Set if the Side Image is in front or behind the Text"), DefaultValue(True)>
    Public Property SideImageBehindText() As Boolean
        Get
            Return _SideImageBehindText
        End Get
        Set(ByVal Value As Boolean)
            _SideImageBehindText = Value
            Invalidate()
        End Set
    End Property

    Private _SideImageAlign As ContentAlignment = ContentAlignment.MiddleLeft

    ''' <summary>
    ''' Get or Set the Side Image Alignment
    ''' </summary>
    <Category("Appearance CButton"), Description("Get or Set the Side Image Alignment"), DefaultValue(GetType(ContentAlignment), "MiddleLeft")>
    Public Property SideImageAlign() As ContentAlignment
        Get
            Return _SideImageAlign
        End Get
        Set(ByVal Value As ContentAlignment)
            _SideImageAlign = Value
            Invalidate()
        End Set
    End Property

#End Region 'SideImage

#Region "FocalPoints"

    Private _FocalPoints As cFocalPoints = New cFocalPoints(0.5, 0.5, 0, 0)

    ''' <summary>
    ''' The CenterPoint and FocusScales for the ColorBlend
    ''' </summary>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
    <Description("The CenterPoint and FocusScales for the ColorBlend"), Category("Appearance CButton")>
    Public Property FocalPoints() As cFocalPoints
        Get
            Return _FocalPoints
        End Get
        Set(ByVal value As cFocalPoints)
            _FocalPoints = value
            Invalidate()
        End Set
    End Property

    Private Function DefaultFocalPoints() As cFocalPoints
        Return New cFocalPoints(0.5, 0.5, 0, 0)
    End Function

#Region "Focal Points Default Value"

    Public Sub ResetFocalPoints()
        FocalPoints = New cFocalPoints(0.5, 0.5, 0, 0)
    End Sub

    Private Function ShouldSerializeFocalPoints() As Boolean
        Return Not (_FocalPoints.Equals(New cFocalPoints(0.5, 0.5, 0, 0)))
    End Function

#End Region

#End Region 'FocalPoints

#Region "Mneumonic"

    Private _UseMnemonic As System.Boolean = True

    ''' <summary>
    ''' If true, the first character proceeded by an ampersand will be used as the button's mnemonic key.
    ''' </summary>
    <Category("Appearance CButton"), Description("If true, the first character proceeded by an ampersand (&) will be used as the button's mnemonic key."), DefaultValue(True)>
    Public Property UseMnemonic() As System.Boolean
        Get
            Return _UseMnemonic
        End Get
        Set(ByVal value As System.Boolean)
            _UseMnemonic = value
            Invalidate()
        End Set
    End Property

#End Region 'Mneumonic

#End Region 'Properties

#Region "Drawing"

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        e.Graphics.TextRenderingHint = _TextSmoothingMode
        'Gray the Text and Border Colors if Disabled
        Dim bColor, tColor, tsColor As Color
        If Enabled Then
            bColor = _BorderColor
            tColor = ForeColor
            tsColor = _TextShadow
        Else
            bColor = GrayTheColor(_BorderColor)
            tColor = GrayTheColor(ForeColor)
            tsColor = GrayTheColor(_TextShadow)
        End If

        Using MyPen As New Pen(bColor)
            MyPen.Alignment = PenAlignment.Inset

            'Shrink the Area so the Border draws correctly, _
            'then trim off the Padding to get the button surface area
            ButtonArea = AdjustRect(New RectangleF(0, 0, Size.Width - 1, Size.Height - 1), Padding)

            'Create the ButtonArea Path
            Using gp As GraphicsPath = GetPath()

                If BackgroundImage Is Nothing Then

                    'Color the ButtonArea with the right Brush
                    Select Case FillType
                        Case eFillType.Solid
                            Using br As Brush = New SolidBrush(GetFill)
                                e.Graphics.FillPath(br, gp)
                            End Using

                        Case eFillType.GradientPath
                            Using br As PathGradientBrush = New PathGradientBrush(gp)
                                Dim cb As New ColorBlend
                                cb.Colors = GetFillBlend()
                                cb.Positions = ColorFillBlend.iPoint

                                br.FocusScales = FocalPoints.FocusScales
                                br.CenterPoint = New PointF(Padding.Left + ButtonArea.Width * FocalPoints.CenterPoint.X, Padding.Top + ButtonArea.Height * FocalPoints.CenterPoint.Y)
                                br.InterpolationColors = cb

                                e.Graphics.FillPath(br, gp)
                            End Using

                        Case eFillType.GradientLinear
                            Using br As LinearGradientBrush = New LinearGradientBrush(ButtonArea, Color.White, Color.White, FillTypeLinear)
                                Dim cb As New ColorBlend
                                cb.Colors = GetFillBlend()
                                cb.Positions = ColorFillBlend.iPoint
                                'MsgBox(cb.Colors.Length & cb.Positions.Length)
                                br.InterpolationColors = cb

                                e.Graphics.FillPath(br, gp)
                            End Using

                    End Select
                End If

                If MyBase.Focused AndAlso ShowFocus = eFocus.Dot Then
                    Using focusPen As Pen = New Pen(Brushes.Black, 1) With {.DashStyle = DashStyle.Dot}
                        e.Graphics.DrawPath(focusPen, GetPath(-1, -1))
                    End Using
                End If

                If BorderShow Then
                    e.Graphics.DrawPath(MyPen, gp)
                End If

            End Using

            Dim ipt As PointF = ImageLocation(GetStringFormat(SideImageAlign), Size, SideImageSize)

            rectSideImage = New Rectangle(CInt(ipt.X), CInt(ipt.Y), SideImageSize.Width, SideImageSize.Height)

            'Put the SideImage behind the Text
            If SideImageBehindText AndAlso SideImage IsNot Nothing Then
                If Enabled Then
                    e.Graphics.SmoothingMode = SmoothingMode.None
                    e.Graphics.DrawImage(SideImage, ipt.X, ipt.Y, SideImageSize.Width, SideImageSize.Height)
                Else
                    ControlPaint.DrawImageDisabled(e.Graphics, New Bitmap(SideImage, SideImageSize.Width, SideImageSize.Height), CInt(ipt.X), CInt(ipt.Y), BackColor)
                End If
            End If

            'Layout the Text and Image on the button surface
            SetImageAndText(e.Graphics)

            If Not Image Is Nothing Then
                If Enabled Then
                    e.Graphics.DrawImage(Image, Imagept.X, Imagept.Y, ImageSize.Width, ImageSize.Height)
                Else
                    ControlPaint.DrawImageDisabled(e.Graphics, New Bitmap(Image, ImageSize.Width, ImageSize.Height), CInt(Imagept.X), CInt(Imagept.Y), BackColor)
                End If
            End If

            'Draw the Text and Shadow
            If TextShadowShow Then
                TextArea.Offset(1, 1)
                e.Graphics.DrawString(Text, Font, New SolidBrush(tsColor), TextArea, GetStringFormat(TextAlign))
                TextArea.Offset(-1, -1)
            End If
            e.Graphics.DrawString(Text, Font, New SolidBrush(tColor), TextArea, GetStringFormat(TextAlign))

            'Put the SideImage in front of the Text
            If Not SideImageBehindText AndAlso Not SideImage Is Nothing Then
                If Enabled Then
                    e.Graphics.SmoothingMode = SmoothingMode.None
                    e.Graphics.DrawImage(SideImage, ipt.X, ipt.Y, SideImageSize.Width, SideImageSize.Height)
                Else
                    ControlPaint.DrawImageDisabled(e.Graphics, New Bitmap(SideImage, SideImageSize.Width, SideImageSize.Height), CInt(ipt.X), CInt(ipt.Y), BackColor)
                End If
            End If

        End Using
    End Sub

    Private Function GetPath(Optional infX As Integer = 0, Optional infY As Integer = 0) As GraphicsPath
        Dim gp As New GraphicsPath
        Dim rect As RectangleF = ButtonArea

        If infX <> 0 AndAlso infY <> 0 Then
            rect.Inflate(infX, infY)
        End If

        Select Case _Shape

            Case eShape.Ellipse
                gp.AddEllipse(rect)

            Case eShape.Rectangle
                gp = GetRoundedRectPath(rect)

            Case eShape.TriangleUp
                Dim pts() As PointF = New PointF() {New PointF(CSng(rect.Width / 2), rect.Y), New PointF(rect.Width, rect.Y + rect.Height), New PointF(rect.X, rect.Y + rect.Height)}
                gp.AddPolygon(pts)

            Case eShape.TriangleDown
                Dim pts() As PointF = New PointF() {New PointF(rect.X, rect.Y), New PointF(CSng(rect.Width / 2), rect.Y + rect.Height), New PointF(rect.X + rect.Width, rect.Y)}
                gp.AddPolygon(pts)

            Case eShape.TriangleLeft
                Dim pts() As PointF = New PointF() {New PointF(rect.X, CSng(rect.Y + (rect.Height / 2))), New PointF(rect.Width, rect.Y), New PointF(rect.Width, rect.Y + rect.Height)}
                gp.AddPolygon(pts)

            Case eShape.TriangleRight
                Dim pts() As PointF = New PointF() {New PointF(rect.X, rect.Y), New PointF(rect.Width, CSng(rect.Y + (rect.Height / 2))), New PointF(rect.X, rect.Y + rect.Height)}
                gp.AddPolygon(pts)

        End Select

        Return gp
    End Function

    Private Function GetStringFormat(ByVal ctrlalign As ContentAlignment) As StringFormat
        Dim strFormat As StringFormat = New StringFormat()
        Select Case ctrlalign
            Case ContentAlignment.MiddleCenter
                strFormat.LineAlignment = StringAlignment.Center
                strFormat.Alignment = StringAlignment.Center
            Case ContentAlignment.MiddleLeft
                strFormat.LineAlignment = StringAlignment.Center
                strFormat.Alignment = StringAlignment.Near
            Case ContentAlignment.MiddleRight
                strFormat.LineAlignment = StringAlignment.Center
                strFormat.Alignment = StringAlignment.Far
            Case ContentAlignment.TopCenter
                strFormat.LineAlignment = StringAlignment.Near
                strFormat.Alignment = StringAlignment.Center
            Case ContentAlignment.TopLeft
                strFormat.LineAlignment = StringAlignment.Near
                strFormat.Alignment = StringAlignment.Near
            Case ContentAlignment.TopRight
                strFormat.LineAlignment = StringAlignment.Near
                strFormat.Alignment = StringAlignment.Far
            Case ContentAlignment.BottomCenter
                strFormat.LineAlignment = StringAlignment.Far
                strFormat.Alignment = StringAlignment.Center
            Case ContentAlignment.BottomLeft
                strFormat.LineAlignment = StringAlignment.Far
                strFormat.Alignment = StringAlignment.Near
            Case ContentAlignment.BottomRight
                strFormat.LineAlignment = StringAlignment.Far
                strFormat.Alignment = StringAlignment.Far
        End Select
        If _UseMnemonic = True Then
            strFormat.HotkeyPrefix = Drawing.Text.HotkeyPrefix.Show
        Else
            strFormat.HotkeyPrefix = Drawing.Text.HotkeyPrefix.None
        End If
        Return strFormat
    End Function

    Private Sub SetImageAndText(ByVal g As Graphics)
        If MouseDrawState = eMouseDrawState.Down Then
            PressedOffset = 1
        Else
            PressedOffset = 0
        End If

        If Not Image Is Nothing Then
            ImageSizeUse = ImageSize
        Else
            ImageSizeUse = New Size(0, 0)
        End If

        Select Case TextImageRelation
            Case Windows.Forms.TextImageRelation.Overlay, Windows.Forms.TextImageRelation.ImageAboveText, Windows.Forms.TextImageRelation.TextAboveImage
                TextArea = AdjustRect(ButtonArea, TextMargin)
                ImageArea = ButtonArea
                TextArea.Y += PressedOffset
                Imagept = ImageLocation(GetStringFormat(ImageAlign), ButtonArea.Size, ImageSizeUse)
                Imagept.X += ButtonArea.X
            Case Windows.Forms.TextImageRelation.ImageBeforeText
                Dim TextSize As SizeF = g.MeasureString(Text, Font)
                TextArea = AdjustRect(ButtonArea, TextMargin)
                TextArea.Width -= ImageSizeUse.Width - 4
                TextArea.Y += PressedOffset
                ImageArea = New RectangleF(TextArea.X - ImageSizeUse.Width, ButtonArea.Y, ImageSizeUse.Width, ImageSizeUse.Height)
                Imagept = ImageLocation(GetStringFormat(ImageAlign), ButtonArea.Size, ImageArea.Size)

                Select Case GetStringFormat(TextAlign).Alignment
                    Case StringAlignment.Center
                        Imagept.X = ButtonArea.X + ((ButtonArea.Width - TextSize.Width - ImageSizeUse.Width) / 2)
                        TextArea.X = ButtonArea.X + ImageSizeUse.Width
                    Case StringAlignment.Near
                        Imagept.X = ButtonArea.X + 4
                        TextArea.X = ButtonArea.X + ImageSizeUse.Width + 4
                    Case StringAlignment.Far
                        Imagept.X = ButtonArea.X + TextArea.Width - TextSize.Width - 12
                        TextArea.X = ButtonArea.X + ImageSizeUse.Width - 8
                End Select

            Case Windows.Forms.TextImageRelation.TextBeforeImage
                Dim TextSize As SizeF = g.MeasureString(Text, Font)
                TextArea = AdjustRect(ButtonArea, TextMargin)
                TextArea.Width -= ImageSizeUse.Width - 8
                TextArea.Y += PressedOffset
                ImageArea = New RectangleF(TextArea.X, ButtonArea.Y, ImageSizeUse.Width, ImageSizeUse.Height)
                Imagept = ImageLocation(GetStringFormat(ImageAlign), ButtonArea.Size, ImageArea.Size)

                Select Case GetStringFormat(TextAlign).Alignment
                    Case StringAlignment.Center
                        Imagept.X = ((TextArea.Width - TextSize.Width) / 2) + TextSize.Width
                        TextArea.X = -4
                    Case StringAlignment.Near
                        Imagept.X = TextSize.Width + 8
                        TextArea.X = 4
                    Case StringAlignment.Far
                        Imagept.X = TextArea.Width - 12
                        TextArea.X = -16
                End Select

        End Select
        Imagept.Y += PressedOffset + ButtonArea.Y
    End Sub

    Private Shared Function ImageLocation(ByVal sf As StringFormat, ByVal Area As SizeF, ByVal ImageArea As SizeF) As PointF
        Dim pt As PointF
        Select Case sf.Alignment
            Case StringAlignment.Center
                pt.X = CSng((Area.Width - ImageArea.Width) / 2)
            Case StringAlignment.Near
                pt.X = 2
            Case StringAlignment.Far
                pt.X = Area.Width - ImageArea.Width - 2

        End Select

        Select Case sf.LineAlignment
            Case StringAlignment.Center
                pt.Y = CSng((Area.Height - ImageArea.Height) / 2)
            Case StringAlignment.Near
                pt.Y = 2
            Case StringAlignment.Far
                pt.Y = Area.Height - ImageArea.Height - 2

        End Select

        Return pt
    End Function

    Private Sub UpdateDimBlends()
        _ClickColorBlend = CType(_ColorFillBlend.iColor.Clone, Color())
        _HoverColorBlend = CType(_ColorFillBlend.iColor.Clone, Color())
        _DisabledBlend = CType(_ColorFillBlend.iColor.Clone, Color())
        Dim c As Color
        For i As Integer = 0 To _ColorFillBlend.iColor.Length - 1
            c = _ColorFillBlend.iColor(i)
            _ClickColorBlend(i) = DimTheColor(c, _DimFactorClick)
            _HoverColorBlend(i) = DimTheColor(c, _DimFactorHover)
            _DisabledBlend(i) = GrayTheColor(c)
        Next
    End Sub

    Private Sub UpdateDimColors()
        _ClickColorSolid = DimTheColor(_ColorFillSolid, _DimFactorClick)
        _HoverColorSolid = DimTheColor(_ColorFillSolid, _DimFactorHover)
        _DisabledSolid = GrayTheColor(_ColorFillSolid)
    End Sub

    ''' <summary>
    ''' This function takes the given color and Lightens or Darkens it by the given value
    ''' </summary>
    ''' <param name="DimColor">Base Color object to be changed</param>
    ''' <param name="DimDegree">Positive value to darken and negative value to lighten DimColor</param>
    Public Shared Function DimTheColor(ByVal DimColor As Color, ByVal DimDegree As Integer) As Color
        If DimColor = Color.Transparent Or DimDegree = 0 Then Return DimColor
        Dim ColorR As Integer = DimColor.R + DimDegree
        Dim ColorG As Integer = DimColor.G + DimDegree
        Dim ColorB As Integer = DimColor.B + DimDegree

        If ColorR > 255 Then ColorR = 255
        If ColorG > 255 Then ColorG = 255
        If ColorB > 255 Then ColorB = 255
        If ColorR < 0 Then ColorR = 0
        If ColorG < 0 Then ColorG = 0
        If ColorB < 0 Then ColorB = 0

        Return Color.FromArgb(ColorR, ColorG, ColorB)
    End Function

    ''' <summary>
    ''' This function takes the given color and returns its gray equivilant
    ''' </summary>
    ''' <param name="GrayColor">Color object to be grayed</param>
    Public Shared Function GrayTheColor(ByVal GrayColor As Color) As Color
        Dim gray As Integer = CInt(GrayColor.R * 0.3 + GrayColor.G * 0.59 + GrayColor.B * 0.11)
        Return Color.FromArgb(GrayColor.A, gray, gray, gray)
    End Function

    Private Function GetFillBlend() As Color()
        If Enabled Then

            If MouseDrawState = eMouseDrawState.Down Then
                Return _ClickColorBlend
            ElseIf MouseDrawState = eMouseDrawState.Over OrElse (ShowFocus = eFocus.Dim And Focused) Then
                Return _HoverColorBlend
            Else
                Return _ColorFillBlend.iColor
            End If
        Else
            Return _DisabledBlend
        End If
    End Function

    Private Function GetFill() As Color

        If Enabled Then
            If MouseDrawState = eMouseDrawState.Down Then
                Return _ClickColorSolid
            ElseIf MouseDrawState = eMouseDrawState.Over OrElse (ShowFocus = eFocus.Dim And Focused) Then
                Return _HoverColorSolid
            Else
                Return _ColorFillSolid
            End If
        Else
            Return _DisabledSolid
        End If
    End Function

    Private Shared Function AdjustRect(ByVal BaseRect As RectangleF, ByVal Pad As Padding) As RectangleF
        BaseRect.Width = Math.Max(BaseRect.Width - Pad.Horizontal, 5)
        BaseRect.Height = Math.Max(BaseRect.Height - Pad.Vertical, 5)

        BaseRect.Offset(Pad.Left, Pad.Top)
        Return BaseRect
    End Function

    Private Shared Function AdjustRect(ByVal BaseRect As Rectangle, ByVal Pad As Padding) As Rectangle
        BaseRect.Width = Math.Max(BaseRect.Width - Pad.Horizontal, 5)
        BaseRect.Height = Math.Max(BaseRect.Height - Pad.Vertical, 5)

        BaseRect.Offset(Pad.Left, Pad.Top)
        Return BaseRect
    End Function

    Private Function GetRoundedRectPath(ByVal BaseRect As RectangleF) As GraphicsPath

        Dim ArcRect As RectangleF
        Dim MyPath As New Drawing2D.GraphicsPath()
        If Corners.All = -1 Then
            With MyPath
                ' top left arc
                If Corners.UpperLeft = 0 Then
                    .AddLine(BaseRect.X, BaseRect.Y, BaseRect.X, BaseRect.Y)
                Else
                    ArcRect = New RectangleF(BaseRect.Location, New SizeF(Corners.UpperLeft * 2, Corners.UpperLeft * 2))
                    .AddArc(ArcRect, 180, 90)
                End If

                ' top right arc
                If Corners.UpperRight = 0 Then
                    .AddLine(BaseRect.X + (Corners.UpperLeft), BaseRect.Y, BaseRect.Right - (Corners.UpperRight), BaseRect.Top)
                Else
                    ArcRect = New RectangleF(BaseRect.Location, New SizeF(Corners.UpperRight * 2, Corners.UpperRight * 2))
                    ArcRect.X = BaseRect.Right - (Corners.UpperRight * 2)
                    .AddArc(ArcRect, 270, 90)
                End If

                ' bottom right arc
                If Corners.LowerRight = 0 Then
                    .AddLine(BaseRect.Right, BaseRect.Top + (Corners.UpperRight), BaseRect.Right, BaseRect.Bottom - (Corners.LowerRight))
                Else
                    ArcRect = New RectangleF(BaseRect.Location, New SizeF(Corners.LowerRight * 2, Corners.LowerRight * 2))
                    ArcRect.Y = BaseRect.Bottom - (Corners.LowerRight * 2)
                    ArcRect.X = BaseRect.Right - (Corners.LowerRight * 2)
                    .AddArc(ArcRect, 0, 90)
                End If

                ' bottom left arc
                If Corners.LowerLeft = 0 Then
                    .AddLine(BaseRect.Right - (Corners.LowerRight), BaseRect.Bottom, BaseRect.X - (Corners.LowerLeft), BaseRect.Bottom)
                Else
                    ArcRect = New RectangleF(BaseRect.Location, New SizeF(Corners.LowerLeft * 2, Corners.LowerLeft * 2))
                    ArcRect.Y = BaseRect.Bottom - (Corners.LowerLeft * 2)
                    .AddArc(ArcRect, 90, 90)
                End If

                .CloseFigure()
            End With
        Else
            With MyPath
                If Corners.All = 0 Then
                    .AddRectangle(BaseRect)
                Else

                    ArcRect = New RectangleF(BaseRect.Location, New SizeF(Corners.All * 2, Corners.All * 2))
                    ' top left arc
                    .AddArc(ArcRect, 180, 90)

                    ' top right arc
                    ArcRect.X = BaseRect.Right - (Corners.All * 2)
                    .AddArc(ArcRect, 270, 90)

                    ' bottom right arc
                    ArcRect.Y = BaseRect.Bottom - (Corners.All * 2)
                    .AddArc(ArcRect, 0, 90)

                    ' bottom left arc
                    ArcRect.X = BaseRect.Left
                    .AddArc(ArcRect, 90, 90)

                End If
                .CloseFigure()
            End With
        End If
        Return MyPath
    End Function

#End Region 'Drawing

#Region "MouseEvents"

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)

        If Enabled Then
            If _SideImageIsClickable AndAlso rectSideImage.Contains(e.Location) Then
                'Create and add additional SideImageDown Event here if needed
                'RaiseEvent SideImageDown(Me, e)

            ElseIf GetPath.IsVisible(e.X, e.Y) Then
                Focus()
                MouseDrawState = eMouseDrawState.Down
                Invalidate(Rectangle.Round(ButtonArea))
                RaiseEvent ButtonAreaDown(Me, e)
            Else
                'Allow click through the non button area
                Dim MouseEvnt As UInteger
                If e.Button = Windows.Forms.MouseButtons.Left Then
                    If e.Clicks = 1 Then
                        MouseEvnt = WM_LBUTTONDOWN
                    ElseIf e.Clicks > 1 Then
                        MouseEvnt = WM_LBUTTONDBLCLK
                    End If
                ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
                    If e.Clicks = 1 Then
                        MouseEvnt = WM_RBUTTONDOWN
                    ElseIf e.Clicks > 1 Then
                        MouseEvnt = WM_RBUTTONDBLCLK
                    End If
                End If
                Call SendMessage(Parent.Handle, MouseEvnt, IntPtr.Zero, IntPtr.Zero)
            End If
        End If
    End Sub

    Private Sub CButton_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If _SideImageIsClickable AndAlso rectSideImage.Contains(e.Location) Then
            MouseDrawState = eMouseDrawState.Up

            Invalidate(Rectangle.Round(ButtonArea))

        ElseIf GetPath.IsVisible(e.X, e.Y) Then
            If Not MouseDrawState = eMouseDrawState.Down Then
                MouseDrawState = eMouseDrawState.Over
            End If
            Invalidate(Rectangle.Round(ButtonArea))
        Else
            If Not MouseDrawState = eMouseDrawState.Up Then
                MouseDrawState = eMouseDrawState.Up
                Invalidate(Rectangle.Round(ButtonArea))

            End If
        End If
    End Sub

    Private Sub CButton_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave
        If Not MouseDrawState = eMouseDrawState.Up Then
            MouseDrawState = eMouseDrawState.Up
            Invalidate(Rectangle.Round(ButtonArea))
        End If
    End Sub

    Protected Overrides Sub OnMouseClick(e As MouseEventArgs)
        MyBase.OnMouseClick(e)
        If _SideImageIsClickable AndAlso rectSideImage.Contains(e.Location) Then
            RaiseEvent SideImageClicked(Me, e)

        ElseIf GetPath.IsVisible(e.X, e.Y) Then
            PerformClickButtonArea(Me, e)
        End If
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        If _SideImageIsClickable AndAlso rectSideImage.Contains(e.Location) Then
            'Create and add additional SideImageUp Event here if needed
            'RaiseEvent SideImageUp(Me, e)

        ElseIf GetPath.IsVisible(e.X, e.Y) Then
            If MouseDrawState = eMouseDrawState.Down Then RaiseEvent ButtonAreaUP(Me, e)
            MouseDrawState = eMouseDrawState.Up
            Invalidate(Rectangle.Round(ButtonArea))
        End If
    End Sub

#End Region

#Region "Focus"

    Private Sub CButton_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        If ShowFocus = eFocus.Dim Then
            MouseDrawState = eMouseDrawState.Over
            Invalidate(Rectangle.Round(ButtonArea))
        End If
    End Sub

    Private Sub CButton_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        If ShowFocus = eFocus.Dim Then
            MouseDrawState = eMouseDrawState.Up
            Invalidate(Rectangle.Round(ButtonArea))
        End If
    End Sub

#End Region

#Region "Key Events"

    Private Sub CButton_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If Enabled Then
            Select Case e.KeyCode
                Case Keys.Enter, Keys.Space, Keys.Return
                    MouseDrawState = eMouseDrawState.Down
                    Invalidate(Rectangle.Round(ButtonArea))
            End Select
        End If
    End Sub

    Private Sub CButton_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyUp
        Select Case e.KeyCode
            Case Keys.Enter, Keys.Space, Keys.Return
                e.Handled = True
                If MouseDrawState = eMouseDrawState.Down Then
                    Parent.Text = Cursor.Position.ToString
                    If ButtonArea.Contains(PointToClient(Cursor.Position)) Then
                        MouseDrawState = eMouseDrawState.Over
                    Else
                        MouseDrawState = eMouseDrawState.Up
                    End If
                    Invalidate(Rectangle.Round(ButtonArea))
                    PerformClickButtonArea(Me, New MouseEventArgs(Windows.Forms.MouseButtons.Left, 1, CInt(ButtonArea.X), CInt(ButtonArea.Y), 0))
                End If
        End Select
    End Sub

#End Region

#Region "Control Events"

    Protected Overrides Function ProcessMnemonic(ByVal charCode As Char) As Boolean
        If (CanSelect And IsMnemonic(charCode, Text)) Then
            [Select]()
            PerformClickButtonArea(Me, New MouseEventArgs(Windows.Forms.MouseButtons.Left, 1, CInt(ButtonArea.X), CInt(ButtonArea.Y), 0))
            Return True
        End If
        Return False
    End Function

#End Region 'Control Events

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class

#End Region    'CButton Class

#Region "Expandable Focal Points Property Classes"

#Region "FocalPointsConverter"

'CornerConverter Code

#End Region    'FocalPointsConverter

#End Region    'Expandable Focal Points Property Class

#Region "Expandable Border Corners Property Class"

#Region "CornersProperty"

'Corners Properties

#End Region    'CornersProperty

#Region "CornerConverter"

'CornerConverter Code

#End Region    'CornerConverter

#End Region    'Expandable Border Corners Property Class