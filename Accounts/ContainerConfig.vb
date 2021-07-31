Imports AATM.Accounts.PresentationLayer.Presenters
Imports Autofac

Public Module ContainerConfig

    Public Function Configure() As IContainer
        Dim builder As Autofac.ContainerBuilder = New ContainerBuilder()
        'builder.RegisterType(Of RecurringPayElementEntry)().[As](Of IRecurringPayElementView)()
        'builder.RegisterType(Of RecurringPayElementPresenter)().[As](Of ISalaryLoanSchedulePresenter)()
        Return builder.Build()
    End Function

End Module