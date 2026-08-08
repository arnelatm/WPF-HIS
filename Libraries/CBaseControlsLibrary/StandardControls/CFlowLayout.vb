Imports System.Windows.Forms

Imports System.ComponentModel

Public Class CFlowLayout
    Inherits FlowLayoutPanel

    <Browsable(False)>
    Public Property PreserveLanguageLayout As Boolean

    Public Sub New()
        MyBase.New()

        RightToLeft = RightToLeft.Inherit
        BackColor = System.Drawing.Color.Transparent
        DoubleBuffered = True
        '    'BackgroundImage = CType(Resources.GetObject("floMainDisplay.BackgroundImage"), System.Drawing.Image)
        '    'BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch

    End Sub

    Public Sub ApplyLanguageLayout(targetRightToLeft As RightToLeft)
        If PreserveLanguageLayout Then
            Return
        End If

        If FlowDirection = FlowDirection.TopDown OrElse
           FlowDirection = FlowDirection.BottomUp Then
            If RightToLeft <> targetRightToLeft Then
                RightToLeft = targetRightToLeft
            End If
        Else
            ' RightToLeft and FlowDirection both reverse horizontal placement. Keep
            ' one source of mirroring so inherited RTL does not reverse the row twice.
            If FlowDirection <> FlowDirection.LeftToRight Then
                FlowDirection = FlowDirection.LeftToRight
            End If
            If RightToLeft <> targetRightToLeft Then
                RightToLeft = targetRightToLeft
            End If
        End If
    End Sub

    'Private Sub CFlowLayout1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
    '    Dim pnt As Point
    '    pnt = New Point(Me.Location)
    '    If BackgroundImage IsNot Nothing then
    '        e.Graphics.DrawImage(BackgroundImage, pnt)
    '    End If
    'End Sub

End Class
