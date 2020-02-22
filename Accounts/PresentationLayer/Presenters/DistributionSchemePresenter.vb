Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters


    Public Class DistributionSchemePresenter
        Inherits CommonPresenterOld(Of IDistributionSchemeView, DistributionScheme, DistributionSchemeModel)

        Public ParentViewList As List(Of DistributionSchemeModel)

        Public Sub New(view As IDistributionSchemeView)
            MyBase.New(view)
            TableName = "DistributionScheme"
            SortOrderKey = "DistributionSchemeName"
            OriginalModel = New DistributionSchemeModel()
            TreeViewMainField = "DistributionSchemeName"
            TreeViewSecondaryField = "DistributionSchemeCode"
            BizObject = New DistributionScheme
            DataModel = New DistributionSchemeModel
            DbDataDao = New DistributionSchemeDao
            Model.SetService(New DistributionSchemeService)
        End Sub

        Public Property DistributionSchemeItemsPresenter As DistributionSchemeItemsPresenter

        Public Overrides Sub Display(idNo As Integer, Optional ByVal undoMode As Boolean = False)
            Dim modelData As New DistributionSchemeModel
            modelData = Model.GetRecordById(Of DistributionSchemeModel)(idNo)
            DistributionSchemeItemsPresenter.Display(idNo)
            With DistributionSchemeItemsPresenter.View
                modelData.DistributionSchemeItems = .DistributionSchemeItems
                modelData.TotalPercentage = .DistributionSchemeItems.Sum(Function(totals) totals.Percentage)
            End With
            If modelData IsNot Nothing Then
                MapObject(modelData, View)
                MapObject(modelData, OriginalModel)
            End If
        End Sub

    End Class
End NameSpace