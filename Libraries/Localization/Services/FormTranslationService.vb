Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.CBaseControlsLibrary.Localization
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.Localization.Core
Imports AATM.Libraries.MessagingLibrary

Namespace Services

    Public Class FormTranslationService

        Private ReadOnly _form As Form
        Private ReadOnly _repo As ITranslationRepository
        Private ReadOnly _cache As TranslationCache

        ' CHANGE (Font optimization): single shared UI font instance (avoid allocating every translate)
        Private Shared ReadOnly UiSharedFont As New Font("Tahoma", 9.0F, FontStyle.Regular, GraphicsUnit.Point)

        Public Sub New(hostForm As Form,
                       repo As ITranslationRepository,
                       cache As TranslationCache)
            If hostForm Is Nothing Then Throw New ArgumentNullException(NameOf(hostForm))
            If repo Is Nothing Then Throw New ArgumentNullException(NameOf(repo))
            If cache Is Nothing Then Throw New ArgumentNullException(NameOf(cache))
            _form = hostForm
            _repo = repo
            _cache = cache
        End Sub

        Public Sub Preload(cultures As IEnumerable(Of String), viewIds As IEnumerable(Of Integer))
            _cache.Preload(cultures, viewIds)
        End Sub

        Public Sub Invalidate()
            _cache.Clear()
        End Sub

        Public Sub SwitchUiLanguage(originalUi As Boolean,
                                    Optional allowFallback As Boolean = True,
                                    Optional adjustButtonsCallback As Action = Nothing)

            Dim newCulture = If(originalUi,
                                GlobalVariables.DefaultUnmirroredCultureInfoStr,
                                GlobalVariables.DefaultMirroredCultureInfoStr)

            If Not String.Equals(CultureInfo.CurrentCulture.Name, newCulture, StringComparison.OrdinalIgnoreCase) Then
                GlobalFunctions.SetCulture(newCulture)
                GlobalVariables.AppCurrentCultureInfo = CultureInfo.CurrentCulture
                GlobalVariables.RightToLeftLayout = CultureInfo.CurrentCulture.TextInfo.IsRightToLeft ' (UNCHANGED) still updates global flag
            End If

            TranslateCurrentForm(allowFallback)

            adjustButtonsCallback?.Invoke()
        End Sub

        Public Sub TranslateCurrentForm(Optional allowFallback As Boolean = True)
            If LicenseManager.UsageMode = LicenseUsageMode.Designtime Then Return

            Dim resolvedLanguageId = ResolveTargetLanguageId(CultureInfo.CurrentCulture.Name, allowFallback)

            Dim originallyVisible = _form.Visible
            If originallyVisible Then _form.Visible = False

            ' CHANGE (Layout optimization): suspend layout before suppressing redraw to avoid intermediate layout passes.
            SuspendAllLayout(_form)
            SuspendAllDrawing(_form)
            Try
                If resolvedLanguageId = 0 Then
                    ControlLocalizer.ResetControls(_form, AddressOf ControlLocalizer.ResetToolStripButtonImage)
                Else
                    Dim dict = GetTranslationDictionary(CultureInfo.CurrentCulture.Name)
                    ControlLocalizer.TranslateControls(_form, dict, AddressOf ControlLocalizer.TranslateToolStripButtonImage)
                End If

                LayoutAdjuster.AdjustFormLayout(_form, CultureInfo.CurrentCulture.TextInfo.IsRightToLeft)

                ' CHANGE (Font optimization): use shared instance + skip redundant sets
                ApplyGlobalFont(UiSharedFont)

                ApplyRtlState()
            Finally
                ResumeAllDrawing(_form)
                ResumeAllLayout(_form, performLayout:=True)
                If originallyVisible Then _form.Visible = True
                _form.Refresh()
            End Try
        End Sub

        ' CHANGE: Added ApplyRtlState call so partial translations also reflect correct RTL without multiple flips elsewhere.
        Public Sub TranslateSpecificControls(controls As IEnumerable(Of Control))
            If controls Is Nothing Then Return
            SuspendAllLayout(_form)
            SuspendAllDrawing(_form)
            Try
                Dim dict = GetTranslationDictionary(CultureInfo.CurrentCulture.Name)
                For Each c In controls
                    ControlLocalizer.TranslateControls(c, dict, AddressOf ControlLocalizer.TranslateToolStripButtonImage)
                Next
                LayoutAdjuster.AdjustFormLayout(_form, CultureInfo.CurrentCulture.TextInfo.IsRightToLeft)
                ApplyRtlState()
            Finally
                ResumeAllDrawing(_form)
                ResumeAllLayout(_form, performLayout:=True)
            End Try
        End Sub

        ' ADD: Centralized, idempotent RTL application (only sets when changed).
        Private Sub ApplyRtlState()
            Dim shouldBeRtl = CultureInfo.CurrentCulture.TextInfo.IsRightToLeft
            Dim desired = If(shouldBeRtl, Windows.Forms.RightToLeft.Yes, Windows.Forms.RightToLeft.No)

            If _form.RightToLeft <> desired Then
                _form.RightToLeft = desired
            End If

            Dim f = TryCast(_form, Form)
            If f IsNot Nothing AndAlso f.RightToLeftLayout <> shouldBeRtl Then
                f.RightToLeftLayout = shouldBeRtl
            End If
            For Each fl In GetAllFlowLayouts(_form)
                fl.RefreshRtl()
            Next

        End Sub



        Private Function GetAllFlowLayouts(root As Control) As IEnumerable(Of CFlowLayout)
            Dim list As New List(Of CFlowLayout)
            Dim stack As New Stack(Of Control)
            stack.Push(root)
            While stack.Count > 0
                Dim c = stack.Pop()
                Dim fl = TryCast(c, CFlowLayout)
                If fl IsNot Nothing Then list.Add(fl)
                For Each child As Control In c.Controls
                    stack.Push(child)
                Next
            End While
            Return list
        End Function

        Private Function GetTranslationDictionary(culture As String) As Dictionary(Of String, String)
            Dim viewId = GetSystemViewId()
            Return CType(_cache.GetOrAdd(culture, viewId), Dictionary(Of String, String))
        End Function

        Private Function ResolveTargetLanguageId(culture As String, allowFallback As Boolean) As Short
            Dim langId = _repo.GetLanguageId(culture)
            If langId = 0 Then Return 0
            If _repo.CultureHasTranslations(culture) Then Return CShort(langId)
            If Not allowFallback Then Return 0
            Dim fb = _repo.GetFallbackLanguageId(culture)
            If fb = 0 Then Return 0
            Return CShort(fb)
        End Function

        Public Shared Sub SetGlobalTranslator(dac As Dac)
            TranslatorAccessor.TranslatorDACV = dac
        End Sub

        Private Function GetSystemViewId() As Integer
            Dim viewName = _form.Name
            Dim dac = TranslatorAccessor.TranslatorDACV
            If dac Is Nothing Then
                Throw New InvalidOperationException("TranslatorDACV is not initialized. Call TranslatorAccessor.InitializeTranslator(dac) before using FormTranslationService.")
            End If
            Dim sql = "SELECT IdNo FROM SystemView WHERE SystemViewName = '" & viewName.Replace("'", "''") & "'"
            Return dac.ExecScalar(Of Integer)(sql)
        End Function

#Region "Drawing Suppression"
        Private Const WM_SETREDRAW As Integer = &HB

        <Runtime.InteropServices.DllImport("user32.dll")>
        Private Shared Function SendMessage(hWnd As IntPtr, msg As Integer, wParam As Boolean, lParam As Integer) As IntPtr
        End Function

        Private Sub SuspendDrawing(ctrl As Control)
            If ctrl Is Nothing OrElse Not ctrl.IsHandleCreated Then Return
            SendMessage(ctrl.Handle, WM_SETREDRAW, False, 0)
        End Sub

        Private Sub ResumeDrawing(ctrl As Control)
            If ctrl Is Nothing OrElse Not ctrl.IsHandleCreated Then Return
            SendMessage(ctrl.Handle, WM_SETREDRAW, True, 0)
            ctrl.Refresh()
        End Sub

        Private Sub SuspendAllDrawing(root As Control)
            SuspendDrawing(root)
            For Each c As Control In root.Controls
                SuspendAllDrawing(c)
            Next
        End Sub

        Private Sub ResumeAllDrawing(root As Control)
            ResumeDrawing(root)
            For Each c As Control In root.Controls
                ResumeAllDrawing(c)
            Next
        End Sub
#End Region

#Region "Layout Suspension"
        ' CHANGE (Layout optimization): recursive layout suspension to avoid intermediate layout passes.
        Private Sub SuspendAllLayout(root As Control)
            root.SuspendLayout()
            For Each c As Control In root.Controls
                SuspendAllLayout(c)
            Next
        End Sub

        Private Sub ResumeAllLayout(root As Control, performLayout As Boolean)
            For Each c As Control In root.Controls
                ResumeAllLayout(c, performLayout:=False)
            Next
            root.ResumeLayout(performLayout)
        End Sub
#End Region

#Region "Font"
        Private Sub ApplyGlobalFont(font As Font)
            SetFontRecursive(_form, font)
        End Sub

        ' CHANGE (Font optimization): skip assignment when identical to avoid layout/paint churn.
        Private Sub SetFontRecursive(ctrl As Control, font As Font)
            If Not FontEquals(ctrl.Font, font) Then
                ctrl.Font = font
            End If
            For Each child As Control In ctrl.Controls
                SetFontRecursive(child, font)
            Next
        End Sub

        Private Shared Function FontEquals(a As Font, b As Font) As Boolean
            If a Is b Then Return True
            If a Is Nothing OrElse b Is Nothing Then Return False
            ' Compare core characteristics (size in points avoids DPI unit differences)
            Return a.Name = b.Name AndAlso
                   Math.Abs(a.SizeInPoints - b.SizeInPoints) < 0.01 AndAlso
                   a.Style = b.Style AndAlso
                   a.Unit = b.Unit
        End Function
#End Region

    End Class

End Namespace