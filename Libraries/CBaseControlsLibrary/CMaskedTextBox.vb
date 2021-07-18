Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports AATM.Libraries.AatmInterfaces
Imports AATM.Libraries.GlobalFuncNSub

Public Class CMaskedTextBox
    Inherits MaskedTextBox
    Implements IEntryControl, IFindableControl, ILinkedLabel

    Private _defaultVal As String
    Private _isNumeric As Boolean
    Private _oldValue As String
    Private _editsAllowed As Boolean = False
    Private WithEvents ContextMenuStrip1 As New ContextMenuStrip
    Private _editingMode As Boolean = False
    Private _searchField As String
    Private _translatable As Boolean = False

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

    <Category("Custom Properties")>
    <DefaultValue(False)>
    <Description("Set to the lowest allowed value for this control")>
    <Browsable(True)>
    Public Property MinimumValue As Decimal? = Nothing

    <Category("Custom Properties")>
    <DefaultValue(False)>
    <Description("Set to the highest allowed value for this control")>
    <Browsable(True)>
    Public Property MaximumValue As Decimal? = Nothing

    Public Property DateTimePickerParent As Control = Nothing

    Public Property EditingMode As Boolean Implements IEntryControl.EditingMode
        Get
            Return _editingMode
        End Get
        Set(value As Boolean)
            _editingMode = value
            If value Then
                If DisplayOnly Then
                    [ReadOnly] = True
                    ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
                    BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
                Else
                    [ReadOnly] = False
                    ForeColor = GlobalVariables.DefaultFormControlForegroundColor
                    BackColor = GlobalVariables.DefaultFormControlBackgroundColor
                End If
            Else
                ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
                BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
                [ReadOnly] = True
            End If
        End Set
    End Property

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to specify that this control is mandatory.")>
    <Browsable(True)>
    Public Property DisplayOnly As Boolean

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to specify that this field will contain a date.")>
    <Browsable(True)>
    Public Property DateField As Boolean

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

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(String))>
    <Description("Specify here the displayed field name to search")>
    <Browsable(True)>
    Public Property SearchField As String
        Get
            Return _searchField
        End Get
        Set(value As String)
            _searchField = value
        End Set
    End Property

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
        If EditingMode And Not DisplayOnly Then
            ForeColor = GlobalVariables.DefaultFormControlEditingForegroundColor
            BackColor = GlobalVariables.DefaultFormControlEditingBackgroundColor
        Else
            ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
            BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
        End If
    End Sub

    Public Sub LeaveHandler(sender As Object, e As EventArgs) Handles MyBase.Leave
        If EditingMode And Not DisplayOnly Then
            ForeColor = GlobalVariables.DefaultFormControlForegroundColor
            BackColor = GlobalVariables.DefaultFormControlBackgroundColor
        Else
            ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
            BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
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

#Region "Declarations#"

    ' Text Menu Captions
    Private ReadOnly _textFind = MessagingLibrary.Messaging.TranslateCaption("Find on this field")

    Private ReadOnly _textCut = MessagingLibrary.Messaging.TranslateCaption("Cut Selected Text")
    Private ReadOnly _textCopy = MessagingLibrary.Messaging.TranslateCaption("Copy Selected Text")
    Private ReadOnly _textPaste = MessagingLibrary.Messaging.TranslateCaption("Paste Text")
    Private ReadOnly _textUndo = MessagingLibrary.Messaging.TranslateCaption("Undo Last Action")
    Private ReadOnly _textDelete = MessagingLibrary.Messaging.TranslateCaption("Delete Selected Text")
    Private ReadOnly _textSelectAll = MessagingLibrary.Messaging.TranslateCaption("Select All Text")

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
                .Text = _textFind
                }
        ContextMenuStrip1.Items.Add(menuItemFind)
        menuItemFind.ShortcutKeys = Keys.Control Or Keys.F
        menuItemFind.ShortcutKeyDisplayString = "Ctrl-F"
        AddHandler menuItemFind.Click, AddressOf MenuItemFind_Click

        Dim menuItemUndo As New ToolStripMenuItem With {
                .Text = _textUndo
                }
        ContextMenuStrip1.Items.Add(menuItemUndo)
        menuItemUndo.ShortcutKeys = Keys.Control Or Keys.Z
        menuItemUndo.ShortcutKeyDisplayString = "Ctrl-Z"
        'menuItemUndo.Enabled = (IIf(SampleTextBox.CanUndo, True, False))
        AddHandler menuItemUndo.Click, AddressOf MenuItemUndo_Click

        ContextMenuStrip1.Items.Add(separator)

        Dim menuItemCut As New ToolStripMenuItem With {
                .Text = _textCut
                }
        ContextMenuStrip1.Items.Add(menuItemCut)
        ' menuItemCut.Enabled = (IIf(SampleTextBox.SelectionLength = 0, False, True))
        menuItemCut.ShortcutKeys = Keys.Control Or Keys.X
        menuItemCut.ShortcutKeyDisplayString = "Ctrl-X"
        AddHandler menuItemCut.Click, AddressOf MenuItemCut_Click

        Dim menuItemCopy As New ToolStripMenuItem With {
                .Text = _textCopy
                }
        ContextMenuStrip1.Items.Add(menuItemCopy)
        menuItemCopy.ShortcutKeys = Keys.Control Or Keys.C
        menuItemCopy.ShortcutKeyDisplayString = "Ctrl-C"
        'menuItemCopy.Enabled = (IIf(SampleTextBox.SelectionLength = 0, False, True))
        AddHandler menuItemCopy.Click, AddressOf MenuItemCopy_Click

        Dim menuItemPaste As New ToolStripMenuItem With {
                .Text = _textPaste
                }
        ContextMenuStrip1.Items.Add(menuItemPaste)
        menuItemPaste.ShortcutKeys = Keys.Control Or Keys.V
        menuItemPaste.ShortcutKeyDisplayString = "Ctrl-V"
        'menuItemPaste.Enabled = (IIf(My.Computer.Clipboard.GetText() = "", False, True))
        AddHandler menuItemPaste.Click, AddressOf MenuItemPaste_Click

        Dim menuItemDelete As New ToolStripMenuItem With {
                .Text = _textDelete
                }
        ContextMenuStrip1.Items.Add(menuItemDelete)
        menuItemDelete.ShortcutKeys = Keys.Delete
        menuItemDelete.ShortcutKeyDisplayString = "Delete"
        'menuItemDelete.Enabled = (IIf(SampleTextBox.SelectionLength = 0, False, True))
        AddHandler menuItemDelete.Click, AddressOf MenuItemDelete_Click

        ContextMenuStrip1.Items.Add(separator)

        Dim menuItemSelectAll As New ToolStripMenuItem With {
                .Text = _textSelectAll
                }
        ContextMenuStrip1.Items.Add(menuItemSelectAll)
        menuItemSelectAll.ShortcutKeys = Keys.Control Or Keys.A
        menuItemSelectAll.ShortcutKeyDisplayString = "Ctrl-A"
        'menuItemSelectAll.Enabled = (IIf(SampleTextBox.SelectionLength = SampleTextBox.Text.Length Or SampleTextBox.SelectionLength = SampleTextBox.Text.Trim.Length, False, True))
        AddHandler menuItemSelectAll.Click, AddressOf MenuItemSelectAll_Click

        ContextMenuStrip1.Items.Add(separator)

        'End If
    End Sub

    <Category("Custom Properties")>
    <Description("Select the label to which this control is linked.")>
    <Browsable(True)>
    Public Property LinkedLabel As CLabel Implements ILinkedLabel.LinkedLabel

    Public Function GetControlDescription(Optional defaultDescription As String = Nothing) Implements ILinkedLabel.GetControlDescription
        Dim description As String
        If LinkedLabel Is Nothing OrElse LinkedLabel.Text Is Nothing OrElse LinkedLabel.Text = "" Then
            description = If(defaultDescription Is Nothing OrElse defaultDescription = "", Name, defaultDescription)
        Else
            description = LinkedLabel.Text
        End If
        Return description
    End Function

    Private Sub MenuItemFind_Click()
        Dim myForm = FindForm()
        Dim searchForm As CFindForm
        Dim description = GetControlDescription(FieldName)
        searchForm = New CFindForm(Me)
        If DateTimePickerParent IsNot Nothing Then
            Dim dateTimePicker As CCustomDateTimePicker
            dateTimePicker = DateTimePickerParent
            FieldName = dateTimePicker.Name.Substring(3)
            FindDataType = IFindableControl.DataTypeEnum.DateTime
            searchForm.SetFieldDescription(description)
        Else
            'Dim x = CallByName(myForm, "GetFieldType", CallType.Method, {FieldName})
            Dim x = Invoker.InvokeFunction(myForm, "GetFieldType", CallType.Method, {FieldName})
            FindDataType = GetObjectDataType(x)
            FieldName = Name.Substring(3)
            searchForm.SetFieldDescription(GetControlDescription(FieldName))
        End If

        searchForm.ShowDialog()
        searchForm.Dispose()
        'CallByName(myForm, "FindFieldNew", CallType.Method, Me)
        Invoker.InvokeFunction(myForm, "FindFieldNew", {Me})
    End Sub

    'Public Function GetTextToSearch() As String
    '    Return _textToSearch
    'End Function

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

    Private Sub CMaskedTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            SendKeys.SendWait("{TAB}")
        End If
    End Sub

    'Private Sub CMaskedTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '            SendKeys.SendWait("{TAB}")
    '        e.Handled = True
    '        e.SuppressKeyPress = True
    '        'SendKeys.Send("{TAB}")
    '        'SendKeys.SendWait("{TAB}")
    '    End If
    'End Sub

    Public Property Translatable As Boolean Implements IEntryControl.Translatable
        Get
            Return False
        End Get
        Set(value As Boolean)
            _translatable = value
        End Set
    End Property

    'Public Sub MakeEditable(editableControl As Boolean) Implements IEntryControl.MakeEditable
    '    EditsAllowed = Not editableControl
    'End Sub

    Public Property EditsAllowed As Boolean
        Get
            Return _editsAllowed
        End Get
        Set(value As Boolean)
            _editsAllowed = value
        End Set
    End Property

#Region "FindableControl"

    <Category("Custom Properties")>
    <Description("Set to True to enable find on this field.")>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Property FindEnabled As Boolean Implements IFindableControl.FindEnabled

    Public ReadOnly Property SearchMode As IFindableControl.SearchModeEnum Implements IFindableControl.SearchMode
        Get
            Return IFindableControl.SearchModeEnum.Date
        End Get
    End Property

    Public ReadOnly Property FindDataSource As Object Implements IFindableControl.FindDataSource
        Get
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property FindDisplayMember As String Implements IFindableControl.FindDisplayMember
        Get
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property FindValueMember As String Implements IFindableControl.FindValueMember
        Get
            Return Nothing
        End Get
    End Property

    Private Property IgnoreCase As Boolean Implements IFindableControl.IgnoreCase

    Public Property SearchPlace As IFindableControl.SearchPlaceEnum Implements IFindableControl.SearchPlace

    Public Property BegFindValue As Object Implements IFindableControl.BegFindValue

    Public Property EndFindValue As Object Implements IFindableControl.EndFindValue

    Public Property FieldName As String Implements IFindableControl.FieldName

    Public Property FindDataType As IFindableControl.DataTypeEnum Implements IFindableControl.FindDataType
        Get
            Return IFindableControl.DataTypeEnum.Date
        End Get
        Set(value As IFindableControl.DataTypeEnum)

        End Set
    End Property

    Public Property FieldDescription As String Implements IFindableControl.FieldDescription

#End Region

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