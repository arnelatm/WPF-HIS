Imports System.Globalization
Imports AATM.Common
Imports AATM.Libraries.CrystalReportsHelper.CrystalReportPrinter
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Views.Forms.Reports

    Public Class PayrollPrinting
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
            Dim language As String
            Dim curCulture = CultureInfo.CurrentCulture
            Dim reportTitle As String = cboPayroll.Text
            Dim reportFileName As String = "Payroll Report.Rpt"
            Dim estName As String
            language = Strings.Left(curCulture.Name, curCulture.Name.IndexOf("-", StringComparison.Ordinal))
            If language = "ar" Then
                estName = GlobalVariables.EstablishmentNameAra
            Else
                estName = GlobalVariables.EstablishmentName
            End If
            crArgs.Language = CultureInfo.CurrentCulture.Name
            crArgs.ReportParameters = {reportTitle, "ReportTitle",
                                        CultureInfo.CurrentCulture.Name, "Language",
                                        GlobalVariables.EstablishmentName, "EstablishmentName",
                                        cboPayroll.SelectedValue, "PayrollIdNo"}

            RaiseEvent PrintReport(reportFileName, crArgs, False)
        End Sub

        Private Sub CButton2_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub


        Private Sub PayrollPrinting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Ea.PublishEvent(New GetControlDataSource("Payroll", cboPayroll, Nothing, Nothing, "IdNo", False))
            cboPayroll.EditingMode = True
        End Sub


    End Class

End Namespace
