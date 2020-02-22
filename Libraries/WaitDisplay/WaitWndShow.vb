Imports System.Threading
Imports System.Windows.Forms

Public Class WaitWndShow
    Private _loadingForm As WaitForm
    Private _loadThread As Thread
    Public Shared frmWait As WaitForm

    Public Sub Show()
        'Debugger.Break()
        'frmWait = New Thread(New ThreadStart(Addressof LoadingProcessEx))        
        _loadthread = New Thread(New ThreadStart(AddressOf LoadingProcessEx))
        _loadthread.Start()
        'Thread.Sleep(5000)
        'Thread.CurrentThread.Join()
        '_loadThread.Join()
    End Sub

    Public Sub Show(parent As Form)
        _loadthread = New Thread(New ParameterizedThreadStart(AddressOf LoadingProcessEx))
        _loadthread.Start(parent)
        'Application.DoEvents()
        '_loadThread.Yield()
        '_loadThread.Join()
    End Sub

    Public Sub Close()

        'Debugger.Break()
        'Application.DoEvents()       
        If frmWait IsNot Nothing AndAlso _loadingForm.IsHandleCreated Then
            frmWait.BeginInvoke(New ThreadStart(AddressOf frmWait.CloseLoadingForm))
            frmWait = nothing
            frmWait = nothing
        End If

        'If _loadingForm IsNot Nothing AndAlso _loadingForm.IsHandleCreated
        '    _loadingForm.BeginInvoke(New ThreadStart(AddressOf _loadingForm.CloseLoadingForm))
        '    _loadingForm = Nothing
        '    _loadthread = Nothing
        'End If
    End Sub

    Private Sub LoadingProcessEx()
        frmWait = New WaitForm()
        frmWait.ShowDialog()
        'thread.Sleep(10000)
        '_loadingForm = New WaitForm()
        '_loadingForm.ShowDialog()
        ''If _loadThread isnot Nothing Andalso _loadThread.IsAlive() Then
        '    _loadThread.Join()
        'End If
        '_loadThread.Yield()
    End Sub

    Private Sub LoadingProcessEx(parent As Object)
        Dim parentForm = TryCast(parent, Form)
        _loadingForm = New WaitForm(parentForm)
        _loadingForm.ShowDialog()
        '_loadThread.Join()
    End Sub
End Class