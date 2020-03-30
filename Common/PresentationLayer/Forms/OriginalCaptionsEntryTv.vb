Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Forms

    Public Class OriginalCaptionsEntryTv
        Implements IOriginalCaptionsView, ITranslatedCaptionsView

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()

            MainTableName = "OriginalCaptions"
            IdFieldName = "IdNo"
            TvMainFieldName = "Caption"
            TvSecondaryFieldName = "Caption"
            SortOrderKey = "Caption"
            FirstControl = txtCaption
            ' Add any initialization after the InitializeComponent() call.
            PresenterObj = New OriginalCaptionsPresenter(Me)

            PresenterObj.TranslatedCaptionsPresenter = New TranslatedCaptionsPresenter(Me)

            'CreateEnumResourceFile()

            'ResourceEnumConverter.MakeResource("OriginalCaptionsTypeSelection", GetType(OriginalCaptionsTypeSelection))
        End Sub

        Public Sub CreateEnumResourceFile()
            'ResourceEnumConverter.MakeResource("YesNoSelection", GetType(YesNoSelection))
            'ResourceEnumConverter.MakeResource("OriginalCaptionsTypeSelection", GetType(OriginalCaptionsTypeSelection))
            'ResourceEnumConverter.MakeResource("ImageTypeSelection", GetType(ImageTypeSelection))
        End Sub


#Region "OriginalCaptionFields"

        Public Property IDNo As Integer Implements IOriginalCaptionsView.IdNo
            Get
                Return NumParser(Of Int32)(TxtIDNo.Text)
            End Get
            Set
                TxtIDNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property ITranslatedCaptionsView_Caption As String Implements ITranslatedCaptionsView.Caption

        Public Property Caption As String Implements IOriginalCaptionsView.Caption
            Get
                Return txtCaption.Text
            End Get
            Set
                txtCaption.Text = Value
            End Set
        End Property

#End Region

#Region "TranslatedCaptionsFields"

        Public Property IdNoTranslated As Integer Implements ITranslatedCaptionsView.IdNo
            Get
                Return NumParser(Of Integer)(txtIdNoTranslated.Text)
            End Get
            Set(value As Integer)
                txtIdNoTranslated.Text = value
            End Set
        End Property

        Public Property CaptionIdNo As Integer Implements ITranslatedCaptionsView.CaptionIdNo
            Get
                Return NumParser(Of Integer)(TxtIDNo.Text)
            End Get
            Set(value As Integer)
                txtCaptionIdNo.Text = value
            End Set
        End Property

        Public Property LanguageIdNo As Integer Implements ITranslatedCaptionsView.LanguageIdNo

        Public Property TranslatedCaption As String Implements ITranslatedCaptionsView.TranslatedCaption
            Get
                Return txtTranslatedCaption.Text
            End Get
            Set
                txtTranslatedCaption.Text = Value
            End Set
        End Property

        Public Property CultureInfoCode As String Implements ITranslatedCaptionsView.CultureInfoCode
        Public Property LanguageCode2 As String Implements ITranslatedCaptionsView.LanguageCode2



#End Region

        Protected Overrides Function ChangesMade()
            If PresenterObj.ChangesMade() Then
                Return True
            End If
            Return PresenterObj.TranslatedCaptionsPresenter.ChangesMade()
        End Function

        Public Sub OnParentRecordUpdatedSuccessfully(passedValue As Integer) Handles MyBase.ParentRecordUpdatedSuccessfully
            PresenterObj.TranslatedCaptionsPresenter.Save(AddMode)
        End Sub

        Private Sub OriginalCaptionsEntryTv_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
            Show()
            HideButton(btnDelete)
        End Sub


        Private Sub OnAfterTranslateForm Handles MyBase.AfterTranslateForm
            txtCaption.RightToLeft = RightToLeft.No
            txtTranslatedCaption.RightToLeft = RightToLeft.Yes
        End Sub

    End Class

End Namespace