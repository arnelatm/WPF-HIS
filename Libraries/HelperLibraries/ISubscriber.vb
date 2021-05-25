Public Interface ISubscriber(Of TEventType)

    Sub OnEventHandler(ByRef eventType As TEventType)

End Interface