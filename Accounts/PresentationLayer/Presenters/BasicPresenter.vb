Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries

Namespace PresentationLayer.Presenters

    Public Class BasicPresenter
        Inherits AccountsPresenter(Of IBasicView, BasicModel)

        Private ReadOnly PresenterView

        Public Sub New(view As IBasicView, tableOrViewName As String)
            MyBase.New(view)
            Dim presenterModelName = $"AATM.Accounts.PresentationLayer.Models.ModelAccounts"
            TableName = tableOrViewName
            SortOrderKey = "Name"
            Service = New ModelAccounts("Basic", tableOrViewName)
            OriginalModel = New BasicModel
            DataModel = New BasicModel
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)

        End Sub

    End Class

End Namespace