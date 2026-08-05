Imports System.ComponentModel
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

    <Category("Custom Properties")>
    <DefaultValue(CType(Nothing, String))>
    <Description("Security Key to use for this control.")>
    <Browsable(True)>
    Public Property SecurityKey As String

    Public Sub SetRightToLeftLayoutSafe(useRightToLeftLayout As Boolean)
        Dim originalSelectedIndex = SelectedIndex
        Dim desiredRightToLeft = If(useRightToLeftLayout, RightToLeft.Yes, RightToLeft.No)

        SuspendLayout()
        Try
            EnsureSelectedTab()

            If RightToLeftLayout <> useRightToLeftLayout Then
                RightToLeftLayout = useRightToLeftLayout
            End If

            If RightToLeft <> desiredRightToLeft Then
                RightToLeft = desiredRightToLeft
            End If

            RestoreSelectedTab(originalSelectedIndex)
        Finally
            ResumeLayout()
        End Try
    End Sub

    Private Sub CTabControl_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        If CultureInfo.CurrentCulture.TextInfo.IsRightToLeft Then
            ' this routine is needed for righttoleft languages because the backgroundimage is
            ' not redrawn for this culture.  So need to manually repaint the background form with
            ' this procedure.
            SetRightToLeftLayoutSafe(True)
            If BackgroundImage IsNot Nothing Then
                Dim r As Rectangle = ClientRectangle
                e.Graphics.DrawImage(BackgroundImage, r)
            End If
        Else
            SetRightToLeftLayoutSafe(False)
        End If
    End Sub

    Private Sub EnsureSelectedTab()
        If TabPages.Count > 0 AndAlso (SelectedIndex < 0 OrElse SelectedIndex >= TabPages.Count) Then
            SelectedIndex = 0
        End If
    End Sub

    Private Sub RestoreSelectedTab(originalSelectedIndex As Integer)
        If originalSelectedIndex >= 0 AndAlso originalSelectedIndex < TabPages.Count AndAlso
           SelectedIndex <> originalSelectedIndex Then
            SelectedIndex = originalSelectedIndex
        End If
    End Sub

End Class
