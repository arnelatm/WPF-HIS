Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Common
Imports AATM.Libraries.CrystalReportsHelper.CrystalReportPrinter
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms.Reports

    Public Class ArSummary
        Implements ICrPrintableReportView

        Public Event PrintReport(reportFileName As String, reportArgs As CrPrintableArgs, printDirectly As Boolean) Implements ICrPrintableReportView.PrintReport
        Public Property MainTableName As String
        Protected SortOrderKey As String

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            MainTableName = "ApJournal"
            SortOrderKey = "IdNo"
            'Presenter = New ReportPresenter(Me)
            Dim currentDate = Now()
            ' returns previous month last day
            Dim endDate = GlobalFunctions.GregorianDateSerial(currentDate.Year, currentDate.Month, 0)
            dtpEndingDate.Value = endDate
            dtpBeginningDate.Value = GlobalFunctions.GregorianDateSerial(endDate.Year, endDate.Month, 1)
        End Sub

        Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            Dim curCulture = CultureInfo.CurrentCulture
            If dtpBeginningDate.Value <= dtpEndingDate.Value Then
                Dim reportName = Messaging.TranslateCaption("Summary of Accounts Receivable")
                Dim reportTitle As String
                reportTitle = Messaging.SelectReportName(reportName, dtpBeginningDate.Value, dtpEndingDate.Value, curCulture)
                'Dim bDate As String = GlobalFunctions.DateToSpecificCultureShortDateString(dtpBeginningDate.Value, CultureInfo.CreateSpecificCulture("en-GB"))
                'Dim eDate As String = GlobalFunctions.DateToSpecificCultureShortDateString(dtpEndingDate.Value, CultureInfo.CreateSpecificCulture("en-GB"))
                Dim formCultureLanguage As String = CultureInfo.CurrentCulture.Name
                Dim reportFileName As String
                reportFileName = "Summary of Accounts Receivable.Rpt"
                Dim reportArgs As New CrPrintableArgs
                Dim reportParameters As New Object
                reportArgs.ReportParameters = {dtpBeginningDate.Value, "BeginningDate",
                         dtpEndingDate.Value, "EndingDate",
                         reportTitle, "ReportTitle",
                         chkIncludeZeroBalances.Checked, "IncludeZeroBalances",
                         GlobalVariables.EstablishmentName, "EstablishmentName",
                         formCultureLanguage, "Language"}
                RaiseEvent PrintReport(reportFileName, reportArgs, False)

            Else
                Messaging.Show(True, "MsgBegDateMustBeLessThanEndDate")
            End If
        End Sub

        Private Sub CButton2_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

    End Class

End Namespace