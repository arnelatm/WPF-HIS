Imports System.ComponentModel
Imports System.Drawing
Imports System.Linq.Expressions
Imports System.Threading
Imports System.Windows.Forms

Public Class CbsComboBox
    Inherits ComboBox

    Private ReadOnly _suggestListBox As ListBox = New ListBox With {
        .Visible = False,
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

        _suggestListBox.DataSource = _suggestBindingList
        AddHandler _suggestListBox.Click, AddressOf SuggestListBoxOnClick
        AddHandler ParentChanged, AddressOf OnParentChanged

    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        MyBase.OnTextChanged(e)
        If Not Focused Then Return
        _suggestBindingList.Clear()
        _suggestBindingList.RaiseListChangedEvents = False
        PropertySelectorCompiled(Items).Where(_filterRuleCompiled).OrderBy(_suggestListOrderRuleCompiled).ToList().ForEach(AddressOf _suggestBindingList.Add)
        _suggestBindingList.RaiseListChangedEvents = True
        _suggestBindingList.ResetBindings()
        _suggestListBox.Visible = _suggestBindingList.Any()

        If _suggestBindingList.Count = 1 AndAlso _suggestBindingList.Single().Length = Text.Trim().Length Then
            Text = _suggestBindingList.Single()
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

    Protected Overloads Overrides Sub OnLostFocus(e As EventArgs)
        If Not _suggestListBox.Focused Then
            HideSuggBox()
        End If
        MyBase.OnLostFocus(e)
    End Sub

    Private Sub SuggestListBoxOnClick()
        Text = _suggestListBox.Text
        Focus()
    End Sub

    Private Sub HideSuggBox()
        _suggestListBox.Visible = False
    End Sub

    Protected Overloads Overrides Sub OnDropDown(e As EventArgs)
        HideSuggBox()
        MyBase.OnDropDown(e)
    End Sub

    Protected Overloads Overrides Sub OnPreviewKeyDown(e As PreviewKeyDownEventArgs)
        If Not _suggestListBox.Visible Then
            MyBase.OnPreviewKeyDown(e)
            Return
        End If
        Select Case e.KeyCode
            Case Keys.Down
                If _suggestListBox.SelectedIndex < _suggestBindingList.Count - 1 Then
                    Math.Max(Interlocked.Increment(_suggestListBox.SelectedIndex), _suggestListBox.SelectedIndex - 1)
                End If
                Return
            Case Keys.Up
                If _suggestListBox.SelectedIndex > 0 Then
                    Math.Max(Interlocked.Decrement(_suggestListBox.SelectedIndex), _suggestListBox.SelectedIndex + 1)
                End If
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

    Protected Overloads Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If _suggestListBox.Visible AndAlso KeysToHandle.Contains(keyData) Then
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
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