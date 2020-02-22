Imports AATM.Common.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Common.ServiceLayer.ActionServices

Namespace PresentationLayer.Presenters

    Public Class CountryPresenter
        Inherits CommonPresenterOld(Of ICountryView, Country, CountryModel)

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
            DbDataDao = New CountryDao
            TreeViewList = New List(Of CountryModel)
            ParentViewList = New List(Of CountryModel)
            Model.SetService(New CountryService)
        End Sub

        'Public Function GetCountryList(Optional ByVal sortKey As String = "") As List(Of CountryModel)
        '    Dim xModel As New CountryModel
        '    Dim newSortOrderKey As String = GetTranslatedSortOrderKey(Of CountryModel)(sortKey, xModel)
        '    Dim modelData = Model.GetAll(Of CountryModel)(newSortOrderKey)
        '    If TreeViewList IsNot Nothing And TreeViewList.Count > 0 Then
        '        TreeViewList.Clear()
        '    End If
        '    For Each modData In modelData
        '        Dim modelTb As New CountryModel
        '        MapObject(modData, modelTb)
        '        TreeViewList.Add(modelTb)
        '    Next
        '    Return TreeViewList
        'End Function

    End Class

End Namespace