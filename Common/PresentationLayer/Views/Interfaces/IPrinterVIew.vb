Imports AATM.Libraries.Lookup
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interface

    Public Interface IPrinterView
        Inherits IView

        Property DefaultPaperOrientation As Int32?
        Property DefaultPaperSize As Int32?
        Property DefaultPaperSource As Int32?
        Property HostOrIpName As String
        Property IdNo As Int16
        Property PrinterCode As String
        Property PrinterName As String
        Property InstalledPrinter As String
        Event CheckPrinterClicked(sender As Object)

        Event PrinterChanged(sender As Object)

    End Interface

End Namespace