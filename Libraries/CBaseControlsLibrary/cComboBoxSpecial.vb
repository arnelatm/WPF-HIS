Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Linq
Imports System.Linq.Expressions
Imports System.Windows.Forms

Public Class CComboboxSpecial
    Inherits ComboBox

    Private ReadOnly _suggestListBox As ListBox = New ListBox With {
        .Visible = False,
        .TabStop = False
    }

    Private ReadOnly _suggestBindingList As BindingList(Of ClassesLibrary.LookupData) = New BindingList(Of ClassesLibrary.LookupData)()
    Private _propertySelector As Expression(Of Func(Of ObjectCollection, IEnumerable(Of String)))
    Private _propertySelectorCompiled As Func(Of ObjectCollection, IEnumerable(Of String))
    Private _filterRule As Expression(Of Func(Of String, String, Boolean))
    Private _filterRuleCompiled As Func(Of String, Boolean)
    Private _suggestListOrderRule As Expression(Of Func(Of String, String))
    Private _suggestListOrderRuleCompiled As Func(Of String, String)

    Public Property SuggestBoxHeight As Integer
        Get
            Return _suggestListBox.Height
        End Get
        Set(ByVal value As Integer)
            If value > 0 Then _suggestListBox.Height = value
        End Set
    End Property

    Public Property PropertySelector As Expression(Of Func(Of ObjectCollection, IEnumerable(Of String)))
        Get
            Return _propertySelector
        End Get
        Set(ByVal value As Expression(Of Func(Of ObjectCollection, IEnumerable(Of String))))
            If value Is Nothing Then Return
            _propertySelector = value
            _propertySelectorCompiled = value.Compile()
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
        _propertySelectorCompiled = Function(collection) collection.Cast(Of String)()
        _suggestListBox.DataSource = _suggestBindingList
        AddHandler _suggestListBox.Click, AddressOf SuggestListBoxOnClick
        AddHandler ParentChanged, AddressOf OnParentChanged
    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        MyBase.OnTextChanged(e)
        If Not Focused Then Return
        _suggestBindingList.Clear()
        _suggestBindingList.RaiseListChangedEvents = False
        _propertySelectorCompiled(Items).Where(_filterRuleCompiled).OrderBy(_suggestListOrderRuleCompiled).ToList().ForEach(AddressOf _suggestBindingList.Add)
        _suggestBindingList.RaiseListChangedEvents = True
        _suggestBindingList.ResetBindings()
        _suggestListBox.Visible = _suggestBindingList.Any()

        If _suggestBindingList.Count = 1 Then 'AndAlso _suggestBindingList.Single().Length = Text.Trim().Length Then
            'Text = _suggestBindingList.Single()
            [Select](0, Text.Length)
            _suggestListBox.Visible = False
        End If
    End Sub

    Private Shadows Sub OnParentChanged(ByVal sender As Object, ByVal e As EventArgs)
        Parent.Controls.Add(_suggestListBox)
        Parent.Controls.SetChildIndex(_suggestListBox, 0)
        _suggestListBox.Top = Top + Height - 3
        _suggestListBox.Left = Left + 3
        _suggestListBox.Width = Width - 20
        _suggestListBox.Font = New Font("Segoe UI", 9)
    End Sub

    Protected Overrides Sub OnLocationChanged(ByVal e As EventArgs)
        MyBase.OnLocationChanged(e)
        _suggestListBox.Top = Top + Height - 3
        _suggestListBox.Left = Left + 3
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        MyBase.OnSizeChanged(e)
        _suggestListBox.Width = Width - 20
    End Sub

    Protected Overrides Sub OnLostFocus(ByVal e As EventArgs)
        If Not _suggestListBox.Focused Then HideSuggBox()
        MyBase.OnLostFocus(e)
    End Sub

    Private Sub SuggestListBoxOnClick(sender As Object, ByVal eventArgs As EventArgs)
        Text = _suggestListBox.Text
        Focus()
    End Sub

    Private Sub HideSuggBox()
        _suggestListBox.Visible = False
    End Sub

    Protected Overrides Sub OnDropDown(ByVal e As EventArgs)
        HideSuggBox()
        'MyBase.OnDropDown(e)
    End Sub

    Protected Overrides Sub OnPreviewKeyDown(ByVal e As PreviewKeyDownEventArgs)
        If Not _suggestListBox.Visible Then
            MyBase.OnPreviewKeyDown(e)
            Return
        End If

        Select Case e.KeyCode
            Case Keys.Down
                If _suggestListBox.SelectedIndex < _suggestBindingList.Count - 1 Then _suggestListBox.SelectedIndex += 1
                Return
            Case Keys.Up
                If _suggestListBox.SelectedIndex > 0 Then _suggestListBox.SelectedIndex -= 1
                Return
            Case Keys.Enter
                Text = _suggestListBox.Text
                [Select](0, Text.Length)
                _suggestListBox.Visible = False
                Return
            Case Keys.Escape
                HideSuggBox()
                Return
        End Select

        MyBase.OnPreviewKeyDown(e)
    End Sub

    Private Shared ReadOnly KeysToHandle As Keys() = {Keys.Down, Keys.Up, Keys.Enter, Keys.Escape}

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If _suggestListBox.Visible AndAlso KeysToHandle.Contains(keyData) Then Return True
        Return MyBase.ProcessCmdKey(msg, keyData)
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
            End If
        End If
    End Sub

    Private Sub IdNoSearch(value As Object)
        Dim returnValue As Int32
        Dim found As Boolean = False
        Dim i = 0
        If DataSource IsNot Nothing Then
            For Each item In DataSource
                If item.IdNo = value Then
                    SelectedItem = DataSource(i)
                    found = True
                    Exit For
                End If
                i += 1
            Next
        End If
        If Not found Then
            SelectedIndex = -1
            returnValue = Nothing
            If value IsNot Nothing Then
                Text = value
            End If
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

End Class