Imports System.Windows.Forms
Imports AATM.Libraries.GlobalResources

Public Class CTabPage
    Inherits TabPage

    Public Sub New()
        BackgroundImage = Images.YellowGradientBackgroundLarge
        BackgroundImageLayout = ImageLayout.Stretch
        RightToLeft = RightToLeft.Inherit
        DoubleBuffered = True
    End Sub

    'Private Sub CTabPage_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
    '    If CultureInfo.CurrentCulture.TextInfo.IsRightToLeft And BackgroundImage IsNot Nothing Then
    '        ' this routine is needed for righttoleft languages because the backgroundimage is
    '        ' not redrawn for this culture.  So need to manually repaint the background form with
    '        ' this procedure.
    '        Dim r As Rectangle = ClientRectangle
    '        e.Graphics.DrawImage(BackgroundImage, r)
    '    End If
    'End Sub

End Class