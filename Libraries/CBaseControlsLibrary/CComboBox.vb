Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports AATM.Libraries.BaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub

Public Class CComboBox
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
    Private _oldValue As Integer
    Private WithEvents ContextMenuStrip1 As New ContextMenuStrip
    Private _originalDropDownStyle As Integer
    Private _hideWhenNotEditingOrAdding As Boolean = False
    Private _editingMode As Boolean = True
    Private _bypassTextChange As Boolean = False
    Public DatasourceProgrammaticChange As Boolean = False
    Private _currentSearchTerm As String = ""
    Private _changingSearchValueOnly As Boolean = False

    Public Sub New()
        MyBase.New()
        Dim myFont As New Font("Sans Serif", 10.0!, FontStyle.Regular)
        ContextMenuStrip = ContextMenuStrip1
        OriginalDropDownStyle = DropDownStyle
        Margin = New Padding(1)
        FlatStyle -= Border3DStyle.RaisedOuter
        Font = myFont

        DropDownStyle = ComboBoxStyle.DropDown
        AutoCompleteMode = AutoCompleteMode.Suggest

    End Sub

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

    Public Property OldValue() As Integer
        Get
            Return _oldValue
        End Get
        Set(ByVal value As Integer)
            _oldValue = value
        End Set
    End Property

    Public Property OriginalDropDownStyle As Integer
        Get
            Return _originalDropDownStyle
        End Get
        Set
            _originalDropDownStyle = Value
        End Set
    End Property

    Public Sub OnKeyDownPressed(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.SendWait("{TAB}")
        End If
    End Sub

    <Category("Custom Properties")>
    <Description("Select the label to which this control is linked.")>
    <Browsable(True)>
    Public Property LinkedLabel As CLabel Implements ILinkedLabel.LinkedLabel

    Public Sub EnterHandler(sender As Object, e As EventArgs) Handles MyBase.Enter
        If EditingMode Then
            ForeColor = GlobalVariables.DefaultFormControlEditingForegroundColor
            BackColor = GlobalVariables.DefaultFormControlEditingBackgroundColor
        Else
            ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
            BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
        End If
    End Sub

    Public Sub LeaveHandler(sender As Object, e As EventArgs) Handles MyBase.Leave
        If EditingMode Then
            ForeColor = GlobalVariables.DefaultFormControlForegroundColor
            BackColor = GlobalVariables.DefaultFormControlBackgroundColor
        Else
            ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
            BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
        End If
    End Sub

    'Public Sub CComboBox_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Validating
    '    Dim ErrorMsg As String
    '    'If Me.ValueIsNumeric Then
    '    '    If Not IsNumeric(Me.Text) Then
    '    '        If Me.ValueIsNullable And Me.Text.Trim() = "" Then
    '    '            Me.Text = ""
    '    '            '' nothing to do
    '    '            ' blank values allowed for nullable fields
    '    '        Else
    '    '            e.Cancel = True
    '    '            ErrorMsg = "Sorry, only numeric values allowed for this field! The value <" + Me.Text + "> is Not allowed. Reverting to previous value."
    '    '            MessageBox.Show(ErrorMsg)
    '    '            'Me.Undo()
    '    '            'MyErrorProvider.ShowErrorMessage(ErrorMsg)
    '    '        End If
    '    '    End If
    '    'End If
    'End Sub

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
        'Dim SearchForm = New CFindForm(1, Me)
        ''SearchForm.Show()
        'SearchForm.ShowDialog()
        '_textToSearch = SearchForm.TextToSearch
        '_searchPlace = SearchForm.GetSearchPlace
        'SearchForm.Dispose()
        'If _textToSearch <> "" Then

        '    CallByName(MyForm, "FindField", CallType.Method, Me)

        'End If
    End Sub

    Public Function GetTextToSearch() As String
        Return _textToSearch
    End Function

    Public Function GetSearchAnywhere() As Char
        Return _searchPlace
    End Function

    Private Sub MenuItemSelectAll_Click()
        SelectAll()
    End Sub

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

    Public Property Translatable As Boolean Implements IEntryControl.Translatable
        Get
            Return False
        End Get
        Set(value As Boolean)
            _translatable = value
        End Set
    End Property

    'Public Sub MakeEditable(editableControl As Boolean) Implements IEntryControl.MakeEditable
    '    DisplayOnly = Not editableControl
    'End Sub

    'Public Sub MakeVisible(visibleControl As Boolean) Implements IEntryControl.MakeVisible
    '    Visible = visibleControl
    'End Sub

    Public Property EditingMode As Boolean Implements IEntryControl.EditingMode
        Get
            Return _editingMode
        End Get
        Set(value As Boolean)
            _editingMode = value
            If value Then
                ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
                BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
            Else
                ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
                BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
            End If
        End Set
    End Property

    Private _previousSearchterm As String
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

    Private Overloads Sub OnTextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Me.TextChanged
        If Not DatasourceProgrammaticChange Then
            If Not String.IsNullOrEmpty(Text) OrElse Not Visible OrElse Not Enabled Then
                Return
            End If
            If Not sender.Items.Count() = 0 Then
                ResetCompletionList()
            End If
        End If
    End Sub

    Private _sel As Object

    Private Overloads Sub OnSelectionChangeCommitted(ByVal sender As Object, ByVal e As EventArgs) Handles Me.SelectionChangeCommitted
        If SelectedItem Is Nothing Then
            Return
        End If
        _sel = SelectedItem
        ResetCompletionList()
        SelectedItem = _sel
    End Sub

    Private Overloads Sub OnKeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = vbCr OrElse e.KeyChar = vbLf Then
            e.Handled = True

            If SelectedIndex = -1 AndAlso Items.Count > 0 AndAlso Items(0).ToString().ToLowerInvariant().StartsWith(Text.ToLowerInvariant()) Then
                Text = Items(0).ToString()
            End If

            DroppedDown = False
            Return
        End If

        BeginInvoke(New Action(AddressOf ReevaluateCompletionList))
    End Sub

    Private Sub ResetCompletionList()
        _previousSearchterm = Nothing
        Try
            SuspendLayout()
            'If _originalList Is Nothing OrElse _originalList.Count = 0 Then
            '    '_originalDataSource = DataSource
            '    _originalList = Items.Cast(Of Object)().ToArray()
            'End If

            'If Items.Count = _originalList.Length Then
            '    Return
            'End If
            DatasourceProgrammaticChange = True
            If OriginalDataSource Is Nothing Then
                OriginalDataSource = DataSource
            Else
                DataSource = OriginalDataSource
            End If
            DatasourceProgrammaticChange = False
        Finally
            ResumeLayout(True)
        End Try
    End Sub

    'Private Sub cComboBox_DataSourceChanged(sender As Object, e As EventArgs) Handles Me.DataSourceChanged
    '    If Not _changingSearchValueOnly then
    '        originalDataSource = DataSource
    '        originalList = Nothing
    '    end if
    'End Sub

    'Private Sub cComboBox_BindingContextChanged(sender As Object, e As EventArgs) Handles Me.BindingContextChanged
    '    If DataSource Is Nothing Then
    '        originalList = Nothing
    '        originalDataSource = Nothing
    '    Else
    '        If Not _changingSearchValueOnly then
    '            originalDataSource = DataSource
    '            originalList = Items.Cast(Of Object)().ToArray()
    '        End if
    '    End If
    'End Sub

    Private Sub ReevaluateCompletionList()
        _currentSearchTerm = Text.ToLowerInvariant()
        If _currentSearchTerm = _previousSearchterm Then
            Return
        End If
        _previousSearchterm = _currentSearchTerm
        Try
            SuspendLayout()
            Dim newList As Object()
            If String.IsNullOrEmpty(_currentSearchTerm) Then
                If Items.Count = _originalList.Length Then
                    Return
                End If
                newList = _originalList
            Else
                If _originalList Is Nothing Then
                    'If Not _changingSearchValueOnly then
                    '    OriginalDataSource = DataSource
                    'end if
                    _originalList = Items.Cast(Of Object)().ToArray()
                End If
                newList = _originalList.Where(Function(x) x.ToString().ToLowerInvariant().Contains(_currentSearchTerm)).ToArray()
            End If
            _changingSearchValueOnly = True
            DataSource = Nothing
            Try
                DataSource = newList
            Catch ex As Exception
                'newList = NewList
            End Try
            _changingSearchValueOnly = True
        Finally
            If _currentSearchTerm.Length >= 1 AndAlso Not DroppedDown Then
                DroppedDown = True
                Cursor.Current = Cursors.[Default]
                Text = _currentSearchTerm
                [Select](_currentSearchTerm.Length, 0)
            End If
            ResumeLayout(True)
        End Try
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

    'Public Sub MakeViewable(ViewableControl As Boolean) Implements IEntryControl.MakeViewable
    '    ' not applicable
    'End Sub

    'Public Sub MakeSelectable(selectableControl As Boolean) Implements IEntryControl.MakeSelectable
    '    Enabled = selectableControl
    'End Sub
End Class