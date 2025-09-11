Public Class SimpleDIContainer
    Private ReadOnly container As New Dictionary(Of Type, Object)()

    Public Sub Register(serviceType As Type, implementation As Object)
        container(serviceType) = implementation
    End Sub

    Public Function Resolve(serviceType As Type) As Object
        If container.ContainsKey(serviceType) Then
            Return container(serviceType)
        End If
        ' Return Nothing if the service is not found.
        Return Nothing
    End Function

End Class