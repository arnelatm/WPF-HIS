Imports System.Windows.Forms

Public Class CDgvCustomButtonColumn
    Inherits DataGridViewButtonColumn

    Public Sub New()
        UseColumnTextForButtonValue = False
    End Sub

    Public Sub Click()
        If Text = "1" Then
            Text = "2"
        ElseIf Text = "2" Then
            Text = "3"
        Else
            Text = "1"
        End If
    End Sub



End Class
