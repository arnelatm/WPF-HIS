Imports System.Threading

<DebuggerStepThrough()>
Public Class EventAggregator
    Implements IEventAggregator

    Private ReadOnly _eventSubscribers As Dictionary(Of Type, List(Of WeakReference)) = New Dictionary(Of Type, List(Of WeakReference))()
    Private ReadOnly _lockSubscriberDictionary As Object = New Object()

    Public Sub PublishEvent(Of TEventType)(ByVal eventToPublish As TEventType) Implements IEventAggregator.PublishEvent
        PublishTheEvent(eventToPublish, False)
    End Sub

    Public Sub PublishEvent(Of TEventType, TE)(ByVal eventToPublish As TEventType) Implements IEventAggregator.PublishEvent
        PublishTheEvent(eventToPublish, False)
    End Sub

    Public Sub PublishEventAsync(Of TEventType)(ByVal eventToPublish As TEventType) Implements IEventAggregator.PublishEventAsync
        PublishTheEvent(eventToPublish, True)
    End Sub

    Private Sub PublishTheEvent(Of TEventType)(ByRef eventToPublish As TEventType, asynchronous As Boolean)

        Dim subscriberType = GetType(ISubscriber(Of)).MakeGenericType(GetType(TEventType))
        Dim subscribers = GetSubscriberList(subscriberType)
        Dim subscribersToBeRemoved As List(Of WeakReference) = New List(Of WeakReference)()

        For Each weaksubscriber In subscribers

            If weaksubscriber.IsAlive Then
                Dim subscriber = CType(weaksubscriber.Target, ISubscriber(Of TEventType))
                InvokeSubscriberEvent(Of TEventType)(eventToPublish, subscriber, asynchronous)
            Else
                subscribersToBeRemoved.Add(weaksubscriber)
            End If
        Next
        CheckSubscribersToBeRemoved(subscribers, subscribersToBeRemoved)
    End Sub

    Private Sub CheckSubscribersToBeRemoved(subscribers As List(Of WeakReference), subscribersToBeRemoved As List(Of WeakReference))

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
            ' ReSharper disable once VBPossibleMistakenCallToGetType.2
            Dim subscriberTypes = subscriber.[GetType]().GetInterfaces().Where(Function(i) i.IsGenericType AndAlso i.GetGenericTypeDefinition() = GetType(ISubscriber(Of)))
            Dim weakReference As WeakReference = New WeakReference(subscriber)

            For Each subscriberType In subscriberTypes
                Dim subscribers As List(Of WeakReference) = GetSubscriberList(subscriberType)
                subscribers.Add(weakReference)
            Next
        End SyncLock
    End Sub

    Private Sub InvokeSubscriberEvent(Of TEventType)(ByRef eventToPublish As TEventType, ByVal subscriber As ISubscriber(Of TEventType), ByVal asynchronous As Boolean)
        Dim syncContext As SynchronizationContext = SynchronizationContext.Current
        If syncContext Is Nothing Then
            syncContext = New SynchronizationContext()
        End If
        Dim lEventToPublish = eventToPublish
        If Not asynchronous Then
            syncContext.Send(Sub(s) subscriber.OnEventHandler(lEventToPublish), Nothing)
        Else
            syncContext.Post(Sub(s) subscriber.OnEventHandler(lEventToPublish), Nothing)
        End If
        eventToPublish = lEventToPublish
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

''Step 1 : Identify Events and their arguments in your application
'Public Class SampleEvent

'End Class

''Step 2 : Create a single global instance of Event Aggregator
'' Visible from Subscribers and Publishers
'Public Class Main(Of)
'    Public Sub New()
'        GlobalVariables.EventAggregator = New EventAggregator
'    End Sub

'End Class

''Step 3 : A Subscriber to subscribe to Events
'Public Class SampleSubscriber
'    Implements ISubscriber(Of SampleEvent)

'    Public Sub New()
'        GlobalVariables.EventAggregator.SubscribeEvent(Me)
'    End Sub

'    Public Sub OnEventHandler(e As SampleEvent) Implements ISubscriber(Of SampleEvent).OnEventHandler
'        MessageBox.Show("Passed Here")
'    End Sub

'End Class

''Step 4 : Publisher to publish the Events

'Public Class SamplePublisher()

'    Public Sub Test()
'        If GlobalVariables.EventAggregator IsNot Nothing Then
'            GlobalVariables.EventAggregator.PublishEvent(New SampleEvent())
'        End If
'    End Sub

'End Class