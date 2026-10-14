Imports System.Security.Permissions
Imports AATM.Accounts.PresentationLayer.Views.Forms

Public Module Main

    Private Sub ReportStartupFailure(ex As Exception)
        Dim logPath As String = Nothing

        Try
            Dim logDirectory = System.IO.Path.Combine(
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData),
                "AATM",
                "Logs")
            System.IO.Directory.CreateDirectory(logDirectory)
            logPath = System.IO.Path.Combine(logDirectory, "AccountsStartup.log")

            Using writer As New System.IO.StreamWriter(logPath, True)
                writer.WriteLine("Date/Time: " & DateTime.Now.ToString("o"))
                writer.WriteLine(ex.ToString())
                writer.WriteLine(New String("="c, 80))
            End Using
        Catch
            logPath = Nothing
        End Try

        Dim message = "Clinic Information System could not start." & Environment.NewLine &
                      Environment.NewLine & ex.Message
        If Not String.IsNullOrEmpty(logPath) Then
            message &= Environment.NewLine & Environment.NewLine &
                       "Details were written to:" & Environment.NewLine & logPath
        End If

        System.Windows.Forms.MessageBox.Show(
            message,
            "Clinic Information System",
            System.Windows.Forms.MessageBoxButtons.OK,
            System.Windows.Forms.MessageBoxIcon.Error)
    End Sub

    ''' <summary>
    ''' The main entry point for the application.
    ''' </summary>
    ''' 
    Public IdleTimer As New System.Windows.Forms.Timer()
    Private _handlingIdleTimeout As Boolean
    Private _idleShutdownRequested As Boolean

    Public ReadOnly Property IdleShutdownRequested As Boolean
        Get
            Return _idleShutdownRequested
        End Get
    End Property
    Const MilliSecondsTimeOut As Integer = 15_000_000 ' approximately 4 hours

    Public Sub Main()
        Call Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Dim limf As LeaveIdleMessageFilter = New LeaveIdleMessageFilter()
        Application.AddMessageFilter(limf)
        AddHandler Application.Idle, New EventHandler(AddressOf Application_Idle)
        IdleTimer.Interval = MilliSecondsTimeOut
        AddHandler IdleTimer.Tick, AddressOf TimeDone
        IdleTimer.Start()
        Try
            AATM.Accounts.Security.ProtectedConnectionStringBootstrap.LoadIfPresent()
            Application.Run(MainForm)
        Catch ex As Exception
            ReportStartupFailure(ex)
        End Try
        RemoveHandler Application.Idle, New EventHandler(AddressOf Application_Idle)
    End Sub

    Private Sub Application_Idle(ByVal sender As Object, ByVal e As EventArgs)
        If Not _handlingIdleTimeout AndAlso Not _idleShutdownRequested AndAlso Not IdleTimer.Enabled Then IdleTimer.Start()
    End Sub

    Private Sub TimeDone(ByVal sender As Object, ByVal e As EventArgs)
        If _handlingIdleTimeout OrElse _idleShutdownRequested Then Return
        _handlingIdleTimeout = True
        IdleTimer.[Stop]()
        Dim mainWindow As Form = MainForm
        Try
            Dim idleLogin As AATM.PresentationLayer.Forms.LoginEntry = Nothing
            If CanCloseAfterIdleTimeout(idleLogin) Then
                If idleLogin Is Nothing Then
                    mainWindow.Close()
                Else
                    _idleShutdownRequested = True
                    If idleLogin.CloseForIdleTimeout() Then
                        ' Let ShowDialog unwind before closing its owner, including startup login.
                        mainWindow.BeginInvoke(New MethodInvoker(
                            Sub()
                                Try
                                    mainWindow.Close()
                                Finally
                                    If Not mainWindow.IsDisposed Then
                                        _idleShutdownRequested = False
                                        If mainWindow.Visible Then IdleTimer.Start()
                                    End If
                                End Try
                            End Sub))
                    Else
                        _idleShutdownRequested = False
                    End If
                End If
                Return
            End If

            Dim prompt = "The session has been idle. Select Yes to close Accounts now, or No/Cancel to continue working." &
                         Environment.NewLine &
                         "انتهت مهلة الجلسة. اختر نعم لإغلاق برنامج الحسابات أو لا/إلغاء لمتابعة العمل."
            Dim promptOwner As Form = Form.ActiveForm
            If promptOwner Is Nothing Then promptOwner = mainWindow
            Dim x As DialogResult = AATM.Libraries.MessagingLibrary.MessagingForm.Show(promptOwner, prompt, "Idle Session / الجلسة غير نشطة",
                                               MessageBoxButtons.YesNoCancel,
                                               MessageBoxIcon.Warning,
                                               MessageBoxDefaultButton.Button2)

            If x = DialogResult.Yes Then
                mainWindow.Close()
            End If
        Finally
            _handlingIdleTimeout = False
            If Not _idleShutdownRequested AndAlso Not mainWindow.IsDisposed AndAlso mainWindow.Visible Then IdleTimer.Start()
        End Try
    End Sub

    Private Function CanCloseAfterIdleTimeout(ByRef idleLogin As AATM.PresentationLayer.Forms.LoginEntry) As Boolean
        Try
            idleLogin = Nothing
            For Each openForm As Form In Application.OpenForms
                Dim login = TryCast(openForm, AATM.PresentationLayer.Forms.LoginEntry)
                If login IsNot Nothing Then
                    If idleLogin IsNot Nothing OrElse Not login.CanCloseForIdleTimeout Then Return False
                    idleLogin = login
                End If
            Next

            For Each openForm As Form In Application.OpenForms
                Dim loginOwnerDisabled = openForm Is MainForm AndAlso idleLogin IsNot Nothing AndAlso idleLogin.Owner Is openForm
                If (openForm.Modal AndAlso openForm IsNot idleLogin) OrElse
                   (Not openForm.Enabled AndAlso Not loginOwnerDisabled) OrElse openForm.UseWaitCursor OrElse
                   openForm.Cursor = Cursors.WaitCursor Then Return False
                If HasActiveWorker(openForm) Then Return False

                If openForm Is idleLogin Then Continue For
                If openForm Is MainForm Then Continue For
                Dim entryForm = TryCast(openForm, AATM.PresentationLayer.Forms.BfMain)
                If entryForm Is Nothing OrElse entryForm.CancelClose OrElse entryForm.Presenter Is Nothing Then Return False

                ' Add/edit mode is pending work even before the first field changes.
                ' Unknown presenter contracts must keep the confirmation prompt.
                Dim presenter = entryForm.Presenter
                Dim addMode = presenter.GetType().GetProperty("AddMode")
                Dim editMode = presenter.GetType().GetProperty("EditMode")
                If addMode Is Nothing OrElse editMode Is Nothing Then Return False
                If CBool(addMode.GetValue(presenter, Nothing)) OrElse
                   CBool(editMode.GetValue(presenter, Nothing)) Then Return False
                If HasActiveWorker(presenter) Then Return False
            Next
            Return True
        Catch
            ' Never discard work when a screen's state cannot be determined.
            Return False
        End Try
    End Function

    Private Function HasActiveWorker(owner As Object) As Boolean
        Dim ownerType = owner.GetType()
        While ownerType IsNot Nothing
            For Each field In ownerType.GetFields(System.Reflection.BindingFlags.Instance Or
                                                  System.Reflection.BindingFlags.Public Or
                                                  System.Reflection.BindingFlags.NonPublic Or
                                                  System.Reflection.BindingFlags.DeclaredOnly)
                If field.FieldType.Name.StartsWith("BackgroundWorker", StringComparison.Ordinal) Then
                    Dim worker = field.GetValue(owner)
                    If worker IsNot Nothing Then
                        Dim busy = worker.GetType().GetProperty("IsBusy")
                        If busy Is Nothing OrElse CBool(busy.GetValue(worker, Nothing)) Then Return True
                    End If
                ElseIf GetType(System.Threading.Tasks.Task).IsAssignableFrom(field.FieldType) Then
                    Dim task = TryCast(field.GetValue(owner), System.Threading.Tasks.Task)
                    If task IsNot Nothing AndAlso Not task.IsCompleted Then Return True
                End If
            Next
            ownerType = ownerType.BaseType
        End While
        Return False
    End Function

End Module


<SecurityPermission(SecurityAction.LinkDemand, Flags:=SecurityPermissionFlag.UnmanagedCode)>
Public Class LeaveIdleMessageFilter
    Implements System.Windows.Forms.IMessageFilter

    Const WM_NCLBUTTONDOWN As Integer = &HA1
    Const WM_NCLBUTTONUP As Integer = &HA2
    Const WM_NCRBUTTONDOWN As Integer = &HA4
    Const WM_NCRBUTTONUP As Integer = &HA5
    Const WM_NCMBUTTONDOWN As Integer = &HA7
    Const WM_NCMBUTTONUP As Integer = &HA8
    Const WM_NCXBUTTONDOWN As Integer = &HAB
    Const WM_NCXBUTTONUP As Integer = &HAC
    Const WM_KEYDOWN As Integer = &H100
    Const WM_KEYUP As Integer = &H101
    Const WM_MOUSEMOVE As Integer = &H200
    Const WM_LBUTTONDOWN As Integer = &H201
    Const WM_LBUTTONUP As Integer = &H202
    Const WM_RBUTTONDOWN As Integer = &H204
    Const WM_RBUTTONUP As Integer = &H205
    Const WM_MBUTTONDOWN As Integer = &H207
    Const WM_MBUTTONUP As Integer = &H208
    Const WM_XBUTTONDOWN As Integer = &H20B
    Const WM_XBUTTONUP As Integer = &H20C
    Shared Messages As Integer() = New Integer() {WM_NCLBUTTONDOWN, WM_NCLBUTTONUP, WM_NCRBUTTONDOWN, WM_NCRBUTTONUP, WM_NCMBUTTONDOWN, WM_NCMBUTTONUP, WM_NCXBUTTONDOWN, WM_NCXBUTTONUP, WM_KEYDOWN, WM_KEYUP, WM_LBUTTONDOWN, WM_LBUTTONUP, WM_RBUTTONDOWN, WM_RBUTTONUP, WM_MBUTTONDOWN, WM_MBUTTONUP, WM_XBUTTONDOWN, WM_XBUTTONUP}


    <DebuggerStepThrough>
    Public Function PreFilterMessage(ByRef m As Message) As Boolean Implements IMessageFilter.PreFilterMessage
        If m.Msg = WM_MOUSEMOVE Then Return False
        If Not IdleTimer.Enabled Then Return False
        If Array.IndexOf(Messages, m.Msg) >= 0 Then Main.IdleTimer.[Stop]()
        Return False
    End Function

End Class

