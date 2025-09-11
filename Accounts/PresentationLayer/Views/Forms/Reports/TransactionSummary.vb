Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Common
Imports AATM.Libraries.CrystalReportsHelper.CrystalReportPrinter
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.Messaging

Namespace PresentationLayer.Views.Forms.Reports

    Public Class TransactionSummary
        Implements ICrPrintableReportView

        Public Property MainTableName As String
        Public Event PrintReport(reportFileName As String, reportArgs As CrPrintableArgs, printDirectly As Boolean) Implements ICrPrintableReportView.PrintReport
        Protected SortOrderKey As String

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            MainTableName = "Account"
            SortOrderKey = "IdNo"
            dtpBeginningDate.Value = GlobalFunctions.GregorianDateSerial(Today.Year, 1, 1)
            dtpEndingDate.Value = GlobalFunctions.GregorianDateSerial(Today.Year, Today.Month, Today.Day)

        End Sub

        Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            Dim reportName = MessagingService.TranslateCaption("Summary of Employee Loans")
            Dim reportTitle As String
            Dim bDate As String = GlobalFunctions.DateToSpecificCultureShortDateString(dtpBeginningDate.Value, CultureInfo.CreateSpecificCulture("en-GB"))
            Dim eDate As String = GlobalFunctions.DateToSpecificCultureShortDateString(dtpEndingDate.Value, CultureInfo.CreateSpecificCulture("en-GB"))
            reportTitle = MessagingService.TranslateCaption("Transaction Summary Report")
            Dim formCultureLanguage As String = CultureInfo.CurrentUICulture.Name

            Dim language As String
            language = Strings.Left(formCultureLanguage, formCultureLanguage.IndexOf("-"))

            Dim reportFileName As String
            reportFileName = "Transaction Summary Report.Rpt"
            Dim reportArgs As New CrPrintableArgs
            Dim reportParameters As New Object
            Dim estName As String
            If formCultureLanguage = "ar" Then
                estName = GlobalVariables.EstablishmentNameAra
            Else
                estName = GlobalVariables.EstablishmentName
            End If
            reportArgs.ReportParameters = {reportTitle, "ReportTitle",
                                           formCultureLanguage, "Language",
                                           dtpBeginningDate.Value, "BeginningDate",
                                           dtpEndingDate.Value, "EndingDate",
                                           estName, "EstablishmentName"}
            RaiseEvent PrintReport(reportFileName, reportArgs, False)

        End Sub

        Private Sub CButton2_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

        Private Sub CButton1_ClickButtonArea_1(Sender As Object, e As MouseEventArgs) Handles btnTranslate.ClickButtonArea
            RunTranslator(VSystemViewIdNo)
        End Sub

    End Class

End Namespace