Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events
Imports AATM.PresentationLayer.Forms
Imports AATM.ServicesLayer.Services

Namespace PresentationLayer.Views.Forms.Reports

    Public Class StatementOfAp

        Public Property MainTableName As String
        Protected SortOrderKey As String

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            MainTableName = "ApJournal"
            SortOrderKey = "IdNo"
            Presenter = New ReportPresenter(Me)
            Presenter.CreateDataSource("Supplier", cboSupplierIdNo)
            Dim today = Now()
            dtpBeginningDate.Value = GlobalFunctions.GregorianDateSerial(today.Year, 1, 1)
            dtpEndingDate.Value = GlobalFunctions.GregorianDateSerial(today.Year, today.Month, today.Day)

        End Sub

        Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            Dim cForm
            If dtpBeginningDate.Value <= dtpEndingDate.Value Then
                Dim reportName As String
                Dim reportTitle As String
                Dim bDate As String = GlobalFunctions.DateToSpecificCultureShortDateString(dtpBeginningDate.Value, CultureInfo.CreateSpecificCulture("en-GB"))
                Dim eDate As String = GlobalFunctions.DateToSpecificCultureShortDateString(dtpEndingDate.Value, CultureInfo.CreateSpecificCulture("en-GB"))
                reportName = Messaging.TranslateCaption("Statement of Accounts Payable")
                reportTitle = Messaging.GetParametrizedMessage(True, "RptForThePeriod", {"reportName", reportName, "beginningDate", bDate, "endingDate", eDate})
                Dim cFormCulture = FormCulture
                OpenCrViewer(cFormCulture, reportTitle)
            Else
                Messaging.Show(True, "MsgBegDateMustBeLessThanEndDate")
            End If
        End Sub

        Private Sub OpenCrViewer(cFormCulture As CultureInfo, reportTitle As String)
            'Dim pjPresenter = New PrintJobPresenter()
            'pjPresenter.ViewReport()
            Dim cForm As CrViewer
            If Strings.Left(cFormCulture.Name, 2) = "ar" Then
                cForm = New CrViewer("Statement of Accounts Payable Arabic.Rpt", reportTitle, CultureInfo.CurrentCulture, dtpBeginningDate.Value, "BeginningDate", dtpEndingDate.Value, "EndingDate", cboSupplierIdNo.SelectedItem.IdNo, "SupplierIdNo", cboSupplierIdNo.Text, "DisplayName")
            Else
                cForm = New CrViewer("Statement of Accounts Payable.Rpt", reportTitle, CultureInfo.CurrentCulture, dtpBeginningDate.Value, "BeginningDate", dtpEndingDate.Value, "EndingDate", cboSupplierIdNo.SelectedItem.IdNo, "SupplierIdNo", cboSupplierIdNo.Text, "DisplayName")
            End If
            cForm.SetDb()
            cForm.SetPrintJob("A4")
            cForm.Show()
        End Sub

        Private Sub CButton2_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

    End Class

End Namespace