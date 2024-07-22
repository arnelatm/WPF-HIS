Imports System.ComponentModel
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

    <Category("Custom Properties")>
    <DefaultValue(CType(Nothing, String))>
    <Description("Security Key to use for this control.")>
    <Browsable(True)>
    Public Property SecurityKey As String

    <Category("Custom Properties")>
    <DefaultValue(False)>
    <Description("Set to True to specify that this control is Read Only .")>
    <Browsable(True)>
    Public Property DisplayOnly As Boolean

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