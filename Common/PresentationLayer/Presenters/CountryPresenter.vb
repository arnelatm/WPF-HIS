Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Libraries

Namespace PresentationLayer.Presenters

    Public Class CountryPresenter
        Inherits CommonPresenter(Of ICountryView, CountryModel)

        Public ParentViewList As List(Of CountryModel)

        Public Sub New(view As ICountryView)
            MyBase.New(view)
            ModelPresenter = New ModelCommon("Country")
            TableName = "Country"
            SortOrderKey = "CountryName"
            TreeViewMainField = "CountryName"
            TreeViewSecondaryField = "Isoa2"
            OriginalModel = New CountryModel()
            DataModel = New CountryModel
            TreeViewList = New List(Of CountryModel)
            ParentViewList = New List(Of CountryModel)
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
        End Sub

    End Class

End Namespace