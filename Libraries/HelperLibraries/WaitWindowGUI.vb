'
' * Created by SharpDevelop.
' * User: mjackson
' * Date: 05/03/2010
' * Time: 09:43
' *
' * To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports System.Windows.Forms

''' <summary>
'''     The dialogue displayed by a WaitWindow instance.
''' </summary>
Partial Friend Class WaitWindowGui
    Inherits Form

    Public Sub New(parent As WaitWindow)
        '
        ' The InitializeComponent() call is required for Windows Forms designer support.
        '
        InitializeComponent()

        _parent = parent

        '	Position the window in the top right of the main screen.
        With Application.OpenForms.Item(0)
            'With .ParentForm
            Top = .Top + .Height / 2 - 16
            Left = .Left + .Width / 2 - Width / 2
            If Left < .Left Then
                Left = .Left + 1
            End If
            'End With
        End With

        'Left = Screen.PrimaryScreen.WorkingArea.Right - Width - 32
    End Sub

    Private ReadOnly _parent As WaitWindow

    Private Delegate Function FunctionInvoker(Of T)() As T

    Friend Result As Object
    Friend [Error] As Exception
    Public Property ThreadResult As IAsyncResult

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        '	Paint a 3D border
        ControlPaint.DrawBorder3D(e.Graphics, ClientRectangle, Border3DStyle.Raised)
    End Sub

    Protected Overrides Sub OnShown(e As EventArgs)
        MyBase.OnShown(e)

        '   Create Delegate
        Dim threadController As New FunctionInvoker(Of Object)(AddressOf DoWork)

        '   Execute on secondary thread.
        ThreadResult = threadController.BeginInvoke(AddressOf WorkComplete, threadController)
    End Sub

    Friend Function DoWork() As Object
        '	Invoke the worker method and return any results.
        Dim e As New WaitWindowEventArgs(_parent, _parent._Args)
        If (_parent._WorkerMethod IsNot Nothing) Then
            _parent._WorkerMethod(Me, e)
        End If
        Return e.Result
    End Function

    Private Sub WorkComplete(results As IAsyncResult)
        If Not IsDisposed Then
            If InvokeRequired Then
                Invoke(New WaitWindow.MethodInvoker(Of IAsyncResult)(AddressOf WorkComplete), results)
            Else
                '	Capture the result
                Try
                    Result = DirectCast(results.AsyncState, FunctionInvoker(Of Object)).EndInvoke(results)
                Catch ex As Exception
                    '	Grab the Exception for rethrowing after the WaitWindow has closed.
                    [Error] = ex
                End Try
                Close()
            End If
        End If
    End Sub

    Friend Sub SetMessage(message As String)
        MessageLabel.Text = message
    End Sub

    Friend Sub Cancel()
        Invoke(New MethodInvoker(AddressOf Close), Nothing)
    End Sub

End Class