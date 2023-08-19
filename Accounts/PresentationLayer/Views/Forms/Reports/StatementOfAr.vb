Imports System.Globalization
Imports AATM.Common
Imports AATM.Libraries.CrystalReportsHelper.CrystalReportPrinter
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Views.Forms.Reports

    Public Class StatementOfAr
        Implements ICrPrintableReportView


        Public Property MainTableName As String
        Private Event PrintReport(reportFileName As String, reportArgs As CrPrintableArgs, printDirectly As Boolean) Implements ICrPrintableReportView.PrintReport
        Protected SortOrderKey As String

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            MainTableName = "ArJournal"
            SortOrderKey = "IdNo"
            Dim today = Now()
            dtpBeginningDate.Value = GlobalFunctions.GregorianDateSerial(today.Year, 1, 1)
            dtpEndingDate.Value = GlobalFunctions.GregorianDateSerial(today.Year, today.Month, today.Day)

        End Sub

        Private Sub btnOkClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            If dtpBeginningDate.Value <= dtpEndingDate.Value Then
                Dim reportName As String = Messaging.TranslateCaption("Statement of Accounts Payable")
                Dim bDate As String = GlobalFunctions.DateToSpecificCultureShortDateString(dtpBeginningDate.Value, CultureInfo.CreateSpecificCulture("en-GB"))
                Dim eDate As String = GlobalFunctions.DateToSpecificCultureShortDateString(dtpEndingDate.Value, CultureInfo.CreateSpecificCulture("en-GB"))
                Dim formCultureLanguage As String = FormCulture.Name
                Dim reportFileName As String
                If formCultureLanguage = "ar" Then
                    reportFileName = "Statement of Accounts Receivable Arabic.Rpt"
                Else
                    reportFileName = "Statement of Accounts Receivable.Rpt"
                End If
                Dim reportTitle As String
                Dim reportArgs As New CrPrintableArgs
                Dim reportParameters As New Object
                reportTitle = Messaging.GetParametrizedMessage(True, "RptForThePeriod", {"reportName", reportName, "beginningDate", bDate, "endingDate", eDate})
                reportArgs.ReportParameters = {dtpBeginningDate.Value, "BeginningDate",
                                    dtpEndingDate.Value, "EndingDate",
                                    cboCustomerIdNo.SelectedItem.IdNo, "CustomerIdNo",
                                    cboCustomerIdNo.Text, "DisplayName",
                                    reportTitle, "ReportTitle",
                                    GlobalVariables.EstablishmentName, "EstablishmentName",
                                    formCultureLanguage, "Language"}
                reportArgs.DataBaseConnectionName = "ISPDATA"
                RaiseEvent PrintReport(reportFileName, reportArgs, False)
            Else
                Messaging.Show(True, "MsgBegDateMustBeLessThanEndDate")
            End If
        End Sub

        Private Sub CButton2_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

        Private Sub StatementOfAr_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Ea.PublishEvent(New GetControlDataSource("Customer", cboCustomerIdNo))
            cboCustomerIdNo.EditingMode = True
        End Sub

    End Class

End Namespace