Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Forms

    Public Class OriginalCaptionEntryTv
        Implements IOriginalCaptionsView, ITranslatedCaptionView

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

            PresenterObj.TranslatedCaptionPresenter = New TranslatedCaptionPresenter(Me)
            PresenterObj.AddChildPresenter(PresenterObj.TranslatedCaptionPresenter)

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

        Public Property ITranslatedCaptionView_Caption As String Implements ITranslatedCaptionView.Caption

        Public Property Caption As String Implements IOriginalCaptionsView.Caption
            Get
                Return txtCaption.Text
            End Get
            Set
                txtCaption.Text = Value
            End Set
        End Property

#End Region

#Region "TranslatedCaptionFields"

        Public Property IdNoTranslated As Integer Implements ITranslatedCaptionView.IdNo
            Get
                Return NumParser(Of Integer)(txtIdNoTranslated.Text)
            End Get
            Set(value As Integer)
                txtIdNoTranslated.Text = value
            End Set
        End Property

        Public Property CaptionIdNo As Integer Implements ITranslatedCaptionView.CaptionIdNo
            Get
                Return NumParser(Of Integer)(TxtIDNo.Text)
            End Get
            Set(value As Integer)
                txtCaptionIdNo.Text = value
            End Set
        End Property

        Public Property LanguageIdNo As Integer Implements ITranslatedCaptionView.LanguageIdNo

        Public Property TranslatedCaption As String Implements ITranslatedCaptionView.TranslatedCaption
            Get
                Return txtTranslatedCaption.Text
            End Get
            Set
                txtTranslatedCaption.Text = Value
            End Set
        End Property

#End Region

        'Protected Overrides Function ChangesMade()
        '    If PresenterObj.ChangesMade() Then
        '        Return True
        '    End If
        '    Return PresenterObj.TranslatedCaptionPresenter.ChangesMade()
        'End Function

        'Public Sub OnParentRecordUpdatedSuccessfully(passedValue As Integer) Handles MyBase.ParentRecordUpdatedSuccessfully
        '    PresenterObj.TranslatedCaptionPresenter.Save(AddMode)
        'End Sub

        Private Sub OriginalCaptionsEntryTv_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
            Show()
            Dim controlSecurityValues = SecurityPresenterObj.GetUserSecurityForKey("_Developer", GlobalVariables.SecurityGroupIdNo)
            If Not (controlSecurityValues IsNot Nothing AndAlso controlSecurityValues.Count > 0 AndAlso controlSecurityValues(0)) Then
                ' Visible property stored in first element of the array
                HideButton(btnDelete)
            End If
        End Sub

        Private Sub OnAfterTranslateForm() Handles MyBase.AfterTranslateForm
            txtCaption.RightToLeft = RightToLeft.No
            txtTranslatedCaption.RightToLeft = RightToLeft.Yes
        End Sub

    End Class

End Namespace