Imports System.Threading
Imports System.Windows.Forms

Public Class MainForm

    Public Sub New()

        Application.EnableVisualStyles()
        'Application.SetCompatibleTextRenderingDefault(false)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub Button1Click(sender As Object, e As EventArgs) Handles button1.Click
        Dim result As Object = WaitWindow.Show(AddressOf Me.WorkerMethod)
        MessageBox.Show(result.ToString())
    End Sub

    Private Sub Button2Click(sender As Object, e As EventArgs) Handles button2.Click
        Dim result As Object = WaitWindow.Show(AddressOf Me.WorkerMethod, "Watch out! Stuff is happening!")
        MessageBox.Show(result.ToString())
    End Sub

    Private Sub Button3Click(sender As Object, e As EventArgs) Handles button3.Click
        Dim result As Object = WaitWindow.Show(AddressOf Me.ProgressWorkerMethod, "Please wait...   0%")
        MessageBox.Show(result.ToString())
    End Sub

    Private Sub Button4Click(sender As Object, e As EventArgs) Handles button4.Click
        Dim result As Object = WaitWindow.Show(AddressOf Me.WorkerMethod, Nothing, Me.textBox1.Text)
        MessageBox.Show(result.ToString())
    End Sub

    Private Sub Button5Click(sender As Object, e As EventArgs) Handles button5.Click
        Try
            Dim result As Object = WaitWindow.Show(AddressOf Me.ErroringWorkerMethod)
            MessageBox.Show(result.ToString())
        Catch ex As Exception
            MessageBox.Show(String.Concat("An Exception occured.", Environment.NewLine, ex.Message, Environment.NewLine,
                                          ex.StackTrace))
            Debugger.Break()
        End Try
    End Sub

    Private Sub Button6Click(sender As Object, e As EventArgs) Handles button6.Click
        Dim result As Object = WaitWindow.Show(AddressOf Me.CancelingWorkerMethod)

        If result IsNot Nothing Then
            MessageBox.Show(result.ToString())
        Else
            MessageBox.Show("No result so we must have canceled the process.")
        End If
    End Sub

    Private Sub WorkerMethod(sender As Object, e As WaitWindowEventArgs)
        Thread.Sleep(4000)
        'System.Threading.Thread.Sleep(0)

        'MessageBox.Show("please wait for me!")

        If e.Arguments.Count > 0 Then
            e.Result = e.Arguments(0).ToString()
        Else
            e.Result = "Hello World"
        End If
    End Sub

    Private Sub ProgressWorkerMethod(sender As Object, e As WaitWindowEventArgs)
        For progress = 1 To 100
            Thread.Sleep(20)
            e.Window.Message = String.Format("Please wait ... {0}%", progress.ToString().PadLeft(3))
        Next

        If e.Arguments.Count > 0 Then
            e.Result = e.Arguments(0).ToString()
        Else
            e.Result = "Hello World"
        End If
    End Sub

    Private Sub ErroringWorkerMethod(sender As Object, e As WaitWindowEventArgs)
        Thread.Sleep(2000)
        Throw New ApplicationException("Something went wrong here")
    End Sub

    Private Sub CancelingWorkerMethod(sender As Object, e As WaitWindowEventArgs)
        Thread.Sleep(2000)
        e.Window.Cancel()
        Thread.Sleep(2000)
        e.Result = "Hello World.  All done"
    End Sub

End Class