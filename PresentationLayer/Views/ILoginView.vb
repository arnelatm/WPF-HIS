' represents login view with credentials.


Public Interface ILoginView
    Inherits IView

    ReadOnly Property UserName As String
    ReadOnly Property Password As String
End Interface