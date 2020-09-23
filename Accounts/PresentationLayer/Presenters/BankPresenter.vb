Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries

Namespace PresentationLayer.Presenters

    Public Class BankPresenter
        Inherits AccountsPresenter(Of IBankView, BankModel)

        Public Sub New(view As IBankView)
            MyBase.New(view)

            InitializerWithTv("Bank")
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)

        End Sub

    End Class

End Namespace