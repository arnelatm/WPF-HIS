Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries

Namespace PresentationLayer.Presenters

    Public Class CustomerPresenter
        Inherits AccountsPresenter(Of ICustomerView, CustomerModel)

        Public ParentViewList As List(Of CustomerModel)

        Public Sub New(view As ICustomerView)
            MyBase.New(view)
            InitializerWithTv("Customer")
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
        End Sub

        'Public Function GetCustomerList()
        '    Return GetTreeViewList("CustomerName")
        'End Function
    End Class

End Namespace