Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Public Class SampleMessagingForm

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
        trackBarMaxWidth.Value = Convert.ToInt32(MessagingForm.MaxWidthFactor * 10)
        Me.trackBarMaxWidth_Scroll(Me, New EventArgs())
        trackBarMaxHeight.Value = Convert.ToInt32(MessagingForm.MaxHeightFactor * 10)
        Me.trackBarMaxHeight_Scroll(Me, New EventArgs())
    End Sub

    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
        MessagingForm.Show("Some text", "Some caption")
    End Sub

    Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click
        Dim result = MessagingForm.Show("Some text with a link: www.google.com" & vbLf & "A second line that contains a very very very very very very very very very very very very very very long text.", "I am a MessagingForm", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
        MessagingForm.Show("You have clicked: " & result.ToString(), "DialogResult")
    End Sub

    Private Sub button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button3.Click
        Dim batchOperationResults = GetBatchOperationResults()
        Dim result = MessageBox.Show(batchOperationResults, "Batch Operation")
    End Sub

    Private Sub button4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button4.Click 
        Dim batchOperationResults = GetBatchOperationResults()
        Dim result = MessagingForm.Show(batchOperationResults, "Batch Operation")
    End Sub

    Private Shared Function GetBatchOperationResults() As String
        Dim builder = New StringBuilder("Batch operation report:" & vbLf & vbLf)
        Dim random = New Random()
        Dim result = 0

        For i As Integer = 0 To 200 - 1
            result = random.[Next](1000)

            If result < 950 Then
                builder.AppendFormat(" - Task {0}: Operation completed sucessfully." & vbLf, i)
            Else
                builder.AppendFormat(" - Task {0}: Operation failed! A very very very very very very very very very very very very serious error has occured during this sub-operation. The errorcode is: {1})." & vbLf, i, result)
            End If
        Next

        Return builder.ToString()
    End Function

    Private Sub trackBarMaxWidth_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles trackBarMaxWidth.Scroll
        MessagingForm.MaxWidthFactor = Math.Round(trackBarMaxWidth.Value * 0.1, 1)
        labelMaxWidthInPercent.Text = String.Format("{0}%", MessagingForm.MaxWidthFactor * 100)
    End Sub

    Private Sub trackBarMaxHeight_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles trackBarMaxHeight.Scroll
        MessagingForm.MaxHeightFactor = Math.Round(trackBarMaxHeight.Value * 0.1, 1)
        labelMaxHeightInPercent.Text = String.Format("{0}%", MessagingForm.MaxHeightFactor * 100)
    End Sub

    Private Sub checkBoxUseOtherFont_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        MessagingForm.DesiredFont = If(checkBoxUseOtherFont.Checked, New Font("Impact", 12, FontStyle.Italic), SystemFonts.MessageBoxFont)
    End Sub

End Class