Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class OriginalMessagesEntryTv
        Implements IOriginalMessagesView

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

            'PresenterObj.TranslatedMessagesPresenter = New TranslatedMessagesPresenter(Me)
            'PresenterObj.AddChildPresenter(PresenterObj.TranslatedMessagesPresenter)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)
        End Sub

#Region "OriginalMessageFields"

        Public Property Caption As String Implements IOriginalMessagesView.Caption
            Get
                Return txtCaption.Text
            End Get
            Set
                txtCaption.Text = Value
            End Set
        End Property

        Public Property IdNo As Int32 Implements IOriginalMessagesView.IdNo
            Get
                Return NumParser(Of Int32)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public ReadOnly Property LanguageIdNo As Int16 Implements IOriginalMessagesView.LanguageIdNo
            Get
                Return 16
            End Get
        End Property

        Public Property Message As String Implements IOriginalMessagesView.Message
            Get
                Return txtMessage.Text
            End Get
            Set
                txtMessage.Text = Value
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

        Public Property Notes As String Implements IOriginalMessagesView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = Value
            End Set
        End Property

        Public Property TranslatedCaption As String Implements IOriginalMessagesView.TranslatedCaption
            Get
                Return txtTranslatedCaption.Text
            End Get
            Set
                txtTranslatedCaption.Text = Value
            End Set
        End Property

        Public Property TranslatedMessage As String Implements IOriginalMessagesView.TranslatedMessage
            Get
                Return txtTranslatedMessage.Text
            End Get
            Set
                txtTranslatedMessage.Text = Value
            End Set
        End Property

        Public Property IdNoTranslated As Integer Implements IOriginalMessagesView.IdNoTranslated
            Get
                Return NumParser(Of Integer)(txtIdNoTranslated.Text)
            End Get
            Set(value As Integer)
                txtIdNoTranslated.Text = value
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

        Private Sub OnAfterTranslateForm() Handles MyBase.AfterTranslateForm
            txtMessage.RightToLeft = RightToLeft.No
            txtTranslatedCaption.RightToLeft = RightToLeft.Yes
        End Sub

        Private Sub OriginalMessagesEntryTv_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
            Show()
            Dim controlSecurityValues = PresenterObj.GetUserSecurityForKey("_Developer",
                                                                                   GlobalVariables.SecurityGroupIdNo)
            If _
                Not _
                (controlSecurityValues IsNot Nothing AndAlso controlSecurityValues.Count > 0 AndAlso
                 controlSecurityValues(0)) Then
                ' Visible property stored in first element of the array
                HideButton(btnDelete)
            End If
        End Sub

    End Class

End Namespace