Imports System.IO

Public Class CbcFlagSelector

    Private reportFiles As String()
    Public Sub New(files As String(), filePath As String, invoiceNumber As String)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        reportFiles = files
        Dim filepathLength As Int16 = filePath.Length
        GetData(reportFiles, filepathLength, invoiceNumber)
    End Sub


    Public Sub GetData(reportFiles, filePathLength, invoiceNumber)
        Dim runTime As DateTime
        Dim sequenceNo As String

        For Each reportFile As String In reportFiles
            Dim row As New DataGridViewRow
            Dim counter As Int32 = 0
            runTime = File.GetCreationTime(reportFile)
            Dim index = reportFile.IndexOf("_")
            sequenceNo = reportFile.Substring(filePathLength + 9, index - filePathLength - 9)
            DataGridViewReportFiles.Rows.Add({invoiceNumber, runTime, sequenceNo})
        Next
    End Sub

    Private Sub btnOk_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
        Dim index = DataGridViewReportFiles.CurrentCell.RowIndex()
        ' Set the result to pass back to the form that called this dialog
        SelectedIndex = DataGridViewReportFiles.CurrentCell.RowIndex()
        DialogResult = DialogResult.OK
        Close()
    End Sub

    Public SelectedIndex As Integer

    Private Function btnCancel_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
        SelectedIndex = -1
        DialogResult = DialogResult.Cancel
        Close()
    End Function



End Class