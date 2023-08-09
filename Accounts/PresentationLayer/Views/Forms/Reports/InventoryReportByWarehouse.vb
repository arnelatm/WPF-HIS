Imports System.Globalization
Imports AATM.Common
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Views.Forms.Reports

    Public Class InventoryReportByWarehouse
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

        End Sub

        Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            Dim reportName As String
            reportName = Messaging.TranslateCaption("Inventory Report By Warehouse")
            ReportTitle = Messaging.GetParametrizedMessage(True, "RptForThePeriod", {"reportName", reportName, "WarehouseIdNo", cboWarehouseIdNo.SelectedValue, "AllWarehouses", chkAllWarehouses.Checked})
            FormCultureLanguage = FormCulture.Name
            FileName = "Inventory Report By Warehouse.Rpt"
            Args = {cboWarehouseIdNo.SelectedItem.IdNo, "WarehouseIdNo",
                    chkAllWarehouses.Checked, "AllWarehouses"}
            Copies = 1
            RaiseEvent PrintReport(Me)
        End Sub

        Private Sub CButton2_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub


        Private Sub InventoryReportByWarehouse_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Ea.PublishEvent(New GetControlDataSource("Warehouse", cboWarehouseIdNo))
            cboWarehouseIdNo.EditingMode = True
        End Sub


    End Class

End Namespace