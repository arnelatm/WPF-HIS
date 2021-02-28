Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms

    Public Class DeductionEntryTv
        Implements IDeductionView

        Private _accountsByCode
        Private _payGroupsByCode
        Private _payrollDeductAccounts As List(Of PayrollDeductAccountView)
        Private _useRevCostCenters As Nullable(Of Boolean)
        Private _useDepartments As Nullable(Of Boolean)
        Private _usePayGroups As Nullable(Of Boolean)
        Private ReadOnly _nfi As NumberFormatInfo = GlobalVariables.DefaultNumberFormatInfo

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

        Public Property Multiplier As String Implements IDeductionView.Multiplier
            Get
                Return txtMultiplier.Text
            End Get
            Set
                txtMultiplier.Text = Value
            End Set
        End Property

        Public Property MultiplierType As Char Implements IDeductionView.MultiplierType
            Get
                Return cboMultiplierType.GetValue()
            End Get
            Set
                cboMultiplierType.SetValue(Value)
            End Set
        End Property

        Public Property AccountIdNo As Int16 Implements IDeductionView.AccountIdNo
            Get
                Return cboAccountIdNo.GetValue()
            End Get
            Set
                cboAccountIdNo.SetValue(Value)
            End Set
        End Property

        Public Property BasePaymentIdNo As Int16? Implements IDeductionView.BasePaymentIdNo
            Get
                Return cboBasePaymentIdNo.GetNullableValue(Of Int16)
            End Get
            Set
                cboBasePaymentIdNo.SetValue(Value)
            End Set
        End Property

        Public Property CalculationType As Char Implements IDeductionView.CalculationType
            Get
                Return cboCalculationType.GetValue()
            End Get
            Set
                cboCalculationType.SetValue(Value)
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

        Public Property DeductionType As Char Implements IDeductionView.DeductionType
            Get
                Return cboDeductionType.GetValue()
            End Get
            Set
                cboDeductionType.SetValue(Value)
            End Set
        End Property

        Public Property Unit As Char Implements IDeductionView.Unit
            Get
                Return cboUnit.GetValue()
            End Get
            Set
                cboUnit.SetValue(Value)
            End Set
        End Property

        Public Property UsePayGroups As Boolean Implements IDeductionView.UsePayGroups
            Get
                Return chkUsePayGroups.Checked
            End Get
            Set
                chkUsePayGroups.Checked = Value
            End Set
        End Property

        Public Property PayrollDeductAccounts As List(Of PayrollDeductAccountView) Implements IDeductionView.PayrollDeductAccounts
            Get
                Return _payrollDeductAccounts
            End Get
            Set
                _payrollDeductAccounts = Value
                BindPayrollDeductAccounts()
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

        Public Property Rate As Decimal Implements IDeductionView.Rate
            Get
                Return txtRate.Text.ToDecimalNumber(_nfi)
            End Get
            Set
                txtRate.Text = FormatDecimalNumber(Value)
            End Set
        End Property

        'Public ReadOnly Property DeductionIdNoDataGridViewTextBoxColumnProperty As DataGridViewTextBoxColumn
        '    Get
        '        Return DeductionIdNoDataGridViewTextBoxColumn
        '    End Get
        'End Property

        Public Property DefaultQuantity As Decimal Implements IDeductionView.DefaultQuantity
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
            cboDeductionType.DataSource = PresenterObj.MakeEnumComboList(Of DeductionTypeSelection)
            cboAccountIdNo.DataSource = PresenterObj.GetDetailAccountList()
            cboCalculationType.DataSource = PresenterObj.MakeEnumComboList(Of CalculationTypeSelection)
            cboMultiplierType.DataSource = PresenterObj.MakeEnumComboList(Of MultiplierTypeSelection)
            cboBasePaymentIdNo.DataSource = PresenterObj.GetLookup("Earning")
            cboUnit.DataSource = PresenterObj.MakeEnumComboList(Of PayRateUnitSelection)
            _accountsByCode = PresenterObj.GetDetailAccountList()
            _payGroupsByCode = PresenterObj.GetLookup("PayGroup")
        End Sub

        Private Sub BindPayrollDeductAccounts()
            SuspendLayout()
            bsPayrollDeductAccounts.DataSource = Nothing
            DataGridViewPayrollDeductAccounts.Refresh()
            bsPayrollDeductAccounts.DataSource = PayrollDeductAccounts
            'bsPayrollDeductAccounts.AllowNew = True
            With DataGridViewPayrollDeductAccounts
                .Refresh()
                .AutoGenerateColumns = False
                .DataSource = Nothing
                .DataSource = bsPayrollDeductAccounts
                .Refresh()
            End With
            With DataGridViewPayrollDeductAccounts.Columns
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
                {"DeductionCode", txtDeductionCode},
                {"DeductionName", txtDeductionName},
                {"DeductionNameAra", txtDeductionNameAra},
                {"DeductionType", cboDeductionType},
                {"IdNo", TxtIdNo},
                {"Notes", txtNotes}
                }
        End Sub

        'Private Sub OnDeductionTypeSelectedIndexChanged(sender As Object, e As EventArgs)
        '    If CodeToEnum(Of DeductionTypeSelection)(cboDeductionType.SelectedValue) = DeductionTypeSelection.Miscellaneous Then
        '        cboFrequency.SelectedValue = EnumToCode(PayFrequencySelection.AsNeeded)
        '        cboFrequency.DisplayOnly = True
        '    Else
        '        cboFrequency.DisplayOnly = False
        '    End If
        'End Sub

        Private Sub BindPayrollDeductAccount()
            SuspendLayout()
            bsPayrollDeductAccounts.DataSource = Nothing
            DataGridViewPayrollDeductAccounts.Refresh()
            bsPayrollDeductAccounts.DataSource = PayrollDeductAccounts
            bsPayrollDeductAccounts.AllowNew = True
            With DataGridViewPayrollDeductAccounts
                .Refresh()
                .AutoGenerateColumns = False
                .DataSource = bsPayrollDeductAccounts
                .Refresh()
            End With
            With DataGridViewPayrollDeductAccounts.Columns
                dgvAccountIdNo.DataSource = _accountsByCode
                dgvAccountIdNo.DisplayMember = "Name"
                dgvAccountIdNo.ValueMember = "IdNo"
                dgvAccountIdNo.DisplayStyleForCurrentCellOnly = True
                dgvPayGroupIdNo.DataSource = _payGroupsByCode
                dgvPayGroupIdNo.DisplayMember = "Name"
                dgvPayGroupIdNo.ValueMember = "idNo"
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
            Dim curCalculationType = CodeToEnum(Of CalculationTypeSelection)(cboCalculationType.SelectedValue)
            Select Case curCalculationType
                Case CalculationTypeSelection.FixedAmount
                    cboBasePaymentIdNo.Visible = False
                    cboMultiplierType.Visible = False
                    cboUnit.Visible = True
                    lblBasePayment.Visible = False
                    lblDefaultQty.Visible = False
                    lblMultiplier.Visible = False
                    lblPayRate.Visible = False
                    lblRate.Visible = True
                    lblRate.Text = Messaging.TranslateCaption("Amount / Unit")
                    txtDefaultQuantity.Visible = False
                    txtMultiplier.Visible = False
                    txtRate.Visible = True
                Case CalculationTypeSelection.Factor
                    cboBasePaymentIdNo.Visible = True
                    cboMultiplierType.Visible = True
                    cboUnit.Visible = True
                    lblBasePayment.Visible = True
                    lblDefaultQty.Visible = True
                    lblMultiplier.Visible = True
                    lblPayRate.Visible = False
                    lblRate.Visible = True
                    lblRate.Text = Messaging.TranslateCaption("Amount / Unit")
                    txtDefaultQuantity.Visible = True
                    txtMultiplier.Visible = True
                    txtRate.Visible = False
                Case CalculationTypeSelection.Variable
                    cboBasePaymentIdNo.Visible = False
                    cboMultiplierType.Visible = False
                    cboUnit.Visible = True
                    lblBasePayment.Visible = False
                    lblDefaultQty.Visible = True
                    lblMultiplier.Visible = False
                    lblPayRate.Visible = True
                    lblRate.Visible = True
                    lblRate.Text = Messaging.TranslateCaption("Rate or Amount / Unit")
                    txtDefaultQuantity.Visible = True
                    txtMultiplier.Visible = False
                    txtRate.Visible = True
                Case CalculationTypeSelection.Global
                    cboBasePaymentIdNo.Visible = False
                    cboMultiplierType.Visible = False
                    cboUnit.Visible = True
                    lblBasePayment.Visible = False
                    lblDefaultQty.Visible = True
                    lblMultiplier.Visible = False
                    lblPayRate.Visible = True
                    lblRate.Visible = True
                    lblRate.Text = Messaging.TranslateCaption("Rate or Amount / Unit")
                    txtDefaultQuantity.Visible = True
                    txtMultiplier.Visible = False
                    txtRate.Visible = True
                Case CalculationTypeSelection.DaysAbsent
                    cboBasePaymentIdNo.Visible = True
                    cboMultiplierType.Visible = False
                    cboUnit.Visible = False
                    lblBasePayment.Visible = True
                    lblDefaultQty.Visible = False
                    lblMultiplier.Visible = False
                    lblPayRate.Visible = False
                    lblRate.Visible = False
                    lblRate.Text = ""
                    txtDefaultQuantity.Visible = False
                    txtMultiplier.Visible = False
                    txtRate.Visible = False
                Case CalculationTypeSelection.Table
                    cboBasePaymentIdNo.Visible = True
                    cboMultiplierType.Visible = False
                    cboUnit.Visible = False
                    lblBasePayment.Visible = True
                    lblDefaultQty.Visible = False
                    lblMultiplier.Visible = False
                    lblPayRate.Visible = False
                    lblRate.Visible = False
                    lblRate.Text = ""
                    txtDefaultQuantity.Visible = False
                    txtMultiplier.Visible = False
                    txtRate.Visible = False
            End Select
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

        'Private Sub tbcDeduction_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcDeduction.SelectedIndexChanged
        '    SuspendLayout()
        '    ' prevent flicker
        '    floPostingAccounts.Visible = False
        '    If _usePayGroups And chkUsePayGroups.Checked Then
        '        If tbcDeduction.SelectedTab Is tbpAccountPosting Then
        '            tbcDeduction.SelectedTab = tbpAccountPosting
        '            cboAccountIdNo.Select()
        '        End If
        '    Else
        '        If tbcDeduction.SelectedTab Is tbpAccountPosting Then
        '            tbcDeduction.SelectedTab = tbpMain
        '            cboAccountIdNo.Select()
        '        End If
        '    End If
        '    floPostingAccounts.Visible = True
        '    ResumeLayout()
        'End Sub

        Private Sub DeductionEntryTv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            'If _usePayGroups Then
            '    chkUsePayGroups.Visible = True
            '    lblUsePayGroups.Visible = True
            '    DataGridViewPayrollDeductAccounts.Visible = True
            'Else
            '    chkUsePayGroups.Visible = False
            '    lblUsePayGroups.Visible = False
            '    DataGridViewPayrollDeductAccounts.Visible = False
            'End If
        End Sub

        Private Sub ChkUsePayGroups_CheckedChanged(sender As Object, e As EventArgs) Handles chkUsePayGroups.CheckedChanged
            UpdatePostingTabDisplay()
        End Sub

        Private Sub UpdatePostingTabDisplay()
            If _usePayGroups IsNot Nothing And _usePayGroups Then
                DataGridViewPayrollDeductAccounts.Visible = True
                chkUsePayGroups.Visible = True
                lblUsePayGroups.Visible = True
                If chkUsePayGroups.Checked Then
                    DataGridViewPayrollDeductAccounts.Visible = True
                    lblAccountIdNo.Text = Messaging.TranslateCaption("Default Posting Account")
                Else
                    DataGridViewPayrollDeductAccounts.Visible = False
                    lblAccountIdNo.Text = Messaging.TranslateCaption("Posting Account")
                End If
            Else
                If _usePayGroups Is Nothing Then
                    _usePayGroups = False
                End If
                DataGridViewPayrollDeductAccounts.Visible = False
                chkUsePayGroups.Visible = False
                lblUsePayGroups.Visible = False
                lblAccountIdNo.Text = Messaging.TranslateCaption("Posting Account")
                DataGridViewPayrollDeductAccounts.Visible = False
            End If
        End Sub

        Private Sub tbpCalculation_Enter(sender As Object, e As EventArgs) Handles tbpCalculation.Enter
            UpdateCalculationTabDisplay()
        End Sub

        Private Sub tbpAccountPosting_Enter(sender As Object, e As EventArgs) Handles tbpAccountPosting.Enter
            UpdatePostingTabDisplay()
        End Sub

    End Class

End Namespace