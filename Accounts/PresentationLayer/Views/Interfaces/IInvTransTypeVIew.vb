Imports AATM.Presentation.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IInvTransTypeView
        Inherits IView

        Property AccountIdNo As Int16?
        Property Active As Boolean
        Property InventoryAction As String
        Property IdNo As Int16
        Property InvTransTypeCode As String
        Property InvTransTypeName As String
        Property InvTransTypeNameAra As String
        Property Notes As String

    End Interface

End Namespace