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

        If Me.Checked Then
            pevent.Graphics.FillRectangle(New SolidBrush(Color.Blue), New Rectangle(0, 0, 16, 16))
        Else
            pevent.Graphics.FillRectangle(New SolidBrush(Color.Red), New Rectangle(0, 0, 16, 16))
        End If
    End Sub
End Class

