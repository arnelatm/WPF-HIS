Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interface

    Public Interface IPrintSetupView
        Inherits IView

        Property IdNo As Int16
        Property ComputerIdNo As Int16
        Property PaperOrientation As Int32?
        Property PaperSize As Int32?
        Property PaperSource As Int32?
        Property PrinterIdNo As Int16
        Property PrintJobIdNo As Int32


    End Interface

End Namespace