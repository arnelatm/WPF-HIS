Imports AATM.Common.DataLayer.AdoNet
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Common.PresentationLayer.Views.Forms
Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class OriginalMessagesPresenter
        Inherits CommonPresenter(Of IOriginalMessagesView, OriginalMessagesModel)

        Public Sub New(view As IOriginalMessagesView)
            MyBase.New(view)
            ModelOfPresenter = New ModelCommon("OriginalMessages")
            TableName = "OriginalMessages"
            SortOrderKey = "MessageKey"
            TreeViewMainField = "MessageKey"
            TreeViewSecondaryField = Nothing
            OriginalModel = New OriginalMessagesModel()
            DataModel = New OriginalMessagesModel
            DbDataDao = New OriginalMessagesDao
            TreeViewList = New List(Of OriginalMessagesModel)
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
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
                GlobalVariables.Mapper.Map(modData, modelTb)
                TreeViewList.Add(modelTb)
            Next
            Return TreeViewList
        End Function

        'Public Overrides Sub Display(idNo As Int32)
        '    If idNo <> 0 Then
        '        Dim modelData As OriginalMessagesModel
        '        modelData = Model.GetRecordByIdNo(Of OriginalMessagesModel)(idNo)
        '        If modelData IsNot Nothing Then
        '            GlobalVariables.Mapper.Map(modelData, View)
        '        End If
        '        TranslatedMessagesPresenter.Display(idNo)
        '    End If
        'End Sub
    End Class

End Namespace