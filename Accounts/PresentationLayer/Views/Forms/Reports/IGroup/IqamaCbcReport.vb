Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Common
Imports AATM.Libraries.CrystalReportsHelper.CrystalReportPrinter
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports CrystalDecisions.ReportAppServer.DataDefModel

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
            If _mode = "SampleNo" Then
                lblSampleNumber.Text = "Sample Number"
            Else
                lblSampleNumber.Text = "Invoice Number"
            End If
        End Sub

        Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            Dim parameters As New Object
            Dim reportFileName As String
            If _mode = "SampleNo" Then
                parameters = {"Complete Blood Count", "ReportTitle",
                              txtSampleNo.GetValue(Of Int32), "SampleNo",
                              GetEstablishmentName("en"), "EstablishmentName"
                             }
                reportFileName = "CBCReportDyMindBySampleNo.Rpt"
            Else
                parameters = {"Complete Blood Count", "ReportTitle",
                              txtSampleNo.GetValue(Of Int32), "InvoiceNo",
                              GetEstablishmentName("en"), "EstablishmentName"
                              }
                reportFileName = "CBCReportDyMindByInvoiceNo.Rpt"
            End If

            ShowReportToScreen(reportFileName, parameters, "IGroupClinic")

        End Sub

        Private Sub CButton2_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

    End Class

End Namespace