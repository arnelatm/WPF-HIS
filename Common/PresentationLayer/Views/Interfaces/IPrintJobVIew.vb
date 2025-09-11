Imports AATM.Presentation.Views

Namespace PresentationLayer.Views.Interface

    Public Interface IPrintJobView
        Inherits IView

        Property IdNo As Int16
        Property PaperOrientation As Int16
        Property PaperSize As Int16
        Property PaperSource As Integer
        Property PrinterIdNo As Int16
        Property PrintJobCode As String
        Property PrintJobName As String
        Property PrintJobNameAra As String
        Event PrinterChanged(sender As Object)

    End Interface

End Namespace