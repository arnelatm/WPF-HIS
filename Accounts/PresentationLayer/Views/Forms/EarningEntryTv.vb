Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms

    Public Class EarningEntryTv
        Implements IEarningView

        Private _accountsByCode
        Private _payGroupsByCode
        Private _payrollEarnAccounts As List(Of PayrollEarnAccountView)
        Private _useRevCostCenters As Nullable(Of Boolean)
        Private _useDepartments As Nullable(Of Boolean)
        Private _usePayGroups As Nullable(Of Boolean)
        Private _unit As Char
        Private _unitPosition As TableLayoutPanelCellPosition
        Private ReadOnly _nfi As NumberFormatInfo = GlobalVariables.DefaultNumberFormatInfo

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

        Public Property IncludeInEos As Boolean Implements IEarningView.IncludeInEos
            Get
                Return chkIncludeInEOS.Checked
            End Get
            Set
                chkIncludeInEOS.Checked = Value
            End Set
        End Property

        Public Property IncludeInPension As Boolean Implements IEarningView.IncludeInPension
            Get
                Return chkIncludeInPension.Checked
            End Get
            Set
                chkIncludeInPension.Checked = Value
            End Set
        End Property

        Public Property Multiplier As Decimal Implements IEarningView.Multiplier
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtMultiplier.Text), _nfi)
            End Get
            Set
                txtMultiplier.Text = Value.ToString("F4")
            End Set
        End Property

        Public Property MultiplierType As Char Implements IEarningView.MultiplierType
            Get
                Return cboMultiplierType.GetValue()
            End Get
            Set
                cboMultiplierType.SetValue(Value)
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

        Public Property BasePaymentIdNo As Int16? Implements IEarningView.BasePaymentIdNo
            Get
                Return cboBasePaymentIdNo.GetValue()
            End Get
            Set
                cboBasePaymentIdNo.SetValue(Value)
            End Set
        End Property

        Public Property CalculationType As Char Implements IEarningView.CalculationType
            Get
                Return cboCalculationType.GetValue()
            End Get
            Set
                cboCalculationType.SetValue(Value)
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

        Public Property EarningType As Char Implements IEarningView.EarningType
            Get
                Return cboEarningType.GetValue()
            End Get
            Set
                cboEarningType.SetValue(Value)
            End Set
        End Property

        Public Property Unit As Char Implements IEarningView.Unit
            Get
                Return cboUnit.GetValue()
            End Get
            Set
                cboUnit.SetValue(Value)
            End Set
        End Property

        Public Property UsePayGroups As Boolean Implements IEarningView.UsePayGroups
            Get
                Return chkUsePayGroups.Checked
            End Get
            Set
                chkUsePayGroups.Checked = Value
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

        Public Property Rate As Decimal Implements IEarningView.Rate
            Get
                Return txtRate.Text.ToDecimalNumber(_nfi)
            End Get
            Set
                txtRate.Text = FormatDecimalNumber(Value)
            End Set
        End Property

        'Public ReadOnly Property EarningIdNoDataGridViewTextBoxColumnProperty As DataGridViewTextBoxColumn
        '    Get
        '        Return EarningIdNoDataGridViewTextBoxColumn
        '    End Get
        'End Property

        Public Property Taxable As Boolean Implements IEarningView.Taxable
            Get
                Return chkTaxable.Checked
            End Get
            Set
                chkTaxable.Checked = Value
            End Set
        End Property

        Public Property DefaultQuantity As Decimal Implements IEarningView.DefaultQuantity
            Get
                Return txtDefaultQuantity.Text.ToDecimalNumber(_nfi)
            End Get
            Set
                txtDefaultQuantity.Text = FormatDecimalNumber(Value)
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateDataSources()
            'cboFrequency.DataSource = PresenterObj.MakeEnumComboList(Of PayFrequencySelection)
            cboEarningType.DataSource = PresenterObj.MakeEnumComboList(Of EarningTypeSelection)
            cboAccountIdNo.DataSource = PresenterObj.GetDetailAccountList
            cboCalculationType.DataSource = PresenterObj.MakeEnumComboList(Of CalculationTypeSelection)
            cboMultiplierType.DataSource = PresenterObj.MakeEnumComboList(Of MultiplierTypeSelection)
            cboBasePaymentIdNo.DataSource = PresenterObj.GetListByCodeName("Earning")
            cboUnit.DataSource = PresenterObj.MakeEnumComboList(Of PayRateUnitSelection)
            _accountsByCode = PresenterObj.GetDetailAccountList()
            _payGroupsByCode = PresenterObj.GetListByCodeName("PayGroup")
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
                {"IdNo", TxtIdNo},
                {"Notes", txtNotes}
                }
        End Sub

        'Private Sub OnEarningTypeSelectedIndexChanged(sender As Object, e As EventArgs)
        '    If GetEnumCodeValue(Of EarningTypeSelection)(cboEarningType.SelectedValue) = EarningTypeSelection.Miscellaneous Then
        '        cboFrequency.SelectedValue = GetEnumCode(PayFrequencySelection.AsNeeded)
        '        cboFrequency.DisplayOnly = True
        '    Else
        '        cboFrequency.DisplayOnly = False
        '    End If
        'End Sub

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

        Private Sub cboCalculationType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCalculationType.SelectedIndexChanged
            Me.DoubleBuffered = True
            SuspendLayout()
            floCalculation.Visible = False
            UpdateCalculationTabDisplay()
            floCalculation.Visible = True
            ResumeLayout()
        End Sub

        Private Sub UpdateCalculationTabDisplay()
            SuspendLayout()
            floCalculation.Visible = False
            tlpCalculation.Visible = False
            Dim curCalculationType = GetEnumCodeValue(Of CalculationTypeSelection)(cboCalculationType.SelectedValue)
            'tlpCalculation.SetCellPosition(cboUnit, _unitPosition)
            Dim cellPosOrig As TableLayoutPanelCellPosition = New TableLayoutPanelCellPosition(3, 2)
            Dim cellPos As TableLayoutPanelCellPosition = New TableLayoutPanelCellPosition(1, 3)
            lblFactoredUnit.Visible = False
            Select Case curCalculationType
                Case CalculationTypeSelection.Fixed
                    cboBasePaymentIdNo.Visible = False
                    cboMultiplierType.Visible = False
                    cboUnit.Visible = True
                    lblBasePayment.Visible = False
                    lblDefaultQuantity.Visible = False
                    lblMultiplier.Visible = False
                    lblPayRate.Visible = True
                    lblRate.Visible = True
                    lblRate.Text = Messaging.TranslateCaption("Amount / Unit")
                    'lblPayRate.Text = Messaging.TranslateCaption("/")
                    txtDefaultQuantity.Visible = False
                    txtMultiplier.Visible = False
                    txtRate.Visible = True
                    tlpCalculation.SetCellPosition(cboUnit, cellPosOrig)
                Case CalculationTypeSelection.Factor
                    cboBasePaymentIdNo.Visible = True
                    cboMultiplierType.Visible = True
                    cboUnit.Visible = True
                    lblBasePayment.Visible = True
                    lblDefaultQuantity.Visible = True
                    lblMultiplier.Visible = True
                    lblPayRate.Visible = False
                    lblRate.Visible = False
                    lblFactoredUnit.Visible = True
                    tlpCalculation.SetCellPosition(cboUnit, cellPos)
                    cboUnit.Visible = True
                    'SwapPosition(cboFactoredUnit,cboUnit)
                    txtDefaultQuantity.Visible = True
                    txtMultiplier.Visible = True
                    txtRate.Visible = False
                Case CalculationTypeSelection.Variable
                    cboBasePaymentIdNo.Visible = False
                    cboMultiplierType.Visible = False
                    cboUnit.Visible = True
                    lblBasePayment.Visible = False
                    lblDefaultQuantity.Visible = True
                    lblMultiplier.Visible = False
                    lblPayRate.Visible = True
                    lblRate.Visible = True
                    lblRate.Text = Messaging.TranslateCaption("Rate or Amount / Unit")
                    txtDefaultQuantity.Visible = True
                    txtMultiplier.Visible = False
                    txtRate.Visible = True
                    tlpCalculation.SetCellPosition(cboUnit, cellPosOrig)
                Case CalculationTypeSelection.Global
                    cboBasePaymentIdNo.Visible = False
                    cboMultiplierType.Visible = False
                    cboUnit.Visible = True
                    lblBasePayment.Visible = False
                    lblDefaultQuantity.Visible = True
                    lblMultiplier.Visible = False
                    lblPayRate.Visible = True
                    lblRate.Visible = True
                    lblRate.Text = Messaging.TranslateCaption("Rate or Amount / Unit")
                    txtDefaultQuantity.Visible = True
                    txtMultiplier.Visible = False
                    txtRate.Visible = True
                    tlpCalculation.SetCellPosition(cboUnit, cellPosOrig)
            End Select
            tlpCalculation.Visible = True
            floCalculation.Visible = True
            ResumeLayout()
        End Sub

        'Private Sub chkPostToSingleAccount_CheckedChanged(sender As Object, e As EventArgs)
        '    If chkPostToSingleAccount.Checked Then
        '        lblAccountIdNo.Text = Messaging.TranslateCaption("Posting Account")
        '        'tbpAccountPosting.Enabled = False
        '    Else
        '        lblAccountIdNo.Text = Messaging.TranslateCaption("Default Posting Account")
        '        'tbpAccountPosting.Enabled = True
        '    End If
        'End Sub

        'Private Sub tbcEarning_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcEarning.SelectedIndexChanged
        '    SuspendLayout()
        '    ' prevent flicker
        '    floPostingAccounts.Visible = False
        '    If _usePayGroups And chkUsePayGroups.Checked Then
        '        If tbcEarning.SelectedTab Is tbpAccountPosting Then
        '            tbcEarning.SelectedTab = tbpAccountPosting
        '            cboAccountIdNo.Select()
        '        End If
        '    Else
        '        If tbcEarning.SelectedTab Is tbpAccountPosting Then
        '            tbcEarning.SelectedTab = tbpMain
        '            cboAccountIdNo.Select()
        '        End If
        '    End If
        '    floPostingAccounts.Visible = True
        '    ResumeLayout()
        'End Sub

        Private Sub EarningEntryTv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            _useDepartments = PresenterObj.GetDepartmentUseSetting()
            If _useDepartments Is Nothing Then
                _useDepartments = False
            End If
            _useRevCostCenters = PresenterObj.GetRevCostCenterUseSetting()
            If _useRevCostCenters Is Nothing Then
                _useRevCostCenters = False
            End If
            _usePayGroups = PresenterObj.UsePayGroups()
            If _usePayGroups Is Nothing Then
                _usePayGroups = False
            End If
            _unitPosition = tlpCalculation.GetCellPosition(cboUnit)
            'If _usePayGroups Then
            '    chkUsePayGroups.Visible = True
            '    lblUsePayGroups.Visible = True
            '    DataGridViewPayrollEarnAccounts.Visible = True
            'Else
            '    chkUsePayGroups.Visible = False
            '    lblUsePayGroups.Visible = False
            '    DataGridViewPayrollEarnAccounts.Visible = False
            'End If
        End Sub

        Private Sub ChkUsePayGroups_CheckedChanged(sender As Object, e As EventArgs) Handles chkUsePayGroups.CheckedChanged
            UpdatePostingTabDisplay()
        End Sub

        Private Sub UpdatePostingTabDisplay()
            If _usePayGroups IsNot Nothing And _usePayGroups Then
                DataGridViewPayrollEarnAccounts.Visible = True
                chkUsePayGroups.Visible = True
                lblUsePayGroups.Visible = True
                If chkUsePayGroups.Checked Then
                    DataGridViewPayrollEarnAccounts.Visible = True
                    lblAccountIdNo.Text = Messaging.TranslateCaption("Default Posting Account")
                Else
                    DataGridViewPayrollEarnAccounts.Visible = False
                    lblAccountIdNo.Text = Messaging.TranslateCaption("Posting Account")
                End If
            Else
                If _usePayGroups Is Nothing Then
                    _usePayGroups = False
                End If
                DataGridViewPayrollEarnAccounts.Visible = False
                chkUsePayGroups.Visible = False
                lblUsePayGroups.Visible = False
                lblAccountIdNo.Text = Messaging.TranslateCaption("Posting Account")
                DataGridViewPayrollEarnAccounts.Visible = False
            End If
        End Sub

        Private Sub tbpCalculation_Enter(sender As Object, e As EventArgs) Handles tbpCalculation.Enter
            UpdateCalculationTabDisplay()
        End Sub

        Private Sub tbpAccountPosting_Enter(sender As Object, e As EventArgs) Handles tbpAccountPosting.Enter
            UpdatePostingTabDisplay()
        End Sub

        Private Sub SwapPosition(c1 As Control, c2 As Control)
            Dim tlp As TableLayoutPanel = TryCast(c1.Parent, TableLayoutPanel)
            If tlpCalculation Is c2.Parent AndAlso tlp IsNot Nothing Then
                Dim posC1 As TableLayoutPanelCellPosition = tlp.GetCellPosition(c1)
                Dim posC2 As TableLayoutPanelCellPosition = tlp.GetCellPosition(c2)
                tlp.SetCellPosition(c2, posC1)
                tlp.SetCellPosition(c1, posC2)
            End If
        End Sub

    End Class

End Namespace