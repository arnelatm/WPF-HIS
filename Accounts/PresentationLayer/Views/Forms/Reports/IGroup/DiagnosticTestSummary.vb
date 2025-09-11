Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Common
Imports AATM.Libraries.CrystalReportsHelper.CrystalReportPrinter
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.Messaging

Namespace PresentationLayer.Views.Forms.Reports

    Public Class DiagnosticTestSummary
        Implements ICrPrintableReportView

        Public Property MainTableName As String
        Public Event PrintReport(reportFileName As String, reportArgs As CrPrintableArgs, printDirectly As Boolean) Implements ICrPrintableReportView.PrintReport
        Protected SortOrderKey As String

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            MainTableName = "ApJournal"
            SortOrderKey = "IdNo"
            Dim currentDate = Now()
            currentDate = GlobalFunctions.GregorianDateSerial(currentDate.Year, currentDate.Month, currentDate.Day)
            ' returns previous month last day
            dtpEndingDate.Value = currentDate.AddDays(-1)
            dtpBeginningDate.Value = dtpEndingDate.Value
        End Sub

        Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            If dtpBeginningDate.Value <= dtpEndingDate.Value Then


                Dim reportFileName As String
                Dim cBegDate As String
                Dim cEndDate As String
                Dim selection As Int16
                Dim reportArgs As New CrPrintableArgs
                Dim reportParameters As New Object
                Dim estName As String
                Dim language = Strings.Left(CultureInfo.CurrentCulture.Name, CultureInfo.CurrentCulture.Name.IndexOf("-"))
                If language = "ar" Then
                    estName = GlobalVariables.EstablishmentNameAra
                Else
                    estName = GlobalVariables.EstablishmentName
                End If
                reportFileName = $"Diagnostic Test Summary.Rpt"
                selection = cboReportSelector.SelectedIndex + 1
                If selection > 0 Then
                    cBegDate = Format(dtpBeginningDate.Value, "yyyy/MM/dd")
                    cEndDate = Format(dtpEndingDate.Value, "yyyy/MM/dd")
                    reportArgs.DataBaseConnectionName = "IGroupClinic"
                    reportArgs.ReportParameters = {cBegDate, "BeginningDate",
                                                   cEndDate, "EndingDate",
                                                   selection.ToString(), "ReportNumber",
                                                   cboReportSelector.SelectedItem.ToString(), "ReportTitle",
                                                   estName, "EstablishmentName"}
                    RaiseEvent PrintReport(reportFileName, reportArgs, False)
                End If
            Else
                MessagingService.Show(True, "MsgBegDateMustBeLessThanEndDate")
            End If
        End Sub

        Private Sub CButton2_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

    End Class

End Namespace