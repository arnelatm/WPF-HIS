Imports System.Drawing
Imports System.Windows.Forms

Public Class CustomCheckBox
    Inherits CheckBox

    Public Sub New()
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
    End Sub

    Protected Overrides Sub OnPaint(ByVal pevent As PaintEventArgs)
        MyBase.OnPaint(pevent)

        Using fillBrush As New SolidBrush(If(Me.Checked, Color.Blue, Color.Red))
            pevent.Graphics.FillRectangle(fillBrush, New Rectangle(0, 0, 16, 16))
        End Using
    End Sub
End Class

