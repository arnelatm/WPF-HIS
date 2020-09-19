Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Libraries
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class TranslatedMessagesPresenter
        Inherits CommonPresenter(Of ITranslatedMessagesView, TranslatedMessagesModel)

        Private Property Dac

        Public Sub New(view As ITranslatedMessagesView)
            MyBase.New(view)
            ModelPresenter = New ModelCommon("TranslatedMessages")
            TableName = "TranslatedMessages"
            SortOrderKey = "MessageKey"
            TreeViewMainField = "MessageKey"
            TreeViewSecondaryField = Nothing
            OriginalModel = New TranslatedMessagesModel()
            DataModel = New TranslatedMessagesModel
            TreeViewList = New List(Of TranslatedMessagesModel)
            Dac = New Dac
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
        End Sub

        'Public Overrides Sub Display(messageIdNo As Int16)
        '    Dim idNoTm As Integer
        '    idNoTm = GetRecordFieldWithKey(messageIdNo, "TranslatedMessages", "messageIdNo", "IdNo")
        '    Dim modelData As New TranslatedMessagesModel
        '    If idNoTm <> 0 Then
        '        modelData = Model.GetRecordById(Of TranslatedMessagesModel)(messageIdNo)
        '    End If
        '    GlobalVariables.Mapper.Map(modelData, View)
        'End Sub

        Public Overrides Function ChangesMade() As Boolean
            ' need to do a non-standard compare because Using the ObjectsCompare method
            ' can only compare items with same name.  However in this case 'IdNo' is
            ' mapped differently between the view and the Model in the model it is named
            ' 'IdNo' and in the View it is named 'translatedMessageIdNo'
            ' we need to compare only the translatedCaption and TranslatedMessages fields
            Dim source = TryCast(OriginalModel, TranslatedMessagesModel)
            If source.TranslatedCaption = View.TranslatedCaption And
               source.TranslatedMessage = View.TranslatedMessage Then
                Return False
            End If
            Return True
        End Function

        Protected Overrides Function AddRecord(record As TranslatedMessagesModel) As Integer
            Dim retVal As Integer
            If Not String.IsNullOrEmpty(record.TranslatedMessage) Then
                NewlyAddedRecordIdNo = ModelPresenter.AddRecord(record)
                retVal = NewlyAddedRecordIdNo
            End If
            Return retVal
        End Function

        Protected Overrides Function UpDateRecord(record As TranslatedMessagesModel) As Integer
            Dim retVal As Integer
            If String.IsNullOrEmpty(record.TranslatedMessage) And String.IsNullOrEmpty(record.TranslatedCaption) Then
                retVal = Model.DeleteRecord(record.IdNo, "TranslatedMessages")
            Else
                If String.IsNullOrEmpty(record.TranslatedMessage) Then
                    record.TranslatedMessage = ""
                ElseIf String.IsNullOrEmpty(record.TranslatedCaption) Then
                    record.TranslatedCaption = ""
                End If
                retVal = Model.UpdateRecord(record)
                If retVal = 0 Then
                    If _
                        Not _
                        (String.IsNullOrEmpty(record.TranslatedMessage) And
                         String.IsNullOrEmpty(record.TranslatedCaption)) Then
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