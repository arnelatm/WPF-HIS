Imports System.ComponentModel
Imports System.Globalization
Imports System.Reflection
Imports System.Windows.Forms
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.Messaging
Imports AATM.Presentation.Events
Imports AATM.Presentation.Forms.Services.Lookup
Imports AATM.Presentation.Forms.Services.Security
Imports AATM.Presentation.Forms.Services.SystemView
Imports AATM.Presentation.Forms.Services.Translation
Imports AATM.Presentation.Forms.Services.Ui

' Encapsulates non-visual orchestration so BfMain focuses on presentation.
Friend Class BfMainServices

    Private ReadOnly _form As BfMain
    Private ReadOnly _ea As EventAggregator

    Private _systemViewProvider As SystemViewIdProvider
    Private _translationCoordinator As TranslationCoordinator
    Private _securityApplier As SecurityApplier
    Private _gridCoordinator As DataGridCoordinator
    Private _lookupDispatcher As LookupDispatcher

    Private _initialized As Boolean
    Private ReadOnly _ltrCulture As String = GlobalVariables.DefaultUnmirroredCultureInfoStr
    Private ReadOnly _rtlCulture As String = GlobalVariables.DefaultMirroredCultureInfoStr

    Public Sub New(form As BfMain, ea As EventAggregator)
        _form = form
        _ea = ea
    End Sub

#Region "Accessors"
    Public ReadOnly Property TranslationCoordinator As TranslationCoordinator
        Get
            Return _translationCoordinator
        End Get
    End Property

    Public ReadOnly Property GridCoordinator As DataGridCoordinator
        Get
            Return _gridCoordinator
        End Get
    End Property

    Public ReadOnly Property SystemViewId As Short
        Get
            Dim id As Integer = If(_systemViewProvider Is Nothing, 0, _systemViewProvider.GetId())
            Return CShort(Math.Min(Short.MaxValue, Math.Max(Short.MinValue, id)))
        End Get
    End Property
#End Region

#Region "Initialization"
    Public Sub EnsureInitialized(Optional force As Boolean = False)
        If LicenseManager.UsageMode = LicenseUsageMode.Designtime Then Return
        If _initialized AndAlso Not force Then Return

        If _systemViewProvider Is Nothing OrElse force Then
            _systemViewProvider = New SystemViewIdProvider(_form.TranslatorDAC,
                Function() If(String.IsNullOrEmpty(_form.ViewDisplayName), _form.Name, _form.ViewDisplayName))
        End If

        If _translationCoordinator Is Nothing OrElse force Then
            _translationCoordinator = New TranslationCoordinator(_form,
                                                                 _ea,
                                                                 _systemViewProvider,
                                                                 _ltrCulture,
                                                                 _rtlCulture)
            _translationCoordinator.Initialize(_form.TranslatorDAC)
        End If

        If _securityApplier Is Nothing OrElse force Then
            _securityApplier = New SecurityApplier(
                isSuperAdmin:=Function() UserIsASuperAdmin(),
                isLoggedIn:=Function() GlobalVariables.IsUserLoggedIn,
                securityGroupId:=Function() GlobalVariables.SecurityGroupIdNo,
                getSecurityId:=Function(key, isMenu) ResolveSecurityId(key, isMenu),
                getUserSecurity:=Function(secId, grp) ResolveUserSecurity(secId, grp))
        End If

        If _gridCoordinator Is Nothing OrElse force Then
            _gridCoordinator = New DataGridCoordinator(_form)
        End If

        If _lookupDispatcher Is Nothing OrElse force Then
            _lookupDispatcher = New LookupDispatcher(_ea, _form)
        End If

        _initialized = True
    End Sub
#End Region

#Region "Translation"
    Public Sub InvalidateTranslationCache()
        _translationCoordinator?.Invalidate()
    End Sub

    Public Sub SwitchUiLanguage(originalUi As Boolean, adjustButtons As Action)
        EnsureInitialized()
        UiPerformanceHelper.WithRedrawSuspended(_form,
            Sub()
                _translationCoordinator?.SwitchUiLanguage(originalUi,
                    adjustButtons:=Sub() adjustButtons?.Invoke())
            End Sub)
    End Sub

    Public Sub TranslateCurrent(Optional allowFallback As Boolean = True)
        EnsureInitialized()
        _translationCoordinator?.TranslateCurrent(allowFallback)
    End Sub

    Public Sub FlickerFreeTranslateForm()
        If LicenseManager.UsageMode = LicenseUsageMode.Designtime Then Return
        EnsureInitialized()
        UiPerformanceHelper.WithRedrawSuspended(_form,
            Sub() _translationCoordinator?.TranslateCurrent())
        If GlobalVariables.TranslationMode Then _form.RaiseAfterTranslateForm()
    End Sub
#End Region


#Region "Captions / SystemView"
    Public Sub GetNSaveCaptions()
        EnableDoubleBuffer(_form)
        If Not GlobalVariables.TranslationMode Then Return

        ' Capture captions for translation DB (ignore old in-form collections).
        'Dim _ = StoreCaptions1.StoreTranslation(_form)
        StoreCaptions1.SaveControlsOriginalText(_form)

        ' Optionally set ViewDisplayName if the property still exists and is empty.
        Try
            Dim pi = _form.GetType().GetProperty("ViewDisplayName", BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.NonPublic)
            If pi IsNot Nothing AndAlso pi.CanRead AndAlso pi.CanWrite Then
                Dim current = TryCast(pi.GetValue(_form, Nothing), String)
                If String.IsNullOrWhiteSpace(current) Then
                    pi.SetValue(_form, _form.Name, Nothing)
                End If
            End If
        Catch
            ' Non-critical – swallow
        End Try
    End Sub
#End Region

    '#Region "Captions / SystemView"
    '    Public Sub GetNSaveCaptions()
    '        _form.SetFormDoubleBuffered(True)
    '        If GlobalVariables.TranslationMode Then
    '            _form.CaptionCollection = StoreCaptions1.StoreTranslation(_form)
    '            StoreCaptions1.SaveControlsOriginalText(_form)
    '            _form.DefaultMirroredLanguageIdNo = _form.TranslatorDAC.DefaultMirroredLanguageIdNo
    '            If String.IsNullOrEmpty(_form.ViewDisplayName) Then _form.ViewDisplayName = _form.Name
    '        End If
    '    End Sub

    '#End Region

#Region "Security"
    Public Sub ApplySecurity(control As Control)
        If _securityApplier Is Nothing Then Return
        If TypeOf control Is MenuStrip Then
            _securityApplier.ApplyMenuStrip(DirectCast(control, MenuStrip), _form.MenuFormName)
        ElseIf TypeOf control Is ToolStrip Then
            _securityApplier.ApplyToolStrip(DirectCast(control, ToolStrip), _form.MenuFormName)
        Else
            Dim key = ResolveControlSecurityKey(control)
            If Not String.IsNullOrWhiteSpace(key) Then
                _securityApplier.ApplyControl(control, key)
            End If
        End If
    End Sub

    ' Replaces removed BfMain.GetControlSecurityKey
    Private Function ResolveControlSecurityKey(ctrl As Control) As String
        Try
            If ctrl Is Nothing Then Return String.Empty
            Dim pi = ctrl.GetType().GetProperty("SecurityKey", BindingFlags.Instance Or BindingFlags.Public)
            If pi Is Nothing Then Return String.Empty
            Dim val = TryCast(pi.GetValue(ctrl, Nothing), String)
            Return If(val, "").Trim()
        Catch
            Return String.Empty
        End Try
    End Function

    ' Safely obtain form-level menu name (fallback to form.Name if property absent)
    Private Function ResolveMenuFormName() As String
        Try
            Dim pi = _form.GetType().GetProperty("MenuFormName", BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.NonPublic)
            If pi IsNot Nothing Then
                Dim val = TryCast(pi.GetValue(_form, Nothing), String)
                If Not String.IsNullOrWhiteSpace(val) Then Return val
            End If
        Catch
        End Try
        Return _form.Name
    End Function

#End Region

#Region "Grid / Focus Helpers"
    Public Sub EndAllGridEdits()
        _gridCoordinator?.EndAllEdits()
    End Sub

    Public Sub InvalidateControlCaches()
        _gridCoordinator?.Invalidate()
    End Sub

    Public Sub ProcessCellEndEdit(dataGridView As DataGridView, bindingSource As BindingSource)
        If bindingSource?.Current IsNot Nothing Then
            _ea?.PublishEvent(New DgvItemsChanged(bindingSource,
                                                 dataGridView.CurrentRow.Index,
                                                 dataGridView.CurrentCell.OwningColumn.DataPropertyName,
                                                 dataGridView.CurrentCell.OwningColumn.Name,
                                                 dataGridView.CurrentCell.Value))
        End If
        bindingSource?.ResetBindings(False)
    End Sub
#End Region

#Region "Lookup"
    Public Sub RequestLookup(tableName As String, targetProperty As String)
        _lookupDispatcher?.Request(tableName, targetProperty)
    End Sub
    Public Sub RequestLookup(tableName As String, targetProperty As String, filter As String)
        _lookupDispatcher?.Request(tableName, targetProperty, filter)
    End Sub
    Public Sub RequestLookup(tableName As String, targetProperty As String, sortKey As String, filter As String)
        _lookupDispatcher?.Request(tableName, targetProperty, sortKey, filter)
    End Sub
    Public Sub RequestLookup(tableName As String, targetProperty As String, fields As String(), Optional filter As String = Nothing)
        _lookupDispatcher?.Request(tableName, targetProperty, fields, filter)
    End Sub
    Public Sub RequestLookup(tableName As String, targetProperty As String, sortField As String, fields As String(), Optional filter As String = Nothing)
        _lookupDispatcher?.Request(tableName, targetProperty, sortField, fields, filter)
    End Sub
#End Region

    Private Function ResolveSecurityId(key As String, isMenu As Boolean) As Long
        If String.IsNullOrWhiteSpace(key) Then Return 0
        Dim presenter = _form.Presenter
        If presenter Is Nothing Then Return 0
        Try
            If isMenu Then
                Return presenter.GetRecordFieldWithKey(key, "SecurityObject_View1", "FullPathName", "IdNo")
            End If
            Return presenter.GetRecordFieldWithKey(key, "SecurityObject", "SecurityObjectName", "IdNo")
        Catch
            Return 0
        End Try
    End Function

    Private Function ResolveUserSecurity(secId As Long, groupId As Integer) As ArrayList
        Dim presenter = _form.Presenter
        If presenter Is Nothing OrElse secId = 0 Or groupId = 0 Then
            Return New ArrayList()
        End If
        Try
            Return presenter.GetUserSecurity(secId, groupId)
        Catch
            Return New ArrayList()
        End Try
    End Function

    Private Sub EnableDoubleBuffer(ctrl As Control)
        Try
            Dim pi = GetType(Control).GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
            pi?.SetValue(ctrl, True, Nothing)
        Catch
        End Try
    End Sub

End Class