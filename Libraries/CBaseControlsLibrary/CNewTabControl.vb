Imports System.Drawing
Imports System.Windows.Forms

Partial Class CNewTabControl
    Inherits TabControl

    Private Sub New()
        MyBase.New()
        Dim myPage1 = New CTabPage
        Dim myPage2 = New CTabPage
        Me.Controls.Add(myPage1)
        Me.Controls.Add(myPage2)
        Me.Location = New Point(0, 0)
        Me.SelectedIndex = 0
        Me.Size = New Size(200, 100)
        Me.TabIndex = 0
    End Sub

End Class