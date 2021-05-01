Imports System.ComponentModel
Imports System.Drawing
Imports System.Linq.Expressions
Imports System.Threading
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub

Public Class CDgvCaComboboxEditingControl
    Inherits DataGridViewComboBoxEditingControl
    Implements IDataGridViewEditingControl

#Region "Custom Properties"

    Public DataSourceProgrammaticChange As Boolean = False
    Public SuggestListForm As CListBoxForm = New CListBoxForm
    Private ReadOnly _suggestBindingList As BindingList(Of String) = New BindingList(Of String)()
    Private _propertySelector As Expression(Of Func(Of ObjectCollection, IEnumerable(Of String)))
    Protected PropertySelectorCompiled As Func(Of ObjectCollection, IEnumerable(Of String))
    Private _filterRule As Expression(Of Func(Of String, String, Boolean))
    Private _filterRuleCompiled As Func(Of String, Boolean)
    Private _suggestListOrderRule As Expression(Of Func(Of String, String))
    Private _suggestListOrderRuleCompiled As Func(Of String, String)

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Override DropDownList style with custom built feature.")>
    <Browsable(True)>
    Public Property OverrideDropDownStyleList As Boolean

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to make this control visible only when in editing or adding mode")>
    <Browsable(True)>
    Public Property HideWhenNotEditingOrAdding As Boolean = False

    Public Property ValueIsNullable As Boolean

    Public Property DefaultValue As Object

    Public Sub OnKeyDownPressed(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            SendKeys.SendWait("{TAB}")
        End If
    End Sub

    Private Shared ReadOnly KeysToHandle As Keys() = {Keys.Down, Keys.Up, Keys.Enter, Keys.Escape}

    Public Property OriginalList As Object() = Nothing

    Public Property OriginalDataSource As Object

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

    Private Property LimitToList As Boolean = False

#End Region

#Region "Event Handlers"

    Private Overloads Sub OnBindingContextChanged(sender As Object, e As EventArgs) Handles MyBase.BindingContextChanged
        PropertySelectorCompiled = Function(collection) collection.Cast(Of ClassesLibrary.LookupData)().[Select](Function(p) p.Name)
    End Sub

    Private _previousIndex As Integer

    Protected Overloads Overrides Sub OnDropDown(e As EventArgs)
        HideSuggestionBox()
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

    Private Shadows Sub OnParentChanged(ByVal sender As Object, ByVal e As EventArgs)
        SetListBoxFormLocation(SuggestListForm)
        SuggestListForm.SuggestListBox.Font = New Font("Segoe UI", 9)
    End Sub

    Protected Overrides Sub OnLocationChanged(ByVal e As EventArgs)
        MyBase.OnLocationChanged(e)
        SetListBoxFormLocation(SuggestListForm)
    End Sub

    'Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
    '    MyBase.OnSizeChanged(e)
    'End Sub

    Protected Overloads Overrides Sub OnLostFocus(e As EventArgs)
        If Not SuggestListForm.SuggestListBox.Focused Then
            HideSuggestionBox()
        End If
        MyBase.OnLostFocus(e)
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

#End Region

#Region "Methods"

    Public Sub New()
        MyBase.New()
        Dim myFont As New Font("Sans Serif", 10.0!, FontStyle.Regular)
        Margin = New Padding(1, 1, 1, 1)
        FlatStyle = FlatStyle.Standard
        Font = myFont
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

    Public Sub SetValue(ByRef value)
        If value = Nothing Then
            Text = Nothing
        Else
            Dim saveDisplaymember As String = DisplayMember
            DisplayMember = ValueMember
            Text = value
            DisplayMember = saveDisplaymember
            If ValueMember.ToLower() = "idno" Then
                If Not IsNumeric(value) OrElse SelectedItem.idNo <> value Then
                    SelectedIndex = -1
                    Text = value.ToString()
                    MessageBox.Show("Invalid value <" + value.ToString() + "> for field " + Name)
                End If
            ElseIf ValueMember.ToLower() = "code" Then
                If SelectedItem.Code <> value Then
                    SelectedIndex = -1
                    Text = value.ToString()
                    MessageBox.Show("Invalid value <" + Text + "> for field " + Name)
                End If
            End If
        End If
    End Sub

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

    Private Sub SuggestListBoxOnClick()
        Text = SuggestListForm.SuggestListBox.Text
        Focus()
    End Sub

    Private Sub HideSuggestionBox()
        SuggestListForm.Hide()
        SuggestListForm.Visible = False
    End Sub

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
        suggestLbForm.StartPosition = FormStartPosition.Manual
        pnt = Parent.PointToScreen(Location)
        If GlobalVariables.RightToLeftLayout Then
            formLocation = New Point(pnt.X - suggestLbForm.Width)
            If formLocation.X < 0 Then
                formLocation.X = pnt.X - suggestLbForm.Width
            End If
        Else
            formLocation = New Point(pnt.X, pnt.Y + Height)
            'If formLocation.X + suggestLbForm.Width > screenRectangle.Width Then
            '    formLocation.X = pnt.X - suggestLbForm.Width
            'End If
        End If
        If formLocation.Y + suggestLbForm.Height > screenRectangle.Height Then
            formLocation.Y = pnt.Y - suggestLbForm.Height
        End If
        suggestLbForm.Location = formLocation
    End Sub

    Private Sub caComboBox_DropDownStyleChanged(sender As Object, e As EventArgs) Handles Me.DropDownStyleChanged
        If Not (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime) Then
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

#End Region

End Class