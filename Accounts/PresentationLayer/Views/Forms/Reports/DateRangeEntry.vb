Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Views.Forms.Reports

    Public Class DateRangeEntry

        Public Property MainTableName As String
        Protected SortOrderKey As String
        Private _reportFileName as String

        Public Sub New(reportFileName as String)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            MainTableName = "ApJournal"
            SortOrderKey = "IdNo"
            Presenter = New ReportPresenter(Me)
            Dim today = Now()
            dtpBeginningDate.Value = GlobalFunctions.GregorianDateSerial(today.Year, today.Month, today.Day).AddDays(-1)
            dtpEndingDate.Value = GlobalFunctions.GregorianDateSerial(today.Year, today.Month, today.Day).AddDays(-1)
            _reportFileName = reportFileName
        End Sub

        Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            Dim cForm
            If dtpBeginningDate.Value <= dtpEndingDate.Value Then
                Dim reportName As String
                Dim reportTitle As String
                Dim bDate As String = GlobalFunctions.DateToSpecificCultureShortDateString(dtpBeginningDate.Value, CultureInfo.CreateSpecificCulture("en-GB"))
                Dim eDate As String = GlobalFunctions.DateToSpecificCultureShortDateString(dtpEndingDate.Value, CultureInfo.CreateSpecificCulture("en-GB"))
                reportName = Messaging.TranslateCaption($"Shift Summary Report")
                reportTitle = Messaging.GetParametrizedMessage(True, "RptForThePeriod", {"reportName", reportName, "beginningDate", bDate, "endingDate", eDate})
                Dim cFormCulture = FormCulture
                If Strings.Left(cFormCulture.Name, 2) = "ar" Then
                    cForm = New ReportFormNew(_reportFileName+".rpt", reportTitle, FormCulture, dtpBeginningDate.Value, "BeginningDate", dtpEndingDate.Value, "EndingDate" )
                Else
                    cForm = New ReportFormNew(_reportFileName+".rpt", reportTitle, FormCulture, dtpBeginningDate.Value, "BeginningDate", dtpEndingDate.Value, "EndingDate" )
                End If
                cForm.Show()
            Else
                Messaging.Show(True, "MsgBegDateMustBeLessThanEndDate")
            End If
        End Sub

        Private Sub CButton2_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

    End Class

End Namespace