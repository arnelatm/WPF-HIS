Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface IOriginalMessagesView
        Inherits IView
        Property IdNo As Integer
        Property MessageKey As String
        Property Message As String
        Property Caption As String
        Property Notes As String
    End Interface

End Namespace