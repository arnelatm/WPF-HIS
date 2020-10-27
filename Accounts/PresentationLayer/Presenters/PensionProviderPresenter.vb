Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries

Namespace PresentationLayer.Presenters

    Public Class PensionProviderPresenter
        Inherits AccountsPresenter(Of IPensionProviderView, PensionProviderModel)

        Public ParentViewList As List(Of PensionProviderModel)

        Public Sub New(view As IPensionProviderView)
            MyBase.New(view)
            InitializerWithTv("PensionProvider")
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
        End Sub

    End Class

End Namespace