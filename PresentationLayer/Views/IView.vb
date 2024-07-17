' marker interface, no members
Imports System.Globalization


Public Interface IView
    Property DataFilter As String
    Property Errors As List(Of String)
End Interface

Public Interface IViewForm
    Inherits IView

    Property FormCulture As CultureInfo
    'Function SetPresenter(presenter As Object)

    ' No members..
End Interface

Public Interface IViewDataEntry
    Inherits IViewForm

    Property QuitOnSave As Boolean


    'Function SetPresenter(presenter As Object)

    ' No members..
End Interface
