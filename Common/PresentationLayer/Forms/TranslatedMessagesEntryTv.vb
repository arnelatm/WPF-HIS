Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Forms
    Public Class TranslatedMessagesEntryTv
        Implements ITranslatedMessagesView

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()

            MainTableName = "TranslatedMessages"
            IdFieldName = "IdNo"
            TvMainFieldName = "Message"
            TvSecondaryFieldName = "MessageKey"
            SortOrderKey = "Message"
            FirstControl = txtMessageKey
            ' Add any initialization after the InitializeComponent() call.
            PresenterObj = New TranslatedMessagesPresenter(Me)
            'CreateEnumResourceFile()

            'ResourceEnumConverter.MakeResource("TranslatedMessagesTypeSelection", GetType(TranslatedMessagesTypeSelection))
        End Sub

        Public Sub CreateEnumResourceFile()
            'ResourceEnumConverter.MakeResource("YesNoSelection", GetType(YesNoSelection))
            'ResourceEnumConverter.MakeResource("TranslatedMessagesTypeSelection", GetType(TranslatedMessagesTypeSelection))
            'ResourceEnumConverter.MakeResource("ImageTypeSelection", GetType(ImageTypeSelection))
        End Sub

        Public Property IDNoTranslated As Integer Implements ITranslatedMessagesView.IdNo
            Get
                Return GlobalFunctions.NumParser(Of Int32)(txtIdNo.Text)
            End Get
            Set
                TxtIDNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property IOriginalMessagesView_MessageKey As String Implements IOriginalMessagesView.MessageKey

        Public Property OriginalIdNo As Integer Implements ITranslatedMessagesView.OriginalIdNo
            Get
                Return txtOriginalIdNo.Text
            End Get
            Set
                txtOriginalIdNo.Text = Value
            End Set
        End Property

        Public Property LanguageIdNo As Integer Implements ITranslatedMessagesView.LanguageIdNo
        Public Property TranslatedMessage As String Implements ITranslatedMessagesView.TranslatedMessage
        Public Property TranslatedCaption As String Implements ITranslatedMessagesView.TranslatedCaption

        Public Property IdNo As Integer Implements IOriginalMessagesView.IdNo

        Public Property MessageKey As String Implements ITranslatedMessagesView.MessageKey
            Get
                Return txtMessageKey.Text
            End Get
            Set
                txtMessageKey.Text = Value
            End Set
        End Property

        Public Property IOriginalMessagesView_Message As String Implements IOriginalMessagesView.Message


        Public Property Message As String Implements ITranslatedMessagesView.Message
            Get
                Return txtMessage.Text
            End Get
            Set
                txtMessage.Text = Value
            End Set
        End Property

        Public Property IOriginalMessagesView_Caption As String Implements IOriginalMessagesView.Caption

        Public Property Caption As String Implements ITranslatedMessagesView.Caption
            Get
                Return txtCaption.Text
            End Get
            Set
                txtCaption.Text = Value
            End Set
        End Property

        Public Property IOriginalMessagesView_Notes As String Implements IOriginalMessagesView.Notes

        Public Property IdNoOrig As Object Implements ITranslatedMessagesView.IdNoOrig

        Public Property Notes As String Implements ITranslatedMessagesView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = Value
            End Set
        End Property

        Public Property CultureInfoCode As String Implements ITranslatedMessagesView.CultureInfoCode
        Public Property LanguageCode2 As String Implements ITranslatedMessagesView.LanguageCode2

        Protected Overrides Sub AddMandatoryFieldCheck()
            'Add controls one by one in error provider.
            'Set summary error message
            MyErrorProvider.SummaryMessage = "Following fields are mandatory,"
        End Sub

    End Class
End Namespace