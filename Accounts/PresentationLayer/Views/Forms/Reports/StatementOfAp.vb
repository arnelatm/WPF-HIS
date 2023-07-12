Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Common
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events
Imports AATM.PresentationLayer.Forms
Imports AATM.ServicesLayer.Services

Namespace PresentationLayer.Views.Forms.Reports

    Public Class StatementOfAp
        Implements IReportPrinterView

        Public Property MainTableName As String

        Public Property FileName As String Implements IReportPrinterView.FileName
        Public Property ReportTitle As String Implements IReportPrinterView.ReportTitle
        Public Property FormCultureLanguage As String Implements IReportPrinterView.FormCultureLanguage
        Public Property Args As Object() Implements IReportPrinterView.Args
        Public Property DataBaseConnectionName As String Implements IReportPrinterView.DataBaseConnectionName
        Public Property Copies As Integer Implements IReportPrinterView.Copies

        Protected SortOrderKey As String
        Private Event PrintReport(ByVal sender As IReportPrinterView) Implements IReportPrinterView.PrintReport

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            MainTableName = "Report"
            SortOrderKey = "IdNo"
            Dim today = Now()
            dtpBeginningDate.Value = GlobalFunctions.GregorianDateSerial(today.Year, 1, 1)
            dtpEndingDate.Value = GlobalFunctions.GregorianDateSerial(today.Year, today.Month, today.Day)

        End Sub

        Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            If dtpBeginningDate.Value <= dtpEndingDate.Value Then
                Dim reportName As String
                Dim bDate As String = GlobalFunctions.DateToSpecificCultureShortDateString(dtpBeginningDate.Value, CultureInfo.CreateSpecificCulture("en-GB"))
                Dim eDate As String = GlobalFunctions.DateToSpecificCultureShortDateString(dtpEndingDate.Value, CultureInfo.CreateSpecificCulture("en-GB"))
                reportName = Messaging.TranslateCaption("Statement of Accounts Payable")
                reportTitle = Messaging.GetParametrizedMessage(True, "RptForThePeriod", {"reportName", reportName, "beginningDate", bDate, "endingDate", eDate})
                FormCultureLanguage = FormCulture.Name
                If FormCultureLanguage = "ar" Then
                    FileName = "Statement of Accounts Payable Arabic.Rpt"
                Else
                    FileName = "Statement of Accounts Payable.Rpt"
                End If
                Args = {dtpBeginningDate.Value, "BeginningDate",
                             dtpEndingDate.Value, "EndingDate",
                             cboSupplierIdNo.SelectedItem.IdNo, "SupplierIdNo",
                             cboSupplierIdNo.Text, "DisplayName"}

                Copies = 1

                RaiseEvent PrintReport(Me)

                'language, "Language",
                '             establishmentName, "EstablishmentName",
                '             reportTitle, "ReportTitle"}
                'Dim cForm

                'Presenter.ProcessReport(FileName, "", True, args)

                'cForm = New ReportFormNew(fileName, reportTitle, CultureInfo.CurrentCulture)

                'cForm.Show()

            Else
                Messaging.Show(True, "MsgBegDateMustBeLessThanEndDate")
            End If
        End Sub

        Private Sub CButton2_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub


        Private Sub StatementOfAp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Ea.PublishEvent(New GetControlDataSource("Supplier", cboSupplierIdNo))
            cboSupplierIdNo.EditingMode = True
        End Sub


    End Class

End Namespace