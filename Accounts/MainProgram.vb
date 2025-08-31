Imports AATM.Libraries.GlobalFuncNSub

Public Class MainProgram

    Public IdleTimer As New System.Windows.Forms.Timer()
    Const MinuteMicroseconds As Integer = 60000

    Public Sub New()
        InitializeComponent()
    End Sub

    '    Private Sub MainProgram_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '        Dim ea = GlobalVariables.EventAggregator ' touches singleton on UI thread
    '#If DEBUG Then
    '        ea.EnableDiagnostics(True)
    '#End If
    '    End Sub

End Class