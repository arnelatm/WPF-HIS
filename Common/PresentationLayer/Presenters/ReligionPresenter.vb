Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Common.PresentationLayer.Views.Forms
Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class ReligionPresenter
        Inherits CommonPresenter(Of IReligionView, ReligionModel)

        Public Sub New(view As IReligionView)
            MyBase.New(view)
            ModelOfPresenter = New ModelCommon("Religion")
            TableName = "Religion"
            SortOrderKey = "ReligionName"
            TreeViewMainField = "ReligionName"
            TreeViewSecondaryField = "ReligionCode"
            OriginalModel = New ReligionModel()
            DataModel = New ReligionModel
            TreeViewList = New List(Of ReligionModel)
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
        End Sub

        'Public Shadows Function GetReligionList(Optional ByVal sortKey As String = "") As List(Of ReligionModel)
        '    Dim xModel As New ReligionModel
        '    Dim newSortOrderKey As String = GetTranslatedSortOrderKey(Of ReligionModel)(sortKey, xModel)
        '    Dim modelData = Model.GetAll(Of ReligionModel)(newSortOrderKey)
        '    If TreeViewList IsNot Nothing And TreeViewList.Count > 0 Then
        '        TreeViewList.Clear()
        '    End If
        '    For Each modData In modelData
        '        Dim modelTb As New ReligionModel
        '        GlobalVariables.Mapper.Map(modData, modelTb)
        '        TreeViewList.Add(modelTb)
        '    Next
        '    Return TreeViewList
        'End Function

    End Class

End Namespace