Imports System.ComponentModel
Imports System.Windows.Forms

Public Class MyTabControl
    Inherits TabControl

    'Required by the Windows Form Designer
    Private components As IContainer

    Public Sub New()
        'MyBase.New()
        Me.SuspendLayout()
        Me.TabPage1 = New CTabPage()
        Me.TabPage2 = New CTabPage()

        '
        'TabPage1
        '
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
End Class