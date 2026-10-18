Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms

Partial Public Class CComboBox

    Private _maxSuggestions As Integer = 100
    Private _showSuggestionCode As Boolean = True
    Private _searchByCode As Boolean = True
    Private _suggestionCodeMember As String = "Code"
    Private _searchDelayMilliseconds As Integer
    Private _suggestionMatchCount As Integer
    Private _lastUserQuery As String
    Private _processingUserTextUpdate As Boolean
    Private _pendingSuggestionQuery As String
    Private _searchCallbackQueued As Boolean
    Private _suggestionTimer As Timer
    Private ReadOnly _codeDescriptors As New Dictionary(Of Type, PropertyDescriptor)()
    Private _popupOwner As Form
    Private _popupParent As Control
    Private ReadOnly _popupScrollParents As New List(Of ScrollableControl)()

    <Category("Custom Properties"), DefaultValue(100)>
    <Description("Maximum rows displayed in the suggestion popup; zero displays all matches. Validation always uses the complete lookup.")>
    Public Property MaxSuggestions As Integer
        Get
            Return _maxSuggestions
        End Get
        Set(value As Integer)
            If value < 0 Then Throw New ArgumentOutOfRangeException(NameOf(value))
            If _maxSuggestions = value Then Return
            _maxSuggestions = value
            RefreshLookupCache()
        End Set
    End Property

    <Category("Custom Properties"), DefaultValue(True)>
    Public Property ShowSuggestionCode As Boolean
        Get
            Return _showSuggestionCode
        End Get
        Set(value As Boolean)
            If _showSuggestionCode = value Then Return
            _showSuggestionCode = value
            RefreshLookupCache()
        End Set
    End Property

    <Category("Custom Properties"), DefaultValue(True)>
    Public Property SearchByCode As Boolean
        Get
            Return _searchByCode
        End Get
        Set(value As Boolean)
            If _searchByCode = value Then Return
            _searchByCode = value
            RefreshLookupCache()
        End Set
    End Property

    <Category("Custom Properties"), DefaultValue("Code")>
    <Description("Optional source member used for code display and search. Names and stored values are unchanged.")>
    Public Property SuggestionCodeMember As String
        Get
            Return _suggestionCodeMember
        End Get
        Set(value As String)
            value = If(value, String.Empty)
            If _suggestionCodeMember = value Then Return
            _suggestionCodeMember = value
            _codeDescriptors.Clear()
            RefreshLookupCache()
        End Set
    End Property

    <Category("Custom Properties"), DefaultValue(0)>
    <Description("Optional pause before searching lists with at least 2000 items. Zero searches on the next UI message without a typing delay.")>
    Public Property SearchDelayMilliseconds As Integer
        Get
            Return _searchDelayMilliseconds
        End Get
        Set(value As Integer)
            If value < 0 Then Throw New ArgumentOutOfRangeException(NameOf(value))
            _searchDelayMilliseconds = value
            HideSuggestionBox()
        End Set
    End Property

    <Browsable(False)>
    Public ReadOnly Property SuggestionMatchCount As Integer
        Get
            Return _suggestionMatchCount
        End Get
    End Property

    Private Function GetSuggestionCode(item As Object) As String
        If item Is Nothing OrElse String.IsNullOrWhiteSpace(SuggestionCodeMember) Then Return String.Empty
        Dim row = TryCast(item, DataRowView)
        If row IsNot Nothing Then
            If Not row.DataView.Table.Columns.Contains(SuggestionCodeMember) Then Return String.Empty
            Return Convert.ToString(row(SuggestionCodeMember), CultureInfo.CurrentCulture)
        End If
        Dim itemType = item.GetType()
        Dim descriptor As PropertyDescriptor = Nothing
        If Not _codeDescriptors.TryGetValue(itemType, descriptor) Then
            descriptor = TypeDescriptor.GetProperties(item).Find(SuggestionCodeMember, True)
            _codeDescriptors(itemType) = descriptor
        End If
        If descriptor Is Nothing Then Return String.Empty
        Return Convert.ToString(descriptor.GetValue(item), CultureInfo.CurrentCulture)
    End Function

    Private Sub UpdateSuggestionStatus()
        If _suggestListForm Is Nothing OrElse _suggestListForm.IsDisposed Then Return
        _suggestListForm.SetSuggestionStatus(_suggestionMatchCount, _suggestBindingList.Count, RightToLeft = RightToLeft.Yes)
    End Sub

    Private Sub CancelSuggestionSearch()
        _pendingSuggestionQuery = Nothing
        If _suggestionTimer IsNot Nothing Then _suggestionTimer.Stop()
    End Sub

    Private Sub RequestSuggestionSearch()
        If _normalizingClear OrElse _synchronizingSelectionText OrElse Not CanEditLookup OrElse
            Not (Focused OrElse ContainsFocus) OrElse DropDownStyle = ComboBoxStyle.DropDownList Then Return
        _lookupTextEdited = True
        _lastUserQuery = Text
        HideSuggestionBox()
        If Text.Length = 0 OrElse Text.Length < SuggestCharCount Then
            ReplaceSuggestions(New List(Of LookupSuggestion)())
            Return
        End If
        If Not IsHandleCreated Then Return
        _pendingSuggestionQuery = Text
        If SearchDelayMilliseconds > 0 AndAlso Items.Count >= 2000 Then
            If _suggestionTimer Is Nothing Then
                _suggestionTimer = New Timer()
                AddHandler _suggestionTimer.Tick, AddressOf SuggestionTimerTick
            End If
            _suggestionTimer.Interval = SearchDelayMilliseconds
            _suggestionTimer.Start()
        ElseIf Not _searchCallbackQueued Then
            _searchCallbackQueued = True
            BeginInvoke(New MethodInvoker(Sub()
                                              _searchCallbackQueued = False
                                              If Not _disposingLookup AndAlso
                                                  (_suggestionTimer Is Nothing OrElse Not _suggestionTimer.Enabled) Then ProcessPendingSuggestionSearch()
                                          End Sub))
        End If
    End Sub

    Private Sub SuggestionTimerTick(sender As Object, e As EventArgs)
        ProcessPendingSuggestionSearch()
    End Sub

    Private Sub ProcessPendingSuggestionSearch()
        Dim query = _pendingSuggestionQuery
        CancelSuggestionSearch()
        If query Is Nothing OrElse _disposingLookup OrElse Not CanEditLookup OrElse
            Not (Focused OrElse ContainsFocus) OrElse DropDownStyle = ComboBoxStyle.DropDownList OrElse
            Not String.Equals(Text, query, StringComparison.Ordinal) Then Return
        Try
            Dim suggestions = FindSuggestions(query)
            ReplaceSuggestions(suggestions)
            _suggestionQuery = query
            If suggestions.Count = 0 Then
                HideSuggestionBox()
            ElseIf suggestions.Count = 1 AndAlso
                (String.Equals(suggestions(0).DisplayText, query.Trim(), StringComparison.CurrentCultureIgnoreCase) OrElse
                 (SearchByCode AndAlso String.Equals(suggestions(0).CodeText, query.Trim(), StringComparison.CurrentCultureIgnoreCase))) Then
                If CommitSuggestion(suggestions(0)) Then [Select](0, Text.Length)
            Else
                Dim popup = SuggestListForm
                AttachPopupOwner()
                PositionSuggestionPopup(popup)
                popup.Show()
            End If
        Catch
            HideSuggestionBox()
            Throw
        End Try
    End Sub

    Private Sub RepositionSuggestionPopup()
        If _suggestListForm Is Nothing OrElse Not _suggestListForm.Visible Then Return
        PositionSuggestionPopup(_suggestListForm)
    End Sub

    Private Sub PositionSuggestionPopup(popup As CListBoxForm)
        If Not IsHandleCreated Then Return
        popup.StartPosition = FormStartPosition.Manual
        popup.RightToLeft = RightToLeft
        popup.RightToLeftLayout = RightToLeft = RightToLeft.Yes
        popup.SuggestListBox.RightToLeft = RightToLeft
        UpdateSuggestionStatus()
        Dim scale = DeviceDpi / 96.0
        Dim desiredWidth = If(_suggestionMatchCount > _suggestBindingList.Count, Math.Max(Width, CInt(300 * scale)), Width)
        For Each item In _suggestBindingList
            desiredWidth = Math.Max(desiredWidth, TextRenderer.MeasureText(item.SuggestionText, popup.SuggestListBox.Font).Width + SystemInformation.VerticalScrollBarWidth + CInt(16 * scale))
        Next
        desiredWidth = Math.Max(Width, Math.Min(desiredWidth, CInt(600 * scale)))
        Dim anchor = RectangleToScreen(ClientRectangle)
        popup.Bounds = CalculateSuggestionBounds(anchor, Screen.FromControl(Me).WorkingArea,
                                                New Size(desiredWidth, Math.Max(1, CInt(SuggestBoxHeight * scale))), RightToLeft = RightToLeft.Yes)
        UpdateSuggestionStatus()
    End Sub

    Private Shared Function CalculateSuggestionBounds(anchor As Rectangle, workArea As Rectangle, preferred As Size, rtl As Boolean) As Rectangle
        Dim width = Math.Max(1, Math.Min(preferred.Width, workArea.Width))
        Dim height = Math.Max(1, Math.Min(preferred.Height, workArea.Height))
        Dim below = Math.Max(0, workArea.Bottom - anchor.Bottom)
        Dim above = Math.Max(0, anchor.Top - workArea.Top)
        Dim useBelow = below >= height OrElse below >= above
        Dim available = If(useBelow, below, above)
        If available > 0 Then height = Math.Min(height, available)
        Dim x = If(rtl, anchor.Right - width, anchor.Left)
        x = Math.Max(workArea.Left, Math.Min(x, workArea.Right - width))
        Dim y = If(useBelow, anchor.Bottom, anchor.Top - height)
        y = Math.Max(workArea.Top, Math.Min(y, workArea.Bottom - height))
        Return New Rectangle(x, y, width, height)
    End Function

    Private Sub AttachPopupOwner()
        Dim owner = FindForm()
        If owner Is _popupOwner AndAlso Parent Is _popupParent Then Return
        DetachPopupOwner()
        _popupOwner = owner
        _popupParent = Parent
        If owner IsNot Nothing Then
            _suggestListForm.Owner = owner
            AddHandler owner.LocationChanged, AddressOf PopupOwnerLayoutChanged
            AddHandler owner.SizeChanged, AddressOf PopupOwnerLayoutChanged
            AddHandler owner.Deactivate, AddressOf PopupOwnerDeactivated
        End If
        Dim parentControl = Parent
        While parentControl IsNot Nothing
            Dim scrollParent = TryCast(parentControl, ScrollableControl)
            If scrollParent IsNot Nothing Then
                _popupScrollParents.Add(scrollParent)
                AddHandler scrollParent.Scroll, AddressOf PopupParentScrolled
            End If
            parentControl = parentControl.Parent
        End While
    End Sub

    Private Sub DetachPopupOwner()
        _popupParent = Nothing
        If _popupOwner IsNot Nothing Then
            RemoveHandler _popupOwner.LocationChanged, AddressOf PopupOwnerLayoutChanged
            RemoveHandler _popupOwner.SizeChanged, AddressOf PopupOwnerLayoutChanged
            RemoveHandler _popupOwner.Deactivate, AddressOf PopupOwnerDeactivated
            _popupOwner = Nothing
        End If
        If _popupScrollParents Is Nothing Then Return
        For Each scrollingParent In _popupScrollParents
            RemoveHandler scrollingParent.Scroll, AddressOf PopupParentScrolled
        Next
        _popupScrollParents.Clear()
    End Sub

    Private Sub PopupOwnerLayoutChanged(sender As Object, e As EventArgs)
        RepositionSuggestionPopup()
    End Sub

    Private Sub PopupParentScrolled(sender As Object, e As ScrollEventArgs)
        HideSuggestionBox()
    End Sub

    Private Sub PopupOwnerDeactivated(sender As Object, e As EventArgs)
        HideSuggestionBox()
    End Sub

    Protected Overrides Sub OnSizeChanged(e As EventArgs)
        MyBase.OnSizeChanged(e)
        RepositionSuggestionPopup()
    End Sub

    Protected Overrides Sub OnRightToLeftChanged(e As EventArgs)
        MyBase.OnRightToLeftChanged(e)
        If _suggestListForm IsNot Nothing Then PositionSuggestionPopup(_suggestListForm)
    End Sub

    Protected Overrides Sub OnFontChanged(e As EventArgs)
        MyBase.OnFontChanged(e)
        If _suggestListForm Is Nothing Then Return
        Dim oldFont = _suggestionFont
        _suggestionFont = DirectCast(Font.Clone(), Font)
        _suggestListForm.Font = _suggestionFont
        _suggestListForm.SuggestListBox.Font = _suggestionFont
        If oldFont IsNot Nothing Then oldFont.Dispose()
        RepositionSuggestionPopup()
    End Sub

    Protected Overrides Sub OnDpiChangedAfterParent(e As EventArgs)
        MyBase.OnDpiChangedAfterParent(e)
        RepositionSuggestionPopup()
    End Sub

End Class
