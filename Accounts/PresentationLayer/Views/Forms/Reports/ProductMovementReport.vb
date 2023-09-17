Imports System.Globalization
Imports AATM.Common
Imports AATM.Libraries.CrystalReportsHelper.CrystalReportPrinter
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Views.Forms.Reports

    Public Class ProductMovementReport
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
            dtpBeginningDate.Value = GlobalFunctions.GregorianDateSerial(Today.Year, 1, 1)
            dtpEndingDate.Value = DateAndTime.Now()
        End Sub

        Private Sub btnOk_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            If dtpBeginningDate.Value Is Nothing Then
                Messaging.Show(True, "MsgDateCannotBeBlank")
            Else
                Dim reportArgs As New CrPrintableArgs
                Dim reportParameters As New Object
                Dim reportTitle As String = Messaging.TranslateCaption("Product Movement Report By Warehouse")
                reportArgs.ReportParameters = {CultureInfo.CurrentCulture.Name, "Language",
                                               reportTitle, "ReportTitle",
                                               cboWarehouseIdNo.SelectedItem("IdNo"), "WarehouseIdNo",
                                               cboProductIdNo.SelectedItem("IdNo"), "ProductIdNo",
                                               dtpBeginningDate.Value, "BeginningDate",
                                               dtpEndingDate.Value, "EndingDate",
                                               GlobalVariables.EstablishmentName, "EstablishmentName"}
                Dim reportFileName As String = "Product Movement Report By Warehouse.Rpt"
                RaiseEvent PrintReport(reportFileName, reportArgs, False)
            End If
        End Sub

        Private Sub CButton2_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub


        Private Sub ProductMovementReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Ea.PublishEvent(New GetControlDataSource("Warehouse", cboWarehouseIdNo, "BranchIdNo = " & GlobalVariables.BranchIdNo.ToString()))
            Ea.PublishEvent(New GetControlDataSource("Product", cboProductIdNo, "BranchIdNo = " & GlobalVariables.BranchIdNo.ToString()))
            cboWarehouseIdNo.EditingMode = True
            cboProductIdNo.EditingMode = True
        End Sub


    End Class

End Namespace