Imports AATM.Common.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Common.ServiceLayer.ActionServices

Namespace PresentationLayer.Presenters

    Public Class ReligionPresenter
        Inherits CommonPresenterOld(Of IReligionView, Religion, ReligionModel)

        Public Sub New(view As IReligionView)
            MyBase.New(view)
            TableName = "Religion"
            SortOrderKey = "ReligionName"
            TreeViewMainField = "ReligionName"
            TreeViewSecondaryField = "ReligionCode"
            OriginalModel = New ReligionModel()
            BizObject = New Religion
            DataModel = New ReligionModel
            DbDataDao = New ReligionDao
            TreeViewList = New List(Of ReligionModel)
            Model.SetService(New ReligionService)
        End Sub

        Public Shadows Function GetReligionList(Optional ByVal sortKey As String = "") As List(Of ReligionModel)
            Dim xModel As New ReligionModel
            Dim newSortOrderKey As String = GetTranslatedSortOrderKey(Of ReligionModel)(sortKey, xModel)
            Dim modelData = Model.GetAll(Of ReligionModel)(newSortOrderKey)
            If TreeViewList IsNot Nothing And TreeViewList.Count > 0 Then
                TreeViewList.Clear()
            End If
            For Each modData In modelData
                Dim modelTb As New ReligionModel
                MapObject(modData, modelTb)
                TreeViewList.Add(modelTb)
            Next
            Return TreeViewList
        End Function

    End Class

End Namespace