Public Interface IEventAggregator

    Sub PublishEvent(Of TEventType)(ByVal eventToPublish As TEventType)

    Sub SubscribeEvent(ByVal subscriber As Object)

End Interface