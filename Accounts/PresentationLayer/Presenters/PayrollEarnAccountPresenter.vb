Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries

Namespace PresentationLayer.Presenters

    Public Class PayrollEarnAccountPresenter
        Inherits AccountsPresenter(Of IPayrollEarnAccountView, PayrollEarnAccountModel)

        Public Sub New(view As IPayrollEarnAccountView)
            MyBase.New(view)

            Initializer("PayrollEarnAccount")
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)

        End Sub

    End Class

End Namespace