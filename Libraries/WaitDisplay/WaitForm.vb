
Imports System.Drawing
Imports System.Windows.Forms

Public Class WaitForm
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Me.StartPosition = FormStartPosition.CenterParent
    End Sub

    Public Sub New(parent As Form)

        ' This call is required by the designer.
        InitializeComponent()

        If parent IsNot Nothing Then
            Me.StartPosition = FormStartPosition.Manual
            Me.Location = New Point(parent.Location.X + parent.Width/2 - Me.Width/2,
                                    parent.Location.Y + parent.Height/2 - Me.Height/2)
        Else
            Me.StartPosition = FormStartPosition.CenterParent
        End If
    End Sub

    Public Function CloseLoadingForm()
        Me.DialogResult = DialogResult.OK
        if Me.InvokeRequired then
            Me.Invoke(New MethodInvoker(AddressOf Me.Close))
        Else
            'Me.Close()
        end if
        If Label1.Image IsNot Nothing Then
            Label1.Image.Dispose()
        End If
        Return nothing
    End Function
End Class
