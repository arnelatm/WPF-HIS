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

        Public Function GetCustomerBalance(idNo As Integer)
            Return Model.GetSqlValue(Of Decimal)("Sum(Debit-Credit)", "ArStatement_View", "CustomerIdNo = " & idNo.ToString())
        End Function

    End Class

End Namespace