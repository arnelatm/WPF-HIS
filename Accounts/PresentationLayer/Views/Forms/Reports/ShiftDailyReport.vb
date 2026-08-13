Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Common
Imports AATM.Libraries.CrystalReportsHelper.CrystalReportPrinter
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Views.Forms.Reports

    Public Class ShiftDailyReport
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
            Dim today = Now()
            dtpBeginningDate.Value = GlobalFunctions.GregorianDateSerial(today.Year, today.Month, today.Day).AddDays(-1)
            dtpEndingDate.Value = GlobalFunctions.GregorianDateSerial(today.Year, today.Month, today.Day).AddDays(-1)
        End Sub

        Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            If dtpBeginningDate.Value <= dtpEndingDate.Value Then

                Dim reportName As String = Messaging.TranslateCaption("Shift Summary Daily Report")
                Dim bDate As String = GlobalFunctions.DateToSpecificCultureShortDateString(dtpBeginningDate.Value, CultureInfo.CreateSpecificCulture("en-GB"))
                Dim eDate As String = GlobalFunctions.DateToSpecificCultureShortDateString(dtpEndingDate.Value, CultureInfo.CreateSpecificCulture("en-GB"))
                Dim formCultureLanguage As String = CultureInfo.CurrentCulture.Name
                Dim reportFileName As String
                Dim cFormCulture = FormCulture
                Dim reportTitle As String
                reportTitle = Messaging.GetParametrizedMessage(True, "RptForThePeriod", {"reportName", reportName, "beginningDate", bDate, "endingDate", eDate})
                If Strings.Left(cFormCulture.Name, 2) = "ar" Then
                    reportFileName = "Shift Summary Daily Report.Rpt"
                Else
                    reportFileName = "Shift Summary Daily Report.Rpt"
                End If
                Dim reportArgs As New CrPrintableArgs
                Dim reportParameters As New Object
                reportArgs.ReportParameters = {CultureInfo.CurrentCulture.Name, "Language",
                                               GlobalVariables.GetEstablishmentName(CultureInfo.CurrentCulture), "EstablishmentName",
                                               reportTitle, "ReportTitle",
                                               dtpBeginningDate.Value, "BeginningDate",
                                               dtpEndingDate.Value, "EndingDate"
                                               }
                RaiseEvent PrintReport(reportFileName, reportArgs, False)

                'Dim reportName As String
                'Dim reportTitle As String
                'Dim bDate As String = GlobalFunctions.DateToSpecificCultureShortDateString(dtpBeginningDate.Value, CultureInfo.CreateSpecificCulture("en-GB"))
                'Dim eDate As String = GlobalFunctions.DateToSpecificCultureShortDateString(dtpEndingDate.Value, CultureInfo.CreateSpecificCulture("en-GB"))
                'reportName = Messaging.TranslateCaption($"Shift Summary Report")
                'reportTitle = Messaging.GetParametrizedMessage(True, "RptForThePeriod", {"reportName", reportName, "beginningDate", bDate, "endingDate", eDate})
                'Dim cFormCulture = FormCulture
                'If Strings.Left(cFormCulture.Name, 2) = "ar" Then
                '    cForm = New ReportFormNew("Shift Summary Daily Report.Rpt", reportTitle, CultureInfo.CurrentCulture, dtpBeginningDate.Value, "BeginningDate", dtpEndingDate.Value, "EndingDate")
                'Else
                '    cForm = New ReportFormNew("Shift Summary Daily Report.Rpt", reportTitle, CultureInfo.CurrentCulture, dtpBeginningDate.Value, "BeginningDate", dtpEndingDate.Value, "EndingDate")
                'End If
                'cForm.Show()
            Else
                Messaging.Show(True, "MsgBegDateMustBeLessThanEndDate")
            End If
        End Sub

        Private Sub CButton2_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

    End Class

End Namespace
