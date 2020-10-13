Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class PayPeriodPresenter
        Inherits AccountsPresenter(Of IPayPeriodView, PayPeriodModel)

        Public Sub New(view As IPayPeriodView)
            MyBase.New(view)
            TreeViewParentIdField = "ParentIdNo"
            InitializerWithTv("PayPeriod")
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
        End Sub

    End Class

End Namespace