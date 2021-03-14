Imports System.Globalization
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Views.Forms

    Public Class EarningEntryTv
        Implements IEarningView

        Private _accountsByCode
        Private _payGroupsByCode
        Private _earningsByCode
        Private _payrollEarnAccounts As List(Of PayrollEarnAccountView)
        Private _earningsSummary As List(Of EarningSummaryView)
        Private _useRevCostCenters As Nullable(Of Boolean)
        Private _useDepartments As Nullable(Of Boolean)
        Private _usePayGroups As Nullable(Of Boolean)
        Private _unit As Char

        'Private _unitPosition As TableLayoutPanelCellPosition
        Private _eSumFieldsDict As Dictionary(Of String, Object)

        Private _eAccFieldsDict As Dictionary(Of String, Object)
        Private ReadOnly _nfi As NumberFormatInfo = GlobalVariables.DefaultNumberFormatInfo
        Private _esModel = New ModelAccounts("EarningSummary")

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

        Public Property Multiplier As String Implements IEarningView.Multiplier
            Get
                Return txtMultiplier.Text  ' Convert.ToDecimal(NumParser(Of Decimal)(txtMultiplier.Text), _nfi)
            End Get
            Set
                txtMultiplier.Text = Value  'Value.ToString("F4")
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

        Public Property Summary As Boolean Implements IEarningView.Summary
            Get
                Return chkSummary.Checked
            End Get
            Set
                chkSummary.Checked = Value
                If Value Then
                    EarningType = EnumToCode(EarningTypeSelection.Computed)
                    CalculationType = EnumToCode(CalculationTypeSelection.Factor)
                    'cboEarningType.SelectedValue =
                    'cboCalculationType.SelectedValue =
                End If
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
                cboEarningType.SetValue(Value)election.OvertimeRegular) Or
                '   Value = EnumToCode(EarningTypeSelection.Ov
                'If Value = EnumToCode(EarningTypeSertimeHoliday) Or
                '   Value = EnumToCode(EarningTypeSelection.OvertimeSpecial) Then
                '    cboEarningType.DisplayOnly = True
                '    cboCalculationType.DisplayOnly = True
                'Else
                '    cboEarningType.DisplayOnly = False
                '    cboCalculationType.DisplayOnly = False
                'End If
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

        Public Property EarningsSummary As List(Of EarningSummaryView) Implements IEarningView.EarningsSummary
            Get
                Return _earningsSummary
            End Get
            Set
                _earningsSummary = Value
                BindEarningsSummary()
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

#End Region

        Protected Overrides Sub CreateDataSources()
            'cboFrequency.DataSource = PresenterObj.MakeEnumComboList(Of PayFrequencySelection)
            cboEarningType.DataSource = PresenterObj.MakeEnumComboList(Of EarningTypeSelection)
            cboAccountIdNo.DataSource = PresenterObj.GetDetailAccountList
            cboCalculationType.DataSource = PresenterObj.MakeEnumComboList(Of CalculationTypeSelection)
            cboMultiplierType.DataSource = PresenterObj.MakeEnumComboList(Of MultiplierTypeSelection)
            cboBasePaymentIdNo.DataSource = PresenterObj.GetLookup("Earning")
            cboUnit.DataSource = PresenterObj.MakeEnumComboList(Of PayRateUnitSelection)
            _accountsByCode = PresenterObj.GetDetailAccountList()
            _payGroupsByCode = PresenterObj.GetLookup("PayGroup")
            _earningsByCode = PresenterObj.GetLookup("Earning")
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

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"AccountIdNo", cboAccountIdNo},
                {"BasePaymentIdNo", cboBasePaymentIdNo},
                {"CalculationType", cboCalculationType},
                {"DefaultQuantity", txtDefaultQuantity},
                {"EarningCode", txtEarningCode},
                {"EarningName", txtEarningName},
                {"EarningNameAra", txtEarningNameAra},
                {"EarningType", cboEarningType},
                {"IdNo", TxtIdNo},
                {"IncludeInEos", chkIncludeInEOS},
                {"Multiplier", txtMultiplier},
                {"MultiplierType", cboMultiplierType},
                {"Notes", txtNotes},
                {"Rate", txtRate},
                {"Summary", chkSummary},
                {"Taxable", chkTaxable},
                {"Unit", cboUnit},
                {"UsePayGroups", chkUsePayGroups},
                {"EarningSummary", DataGridViewSummaryDetail}
                }

            _eSumFieldsDict = New Dictionary(Of String, Object) From
                {
                {"Multiplier", dgvMultiplierSummary}
                }

            _eAccFieldsDict = New Dictionary(Of String, Object) From
                {
                {"PayGroupIdNo", dgvPayGroupIdNo},
                {"AccountIdNo", dgvAccountIdNo}
                }

            DataGridViewSummaryDetail.FieldsDictionary = _eSumFieldsDict
            DataGridViewPayrollEarnAccounts.FieldsDictionary = _eAccFieldsDict

        End Sub

        Private Sub BindEarningsSummary()
            SuspendLayout()
            bsEarningSummary.DataSource = Nothing
            DataGridViewSummaryDetail.Refresh()
            bsEarningSummary.DataSource = EarningsSummary
            bsEarningSummary.AllowNew = True
            With DataGridViewSummaryDetail
                .Refresh()
                .AutoGenerateColumns = False
                .DataSource = bsEarningSummary
                .Refresh()
            End With
            With DataGridViewSummaryDetail.Columns
                dgvEarningIdNo.DataSource = _earningsByCode
                dgvEarningIdNo.ValueMember = "IdNo"
                dgvEarningIdNo.DisplayMember = "Name"
                dgvEarningIdNo.DisplayStyleForCurrentCellOnly = True
            End With
            ResumeLayout()
        End Sub

        Private Sub cboCalculationType_ValueChanged(sender As Object, e As EventArgs) Handles cboCalculationType.Validated, cboCalculationType.SelectionChangeCommitted
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
            Dim curCalculationType = CodeToEnum(Of CalculationTypeSelection)(cboCalculationType.SelectedValue)
            'tlpCalculation.SetCellPosition(cboUnit, _unitPosition)
            Dim cellPosOrigUnit As TableLayoutPanelCellPosition = New TableLayoutPanelCellPosition(3, 2)
            Dim cellPosUnit As TableLayoutPanelCellPosition = New TableLayoutPanelCellPosition(1, 3)
            lblUnit.Visible = False
            Select Case curCalculationType
                Case CalculationTypeSelection.FixedAmount
                    cboEarningType.Visible = True
                    cboBasePaymentIdNo.Visible = False
                    cboMultiplierType.Visible = False
                    cboUnit.Visible = False
                    lblBasePayment.Visible = False
                    lblDefaultQuantity.Visible = False
                    lblMultiplier.Visible = False
                    lblSlash.Visible = False
                    lblSlash.Visible = False
                    txtDefaultQuantity.Visible = False
                    txtMultiplier.Visible = False
                    'tlpCalculation.SetCellPosition(cboUnit, cellPosOrigUnit)
                    'tlpCalculation.SetColumnSpan(cboUnit, 1)
                Case CalculationTypeSelection.FixedRate
                    If IsOvertimeEarning(cboEarningType.SelectedValue) Then
                        lblRate.Visible = True
                        txtRate.Visible = True
                        cboUnit.Visible = False
                        lblSlash.Visible = False
                        lblSlash.Visible = False
                        lblRate.Text = Messaging.TranslateCaption("Default Amount")
                    Else
                        cboUnit.Visible = True
                        lblSlash.Visible = True
                        lblSlash.Visible = True
                        lblRate.Text = Messaging.TranslateCaption("Amount / Unit")
                        lblSlash.Text = Messaging.TranslateCaption("/")
                    End If
                    cboEarningType.Visible = True
                    lblDefaultQuantity.Visible = True
                    lblRate.Visible = True
                    txtDefaultQuantity.Visible = True
                    txtRate.Visible = True
                    cboBasePaymentIdNo.Visible = False
                    cboMultiplierType.Visible = False
                    lblBasePayment.Visible = False
                    lblMultiplier.Visible = False
                    txtMultiplier.Visible = False
                    'tlpCalculation.SetCellPosition(cboUnit, cellPosOrigUnit)
                    'tlpCalculation.SetColumnSpan(cboUnit, 1)
                Case CalculationTypeSelection.Factor
                    cboEarningType.Visible = True
                    cboBasePaymentIdNo.Visible = True
                    cboMultiplierType.Visible = True
                    cboUnit.Visible = False
                    lblBasePayment.Visible = True
                    lblDefaultQuantity.Visible = False
                    lblMultiplier.Visible = True
                    lblSlash.Visible = False
                    lblRate.Visible = False
                    lblUnit.Visible = False
                    lblSlash.Visible = False
                    'tlpCalculation.SetCellPosition(cboUnit, cellPosUnit)
                    'tlpCalculation.SetColumnSpan(cboUnit, 3)
                    cboUnit.Visible = False
                    txtDefaultQuantity.Visible = False
                    txtMultiplier.Visible = True
                    txtRate.Visible = False
                Case CalculationTypeSelection.Variable
                    cboEarningType.Visible = True
                    cboBasePaymentIdNo.Visible = False
                    cboMultiplierType.Visible = False
                    cboUnit.Visible = True
                    lblBasePayment.Visible = False
                    lblDefaultQuantity.Visible = True
                    lblMultiplier.Visible = False
                    lblSlash.Visible = True
                    lblRate.Visible = True
                    lblRate.Text = Messaging.TranslateCaption("Rate or Amount / Unit")
                    txtDefaultQuantity.Visible = True
                    txtMultiplier.Visible = False
                    txtRate.Visible = True
                    'tlpCalculation.SetCellPosition(cboUnit, cellPosOrigUnit)
                    'tlpCalculation.SetColumnSpan(cboUnit, 1)
                Case CalculationTypeSelection.Global
                    cboEarningType.Visible = True
                    cboBasePaymentIdNo.Visible = False
                    cboMultiplierType.Visible = False
                    cboUnit.Visible = True
                    lblBasePayment.Visible = False
                    lblDefaultQuantity.Visible = True
                    lblMultiplier.Visible = False
                    lblSlash.Visible = True
                    lblRate.Visible = True
                    lblRate.Text = Messaging.TranslateCaption("Rate or Amount / Unit")
                    txtDefaultQuantity.Visible = True
                    txtMultiplier.Visible = False
                    txtRate.Visible = True
                    'tlpCalculation.SetCellPosition(cboUnit, cellPosOrigUnit)
                    'tlpCalculation.SetColumnSpan(cboUnit, 1)
            End Select
            If chkSummary.Checked Then
                tlpCalculation.Visible = False
                floCalculation.Visible = False
            Else
                tlpCalculation.Visible = True
                floCalculation.Visible = True
            End If
            If IsOvertimeEarning(cboEarningType.SelectedValue) Then
                cboEarningType.DisplayOnly = True
                cboCalculationType.DisplayOnly = True
            Else
                If PresenterObj.EditMode Or PresenterObj.AddMode Then
                    cboEarningType.DisplayOnly = False
                    cboCalculationType.DisplayOnly = False
                Else
                    cboEarningType.DisplayOnly = True
                    cboCalculationType.DisplayOnly = True
                End If
            End If
            ResumeLayout()
        End Sub

        'Private Sub UpdateDisplay()
        '    If cboEarningType.SelectedValue = EnumToCode(EarningTypeSelection.OvertimeRegular) Or
        '       cboEarningType.SelectedValue = EnumToCode(EarningTypeSelection.OvertimeHoliday) Or
        '       cboEarningType.SelectedValue = EnumToCode(EarningTypeSelection.OvertimeSpecial) Then
        '        cboEarningType.DisplayOnly = True
        '        cboCalculationType.DisplayOnly = True
        '    Else
        '        If PresenterObj.EditMode Or PresenterObj.AddMode Then
        '            cboEarningType.DisplayOnly = False
        '            cboCalculationType.DisplayOnly = False
        '        Else
        '            cboEarningType.DisplayOnly = True
        '            cboCalculationType.DisplayOnly = True
        '        End If
        '    End If
        'End Sub

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
            '_unitPosition = tlpCalculation.GetCellPosition(cboUnit)
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
            If Not chkSummary.Checked Then
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
            End If
        End Sub

        Private Sub tbpCalculation_Enter(sender As Object, e As EventArgs) Handles tbpCalculation.Enter
            UpdateCalculationTabDisplay()
        End Sub

        Private Sub tbpAccountPosting_Enter(sender As Object, e As EventArgs) Handles tbpAccountPosting.Enter
            UpdatePostingTabDisplay()
        End Sub

        Private Sub chkSummary_CheckedChanged(sender As Object, e As EventArgs) Handles chkSummary.CheckedChanged
            If chkSummary.Checked Then
                cboEarningType.Visible = False
                tlpPostingAccounts.Visible = False
                tlpCalculation.Visible = False
                floCalculation.Visible = False
                DataGridViewSummaryDetail.Visible = True
                EarningType = EnumToCode(EarningTypeSelection.OnDemand)
                CalculationType = EnumToCode(CalculationTypeSelection.Factor)
            Else
                cboEarningType.Visible = True
                tlpPostingAccounts.Visible = True
                tlpCalculation.Visible = True
                floCalculation.Visible = True
                DataGridViewSummaryDetail.Visible = False
            End If
        End Sub

        Protected Overrides Sub InputsTurnedON()
            tbpSummaryDetail.ImageIndex = -1
            UpdateCalculationTabDisplay()
        End Sub

        'Private Sub DgvJi_OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewSummaryDetail.CellEndEdit
        '    With DataGridViewSummaryDetail
        '        Dim nIndex = .CurrentRow.Index
        '        Select Case .CurrentCell.OwningColumn.Name
        '            Case "dgvEarningIdNo"
        '                Dim earningId = DirectCast(DataGridViewSummaryDetail.CurrentCell, CaDgvComboboxCell).CellEditingControl.GetValue()
        '                If DataGridViewSummaryDetail.CurrentRow.Index = DataGridViewSummaryDetail.NewRowIndex Then
        '                    bsEarningSummary.AddNew()
        '                    EarningsSummary(nIndex).EarningIdNo = earningId
        '                    ' adding a new row to the bindingSource adds a new empty row at the end with null values
        '                    ' therefore there is a need to remove that row because it causes errors when moving to that empty row
        '                    bsEarningSummary.RemoveAt(bsEarningSummary.Count - 1)
        '                End If
        '        End Select
        '    End With
        'End Sub

        Public Overrides Function ValidateView()
            Dim valid As Boolean
            valid = ValidateDataBoundGrid(Of EarningSummaryView, EarningSummaryModel)(EarningsSummary, DataGridViewSummaryDetail, _eSumFieldsDict, tbpSummaryDetail) And
                    ValidateDataBoundGrid(Of PayrollEarnAccountView, PayrollEarnAccountModel)(PayrollEarnAccounts, DataGridViewPayrollEarnAccounts, _eAccFieldsDict, tbpAccountPosting)
            Return valid
        End Function

        Private Sub cboEarningType_ValueChanged(sender As Object, e As EventArgs) Handles cboEarningType.Validated, cboEarningType.SelectionChangeCommitted
            'If CodeToEnum(Of EarningTypeSelection)(cboEarningType.SelectedValue) = EarningTypeSelection.OvertimeRegular Or
            '    CodeToEnum(Of EarningTypeSelection)(cboEarningType.SelectedValue) = EarningTypeSelection.OvertimeHoliday Or
            '    CodeToEnum(Of EarningTypeSelection)(cboEarningType.SelectedValue) = EarningTypeSelection.OvertimeSpecial Then
            '    cboCalculationType.DisplayOnly = True
            '    cboEarningType.DisplayOnly = True
            '    cboUnit.DisplayOnly = True
            '    txtEarningName.DisplayOnly = True
            'Else
            '    cboCalculationType.DisplayOnly = False
            '    cboEarningType.DisplayOnly = False
            '    cboUnit.DisplayOnly = False
            '    txtEarningName.DisplayOnly = False
            'End If
            'UpdateCalculationTabDisplay()
            If IsOvertimeEarning(cboEarningType.SelectedValue) Then
                lblRate.Visible = True
                txtRate.Visible = True
                cboUnit.Visible = False
                lblSlash.Visible = False
                lblSlash.Visible = False
                lblRate.Text = Messaging.TranslateCaption("Default Amount")
            Else
                cboUnit.Visible = True
                lblSlash.Visible = True
                lblSlash.Visible = True
                lblRate.Text = Messaging.TranslateCaption("Amount / Unit")
                lblSlash.Text = Messaging.TranslateCaption("/")
            End If
        End Sub

        Private Function IsOvertimeEarning(earnType As Char)
            If earnType = EnumToCode(EarningTypeSelection.OvertimeRegular) Or
               earnType = EnumToCode(EarningTypeSelection.OvertimeHoliday) Or
               earnType = EnumToCode(EarningTypeSelection.OvertimeSpecial) Then
                Return True
            End If
            Return False
        End Function

        Protected Overrides Sub RecordPositionChanged(ByRef e As RecordPositionChanged)
            MyBase.RecordPositionChanged(e)
            UpdateCalculationTabDisplay()
            UpdatePostingTabDisplay()
        End Sub

        'Public Overrides Function ValidateView()
        '    Dim errorFound As Boolean = False
        '    Dim rules = PresenterObj.GetBizRules(EarningsSummary)
        '    Dim bo = PresenterObj.GetBizObject(EarningsSummary)
        '    For Each rule In rules
        '        For Each col In DataGridViewSummaryDetail.Columns()
        '            Dim colName = col.DataPropertyName
        '            If rule.Property = colName Then
        '                For Each row As DataGridViewRow In DataGridViewSummaryDetail.Rows
        '                    Dim model As New EarningSummaryModel
        '                    If row.Index() < DataGridViewSummaryDetail.RowCount() - 1 Then
        '                        GlobalVariables.Mapper.Map(Of EarningSummaryView, EarningSummaryModel)(EarningsSummary(row.Index()), model)
        '                        GlobalVariables.Mapper.Map(Of EarningSummaryModel, EarningSummary)(model, bo)
        '                        If Not bo.IsRuleValid(rule) Then
        '                            Dim obj As New Object
        '                            _eSumFieldsDict.TryGetValue(rule.Property, obj)
        '                            row.Cells(obj.Name).ErrorText = rule.Error
        '                            errorFound = True
        '                        End If
        '                    End If
        '                Next
        '            End If
        '        Next
        '    Next
        '    If errorFound Then
        '        tbpSummaryDetail.ImageIndex = 0
        '    Else
        '        tbpSummaryDetail.ImageIndex = -1
        '    End If
        '    Return Not errorFound
        'End Function

        'Protected Overrides Sub OnLoad(ByVal e As EventArgs)
        '    MyBase.OnLoad(e)
        '    Me.AutoValidate = AutoValidate.EnableAllowFocusChange
        '    ImageList1.ColorDepth = ColorDepth.Depth32Bit
        '    ImageList1.Images.Add(errorProvider1.Icon)
        '    tabControl1.ImageList = ImageList1
        '    textBox1.Validating += AddressOf textBox_Validating
        '    textBox2.Validating += AddressOf textBox_Validating
        'End Sub

        'Private Sub textBox_Validating(ByVal sender As Object, ByVal e As CancelEventArgs)
        '    Dim textBox = CType(sender, TextBox)

        '    If String.IsNullOrEmpty(textBox.Text) Then
        '        Me.errorProvider1.SetError(textBox, "Value is required.")
        '        e.Cancel = True
        '    Else
        '        Me.errorProvider1.SetError(textBox, Nothing)
        '    End If

        '    Dim tabPage = TryCast(textBox.Parent, TabPage)
        '    If tabPage IsNot Nothing Then ValidateTabPage(tabPage)
        'End Sub

        'Private Sub ValidateTabPage(ByVal tabPage As TabPage)
        '    Dim tabIsValid = tabPage.Controls.Cast(Of Control)().All(Function(x) String.IsNullOrEmpty(errorProvider1.GetError(x)))

        '    If tabIsValid Then
        '        tabPage.ImageIndex = -1
        '    Else
        '        tabPage.ImageIndex = 0
        '    End If
        'End Sub

    End Class

End Namespace