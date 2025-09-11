Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles
Imports AATM.Libraries.AatmInterfaces
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.Messaging

Public Class CCheckBox
    Inherits CheckBox
    Implements IEntryControl, IFindableControl, ILinkedLabel

    Private _displayOnly As Boolean
    Private _editingMode As Boolean = True
    Private _translatable As Boolean = False
    Private _noLabel As Boolean
    Private _oldValue As String
    Private _autoSize As Boolean
    Private _textToSearch As String
    Private WithEvents _contextMenuStrip1 As New ContextMenuStrip
    Private _textRectangleValue As New Rectangle()

    'Private clickedLocationValue As New Point()
    Private clicked As Boolean = False

    Private _state As CheckBoxState = CheckBoxState.UncheckedNormal


    Public Sub New()
        MyBase.New()
        Font = SystemFonts.IconTitleFont
        AutoSize = False
        Appearance = Appearance.Normal
        UseVisualStyleBackColor = True
        FlatStyle = FlatStyle.Flat
        'TextAlign = System.Drawing.ContentAlignment.MiddleRight
        'CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        ContextMenuStrip = _contextMenuStrip1
        Size = New Size(13, 13)
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        BackColor = Color.Transparent
        'Margin = New Padding(5)
        'FlatAppearance.BorderSize = 0
        NoLabel = True
        Text = ""
    End Sub

    <Category("Custom Properties")>
    <DefaultValue(False)>
    <Description("Set to True to specify that this control is always editable.")>
    Public Property AlwaysEditable As Boolean = False

    <Category("Custom Properties")>
    <DefaultValue(CType(Nothing, String))>
    <Description("Security Key to use for this control.")>
    <Browsable(True)>
    Public Property SecurityKey As String

    'Calculate the text bounds, excluding the check box.
    Public ReadOnly Property TextRectangle() As Rectangle
        Get
            Using g As Graphics = Me.CreateGraphics()
                With _textRectangleValue
                    .X = Me.ClientRectangle.X +
                        CheckBoxRenderer.GetGlyphSize(g,
                        CheckBoxState.UncheckedNormal).Width
                    .Y = Me.ClientRectangle.Y
                    .Width = Me.ClientRectangle.Width -
                        CheckBoxRenderer.GetGlyphSize(g,
                        CheckBoxState.UncheckedNormal).Width
                    .Height = Me.ClientRectangle.Height
                End With
            End Using
            Return _textRectangleValue
        End Get
    End Property

    ' Draw the check box in the current state.
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)
        If DisplayOnly OrElse Not EditingMode Then
            _state = IIf(Checked, VisualStyles.CheckBoxState.CheckedDisabled, VisualStyles.CheckBoxState.UncheckedDisabled)
        Else
            _state = IIf(Checked, VisualStyles.CheckBoxState.CheckedNormal, VisualStyles.CheckBoxState.UncheckedNormal)
        End If

        Dim pt As Point = New Point(0, 0)
        Dim rect As Rectangle = New Rectangle(pt, New Size(13, 13))
        'Dim cForeColor As Color

        'If Focused Then
        '    cForeColor = GlobalVariables.DefaultFormControlEditingBackgroundColor
        'Else
        '    cForeColor = GlobalVariables.DefaultFormControlBackgroundColor
        'End If
        'Dim cBrush = New SolidBrush(cForeColor)
        'e.Graphics.FillRectangle(cBrush, rect)
        'CheckBoxRenderer.DrawCheckBox(e.Graphics,
        '                              ClientRectangle.Location, TextRectangle, Text,
        '                              Font, TextFormatFlags.HorizontalCenter,
        '                              clicked, _state)

        'e.Graphics.Clear(BackColor)

        'Using brush As SolidBrush = New SolidBrush(ForeColor)
        '    e.Graphics.DrawString(Text, Font, brush, 27, 4)
        'End Using

        'Dim pt As Point = New Point(5, 5)
        'Dim rect As Rectangle = New Rectangle(pt, New Size(13, 13))
        'Dim cForeColor As Color

        'If Focused Then
        '    cForeColor = GlobalVariables.DefaultFormControlEditingBackgroundColor
        'Else
        '    cForeColor = GlobalVariables.DefaultFormControlBackgroundColor
        'End If
        'Dim cBrush = New SolidBrush(cForeColor)
        'e.Graphics.FillRectangle(cBrush, rect)

        If Checked Then
            Dim cCol As Color
            If _editingMode And Not DisplayOnly Then
                If Focused Then
                    cCol = GlobalVariables.DefaultFormControlEditingForegroundColor
                Else
                    cCol = GlobalVariables.DefaultFormControlForegroundColor
                End If
            Else
                If Focused Then
                    cCol = GlobalVariables.DefaultFormControlForegroundColor
                Else
                    cCol = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
                End If
            End If
            Using brush As SolidBrush = New SolidBrush(cCol)
                Dim emSize = CInt(Height / 13 * 9)
                Using wing As Font = New Font("Wingdings", emSize)
                    e.Graphics.DrawString("ü", wing, brush, 0, 0)
                End Using
            End Using
        End If

        'e.Graphics.DrawRectangle(Pens.Gray, rect)
        'Dim fRect As Rectangle = ClientRectangle

        'If Focused Then
        '    fRect.Inflate(-1, -1)

        '    Using pen As Pen = New Pen(Brushes.Gray) With {
        '        .DashStyle = DashStyle.Dot
        '        }
        '        e.Graphics.DrawRectangle(pen, fRect)
        '    End Using
        'End If
    End Sub

    '' Draw the check box in the checked or unchecked state, alternately.
    'Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
    '    MyBase.OnMouseDown(e)
    '    If Not clicked Then
    '        With Me
    '            .clicked = True
    '            .Text = "Clicked!"
    '            _state = CheckBoxState.CheckedPressed
    '        End With
    '        Invalidate()
    '    Else
    '        With Me
    '            .clicked = False
    '            .Text = "Click here"
    '            _state = CheckBoxState.UncheckedNormal
    '        End With
    '        Invalidate()
    '    End If
    'End Sub

    '' Draw the check box in the hot state.
    'Protected Overrides Sub OnMouseHover(ByVal e As EventArgs)
    '    MyBase.OnMouseHover(e)
    '    If clicked Then
    '        _state = CheckBoxState.CheckedHot
    '    Else
    '        _state = CheckBoxState.UncheckedHot
    '    End If
    '    Invalidate()
    'End Sub

    '' Draw the check box in the hot state.
    'Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
    '    MyBase.OnMouseUp(e)
    '    Me.OnMouseHover(e)
    'End Sub

    '' Draw the check box in the unpressed state.
    'Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
    '    MyBase.OnMouseLeave(e)
    '    If clicked Then
    '        _state = CheckBoxState.CheckedNormal
    '    Else
    '        _state = CheckBoxState.UncheckedNormal
    '    End If
    '    Invalidate()
    'End Sub

#Region "Declarations#"

    ' Text Menu Captions
    Private ReadOnly _textFind = MessagingService.TranslateCaption("Find on this field")

#End Region

    Public Overrides Property AutoSize As Boolean
        Get
            Return _autoSize
        End Get
        Set(value As Boolean)
            _autoSize = False
        End Set
    End Property

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
            If AlwaysEditable Then
                Enabled = True
                ForeColor = GlobalVariables.DefaultFormControlForegroundColor
                BackColor = GlobalVariables.DefaultFormControlBackgroundColor
            Else
                _displayOnly = value
                If value Then
                    Enabled = False
                    ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
                    BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
                Else
                    Enabled = True
                    ForeColor = GlobalVariables.DefaultFormControlForegroundColor
                    BackColor = GlobalVariables.DefaultFormControlBackgroundColor
                End If
            End If
        End Set
    End Property

    <Bindable(True)>
    <Category("Custom Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to specify that this checkbox has no label.")>
    <Browsable(True)>
    Public Property NoLabel As Boolean
        Get
            Return _noLabel
        End Get
        Set(value As Boolean)
            If value Then
                Text = " "
            End If
            _noLabel = value
        End Set
    End Property

    Public Property EditingMode As Boolean Implements IEntryControl.EditingMode
        Get
            Return _editingMode
        End Get
        Set(value As Boolean)
            If AlwaysEditable Then
                _editingMode = True
            Else
                _editingMode = value

            End If
            UpdateDisplayOnlyControl()
        End Set
    End Property

    Public Sub UpdateDisplayOnlyControl()
        If _editingMode And Not DisplayOnly Then
            AutoCheck = True
            ForeColor = GlobalVariables.DefaultFormControlForegroundColor
            BackColor = GlobalVariables.DefaultFormControlBackgroundColor
            '_state = VisualStyles.CheckBoxState.CheckedDisabled
        Else
            AutoCheck = False
            ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
            BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
            '_state = VisualStyles.CheckBoxState.CheckedNormal
        End If
    End Sub

    'End Sub
    <Category("Custom Properties")>
    <Description("Select the label to which this control is linked.")>
    <Browsable(True)>
    Public Property LinkedLabel As CLabel Implements ILinkedLabel.LinkedLabel

    '    If Checked Then
    '        e.Graphics.FillRectangle(New SolidBrush(_checkRegionColor), checkRegion)
    '    End If
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
            Return False
        End Get
        Set(value As Boolean)
            _translatable = value
        End Set

    End Property

    '    MyBase.OnPaint(e)
    Public Sub EnterHandler(sender As Object, e As EventArgs) Handles MyBase.Enter
        _oldValue = Text
        If AlwaysEditable Then
            ForeColor = GlobalVariables.DefaultFormControlEditingForegroundColor
            BackColor = GlobalVariables.DefaultFormControlEditingBackgroundColor
        Else
            If EditingMode And Not DisplayOnly Then
                ForeColor = GlobalVariables.DefaultFormControlEditingForegroundColor
                BackColor = GlobalVariables.DefaultFormControlEditingBackgroundColor
            Else
                ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
                BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
            End If
        End If
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

    'Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
    '    Dim checkRegion As New Rectangle(2, 3, 9, 9)
    Public Sub LeaveHandler(sender As Object, e As EventArgs) Handles MyBase.Leave
        If AlwaysEditable Then
            ForeColor = GlobalVariables.DefaultFormControlEditingForegroundColor
            BackColor = GlobalVariables.DefaultFormControlEditingBackgroundColor
        Else
            If EditingMode And Not DisplayOnly Then
                ForeColor = GlobalVariables.DefaultFormControlForegroundColor
                BackColor = GlobalVariables.DefaultFormControlBackgroundColor
            Else
                ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
                BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
            End If
        End If
    End Sub

    Public Sub OnKeyDownPressed(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.SendWait("{TAB}")
        End If
    End Sub

    'Protected Overrides Sub OnPaint(ByVal pEvent As PaintEventArgs)
    '    pEvent.Graphics.Clear(BackColor)

    '    Using brush As SolidBrush = New SolidBrush(ForeColor)
    '        pEvent.Graphics.DrawString(Text, Font, brush, 27, 4)
    '    End Using

    '    Dim pt As Point = New Point(0, 0)
    '    Dim rect As Rectangle = New Rectangle(pt, New Size(23, 23))
    '    Dim cForeColor As Color

    '    If Focused Then
    '        cForeColor = GlobalVariables.DefaultFormControlEditingBackgroundColor
    '    Else
    '        cForeColor = GlobalVariables.DefaultFormControlBackgroundColor
    '    End If
    '    Dim cBrush = New SolidBrush(cForeColor)
    '    pEvent.Graphics.FillRectangle(cBrush, rect)

    '    If Checked Then
    '        Dim cCol As Color
    '        If _editingMode And Not DisplayOnly Then
    '            If Focused Then
    '                cCol = GlobalVariables.DefaultFormControlEditingForegroundColor
    '            Else
    '                cCol = GlobalVariables.DefaultFormControlForegroundColor
    '            End If
    '        Else
    '            If Focused Then
    '                cCol = GlobalVariables.DefaultFormControlForegroundColor
    '            Else
    '                cCol = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
    '            End If
    '        End If
    '        Using brush As SolidBrush = New SolidBrush(cCol)
    '            Using wing As Font = New Font("Wingdings", 12.0F)
    '                pEvent.Graphics.DrawString("ü", wing, brush, 1, 2)
    '            End Using
    '        End Using
    '    End If

    '    pEvent.Graphics.DrawRectangle(Pens.Gray, rect)
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
                .Text = AATM.Libraries.Messaging.MessagingService.TranslateCaption("Find on this field")
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
            FindDataType = IFindableControl.DataTypeEnum.Boolean
            searchForm.Location = formLocation
            If LinkedLabel IsNot Nothing AndAlso LinkedLabel.Text <> "" Then
                searchForm.SetFieldDescription(LinkedLabel.Text)
            Else
                searchForm.SetFieldDescription(FieldName)
            End If
            searchForm.ShowDialog()
            searchForm.Dispose()

            'CallByName(myForm, "FindFieldNew", CallType.Method, Me)
            Invoker.InvokeFunction(myForm, "FindFieldNew", {Me})
        Else
            AATM.Libraries.Messaging.MessagingService.Show(True, "MsgNothingToFind")
        End If
        'Dim x = Me.GetType()
        'MessageBox.Show(x.ToString())
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

    'Private ReadOnly _checkRegionColor As Color = Color.Coral
    'Public Sub MakeEditable(editableControl As Boolean) Implements IEntryControl.MakeEditable
    '    EditingMode = Not editableControl
    'End Sub

    'Public Sub MakeVisible(visibleControl As Boolean) Implements IEntryControl.MakeVisible
    '    Visible = visibleControl
    'End Sub
    'Public Sub MakeViewable(ViewableControl As Boolean) Implements IEntryControl.MakeViewable
    '    Throw New NotImplementedException()
    'End Sub

    'Public Sub MakeSelectable(selectableControl As Boolean) Implements IEntryControl.MakeSelectable
    '    Throw New NotImplementedException()
    'End Sub
End Class