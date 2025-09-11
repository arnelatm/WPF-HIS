Imports System
Imports System.Windows.Forms

''' <summary>
''' A concrete implementation of IMessagingService that displays messages
''' in a StatusStrip control on a WinForms form.
''' </summary>
Public Class StatusBarMessagingService
    Implements IMessagingService

    Private ReadOnly _statusLabel As ToolStripStatusLabel
    Private ReadOnly _statusStrip As StatusStrip

    ''' <summary>
    ''' Initializes a new instance of the StatusBarMessagingService.
    ''' </summary>
    ''' <param name="statusStrip">The StatusStrip control to use for displaying messages.</param>
    Public Sub New(statusStrip As StatusStrip)
        If statusStrip Is Nothing Then
            Throw New ArgumentNullException(NameOf(statusStrip), "StatusStrip cannot be null.")
        End If
        If statusStrip.Items.Count = 0 OrElse Not (TypeOf statusStrip.Items(0) Is ToolStripStatusLabel) Then
            Throw New ArgumentException("The StatusStrip must contain at least one ToolStripStatusLabel.", NameOf(statusStrip))
        End If

        _statusStrip = statusStrip
        _statusLabel = CType(statusStrip.Items(0), ToolStripStatusLabel)
    End Sub

    ''' <summary>
    ''' Displays a success message in the status bar.
    ''' </summary>
    Public Sub ShowSuccess(message As String) Implements IMessagingService.ShowSuccess
        _statusStrip.BeginInvoke(Sub()
                                     _statusLabel.Text = "Success: " & message
                                     _statusLabel.ForeColor = Color.Green
                                 End Sub)
    End Sub

    ''' <summary>
    ''' Displays an error message in the status bar.
    ''' </summary>
    Public Sub ShowError(message As String) Implements IMessagingService.ShowError
        _statusStrip.BeginInvoke(Sub()
                                     _statusLabel.Text = "Error: " & message
                                     _statusLabel.ForeColor = Color.Red
                                 End Sub)
    End Sub

    ''' <summary>
    ''' Displays an informational message in the status bar.
    ''' </summary>
    Public Sub ShowInformation(message As String) Implements IMessagingService.ShowInformation
        _statusStrip.BeginInvoke(Sub()
                                     _statusLabel.Text = "Info: " & message
                                     _statusLabel.ForeColor = Color.Black
                                 End Sub)
    End Sub
End Class
