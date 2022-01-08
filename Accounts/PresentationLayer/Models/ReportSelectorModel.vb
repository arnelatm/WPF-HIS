Imports AATM.PresentationLayer.Models

Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class ReportSelectorModel
        Inherits ReportModel

        Public Property ReportList As List(Of ReportModel)

    End Class

End Namespace