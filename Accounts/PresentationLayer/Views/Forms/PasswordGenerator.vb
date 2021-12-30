Public Class PasswordGenerator
    Private Sub btnQuit_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnQuit.ClickButtonArea
        Close()
    End Sub

    Private Sub btnGenerate_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnGenerate.ClickButtonArea
        Dim user = txtUserName.Text.Trim()
        If user Is Nothing OrElse user = "" Then
            MessageBox.Show("You must enter a user name for this to work.")
        Else
            Dim password As String = ""
            Dim userBase As String = user
            password += Strings.Right(user, 1).ToUpper()
            password += Strings.Left(user, 1).ToLower()
            userBase += "24680"
            For i = 1 To 6
                password += (Asc(Mid(userBase, i, 1)) Mod 10).ToString()                
            Next
            txtPassword.Text = password
            txtPassword.Refresh()
        End If
    End Sub
End Class
