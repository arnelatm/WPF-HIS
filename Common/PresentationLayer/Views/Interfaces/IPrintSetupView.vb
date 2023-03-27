Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interface

    Public Interface IPrintSetupView
        Inherits IView

        Property IdNo As Int16
        Property ComputerIdNo As Int16
        Property PaperOrientation As Int16
        Property PaperSize As Int16
        Property PaperSource As Int16
        Property PrinterIdNo As Int16
        Property PrintJobIdNo As Int16
        Property PrintSetupCode As String
        Property PrintSetupName As String
        Event PrinterChanged(sender As Object)
    End Interface

End Namespace