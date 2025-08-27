Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace Services.Ui

    ''' <summary>
    ''' WinForms UI performance helpers:
    '''  - Suspend/resume redraw recursively (flicker reduction for batch updates)
    '''  - Enable double buffering selectively
    '''  - Bulk operations wrapper (WithRedrawSuspended)
    ''' </summary>
    Public NotInheritable Class UiPerformanceHelper
        Private Sub New()
        End Sub

        <DllImport("user32.dll")>
        Private Shared Function SendMessage(hWnd As IntPtr, msg As Integer, wParam As Boolean, lParam As Integer) As IntPtr
        End Function
        Private Const WM_SETREDRAW As Integer = &HB

        ''' <summary>
        ''' Execute an action while redraw/layout is suspended for the entire subtree.
        ''' Safe even if an exception occurs.
        ''' </summary>
        Public Shared Sub WithRedrawSuspended(root As Control, action As Action)
            If root Is Nothing Then
                action?.Invoke()
                Return
            End If
            Try
                SuspendAll(root)
                action?.Invoke()
            Finally
                ResumeAll(root)
            End Try
        End Sub

        Public Shared Sub EnableDoubleBufferRecursive(root As Control, Optional exclude As Func(Of Control, Boolean) = Nothing)
            If root Is Nothing Then Return
            If exclude Is Nothing OrElse Not exclude(root) Then
                EnableDoubleBuff(root)
            End If
            For Each child As Control In root.Controls
                EnableDoubleBufferRecursive(child, exclude)
            Next
        End Sub

        Public Shared Sub EnableDoubleBuff(ctrl As Control)
            If ctrl Is Nothing Then Return
            ' Skip certain controls (text boxes selection issues, huge images)
            If TypeOf ctrl Is TextBoxBase Then Return
            If TypeOf ctrl Is PictureBox Then
                Dim pb = DirectCast(ctrl, PictureBox)
                If pb.Width * pb.Height > 800000 Then Return
            End If
            Dim t = ctrl.GetType()
            Dim pi = t.GetProperty("DoubleBuffered", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic)
            If pi IsNot Nothing AndAlso pi.CanWrite Then
                Try : pi.SetValue(ctrl, True, Nothing) : Catch : End Try
            End If
            Dim dgv = TryCast(ctrl, DataGridView)
            If dgv IsNot Nothing Then dgv.EnableHeadersVisualStyles = False
        End Sub

        Private Shared Sub SuspendAll(c As Control)
            If c.IsHandleCreated Then SendMessage(c.Handle, WM_SETREDRAW, False, 0)
            c.SuspendLayout()
            For Each child As Control In c.Controls
                SuspendAll(child)
            Next
        End Sub

        Private Shared Sub ResumeAll(c As Control)
            For Each child As Control In c.Controls
                ResumeAll(child)
            Next
            c.ResumeLayout(False)
            If c.IsHandleCreated Then SendMessage(c.Handle, WM_SETREDRAW, True, 0)
            c.Invalidate()
        End Sub

    End Class
End Namespace