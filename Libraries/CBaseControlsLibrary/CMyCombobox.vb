Imports System.ComponentModel
Imports System.Drawing
Imports System.Linq.Expressions
Imports System.Threading
Imports System.Windows.Forms
Imports AATM.Libraries.BaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub

Public Class CMyComboBox
    Inherits BCombobox
    Implements IEntryControl, ILinkedLabel

    Private _defaultValue As Object
    Private _isNumeric As Boolean
    Private _isMandatory As Boolean
    Private _displayOnly As Boolean
    Private _translatable As Boolean = False

    'Private MyErrorProvider As New ErrorProviderExtended
    Private ReadOnly _textToSearch As String

    Private _searchPlace As Char
    Private _isNullable As Boolean
    Private _oldValue As String
    Private WithEvents ContextMenuStrip1 As New ContextMenuStrip
    Private _hideWhenNotEditingOrAdding As Boolean = False
    Private _editingMode As Boolean = True
    Private _bypassTextChange As Boolean = False
    Public DatasourceProgrammaticChange As Boolean = False
    Private _currentSearchTerm As String = ""
    Private _changingSearchValueOnly As Boolean = False

    Public SuggestListForm As CListBoxForm = New CListBoxForm With {
        .TabStop = False
        }

    Private ReadOnly _suggestBindingList As BindingList(Of String) = New BindingList(Of String)()
    Private _propertySelector As Expression(Of Func(Of ObjectCollection, IEnumerable(Of String)))
    Protected PropertySelectorCompiled As Func(Of ObjectCollection, IEnumerable(Of String))
    Private _filterRule As Expression(Of Func(Of String, String, Boolean))
    Private _filterRuleCompiled As Func(Of String, Boolean)
    Private _suggestListOrderRule As Expression(Of Func(Of String, String))
    Private _suggestListOrderRuleCompiled As Func(Of String, String)

    Public Property SuggestBoxHeight As Integer
        Get
            Return SuggestListForm.Height
        End Get
        Set(ByVal value As Integer)
            If value > 0 Then SuggestListForm.Height = value
        End Set
    End Property

    Public Property PropertySelector As Expression(Of Func(Of ObjectCollection, IEnumerable(Of String)))
        Get
            Return _propertySelector
        End Get
        Set(ByVal value As Expression(Of Func(Of ObjectCollection, IEnumerable(Of String))))
            If value Is Nothing Then Return
            _propertySelector = value
            PropertySelectorCompiled = value.Compile()
        End Set
    End Property

    Public Property FilterRule As Expression(Of Func(Of String, String, Boolean))
        Get
            Return _filterRule
        End Get
        Set(ByVal value As Expression(Of Func(Of String, String, Boolean)))
            If value Is Nothing Then Return
            _filterRule = value
            _filterRuleCompiled = Function(item) value.Compile()(item, Text)
        End Set
    End Property

    Public Property SuggestListOrderRule As Expression(Of Func(Of String, String))
        Get
            Return _suggestListOrderRule
        End Get
        Set(ByVal value As Expression(Of Func(Of String, String)))
            If value Is Nothing Then Return
            _suggestListOrderRule = value
            _suggestListOrderRuleCompiled = value.Compile()
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        Dim myFont As New Font("Sans Serif", 10.0!, FontStyle.Regular)
        ContextMenuStrip = ContextMenuStrip1
        Margin = New Padding(1)
        FlatStyle -= Border3DStyle.RaisedOuter
        Font = myFont

        _filterRuleCompiled = Function(s) s.ToLower().Contains(Text.Trim().ToLower())
        _suggestListOrderRuleCompiled = Function(s) s
        PropertySelectorCompiled = Function(collection) collection.Cast(Of String)()

        SuggestListForm.SuggestListBox.DataSource = _suggestBindingList
        AddHandler SuggestListForm.SuggestListBox.Click, AddressOf SuggestListBoxOnClick
        AddHandler ParentChanged, AddressOf OnParentChanged

    End Sub

    Private Overloads Sub OnBindingContextChanged(sender As Object, e As EventArgs) Handles MyBase.BindingContextChanged
        PropertySelectorCompiled = Function(collection) collection.Cast(Of Lookup.LookupData)().[Select](Function(p) p.Name)
    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        MyBase.OnTextChanged(e)
        If Not Focused Then Return
        _suggestBindingList.Clear()
        _suggestBindingList.RaiseListChangedEvents = False
        PropertySelectorCompiled(Items).Where(_filterRuleCompiled).OrderBy(_suggestListOrderRuleCompiled).ToList().ForEach(AddressOf _suggestBindingList.Add)
        _suggestBindingList.RaiseListChangedEvents = True
        _suggestBindingList.ResetBindings()
        Dim showForm As Boolean
        showForm = _suggestBindingList.Any()
        SuggestListForm.Visible = showForm
        If showForm Then
            SetListBoxFormLocation(SuggestListForm)
            SuggestListForm.Visible = True
        Else
            SuggestListForm.Hide()
        End If

        If _suggestBindingList.Count = 1 AndAlso _suggestBindingList.Single().Length = Text.Trim().Length Then
            Text = _suggestBindingList.Single()
            [Select](0, Text.Length)
            HideSuggBox()
        End If
    End Sub

    Private Shadows Sub OnParentChanged(ByVal sender As Object, ByVal e As EventArgs)
        SetListBoxFormLocation(SuggestListForm)
        SuggestListForm.SuggestListBox.Font = New Font("Segoe UI", 9)
    End Sub

    Protected Overrides Sub OnLocationChanged(ByVal e As EventArgs)
        MyBase.OnLocationChanged(e)
        SetListBoxFormLocation(SuggestListForm)
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        MyBase.OnSizeChanged(e)
        SuggestListForm.Width = Width - 20
        SuggestListForm.SuggestListBox.Width = SuggestListForm.Width
    End Sub

    Private Sub SuggestListBoxOnClick()
        Text = SuggestListForm.SuggestListBox.Text
        Focus()
    End Sub

    Private Sub HideSuggBox()
        SuggestListForm.Hide()
        SuggestListForm.Visible = False
    End Sub

    Protected Overloads Overrides Sub OnDropDown(e As EventArgs)
        HideSuggBox()
        MyBase.OnDropDown(e)
    End Sub

    Protected Overloads Overrides Sub OnPreviewKeyDown(e As PreviewKeyDownEventArgs)
        If Not SuggestListForm.Visible Then
            MyBase.OnPreviewKeyDown(e)
            Return
        End If
        Select Case e.KeyCode
            Case Keys.Down
                If SuggestListForm.SuggestListBox.SelectedIndex < _suggestBindingList.Count - 1 Then
                    Math.Max(Interlocked.Increment(SuggestListForm.SuggestListBox.SelectedIndex), SuggestListForm.SuggestListBox.SelectedIndex - 1)
                End If
                Return
            Case Keys.Up
                If SuggestListForm.SuggestListBox.SelectedIndex > 0 Then
                    Math.Max(Interlocked.Decrement(SuggestListForm.SuggestListBox.SelectedIndex), SuggestListForm.SuggestListBox.SelectedIndex + 1)
                End If
                Return
            Case Keys.Enter
                Text = SuggestListForm.SuggestListBox.Text
                [Select](0, Text.Length)
                SuggestListForm.Hide()
                SuggestListForm.Visible = False
                Return
            Case Keys.Escape
                HideSuggBox()
                Return
        End Select
        MyBase.OnPreviewKeyDown(e)
    End Sub

    Private Shared ReadOnly KeysToHandle As Keys() = {Keys.Down, Keys.Up, Keys.Enter, Keys.Escape}

    Protected Overloads Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If SuggestListForm.Visible AndAlso KeysToHandle.Contains(keyData) Then
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub SetListBoxFormLocation(ByRef suggestLbForm As CListBoxForm)
        Dim pnt As Point
        Dim formLocation As Point
        Dim screenRectangle As Rectangle
        Dim myForm = FindForm()
        If myForm Is Nothing Then
            Return
        End If
        screenRectangle = Screen.PrimaryScreen.WorkingArea
        suggestLbForm.Width = Width + 2
        suggestLbForm.StartPosition = FormStartPosition.Manual
        pnt = Parent.PointToScreen(Location)
        If GlobalVariables.RightToLeftLayout Then
            formLocation = New Point(pnt.X - suggestLbForm.Width)
            If formLocation.X < 0 Then
                formLocation.X = pnt.X - suggestLbForm.Width
            End If
        Else
            formLocation = New Point(pnt.X, pnt.Y + Height)
            If formLocation.X + suggestLbForm.Width > screenRectangle.Width Then
                formLocation.X = pnt.X - suggestLbForm.Width
            End If
        End If
        If formLocation.Y + suggestLbForm.Height > screenRectangle.Height Then
            formLocation.Y = pnt.Y - suggestLbForm.Height
        End If
        suggestLbForm.Location = formLocation
    End Sub

    Protected Overloads Overrides Sub OnLostFocus(e As EventArgs)
        If Not SuggestListForm.SuggestListBox.Focused Then
            HideSuggBox()
        End If
        MyBase.OnLostFocus(e)
    End Sub

#Region "Custom Properties#"

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

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to specify that this control is mandatory.")>
    <Browsable(True)>
    Public Property DisplayOnly As Boolean
        Get
            Return _displayOnly
        End Get
        Set(value As Boolean)
            _displayOnly = value
            EditingMode = value
        End Set
    End Property

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to specify that this control is mandatory.")>
    <Browsable(True)>
    Public Property ValueIsMandatory As Boolean
        Get
            Return _isMandatory
        End Get
        Set
            _isMandatory = Value
        End Set
    End Property

    '<Bindable(True)>
    '<Category("Properties")>
    '<DefaultValue(GetType(Boolean))>
    '<Description("Set to True to specify that this control has a fixed Datasource value.")>
    '<Browsable(True)>
    'Public Property FixedDataSource As Boolean = True

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to make this control visible only when in editing or adding mode")>
    <Browsable(True)>
    Public Property HideWhenNotEditingOrAdding As Boolean
        Get
            Return _hideWhenNotEditingOrAdding
        End Get
        Set
            _hideWhenNotEditingOrAdding = Value
        End Set
    End Property

    Public Property ValueIsNullable As Boolean
        Get
            Return _isNullable
        End Get
        Set
            _isNullable = Value
        End Set
    End Property

    Public Property DefaultValue As Object
        Get
            Return _defaultValue
        End Get
        Set
            _defaultValue = Value
        End Set
    End Property

    Public Sub OnKeyDownPressed(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.SendWait("{TAB}")
            e.Handled = True
        End If
    End Sub

    <Category("Custom Properties")>
    <Description("Select the label to which this control is linked.")>
    <Browsable(True)>
    Public Property LinkedLabel As CLabel Implements ILinkedLabel.LinkedLabel

    Private Const WmPaint As Integer = &HF
    Private _readOnlyCombo As Boolean

    Public Property ReadOnlyCombo As Boolean
        Get
            Return _readOnlyCombo
        End Get
        Set
            ' If the value isn't changing, then do nothing
            If Value = _readOnlyCombo Then Exit Property
            _readOnlyCombo = Value
        End Set
    End Property

    Public Property EditingMode As Boolean Implements IEntryControl.EditingMode
        Get
            Return _editingMode
        End Get
        Set(value As Boolean)
            _editingMode = value
            UpdateDisplayOnlyControl()
        End Set
    End Property

    Public Sub UpdateDisplayOnlyControl()
        If _editingMode AndAlso Not DisplayOnly Then
            ForeColor = GlobalVariables.DefaultFormControlForegroundColor
            BackColor = GlobalVariables.DefaultFormControlBackgroundColor
        Else
            ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
            BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
        End If
    End Sub

    Private _previousSearchTerm As String
    Private _originalList As Object() = Nothing
    Private _originalDataSource As Object

    Public Property OriginalList As Object()
        Get
            Return _originalList
        End Get
        Set(value As Object())
            _originalList = value
        End Set
    End Property

    Public Property OriginalDataSource As Object
        Get
            Return _originalDataSource
        End Get
        Set(value As Object)
            _originalDataSource = value
        End Set
    End Property

#End Region

    Public Sub EnterHandler(sender As Object, e As EventArgs) Handles MyBase.Enter
        If Not EditingMode Then
            ForeColor = GlobalVariables.DefaultFormControlEditingForegroundColor
            BackColor = GlobalVariables.DefaultFormControlEditingBackgroundColor
        End If
    End Sub

    Public Sub LeaveHandler(sender As Object, e As EventArgs) Handles MyBase.Leave
        If Not EditingMode Then
            ForeColor = GlobalVariables.DefaultFormControlForegroundColor
            BackColor = GlobalVariables.DefaultFormControlBackgroundColor
        End If
    End Sub

#Region "Constant Declarations#"

    ' Text Menu Captions
    Const TextFind = "Find on this field"

    Const TextUndo = "Undo Last Cut/Paste/Delete"
    Const TextCut = "Cut Selected Text"
    Const TextCopy = "Copy Selected Text"
    Const TextDelete = "Delete Selected Text"
    Const TextSelectAll = "Select All Text"

#End Region

    Private Sub TextBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
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
    End Sub

    Private Sub MenuItemFind_Click()
        'Dim MyForm = Me.FindForm()
        'Dim SearchForm = New CFindForm
        ''SearchForm.Show()
        'SearchForm.ShowDialog()
        '_TextToSearch = SearchForm.TextToSearch
        '_SearchPlace = SearchForm.GetSearchPlace
        'SearchForm.Dispose()
        'If _TextToSearch <> "" Then

        '    CallByName(MyForm, "FindField", CallType.Method, Me)

        'End If
    End Sub

    Public Function GetTextToSearch() As String
        Return _textToSearch
    End Function

    Public Function GetSearchPlace() As Char
        Return _searchPlace
    End Function

    Private Sub MenuItemSelectAll_Click()
        SelectAll()
    End Sub

    Public Property Translatable As Boolean Implements IEntryControl.Translatable
        Get
            Return False
        End Get
        Set(value As Boolean)
            _translatable = value
        End Set
    End Property

    Public Function GetControlDescription(Optional defaultDescription As String = Nothing) Implements ILinkedLabel.GetControlDescription
        Dim description As String
        If LinkedLabel Is Nothing OrElse LinkedLabel.Text Is Nothing OrElse LinkedLabel.Text = "" Then
            description = If(defaultDescription Is Nothing OrElse defaultDescription = "", Name, defaultDescription)
        Else
            description = LinkedLabel.Text
        End If
        Return description
    End Function

    'Public Sub MakeEditable(editableControl As Boolean) Implements IEntryControl.MakeEditable
    '    DisplayOnly = Not editableControl
    'End Sub

    'Public Sub MakeVisible(visibleControl As Boolean) Implements IEntryControl.MakeVisible
    '    Visible = visibleControl
    'End Sub

    'Public Sub MakeViewable(ViewableControl As Boolean) Implements IEntryControl.MakeViewable
    '    ' not applicable
    'End Sub

    'Public Sub MakeSelectable(selectableControl As Boolean) Implements IEntryControl.MakeSelectable
    '    Enabled = selectableControl
    'End Sub
End Class

'Sample Use
'
'Imports System
'Imports System.Linq
'Imports System.Windows.Forms

'Public Class Form1

'    Public Sub New()

'        ' This call is required by the designer.
'        InitializeComponent()

'        ' Add any initialization after the InitializeComponent() call.

'    End Sub

'    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
'        sugComboBox.DataSource = {"Janean Mcgaha", "Tama Gaitan", "Jacque Tinnin", "Elvira Woolfolk", "Fransisca Owens", "Minnie Ardoin", "Renay Bentler", "Joye Boyter", "Jaime Flannery", "Maryland Arai", "Walton Edelstein", "Nereida Storrs", "Theron Zinn", "Katharyn Estrella", "Alline Dubin", "Edra Bhatti", "Willa Jeppson", "Chelsea Revel", "Sonya Lowy", "Danelle Kapoor"}
'        sugComboBox.SelectedIndex = -1

'        'trySomeThings()

'    End Sub

'    Private Sub TrySomeThings()
'        sugComboBox.DataSource = sugComboBox.Items.Cast(Of String)().[Select](Function(i) New Person With {
'            .Name = i
'        }).ToList()
'        sugComboBox.DisplayMember = "Name"
'        sugComboBox.PropertySelector = Function(collection) collection.Cast(Of Person)().[Select](Function(p) p.Name)
'        sugComboBox.FilterRule = Function(item, text) item.StartsWith(text.Trim(), StringComparison.CurrentCultureIgnoreCase)
'        sugComboBox.SuggestListOrderRule = Function(s) s.Split(" "c)(1)
'    End Sub
'End Class

'Class Person
'    Public Property Name As String
'    Public Property DateOfBirth As DateTime
'    Public Property Height As Integer
'End Class