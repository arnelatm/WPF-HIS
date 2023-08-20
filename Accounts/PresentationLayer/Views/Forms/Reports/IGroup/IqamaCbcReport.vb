Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Common
Imports AATM.Libraries.CrystalReportsHelper.CrystalReportPrinter
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms.Reports

    Public Class IqamaCbcReport
        Implements ICrPrintableReportView

        Public Property MainTableName As String
        Public Event PrintReport(reportFileName As String, reportArgs As CrPrintableArgs, printDirectly As Boolean) Implements ICrPrintableReportView.PrintReport
        Protected SortOrderKey As String
        Private _mode As String

        Public Sub New(mode As String)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            MainTableName = "CBCResults"
            SortOrderKey = "IdNo"
            txtSampleNo.Text = ""
            _mode = mode
        End Sub

        Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            Dim parameters As New ArrayList
            Dim reportName As String
            parameters.Add({"ReportTitle", "Complete Blood Count"})
            If _mode = "SampleNo" Then
                parameters.Add({"SampleNo", txtSampleNo.GetValue(Of Int32)})
                reportName = "CBCReportDyMindBySampleNo.Rpt"
            Else
                parameters.Add({"InvoiceNo", txtSampleNo.GetValue(Of Int32)})
                reportName = "CBCReportDyMindByInvoiceNo.Rpt"
            End If
            Dim cForm As New ReportFormIGroup(reportName, FormCulture, parameters)
            cForm.Show()



            Dim reportFileName As String
            Dim reportArgs As New CrPrintableArgs
            Dim reportParameters As New Object
            Dim estName As String
            Dim language = Strings.Left(CultureInfo.CurrentCulture.Name, CultureInfo.CurrentCulture.Name.IndexOf("-"))
            If language = "ar" Then
                estName = GlobalVariables.EstablishmentNameAra
            Else
                estName = GlobalVariables.EstablishmentName
            End If
            If _mode = "SampleNo" Then
                parameters.Add({"SampleNo", txtSampleNo.GetValue(Of Int32)})
                reportFileName = "CBCReportDyMindBySampleNo.Rpt"
            Else
                parameters.Add({"InvoiceNo", txtSampleNo.GetValue(Of Int32)})
                reportFileName = "CBCReportDyMindByInvoiceNo.Rpt"
            End If

            reportArgs.DataBaseConnectionName = "IGroupClinic"
            reportArgs.ReportParameters = {"Complete Blood Count", "ReportTitle",
                                           txtSampleNo.GetValue(Of Int32), IIf(_mode = "SampleNo", "SampleNo", "InvoiceNo"),
                                           txtSampleNo.GetValue(Of Int32), "ReportNumber"}
            RaiseEvent PrintReport(reportFileName, reportArgs, False)

        End Sub

        Private Sub CButton2_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

    End Class

End Namespace