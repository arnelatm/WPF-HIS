Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports CrystalDecisions.ReportAppServer.Controllers

Namespace PresentationLayer.Views.Forms.Reports

    Public Class SterilizationLabelPrinter

        Public Property MainTableName As String
        Protected SortOrderKey As String
        'Public Event PrintReport(reportFileName As String)

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            Dim currentDate = Now()
            currentDate = GlobalFunctions.GregorianDateSerial(currentDate.Year, currentDate.Month, currentDate.Day)
            ' returns previous month last day
            dtpProductionDate.Value = currentDate
            dtpExpiryDate.Value = currentDate.AddMonths(1)
            txtCopies.Text = 1
            'AddHandler PrintReport, AddressOf OnPrintReport
        End Sub

        Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            Dim prPresenter As New PrintReportPresenter()
            Dim productionDate As Date
            Dim expiryDate As Date
            productionDate = dtpProductionDate.Value
            expiryDate = dtpExpiryDate.Value
            Dim args As Object() = {productionDate, "ProductionDate", expiryDate, "ExpiryDate"}
            prPresenter.PrintReport("Expiry Label.Rpt", "ISPDATA", args, CInt(txtCopies.Text))
        End Sub

        Private Sub CButton2_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

    End Class

End Namespace