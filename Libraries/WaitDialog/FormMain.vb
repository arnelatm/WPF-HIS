Imports System.Threading
Imports System.Windows.Forms
Imports AATM.Libraries.BgwGeneric

Public Class FormMain
    Private ReadOnly fileWorker As BackgroundWorker(Of String(), String, List(Of FileData))
    Private ReadOnly showWaitForm As BackgroundWorker(Of String)
    Private result As String()
    Private files As String()

    Public Sub New()

        'System.Windows.Forms.Application.EnableVisualStyles()
        'Application.SetCompatibleTextRenderingDefault(False)
        'Application.EnableVisualStyles()
        ' This call is required by the designer.
        InitializeComponent()
        InitializeFileArray()

        fileWorker = New BackgroundWorker(Of String(), String, List(Of FileData))
        showWaitForm = New BackgroundWorker(Of String)
        AddHandler fileWorker.DoWork, AddressOf fileWorker_DoWorkHandler
        AddHandler fileWorker.ProgressChanged, AddressOf fileWorker_ProgressChangedHandler
        AddHandler fileWorker.RunWorkerCompleted, AddressOf fileWorker_RunWorkerCompletedHandler
        AddHandler showWaitForm.DoWork, AddressOf showWaitForm_DoWorkHandler
        AddHandler showWaitForm.RunWorkerCompleted, AddressOf showWaitForm_RunWorkerCompletedHandler

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub SetProgressBarStyleToMarquee()
        progressBar.Style = ProgressBarStyle.Marquee
    End Sub

    Private Sub ResetProgressBarStyle()
        progressBar.Style = ProgressBarStyle.Blocks
    End Sub

    Public Sub fileWorker_DoWorkHandler(sender As Object, e As DoWorkEventArgs(Of String(), List(Of FileData)))
        Dim progress = 0
        e.Result = New List(Of FileData)(e.Argument.Length)
        For Each file As String In e.Argument
            If fileWorker.CancellationPending Then
                e.Cancel = True
                Return
            End If
            fileWorker.ReportProgress(progress, file)
            Thread.Sleep(50)
            e.Result.Add(New FileData(file, DateTime.Now))
            progress += 2
        Next
        fileWorker.ReportProgress(progress, String.Empty)
    End Sub


    Public Sub showWaitForm_DoWorkHandler(sender As Object, e As DoWorkEventArgs(Of String))
        Dim progress = 0
        For i = 1 To 100
            If showWaitForm.CancellationPending Then
                e.Cancel = True
                Return
            End If
            'showWaitForm.ReportProgress(progress)
            Thread.Sleep(10)
        Next
        showWaitForm.ReportProgress(progress)
    End Sub

    Public Sub fileWorker_ProgressChangedHandler _
        (sender As Object, e As ProgressChangedEventArgs(Of String))
        labelProgress.Text = e.UserState
        progressBar.Value = e.ProgressPercentage
    End Sub

    Public Sub fileWorker_RunWorkerCompletedHandler(sender As Object,
                                                    e As RunWorkerCompletedEventArgs(Of List(Of FileData)))
        If e.Cancelled Then
            labelProgress.Text = "Cancelled"
            progressBar.Value = 0
        Else
            labelProgress.Text = "Done!"
        End If
        listBox.DataSource = e.Result
        listBox.Enabled = True
        buttonStart.Enabled = True
        buttonCancel.Enabled = False
        progressBar.Enabled = False
        AcceptButton = buttonStart
    End Sub


    Public Sub showWaitForm_RunWorkerCompletedHandler(sender As Object, e As RunWorkerCompletedEventArgs(Of String))
        If e.Cancelled Then
            labelProgress.Text = "Cancelled"
            progressBar.Value = 0
        Else
            labelProgress.Text = "Done!"
            progressBar.Value = 100
            ResetProgressBarStyle()
        End If
    End Sub


    Private Sub InitializeFileArray()
        files = New String() { _
                                 "00", "01", "02", "03", "04", "05", "06", "07",
                                 "08", "09", "0A", "0B", "0C", "0D", "0E", "0F",
                                 "10", "11", "12", "13", "14", "15", "16", "17",
                                 "18", "19", "1A", "1B", "1C", "1D", "1E", "1F",
                                 "20", "21", "22", "23", "24", "25", "26", "27",
                                 "28", "29", "2A", "2B", "2C", "2D", "2E", "2F",
                                 "30", "31"}
    End Sub

    Private Sub buttonStart_Click(sender As Object, e As EventArgs) Handles buttonStart.Click
        buttonCancel.Enabled = True
        AcceptButton = buttonCancel
        buttonStart.Enabled = False
        listBox.DataSource = Nothing
        listBox.Enabled = False
        fileWorker.RunWorkerAsync(files)
    End Sub

    Private Sub buttonCancel_Click(sender As Object, e As EventArgs) Handles buttonCancel.Click
        fileWorker.CancelAsync()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        showWaitForm.RunWorkerAsync()
        SetProgressBarStyleToMarquee()
    End Sub
End Class