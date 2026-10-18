Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Partial Public Class CComboBox

    Private _suggestListForm As CListBoxForm
    Private _suggestionFont As Font
    Private _suggestBoxHeight As Integer = 200
    Private _lookupStartItem As Object
    Private _lookupStartValue As Object
    Private _lookupStartText As String
    Private _hasLookupStart As Boolean
    Private _lookupTextEdited As Boolean
    Private _suggestionQuery As String

    ' Keep the protected accessor for derived controls, but normal initialization,
    ' binding, layout, hiding and disposal must never call it just to check state.
    Protected ReadOnly Property SuggestListForm As CListBoxForm
        Get
            If _suggestListForm Is Nothing Then
                If _disposingLookup OrElse IsDisposed Then Throw New ObjectDisposedException(NameOf(CComboBox))
                Dim popup As New CListBoxForm()
                Try
                    popup.Height = _suggestBoxHeight
                    popup.AutoScaleMode = AutoScaleMode.None
                    _suggestionFont = DirectCast(Font.Clone(), Font)
                    popup.Font = _suggestionFont
                    popup.SuggestListBox.Font = _suggestionFont
                    popup.SuggestListBox.ForeColor = Color.Green
                    popup.SuggestListBox.BackColor = Color.White
                    popup.SuggestListBox.DataSource = _suggestBindingList
                    AddHandler popup.SuggestListBox.Click, AddressOf SuggestListBoxOnClick
                    _suggestListForm = popup
                    UpdateSuggestionStatus()
                Catch
                    popup.Dispose()
                    If _suggestionFont IsNot Nothing Then _suggestionFont.Dispose()
                    _suggestionFont = Nothing
                    Throw
                End Try
            End If
            Return _suggestListForm
        End Get
    End Property

    Protected ReadOnly Property SuggestionVisible As Boolean
        Get
            Return _suggestListForm IsNot Nothing AndAlso _suggestListForm.Visible
        End Get
    End Property

    Private ReadOnly Property SuggestionHasFocus As Boolean
        Get
            Return _suggestListForm IsNot Nothing AndAlso _suggestListForm.ContainsFocus
        End Get
    End Property

    Private ReadOnly Property CanEditLookup As Boolean
        Get
            Return EditingMode AndAlso Editable AndAlso Not DisplayOnly
        End Get
    End Property

    Protected ReadOnly Property HasPendingLookupEdit As Boolean
        Get
            Return _lookupTextEdited OrElse SuggestionVisible OrElse
                (_hasLookupStart AndAlso Not String.Equals(Text, _lookupStartText, StringComparison.Ordinal))
        End Get
    End Property

    Protected Sub BeginLookupEdit()
        _lookupStartItem = SelectedItem
        _lookupStartValue = SelectedValue
        _lookupStartText = Text
        _hasLookupStart = True
        _lookupTextEdited = False
    End Sub

    Protected Sub InitializeLookupSelection(value As Object)
        If DataSource Is Nothing OrElse String.IsNullOrEmpty(ValueMember) OrElse
            value Is Nothing OrElse value Is DBNull.Value Then Return
        Dim synchronizing = _synchronizingSelectionText
        _synchronizingSelectionText = True
        Try
            SelectedValue = value
            If SelectedIndex >= 0 Then SynchronizeSelectionText(GetItemText(SelectedItem))
        Finally
            _synchronizingSelectionText = synchronizing
        End Try
    End Sub

    Private Sub RestoreLookupSelection()
        HideSuggestionBox()
        If Not _hasLookupStart Then Return
        Dim synchronizing = _synchronizingSelectionText
        _synchronizingSelectionText = True
        Try
            Dim index = -1
            If _lookupStartItem IsNot Nothing Then
                For itemIndex As Integer = 0 To Items.Count - 1
                    If SameLookupItem(Items(itemIndex), _lookupStartItem) Then
                        index = itemIndex
                        Exit For
                    End If
                Next
            End If
            If index >= 0 Then
                SelectedIndex = index
                SynchronizeSelectionText(GetItemText(Items(index)))
            ElseIf _lookupStartItem IsNot Nothing AndAlso DataSource IsNot Nothing AndAlso _lookupStartValue IsNot Nothing Then
                ' A refreshed source may contain new row objects for the same ID.
                SelectedValue = _lookupStartValue
                If Object.Equals(SelectedValue, _lookupStartValue) Then
                    SynchronizeSelectionText(GetItemText(SelectedItem))
                Else
                    ClearSelectionForValidation()
                End If
            Else
                ClearSelectionForValidation()
                If _lookupStartItem Is Nothing Then SynchronizeSelectionText(_lookupStartText)
            End If
        Finally
            _synchronizingSelectionText = synchronizing
            _lookupTextEdited = False
        End Try
    End Sub

    Private Function TryAcceptLookupText(preferPopup As Boolean) As Boolean
        If preferPopup AndAlso SuggestionVisible AndAlso String.Equals(_suggestionQuery, Text, StringComparison.Ordinal) Then
            Return CommitSuggestion(TryCast(_suggestListForm.SuggestListBox.SelectedItem, LookupSuggestion))
        End If
        If String.IsNullOrWhiteSpace(Text) Then
            ClearSelectionForValidation()
            Return True
        End If
        If SelectExactTextMatch() Then Return True
        If SearchByCode AndAlso FilterRule Is Nothing Then
            Dim codeMatches = EnsureLookupCache().Where(Function(item) item.CodeText.Length > 0 AndAlso
                                                           String.Equals(item.CodeText, Text.Trim(), StringComparison.CurrentCultureIgnoreCase)).ToList()
            If codeMatches.Count = 1 Then Return CommitSuggestion(codeMatches(0))
            If codeMatches.Count > 1 Then Return False
        End If
        Dim suggestions = FindSuggestions(Text)
        If suggestions.Count = 1 Then Return CommitSuggestion(suggestions(0))
        ' Keep invalid/ambiguous input available for correction. In particular,
        ' never send synthetic Backspace keys into a paste or an IME composition.
        HideSuggestionBox()
        Return False
    End Function

    Private Function AcceptLookupInput(preferPopup As Boolean) As Boolean
        If Not TryAcceptLookupText(preferPopup) Then Return False
        BeginLookupEdit()
        Return True
    End Function

    Friend Function TryCommitLookupInput() As Boolean
        Return Not CanEditLookup OrElse AcceptLookupInput(True)
    End Function

    Protected Function LookupWantsInputKey(keyData As Keys, dataGridViewWantsInputKey As Boolean) As Boolean
        Select Case keyData And Keys.KeyCode
            Case Keys.Down, Keys.Up
                Return True
            Case Keys.Enter
                Return SuggestionVisible OrElse DroppedDown OrElse Not dataGridViewWantsInputKey
            Case Keys.Escape
                Return HasPendingLookupEdit OrElse DroppedDown OrElse Not dataGridViewWantsInputKey
        End Select
        Return Not dataGridViewWantsInputKey
    End Function

    Private Function HandleLookupKey(keyData As Keys) As Boolean
        If Not CanEditLookup OrElse (keyData And (Keys.Control Or Keys.Alt)) <> Keys.None Then Return False
        Dim key = keyData And Keys.KeyCode
        If key = Keys.Enter OrElse key = Keys.Up OrElse key = Keys.Down Then ProcessPendingSuggestionSearch()
        ' Let the native dropdown handle its own selection and cancellation.
        If DroppedDown Then Return False
        Select Case key
            Case Keys.Down, Keys.Up
                If Not SuggestionVisible Then Return False
                If _suggestBindingList.Count = 0 Then
                    HideSuggestionBox()
                    Return True
                End If
                Dim listBox = _suggestListForm.SuggestListBox
                Dim offset = If(key = Keys.Down, 1, -1)
                listBox.SelectedIndex = Math.Max(0, Math.Min(_suggestBindingList.Count - 1, listBox.SelectedIndex + offset))
                Return True
            Case Keys.Enter
                Dim popupWasVisible = SuggestionVisible
                ' Without a popup the grid owns Enter and its cell navigation.
                If Not popupWasVisible AndAlso TypeOf Me Is IDataGridViewEditingControl Then Return False
                If AcceptLookupInput(popupWasVisible) AndAlso Not popupWasVisible Then
                    Dim form = FindForm()
                    If form IsNot Nothing Then form.SelectNextControl(Me, True, True, True, True)
                End If
                Return True
            Case Keys.Escape
                If Not HasPendingLookupEdit Then Return False
                RestoreLookupSelection()
                Return True
        End Select
        Return False
    End Function

    Protected Overrides Function ProcessDialogKey(keyData As Keys) As Boolean
        If CanEditLookup AndAlso (keyData And Keys.KeyCode) = Keys.Tab AndAlso
            (keyData And (Keys.Control Or Keys.Alt)) = Keys.None Then
            ProcessPendingSuggestionSearch()
            If Not AcceptLookupInput(True) Then Return True
        End If
        Return MyBase.ProcessDialogKey(keyData)
    End Function

    Protected Overrides Sub OnValidated(e As EventArgs)
        BeginLookupEdit()
        MyBase.OnValidated(e)
    End Sub

    Protected Overrides Sub OnSelectionChangeCommitted(e As EventArgs)
        MyBase.OnSelectionChangeCommitted(e)
        BeginLookupEdit()
    End Sub

End Class
