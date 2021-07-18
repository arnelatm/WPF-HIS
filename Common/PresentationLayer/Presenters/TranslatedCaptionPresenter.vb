Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Common.ServiceLayer
Imports AATM.Libraries
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class TranslatedCaptionPresenter(Of TM As New)
        Inherits CommonPresenterNew(Of ITranslatedCaptionView, TM)

        Private Property Dac

        Public Sub New(view As ITranslatedCaptionView)
            MyBase.New(view)
            Service = New ServiceCommon("TranslatedCaption")
            TableName = "TranslatedCaption"
            SortOrderKey = "MessageKey"
            TreeViewMainField = "MessageKey"
            TreeViewSecondaryField = Nothing
            TreeViewList = New List(Of TM)
            Dac = New Dac
        End Sub

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
        End Function

        Protected Shadows Function UpDateRecord(record As TranslatedCaptionModel) As Integer
            Dim retVal As Integer
            If String.IsNullOrEmpty(record.TranslatedCaption) Then
                retVal = Service.DeleteRecord(record.IdNo, "TranslatedCaption")
            Else
                If String.IsNullOrEmpty(record.TranslatedCaption) Then
                    record.TranslatedCaption = ""
                End If
                retVal = Service.UpdateRecord(record)
                If retVal = 0 Then
                    If Not (String.IsNullOrEmpty(record.TranslatedCaption)) Then
                        record.LanguageIdNo = Dac.DefaultMirroredLanguageIdNo
                        NewlyAddedRecordIdNo = Service.AddRecord(record)
                        retVal = NewlyAddedRecordIdNo
                        Invoker.SetProperty(View, "IdNo", {retVal})
                    End If
                End If
            End If
            Return retVal
        End Function

    End Class

End Namespace