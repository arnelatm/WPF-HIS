Imports System.Windows.Forms

''' <summary>
''' A concrete implementation of IMessagingService that uses a standard WinForms MessageBox.
''' This class is specific to the UI technology and can be easily swapped out.
''' </summary>
Public Class WinFormsMessageBoxService
    Implements IMessagingService

    Public Sub ShowSuccess(message As String) Implements IMessagingService.ShowSuccess
        MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Sub ShowError(message As String) Implements IMessagingService.ShowError
        MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Public Sub ShowInformation(message As String) Implements IMessagingService.ShowInformation
        MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class