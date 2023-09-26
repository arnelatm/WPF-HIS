Imports System.Globalization
Imports AATM.Common
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.CrystalReportsHelper.CrystalReportPrinter
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Views.Forms.Reports

    Public Class DocumentReportList
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
            chkAllDocuments.Checked = True
        End Sub

        Private Sub btnOk_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            Dim reportArgs As New CrPrintableArgs
            Dim reportParameters As New Object
            Dim language As String = Microsoft.VisualBasic.Strings.Left(FormCulture.Name, FormCulture.Name.IndexOf("-", StringComparison.Ordinal))
            Dim reportTitle As String = Messaging.TranslateCaption("Document Report List")
            reportArgs.ReportParameters = {language, "Language",
                                           reportTitle, "ReportTitle",
                                           GlobalVariables.BranchIdNo, "BranchIdNo",
                                           chkAllDocuments.Checked, "AllDocumentTypes",
                                           cboDocumentType.SelectedItem("Code"), "DocumentType"
                                           }

            Dim reportFileName As String = "Document List By Branch.Rpt"
            RaiseEvent PrintReport(reportFileName, reportArgs, False)
        End Sub

        Private Sub CButton2_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub


        Private Sub DocumentReportList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Dim docTypeEnum As New DocumentTypeSelection
            Ea.PublishEvent(New GetControlEnumDataSource(docTypeEnum, cboDocumentType))
            cboDocumentType.EditingMode = True
        End Sub


    End Class

End Namespace