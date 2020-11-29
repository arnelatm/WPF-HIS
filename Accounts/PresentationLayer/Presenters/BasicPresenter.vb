Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Views
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Presenters
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.BusinessLayer

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