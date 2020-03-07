Imports AATM.Common.BusinessLayer
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class CountryPresenter
        Inherits CommonPresenter(Of ICountryView, CountryModel)

        Public ParentViewList As List(Of CountryModel)

        Public Sub New(view As ICountryView)
            MyBase.New(view)
            TableName = "Country"
            SortOrderKey = "CountryName"
            TreeViewMainField = "CountryName"
            TreeViewSecondaryField = "Isoa2"
            OriginalModel = New CountryModel()
            BizObject = New Country
            DataModel = New CountryModel
            'DbDataDao = New CountryDao
            TreeViewList = New List(Of CountryModel)
            ParentViewList = New List(Of CountryModel)
        End Sub

    End Class

End Namespace