Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries.CustomControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Forms

    Public Class CashDisbursementJournalEntry
        Implements ICashDisbursementJournalView

        Public TxtTotalCredits As Decimal
        Public TxtTotalDebits As Decimal

        'Private ReadOnly _cadOiItemsPresenter As CadOiItemsPresenter
        'Private ReadOnly _journalItemsPresenter As CashDisbursementJournalItemsPresenter
        Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat

        Private ReadOnly _payeeOrigWidth As Integer
        Private _accountsByCode

        Private _apFooter As DgvFooter
        Private _cadOiItems As List(Of CadOiItemView)
        Private _jiFooter As DgvFooter
        Private _journalItems As List(Of JournalItemView)
        Private _profitCentersByCode
        Private _totalBalance As Decimal = 0
        Private _viewGl As Boolean = False

        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            MainTableName = "CashDisbursementJournal"
            SortOrderKey = "IdNo"
            FirstControl = txtReferenceNo

            _payeeOrigWidth = cboPayeeIdNo.Width
            _nfi.NumberDecimalDigits = 2
            PresenterObj = New CashDisbursementJournalPresenter(Me)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)

            '_journalItemsPresenter = New CashDisbursementJournalItemsPresenter(Me)
            '_cadOiItemsPresenter = New CadOiItemsPresenter(Me)

            'PresenterObj.JournalItemsPresenter = _journalItemsPresenter
            'PresenterObj.CadOiItemsPresenter = _cadOiItemsPresenter

        End Sub

#Region "Field Items"

        Public Property AccountIdNo As Integer Implements ICashDisbursementJournalView.AccountIdNo
            Get
                Return cboAccountIdNo.GetValue()
            End Get
            Set
                cboAccountIdNo.SetValue(Value)
            End Set
        End Property

        Public Property Amount As Decimal Implements ICashDisbursementJournalView.Amount
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtAmount.Text), _nfi)
            End Get
            Set
                txtAmount.Text = FormatMoney(Value)

            End Set
        End Property

        Public Property Applied As Decimal Implements ICashDisbursementJournalView.Applied
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtApplied.Text), _nfi)
            End Get
            Set
                txtApplied.Text = FormatMoney(Value)
            End Set
        End Property

        Public Property Cancelled As Boolean Implements ICashDisbursementJournalView.Cancelled
            Get
                Return chkCancelled.Checked
            End Get
            Set
                chkCancelled.Checked = Value
            End Set
        End Property

        Public Property DateCreated As DateTime? Implements ICashDisbursementJournalView.DateCreated
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

        Public Property DiscountAccountIdNo As Integer Implements ICashDisbursementJournalView.DiscountAccountIdNo
            Get
                Return cboDiscountAccountIdNo.GetValue()
            End Get
            Set
                cboDiscountAccountIdNo.SetValue(Value)
            End Set
        End Property

        Public Property DiscountTaken As Decimal Implements ICashDisbursementJournalView.DiscountTaken
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtDiscountTaken.Text), _nfi)
            End Get
            Set
                txtDiscountTaken.Text = FormatMoney(Value)
            End Set
        End Property

        Public Property IdNo As Integer Implements ICashDisbursementJournalView.IdNo
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

        Public Property CadOiItems As List(Of CadOiItemView) Implements ICashDisbursementJournalView.CadOiItems
            Get
                Return _cadOiItems
            End Get
            Set
                _cadOiItems = Value
                BindCadOiItem()
            End Set
        End Property

        Public Property JournalItems As List(Of JournalItemView) Implements ICashDisbursementJournalView.JournalItems
            Get
                Return _journalItems
            End Get
            Set
                _journalItems = Value
                BindJournalItem()
            End Set
        End Property

        Public Property Notes As String Implements ICashDisbursementJournalView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = If(Value, "")
            End Set
        End Property

        Public Property ORNumber As String Implements ICashDisbursementJournalView.OrNumber
            Get
                Return txtORNumber.Text
            End Get
            Set
                txtORNumber.Text = Value
            End Set
        End Property

        Public Property PayeeIdNo As Integer Implements ICashDisbursementJournalView.PayeeIdNo
            Get
                Return cboPayeeIdNo.GetValue()
            End Get
            Set
                cboPayeeIdNo.SetValue(Value)
            End Set
        End Property

        Public Property PayeeName As String Implements ICashDisbursementJournalView.PayeeName
            Get
                Return txtPayeeName.Text
            End Get
            Set
                txtPayeeName.Text = Value
            End Set
        End Property

        Public Property PaymentType As String Implements ICashDisbursementJournalView.PaymentType
            Get
                Return cboPaymentType.GetValue()
            End Get
            Set
                cboPaymentType.SetValue(Value)
                SetPayeeProperty(Value)
            End Set
        End Property

        Public Property Posted As Boolean Implements ICashDisbursementJournalView.Posted
            Get
                Return chkPosted.Checked
            End Get
            Set
                chkPosted.Checked = Value
            End Set
        End Property

        Public Property ReferenceNo As String Implements ICashDisbursementJournalView.ReferenceNo
            Get
                Return txtReferenceNo.Text
            End Get
            Set
                txtReferenceNo.Text = Value
            End Set
        End Property

        Public Property TotalCredits As Decimal Implements ICashDisbursementJournalView.TotalCredits
            Get
                Return TxtTotalCredits
            End Get
            Set(value As Decimal)
                TxtTotalCredits = value
            End Set
        End Property

        Public Property TotalDebits As Decimal Implements ICashDisbursementJournalView.TotalDebits
            Get
                Return TxtTotalDebits
            End Get
            Set(value As Decimal)
                TxtTotalDebits = value
            End Set
        End Property

        Public Property TransactionDate As Date? Implements ICashDisbursementJournalView.TransactionDate
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

        Public Property UnApplied As Decimal Implements ICashDisbursementJournalView.UnApplied
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtUnapplied.Text), _nfi)
            End Get
            Set
                txtUnapplied.Text = FormatMoney(Value)
            End Set
        End Property

        Public Property VatAmount As Decimal Implements ICashDisbursementJournalView.VatAmount
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtVatAmount.Text), _nfi)
            End Get
            Set
                txtVatAmount.Text = FormatMoney(Value)
            End Set
        End Property

        Public Property VatNumber As String Implements ICashDisbursementJournalView.VatNumber
            Get
                Return txtVatNumber.Text
            End Get
            Set
                txtVatNumber.Text = Value
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateDataSources()
            _accountsByCode = PresenterObj.GetDetailAccountListByCode()
            _profitCentersByCode = PresenterObj.GetProfitCenterListByCode()
            cboPaymentType.BeginUpdate()
            cboPaymentType.DataSource = PresenterObj.MakeEnumComboList(Of PaymentTypeSelection)
            cboPaymentType.EndUpdate()
            cboAccountIdNo.BeginUpdate()
            cboAccountIdNo.DataSource = PresenterObj.GetAccountTypesList("BA,CS,CK")
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

        Private Overloads Sub Dispose()
            Close()
            '_jifooter.Dispose()
            '_apfooter.Dispose()
        End Sub

        Protected Overrides Sub RecordPositionChanged()
            MyBase.RecordPositionChanged()
            UpdateTotals()
        End Sub

        'Protected Overrides Function DataIsValid() As Boolean
        '    Dim retValue As Boolean = False
        '    If MyBase.DataIsValid() Then
        '        If PaymentTypeToEnum(PaymentType) = PaymentTypeSelection.AccountsPayable Then
        '            _totalBalance = TotalBalance()
        '            If _cadOiItemsPresenter.DataIsValid(bscadOiItems, Applied, UnApplied, _totalBalance) Then
        '                retValue = True
        '            Else
        '                Dim index As Int16 = 0
        '                For Each item In bscadOiItems
        '                    If item.Errors IsNot Nothing Then
        '                        DataGridViewCadOiItems.Rows(index).Cells("dgvAmount").ErrorText = String.Join(",", cadOiItems(index).Errors)
        '                    Else
        '                        DataGridViewCadOiItems.Rows(index).ErrorText = ""
        '                    End If
        '                    index += 1
        '                Next
        '            End If
        '        Else
        '            If _journalItemsPresenter.DataIsValid(JournalItems, PaymentType) Then
        '                retValue = True
        '            End If
        '        End If
        '    End If
        '    Return retValue
        'End Function

        'Protected Overrides Sub DisplayView(ByVal idNoOfRecord As Integer)
        '    MyBase.DisplayView(idNoOfRecord)
        '    _journalItemsPresenter.Display(idNoOfRecord)
        '    TotalDebits = 0
        '    TotalCredits = 0
        '    For Each item In bsJournalItems
        '        TotalDebits += item.Debit
        '        TotalCredits += item.Credit
        '    Next
        '    _cadOiItemsPresenter.Display(idNoOfRecord)
        '    If bscadOiItems IsNot Nothing Then
        '        Applied = 0
        '        DiscountTaken = 0
        '        _totalBalance = 0
        '        For Each item In bscadOiItems
        '            Applied += item.Amount
        '            DiscountTaken += item.DiscountTaken
        '            _totalBalance += item.Balance
        '        Next
        '    End If
        'End Sub

        Private Sub BindCadOiItem()
            SuspendLayout()
            bscadOiItems.DataSource = Nothing
            DataGridViewCadOiItems.Refresh()
            bscadOiItems.DataSource = CadOiItems
            bscadOiItems.AllowNew = True
            With DataGridViewCadOiItems
                .Refresh()
                .AutoGenerateColumns = False
                .DataSource = bscadOiItems
                .Refresh()
                .AllowUserToAddRows = True
                .AllowUserToDeleteRows = True
            End With
            With DataGridViewCadOiItems.Columns
                If dgvSequenceCadOi IsNot Nothing Then
                    dgvSequenceCadOi.DisplayOnly = True
                    dgvInvoiceNo.DisplayOnly = True
                    dgvPreviousBalance.DisplayOnly = True
                    dgvBalance.DisplayOnly = True
                    dgvTransactionDate.DisplayOnly = True
                    dgvJournalCode.DisplayOnly = True
                    dgvJournalIdNoAp.DisplayOnly = True
                End If
            End With
            ResumeLayout()
        End Sub

        Private Sub BindJournalItem()
            SuspendLayout()
            bscadOiItems.DataSource = Nothing
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
                DataGridViewCadOiItems.Visible = True
                btnViewGL.Text = "View Journal Entry"
            Else
                _viewGl = True
                DataGridViewJournalItems.Visible = True
                DataGridViewCadOiItems.Visible = False
                btnViewGL.Text = "Hide Journal Entry"
            End If
        End Sub

        Private Sub cadOiItemDgv_OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewCadOiItems.CellEndEdit
            With DataGridViewCadOiItems.CurrentCell
                Select Case .OwningColumn.Name.ToLower()
                    Case $"dgvamount"
                        Dim selectedRow As CadOiItemView
                        Dim amt = .Value
                        selectedRow = DataGridViewCadOiItems.Rows(.RowIndex).DataBoundItem
                        selectedRow.Balance = selectedRow.PreviousBalance - amt - selectedRow.DiscountTaken
                        UpdateOiTotals()
                    Case $"dgvdiscounttaken"
                        Dim selectedRow As CadOiItemView
                        Dim amt = .Value
                        selectedRow = DataGridViewCadOiItems.Rows(.RowIndex).DataBoundItem
                        selectedRow.Balance = selectedRow.PreviousBalance - selectedRow.Amount - amt
                        UpdateOiTotals()
                        SendKeys.Send("{HOME}{DOWN}{TAB}{TAB}{TAB}")
                    Case $"dgvbalance"
                        SendKeys.Send("{DOWN}")
                End Select
            End With
        End Sub

        Private Sub CashDisbursementJournalEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            KeyPreview = True
            _jiFooter = New DgvFooter(DataGridViewJournalItems)
            _jiFooter.AutoCalc = True
            _jiFooter.ColumnToSum("dgvDebit") = True
            _jiFooter.ColumnToSum("dgvCredit") = True
            _jiFooter.SetText("DgvAccountIdNo", "Totals ->")

            _apFooter = New DgvFooter(DataGridViewCadOiItems)
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
                        bscadOiItems.Clear()
                        UpdateOiTotals()
                    End If
                    PresenterObj.AddSupplierOpenInvoices()
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
                                MessageBox.Show($"Sorry, insertion on first row not allowed for Cash Disbursement journal.")
                            Else
                                Dim newRow As New JournalItemModel
                                bsJournalItems.Insert(.RowIndex(), newRow)
                                ReSequenceDgvAfterInsert(DataGridViewJournalItems, bsJournalItems)
                                SendKeys.Send("{UP}")
                            End If
                        Else
                            Messaging.Show(True, "MsgRowInsNotAllowedInViewMode", "Row insertion not allowed while in view mode. Press edit button to enable deletion.", "Error")
                        End If
                End Select
            End With
        End Sub

        'Private Sub DataGridViewCadOiItems_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewCadOiItems.CellClick
        '    With DataGridViewCadOiItems.CurrentCell
        '        Select Case .OwningColumn.Name.ToLower()
        '            'Case $"dgvinsertcolumn"
        '            '    _cadOiItemsPresenter.ChangesMadeIncadOiItem = True
        '            '    If PresenterObj.EditMode OrElse PresenterObj.AddMode Then
        '            '        Dim newRow As New cadOiItemModel
        '            '        bscadOiItems.Insert(.RowIndex(), newRow)
        '            '        _cadOiItemsPresenter.ChangesMadeIncadOiItem = True
        '            '        ReSequenceDgvAfterInsert(DataGridViewcadOiItems, cadOiItems)
        '            '        SendKeys.Send("{UP}")
        '            '    Else
        '            '        MessageBox.Show($"Row insertion not allowed while in view mode. Press edit button to enable insertion.")
        '            '    End If
        '        End Select
        '    End With
        'End Sub

        Private Sub DataGridViewCadOiItems_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridViewCadOiItems.UserDeletedRow
            ReSequenceDgvAfterDelete(DataGridViewCadOiItems, CadOiItems)
        End Sub

        Private Sub DataGridViewJournalItems_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewJournalItems.CellContentClick

        End Sub

        Private Sub DataGridViewJournalItems_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridViewJournalItems.UserDeletedRow
            ReSequenceDgvAfterDelete(DataGridViewJournalItems, bsJournalItems)
            UpdateTotals()
            UpdateTotalVatAmount()
        End Sub

        Private Sub OnBeforeDisplayView() Handles MyBase.BeforeDisplayView
            Dim cPaymentType = PresenterObj.GetPaymentType(PresenterObj.TargetIdNo)
            SetPayeeProperty(cPaymentType)
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
                        Dim newValue = DirectCast(DataGridViewJournalItems.CurrentCell, Libraries.CBaseControlsLibrary.CaDgvComboboxCell).CellEditingControl.GetValue()
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
                        'Dim idNo As Integer = .Value
                        Dim chart As ChartModel
                        chart = PresenterObj.GetChart(newValue)
                        bsJournalItems(nIndex).SpecialAccount = chart.SpecialAccount
                        bsJournalItems(nIndex).PayeeType = chart.PayeeType
                        bsJournalItems(nIndex).AccountName = chart.AccountName
                        DataGridViewJournalItems.Refresh()
                    Case $"dgvdebit"
                        Dim selectedRow As JournalItemModel
                        selectedRow = DataGridViewJournalItems.Rows(.RowIndex).DataBoundItem
                        If PresenterObj.IsInputVatAccount(selectedRow.AccountIdNo) Then
                            DataGridViewJournalItems.Rows(.RowIndex).Cells("ItemVatAmount").Value = selectedRow.Debit - selectedRow.Credit
                        End If
                        UpdateJiTotals()
                        UpdateTotalVatAmount()
                        SendKeys.Send("{TAB}")
                    Case $"dgvcredit"
                        Dim selectedRow As JournalItemModel
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
            btnViewGL.Visible = False
            SetPayeeProperty(PaymentType)
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
                DataGridViewCadOiItems.Visible = True
            Else
                DataGridViewJournalItems.Visible = True
                DataGridViewCadOiItems.Visible = False
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

        'Private Function TotalBalance() As Decimal
        '    'Return bsCadOiItems.Cast (Of Object)().Aggregate (Of Decimal)(0, Function(current, item) current + item.Balance)
        '    Dim nTotalBalance As Decimal = 0
        '    For Each item In bscadOiItems
        '        nTotalBalance += item.Balance
        '    Next
        '    Return nTotalBalance
        'End Function

        'Private Sub caCombobox_Leave(sender As Object, e As EventArgs) Handles cboPaymentType.Leave
        '    If cboPaymentType.SelectedIndex < 0 Then
        '        SetPayeeProperty()
        '    End If
        'End Sub
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
                DataGridViewCadOiItems.Focus()
                DataGridViewCadOiItems.CurrentCell = DataGridViewCadOiItems(DataGridViewCadOiItems.Columns("dgvAmount").Index(), 0)
            End If
        End Sub

        Private Sub UpdateFirstLine()
            If PresenterObj.EditMode Or PresenterObj.AddMode Then
                If bsJournalItems IsNot Nothing Then
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
                    UpdateJiTotals()
                End If
            End If
        End Sub

        Private Sub UpdateOiTotals()
            If _apFooter IsNot Nothing Then
                _apFooter.SumAllColumns()
            End If
            Applied = _apFooter.Value("dgvAmount")
            DiscountTaken = _apFooter.Value("dgvDiscTaken")
            UnApplied = Amount - Applied
        End Sub

        Private Sub UpdateRowVatAmounts()
            Dim vatAmt As Integer
            For Each glRow As DataGridViewRow In DataGridViewJournalItems.Rows
                If PresenterObj.IsInputVatAccount(glRow.Cells("dgvAccountIdNo").Value) Then
                    vatAmt = glRow.Cells("dgvDebit").Value - glRow.Cells("dgvCredit").Value
                    glRow.Cells("ItemVatAmount").Value = vatAmt
                End If
            Next
        End Sub

        Private Sub UpdateTotals()
            UpdateJiTotals()
            UpdateOiTotals()
        End Sub

        Private Sub UpdateJiTotals()
            If _jiFooter IsNot Nothing Then
                _jiFooter.SumAllColumns()
                TotalDebits = _jiFooter.Value("dgvDebit")
                TotalCredits = _jiFooter.Value("dgvCredit")
            End If
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
            Dim cashDisbursementRowEntry As DataGridViewRow = DataGridViewJournalItems.Rows(0)

            ' Check if the starting balance row is included in the selected rows
            If DataGridViewJournalItems.SelectedRows.Contains(cashDisbursementRowEntry) Then
                ' Do not allow the user to delete the first row.
                Messaging.Show(True, "MsgFirstRowDeletionNotAllowed")
                ' Cancel the deletion
                e.Cancel = True
            End If
        End Sub

    End Class

End Namespace