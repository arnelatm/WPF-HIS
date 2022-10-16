Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interface

    Public Interface IPrintJobView
        Inherits IView

        Property ComputerName As String
        Property IdNo As Int16
        Property PaperOrientation As Int16?
        Property PaperSize As Int32?
        Property PaperSource As Int16?
        Property PrinterName As String
        Property PrintJobName As String

    End Interface

End Namespace