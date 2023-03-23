Imports System.ComponentModel
Imports System.Drawing
Imports System.Linq.Expressions
Imports System.Threading
Imports System.Windows.Forms
Imports AATM.Libraries.AatmInterfaces
Imports AATM.Libraries.BaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub

Public Class CbComboBox
    Inherits BCombobox
    Implements IEntryControl, ILinkedLabel, IFindableControl

#Region "Custom Properties"

    'Private MyErrorProvider As New ErrorProviderExtended
    Private _displayOnly As Boolean

    Private _editable As Boolean
    Private _translatable As Boolean = False
    Private _editingMode As Boolean = True
    Private _filterRule As Expression(Of Func(Of String, String, Boolean))
    Private _filterRuleCompiled As Func(Of String, Boolean)
    Private _propertySelector As Expression(Of Func(Of ObjectCollection, IEnumerable(Of String)))
    Private _readOnlyCombo As Boolean
    'Private _suggestListOrderRule As Expression(Of Func(Of String, String))
    'Private _suggestListOrderRuleCompiled As Func(Of String, String)
    'Private ReadOnly _defaultDropDownHeight As Int16
    Private ReadOnly _defaultDropdownStyle As ComboBoxStyle
    Private ReadOnly _defaultMaxDropDownItems As Int16
    'Private ReadOnly _suggestBindingList As BindingList(Of String) = New BindingList(Of String)()
    Private Shared ReadOnly KeysToHandle As Keys() = {Keys.Down, Keys.Up, Keys.Enter, Keys.Escape}
    Private WithEvents _contextMenuStrip1 As New ContextMenuStrip
    'Protected PropertySelectorCompiled As Func(Of ObjectCollection, IEnumerable(Of String))
    Public DataSourceProgrammaticChange As Boolean = False
    'Protected SuggestListForm As CListBoxForm = New CListBoxForm

    Public Property ChangingSearchValueOnly As Boolean = False

    Public Shared Property Copy As String = "Copy Selected Text"

    Public Property CurrentSearchTerm As String = ""

    Public Shared Property Cut As String = "Cut Selected Text"

    Public Property DefaultValue As Object

    Public Shared Property Delete As String = "Delete Selected Text"
    Public ComboBoxValueChanged As Boolean = False
    Private _lastValue As Object = Nothing

    <Bindable(True)>
    <Category("Custom Properties")>
    <DefaultValue(False)>
    <Description("Set to True to specify that this control is for DisplayOnly.")>
    <Browsable(True)>
    Public Property DisplayOnly As Boolean
        Get
            Return _displayOnly
        End Get
        Set(value As Boolean)
            If _displayOnly <> value Then
                _displayOnly = value
            End If
            If value Then
                ReadOnlyCombo = True
            Else
                ReadOnlyCombo = False
            End If
        End Set
    End Property

    <Category("Custom Properties")>
    <DefaultValue(False)>
    <Description("Set to True to specify that this control can be edited.")>
    Public Property Editable As Boolean
        Get
            Return _editable
        End Get
        Set
            _editable = Value
            DisplayOnly = Value
        End Set
    End Property

    <Category("Custom Properties")>
    <DefaultValue(False)>
    <Description("Set to True to specify that this control value is hidden (used for secured controls)")>
    Public Property Hidden As Boolean

    Public Property EditingMode As Boolean Implements IEntryControl.EditingMode
        Get
            Return _editingMode
        End Get
        Set(value As Boolean)
            _editingMode = value
            If value Then
                If DisplayOnly Then
                    ReadOnlyCombo = True
                    'ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
                    'BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
                    'MaxDropDownItems = 1
                    'DropDownStyle = ComboBoxStyle.Simple
                    'DropDownHeight = 1
                Else
                    ReadOnlyCombo = False
                    'ForeColor = GlobalVariables.DefaultFormControlForegroundColor
                    'BackColor = GlobalVariables.DefaultFormControlBackgroundColor
                    'MaxDropDownItems = _defaultMaxDropDownItems
                    'IntegralHeight = True
                    DropDownStyle = ComboBoxStyle.DropDown
                    'DropDownHeight = _defaultDropDownHeight
                End If
            Else
                ReadOnlyCombo = True
                'ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
                'BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
                'DropDownStyle = ComboBoxStyle.Simple
                'DropDownHeight = 1
            End If
        End Set
    End Property

    'Public Property FilterRule As Expression(Of Func(Of String, String, Boolean))
    '    Get
    '        Return _filterRule
    '    End Get
    '    Set(ByVal value As Expression(Of Func(Of String, String, Boolean)))
    '        If value Is Nothing Then Return
    '        _filterRule = value
    '        _filterRuleCompiled = Function(item) value.Compile()(item, Text)
    '    End Set
    'End Property

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to make this control visible only when in editing or adding mode")>
    <Browsable(True)>
    Public Property HideWhenNotEditingOrAdding As Boolean = False

    '<Category("Custom Properties")>
    '<Description("Select the label to which this control is linked.")>
    '<Browsable(True)>
    'Public Property LinkedLabel As Label Implements IEntryControl.LinkedLabel

    Public Property OldValue As Integer

    Public Property OriginalDataSource As Object

    Public Property OriginalList As Object() = Nothing

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Override DropDownList style with custom built feature.")>
    <Browsable(True)>
    Public Property OverrideDropDownStyleList As Boolean

    'Public Property BorderColor As Color
    Public Property PreviousSearchTerm As String

    'Public Property PropertySelector As Expression(Of Func(Of ObjectCollection, IEnumerable(Of String)))
    '    Get
    '        Return _propertySelector
    '    End Get
    '    Set(ByVal value As Expression(Of Func(Of ObjectCollection, IEnumerable(Of String))))
    '        If value Is Nothing Then Return
    '        _propertySelector = value
    '        PropertySelectorCompiled = value.Compile()
    '    End Set
    'End Property

    Public Property ReadOnlyCombo As Boolean
        Get
            Return _readOnlyCombo
        End Get
        Set
            ' If the value isn't changing, then do nothing
            'If Value = _readOnlyCombo Then Exit Property
            _readOnlyCombo = Value
            If Value Then
                DropDownStyle = ComboBoxStyle.Simple
                ' MaxDropDownItems = 1
                If Hidden Then
                    ForeColor = Color.Black
                    BackColor = Color.Black
                Else
                    ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
                    BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
                End If
                'DropDownHeight = Height
            Else
                MaxDropDownItems = _defaultMaxDropDownItems
                DropDownStyle = _defaultDropdownStyle
                If Hidden Then
                    ForeColor = Color.Black
                    BackColor = Color.Black
                Else
                    ForeColor = GlobalVariables.DefaultFormControlForegroundColor
                    BackColor = GlobalVariables.DefaultFormControlBackgroundColor
                End If
                'DropDownHeight = _defaultDropDownHeight
            End If
        End Set
    End Property

    'Public Property SuggestBoxHeight As Integer
    '    Get
    '        Return SuggestListForm.Height
    '    End Get
    '    Set(ByVal value As Integer)
    '        If value > 0 Then SuggestListForm.Height = value
    '    End Set
    'End Property

    'Public Property SuggestListOrderRule As Expression(Of Func(Of String, String))
    '    Get
    '        Return _suggestListOrderRule
    '    End Get
    '    Set(ByVal value As Expression(Of Func(Of String, String)))
    '        If value Is Nothing Then Return
    '        _suggestListOrderRule = value
    '        _suggestListOrderRuleCompiled = value.Compile()
    '    End Set
    'End Property

    Public Property TextToSearch As String

    Public Property Translatable As Boolean Implements IEntryControl.Translatable
        Get
            Return False
        End Get
        Set(value As Boolean)
            _translatable = value
        End Set
    End Property

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to specify that this control is mandatory.")>
    <Browsable(True)>
    Public Property ValueIsMandatory As Boolean

    Public Property ValueIsNullable As Boolean

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to specify that this control will only accept numeric values.")>
    <Browsable(True)>
    Public Property ValueIsNumeric As Boolean

    '<Category("Custom Properties")>
    '<DefaultValue(False)>
    '<Description("Set to True to specify that this control value will not be shown.")>
    '<Browsable(True)>
    'Public Property Viewable As Boolean
    '    Get
    '        Return _viewable
    '    End Get
    '    Set
    '        _viewable = Value
    '        If Not Value Then
    '            Width = 0
    '        End If
    '    End Set
    'End Property

    Public Shared Property WmPaint1 As Integer = &HF

    '<Bindable(True)>
    '<Category("Properties")>
    '<DefaultValue(GetType(Boolean))>
    '<Description("Set to True to specify that this control will only accept numeric values.")>
    '<Browsable(True)>
    'Private Property LimitToList As Boolean = False

    'Public Sub OnKeyDownPressed(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
    '    If DisplayOnly Then
    '        e.SuppressKeyPress = True
    '    Else
    '        If e.KeyCode = Keys.Enter Then
    '            SendKeys.Send("{TAB}")
    '            e.Handled = True
    '            e.SuppressKeyPress = True
    '            'SendKeys.SendWait("{TAB}")
    '        Else
    '            e.Handled = False
    '        End If
    '    End If
    'End Sub

#End Region

#Region "Declarations#"

    ' Text Menu Captions
    Private Shared ReadOnly _textFind = MessagingLibrary.Messaging.TranslateCaption("Find on this field")

    Private Shared ReadOnly _textCut = MessagingLibrary.Messaging.TranslateCaption("Cut Selected Text")
    Private Shared ReadOnly _textCopy = MessagingLibrary.Messaging.TranslateCaption("Copy Selected Text")
    Private Shared ReadOnly _textPaste = MessagingLibrary.Messaging.TranslateCaption("Paste Text")
    Private Shared ReadOnly _textUndo = MessagingLibrary.Messaging.TranslateCaption("Undo Last Action")
    Private Shared ReadOnly _textDelete = MessagingLibrary.Messaging.TranslateCaption("Delete Selected Text")
    Private Shared ReadOnly _textSelectAll = MessagingLibrary.Messaging.TranslateCaption("Select All Text")

#End Region

#Region "Event Handlers"

    Private _previousIndex As Integer
    'Private _findDataType As IFindableControl.DataTypeEnum

    Public Sub EnterHandler(sender As Object, e As EventArgs) Handles MyBase.Enter
        If Hidden Then
            ForeColor = Color.Black
            BackColor = Color.Black
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

    Public Sub LeaveHandler(sender As Object, e As EventArgs) Handles MyBase.Leave
        If Hidden Then
            ForeColor = Color.Black
            BackColor = Color.Black
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

    'Protected Overrides Sub OnDropDown(e As EventArgs)
    '    HideSuggestionBox()
    '    'SetVisibleCore(True)
    '    If DisplayOnly Then
    '        _previousIndex = SelectedIndex
    '    End If
    'End Sub

    'Protected Overrides Sub OnLocationChanged(ByVal e As EventArgs)
    '    MyBase.OnLocationChanged(e)
    '    SetListBoxFormLocation(SuggestListForm)
    'End Sub

    'Protected Overloads Overrides Sub OnLostFocus(e As EventArgs)
    '    If Not SuggestListForm.SuggestListBox.Focused Then
    '        HideSuggestionBox()
    '    End If
    'End Sub

    'Protected Overrides Sub OnGotFocus(e As EventArgs)
    '    MyBase.OnGotFocus(e)
    '    _lastValue = SelectedValue
    'End Sub

    '    Protected Overloads Overrides Sub OnPreviewKeyDown(e As PreviewKeyDownEventArgs)
    '        If Not SuggestListForm.Visible Then
    '            MyBase.OnPreviewKeyDown(e)
    '            Return
    '        End If
    '        Select Case e.KeyCode
    '            Case Keys.Down
    '                If SuggestListForm.SuggestListBox.SelectedIndex < _suggestBindingList.Count - 1 Then
    '                    ' ReSharper disable once ReturnValueOfPureMethodIsNotUsed
    '                    Math.Max(Interlocked.Increment(SuggestListForm.SuggestListBox.SelectedIndex), SuggestListForm.SuggestListBox.SelectedIndex - 1)
    '                End If
    '                Return
    '            Case Keys.Up
    '                If SuggestListForm.SuggestListBox.SelectedIndex > 0 Then
    '#Disable Warning ReturnValueOfPureMethodIsNotUsed
    '                    Math.Max(Interlocked.Decrement(SuggestListForm.SuggestListBox.SelectedIndex), SuggestListForm.SuggestListBox.SelectedIndex + 1)
    '#Enable Warning ReturnValueOfPureMethodIsNotUsed
    '                End If
    '                Return
    '            Case Keys.Enter
    '                Text = SuggestListForm.SuggestListBox.Text
    '                [Select](0, Text.Length)
    '                SuggestListForm.Hide()
    '                SuggestListForm.Visible = False
    '                Return
    '            Case Keys.Escape
    '                HideSuggestionBox()
    '                Return
    '        End Select
    '        MyBase.OnPreviewKeyDown(e)
    '    End Sub

    'Private Sub HideDropDown(hide As Boolean)
    '    If hide Then
    '        DropDownStyle = ComboBoxStyle.Simple
    '        MaxDropDownItems = 1
    '        If Hidden Then
    '            ForeColor = Color.Black
    '            BackColor = Color.Black
    '        Else
    '            ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
    '            BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
    '        End If
    '        DropDownHeight = Height
    '    Else
    '        MaxDropDownItems = _defaultMaxDropDownItems
    '        DropDownStyle = _defaultDropdownStyle
    '        If Hidden Then
    '            ForeColor = Color.Black
    '            BackColor = Color.Black
    '        Else
    '            ForeColor = GlobalVariables.DefaultFormControlForegroundColor
    '            BackColor = GlobalVariables.DefaultFormControlBackgroundColor
    '        End If
    '        DropDownHeight = _defaultDropDownHeight
    '    End If
    'End Sub



    'Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
    '    MyBase.OnTextChanged(e)
    '    If Not Focused Then Return
    '    _suggestBindingList.Clear()
    '    _suggestBindingList.RaiseListChangedEvents = False
    '    '    PropertySelectorCompiled(Items).Where(_filterRuleCompiled).OrderBy(_suggestListOrderRuleCompiled).ToList().ForEach(AddressOf _suggestBindingList.Add)
    '    _suggestBindingList.RaiseListChangedEvents = True
    '    _suggestBindingList.ResetBindings()
    '    Dim showForm As Boolean
    '    showForm = _suggestBindingList.Any()
    '    'SuggestListForm.Visible = showForm
    '    If showForm Then
    '        SetListBoxFormLocation(SuggestListForm)
    '        SuggestListForm.Visible = True
    '        'Me.SendToBack()
    '        'SuggestListForm.BringToFront()
    '        'Me.Focus()
    '    Else
    '        'SuggestListForm.Hide()
    '        'Me.SetVisibleCore(True)
    '    End If
    '    If _suggestBindingList.Count = 0 And LimitToList Then
    '        Beep()
    '        SendKeys.SendWait("{BACKSPACE}")
    '    ElseIf _suggestBindingList.Count = 1 AndAlso _suggestBindingList.Single().Length = Text.Trim().Length Then
    '        Text = _suggestBindingList.Single()
    '        [Select](0, Text.Length)
    '        HideSuggestionBox()
    '    End If
    'End Sub

    'Private Sub caComboBox_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
    '    HandleMouseUp(sender, e)
    'End Sub

    'Private Sub HandleMouseUp(control As Object, e As MouseEventArgs)
    '    ' Checking the Mouse right Button
    '    If e.Button = MouseButtons.Right Then
    '        control.ContextMenuStrip.Show(control, New Point(e.X, e.Y))
    '    End If
    'End Sub

    'Private Sub HandlePopup(sender As Object, e As EventArgs) Handles _contextMenuStrip1.Opening
    '    ContextHandler(sender, e)
    'End Sub

    'Private Overloads Sub OnBindingContextChanged(sender As Object, e As EventArgs) Handles MyBase.BindingContextChanged
    '    'PropertySelectorCompiled = Function(collection) collection.Cast(Of Lookup.LookupData)().[Select](Function(p) p.Name)
    '    PropertySelectorCompiled = Function(collection) collection.Cast(Of DataRow)().Select(Function(p) p.ItemArray(0))
    'End Sub

    'Private Shadows Sub OnParentChanged(ByVal sender As Object, ByVal e As EventArgs)
    '    SetListBoxFormLocation(SuggestListForm)
    '    SuggestListForm.SuggestListBox.Font = New Font("Segoe UI", 9)
    'End Sub

#End Region

#Region "Methods"

    Public Sub New()
        MyBase.New()
        Dim myFont As New Font("Sans Serif", 10.0!, FontStyle.Regular)
        DoubleBuffered = True
        ContextMenuStrip = _contextMenuStrip1
        Margin = New Padding(1, 1, 1, 1)
        FlatStyle = FlatStyle.Standard
        Font = myFont
        BorderColor = Color.DimGray
        'ValueMember = "IdNo"
        'DisplayMember = "Name"
        _defaultMaxDropDownItems = MaxDropDownItems
        _defaultDropdownStyle = DropDownStyle
        '_defaultDropDownHeight = DropDownHeight
        Text = ""
        '_filterRuleCompiled = Function(s) s.ToLower().Contains(Text.Trim().ToLower())
        '_suggestListOrderRuleCompiled = Function(s) s
        'PropertySelectorCompiled = Function(collection) collection.Cast(Of String)()
        'SetStyle(ControlStyles.EnableNotifyMessage, True)
        'SuggestListForm.SuggestListBox.DataSource = _suggestBindingList
        'SuggestListForm.SuggestListBox.ForeColor = Color.Green
        'AddHandler SuggestListForm.SuggestListBox.Click, AddressOf SuggestListBoxOnClick
        'AddHandler ParentChanged, AddressOf OnParentChanged

    End Sub

    Public Function GetValue()
        If SelectedItem IsNot Nothing Then
            Return ValueMember
            'If ValueMember.ToLower() = "idno" Then
            '    Return CType(SelectedItem, Lookup.LookupData).IdNo
            'ElseIf ValueMember.ToLower() = "name" Then
            '    Return CType(SelectedItem, Lookup.LookupData).Name
            'ElseIf ValueMember.ToLower() = "code" Then
            '    Return CType(SelectedItem, Lookup.LookupData).Code
            'ElseIf ValueMember.ToLower() = "index" Then
            '    Return CType(SelectedItem, Lookup.LookupData).Index
            'Else
            '    Return Text
            'End If
        Else
            Return Nothing
        End If
    End Function

    Public Function GetNullableValue(Of T)()
        Dim x = GetValue()
        If x Is Nothing Then
            Return Nothing
        Else
            Return CType(x, T)
        End If
    End Function

    Public Sub SetValue(ByRef value)
        If value Is Nothing Then
            Text = Nothing
        Else
            If ValueMember.ToLower() = "idno" Then
                If IsNumeric(value) Then
                    IdNoSearch(value)
                Else
                    SelectedIndex = -1
                End If
            ElseIf ValueMember.ToLower() = "code" Then
                CodeSearch(value)
            Else
                NameSearch(value)
                'SelectedValue = value
                'Text = value
                'SelectedText = value
            End If
        End If
    End Sub

    Public Property DataValue

    Private Sub IdNoSearch(value As Object)
        Dim returnValue As Int32
        Dim found As Boolean = False
        Dim i = 0
        If DataSource IsNot Nothing Then
            For Each item In DataSource
                If item.IdNo = value Then
                    'SelectedIndex = i
                    'Dim lReadOnlyCombo As Boolean = Visible
                    If Visible Then
                        SelectedItem = DataSource(i)
                    Else
                        SelectedItem = DataSource(i)
                    End If
                    '    Visible = True
                    '    DisplayOnly = False
                    '    ReadOnlyCombo = False
                    '    SelectedItem = DataSource(i)
                    '    Visible = False
                    'End If
                    found = True
                    Exit For
                End If
                i += 1
            Next
            If Not found Then
                SelectedIndex = -1
                returnValue = Nothing
                If value IsNot Nothing Then
                    Text = value
                End If
            End If
        Else
            SelectedIndex = -1
        End If
    End Sub

    Private Sub CodeSearch(value As Object)
        Dim found As Boolean = False
        Dim i = 0
        If DataSource IsNot Nothing Then
            For Each item In DataSource
                If item.Code = value Then
                    SelectedItem = DataSource(i)
                    found = True
                    Exit For
                End If
                i += 1
            Next
            If Not found Then
                If value IsNot Nothing Then
                    Text = value
                End If
                SelectedIndex = -1
            End If
        Else
            SelectedIndex = -1
        End If
    End Sub

    Private Sub NameSearch(value As Object)
        Dim found As Boolean = False
        Dim i = 0
        If DataSource IsNot Nothing Then
            For Each item In DataSource
                If item.Name = value Then
                    SelectedItem = DataSource(i)
                    found = True
                    Exit For
                End If
                i += 1
            Next
            If Not found Then
                If value IsNot Nothing Then
                    Text = value
                End If
                SelectedIndex = -1
            End If
        Else
            SelectedIndex = -1
        End If
    End Sub

    Protected Sub ContextHandler(sender As Object, e As EventArgs)

        'Const separator = "-"

        '_contextMenuStrip1.Items.Clear()

        'Dim menuItemFind As New ToolStripMenuItem With {
        '        .Text = _textFind
        '        }
        '_contextMenuStrip1.Items.Add(menuItemFind)
        'menuItemFind.ShortcutKeys = Keys.Control Or Keys.F
        '' ReSharper disable once LocalizableElement
        'menuItemFind.ShortcutKeyDisplayString = "Ctrl-F"
        'AddHandler menuItemFind.Click, AddressOf MenuItemFind_Click

        '_contextMenuStrip1.Items.Add(separator)

        'Dim menuItemSelectAll As New ToolStripMenuItem With {
        '        .Text = _textSelectAll
        '        }
        '_contextMenuStrip1.Items.Add(menuItemSelectAll)
        'menuItemSelectAll.ShortcutKeys = Keys.Control Or Keys.A
        '' ReSharper disable once LocalizableElement
        'menuItemSelectAll.ShortcutKeyDisplayString = "Ctrl-A"
        ''menuItemSelectAll.Enabled = (IIf(SampleTextBox.SelectionLength = SampleTextBox.Text.Length Or SampleTextBox.SelectionLength = SampleTextBox.Text.Trim.Length, False, True))
        'AddHandler menuItemSelectAll.Click, AddressOf MenuItemSelectAll_Click

        '_contextMenuStrip1.Items.Add(separator)

        Const separator = "-"

        _contextMenuStrip1.Items.Clear()

        Dim menuItemFind As New ToolStripMenuItem With {
                .Text = _textFind
                }
        _contextMenuStrip1.Items.Add(menuItemFind)
        menuItemFind.ShortcutKeys = Keys.Control Or Keys.F
        menuItemFind.ShortcutKeyDisplayString = $"Ctrl-F"
        AddHandler menuItemFind.Click, AddressOf MenuItemFind_Click

        Dim menuItemUndo As New ToolStripMenuItem With {
                .Text = _textUndo
                }
        _contextMenuStrip1.Items.Add(menuItemUndo)
        menuItemUndo.ShortcutKeys = Keys.Control Or Keys.Z
        menuItemUndo.ShortcutKeyDisplayString = $"Ctrl-Z"
        AddHandler menuItemUndo.Click, AddressOf MenuItemUndo_Click

        _contextMenuStrip1.Items.Add(separator)

        Dim menuItemCut As New ToolStripMenuItem With {
                .Text = _textCut
                }
        _contextMenuStrip1.Items.Add(menuItemCut)
        menuItemCut.Enabled = (SelectionLength <> 0)
        menuItemCut.ShortcutKeys = Keys.Control Or Keys.X
        menuItemCut.ShortcutKeyDisplayString = $"Ctrl-X"
        AddHandler menuItemCut.Click, AddressOf MenuItemCut_Click

        Dim menuItemCopy As New ToolStripMenuItem With {
                .Text = _textCopy
                }
        _contextMenuStrip1.Items.Add(menuItemCopy)
        menuItemCopy.ShortcutKeys = Keys.Control Or Keys.C
        menuItemCopy.ShortcutKeyDisplayString = $"Ctrl-C"
        menuItemCopy.Enabled = (SelectionLength <> 0)
        AddHandler menuItemCopy.Click, AddressOf MenuItemCopy_Click

        Dim menuItemPaste As New ToolStripMenuItem With {
                .Text = _textPaste
                }
        _contextMenuStrip1.Items.Add(menuItemPaste)
        menuItemPaste.ShortcutKeys = Keys.Control Or Keys.V
        menuItemPaste.ShortcutKeyDisplayString = $"Ctrl-V"
        menuItemPaste.Enabled = (My.Computer.Clipboard.GetText() <> "")
        AddHandler menuItemPaste.Click, AddressOf MenuItemPaste_Click

        Dim menuItemDelete As New ToolStripMenuItem With {
                .Text = _textDelete
                }
        _contextMenuStrip1.Items.Add(menuItemDelete)
        menuItemDelete.ShortcutKeys = Keys.Delete
        menuItemDelete.ShortcutKeyDisplayString = $"Delete"
        menuItemDelete.Enabled = (SelectionLength <> 0)
        AddHandler menuItemDelete.Click, AddressOf MenuItemDelete_Click

        _contextMenuStrip1.Items.Add(separator)

        Dim menuItemSelectAll As New ToolStripMenuItem With {
                .Text = _textSelectAll
                }
        _contextMenuStrip1.Items.Add(menuItemSelectAll)
        menuItemSelectAll.ShortcutKeys = Keys.Control Or Keys.A
        menuItemSelectAll.ShortcutKeyDisplayString = $"Ctrl-A"
        menuItemSelectAll.Enabled = (Not (SelectionLength = Text.Length Or SelectionLength = Text.Trim.Length))
        AddHandler menuItemSelectAll.Click, AddressOf MenuItemSelectAll_Click

        _contextMenuStrip1.Items.Add(separator)

        'End If
    End Sub

    Private Sub MenuItemCut_Click()
        If EditingMode Then
            Clipboard.SetText(SelectedText)
            SelectedIndex = -1
        Else
            MessagingLibrary.Messaging.Show(True, "MsgOperationNotAvailableInViewMode")
        End If
    End Sub

    Private Sub MenuItemDelete_Click()
        If EditingMode Then
            SelectedIndex = -1
        Else
            MessagingLibrary.Messaging.Show(True, "MsgOperationNotAvailableInViewMode")
        End If
    End Sub

    Private Sub MenuItemCopy_Click()
        Clipboard.SetText(SelectedText)
    End Sub

    Private Sub MenuItemPaste_Click()
        If EditingMode Then
            Text = Clipboard.GetText()
        Else
            MessagingLibrary.Messaging.Show(True, "MsgOperationNotAvailableInViewMode")
        End If
    End Sub

    Private Sub MenuItemUndo_Click()
        If EditingMode Then
            SendKeys.Send("^Z")
        Else
            MessagingLibrary.Messaging.Show(True, "MsgOperationNotAvailableInViewMode")
        End If
    End Sub

    'Protected Overloads Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
    '    If SuggestListForm.Visible AndAlso KeysToHandle.Contains(keyData) Then
    '        Return True
    '    End If
    '    Return MyBase.ProcessCmdKey(msg, keyData)
    'End Function

    'Private Sub caCombobox_Leave(sender As Object, e As EventArgs) Handles Me.Leave
    '    If SelectedIndex < 0 Then
    '        If Text = "" Then
    '            'allow empty strings
    '        Else
    '            If _suggestBindingList.Count() = 1 Then
    '                Text = SuggestListForm.SuggestListBox.Items(0)
    '            Else
    '                ' invalid selection or text set to empty string
    '                Text = Nothing
    '            End If
    '        End If
    '    End If
    'End Sub

    'Private Sub HideSuggestionBox()
    '    SuggestListForm.Hide()
    '    SuggestListForm.Visible = False
    'End Sub

    Private Sub MenuItemFind_Click()
        Dim myForm = FindForm()
        Dim searchForm As CFindForm
        searchForm = New CFindForm(Me)
        FieldName = Name.Substring(3)
        If LinkedLabel IsNot Nothing AndAlso LinkedLabel.Text <> "" Then
            searchForm.SetFieldDescription(LinkedLabel.Text)
        Else
            searchForm.SetFieldDescription(FieldName)
        End If
        Dim x = CallByName(myForm, "GetFieldType", CallType.Method, {FieldName})
        'Dim x = Invoker.InvokeProperty(myForm, "GetFieldType", CallType.Method, {FieldName})
        'If x IsNot Nothing Then
        FindDataType = GetObjectDataType(x)
        'Else
        'Dim y = Invoker.InvokeProperty(myForm, "GetFieldType", CallType.Method, {FieldName})
        'FindDataType = GetObjectDataType(y)
        'End If
        searchForm.ShowDialog()
        'CallByName(myForm, "FindFieldNew", CallType.Method, Me)
        Invoker.InvokeFunction(myForm, "FindFieldNew", {Me})
    End Sub

    Private Sub MenuItemSelectAll_Click()
        SelectAll()
    End Sub

    'Private Shadows Sub OnDropDownClosed(sender As Object, e As EventArgs) Handles Me.DropDownClosed
    '    If DisplayOnly Then
    '        SelectedIndex = _previousIndex
    '        AATM.Libraries.MessagingLibrary.Messaging.Show(True, "MsgCannotEditReadOnly")
    '    End If
    'End Sub

    'Private Sub SetListBoxFormLocation(ByRef suggestLbForm As CListBoxForm)
    '    'SetVisibleCore(True)
    '    Dim pnt As Point
    '    Dim formLocation As Point
    '    Dim screenRectangle As Rectangle
    '    Dim myForm = FindForm()
    '    If myForm Is Nothing Then
    '        Return
    '    End If
    '    screenRectangle = Screen.PrimaryScreen.WorkingArea
    '    suggestLbForm.StartPosition = FormStartPosition.Manual
    '    pnt = Parent.PointToScreen(Location)
    '    formLocation = New Point(pnt.X, pnt.Y + Height)
    '    If formLocation.Y + suggestLbForm.Height > screenRectangle.Height Then
    '        formLocation.Y = pnt.Y - suggestLbForm.Height
    '    End If
    '    suggestLbForm.Location = formLocation
    '    suggestLbForm.Width = Width
    'End Sub

    'Private Sub SuggestListBoxOnClick()
    '    Text = SuggestListForm.SuggestListBox.Text
    '    Focus()
    'End Sub

    'Private Event SuggestListBoxOnTextChanged()

    'Private Sub OnSuggestListBoxOnTextChanged()
    '    If Not Focused Then Return
    '    _suggestBindingList.Clear()
    '    _suggestBindingList.RaiseListChangedEvents = False
    '    PropertySelectorCompiled(Items).Where(_filterRuleCompiled).OrderBy(_suggestListOrderRuleCompiled).ToList().ForEach(AddressOf _suggestBindingList.Add)
    '    _suggestBindingList.RaiseListChangedEvents = True
    '    _suggestBindingList.ResetBindings()
    '    If _suggestBindingList.Count = 0 And LimitToList Then
    '        Beep()
    '        SendKeys.SendWait("{BACKSPACE}")
    '    ElseIf _suggestBindingList.Count = 1 AndAlso _suggestBindingList.Single().Length = Text.Trim().Length Then
    '        Text = _suggestBindingList.Single()
    '        [Select](0, Text.Length)
    '        HideSuggestionBox()
    '    End If
    'End Sub

#End Region

#Region "FindableControl"

    Public Property FindEnabled As Boolean Implements IFindableControl.FindEnabled

    Public Property BegFindValue As Object Implements IFindableControl.BegFindValue

    Public Property EndFindValue As Object Implements IFindableControl.EndFindValue

    Private Property SearchPlace As IFindableControl.SearchPlaceEnum Implements IFindableControl.SearchPlace
        Get
            Return IFindableControl.SearchPlaceEnum.ExactValue
        End Get
        Set(value As IFindableControl.SearchPlaceEnum)

        End Set
    End Property

    Public Property FieldName As String Implements IFindableControl.FieldName

    Private ReadOnly Property FindDataSource As Object Implements IFindableControl.FindDataSource
        Get
            Return DataSource
        End Get
    End Property

    Private ReadOnly Property FindDisplayMember As String Implements IFindableControl.FindDisplayMember
        Get
            Return DisplayMember
        End Get
    End Property

    Public Property IgnoreCase As Boolean Implements IFindableControl.IgnoreCase

    Public ReadOnly Property SearchMode As IFindableControl.SearchModeEnum Implements IFindableControl.SearchMode
        Get
            Return IFindableControl.SearchModeEnum.ComboBox
        End Get
    End Property

    Private ReadOnly Property IFindableControl_ValueMember As String Implements IFindableControl.FindValueMember
        Get
            Return ValueMember
        End Get
    End Property

#End Region

    <Browsable(True)>
    <Category("Appearance")>
    <DefaultValue(GetType(Color), "DimGray")>
    Public Property BorderColor As Color

    Public Property FindDataType As IFindableControl.DataTypeEnum Implements IFindableControl.FindDataType

    Public Property FieldDescription As String Implements IFindableControl.FieldDescription

    '<Category("Custom Properties")>
    '<Description("Select the label to which this control is linked.")>
    '<Browsable(True)>
    Public Property LinkedLabel As CLabel Implements ILinkedLabel.LinkedLabel

    Public Sub RevertValue()
        ' revert to previous value
        SelectedValue = _lastValue
    End Sub

    'Private Sub caCombobox_TextChanged(sender As Object, e As EventArgs) Handles Me.TextChanged
    '    ComboBoxValueChanged = True
    'End Sub

    'Private Sub caComboBox_SelectedValueChanged(sender As Object, e As EventArgs) Handles Me.SelectedValueChanged
    '    If Not ComboBoxValueChanged Then
    '        ComboBoxValueChanged = True
    '    Else
    '        ComboBoxValueChanged = False
    '    End If
    'End Sub

    Public Function ValueChanged()
        If SelectedValue = _lastValue Then
            Return False
        End If
        Return True
    End Function

    Private Const WmMousewheel As Integer = &H20A

    <DebuggerStepThrough>
    Protected Overrides Sub WndProc(ByRef m As Message)
        If EditingMode And Not DisplayOnly Then
            MyBase.WndProc(m)
        Else
            If Not m.Msg = WmMousewheel Then MyBase.WndProc(m)
        End If
    End Sub

    Public Function GetControlDescription(Optional defaultDescription As String = Nothing) Implements ILinkedLabel.GetControlDescription
        Dim description As String
        If LinkedLabel Is Nothing OrElse LinkedLabel.Text Is Nothing OrElse LinkedLabel.Text = "" Then
            description = If(defaultDescription Is Nothing OrElse defaultDescription = "", Name, defaultDescription)
        Else
            description = LinkedLabel.Text
        End If
        Return description
    End Function

End Class


