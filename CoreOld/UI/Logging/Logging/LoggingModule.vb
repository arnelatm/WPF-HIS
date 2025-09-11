Imports AATM.Core
Imports AATM.Core.UI

Public Class LoggingModule
    Implements IAppModule

    Public Sub RegisterServices(container As SimpleDIContainer) Implements IAppModule.RegisterServices
        ' Register the FrmLogViewer so the DI container knows how to create it.
        container.Register(GetType(FrmLogViewer), New FrmLogViewer())
    End Sub

End Class