Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events
Imports AATM.PresentationLayer.Forms
Imports AATM.ServicesLayer.Services

Namespace PresentationLayer.Views.Forms.Reports

    Public Class StatementOfAp

        Public Property MainTableName As String
        Protected SortOrderKey As String
        Public Event PrintReport(reportFileName As String)

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            MainTableName = "ApJournal"
            SortOrderKey = "IdNo"
            Dim today = Now()
            dtpBeginningDate.Value = GlobalFunctions.GregorianDateSerial(today.Year, 1, 1)
            dtpEndingDate.Value = GlobalFunctions.GregorianDateSerial(today.Year, today.Month, today.Day)

        End Sub

        Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            If dtpBeginningDate.Value <= dtpEndingDate.Value Then
                Dim reportName As String
                Dim reportTitle As String
                Dim fileName As String
                Dim bDate As String = GlobalFunctions.DateToSpecificCultureShortDateString(dtpBeginningDate.Value, CultureInfo.CreateSpecificCulture("en-GB"))
                Dim eDate As String = GlobalFunctions.DateToSpecificCultureShortDateString(dtpEndingDate.Value, CultureInfo.CreateSpecificCulture("en-GB"))
                reportName = Messaging.TranslateCaption("Statement of Accounts Payable")
                reportTitle = Messaging.GetParametrizedMessage(True, "RptForThePeriod", {"reportName", reportName, "beginningDate", bDate, "endingDate", eDate})
                If Strings.Left(FormCulture.Name, 2) = "ar" Then
                    fileName = "Statement of Accounts Payable Arabic.Rpt"
                Else
                    fileName = "Statement of Accounts Payable.Rpt"
                End If

                Dim cForm
                cForm = New ReportFormNew(fileName, reportTitle, CultureInfo.CurrentCulture,
                                      dtpBeginningDate.Value, "BeginningDate",
                                      dtpEndingDate.Value, "EndingDate",
                                      cboSupplierIdNo.SelectedItem.IdNo, "SupplierIdNo",
                                      cboSupplierIdNo.Text, "DisplayName")
                cForm.Show()

                'prPresenter.PrintReport(fileName, Nothing , args)

                'Ea.PublishEvent(New ShowReportRequested(fileName, reportTitle, FormCulture, $"ISPDATA", args))

                'prPresenter.ShowReport(fileName, reportTitle, FormCulture, "A4", $"ISPDATA", args)
            Else
                Messaging.Show(True, "MsgBegDateMustBeLessThanEndDate")
            End If
        End Sub

        Private Sub CButton2_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub


        Private Sub StatementOfAp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            If Ea IsNot Nothing Then
                Ea.PublishEvent(New GetControlDataSource("Supplier", cboSupplierIdNo))
            End If
        End Sub

    End Class

End Namespace