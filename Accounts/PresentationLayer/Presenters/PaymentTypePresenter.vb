Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries

Namespace PresentationLayer.Presenters

    Public Class PaymentTypePresenter
        Inherits AccountsPresenter(Of IPaymentTypeView, PaymentTypeModel)

        Public Sub New(view As IPaymentTypeView)
            MyBase.New(view)
            InitializerWithTv("PaymentType")
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
        End Sub

    End Class

End Namespace