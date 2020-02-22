Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub

Public Class CMaskedTextBox
    Inherits MaskedTextBox
    Implements IEntryControl

    Private _defaultVal As String
    Private _isNumeric As Boolean
    Private _displayOnly As Boolean
    Private _textToSearch As String
    Private _searchAnywhere As Boolean
    Private _oldValue As String
    Private _editsALlowed As Boolean = False
    Private WithEvents ContextMenuStrip1 As New ContextMenuStrip
    Private _editingMode As Boolean = True

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to specify that this control will only accept numeric values.")>
    <Browsable(True)>
    Public Property ValueIsNumeric As Boolean
        Get
            Return _isNumeric
        End Get
        Set
            _isNumeric = Value
        End Set
    End Property

    Public Property EditingMode As Boolean Implements IEntryControl.EditingMode
        Get
            Return _editingMode
        End Get
        Set(value As Boolean)
            _editingMode = value
            If value Or DisplayOnly Then
                ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
                BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
                [ReadOnly] = True
            Else
                ForeColor = GlobalVariables.DefaultFormControlForegroundColor
                BackColor = GlobalVariables.DefaultFormControlBackgroundColor
                [ReadOnly] = False
            End If
        End Set
    End Property

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to specify that this control is mandatory.")>
    <Browsable(True)>
    Public Property DisplayOnly As Boolean
        Get
            Return _displayOnly
        End Get
        Set
            _displayOnly = Value
            EditingMode = Value
        End Set
    End Property

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to specify that this control is mandatory.")>
    <Browsable(True)>
    Public Property ValueIsMandatory As Boolean

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Security Key to use for this control.")>
    <Browsable(True)>
    Public Property SecurityKey As String

    Public Property ValueIsNullable As Boolean

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("The Default Value that this control will have if initialized or cleared.")>
    <Browsable(True)>
    Public Property DefaultValue As String

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("The Mask to treat as empty value")>
    <Browsable(True)>
    Public Property EmptyMask As String = ""

    'Public Property OldValue() As String
    '    Get
    '        Return _OldValue
    '    End Get
    '    Set(ByVal value As String)
    '        _OldValue = value
    '    End Set
    'End Property

    Public Sub New()
        MyBase.New()
        'Dim myCIintl As New CultureInfo("en-GB", False)
        Text = ""
        Width = 200
        DisplayOnly = False
        CausesValidation = True
        'Culture = myCIintl
        BackColor = SystemColors.ControlLight
        ContextMenuStrip = ContextMenuStrip1
    End Sub

    Public Sub EnterHandler(sender As Object, e As EventArgs) Handles MyBase.Enter
        If Not _editingMode Then
            ForeColor = GlobalVariables.DefaultFormControlEditingForegroundColor
            BackColor = GlobalVariables.DefaultFormControlEditingBackgroundColor
        End If
    End Sub

    Public Sub LeaveHandler(sender As Object, e As EventArgs) Handles MyBase.Leave
        If Not _editingMode Then
            ForeColor = GlobalVariables.DefaultFormControlForegroundColor
            BackColor = GlobalVariables.DefaultFormControlBackgroundColor
        End If
    End Sub

    'Public Sub DisableHandler(Sender As Object, e As EventArgs) Handles MyBase.EnabledChanged
    '    ForeColor = CType(IIf(Enabled, Color.Black, SystemColors.ControlLight), Color)
    '    BackColor = CType(IIf(Enabled, Color.White, SystemColors.ControlLight), Color)
    'End Sub

    Public Sub CMaskedTextBox_Validating(sender As Object, e As CancelEventArgs) Handles MyBase.Validating
        'Dim errorMsg As String
        'If ValueIsNumeric Then
        '    If Not IsNumeric(Text) Then
        '        If ValueIsNullable And (Text.Trim() = "" Or Text.Trim() = EmptyMask) Then
        '            Text = Nothing
        '            '' nothing to do
        '            ' blank values allowed for nullable fields
        '        Else
        '            e.Cancel = True
        '            errorMsg = "Sorry, only numeric values allowed for this field! The value <" + Text + "> is Not allowed. Reverting to previous value."
        '            MessageBox.Show(errorMsg)
        '            Undo()
        '            'MyErrorProvider.ShowErrorMessage(ErrorMsg)
        '        End If
        '    End If
        'Else
        '    If ValueIsNullable And (Text.Trim() = "" Or Text.TrimEnd() = EmptyMask) Then
        '        Text = Nothing
        '        '' nothing to do
        '        ' blank values allowed for nullable fields
        '    End If
        'End If
    End Sub

#Region "Constant Declarations#"

    ' Text Menu Captions
    Const TextFind = "Find on this field"

    Const TextUndo = "Undo Last Cut/Paste/Delete"
    Const TextCut = "Cut Selected Text"
    Const TextCopy = "Copy Selected Text"
    Const TextPaste = "Paste Text"
    Const TextDelete = "Delete Selected Text"
    Const TextSelectAll = "Select All Text"

#End Region

    Private Sub TextBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
        HandleMouseUp(sender, e)
    End Sub

    Private Sub HandleMouseUp(control As Object, e As MouseEventArgs)

        ' Checking the Mouse right Button
        If e.Button = MouseButtons.Right Then
            control.ContextMenuStrip.Show(control, New Point(e.X, e.Y))
        End If
    End Sub

    Private Sub HandlePopup(sender As Object, e As EventArgs) Handles ContextMenuStrip1.Opening
        ContextHandler(sender, e)
    End Sub

    Protected Sub ContextHandler(sender As Object, e As EventArgs)

        Const separator = "-"

        ContextMenuStrip1.Items.Clear()

        Dim menuItemFind As New ToolStripMenuItem With {
                .Text = TextFind
                }
        ContextMenuStrip1.Items.Add(menuItemFind)
        menuItemFind.ShortcutKeys = Keys.Control Or Keys.F
        menuItemFind.ShortcutKeyDisplayString = "Ctrl-F"
        AddHandler menuItemFind.Click, AddressOf MenuItemFind_Click

        Dim menuItemUndo As New ToolStripMenuItem With {
                .Text = TextUndo
                }
        ContextMenuStrip1.Items.Add(menuItemUndo)
        menuItemUndo.ShortcutKeys = Keys.Control Or Keys.Z
        menuItemUndo.ShortcutKeyDisplayString = "Ctrl-Z"
        'menuItemUndo.Enabled = (IIf(SampleTextBox.CanUndo, True, False))
        AddHandler menuItemUndo.Click, AddressOf MenuItemUndo_Click

        ContextMenuStrip1.Items.Add(separator)

        Dim menuItemCut As New ToolStripMenuItem With {
                .Text = TextCut
                }
        ContextMenuStrip1.Items.Add(menuItemCut)
        ' menuItemCut.Enabled = (IIf(SampleTextBox.SelectionLength = 0, False, True))
        menuItemCut.ShortcutKeys = Keys.Control Or Keys.X
        menuItemCut.ShortcutKeyDisplayString = "Ctrl-X"
        AddHandler menuItemCut.Click, AddressOf MenuItemCut_Click

        Dim menuItemCopy As New ToolStripMenuItem With {
                .Text = TextCopy
                }
        ContextMenuStrip1.Items.Add(menuItemCopy)
        menuItemCopy.ShortcutKeys = Keys.Control Or Keys.C
        menuItemCopy.ShortcutKeyDisplayString = "Ctrl-C"
        'menuItemCopy.Enabled = (IIf(SampleTextBox.SelectionLength = 0, False, True))
        AddHandler menuItemCopy.Click, AddressOf MenuItemCopy_Click

        Dim menuItemPaste As New ToolStripMenuItem With {
                .Text = TextPaste
                }
        ContextMenuStrip1.Items.Add(menuItemPaste)
        menuItemPaste.ShortcutKeys = Keys.Control Or Keys.V
        menuItemPaste.ShortcutKeyDisplayString = "Ctrl-V"
        'menuItemPaste.Enabled = (IIf(My.Computer.Clipboard.GetText() = "", False, True))
        AddHandler menuItemPaste.Click, AddressOf MenuItemPaste_Click

        Dim menuItemDelete As New ToolStripMenuItem With {
                .Text = TextDelete
                }
        ContextMenuStrip1.Items.Add(menuItemDelete)
        menuItemDelete.ShortcutKeys = Keys.Delete
        menuItemDelete.ShortcutKeyDisplayString = "Delete"
        'menuItemDelete.Enabled = (IIf(SampleTextBox.SelectionLength = 0, False, True))
        AddHandler menuItemDelete.Click, AddressOf MenuItemDelete_Click

        ContextMenuStrip1.Items.Add(separator)

        Dim menuItemSelectAll As New ToolStripMenuItem With {
                .Text = TextSelectAll
                }
        ContextMenuStrip1.Items.Add(menuItemSelectAll)
        menuItemSelectAll.ShortcutKeys = Keys.Control Or Keys.A
        menuItemSelectAll.ShortcutKeyDisplayString = "Ctrl-A"
        'menuItemSelectAll.Enabled = (IIf(SampleTextBox.SelectionLength = SampleTextBox.Text.Length Or SampleTextBox.SelectionLength = SampleTextBox.Text.Trim.Length, False, True))
        AddHandler menuItemSelectAll.Click, AddressOf MenuItemSelectAll_Click

        ContextMenuStrip1.Items.Add(separator)

        'End If
    End Sub

    Private Sub MenuItemFind_Click()
        'Dim MyForm = FindForm()
        'Dim SearchForm = New CFindForm
        ''SearchForm.Show()
        'SearchForm.ShowDialog()
        '_TextToSearch = SearchForm.TextToSearch
        '_SearchAnywhere = Convert.ToBoolean(SearchForm.GetSearchAnywhere)
        'SearchForm.Dispose()
        'If _TextToSearch <> "" Then

        '    CallByName(MyForm, "FindField", CallType.Method, Me)

        'End If
    End Sub

    Public Function GetTextToSearch() As String
        Return _textToSearch
    End Function

    Public Function GetSearchAnywhere() As Boolean
        Return _searchAnywhere
    End Function

    Private Sub MenuItemCut_Click()
        Cut()
    End Sub

    Private Sub MenuItemCopy_Click()
        Copy()
    End Sub

    Private Sub MenuItemPaste_Click()
        Paste()
    End Sub

    Private Sub MenuItemSelectAll_Click()
        SelectAll()
    End Sub

    Private Sub MenuItemUndo_Click()
        Undo()
    End Sub

    Private Sub MenuItemDelete_Click()
        Dim clipBoardText As String
        clipBoardText = Clipboard.GetText()
        Cut()
        If clipBoardText <> "" Then
            Clipboard.SetText(clipBoardText)
        End If
    End Sub

    Private Sub CMaskedTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.Send("{TAB}")
            'SendWait("{TAB}")
        End If
    End Sub

    Public ReadOnly Property Translatable As Boolean Implements IEntryControl.Translatable
        Get
            Return False
        End Get
    End Property

    'Public Sub MakeEditable(editableControl As Boolean) Implements IEntryControl.MakeEditable
    '    EditsAllowed = Not editableControl
    'End Sub

    Public Property EditsAllowed As Boolean
        Get
            Return _editsALlowed
        End Get
        Set(value As Boolean)
            _editsALlowed = value
        End Set
    End Property

    'Public Sub MakeVisible(visibleControl As Boolean) Implements IEntryControl.MakeVisible
    '    MakeVisible(visibleControl)
    'End Sub

    'Public Sub MakeViewable(ViewableControl As Boolean) Implements IEntryControl.MakeViewable
    '    ' not applicable
    'End Sub

    'Public Sub MakeSelectable(selectableControl As Boolean) Implements IEntryControl.MakeSelectable
    '    Enabled = selectableControl
    'End Sub
End Class