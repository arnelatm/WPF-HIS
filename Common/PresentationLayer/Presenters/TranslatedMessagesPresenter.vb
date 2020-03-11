Imports System.Windows.Forms
Imports AATM.Common.BusinessLayer
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Common.ServiceLayer
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class TranslatedMessagesPresenter
        Inherits CommonPresenter(Of ITranslatedMessagesView, TranslatedMessagesModel)

        Public Property FieldRetrievalMappingDictionary As Dictionary(Of String, String)
        Public Property FieldSavingMappingDictionary As Dictionary(Of String, String)

        Public Sub New(view As ITranslatedMessagesView)
            MyBase.New(view)
            ModelPresenter = New ModelTranslatedMessages
            TableName = "TranslatedMessages"
            SortOrderKey = "MessageKey"
            TreeViewMainField = "MessageKey"
            TreeViewSecondaryField = Nothing
            OriginalModel = New TranslatedMessagesModel()
            DataBizObject = New TranslatedMessages(True)
            DataModel = New TranslatedMessagesModel
            TreeViewList = New List(Of TranslatedMessagesModel)
            FieldRetrievalMappingDictionary = New Dictionary(Of String, String) From {{"IdNo", "IdNoTranslated"}}
            FieldSavingMappingDictionary = New Dictionary(Of String, String) From {{"IdNoTranslated", "IdNo"}}
        End Sub

        Public Overrides Sub Display(originalIdNo As Integer, Optional ByVal undoMode As Boolean = False)
            Dim idNoTm As Int16
            idNoTm = GetRecordFieldWithKey(originalIdNo, "TranslatedMessages", "originalIdNo", "IdNo")
            Dim modelData As New TranslatedMessagesModel
            If idNoTm <> 0 Then
                modelData = Model.GetRecordById(Of TranslatedMessagesModel)(originalIdNo)
            End If
            MapObject(modelData, View, FieldRetrievalMappingDictionary)
            MapObject(modelData, OriginalModel)
        End Sub

        Public Function GetTranslatedMessagesList(Optional ByVal sortKey As String = "") As List(Of TranslatedMessagesModel)
            Dim xModel As New TranslatedMessagesModel
            Dim newSortOrderKey As String = GetTranslatedSortOrderKey(Of TranslatedMessagesModel)(sortKey, xModel)
            Dim modelData = Model.GetAll(Of TranslatedMessagesModel)(newSortOrderKey)
            If TreeViewList IsNot Nothing And TreeViewList.Count > 0 Then
                TreeViewList.Clear()
            End If
            For Each modData In modelData
                Dim modelTb As New TranslatedMessagesModel
                MapObject(modData, modelTb, FieldSavingMappingDictionary)
                TreeViewList.Add(modelTb)
            Next
            Return TreeViewList
        End Function

        Public Overrides Function Save(ByRef addMode As Boolean)
            Dim retVal As Integer
            MapObject(View, DataBizObject, FieldSavingMappingDictionary)
            If Model.IsValid(DataBizObject) Then
                'If DataIsValid() Then
                '    If addMode Or Model.IdNo = 0 Then
                '        NewlyAddedRecordIdNo = Model.AddRecord(Of TranslatedMessages)(DataBizObject)
                '        retVal = NewlyAddedRecordIdNo
                '    Else

                '        retVal = Model.UpdateRecord(Model)

                '    End If
                'End If
            Else
                Dim errorList As String = ""
                For Each bizError In DataBizObject.Errors
                    errorList = errorList & bizError & Environment.NewLine
                Next
                MessageBox.Show(errorList)
            End If
            Return retVal
        End Function

    End Class

End Namespace