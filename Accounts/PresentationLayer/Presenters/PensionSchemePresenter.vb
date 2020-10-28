Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries

Namespace PresentationLayer.Presenters

    Public Class PensionSchemePresenter
        Inherits AccountsPresenter(Of IPensionSchemeView, PensionSchemeModel)

        Public ParentViewList As List(Of PensionSchemeModel)

        Public Sub New(view As IPensionSchemeView)
            MyBase.New(view)
            InitializerWithTv("PensionScheme")
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
        End Sub

    End Class

End Namespace