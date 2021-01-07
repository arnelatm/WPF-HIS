Imports System.ComponentModel
Imports System.Globalization
Imports Sytem.Windows.Input
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events
Imports Microsoft.VisualBasic.Devices

Namespace PresentationLayer.Views.Forms

    Public Class DisbursementJournalEntry
        Implements IDisbursementJournalView, ISubscriber(Of BeforeAssignment)

        Public TxtTotalCredits As Decimal
        Public TxtTotalDebits As Decimal

        Private Property MyPresenter As DisbursementJournalPresenter
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
                MyPresenter = New DisbursementJournalPresenter(Me, "PcJournal")
                Me.Text = Messaging.TranslateCaption("Petty Cash Disbursement Journal")
                btnPrintCheck.Visible = False
            ElseIf tableName = "CdJournal" Then
                MyPresenter = New DisbursementJournalPresenter(Me, "CdJournal")
                Me.Text = Messaging.TranslateCaption("Cash Disbursement Journal")
                btnPrintCheck.Visible = False
            Else
                MyPresenter = New DisbursementJournalPresenter(Me, "CkJournal")
                MyPresenter.JournalCode = "CK"
                Me.Text = Messaging.TranslateCaption("Check Disbursement Journal")
                btnPrintCheck.Visible = True
            End If
            PresenterObj = MyPresenter
            txtJournalCode.Text = MyPresenter.JournalCode
            SortOrderKey = "IdNo"
            FirstControl = cboPaymentType
            _nfi.NumberDecimalDigits = 2
            Ea = MyPresenter.Ea
            Ea.SubscribeEvent(Me)
        End Sub

        Private Sub JournalItemBs_AddingNew(ByVal sender As Object, ByVal e As AddingNewEventArgs) Handles bsJournalItems.AddingNew
            e.NewObject = New JournalItemView
            'Me.JournalItems.Add(New JournalItemView)
            'e.NewObject = New JournalItemView
            '' move to new record
            'bsJournalItems.MoveLast()
        End Sub

        Private ReadOnly Property OpenInvoiceMode As Boolean
            Get
                Dim paymentTypeEnum = CodeToEnum(Of PaymentTypeSelection)(cboPaymentType.SelectedValue)
                If paymentTypeEnum = PaymentTypeSelection.AccountsPayable Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property

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
                bsJournalItems.ResetBindings(False)
                'BindJournalItem()
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
                'bsJournalItems.ResetBindings(True)
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
            _accountsByCode = MyPresenter.GetDetailAccountList()
            _revCostCenterByCode = MyPresenter.GetLookup("RevCostCenter")
            cboPaymentType.DataSource = MyPresenter.MakeEnumComboList(Of PaymentTypeSelection)
            If MainTableName = "CdJournal" Then
                cboAccountIdNo.DataSource = MyPresenter.GetAccountTypesList(EnumToCode(SpecialAccountSelection.Bank) + "," + EnumToCode(SpecialAccountSelection.Cash) + "," + EnumToCode(SpecialAccountSelection.CheckingAccount))
            ElseIf MainTableName = "PcJournal" Then
                cboAccountIdNo.DataSource = MyPresenter.GetAccountTypesList(EnumToCode(SpecialAccountSelection.PettyCashAccount))
            Else
                cboAccountIdNo.DataSource = MyPresenter.GetAccountTypesList(EnumToCode(SpecialAccountSelection.CheckingAccount))
            End If
            cboDiscountAccountIdNo.DataSource = MyPresenter.GetAccountTypesList("PD")
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
            UpdateLayout()
            UpdateTotals()
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

            If MyPresenter.CdAccountCount = 1 Then
                cboAccountIdNo.DisplayOnly = True
                cboAccountIdNo.TabStop = False
            End If
            If MainTableName <> "CkJournal" Then
                dtpCheckDate.Visible = False
                lblCheckDate.Visible = False
                lblCheckNumber.Visible = False
                txtCheckNumber.Visible = False
            Else
                dtpCheckDate.Visible = True
                lblCheckDate.Visible = True
                lblCheckNumber.Visible = True
                txtCheckNumber.Visible = True
            End If
            If MyPresenter.CdAccountCount = 0 Then
                If txtJournalCode.Text = "PC" Then
                    Messaging.ShowParametrizedMessage(True, "MsgNoSpecialAccount", {"specialAccountName", "Petty Cash"})
                ElseIf txtJournalCode.Text = "CD" Then
                    Messaging.ShowParametrizedMessage(True, "MsgNoSpecialAccount", {"specialAccountName", "Cash"})
                Else
                    Messaging.ShowParametrizedMessage(True, "MsgNoSpecialAccount", {"specialAccountName", "Checking Account"})
                End If
                MyPresenter.GoQuit()
            End If
            BindDjOiItem()
            BindJournalItem()
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

        Public Overloads Sub Dispose()
            Close()
        End Sub

        Private Sub CboPayeeIdNo_ValueChanged(sender As Object, e As EventArgs) Handles cboPayeeIdNo.SelectionChangeCommitted, cboPayeeIdNo.Validated
            If OpenInvoiceMode Then
                UpdateOpenInvoicesDisplay()
            Else
                If CodeToEnum(Of PaymentTypeSelection)(PaymentType) = PaymentTypeSelection.Supplier Then
                    UpdateVatNumber()
                Else
                    VatNumber = ""
                End If
            End If
        End Sub

        Private Sub UpdateOpenInvoicesDisplay()
            If OpenInvoiceMode Then
                bsDjOiItems.Clear()
                UpdateOiTotals()
                MyPresenter.AddSupplierOpenInvoices()
                BindDjOiItem()
                UpdateVatNumber()
            End If
        End Sub

        Private Sub TxtAmount_Validated(sender As Object, e As EventArgs) Handles txtAmount.Validated
            If OpenInvoiceMode Then
                UpdateOiTotals()
            End If
            UpdateFirstLine()
        End Sub

        Private Sub CboPaymentType_ValueChanged(sender As Object, e As EventArgs) Handles cboPaymentType.SelectionChangeCommitted, cboPaymentType.Validated
            SetPayeeDataSource(PaymentType)
            If OpenInvoiceMode Then
                If cboPayeeIdNo.SelectedIndex <> cboPayeeIdNo.PreviousSelectedIndex Then
                    UpdateOpenInvoicesDisplay()
                End If
                If cboPayeeIdNo.SelectedIndex = -1 Then
                    bsDjOiItems.Clear()
                End If
            Else
                cboPayeeIdNo.SelectedIndex = -1
            End If
            UpdateFirstLine()
            UpdateLayout()
        End Sub

        Private Sub DataGridViewJournalItems_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridViewJournalItems.UserDeletedRow
            UpdateTotals()
            UpdateTotalVatAmount()
        End Sub

        Private Sub AccountIdNo_Changed(sender As Object, e As EventArgs) Handles cboAccountIdNo.SelectionChangeCommitted, cboAccountIdNo.Validated
            UpdateFirstLine()
        End Sub

        Private Sub OnCellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridViewJournalItems.CellBeginEdit
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

        Private Sub OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewJournalItems.CellEndEdit
            With DataGridViewJournalItems
                Dim nIndex = DataGridViewJournalItems.CurrentRow.Index
                Select Case .CurrentCell.OwningColumn.Name.ToLower()
                    Case $"dgvaccountidno"
                        Dim newValue = DirectCast(DataGridViewJournalItems.CurrentCell, CaDgvComboboxCell).CellEditingControl.GetValue()
                        If nIndex + 1 <= DataGridViewJournalItems.RowCount() Then
                            If nIndex < JournalItems.Count() Then
                                bsJournalItems(nIndex).AccountIdNo = newValue
                                Dim account As AccountModel
                                account = MyPresenter.GetAccount(newValue)
                                With DataGridViewJournalItems.CurrentRow
                                    Dim currentVatAmount As Decimal
                                    If MyPresenter.IsInputVatAccount(newValue) Then
                                        currentVatAmount = .Cells("dgvDebit").Value - .Cells("dgvCredit").Value
                                    Else
                                        currentVatAmount = 0
                                    End If
                                    .Cells("ItemVatAmount").Value = currentVatAmount
                                    .Cells("SpecialAccount").Value = account.SpecialAccount
                                    .Cells("PayeeType").Value = account.PayeeType
                                End With
                                UpdateTotalVatAmount()
                            End If
                        End If
                    Case $"dgvdebit"
                        Dim newValue = .CurrentCell.Value
                        If nIndex + 1 <= DataGridViewJournalItems.RowCount() And nIndex < bsJournalItems.Count() Then
                            If newValue > 0 Then
                                bsJournalItems(nIndex).Credit = 0
                                bsJournalItems(nIndex).Credit = 0
                            ElseIf newValue < 0 Then
                                bsJournalItems(nIndex).Credit = newValue * -1
                                bsJournalItems(nIndex).Debit = 0
                            End If
                            If MyPresenter.IsInputVatAccount(.CurrentRow.Cells("dgvAccountIdNo").Value) Then
                                .CurrentRow.Cells("ItemVatAmount").Value = .CurrentRow.Cells("dgvDebit").Value - .CurrentRow.Cells("dgvCredit").Value
                            End If
                        End If
                        UpdateJiTotals()
                        UpdateTotalVatAmount()
                        SendKeys.Send("{TAB}")
                    Case $"dgvcredit"
                        Dim newValue = .CurrentCell.Value
                        If nIndex + 1 <= DataGridViewJournalItems.RowCount() And nIndex < bsJournalItems.Count() Then
                            If newValue > 0 Then
                                bsJournalItems(nIndex).Debit = 0
                            ElseIf newValue < 0 Then
                                bsJournalItems(nIndex).Debit = newValue * -1
                                bsJournalItems(nIndex).Credit = 0
                            End If
                            If MyPresenter.IsInputVatAccount(.CurrentRow.Cells("dgvAccountIdNo").Value) Then
                                .CurrentRow.Cells("ItemVatAmount").Value = .CurrentRow.Cells("dgvDebit").Value - .CurrentRow.Cells("dgvCredit").Value
                            End If
                        End If
                        UpdateJiTotals()
                        UpdateTotalVatAmount()
                    Case $"dgvnotes"
                        SendKeys.Send("{DOWN}")
                End Select
            End With
        End Sub

        Private Sub DjOiItemDgv_OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewDjOiItems.CellEndEdit
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

        Private Sub TxtNotes_Leave(sender As Object, e As EventArgs) Handles txtNotes.Leave
            If OpenInvoiceMode Then
                If DataGridViewDjOiItems IsNot Nothing AndAlso DataGridViewDjOiItems.Visible Then
                    If DataGridViewDjOiItems.CurrentCell Is Nothing Then
                        DataGridViewDjOiItems.Focus()
                        If DataGridViewDjOiItems.CurrentCell IsNot Nothing Then
                            ' if after focus and currentcell is not empty
                            DataGridViewDjOiItems.CurrentCell = DataGridViewDjOiItems(DataGridViewDjOiItems.Columns("dgvAmount").Index(), 0)
                        End If
                    End If
                End If
            Else
                If DataGridViewJournalItems IsNot Nothing AndAlso DataGridViewJournalItems.Visible Then
                    If DataGridViewJournalItems.CurrentCell Is Nothing Then
                        DataGridViewJournalItems.Focus()
                        If DataGridViewJournalItems.CurrentCell Is Nothing Then
                            ' if after focus and currentcell is not empty
                            DataGridViewJournalItems.CurrentCell = DataGridViewJournalItems(DataGridViewJournalItems.Columns("dgvRevCostCenterIdNo").Index(), 0)
                        End If
                    End If
                End If
            End If
        End Sub

        Private Sub UpdateTotals()
            If OpenInvoiceMode Then
                UpdateJiTotals()
            Else
                UpdateOiTotals()
            End If
        End Sub

        Private Sub UpdateOiTotals()
            If _apFooter IsNot Nothing Then
                _apFooter.CalculateTotals()
                Applied = _apFooter.Value("dgvAmount")
                DiscountTaken = _apFooter.Value("dgvDiscountTaken")
                UnApplied = Amount - Applied
            End If
        End Sub

        Private Sub UpdateJiTotals()
            If _jiFooter IsNot Nothing Then
                _jiFooter.CalculateTotals()
                TotalDebits = _jiFooter.Value("dgvDebit")
                TotalCredits = _jiFooter.Value("dgvCredit")
            End If
            Applied = Amount
            UnApplied = 0
        End Sub

        Private Sub UpdateTotalVatAmount()
            Dim tVatAmount As Decimal = 0
            For Each row In DataGridViewJournalItems.Rows
                tVatAmount += row.cells("ItemVatAmount").Value
            Next
            VatAmount = tVatAmount
        End Sub

        Private Sub UpdateVatNumber()
            If cboPayeeIdNo.Text IsNot Nothing Then
                VatNumber = MyPresenter.GetSupplierVatNumber(cboPayeeIdNo.SelectedValue)
            Else
                VatNumber = ""
            End If
        End Sub

        Private Sub UserDeletingRow(ByVal sender As Object, ByVal e As DataGridViewRowCancelEventArgs) Handles DataGridViewJournalItems.UserDeletingRow
            Dim cdJournalRow As DataGridViewRow = DataGridViewJournalItems.Rows(0)
            If DataGridViewJournalItems.SelectedRows.Contains(cdJournalRow) Then
                ' Do not allow the user to delete the first row.
                Messaging.Show(True, "MsgFirstRowDeletionNotAllowed", "Deletion of the first row Is Not allowed!", "Delete Error")
                ' Cancel the deletion
                e.Cancel = True
            ElseIf MyPresenter.EditMode Then
                Dim jiIdNo As Integer
                jiIdNo = DataGridViewJournalItems.CurrentRow.Cells("dgvIdNo").Value
            End If
        End Sub

        Private Sub btnPrintCheck_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnPrintCheck.ClickButtonArea
            MyPresenter.PrintCheck()
        End Sub

        Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnAutoApply.ClickButtonArea
            MyPresenter.AutoApplyAmount()
            DataGridViewDjOiItems.Refresh()
            UpdateOiTotals()
        End Sub

        Private Sub BtnViewGL_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnViewGL.ClickButtonArea
            If _viewGl Then
                _viewGl = False
                btnViewGL.Text = Messaging.TranslateCaption("View Journal Entry")
                ShowOpenInvoicesDataGrid()
            Else
                _viewGl = True
                btnViewGL.Text = Messaging.TranslateCaption("Hide Journal Entry")
                ShowJournalItemDataGrid()
            End If
        End Sub

        Private Sub UpdateLayout()
            SuspendLayout()
            If OpenInvoiceMode Then
                ShowOpenInvoicesDataGrid()
            Else
                ShowJournalItemDataGrid()
                BindJournalItem()
                Applied = Amount
                UnApplied = 0
                DiscountTaken = 0
            End If
            ShowPayee()
            ResumeLayout()
        End Sub

        Private Sub ShowPayee()
            Dim paymentTypeEnum = CodeToEnum(Of PaymentTypeSelection)(cboPaymentType.SelectedValue)
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

        Protected Overrides Sub InputsTurnedOff()
            If OpenInvoiceMode Then
                btnViewGL.Visible = True
            Else
                btnViewGL.Visible = False
            End If
            btnAutoApply.Visible = False
        End Sub

        Protected Overrides Sub InputsTurnedOn()
            'BindDjOiItem()
            bsJournalItems.ResetBindings(False)
            btnViewGL.Visible = False
            If OpenInvoiceMode Then
                btnAutoApply.Visible = True
            Else
                btnAutoApply.Visible = False
            End If
            MyPresenter.AddSupplierOpenInvoices()
        End Sub

        Private Sub ShowJournalItemDataGrid()
            UpdateFirstLine()
            UpdateTotals()
            DataGridViewJournalItems.Visible = True
            DataGridViewDjOiItems.Visible = False
            If tlpDisbursement.GetCellPosition(DataGridViewJournalItems) <> New TableLayoutPanelCellPosition(0, 7) Then
                tlpDisbursement.SetColumnSpan(DataGridViewJournalItems, 12)
                tlpDisbursement.SetColumnSpan(DataGridViewDjOiItems, 1)
                GlobalSubs.SwapPosition(DataGridViewJournalItems, DataGridViewDjOiItems)
            End If
            DataGridViewJournalItems.DataSource = bsJournalItems
            DataGridViewJournalItems.Refresh()
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

        Private Sub SetPayeeDataSource(ByVal cPaymentType As String)
            Dim cbDataSource = Nothing
            Dim curValue As Int32? = cboPayeeIdNo.SelectedValue
            cboPayeeIdNo.DataSource = cbDataSource
            If OpenInvoiceMode Then
                cbDataSource = MyPresenter.GetLookup("Supplier")
            Else
                Dim paymentTypeEnum = CodeToEnum(Of PaymentTypeSelection)(cPaymentType)
                If paymentTypeEnum = PaymentTypeSelection.Supplier Then
                    cbDataSource = MyPresenter.GetLookup("Supplier")
                ElseIf paymentTypeEnum = PaymentTypeSelection.Employee Then
                    cbDataSource = MyPresenter.GetLookup("Employee")
                ElseIf paymentTypeEnum = PaymentTypeSelection.CustomerRefund Then
                    cbDataSource = MyPresenter.GetLookup("Customer")
                End If
            End If
            cboPayeeIdNo.DataSource = cbDataSource
            If curValue IsNot Nothing Then
                cboPayeeIdNo.SelectedValue = curValue
            Else
                cboPayeeIdNo.SelectedValue = -1
            End If
        End Sub

        Private Sub UpdateFirstLine()
            MyPresenter.UpdateFirstLine()
            bsJournalItems.ResetBindings(True)
        End Sub

    End Class

End Namespace