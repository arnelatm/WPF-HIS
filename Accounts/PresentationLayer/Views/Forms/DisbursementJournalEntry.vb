Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Views.Forms

    Public Class DisbursementJournalEntry
        Implements IDisbursementJournalView

        Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat

        Private _apFooter As DgvFooter
        Private _djOiItems As List(Of DjOiItemView)
        Private _jiFooter As DgvFooter
        Private _journalItems As List(Of JournalItemView)
        Private _tableName As String = ""

        Public Sub New(ByVal tableName As String)
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            _tableName = tableName
            EnableDoubleBuff(tlpDisbursement)
            ' Add any initialization after the InitializeComponent() call.
            If tableName = "CdJournal" Then
                ViewDisplayName = "CdJournalEntry"
                DisplayPrintCheckButton(PayType)
                Me.Text = Messaging.TranslateCaption("Cash Disbursement Journal")
            Else
                ViewDisplayName = "PcJournalEntry"
                Me.Text = Messaging.TranslateCaption("Petty Cash Disbursement Journal")
                btnPrintCheck.Visible = False
                btnPrintPcReplenishment.Visible = False
                cboPayType.Visible = False
                lblPayType.Visible = False
                txtCheckNumber.Visible = False
                dtpCheckDate.Visible = False
            End If
            FirstControl = cboPaymentType
            Height = 860
        End Sub

        Public Event AddSupplierOpenInvoices() Implements IDisbursementJournalView.AddSupplierOpenInvoices

        Public Event AutoApplyAmount(bsDjOiItem As BindingSource) Implements IDisbursementJournalView.AutoApplyAmount

        Public Event ContactIdNoChanged() Implements IDisbursementJournalView.ContactIdNoChanged

        Public Event FirstLineUpdateNeeded() Implements IDisbursementJournalView.FirstLineUpdateNeeded

        Public Event PaymentTypeChanged(paymentType As String) Implements IDisbursementJournalView.PaymentTypeChanged

        Public Event PrintCheck() Implements IDisbursementJournalView.PrintCheck
        Public Event PrintPcReplenishment() Implements IDisbursementJournalView.PrintPcReplenishment

        Public Event SetSupplierVatNumber(ByRef currentVatNumber As String, ByVal idNo As String, ByVal override As Boolean) Implements IDisbursementJournalView.SetSupplierVatNumber
        Public Event UserDeletedRow() Implements IDisbursementJournalView.UserDeletedRow
        Public Property OpenInvoiceMode As Boolean Implements IDisbursementJournalView.OpenInvoiceMode

#Region "Field Items"

        Private _contactDataSource
        Public Property AccountIdNo As Int16? Implements IDisbursementJournalView.AccountIdNo
            Get
                Return cboAccountIdNo.GetNullableValue(Of Int16)
            End Get
            Set
                cboAccountIdNo.SetValue(Value)
            End Set
        End Property

        Public Property AccountsByCode Implements IDisbursementJournalView.AccountsByCode
        Public Property Amount As Decimal Implements IDisbursementJournalView.Amount
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtAmount.Text), _nfi)
            End Get
            Set
                txtAmount.Text = FormatMoney(Value)

            End Set
        End Property

        Public Property Applied As Decimal Implements IDisbursementJournalView.Applied
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtApplied.Text), _nfi)
            End Get
            Set
                txtApplied.Text = FormatMoney(Value)
            End Set
        End Property

        Public Property Approved As Boolean Implements IDisbursementJournalView.Approved
            Get
                Return chkApproved.Checked
            End Get
            Set
                chkApproved.Checked = Value
            End Set
        End Property

        Public Property BankTransfer As Boolean Implements IDisbursementJournalView.BankTransfer
        Public Property Cancelled As Boolean Implements IDisbursementJournalView.Cancelled
            Get
                Return chkCancelled.Checked
            End Get
            Set
                chkCancelled.Checked = Value
            End Set
        End Property

        Public Property CdAccountCount As Int32 Implements IDisbursementJournalView.CdAccountCount
        Public Property CdJournalIdNo As Int32? Implements IDisbursementJournalView.CdJournalIdNo
            Get
                If txtCdJournalIdNo.Text <> "" Then
                    Return Convert.ToInt16(txtCdJournalIdNo.Text)
                Else
                    Return 0
                End If
            End Get
            Set
                txtCdJournalIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property CheckDate As DateTime? Implements IDisbursementJournalView.CheckDate
            Get
                Return dtpCheckDate.Value
            End Get
            Set
                If Value.HasValue Then
                    dtpCheckDate.Value = Value
                Else
                    dtpCheckDate.Value = Date.Now()
                End If
            End Set
        End Property

        Public Property CheckNumber As String Implements IDisbursementJournalView.CheckNumber
            Get
                Return txtCheckNumber.Text
            End Get
            Set
                txtCheckNumber.Text = Value
            End Set
        End Property

        Public Property ContactIdNo As Integer? Implements IDisbursementJournalView.ContactIdNo
            Get
                Return cboContactIdNo.GetNullableValue(Of Int32)
            End Get
            Set
                cboContactIdNo.SetValue(Value)
            End Set
        End Property

        Public Property ContactsByName As Object Implements IDisbursementJournalView.ContactsByName

        Public Property CSEIdNo As Integer? Implements IDisbursementJournalView.CSEIdNo
        Public Property DateCreated As DateTime? Implements IDisbursementJournalView.DateCreated
            Get
                Return txtDateCreated.Text
            End Get
            Set
                If Value.HasValue Then
                    txtDateCreated.Text = Value
                Else
                    txtDateCreated.Text = Date.Now()
                End If
            End Set
        End Property

        Public Property DefaultAccount As Int32? Implements IDisbursementJournalView.DefaultAccount
        Public Property DiscountAccountIdNo As Int16? Implements IDisbursementJournalView.DiscountAccountIdNo
            Get
                Return cboDiscountAccountIdNo.GetNullableValue(Of Int16)
            End Get
            Set
                cboDiscountAccountIdNo.SetValue(Value)
            End Set
        End Property

        Public Property DiscountTaken As Decimal Implements IDisbursementJournalView.DiscountTaken
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtDiscountTaken.Text), _nfi)
            End Get
            Set
                txtDiscountTaken.Text = FormatMoney(Value)
            End Set
        End Property

        Public Property DjOiItems As List(Of DjOiItemView) Implements IDisbursementJournalView.DjOiItems
            Get
                Return _djOiItems
            End Get
            Set(value As List(Of DjOiItemView))
                _djOiItems = value
                BindDjOiItem()
            End Set
        End Property

        Public Property IdNo As Int32 Implements IDisbursementJournalView.IdNo
            Get
                If TxtIdNo.Text <> "" Then
                    Return Convert.ToInt16(TxtIdNo.Text)
                Else
                    Return 0
                End If
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property JournalCode As String Implements IDisbursementJournalView.JournalCode
        Public Property JournalCodeDisplay As String Implements IDisbursementJournalView.JournalCodeDisplay
            Get
                Return txtJournalCodeDisplay.GetValue(Of String)
            End Get
            Set(value As String)
                txtJournalCodeDisplay.Text = value
            End Set
        End Property

        Public Property JournalItems As List(Of JournalItemView) Implements IDisbursementJournalView.JournalItems
            Get
                Return _journalItems
            End Get
            Set
                _journalItems = Value
                BindJournalItem()
            End Set
        End Property

        Public Property Notes As String Implements IDisbursementJournalView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = If(Value, "")
            End Set
        End Property

        Public Property ORNumber As String Implements IDisbursementJournalView.OrNumber
            Get
                Return txtORNumber.Text
            End Get
            Set
                txtORNumber.Text = Value
            End Set
        End Property

        Public Property ContactDataSource As Object Implements IDisbursementJournalView.ContactDataSource
            Get
                Return _contactDataSource
            End Get
            Set(value As Object)
                Dim cbValue As Int32 = cboContactIdNo.SelectedValue
                _contactDataSource = value
                cboContactIdNo.DataSource = Nothing
                cboContactIdNo.DataSource = value
                cboContactIdNo.Refresh()
            End Set
        End Property

        Public Property PayeeIdNo As Int32? Implements IDisbursementJournalView.PayeeIdNo
        Public Property PayeeName As String Implements IDisbursementJournalView.PayeeName
            Get
                Return txtPayeeName.Text
            End Get
            Set
                txtPayeeName.Text = Value
            End Set
        End Property

        Public Property PaymentType As String Implements IDisbursementJournalView.PaymentType
            Get
                Return cboPaymentType.GetValue(Of String)
            End Get
            Set
                cboPaymentType.SetValue(Value)
            End Set
        End Property

        Public Property PayType As String Implements IDisbursementJournalView.PayType
            Get
                Return cboPayType.GetValue()
            End Get
            Set
                cboPayType.SetValue(Value)
            End Set
        End Property

        Public Property PcClosed As Boolean Implements IDisbursementJournalView.PcClosed
            Get
                Return chkPcClosed.Checked
            End Get
            Set
                chkPcClosed.Checked = Value
            End Set
        End Property

        Public Property Posted As Boolean Implements IDisbursementJournalView.Posted
            Get
                Return chkPosted.Checked
            End Get
            Set
                chkPosted.Checked = Value
            End Set
        End Property

        Public Property ReferenceNo As String Implements IDisbursementJournalView.ReferenceNo
            Get
                Return txtReferenceNo.Text
            End Get
            Set
                txtReferenceNo.Text = Value
            End Set
        End Property

        Public Property RevCostCentersByCode Implements IDisbursementJournalView.RevCostCentersByCode
        Public ReadOnly Property TotalCredits As Decimal Implements IDisbursementJournalView.TotalCredits
            Get
                Return NumParser(Of Decimal)(txtTotalCredits.Text)
            End Get
        End Property

        Public ReadOnly Property TotalDebits As Decimal Implements IDisbursementJournalView.TotalDebits
            Get
                Return NumParser(Of Decimal)(txtTotalDebits.Text)
            End Get
        End Property
        Public Property TransactionDate As Date? Implements IDisbursementJournalView.TransactionDate
            Get
                Return dtpTransactionDate.Value
            End Get
            Set
                If Value Is Nothing Then
                    dtpTransactionDate.Value = Date.Now()
                Else
                    dtpTransactionDate.Value = Value
                End If
            End Set
        End Property

        Public Property UnApplied As Decimal Implements IDisbursementJournalView.UnApplied
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtUnapplied.Text), _nfi)
            End Get
            Set
                txtUnapplied.Text = FormatMoney(Value)
            End Set
        End Property

        Public Property VatAmount As Decimal Implements IDisbursementJournalView.VatAmount
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtVatAmount.Text), _nfi)
            End Get
            Set
                txtVatAmount.Text = FormatMoney(Value)
            End Set
        End Property

        Public Property VatNumber As String Implements IDisbursementJournalView.VatNumber
            Get
                Return txtVatNumber.Text
            End Get
            Set
                txtVatNumber.Text = Value
            End Set
        End Property
        Public Overrides Function GetPrintParameters() As Object
            Return Me.FormCulture
        End Function



#End Region

        Public Overloads Sub Dispose()
            Close()
        End Sub

        Public Sub OnInputsTurnedOff() Handles MyBase.InputsTurnedOff
            UpdateAutoApplyButtonDisplay()
            UpdateViewGLBtnDisplay()
        End Sub

        Private Sub UpdateAutoApplyButtonDisplay()
            If EditingMode OrElse AddingMode Then
                If OpenInvoiceMode Then
                    btnAutoApply.Visible = True
                Else
                    btnAutoApply.Visible = False
                End If
            Else
                btnAutoApply.Visible = False
            End If
        End Sub

        Public Sub OnInputsTurnedOn() Handles MyBase.InputsTurnedOn
            btnViewGL.Visible = False
            UpdateAutoApplyButtonDisplay()
            'For Each control In Controls
            '    If TypeOf control Is AtmComboBox Then
            '        Dim x As AtmComboBox = control
            '        x.SelectionLength = 0
            '        x.SelectionStart = 0
            '    End If
            'Next
        End Sub

        Public Sub UpdateJiTotals()
            If _jiFooter IsNot Nothing Then
                _jiFooter.CalculateTotals()
                txtTotalDebits.Text = _jiFooter.Value("dgvDebit")
                txtTotalCredits.Text = _jiFooter.Value("dgvCredit")
            End If
            Applied = Amount
            UnApplied = 0
            DataGridViewJournalItems.Refresh()
        End Sub

        Public Sub UpdateOiTotals()
            If _apFooter IsNot Nothing Then
                _apFooter.CalculateTotals()
                Applied = _apFooter.Value("dgvAmount")
                DiscountTaken = _apFooter.Value("dgvDiscountTaken")
                UnApplied = Amount - Applied
            End If
        End Sub

        Public Overrides Sub UpdateViewDisplay(editMode As Boolean, addMode As Boolean, recordPositionNumber As Integer, targetIdNo As Integer, recordCount As Integer)
            SuspendLayout()
            UpdatePayeeDisplay()
            UpdateDataGridDisplay()
            UpdateTotalsDisplay()
            DisplayPrintCheckButton(PayType)
            DisplayCheckInfo()
            ResumeLayout()
            MyBase.UpdateViewDisplay(editMode, addMode, recordPositionNumber, targetIdNo, recordCount)
            UpdateActionButtons(editMode Or addMode)
            'For Each control In Controls
            '    If TypeOf control Is AtmComboBox Then
            '        Dim x As AtmComboBox = control
            '        x.SelectionLength = 0
            '        x.SelectionStart = 0
            '    End If

            'Next
        End Sub


        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
        {
         {"AccountIdNo", cboAccountIdNo},
         {"Amount", txtAmount},
         {"Applied", txtApplied},
         {"Cancelled", chkCancelled},
         {"CheckDate", dtpCheckDate},
         {"PcClosed", chkPcClosed},
         {"CheckNumber", txtCheckNumber},
         {"DateCreated", txtDateCreated},
         {"PayType", cboPayType},
         {"DiscountAccountIdNo", cboDiscountAccountIdNo},
         {"DiscountTaken", txtDiscountTaken},
         {"IdNo", TxtIdNo},
         {"Notes", txtNotes},
         {"OrNumber", txtORNumber},
         {"PaymentType", cboPaymentType},
         {"ContactIdNo", cboContactIdNo},
         {"PayeeName", txtPayeeName},
         {"Posted", chkPosted},
         {"ReferenceNo", txtReferenceNo},
         {"TransactionDate", dtpTransactionDate},
         {"UnApplied", txtUnapplied},
         {"VatAmount", txtVatAmount},
         {"VatNumber", txtVatNumber},
         {"TotalDebits", txtTotalDebits},
         {"TotalCredits", txtTotalCredits}
        }
        End Sub


        Private Sub AfterSave_Handler() Handles MyBase.AfterSave
            EditingMode = False
            AddingMode = False
            UpdateViewGLBtnDisplay()
            UpdateAutoApplyButtonDisplay()
        End Sub

        Private Sub BindDjOiItem()
            SuspendLayout()
            bsDjOiItems.DataSource = Nothing
            DataGridViewDjOiItems.Refresh()
            bsDjOiItems.DataSource = DjOiItems
            bsDjOiItems.AllowNew = True
            With DataGridViewDjOiItems
                .Refresh()
                .AutoGenerateColumns = False
                .DataSource = bsDjOiItems
                .Refresh()
            End With
            With DataGridViewDjOiItems.Columns
                If dgvSequenceDjOi IsNot Nothing Then
                    dgvSequenceDjOi.DisplayOnly = True
                    dgvInvoiceNo.DisplayOnly = True
                    dgvPreviousBalance.DisplayOnly = True
                    dgvBalance.DisplayOnly = True
                    DgvTransactionDate.DisplayOnly = True
                    dgvJournalCode.DisplayOnly = True
                    dgvJournalIdNoAp.DisplayOnly = True
                End If
            End With
            UpdateTotalsDisplay()
            ResumeLayout()
        End Sub

        Private Sub BindJournalItem()
            SuspendLayout()
            bsJournalItems.DataSource = Nothing
            DataGridViewJournalItems.Refresh()
            bsJournalItems.DataSource = JournalItems
            bsJournalItems.AllowNew = True
            With DataGridViewJournalItems
                '.Refresh()
                .AutoGenerateColumns = False
                .DataSource = bsJournalItems
                '.Refresh()
            End With
            With DataGridViewJournalItems.Columns
                dgvSequence.DisplayOnly = True
                dgvAccountIdNo.DataSource = AccountsByCode
                dgvAccountIdNo.DisplayMember = "Name"
                dgvAccountIdNo.ValueMember = "IdNo"
                dgvAccountIdNo.DisplayStyleForCurrentCellOnly = True
                dgvRevCostCenterIdNo.DataSource = RevCostCentersByCode
                dgvRevCostCenterIdNo.DisplayMember = "Name"
                dgvRevCostCenterIdNo.ValueMember = "idNo"
                dgvRevCostCenterIdNo.DisplayStyleForCurrentCellOnly = True
            End With
            ResumeLayout()
        End Sub

        Private Sub btnPrintCheck_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnPrintCheck.ClickButtonArea
            RaiseEvent PrintCheck()
        End Sub

        Private Sub btnPrintPcReplenishment_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnPrintPcReplenishment.ClickButtonArea
            RaiseEvent PrintPcReplenishment()
        End Sub

        Private Sub BtnViewGL_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnViewGL.ClickButtonArea
            If DataGridViewJournalItems.Visible Then
                ShowOpenInvoicesDataGrid()
            Else
                ShowJournalItemDataGrid()
            End If
            UpdateViewGLBtnDisplay()
        End Sub

        Private Sub CboAccountIdNo_Changed(sender As Object, e As EventArgs) Handles cboAccountIdNo.Validated, cboAccountIdNo.SelectionChangeCommitted
            UpdateFirstLine()
        End Sub

        Private Sub CboContactIdNo_ValueChanged(sender As Object, e As EventArgs) Handles cboContactIdNo.SelectedValueChanged
            RaiseEvent ContactIdNoChanged()
            If OpenInvoiceMode Then
                UpdateOpenInvoiceDisplay()
            End If
        End Sub

        Private Sub CboPaymentType_ValueChanged(sender As Object, e As EventArgs) Handles cboPaymentType.SelectionChangeCommitted, cboPaymentType.Validated ', cboPaymentType.SelectedIndexChanged, 
            RaiseEvent PaymentTypeChanged(PaymentType)
            UpdatePayeeDisplay()
            If OpenInvoiceMode Then
                UpdateOpenInvoiceDisplay()
            Else
                UpdateJournalItemsDisplay()
            End If
            UpdateTotalsDisplay()
            UpdateActionButtons(True)
        End Sub

        Private Sub CboPayType_ValueChanged(sender As Object, e As EventArgs) Handles cboPayType.SelectionChangeCommitted '  ,cboPayType.Validated, cboPayType.SelectedValueChanged 
            If FormShown Then

                DisplayPrintCheckButton(cboPayType.SelectedValue)
                DisplayCheckInfo()
            End If
        End Sub

        Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnAutoApply.ClickButtonArea
            RaiseEvent AutoApplyAmount(bsDjOiItems)
            bsDjOiItems.ResetBindings(False)
            UpdateOiTotals()
        End Sub

        Private Sub DataGridViewJournalItems_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridViewJournalItems.UserDeletedRow
            RaiseEvent UserDeletedRow()
            UpdateTotalsDisplay()
        End Sub

        Private Sub DgvJi_OnCellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridViewJournalItems.CellBeginEdit
            If DataGridViewJournalItems.CurrentCell.RowIndex() = 0 Then
                With DataGridViewJournalItems.CurrentCell
                    Dim cColumnName = .OwningColumn.Name.ToLower()
                    If cColumnName = $"dgvaccountidno" Or cColumnName = $"dgvdebit" Or cColumnName = $"dgvcredit" Then
                        Beep()
                        e.Cancel = True
                        DataGridViewJournalItems.EndEdit()
                    End If
                End With
            End If
        End Sub

        Private Sub DgvJi_OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewJournalItems.CellEndEdit
            ProcessCellEndEdit(DataGridViewJournalItems, bsJournalItems)
        End Sub

        Private Sub DisbursementJournalEntry_Click(sender As Object, e As EventArgs) Handles MyBase.Click
            Debugger.Break()
        End Sub

        Private Sub DisbursementJournalEntry_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
            If CdAccountCount = 1 Then
                cboAccountIdNo.DisplayOnly = True
                cboAccountIdNo.TabStop = False
            End If
            If cboAccountIdNo.SelectedValue Is Nothing OrElse cboAccountIdNo.SelectedValue <= 0 Then
                cboAccountIdNo.SelectedValue = DefaultAccount
            End If
            DisplayCheckInfo()
            btnPrint.Visible = False
            btnPrintWithArgs.Visible = True
        End Sub

        Private Sub DisplayCheckInfo()
            If _tableName = "CdJournal" AndAlso cboPayType.SelectedValue = EnumToCode(PayTypeSelection.CheckPayment) Then
                dtpCheckDate.Visible = True
                lblCheckDate.Visible = True
                lblCheckNumber.Visible = True
                txtCheckNumber.Visible = True
            Else
                dtpCheckDate.Visible = False
                lblCheckDate.Visible = False
                lblCheckNumber.Visible = False
                txtCheckNumber.Visible = False
            End If
        End Sub

        Private Sub DisplayPrintCheckButton(ByVal cPayType As String)
            If cPayType = EnumToCode(PayTypeSelection.BankTransfer) Then
                btnPrintCheck.Visible = False
            ElseIf cPayType = EnumToCode(PayTypeSelection.CheckPayment) Then
                btnPrintCheck.Visible = True
            Else
                btnPrintCheck.Visible = False
            End If
            If ViewDisplayName = "CdJournalEntry" And PcClosed Then
                btnPrintPcReplenishment.Visible = True
            Else
                btnPrintPcReplenishment.Visible = False
            End If
        End Sub

        Private Sub DjJournalEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            _jiFooter = New DgvFooter(DataGridViewJournalItems) With {
                .AutoCalc = True
            }
            _jiFooter.ColumnToSum("dgvDebit") = True
            _jiFooter.ColumnToSum("dgvCredit") = True
            _jiFooter.SetText("DgvAccountIdNo", "Totals ->")

            _apFooter = New DgvFooter(DataGridViewDjOiItems) With {
                .AutoCalc = True
            }
            _apFooter.ColumnToSum("dgvAmount") = True
            _apFooter.ColumnToSum("dgvDiscountTaken") = True
            _apFooter.ColumnToSum("dgvBalance") = True
            _apFooter.ColumnToSum("dgvPreviousBalance") = True
            _apFooter.SetText("dgvJournalIdNoAp", "Totals")
            BindDjOiItem()
            BindJournalItem()
        End Sub
        Private Sub DjOiItemDgv_OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewDjOiItems.CellEndEdit
            ProcessCellEndEdit(DataGridViewDjOiItems, bsDjOiItems)
        End Sub

        Private Sub ShowJournalItemDataGrid()
            DataGridViewJournalItems.Visible = True
            DataGridViewDjOiItems.Visible = False
            If tlpDisbursement.GetCellPosition(DataGridViewJournalItems) <> New TableLayoutPanelCellPosition(0, 8) Then
                tlpDisbursement.SetColumnSpan(DataGridViewJournalItems, 12)
                tlpDisbursement.SetColumnSpan(DataGridViewDjOiItems, 1)
                GlobalSubs.SwapPosition(DataGridViewJournalItems, DataGridViewDjOiItems)
            End If
            DataGridViewJournalItems.DataSource = bsJournalItems
            If DataGridViewJournalItems.DgvFooter IsNot Nothing Then
                DataGridViewJournalItems.DgvFooter.Refresh()
            End If
        End Sub

        Private Sub ShowOpenInvoicesDataGrid()
            DataGridViewJournalItems.Visible = False
            DataGridViewDjOiItems.Visible = True
            If tlpDisbursement.GetCellPosition(DataGridViewDjOiItems) <> New TableLayoutPanelCellPosition(0, 8) Then
                tlpDisbursement.SetColumnSpan(DataGridViewJournalItems, 1)
                tlpDisbursement.SetColumnSpan(DataGridViewDjOiItems, 12)
                GlobalSubs.SwapPosition(DataGridViewJournalItems, DataGridViewDjOiItems)
            End If
            If DataGridViewDjOiItems.DgvFooter IsNot Nothing Then
                DataGridViewDjOiItems.DgvFooter.Refresh()
            End If
        End Sub

        Private Sub TxtAmount_Validated(sender As Object, e As EventArgs) Handles txtAmount.Validated
            UpdateTotalsDisplay()
            UpdateFirstLine()
        End Sub
        Private Sub TxtNotes_Leave(sender As Object, e As EventArgs) Handles txtNotes.Leave
            If OpenInvoiceMode Then
                MoveToGridView(DataGridViewDjOiItems, "dgvAmount")
            Else
                MoveToGridView(DataGridViewJournalItems, "dgvRevCostCenterIdNo")
            End If
        End Sub
        Private Sub UpdateActionButtons(editOrAddMode As Boolean)
            UpdateViewGLBtnDisplay()
            UpdateAutoApplyButtonDisplay()
        End Sub

        Private Sub UpdateDataGridDisplay()
            If OpenInvoiceMode Then
                UpdateOpenInvoiceDisplay()
            Else
                UpdateJournalItemsDisplay()
            End If
        End Sub

        Private Sub UpdateFirstLine()
            RaiseEvent FirstLineUpdateNeeded()
            If Not OpenInvoiceMode Then
                bsJournalItems.ResetBindings(True)
                UpdateJiTotals()
            End If
        End Sub

        Private Sub UpdateJournalItemsDisplay()
            ShowJournalItemDataGrid()
            cboDiscountAccountIdNo.Enabled = False
            BindJournalItem()
            Applied = Amount
            UnApplied = 0
            DiscountTaken = 0
        End Sub

        Private Sub UpdateOpenInvoiceDisplay()
            ShowOpenInvoicesDataGrid()
            cboDiscountAccountIdNo.Enabled = True
        End Sub

        Private Sub UpdatePayeeDisplay()
            Dim paymentTypeEnum = CodeToEnum(Of PaymentTypeSelection)(cboPaymentType.SelectedValue)
            If paymentTypeEnum = PaymentTypeSelection.Others Or paymentTypeEnum = PaymentTypeSelection.NotSpecified Then
                cboContactIdNo.Visible = False
                txtPayeeName.Visible = True
                cboContactIdNo.SelectedIndex = -1
                tlpDisbursement.SetCellPosition(cboContactIdNo, New TableLayoutPanelCellPosition(12, 9))
                tlpDisbursement.SetCellPosition(txtPayeeName, New TableLayoutPanelCellPosition(1, 2))
                tlpDisbursement.SetColumnSpan(txtPayeeName, 8)
            Else
                cboContactIdNo.Visible = True
                txtPayeeName.Visible = False
                txtPayeeName.Text = cboContactIdNo.Text
                tlpDisbursement.SetCellPosition(txtPayeeName, New TableLayoutPanelCellPosition(12, 9))
                tlpDisbursement.SetCellPosition(cboContactIdNo, New TableLayoutPanelCellPosition(1, 2))
                tlpDisbursement.SetColumnSpan(cboContactIdNo, 8)
            End If
            cboPaymentType.SelectionLength = 0
            cboPayType.SelectionLength = 0
            cboContactIdNo.SelectionLength = 0
            cboAccountIdNo.SelectionLength = 0
            cboDiscountAccountIdNo.SelectionLength = 0
        End Sub

        Private Sub UpdateTotalsDisplay()
            If OpenInvoiceMode Then
                UpdateOiTotals()
            Else
                UpdateJiTotals()
            End If
        End Sub

        Private Sub UpdateViewGLBtnDisplay()
            If OpenInvoiceMode Then
                If EditingMode OrElse AddingMode Then
                    btnViewGL.Visible = False
                Else
                    btnViewGL.Visible = True
                    If DataGridViewJournalItems.Visible Then
                        btnViewGL.Text = Messaging.TranslateCaption("Hide Journal Entry")
                    Else
                        btnViewGL.Text = Messaging.TranslateCaption("View Journal Entry")
                    End If
                End If
            Else
                btnViewGL.Visible = False
            End If
        End Sub

        Private Sub UserDeletingRow(ByVal sender As Object, ByVal e As DataGridViewRowCancelEventArgs) Handles DataGridViewJournalItems.UserDeletingRow
            Dim cdJournalRow As DataGridViewRow = DataGridViewJournalItems.Rows(0)
            If DataGridViewJournalItems.SelectedRows.Contains(cdJournalRow) Then
                ' Do not allow the user to delete the first row.
                Messaging.Show(True, "MsgFirstRowDeletionNotAllowed", "Deletion of the first row Is Not allowed!", "Delete Error")
                ' Cancel the deletion
                e.Cancel = True
            End If
        End Sub
    End Class

End Namespace