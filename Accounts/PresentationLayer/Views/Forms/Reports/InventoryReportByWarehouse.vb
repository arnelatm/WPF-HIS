Imports System.Globalization
Imports AATM.Common
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.CrystalReportsHelper.CrystalReportPrinter
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Views.Forms.Reports

    Public Class InventoryReportByWarehouse
        Implements ICrPrintableReportView

        Public Property MainTableName As String
        Private Event PrintReport As ICrPrintableReportView.PrintReportEventHandler Implements ICrPrintableReportView.PrintReport
        Protected SortOrderKey As String

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            MainTableName = "Report"
            SortOrderKey = "IdNo"

        End Sub

        Private Sub btnOk_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            Dim crArgs As New CrPrintableArgs
            Dim reportParameters As New Object
            Dim reportTitle As String = Messaging.TranslateCaption("Inventory Report By Warehouse")
            Dim reportFileName As String = "Inventory Report By Warehouse.Rpt"
            crArgs.ReportParameters = {"WarehouseIdNo", cboWarehouseIdNo.SelectedValue, "AllWarehouses", chkAllWarehouses.Checked}
            RaiseEvent PrintReport(reportFileName, crArgs)
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