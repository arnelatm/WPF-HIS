Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Views.Forms

    Public Class PayElementEntryTv
        Implements IPayElementView

        Private _accountsByCode
        Private _payGroupsByCode
        Private _payElementsByCode
        Private _earnReportGroupsByCode
        Private _dedReportGroupsByCode
        Private _factorTypeByCode
        Private _calculationTypeByCode
        Private _payElementAccounts As List(Of PayElementAccountView)
        Private _payElementItems As List(Of PayElementItemView)
        Private _useRevCostCenters As Nullable(Of Boolean)
        Private _useDepartments As Nullable(Of Boolean)
        Private _usePayGroups As Nullable(Of Boolean)

        'Private _unitPosition As TableLayoutPanelCellPosition
        Private _eSumFieldsDict As Dictionary(Of String, Object)

        Private _eAccFieldsDict As Dictionary(Of String, Object)
        Private ReadOnly _nfi As NumberFormatInfo = GlobalVariables.DefaultNumberFormatInfo
        Private _esModel = New ModelAccounts("PayElementItem")
        Private cellPosOrigUnitAtt As TableLayoutPanelCellPosition = New TableLayoutPanelCellPosition(3, 8)
        Private cellPosOrigUnit As TableLayoutPanelCellPosition = New TableLayoutPanelCellPosition(3, 2)
        Private cellPosQtyUnit As TableLayoutPanelCellPosition = New TableLayoutPanelCellPosition(3, 6)
        Private cellPosUnitSave As TableLayoutPanelCellPosition = New TableLayoutPanelCellPosition(0, 8)
        Private MyPresenter As PayElementPresenter

        Public Sub New()

            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            DoubleBuffered = True
            MainTableName = "PayElement"
            TvMainFieldName = "PayElementName"
            TvSecondaryFieldName = "PayElementCode"
            SortOrderKey = "PayElementName"
            FirstControl = txtPayElementCode
            MyPresenter = New PayElementPresenter(Me)
            PresenterObj = MyPresenter
            Ea = MyPresenter.Ea
            Ea.SubscribeEvent(Me)

            'cboCalculationType.DrawMode = DrawMode.OwnerDrawFixed
            'AddHandler cboCalculationType.DrawItem, New System.Windows.Forms.DrawItemEventHandler(AddressOf cboCalculationType_DrawItem)
            'AddHandler cboCalculationType.SelectedIndexChanged, New System.EventHandler(AddressOf cboCalculationType_ValueChanged)
            'cboQuantityType.DrawMode = DrawMode.OwnerDrawFixed
            'AddHandler cboQuantityType.DrawItem, New System.Windows.Forms.DrawItemEventHandler(AddressOf cboQuantityType_DrawItem)
            'AddHandler cboQuantityType.SelectedIndexChanged, New System.EventHandler(AddressOf cboQuantityType_ValueChanged)

        End Sub

#Region "Fields"

        Public Property IdNo As Int16 Implements IPayElementView.IdNo
            Get
                Return NumParser(Of Int16)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property IncludeInEos As Boolean Implements IPayElementView.IncludeInEos
            Get
                Return chkIncludeInEOS.Checked
            End Get
            Set
                chkIncludeInEOS.Checked = Value
            End Set
        End Property

        Public Property FactorValue As Decimal Implements IPayElementView.FactorValue
            Get
                Return txtMultiplier.Text  ' Convert.ToDecimal(NumParser(Of Decimal)(txtMultiplier.Text), _nfi)
            End Get
            Set
                txtMultiplier.Text = Value  'Value.ToString("F4")
            End Set
        End Property

        Public Property FactorType As String Implements IPayElementView.FactorType
            Get
                Return cboFactorType.GetValue()
            End Get
            Set
                cboFactorType.SetValue(Value)
            End Set
        End Property

        Public Property AccountIdNo As Int16 Implements IPayElementView.AccountIdNo
            Get
                Return cboAccountIdNo.GetValue()
            End Get
            Set
                cboAccountIdNo.SetValue(Value)
            End Set
        End Property

        Public Property Active As Boolean Implements IPayElementView.Active
            Get
                Return chkActive.Checked
            End Get
            Set
                chkActive.Checked = Value
            End Set
        End Property

        Public Property BasePaymentIdNo As Int16? Implements IPayElementView.BasePaymentIdNo
            Get
                Return cboBasePaymentIdNo.GetValue()
            End Get
            Set
                cboBasePaymentIdNo.SetValue(Value)
            End Set
        End Property

        Public Property CalculationType As Char Implements IPayElementView.CalculationType
            Get
                Return cboCalculationType.GetValue()
            End Get
            Set
                cboCalculationType.SetValue(Value)
                If Value = EnumToCode(CalculationTypeSelection.Variable) Then
                    QuantityType = EnumToCode(QuantityTypeSelection.Variable)
                End If
            End Set
        End Property

        Public Property PayElementCode As String Implements IPayElementView.PayElementCode
            Get
                Return txtPayElementCode.Text
            End Get
            Set
                txtPayElementCode.Text = Value
            End Set
        End Property

        Public Property ReportGroupIdNo As Int16 Implements IPayElementView.ReportGroupIdNo
            Get
                Return cboReportGroupIdNo.GetValue()
            End Get
            Set
                cboReportGroupIdNo.SetValue(Value)
            End Set
        End Property

        Public Property PayElementKind As Char Implements IPayElementView.PayElementKind
            Get
                Return cboPayElementKind.GetValue()
            End Get
            Set
                cboPayElementKind.SetValue(Value)
            End Set
        End Property

        Public Property Summary As Boolean Implements IPayElementView.Summary
            Get
                Return chkSummary.Checked
            End Get
            Set
                chkSummary.Checked = Value
                If Value Then
                    PayElementType = EnumToCode(PayElementTypeSelection.Computed)
                    CalculationType = EnumToCode(CalculationTypeSelection.Factor)
                    'cboPayElementType.SelectedValue =
                    'cboCalculationType.SelectedValue =
                End If
            End Set
        End Property

        Public Property PayElementName As String Implements IPayElementView.PayElementName
            Get
                Return txtPayElementName.Text
            End Get
            Set
                txtPayElementName.Text = Value
            End Set
        End Property

        Public Property PayElementNameAra As String Implements IPayElementView.PayElementNameAra
            Get
                Return txtPayElementNameAra.Text
            End Get
            Set
                txtPayElementNameAra.Text = Value
            End Set
        End Property

        Public Property PayElementType As Char Implements IPayElementView.PayElementType
            Get
                Return cboPayElementType.GetValue()
            End Get
            Set
                cboPayElementType.SetValue(Value)
                'If IsOvertimePayElement(Value) Then
                '    If Value = EnumToCode(PayElementTypeSelection.OvertimeRegular) Then
                '        Unit = EnumToCode(PayRateUnitSelection.OvertimeHoursRegular)
                '    ElseIf Value = EnumToCode(PayElementTypeSelection.OvertimeHoliday) Then
                '        Unit = EnumToCode(PayRateUnitSelection.OvertimeHoursRegular)
                '    ElseIf Value = EnumToCode(PayElementTypeSelection.OvertimeSpecial) Then
                '        Unit = EnumToCode(PayRateUnitSelection.OvertimeHoursSpecial)
                '    End If
                'End If
            End Set
        End Property

        Public Property Unit As Char Implements IPayElementView.Unit
            Get
                Return cboUnit.GetValue()
            End Get
            Set
                cboUnit.SetValue(Value)
            End Set
        End Property

        Public Property QuantityType As Char Implements IPayElementView.QuantityType
            Get
                Return cboQuantityType.GetValue()
            End Get
            Set
                cboQuantityType.SetValue(Value)
            End Set
        End Property

        Public Property UsePayGroups As Boolean Implements IPayElementView.UsePayGroups
            Get
                Return chkUsePayGroups.Checked
            End Get
            Set
                chkUsePayGroups.Checked = Value
            End Set
        End Property

        Public Property Notes As String Implements IPayElementView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = Value
            End Set
        End Property

        Public Property Rate As Decimal Implements IPayElementView.Rate
            Get
                Return txtRate.Text.ToDecimalNumber(_nfi)
            End Get
            Set
                txtRate.Text = FormatDecimalNumber(Value)
            End Set
        End Property

        'Public ReadOnly Property PayElementIdNoDataGridViewTextBoxColumnProperty As DataGridViewTextBoxColumn
        '    Get
        '        Return PayElementIdNoDataGridViewTextBoxColumn
        '    End Get
        'End Property

        Public Property Taxable As Boolean Implements IPayElementView.Taxable
            Get
                Return chkTaxable.Checked
            End Get
            Set
                chkTaxable.Checked = Value
            End Set
        End Property

        Public Property DefaultQuantity As Decimal Implements IPayElementView.DefaultQuantity
            Get
                Return txtDefaultQuantity.Text.ToDecimalNumber(_nfi)
            End Get
            Set
                txtDefaultQuantity.Text = FormatDecimalNumber(Value)
            End Set
        End Property

        Public Property PayElementItems As List(Of PayElementItemView) Implements IPayElementView.PayElementItems
            Get
                Return _payElementItems
            End Get
            Set
                _payElementItems = Value
                BindPayElementItems()
            End Set
        End Property

        Public Property PayElementAccounts As List(Of PayElementAccountView) Implements IPayElementView.PayElementAccounts
            Get
                Return _payElementAccounts
            End Get
            Set
                _payElementAccounts = Value
                BindPayElementAccounts()
            End Set
        End Property

#End Region

        Private myFont As Font = New Font("Aerial", 10, FontStyle.Underline Or FontStyle.Regular)
        Private myFont2 As Font = New Font("Aerial", 10, FontStyle.Italic Or FontStyle.Strikeout)

        'Private Sub cboCalculationType_DrawItem(ByVal sender As Object, ByVal e As DrawItemEventArgs)
        '    Dim comboBox As ComboBox = CType(sender, ComboBox)
        '    If IsCalcTypeItemDisabled(e.Index) Then
        '        e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds)
        '        e.Graphics.DrawString(comboBox.Items(e.Index).ToString(), comboBox.Font, SystemBrushes.GrayText, e.Bounds)
        '    Else
        '        e.DrawBackground()
        '        'Dim brush As Brush = If((e.State And DrawItemState.Selected) > 0, SystemBrushes.HighlightText, SystemBrushes.ControlText)
        '        e.Graphics.DrawString(comboBox.Items(e.Index).ToString(), comboBox.Font, Brushes.White, e.Bounds)
        '        e.DrawFocusRectangle()
        '    End If
        'End Sub

        Private Sub cboCalculationType_ValueChanged(sender As Object, e As EventArgs) Handles cboCalculationType.SelectionChangeCommitted, cboCalculationType.Validated
            If cboCalculationType.Focused Then
                If IsCalcTypeItemDisabled(cboCalculationType.SelectedIndex) Then
                    Messaging.ShowParametrizedMessage(True, "MsgSelectedValueNotAllowed", {cboPayElementType.LinkedLabel.Text, "field1", cboCalculationType.LinkedLabel.Text, "field2"})
                    cboCalculationType.SelectedValue = -1
                ElseIf cboCalculationType.SelectedValue = EnumToCode(CalculationTypeSelection.FixedAmount) Then
                    QuantityType = EnumToCode(QuantityTypeSelection.NotNeeded)
                End If
                UpdateCalculationTabDisplay()
            End If
        End Sub

        Private Function IsCalcTypeItemDisabled(ByVal index As Integer) As Boolean
            If cboPayElementType.SelectedValue = EnumToCode(PayElementTypeSelection.Regular) Then
                If index = CalculationTypeSelection.Variable Or index = CalculationTypeSelection.Table Then
                    Return True
                End If
            ElseIf cboPayElementType.SelectedValue = EnumToCode(PayElementTypeSelection.Computed) Then
                If index = CalculationTypeSelection.FixedAmount Or index = CalculationTypeSelection.Variable Or index = CalculationTypeSelection.Table Then
                    Return True
                End If
            ElseIf cboPayElementType.SelectedValue = EnumToCode(PayElementTypeSelection.Global) Then
                If index = CalculationTypeSelection.Factor Or index = CalculationTypeSelection.FixedRate Or index = CalculationTypeSelection.Variable Or index = CalculationTypeSelection.Table Then
                    Return True
                End If
            ElseIf cboPayElementType.SelectedValue = EnumToCode(PayElementTypeSelection.OnDemand) Then
                If index = CalculationTypeSelection.Table Then
                    Return True
                End If
            End If
            Return False
        End Function

        'Private Sub cboQuantityType_DrawItem(ByVal sender As Object, ByVal e As DrawItemEventArgs)
        '    Dim comboBox As ComboBox = CType(sender, ComboBox)
        '    If IsQtyTypeItemDisabled(e.Index) Then
        '        e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds)
        '        e.Graphics.DrawString(comboBox.Items(e.Index).ToString(), comboBox.Font, SystemBrushes.GrayText, e.Bounds)
        '    Else
        '        e.DrawBackground()
        '        'Dim brush As Brush = If((e.State And DrawItemState.Selected) > 0, SystemBrushes.HighlightText, SystemBrushes.ControlText)
        '        e.Graphics.DrawString(comboBox.Items(e.Index).ToString(), comboBox.Font, Brushes.White, e.Bounds)
        '        e.DrawFocusRectangle()
        '    End If
        'End Sub

        Private Sub cboQuantityType_ValueChanged(sender As Object, e As EventArgs) Handles cboQuantityType.SelectionChangeCommitted, cboQuantityType.Validated
            If cboCalculationType.Focused Then
                If IsQtyTypeItemDisabled(cboCalculationType.SelectedIndex) Then
                    Messaging.ShowParametrizedMessage(True, "MsgSelectedValueNotAllowed", {cboCalculationType.LinkedLabel.Text, "field1", cboQuantityType.LinkedLabel.Text, "field2"})
                    cboCalculationType.SelectedValue = -1
                End If
                DoubleBuffered = True
                SuspendLayout()
                floCalculation.Visible = False
                lblDefaultQuantity.Visible = True
                txtDefaultQuantity.Visible = True
                lblSlash2.Visible = False
                cboUnit.Visible = True
                tlpCalculation.SetCellPosition(cboUnit, cellPosQtyUnit)
                floCalculation.Visible = True
                ResumeLayout()
            End If
        End Sub

        Private Function IsQtyTypeItemDisabled(ByVal index As Integer) As Boolean
            If PayElementType = EnumToCode(CalculationTypeSelection.FixedRate) Then
                If index = QuantityTypeSelection.NotNeeded Or index = QuantityTypeSelection.Variable Then
                    Return True
                End If
            End If
            Return False
        End Function

        Protected Overrides Sub CreateDataSources()
            'cboFrequency.DataSource = PresenterObj.MakeEnumComboList(Of PayFrequencySelection)
            cboPayElementKind.DataSource = PresenterObj.MakeEnumComboList(Of PayElementKindSelection)
            cboPayElementType.DataSource = PresenterObj.MakeEnumComboList(Of PayElementTypeSelection)
            cboAccountIdNo.DataSource = PresenterObj.GetDetailAccountList
            cboCalculationType.DataSource = PresenterObj.MakeEnumComboList(Of CalculationTypeSelection)
            cboFactorType.DataSource = PresenterObj.MakeEnumComboList(Of FactorTypeSelection)
            cboBasePaymentIdNo.DataSource = PresenterObj.GetLookup("PayElement")
            cboUnit.DataSource = PresenterObj.MakeEnumComboList(Of PayRateUnitSelection)
            cboQuantityType.DataSource = PresenterObj.MakeEnumComboList(Of QuantityTypeSelection)
            _accountsByCode = PresenterObj.GetDetailAccountList()
            _payGroupsByCode = PresenterObj.GetLookup("PayGroup")
            _earnReportGroupsByCode = PresenterObj.GetLookup("PayElementGroup", "PayElementKind = '" & EnumToCode(PayElementKindSelection.Earning) & "'")
            _dedReportGroupsByCode = PresenterObj.GetLookup("PayElementGroup", "PayElementKind = '" & EnumToCode(PayElementKindSelection.Deduction) & "'")
            _payElementsByCode = PresenterObj.GetLookup("PayElement")
            _factorTypeByCode = PresenterObj.MakeEnumComboList(Of FactorTypeSelection)
            _calculationTypeByCode = PresenterObj.MakeEnumComboList(Of CalculationTypeSelection)
            UpdateReportGroup()
        End Sub

        Private Sub UpdateReportGroup()
            cboReportGroupIdNo.DataSource = Nothing
            If cboPayElementKind.SelectedValue = EnumToCode(PayElementKindSelection.Deduction) Then
                cboReportGroupIdNo.DataSource = _dedReportGroupsByCode
            Else
                cboReportGroupIdNo.DataSource = _earnReportGroupsByCode
            End If
        End Sub

        Private Sub BindPayElementAccounts()
            SuspendLayout()
            bsPayElementAccounts.DataSource = Nothing
            DataGridViewPayElementAccounts.Refresh()
            bsPayElementAccounts.DataSource = PayElementAccounts
            'bsPayElementAccounts.AllowNew = True
            With DataGridViewPayElementAccounts
                .Refresh()
                .AutoGenerateColumns = False
                .DataSource = Nothing
                .DataSource = bsPayElementAccounts
                .Refresh()
            End With
            With DataGridViewPayElementAccounts.Columns
                dgvPayGroupIdNo.DataSource = _payGroupsByCode
                dgvPayGroupIdNo.DisplayMember = "Name"
                dgvPayGroupIdNo.ValueMember = "IdNo"
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
                {"PayElementCode", txtPayElementCode},
                {"PayElementName", txtPayElementName},
                {"PayElementNameAra", txtPayElementNameAra},
                {"IdNo", TxtIdNo},
                {"IncludeInEos", chkIncludeInEOS},
                {"FactorValue", txtMultiplier},
                {"FactorType", cboFactorType},
                {"Notes", txtNotes},
                {"Rate", txtRate},
                {"Summary", chkSummary},
                {"Taxable", chkTaxable},
                {"Unit", cboUnit},
                {"QuantityType", cboQuantityType},
                {"UsePayGroups", chkUsePayGroups},
                {"PayElementItems", DataGridViewPayElementItems},
                {"PayElementAccounts", DataGridViewPayElementAccounts}
                }

            _eSumFieldsDict = New Dictionary(Of String, Object) From
                {
                {"PayElementIdNo", dgvPayElementIdNo},
                {"FactorValue", dgvFactorValue},
                {"FactorType", dgvFactorType}
                }

            _eAccFieldsDict = New Dictionary(Of String, Object) From
                {
                {"PayGroupIdNo", dgvPayGroupIdNo},
                {"AccountIdNo", dgvAccountIdNo}
                }

            DataGridViewPayElementItems.FieldsDictionary = _eSumFieldsDict
            DataGridViewPayElementAccounts.FieldsDictionary = _eAccFieldsDict

        End Sub

        Private Sub BindPayElementItems()
            SuspendLayout()
            bsPayElementItems.DataSource = Nothing
            DataGridViewPayElementItems.Refresh()
            bsPayElementItems.DataSource = PayElementItems
            bsPayElementItems.AllowNew = True
            With DataGridViewPayElementItems
                .Refresh()
                .AutoGenerateColumns = False
                .DataSource = bsPayElementItems
                .Refresh()
            End With
            With DataGridViewPayElementItems.Columns
                dgvPayElementIdNo.DataSource = _payElementsByCode
                dgvPayElementIdNo.DisplayMember = "Name"
                dgvPayElementIdNo.ValueMember = "IdNo"
                dgvPayElementIdNo.AutoComplete = AutoCompleteMode.SuggestAppend
                dgvPayElementIdNo.DisplayStyleForCurrentCellOnly = True
                dgvFactorType.DataSource = _factorTypeByCode
                dgvFactorType.ValueMember = "Code"
                dgvFactorType.DisplayMember = "Name"
                dgvFactorType.DisplayStyleForCurrentCellOnly = True
            End With
            ResumeLayout()
        End Sub

        'Private Sub cboCalculationType_ValueChanged(sender As Object, e As EventArgs) Handles cboCalculationType.Validated, cboCalculationType.SelectionChangeCommitted
        '    Me.DoubleBuffered = True
        '    SuspendLayout()
        '    floCalculation.Visible = False
        '    UpdateCalculationTabDisplay()
        '    floCalculation.Visible = True
        '    ResumeLayout()
        'End Sub

        'Private Sub cboQuantityType_ValueChanged(sender As Object, e As EventArgs) Handles cboQuantityType.Validated, cboQuantityType.SelectionChangeCommitted
        '    Me.DoubleBuffered = True
        '    SuspendLayout()
        '    floCalculation.Visible = False
        '    If cboQuantityType.SelectedValue = EnumToCode(QuantityTypeSelection.NotNeeded) Then
        '        lblDefaultQuantity.Visible = False
        '        txtDefaultQuantity.Visible = False
        '        lblSlash2.Visible = False
        '        cboUnit.Visible = False
        '        tlpCalculation.SetCellPosition(cboUnit, cellPosOrigUnit)
        '    Else
        '        lblDefaultQuantity.Visible = True
        '        txtDefaultQuantity.Visible = True
        '        lblSlash2.Visible = False
        '        cboUnit.Visible = True
        '        tlpCalculation.SetCellPosition(cboUnit, cellPosQtyUnit)
        '    End If
        '    floCalculation.Visible = True
        '    ResumeLayout()
        'End Sub

        Private Sub UpdateCalculationTabDisplay()
            SuspendLayout()
            floCalculation.Visible = False
            tlpCalculation.Visible = False
            Dim curCalculationType = CodeToEnum(Of CalculationTypeSelection)(cboCalculationType.SelectedValue)
            'tlpCalculation.SetCellPosition(cboUnit, _unitPosition)
            lblUnit.Visible = False
            Select Case curCalculationType
                Case CalculationTypeSelection.FixedAmount
                    lblSlash.Visible = True
                    lblRate.Text = Messaging.TranslateCaption("Default Amount / Unit")
                    lblSlash.Text = Messaging.TranslateCaption("/")
                    cboPayElementType.Visible = True
                    cboUnit.Visible = True
                    lblRate.Visible = True
                    txtRate.Visible = True
                    lblDefaultQuantity.Visible = False
                    txtDefaultQuantity.Visible = False
                    cboBasePaymentIdNo.Visible = False
                    cboQuantityType.Visible = False
                    lblQuantityType.Visible = False
                    cboFactorType.Visible = False
                    lblBasePayment.Visible = False
                    lblFactorValue.Visible = False
                    lblSlash2.Visible = False
                    txtMultiplier.Visible = False
                    tlpCalculation.SetCellPosition(cboUnit, cellPosOrigUnit)
                    'tlpCalculation.SetCellPosition(cboQuantityType, cellPosOrigUnitAtt)
                Case CalculationTypeSelection.FixedRate
                    'If IsOvertimePayElement(cboPayElementType.SelectedValue) Then
                    '    cboUnit.
                    'End If
                    lblSlash.Visible = True
                    lblRate.Text = Messaging.TranslateCaption("Default Rate / Unit")
                    lblSlash.Text = Messaging.TranslateCaption("/")
                    cboPayElementType.Visible = True
                    cboUnit.Visible = True
                    lblDefaultQuantity.Visible = True
                    lblRate.Visible = True
                    txtDefaultQuantity.Visible = True
                    txtRate.Visible = True
                    cboBasePaymentIdNo.Visible = False
                    cboQuantityType.Visible = True
                    lblQuantityType.Visible = True
                    cboFactorType.Visible = False
                    lblBasePayment.Visible = False
                    lblFactorValue.Visible = False
                    lblSlash2.Visible = False
                    txtMultiplier.Visible = False
                    tlpCalculation.SetCellPosition(cboUnit, cellPosOrigUnit)
                Case CalculationTypeSelection.Factor
                    cboPayElementType.Visible = True
                    cboBasePaymentIdNo.Visible = True
                    cboFactorType.Visible = True
                    cboQuantityType.Visible = True
                    cboUnit.Visible = True
                    lblBasePayment.Visible = True
                    lblFactorValue.Visible = True
                    lblQuantityType.Visible = True
                    lblSlash.Visible = False
                    lblRate.Visible = False
                    lblUnit.Visible = False
                    lblSlash.Visible = False
                    txtMultiplier.Visible = True
                    txtRate.Visible = False
                    If cboQuantityType.SelectedValue = EnumToCode(QuantityTypeSelection.NotNeeded) Then
                        lblDefaultQuantity.Visible = False
                        txtDefaultQuantity.Visible = False
                        lblSlash2.Visible = False
                        cboUnit.Visible = False
                        tlpCalculation.SetCellPosition(cboUnit, cellPosOrigUnit)
                    Else
                        lblDefaultQuantity.Visible = True
                        txtDefaultQuantity.Visible = True
                        lblSlash2.Visible = False
                        cboUnit.Visible = True
                        tlpCalculation.SetCellPosition(cboUnit, cellPosQtyUnit)
                    End If
                Case CalculationTypeSelection.Variable
                    cboPayElementType.Visible = True
                    cboBasePaymentIdNo.Visible = False
                    cboFactorType.Visible = False
                    cboUnit.Visible = True
                    lblSlash.Visible = True
                    lblRate.Visible = True
                    lblQuantityType.Visible = False
                    cboFactorType.Visible = False
                    cboQuantityType.Visible = False
                    lblBasePayment.Visible = False
                    lblDefaultQuantity.Visible = True
                    lblFactorValue.Visible = False
                    lblSlash2.Visible = False
                    lblRate.Text = Messaging.TranslateCaption("Default Rate/Unit")
                    txtDefaultQuantity.Visible = True
                    txtMultiplier.Visible = False
                    txtRate.Visible = True
                    tlpCalculation.SetCellPosition(cboUnit, cellPosOrigUnit)
            End Select
            If chkSummary.Checked Then
                tlpCalculation.Visible = False
                floCalculation.Visible = False
            Else
                tlpCalculation.Visible = True
                floCalculation.Visible = True
            End If
            ResumeLayout()
        End Sub

        'Private Sub UpdateDisplay()
        '    If cboPayElementType.SelectedValue = EnumToCode(PayElementTypeSelection.OvertimeRegular) Or
        '       cboPayElementType.SelectedValue = EnumToCode(PayElementTypeSelection.OvertimeHoliday) Or
        '       cboPayElementType.SelectedValue = EnumToCode(PayElementTypeSelection.OvertimeSpecial) Then
        '        cboPayElementType.DisplayOnly = True
        '        cboCalculationType.DisplayOnly = True
        '    Else
        '        If PresenterObj.EditMode Or PresenterObj.AddMode Then
        '            cboPayElementType.DisplayOnly = False
        '            cboCalculationType.DisplayOnly = False
        '        Else
        '            cboPayElementType.DisplayOnly = True
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

        'Private Sub tbcPayElement_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcPayElement.SelectedIndexChanged
        '    SuspendLayout()
        '    ' prevent flicker
        '    floPostingAccounts.Visible = False
        '    If _usePayGroups And chkUsePayGroups.Checked Then
        '        If tbcPayElement.SelectedTab Is tbpAccountPosting Then
        '            tbcPayElement.SelectedTab = tbpAccountPosting
        '            cboAccountIdNo.Select()
        '        End If
        '    Else
        '        If tbcPayElement.SelectedTab Is tbpAccountPosting Then
        '            tbcPayElement.SelectedTab = tbpMain
        '            cboAccountIdNo.Select()
        '        End If
        '    End If
        '    floPostingAccounts.Visible = True
        '    ResumeLayout()
        'End Sub

        Private Sub PayElementEntryTv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

            ImageListTreeView.Images.Add(Image.FromFile("Images\Deduction.png"))
            ImageListTreeView.Images.Add(Image.FromFile("Images\Earning.png"))
            TreeViewTableName.ImageList = ImageListTreeView

            'If _usePayGroups Then
            '    chkUsePayGroups.Visible = True
            '    lblUsePayGroups.Visible = True
            '    DataGridViewPayElementAccounts.Visible = True
            'Else
            '    chkUsePayGroups.Visible = False
            '    lblUsePayGroups.Visible = False
            '    DataGridViewPayElementAccounts.Visible = False
            'End If
        End Sub

        Private Sub ChkUsePayGroups_CheckedChanged(sender As Object, e As EventArgs) Handles chkUsePayGroups.CheckedChanged
            UpdatePostingTabDisplay()
        End Sub

        Private Sub UpdatePostingTabDisplay()
            If Not chkSummary.Checked Then
                If _usePayGroups IsNot Nothing And _usePayGroups Then
                    DataGridViewPayElementAccounts.Visible = True
                    chkUsePayGroups.Visible = True
                    lblUsePayGroups.Visible = True
                    If chkUsePayGroups.Checked Then
                        DataGridViewPayElementAccounts.Visible = True
                        lblAccountIdNo.Text = Messaging.TranslateCaption("Default Posting Account")
                    Else
                        DataGridViewPayElementAccounts.Visible = False
                        lblAccountIdNo.Text = Messaging.TranslateCaption("Posting Account")
                    End If
                Else
                    If _usePayGroups Is Nothing Then
                        _usePayGroups = False
                    End If
                    DataGridViewPayElementAccounts.Visible = False
                    chkUsePayGroups.Visible = False
                    lblUsePayGroups.Visible = False
                    lblAccountIdNo.Text = Messaging.TranslateCaption("Posting Account")
                    DataGridViewPayElementAccounts.Visible = False
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
                cboPayElementType.Visible = False
                tlpPostingAccounts.Visible = False
                tlpCalculation.Visible = False
                floCalculation.Visible = False
                DataGridViewPayElementItems.Visible = True
                PayElementType = EnumToCode(PayElementTypeSelection.OnDemand)
                CalculationType = EnumToCode(CalculationTypeSelection.Factor)
            Else
                cboPayElementType.Visible = True
                tlpPostingAccounts.Visible = True
                tlpCalculation.Visible = True
                floCalculation.Visible = True
                DataGridViewPayElementItems.Visible = False
            End If
        End Sub

        Protected Overrides Sub InputsTurnedON()
            tbpSummaryDetail.ImageIndex = -1
            UpdateCalculationTabDisplay()
        End Sub

        'Private Sub DgvJi_OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs)
        '    With DataGridViewPayElementItems
        '        Dim nIndex = .CurrentRow.Index
        '        Select Case .CurrentCell.OwningColumn.Name
        '            Case "dgvFactorType"
        '                Dim PayElementId = DirectCast(DataGridViewPayElementItems.CurrentCell, CDgvComboboxCell).CellEditingControl.GetValue()
        '                'If DataGridViewSummaryDetail.CurrentRow.Index = DataGridViewSummaryDetail.NewRowIndex Then
        '                '    bsPayElementItem.AddNew()
        '                '    PayElementItems(nIndex).PayElementIdNo = PayElementId
        '                '    ' adding a new row to the bindingSource adds a new empty row at the end with null values
        '                '    ' therefore there is a need to remove that row because it causes errors when moving to that empty row
        '                '    bsPayElementItem.RemoveAt(bsPayElementItem.Count - 1)
        '                'End If
        '        End Select
        '    End With
        'End Sub

        'Public Overrides Function ValidateView()
        '    Dim valid As Boolean
        '    valid = ValidateDataBoundGrid(Of PayElementItemView, PayElementItemModel)(PayElementItems, DataGridViewPayElementItems, _eSumFieldsDict, tbpSummaryDetail) And
        '            ValidateDataBoundGrid(Of PayElementAccountView, PayElementAccountModel)(PayElementAccounts, DataGridViewPayElementAccounts, _eAccFieldsDict, tbpAccountPosting)
        '    Return valid
        'End Function

        Public Overrides Function ValidateView()
            Dim valid As Boolean
            valid = MyPresenter.ValidateDataBoundGrid(Of PayElementItemModel)(PayElementItems, DataGridViewPayElementItems, _eSumFieldsDict, tbpSummaryDetail) And
                    MyPresenter.ValidateDataBoundGrid(Of PayElementAccountModel)(PayElementAccounts, DataGridViewPayElementAccounts, _eAccFieldsDict, tbpAccountPosting)
            Return valid
        End Function

        'Private Sub cboPayElementType_ValueChanged(sender As Object, e As EventArgs) Handles cboPayElementType.Validated, cboPayElementType.SelectionChangeCommitted
        '    'If CodeToEnum(Of PayElementTypeSelection)(cboPayElementType.SelectedValue) = PayElementTypeSelection.OvertimeRegular Or
        '    '    CodeToEnum(Of PayElementTypeSelection)(cboPayElementType.SelectedValue) = PayElementTypeSelection.OvertimeHoliday Or
        '    '    CodeToEnum(Of PayElementTypeSelection)(cboPayElementType.SelectedValue) = PayElementTypeSelection.OvertimeSpecial Then
        '    '    cboCalculationType.DisplayOnly = True
        '    '    cboPayElementType.DisplayOnly = True
        '    '    cboUnit.DisplayOnly = True
        '    '    txtPayElementName.DisplayOnly = True
        '    'Else
        '    '    cboCalculationType.DisplayOnly = False
        '    '    cboPayElementType.DisplayOnly = False
        '    '    cboUnit.DisplayOnly = False
        '    '    txtPayElementName.DisplayOnly = False
        '    'End If
        '    'UpdateCalculationTabDisplay()
        '    'If IsOvertimePayElement(cboPayElementType.SelectedValue) Then
        '    '    If cboPayElementType.SelectedValue = EnumToCode(PayElementTypeSelection.OvertimeRegular) Then
        '    '        cboUnit.SelectedValue = EnumToCode(PayRateUnitSelection.OvertimeHoursRegular)
        '    '    ElseIf cboPayElementType.SelectedValue = EnumToCode(PayElementTypeSelection.OvertimeHoliday) Then
        '    '        cboUnit.SelectedValue = EnumToCode(PayRateUnitSelection.OvertimeHoursRegular)
        '    '    ElseIf cboPayElementType.SelectedValue = EnumToCode(PayElementTypeSelection.OvertimeSpecial) Then
        '    '        cboUnit.SelectedValue = EnumToCode(PayRateUnitSelection.OvertimeHoursSpecial)
        '    '    End If
        '    '    '    lblRate.Visible = True
        '    '    '    txtRate.Visible = True
        '    '    '    cboUnit.Visible = False
        '    '    '    lblSlash.Visible = False
        '    '    '    lblSlash.Visible = False
        '    '    '    lblRate.Text = Messaging.TranslateCaption("Default Amount")
        '    '    'Else
        '    '    '    cboUnit.Visible = True
        '    '    '    lblSlash.Visible = True
        '    '    '    lblSlash.Visible = True
        '    '    '    lblRate.Text = Messaging.TranslateCaption("Amount / Unit")
        '    '    '    lblSlash.Text = Messaging.TranslateCaption("/")
        '    'End If
        'End Sub

        Private Function IsOvertimePayElement(earnType As Char)
            'If earnType = EnumToCode(PayElementTypeSelection.OvertimeRegular) Or
            '   earnType = EnumToCode(PayElementTypeSelection.OvertimeHoliday) Or
            '   earnType = EnumToCode(PayElementTypeSelection.OvertimeSpecial) Then
            '    Return True
            'End If
            'If earnType = EnumToCode(PayElementTypeSelection.OvertimeRegular) Or
            '   earnType = EnumToCode(PayElementTypeSelection.OvertimeHoliday) Or
            '   earnType = EnumToCode(PayElementTypeSelection.OvertimeSpecial) Then
            '    Return True
            'End If
            Return False
        End Function

        Protected Overrides Sub RecordPositionChanged(ByRef e As RecordPositionChanged)
            MyBase.RecordPositionChanged(e)
            UpdateCalculationTabDisplay()
            UpdatePostingTabDisplay()
        End Sub

        Protected Sub PayElement_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeViewTableName.AfterSelect
            Dim n As TreeNode = TreeViewTableName.SelectedNode
            If PayElementKind = EnumToCode(PayElementKindSelection.Deduction) Then
                n.SelectedImageIndex = 2
            Else
                n.SelectedImageIndex = 3
            End If
        End Sub

        Private Sub cboPayElementKind_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPayElementKind.SelectedIndexChanged
            UpdateReportGroup()
        End Sub

        'Public Overrides Function ValidateView()
        '    Dim errorFound As Boolean = False
        '    Dim rules = PresenterObj.GetBizRules(PayElementItems)
        '    Dim bo = PresenterObj.GetBizObject(PayElementItems)
        '    For Each rule In rules
        '        For Each col In DataGridViewSummaryDetail.Columns()
        '            Dim colName = col.DataPropertyName
        '            If rule.Property = colName Then
        '                For Each row As DataGridViewRow In DataGridViewSummaryDetail.Rows
        '                    Dim model As New PayElementItemModel
        '                    If row.Index() < DataGridViewSummaryDetail.RowCount() - 1 Then
        '                        GlobalVariables.Mapper.Map(Of PayElementItemView, PayElementItemModel)(PayElementItems(row.Index()), model)
        '                        GlobalVariables.Mapper.Map(Of PayElementItemModel, PayElementItem)(model, bo)
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