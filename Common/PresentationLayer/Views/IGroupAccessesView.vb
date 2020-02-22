Imports AATM.PresentationLayer.Views
Imports AATM.Common.PresentationLayer.Models

Namespace PresentationLayer.Views

    ''' represents view of a list of GroupAccesses
    Public Interface IGroupAccessesView
        Inherits IView

        Property GroupAccesses As IList(Of GroupAccessModel)
    End Interface

End Namespace