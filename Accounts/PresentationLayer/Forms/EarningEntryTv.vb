Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Forms

    Public Class EarningEntryTv
        Implements IEarningView

        Public Sub New()

            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()

            MainTableName = "Earning"
            TvMainFieldName = "EarningName"
            TvSecondaryFieldName = "EarningCode"
            SortOrderKey = "EarningName"
            FirstControl = txtEarningCode
            PresenterObj = New EarningPresenter(Me)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)

        End Sub

#Region "Fields"

        Public Property IdNo As Int32 Implements IEarningView.IdNo
            Get
                Return NumParser(Of Int32)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property EarningCode As String Implements IEarningView.EarningCode
            Get
                Return txtEarningCode.Text
            End Get
            Set
                txtEarningCode.Text = Value
            End Set
        End Property

        Public Property EarningName As String Implements IEarningView.EarningName
            Get
                Return txtEarningName.Text
            End Get
            Set
                txtEarningName.Text = Value
            End Set
        End Property

        Public Property EarningNameAra As String Implements IEarningView.EarningNameAra
            Get
                Return txtEarningNameAra.Text
            End Get
            Set
                txtEarningNameAra.Text = Value
            End Set
        End Property

        Public Property AccountIdNo As Int16? Implements IEarningView.AccountIdNo
            Get
                Return cboAccountIdNo.GetValue()
            End Get
            Set
                cboAccountIdNo.SetValue(Value)
            End Set
        End Property

        Public Property DefaultFrequency As Char Implements IEarningView.DefaultFrequency
            Get
                Return cboDefaultFrequency.GetValue()
            End Get
            Set
                cboDefaultFrequency.SetValue(Value)
            End Set
        End Property

        Public Property EarningType As Char Implements IEarningView.EarningType
            Get
                Return cboEarningType.GetValue()
            End Get
            Set
                cboEarningType.SetValue(Value)
            End Set
        End Property

        Public Property Notes As String Implements IEarningView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = Value
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateDataSources()
            cboAccountIdNo.DataSource = PresenterObj.GetChartList()
            cboDefaultFrequency.DataSource = PresenterObj.MakeEnumComboList(Of PayFrequencySelection)
            cboEarningType.DataSource = PresenterObj.MakeEnumComboList(Of EarningTypeSelection)
        End Sub

        Protected Overrides Sub CreateFieldsDictionary()
            FieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"EarningCode", txtEarningCode},
                {"EarningName", txtEarningName},
                {"EarningNameAra", txtEarningNameAra},
                {"IdNo", TxtIdNo},
                {"Notes", txtNotes}
                }
        End Sub

        Private Sub OnEarningTypeSelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEarningType.SelectedIndexChanged
            If GetEnumCodeValue(Of EarningTypeSelection)(cboEarningType.SelectedValue) = EarningTypeSelection.Others Then
                cboDefaultFrequency.SelectedValue = GetEnumCode(PayFrequencySelection.AsNeeded)
                cboDefaultFrequency.DisplayOnly = True
            Else
                cboDefaultFrequency.DisplayOnly = False
            End If
        End Sub

    End Class

End Namespace