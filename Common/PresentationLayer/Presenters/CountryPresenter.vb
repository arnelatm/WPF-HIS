Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Common.ServiceLayer
Imports AATM.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class CountryPresenter(Of TM As New)
        Inherits CommonPresenterNew(Of ICountryView, TM)

        Public ParentViewList As List(Of TM)

        Public Sub New(view As ICountryView)
            MyBase.New(view)
            Service = New CommonService("Country")
            TableName = "Country"
            SortOrderKey = "CountryName"
            TreeViewMainField = "CountryName"
            TreeViewSecondaryField = "CountryCode"
            ParentViewList = New List(Of TM)
        End Sub

    End Class

End Namespace