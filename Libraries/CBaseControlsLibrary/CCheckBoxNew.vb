Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports AATM.Libraries.AatmInterfaces
Imports AATM.Libraries.GlobalFuncNSub

Public Class CCheckBoxNew
    Inherits CheckBox
    Implements IEntryControl, IFindableControl, ILinkedLabel

    Private _displayOnly As Boolean
    Private _editingMode As Boolean = True
    Private _translatable As Boolean = False
    Private _noLabel As Boolean
    Private _oldValue As String
    Private _autoSize As Boolean
    Private _textToSearch As String
    Private _searchPlace As IFindableControl.SearchPlaceEnum
    Private WithEvents _contextMenuStrip1 As New ContextMenuStrip
    'Private ReadOnly _stringFormat As New StringFormat

    Public Sub New()
        MyBase.New()
        Dim myFont As New Font("Sans Serif", 10.0!, FontStyle.Regular)
        ContextMenuStrip = _contextMenuStrip1
        Font = myFont
        'Appearance = System.Windows.Forms.Appearance.Button
        FlatStyle = System.Windows.Forms.FlatStyle.Flat
        AutoSize = True
        'Height = 16
        '_stringFormat.Alignment = StringAlignment.Center
        '_stringFormat.LineAlignment = StringAlignment.Center
    End Sub

#Region "Declarations#"

    ' Text Menu Captions
    Private ReadOnly _textFind = MessagingLibrary.Messaging.TranslateCaption("Find on this field")

#End Region

    <Category("Custom Properties")>
    <DefaultValue(CType(Nothing, String))>
    <Description("Security Key to use for this control.")>
    <Browsable(True)>
    Public Property SecurityKey As String

    <Bindable(True)>
    <Category("Custom Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to specify that this control is read only.")>
    <Browsable(True)>
    Public Property DisplayOnly As Boolean
        Get
            Return _displayOnly
        End Get
        Set(value As Boolean)
            'If _displayOnly = value Then Exit Property
            _displayOnly = value
            If value Then
                Enabled = False
            Else
                Enabled = True
            End If
        End Set
    End Property

    Public Property EditingMode As Boolean Implements IEntryControl.EditingMode
        Get
            Return _editingMode
        End Get
        Set(value As Boolean)
            _editingMode = value
            If value Then
                If DisplayOnly Then
                    AutoCheck = False
                Else
                    AutoCheck = True
                End If
            Else
                AutoCheck = False
            End If
        End Set
    End Property

    'End Sub
    <Category("Custom Properties")>
    <Description("Select the label to which this control is linked.")>
    <Browsable(True)>
    Public Property LinkedLabel As CLabel Implements ILinkedLabel.LinkedLabel

    Public Property OldValue() As String
        Get
            Return _oldValue
        End Get
        Set(ByVal value As String)
            _oldValue = value
        End Set
    End Property

    Public Property Translatable As Boolean Implements IEntryControl.Translatable
        Get
            Return True
        End Get
        Set(value As Boolean)
            _translatable = value
        End Set
    End Property

    Public Sub EnterHandler(sender As Object, e As EventArgs) Handles MyBase.Enter
        _oldValue = Text
    End Sub

    Public Property FindDataType As IFindableControl.DataTypeEnum Implements IFindableControl.FindDataType
    Public Property IFindableControl_FindEnabled As Boolean Implements IFindableControl.FindEnabled

    <Category("Custom Properties")>
    <Description("Set to True to enable find on this field.")>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Property FindEnabled As Boolean

    Public Property BegFindValue As Object Implements IFindableControl.BegFindValue
    Public Property EndFindValue As Object Implements IFindableControl.EndFindValue

    Public Property SearchPlace As IFindableControl.SearchPlaceEnum Implements IFindableControl.SearchPlace
        Get
            Return IFindableControl.SearchPlaceEnum.ExactValue
        End Get
        Set(value As IFindableControl.SearchPlaceEnum)
            _searchPlace = value
        End Set
    End Property

    Public Property FieldName As String Implements IFindableControl.FieldName
    Public Property FieldDescription As String Implements IFindableControl.FieldDescription
    Public ReadOnly Property FindDataSource As Object Implements IFindableControl.FindDataSource
    Public ReadOnly Property FindDisplayMember As String Implements IFindableControl.FindDisplayMember

    Public ReadOnly Property SearchMode As IFindableControl.SearchModeEnum Implements IFindableControl.SearchMode
        Get
            Return IFindableControl.SearchModeEnum.CheckBox
        End Get
    End Property

    Public Property IgnoreCase As Boolean Implements IFindableControl.IgnoreCase

    Public ReadOnly Property FindValueMember As String Implements IFindableControl.FindValueMember

    Public Sub OnKeyDownPressed(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.SendWait("{TAB}")
        End If
    End Sub

    Private Sub HandleMouseUp(control As Object, e As MouseEventArgs)
        ' Checking the Mouse right Button
        If e.Button = MouseButtons.Right Then
            control.ContextMenuStrip.Show(control, New Point(e.X, e.Y))
        End If
    End Sub

    Private Sub HandlePopup(sender As Object, e As EventArgs) Handles _contextMenuStrip1.Opening
        ContextHandler(sender, e)
    End Sub

    Protected Sub ContextHandler(sender As Object, e As EventArgs)
        _contextMenuStrip1.Items.Clear()
        Dim menuItemFind As New ToolStripMenuItem With {
                .Text = AATM.Libraries.MessagingLibrary.Messaging.TranslateCaption("Find on this field")
                }
        _contextMenuStrip1.Items.Add(menuItemFind)
        menuItemFind.ShortcutKeys = Keys.Control Or Keys.F
        menuItemFind.ShortcutKeyDisplayString = $"Ctrl-F"
        AddHandler menuItemFind.Click, AddressOf MenuItemFind_Click
    End Sub

    Private Sub MenuItemFind_Click()
        If FindEnabled Then
            Dim myForm = FindForm()
            Dim pnt As Point
            Dim searchForm = New CFindForm(Me)
            Dim screenRectangle As Rectangle
            Dim formLocation As Point
            FieldName = Name.Substring(3)
            If LinkedLabel IsNot Nothing AndAlso LinkedLabel.Text <> "" Then
                searchForm.SetFieldDescription(LinkedLabel.Text)
            Else
                searchForm.SetFieldDescription(FieldName)
            End If
            screenRectangle = Screen.PrimaryScreen.WorkingArea
            searchForm.StartPosition = FormStartPosition.Manual
            pnt = myForm.PointToScreen(Location)
            If formLocation.Y + searchForm.Height > screenRectangle.Height Then
                formLocation.Y = pnt.Y - searchForm.Height + Height
            End If
            searchForm.Location = formLocation
            If LinkedLabel IsNot Nothing AndAlso LinkedLabel.Text <> "" Then
                searchForm.SetFieldDescription(LinkedLabel.Text)
            Else
                searchForm.SetFieldDescription(FieldName)
            End If
            searchForm.ShowDialog()
            searchForm.Dispose()

            CallByName(myForm, "FindFieldNew", CallType.Method, Me)
        Else
            AATM.Libraries.MessagingLibrary.Messaging.Show(True, "MsgNothingToFind")
        End If
        Dim x = Me.GetType()
        MessageBox.Show(x.ToString())
    End Sub

    Public Function GetTextToSearch() As String
        Return _textToSearch
    End Function

    Public Function GetControlDescription(Optional defaultDescription As String = Nothing) Implements ILinkedLabel.GetControlDescription
        Dim description As String
        If LinkedLabel Is Nothing OrElse LinkedLabel.Text Is Nothing OrElse LinkedLabel.Text = "" Then
            description = If(defaultDescription Is Nothing OrElse defaultDescription = "", Name, defaultDescription)
        Else
            description = LinkedLabel.Text
        End If
        Return description
    End Function

    'Protected Overrides Sub OnPaint(ByVal pEvent As System.Windows.Forms.PaintEventArgs)
    '    Dim brush As New SolidBrush(BackColor)
    '    Dim boxSide As Integer = CInt(pEvent.Graphics.MeasureString(Text, Font, Width).Height)
    '    pEvent.Graphics.FillRectangle(brush, 0, 0, Width, Height)
    '    If Checked And Enabled Then
    '        pEvent.Graphics.DrawString(Chr(252), New Font("Wingdings", Font.Size, FontStyle.Bold), Brushes.Black, New Rectangle(0, boxSide \ 10, boxSide, boxSide), _stringFormat)
    '        pEvent.Graphics.DrawRectangle(Pens.Black, New Rectangle(0, 0, boxSide - 1, boxSide - 1))
    '        pEvent.Graphics.DrawString(Text, Font, Brushes.Black, boxSide, 0)
    '    ElseIf Enabled Then
    '        pEvent.Graphics.DrawRectangle(Pens.Black, New Rectangle(0, 0, boxSide - 1, boxSide - 1))
    '        pEvent.Graphics.DrawString(Text, Font, Brushes.Black, boxSide, 0)
    '    ElseIf Checked And Not Enabled Then
    '        pEvent.Graphics.DrawString(Chr(252), New Font("Wingdings", Font.Size, FontStyle.Bold), Brushes.Gray, New Rectangle(0, boxSide \ 10, boxSide, boxSide), _stringFormat)
    '        pEvent.Graphics.DrawRectangle(Pens.Black, New Rectangle(0, 0, boxSide - 1, boxSide - 1))
    '        pEvent.Graphics.DrawString(Text, Font, Brushes.Gray, boxSide, 0)
    '    Else
    '        pEvent.Graphics.DrawRectangle(Pens.Black, New Rectangle(0, 0, boxSide - 1, boxSide - 1))
    '        pEvent.Graphics.DrawString(Text, Font, Brushes.Gray, boxSide, 0)
    '    End If
    '    brush.Dispose()
    'End Sub

    'Protected Overrides Sub OnPaint(ByVal pEvent As PaintEventArgs)
    '    'pEvent.Graphics.Clear(BackColor)

    '    Using brush As SolidBrush = New SolidBrush(ForeColor)
    '        pEvent.Graphics.DrawString(Text, Font, brush, 27, 4)
    '    End Using

    '    Dim pt As Point = New Point(4, 4)
    '    Dim rect As Rectangle = New Rectangle(pt, New Size(16, 16))
    '    pEvent.Graphics.FillRectangle(Brushes.Beige, rect)

    '    If Checked Then

    '        Using brush As SolidBrush = New SolidBrush(Color.Orange)

    '            Using wing As Font = New Font("Wingdings", 12.0F)
    '                pEvent.Graphics.DrawString("ü", wing, brush, 1, 2)
    '            End Using
    '        End Using
    '    End If

    '    pEvent.Graphics.DrawRectangle(Pens.DarkSlateBlue, rect)
    '    Dim fRect As Rectangle = ClientRectangle

    '    If Focused Then
    '        fRect.Inflate(-1, -1)

    '        Using pen As Pen = New Pen(Brushes.Gray) With {
    '            .DashStyle = DashStyle.Dot
    '            }
    '            pEvent.Graphics.DrawRectangle(pen, fRect)
    '        End Using
    '    End If
    'End Sub

    'Protected Overrides Sub OnPaint(ByVal pEvent As System.Windows.Forms.PaintEventArgs)
    '    Dim brush As New SolidBrush(Color.Gray)
    '    'Dim boxSide As Integer = CInt(pEvent.Graphics.MeasureString(Text, Font, Width).Height)
    '    Dim boxSide As Integer = 12
    '    'Dim bitmap As Bitmap = New Bitmap(Width, Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
    '    'bitmap.MakeTransparent()
    '    'BackgroundImage = bitmap
    '    pEvent.Graphics.FillRectangle(brush, 0, 0, boxSide, boxSide)
    '    If Checked Then
    '        pEvent.Graphics.FillRectangle(Brushes.Black, New Rectangle(0, 0, boxSide, boxSide))
    '    Else
    '        pEvent.Graphics.FillRectangle(Brushes.White, New Rectangle(0, 0, boxSide, boxSide))
    '        pEvent.Graphics.DrawRectangle(Pens.Black, New Rectangle(0, 0, boxSide - 1, boxSide - 1))
    '    End If
    '    pEvent.Graphics.DrawString(Text, Font, Brushes.Black, boxSide + 2, 0)
    'End Sub

    Protected Overrides Sub OnPaint(ByVal pEvent As PaintEventArgs)
        MyBase.OnPaint(pEvent)
        'Using brush As SolidBrush = New SolidBrush(Color.Gray)
        '    'pEvent.Graphics.Clear(Color.Transparent)
        '    'Dim bitmap As Bitmap = New Bitmap(Width, Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
        '    'Bitmap.MakeTransparent()
        '    'Dim graph As Graphics = Graphics.FromImage(bitmap)
        '    'pEvent.Graphics.DrawString(Text, Font, brush, 14, 0)
        '    'BackgroundImage = bitmap
        'End Using

        Dim pt As Point = New Point(1, 6)
        Dim rect As Rectangle = New Rectangle(pt, New Size(9, 9))
        Dim cBoxColorFill As Color

        If Focused Then
            If _editingMode And Not DisplayOnly Then
                cBoxColorFill = Color.White
            Else
                cBoxColorFill = Color.LightGray
            End If
        Else
            If _editingMode And Not DisplayOnly Then
                cBoxColorFill = Color.White
            Else
                cBoxColorFill = Color.LightGray
            End If
        End If
        Dim cBrush = New SolidBrush(cBoxColorFill)
        pEvent.Graphics.FillRectangle(cBrush, rect)

        If Checked Then
            Dim cCol As Color
            If _editingMode And Not DisplayOnly Then
                If Focused Then
                    cCol = Color.Blue
                Else
                    cCol = Color.Black
                End If
            Else
                If Focused Then
                    cCol = Color.Blue
                Else
                    cCol = Color.Black
                End If
            End If
            Using brush As SolidBrush = New SolidBrush(cCol)
                Using wing As Font = New Font("Wingdings", 10.0F)
                    pEvent.Graphics.DrawString("ü", wing, brush, -1, 4)
                End Using
            End Using
        End If

        'pEvent.Graphics.DrawRectangle(Pens.Gray, rect)
        'Dim fRect As Rectangle = ClientRectangle

        'If Focused Then
        '    fRect.Inflate(-1, -1)

        '    Using pen As Pen = New Pen(Brushes.Gray) With {
        '        .DashStyle = DashStyle.Dot
        '        }
        '        pEvent.Graphics.DrawRectangle(pen, fRect)
        '    End Using
        'End If

    End Sub

End Class