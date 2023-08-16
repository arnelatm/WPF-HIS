Imports System.Globalization
Imports AATM.Common
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.CrystalReportsHelper.CrystalReportPrinter
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Views.Forms.Reports

    Public Class ExpiryReportByWarehouse
        Implements ICrPrintableReportView


        Public Property MainTableName As String
        Protected SortOrderKey As String
        Private Event PrintReport As ICrPrintableReportView.PrintReportEventHandler Implements ICrPrintableReportView.PrintReport

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            MainTableName = "Report"
            SortOrderKey = "IdNo"

        End Sub

        Private Sub btnOk_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            If dtpExpiryDate.Value Is Nothing Then
                Messaging.Show(True, "MsgDateCannotBeBlank")
            Else
                Dim reportArgs As New CrPrintableArgs
                Dim reportParameters As New Object
                reportArgs.ReportParameters = {cboWarehouseIdNo.SelectedItem.IdNo, "WarehouseIdNo",
                                               chkAllWarehouses.Checked, "AllWarehouses",
                                               dtpExpiryDate.Value, "ExpiryDate"}
                Dim reportFileName As String = "Inventory Expiry Report By Warehouse.Rpt"
                RaiseEvent PrintReport(reportFileName, reportArgs)
            End If
        End Sub

        Private Sub CButton2_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub


        Private Sub ExpiryReportByWarehouse_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Ea.PublishEvent(New GetControlDataSource("Warehouse", cboWarehouseIdNo))
            cboWarehouseIdNo.EditingMode = True
        End Sub


    End Class

End Namespace