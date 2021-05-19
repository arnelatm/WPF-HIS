' marker interface, no members
Imports AATM.Libraries

Public Interface IViewNew
    Property Errors As List(Of String)

    Function GetEventAggregator() As EventAggregator

    ' No members..
End Interface