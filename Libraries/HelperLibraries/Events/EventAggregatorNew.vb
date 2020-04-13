Imports System
Imports System.Collections.Concurrent
Imports System.Collections.Generic

Namespace Events

    Public Class EventAggregatorNew
        Implements IEventAggregator

        Public Shared ReadOnly Property Instance As IEventAggregator = New EventAggregator()

        Private ReadOnly _subscriptions As ConcurrentDictionary(Of Type, List(Of Object)) = New ConcurrentDictionary(Of Type, List(Of Object))()

        Public Sub Publish(Of T As Libraries.IApplicationEvent)(ByVal message As T) Implements IEventAggregator.Publish
            Dim subscribers As List(Of Object)

            If _subscriptions.TryGetValue(GetType(T), subscribers) Then

                ' To Array creates a copy in case someone unsubscribes in their own handler
                For Each subscriber In subscribers.ToArray()
                    CType(subscriber, Action(Of T))(message)
                Next
            End If
        End Sub

        Public Sub Subscribe(Of T As Libraries.IApplicationEvent)(ByVal action As Action(Of T)) Implements IEventAggregator.Subscribe
            Dim subscribers = _subscriptions.GetOrAdd(GetType(T), Function(x) New List(Of Object)())

            SyncLock subscribers
                subscribers.Add(action)
            End SyncLock
        End Sub

        Public Sub Unsubscribe(Of T As Libraries.IApplicationEvent)(ByVal action As Action(Of T)) Implements IEventAggregator.Unsubscribe
            Dim subscribers As List(Of Object)

            If _subscriptions.TryGetValue(GetType(T), subscribers) Then

                SyncLock subscribers
                    subscribers.Remove(action)
                End SyncLock
            End If
        End Sub

        Public Sub Dispose()
            _subscriptions.Clear()
        End Sub

    End Class

End Namespace