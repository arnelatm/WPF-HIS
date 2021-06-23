Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Libraries
Imports AATM.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class ReligionPresenter
        Inherits PresenterTv(Of IReligionView, ReligionModel)

        Public Sub New(view As IReligionView)
            MyBase.New(view)
            ModelOfPresenter = New ModelCommon("Religion")
            TableName = "Religion"
            TreeViewMainField = "ReligionName"
            TreeViewSecondaryField = "ReligionCode"
            SortOrderKey = "IdNo"
            OriginalModel = New ReligionModel()
            DataModel = New ReligionModel()
        End Sub

    End Class

End Namespace