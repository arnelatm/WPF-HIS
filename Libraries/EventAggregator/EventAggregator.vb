Imports System.Threading

Public Class EventAggregator
    Implements IEventAggregator

    Private ReadOnly _eventSubscribers As Dictionary(Of Type, List(Of WeakReference)) = New Dictionary(Of Type, List(Of WeakReference))()
    Private ReadOnly _lockSubscriberDictionary As Object = New Object()

    Public Sub PublishEvent(Of TEventType)(ByVal eventToPublish As TEventType) Implements IEventAggregator.PublishEvent
        Dim subscriberType = GetType(ISubscriber(Of)).MakeGenericType(GetType(TEventType))
        Dim subscribers = GetSubscriberList(subscriberType)
        Dim subscribersToBeRemoved As List(Of WeakReference) = New List(Of WeakReference)()

        For Each weaksubscriber In subscribers

            If weaksubscriber.IsAlive Then
                Dim subscriber = CType(weaksubscriber.Target, ISubscriber(Of TEventType))
                InvokeSubscriberEvent(Of TEventType)(eventToPublish, subscriber)
            Else
                subscribersToBeRemoved.Add(weaksubscriber)
            End If
        Next

        If subscribersToBeRemoved.Any() Then

            SyncLock _lockSubscriberDictionary

                For Each remove In subscribersToBeRemoved
                    subscribers.Remove(remove)
                Next
            End SyncLock
        End If
    End Sub

    Public Sub SubscribeEvent(ByVal subscriber As Object) Implements IEventAggregator.SubscribeEvent
        SyncLock _lockSubscriberDictionary
            Dim subscriberTypes = subscriber.[GetType]().GetInterfaces().Where(Function(i) i.IsGenericType AndAlso i.GetGenericTypeDefinition() = GetType(ISubscriber(Of)))
            Dim weakReference As WeakReference = New WeakReference(subscriber)

            For Each subscriberType In subscriberTypes
                Dim subscribers As List(Of WeakReference) = GetSubscriberList(subscriberType)
                subscribers.Add(weakReference)
            Next
        End SyncLock
    End Sub

    Private Sub InvokeSubscriberEvent(Of TEventType)(ByVal eventToPublish As TEventType, ByVal subscriber As ISubscriber(Of TEventType))
        Dim syncContext As SynchronizationContext = SynchronizationContext.Current

        If syncContext Is Nothing Then
            syncContext = New SynchronizationContext()
        End If

        syncContext.Post(Sub(s) subscriber.OnEventHandler(eventToPublish), Nothing)
    End Sub

    Private Function GetSubscriberList(ByVal subscriberType As Type) As List(Of WeakReference)
        Dim subscribersList As List(Of WeakReference) = Nothing

        SyncLock _lockSubscriberDictionary
            Dim found As Boolean = _eventSubscribers.TryGetValue(subscriberType, subscribersList)

            If Not found Then
                subscribersList = New List(Of WeakReference)()
                _eventSubscribers.Add(subscriberType, subscribersList)
            End If
        End SyncLock

        Return subscribersList
    End Function

End Class