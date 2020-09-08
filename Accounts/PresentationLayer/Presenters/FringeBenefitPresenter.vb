Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries

Namespace PresentationLayer.Presenters

    Public Class FringeBenefitPresenter
        Inherits AccountsPresenter(Of IFringeBenefitView, FringeBenefitModel)

        Public Sub New(view As IFringeBenefitView)
            MyBase.New(view)

            InitializerWithTv("FringeBenefit")
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)

        End Sub

    End Class

End Namespace