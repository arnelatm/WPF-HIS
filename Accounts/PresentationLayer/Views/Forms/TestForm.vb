Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

Public Class TestForm
    Private Sub TestForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PublishClickedButton(ButtonClicked.Edit)
        CTextBox1.DisplayOnly = False
        CTextBox2.DisplayOnly = False
        CTextBox2.Editable = True
        CTextBox2.ReadOnly = False
        CTextBox2.EditingMode = True
    End Sub

    Private Sub TestClick() Handles btnEdit.Click
        TurnEditOn()
    End Sub

    Private Sub TurnEditOn()
        CTextBox2.DisplayOnly = False
        'CTextBox2.Editable = True
        CTextBox2.ReadOnly = False
        CTextBox2.EditingMode = True
        CTextBox2.ShortcutsEnabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TurnEditOn()
    End Sub
End Class