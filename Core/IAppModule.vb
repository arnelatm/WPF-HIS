Public Interface IAppModule
    ''' <summary>
    ''' Registers the services and dependencies for a specific application module.
    ''' </summary>
    Sub RegisterServices(container As SimpleDIContainer)
End Interface