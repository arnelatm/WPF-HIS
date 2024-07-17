Imports System.Globalization
Imports AATM.Common
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms.Reports

    Public Class ShiftDailyReport

        Public Property MainTableName As String
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
                Dim reportName As String = Messaging.TranslateCaption("Shift Summary Daily Report", LanguageCode)
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
                Dim reportParameters As Object = {LanguageCode, "Language",
                                               GetEstablishmentName(LanguageCode), "EstablishmentName",
                                               reportTitle, "ReportTitle",
                                               dtpBeginningDate.Value, "BeginningDate",
                                               dtpEndingDate.Value, "EndingDate"
                                               }
                ShowReportToScreen(reportFileName, reportParameters)
            Else
                Messaging.Show(True, "MsgBegDateMustBeLessThanEndDate")
            End If
        End Sub

        Private Sub CButton2_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

    End Class

End Namespace