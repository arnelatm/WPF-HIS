Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms.Reports

    Public Class DiagnosticTestSummary

        Public Property MainTableName As String
        Protected SortOrderKey As String

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            MainTableName = "ApJournal"
            SortOrderKey = "IdNo"
            Presenter = New ReportPresenter(Me)
            Dim currentDate = Now()
            currentDate = GlobalFunctions.GregorianDateSerial(currentDate.Year, currentDate.Month, currentDate.Day)
            ' returns previous month last day
            dtpEndingDate.Value = currentDate.AddDays(-1)
            dtpBeginningDate.Value = dtpEndingDate.Value
        End Sub

        Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            If dtpBeginningDate.Value <= dtpEndingDate.Value Then
                Dim cBegDate As String
                Dim cEndDate As String
                Dim selection As Int16
                selection = cboReportSelector.SelectedIndex + 1
                If selection > 0 Then
                    cBegDate = Format(dtpBeginningDate.Value, "yyyy/MM/dd")
                    cEndDate = Format(dtpEndingDate.Value, "yyyy/MM/dd")
                    Dim parameter As New ArrayList
                    parameter.Add({"BeginningDate", cBegDate})
                    parameter.Add({"EndingDate", cEndDate})
                    parameter.Add({"ReportNumber", selection.ToString()})
                    Dim cForm As New ReportFormIGroup($"Diagnostic Test Summary.Rpt", FormCulture, parameter)
                    cForm.Show()
                End If
            Else
                Messaging.Show(True, "MsgBegDateMustBeLessThanEndDate")
            End If
        End Sub

        Private Sub CButton2_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

    End Class

End Namespace