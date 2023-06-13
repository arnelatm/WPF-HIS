Imports AATM.Common
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms.Reports

    Public Class SterilizationLabelPrinter
        Implements IPrintReportView

        Public Property MainTableName As String
        Protected SortOrderKey As String
        Public Event OnPrintReport As IPrintReportView.OnPrintReportEventHandler Implements IPrintReportView.OnPrintReport

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

        End Sub

        Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            Dim productionDate As Date
            Dim expiryDate As Date
            productionDate = dtpProductionDate.Value
            expiryDate = dtpExpiryDate.Value
            Dim args As Object() = {productionDate, "ProductionDate", expiryDate, "ExpiryDate"}
            RaiseEvent OnPrintReport("Expiry Label.Rpt", "ISPDATA", args, CInt(txtCopies.Text))
        End Sub

        Private Sub CButton2_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

    End Class

End Namespace