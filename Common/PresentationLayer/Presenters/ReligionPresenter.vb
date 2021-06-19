Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Libraries
Imports AATM.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class ReligionPresenter
        Inherits PresenterTv(Of IReligionView, ReligionModel)
        'Inherits CommonPresenter(Of IReligionView, ReligionModel)

        Public Sub New(view As IReligionView)
            MyBase.New(view)
            ModelOfPresenter = New ModelCommon("Religion")
            TableName = "Religion"
            TreeViewMainField = "ReligionName"
            TreeViewSecondaryField = "ReligionCode"
            SortOrderKey = "IdNo"
            OriginalModel = New ReligionModel()
            DataModel = New ReligionModel()

            'ModelOfPresenter = New ModelCommon("Religion")
            'TableName = "Religion"
            'SortOrderKey = "ReligionName"
            'TreeViewMainField = "ReligionName"
            'TreeViewSecondaryField = "ReligionCode"
            'OriginalModel = New ReligionModel()
            'DataModel = New ReligionModel
            'TreeViewList = New List(Of ReligionModel)
            'Ea = New EventAggregator()
            'Ea.SubscribeEvent(Me)
        End Sub

    End Class

End Namespace