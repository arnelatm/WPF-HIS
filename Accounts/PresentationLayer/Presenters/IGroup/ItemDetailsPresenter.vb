Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class ItemDetailsPresenter(Of TM As New)
        Inherits CommonPresenterNew(Of IItemDetailsView, TM)

        Public Sub New(itemView As IItemDetailsView)
            MyBase.New(itemView)           
            Service = New AccountsService("ItemDetails") ', Nothing ,Nothing, "IGROUPCLINIC")
            'Service.SaveConnectionString()
            'Service.SetConnectionString("IGROUPCLINIC")                    
            TableName = "ItemDetails"
            SortOrderKey = "ItemNameEnglish"
            'Service.RestoreConnectionString()
            WithTreeView = False
        End Sub

    End Class

End Namespace