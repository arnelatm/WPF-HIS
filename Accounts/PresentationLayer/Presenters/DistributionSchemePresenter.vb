Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries

Namespace PresentationLayer.Presenters

    Public Class DistributionSchemePresenter
        Inherits AccountsPresenter(Of IDistributionSchemeView, DistributionSchemeModel)

        Public ParentViewList As List(Of DistributionSchemeModel)

        Public Sub New(view As IDistributionSchemeView)
            MyBase.New(view)
            TableName = "DistributionScheme"
            SortOrderKey = "DistributionSchemeName"
            ModelPresenter = New ModelAccounts("DistributionScheme")
            OriginalModel = New DistributionSchemeModel()
            TreeViewMainField = "DistributionSchemeName"
            TreeViewSecondaryField = "DistributionSchemeCode"
            DataModel = New DistributionSchemeModel
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
        End Sub

        Public Property DistributionSchemeItemsPresenter As DistributionSchemeItemsPresenter

        'Public Overrides Sub Display(idNo As Integer)
        '    MyBase.Display(idNo, undoMode)
        '    DistributionSchemeItemsPresenter.Display(idNo)
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