Imports System.ComponentModel
Imports System.Threading
Imports System.Windows.Forms

Public Class TestForm2

    Public Sub New()

        Application.EnableVisualStyles()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub Button1Click(sender As Object, e As EventArgs) Handles button1.Click
        'Dim result As Object = WaitWindow.Show(AddressOf Me.WorkerMethod)
        MessageBox.Show(lblMessage.ToString())
        If BackgroundWorker1.IsBusy <> True Then
            ' Start the asynchronous operation.
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub Button2Click(sender As Object, e As EventArgs) Handles button2.Click
        'Dim result As Object = WaitWindow.Show(AddressOf Me.WorkerMethod, "Watch out! Stuff is happening!")
        MessageBox.Show(lblMessage.ToString())
    End Sub

    Private Sub Button3Click(sender As Object, e As EventArgs) Handles button3.Click
        'Dim result As Object = WaitWindow.Show(AddressOf Me.ProgressWorkerMethod, "Please wait...   0%")
        MessageBox.Show(lblMessage.ToString())
    End Sub

    Private Sub Button4Click(sender As Object, e As EventArgs) Handles button4.Click
        'Dim result As Object = WaitWindow.Show(AddressOf Me.WorkerMethod, Nothing, Me.textBox1.Text)
        MessageBox.Show(lblMessage.ToString())
    End Sub

    Private Sub Button5Click(sender As Object, e As EventArgs) Handles button5.Click
        'Try
        '    Dim result As Object = WaitWindow.Show(AddressOf Me.ErroringWorkerMethod)
        '    MessageBox.Show(result.ToString())
        'Catch ex As Exception
        '    MessageBox.Show(String.Concat("An Exception occured.", Environment.NewLine, ex.Message, Environment.NewLine, ex.StackTrace))
        '    System.Diagnostics.Debugger.Break()
        'End Try
    End Sub

    Private Sub Button6Click(sender As Object, e As EventArgs) Handles button6.Click
        'Dim result As Object = WaitWindow.Show(AddressOf Me.CancelingWorkerMethod)

        'If result IsNot Nothing Then
        '    MessageBox.Show(result.ToString())
        'Else
        '    MessageBox.Show("No result so we must have canceled the process.")
        'End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim worker = CType(sender, BackgroundWorker)
        For i = 1 To 100
            If (worker.CancellationPending = True) Then
                e.Cancel = True
                Exit For
            Else
                ' Perform a time consuming operation and report progress.
                Thread.Sleep(50)
                worker.ReportProgress(i)
                ProgressBar1.Increment(1)
            End If
        Next
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) _
        Handles BackgroundWorker1.ProgressChanged
        lblMessage.Text = (e.ProgressPercentage.ToString() + "%")
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) _
        Handles BackgroundWorker1.RunWorkerCompleted
        If e.Cancelled = True Then
            lblMessage.Text = "Canceled!"
        ElseIf e.Error IsNot Nothing Then
            lblMessage.Text = "Error: " & e.Error.Message
        Else
            lblMessage.Text = "Done!"
        End If
    End Sub

End Class