Imports AATM.Accounts.Interfaces
Imports AATM.Accounts.PresentationLayer.Presenters
Imports Autofac

Public Module ContainerConfig

    Public Function Configure() As IContainer
        Dim builder As Autofac.ContainerBuilder = New ContainerBuilder()
        'builder.RegisterType(Of SalaryLoanScheduleEntry)().[As](Of ISalaryLoanScheduleView)()
        builder.RegisterType(Of SalaryLoanSchedulePresenter)().[As](Of ISalaryLoanSchedulePresenter)()
        Return builder.Build()
    End Function

End Module