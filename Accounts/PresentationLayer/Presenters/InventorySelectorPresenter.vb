Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class InventorySelectorPresenter(Of TM As New)
        Inherits AccountsPresenter(Of IInventorySelectorView, TM)

        Private ReadOnly PresenterView
        Private _limitToBranch As Boolean

        Public Sub New(view As IInventorySelectorView)
            MyBase.New(view)
            TableName = "Inventory"
            WithTreeView = False
            Service = New AccountsService("Inventory")
            'AddHandler view.ProductUnitEditing, AddressOf OnProductUnitEditing
            'AddHandler view.ProductCodeChanged, AddressOf OnProductCodeChanged
        End Sub

    End Class

End Namespace