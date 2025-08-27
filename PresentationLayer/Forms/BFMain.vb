Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.Threading
Imports System.Windows.Forms
Imports AATM.Libraries
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events
Imports AATM.PresentationLayer.Forms.Services.Translation
Imports AATM.PresentationLayer.Forms.Services.Ui
Imports AATM.PresentationLayer.Views

' PURPOSE:
'  Lean presentation-focused main form.
'  All non-visual / orchestration concerns (security, lookup, grid coordination,
'  caption persistence, translation internals) live in BfMainServices.
'
' WHAT WAS REMOVED (moved to services or helpers):
'  - Security wrappers (SetObjectSecurityNew, SafeGetUserSecurity, SafeGetSecurityId, GetControlSecurityKey)
'  - Lookup CreateLookupDataTable overloads
'  - Grid edit / cache methods (ForceEndEditForAllGridControls, InvalidateControlCaches, ProcessCellEndEdit)
'  - Caption collection & default mirrored language management
'  - Language switching implementation details
'  - Double-buffer skip predicate (retained only enabling call)
'  - Presenter reflection logic now in SubFormLauncher
'
' COMPATIBILITY:
'  If external code relied on removed members, add the optional partial "BFMain.Compat.vb"
'  (sample provided below) to forward calls to Services.

Public Class BfMain
    Implements IView

#Region "Events"
    Public Event AfterTranslateForm()
    Public Event BeforeLoad()
    Public Event TextDisplayLanguageChanged()
    Friend Sub RaiseAfterTranslateForm()
        RaiseEvent AfterTranslateForm()
    End Sub
#End Region

#Region "State / Fields"
    Private _textDisplayLanguage As String
    Private _formCulture As CultureInfo
    Private _firstLoadDone As Boolean

    Public Ea As EventAggregator
    Public Presenter As Object

    Private ReadOnly _services As BfMainServices
    Private ReadOnly _subFormLauncher As SubFormLauncher

    Public Property HideNavigatorButtons As Boolean
#End Region

#Region "Constructors"
    Public Sub New()
        InitializeComponent()
        InitializeErrorProvider()
        Ea = New EventAggregator
        _services = New BfMainServices(Me, Ea)
        _subFormLauncher = New SubFormLauncher(Me)
        If LicenseManager.UsageMode <> LicenseUsageMode.Designtime Then
            TextDisplayLanguage = GlobalVariables.AppCurrentCultureInfo.Name
        End If
    End Sub

    Public Sub New(transDac As Dac, appDac As Dac)
        Me.New()
        If LicenseManager.UsageMode <> LicenseUsageMode.Designtime Then
            TranslatorDAC = transDac
            AppDataDAC = appDac
            _services.EnsureInitialized()
        End If
    End Sub

    Friend Sub New(services As BfMainServices)
        InitializeComponent()
        Ea = New EventAggregator
        _services = services
        _subFormLauncher = New SubFormLauncher(Me)
    End Sub
#End Region

#Region "Service Exposure"
    ' Expose the services container for advanced callers (read-only).
    Friend ReadOnly Property Services As BfMainServices
        Get
            Return _services
        End Get
    End Property
#End Region

#Region "Properties"
    Public Property CancelClose As Boolean
    Public Property Errors As List(Of String) Implements IView.Errors
    Public Property DataFilter As String Implements IView.DataFilter

    Protected Property TextDisplayLanguage As String
        Get
            Return _textDisplayLanguage
        End Get
        Set(value As String)
            If value <> _textDisplayLanguage Then
                _services.InvalidateTranslationCache()
                _textDisplayLanguage = value
                SetCulture(_textDisplayLanguage)
                RaiseEvent TextDisplayLanguageChanged()
            End If
        End Set
    End Property

    Protected Property FormCulture As CultureInfo
        Get
            Return If(_formCulture, CultureInfo.CurrentCulture)
        End Get
        Set(value As CultureInfo)
            _formCulture = value
        End Set
    End Property

    Protected ReadOnly Property VSystemViewIdNo As Short
        Get
            Return _services.SystemViewId
        End Get
    End Property
#End Region

#Region "Load"
    Private Sub BFMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _services.EnsureInitialized()
        If LicenseManager.UsageMode <> LicenseUsageMode.Designtime Then
            If Not _firstLoadDone Then
                _services.GetNSaveCaptions()
                _firstLoadDone = True
            End If
            TextDisplayLanguage = CultureInfo.CurrentCulture.Name
            RaiseEvent BeforeLoad()
            _services.FlickerFreeTranslateForm()
        End If
        UiPerformanceHelper.EnableDoubleBufferRecursive(Me, AddressOf ShouldSkipDoubleBuffer)
        _services.GridCoordinator?.Invalidate()
    End Sub
#End Region

#Region "Translation (Presentation Surface)"
    Protected Sub SwitchUiLanguage(originalUi As Boolean)
        _services.SwitchUiLanguage(originalUi, AddressOf OnAdjustLanguageButtons)
    End Sub

    Private Sub OnAdjustLanguageButtons()
        ' Override in descendants to toggle custom language buttons.
    End Sub

    Public Sub FlickerFreeTranslateForm()
        _services.FlickerFreeTranslateForm()
    End Sub
#End Region

#Region "UI Utilities"
    Private Shared Function ShouldSkipDoubleBuffer(ctrl As Control) As Boolean
        If TypeOf ctrl Is PictureBox AndAlso (ctrl.Width * ctrl.Height > 800000) Then Return True
        If TypeOf ctrl Is TextBoxBase Then Return True
        If ctrl.Tag IsNot Nothing AndAlso String.Equals(ctrl.Tag.ToString(), "__NO_DB__", StringComparison.Ordinal) Then Return True
        Return False
    End Function

    Public Sub ForceLooseFocusOnCurrentControl()
        Dim current = ActiveControl
        If current IsNot Nothing Then SelectNextControl(current, True, True, True, True)
        Refresh()
        If current IsNot Nothing Then ActiveControl = current
    End Sub
#End Region

#Region "Sub-form Launch (UI Orchestration)"
    Public Sub RunSubForm(Of TView As {Form}, TPresenter)()
        _subFormLauncher.RunSubForm(Of TView, TPresenter)()
    End Sub

    Public Sub RunSubForm(Of TView As {Form}, TPresenter)(data As Object, mdiParent As Form)
        _subFormLauncher.RunSubForm(Of TView, TPresenter)(data, mdiParent)
    End Sub

    Public Sub RunSubForm(Of TView As {Form}, TPresenter)(mdiParent As Form)
        _subFormLauncher.RunSubForm(Of TView, TPresenter)(mdiParent)
    End Sub

    Public Sub RunSubForm(Of TView As {Form}, TPresenter, TArg)(ByRef mdiParent As Form, param As TArg)
        _subFormLauncher.RunSubForm(Of TView, TPresenter, TArg)(mdiParent, param)
    End Sub
#End Region

#Region "Translator Launch"
    Protected Sub RunTranslator(systemViewIdNo As Short)
        Dim frm As New TranslationTableManager() With {
            .SystemViewIdNoToTranslate = systemViewIdNo,
            .AppDataDAC = AppDataDAC,
            .TranslatorDAC = TranslatorDAC
        }
        frm.Show()
    End Sub
#End Region

End Class


'Imports System.ComponentModel
'Imports System.Drawing
'Imports System.Globalization
'Imports System.Threading
'Imports System.Windows.Forms
'Imports AATM.Libraries
'Imports AATM.Libraries.CBaseControlsLibrary
'Imports AATM.Libraries.GlobalFuncNSub
'Imports AATM.Libraries.MessagingLibrary
'Imports AATM.PresentationLayer.Events
'Imports AATM.PresentationLayer.Forms.Services.Lookup
'Imports AATM.PresentationLayer.Forms.Services.Security
'Imports AATM.PresentationLayer.Forms.Services.SystemView
'Imports AATM.PresentationLayer.Forms.Services.Translation
'Imports AATM.PresentationLayer.Forms.Services.Ui
'Imports AATM.PresentationLayer.Views

'Public Class BfMain
'    Implements IView

'#Region "Constants"
'    Private Const WM_SETREDRAW As Integer = &HB
'#End Region

'#Region "Events"
'    Public Event AfterTranslateForm()
'    Public Event BeforeLoad()
'    Public Event TextDisplayLanguageChanged()
'    Friend Sub RaiseAfterTranslateForm()
'        RaiseEvent AfterTranslateForm()
'    End Sub
'#End Region

'#Region "State / Fields"
'    Private _textDisplayLanguage As String
'    Private _formCulture As CultureInfo
'    Private _firstLoadSwitch As Int32 = 0

'    Protected Friend CaptionCollection As New Collection
'    Protected Friend InitializationMode As Boolean = True
'    Protected Friend LtrCultureInfoStr = GlobalVariables.DefaultUnmirroredCultureInfoStr
'    Protected Friend RtlCultureInfoStr = GlobalVariables.DefaultMirroredCultureInfoStr
'    Protected Friend DefaultMirroredLanguageIdNo As Int16
'    Protected Shared ResetEvent As AutoResetEvent = New AutoResetEvent(False)
'    Protected FormShown As Boolean = False

'    Public Dv As DataView
'    Public MyErrorProvider As New ErrorProviderExtended
'    Public Ea As EventAggregator
'    Public Presenter As Object

'    Public Property HideNavigatorButtons As Boolean

'    ' Refactored orchestration services container
'    Private _services As BfMainServices

'    ' Cached reflection for presenter assignment optimization (kept for backward compatibility)
'    Private Shared ReadOnly _presenterPiLock As New Object()
'    Private Shared ReadOnly _presenterPiCache As New Dictionary(Of Type, Reflection.PropertyInfo)()
'#End Region

'#Region "Interop"
'    <Runtime.InteropServices.DllImport("user32.dll")>
'    Private Shared Function SendMessage(hWnd As IntPtr, msg As Integer, wParam As Boolean, lParam As Integer) As IntPtr
'    End Function
'#End Region

'#Region "Constructors"
'    Public Sub New()
'        InitializeComponent()
'        Ea = New EventAggregator
'        _services = New BfMainServices(Me, Ea)
'        If LicenseManager.UsageMode <> LicenseUsageMode.Designtime Then
'            TextDisplayLanguage = GlobalVariables.AppCurrentCultureInfo.Name
'        End If
'        InitializationMode = False
'    End Sub

'    Public Sub New(transDac As Dac, appDac As Dac)
'        Me.New()
'        If LicenseManager.UsageMode <> LicenseUsageMode.Designtime Then
'            TranslatorDAC = transDac
'            AppDataDAC = appDac
'            _services.EnsureInitialized()
'        End If
'    End Sub

'    ' Optional DI-friendly overload
'    ' PSEUDOCODE PLAN:
'    ' 1. Identify constructor: Public Sub New(services As BfMainServices)
'    ' 2. Problem: Public class BfMain exposes less accessible (Friend/Internal) type BfMainServices via a public constructor parameter -> BC30909.
'    ' 3. Minimal fix options:
'    '    a) Make BfMainServices Public (may break encapsulation) OR
'    '    b) Reduce constructor visibility to Friend so it no longer leaks the internal type OR
'    '    c) Introduce a public interface and depend on that.
'    ' 4. Choose (b) for minimal change: change constructor to Friend Sub New(...)
'    ' 5. Leave other constructors untouched.
'    ' 6. Add comment explaining rationale.

'    ' REPLACEMENT FOR ORIGINAL PUBLIC CONSTRUCTOR ACCEPTING BfMainServices
'    Friend Sub New(services As BfMainServices)
'        ' Constructor visibility reduced to Friend to avoid exposing internal type BfMainServices publicly (fixes BC30909).
'        InitializeComponent()
'        Ea = New EventAggregator
'        _services = services
'        InitializationMode = False
'    End Sub
'#End Region

'#Region "Properties"
'    Public Property CancelClose As Boolean
'    Public Property Errors As List(Of String) Implements IView.Errors
'    Public Property DataFilter As String Implements IView.DataFilter

'    Protected Property TextDisplayLanguage As String
'        Get
'            Return _textDisplayLanguage
'        End Get
'        Set(value As String)
'            If value <> _textDisplayLanguage Then
'                _services?.InvalidateTranslationCache()
'                _textDisplayLanguage = value
'                SetCulture(_textDisplayLanguage)
'                RaiseEvent TextDisplayLanguageChanged()
'            End If
'        End Set
'    End Property

'    Protected Property FormCulture As CultureInfo
'        Get
'            Return If(_formCulture, CultureInfo.CurrentCulture)
'        End Get
'        Set(value As CultureInfo)
'            _formCulture = value
'        End Set
'    End Property

'    Protected ReadOnly Property VSystemViewIdNo As Short
'        Get
'            Return If(_services Is Nothing, CShort(0), _services.SystemViewId)
'        End Get
'    End Property
'#End Region

'#Region "Load / Shown"
'    Private Sub BFMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
'        _services.EnsureInitialized()
'        If LicenseManager.UsageMode <> LicenseUsageMode.Designtime Then
'            If _firstLoadSwitch = 0 Then
'                _services.GetNSaveCaptions()
'                _firstLoadSwitch = 1
'            End If
'            TextDisplayLanguage = CultureInfo.CurrentCulture.Name
'            RaiseEvent BeforeLoad()
'            _services.FlickerFreeTranslateForm()
'        End If
'        UiPerformanceHelper.EnableDoubleBufferRecursive(Me, AddressOf ShouldSkipDoubleBuffer)
'        _services.GridCoordinator?.Invalidate()
'    End Sub
'#End Region

'#Region "Translation (UI-facing wrappers)"
'    Protected Sub SwitchUiLanguage(originalUi As Boolean)
'        _services.SwitchUiLanguage(originalUi, AddressOf SetLanguageChangeButtonsSafe)
'    End Sub

'    Protected Sub TranslateCaptions(allControls As List(Of Control),
'                                    desiredLanguage As String,
'                                    Optional allowFallback As Boolean = True)
'        _services.EnsureInitialized()
'        If Not String.Equals(CultureInfo.CurrentCulture.Name, desiredLanguage, StringComparison.OrdinalIgnoreCase) Then
'            GlobalFunctions.SetCulture(desiredLanguage)
'            GlobalVariables.AppCurrentCultureInfo = CultureInfo.CurrentCulture
'            GlobalVariables.RightToLeftLayout = CultureInfo.CurrentCulture.TextInfo.IsRightToLeft
'        End If
'        _services.TranslateCurrent(allowFallback)
'    End Sub

'    Public Sub FlickerFreeTranslateForm()
'        _services.FlickerFreeTranslateForm()
'    End Sub

'    Private Sub SetLanguageChangeButtonsSafe()
'        ' Override in descendants if they host language toggle buttons
'    End Sub
'#End Region

'#Region "Security (wrapper)"
'    Public Sub SetObjectSecurityNew(ByRef cCtrl As Control)
'        _services.ApplySecurity(cCtrl)
'    End Sub

'    ' Safe wrappers reused by services
'    Friend Function SafeGetUserSecurity(secId As Long, groupId As Integer) As ArrayList
'        If Presenter Is Nothing OrElse secId = 0 OrElse groupId = 0 Then Return New ArrayList()
'        Try
'            Return Presenter.GetUserSecurity(secId, groupId)
'        Catch
'            Return New ArrayList()
'        End Try
'    End Function

'    Friend Function SafeGetSecurityId(key As String, isMenu As Boolean) As Long
'        If Presenter Is Nothing OrElse String.IsNullOrEmpty(key) Then Return 0
'        Try
'            If isMenu Then
'                Return Presenter.GetRecordFieldWithKey(key, "SecurityObject_View1", "FullPathName", "IdNo")
'            End If
'            Return Presenter.GetRecordFieldWithKey(key, "SecurityObject", "SecurityObjectName", "IdNo")
'        Catch
'            Return 0
'        End Try
'    End Function

'    Public Function GetControlSecurityKey(cCtrl As Control) As String
'        If cCtrl.GetType().GetProperty("SecurityKey") IsNot Nothing Then
'            Return GetPropertyValue(cCtrl, "SecurityKey")
'        End If
'        Return ""
'    End Function
'#End Region

'#Region "Double Buffering (Helper Predicate)"
'    Private Shared Function ShouldSkipDoubleBuffer(ctrl As Control) As Boolean
'        If TypeOf ctrl Is PictureBox Then
'            Dim pb = DirectCast(ctrl, PictureBox)
'            If pb.Width * pb.Height > 800000 Then Return True
'        End If
'        If TypeOf ctrl Is TextBoxBase Then Return True
'        If ctrl.Tag IsNot Nothing AndAlso String.Equals(ctrl.Tag.ToString(), "__NO_DB__", StringComparison.Ordinal) Then Return True
'        Return False
'    End Function

'    Friend Sub SetFormDoubleBuffered(onOff As Boolean)
'        DoubleBuffered = onOff
'    End Sub

'    'Friend Sub LoadAndSaveCaptions()
'    '    SetFormDoubleBuffered(True)
'    '    If GlobalVariables.TranslationMode Then
'    '        CaptionCollection = StoreCaptions1.StoreTranslation(Me)
'    '        StoreCaptions1.SaveControlsOriginalText(Me) ' Ensure plural spelling matches declaration
'    '        DefaultMirroredLanguageIdNo = TranslatorDAC.DefaultMirroredLanguageIdNo
'    '        If String.IsNullOrEmpty(ViewDisplayName) Then ViewDisplayName = Name
'    '    End If
'    'End Sub

'#End Region

'#Region "Font / Utility"
'    Private Sub SetGlobalFont(ctrl As Control, font As Font)
'        ctrl.Font = font
'        For Each child As Control In ctrl.Controls
'            SetGlobalFont(child, font)
'        Next
'        If TypeOf ctrl Is MenuStrip Then
'            For Each item As ToolStripMenuItem In DirectCast(ctrl, MenuStrip).Items
'                SetToolStripItemFont(item, font)
'            Next
'        ElseIf TypeOf ctrl Is ToolStrip Then
'            For Each item As ToolStripItem In DirectCast(ctrl, ToolStrip).Items
'                item.Font = font
'            Next
'        End If
'    End Sub

'    Private Sub SetToolStripItemFont(item As ToolStripMenuItem, font As Font)
'        item.Font = font
'        For Each subItem As ToolStripItem In item.DropDownItems
'            If TypeOf subItem Is ToolStripMenuItem Then
'                SetToolStripItemFont(DirectCast(subItem, ToolStripMenuItem), font)
'            Else
'                subItem.Font = font
'            End If
'        Next
'    End Sub
'#End Region

'#Region "Focus / Grid Edits"
'    Public Sub ForceLooseFocusOnCurrentControl()
'        Dim current = ActiveControl
'        If current IsNot Nothing Then
'            SelectNextControl(current, True, True, True, True)
'        End If
'        Refresh()
'        If current IsNot Nothing Then ActiveControl = current
'    End Sub

'    Public Sub ForceLoseFocusOnCurrentControl()
'        ForceLooseFocusOnCurrentControl()
'    End Sub

'    Public Sub ForceEndEditForAllGridControls()
'        _services.EndAllGridEdits()
'    End Sub

'    Public Sub InvalidateControlCaches()
'        _services.InvalidateControlCaches()
'    End Sub

'    Protected Sub ProcessCellEndEdit(dataGridView As DataGridView, bindingSource As BindingSource)
'        _services.ProcessCellEndEdit(dataGridView, bindingSource)
'    End Sub
'#End Region

'#Region "Lookup Helpers (wrappers)"
'    Protected Overloads Sub CreateLookupDataTable(tableName As String, targetProperty As String)
'        _services.RequestLookup(tableName, targetProperty)
'    End Sub
'    Protected Overloads Sub CreateLookupDataTable(tableName As String, targetProperty As String, filter As String)
'        _services.RequestLookup(tableName, targetProperty, filter)
'    End Sub
'    Protected Overloads Sub CreateLookupDataTable(tableName As String, targetProperty As String, sortKey As String, filter As String)
'        _services.RequestLookup(tableName, targetProperty, sortKey, filter)
'    End Sub
'    Protected Overloads Sub CreateLookupDataTable(tableName As String, targetProperty As String, fields As String(), Optional filter As String = Nothing)
'        _services.RequestLookup(tableName, targetProperty, fields, filter)
'    End Sub
'    Protected Overloads Sub CreateLookupDataTable(tableName As String, targetProperty As String, sortField As String, fields As String(), Optional filter As String = Nothing)
'        _services.RequestLookup(tableName, targetProperty, sortField, fields, filter)
'    End Sub
'#End Region

'#Region "Sub-form Launch Helpers"
'    Private Sub AttachPresenter(Of TPresenter)(view As Form, ParamArray ctorArgs() As Object)
'        Dim pType = GetType(TPresenter)
'        Dim presenter = Activator.CreateInstance(pType, ctorArgs)
'        Dim vt = view.GetType()
'        Dim pi As Reflection.PropertyInfo = Nothing
'        SyncLock _presenterPiLock
'            If Not _presenterPiCache.TryGetValue(vt, pi) Then
'                pi = vt.GetProperty("Presenter")
'                _presenterPiCache(vt) = pi
'            End If
'        End SyncLock
'        If pi IsNot Nothing Then
'            pi.SetValue(view, presenter, Nothing)
'        End If
'    End Sub

'    Public Sub RunSubForm(Of TView As {Form}, TPresenter)()
'        Dim child = DirectCast(Activator.CreateInstance(GetType(TView)), TView)
'        AttachPresenter(Of TPresenter)(child, child)
'        child.MdiParent = Me
'        child.Show()
'    End Sub

'    Public Sub RunSubForm(Of TView As {Form}, TPresenter)(data As Object, mdiParent As Form)
'        Dim child As TView = DirectCast(Activator.CreateInstance(GetType(TView), data), TView)
'        AttachPresenter(Of TPresenter)(child, child)
'        child.MdiParent = mdiParent
'        child.Show()
'    End Sub

'    Public Sub RunSubForm(Of TView As {Form}, TPresenter)(mdiParent As Form)
'        Dim child As TView = DirectCast(Activator.CreateInstance(GetType(TView)), TView)
'        AttachPresenter(Of TPresenter)(child, child)
'        child.MdiParent = mdiParent
'        child.Show()
'    End Sub

'    Public Sub RunSubForm(Of TView As {Form}, TPresenter, TArg)(ByRef mdiParent As Form, param As TArg)
'        Dim child As TView = DirectCast(Activator.CreateInstance(GetType(TView), New Object() {param}), TView)
'        AttachPresenter(Of TPresenter)(child, child, param)
'        child.MdiParent = mdiParent
'        child.Show()
'    End Sub
'#End Region

'#Region "Translator Launch"
'    Protected Sub RunTranslator(nSystemViewIdNo)
'        Dim frm As New TranslationTableManager() With {
'            .SystemViewIdNoToTranslate = nSystemViewIdNo,
'            .AppDataDAC = AppDataDAC,
'            .TranslatorDAC = TranslatorDAC
'        }
'        frm.Show()
'    End Sub
'#End Region

'End Class

'Public Class SettingsSaver
'    Private _top As UInt16
'    Private _left As UInt16
'    Private _width As UInt16
'    Private _height As UInt16
'    Private _visible As Boolean

'    Public Sub SaveSetting(control As Control)
'        _top = Math.Max(control.Top, 0)
'        _left = Math.Max(control.Left, 0)
'        _width = control.Width
'        _height = control.Height
'        _visible = control.Visible
'    End Sub

'    Public Sub RestoreSetting(control As Control)
'        control.Top = _top
'        control.Left = _left
'        control.Width = _width
'        control.Height = _height
'        control.Visible = _visible
'    End Sub
'End Class