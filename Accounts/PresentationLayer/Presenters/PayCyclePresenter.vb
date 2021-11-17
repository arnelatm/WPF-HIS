Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class PayCyclePresenter(Of TM As New)
        Inherits CommonPresenterNew(Of IPayCycleView, TM)

        Public Sub New(view As IPayCycleView)
            MyBase.New(view)
            Service = New AccountsService("PayCycle")
            TableName = "PayCycle"
            TreeViewMainField = "PayCycleName"
            TreeViewSecondaryField = "PayCycleCode"
            SortOrderKey = "PayCycleName"
        End Sub

        Protected Overrides Sub CreateDataSources()
            CreateEnumDataSource(Of PayFrequencySelection)("PayFrequency")
        End Sub

    End Class



End Namespace