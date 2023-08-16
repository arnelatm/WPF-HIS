Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.CrystalReportsHelper.CrystalReportPrinter
Imports AATM.Libraries.Lookup
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interface


    Public Interface IPrintableCrReportView
        Inherits AATM.PresentationLayer.Views.IView

        Property ReportFileName As String
        Property PrintArgs As CrPrintableArgs

        Event PrintReport(ByVal sender As IReportPrinterView)

    End Interface

End Namespace