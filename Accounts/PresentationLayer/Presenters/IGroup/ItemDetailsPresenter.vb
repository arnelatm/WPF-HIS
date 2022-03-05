Imports AATM.Accounts.DataLayer
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class ItemDetailsPresenter(Of TM As New)
        Inherits CommonPresenterNew(Of IItemDetailsView, TM)
        Implements IDaoAutoCode2

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


        Private Sub OnBeforeSave() Handles MyBase.BeforeSave
            If View.ItemDetailsCode Is Nothing Or View.ItemDetailsCode = "" Then
                View.ItemDetailsCode = Service.GenerateCode(View.IdNo)
            End If
        End Sub

        Public Function GenerateCode(idNo As Integer) As String Implements IDaoAutoCode2.GenerateCode
            Return Service.UpdateCode("ItemDetails", idNo)
        End Function

        Public Sub OnAfterSaveItemDetails() Handles Me.AfterSave
            Return Service.G
        End Sub

    End Class

End Namespace