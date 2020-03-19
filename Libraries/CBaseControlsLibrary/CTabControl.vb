Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms

Public Class CTabControl
    Inherits TabControl

    'Public OverLoads Property TabPages As CTabPageCollection

    Public Sub New()
        MyBase.New()
        Width = 200
        Height = 100
    End Sub

    Private Sub CTabControl_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        If CultureInfo.CurrentCulture.TextInfo.IsRightToLeft And BackgroundImage IsNot Nothing Then
            ' this routine is needed for righttoleft languages because the backgroundimage is
            ' not redrawn for this culture.  So need to manually repaint the background form with
            ' this procedure.
            RightToLeftLayout = True
            RightToLeft = RightToLeft.Yes
            Dim r As Rectangle = ClientRectangle
            e.Graphics.DrawImage(BackgroundImage, r)
        Else
            RightToLeftLayout = False
            RightToLeft = RightToLeft.No
        End If
    End Sub

End Class