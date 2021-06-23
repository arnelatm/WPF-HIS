Public Interface ISubscriber(Of TEventType)

    Sub OnEventHandler(ByRef eventType As TEventType)

End Interface

Public Interface ISubscriber(Of TEventType, TE)

    Sub OnEventHandler(ByRef eventType As TEventType, ByRef enumList As TE)

End Interface