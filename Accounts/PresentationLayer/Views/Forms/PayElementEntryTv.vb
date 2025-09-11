Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.Messaging

Namespace PresentationLayer.Views.Forms

    Public Class PayElementEntryTv
        Implements IPayElementView

        Private _payElementAccounts As List(Of PayElementAccountView)
        Private _payElementItems As List(Of PayElementItemView)
        Private _eSumFieldsDict As Dictionary(Of String, Object)
        Private _eAccFieldsDict As Dictionary(Of String, Object)
        Private ReadOnly _nfi As NumberFormatInfo = GlobalVariables.DefaultNumberFormatInfo
        Private _esService = New AccountsService("PayElementItem")
        Private cellPosOrigUnitAtt As TableLayoutPanelCellPosition = New TableLayoutPanelCellPosition(3, 8)
        Private cellPosOrigUnit As TableLayoutPanelCellPosition = New TableLayoutPanelCellPosition(3, 2)
        Private cellPosQtyUnit As TableLayoutPanelCellPosition = New TableLayoutPanelCellPosition(3, 6)
        Private cellPosUnitSave As TableLayoutPanelCellPosition = New TableLayoutPanelCellPosition(0, 8)

        Public Sub New()
            'MyBase.New()
            SuspendLayout()
            DoubleBuffered = True
            FirstControl = txtPayElementCode
            ' This call is required by the designer.
            InitializeComponent()
            ResumeLayout()
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

        Public Property UsePayGroupSetting As Boolean Implements IPayElementView.UsePayGroupSetting
        Public Property FactorTypeByCode As Object Implements IPayElementView.FactorTypeByCode
        Public Property CalculationTypeByCode As Object Implements IPayElementView.CalculationTypeByCode
        Public Property EarnReportGroupsByCode As Object Implements IPayElementView.EarnReportGroupsByCode
        Public Property DedReportGroupsByCode As Object Implements IPayElementView.DedReportGroupsByCode
        Public Property PayElementsByCode As Object Implements IPayElementView.PayElementsByCode
        Public Property PayGroupsByCode As Object Implements IPayElementView.PayGroupsByCode
        Public Property AccountsByCode As Object Implements IPayElementView.AccountsByCode

#End Region

        Private myFont As Font = New Font("Arial", 10, FontStyle.Underline Or FontStyle.Regular)
        Private myFont2 As Font = New Font("Arial", 10, FontStyle.Italic Or FontStyle.Strikeout)

        Private Sub cboCalculationType_ValueChanged(sender As Object, e As EventArgs) Handles cboCalculationType.SelectionChangeCommitted, cboCalculationType.Validated
            If cboCalculationType.Focused Then
                If IsCalcTypeItemDisabled(cboCalculationType.SelectedIndex) Then
                    MessagingService.ShowPmMessage(True, "MsgSelectedValueNotAllowed", {cboPayElementType.LinkedLabel.Text, "field1", cboCalculationType.LinkedLabel.Text, "field2"})
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

        Private Sub cboQuantityType_ValueChanged(sender As Object, e As EventArgs) Handles cboQuantityType.SelectionChangeCommitted, cboQuantityType.Validated
            If cboCalculationType.Focused Then
                If IsQtyTypeItemDisabled(cboCalculationType.SelectedIndex) Then
                    Dim description As String = DirectCast(cboCalculationType, ILinkedLabel).GetControlDescription()
                    MessagingService.ShowPmMessage(True, "MsgSelectedValueNotAllowed",
                                                      {DirectCast(cboCalculationType, ILinkedLabel).GetControlDescription(), "field1",
                                                       DirectCast(cboQuantityType, ILinkedLabel).GetControlDescription(), "field2"})
                    cboCalculationType.SelectedValue = -1
                End If
                DoubleBuffered = True
                'SuspendLayout()
                floCalculation.Visible = False
                lblDefaultQuantity.Visible = True
                txtDefaultQuantity.Visible = True
                lblSlash2.Visible = False
                cboUnit.Visible = True
                tlpCalculation.SetCellPosition(cboUnit, cellPosQtyUnit)
                floCalculation.Visible = True
                'ResumeLayout()
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

        Private Sub UpdateReportGroup()
            cboReportGroupIdNo.DataSource = Nothing
            If cboPayElementKind.SelectedValue = EnumToCode(PayElementKindSelection.Deduction) Then
                cboReportGroupIdNo.DataSource = DedReportGroupsByCode
            Else
                cboReportGroupIdNo.DataSource = EarnReportGroupsByCode
            End If
        End Sub

        Private Sub BindPayElementAccounts()
            bsPayElementAccounts.DataSource = Nothing
            DataGridViewPayElementAccounts.Refresh()
            bsPayElementAccounts.DataSource = PayElementAccounts
            With DataGridViewPayElementAccounts
                .Refresh()
                .AutoGenerateColumns = False
                .DataSource = Nothing
                .DataSource = bsPayElementAccounts
                .Refresh()
            End With
            With DataGridViewPayElementAccounts.Columns
                dgvPayGroupIdNo.DataSource = PayGroupsByCode
                dgvPayGroupIdNo.DisplayMember = "Name"
                dgvPayGroupIdNo.ValueMember = "IdNo"
                dgvPayGroupIdNo.DisplayStyleForCurrentCellOnly = True
                dgvAccountIdNo.DataSource = AccountsByCode
                dgvAccountIdNo.DisplayMember = "Name"
                dgvAccountIdNo.ValueMember = "IdNo"
                dgvAccountIdNo.DisplayStyleForCurrentCellOnly = True
            End With
        End Sub

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"AccountIdNo", cboAccountIdNo},
                {"BasePaymentIdNo", cboBasePaymentIdNo},
                {"CalculationType", cboCalculationType},
                {"DefaultQuantity", txtDefaultQuantity},
                {"FactorType", cboFactorType},
                {"FactorValue", txtMultiplier},
                {"IdNo", TxtIdNo},
                {"IncludeInEos", chkIncludeInEOS},
                {"Notes", txtNotes},
                {"PayElementAccounts", DataGridViewPayElementAccounts},
                {"PayElementCode", txtPayElementCode},
                {"PayElementItems", DataGridViewPayElementItems},
                {"PayElementKind", cboPayElementKind},
                {"PayElementName", txtPayElementName},
                {"PayElementNameAra", txtPayElementNameAra},
                {"PayElementType", cboPayElementType},
                {"QuantityType", cboQuantityType},
                {"Rate", txtRate},
                {"ReportGroupIdNo", cboReportGroupIdNo},
                {"Summary", chkSummary},
                {"Taxable", chkTaxable},
                {"Unit", cboUnit},
                {"UsePayGroups", chkUsePayGroups}
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
            'SuspendLayout()
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
                dgvPayElementIdNo.DataSource = PayElementsByCode
                dgvPayElementIdNo.DisplayMember = "Name"
                dgvPayElementIdNo.ValueMember = "IdNo"
                dgvPayElementIdNo.DisplayStyleForCurrentCellOnly = True
                dgvFactorType.DataSource = FactorTypeByCode
                dgvFactorType.ValueMember = "Code"
                dgvFactorType.DisplayMember = "Name"
                dgvFactorType.DisplayStyleForCurrentCellOnly = True
            End With
            'ResumeLayout()
        End Sub

        Private Sub UpdateCalculationTabDisplay()
            'DoubleBuffered = True
            'SuspendLayout()
            'floDataDisplay.Visible = False
            floCalculation.Visible = False
            tlpCalculation.Visible = False
            Dim curCalculationType = CodeToEnum(Of CalculationTypeSelection)(cboCalculationType.SelectedValue)
            'tlpCalculation.SetCellPosition(cboUnit, _unitPosition)
            lblUnit.Visible = False
            Select Case curCalculationType
                Case CalculationTypeSelection.FixedAmount
                    lblSlash.Visible = True
                    lblRate.Text = MessagingService.TranslateCaption("Default Amount / Unit")
                    lblSlash.Text = MessagingService.TranslateCaption("/")
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
                Case CalculationTypeSelection.FixedRate
                    lblSlash.Visible = True
                    lblRate.Text = MessagingService.TranslateCaption("Default Rate / Unit")
                    lblSlash.Text = MessagingService.TranslateCaption("/")
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
                    lblRate.Text = MessagingService.TranslateCaption("Default Rate/Unit")
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
            'floDataDisplay.Visible = True
            'ResumeLayout(False)
            'PerformLayout()
        End Sub

        Private Sub PayElementEntryTv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            ImageListTreeView.Images.Add(Image.FromFile("Resources\Deduction.png"))
            ImageListTreeView.Images.Add(Image.FromFile("Resources\Earning.png"))
            FormTreeView.ImageList = ImageListTreeView
            UpdateReportGroup()
        End Sub

        Private Sub ChkUsePayGroups_CheckedChanged(sender As Object, e As EventArgs) Handles chkUsePayGroups.CheckedChanged
            UpdatePostingTabDisplay()
        End Sub

        Private Sub UpdatePostingTabDisplay()
            SuspendLayout()
            'floDataDisplay.Visible = False
            If Not chkSummary.Checked Then
                If UsePayGroupSetting Then
                    DataGridViewPayElementAccounts.Visible = True
                    chkUsePayGroups.Visible = True
                    lblUsePayGroups.Visible = True
                    If chkUsePayGroups.Checked Then
                        DataGridViewPayElementAccounts.Visible = True
                        lblAccountIdNo.Text = MessagingService.TranslateCaption("Default Posting Account")
                    Else
                        DataGridViewPayElementAccounts.Visible = False
                        lblAccountIdNo.Text = MessagingService.TranslateCaption("Posting Account")
                    End If
                Else
                    DataGridViewPayElementAccounts.Visible = False
                    chkUsePayGroups.Visible = False
                    lblUsePayGroups.Visible = False
                    lblAccountIdNo.Text = MessagingService.TranslateCaption("Posting Account")
                    DataGridViewPayElementAccounts.Visible = False
                End If
            End If
            'floDataDisplay.Visible = True
            ResumeLayout(False)
            'PerformLayout()
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

        Protected Sub OnInputsTurnedOn() Handles MyBase.InputsTurnedOn
            tbpSummaryDetail.ImageIndex = -1
            UpdateCalculationTabDisplay()
        End Sub

        'Private Sub OnAfterUpdateView() Handles MyBase.AfterUpdateView
        '    UpdateCalculationTabDisplay()
        '    UpdatePostingTabDisplay()
        'End Sub

        Protected Sub PayElement_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles FormTreeView.AfterSelect
            Dim n As TreeNode = FormTreeView.SelectedNode
            If PayElementKind = EnumToCode(PayElementKindSelection.Deduction) Then
                n.SelectedImageIndex = 2
            Else
                n.SelectedImageIndex = 3
            End If
        End Sub

        Private Sub cboPayElementKind_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPayElementKind.SelectedIndexChanged
            UpdateReportGroup()
        End Sub

    End Class

End Namespace