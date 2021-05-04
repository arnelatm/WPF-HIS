Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports AATM.Libraries.AatmInterfaces
Imports AATM.Libraries.GlobalFuncNSub

Public Class CCheckBoxNew
    Inherits CheckBox
    Implements IEntryControl, IFindableControl

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
        BackColor = System.Drawing.Color.Transparent
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
                'BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
            Else
                Enabled = True
                ForeColor = GlobalVariables.DefaultFormControlForegroundColor
                'BackColor = GlobalVariables.DefaultFormControlBackgroundColor
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
                    'BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
                Else
                    AutoCheck = True
                    ForeColor = GlobalVariables.DefaultFormControlForegroundColor
                    'BackColor = GlobalVariables.DefaultFormControlBackgroundColor
                End If
            Else
                AutoCheck = False
                ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
                'BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
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
            'BackColor = GlobalVariables.DefaultFormControlEditingBackgroundColor
        Else
            ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
            'BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
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

    Public ReadOnly Property FindValueMember As String Implements IFindableControl.FindValueMember

    'Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
    '    Dim checkRegion As New Rectangle(2, 3, 9, 9)
    Public Sub LeaveHandler(sender As Object, e As EventArgs) Handles MyBase.Leave
        If EditingMode And Not DisplayOnly Then
            ForeColor = GlobalVariables.DefaultFormControlForegroundColor
            ' BackColor = GlobalVariables.DefaultFormControlBackgroundColor
        Else
            ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
            'BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
        End If
    End Sub

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