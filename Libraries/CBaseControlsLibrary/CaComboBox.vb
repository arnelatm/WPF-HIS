Imports System.ComponentModel
Imports System.Drawing
Imports System.Linq.Expressions
Imports System.Threading
Imports System.Windows.Forms
Imports AATM.Libraries.BaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub

Public Class CaComboBox
    Inherits BCombobox
    Implements IEntryControl

#Region "Custom Properties"

    'Private MyErrorProvider As New ErrorProviderExtended
    Private WithEvents _contextMenuStrip1 As New ContextMenuStrip

    Public DataSourceProgrammaticChange As Boolean = False
    Public SuggestListForm As CListBoxForm = New CListBoxForm
    Protected PropertySelectorCompiled As Func(Of ObjectCollection, IEnumerable(Of String))
    Private Shared ReadOnly KeysToHandle As Keys() = {Keys.Down, Keys.Up, Keys.Enter, Keys.Escape}
    Private ReadOnly _suggestBindingList As BindingList(Of String) = New BindingList(Of String)()
    Private _displayOnly As Boolean
    Private _editable As Boolean
    Private _editingMode As Boolean = True
    Private _filterRule As Expression(Of Func(Of String, String, Boolean))
    Private _filterRuleCompiled As Func(Of String, Boolean)
    Private _previousSelectedIndex As Integer = -1
    Private _propertySelector As Expression(Of Func(Of ObjectCollection, IEnumerable(Of String)))
    Private _readOnlyCombo As Boolean
    Private _selectable As Boolean
    Private _suggestListOrderRule As Expression(Of Func(Of String, String))
    Private _suggestListOrderRuleCompiled As Func(Of String, String)
    Private _viewable As Boolean
    '<Bindable(True)>
    '<Category("Properties")>
    '<DefaultValue("Name")>
    '<Description("The field to display in the Combobox (when not Dropped down)")>
    '<Browsable(True)>
    'Public Property TextDisplayMember As String = "Name"

    Public Property ChangingSearchValueOnly As Boolean = False

    Public Shared Property Copy As String = "Copy Selected Text"

    Public Property CurrentSearchTerm As String = ""

    Public Shared Property Cut As String = "Cut Selected Text"

    Public Property DefaultValue As Object

    Public Shared Property Delete As String = "Delete Selected Text"

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
            _displayOnly = value
        End Set
    End Property

    <Category("Custom Properties")>
    <DefaultValue(False)>
    <Description("Set to True to specify that this control can be edited.")>
    <Browsable(True)>
    Public Property Editable As Boolean
        Get
            Return _editable
        End Get
        Set
            _editable = Value
            DisplayOnly = Value
        End Set
    End Property

    Public Property EditingMode As Boolean Implements IEntryControl.EditingMode
        Get
            Return _editingMode
        End Get
        Set(value As Boolean)
            _editingMode = value
            If value Then
                ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
                BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
                DropDownHeight = 1
            Else
                If DisplayOnly Then
                    ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
                    BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
                Else
                    ForeColor = GlobalVariables.DefaultFormControlForegroundColor
                    BackColor = GlobalVariables.DefaultFormControlBackgroundColor
                End If
                DropDownHeight = 200
                IntegralHeight = True
            End If
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

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to make this control visible only when in editing or adding mode")>
    <Browsable(True)>
    Public Property HideWhenNotEditingOrAdding As Boolean = False

    <Category("Custom Properties")>
    <Description("Select the label to which this control is linked.")>
    <Browsable(True)>
    Public Property LinkedLabel As CLabel

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

    Public Property PreviousSelectedIndex As Integer
        Get
            Return _previousSelectedIndex
        End Get
        Set(value As Integer)
            _previousSelectedIndex = value
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

    Public Property SearchAnywhere As Boolean

    <Category("Custom Properties")>
    <DefaultValue(False)>
    <Description("Set to True to specify that this control can be selected.")>
    <Browsable(True)>
    Public Property Selectable As Boolean
        Get
            Return _selectable
        End Get
        Set
            _selectable = Value
            Enabled = Value
        End Set
    End Property

    Public Property SuggestBoxHeight As Integer
        Get
            Return SuggestListForm.Height
        End Get
        Set(ByVal value As Integer)
            If value > 0 Then SuggestListForm.Height = value
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

    Public Property TextToSearch As String

    Public ReadOnly Property Translatable As Boolean Implements IEntryControl.Translatable
        Get
            Return False
        End Get
    End Property

    'Public Property ButtonWidth As Integer = SystemInformation.HorizontalScrollBarArrowWidth
    'Public Property EnableTheme As Boolean = False
    'Public Property CustomBorder As Boolean
    Public Shared Property Undo As String = "Undo Last Cut/Paste/Delete"

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

    <Category("Custom Properties")>
    <DefaultValue(False)>
    <Description("Set to True to specify that this control value will not be shown.")>
    <Browsable(True)>
    Public Property Viewable As Boolean
        Get
            Return _viewable
        End Get
        Set
            _viewable = Value
            If Not Value Then
                Width = 0
            End If
        End Set
    End Property

    Public Shared Property WmPaint1 As Integer = &HF

    Private Property LimitToList As Boolean = False

    Public Sub OnKeyDownPressed(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If DisplayOnly Then
            e.SuppressKeyPress = True
        Else
            If e.KeyCode = Keys.Enter Then
               SendKeys.SendWait("{TAB}")
               e.SuppressKeyPress = True
               e.Handled = True
               'SendKeys.SendWait("{TAB}")
            End If
        End If
    End Sub

#End Region

#Region "Constant Declarations#"

    ' Text Menu Captions
    Const TextFind = "Find on this field"

    Const TextSelectAll = "Select All Text"

#End Region

#Region "Event Handlers"

    Private _previousIndex As Integer

    Public Sub EnterHandler(sender As Object, e As EventArgs) Handles MyBase.Enter
        If Not (EditingMode Or DisplayOnly) Then
            ForeColor = GlobalVariables.DefaultFormControlEditingForegroundColor
            BackColor = GlobalVariables.DefaultFormControlEditingBackgroundColor
        End If
    End Sub

    Public Sub LeaveHandler(sender As Object, e As EventArgs) Handles MyBase.Leave
        If Not (EditingMode Or DisplayOnly) Then
            ForeColor = GlobalVariables.DefaultFormControlForegroundColor
            BackColor = GlobalVariables.DefaultFormControlBackgroundColor
        End If
    End Sub

    Protected Overloads Overrides Sub OnDropDown(e As EventArgs)
        HideSuggestionBox()
        'MyBase.OnDropDown(e)
        If DisplayOnly Then
            _previousIndex = SelectedIndex
        End If
    End Sub

    Protected Overrides Sub OnLocationChanged(ByVal e As EventArgs)
        MyBase.OnLocationChanged(e)
        SetListBoxFormLocation(SuggestListForm)
    End Sub

    Protected Overloads Overrides Sub OnLostFocus(e As EventArgs)
        If Not SuggestListForm.SuggestListBox.Focused Then
            HideSuggestionBox()
        End If
    End Sub

    Protected Overloads Overrides Sub OnPreviewKeyDown(e As PreviewKeyDownEventArgs)
        If Not SuggestListForm.Visible Then
            MyBase.OnPreviewKeyDown(e)
            Return
        End If
        Select Case e.KeyCode
            Case Keys.Down
                If SuggestListForm.SuggestListBox.SelectedIndex < _suggestBindingList.Count - 1 Then
                    ' ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                    Math.Max(Interlocked.Increment(SuggestListForm.SuggestListBox.SelectedIndex), SuggestListForm.SuggestListBox.SelectedIndex - 1)
                End If
                Return
            Case Keys.Up
                If SuggestListForm.SuggestListBox.SelectedIndex > 0 Then
#Disable Warning ReturnValueOfPureMethodIsNotUsed
                    Math.Max(Interlocked.Decrement(SuggestListForm.SuggestListBox.SelectedIndex), SuggestListForm.SuggestListBox.SelectedIndex + 1)
#Enable Warning ReturnValueOfPureMethodIsNotUsed
                End If
                Return
            Case Keys.Enter
                Text = SuggestListForm.SuggestListBox.Text
                [Select](0, Text.Length)
                SuggestListForm.Hide()
                SuggestListForm.Visible = False
                Return
            Case Keys.Escape
                HideSuggestionBox()
                Return
        End Select
        MyBase.OnPreviewKeyDown(e)
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        MyBase.OnSizeChanged(e)
        If Viewable Then
            'SuggestListForm.Width = Width - 10
            'SuggestListForm.SuggestListBox.Width = SuggestListForm.Width
        End If
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

        If _suggestBindingList.Count = 0 And LimitToList Then
            Beep()
            SendKeys.SendWait("{BACKSPACE}")
        ElseIf _suggestBindingList.Count = 1 AndAlso _suggestBindingList.Single().Length = Text.Trim().Length Then
            Text = _suggestBindingList.Single()
            [Select](0, Text.Length)
            HideSuggestionBox()
        End If
    End Sub

    Private Sub caComboBox_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        HandleMouseUp(sender, e)
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

    Private Overloads Sub OnBindingContextChanged(sender As Object, e As EventArgs) Handles MyBase.BindingContextChanged
        PropertySelectorCompiled = Function(collection) collection.Cast(Of ClassesLibrary.LookupData)().[Select](Function(p) p.Name)
    End Sub

    Private Shadows Sub OnParentChanged(ByVal sender As Object, ByVal e As EventArgs)
        SetListBoxFormLocation(SuggestListForm)
        SuggestListForm.SuggestListBox.Font = New Font("Segoe UI", 9)
    End Sub

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
        ValueMember = "IdNo"
        DisplayMember = "Name"
        DropDownStyle = ComboBoxStyle.DropDownList
        Text = ""
        _filterRuleCompiled = Function(s) s.ToLower().Contains(Text.Trim().ToLower())
        _suggestListOrderRuleCompiled = Function(s) s
        PropertySelectorCompiled = Function(collection) collection.Cast(Of String)()

        SuggestListForm.SuggestListBox.DataSource = _suggestBindingList
        AddHandler SuggestListForm.SuggestListBox.Click, AddressOf SuggestListBoxOnClick
        AddHandler ParentChanged, AddressOf OnParentChanged
    End Sub

    Public Function GetSearchAnywhere() As Boolean
        Return SearchAnywhere
    End Function

    Public Function GetTextToSearch() As String
        Return TextToSearch
    End Function

    Public Function GetValue()
        If SelectedItem IsNot Nothing Then
            If ValueMember.ToLower() = "idno" Then
                Return CType(SelectedItem, ClassesLibrary.LookupData).IdNo
            ElseIf ValueMember.ToLower() = "name" Then
                Return CType(SelectedItem, ClassesLibrary.LookupData).Name
            ElseIf ValueMember.ToLower() = "code" Then
                Return CType(SelectedItem, ClassesLibrary.LookupData).Code
            ElseIf ValueMember.ToLower() = "index" Then
                Return CType(SelectedItem, ClassesLibrary.LookupData).Index
            Else
                Return Text
            End If
        Else
            Return Nothing
        End If
    End Function

    Public Sub SetValue(ByRef value As Object)
        If value = Nothing Then
            Text = Nothing
        Else
            Dim saveDisplaymember As String = DisplayMember
            DisplayMember = ValueMember
            Text = value
            DisplayMember = saveDisplaymember
            'SelectedValue = value
            If ValueMember.ToLower() = "idno" Then
                If Not IsNumeric(value) OrElse (SelectedItem IsNot Nothing AndAlso SelectedItem.idNo <> value) Then
                    SelectedIndex = -1
                    Text = value.ToString()
                    MessageBox.Show("Invalid value <" + value.ToString() + "> for field " + If(LinkedLabel Is Nothing, Name, LinkedLabel.Text))
                End If
            ElseIf ValueMember.ToLower() = "code" Then
                If SelectedItem IsNot Nothing AndAlso SelectedItem.Code <> value Then
                    SelectedIndex = -1
                    Text = value.ToString()
                    MessageBox.Show("Invalid value <" + Text + "> for field " + If(LinkedLabel Is Nothing, Name, LinkedLabel.Text))
                End If
                'If SelectedItem.Code <> value Then
                '    Text = Nothing
                'End If
            End If
        End If
        'If value Is Nothing Then
        '    Text = Nothing
        '    'Else
        '    '    Text = value
        'End If
        'If IsNumeric(value) Then
        '    If value = 0 Then
        '        Text = ""
        '    ElseIf ValueMember.ToLower() = "idno" AndAlso TextDisplayMember.ToLower() <> "idno" Then
        '        Dim saveDisplayMember As String = DisplayMember
        '        DisplayMember = "IdNo"
        '        Text = value
        '        DisplayMember = saveDisplayMember
        '    ElseIf ValueMember.ToLower() = "code" Then
        '        Dim saveDisplayMember As String = DisplayMember
        '        DisplayMember = "Code"
        '        Text = Val(value)
        '        DisplayMember = saveDisplayMember
        '    Else
        '        Text = value
        '    End If
        'Else
        'If ValueMember.ToLower() = "idno" Then
        '    Dim saveDisplaymember As String = DisplayMember
        '    If value = Nothing Then
        '        Text = Nothing
        '    Else
        '        DisplayMember = "IdNo"
        '        Text = value
        '        DisplayMember = saveDisplaymember
        '    End If
        'ElseIf ValueMember.ToLower() = "code" Then
        '    Dim saveDisplayMember As String = DisplayMember
        '    DisplayMember = "Code"
        '    If value = Nothing Then
        '        Text = Nothing
        '    Else
        '        DisplayMember = "Code"
        '        Text = Value
        '        DisplayMember = saveDisplayMember
        '    End If
        'Else
        '    Text = value
        'End If
        'End If
    End Sub

    Protected Sub ContextHandler(sender As Object, e As EventArgs)

        Const separator = "-"

        _contextMenuStrip1.Items.Clear()

        Dim menuItemFind As New ToolStripMenuItem With {
                .Text = TextFind
                }
        _contextMenuStrip1.Items.Add(menuItemFind)
        menuItemFind.ShortcutKeys = Keys.Control Or Keys.F
        ' ReSharper disable once LocalizableElement
        menuItemFind.ShortcutKeyDisplayString = "Ctrl-F"
        AddHandler menuItemFind.Click, AddressOf MenuItemFind_Click

        _contextMenuStrip1.Items.Add(separator)

        Dim menuItemSelectAll As New ToolStripMenuItem With {
                .Text = TextSelectAll
                }
        _contextMenuStrip1.Items.Add(menuItemSelectAll)
        menuItemSelectAll.ShortcutKeys = Keys.Control Or Keys.A
        ' ReSharper disable once LocalizableElement
        menuItemSelectAll.ShortcutKeyDisplayString = "Ctrl-A"
        'menuItemSelectAll.Enabled = (IIf(SampleTextBox.SelectionLength = SampleTextBox.Text.Length Or SampleTextBox.SelectionLength = SampleTextBox.Text.Trim.Length, False, True))
        AddHandler menuItemSelectAll.Click, AddressOf MenuItemSelectAll_Click

        _contextMenuStrip1.Items.Add(separator)
    End Sub

    Protected Overloads Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If SuggestListForm.Visible AndAlso KeysToHandle.Contains(keyData) Then
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub caComboBox_DropDownStyleChanged(sender As Object, e As EventArgs) Handles Me.DropDownStyleChanged
        If Not DesignMode Then
            If DropDownStyle = ComboBoxStyle.DropDown Then
                ''
            Else
                If DropDownStyle = ComboBoxStyle.DropDownList Then
                    DropDownStyle = ComboBoxStyle.DropDown
                    LimitToList = True
                Else
                    LimitToList = False
                End If
            End If
        End If
    End Sub

    Private Sub caCombobox_Leave(sender As Object, e As EventArgs) Handles Me.Leave
        'Debugger.Break()
        If SelectedIndex < 0 Then
            If Text = "" Then
                'allow empty strings
            Else
                If _suggestBindingList.Count() = 1 Then
                    Text = SuggestListForm.SuggestListBox.Items(0)
                Else
                    ' invalid selection or text set to empty string
                    Text = Nothing
                End If
            End If
        End If
    End Sub

    Private Sub cboAccountIdNo_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        PreviousSelectedIndex = SelectedIndex
    End Sub

    Private Sub HideSuggestionBox()
        SuggestListForm.Hide()
        SuggestListForm.Visible = False
    End Sub

    Private Sub MenuItemFind_Click()
        'Dim MyForm = Me.FindForm()
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

    Private Sub MenuItemSelectAll_Click()
        SelectAll()
    End Sub

    Private Shadows Sub OnDropDownClosed(sender As Object, e As EventArgs) Handles Me.DropDownClosed
        If DisplayOnly Then
            SelectedIndex = _previousIndex
            MessageBox.Show($"Sorry you don't have the proper security credentials to change this value. Reverting to original value.")
        End If
    End Sub

    'Private Sub OnSelectionChange(sender As Object, e As EventArgs) Handles Me.SelectedIndexChanged
    '    PreviousSelectedIndex = SelectedIndex
    'End Sub
    'Private Sub OnSelectionChange(sender As Object, e As EventArgs) Handles Me.SelectedIndexChanged
    '    PreviousSelectedIndex = SelectedIndex
    'End Sub

    Private Sub SetListBoxFormLocation(ByRef suggestLbForm As CListBoxForm)
        Dim pnt As Point
        Dim formLocation As Point
        Dim screenRectangle As Rectangle
        Dim myForm = FindForm()
        If myForm Is Nothing Then
            Return
        End If
        screenRectangle = Screen.PrimaryScreen.WorkingArea
        'suggestLbForm.Width = DropDownWidth
        suggestLbForm.StartPosition = FormStartPosition.Manual
        pnt = Parent.PointToScreen(Location)
        'If GlobalVariables.RightToLeftLayout Then
        '    formLocation = New Point(pnt.X - suggestLbForm.Width)
        '    If formLocation.X < 0 Then
        '        formLocation.X = pnt.X - suggestLbForm.Width
        '    End If
        'Else
        formLocation = New Point(pnt.X, pnt.Y + Height)
        'If formLocation.X + suggestLbForm.Width > screenRectangle.Width Then
        '    formLocation.X = pnt.X - suggestLbForm.Width
        'End If
        'End If
        If formLocation.Y + suggestLbForm.Height > screenRectangle.Height Then
            formLocation.Y = pnt.Y - suggestLbForm.Height
        End If
        suggestLbForm.Location = formLocation
        suggestLbForm.Width = Width
    End Sub

    'Public Sub SetValue(ByRef value)
    '    If value Is Nothing Then
    '        Text = Nothing
    '    End If
    '    If IsNumeric(value) Then
    '        If value = 0 Then
    '            Text = ""
    '        ElseIf ValueMember.ToLower() = "idno" AndAlso TextDisplayMember.ToLower() <> "idno" Then
    '            Dim saveDisplayMember As String = DisplayMember
    '            DisplayMember = "IdNo"
    '            Text = value
    '            DisplayMember = saveDisplayMember
    '        ElseIf ValueMember.ToLower() = "code" Then
    '            Dim saveDisplayMember As String = DisplayMember
    '            DisplayMember = "Code"
    '            Text = Val(value)
    '            DisplayMember = saveDisplayMember
    '        Else
    '            Text = value
    '        End If
    '    Else
    '        If ValueMember.ToLower() = "code" Then
    '            Dim saveDisplayMember As String = DisplayMember
    '            DisplayMember = "Code"
    '            Text = value
    '            DisplayMember = saveDisplayMember
    '        Else
    '            Text = value
    '        End If
    '    End If
    'End Sub
    Private Sub SuggestListBoxOnClick()
        Text = SuggestListForm.SuggestListBox.Text
        Focus()
    End Sub

    'Public Sub MakeEditable(editableControl As Boolean) Implements IEntryControl.MakeEditable
    '    DisplayOnly = Not editableControl
    'End Sub

    'Public Sub MakeSelectable(selectableControl As Boolean) Implements IEntryControl.MakeSelectable
    '    Me.Enabled = selectableControl
    'End Sub

    'Public Sub MakeViewable(ViewableControl As Boolean) Implements IEntryControl.MakeViewable
    '    DisplayOnly = Not ViewableControl
    'End Sub

    'Public Sub MakeVisible(visibleControl As Boolean) Implements IEntryControl.MakeVisible
    '    Visible = visibleControl
    'End Sub

#End Region

    'Private Const WmPaint As Integer = &HF
    'Private ReadOnly _buttonWidth As Integer = SystemInformation.HorizontalScrollBarArrowWidth

    'Protected Overrides Sub WndProc(ByRef m As Message)
    '    ' this will have an option to change the border color
    '    MyBase.WndProc(m)

    '    If m.Msg = WmPaint Then

    '        Using g = Graphics.FromHwnd(Handle)

    '            Using p = New Pen(BorderColor, 1)
    '                g.DrawRectangle(p, 0, 0, Width - _buttonWidth - 3, Height - 3)
    '                'Dim blueBrush As New SolidBrush(Color.RED)
    '                'Dim rect As New Rectangle(0, 0, Width - _buttonWidth - 3, Height - 3)
    '                'g.DrawRectangle(p, rect)
    '                'g.FillRectangle(blueBrush, rect)
    '                'ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
    '                'BackColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
    '            End Using

    '        End Using
    '    End If

    'End Sub

    <Browsable(True)>
    <Category("Appearance")>
    <DefaultValue(GetType(Color), "DimGray")>
    Public Property BorderColor As Color

    '    Private Declare Auto Function GetWindow Lib "user32.dll" (
    '        ByVal hWnd As IntPtr,
    '        ByVal wCmd As Int32
    '    ) As IntPtr

    Public Sub RevertValue()
        ' revert to previous value
        SelectedIndex = PreviousSelectedIndex
    End Sub

    Public Function ValueChanged()
        If SelectedIndex = PreviousSelectedIndex Then
            Return False
        End If
        Return True
    End Function

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
' ReSharper disable once CommentTypo
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