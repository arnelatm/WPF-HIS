Imports System.IO
Imports System.Windows.Forms

Public Class FrmLogViewer
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub LoadLogs(logFilePath As String)
        If File.Exists(logFilePath) Then
            Dim logContent As String = File.ReadAllText(logFilePath)
            ' Assuming you have a TextBox or a RichTextBox named txtLogs
            txtLogs.Text = logContent
        Else
            ' Assuming you have a Label or similar control to show a message
            MessageBox.Show("Log file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class