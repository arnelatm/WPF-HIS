Imports AATM.Common.DataLayer.AdoNet
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views
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
        End Sub

        Public Property TranslatedCaptionPresenter As TranslatedCaptionPresenter

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

        Public Overrides Sub Display(idNo As Integer)
            If idNo <> 0 Then
                Dim modelData As OriginalCaptionsModel
                modelData = Model.GetRecordById(Of OriginalCaptionsModel)(idNo)
                If modelData IsNot Nothing Then
                    'Dim fieldsDictionary As New Dictionary(Of String, String)
                    '' Add two keys.
                    'fieldsDictionary.Add("IdNo","IdNo")
                    'fieldsDictionary.Add("Caption","Caption")
                    'fieldsDictionary.Add("Caption","Caption")
                    GlobalVariables.Mapper.Map(modelData, View)
                    'MapObject(modelData, View)
                    'MapObject(modelData, OriginalModel)
                End If
                TranslatedCaptionPresenter.Display(idNo)
            End If
        End Sub

    End Class

End Namespace