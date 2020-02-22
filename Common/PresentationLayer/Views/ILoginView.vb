' represents login view with credentials.
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface ILoginView
        Inherits IView

        ReadOnly Property UserName As String
        ReadOnly Property Password As String
    End Interface

End Namespace