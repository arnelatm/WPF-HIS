Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.CustomControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Forms

    Public Class PettyCashJournalEntry
        Implements IPettyCashJournalView, ISubscriber(Of BeforeAssignment)

        Public TxtTotalCredits As Decimal
        Public TxtTotalDebits As Decimal

        Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat

        Private ReadOnly _payeeOrigWidth As Integer
        Private _accountsByCode

        Private _apFooter As DgvFooter
        Private _jiFooter As DgvFooter
        Private _journalItems As List(Of JournalItemView)
        Private _pcsOiItems As List(Of PcsOiItemView)
        Private _profitCentersByCode
        Private _viewGl As Boolean = False

        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            MainTableName = "PettyCashJournal"
            SortOrderKey = "IdNo"
            FirstControl = txtReferenceNo

            _payeeOrigWidth = cboPayeeIdNo.Width
            _nfi.NumberDecimalDigits = 2
            PresenterObj = New PettyCashJournalPresenter(Me)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)

        End Sub

#Region "Field Items"

        Public Property AccountIdNo As Int32 Implements IPettyCashJournalView.AccountIdNo
            Get
                Return cboAccountIdNo.GetValue()
            End Get
            Set
                cboAccountIdNo.SetValue(Value)
            End Set
        End Property

        Public Property Amount As Decimal Implements IPettyCashJournalView.Amount
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtAmount.Text), _nfi)
            End Get
            Set
                txtAmount.Text = FormatMoney(Value)

            End Set
        End Property

        Public Property Applied As Decimal Implements IPettyCashJournalView.Applied
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtApplied.Text), _nfi)
            End Get
            Set
                txtApplied.Text = FormatMoney(Value)
            End Set
        End Property

        Public Property Cancelled As Boolean Implements IPettyCashJournalView.Cancelled
            Get
                Return chkCancelled.Checked
            End Get
            Set
                chkCancelled.Checked = Value
            End Set
        End Property

        Public Property DateCreated As DateTime? Implements IPettyCashJournalView.DateCreated
            Get
                If String.IsNullOrEmpty(txtDateCreated.Text) Then
                    Return Now()
                End If
                Return Convert.ToDateTime(txtDateCreated.Text)
            End Get
            Set(value As DateTime?)
                If value Is Nothing Then
                    txtDateCreated.Text = Nothing
                Else
                    txtDateCreated.Text = String.Format(CultureInfo.CurrentCulture, "{0:g}", value)
                End If
            End Set
        End Property

        Public Property DiscountAccountIdNo As Int32? Implements IPettyCashJournalView.DiscountAccountIdNo
            Get
                Return CType(cboDiscountAccountIdNo.GetValue(), Int32?)
            End Get
            Set
                cboDiscountAccountIdNo.SetValue(Value)
            End Set
        End Property

        Public Property DiscountTaken As Decimal Implements IPettyCashJournalView.DiscountTaken
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtDiscountTaken.Text), _nfi)
            End Get
            Set
                txtDiscountTaken.Text = FormatMoney(Value)
            End Set
        End Property

        Public Property IdNo As Int32 Implements IPettyCashJournalView.IdNo
            Get
                If TxtIDNo.Text <> "" Then
                    Return Convert.ToInt16(TxtIDNo.Text)
                Else
                    Return 0
                End If
            End Get
            Set
                TxtIDNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property JournalItems As List(Of JournalItemView) Implements IPettyCashJournalView.JournalItems
            Get
                Return _journalItems
            End Get
            Set
                _journalItems = Value
                BindJournalItem()
            End Set
        End Property

        Public Property Notes As String Implements IPettyCashJournalView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = If(Value, "")
            End Set
        End Property

        Public Property ORNumber As String Implements IPettyCashJournalView.OrNumber
            Get
                Return txtORNumber.Text
            End Get
            Set
                txtORNumber.Text = Value
            End Set
        End Property

        Public Property PayeeIdNo As Int32 Implements IPettyCashJournalView.PayeeIdNo
            Get
                Return cboPayeeIdNo.GetValue()
            End Get
            Set
                cboPayeeIdNo.SetValue(Value)
            End Set
        End Property

        Public Property PayeeName As String Implements IPettyCashJournalView.PayeeName
            Get
                Return txtPayeeName.Text
            End Get
            Set
                txtPayeeName.Text = Value
            End Set
        End Property

        Public Property PaymentType As String Implements IPettyCashJournalView.PaymentType
            Get
                Return cboPaymentType.GetValue()
            End Get
            Set
                cboPaymentType.SetValue(Value)
                'SetPayeeProperty(Value)
            End Set
        End Property

        Public Property PcsOiItems As List(Of PcsOiItemView) Implements IPettyCashJournalView.PcsOiItems
            Get
                Return _pcsOiItems
            End Get
            Set(value As List(Of PcsOiItemView))
                _pcsOiItems = value
                BindPcsOiItem()
            End Set
        End Property

        Public Property Posted As Boolean Implements IPettyCashJournalView.Posted
            Get
                Return chkPosted.Checked
            End Get
            Set
                chkPosted.Checked = Value
            End Set
        End Property

        Public Property ReferenceNo As String Implements IPettyCashJournalView.ReferenceNo
            Get
                Return txtReferenceNo.Text
            End Get
            Set
                txtReferenceNo.Text = Value
            End Set
        End Property

        Public Property TotalCredits As Decimal Implements IPettyCashJournalView.TotalCredits
            Get
                Return TxtTotalCredits
            End Get
            Set(value As Decimal)
                TxtTotalCredits = value
            End Set
        End Property

        Public Property TotalDebits As Decimal Implements IPettyCashJournalView.TotalDebits
            Get
                Return TxtTotalDebits
            End Get
            Set(value As Decimal)
                TxtTotalDebits = value
            End Set
        End Property

        Public Property TransactionDate As Date? Implements IPettyCashJournalView.TransactionDate
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

        Public Property UnApplied As Decimal Implements IPettyCashJournalView.UnApplied
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtUnapplied.Text), _nfi)
            End Get
            Set
                txtUnapplied.Text = FormatMoney(Value)
            End Set
        End Property

        Public Property VatAmount As Decimal Implements IPettyCashJournalView.VatAmount
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtVatAmount.Text), _nfi)
            End Get
            Set
                txtVatAmount.Text = FormatMoney(Value)
            End Set
        End Property

        Public Property VatNumber As String Implements IPettyCashJournalView.VatNumber
            Get
                Return txtVatNumber.Text
            End Get
            Set
                txtVatNumber.Text = Value
            End Set
        End Property

#End Region

        Public Sub OnEventHandler(ByRef eventType As BeforeAssignment) Implements ISubscriber(Of BeforeAssignment).OnEventHandler
            SetPayeeProperty(eventType.Model.PaymentType)
        End Sub

        Protected Overrides Sub CreateDataSources()
            _accountsByCode = PresenterObj.GetDetailAccountListByCode()
            _profitCentersByCode = PresenterObj.GetProfitCenterListByCode()
            cboPaymentType.BeginUpdate()
            cboPaymentType.DataSource = PresenterObj.MakeEnumComboList(Of PaymentTypeSelection)
            cboPaymentType.EndUpdate()
            cboAccountIdNo.BeginUpdate()
            cboAccountIdNo.DataSource = PresenterObj.GetAccountTypesList("PC")
            cboAccountIdNo.EndUpdate()
            cboDiscountAccountIdNo.BeginUpdate()
            cboDiscountAccountIdNo.DataSource = PresenterObj.GetAccountTypesList("PD")
            cboDiscountAccountIdNo.EndUpdate()
        End Sub

        Protected Overrides Sub CreateFieldsDictionary()
            FieldsDictionary = New Dictionary(Of String, Object) From
        {
         {"AccountIdNo", cboAccountIdNo},
         {"Amount", txtAmount},
         {"Applied", txtApplied},
         {"Cancelled", chkCancelled},
         {"DateCreated", txtDateCreated},
         {"DiscountAccountIdNo", cboDiscountAccountIdNo},
         {"DiscountTaken", txtDiscountTaken},
         {"IdNo", TxtIDNo},
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

        'Private Sub AddSupplierOpenInvoices()
        '    If PayeeIdNo <> 0 Then
        '        Dim unpaidInvoices = PresenterObj.GetSupplierOpenInvoices(PayeeIdNo)
        '        Dim newItem As New PcsOiItemModel
        '        Dim nSeq As Integer
        '        If PresenterObj.AddMode Then
        '            bsPcsOiItems.Clear()
        '        End If
        '        If bsPcsOiItems IsNot Nothing Then
        '            nSeq = bsPcsOiItems.Count()
        '        Else
        '            nSeq = 0
        '        End If
        '        For Each unpaidInvoice In unpaidInvoices
        '            Dim itemFound = False
        '            If bsPcsOiItems IsNot Nothing Then
        '                For Each item In bsPcsOiItems
        '                    If item.JournalItemIdNo = unpaidInvoice.JournalItemIdNo And item.JournalCode = unpaidInvoice.JournalCode Then
        '                        itemFound = True
        '                    End If
        '                Next
        '            End If
        '            If Not itemFound Then

        '                If unpaidInvoice.JournalCode = "CD" And unpaidInvoice.JournalIdNo = IdNo Then
        '                    ' ignore advance payments if applied to this entry.
        '                Else
        '                    nSeq = nSeq + 1
        '                    Dim item As New PcsOiItemModel With {
        '                            .AccountIdNo = unpaidInvoice.AccountIdNo,
        '                            .Amount = unpaidInvoice.Amount,
        '                            .Balance = unpaidInvoice.Balance,
        '                            .DiscountTaken = unpaidInvoice.DiscountTaken,
        '                            .InvoiceNo = unpaidInvoice.InvoiceNo,
        '                            .JournalCode = unpaidInvoice.JournalCode,
        '                            .JournalIdNo = unpaidInvoice.JournalIdNo,
        '                            .JournalItemIdNo = unpaidInvoice.JournalItemIdNo,
        '                            .OpenInvoiceIdNo = unpaidInvoice.OpenInvoiceIdNo,
        '                            .PreviousBalance = unpaidInvoice.Balance,
        '                            .Sequence = nSeq,
        '                            .TransactionDate = unpaidInvoice.TransactionDate
        '                            }
        '                    bsPcsOiItems.Add(item)
        '                End If
        '            End If
        '        Next
        '    End If
        '    DataGridViewPcsOiItems.Refresh()
        'End Sub
        Private Sub BindPcsOiItem()
            SuspendLayout()
            bsPcsOiItems.DataSource = Nothing
            DataGridViewPcsOiItems.Refresh()
            bsPcsOiItems.DataSource = PcsOiItems
            bsPcsOiItems.AllowNew = True
            With DataGridViewPcsOiItems
                .Refresh()
                .AutoGenerateColumns = False
                .DataSource = bsPcsOiItems
                .Refresh()
                .AllowUserToAddRows = True
                .AllowUserToDeleteRows = True
            End With
            'With DataGridViewPcsOiItems.Columns
            'If dgvSequencePcsOi IsNot Nothing Then
            '    dgvSequencePcsOi.DisplayOnly = True
            '    dgvInvoiceNo.DisplayOnly = True
            '    dgvPreviousBalance.DisplayOnly = True
            '    dgvNewBalance.DisplayOnly = True
            '    dgvTransactionDate.DisplayOnly = True
            '    dgvJournalCode.DisplayOnly = True
            '    dgvJournalIdNoJi.DisplayOnly = True
            'End If
            'End With
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
                .AllowUserToAddRows = True
                .AllowUserToDeleteRows = True
            End With
            With DataGridViewJournalItems.Columns
                dgvSequence.DisplayOnly = True
                dgvAccountIdNo.DataSource = _accountsByCode
                dgvAccountIdNo.DisplayMember = "Name"
                dgvAccountIdNo.ValueMember = "IdNo"
                dgvAccountIdNo.AutoComplete = AutoCompleteMode.SuggestAppend
                dgvAccountIdNo.DisplayStyleForCurrentCellOnly = True
                dgvAccountIdNo.AutoComplete = True
                dgvProfitCenterIdNo.DataSource = _profitCentersByCode
                dgvProfitCenterIdNo.DisplayMember = "Name"
                dgvProfitCenterIdNo.ValueMember = "idNo"
                dgvProfitCenterIdNo.AutoComplete = AutoCompleteMode.SuggestAppend
                dgvProfitCenterIdNo.DisplayStyleForCurrentCellOnly = True
            End With
            ResumeLayout()
        End Sub

        Private Sub btnViewGL_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnViewGL.ClickButtonArea
            If _viewGl Then
                _viewGl = False
                DataGridViewJournalItems.Visible = False
                DataGridViewPcsOiItems.Visible = True
                btnViewGL.Text = Messaging.TranslateCaption("View Journal Entry")
            Else
                _viewGl = True
                DataGridViewJournalItems.Visible = True
                DataGridViewPcsOiItems.Visible = False
                btnViewGL.Text = Messaging.TranslateCaption("Hide Journal Entry")
            End If
        End Sub

        Private Sub PcsOiItemDgv_OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewPcsOiItems.CellEndEdit
            With DataGridViewPcsOiItems.CurrentCell
                Select Case .OwningColumn.Name.ToLower()
                    Case $"dgvamount"
                        Dim selectedRow As PcsOiItemView
                        Dim amt = .Value
                        selectedRow = DataGridViewPcsOiItems.Rows(.RowIndex).DataBoundItem
                        selectedRow.Balance = selectedRow.PreviousBalance - amt - selectedRow.DiscountTaken
                        UpdateOiTotals()
                    Case $"dgvdiscounttaken"
                        Dim selectedRow As PcsOiItemView
                        Dim amt = .Value
                        selectedRow = DataGridViewPcsOiItems.Rows(.RowIndex).DataBoundItem
                        selectedRow.Balance = selectedRow.PreviousBalance - selectedRow.Amount - amt
                        UpdateOiTotals()
                        SendKeys.Send("{HOME}{DOWN}{TAB}{TAB}{TAB}")
                    Case $"dgvbalance"
                        SendKeys.Send("{DOWN}")
                End Select
            End With
        End Sub

        Private Sub PettyCashDisbursementJournalEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            KeyPreview = True
            _jiFooter = New DgvFooter(DataGridViewJournalItems)
            _jiFooter.AutoCalc = True
            _jiFooter.ColumnToSum("dgvDebit") = True
            _jiFooter.ColumnToSum("dgvCredit") = True
            _jiFooter.SetText("DgvAccountIdNo", "Totals ->")

            _apFooter = New DgvFooter(DataGridViewPcsOiItems)
            _apFooter.AutoCalc = True
            _apFooter.ColumnToSum("dgvAmount") = True
            _apFooter.ColumnToSum("dgvDiscountTaken") = True
            _apFooter.ColumnToSum("dgvBalance") = True
            _apFooter.ColumnToSum("dgvPreviousBalance") = True
            _apFooter.SetText("dgvJournalIdNoAp", "Totals")

            DataGridViewJournalItems.Columns("ItemVatAmount").ValueType = GetType(System.Decimal)
            DataGridViewJournalItems.Columns("ItemVatAmount").ReadOnly = False
        End Sub

        Private Sub cboAccountIdNo_ValueChanged(sender As Object, e As EventArgs) Handles txtAmount.Validated, cboPaymentType.Validated, cboAccountIdNo.Validated
            UpdateFirstLine()
        End Sub

        Private Sub cboPayeeIdNo_ValueChanged(sender As Object, e As EventArgs) Handles cboPayeeIdNo.Validated
            If PaymentTypeToEnum(PaymentType) = PaymentTypeSelection.AccountsPayable Or PaymentTypeToEnum(PaymentType) = PaymentTypeSelection.Supplier Then
                If PaymentTypeToEnum(PaymentType) = PaymentTypeSelection.AccountsPayable Then
                    If cboPayeeIdNo.PreviousSelectedIndex <> cboPayeeIdNo.SelectedIndex Then
                        bsPcsOiItems.Clear()
                        UpdateOiTotals()
                    End If
                    PresenterObj.AddSupplierOpenInvoices()
                    BindPcsOiItem()
                End If
                Dim lVatNumber As String
                lVatNumber = PresenterObj.GetSupplierVatNumber(cboPayeeIdNo.SelectedValue)
                If Not String.IsNullOrEmpty(lVatNumber) Then
                    VatNumber = lVatNumber
                End If
            End If
        End Sub

        Private Sub cboPaymentType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPaymentType.SelectionChangeCommitted
            SetPayeeProperty(cboPaymentType.SelectedValue)
        End Sub

        Private Sub DataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewJournalItems.CellClick
            With DataGridViewJournalItems.CurrentCell
                Select Case .OwningColumn.Name.ToLower()
                    Case $"dgvinsertcolumn"
                        If PresenterObj.EditMode OrElse PresenterObj.AddMode Then
                            If .RowIndex() = 0 Then
                                Messaging.Show(True, "MsgRowInsNotAllowedInFirstRow", "Row insertion on first row not allowed for this transaction.", "Error")
                            Else
                                Dim newRow As New JournalItemModel
                                bsJournalItems.Insert(.RowIndex(), newRow)
                                ReSequenceDgvAfterInsert(DataGridViewJournalItems, bsJournalItems)
                                SendKeys.Send("{UP}")
                            End If
                        Else
                            Messaging.Show(True, "MsgRowInsNotAllowedInViewMode", "Row insertion not allowed while in view mode. Press edit button to enable insertion.", "Error")
                        End If
                End Select
            End With
        End Sub

        Private Sub DataGridViewJournalItems_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridViewJournalItems.UserDeletedRow
            ReSequenceDgvAfterDelete(DataGridViewJournalItems, bsJournalItems)
            UpdateTotals()
            UpdateTotalVatAmount()
        End Sub

        Private Overloads Sub Dispose()
            Close()
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
            With DataGridViewJournalItems.CurrentCell
                Dim nIndex = DataGridViewJournalItems.CurrentRow.Index
                Select Case .OwningColumn.Name.ToLower()
                    Case $"dgvaccountidno"
                        Dim newValue = DirectCast(DataGridViewJournalItems.CurrentCell, CaDgvComboboxCell).CellEditingControl.GetValue()
                        With DataGridViewJournalItems.CurrentRow
                            Dim currentVatAmount As Decimal
                            If PresenterObj.IsInputVatAccount(newValue) Then
                                currentVatAmount = .Cells("dgvDebit").Value - .Cells("dgvCredit").Value
                            Else
                                currentVatAmount = 0
                            End If
                            .Cells("ItemVatAmount").Value = currentVatAmount
                        End With
                        UpdateTotalVatAmount()
                        'Dim idNo As Int32 = .Value
                        Dim chart As ChartModel
                        chart = PresenterObj.GetChart(newValue)
                        bsJournalItems(nIndex).SpecialAccount = chart.SpecialAccount
                        bsJournalItems(nIndex).PayeeType = chart.PayeeType
                        bsJournalItems(nIndex).AccountName = chart.AccountName
                        DataGridViewJournalItems.Refresh()
                    Case $"dgvdebit"
                        Dim selectedRow As JournalItemView
                        selectedRow = DataGridViewJournalItems.Rows(.RowIndex).DataBoundItem
                        If PresenterObj.IsInputVatAccount(selectedRow.AccountIdNo) Then
                            DataGridViewJournalItems.Rows(.RowIndex).Cells("ItemVatAmount").Value = selectedRow.Debit - selectedRow.Credit
                        End If
                        UpdateJiTotals()
                        UpdateTotalVatAmount()
                        SendKeys.Send("{TAB}")
                    Case $"dgvcredit"
                        Dim selectedRow As JournalItemView
                        selectedRow = DataGridViewJournalItems.Rows(.RowIndex).DataBoundItem
                        If PresenterObj.IsInputVatAccount(selectedRow.AccountIdNo) Then
                            DataGridViewJournalItems.Rows(.RowIndex).Cells("ItemVatAmount").Value = selectedRow.Debit - selectedRow.Credit
                        End If
                        UpdateJiTotals()
                        UpdateTotalVatAmount()
                    Case $"dgvnotes"
                        SendKeys.Send("{DOWN}")
                End Select
            End With
        End Sub

        Private Sub OnInputsTurnedOff() Handles MyBase.InputsTurnedOff
            DataGridViewJournalItems.StartTrackingChanges = False
            DataGridViewJournalItems.RemoveInsertColumn()
            If PaymentTypeToEnum(PaymentType) = PaymentTypeSelection.AccountsPayable Then
                btnViewGL.Visible = True
            Else
                btnViewGL.Visible = False
            End If
        End Sub

        Private Sub OnInputsTurnedOn() Handles MyBase.InputsTurnedOn
            DataGridViewJournalItems.StartTrackingChanges = True
            DataGridViewJournalItems.AddInsertColumn()
            PresenterObj.AddSupplierOpenInvoices()
            BindPcsOiItem()
            btnViewGL.Visible = False
        End Sub

        Private Sub ReSequenceDgvAfterDelete(ByRef dataGridView As DataGridView, ByRef items As Object)
            Dim i = dataGridView.CurrentCell.RowIndex()
            For Each item In items
                If item.Sequence > i + 1 Then
                    item.Sequence = item.Sequence - 1
                End If
            Next
        End Sub

        Private Sub ReSequenceDgvAfterInsert(ByRef dataGridView As DataGridView, ByRef items As Object)
            Dim i = dataGridView.CurrentCell.RowIndex()
            For Each item In items
                If item.Sequence = 0 Then
                    item.Sequence = i
                ElseIf item.Sequence >= i Then
                    item.Sequence = item.Sequence + 1
                End If
            Next
        End Sub

        Private Sub SetPayeeProperty(ByVal cPaymentType As String)
            SuspendLayout()
            Dim savePayeeIdNo = PayeeIdNo
            txtPayeeName.Visible = False
            txtPayeeName.Width = 0
            cboPayeeIdNo.Visible = True
            cboPayeeIdNo.Width = _payeeOrigWidth
            cboPayeeIdNo.ValueMember = "IdNo"
            cboPayeeIdNo.DisplayMember = "Name"
            Dim cbDataSource = Nothing
            cboPayeeIdNo.DataSource = cbDataSource
            Dim paymentTypeEnum = PaymentTypeToEnum(cPaymentType)
            If paymentTypeEnum = PaymentTypeSelection.AccountsPayable Then
                cbDataSource = PresenterObj.GetSupplierListByCode()
                DataGridViewJournalItems.Visible = False
                DataGridViewPcsOiItems.Visible = True
            Else
                DataGridViewJournalItems.Visible = True
                DataGridViewPcsOiItems.Visible = False
                Applied = 0
                UnApplied = 0
                DiscountTaken = 0
                If paymentTypeEnum = PaymentTypeSelection.Supplier Then
                    cbDataSource = PresenterObj.GetSupplierListByCode()
                ElseIf paymentTypeEnum = PaymentTypeSelection.Employee Then
                    cbDataSource = PresenterObj.GetEmployeeListByCode()
                ElseIf paymentTypeEnum = PaymentTypeSelection.CustomerRefund Then
                    cbDataSource = PresenterObj.GetCustomerListByCode()
                Else
                    txtPayeeName.Visible = True
                    txtPayeeName.Width = _payeeOrigWidth
                    cboPayeeIdNo.SelectedIndex = -1
                    cboPayeeIdNo.Width = 0
                    cboPayeeIdNo.Visible = False
                End If
            End If
            cboPayeeIdNo.DataSource = cbDataSource
            cboPayeeIdNo.SelectedValue = savePayeeIdNo
            ResumeLayout()
        End Sub

        Private Sub txtAmount_ValueChanged(sender As Object, e As EventArgs) Handles txtAmount.Validated
            If PaymentTypeToEnum(PaymentType) = PaymentTypeSelection.AccountsPayable Then
                UpdateOiTotals()
            End If
        End Sub

        Private Sub TxtNotes_Leave(sender As Object, e As EventArgs) Handles txtNotes.Leave
            If DataGridViewJournalItems.Visible Then
                DataGridViewJournalItems.Focus()
                DataGridViewJournalItems.CurrentCell = DataGridViewJournalItems(DataGridViewJournalItems.Columns("dgvProfitCenterIdNo").Index(), 0)
            Else
                DataGridViewPcsOiItems.Focus()
                DataGridViewPcsOiItems.CurrentCell = DataGridViewPcsOiItems(DataGridViewPcsOiItems.Columns("dgvAmount").Index(), 0)
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
                                              .ProfitCenterIdNo = 0})
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
                            item.ProfitCenterIdNo = 0
                            DataGridViewJournalItems.Refresh()
                            Exit For
                        Next
                    End If
                End If
                BindJournalItem()
                UpdateJiTotals()
            End If
        End Sub

        Private Sub UpdateJiTotals()
            If _jiFooter IsNot Nothing Then
                _jiFooter.SumAllColumns()
                TotalDebits = _jiFooter.Value("dgvDebit")
                TotalCredits = _jiFooter.Value("dgvCredit")
            End If
        End Sub

        Private Sub UpdateOiTotals()
            If _apFooter IsNot Nothing Then
                _apFooter.SumAllColumns()
                Applied = _apFooter.Value("dgvAmount")
                DiscountTaken = _apFooter.Value("dgvDiscountTaken")
                UnApplied = Amount - Applied
            End If
        End Sub

        Private Sub UpdateTotals()
            UpdateJiTotals()
            UpdateOiTotals()
        End Sub

        Private Sub UpdateTotalVatAmount()
            Dim tVatAmount As Decimal = 0
            For Each row In DataGridViewJournalItems.Rows
                tVatAmount = tVatAmount + row.cells("ItemVatAmount").Value
            Next
            VatAmount = tVatAmount
        End Sub

        Private Sub UserDeletingRow(ByVal sender As Object,
                                    ByVal e As DataGridViewRowCancelEventArgs) Handles DataGridViewJournalItems.UserDeletingRow _

            ' Check if the starting balance row is included in the selected rows
            Dim pettyCashRowEntry As DataGridViewRow = DataGridViewJournalItems.Rows(0)

            ' Check if the starting balance row is included in the selected rows
            If DataGridViewJournalItems.SelectedRows.Contains(pettyCashRowEntry) Then
                ' Do not allow the user to delete the first row.
                Messaging.Show(True, "MsgFirstRowDeletionNotAllowed")
                ' Cancel the deletion
                e.Cancel = True
            End If
        End Sub

    End Class

End Namespace