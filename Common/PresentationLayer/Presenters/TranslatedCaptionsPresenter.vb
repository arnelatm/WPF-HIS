Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.Translations

Namespace PresentationLayer.Presenters

    Public Class TranslatedCaptionsPresenter
        Inherits CommonPresenter(Of ITranslatedCaptionsView, TranslatedCaptionsModel)

        Public Property FieldRetrievalMappingDictionary As Dictionary(Of String, String)
        Public Property FieldSavingMappingDictionary As Dictionary(Of String, String)
        Private Property Dac

        Public Sub New(view As ITranslatedCaptionsView)
            MyBase.New(view)
            ModelPresenter = New ModelCommon("TranslatedCaption")
            TableName = "TranslatedCaption"
            SortOrderKey = "MessageKey"
            TreeViewMainField = "MessageKey"
            TreeViewSecondaryField = Nothing
            OriginalModel = New TranslatedCaptionsModel()
            DataModel = New TranslatedCaptionsModel
            TreeViewList = New List(Of TranslatedCaptionsModel)
            FieldRetrievalMappingDictionary = New Dictionary(Of String, String) From {{"IdNo", "IdNoTranslated"}}
            FieldSavingMappingDictionary = New Dictionary(Of String, String) From {{"IdNoTranslated", "IdNo"}}
            Dac = New Dac
        End Sub

        Public Overrides Sub Display(messageIdNo As Integer, Optional ByVal undoMode As Boolean = False)
            Dim idNoTm As Int16
            idNoTm = GetRecordFieldWithKey(messageIdNo, "TranslatedCaption", "messageIdNo", "IdNo")
            Dim modelData As New TranslatedCaptionsModel
            If idNoTm <> 0 Then
                modelData = Model.GetRecordById(Of TranslatedCaptionsModel)(messageIdNo)
            End If
            GlobalVariables.Mapper.Map(modelData, View)
        End Sub

        Public Function GetTranslatedCaptionList(Optional ByVal sortKey As String = "") As List(Of TranslatedCaptionsModel)
            Dim xModel As New TranslatedCaptionsModel
            Dim newSortOrderKey As String = GetTranslatedSortOrderKey(Of TranslatedCaptionsModel)(sortKey, xModel)
            Dim modelData = Model.GetAll(Of TranslatedCaptionsModel)(newSortOrderKey)
            If TreeViewList IsNot Nothing And TreeViewList.Count > 0 Then
                TreeViewList.Clear()
            End If
            For Each modData In modelData
                Dim modelTb As New TranslatedCaptionsModel
                MapObject(modData, modelTb, FieldSavingMappingDictionary)
                TreeViewList.Add(modelTb)
            Next
            Return TreeViewList
        End Function

        Public Overrides Function Save(ByRef addMode As Boolean)
            Dim retVal As Integer
            Dim record As New TranslatedCaptionsModel
            'record.LanguageIdNo = Dac.DefaultMirroredLanguageIdNo
            GlobalVariables.Mapper.Map(Of ITranslatedCaptionsView, TranslatedCaptionsModel)(View, record)
            If addMode Then
                NewlyAddedRecordIdNo = ModelPresenter.AddRecord(record)
                retVal = NewlyAddedRecordIdNo
                CallByName(View, "IdNo", CallType.Set, retVal)
            Else
                If String.IsNullOrEmpty(record.TranslatedCaption) And String.IsNullOrEmpty(record.TranslatedCaption) Then
                    retVal = Model.DeleteRecord(record.IdNo, "TranslatedCaption")
                Else
                    If String.IsNullOrEmpty(record.TranslatedCaption) Then
                        record.TranslatedCaption = ""
                    ElseIf String.IsNullOrEmpty(record.TranslatedCaption) Then
                        record.TranslatedCaption = ""
                    End If
                    retVal = Model.UpdateRecord(record)
                    If retVal = 0 Then
                        If Not (String.IsNullOrEmpty(record.TranslatedCaption) And String.IsNullOrEmpty(record.TranslatedCaption)) Then
                            record.LanguageIdNo = Dac.DefaultMirroredLanguageIdNo
                            NewlyAddedRecordIdNo = ModelPresenter.AddRecord(record)
                            retVal = NewlyAddedRecordIdNo
                            CallByName(View, "IdNo", CallType.Set, retVal)
                        End If
                    End If
                End If
            End If
            Return retVal
        End Function

    End Class

End Namespace