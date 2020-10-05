Imports AATM.Common.DataLayer.AdoNet
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Common.PresentationLayer.Views.Forms
Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class OriginalCaptionsPresenter
        Inherits CommonPresenter(Of IOriginalCaptionsView, OriginalCaptionsModel)

        Public Sub New(view As IOriginalCaptionsView)
            MyBase.New(view)
            ModelPresenter = New ModelCommon("OriginalCaptions")
            TableName = "OriginalCaptions"
            SortOrderKey = "Caption"
            TreeViewMainField = "Caption"
            TreeViewSecondaryField = Nothing
            OriginalModel = New OriginalCaptionsModel()
            DataModel = New OriginalCaptionsModel
            DbDataDao = New OriginalCaptionsDao
            TreeViewList = New List(Of OriginalCaptionsModel)
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
        End Sub

        Public Function GetOriginalCaptionsList(Optional ByVal sortKey As String = "") As List(Of OriginalCaptionsModel)
            Dim xModel As New OriginalCaptionsModel
            Dim newSortOrderKey As String = GetTranslatedSortOrderKey(Of OriginalCaptionsModel)(sortKey, xModel)
            Dim modelData = Model.GetAll(Of OriginalCaptionsModel)(newSortOrderKey)
            If TreeViewList IsNot Nothing And TreeViewList.Count > 0 Then
                TreeViewList.Clear()
            End If
            For Each modData In modelData
                Dim modelTb As New OriginalCaptionsModel
                GlobalVariables.Mapper.Map(modData, modelTb)
                TreeViewList.Add(modelTb)
            Next
            Return TreeViewList
        End Function

    End Class

End Namespace