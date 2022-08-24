Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class AccountsPresenterNewTv(Of T As IView, TM As New)
        Inherits AccountsPresenterNew(Of T, TM)
        Implements IAccountsPresenter

        Public Sub New(ItemView As T)
            MyBase New(ItemView)
        End Sub


    End Class

End Namespace