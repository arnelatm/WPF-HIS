Imports System

Module EventHelpers

    Public Sub [RaiseEvent](ByVal objectRaisingEvent As Object, ByVal eventHandlerRaised As EventHandler(Of AccessTypeEventArgs), ByVal accessTypeEventArgs As AccessTypeEventArgs)
        eventHandlerRaised(objectRaisingEvent, accessTypeEventArgs)
    End Sub

    Public Sub [RaiseEvent](ByVal objectRaisingEvent As Object, ByVal eventHandlerRaised As EventHandler, ByVal eventArgs As EventArgs)
        eventHandlerRaised(objectRaisingEvent, eventArgs)
    End Sub

End Module