Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Forms

    Public Class FringeBenefitEntryTv
        Implements IFringeBenefitView

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()
            FormTitleCaption = "FringeBenefites Maintenance Form"
            MainTableName = "FringeBenefit"
            TvMainFieldName = "FringeBenefitName"
            TvSecondaryFieldName = "FringeBenefitCode"
            SortOrderKey = "FringeBenefitName"
            FirstControl = txtFringeBenefitCode
            ' Add any initialization after the InitializeComponent() call.
            PresenterObj = New FringeBenefitPresenter(Me)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)
        End Sub

#Region "Fields"

        Public Property IdNo As Int32 Implements IFringeBenefitView.IdNo
            Get
                Return NumParser(Of Int32)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property FringeBenefitCode As String Implements IFringeBenefitView.FringeBenefitCode
            Get
                Return txtFringeBenefitCode.Text
            End Get
            Set
                txtFringeBenefitCode.Text = Value
            End Set
        End Property

        Public Property FringeBenefitName As String Implements IFringeBenefitView.FringeBenefitName
            Get
                Return txtFringeBenefitName.Text
            End Get
            Set
                txtFringeBenefitName.Text = Value
            End Set
        End Property

        Public Property FringeBenefitNameAra As String Implements IFringeBenefitView.FringeBenefitNameAra
            Get
                Return txtFringeBenefitNameAra.Text
            End Get
            Set
                txtFringeBenefitNameAra.Text = Value
            End Set
        End Property

        Public Property Notes As String Implements IFringeBenefitView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = Value
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateFieldsDictionary()
            FieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"FringeBenefitCode", txtFringeBenefitCode},
                {"FringeBenefitName", txtFringeBenefitName},
                {"FringeBenefitNameAra", txtFringeBenefitNameAra},
                {"IdNo", TxtIdNo},
                {"Notes", txtNotes}
                }
        End Sub

    End Class

End Namespace