Imports AATM.Common.DataLayer.AdoNet
Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Common.ServiceLayer
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class OriginalMessagesPresenter(Of TM As New)
        Inherits CommonPresenterNew(Of IOriginalMessagesView, TM)

        Public Sub New(view As IOriginalMessagesView)
            MyBase.New(view)
            Service = New ServiceCommon("OriginalMessages")
            TableName = "OriginalMessages"
            SortOrderKey = "MessageKey"
            TreeViewMainField = "MessageKey"
            TreeViewSecondaryField = Nothing
            OriginalModel = New TM()
            DbDataDao = New OriginalMessagesDao
        End Sub

        'Public Property TranslatedMessagesPresenter As TranslatedMessagesPresenter

        Public Function GetOriginalMessagesList(Optional ByVal sortKey As String = "") As List(Of TM)
            Dim xModel As New TM
            Dim newSortOrderKey As String = GetTranslatedSortOrderKey(Of TM)(sortKey, xModel)
            Dim modelData = Service.GetAll(Of TM)(newSortOrderKey)
            If TreeViewList IsNot Nothing And TreeViewList.Count > 0 Then
                TreeViewList.Clear()
            End If
            For Each modData In modelData
                Dim modelTb As New TM
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