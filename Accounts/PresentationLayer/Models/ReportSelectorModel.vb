Imports AATM.Common.PresentationLayer.Models

Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class ReportSelectorModel
        Inherits ReportModel

        Public Property ReportList As List(Of ReportModel)
        Public Property ReportGroupList As List(Of ReportGroupModel)

    End Class

End Namespace