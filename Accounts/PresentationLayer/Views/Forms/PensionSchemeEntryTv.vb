Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class PensionSchemeEntryTv
        Implements IPensionSchemeView

        Private _pensionRates As List(Of PensionRateView)

        Public Sub New()

            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()

            MainTableName = "PensionScheme"
            TvMainFieldName = "PensionSchemeName"
            TvSecondaryFieldName = "PensionSchemeCode"
            SortOrderKey = "PensionSchemeName"
            FirstControl = txtPensionSchemeCode
            PresenterObj = New PensionSchemePresenter(Me)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)

        End Sub

#Region "Fields"

        Public Property IdNo As Int16 Implements IPensionSchemeView.IdNo
            Get
                Return NumParser(Of Int16)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property AccountIdNo As Int16 Implements IPensionSchemeView.AccountIdNo
            Get
                Return cboAccountIdNo.GetValue()
            End Get
            Set
                cboAccountIdNo.SetValue(Value)
            End Set
        End Property

        Public Property PensionProviderIdNo As Int16 Implements IPensionSchemeView.PensionProviderIdNo
            Get
                Return cboPensionProviderIdNo.GetValue()
            End Get
            Set
                cboPensionProviderIdNo.SetValue(Value)
            End Set
        End Property

        Public Property PensionSchemeCode As String Implements IPensionSchemeView.PensionSchemeCode
            Get
                Return txtPensionSchemeCode.Text
            End Get
            Set
                txtPensionSchemeCode.Text = Value
            End Set
        End Property

        Public Property PensionSchemeName As String Implements IPensionSchemeView.PensionSchemeName
            Get
                Return txtPensionSchemeName.Text
            End Get
            Set
                txtPensionSchemeName.Text = Value
            End Set
        End Property

        Public Property PensionSchemeNameAra As String Implements IPensionSchemeView.PensionSchemeNameAra
            Get
                Return txtPensionSchemeNameAra.Text
            End Get
            Set
                txtPensionSchemeNameAra.Text = Value
            End Set
        End Property

        Public Property PensionRates As List(Of PensionRateView) Implements IPensionSchemeView.PensionRates
            Get
                Return _pensionRates
            End Get
            Set
                _pensionRates = Value
                BindPensionRates()
            End Set
        End Property

        Public Property Notes As String Implements IPensionSchemeView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = Value
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateDataSources()
            cboAccountIdNo.DataSource = PresenterObj.GetAccountList()
            cboPensionProviderIdNo.DataSource = PresenterObj.GetLookup("PensionProvider")
        End Sub

        Private Sub BindPensionRates()
            SuspendLayout()
            bsPensionRates.DataSource = Nothing
            DataGridViewPensionRates.Refresh()
            bsPensionRates.DataSource = PensionRates
            With DataGridViewPensionRates
                .Refresh()
                .AutoGenerateColumns = False
                .DataSource = Nothing
                .DataSource = bsPensionRates
                .Refresh()
            End With
            ResumeLayout()
        End Sub

        Protected Overrides Sub CreateFieldsDictionary()
            FieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"AccountIdNo", cboAccountIdNo},
                {"PensionProviderIdNo", cboPensionProviderIdNo},
                {"PensionSchemeCode", txtPensionSchemeCode},
                {"PensionSchemeName", txtPensionSchemeName},
                {"PensionSchemeNameAra", txtPensionSchemeNameAra},
                {"IdNo", TxtIdNo},
                {"Notes", txtNotes}
                }
        End Sub

    End Class

End Namespace