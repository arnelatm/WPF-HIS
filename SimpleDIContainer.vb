Imports System
Imports System.Collections.Generic

Public Class SimpleDIContainer
    Private ReadOnly _mappings As New Dictionary(Of Type, Object)()

    ''' <summary>
    ''' Registers a concrete instance for a given type or interface.
    ''' </summary>
    ''' <param name="serviceType">The type or interface to register.</param>
    ''' <param name="instance">The concrete instance to associate with the type.</param>
    Public Sub Register(ByVal serviceType As Type, ByVal instance As Object)
        If _mappings.ContainsKey(serviceType) Then
            Throw New InvalidOperationException($"Service of type {serviceType.Name} is already registered.")
        End If
        _mappings.Add(serviceType, instance)
    End Sub

    ''' <summary>
    ''' Resolves a registered instance for a given type or interface.
    ''' </summary>
    ''' <param name="serviceType">The type or interface to resolve.</param>
    Public Function Resolve(ByVal serviceType As Type) As Object
        If Not _mappings.ContainsKey(serviceType) Then
            Throw New KeyNotFoundException($"Service of type {serviceType.Name} is not registered.")
        End If
        Return _mappings(serviceType)
    End Function

End Class