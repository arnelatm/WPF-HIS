Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports AATM.Libraries.BaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub

<Obsolete("Apparently unused legacy/experimental combo control. Prefer CtComboBox for new code.", False)>
<System.ComponentModel.ToolboxItem(False)>
Public Class CfComboBox
    Inherits BCombobox
    Implements IEntryControl, ILinkedLabel

    Private _defaultValue As Object
    Private _isNumeric As Boolean
    Private _isMandatory As Boolean
    Private _displayOnly As Boolean
    Private _translatable As Boolean = False
    Private _comboBoxBusy As Boolean
    Private _cBFullList As Dictionary(Of String, System.Int32)
    Private _cBFilteredList As Dictionary(Of String, System.Int32)


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
        Dim myFont As New Font("Arial", 10.0!, FontStyle.Regular)
        ContextMenuStrip = ContextMenuStrip1
        Margin = New Padding(1)
        FlatStyle -= Border3DStyle.RaisedOuter
        Font = myFont

        DropDownStyle = ComboBoxStyle.DropDown
        AutoCompleteMode = AutoCompleteMode.SuggestAppend
        AutoCompleteSource = AutoCompleteSource.ListItems

    End Sub

    Public Property CbFullList As Dictionary(Of String, System.Int32)
        Get
            Return _cBFullList
        End Get
        Set(value As Dictionary(Of String, System.Int32))
            _cBFullList = value
        End Set
    End Property

    <Category("Custom Properties")>
    <DefaultValue(False)>
    <Description("Set to True to specify that this control is always editable.")>
    Public Property AlwaysEditable As Boolean = False

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
        If Not AlwaysEditable Then
            If EditingMode Then
                ForeColor = GlobalVariables.DefaultFormControlEditingForegroundColor
                BackColor = GlobalVariables.DefaultFormControlEditingBackgroundColor
            Else
                ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
                BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
            End If
        End If
    End Sub

    Public Sub LeaveHandler(sender As Object, e As EventArgs) Handles MyBase.Leave
        If Not AlwaysEditable Then
            If EditingMode Then
                ForeColor = GlobalVariables.DefaultFormControlForegroundColor
                BackColor = GlobalVariables.DefaultFormControlBackgroundColor
            Else
                ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
                BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
            End If
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
        AddHandler menuItemSelectAll.Click, AddressOf MenuItemSelectAll_Click

        ContextMenuStrip1.Items.Add(separator)
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
            If Not AlwaysEditable Then
                ' If the value isn't changing, then do nothing
                If Value = _readOnlyCombo Then Exit Property
                _readOnlyCombo = Value
            End If
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

    Public Property EditingMode As Boolean Implements IEntryControl.EditingMode
        Get
            Return _editingMode
        End Get
        Set(value As Boolean)
            If Not AlwaysEditable Then
                _editingMode = value
                UpdateDisplayOnlyControl()
            End If
        End Set
    End Property

    Public Sub UpdateDisplayOnlyControl()
        If _editingMode And Not DisplayOnly Then
            ForeColor = GlobalVariables.DefaultFormControlForegroundColor
            BackColor = GlobalVariables.DefaultFormControlForegroundColor
        Else
            ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
            BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
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

    Private Sub FilterList(ByVal show As Boolean)
        If _comboBoxBusy = False Then
            Dim orgText As String
            _comboBoxBusy = True
            orgText = Text
            DroppedDown = False
            _cBFilteredList.Clear()

            For Each item As KeyValuePair(Of String, Int32) In _cBFullList
                If item.Key.ToUpper().Contains(orgText.ToUpper()) Then _cBFilteredList.Add(item.Key, item.Value)
            Next

            If _cBFilteredList.Count < 1 Then _cBFilteredList.Add("None", 0)
            BeginUpdate()
            DataSource = New BindingSource(_cBFilteredList, Nothing)
            DisplayMember = "Key"
            ValueMember = "Value"
            DroppedDown = show
            SelectedIndex = -1
            Text = orgText
            [Select](Text.Length, 0)
            EndUpdate()
            Cursor.Current = Cursors.[Default]
            _comboBoxBusy = False
        End If
    End Sub

    Private Sub comboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.SelectedIndexChanged
        If _comboBoxBusy = False Then
            FilterList(False)
        End If
    End Sub

    Private Sub comboBox1_TextUpdate(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.TextUpdate
        FilterList(True)
    End Sub

End Class
