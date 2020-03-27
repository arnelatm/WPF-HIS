Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Forms

    Public Class OriginalCaptionsEntryTv
        Implements IOriginalCaptionsView, ITranslatedMessagesView

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()

            MainTableName = "OriginalMessages"
            IdFieldName = "IdNo"
            TvMainFieldName = "Message"
            TvSecondaryFieldName = "MessageKey"
            SortOrderKey = "Message"
            FirstControl = txtMessageKey
            ' Add any initialization after the InitializeComponent() call.
            PresenterObj = New OriginalMessagesPresenter(Me)

            PresenterObj.TranslatedMessagesPresenter = New TranslatedMessagesPresenter(Me)

            'CreateEnumResourceFile()

            'ResourceEnumConverter.MakeResource("OriginalMessagesTypeSelection", GetType(OriginalMessagesTypeSelection))
        End Sub

        Public Sub CreateEnumResourceFile()
            'ResourceEnumConverter.MakeResource("YesNoSelection", GetType(YesNoSelection))
            'ResourceEnumConverter.MakeResource("OriginalMessagesTypeSelection", GetType(OriginalMessagesTypeSelection))
            'ResourceEnumConverter.MakeResource("ImageTypeSelection", GetType(ImageTypeSelection))
        End Sub

#Region "OriginalMessageFields"

        Public Property IDNo As Integer Implements IOriginalCaptionsView.IdNo
            Get
                Return GlobalFunctions.NumParser(Of Int32)(TxtIDNo.Text)
            End Get
            Set
                TxtIDNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property MessageKey As String Implements IOriginalCaptionsView.MessageKey
            Get
                Return txtMessageKey.Text
            End Get
            Set
                txtMessageKey.Text = Value
            End Set
        End Property

        Public Property Message As String Implements IOriginalCaptionsView.Message
            Get
                Return txtMessage.Text
            End Get
            Set
                txtMessage.Text = Value
            End Set
        End Property

        Public Property Caption As String Implements IOriginalCaptionsView.Caption
            Get
                Return txtCaption.Text
            End Get
            Set
                txtCaption.Text = Value
            End Set
        End Property

        Public Property Notes As String Implements IOriginalCaptionsView.Notes
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

        Public Property IdNoTranslated As Integer Implements ITranslatedMessagesView.IdNo
            Get
                Return GlobalFunctions.NumParser(Of Integer)(txtIdNoTranslated.Text)
            End Get
            Set(value As Integer)
                txtIdNoTranslated.Text = value
            End Set
        End Property

        Public Property OriginalIdNo As Integer Implements ITranslatedMessagesView.OriginalIdNo
            Get
                Return GlobalFunctions.NumParser(Of Integer)(TxtIDNo.Text)
            End Get
            Set(value As Integer)
                txtOriginalIdNo.Text = value
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

        Protected Overrides Function ChangesMade()
            If PresenterObj.ChangesMade() Then
                Return True
            End If
            Return PresenterObj.TranslatedMessagesPresenter.ChangesMade()
        End Function

        Public Sub OnParentRecordUpdatedSuccessfully(passedValue As Integer) Handles MyBase.ParentRecordUpdatedSuccessfully
            PresenterObj.TranslatedMessagesPresenter.Save(AddMode)
        End Sub

        'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '    MessageBox.Show(txtMessageKey.Enabled.ToString())
        'End Sub

        'Private Sub txtMessageKey_EnabledChanged(sender As Object, e As EventArgs) Handles txtMessageKey.EnabledChanged
        '    'Debugger.Break()
        'End Sub
    End Class

End Namespace