Imports AATM.Common.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class OriginalMessagesPresenter
        Inherits CommonPresenter(Of IOriginalMessagesView, OriginalMessagesModel)

        Public Sub New(view As IOriginalMessagesView)
            MyBase.New(view)
            ModelPresenter = New ModelOriginalMessages
            TableName = "OriginalMessages"
            SortOrderKey = "MessageKey"
            TreeViewMainField = "MessageKey"
            TreeViewSecondaryField = Nothing
            OriginalModel = New OriginalMessagesModel()
            DataModel = New OriginalMessagesModel
            DbDataDao = New OriginalMessagesDao
            TreeViewList = New List(Of OriginalMessagesModel)
        End Sub

        Public Property TranslatedMessagesPresenter As TranslatedMessagesPresenter

        Public Function GetOriginalMessagesList(Optional ByVal sortKey As String = "") As List(Of OriginalMessagesModel)
            Dim xModel As New OriginalMessagesModel
            Dim newSortOrderKey As String = GetTranslatedSortOrderKey(Of OriginalMessagesModel)(sortKey, xModel)
            Dim modelData = Model.GetAll(Of OriginalMessagesModel)(newSortOrderKey)
            If TreeViewList IsNot Nothing And TreeViewList.Count > 0 Then
                TreeViewList.Clear()
            End If
            For Each modData In modelData
                Dim modelTb As New OriginalMessagesModel
                GlobalVariables.Mapper.MapObject(modData, modelTb)
                TreeViewList.Add(modelTb)
            Next
            Return TreeViewList
        End Function

        Public Overrides Sub Display(idNo As Integer, Optional ByVal undoMode As Boolean = False)
            If idNo <> 0 Then
                Dim modelData As New OriginalMessagesModel
                modelData = Model.GetRecordById(Of OriginalMessagesModel)(idNo)
                If modelData IsNot Nothing Then
                    'Dim fieldsDictionary As New Dictionary(Of String, String)
                    '' Add two keys.
                    'fieldsDictionary.Add("IdNo","IdNo")
                    'fieldsDictionary.Add("Message","Message")
                    'fieldsDictionary.Add("Caption","Caption")
                    MapObject(modelData, View)
                    MapObject(modelData, OriginalModel)
                End If
                TranslatedMessagesPresenter.Display(idNo)
            End If
        End Sub

    End Class

End Namespace