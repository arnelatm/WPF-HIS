Public Interface ISubscriber(Of TEventType)

    Sub OnEventHandler(e As TEventType)

End Interface