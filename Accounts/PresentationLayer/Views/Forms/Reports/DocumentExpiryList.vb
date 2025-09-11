Imports System.Globalization
Imports AATM.Common
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.CrystalReportsHelper.CrystalReportPrinter
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.Messaging
Imports AATM.Presentation.Events

Namespace PresentationLayer.Views.Forms.Reports

    Public Class DocumentExpiryList
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
            dtpExpiryDate.Value = DateAndTime.DateAdd(DateInterval.Month, 1, DateAndTime.Now())
            chkAllDocuments.Checked = True
        End Sub

        Private Sub btnOk_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            If dtpExpiryDate.Value Is Nothing Then
                MessagingService.Show(True, "MsgDateCannotBeBlank")
            Else
                Dim reportArgs As New CrPrintableArgs
                Dim reportParameters As New Object
                Dim language As String = Microsoft.VisualBasic.Strings.Left(FormCulture.Name, FormCulture.Name.IndexOf("-", StringComparison.Ordinal))
                Dim reportTitle As String = MessagingService.TranslateCaption("Document Expiry Report")
                reportArgs.ReportParameters = {language, "Language",
                                               reportTitle, "ReportTitle",
                                               GlobalVariables.BranchIdNo, "BranchIdNo",
                                               dtpExpiryDate.Value, "ExpiryDate",
                                               chkAllDocuments.Checked, "AllDocumentTypes",
                                               cboDocumentType.SelectedItem("Code"), "DocumentType"
                                               }
                Dim reportFileName As String = "Document Expiry Report By Branch.Rpt"
                RaiseEvent PrintReport(reportFileName, reportArgs, False)
            End If
        End Sub

        Private Sub CButton2_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub


        Private Sub DocumentExpiryList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Dim docTypeEnum As New DocumentTypeSelection
            Ea.PublishEvent(New GetControlEnumDataSource(docTypeEnum, cboDocumentType))
            cboDocumentType.EditingMode = True
        End Sub


    End Class

End Namespace