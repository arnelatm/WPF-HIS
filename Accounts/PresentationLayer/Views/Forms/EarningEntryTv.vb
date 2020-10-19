Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class EarningEntryTv
        Implements IEarningView

        Private _accountsByCode
        Private _payGroupsByCode
        Private _payrollEarnAccounts As List(Of PayrollEarnAccountView)

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

        Public Property IdNo As Int16 Implements IEarningView.IdNo
            Get
                Return NumParser(Of Int16)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property AccountIdNo As Int16 Implements IEarningView.AccountIdNo
            Get
                Return cboAccountIdNo.GetValue()
            End Get
            Set
                cboAccountIdNo.SetValue(Value)
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
                txtName.Text = Value
            End Set
        End Property

        Public Property EarningNameAra As String Implements IEarningView.EarningNameAra
            Get
                Return txtEarningNameAra.Text
            End Get
            Set
                txtEarningNameAra.Text = Value
                txtNameAra.Text = Value
            End Set
        End Property

        Public Property Frequency As Char Implements IEarningView.Frequency
            Get
                Return cboFrequency.GetValue()
            End Get
            Set
                cboFrequency.SetValue(Value)
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

        Public Property PayrollEarnAccounts As List(Of PayrollEarnAccountView) Implements IEarningView.PayrollEarnAccounts
            Get
                Return _payrollEarnAccounts
            End Get
            Set
                _payrollEarnAccounts = Value
                BindPayrollEarnAccounts()
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
            cboFrequency.DataSource = PresenterObj.MakeEnumComboList(Of PayFrequencySelection)
            cboEarningType.DataSource = PresenterObj.MakeEnumComboList(Of EarningTypeSelection)
            cboAccountIdNo.DataSource = PresenterObj.GetChartList()
            _accountsByCode = PresenterObj.GetDetailAccountListByCode()
            _payGroupsByCode = PresenterObj.GetListByCode("PayGroup")
        End Sub

        Private Sub BindPayrollEarnAccounts()
            SuspendLayout()
            bsPayrollEarnAccounts.DataSource = Nothing
            DataGridViewPayrollEarnAccounts.Refresh()
            bsPayrollEarnAccounts.DataSource = PayrollEarnAccounts
            'bsPayrollEarnAccounts.AllowNew = True
            With DataGridViewPayrollEarnAccounts
                .Refresh()
                .AutoGenerateColumns = False
                .DataSource = Nothing
                .DataSource = bsPayrollEarnAccounts
                .Refresh()
            End With
            With DataGridViewPayrollEarnAccounts.Columns
                dgvPayGroupIdNo.DataSource = _payGroupsByCode
                dgvPayGroupIdNo.DisplayMember = "Name"
                dgvPayGroupIdNo.ValueMember = "IdNo"
                dgvPayGroupIdNo.AutoComplete = AutoCompleteMode.SuggestAppend
                dgvPayGroupIdNo.DisplayStyleForCurrentCellOnly = True
                dgvAccountIdNo.DataSource = _accountsByCode
                dgvAccountIdNo.DisplayMember = "Name"
                dgvAccountIdNo.ValueMember = "IdNo"
                dgvAccountIdNo.AutoComplete = AutoCompleteMode.SuggestAppend
                dgvAccountIdNo.DisplayStyleForCurrentCellOnly = True
            End With
            ResumeLayout()
        End Sub

        Protected Overrides Sub CreateFieldsDictionary()
            FieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"AccountIdNo", cboAccountIdNo},
                {"EarningCode", txtEarningCode},
                {"EarningName", txtEarningName},
                {"EarningNameAra", txtEarningNameAra},
                {"EarningType", cboEarningType},
                {"Frequency", cboFrequency},
                {"IdNo", TxtIdNo},
                {"Notes", txtNotes}
                }
        End Sub

        Private Sub OnEarningTypeSelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEarningType.SelectedIndexChanged
            If GetEnumCodeValue(Of EarningTypeSelection)(cboEarningType.SelectedValue) = EarningTypeSelection.Miscellaneous Then
                cboFrequency.SelectedValue = GetEnumCode(PayFrequencySelection.AsNeeded)
                cboFrequency.DisplayOnly = True
            Else
                cboFrequency.DisplayOnly = False
            End If
        End Sub

        Private Sub BindPayrollEarnAccount()
            SuspendLayout()
            bsPayrollEarnAccounts.DataSource = Nothing
            DataGridViewPayrollEarnAccounts.Refresh()
            bsPayrollEarnAccounts.DataSource = PayrollEarnAccounts
            bsPayrollEarnAccounts.AllowNew = True
            With DataGridViewPayrollEarnAccounts
                .Refresh()
                .AutoGenerateColumns = False
                .DataSource = bsPayrollEarnAccounts
                .Refresh()
            End With
            With DataGridViewPayrollEarnAccounts.Columns
                dgvAccountIdNo.DataSource = _accountsByCode
                dgvAccountIdNo.DisplayMember = "Name"
                dgvAccountIdNo.ValueMember = "IdNo"
                dgvAccountIdNo.AutoComplete = AutoCompleteMode.SuggestAppend
                dgvAccountIdNo.DisplayStyleForCurrentCellOnly = True
                dgvAccountIdNo.AutoComplete = True
                dgvPayGroupIdNo.DataSource = _payGroupsByCode
                dgvPayGroupIdNo.DisplayMember = "Name"
                dgvPayGroupIdNo.ValueMember = "idNo"
                dgvPayGroupIdNo.AutoComplete = AutoCompleteMode.SuggestAppend
                dgvPayGroupIdNo.DisplayStyleForCurrentCellOnly = True
            End With
            ResumeLayout()
        End Sub

    End Class

End Namespace