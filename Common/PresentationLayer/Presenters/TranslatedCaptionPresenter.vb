Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Libraries
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class TranslatedCaptionPresenter
        Inherits CommonPresenter(Of ITranslatedCaptionView, TranslatedCaptionModel)

        Private Property Dac

        Public Sub New(view As ITranslatedCaptionView)
            MyBase.New(view)
            ModelPresenter = New ModelCommon("TranslatedCaption")
            TableName = "TranslatedCaption"
            SortOrderKey = "MessageKey"
            TreeViewMainField = "MessageKey"
            TreeViewSecondaryField = Nothing
            OriginalModel = New TranslatedCaptionModel()
            DataModel = New TranslatedCaptionModel
            TreeViewList = New List(Of TranslatedCaptionModel)
            Dac = New Dac
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
        End Sub

        'Public Overrides Sub Display(messageIdNo As Int16)
        '    Dim idNoTm As Int16
        '    idNoTm = GetRecordFieldWithKey(messageIdNo, "TranslatedCaption", "captionIdNo", "IdNo")
        '    Dim modelData As New TranslatedCaptionModel
        '    If idNoTm <> 0 Then
        '        modelData = Model.GetRecordById(Of TranslatedCaptionModel)(messageIdNo)
        '    End If
        '    GlobalVariables.Mapper.Map(modelData, View)
        'End Sub

        Public Overrides Function ChangesMade() As Boolean
            ' need to do a non-standard compare because Using the ObjectsCompare method
            ' can only compare items with same name.  However in this case 'IdNo' is
            ' mapped differently between the view and the Model in the model it is named
            ' 'IdNo' and in the View it is named 'translatedMessageIdNo'
            ' we need to compare only the translatedCaption field
            If OriginalModel.TranslatedCaption = View.TranslatedCaption Then
                Return False
            End If
            Return True
            'If OriginalModel is Nothing Then
            '    If String.IsNullOrEmpty(View.TranslatedCaption) Then
            '        Return True
            '    End If
            'End If
            'If Not GlobalFunctions.CompareValues(OriginalModel.TranslatedCaption, View.TranslatedCaption) Then
            '    Return True
            'End If
            'Return False
        End Function

        Protected Overrides Function UpDateRecord(record As TranslatedCaptionModel) As Integer
            Dim retVal As Integer
            If String.IsNullOrEmpty(record.TranslatedCaption) Then
                retVal = Model.DeleteRecord(record.IdNo, "TranslatedCaption")
            Else
                If String.IsNullOrEmpty(record.TranslatedCaption) Then
                    record.TranslatedCaption = ""
                End If
                retVal = Model.UpdateRecord(record)
                If retVal = 0 Then
                    If Not (String.IsNullOrEmpty(record.TranslatedCaption)) Then
                        record.LanguageIdNo = Dac.DefaultMirroredLanguageIdNo
                        NewlyAddedRecordIdNo = ModelPresenter.AddRecord(record)
                        retVal = NewlyAddedRecordIdNo
                        CallByName(View, "IdNo", CallType.Set, retVal)
                    End If
                End If
            End If
            Return retVal
        End Function

    End Class

End Namespace