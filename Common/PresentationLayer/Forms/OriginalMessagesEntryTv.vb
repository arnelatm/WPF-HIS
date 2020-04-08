Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Forms

    Public Class OriginalMessagesEntryTv
        Implements IOriginalMessagesView, ITranslatedMessagesView

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()
            FormTitleCaption = "System Messages Maintenance Form"
            MainTableName = "OriginalMessages"
            TvMainFieldName = "Message"
            TvSecondaryFieldName = "MessageKey"
            SortOrderKey = "Message"
            FirstControl = txtMessageKey
            ' Add any initialization after the InitializeComponent() call.
            PresenterObj = New OriginalMessagesPresenter(Me)

            PresenterObj.TranslatedMessagesPresenter = New TranslatedMessagesPresenter(Me)
            PresenterObj.AddChildPresenter(PresenterObj.TranslatedMessagesPresenter)
        End Sub

#Region "OriginalMessageFields"

        Public Property IDNo As Integer Implements IOriginalMessagesView.IdNo
            Get
                Return NumParser(Of Int32)(TxtIDNo.Text)
            End Get
            Set
                TxtIDNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property MessageKey As String Implements IOriginalMessagesView.MessageKey
            Get
                Return txtMessageKey.Text
            End Get
            Set
                txtMessageKey.Text = Value
            End Set
        End Property

        Public Property Message As String Implements IOriginalMessagesView.Message
            Get
                Return txtMessage.Text
            End Get
            Set
                txtMessage.Text = Value
            End Set
        End Property

        Public Property Caption As String Implements IOriginalMessagesView.Caption
            Get
                Return txtCaption.Text
            End Get
            Set
                txtCaption.Text = Value
            End Set
        End Property

        Public Property Notes As String Implements IOriginalMessagesView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = Value
            End Set
        End Property

        Protected Overrides Sub AddMandatoryFieldCheck()
            'Add controls one by one in error provider.
            MyErrorProvider.Controls.AddMandatory(txtMessageKey, "Message Key")
            MyErrorProvider.Controls.AddMandatory(txtMessage, "Original Message")
            'Set summary error message
            MyErrorProvider.SummaryMessage = "Following fields are mandatory,"
        End Sub

#End Region

#Region "TranslatedMessagesFields"

        Public Property TranslatedMessageIdNo As Integer Implements ITranslatedMessagesView.TranslatedMessageIdNo
            Get
                Return NumParser(Of Integer)(txtIdNoTranslated.Text)
            End Get
            Set(value As Integer)
                txtIdNoTranslated.Text = value
            End Set
        End Property

        Public Property MessageIdNo As Integer Implements ITranslatedMessagesView.MessageIdNo
            Get
                Return NumParser(Of Integer)(TxtIDNo.Text)
            End Get
            Set(value As Integer)
                txtMessageIdNo.Text = value
            End Set
        End Property

        Public Property LanguageIdNo As Integer Implements ITranslatedMessagesView.LanguageIdNo

        Public Property TranslatedMessage As String Implements ITranslatedMessagesView.TranslatedMessage
            Get
                Return txtTranslatedMessage.Text
            End Get
            Set
                txtTranslatedMessage.Text = Value
            End Set
        End Property

        Public Property TranslatedCaption As String Implements ITranslatedMessagesView.TranslatedCaption
            Get
                Return txtTranslatedCaption.Text
            End Get
            Set
                txtTranslatedCaption.Text = Value
            End Set
        End Property

#End Region

        Private Sub OriginalMessagesEntryTv_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
            Show()
            Dim controlSecurityValues = SecurityPresenterObj.GetUserSecurityForKey("_Developer", GlobalVariables.SecurityGroupIdNo)
            If Not (controlSecurityValues IsNot Nothing AndAlso controlSecurityValues.Count > 0 AndAlso controlSecurityValues(0)) Then
                ' Visible property stored in first element of the array
                HideButton(btnDelete)
            End If
        End Sub

        Private Sub OnAfterTranslateForm() Handles MyBase.AfterTranslateForm
            txtMessage.RightToLeft = RightToLeft.No
            txtTranslatedCaption.RightToLeft = RightToLeft.Yes
        End Sub

    End Class

End Namespace