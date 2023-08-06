Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService

Namespace PresentationLayer.Presenters

    Public Class ProductFinderPresenter(Of TM As New)
        Inherits AccountsPresenter(Of IProductFinderView, TM)

        Public Sub New(view As IProductFinderView)
            MyBase.New(view)
            TableName = "Product"
            WithTreeView = False
            Service = New AccountsService("Product")
        End Sub

    End Class

End Namespace