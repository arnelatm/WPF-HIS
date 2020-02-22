Imports AATM.PresentationLayer.Views
Imports AATM.Common.PresentationLayer.Models

Namespace PresentationLayer.Views

    ''' represents view of a list of SecurityObjects
    Public Interface ISecurityObjectsView
        Inherits IView

        WriteOnly Property SecurityObjects As IList(Of SecurityObjectModel)
    End Interface

End Namespace