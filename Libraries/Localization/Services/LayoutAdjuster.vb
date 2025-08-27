Imports System.Globalization
Imports System.Windows.Forms

Namespace Services
    ' Purpose:
    '   Perform ONLY structural / sizing / alignment adjustments.
    '   It NO LONGER flips RightToLeft or RightToLeftLayout on the form or child controls.
    '   RTL flipping is deferred (and done once) inside FormTranslationService after all text/layout changes
    '   while drawing is still suspended, reducing flicker and multiple handle recreations.
    '
    ' Usage:
    '   FormTranslationService:
    '       1. Translate text.
    '       2. LayoutAdjuster.AdjustFormLayout(form, CultureInfo.CurrentCulture.TextInfo.IsRightToLeft)
    '       3. Apply font.
    '       4. ApplyRtlState() (sets RightToLeft / RightToLeftLayout once).
    '
    ' Optional:
    '   If a specific control requires intrinsic RTL property changes for sizing logic
    '   (e.g., owner-drawn layout that depends on RightToLeft), pass applyDirectionalProperties:=True.
    '   Default is False to avoid flicker.
    Public NotInheritable Class LayoutAdjuster
        Private Sub New()
        End Sub

        Public Shared Sub AdjustFormLayout(root As Form,
                                           Optional isRtl As Boolean? = Nothing,
                                           Optional applyDirectionalProperties As Boolean = False)
            If root Is Nothing Then Return

            ' Determine intended RTL status (but do NOT directly set root.RightToLeft/Layout here)
            Dim targetRtl = If(isRtl.HasValue, isRtl.Value, CultureInfo.CurrentCulture.TextInfo.IsRightToLeft)

            ' Breadth-first traversal for predictable order
            Dim queue As New Queue(Of Control)
            queue.Enqueue(root)

            While queue.Count > 0
                Dim c = queue.Dequeue()

                ' (1) Numeric custom textbox alignment (no handle recreation needed)
                If IsCustomNumericTextBox(c) Then
                    ApplyNumericAlignment(c, targetRtl)
                End If

                ' (2) Direction-sensitive tweaks that DO NOT force setting RightToLeft on parents
                '     Only run if caller explicitly allows (rare cases).
                If applyDirectionalProperties Then
                    ApplyOptionalDirectionalHints(c, targetRtl)
                End If

                ' Enqueue children
                For Each child As Control In c.Controls
                    queue.Enqueue(child)
                Next
            End While
        End Sub

#Region "Helpers"

        Private Shared Function IsCustomNumericTextBox(ctrl As Control) As Boolean
            If ctrl Is Nothing Then Return False
            ' Heuristic: custom control named CTextBox with Boolean property ValueIsNumeric = True
            If Not ctrl.GetType().Name.Equals("CTextBox", StringComparison.OrdinalIgnoreCase) Then Return False
            Try
                Dim prop = ctrl.GetType().GetProperty("ValueIsNumeric")
                If prop IsNot Nothing Then
                    Dim raw = prop.GetValue(ctrl, Nothing)
                    If TypeOf raw Is Boolean AndAlso CBool(raw) Then Return True
                End If
            Catch
            End Try
            Return False
        End Function

        Private Shared Sub ApplyNumericAlignment(ctrl As Control, targetRtl As Boolean)
            Try
                Dim desired = If(targetRtl, HorizontalAlignment.Left, HorizontalAlignment.Right)
                ' If the custom control inherits TextBoxBase we can cast safely
                Dim tb = TryCast(ctrl, TextBox)
                If tb IsNot Nothing Then
                    If tb.TextAlign <> desired Then tb.TextAlign = desired
                    Return
                End If
                ' Fallback: reflect TextAlign property
                Dim taProp = ctrl.GetType().GetProperty("TextAlign")
                If taProp IsNot Nothing AndAlso
                   taProp.CanWrite AndAlso
                   taProp.PropertyType Is GetType(HorizontalAlignment) Then
                    Dim current = DirectCast(taProp.GetValue(ctrl, Nothing), HorizontalAlignment)
                    If current <> desired Then taProp.SetValue(ctrl, desired, Nothing)
                End If
            Catch
                ' Swallow – alignment is cosmetic.
            End Try
        End Sub

        ' Only used if applyDirectionalProperties:=True. Keeps it isolated.
        Private Shared Sub ApplyOptionalDirectionalHints(ctrl As Control, targetRtl As Boolean)
            ' NOTE: We intentionally avoid setting RightToLeft / RightToLeftLayout on the root form here.
            ' For certain child controls (TreeView, TabControl) some layout metrics may depend on RTL.
            ' If you truly must pre-set them before translation, enable via the optional flag.
            Try
                If TypeOf ctrl Is TreeView Then
                    Dim tv = DirectCast(ctrl, TreeView)
                    tv.SuspendLayout()
                    tv.RightToLeft = If(targetRtl, RightToLeft.Yes, RightToLeft.No)
                    ' TreeView has a RightToLeftLayout property only on newer frameworks; guard via reflection.
                    Dim rtlLayoutProp = tv.GetType().GetProperty("RightToLeftLayout")
                    rtlLayoutProp?.SetValue(tv, targetRtl, Nothing)
                    tv.ResumeLayout()
                ElseIf TypeOf ctrl Is TabControl OrElse
                       ctrl.GetType().Name.Equals("CTabControl", StringComparison.OrdinalIgnoreCase) Then
                    ctrl.SuspendLayout()
                    ctrl.RightToLeft = If(targetRtl, RightToLeft.Yes, RightToLeft.No)
                    Dim rtlLayoutProp = ctrl.GetType().GetProperty("RightToLeftLayout")
                    rtlLayoutProp?.SetValue(ctrl, targetRtl, Nothing)
                    ctrl.ResumeLayout()
                End If
            Catch
                ' Non-critical; ignore failures.
            End Try
        End Sub

#End Region

    End Class
End Namespace

'Imports System.Globalization
'Imports System.Windows.Forms
'Imports AATM.Libraries.GlobalFuncNSub

'Namespace Services
'    Public NotInheritable Class LayoutAdjuster
'        Private Sub New()
'        End Sub

'        Public Shared Sub AdjustFormLayout(root As Form)
'            If root Is Nothing Then Return

'            Dim isRtl = CultureInfo.CurrentCulture.TextInfo.IsRightToLeft
'            GlobalVariables.RightToLeftLayout = isRtl
'            root.RightToLeft = If(isRtl, RightToLeft.Yes, RightToLeft.No)
'            root.RightToLeftLayout = isRtl

'            Dim all As New Queue(Of Control)
'            all.Enqueue(root)
'            While all.Count > 0
'                Dim c = all.Dequeue()

'                ' TreeView orientation
'                If TypeOf c Is TreeView Then
'                    Dim tv = DirectCast(c, TreeView)
'                    tv.SuspendLayout()
'                    tv.RightToLeftLayout = isRtl
'                    tv.RightToLeft = If(isRtl, RightToLeft.Yes, RightToLeft.No)
'                    tv.ResumeLayout()
'                End If

'                ' TabControl / custom tab control
'                If TypeOf c Is TabControl OrElse c.GetType().Name.Equals("CTabControl", StringComparison.OrdinalIgnoreCase) Then
'                    c.SuspendLayout()
'                    c.RightToLeft = If(isRtl, RightToLeft.Yes, RightToLeft.No)
'                    Dim rtlProp = c.GetType().GetProperty("RightToLeftLayout")
'                    rtlProp?.SetValue(c, isRtl, Nothing)
'                    c.ResumeLayout()
'                End If

'                ' Numeric CTextBox alignment (ValueIsNumeric = True)
'                If c.GetType().Name.Equals("CTextBox", StringComparison.OrdinalIgnoreCase) Then
'                    Dim valProp = c.GetType().GetProperty("ValueIsNumeric")
'                    Dim isNumeric = False
'                    If valProp IsNot Nothing Then
'                        Dim raw = valProp.GetValue(c, Nothing)
'                        If TypeOf raw Is Boolean Then isNumeric = CBool(raw)
'                    End If
'                    If isNumeric Then
'                        ' Try direct cast to TextBox (if custom control inherits TextBox)
'                        Dim stdTb = TryCast(c, TextBox)
'                        Dim alignValue = If(c.RightToLeft = RightToLeft.Yes,
'                                            HorizontalAlignment.Left,
'                                            HorizontalAlignment.Right)
'                        If stdTb IsNot Nothing Then
'                            stdTb.TextAlign = alignValue
'                        Else
'                            ' Fallback: reflect a writable TextAlign property of type HorizontalAlignment
'                            Dim txtAlignProp = c.GetType().GetProperty("TextAlign")
'                            If txtAlignProp IsNot Nothing AndAlso
'                               txtAlignProp.CanWrite AndAlso
'                               txtAlignProp.PropertyType Is GetType(HorizontalAlignment) Then
'                                txtAlignProp.SetValue(c, alignValue, Nothing)
'                            End If
'                        End If
'                    End If
'                End If

'                For Each child As Control In c.Controls
'                    all.Enqueue(child)
'                Next
'            End While
'        End Sub
'    End Class
'End Namespace