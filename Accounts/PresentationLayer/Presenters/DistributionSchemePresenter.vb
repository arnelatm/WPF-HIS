Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class DistributionSchemePresenter
        Inherits AccountsPresenter(Of IDistributionSchemeView, DistributionSchemeModel)

        Public ParentViewList As List(Of DistributionSchemeModel)

        Public Sub New(view As IDistributionSchemeView)
            MyBase.New(view)
            TableName = "DistributionScheme"
            SortOrderKey = "DistributionSchemeName"
            ModelPresenter = New ModelDistributionScheme()
            OriginalModel = New DistributionSchemeModel()
            TreeViewMainField = "DistributionSchemeName"
            TreeViewSecondaryField = "DistributionSchemeCode"
            DataModel = New DistributionSchemeModel
        End Sub

        Public Property DistributionSchemeItemsPresenter As DistributionSchemeItemsPresenter

        'Public Overrides Sub Display(idNo As Integer, Optional ByVal undoMode As Boolean = False)
        '    MyBase.Display(idNo, undoMode)
        '    DistributionSchemeItemsPresenter.Display(idNo, undoMode)
        '    BindDistributionSchemeItem()
        '    With DistributionSchemeItems
        '        View.DistributionSchemeItems = .DistributionSchemeItems
        '        modelData.TotalPercentage = .DistributionSchemeItems.Sum(Function(totals) totals.Percentage)
        '    End With
        '    If modelData IsNot Nothing Then
        '        MapObject(modelData, View)
        '        MapObject(modelData, OriginalModel)
        '    End If
        'End Sub

    End Class

End Namespace