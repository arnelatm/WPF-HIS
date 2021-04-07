Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub

Public Class CCheckBox
    Inherits CheckBox
    Implements IEntryControl

    Private _displayOnly As Boolean
    Private _editingMode As Boolean = True
    Private _noLabel As Boolean
    Private _oldValue As String
    Private _autoSize As Boolean
    Private _textToSearch As String
    Private WithEvents _contextMenuStrip1 As New ContextMenuStrip

    Public Sub New()
        MyBase.New()
        AutoSize = False
        Appearance = Appearance.Normal
        UseVisualStyleBackColor = True
        FlatStyle = FlatStyle.Flat
        TextAlign = ContentAlignment.MiddleRight
        ContextMenuStrip = _contextMenuStrip1
        Size = New Size(24, 24)
        Margin = New Padding(1)
        FlatAppearance.BorderSize = 0
        NoLabel = True
        Text = ""
    End Sub

#Region "Declarations#"

    ' Text Menu Captions
    Private ReadOnly _textFind = MessagingLibrary.Messaging.TranslateCaption("Find on this field")

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
            _editingMode = value
            If value Then
                If DisplayOnly Then
                    AutoCheck = False
                    ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
                    BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
                Else
                    AutoCheck = True
                    ForeColor = GlobalVariables.DefaultFormControlForegroundColor
                    BackColor = GlobalVariables.DefaultFormControlBackgroundColor
                End If
            Else
                AutoCheck = False
                ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
                BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
            End If
        End Set
    End Property

    'End Sub
    <Category("Custom Properties")>
    <Description("Select the label to which this control is linked.")>
    <Browsable(True)>
    Public Property LinkedLabel As CLabel

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

    Public ReadOnly Property Translatable As Boolean Implements IEntryControl.Translatable
        Get
            Return False
        End Get
    End Property

    '    MyBase.OnPaint(e)
    Public Sub EnterHandler(sender As Object, e As EventArgs) Handles MyBase.Enter
        _oldValue = Text
        If EditingMode And Not DisplayOnly Then
            ForeColor = GlobalVariables.DefaultFormControlEditingForegroundColor
            BackColor = GlobalVariables.DefaultFormControlEditingBackgroundColor
        Else
            ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
            BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
        End If
    End Sub

    <Category("Custom Properties")>
    <Description("Set to True to enable find on this field.")>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Property FindEnabled As Boolean

    'Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
    '    Dim checkRegion As New Rectangle(2, 3, 9, 9)
    Public Sub LeaveHandler(sender As Object, e As EventArgs) Handles MyBase.Leave
        If EditingMode And Not DisplayOnly Then
            ForeColor = GlobalVariables.DefaultFormControlForegroundColor
            BackColor = GlobalVariables.DefaultFormControlBackgroundColor
        Else
            ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
            BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
        End If
    End Sub

    Public Sub OnKeyDownPressed(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.SendWait("{TAB}")
        End If
    End Sub

    Protected Overrides Sub OnPaint(ByVal pEvent As PaintEventArgs)
        pEvent.Graphics.Clear(BackColor)

        Using brush As SolidBrush = New SolidBrush(ForeColor)
            pEvent.Graphics.DrawString(Text, Font, brush, 27, 4)
        End Using

        Dim pt As Point = New Point(0, 0)
        Dim rect As Rectangle = New Rectangle(pt, New Size(23, 23))
        Dim cForeColor As Color

        If Focused Then
            cForeColor = GlobalVariables.DefaultFormControlEditingBackgroundColor
        Else

            cForeColor = GlobalVariables.DefaultFormControlBackgroundColor
        End If
        Dim cBrush = New SolidBrush(cForeColor)
        pEvent.Graphics.FillRectangle(cBrush, rect)

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
                Using wing As Font = New Font("Wingdings", 12.0F)
                    pEvent.Graphics.DrawString("ü", wing, brush, 1, 2)
                End Using
            End Using
        End If

        pEvent.Graphics.DrawRectangle(Pens.Gray, rect)
        Dim fRect As Rectangle = ClientRectangle

        If Focused Then
            fRect.Inflate(-1, -1)

            Using pen As Pen = New Pen(Brushes.Gray) With {
                .DashStyle = DashStyle.Dot
                }
                pEvent.Graphics.DrawRectangle(pen, fRect)
            End Using
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
            Dim searchForm = New CFindForm(3)
            Dim screenRectangle As Rectangle
            Dim formLocation As Point
            screenRectangle = Screen.PrimaryScreen.WorkingArea
            searchForm.StartPosition = FormStartPosition.Manual
            pnt = myForm.PointToScreen(Location)
            If formLocation.Y + searchForm.Height > screenRectangle.Height Then
                formLocation.Y = pnt.Y - searchForm.Height + Height
            End If
            searchForm.Location = formLocation
            searchForm.ShowDialog()
            _textToSearch = searchForm.TextToSearch
            searchForm.Dispose()
            CallByName(myForm, "FindField", CallType.Method, Me)
        Else
            AATM.Libraries.MessagingLibrary.Messaging.Show(True, "MsgNothingToFind")
        End If
    End Sub

    Public Function GetTextToSearch() As String
        Return _textToSearch
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