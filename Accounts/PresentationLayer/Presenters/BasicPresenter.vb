Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Libraries
Imports AATM.Accounts.PresentationLayer.Views.Interfaces

Namespace PresentationLayer.Presenters

    Public Class BasicPresenter
        Inherits AccountsPresenter(Of IBasicView, BasicModel)

        Private ReadOnly PresenterView

        Public Sub New(view As IBasicView, tableOrViewName As String)
            MyBase.New(view)
            Dim presenterModelName = $"AATM.Accounts.PresentationLayer.Models.ModelAccounts"
            TableName = tableOrViewName
            SortOrderKey = "Name"
            ModelPresenter = New ModelAccounts("Basic", tableOrViewName)
            OriginalModel = New BasicModel
            DataModel = New BasicModel
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)

        End Sub

    End Class

End Namespace