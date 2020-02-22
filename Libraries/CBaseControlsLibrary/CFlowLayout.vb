Imports System.Drawing
Imports System.Windows.Forms

Public Class CFlowLayout
    Inherits FlowLayoutPanel

    Public Sub New()
        MyBase.New()

        RightToLeft = RightToLeft.Inherit
        BackColor = System.Drawing.Color.Transparent
        DoubleBuffered = True
        '    'BackgroundImage = CType(Resources.GetObject("floMainDisplay.BackgroundImage"), System.Drawing.Image)
        '    'BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch

    End Sub

    'Private Sub CFlowLayout1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
    '    Dim pnt As Point
    '    pnt = New Point(Me.Location)
    '    If BackgroundImage IsNot Nothing then
    '        e.Graphics.DrawImage(BackgroundImage, pnt)
    '    End If
    'End Sub

End Class