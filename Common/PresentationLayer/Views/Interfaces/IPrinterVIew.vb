Imports AATM.Presentation.Views

Namespace PresentationLayer.Views.Interface

    Public Interface IPrinterView
        Inherits IView

        Property HostOrIpName As String
        Property IdNo As Int16
        Property PaperOrientation As Int16
        Property PaperSize As Int16
        Property PaperSource As Integer
        Property PrinterCode As String
        Property PrinterName As String
        Event CheckPrinterClicked(sender As Object)
        Event PrinterChanged(sender As Object)

    End Interface

End Namespace