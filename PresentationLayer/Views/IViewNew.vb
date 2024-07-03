' marker interface, no members

Public Interface IViewNew
    Inherits IView

    Property ViewDisplayName As String
    ReadOnly Property MainFieldsDictionary As Dictionary(Of String, Object)

    ' No members..
End Interface