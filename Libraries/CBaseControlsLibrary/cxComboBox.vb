Imports System.ComponentModel
Imports System.Drawing
Imports System.Linq.Expressions
Imports System.Threading
Imports System.Windows.Forms
Imports AATM.Libraries.AatmInterfaces
Imports AATM.Libraries.BaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.Messaging

Public Class CxComboBox
    Inherits BCombobox
    Implements IEntryControl, ILinkedLabel, IFindableControl

#Region "Custom Properties"

    Private _translatable As Boolean = False
    Private _editingMode As Boolean = False
    Private _filterRule As Expression(Of Func(Of String, String, Boolean))
    Private _filterRuleCompiled As Func(Of String, Boolean)
    Private _propertySelector As Expression(Of Func(Of ObjectCollection, IEnumerable(Of String)))
    Private _suggestListOrderRule As Expression(Of Func(Of String, String))
    Private _suggestListOrderRuleCompiled As Func(Of String, String)
    Private ReadOnly _defaultDropDownHeight As Int16
    Private ReadOnly _defaultDropdownStyle As ComboBoxStyle
    Private ReadOnly _defaultMaxDropDownItems As Int16
    Private ReadOnly _suggestBindingList As BindingList(Of String) = New BindingList(Of String)()
    Private Shared ReadOnly KeysToHandle As Keys() = {Keys.Down, Keys.Up, Keys.Enter, Keys.Escape}
    Private WithEvents _contextMenuStrip1 As New ContextMenuStrip
    Public DataSourceProgrammaticChange As Boolean = False
    Public DataT As DataTable
    Public DataV As DataView
    Private CBFullList As Dictionary(Of String, Int32)
    Private CBFilteredList As Dictionary(Of String, Int32)
    Private ComboBoxBusy As Boolean



    Private Property _editMode As Boolean
    Public Property ChangingSearchValueOnly As Boolean = False

    Public Shared Property Copy As String = "Copy Selected Text"

    Public Property CurrentSearchTerm As String = ""

    Public Shared Property Cut As String = "Cut Selected Text"

    Public Property DefaultValue As Object

    Public Shared Property Delete As String = "Delete Selected Text"
    Public ComboBoxValueChanged As Boolean = False


    <Category("Custom Properties")>
    <DefaultValue(False)>
    <Description("Set to True to specify that this control is always editable.")>
    Public Property AlwaysEditable As Boolean = False
    Private _lastValue As Object = Nothing

    <Bindable(True)>
    <Category("Custom Properties")>
    <DefaultValue(False)>
    <Description("Set to True to specify that this control is for DisplayOnly.")>
    <Browsable(True)>
    Public Property DisplayOnly As Boolean


    <Category("Custom Properties")>
    <DefaultValue(False)>
    <Description("Set to True to specify that this control can be edited.")>
    Public Property Editable As Boolean = True


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
            UpdateDisplayOnlyControl()
        End Set
    End Property

    Public Sub UpdateDisplayOnlyControl()
        If _editingMode AndAlso Editable AndAlso Not DisplayOnly Then
            DropDownHeight = _defaultDropDownHeight
            DropDownStyle = _defaultDropdownStyle
            MaxDropDownItems = _defaultMaxDropDownItems
            If Hidden Then
                ForeColor = Color.Black
                BackColor = Color.Black
            Else
                ForeColor = GlobalVariables.DefaultFormControlForegroundColor
                BackColor = GlobalVariables.DefaultFormControlBackgroundColor
            End If
        Else
            DropDownStyle = ComboBoxStyle.Simple
            DropDownHeight = Height
            MaxDropDownItems = 1
            IntegralHeight = True
            ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
            BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
        End If

    End Sub

    <Bindable(True)>
    <Category("Custom Properties")>
    <DefaultValue(False)>
    <Description("Set to True to specify that this will only suggestappend when more than this specified number of characters is typed in.")>
    <Browsable(True)>
    Public Property SuggestCharCount As Integer

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to make this control visible only when in editing or adding mode")>
    <Browsable(True)>
    Public Property HideWhenNotEditingOrAdding As Boolean = False

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

    Public Shared Property WmPaint1 As Integer = &HF

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to specify that this control will only accept values on list.")>
    <Browsable(True)>
    Public Property LimitToList As Boolean = False

    Public Sub OnKeyDownPressed(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If DisplayOnly Then
            e.SuppressKeyPress = True
        Else
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
                e.Handled = True
                e.SuppressKeyPress = True
            Else
                e.Handled = False
            End If
        End If
    End Sub

#End Region

#Region "Declarations#"

    ' Text Menu Captions
    Private Shared ReadOnly _textFind = MessagingService.TranslateCaption("Find on this field")

    Private Shared ReadOnly _textCut = MessagingService.TranslateCaption("Cut Selected Text")
    Private Shared ReadOnly _textCopy = MessagingService.TranslateCaption("Copy Selected Text")
    Private Shared ReadOnly _textPaste = MessagingService.TranslateCaption("Paste Text")
    Private Shared ReadOnly _textUndo = MessagingService.TranslateCaption("Undo Last Action")
    Private Shared ReadOnly _textDelete = MessagingService.TranslateCaption("Delete Selected Text")
    Private Shared ReadOnly _textSelectAll = MessagingService.TranslateCaption("Select All Text")

#End Region

#Region "Event Handlers"

    Private _previousIndex As Integer

    Public Sub EnterHandler(sender As Object, e As EventArgs) Handles MyBase.Enter
        If Hidden Then
            ForeColor = Color.Black
            BackColor = Color.Black
        Else
            If DisplayOnly Then
                ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
                BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
            ElseIf EditingMode AndAlso Editable Then
                ForeColor = GlobalVariables.DefaultFormControlEditingForegroundColor
                BackColor = GlobalVariables.DefaultFormControlEditingBackgroundColor
            Else
                ForeColor = GlobalVariables.DefaultFormForegroundColor
                BackColor = GlobalVariables.DefaultFormBackgroundColor
            End If
        End If
    End Sub

    Protected Overrides Sub OnDropDown(e As EventArgs)
        If DisplayOnly Then
            _previousIndex = SelectedIndex
        End If
    End Sub
    Protected Overrides Sub OnGotFocus(e As EventArgs)
        BeginUpdate()
        MyBase.OnGotFocus(e)
        _lastValue = SelectedValue
        EndUpdate()
    End Sub

    Private Sub CxComboBox_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
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
        _defaultMaxDropDownItems = MaxDropDownItems
        _defaultDropdownStyle = DropDownStyle
        _defaultDropDownHeight = DropDownHeight

        Text = ""
        SetStyle(ControlStyles.EnableNotifyMessage, True)
        EditingMode = False

        ComboBoxBusy = False
        CBFullList = New Dictionary(Of String, Int32)()
        CBFilteredList = New Dictionary(Of String, Int32)()

    End Sub

    Private Sub FilterList(ByVal show As Boolean)
        If ComboBoxBusy = False Then
            Dim orgText As String
            ComboBoxBusy = True
            orgText = Text
            DroppedDown = False
            CBFilteredList.Clear()

            For Each item As KeyValuePair(Of String, Int32) In CBFullList
                If item.Key.ToUpper().Contains(orgText.ToUpper()) Then CBFilteredList.Add(item.Key, item.Value)
            Next

            If CBFilteredList.Count < 1 Then CBFilteredList.Add("None", 0)
            BeginUpdate()
            DataSource = New BindingSource(CBFilteredList, Nothing)
            DisplayMember = "Key"
            ValueMember = "Value"
            DroppedDown = show
            SelectedIndex = -1
            Text = orgText
            [Select](Text.Length, 0)
            EndUpdate()
            Cursor.Current = Cursors.[Default]
            ComboBoxBusy = False
        End If
    End Sub

    Public Function GetValue(Of T)() As T
        If SelectedIndex = -1 Then
            Return Nothing
        Else
            Dim x As T
            x = CType(SelectedValue, T)
            Return x
        End If
    End Function

    Public Function GetValue()
        If SelectedItem IsNot Nothing Then
            Return DirectCast(SelectedItem, System.Data.DataRowView).Row(ValueMember)
        Else
            Return Nothing
        End If
    End Function

    Public Sub SetValue(value)
        If value Is DBNull.Value OrElse value Is Nothing Then
            SelectedIndex = -1
        Else
            Select Case DisplayMember
                Case "IdNo", "Code", "Name"
                    ValueSearch(value)
                Case Else
                    SelectedValue = value
            End Select
        End If
    End Sub

    Public Property DataValue

    Private Sub ValueSearch(value As Object)
        If DataSource IsNot Nothing Then
            SelectedValue = value
        Else
            SelectedIndex = -1
        End If
    End Sub


    Private Sub IdNoSearch(value As Object)
        Dim returnValue As Int32
        Dim found As Boolean = False
        Dim i = 0
        If DataSource IsNot Nothing Then
            For Each item As DataRow In DataSource.Rows()
                If item(ValueMember) = value Then
                    'If Visible Then
                    SelectedItem = item
                    'Else
                    '    SelectedItem = DataSource(i)
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
                    SelectedItem = DataSource(i).Code
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
                    SelectedItem = DataSource(i).Name
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
            MessagingService.Show(True, "MsgOperationNotAvailableInViewMode")
        End If
    End Sub

    Private Sub MenuItemDelete_Click()
        If EditingMode Then
            SelectedIndex = -1
        Else
            MessagingService.Show(True, "MsgOperationNotAvailableInViewMode")
        End If
    End Sub

    Private Sub MenuItemCopy_Click()
        Clipboard.SetText(SelectedText)
    End Sub

    Private Sub MenuItemPaste_Click()
        If EditingMode Then
            Text = Clipboard.GetText()
        Else
            MessagingService.Show(True, "MsgOperationNotAvailableInViewMode")
        End If
    End Sub

    Private Sub MenuItemUndo_Click()
        If EditingMode Then
            SendKeys.Send("^Z")
        Else
            MessagingService.Show(True, "MsgOperationNotAvailableInViewMode")
        End If
    End Sub

    Protected Overloads Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If KeysToHandle.Contains(keyData) Then
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

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
        FindDataType = GetObjectDataType(x)
        searchForm.ShowDialog()
        Invoker.InvokeFunction(myForm, "FindFieldNew", {Me})
    End Sub

    Private Sub MenuItemSelectAll_Click()
        SelectAll()
    End Sub

    Private Shadows Sub OnDropDownClosed(sender As Object, e As EventArgs) Handles Me.DropDownClosed
        If DisplayOnly Then
            SelectedIndex = _previousIndex
            AATM.Libraries.Messaging.MessagingService.Show(True, "MsgCannotEditReadOnly")
        End If
    End Sub

    Public Function GetNullableValue(Of T)()
        Dim x = GetValue()
        If x Is Nothing Then
            Return Nothing
        Else
            Return CType(x, T)
        End If
    End Function

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

'Public Class CSuggestListForm
'    Inherits CListBoxForm

'End Class

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