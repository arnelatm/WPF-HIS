Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interface

    Public Interface IPrintJobView
        Inherits IView

        Property ComputerIdNo As Int16
        Property IdNo As Int16
        Property PaperOrientation As Int32?
        Property PaperSize As Int32?
        Property PaperSource As Int32?
        Property PrinterIdNo As Int16?
        Property PrintJobName As Int32?

    End Interface

End Namespace