Imports System.Threading
Imports System.Threading.Tasks

'<DebuggerStepThrough()>
Public Class EventAggregator
    Implements IEventAggregator

    Private ReadOnly _eventSubscribers As Dictionary(Of Type, List(Of WeakReference)) = New Dictionary(Of Type, List(Of WeakReference))()
    Private ReadOnly _lockSubscriberDictionary As Object = New Object()

    Public Sub PublishEvent(Of TEventType)(ByVal eventToPublish As TEventType) Implements IEventAggregator.PublishEvent
        PublishTheEvent(eventToPublish, asynchronous:=False)
    End Sub

    Public Sub PublishEvent(Of TEventType, TE)(ByVal eventToPublish As TEventType) Implements IEventAggregator.PublishEvent
        PublishTheEvent(eventToPublish, asynchronous:=False)
    End Sub

    Public Sub PublishEventAsync(Of TEventType)(ByVal eventToPublish As TEventType) Implements IEventAggregator.PublishEventAsync
        PublishTheEvent(eventToPublish, asynchronous:=True)
    End Sub

    Private Sub PublishTheEvent(Of TEventType)(ByVal eventToPublish As TEventType, asynchronous As Boolean)
        Dim subscriberType = GetType(ISubscriber(Of)).MakeGenericType(GetType(TEventType))

        Dim subscribersList As List(Of WeakReference) = Nothing

        ' Get the actual list reference (create if missing) then take a snapshot for safe iteration
        SyncLock _lockSubscriberDictionary
            If Not _eventSubscribers.TryGetValue(subscriberType, subscribersList) Then
                subscribersList = New List(Of WeakReference)()
                _eventSubscribers.Add(subscriberType, subscribersList)
            End If
            ' create snapshot to iterate without holding the lock
            Dim snapshot = subscribersList.ToList()
            ' iterate outside lock
            For Each weaksubscriber In snapshot
                Dim target = TryCast(weaksubscriber.Target, Object)
                If target Is Nothing Then
                    ' mark for cleanup below
                    Continue For
                End If

                Dim subscriber = TryCast(target, ISubscriber(Of TEventType))
                If subscriber Is Nothing Then
                    Continue For
                End If

                InvokeSubscriberEvent(Of TEventType)(eventToPublish, subscriber, asynchronous)
            Next
        End SyncLock

        ' Clean dead weak refs (do separately under lock)
        CleanupDeadSubscribers(subscriberType)
    End Sub

    Private Sub CleanupDeadSubscribers(subscriberType As Type)
        SyncLock _lockSubscriberDictionary
            Dim existing As List(Of WeakReference) = Nothing
            If _eventSubscribers.TryGetValue(subscriberType, existing) Then
                existing.RemoveAll(Function(wr) Not wr.IsAlive)
                If existing.Count = 0 Then
                    ' optionally remove empty lists to reduce dictionary size
                    _eventSubscribers.Remove(subscriberType)
                End If
            End If
        End SyncLock
    End Sub

    Public Sub SubscribeEvent(ByVal subscriber As Object) Implements IEventAggregator.SubscribeEvent
        If subscriber Is Nothing Then
            Return
        End If

        SyncLock _lockSubscriberDictionary
            Dim subscriberTypes = subscriber.[GetType]().GetInterfaces().Where(Function(i) i.IsGenericType AndAlso i.GetGenericTypeDefinition() = GetType(ISubscriber(Of)))
            Dim weakReference As WeakReference = New WeakReference(subscriber)

            For Each subscriberType In subscriberTypes
                Dim subscribers As List(Of WeakReference) = Nothing
                If Not _eventSubscribers.TryGetValue(subscriberType, subscribers) Then
                    subscribers = New List(Of WeakReference)()
                    _eventSubscribers.Add(subscriberType, subscribers)
                End If

                ' prevent duplicate subscription by same instance (optional)
                If Not subscribers.Any(Function(wr) wr.IsAlive AndAlso Object.ReferenceEquals(wr.Target, subscriber)) Then
                    subscribers.Add(weakReference)
                End If
            Next
        End SyncLock
    End Sub

    Private Sub InvokeSubscriberEvent(Of TEventType)(ByVal eventToPublish As TEventType, ByVal subscriber As ISubscriber(Of TEventType), ByVal asynchronous As Boolean)
        If subscriber Is Nothing Then
            Return
        End If

        Dim syncContext As SynchronizationContext = SynchronizationContext.Current

        Dim safeInvoke = Sub()
                             Try
                                 subscriber.OnEventHandler(eventToPublish)
                             Catch ex As Exception
                                 ' Log or handle subscriber exception.
                                 ' Swallowing here to avoid one subscriber breaking others.
                                 ' Consider exposing an error handler/ILogger in future.
                             End Try
                         End Sub

        If asynchronous Then
            If syncContext IsNot Nothing Then
                Try
                    syncContext.Post(Sub(s) safeInvoke(), Nothing)
                Catch
                    ' If posting to context fails, fall back to thread pool
                    Task.Run(Sub() safeInvoke())
                End Try
            Else
                Task.Run(Sub() safeInvoke())
            End If
        Else
            If syncContext IsNot Nothing Then
                Try
                    syncContext.Send(Sub(s) safeInvoke(), Nothing)
                Catch ex As Exception
                    ' If Send fails (rare), invoke directly to avoid losing the event
                    Try
                        safeInvoke()
                    Catch
                        ' swallow - already handled in safeInvoke
                    End Try
                End Try
            Else
                ' No synchronization context — call directly
                safeInvoke()
            End If
        End If
    End Sub

    Private Sub CheckSubscribersToBeRemoved(subscribers As List(Of WeakReference), subscribersToBeRemoved As List(Of WeakReference))
        If subscribersToBeRemoved Is Nothing OrElse Not subscribersToBeRemoved.Any() Then
            Return
        End If

        SyncLock _lockSubscriberDictionary
            For Each remove In subscribersToBeRemoved
                subscribers.Remove(remove)
            Next
        End SyncLock
    End Sub

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