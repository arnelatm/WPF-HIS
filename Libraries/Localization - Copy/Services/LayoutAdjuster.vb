Imports System.Globalization
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub

Namespace AATM.Libraries.Localization.Services
    Public NotInheritable Class LayoutAdjuster
        Private Sub New()
        End Sub

        Public Shared Sub AdjustFormLayout(root As Form)
            If root Is Nothing Then Return

            Dim isRtl = CultureInfo.CurrentCulture.TextInfo.IsRightToLeft
            GlobalVariables.RightToLeftLayout = isRtl
            root.RightToLeft = If(isRtl, RightToLeft.Yes, RightToLeft.No)
            root.RightToLeftLayout = isRtl

            Dim all As New Queue(Of Control)
            all.Enqueue(root)
            While all.Count > 0
                Dim c = all.Dequeue()

                ' TreeView orientation
                If TypeOf c Is TreeView Then
                    Dim tv = DirectCast(c, TreeView)
                    tv.SuspendLayout()
                    tv.RightToLeftLayout = isRtl
                    tv.RightToLeft = If(isRtl, RightToLeft.Yes, RightToLeft.No)
                    tv.ResumeLayout()
                End If

                ' TabControl / custom tab control
                If TypeOf c Is TabControl OrElse c.GetType().Name.Equals("CTabControl", StringComparison.OrdinalIgnoreCase) Then
                    c.SuspendLayout()
                    c.RightToLeft = If(isRtl, RightToLeft.Yes, RightToLeft.No)
                    Dim rtlProp = c.GetType().GetProperty("RightToLeftLayout")
                    rtlProp?.SetValue(c, isRtl, Nothing)
                    c.ResumeLayout()
                End If

                ' Numeric CTextBox alignment (ValueIsNumeric = True)
                If c.GetType().Name.Equals("CTextBox", StringComparison.OrdinalIgnoreCase) Then
                    Dim valProp = c.GetType().GetProperty("ValueIsNumeric")
                    Dim isNumeric = False
                    If valProp IsNot Nothing Then
                        Dim raw = valProp.GetValue(c, Nothing)
                        If TypeOf raw Is Boolean Then isNumeric = CBool(raw)
                    End If
                    If isNumeric Then
                        ' Try direct cast to TextBox (if custom control inherits TextBox)
                        Dim stdTb = TryCast(c, TextBox)
                        Dim alignValue = If(c.RightToLeft = RightToLeft.Yes,
                                            HorizontalAlignment.Left,
                                            HorizontalAlignment.Right)
                        If stdTb IsNot Nothing Then
                            stdTb.TextAlign = alignValue
                        Else
                            ' Fallback: reflect a writable TextAlign property of type HorizontalAlignment
                            Dim txtAlignProp = c.GetType().GetProperty("TextAlign")
                            If txtAlignProp IsNot Nothing AndAlso
                               txtAlignProp.CanWrite AndAlso
                               txtAlignProp.PropertyType Is GetType(HorizontalAlignment) Then
                                txtAlignProp.SetValue(c, alignValue, Nothing)
                            End If
                        End If
                    End If
                End If

                For Each child As Control In c.Controls
                    all.Enqueue(child)
                Next
            End While
        End Sub
    End Class
End Namespace