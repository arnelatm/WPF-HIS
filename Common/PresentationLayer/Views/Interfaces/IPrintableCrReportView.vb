Imports AATM.Libraries.CrystalReportsHelper.CrystalReportPrinter

Namespace PresentationLayer.Views.Interface


    Public Interface IPrintableCrReportView
        Inherits AATM.Presentation.Views.IView

        Property ReportFileName As String
        Property PrintArgs As CrPrintableArgs

        Event PrintReport(ByVal sender As IReportPrinterView)

    End Interface

End Namespace