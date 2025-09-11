Public Class LoggingModule
    Implements IAppModule

    Public Sub RegisterServices(container As SimpleDIContainer) Implements IAppModule.RegisterServices
        ' This is where we register the concrete log viewer form with the DI container.
        container.Register(GetType(FrmLogViewer), New FrmLogViewer())
    End Sub

End Class