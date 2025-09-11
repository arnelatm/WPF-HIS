Imports System.Globalization
Imports AATM.Common
Imports AATM.Libraries.CrystalReportsHelper.CrystalReportPrinter
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.Messaging
Imports AATM.Presentation.Events

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
                MessagingService.Show(True, "MsgDateCannotBeBlank")
            Else
                Dim reportArgs As New CrPrintableArgs
                Dim reportParameters As New Object
                Dim reportTitle As String = MessagingService.TranslateCaption("Product Movement Report By Warehouse")
                Dim unitDescriptionObj As New Object
                Dim myOtherData As New OtherData("GetUnitDescription", cboProductIdNo.SelectedItem("IdNo"), unitDescriptionObj)
                Ea.PublishEvent(myOtherData)
                Dim unitsDescription As String = myOtherData.ReturnArgs.ToString()
                reportArgs.ReportParameters = {cboProductIdNo.SelectedItem("IdNo"), "ProductIdNo",
                                               cboWarehouseIdNo.SelectedItem("IdNo"), "WarehouseIdNo",
                                               reportTitle, "ReportTitle",
                                               GlobalVariables.EstablishmentName, "EstablishmentName",
                                               CultureInfo.CurrentCulture.Name, "Language",
                                               cboWarehouseIdNo.SelectedItem("Name"), "WarehouseName",
                                               dtpBeginningDate.Value, "BeginningDate",
                                               dtpEndingDate.Value, "EndingDate",
                                               unitsDescription, "UnitsDescription"
                                               }
                Dim reportFileName As String = "Product Movement Report By Warehouse.Rpt"
                RaiseEvent PrintReport(reportFileName, reportArgs, False)
            End If
        End Sub

        Private Sub CButton2_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub


        Private Sub ProductMovementReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Ea.PublishEvent(New GetControlDataSource("Warehouse", cboWarehouseIdNo, Nothing, "BranchIdNo = " & GlobalVariables.BranchIdNo.ToString()))
            Ea.PublishEvent(New GetControlDataSource("Product", cboProductIdNo, Nothing, "BranchIdNo = " & GlobalVariables.BranchIdNo.ToString()))
            cboWarehouseIdNo.EditingMode = True
            cboProductIdNo.EditingMode = True
        End Sub


    End Class

End Namespace