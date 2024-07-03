' marker interface, no members
Public Interface IView

    Property Errors As List(Of String)
    Property DataFilter As String
    'Function SetPresenter(presenter As Object)

    ' No members..
End Interface

Public Interface IViewDataEntry
    Inherits IView

    Property QuitOnSave As Boolean


    'Function SetPresenter(presenter As Object)

    ' No members..
End Interface
