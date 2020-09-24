Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries

Namespace PresentationLayer.Presenters

    Public Class LeavePresenter
        Inherits AccountsPresenter(Of ILeaveView, LeaveModel)

        Public Sub New(view As ILeaveView)
            MyBase.New(view)

            InitializerWithTv("Leave")
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)

        End Sub

    End Class

End Namespace