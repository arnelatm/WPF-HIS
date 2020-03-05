Imports AATM.PresentationLayer.Models

''' represents view of a list of SecurityObjects
Public Interface ISecurityObjectsView
    Inherits IView

    WriteOnly Property SecurityObjects As IList(Of SecurityObjectModel)
End Interface