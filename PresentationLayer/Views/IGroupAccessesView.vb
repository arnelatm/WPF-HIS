Imports AATM.PresentationLayer.Models

''' represents view of a list of GroupAccesses
Public Interface IGroupAccessesView
    Inherits IView

    Property GroupAccesses As IList(Of GroupAccessModel)
End Interface