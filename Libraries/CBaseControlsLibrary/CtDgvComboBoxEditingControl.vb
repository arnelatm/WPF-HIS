Imports System.ComponentModel
Imports System.Drawing
Imports System.Linq.Expressions
Imports System.Threading
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub

Public Class CtDgvComboBoxEditingControl
    Inherits DataGridViewComboBoxEditingControl

    Public SuggestListForm As CListBoxForm = New CListBoxForm
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
        _filterRuleCompiled = Function(s) s.ToLower().Contains(Text.Trim().ToLower())
        _suggestListOrderRuleCompiled = Function(s) s
        PropertySelectorCompiled = Function(collection) collection.Cast(Of String)()

        SuggestListForm.SuggestListBox.DataSource = _suggestBindingList
        AddHandler SuggestListForm.SuggestListBox.Click, AddressOf SuggestListBoxOnClick
        AddHandler ParentChanged, AddressOf OnParentChanged
        DisplayMember = "Name"
        ValueMember = "IdNo"

    End Sub

    Public Property SuggestCharCount As Integer = 1

    Private Overloads Sub OnBindingContextChanged(sender As Object, e As EventArgs) Handles MyBase.BindingContextChanged
        PropertySelectorCompiled = Function(collection) collection.Cast(Of DataRowView)().[Select](Function(p) p.Row.ItemArray(0).ToString())
    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        'BeginUpdate()
        If Text.Length < SuggestCharCount Then
            _suggestBindingList.Clear()
            _suggestBindingList.RaiseListChangedEvents = True
            _suggestBindingList.ResetBindings()
            SuggestListForm.Hide()
        Else
            BeginUpdate()
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
            EndUpdate()
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

    Protected Overloads Overrides Sub OnLostFocus(e As EventArgs)
        If Not SuggestListForm.SuggestListBox.Focused Then
            HideSuggBox()
        End If
        MyBase.OnLostFocus(e)
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
        Dim myform = FindForm()
        If myform Is Nothing Then
            Return
        End If
        screenRectangle = Screen.PrimaryScreen.WorkingArea
        suggestLbForm.Width = Width + 2
        suggestLbForm.StartPosition = FormStartPosition.Manual
        pnt = Parent.PointToScreen(Location)
        'If GlobalVariables.RightToLeftLayout Then
        '    formLocation = New Point(pnt.X - suggestLbForm.Width)
        '    If formLocation.X < 0 Then
        '        formLocation.X = pnt.X - suggestLbForm.Width
        '    End If
        'Else
        formLocation = New Point(pnt.X, pnt.Y + Height)
        'End If
        suggestLbForm.Location = formLocation
    End Sub

    Private Function Offset(ByRef controlObj As Control, ByVal x As Integer, ByVal y As Integer) As Point

        Dim pt As Point
        Dim parentObj As Control = controlObj.Parent

        Do While parentObj IsNot controlObj.FindForm
            x += parentObj.Location.X
            y += parentObj.Location.Y
            parentObj = parentObj.Parent
        Loop

        pt = PointToScreen(controlObj.Location)
        pt.Offset(x, y)
        Return pt

    End Function

    Public Function GetValue()
        Return SelectedValue
    End Function

    'Public Overrides Function EditingControlWantsInputKey(ByVal keyData As Keys, ByVal dataGridViewWantsInputKey As Boolean) As Boolean
    '    Return (keyData And Keys.KeyCode) = Keys.Down OrElse (keyData And Keys.KeyCode) = Keys.Up OrElse Me.DroppedDown AndAlso (keyData And Keys.KeyCode) = Keys.Escape OrElse (keyData And Keys.KeyCode) = Keys.[Return] OrElse Not dataGridViewWantsInputKey
    'End Function

    Public Overrides Function EditingControlWantsInputKey(ByVal key As Keys, ByVal dataGridViewWantsInputKey As Boolean) As Boolean

        ' Let the DateTimePicker handle the keys listed.
        Select Case key And Keys.KeyCode

            Case Keys.Return, Keys.Escape
                If DroppedDown Then
                    Return True
                Else
                    Return dataGridViewWantsInputKey
                End If

            'Case Keys.Left, Keys.Right, Keys.Home, Keys.End
            '    '    Keys.Home, Keys.End, Keys.PageDown, Keys.PageUp
            '    Return True

            Case Keys.PageDown, Keys.PageUp, Keys.Up, Keys.Down
                If DroppedDown Then
                    Return True
                Else
                    Return False
                End If

            Case Else
                Return Not dataGridViewWantsInputKey
        End Select

    End Function

End Class