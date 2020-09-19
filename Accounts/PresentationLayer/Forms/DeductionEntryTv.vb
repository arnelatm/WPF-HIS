Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Forms

    Public Class DeductionEntryTv
        Implements IDeductionView

        Public Sub New()

            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()

            MainTableName = "Deduction"
            TvMainFieldName = "DeductionName"
            TvSecondaryFieldName = "DeductionCode"
            SortOrderKey = "DeductionName"
            FirstControl = txtDeductionCode
            PresenterObj = New DeductionPresenter(Me)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)

        End Sub

#Region "Fields"

        Public Property IdNo As Int16 Implements IDeductionView.IdNo
            Get
                Return NumParser(Of Int16)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property DeductionCode As String Implements IDeductionView.DeductionCode
            Get
                Return txtDeductionCode.Text
            End Get
            Set
                txtDeductionCode.Text = Value
            End Set
        End Property

        Public Property DeductionName As String Implements IDeductionView.DeductionName
            Get
                Return txtDeductionName.Text
            End Get
            Set
                txtDeductionName.Text = Value
            End Set
        End Property

        Public Property DeductionNameAra As String Implements IDeductionView.DeductionNameAra
            Get
                Return txtDeductionNameAra.Text
            End Get
            Set
                txtDeductionNameAra.Text = Value
            End Set
        End Property

        Public Property AccountIdNo As Int16? Implements IDeductionView.AccountIdNo
            Get
                Return cboAccountIdNo.GetValue()
            End Get
            Set
                cboAccountIdNo.SetValue(Value)
            End Set
        End Property

        Public Property DefaultFrequency As Char Implements IDeductionView.DefaultFrequency
            Get
                Return cboDefaultFrequency.GetValue()
            End Get
            Set
                cboDefaultFrequency.SetValue(Value)
            End Set
        End Property

        Public Property DeductionType As Char Implements IDeductionView.DeductionType
            Get
                Return cboDeductionType.GetValue()
            End Get
            Set
                cboDeductionType.SetValue(Value)
            End Set
        End Property

        Public Property Notes As String Implements IDeductionView.Notes
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
            cboDeductionType.DataSource = PresenterObj.MakeEnumComboList(Of DeductionTypeSelection)
        End Sub

        Protected Overrides Sub CreateFieldsDictionary()
            FieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"DeductionCode", txtDeductionCode},
                {"DeductionName", txtDeductionName},
                {"DeductionNameAra", txtDeductionNameAra},
                {"IdNo", TxtIdNo},
                {"Notes", txtNotes}
                }
        End Sub

        Private Sub OnDeductionTypeSelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDeductionType.SelectedIndexChanged
            If GetEnumCodeValue(Of DeductionTypeSelection)(cboDeductionType.SelectedValue) = DeductionTypeSelection.Others Then
                cboDefaultFrequency.SelectedValue = GetEnumCode(PayFrequencySelection.AsNeeded)
                cboDefaultFrequency.DisplayOnly = True
            Else
                cboDefaultFrequency.DisplayOnly = False
            End If
        End Sub

    End Class

End Namespace