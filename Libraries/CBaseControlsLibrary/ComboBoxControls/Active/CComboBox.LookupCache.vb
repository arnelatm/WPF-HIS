Imports System.Collections
Imports System.ComponentModel
Imports System.Globalization
Imports System.Windows.Forms

Partial Public Class CComboBox

    ' Keep the source row and index: display names are not unique identifiers.
    Private NotInheritable Class LookupSuggestion
        Public ReadOnly SourceItem As Object
        Public ReadOnly SourceIndex As Integer
        Public ReadOnly DisplayText As String
        Public ReadOnly SearchText As String
        Public ReadOnly SortKey As String
        Public ReadOnly Generation As Integer
        Public ReadOnly CodeText As String
        Public ReadOnly SearchCode As String
        Public ReadOnly SuggestionText As String

        Public Sub New(item As Object, index As Integer, text As String, sortKey As String, generation As Integer, code As String, showCode As Boolean)
            SourceItem = item
            SourceIndex = index
            DisplayText = If(text, String.Empty)
            SearchText = DisplayText.ToLower(CultureInfo.CurrentCulture)
            Me.SortKey = sortKey
            Me.Generation = generation
            CodeText = If(code, String.Empty).Trim()
            SearchCode = CodeText.ToLower(CultureInfo.CurrentCulture)
            SuggestionText = DisplayText
            If showCode AndAlso CodeText.Length > 0 AndAlso
                Not DisplayText.Split("|"c).Any(Function(part) String.Equals(part.Trim(), CodeText, StringComparison.CurrentCultureIgnoreCase)) AndAlso
                Not DisplayText.StartsWith(CodeText & " ", StringComparison.CurrentCultureIgnoreCase) Then
                SuggestionText = CodeText & " — " & DisplayText
            End If
        End Sub

        Public Overrides Function ToString() As String
            Return SuggestionText
        End Function
    End Class

    Private _lookupRows As List(Of LookupSuggestion)
    Private _sortedLookupRows As List(Of LookupSuggestion)
    Private _lookupGeneration As Integer
    Private _observedLookupList As IBindingList
    Private _lookupCulture As String
    Private _lookupFormatting As String
    Private _lookupFormatProvider As IFormatProvider
    Private _lookupSelector As Func(Of ObjectCollection, IEnumerable(Of String))
    Private _lookupSort As Func(Of String, String)
    Private _disposingLookup As Boolean

    ''' <summary>
    ''' Invalidates cached lookup text and suggestions. Call on the UI thread after
    ''' changing external state used by Format, PropertySelector or a custom sort rule.
    ''' Bound IBindingList changes are observed automatically; other lists are checked
    ''' on each search, including replacements that do not change the item count.
    ''' </summary>
    Public Sub RefreshLookupCache()
        _lookupGeneration += 1
        _lookupRows = Nothing
        _sortedLookupRows = Nothing
        If _codeDescriptors IsNot Nothing Then _codeDescriptors.Clear()
        If _suggestBindingList Is Nothing OrElse _disposingLookup Then Return
        HideSuggestionBox()
        ReplaceSuggestions(New List(Of LookupSuggestion)())
    End Sub

    Private Sub ConfigureLookupProjection()
        If _propertySelector IsNot Nothing Then
            PropertySelectorCompiled = _propertySelector.Compile()
            Return
        End If

        ' Preserve the legacy second-column fallback for direct DataTable sources.
        Dim data = TryCast(DataSource, DataTable)
        Dim view = TryCast(DataSource, DataView)
        If data Is Nothing AndAlso view IsNot Nothing Then data = view.Table
        If data IsNot Nothing AndAlso data.Columns.Count > 0 AndAlso
            (String.IsNullOrWhiteSpace(DisplayMember) OrElse Not data.Columns.Contains(DisplayMember)) Then
            Dim columnName = data.Columns(Math.Min(1, data.Columns.Count - 1)).ColumnName
            PropertySelectorCompiled = Function(collection) collection.Cast(Of DataRowView)().Select(Function(row) Convert.ToString(row(columnName)))
        Else
            PropertySelectorCompiled = Function(collection) collection.Cast(Of Object)().Select(Function(item) GetItemText(item))
        End If
    End Sub

    Private Sub ObserveLookupList()
        If _disposingLookup Then Return
        Dim list As IBindingList = Nothing
        If DataManager IsNot Nothing Then list = TryCast(DataManager.List, IBindingList)
        If list Is Nothing Then list = TryCast(DataSource, IBindingList)
        If list Is Nothing Then
            Dim source = TryCast(DataSource, IListSource)
            If source IsNot Nothing Then list = TryCast(source.GetList(), IBindingList)
        End If
        If list IsNot Nothing AndAlso Not list.SupportsChangeNotification Then list = Nothing
        If Object.ReferenceEquals(list, _observedLookupList) Then Return
        If _observedLookupList IsNot Nothing Then RemoveHandler _observedLookupList.ListChanged, AddressOf LookupListChanged
        _observedLookupList = list
        If list IsNot Nothing Then AddHandler list.ListChanged, AddressOf LookupListChanged
        RefreshLookupCache()
    End Sub

    Private Sub LookupListChanged(sender As Object, e As ListChangedEventArgs)
        If _disposingLookup OrElse IsDisposed Then Return
        ' Lookup sources, like all WinForms binding sources, must be changed on
        ' the UI thread. Do not access the popup from a worker notification.
        If IsHandleCreated AndAlso InvokeRequired Then
            BeginInvoke(New MethodInvoker(AddressOf RefreshLookupCache))
        Else
            RefreshLookupCache()
        End If
    End Sub

    Private Shared Function SameLookupItem(left As Object, right As Object) As Boolean
        If Object.ReferenceEquals(left, right) Then Return True
        Return left IsNot Nothing AndAlso left.GetType().IsValueType AndAlso left.Equals(right)
    End Function

    Private Function EnsureLookupCache() As List(Of LookupSuggestion)
        ObserveLookupList()
        Dim culture = CultureInfo.CurrentCulture.Name & "|" & CultureInfo.CurrentUICulture.Name
        Dim formatting = DisplayMember & "|" & ValueMember & "|" & FormattingEnabled.ToString() & "|" & FormatString
        If _lookupRows IsNot Nothing AndAlso
            (culture <> _lookupCulture OrElse formatting <> _lookupFormatting OrElse
             Not Object.ReferenceEquals(FormatInfo, _lookupFormatProvider) OrElse
             Not Object.ReferenceEquals(PropertySelectorCompiled, _lookupSelector) OrElse
             Not Object.ReferenceEquals(_suggestListOrderRuleCompiled, _lookupSort) OrElse
             _lookupRows.Count <> Items.Count) Then
            RefreshLookupCache()
        End If

        Dim sourceItems As Object() = Nothing
        Dim displayTexts As String() = Nothing
        Dim codes As String() = Nothing
        Dim itemNotifications = TryCast(_observedLookupList, IRaiseItemChangedEvents)
        If _lookupRows Is Nothing OrElse _observedLookupList Is Nothing OrElse
            (itemNotifications IsNot Nothing AndAlso Not itemNotifications.RaisesItemChangedEvents) Then
            Dim projectionGeneration = _lookupGeneration
            sourceItems = Items.Cast(Of Object)().ToArray()
            displayTexts = PropertySelectorCompiled(Items).Select(Function(text) If(text, String.Empty)).ToArray()
            codes = sourceItems.Select(AddressOf GetSuggestionCode).ToArray()
            If projectionGeneration <> _lookupGeneration Then Return New List(Of LookupSuggestion)()
            If displayTexts.Length <> sourceItems.Length Then
                Throw New InvalidOperationException("PropertySelector must return one display string per ComboBox item in source order.")
            End If
            If _lookupRows IsNot Nothing Then
                For index As Integer = 0 To sourceItems.Length - 1
                    If Not SameLookupItem(sourceItems(index), _lookupRows(index).SourceItem) OrElse
                        displayTexts(index) <> _lookupRows(index).DisplayText OrElse codes(index).Trim() <> _lookupRows(index).CodeText Then
                        RefreshLookupCache()
                        Exit For
                    End If
                Next
            End If
        End If

        If _lookupRows Is Nothing Then
            Dim generation = _lookupGeneration
            Dim rows As New List(Of LookupSuggestion)(sourceItems.Length)
            For index As Integer = 0 To sourceItems.Length - 1
                rows.Add(New LookupSuggestion(sourceItems(index), index, displayTexts(index), _suggestListOrderRuleCompiled(displayTexts(index)), generation, codes(index), ShowSuggestionCode))
            Next
            Dim sorted = rows.OrderBy(Function(item) item.SortKey, StringComparer.CurrentCulture).ToList()
            ' Formatting and custom projection callbacks can rebind the control.
            If generation <> _lookupGeneration OrElse Items.Count <> sourceItems.Length Then Return New List(Of LookupSuggestion)()
            For index As Integer = 0 To sourceItems.Length - 1
                If Not SameLookupItem(sourceItems(index), Items(index)) Then Return New List(Of LookupSuggestion)()
            Next
            _lookupCulture = culture
            _lookupFormatting = formatting
            _lookupFormatProvider = FormatInfo
            _lookupSelector = PropertySelectorCompiled
            _lookupSort = _suggestListOrderRuleCompiled
            _lookupRows = rows
            _sortedLookupRows = sorted
        End If
        Return _sortedLookupRows
    End Function

    Private Function FindSuggestions(query As String) As List(Of LookupSuggestion)
        Dim rows = EnsureLookupCache()
        Dim generation = _lookupGeneration
        Dim filter = _filterRuleCompiled
        Dim normalizedQuery = query.Trim().ToLower(CultureInfo.CurrentCulture)
        Dim result As New List(Of LookupSuggestion)()
        Dim exactCodes As New List(Of LookupSuggestion)()
        For Each item In rows
            Dim matches = If(filter Is Nothing,
                             item.SearchText.Contains(normalizedQuery) OrElse (SearchByCode AndAlso item.SearchCode.Contains(normalizedQuery)),
                             filter(item.DisplayText, query))
            If Not matches Then Continue For
            If filter Is Nothing AndAlso SearchByCode AndAlso item.SearchCode.Length > 0 AndAlso item.SearchCode = normalizedQuery Then
                exactCodes.Add(item)
            Else
                result.Add(item)
            End If
        Next
        If generation <> _lookupGeneration Then Return New List(Of LookupSuggestion)()
        If exactCodes.Count > 0 Then
            exactCodes.AddRange(result)
            Return exactCodes
        End If
        Return result
    End Function

    Private Sub ReplaceSuggestions(items As IList(Of LookupSuggestion))
        _suggestionMatchCount = items.Count
        If MaxSuggestions > 0 AndAlso items.Count > MaxSuggestions Then items = items.Take(MaxSuggestions).ToList()
        If items.Count = _suggestBindingList.Count AndAlso
            items.Where(Function(item, index) Not Object.ReferenceEquals(item, _suggestBindingList(index))).Any() = False Then
            UpdateSuggestionStatus()
            Return
        End If

        Dim listBox = If(_suggestListForm Is Nothing, Nothing, _suggestListForm.SuggestListBox)
        Dim raiseEvents = _suggestBindingList.RaiseListChangedEvents
        If listBox IsNot Nothing Then listBox.BeginUpdate()
        _suggestBindingList.RaiseListChangedEvents = False
        Try
            _suggestBindingList.Clear()
            For Each item In items
                _suggestBindingList.Add(item)
            Next
        Finally
            _suggestBindingList.RaiseListChangedEvents = raiseEvents
            Try
                If raiseEvents Then _suggestBindingList.ResetBindings()
            Finally
                If listBox IsNot Nothing Then listBox.EndUpdate()
            End Try
        End Try
        UpdateSuggestionStatus()
    End Sub

    Private Function CommitSuggestion(item As LookupSuggestion) As Boolean
        If item Is Nothing Then Return False
        EnsureLookupCache()
        If item.Generation <> _lookupGeneration OrElse item.SourceIndex >= Items.Count OrElse
            Not SameLookupItem(item.SourceItem, Items(item.SourceIndex)) Then
            HideSuggestionBox()
            Return False
        End If

        Dim synchronizing = _synchronizingSelectionText
        _synchronizingSelectionText = True
        Try
            SelectedIndex = item.SourceIndex
            ' A selection handler may have rebound the source.
            If item.Generation <> _lookupGeneration OrElse SelectedIndex <> item.SourceIndex Then Return False
            SynchronizeSelectionText(item.DisplayText)
            HideSuggestionBox()
            Return SelectedIndex = item.SourceIndex
        Finally
            _synchronizingSelectionText = synchronizing
        End Try
    End Function

    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso Not _disposingLookup Then
            _disposingLookup = True
            If _observedLookupList IsNot Nothing Then RemoveHandler _observedLookupList.ListChanged, AddressOf LookupListChanged
            _observedLookupList = Nothing
            _lookupRows = Nothing
            _sortedLookupRows = Nothing
            If _suggestListForm IsNot Nothing Then _suggestListForm.Dispose()
            If _suggestionFont IsNot Nothing Then _suggestionFont.Dispose()
            If _suggestionTimer IsNot Nothing Then _suggestionTimer.Dispose()
            DetachPopupOwner()
            If _contextMenuStrip1 IsNot Nothing Then _contextMenuStrip1.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

End Class
