Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Views.Forms

    Public Class DisbursementJournalEntry
        Implements IDisbursementJournalView, ISubscriber(Of BeforeAssignment)

        Public TxtTotalCredits As Decimal
        Public TxtTotalDebits As Decimal

        Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat

        Private _accountsByCode

        Private _apFooter As DgvFooter
        Private _jiFooter As DgvFooter
        Private _journalItems As List(Of IJournalItemView)
        Private _djOiItems As List(Of DjOiItemView)
        Private _revCostCenterByCode
        Private _viewGl As Boolean = False

        Public Sub New(ByVal tableName As String)
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            EnableDoubleBuff(tlpDisbursement)
            ' Add any initialization after the InitializeComponent() call.
            MainTableName = tableName
            If tableName = "PcJournal" Then
                PresenterObj = New DisbursementJournalPresenter(Me, "PcJournal")
                Me.Text = Messaging.TranslateCaption("Petty Cash Disbursement Journal")
                btnPrintCheck.Visible = False
            ElseIf tableName = "CdJournal" Then
                PresenterObj = New DisbursementJournalPresenter(Me, "CdJournal")
                Me.Text = Messaging.TranslateCaption("Cash Disbursement Journal")
                btnPrintCheck.Visible = False
            Else
                PresenterObj = New DisbursementJournalPresenter(Me, "CkJournal")
                PresenterObj.JournalCode = "CK"
                Me.Text = Messaging.TranslateCaption("Check Disbursement Journal")
                btnPrintCheck.Visible = True
            End If
            txtJournalCode.Text = PresenterObj.JournalCode
            SortOrderKey = "IdNo"
            FirstControl = cboPaymentType
            _nfi.NumberDecimalDigits = 2
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)
        End Sub

#Region "Field Items"

        Public Property AccountIdNo As Int16? Implements IDisbursementJournalView.AccountIdNo
            Get
                Return cboAccountIdNo.GetNullableValue(Of Int16)
            End Get
            Set
                cboAccountIdNo.SetValue(Value)
            End Set
        End Property

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

        Public Property Cancelled As Boolean Implements IDisbursementJournalView.Cancelled
            Get
                Return chkCancelled.Checked
            End Get
            Set
                chkCancelled.Checked = Value
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

        Public Property DateCreated As DateTime? Implements IDisbursementJournalView.DateCreated
            Get
                Return dtpDateCreated.Value
            End Get
            Set
                If Value.HasValue Then
                    dtpDateCreated.Value = Value
                Else
                    dtpDateCreated.Value = Date.Now()
                End If
            End Set
        End Property

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

        Public Property JournalItems As List(Of IJournalItemView) Implements IDisbursementJournalView.JournalItems
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

        Public Property PayeeIdNo As Int32? Implements IDisbursementJournalView.PayeeIdNo
            Get
                Return cboPayeeIdNo.GetNullableValue(Of Int32)
            End Get
            Set
                If cboPayeeIdNo.DataSource IsNot Nothing Then
                    cboPayeeIdNo.SetValue(Value)
                Else
                    cboPayeeIdNo.SelectedValue = Nothing
                End If
            End Set
        End Property

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
                Return cboPaymentType.GetValue()
            End Get
            Set
                cboPaymentType.SetValue(Value)
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

        Public Property TotalCredits As Decimal Implements IDisbursementJournalView.TotalCredits
            Get
                Return TxtTotalCredits
            End Get
            Set(value As Decimal)
                TxtTotalCredits = value
            End Set
        End Property

        Public Property TotalDebits As Decimal Implements IDisbursementJournalView.TotalDebits
            Get
                Return TxtTotalDebits
            End Get
            Set(value As Decimal)
                TxtTotalDebits = value
            End Set
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

#End Region

        Public Sub OnEventHandler(ByRef eventType As BeforeAssignment) Implements ISubscriber(Of BeforeAssignment).OnEventHandler
            ' need to do this because the Mapping source part of this program maps the PayeeIdNo first before
            ' the DepositType so in order to override this part we need to retrieve the DepositType first
            ' because when assigning the cboPayeeIdNo the dataSource must be correct that is why
            ' we need to set the DataSource part of the cboPayeeIdNo before we can assign the PayeeIdNo
            PaymentType = eventType.Model.PaymentType
            SetPayeeDataSource(PaymentType)
            cboPaymentType.SelectedValue = IIf(PaymentType = Nothing, 0, PaymentType)
        End Sub

        Protected Overrides Sub CreateDataSources()
            _accountsByCode = PresenterObj.GetDetailAccountList()
            _revCostCenterByCode = PresenterObj.GetLookup("RevCostCenter")
            cboPaymentType.DataSource = PresenterObj.MakeEnumComboList(Of PaymentTypeSelection)
            If MainTableName = "CdJournal" Then
                cboAccountIdNo.DataSource = PresenterObj.GetAccountTypesList(EnumToCode(SpecialAccountSelection.Bank) + "," + EnumToCode(SpecialAccountSelection.Cash) + "," + EnumToCode(SpecialAccountSelection.CheckingAccount))
            ElseIf MainTableName = "PcJournal" Then
                cboAccountIdNo.DataSource = PresenterObj.GetAccountTypesList(EnumToCode(SpecialAccountSelection.PettyCashAccount))
            Else
                cboAccountIdNo.DataSource = PresenterObj.GetAccountTypesList(EnumToCode(SpecialAccountSelection.CheckingAccount))
            End If
            cboDiscountAccountIdNo.DataSource = PresenterObj.GetAccountTypesList("PD")
        End Sub

        Protected Overrides Sub CreateFieldsDictionary()
            FieldsDictionary = New Dictionary(Of String, Object) From
        {
         {"AccountIdNo", cboAccountIdNo},
         {"Amount", txtAmount},
         {"Applied", txtApplied},
         {"Cancelled", chkCancelled},
         {"DateCreated", dtpDateCreated},
         {"DiscountAccountIdNo", cboDiscountAccountIdNo},
         {"DiscountTaken", txtDiscountTaken},
         {"IdNo", TxtIdNo},
         {"Notes", txtNotes},
         {"OrNumber", txtORNumber},
         {"PaymentType", cboPaymentType},
         {"PayeeIdNo", cboPayeeIdNo},
         {"PayeeName", txtPayeeName},
         {"Posted", chkPosted},
         {"ReferenceNo", txtReferenceNo},
         {"TransactionDate", dtpTransactionDate},
         {"UnApplied", txtUnapplied},
         {"VatAmount", txtVatAmount},
         {"VatNumber", txtVatNumber}
        }
        End Sub

        Protected Overrides Sub RecordPositionChanged(ByRef e As RecordPositionChanged)
            MyBase.RecordPositionChanged(e)
            UpdateLayout()
            UpdateTotals()
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
            UpdateTotals()
            ResumeLayout()
        End Sub

        Private Sub BindJournalItem()
            SuspendLayout()
            bsJournalItems.DataSource = Nothing
            DataGridViewJournalItems.Refresh()
            bsJournalItems.DataSource = JournalItems
            bsJournalItems.AllowNew = True
            With DataGridViewJournalItems
                .Refresh()
                .AutoGenerateColumns = False
                .DataSource = bsJournalItems
                .Refresh()
            End With
            With DataGridViewJournalItems.Columns
                dgvSequence.DisplayOnly = True
                dgvAccountIdNo.DataSource = _accountsByCode
                dgvAccountIdNo.DisplayMember = "Name"
                dgvAccountIdNo.ValueMember = "IdNo"
                dgvAccountIdNo.AutoComplete = AutoCompleteMode.SuggestAppend
                dgvAccountIdNo.DisplayStyleForCurrentCellOnly = True
                dgvAccountIdNo.AutoComplete = True
                dgvRevCostCenterIdNo.DataSource = _revCostCenterByCode
                dgvRevCostCenterIdNo.DisplayMember = "Name"
                dgvRevCostCenterIdNo.ValueMember = "idNo"
                dgvRevCostCenterIdNo.AutoComplete = AutoCompleteMode.SuggestAppend
                dgvRevCostCenterIdNo.DisplayStyleForCurrentCellOnly = True
            End With
            ResumeLayout()
        End Sub

        Private Sub BtnViewGL_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnViewGL.ClickButtonArea
            If _viewGl Then
                _viewGl = False
                'DataGridViewJournalItems.Visible = False
                'DataGridViewDjOiItems.Visible = True
                btnViewGL.Text = Messaging.TranslateCaption("View Journal Entry")
                'If tlpDisbursement.GetColumn(DataGridViewDjOiItems) <> 0 Then
                'SwapPosition(DataGridViewJournalItems, DataGridViewDjOiItems)
                'tlpDisbursement.SetColumnSpan(DataGridViewJournalItems, 1)
                'tlpDisbursement.SetColumnSpan(DataGridViewDjOiItems, 12)
                'End If
                ShowOpenInvoicesDataGrid()
            Else
                _viewGl = True
                'DataGridViewJournalItems.Visible = True
                'DataGridViewDjOiItems.Visible = False
                btnViewGL.Text = Messaging.TranslateCaption("Hide Journal Entry")
                ShowJournalItemDataGrid()
                'If tlpDisbursement.GetColumn(DataGridViewJournalItems) <> 1 Then
                'SwapPosition(DataGridViewJournalItems, DataGridViewDjOiItems)
                'tlpDisbursement.SetColumnSpan(DataGridViewDjOiItems, 1)
                'tlpDisbursement.SetColumnSpan(DataGridViewJournalItems, 12)
                'End If
            End If
        End Sub

        Private Sub DjOiItemDgv_OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs)
            With DataGridViewDjOiItems.CurrentCell
                Select Case .OwningColumn.Name.ToLower()
                    Case $"dgvamount"
                        Dim selectedRow As DjOiItemView
                        Dim amt = .Value
                        selectedRow = DataGridViewDjOiItems.Rows(.RowIndex).DataBoundItem
                        selectedRow.Balance = selectedRow.PreviousBalance - amt - selectedRow.DiscountTaken
                        UpdateOiTotals()
                    Case $"dgvdiscounttaken"
                        Dim selectedRow As DjOiItemView
                        Dim amt = .Value
                        selectedRow = DataGridViewDjOiItems.Rows(.RowIndex).DataBoundItem
                        selectedRow.Balance = selectedRow.PreviousBalance - selectedRow.Amount - amt
                        UpdateOiTotals()
                        'SendKeys.Send("{HOME}{DOWN}{TAB}{TAB}{TAB}")
                    Case $"dgvbalance"
                        SendKeys.Send("{DOWN}")
                End Select
            End With
        End Sub

        Private Sub DjJournalEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            KeyPreview = True
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

            If PresenterObj.CdAccountCount = 1 Then
                cboAccountIdNo.DisplayOnly = True
                cboAccountIdNo.TabStop = False
            End If
            If MainTableName <> "CkJournal" Then
                dtpCheckDate.Visible = False
                lblCheckDate.Visible = False
                lblCheckNumber.Visible = False
                txtCheckNumber.Visible = False
                'SwapPosition(txtORNumber, txtCheckNumber)
                'tlpDisbursement.SetCellPosition(txtORNumber, New TableLayoutPanelCellPosition(1, 3))
                'tlpDisbursement.SetCellPosition(txtCheckNumber, New TableLayoutPanelCellPosition(6, 8))
            Else
                'tlpDisbursement.SetCellPosition(txtCheckNumber, New TableLayoutPanelCellPosition(11, 8))
                'tlpDisbursement.SetCellPosition(txtOrNumber, New TableLayoutPanelCellPosition(1, 3))
                'SwapPosition(txtORNumber, txtCheckNumber)
                'tlpDisbursement.SetColumnSpan(lblCheckNumber, 1)
                'SwapPosition(lblInvoiceNo, lblCheckNumber)
                dtpCheckDate.Visible = True
                lblCheckDate.Visible = True
                lblCheckNumber.Visible = True
                txtCheckNumber.Visible = True
                'lblInvoiceNo.Visible = False
                'txtORNumber.Visible = False
            End If

            If PresenterObj.CdAccountCount = 0 Then
                If txtJournalCode.Text = "PC" Then
                    Messaging.ShowParametrizedMessage(True, "MsgNoSpecialAccount", {"specialAccountName", "Petty Cash"})
                ElseIf txtJournalCode.Text = "CD" Then
                    Messaging.ShowParametrizedMessage(True, "MsgNoSpecialAccount", {"specialAccountName", "Cash"})
                Else
                    Messaging.ShowParametrizedMessage(True, "MsgNoSpecialAccount", {"specialAccountName", "Checking Account"})
                End If
                PresenterObj.GoQuit()
            End If

        End Sub

        Private Sub CboAccountIdNo_ValueChanged(sender As Object, e As EventArgs)
            UpdateFirstLine()
        End Sub

        Private Sub CboPayeeIdNo_Validated(sender As Object, e As EventArgs)
            If CodeToEnum(Of PaymentTypeSelection)(PaymentType) = PaymentTypeSelection.AccountsPayable Or CodeToEnum(Of PaymentTypeSelection)(PaymentType) = PaymentTypeSelection.Supplier Then
                If CodeToEnum(Of PaymentTypeSelection)(PaymentType) = PaymentTypeSelection.AccountsPayable Then
                    If cboPayeeIdNo.PreviousSelectedIndex <> cboPayeeIdNo.SelectedIndex Then
                        bsDjOiItems.Clear()
                        UpdateOiTotals()
                    End If
                    PresenterObj.AddSupplierOpenInvoices()
                    BindDjOiItem()
                End If
                Dim lVatNumber As String
                lVatNumber = PresenterObj.GetSupplierVatNumber(cboPayeeIdNo.SelectedValue)
                If Not String.IsNullOrEmpty(lVatNumber) Then
                    VatNumber = lVatNumber
                End If
            End If
        End Sub

        Private Sub CboPaymentType_SelectedIndexChanged(sender As Object, e As EventArgs)
            If cboPaymentType.PreviousSelectedIndex <> cboPaymentType.SelectedIndex Then
                SetPayeeDataSource(PaymentType)
                UpdateLayout()
            End If
        End Sub

        Private Sub UpdateLayout()
            SuspendLayout()
            Dim paymentTypeEnum = CodeToEnum(Of PaymentTypeSelection)(cboPaymentType.SelectedValue)
            If paymentTypeEnum = PaymentTypeSelection.AccountsPayable Then
                ShowOpenInvoicesDataGrid()
            Else
                ShowJournalItemDataGrid()
                Applied = Amount
                UnApplied = 0
                DiscountTaken = 0
            End If
            ShowPayee(paymentTypeEnum)
            ResumeLayout()
        End Sub

        Public Overloads Sub Dispose()
            Close()
        End Sub

        Private Sub OnCellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs)
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

        Private Sub OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs)
            With DataGridViewJournalItems.CurrentCell
                Dim nIndex = DataGridViewJournalItems.CurrentRow.Index
                Select Case .OwningColumn.Name.ToLower()
                    Case $"dgvaccountidno"
                        Dim newValue = DirectCast(DataGridViewJournalItems.CurrentCell, CaDgvComboboxCell).CellEditingControl.GetValue()
                        Dim account As AccountModel
                        account = PresenterObj.GetAccount(newValue)
                        If nIndex + 1 <= DataGridViewJournalItems.RowCount() Then
                            If nIndex < JournalItems.Count() Then
                                JournalItems(nIndex).AccountIdNo = newValue
                                JournalItems(nIndex).SpecialAccount = account.SpecialAccount
                                JournalItems(nIndex).PayeeType = account.PayeeType
                                JournalItems(nIndex).AccountName = account.AccountName
                                UpdateTotalVatAmount()
                                'BindJournalItem()
                            End If
                        End If
                    Case $"dgvdebit"
                        UpdateJiTotals()
                        UpdateTotalVatAmount()
                        SendKeys.Send("{TAB}")
                    Case $"dgvcredit"
                        UpdateJiTotals()
                        UpdateTotalVatAmount()
                    Case $"dgvnotes"
                        SendKeys.Send("{DOWN}")
                End Select
            End With
        End Sub

        Protected Overrides Sub InputsTurnedOff()
            If CodeToEnum(Of PaymentTypeSelection)(PaymentType) = PaymentTypeSelection.AccountsPayable Then
                btnViewGL.Visible = True
            Else
                btnViewGL.Visible = False
            End If
            btnAutoApply.Visible = False
        End Sub

        Protected Overrides Sub InputsTurnedOn()
            PresenterObj.AddSupplierOpenInvoices()
            BindDjOiItem()
            btnViewGL.Visible = False
            If CodeToEnum(Of PaymentTypeSelection)(PaymentType) = PaymentTypeSelection.AccountsPayable Then
                btnAutoApply.Visible = True
            Else
                btnAutoApply.Visible = False
            End If
        End Sub

        Private Sub SetPayeeDataSource(ByVal cPaymentType As String)
            Dim cbDataSource = Nothing
            cboPayeeIdNo.DataSource = cbDataSource
            Dim paymentTypeEnum = CodeToEnum(Of PaymentTypeSelection)(cPaymentType)
            If paymentTypeEnum = PaymentTypeSelection.AccountsPayable Then
                cbDataSource = PresenterObj.GetLookup("Supplier")
            Else
                If paymentTypeEnum = PaymentTypeSelection.Supplier Then
                    cbDataSource = PresenterObj.GetLookup("Supplier")
                ElseIf paymentTypeEnum = PaymentTypeSelection.Employee Then
                    cbDataSource = PresenterObj.GetLookup("Employee")
                ElseIf paymentTypeEnum = PaymentTypeSelection.CustomerRefund Then
                    cbDataSource = PresenterObj.GetLookup("Customer")
                End If
            End If
            cboPayeeIdNo.DataSource = cbDataSource
        End Sub

        Private Sub ShowJournalItemDataGrid()
            DataGridViewJournalItems.Visible = True
            DataGridViewDjOiItems.Visible = False
            If tlpDisbursement.GetCellPosition(DataGridViewJournalItems) <> New TableLayoutPanelCellPosition(0, 7) Then
                tlpDisbursement.SetColumnSpan(DataGridViewJournalItems, 12)
                tlpDisbursement.SetColumnSpan(DataGridViewDjOiItems, 1)
                GlobalSubs.SwapPosition(DataGridViewJournalItems, DataGridViewDjOiItems)
            End If
            cboDiscountAccountIdNo.Enabled = False
        End Sub

        Private Sub ShowOpenInvoicesDataGrid()
            DataGridViewJournalItems.Visible = False
            DataGridViewDjOiItems.Visible = True
            If tlpDisbursement.GetCellPosition(DataGridViewDjOiItems) <> New TableLayoutPanelCellPosition(0, 7) Then
                tlpDisbursement.SetColumnSpan(DataGridViewJournalItems, 1)
                tlpDisbursement.SetColumnSpan(DataGridViewDjOiItems, 12)
                GlobalSubs.SwapPosition(DataGridViewJournalItems, DataGridViewDjOiItems)
            End If
            cboDiscountAccountIdNo.Enabled = True
        End Sub

        Private Sub ShowPayee(paymentTypeEnum)
            If paymentTypeEnum <> PaymentTypeSelection.Others Then
                cboPayeeIdNo.Visible = True
                txtPayeeName.Visible = False
                tlpDisbursement.SetCellPosition(txtPayeeName, New TableLayoutPanelCellPosition(6, 8))
                tlpDisbursement.SetCellPosition(cboPayeeIdNo, New TableLayoutPanelCellPosition(5, 1))
            Else
                cboPayeeIdNo.Visible = False
                txtPayeeName.Visible = True
                tlpDisbursement.SetCellPosition(cboPayeeIdNo, New TableLayoutPanelCellPosition(12, 8))
                tlpDisbursement.SetCellPosition(txtPayeeName, New TableLayoutPanelCellPosition(5, 1))
            End If
        End Sub

        Private Sub TxtAmount_ValueChanged(sender As Object, e As EventArgs) Handles txtAmount.Validated
            If CodeToEnum(Of PaymentTypeSelection)(PaymentType) = PaymentTypeSelection.AccountsPayable Then
                UpdateOiTotals()
            End If
        End Sub

        Private Sub TxtNotes_Leave(sender As Object, e As EventArgs)
            If DataGridViewJournalItems.Visible Then
                If DataGridViewJournalItems IsNot Nothing Then
                    DataGridViewJournalItems.Focus()
                    If DataGridViewJournalItems.CurrentCell IsNot Nothing Then
                        DataGridViewJournalItems.CurrentCell = DataGridViewJournalItems(DataGridViewJournalItems.Columns("dgvRevCostCenterIdNo").Index(), 0)
                    End If
                End If
            Else
                If DataGridViewDjOiItems IsNot Nothing Then
                    If DataGridViewDjOiItems.CurrentCell IsNot Nothing Then
                        DataGridViewDjOiItems.Focus()
                        DataGridViewDjOiItems.CurrentCell = DataGridViewDjOiItems(DataGridViewDjOiItems.Columns("dgvAmount").Index(), 0)
                    End If
                End If
            End If
        End Sub

        Private Sub UpdateFirstLine()
            If PresenterObj.EditMode Or PresenterObj.AddMode Then
                If bsJournalItems IsNot Nothing Then
                    If bsJournalItems.Count() = 0 Then
                        bsJournalItems.Add(New JournalItemView With {
                                              .JournalIdNo = IdNo,
                                              .Sequence = 1,
                                              .AccountIdNo = AccountIdNo,
                                              .Credit = Amount,
                                              .Debit = 0,
                                              .RevCostCenterIdNo = 0})
                    Else
                        For Each item In bsJournalItems
                            item.JournalIdNo = IdNo
                            item.Sequence = 1
                            If cboAccountIdNo.Text Is Nothing Or cboAccountIdNo.Text = "" Then
                                item.AccountIdNo = Nothing
                            Else
                                item.AccountIdNo = AccountIdNo
                            End If
                            item.Credit = Amount
                            item.Debit = 0
                            item.RevCostCenterIdNo = 0
                            DataGridViewJournalItems.Refresh()
                            Exit For
                        Next
                    End If
                End If
                'BindJournalItem()
                UpdateJiTotals()
            End If
        End Sub

        Private Sub UpdateJiTotals()
            If _jiFooter IsNot Nothing Then
                _jiFooter.CalculateTotals()
                TotalDebits = _jiFooter.Value("dgvDebit")
                TotalCredits = _jiFooter.Value("dgvCredit")
            End If
        End Sub

        Private Sub UpdateOiTotals()
            If PaymentType = EnumToCode(PaymentTypeSelection.AccountsPayable) Then
                If _apFooter IsNot Nothing Then
                    _apFooter.CalculateTotals()
                    Applied = _apFooter.Value("dgvAmount")
                    DiscountTaken = _apFooter.Value("dgvDiscountTaken")
                    UnApplied = Amount - Applied
                End If
            Else
                Applied = Amount
                UnApplied = 0
            End If
        End Sub

        Private Sub UpdateTotals()
            UpdateJiTotals()
            UpdateOiTotals()
        End Sub

        Private Sub UpdateTotalVatAmount()
            Dim tVatAmount As Decimal = 0
            For Each row In DataGridViewJournalItems.Rows
                If PresenterObj.IsInputVatAccount(row.Cells("dgvAccountIdNo").Value) Then
                    tVatAmount = tVatAmount + row.Cells("dgvDebit").Value - row.Cells("dgvCredit").Value
                End If
            Next
            VatAmount = tVatAmount
        End Sub

        Private Sub DataGridViewJournalItems_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs)
            UpdateTotals()
            UpdateTotalVatAmount()
        End Sub

        Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnAutoApply.ClickButtonArea
            PresenterObj.AutoApplyAmount()
            DataGridViewDjOiItems.Refresh()
            UpdateOiTotals()
        End Sub

        Private Sub DataGridViewJournalItems_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewJournalItems.CellContentClick

        End Sub

        Private Sub tlpDisbursement_Paint(sender As Object, e As PaintEventArgs) Handles tlpDisbursement.Paint

        End Sub

        Private Sub btnPrintCheck_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnPrintCheck.ClickButtonArea
            PresenterObj.PrintCheck()
        End Sub

    End Class

End Namespace