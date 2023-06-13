Imports System.Globalization
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Presenters
Imports CrystalDecisions.ReportAppServer.Controllers

Namespace PresentationLayer.Views.Forms.Reports

    Public Class ReportPrinting
        Implements IPrintReportView

        Public Event OnPrintReport(reportFileName As String, pDatabaseConnectionName As String, args As Object, copies As Integer) Implements IPrintReportView.OnPrintReport

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.            

        End Sub

        Public Sub PrintReport(reportFileName, pDatabaseConnectionName, args, copies)
            RaiseEvent OnPrintReport(reportFileName, pDatabaseConnectionName, args, copies)
        End Sub

    End Class

End Namespace