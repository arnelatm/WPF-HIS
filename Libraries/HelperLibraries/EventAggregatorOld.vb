Imports System
Imports System.Collections.Concurrent
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Linq
Imports System.Threading
Imports System.Threading.Tasks

' =====================================================================================
' CHANGED: Re-designed EventAggregator for thread safety, explicit unsubscribe,
'          optional UI marshaling, diagnostics, weak/strong handlers, async support.
'          Old implementation used a Dictionary(Of Type, List(Of WeakReference)) and
'          reflection-based ISubscriber discovery each call. Enumeration outside lock
'          risked race conditions. No unsubscribe token. Only weak refs. Send/Post
'          used SynchronizationContext.Current at publish time (non-deterministic).
' =====================================================================================

#Region "New Public Contracts"

' ADDED: SubscriptionToken for deterministic unsubscription (previously only GC cleanup).
Public NotInheritable Class SubscriptionToken
    Private ReadOnly _unsubscribe As Action
    Friend Sub New(unsubscribe As Action)
        _unsubscribe = unsubscribe
    End Sub
    Public Sub Unsubscribe()
        _unsubscribe?.Invoke()
    End Sub
End Class

' ADDED: New delegate-based interface (lighter than reflection over ISubscriber(Of T)).
' NOTE: Keep legacy interface methods below for backward compatibility.
Public Interface IEventAggregator
    Function Subscribe(Of TMessage)(handler As Action(Of TMessage),
                                    Optional strongReference As Boolean = False,
                                    Optional marshalToUI As Boolean = True) As SubscriptionToken
    Sub Publish(Of TMessage)(message As TMessage,
                             Optional marshalToUI As Boolean = True)
    Function PublishAsync(Of TMessage)(message As TMessage,
                                       Optional marshalToUI As Boolean = True,
                                       Optional cancellationToken As CancellationToken = Nothing) As Task
    Sub Unsubscribe(token As SubscriptionToken)
    Sub EnableDiagnostics(enable As Boolean)
    Property ExternalLogSink As Action(Of String)

    ' LEGACY: These members mirror the old usage pattern (object implementing ISubscriber(Of T)).
    ' They are optional – remove when all callers migrate to delegate API.
    Sub SubscribeEvent(subscriber As Object)
    Sub PublishEvent(Of TEventType)(eventToPublish As TEventType)
    Sub PublishEventAsync(Of TEventType)(eventToPublish As TEventType)
End Interface

' LEGACY SUPPORT: Original pattern relied on interface ISubscriber(Of T).
' Keep this interface definition here if not globally defined; else exclude.
' Remove when last legacy subscriber is refactored.
Public Interface ISubscriber(Of T)
    Sub OnEventHandler(message As T)
End Interface

#End Region

#Region "Internal Handler Abstractions"
' ADDED: Internal abstractions unify weak & strong handlers.

Friend Interface IHandlerRef
    ReadOnly Property IsAlive As Boolean
    Function TryInvoke(message As Object) As Boolean
    Function Matches(d As [Delegate]) As Boolean
End Interface

Friend NotInheritable Class StrongHandlerRef
    Implements IHandlerRef
    Private ReadOnly _delegate As [Delegate]
    Public Sub New(d As [Delegate]) : _delegate = d : End Sub
    Public ReadOnly Property IsAlive As Boolean Implements IHandlerRef.IsAlive
        Get
            Return True
        End Get
    End Property
    Public Function TryInvoke(message As Object) As Boolean Implements IHandlerRef.TryInvoke
        _delegate.DynamicInvoke(message)
        Return True
    End Function
    Public Function Matches(d As [Delegate]) As Boolean Implements IHandlerRef.Matches
        Return _delegate = d
    End Function
End Class

Friend NotInheritable Class WeakHandlerRef
    Implements IHandlerRef
    Private ReadOnly _method As Reflection.MethodInfo
    Private ReadOnly _targetRef As WeakReference
    Public Sub New(d As [Delegate])
        _method = d.Method
        If d.Target IsNot Nothing Then _targetRef = New WeakReference(d.Target)
    End Sub
    Public ReadOnly Property IsAlive As Boolean Implements IHandlerRef.IsAlive
        Get
            If _targetRef Is Nothing Then Return True
            Return _targetRef.IsAlive
        End Get
    End Property
    Public Function TryInvoke(message As Object) As Boolean Implements IHandlerRef.TryInvoke
        If _targetRef Is Nothing Then
            _method.Invoke(Nothing, {message})
            Return True
        End If
        Dim tgt = _targetRef.Target
        If tgt Is Nothing Then Return False
        _method.Invoke(tgt, {message})
        Return True
    End Function
    Public Function Matches(d As [Delegate]) As Boolean Implements IHandlerRef.Matches
        If d.Method IsNot _method Then Return False
        If _targetRef Is Nothing AndAlso d.Target Is Nothing Then Return True
        If _targetRef IsNot Nothing AndAlso d.Target Is _targetRef.Target Then Return True
        Return False
    End Function
End Class

Friend NotInheritable Class HandlerEntry
    Public ReadOnly Handler As IHandlerRef
    Public ReadOnly MarshalToUI As Boolean
    Public Sub New(handler As IHandlerRef, marshalToUI As Boolean)
        Me.Handler = handler
        Me.MarshalToUI = marshalToUI
    End Sub
End Class
#End Region

Public NotInheritable Class EventAggregatorOld
    Implements IEventAggregator

    ' CHANGED: ConcurrentDictionary for thread-safe handler list lookup.
    Private ReadOnly _handlers As New ConcurrentDictionary(Of Type, List(Of HandlerEntry))()

    ' ADDED: Captured UI context at construction (deterministic, not per-publish Current).
    Private ReadOnly _uiContext As SynchronizationContext

    ' CHANGED: Diagnostics flag (replaces _diagnosticsEnabled & DebugLog pattern).
    Private _diagnostics As Boolean

    Public Sub New(Optional uiContext As SynchronizationContext = Nothing)
        _uiContext = If(uiContext, SynchronizationContext.Current)
    End Sub

    ' ADDED: New diagnostics toggle method (replacement for SetDiagnostics).
    Public Sub EnableDiagnostics(enable As Boolean) Implements IEventAggregator.EnableDiagnostics
        _diagnostics = enable
        Log($"Diagnostics {(If(enable, "ENABLED", "DISABLED"))}")
    End Sub

    ' LEGACY: Preserve old method signature name (SetDiagnostics) for minimal breakage.
    Public Sub SetDiagnostics(enabled As Boolean)
        EnableDiagnostics(enabled)
    End Sub

    Public Property ExternalLogSink As Action(Of String) Implements IEventAggregator.ExternalLogSink

    ' =================================================================================
    ' SUBSCRIBE (new delegate API)
    ' =================================================================================
    Public Function Subscribe(Of TMessage)(handler As Action(Of TMessage),
                                           Optional strongReference As Boolean = False,
                                           Optional marshalToUI As Boolean = True) As SubscriptionToken _
                                           Implements IEventAggregator.Subscribe
        If handler Is Nothing Then Throw New ArgumentNullException(NameOf(handler))
        Dim ref As IHandlerRef = If(strongReference,
                                    CType(New StrongHandlerRef(handler), IHandlerRef),
                                    New WeakHandlerRef(handler))
        Dim list = _handlers.GetOrAdd(GetType(TMessage), Function(_) New List(Of HandlerEntry)())
        SyncLock list
            list.Add(New HandlerEntry(ref, marshalToUI))
            Log($"Subscribe {GetType(TMessage).Name} (count={list.Count}, strong={strongReference}, ui={marshalToUI})")
        End SyncLock
        Return New SubscriptionToken(Sub() UnsubscribeInternal(GetType(TMessage), handler))
    End Function

    Public Sub Unsubscribe(token As SubscriptionToken) Implements IEventAggregator.Unsubscribe
        token?.Unsubscribe()
    End Sub

    Private Sub UnsubscribeInternal(messageType As Type, d As [Delegate])
        Dim list As List(Of HandlerEntry) = Nothing
        If Not _handlers.TryGetValue(messageType, list) Then Return
        SyncLock list
            Dim removed = list.RemoveAll(Function(e) e.Handler.Matches(d))
            If removed > 0 Then Log($"Unsubscribe {messageType.Name} removed={removed} remaining={list.Count}")
            If list.Count = 0 Then
                Dim trash As List(Of HandlerEntry) = Nothing
                _handlers.TryRemove(messageType, trash)
            End If
        End SyncLock
    End Sub

    ' =================================================================================
    ' PUBLISH (sync + async)
    ' =================================================================================
    Public Sub Publish(Of TMessage)(message As TMessage,
                                    Optional marshalToUI As Boolean = True) Implements IEventAggregator.Publish
        ' ADDED: Synchronous variant waits for UI marshaled handlers (if any).
        PublishCore(message, marshalToUI, synchronous:=True).GetAwaiter().GetResult()
    End Sub

    Public Function PublishAsync(Of TMessage)(message As TMessage,
                                              Optional marshalToUI As Boolean = True,
                                              Optional cancellationToken As CancellationToken = Nothing) As Task _
                                              Implements IEventAggregator.PublishAsync
        Return PublishCore(message, marshalToUI, synchronous:=False, cancellationToken:=cancellationToken)
    End Function

    Private Function PublishCore(Of TMessage)(message As TMessage,
                                              marshalToUI As Boolean,
                                              synchronous As Boolean,
                                              Optional cancellationToken As CancellationToken = Nothing) As Task
        Dim t = GetType(TMessage)
        Dim list As List(Of HandlerEntry) = Nothing
        If Not _handlers.TryGetValue(t, list) Then
            Log($"Publish {t.Name}: no subscribers")
            Return Task.CompletedTask
        End If

        Dim snapshot As HandlerEntry()
        SyncLock list
            list.RemoveAll(Function(e) Not e.Handler.IsAlive)
            snapshot = list.ToArray()
        End SyncLock
        If snapshot.Length = 0 Then
            Log($"Publish {t.Name}: all handlers dead")
            Return Task.CompletedTask
        End If

        Log($"Publish {t.Name}: handlers={snapshot.Length}, sync={synchronous}")

        Dim tasks As New List(Of Task)(snapshot.Length)

        For Each entry In snapshot
            cancellationToken.ThrowIfCancellationRequested()
            Dim targetMarshal = marshalToUI AndAlso entry.MarshalToUI
            Dim invokeAction As Action =
                Sub()
                    If Not entry.Handler.IsAlive Then Exit Sub
                    Try
                        entry.Handler.TryInvoke(message)
                    Catch ex As Exception
                        Log($"Handler exception {t.Name}: {ex.Message}")
                    End Try
                End Sub

            If targetMarshal AndAlso _uiContext IsNot Nothing AndAlso SynchronizationContext.Current IsNot _uiContext Then
                If synchronous Then
                    Dim done = New TaskCompletionSource(Of Object)()
                    _uiContext.Post(Sub(_)
                                        Try
                                            invokeAction()
                                            done.SetResult(Nothing)
                                        Catch ex As Exception
                                            done.SetException(ex)
                                        End Try
                                    End Sub, Nothing)
                    tasks.Add(done.Task)
                Else
                    Dim tcs = New TaskCompletionSource(Of Object)()
                    _uiContext.Post(Sub(_)
                                        Try
                                            invokeAction()
                                            tcs.SetResult(Nothing)
                                        Catch ex As Exception
                                            tcs.SetException(ex)
                                        End Try
                                    End Sub, Nothing)
                    tasks.Add(tcs.Task)
                End If
            Else
                If synchronous Then
                    invokeAction()
                Else
                    tasks.Add(Task.Run(Sub() invokeAction(), cancellationToken))
                End If
            End If
        Next

        If synchronous Then
            If tasks.Count > 0 Then Task.WaitAll(tasks.ToArray())
            Return Task.CompletedTask
        End If
        Return Task.WhenAll(tasks)
    End Function

    ' =================================================================================
    ' LEGACY COMPATIBILITY REGION
    ' =================================================================================
    ' CHANGED: Old API used SubscribeEvent(object implementing ISubscriber(Of T)).
    '          We adapt by reflecting its generic interfaces and wiring delegates.
    '
    ' REMOVED (old): PublishEvent(Of TEventType, TE) duplicate overload (ignored second generic).
    '                Not reintroduced; callers should remove the extra type argument.
    '
    ' NOTE: Remove this entire region after migrating all callers to Subscribe / Publish.
#Region "Legacy API"

    Public Sub SubscribeEvent(subscriber As Object) Implements IEventAggregator.SubscribeEvent
        If subscriber Is Nothing Then Return
        ' Discover ISubscriber(Of T) interfaces.
        Dim ifaces = subscriber.GetType().GetInterfaces().
            Where(Function(i) i.IsGenericType AndAlso i.GetGenericTypeDefinition() = GetType(ISubscriber(Of)))
        For Each it In ifaces
            Dim messageType = it.GetGenericArguments()(0)
            ' Build delegate: Sub(msg As T) => DirectCast(subscriber, ISubscriber(Of T)).OnEventHandler(msg)
            Dim subscribeMethod = GetType(EventAggregator).GetMethod(NameOf(SubscribeGeneric), Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
            Dim closed = subscribeMethod.MakeGenericMethod(messageType)
            closed.Invoke(Me, {subscriber})
        Next
        Log($"LEGACY SubscribeEvent: {subscriber.GetType().Name}")
    End Sub

    ' Helper generic invoked via reflection above.
    Private Sub SubscribeGeneric(Of T)(subscriber As Object)
        Dim typed = DirectCast(subscriber, ISubscriber(Of T))
        Subscribe(Of T)(Sub(m) typed.OnEventHandler(m))
    End Sub

    Public Sub PublishEvent(Of TEventType)(eventToPublish As TEventType) Implements IEventAggregator.PublishEvent
        Publish(eventToPublish)
    End Sub

    Public Sub PublishEventAsync(Of TEventType)(eventToPublish As TEventType) Implements IEventAggregator.PublishEventAsync
        ' Fire & forget to mimic old semantics.
        Dim _ = PublishAsync(eventToPublish)
    End Sub

#End Region

    ' =================================================================================
    ' Logging
    ' =================================================================================
    Private Sub Log(msg As String)
        If Not _diagnostics Then Return
        Dim line = $"[EventAggregator] {Date.Now:HH:mm:ss.fff} {msg}"
        Debug.WriteLine(line)
        ExternalLogSink?.Invoke(line)
    End Sub

End Class

