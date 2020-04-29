' represents login view with credentials.

Public Interface ILoginView
    Inherits IView
    ReadOnly Property IdNo As Int32
    ReadOnly Property UserName As String
    ReadOnly Property Password As String
End Interface