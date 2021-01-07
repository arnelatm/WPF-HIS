Imports System.ComponentModel
Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Views.Forms

    Public Class CashReceiptJournalEntry
        Implements ICashReceiptJournalView, ISubscriber(Of BeforeAssignment)

        Public TxtTotalCredits As Decimal
        Public TxtTotalDebits As Decimal

        Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat

        Private ReadOnly _payorOrigWidth As Integer
        Private _accountsByCode

        Private _arFooter As DgvFooter
        Private _csrOiItems As List(Of CsrOiItemView)
        Private _jiFooter As DgvFooter
        Private _journalItems As List(Of IJournalItemView)
        Private _revCostCenterByCode
        Private _viewGl As Boolean = False

        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            MainTableName = "CashReceiptJournal"
            SortOrderKey = "IdNo"
            FirstControl = txtReferenceNo

            _payorOrigWidth = cboPayorIdNo.Width
            _nfi.NumberDecimalDigits = 2
            PresenterObj = New CashReceiptJournalPresenter(Me)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)

        End Sub

        ' This event handler provides custom item-creation behavior.
        Private Sub journalItemsBindingSource_AddingNew(
                                                        ByVal sender As Object,
                                                        ByVal e As AddingNewEventArgs) _
            Handles bsJournalItems.AddingNew
            e.NewObject = New JournalItemView
        End Sub

#Region "Fields"

        Public Property AccountIdNo As Int16? Implements ICashReceiptJournalView.AccountIdNo
            Get
                Return cboAccountIdNo.GetNullableValue(Of Int16)
            End Get
            Set
                cboAccountIdNo.SetValue(Value)
            End Set
        End Property

        Public Property Amount As Decimal Implements ICashReceiptJournalView.Amount
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtAmount.Text), _nfi)
            End Get
            Set
                txtAmount.Text = FormatMoney(Value)

            End Set
        End Property

        Public Property Applied As Decimal Implements ICashReceiptJournalView.Applied
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtApplied.Text), _nfi)
            End Get
            Set
                txtApplied.Text = FormatMoney(Value)
            End Set
        End Property

        Public Property Cancelled As Boolean Implements ICashReceiptJournalView.Cancelled
            Get
                Return chkCancelled.Checked
            End Get
            Set
                chkCancelled.Checked = Value
            End Set
        End Property

        Public Property CheckDate As DateTime? Implements ICashReceiptJournalView.CheckDate
            Get
                If String.IsNullOrEmpty(dtpCheckDate.Text) Then
                    Return Nothing
                End If
                Return Convert.ToDateTime(dtpCheckDate.Text)
            End Get
            Set(value As DateTime?)
                If value Is Nothing Then
                    dtpCheckDate.Value = Nothing
                Else
                    dtpCheckDate.Value = String.Format(CultureInfo.CurrentCulture, "{0:g}", value)
                End If
            End Set
        End Property

        Public Property CheckNumber As String Implements ICashReceiptJournalView.CheckNumber
            Get
                Return txtCheckNumber.Text
            End Get
            Set
                txtCheckNumber.Text = Value
            End Set
        End Property

        Public Property DateCreated As DateTime? Implements ICashReceiptJournalView.DateCreated
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

        Public Property DiscountAccountIdNo As Int16? Implements ICashReceiptJournalView.DiscountAccountIdNo
            Get
                Return cboDiscountAccountIdNo.GetNullableValue(Of Int16)
            End Get
            Set
                cboDiscountAccountIdNo.SetValue(Value)
            End Set
        End Property

        Public Property DiscountTaken As Decimal Implements ICashReceiptJournalView.DiscountTaken
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtDiscountTaken.Text), _nfi)
            End Get
            Set
                txtDiscountTaken.Text = FormatMoney(Value)
            End Set
        End Property

        Public Property IdNo As Int32 Implements ICashReceiptJournalView.IdNo
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

        Public Property JournalItems As List(Of IJournalItemView) Implements ICashReceiptJournalView.JournalItems
            Get
                Return _journalItems
            End Get
            Set
                _journalItems = Value
                BindJournalItem()
            End Set
        End Property

        Public Property Notes As String Implements ICashReceiptJournalView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = If(Value, "")
            End Set
        End Property

        Public Property ORNumber As String Implements ICashReceiptJournalView.OrNumber
            Get
                Return txtORNumber.Text
            End Get
            Set
                txtORNumber.Text = Value
            End Set
        End Property

        Public Property PayorIdNo As Int32? Implements ICashReceiptJournalView.PayorIdNo
            Get
                Return cboPayorIdNo.GetNullableValue(Of Int32)
            End Get
            Set
                If cboPayorIdNo.DataSource IsNot Nothing Then
                    cboPayorIdNo.SetValue(Value)
                Else
                    cboPayorIdNo.SelectedValue = Nothing
                End If
            End Set
        End Property

        Public Property PayorName As String Implements ICashReceiptJournalView.PayorName
            Get
                Return txtPayorName.Text
            End Get
            Set
                txtPayorName.Text = Value
            End Set
        End Property

        Public Property PayorType As String Implements ICashReceiptJournalView.PayorType
            Get
                Return cboPayorType.GetValue()
            End Get
            Set
                cboPayorType.SetValue(Value)
                SetPayorProperty(Value)
            End Set
        End Property

        Public Property CsrOiItems As List(Of CsrOiItemView) Implements ICashReceiptJournalView.CsrOiItems
            Get
                Return _csrOiItems
            End Get
            Set(value As List(Of CsrOiItemView))
                _csrOiItems = value
                BindCsrOiItem()
            End Set
        End Property

        Public Property Posted As Boolean Implements ICashReceiptJournalView.Posted
            Get
                Return chkPosted.Checked
            End Get
            Set
                chkPosted.Checked = Value
            End Set
        End Property

        Public Property ReferenceNo As String Implements ICashReceiptJournalView.ReferenceNo
            Get
                Return txtReferenceNo.Text
            End Get
            Set
                txtReferenceNo.Text = Value
            End Set
        End Property

        Public Property TotalCredits As Decimal Implements ICashReceiptJournalView.TotalCredits
            Get
                Return TxtTotalCredits
            End Get
            Set(value As Decimal)
                TxtTotalCredits = value
            End Set
        End Property

        Public Property TotalDebits As Decimal Implements ICashReceiptJournalView.TotalDebits
            Get
                Return TxtTotalDebits
            End Get
            Set(value As Decimal)
                TxtTotalDebits = value
            End Set
        End Property

        Public Property TransactionDate As Date? Implements ICashReceiptJournalView.TransactionDate
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

        Public Property UnApplied As Decimal Implements ICashReceiptJournalView.UnApplied
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtUnapplied.Text), _nfi)
            End Get
            Set
                txtUnapplied.Text = FormatMoney(Value)
            End Set
        End Property

#End Region

        Public Sub OnEventHandler(ByRef eventType As BeforeAssignment) Implements ISubscriber(Of BeforeAssignment).OnEventHandler
            ' need to do this because the Mapping source part of this program maps the PayeeIdNo first before
            ' the PaymentType so in order to override this part we need to retrieve the PaymentType first
            ' because when assigning the cboPayeeIdNo the datasource must be correct that is why
            ' we need to set the DataSource part of the cboPayeeIdNo before we can assign the PayeeIdNo
            PayorType = eventType.Model.PayorType
            SetPayorDataSource(PayorType)
            cboPayorType.SelectedValue = IIf(PayorType = Nothing, 0, PayorType)
        End Sub

        Protected Overrides Sub CreateDataSources()
            _accountsByCode = PresenterObj.GetDetailAccountList()
            _revCostCenterByCode = PresenterObj.GetLookup("RevCostCenter")
            cboAccountIdNo.BeginUpdate()
            cboAccountIdNo.DataSource = PresenterObj.GetAccountTypesList("CS,CK,BA")
            cboAccountIdNo.EndUpdate()
            cboPayorType.BeginUpdate()
            cboPayorType.DataSource = PresenterObj.MakeEnumComboList(Of ReceiptTypeSelection)
            cboPayorType.EndUpdate()
            cboDiscountAccountIdNo.BeginUpdate()
            cboDiscountAccountIdNo.DataSource = PresenterObj.GetAccountTypesList("RD")
            cboDiscountAccountIdNo.EndUpdate()
        End Sub

        Protected Overrides Sub CreateFieldsDictionary()
            FieldsDictionary = New Dictionary(Of String, Object) From
        {
         {"AccountIdNo", cboAccountIdNo},
         {"Amount", txtAmount},
         {"Applied", txtApplied},
         {"Cancelled", chkCancelled},
         {"CheckDate", dtpCheckDate},
         {"CheckNumber", txtCheckNumber},
         {"DateCreated", dtpDateCreated},
         {"DiscountAccountIdNo", cboDiscountAccountIdNo},
         {"DiscountTaken", txtDiscountTaken},
         {"IdNo", TxtIdNo},
         {"Notes", txtNotes},
         {"OrNumber", txtORNumber},
         {"PayorIdNo", cboPayorIdNo},
         {"PayorName", txtPayorName},
         {"PayorType", cboPayorType},
         {"Posted", chkPosted},
         {"ReferenceNo", txtReferenceNo},
         {"TransactionDate", dtpTransactionDate},
         {"UnApplied", txtUnapplied}
        }
        End Sub

        Protected Overrides Sub RecordPositionChanged(ByRef e As RecordPositionChanged)
            MyBase.RecordPositionChanged(e)
            UpdateLayout()
            UpdateTotals()
        End Sub

        Private Sub BindCsrOiItem()
            SuspendLayout()
            bsCsrOiItems.DataSource = Nothing
            DataGridViewCsrOiItems.Refresh()
            bsCsrOiItems.DataSource = CsrOiItems
            bsCsrOiItems.AllowNew = True
            With DataGridViewCsrOiItems
                .Refresh()
                .AutoGenerateColumns = False
                .DataSource = bsCsrOiItems
                .Refresh()
            End With
            With DataGridViewCsrOiItems.Columns
                If dgvSequenceCsrOi IsNot Nothing Then
                    dgvSequenceCsrOi.DisplayOnly = True
                    dgvInvoiceNo.DisplayOnly = True
                    dgvPreviousBalance.DisplayOnly = True
                    dgvBalance.DisplayOnly = True
                    dgvTransactionDate.DisplayOnly = True
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
                DataGridViewJournalItems.Visible = False
                DataGridViewCsrOiItems.Visible = True
                btnViewGL.Text = Messaging.TranslateCaption("View Journal Entry")
            Else
                _viewGl = True
                DataGridViewJournalItems.Visible = True
                DataGridViewCsrOiItems.Visible = False
                btnViewGL.Text = Messaging.TranslateCaption("Hide Journal Entry")
            End If
        End Sub

        Private Sub CsrOiItemDgv_OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewCsrOiItems.CellEndEdit
            With DataGridViewCsrOiItems.CurrentCell
                Select Case .OwningColumn.Name.ToLower()
                    Case $"dgvaccountidno"
                        Dim nIndex = DataGridViewJournalItems.CurrentRow.Index
                        Dim newValue = DirectCast(DataGridViewJournalItems.CurrentCell, CaDgvComboboxCell).CellEditingControl.GetValue()
                        If nIndex + 1 <= DataGridViewJournalItems.RowCount() Then
                            If nIndex < JournalItems.Count() Then
                                JournalItems(nIndex).AccountIdNo = newValue
                                'BindJournalItem()
                            End If
                        End If
                    Case $"dgvamount"
                        Dim selectedRow As CsrOiItemView
                        Dim amt = .Value
                        selectedRow = DataGridViewCsrOiItems.Rows(.RowIndex).DataBoundItem
                        selectedRow.Balance = selectedRow.PreviousBalance - amt - selectedRow.DiscountTaken
                        UpdateOiTotals()
                    Case $"dgvdiscounttaken"
                        Dim selectedRow As CsrOiItemView
                        Dim amt = .Value
                        selectedRow = DataGridViewCsrOiItems.Rows(.RowIndex).DataBoundItem
                        selectedRow.Balance = selectedRow.PreviousBalance - selectedRow.Amount - amt
                        UpdateOiTotals()
                        SendKeys.Send("{HOME}{DOWN}{TAB}{TAB}{TAB}")
                    Case $"dgvbalance"
                        SendKeys.Send("{DOWN}")
                End Select
            End With
        End Sub

        Private Sub CashReceiptJournalEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            KeyPreview = True
            _jiFooter = New DgvFooter(DataGridViewJournalItems) With {
                .AutoCalc = True
            }
            _jiFooter.ColumnToSum("dgvDebit") = True
            _jiFooter.ColumnToSum("dgvCredit") = True
            _jiFooter.SetText("DgvAccountIdNo", "Totals ->")

            _arFooter = New DgvFooter(DataGridViewCsrOiItems) With {
                .AutoCalc = True
            }
            _arFooter.ColumnToSum("dgvAmount") = True
            _arFooter.ColumnToSum("dgvDiscountTaken") = True
            _arFooter.ColumnToSum("dgvBalance") = True
            _arFooter.ColumnToSum("dgvPreviousBalance") = True
            _arFooter.SetText("dgvJournalIdNoAp", "Totals")

        End Sub

        Private Sub CboAccountIdNo_ValueChanged(sender As Object, e As EventArgs) Handles txtAmount.Validated, cboPayorType.Validated, cboAccountIdNo.Validated
            UpdateFirstLine()
        End Sub

        Private Sub CboPayorIdNo_ValueChanged(sender As Object, e As EventArgs) Handles cboPayorIdNo.Validated, cboPayorIdNo.SelectedIndexChanged
            If CodeToEnum(Of ReceiptTypeSelection)(PayorType) = ReceiptTypeSelection.AccountsReceivable Or CodeToEnum(Of ReceiptTypeSelection)(PayorType) = ReceiptTypeSelection.Customer Then
                If CodeToEnum(Of ReceiptTypeSelection)(PayorType) = ReceiptTypeSelection.AccountsReceivable Then
                    'If cboPayorIdNo.PreviousSelectedIndex <> cboPayorIdNo.SelectedIndex Then
                    bsCsrOiItems.Clear()
                    UpdateOiTotals()
                    'End If
                    PresenterObj.AddCustomerOpenInvoices()
                    BindCsrOiItem()
                End If
            End If
        End Sub

        Private Sub UpdateLayout()
            SuspendLayout()
            Dim paymentTypeEnum = CodeToEnum(Of PaymentTypeSelection)(cboPayorType.SelectedValue)
            If paymentTypeEnum = ReceiptTypeSelection.AccountsReceivable Then
                'ShowOpenInvoicesDataGrid()
            Else
                'ShowJournalItemDataGrid()
                Applied = Amount
                UnApplied = 0
                DiscountTaken = 0
            End If
            ShowPayor(paymentTypeEnum)
            ResumeLayout()
        End Sub

        Private Sub ShowPayor(paymentTypeEnum)
            If paymentTypeEnum <> PaymentTypeSelection.Others Then
                cboPayorIdNo.Visible = True
                txtPayorName.Visible = False
                'tlpDisbursement.SetCellPosition(txtPayorName, New TableLayoutPanelCellPosition(6, 8))
                'tlpDisbursement.SetCellPosition(cboPayorIdNo, New TableLayoutPanelCellPosition(5, 1))
            Else
                cboPayorIdNo.Visible = False
                txtPayorName.Visible = True
                'tlpDisbursement.SetCellPosition(cboPayorIdNo, New TableLayoutPanelCellPosition(12, 8))
                'tlpDisbursement.SetCellPosition(txtPayorName, New TableLayoutPanelCellPosition(5, 1))
            End If
        End Sub

        Public Overloads Sub Dispose()
            Close()
        End Sub

        Private Sub OnCellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) _
            Handles DataGridViewJournalItems.CellBeginEdit
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

        Private Sub OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) _
            Handles DataGridViewJournalItems.CellEndEdit
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
                                'BindJournalItem()
                            End If
                        End If
                    Case $"dgvdebit"
                        UpdateJiTotals()
                        SendKeys.Send("{TAB}")
                    Case $"dgvcredit"
                        UpdateJiTotals()
                    Case $"dgvnotes"
                        SendKeys.Send("{DOWN}")
                End Select
            End With
        End Sub

        Protected Overrides Sub InputsTurnedOff()
            If CodeToEnum(Of ReceiptTypeSelection)(PayorType) = ReceiptTypeSelection.AccountsReceivable Then
                btnViewGL.Visible = True
            Else
                btnViewGL.Visible = False
            End If
        End Sub

        Protected Overrides Sub InputsTurnedOn()
            PresenterObj.AddCustomerOpenInvoices()
            BindCsrOiItem()
            btnViewGL.Visible = False
        End Sub

        Private Sub SetPayorProperty(ByVal cPayorType As String)
            SuspendLayout()
            SetPayorDataSource(cPayorType)
            Dim savePayorIdNo = PayorIdNo
            If savePayorIdNo Is Nothing Then
                cboPayorIdNo.SelectedValue = ""
            Else
                cboPayorIdNo.SelectedValue = savePayorIdNo
            End If
            ResumeLayout()
        End Sub

        Private Sub SetPayorDataSource(cPayorType As String)
            SuspendLayout()
            cboPayorIdNo.Visible = True
            cboPayorIdNo.Width = _payorOrigWidth
            cboPayorIdNo.ValueMember = "IdNo"
            cboPayorIdNo.DisplayMember = "Name"
            txtPayorName.Visible = False
            txtPayorName.Width = 0
            Dim curValue As Int32? = cboPayorIdNo.SelectedValue
            Dim cbDataSource = Nothing
            cboPayorIdNo.DataSource = cbDataSource
            Dim payorTypeEnum = CodeToEnum(Of ReceiptTypeSelection)(cPayorType)
            If payorTypeEnum = ReceiptTypeSelection.AccountsReceivable Then
                cbDataSource = PresenterObj.GetLookup("Customer")
                DataGridViewJournalItems.Visible = False
                DataGridViewCsrOiItems.Visible = True
            Else
                DataGridViewJournalItems.Visible = True
                DataGridViewCsrOiItems.Visible = False
                Applied = Amount
                UnApplied = 0
                DiscountTaken = 0
                If payorTypeEnum = ReceiptTypeSelection.Customer Then
                    cbDataSource = PresenterObj.GetLookup("Customer")
                ElseIf payorTypeEnum = ReceiptTypeSelection.Employee Then
                    cbDataSource = PresenterObj.GetLookup("Employee")
                ElseIf payorTypeEnum = ReceiptTypeSelection.SupplierRefund Then
                    cbDataSource = PresenterObj.GetLookup("Supplier")
                Else
                    txtPayorName.Visible = True
                    txtPayorName.Width = _payorOrigWidth
                    cboPayorIdNo.SelectedIndex = -1
                    cboPayorIdNo.Width = 0
                    cboPayorIdNo.Visible = False
                End If
            End If
            cboPayorIdNo.DataSource = cbDataSource
            If curValue IsNot Nothing Then
                cboPayorIdNo.SelectedValue = curValue
            Else
                cboPayorIdNo.SelectedValue = -1
            End If
            ResumeLayout()
        End Sub

        Private Sub TxtAmount_ValueChanged(sender As Object, e As EventArgs) Handles txtAmount.Validated
            If CodeToEnum(Of ReceiptTypeSelection)(PayorType) = ReceiptTypeSelection.AccountsReceivable Then
                UpdateOiTotals()
            End If
        End Sub

        Private Sub TxtNotes_Leave(sender As Object, e As EventArgs) Handles txtNotes.Leave
            If DataGridViewJournalItems.Visible Then
                If DataGridViewJournalItems IsNot Nothing Then
                    DataGridViewJournalItems.Focus()
                    If DataGridViewJournalItems.CurrentCell IsNot Nothing Then
                        ' if after focus and currentcell is not empty
                        DataGridViewJournalItems.CurrentCell = DataGridViewJournalItems(DataGridViewJournalItems.Columns("dgvRevCostCenterIdNo").Index(), 0)
                    End If
                End If
            Else
                If DataGridViewJournalItems IsNot Nothing Then
                    DataGridViewCsrOiItems.Focus()
                    If DataGridViewCsrOiItems.CurrentCell IsNot Nothing Then
                        ' if after focus and currentcell is not empty
                        DataGridViewCsrOiItems.CurrentCell = DataGridViewCsrOiItems(5, 0)
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
                            item.Debit = Amount
                            item.Credit = 0
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
            If PayorType = EnumToCode(ReceiptTypeSelection.AccountsReceivable) Then
                If _arFooter IsNot Nothing Then
                    _arFooter.CalculateTotals()
                    Applied = _arFooter.Value("dgvAmount")
                    DiscountTaken = _arFooter.Value("dgvDiscountTaken")
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

        Private Sub DataGridViewJournalItems_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridViewJournalItems.UserDeletedRow
            UpdateTotals()
        End Sub

        Private Sub CboPayorType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPayorType.SelectedIndexChanged
            SetPayorProperty(cboPayorType.SelectedValue)
            UpdateLayout()
        End Sub

    End Class

End Namespace