Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.CBaseControlsLibrary.Localization
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.Localization.Core
Imports AATM.Libraries.Messaging

Namespace Services

    Public Class FormTranslationService
        Implements IUiLocalizationService

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

        ' Add event + interface members:
        Public Event UiLanguageChanged(newCulture As CultureInfo, isRtl As Boolean) Implements IUiLocalizationService.UiLanguageChanged

        Public ReadOnly Property CurrentCulture As CultureInfo Implements IUiLocalizationService.CurrentCulture
            Get
                Return CultureInfo.CurrentCulture
            End Get
        End Property

        Public ReadOnly Property IsRtl As Boolean Implements IUiLocalizationService.IsRtl
            Get
                Return CultureInfo.CurrentCulture.TextInfo.IsRightToLeft
            End Get
        End Property

        Public Sub SwitchLanguage(originalUi As Boolean) Implements IUiLocalizationService.SwitchLanguage
            SwitchUiLanguage(originalUi, allowFallback:=True)
            RaiseEvent UiLanguageChanged(CultureInfo.CurrentCulture, CultureInfo.CurrentCulture.TextInfo.IsRightToLeft)
        End Sub

        Public Sub Translate(Optional force As Boolean = False) Implements IUiLocalizationService.Translate
            TranslateCurrentForm()
            RaiseEvent UiLanguageChanged(CultureInfo.CurrentCulture, CultureInfo.CurrentCulture.TextInfo.IsRightToLeft)
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

        ' --- Overload to translate with explicit culture (NEW) ---
        ' REPLACE the existing TranslateCurrentForm overload with the following fixed version
        Public Sub TranslateCurrentForm(targetCulture As CultureInfo)
            ' Plan:
            ' 1. If targetCulture is Nothing, delegate to existing TranslateCurrentForm().
            ' 2. Use existing GetSystemViewId (fix: remove call to missing GetViewId).
            ' 3. Fetch translation dictionary from cache.
            ' 4. Apply translations.
            If targetCulture Is Nothing Then
                TranslateCurrentForm()
                Return
            End If
            Dim cultureName = targetCulture.Name
            Dim viewId = GetSystemViewId()
            Dim dict = _cache.GetOrAdd(cultureName, viewId)
            ApplyTranslations(dict, targetCulture)
        End Sub

        ' --- Factor existing logic into reusable method (NEW if not present) ---
        Private Sub ApplyTranslations(dict As IDictionary(Of String, String), targetCulture As CultureInfo)
            If dict Is Nothing Then Exit Sub
            For Each ctl In EnumerateControls(_form)
                Dim key = ResolveKey(ctl)
                If key IsNot Nothing AndAlso dict.ContainsKey(key) Then
                    ctl.Text = dict(key)
                End If
            Next
            ' (No global RTL changes here; form decides its own layout)
        End Sub

        ' NEW: Enumerate all controls (depth-first) starting from a root control.
        Private Iterator Function EnumerateControls(root As Control) As IEnumerable(Of Control)
            If root Is Nothing Then
                Return
            End If
            Dim stack As New Stack(Of Control)
            stack.Push(root)
            While stack.Count > 0
                Dim current = stack.Pop()
                Yield current
                For i = current.Controls.Count - 1 To 0 Step -1
                    stack.Push(current.Controls(i))
                Next
            End While
        End Function

        ' NEW: Resolve translation key for a control (can be extended later).
        ' Currently uses control.Name; falls back to Nothing when unnamed.
        Private Function ResolveKey(ctrl As Control) As String
            If ctrl Is Nothing Then Return Nothing
            If String.IsNullOrWhiteSpace(ctrl.Name) Then Return Nothing
            Return ctrl.Name
        End Function


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

        '        ' ADD: Centralized, idempotent RTL application (only sets when changed).
        '        ' Added: RTL handling for TabControl and TabPages
        '        Private Sub ApplyRtlState()
        '            Dim shouldBeRtl = CultureInfo.CurrentCulture.TextInfo.IsRightToLeft
        '            Dim desired = If(shouldBeRtl, Windows.Forms.RightToLeft.Yes, Windows.Forms.RightToLeft.No)

        '            ' Form level
        '            If _form.RightToLeft <> desired Then
        '                _form.RightToLeft = desired
        '            End If

        '            Dim f = TryCast(_form, Form)
        '            If f IsNot Nothing AndAlso f.RightToLeftLayout <> shouldBeRtl Then
        '                f.RightToLeftLayout = shouldBeRtl
        '            End If

        '            ' Flow layouts (existing behavior)
        '            For Each fl In GetAllFlowLayouts(_form)
        '                fl.RefreshRtl()
        '            Next

        '            ' NEW: TabControls + their TabPages
        '            For Each tc In GetAllTabControls(_form)
        '                If tc.RightToLeft <> desired Then
        '                    tc.RightToLeft = desired
        '                End If
        '#If NETFRAMEWORK Then
        '                ' RightToLeftLayout exists for TabControl in .NET Framework
        '                Try
        '                    If tc.RightToLeftLayout <> shouldBeRtl Then
        '                        tc.RightToLeftLayout = shouldBeRtl
        '                    End If
        '                Catch
        '                    ' Ignore if not supported (defensive)
        '                End Try
        '#End If
        '                For Each page As TabPage In tc.TabPages
        '                    If page.RightToLeft <> desired Then
        '                        page.RightToLeft = desired
        '                    End If
        '                    ' TabPage does not expose RightToLeftLayout; layout mirroring handled by parent.
        '                Next
        '            Next
        '        End Sub

        ' Usage:
        '   SetRightToLeftRecursive(Me, makeRtl:=True)
        '   SetRightToLeftRecursive(panel1, makeRtl:=False, overrideExisting:=False)
        ' REFACTOR: Centralize RTL handling through SetRightToLeftRecursive to avoid duplication.
        ' CHANGES:
        ' 1. ApplyRtlState now simply calls SetRightToLeftRecursive + refreshes flow layouts.
        ' 2. Moved TabControl + TabPages handling into SetRightToLeftRecursive.
        ' 3. Removed GetAllTabControls (no longer needed).
        ' 4. Preserved existing special cases (Form, DataGridView, ToolStrip) and added TabControl logic there.

        ' --- REPLACEMENT: ApplyRtlState (old implementation removed) ---
        Private Sub ApplyRtlState()
            Dim shouldBeRtl = CultureInfo.CurrentCulture.TextInfo.IsRightToLeft
            ' Force propagation (overrideExisting:=True) so a language switch fully applies.
            SetRightToLeftRecursive(_form, shouldBeRtl, overrideExisting:=True)

            '' Flow layouts may need explicit refresh after direction change.
            'For Each fl In GetAllFlowLayouts(_form)
            '    fl.RefreshRtl()
            'Next
        End Sub

        ' --- UPDATED: SetRightToLeftRecursive (added TabControl handling & TabPages) ---
        ' REFACTORED: Simplified SetRightToLeftRecursive by extracting specialized handlers.
        Public Sub SetRightToLeftRecursive(root As Control,
                                           makeRtl As Boolean,
                                           Optional overrideExisting As Boolean = True,
                                           Optional excludeTypes As IEnumerable(Of Type) = Nothing)

            If root Is Nothing Then Exit Sub

            Dim desired = If(makeRtl, RightToLeft.Yes, RightToLeft.No)
            Dim excluded As HashSet(Of Type) = If(excludeTypes Is Nothing, Nothing, New HashSet(Of Type)(excludeTypes))

            Dim stack As New Stack(Of Control)
            stack.Push(root)

            While stack.Count > 0
                Dim current = stack.Pop()

                If Not IsExcluded(current, excluded) AndAlso ShouldApply(current, overrideExisting) Then
                    ApplyGenericRtl(current, desired)
                    ApplySpecialCases(current, makeRtl, desired, overrideExisting)
                End If

                PushChildren(current, stack)
            End While
        End Sub

        ' ----------------- Helper Methods (Private) -----------------

        Private Function IsExcluded(ctrl As Control, excluded As HashSet(Of Type)) As Boolean
            Return excluded IsNot Nothing AndAlso excluded.Contains(ctrl.GetType())
        End Function

        Private Function ShouldApply(ctrl As Control, overrideExisting As Boolean) As Boolean
            Return overrideExisting OrElse ctrl.RightToLeft = RightToLeft.Inherit
        End Function

        Private Sub ApplyGenericRtl(ctrl As Control, desired As RightToLeft)
            Try
                ctrl.RightToLeft = desired
            Catch
                ' Swallow for 3rd-party controls without setter
            End Try
        End Sub
        ' PSEUDOCODE (planned modifications):
        ' 1. Extend ApplySpecialCases with additional ElseIf branches for:
        '    - ListView (RightToLeftLayout + column header alignment flip)
        '    - TreeView (RightToLeftLayout)
        '    - MonthCalendar (RightToLeftLayout)
        '    - DateTimePicker (RightToLeftLayout)
        '    - DomainUpDown (UpDownAlign flip)
        '    - NumericUpDown (UpDownAlign / TextAlign flip)
        '    - ListBox / CheckedListBox (force Refresh for owner draw)
        '    - TableLayoutPanel (PerformLayout after direction change)
        '    - Label / LinkLabel (TextAlign flip)
        '    - CheckBox / RadioButton (TextAlign & CheckAlign flip)
        ' 2. Enhance existing DataGridView handler to also adjust DefaultCellStyle.Alignment.
        ' 3. Enhance ToolStrip handler to flip TextImageRelation (ImageBeforeText/TextBeforeImage).
        ' 4. Add helper methods:
        '    - FlipContentAlignment (maps Left<->Right)
        '    - FlipHorizontalAlignment(DataGridViewContentAlignment)
        '    - TrySetRightToLeftLayout(reflection safe)
        '    - HandleListView / HandleTreeView / HandleMonthCalendar / HandleDateTimePicker / HandleDomainUpDown / HandleNumericUpDown
        '      / HandleListBoxBase / HandleTableLayout / HandleTextImageAlignmentControls
        ' 5. Keep changes minimal / defensive (Try/Catch around unsupported props).
        ' 6. Only flip alignments when they are strictly Left or Right variants (avoid overriding explicit centered/custom choices).
        '
        ' ================== MODIFIED ApplySpecialCases + NEW HELPERS ==================

        Private Sub ApplySpecialCases(ctrl As Control,
                                      makeRtl As Boolean,
                                      desired As RightToLeft,
                                      overrideExisting As Boolean)

            If TypeOf ctrl Is Form Then
                HandleForm(DirectCast(ctrl, Form), makeRtl)
            ElseIf TypeOf ctrl Is DataGridView Then
                HandleDataGridView(DirectCast(ctrl, DataGridView), makeRtl)
            ElseIf TypeOf ctrl Is ToolStrip Then
                HandleToolStrip(DirectCast(ctrl, ToolStrip), desired)
            ElseIf TypeOf ctrl Is TabControl Then
                HandleTabControl(DirectCast(ctrl, TabControl), makeRtl, desired, overrideExisting)
            ElseIf TypeOf ctrl Is FlowLayoutPanel Then
                HandleFlowLayoutPanel(DirectCast(ctrl, FlowLayoutPanel))
            ElseIf ctrl.GetType().Name = "CFlowLayout" Then
                HandleCustomCFlowLayout(ctrl, makeRtl)
            ElseIf TypeOf ctrl Is SplitContainer Then
                HandleSplitContainer(DirectCast(ctrl, SplitContainer))

                ' --- NEW CASES ---
            ElseIf TypeOf ctrl Is ListView Then
                HandleListView(DirectCast(ctrl, ListView), makeRtl)
            ElseIf TypeOf ctrl Is TreeView Then
                HandleTreeView(DirectCast(ctrl, TreeView), makeRtl)
            ElseIf TypeOf ctrl Is MonthCalendar Then
                HandleMonthCalendar(DirectCast(ctrl, MonthCalendar), makeRtl)
            ElseIf TypeOf ctrl Is DateTimePicker Then
                HandleDateTimePicker(DirectCast(ctrl, DateTimePicker), makeRtl)
            ElseIf TypeOf ctrl Is DomainUpDown Then
                HandleDomainUpDown(DirectCast(ctrl, DomainUpDown), makeRtl)
            ElseIf TypeOf ctrl Is NumericUpDown Then
                HandleNumericUpDown(DirectCast(ctrl, NumericUpDown), makeRtl)
            ElseIf TypeOf ctrl Is CheckedListBox OrElse TypeOf ctrl Is ListBox Then
                HandleListBoxBase(DirectCast(ctrl, ListBox))
            ElseIf TypeOf ctrl Is TableLayoutPanel Then
                HandleTableLayoutPanel(DirectCast(ctrl, TableLayoutPanel))
            ElseIf TypeOf ctrl Is Label OrElse TypeOf ctrl Is LinkLabel Then
                HandleLabelLikeAlignment(ctrl, makeRtl)
            ElseIf TypeOf ctrl Is CheckBox Then
                HandleCheckRadioAlignment(DirectCast(ctrl, CheckBox), makeRtl)
            ElseIf TypeOf ctrl Is RadioButton Then
                HandleCheckRadioAlignment(DirectCast(ctrl, RadioButton), makeRtl)
            End If
        End Sub

        ' ----------------- ENHANCED / NEW HELPERS -----------------

        Private Sub HandleDataGridView(dgv As DataGridView, makeRtl As Boolean)
            For Each col As DataGridViewColumn In dgv.Columns
                ' Header alignment (existing behavior extended)
                If makeRtl Then
                    If col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.NotSet OrElse
                       col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft Then
                        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    End If
                Else
                    If col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight Then
                        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
                    End If
                End If

                ' NEW: DefaultCellStyle alignment flip (only left/right variants)
                col.DefaultCellStyle.Alignment = FlipHorizontalAlignment(col.DefaultCellStyle.Alignment, makeRtl)
            Next
            ' (Optional column order reversal could be added here if required)
        End Sub

        Private Sub HandleToolStrip(ts As ToolStrip, desired As RightToLeft)
            Try
                If ts.RightToLeft <> desired Then ts.RightToLeft = desired
            Catch
            End Try
            ' NEW: Adjust per-item TextImageRelation to keep icon leading side
            For Each item As ToolStripItem In ts.Items
                Dim relation = item.TextImageRelation
                If desired = RightToLeft.Yes Then
                    If relation = TextImageRelation.ImageBeforeText Then
                        item.TextImageRelation = TextImageRelation.TextBeforeImage
                    End If
                Else
                    If relation = TextImageRelation.TextBeforeImage Then
                        item.TextImageRelation = TextImageRelation.ImageBeforeText
                    End If
                End If
            Next
        End Sub

        Private Sub HandleListView(lv As ListView, makeRtl As Boolean)
            TrySetRightToLeftLayout(lv, makeRtl)
            If lv.View = View.Details AndAlso lv.Columns IsNot Nothing Then
                For Each ch As ColumnHeader In lv.Columns
                    If makeRtl AndAlso ch.TextAlign = HorizontalAlignment.Left Then
                        ch.TextAlign = HorizontalAlignment.Right
                    ElseIf Not makeRtl AndAlso ch.TextAlign = HorizontalAlignment.Right Then
                        ch.TextAlign = HorizontalAlignment.Left
                    End If
                Next
            End If
        End Sub

        Private Sub HandleTreeView(tv As TreeView, makeRtl As Boolean)
            TrySetRightToLeftLayout(tv, makeRtl)
        End Sub

        Private Sub HandleMonthCalendar(mc As MonthCalendar, makeRtl As Boolean)
            TrySetRightToLeftLayout(mc, makeRtl)
        End Sub

        Private Sub HandleDateTimePicker(dtp As DateTimePicker, makeRtl As Boolean)
            TrySetRightToLeftLayout(dtp, makeRtl)
        End Sub

        Private Sub HandleDomainUpDown(dud As DomainUpDown, makeRtl As Boolean)
            Try
                dud.UpDownAlign = If(makeRtl, LeftRightAlignment.Left, LeftRightAlignment.Right)
            Catch
            End Try
        End Sub

        Private Sub HandleNumericUpDown(nud As NumericUpDown, makeRtl As Boolean)
            Try
                nud.UpDownAlign = If(makeRtl, LeftRightAlignment.Left, LeftRightAlignment.Right)
            Catch
            End Try
            Try
                ' Flip text alignment only if explicitly Left/Right
                If makeRtl AndAlso nud.TextAlign = HorizontalAlignment.Left Then
                    nud.TextAlign = HorizontalAlignment.Right
                ElseIf Not makeRtl AndAlso nud.TextAlign = HorizontalAlignment.Right Then
                    nud.TextAlign = HorizontalAlignment.Left
                End If
            Catch
            End Try
        End Sub

        Private Sub HandleListBoxBase(lb As ListBox)
            ' Generic Refresh so owner-draw logic can pick up RightToLeft change.
            Try
                lb.Refresh()
            Catch
            End Try
        End Sub

        Private Sub HandleTableLayoutPanel(tlp As TableLayoutPanel)
            ' Force layout recalculation after direction switch
            Try
                tlp.PerformLayout()
            Catch
            End Try
        End Sub

        Private Sub HandleLabelLikeAlignment(ctrl As Control, makeRtl As Boolean)
            Dim lbl = TryCast(ctrl, Label)
            If lbl Is Nothing Then
                Dim lnk = TryCast(ctrl, LinkLabel)
                If lnk Is Nothing Then Return
                lnk.TextAlign = FlipContentAlignment(lnk.TextAlign, makeRtl)
            Else
                lbl.TextAlign = FlipContentAlignment(lbl.TextAlign, makeRtl)
            End If
        End Sub

        Private Sub HandleCheckRadioAlignment(ctrl As Control, makeRtl As Boolean)
            ' Works for CheckBox / RadioButton
            Dim textAlignProp = ctrl.GetType().GetProperty("TextAlign")
            Dim checkAlignProp = ctrl.GetType().GetProperty("CheckAlign")
            Try
                If textAlignProp IsNot Nothing Then
                    Dim current = CType(textAlignProp.GetValue(ctrl, Nothing), ContentAlignment)
                    textAlignProp.SetValue(ctrl, FlipContentAlignment(current, makeRtl), Nothing)
                End If
            Catch
            End Try
            Try
                If checkAlignProp IsNot Nothing Then
                    Dim current = CType(checkAlignProp.GetValue(ctrl, Nothing), ContentAlignment)
                    checkAlignProp.SetValue(ctrl, FlipContentAlignment(current, makeRtl), Nothing)
                End If
            Catch
            End Try
        End Sub

        Private Sub TrySetRightToLeftLayout(ctrl As Control, makeRtl As Boolean)
            ' Uses reflection so we can call for any control that exposes RightToLeftLayout (ListView, TreeView, etc.)
            Try
                Dim prop = ctrl.GetType().GetProperty("RightToLeftLayout", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.Public)
                If prop IsNot Nothing AndAlso prop.CanWrite Then
                    Dim current = CBool(prop.GetValue(ctrl, Nothing))
                    If current <> makeRtl Then
                        prop.SetValue(ctrl, makeRtl, Nothing)
                    End If
                End If
            Catch
            End Try
        End Sub

        Private Function FlipContentAlignment(value As ContentAlignment, makeRtl As Boolean) As ContentAlignment
            If makeRtl Then
                Select Case value
                    Case ContentAlignment.MiddleLeft : Return ContentAlignment.MiddleRight
                    Case ContentAlignment.TopLeft : Return ContentAlignment.TopRight
                    Case ContentAlignment.BottomLeft : Return ContentAlignment.BottomRight
                    Case Else : Return value
                End Select
            Else
                Select Case value
                    Case ContentAlignment.MiddleRight : Return ContentAlignment.MiddleLeft
                    Case ContentAlignment.TopRight : Return ContentAlignment.TopLeft
                    Case ContentAlignment.BottomRight : Return ContentAlignment.BottomLeft
                    Case Else : Return value
                End Select
            End If
        End Function

        Private Function FlipHorizontalAlignment(value As DataGridViewContentAlignment, makeRtl As Boolean) As DataGridViewContentAlignment
            If makeRtl Then
                Select Case value
                    Case DataGridViewContentAlignment.MiddleLeft : Return DataGridViewContentAlignment.MiddleRight
                    Case DataGridViewContentAlignment.TopLeft : Return DataGridViewContentAlignment.TopRight
                    Case DataGridViewContentAlignment.BottomLeft : Return DataGridViewContentAlignment.BottomRight
                    Case Else : Return value
                End Select
            Else
                Select Case value
                    Case DataGridViewContentAlignment.MiddleRight : Return DataGridViewContentAlignment.MiddleLeft
                    Case DataGridViewContentAlignment.TopRight : Return DataGridViewContentAlignment.TopLeft
                    Case DataGridViewContentAlignment.BottomRight : Return DataGridViewContentAlignment.BottomLeft
                    Case Else : Return value
                End Select
            End If
        End Function

        Private Sub HandleForm(f As Form, makeRtl As Boolean)
            If f.RightToLeftLayout <> makeRtl Then
                f.RightToLeftLayout = makeRtl
            End If
        End Sub

        'Private Sub HandleDataGridView(dgv As DataGridView, makeRtl As Boolean)
        '    For Each col As DataGridViewColumn In dgv.Columns
        '        If makeRtl Then
        '            If col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.NotSet _
        '               OrElse col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft Then
        '                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        '            End If
        '        Else
        '            If col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight Then
        '                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        '            End If
        '        End If
        '    Next
        'End Sub

        'Private Sub HandleToolStrip(ts As ToolStrip, desired As RightToLeft)
        '    ts.RightToLeft = desired
        'End Sub

        Private Sub HandleTabControl(tc As TabControl,
                                     makeRtl As Boolean,
                                     desired As RightToLeft,
                                     overrideExisting As Boolean)
            Dim rtlLayoutChanged As Boolean = (tc.RightToLeftLayout <> makeRtl)
            Dim rtlPropChanged As Boolean = (tc.RightToLeft <> desired)
            Dim needLayoutFlip As Boolean = rtlLayoutChanged OrElse rtlPropChanged

            tc.SuspendLayout()

            ' Core flags
            If rtlPropChanged Then
                tc.RightToLeft = desired
            End If

            If rtlLayoutChanged Then
                ' Toggle sequence (helps in some edge cases)
                tc.RightToLeftLayout = makeRtl
                ForceTabControlStyleRefresh(tc)   ' replaces inaccessible UpdateStyles
            End If

            ' Pages
            For Each page As TabPage In tc.TabPages
                If overrideExisting OrElse page.RightToLeft = RightToLeft.Inherit Then
                    If page.RightToLeft <> desired Then
                        page.RightToLeft = desired
                    End If
                End If
            Next

            tc.ResumeLayout(performLayout:=needLayoutFlip)
            If needLayoutFlip Then
                tc.PerformLayout()
                tc.Invalidate()
                tc.Refresh()
            End If
        End Sub

        ' Helper: safely force TabControl to rebuild styles after RTL / RightToLeftLayout change
        Private Sub ForceTabControlStyleRefresh(tc As TabControl)
            If tc Is Nothing OrElse tc.IsDisposed Then Return

            ' Ensure handle exists
            If Not tc.IsHandleCreated Then
                Try
                    tc.CreateControl()
                Catch
                End Try
            End If

            ' Try calling protected RecreateHandle via reflection (works in WinForms .NET Framework)
            Try
                Dim m = GetType(Control).GetMethod("RecreateHandle",
                                           Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic)
                If m IsNot Nothing Then
                    m.Invoke(tc, Nothing)
                    Return
                End If
            Catch
                ' Ignore and fallback
            End Try

            ' Fallback 1: slight size nudge to invalidate and force layout/paint
            Try
                Dim w = tc.Width
                tc.Width = w + 1
                tc.Width = w
            Catch
            End Try

            ' Fallback 2 (async invalidate to avoid doing it while suspended)
            Try
                tc.BeginInvoke(New MethodInvoker(Sub()
                                                     If Not tc.IsDisposed Then
                                                         tc.Invalidate()
                                                         tc.Update()
                                                     End If
                                                 End Sub))
            Catch
            End Try
        End Sub

        '    Dim needLayoutFlip As Boolean = (tc.RightToLeftLayout <> makeRtl) OrElse (tc.RightToLeft <> desired)

        '    ' Suspend while toggling
        '    tc.SuspendLayout()

        '    ' Always set core RTL flags
        '    If tc.RightToLeft <> desired Then
        '        tc.RightToLeft = desired
        '    End If

        '    ' Ensure RightToLeftLayout (no conditional compilation)
        '    If tc.RightToLeftLayout <> makeRtl Then
        '        ' Toggle pattern to force handle to refresh header order reliably
        '        ' (some frameworks need a false->true sequence)
        '        tc.RightToLeftLayout = makeRtl
        '        tc.UpdateStyles()
        '    End If

        '    ' Apply to pages
        '    For Each page As TabPage In tc.TabPages
        '        If overrideExisting OrElse page.RightToLeft = RightToLeft.Inherit Then
        '            If page.RightToLeft <> desired Then
        '                page.RightToLeft = desired
        '            End If
        '        End If
        '    Next

        '    tc.ResumeLayout(performLayout:=needLayoutFlip)
        '    If needLayoutFlip Then
        '        tc.PerformLayout()
        '        tc.Refresh()
        '    End If
        '    ''#If NETFRAMEWORK Then
        '    ''            Try
        '    'If tc.RightToLeftLayout <> makeRtl Then
        '    '    tc.RightToLeftLayout = makeRtl
        '    'End If
        '    ''            Catch
        '    ''            End Try
        '    ''#End If
        '    'For Each page As TabPage In tc.TabPages
        '    '    If overrideExisting OrElse page.RightToLeft = RightToLeft.Inherit Then
        '    '        Try
        '    '            page.RightToLeft = desired
        '    '        Catch
        '    '        End Try
        '    '    End If
        '    'Next
        'End Sub

        Private Sub HandleFlowLayoutPanel(flp As FlowLayoutPanel)
            flp.PerformLayout()
        End Sub

        Private Sub HandleCustomCFlowLayout(ctrl As Control, makeRtl As Boolean)
            Try
                Dim t = ctrl.GetType()
                Dim flowDirProp = t.GetProperty("FlowDirection")
                If flowDirProp IsNot Nothing Then
                    Dim current = flowDirProp.GetValue(ctrl, Nothing)
                    Dim name = current.ToString()
                    If makeRtl AndAlso name = "LeftToRight" Then
                        flowDirProp.SetValue(ctrl, [Enum].Parse(flowDirProp.PropertyType, "RightToLeft"), Nothing)
                    ElseIf Not makeRtl AndAlso name = "RightToLeft" Then
                        flowDirProp.SetValue(ctrl, [Enum].Parse(flowDirProp.PropertyType, "LeftToRight"), Nothing)
                    End If
                End If
                Dim m = t.GetMethod("RefreshRtl")
                If m IsNot Nothing Then
                    m.Invoke(ctrl, Nothing)
                Else
                    ctrl.PerformLayout()
                End If
            Catch
                ' Ignore reflective failures
            End Try
        End Sub

        Private Sub HandleSplitContainer(sc As SplitContainer)
            sc.PerformLayout()
        End Sub

        Private Sub PushChildren(parent As Control, stack As Stack(Of Control))
            For Each child As Control In parent.Controls
                stack.Push(child)
            Next
        End Sub

        '        ' REFACTORED: Added handling for FlowLayoutPanel, CFlowLayout and SplitContainer (splitter controls).
        '        ' - FlowLayoutPanel / CFlowLayout: mirror FlowDirection when switching RTL/LTR (only horizontal directions).
        '        ' - CFlowLayout: call RefreshRtl() if available (wrapped in Try/Catch to avoid hard dependency).
        '        ' - SplitContainer: ensure RightToLeft is applied (panel mirroring handled by framework when RightToLeftLayout is not present).
        '        ' - Splitter: inherits generic RightToLeft assignment (no extra logic needed).
        '        Public Sub SetRightToLeftRecursive(root As Control,
        '                                   makeRtl As Boolean,
        '                                   Optional overrideExisting As Boolean = True,
        '                                   Optional excludeTypes As IEnumerable(Of Type) = Nothing)

        '            If root Is Nothing Then Exit Sub
        '            Dim desired = If(makeRtl, RightToLeft.Yes, RightToLeft.No)

        '            Dim excluded As HashSet(Of Type) = Nothing
        '            If excludeTypes IsNot Nothing Then
        '                excluded = New HashSet(Of Type)(excludeTypes)
        '            End If

        '            Dim stack As New Stack(Of Control)
        '            stack.Push(root)

        '            While stack.Count > 0
        '                Dim c = stack.Pop()

        '                If excluded Is Nothing OrElse Not excluded.Contains(c.GetType()) Then
        '                    If overrideExisting OrElse c.RightToLeft = RightToLeft.Inherit Then
        '                        ' Generic assignment (wrapped to tolerate 3rd-party custom controls)
        '                        Try
        '                            c.RightToLeft = desired
        '                        Catch
        '                        End Try

        '                        If TypeOf c Is Form Then
        '                            Dim f = DirectCast(c, Form)
        '                            If f.RightToLeftLayout <> makeRtl Then
        '                                f.RightToLeftLayout = makeRtl
        '                            End If

        '                        ElseIf TypeOf c Is DataGridView Then
        '                            Dim dgv = DirectCast(c, DataGridView)
        '                            For Each col As DataGridViewColumn In dgv.Columns
        '                                If makeRtl Then
        '                                    If col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.NotSet _
        '                                       OrElse col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft Then
        '                                        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        '                                    End If
        '                                Else
        '                                    If col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight Then
        '                                        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        '                                    End If
        '                                End If
        '                            Next

        '                        ElseIf TypeOf c Is ToolStrip Then
        '                            Dim ts = DirectCast(c, ToolStrip)
        '                            ts.RightToLeft = desired

        '                        ElseIf TypeOf c Is TabControl Then
        '                            Dim tc = DirectCast(c, TabControl)
        '#If NETFRAMEWORK Then
        '                            Try
        '                                If tc.RightToLeftLayout <> makeRtl Then
        '                                    tc.RightToLeftLayout = makeRtl
        '                                End If
        '                            Catch
        '                            End Try
        '#End If
        '                            For Each page As TabPage In tc.TabPages
        '                                If overrideExisting OrElse page.RightToLeft = RightToLeft.Inherit Then
        '                                    Try
        '                                        page.RightToLeft = desired
        '                                    Catch
        '                                    End Try
        '                                End If
        '                            Next

        '                        ElseIf TypeOf c Is FlowLayoutPanel Then
        '                            Dim flp = DirectCast(c, FlowLayoutPanel)
        '                            ' Do not flip FlowDirection; rely on RightToLeft to mirror horizontal layout.
        '                            ' Just force a layout refresh after text / direction changes.
        '                            flp.PerformLayout()

        '                        ElseIf c.GetType().Name = "CFlowLayout" Then
        '                            ' Custom flow layout (AATM.Libraries.CBaseControlsLibrary.CFlowLayout)
        '                            ' Attempt to mirror via FlowDirection property if it exists; else call RefreshRtl
        '                            Try
        '                                Dim t = c.GetType()
        '                                Dim flowDirProp = t.GetProperty("FlowDirection")
        '                                If flowDirProp IsNot Nothing Then
        '                                    Dim current = flowDirProp.GetValue(c, Nothing)
        '                                    ' Expecting enum with names LeftToRight / RightToLeft / TopDown / BottomUp
        '                                    If makeRtl AndAlso current.ToString() = "LeftToRight" Then
        '                                        flowDirProp.SetValue(c, [Enum].Parse(flowDirProp.PropertyType, "RightToLeft"), Nothing)
        '                                    ElseIf Not makeRtl AndAlso current.ToString() = "RightToLeft" Then
        '                                        flowDirProp.SetValue(c, [Enum].Parse(flowDirProp.PropertyType, "LeftToRight"), Nothing)
        '                                    End If
        '                                End If
        '                                ' Try invoke RefreshRtl if provided by control
        '                                Dim m = c.GetType().GetMethod("RefreshRtl")
        '                                If m IsNot Nothing Then
        '                                    m.Invoke(c, Nothing)
        '                                Else
        '                                    c.PerformLayout()
        '                                End If
        '                            Catch
        '                            End Try

        '                        ElseIf TypeOf c Is SplitContainer Then
        '                            Dim sc = DirectCast(c, SplitContainer)
        '                            ' RightToLeft already set above; ensure panels re-layout
        '                            sc.PerformLayout()
        '                            ' Optional: could swap Panel1/Panel2 content for full semantic mirroring (not done automatically).

        '                        End If
        '                    End If
        '                End If

        '                For Each child As Control In c.Controls
        '                    stack.Push(child)
        '                Next
        '            End While
        '        End Sub

        '' --- REMOVED: GetAllTabControls (no longer used after refactor) ---
        '' (Delete the previous GetAllTabControls function from the file.)
        '                           makeRtl As Boolean,
        '                           Optional overrideExisting As Boolean = True,
        '                           Optional excludeTypes As IEnumerable(Of Type) = Nothing)

        '    If root Is Nothing Then Exit Sub
        '    Dim desired = If(makeRtl, RightToLeft.Yes, RightToLeft.No)

        '    Dim excluded As HashSet(Of Type) = Nothing
        '    If excludeTypes IsNot Nothing Then
        '        excluded = New HashSet(Of Type)(excludeTypes)
        '    End If

        '    Dim stack As New Stack(Of Control)
        '    stack.Push(root)

        '    While stack.Count > 0
        '        Dim c = stack.Pop()

        '        If excluded Is Nothing OrElse Not excluded.Contains(c.GetType()) Then
        '            If overrideExisting OrElse c.RightToLeft = RightToLeft.Inherit Then
        '                ' Skip if control does not expose a settable RightToLeft (rare custom control cases)
        '                Try
        '                    c.RightToLeft = desired
        '                Catch
        '                End Try

        '                ' Special cases
        '                If TypeOf c Is Form Then
        '                    Dim f = DirectCast(c, Form)
        '                    If f.RightToLeftLayout <> makeRtl Then
        '                        f.RightToLeftLayout = makeRtl
        '                    End If
        '                ElseIf TypeOf c Is DataGridView Then
        '                    Dim dgv = DirectCast(c, DataGridView)
        '                    ' Align column headers / default cell style if needed
        '                    For Each col As DataGridViewColumn In dgv.Columns
        '                        If makeRtl Then
        '                            If col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.NotSet Then
        '                                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        '                            End If
        '                        Else
        '                            If col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight Then
        '                                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        '                            End If
        '                        End If
        '                    Next
        '                ElseIf TypeOf c Is ToolStrip Then
        '                    Dim ts = DirectCast(c, ToolStrip)
        '                    ts.RightToLeft = desired
        '                End If
        '            End If
        '        End If

        '        ' Push children
        '        For Each child As Control In c.Controls
        '            stack.Push(child)
        '        Next
        '    End While
        'End Sub

        ' NEW: Collect all TabControls in the form hierarchy
        Private Function GetAllTabControls(root As Control) As IEnumerable(Of TabControl)
            Dim list As New List(Of TabControl)
            Dim stack As New Stack(Of Control)
            stack.Push(root)
            While stack.Count > 0
                Dim c = stack.Pop()
                Dim tc = TryCast(c, TabControl)
                If tc IsNot Nothing Then list.Add(tc)
                For Each child As Control In c.Controls
                    stack.Push(child)
                Next
            End While
            Return list
        End Function



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


        ' CHANGE: Always perform layout for any FlowLayoutPanel / CFlowLayout while still deferring others
        ' Rationale: Previously only the root received performLayout:=True; flow panels stayed suspended (no reflow after RTL / text changes).
        ' This forces a layout pass on flow-based containers to update child order/direction (especially after RTL switch).
        Private Sub ResumeAllLayout(root As Control, performLayout As Boolean)
            For Each c As Control In root.Controls
                Dim childNeedsLayout As Boolean =
                    TypeOf c Is FlowLayoutPanel OrElse TypeOf c Is CFlowLayout
                ' Propagate True only for flow panels (or if explicitly requested upstream)
                ResumeAllLayout(c, performLayout:=childNeedsLayout)
            Next

            Dim isFlow As Boolean = TypeOf root Is FlowLayoutPanel OrElse TypeOf root Is CFlowLayout
            Dim doLayout As Boolean = performLayout OrElse isFlow
            root.ResumeLayout(doLayout)

            ' Extra safety: explicit PerformLayout for flow containers when we requested layout.
            If doLayout AndAlso isFlow Then
                root.PerformLayout()
            End If
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