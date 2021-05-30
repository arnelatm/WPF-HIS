Imports System.ComponentModel
Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
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

        Private Property MyPresenter As DisbursementJournalPresenter
        Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat
        Private _accountsByCode
        Private _apFooter As DgvFooter
        Private _jiFooter As DgvFooter
        Private _journalItems As List(Of IJournalItemView)
        Private _djOiItems As List(Of DjOiItemView)
        Private _revCostCentersByCode
        Private _defaultAccount As Int16
        Private _bankTransfer As Boolean

        Public Sub New(ByVal tableName As String)
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            EnableDoubleBuff(tlpDisbursement)
            ' Add any initialization after the InitializeComponent() call.
            MainTableName = tableName
            SortOrderKey = "IdNo"
            If tableName = "CdJournal" Then
                ViewDisplayName = "CdJournalEntry"
                MyPresenter = New DisbursementJournalPresenter(Me, "CdJournal")
                DisplayPrintCheckButton(PayType)
                Me.Text = Messaging.TranslateCaption("Cash Disbursement Journal")
            Else
                ViewDisplayName = "PcJournalEntry"
                'tableName = "PcJournal"
                MyPresenter = New DisbursementJournalPresenter(Me, "PcJournal")
                Me.Text = Messaging.TranslateCaption("Petty Cash Disbursement Journal")
                btnPrintCheck.Visible = False
                btnPrintPcReplenishment.Visible = False
                cboPayType.Visible = False
                lblPayType.Visible = False
                txtCheckNumber.Visible = False
                dtpCheckDate.Visible = False
            End If
            PresenterObj = MyPresenter
            _defaultAccount = MyPresenter.DefaultDisbursementAccount
            txtJournalCode.Text = MyPresenter.JournalCode
            FirstControl = cboPaymentType
            '_nfi.NumberDecimalDigits = 2
            Height = 655
            Ea = MyPresenter.Ea
            Ea.SubscribeEvent(Me)

        End Sub

        Private Sub JournalItemBs_AddingNew(ByVal sender As Object, ByVal e As AddingNewEventArgs) Handles bsJournalItems.AddingNew
            e.NewObject = New JournalItemView
            ' work arround for error on datagrid entry on lastrow please do not remove.
            ' The reason it works Is because On a DataGridView where AllowUserToAddRows Is True,
            ' it adds an empty row at the end of its rows which if bound to a list creates a null element at the end of the list.
            ' The code removes that element And then the AddNew in the BindingList will trigger the DataGridView to add it again
            If DataGridViewJournalItems.Rows.Count = bsJournalItems.Count Then
                bsJournalItems.RemoveAt(bsJournalItems.Count - 1)
            End If
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

        Public Property PcClosed As Boolean Implements IDisbursementJournalView.PcClosed
            Get
                Return chkPcClosed.Checked
            End Get
            Set
                chkPcClosed.Checked = Value
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

        Public Property PayType As String Implements IDisbursementJournalView.PayType
            Get
                Return cboPayType.GetValue()
            End Get
            Set
                cboPayType.SetValue(Value)
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
                'bsJournalItems.ResetBindings(True)
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

        Public Property Approved As Boolean Implements IDisbursementJournalView.Approved
            Get
                Return chkApproved.Checked
            End Get
            Set
                chkApproved.Checked = Value
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
            _revCostCentersByCode = MyPresenter.GetLookup("RevCostCenter")
            cboPaymentType.DataSource = MyPresenter.MakeEnumComboList(Of PaymentTypeSelection)
            cboPayType.DataSource = MyPresenter.MakeEnumComboList(Of PayTypeSelection)
            If MainTableName = "CdJournal" Then
                If _bankTransfer Then
                    cboAccountIdNo.DataSource = MyPresenter.GetAccountTypesList(EnumToCode(SpecialAccountSelection.Bank) + "," + EnumToCode(SpecialAccountSelection.CheckingAccount))
                Else
                    cboAccountIdNo.DataSource = MyPresenter.GetAccountTypesList(EnumToCode(SpecialAccountSelection.Bank) + "," + EnumToCode(SpecialAccountSelection.Cash) + "," + EnumToCode(SpecialAccountSelection.CheckingAccount))
                End If
            ElseIf MainTableName = "PcJournal" Then
                cboAccountIdNo.DataSource = MyPresenter.GetAccountTypesList(EnumToCode(SpecialAccountSelection.PettyCashAccount))
            Else
                cboAccountIdNo.DataSource = MyPresenter.GetAccountTypesList(EnumToCode(SpecialAccountSelection.CheckingAccount))
            End If
            cboDiscountAccountIdNo.DataSource = MyPresenter.GetAccountTypesList("PD")
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
         {"DateCreated", dtpDateCreated},
         {"PayType", cboPayType},
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
            UpdateDisplay()
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
            If cboAccountIdNo.SelectedValue Is Nothing Or cboAccountIdNo.SelectedValue <= 0 Then
                cboAccountIdNo.SelectedValue = _defaultAccount
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
            DisplayCheckInfo()
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
                '.Refresh()
                .AutoGenerateColumns = False
                .DataSource = bsJournalItems
                '.Refresh()
            End With
            With DataGridViewJournalItems.Columns
                dgvSequence.DisplayOnly = True
                dgvAccountIdNo.DataSource = _accountsByCode
                dgvAccountIdNo.DisplayMember = "Name"
                dgvAccountIdNo.ValueMember = "IdNo"
                'dgvAccountIdNo.AutoComplete = AutoCompleteMode.SuggestAppend
                dgvAccountIdNo.DisplayStyleForCurrentCellOnly = True
                'dgvAccountIdNo.AutoComplete = True
                dgvRevCostCenterIdNo.DataSource = _revCostCentersByCode
                dgvRevCostCenterIdNo.DisplayMember = "Name"
                dgvRevCostCenterIdNo.ValueMember = "idNo"
                'dgvRevCostCenterIdNo.AutoComplete = AutoCompleteMode.SuggestAppend
                dgvRevCostCenterIdNo.DisplayStyleForCurrentCellOnly = True
                'dgvRevCostCenterIdNo.AutoComplete = True
            End With
            ResumeLayout()
        End Sub

        Public Overloads Sub Dispose()
            Close()
        End Sub

        Private Sub UpdateOpenInvoicesDisplay()
            If OpenInvoiceMode Then
                If MyPresenter.AddMode Or cboPayeeIdNo.ValueChanged() Then
                    DjOiItems.Clear()
                End If
                bsDjOiItems.DataSource = MyPresenter.GetSupplierOpenInvoices(DjOiItems)
                bsDjOiItems.ResetBindings(True)
                UpdateOiTotals()
                'UpdateVatNumber()
            End If
        End Sub

        Private Sub TxtAmount_Validated(sender As Object, e As EventArgs) Handles txtAmount.Validated
            If OpenInvoiceMode Then
                UpdateOiTotals()
            End If
            UpdateFirstLine()
        End Sub

        Private Sub CboPayeeIdNo_ValueChanged(sender As Object, e As EventArgs) Handles cboPayeeIdNo.Validated, cboPayeeIdNo.SelectionChangeCommitted
            If OpenInvoiceMode Then
                UpdateOpenInvoicesDisplay()
            End If
            If CodeToEnum(Of PaymentTypeSelection)(PaymentType) = PaymentTypeSelection.Supplier Or CodeToEnum(Of PaymentTypeSelection)(PaymentType) = PaymentTypeSelection.AccountsPayable Then
                MyPresenter.SetSupplierVatNumber(VatNumber, PayeeIdNo, True)
            Else
                VatNumber = ""
            End If
        End Sub

        Private Sub CboPaymentType_ValueChanged(sender As Object, e As EventArgs) Handles cboPaymentType.Validated, cboPaymentType.SelectionChangeCommitted
            SetPayeeDataSource(PaymentType)
            If OpenInvoiceMode Then
                UpdateOpenInvoicesDisplay()
                If cboPayeeIdNo.SelectedIndex = -1 Then
                    bsDjOiItems.Clear()
                End If
            Else
                cboPayeeIdNo.SelectedIndex = -1
            End If
            UpdateFirstLine()
            UpdateDisplay()
        End Sub

        Private Sub CboPayType_ValueChanged(sender As Object, e As EventArgs) Handles cboPayType.Validated, cboPayType.SelectionChangeCommitted
            DisplayPrintCheckButton(cboPayType.SelectedValue)
            DisplayCheckInfo()
        End Sub

        Private Sub DisplayCheckInfo()
            If MainTableName = "CdJournal" AndAlso cboPayType.SelectedValue = EnumToCode(PayTypeSelection.CheckPayment) Then
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

        Private Sub CboAccountIdNo_Changed(sender As Object, e As EventArgs) Handles cboAccountIdNo.Validated, cboAccountIdNo.SelectionChangeCommitted
            UpdateFirstLine()
        End Sub

        Private Sub TxtNotes_Leave(sender As Object, e As EventArgs) Handles txtNotes.Leave
            If OpenInvoiceMode Then
                MoveToGridView(DataGridViewDjOiItems, "dgvAmount")
            Else
                MoveToGridView(DataGridViewJournalItems, "dgvRevCostCenterIdNo")
            End If
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
            With DataGridViewJournalItems
                If .CurrentRow IsNot Nothing Then
                    Dim nIndex = .CurrentRow.Index
                    Select Case .CurrentCell.OwningColumn.Name.ToLower()
                        Case $"dgvaccountidno"
                            If DirectCast(DataGridViewJournalItems.CurrentCell, CDgvComboBoxCell).CellEditingControl IsNot Nothing Then
                                'Dim accountId = DirectCast(DataGridViewJournalItems.CurrentCell, CaDgvComboboxCell).CellEditingControl.GetValue()
                                Dim accountId = DirectCast(DataGridViewJournalItems.CurrentCell, CDgvComboBoxCell).CellEditingControl.GetValue()
                                If DataGridViewJournalItems.CurrentRow.Index = DataGridViewJournalItems.NewRowIndex Then
                                    bsJournalItems.AddNew()
                                    JournalItems(nIndex).AccountIdNo = accountId
                                    ' adding a new row to the bindingsource adds a new empty row at the end with null values
                                    ' therefore there is a need to remove that row because it causes errors when moving to that empty row
                                    bsJournalItems.RemoveAt(bsJournalItems.Count - 1)
                                End If
                                If JournalItems.Count() - 1 <= nIndex Then
                                    MyPresenter.MakePayTypeAndSpecialAccount(JournalItems(nIndex), accountId)
                                    UpdateInputVatAmount()
                                    bsJournalItems.ResetItem(nIndex)
                                End If
                                DataGridViewJournalItems.Refresh()
                            End If
                        Case $"dgvdebit"
                            MyPresenter.MakeDebitAmount(JournalItems(nIndex), .CurrentCell.Value)
                            UpdateJiTotals()
                            UpdateInputVatAmount()
                            bsJournalItems.ResetItem(nIndex)
                            SendKeys.Send("{TAB}")
                        Case $"dgvcredit"
                            MyPresenter.MakeCreditAmount(JournalItems(nIndex), .CurrentCell.Value)
                            UpdateJiTotals()
                            UpdateInputVatAmount()
                            bsJournalItems.ResetItem(nIndex)
                        Case $"dgvnotes"
                            SendKeys.Send("{DOWN}")
                    End Select
                End If
            End With
        End Sub

        Private Sub DjOiItemDgv_OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewDjOiItems.CellEndEdit
            With DataGridViewDjOiItems
                If .CurrentRow IsNot Nothing Then
                    Select Case .CurrentCell.OwningColumn.Name.ToLower()
                        Case $"dgvamount"
                            Dim selectedRow As DjOiItemView
                            Dim amt = .CurrentCell.Value
                            selectedRow = DataGridViewDjOiItems.Rows(.CurrentCell.RowIndex).DataBoundItem
                            selectedRow.Balance = selectedRow.PreviousBalance - amt - selectedRow.DiscountTaken
                            UpdateOiTotals()
                        Case $"dgvdiscounttaken"
                            Dim selectedRow As DjOiItemView
                            Dim amt = .CurrentCell.Value
                            selectedRow = DataGridViewDjOiItems.Rows(.CurrentCell.RowIndex).DataBoundItem
                            selectedRow.Balance = selectedRow.PreviousBalance - selectedRow.Amount - amt
                            UpdateOiTotals()
                        Case $"dgvbalance"
                            SendKeys.Send("{DOWN}")
                    End Select
                End If
            End With
        End Sub

        Private Sub UpdateInputVatAmount()
            VatAmount = MyPresenter.UpdateInputVatAmount(JournalItems)
        End Sub

        Private Sub UpdateOutputVatAmount()
            VatAmount = MyPresenter.UpdateOutputVatAmount(JournalItems)
        End Sub

        Private Sub DataGridViewJournalItems_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridViewJournalItems.UserDeletedRow
            UpdateTotals()
            Dim payeeTypeEnum = CodeToEnum(Of PaymentTypeSelection)(cboPaymentType.SelectedIndex)
            If payeeTypeEnum = PaymentTypeSelection.AccountsPayable Or payeeTypeEnum = PaymentTypeSelection.Supplier Then
                UpdateInputVatAmount()
            ElseIf payeeTypeEnum = PaymentTypeSelection.CustomerRefund Then
                UpdateOutputVatAmount()
            End If
        End Sub

        Private Sub UpdateTotals()
            If OpenInvoiceMode Then
                UpdateOiTotals()
            Else
                UpdateJiTotals()
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
            DataGridViewJournalItems.Refresh()
        End Sub

        'Private Sub UpdateVatNumber()
        '    If cboPayeeIdNo.Text IsNot Nothing Then
        '        VatNumber = MyPresenter.GetSupplierVatNumber(cboPayeeIdNo.SelectedValue)
        '    Else
        '        VatNumber = ""
        '    End Ifbtn
        'End Sub

        Private Sub UserDeletingRow(ByVal sender As Object, ByVal e As DataGridViewRowCancelEventArgs) Handles DataGridViewJournalItems.UserDeletingRow
            Dim cdJournalRow As DataGridViewRow = DataGridViewJournalItems.Rows(0)
            If DataGridViewJournalItems.SelectedRows.Contains(cdJournalRow) Then
                ' Do not allow the user to delete the first row.
                Messaging.Show(True, "MsgFirstRowDeletionNotAllowed", "Deletion of the first row Is Not allowed!", "Delete Error")
                ' Cancel the deletion
                e.Cancel = True
            End If
        End Sub

        Private Sub btnPrintCheck_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnPrintCheck.ClickButtonArea
            MyPresenter.PrintCheck()
        End Sub

        Private Sub btnPrintPcReplenishment_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnPrintPcReplenishment.ClickButtonArea
            MyPresenter.PrintPcReplenishment()
        End Sub

        Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnAutoApply.ClickButtonArea
            MyPresenter.AutoApplyAmount()
            DataGridViewDjOiItems.Refresh()
            UpdateOiTotals()
        End Sub

        Private Sub BtnViewGL_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnViewGL.ClickButtonArea
            If DataGridViewJournalItems.Visible Then
                btnViewGL.Text = Messaging.TranslateCaption("View Journal Entry")
                ShowOpenInvoicesDataGrid()
            Else
                btnViewGL.Text = Messaging.TranslateCaption("Hide Journal Entry")
                ShowJournalItemDataGrid()
            End If
        End Sub

        Private Sub UpdateDisplay()
            SuspendLayout()
            If OpenInvoiceMode Then
                ShowOpenInvoicesDataGrid()
                cboDiscountAccountIdNo.Enabled = True
            Else
                ShowJournalItemDataGrid()
                btnViewGL.Visible = False
                cboDiscountAccountIdNo.Enabled = False
                BindJournalItem()
                Applied = Amount
                UnApplied = 0
                DiscountTaken = 0
            End If
            ShowPayee()
            UpdateTotals()
            If MyPresenter.EditMode Or MyPresenter.AddMode Then
                If OpenInvoiceMode Then
                    btnAutoApply.Visible = True
                Else
                    btnAutoApply.Visible = False
                End If
            End If
            DisplayPrintCheckButton(PayType)
            DisplayCheckInfo()
            ResumeLayout()
        End Sub

        Private Sub ShowPayee()
            Dim paymentTypeEnum = CodeToEnum(Of PaymentTypeSelection)(cboPaymentType.SelectedValue)
            If paymentTypeEnum = PaymentTypeSelection.Others Or paymentTypeEnum = ReceiptTypeSelection.NotSpecified Then
                cboPayeeIdNo.Visible = False
                txtPayeeName.Visible = True
                cboPayeeIdNo.SelectedIndex = -1
                tlpDisbursement.SetCellPosition(cboPayeeIdNo, New TableLayoutPanelCellPosition(12, 9))
                tlpDisbursement.SetCellPosition(txtPayeeName, New TableLayoutPanelCellPosition(1, 2))
                tlpDisbursement.SetColumnSpan(txtPayeeName, 8)
            Else
                cboPayeeIdNo.Visible = True
                txtPayeeName.Visible = False
                tlpDisbursement.SetCellPosition(txtPayeeName, New TableLayoutPanelCellPosition(6, 9))
                tlpDisbursement.SetCellPosition(cboPayeeIdNo, New TableLayoutPanelCellPosition(1, 2))
                tlpDisbursement.SetColumnSpan(txtPayeeName, 3)
            End If
        End Sub

        Protected Overrides Sub InputsTurnedOff()
            If OpenInvoiceMode Then
                btnViewGL.Visible = True
                btnViewGL.Text = Messaging.TranslateCaption("View Journal Entry")
            Else
                btnViewGL.Visible = False
            End If
            btnAutoApply.Visible = False
        End Sub

        Protected Overrides Sub InputsTurnedOn()
            bsJournalItems.ResetBindings(False)
            btnViewGL.Visible = False
            MyPresenter.AddSupplierOpenInvoices()
            bsDjOiItems.ResetBindings(False)
            UpdateDisplay()
            If OpenInvoiceMode Then
                btnAutoApply.Visible = True
            Else
                btnAutoApply.Visible = False
            End If
        End Sub

        Private Sub ShowJournalItemDataGrid()
            UpdateFirstLine()
            UpdateTotals()
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
            If Not OpenInvoiceMode Then
                bsJournalItems.ResetBindings(True)
                UpdateJiTotals()
            End If
        End Sub

    End Class

End Namespace