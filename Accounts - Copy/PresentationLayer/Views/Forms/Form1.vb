Public Class Form1

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

    End Sub

    Private Sub CTextBox1_TextChanged(sender As Object, e As EventArgs) Handles CTextBox1.TextChanged

    End Sub

    Private Sub btnQuit_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnQuit.ClickButtonArea

    End Sub

    Private Sub btnTranslate_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnTranslate.ClickButtonArea
        If Not (txtOldNote.Text Is Nothing OrElse txtOldNote.Text = "") Then

        End If
    End Sub

End Class