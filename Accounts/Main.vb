Imports System.Security.Permissions
Imports AATM.Accounts.PresentationLayer.Views.Forms


'Imports System
'Imports System.Windows.Forms

'Namespace FormUI
'    Public Module Program

'        ''' <summary>
'        ''' The main entry point for the application.
'        ''' </summary>
'        <STAThread>
'        Public Sub Main()
'            Call Application.EnableVisualStyles()
'            Application.SetCompatibleTextRenderingDefault(False)
'            Call Application.Run(New Dashboaard())
'        End Sub

'    End Module
'End Namespace

Public Module Main

    ''' <summary>
    ''' The main entry point for the application.
    ''' </summary>
    Public IdleTimer As New System.Windows.Forms.Timer()
    'Public mainForm As New MainForm()
    Const MilliSecondsTimeOut As Integer = 60000

    Public Sub Main()
        Call Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Dim limf As LeaveIdleMessageFilter = New LeaveIdleMessageFilter()
        Application.AddMessageFilter(limf)
        AddHandler Application.Idle, New EventHandler(AddressOf Application_Idle)
        IdleTimer.Interval = MilliSecondsTimeOut
        AddHandler IdleTimer.Tick, AddressOf TimeDone
        IdleTimer.Start()
        'f = New MainForm()
        'Application.Run(f)
        Call Application.Run(MainForm)
        RemoveHandler Application.Idle, New EventHandler(AddressOf Application_Idle)
    End Sub

    Private Sub Application_Idle(ByVal sender As Object, ByVal e As EventArgs)
        If Not IdleTimer.Enabled Then IdleTimer.Start()
    End Sub

    Private Sub TimeDone(ByVal sender As Object, ByVal e As EventArgs)
        IdleTimer.[Stop]()
        MessageBox.Show("Auto logoff")
        MainForm.Close()
    End Sub
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

    Public Function PreFilterMessage(ByRef m As Message) As Boolean Implements IMessageFilter.PreFilterMessage
        If m.Msg = WM_MOUSEMOVE Then Return False
        If Not IdleTimer.Enabled Then Return False
        If Array.BinarySearch(Messages, m.Msg) >= 0 Then Main.IdleTimer.[Stop]()
        Return False
    End Function

End Class

