Friend Interface IEventAggregator
    Sub PublishEvent(Of TEventType)(eventToPublish As TEventType)
    Sub PublishEvent(Of TEventType, TE)(eventToPublish As TEventType)
    Sub PublishEventAsync(Of TEventType)(eventToPublish As TEventType)
    Sub SubscribeEvent(subscriber As Object)
End Interface
