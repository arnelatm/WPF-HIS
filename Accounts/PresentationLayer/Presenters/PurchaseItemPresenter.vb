Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries

Namespace PresentationLayer.Presenters

    Public Class PurchaseItemPresenter
        Inherits AccountsPresenter(Of IPurchaseItemView, PurchaseItemModel)

        Public Sub New(view As IPurchaseItemView)
            MyBase.New(view)
            Initializer("PurchaseItem")
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
        End Sub

    End Class

End Namespace