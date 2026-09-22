Imports System.Windows.Forms

Public Class ErrLogger

    Public Shared Sub LogError(e As Exception, Optional ByVal logOnly As Boolean = False)

        Dim el As New ErrorLogger
        el.WriteToErrorLog(e.Message, e.StackTrace, "Error")

        If Not logOnly Then
            MessageBox.Show(e.Message, "Unhandled Error!")
        End If
    End Sub

End Class
