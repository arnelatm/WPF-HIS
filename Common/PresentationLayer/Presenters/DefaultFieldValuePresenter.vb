Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class DefaultFieldValuePresenter
        Inherits CommonPresenter(Of IDefaultFieldValueView, DefaultFieldValueModel)

        Public Sub New(view As IDefaultFieldValueView)
            MyBase.New(view)

            ModelOfPresenter = New ModelCommon("DefaultFieldValue")
            'TableName = "DefaultFieldValue"
            SortOrderKey = "SystemViewName + FieldName"
            TreeViewMainField = "SystemViewName"
            TreeViewSecondaryField = "FieldName"
            OriginalModel = New DefaultFieldValueModel()
            DataModel = New DefaultFieldValueModel
            TreeViewList = New List(Of DefaultFieldValueModel)
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
        End Sub

        Public Function GetDefaultFieldValueList(Optional ByVal sortKey As String = "") As List(Of DefaultFieldValueModel)
            Dim xModel As New DefaultFieldValueModel
            Dim newSortOrderKey As String = GetTranslatedSortOrderKey(Of DefaultFieldValueModel)(sortKey, xModel)
            Dim modelData = Model.GetAll(Of DefaultFieldValueModel)(newSortOrderKey)
            If TreeViewList IsNot Nothing And TreeViewList.Count > 0 Then
                TreeViewList.Clear()
            End If
            For Each modData In modelData
                Dim modelTb As New DefaultFieldValueModel
                GlobalVariables.Mapper.Map(modData, modelTb)
                TreeViewList.Add(modelTb)
            Next
            Return TreeViewList
        End Function

    End Class

End Namespace