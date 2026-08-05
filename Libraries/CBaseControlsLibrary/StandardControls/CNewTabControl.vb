Imports System.Drawing
Imports System.Windows.Forms

Partial Class CNewTabControl
    Inherits TabControl

    Private Sub New()
        MyBase.New()
        Dim myPage1 = New CTabPage
        Dim myPage2 = New CTabPage
        Controls.Add(myPage1)
        Controls.Add(myPage2)
        Location = New Point(0, 0)
        SelectedIndex = 0
        Size = New Size(200, 100)
        TabIndex = 0
    End Sub

End Class