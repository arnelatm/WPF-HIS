Imports System.Globalization
Imports AATM.Accounts.My.Resources
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Forms

    Public Class PurchaseJournalEntry
        Implements IPurchaseJournalView, IJournalItemsView

        Protected DtInsertTable As New DataTable
        Protected DtUpdateTable As New DataTable
        Private ReadOnly _journalItemsPresenter As PurchaseJournalItemsPresenter
        Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat
        Private _accountsByCode
        Private _journalItems As List(Of JournalItemModel)
        Private _profitCentersByCode
        Private _suppliersByCode

        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            MainTableName = "PurchaseJournal"
            SortOrderKey = "IdNo"
            FirstControl = txtReferenceNo
            _nfi.NumberDecimalDigits = 2
            PresenterObj = New PurchaseJournalPresenter(Me)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)

            'Assign comboboxes datasources

            _journalItemsPresenter = New PurchaseJournalItemsPresenter(Me)

            PresenterObj.JournalItemsPresenter = _journalItemsPresenter

            DtInsertTable.Columns.Add("JournalIdNo", GetType(Int32))
            DtInsertTable.Columns.Add("Sequence", GetType(Int32))
            DtInsertTable.Columns.Add("AccountIdNo", GetType(Int32))
            DtInsertTable.Columns.Add("Debit", GetType(Decimal))
            DtInsertTable.Columns.Add("Credit", GetType(Decimal))
            DtInsertTable.Columns.Add("ProfitCenterIdNo", GetType(Int32))
            DtInsertTable.Columns.Add("Notes", GetType(String))

            DtUpdateTable.Columns.Add("IdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("JournalIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("Sequence", GetType(Int32))
            DtUpdateTable.Columns.Add("AccountIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("Debit", GetType(Decimal))
            DtUpdateTable.Columns.Add("Credit", GetType(Decimal))
            DtUpdateTable.Columns.Add("ProfitCenterIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("Notes", GetType(String))

        End Sub

        Public Property AccountIdNo As Int32? Implements IPurchaseJournalView.AccountIdNo
            Get
                Return cboAccountIdNo.GetValue()
            End Get
            Set
                cboAccountIdNo.SetValue(Value)
            End Set
        End Property

        Public Property Amount As Decimal Implements IPurchaseJournalView.Amount
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtAmount.Text), _nfi)
            End Get
            Set
                txtAmount.Text = FormatMoney(Value)
            End Set
        End Property

        Public Property Cancelled As Boolean Implements IPurchaseJournalView.Cancelled
            Get
                Return chkCancelled.Checked
            End Get
            Set
                chkCancelled.Checked = Value
            End Set
        End Property

        Public Property DateCreated As DateTime? Implements IPurchaseJournalView.DateCreated
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

        Public Property DueDate As Date? Implements IPurchaseJournalView.DueDate
            Get
                Return dtpDueDate.Value
            End Get
            Set
                If String.IsNullOrEmpty(Value) Then
                    dtpDueDate.Value = Date.Now()
                Else
                    dtpDueDate.Value = Value
                End If
            End Set
        End Property

        Public Property IdNo As Int32 Implements IPurchaseJournalView.IdNo
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

        Public Property InvoiceDate As Date? Implements IPurchaseJournalView.InvoiceDate
            Get
                Return dtpInvoiceDate.Value
            End Get
            Set
                If String.IsNullOrEmpty(Value) Then
                    dtpInvoiceDate.Value = Date.Now()
                Else
                    dtpInvoiceDate.Value = Value
                End If
            End Set
            'Get
            '    Dim retDate As Date
            '    Date.TryParse(dtpInvoiceDate.Text, retDate)
            '    Return retDate
            'End Get
            'Set
            '    dtpInvoiceDate.Text = Value
            'End Set
        End Property

        Public Property InvoiceNo As String Implements IPurchaseJournalView.InvoiceNo
            Get
                Return txtInvoiceNo.Text
            End Get
            Set
                txtInvoiceNo.Text = Value
            End Set
        End Property

        Public Property JournalItems As IList(Of JournalItemModel) Implements IJournalItemsView.JournalItems
            Get
                Return _journalItems
            End Get
            Set
                _journalItems = Value
                BindJournalItem()
            End Set
        End Property

        Public Property Notes As String Implements IPurchaseJournalView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = If(Value, "")
            End Set
        End Property

        Public Property Posted As Boolean Implements IPurchaseJournalView.Posted
            Get
                Return chkPosted.Checked
            End Get
            Set
                chkPosted.Checked = Value
            End Set
        End Property

        Public Property PurchaseJournalItemsDataSource As List(Of JournalItemModel)

        Public Property ReferenceNo As String Implements IPurchaseJournalView.ReferenceNo
            Get
                Return txtReferenceNo.Text
            End Get
            Set
                txtReferenceNo.Text = Value
            End Set
        End Property

        Public Property SettlementDiscount As Decimal Implements IPurchaseJournalView.SettlementDiscount
            Get
                If txtSettlementDiscount.Text <> "" Then
                    Return Convert.ToDecimal(txtSettlementDiscount.Text)
                Else
                    Return 0D
                End If
            End Get
            Set
                txtSettlementDiscount.Text = Value
            End Set
        End Property

        Public Property SettlementDueDate As Date? Implements IPurchaseJournalView.SettlementDueDate
            Get
                Return dtpSettlementDueDate.Value
            End Get
            Set
                If Value Is Nothing Then
                    dtpSettlementDueDate.Value = Date.Now()
                Else
                    dtpSettlementDueDate.Value = Value
                End If
            End Set
        End Property

        Public Property SupplierIdNo As Int32 Implements IPurchaseJournalView.SupplierIdNo
            Get
                Return cboSupplierIdNo.GetValue()
            End Get
            Set
                cboSupplierIdNo.SetValue(Value)
            End Set
        End Property

        Public Property TotalCredits As Decimal Implements IPurchaseJournalView.TotalCredits
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtTotalCredits.Text), _nfi)
            End Get
            Set
                txtTotalCredits.Text = FormatMoney(Value)
            End Set
        End Property

        Public Property TotalDebits As Decimal Implements IPurchaseJournalView.TotalDebits
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtTotalDebits.Text), _nfi)
            End Get
            Set
                txtTotalDebits.Text = FormatMoney(Value)
            End Set
        End Property

        Public Property TransactionDate As Date? Implements IPurchaseJournalView.TransactionDate
            Get
                Return dtpTransactionDate.Value
            End Get
            Set
                If Value Is Nothing Then
                    dtpTransactionDate.Value = Date.Now()
                Else
                    dtpTransactionDate.Value = Value
                    If dtpDueDate.Text Is Nothing Then
                        If cboSupplierIdNo.Text IsNot Nothing Then
                            Dim supplierPaymentDueDays =
                                    PresenterObj.GetSupplierPaymentDueDays(cboSupplierIdNo.SelectedValue)
                            Dim supplierSettlementDueDays =
                                    PresenterObj.GetSupplierSettlementDueDays(cboSupplierIdNo.SelectedValue)
                            Dim supplierSettlementDiscount As Decimal
                            supplierSettlementDiscount = PresenterObj.GetSupplierSettlementDiscount(cboSupplierIdNo.SelectedValue)
                            DueDate = DateAdd("d", supplierPaymentDueDays, Value)
                            SettlementDueDate = DateAdd("d", supplierSettlementDueDays, Value)
                            txtSettlementDiscount.Text = supplierSettlementDiscount
                        Else
                            dtpDueDate.Text = Value
                            dtpSettlementDueDate.Text = Value
                            txtSettlementDiscount.Text = 0
                        End If
                    End If
                End If
            End Set
        End Property

        Public Property VatAmount As Decimal Implements IPurchaseJournalView.VatAmount
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtVatAmount.Text), _nfi)
            End Get
            Set
                txtVatAmount.Text = FormatMoney(Value)
            End Set
        End Property

        Public Property VatNumber As String Implements IPurchaseJournalView.VatNumber
            Get
                Return txtVatNumber.Text
            End Get
            Set
                txtVatNumber.Text = Value
            End Set
        End Property

        Public Sub OnAfterSave() Handles MyBase.AfterSave
            If IsEmpty(ReferenceNo) Then
                PresenterObj.UpdateGlReferenceNumber()
            End If
            If PresenterObj.AddMode Then
                btnLast.PerformClick()
            End If
        End Sub

        Public Sub OnBeforeAdd() Handles MyBase.BeforeAdd
            SuspendLayout()
            txtJournalCode.Text = AccountStrings.PurchaseJournalPrefix
            dtpTransactionDate.Value = Date.Now()
            bsJournalItems.Clear()
            Dim item As New JournalItemModel With {
                .JournalIdNo = IdNo,
                .Sequence = 1,
                .AccountIdNo = Nothing,
                .Credit = Amount,
                .Debit = 0,
                .ProfitCenterIdNo = 0,
                .Notes = ""
            }
            bsJournalItems.Add(item)
            DataGridViewJournalItems.Refresh()
            ResumeLayout()
        End Sub

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If PresenterObj.AddMode Then
                txtJournalCode.Text = AccountStrings.PurchaseJournalPrefix
            End If
            If bsJournalItems Is Nothing OrElse bsJournalItems.Count() = 0 Then

                If MessageBox.Show(AccountStrings.JournalEntry_OnBeforeSave_Empty_Journal_Ask_To_Save,
                                   AccountStrings.JournalEntry_OnBeforeSave_Empty_Journal,
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question,
                                   MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    PresenterObj.CancelSave = True
                End If
            End If
        End Sub

        Public Sub OnParentRecordUpdatedSuccessfully(passedValue As Integer) _
            Handles MyBase.ParentRecordUpdatedSuccessfully, MyBase.ParentRecordAddedSuccessfully
            If PresenterObj.AddMode Then
                IdNo = passedValue
            End If
            If DtInsertTable IsNot Nothing Then
                DtInsertTable.Clear()
            End If
            If DtUpdateTable IsNot Nothing Then
                DtUpdateTable.Clear()
            End If
            Dim nRowCount = 1
            For Each ji In bsJournalItems
                Dim workRow As DataRow
                If ji.IdNo <= 0 Then
                    workRow = DtInsertTable.NewRow()
                Else
                    workRow = DtUpdateTable.NewRow()
                    workRow("IdNo") = ji.IdNo
                End If
                workRow("JournalIdNo") = IdNo
                workRow("Sequence") = nRowCount
                workRow("AccountIdNo") = ji.AccountIdNo
                workRow("Debit") = ji.Debit
                workRow("Credit") = ji.Credit
                workRow("ProfitCenterIdNo") = ji.ProfitCenterIdNo
                workRow("Notes") = If(ji.Notes, "")
                If ji.IdNo <= 0 Then
                    DtInsertTable.Rows.Add(workRow)
                Else
                    DtUpdateTable.Rows.Add(workRow)
                End If
                nRowCount += 1
            Next
            _journalItemsPresenter.Save(DtInsertTable, DtUpdateTable, IdNo)
        End Sub

        Protected Overrides Sub CreateDataSources()
            _accountsByCode = PresenterObj.GetDetailAccountListByCode()
            _profitCentersByCode = PresenterObj.GetProfitCenterListByCode()
            cboSupplierIdNo.BeginUpdate()
            cboSupplierIdNo.DataSource = PresenterObj.GetSupplierListByCode()
            cboSupplierIdNo.EndUpdate()
            cboAccountIdNo.BeginUpdate()
            cboAccountIdNo.DataSource = PresenterObj.GetAccountTypesList("AP")
            cboAccountIdNo.EndUpdate()
            'ResourceEnumConverter.MakeResource("MaritalStatusSelection", GetType(MaritalStatusSelection))
            'ResourceEnumConverter.MakeResource("MaleFemaleSelection", GetType(MaleFemaleSelection))
        End Sub

        Protected Overrides Sub CreateFieldsDictionary()
            FieldsDictionary = New Dictionary(Of String, Object) From
        {
         {"IdNo", TxtIdNo},
         {"TransactionDate", dtpTransactionDate},
         {"ReferenceNo", txtReferenceNo},
         {"Amount", txtAmount},
         {"AccountIdNo", cboAccountIdNo},
         {"VatNumber", txtVatNumber},
         {"VatAmount", txtVatAmount},
         {"Posted", chkPosted},
         {"Notes", txtNotes},
         {"Cancelled", chkCancelled},
         {"DateCreated", txtDateCreated}
        }
        End Sub

        Private Sub BindJournalItem()
            SuspendLayout()
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
                dgvProfitCenterIdNo.DisplayStyleForCurrentCellOnly = True
            End With
            ResumeLayout()
        End Sub

        'Private Sub cboAccountIdNo_SelectedIndexChanged(sender As Object, e As EventArgs)
        '    UpdateFirstLine()
        'End Sub

        Private Sub cboAccountIdNo_ValueChanged(sender As Object, e As EventArgs) Handles cboAccountIdNo.SelectionChangeCommitted, cboAccountIdNo.TextChanged
            SuspendLayout()
            If JournalItems Is Nothing OrElse JournalItems.Count() > 0 Then
                Dim item As New JournalItemModel With {
                    .JournalIdNo = IdNo,
                    .Sequence = 1,
                    .AccountIdNo = AccountIdNo,
                    .Credit = Amount,
                    .Debit = 0,
                    .ProfitCenterIdNo = 0,
                    .Notes = ""
                }
            Else
                For Each item In JournalItems
                    item.JournalIdNo = IdNo
                    item.Sequence = 1
                    item.AccountIdNo = AccountIdNo
                    item.Credit = Amount
                    item.Debit = 0
                    item.ProfitCenterIdNo = 0
                    Exit For
                Next
            End If
            UpdateFirstLine()
            ResumeLayout()
        End Sub

        Private Sub DataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) _
            Handles DataGridViewJournalItems.CellClick
            With DataGridViewJournalItems.CurrentCell
                Select Case .OwningColumn.Name.ToLower()
                    Case $"dgvinsertcolumn"
                        _journalItemsPresenter.ChangesMadeInJournalItem = True
                        If PresenterObj.EditMode OrElse PresenterObj.AddMode Then
                            If .RowIndex() = 0 Then
                                MessageBox.Show("Sorry, insertion on first row not allowed for purchase journal.")
                            Else
                                Dim newRow As New JournalItemModel
                                bsJournalItems.Insert(.RowIndex(), newRow)
                                _journalItemsPresenter.ChangesMadeInJournalItem = True
                                ReSequenceDgvAfterInsert()
                                SendKeys.Send("{UP}")
                            End If
                        Else
                            MessageBox.Show($"Row insertion not allowed while in view mode. Press edit button to enable insertion.")
                        End If
                End Select
            End With
        End Sub

        Private Sub DataGridViewJournalItems_ChangesMade(sender As Object, e As EventArgs) Handles DataGridViewJournalItems.ChangesMade
            _journalItemsPresenter.ChangesMadeInJournalItem = True
        End Sub

        Private Sub DataGridViewJournalItems_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridViewJournalItems.UserDeletedRow
            ReSequenceDgvAfterDelete()
            UpdateTotals()
            UpdateTotalVatAmount()
        End Sub

        Private Sub dtpTransactionDate_Leave(sender As Object, e As EventArgs) Handles dtpTransactionDate.Leave
            If DueDate Is Nothing Then
                If cboSupplierIdNo.SelectedValue IsNot Nothing Then
                    Dim supplierPaymentDueDays = PresenterObj.GetSupplierPaymentDueDays(cboSupplierIdNo.SelectedValue)
                    Dim supplierSettlementDueDays =
                            PresenterObj.GetSupplierSettlementDueDays(cboSupplierIdNo.SelectedValue)
                    Dim supplierSettlementDiscount =
                            PresenterObj.GetSupplierSettlementDiscount(cboSupplierIdNo.SelectedValue)
                    DueDate = DateAdd("d", CInt(supplierPaymentDueDays), TransactionDate)
                    InvoiceDate = TransactionDate
                    SettlementDueDate = DateAdd("d", CInt(supplierSettlementDueDays), TransactionDate)
                    SettlementDiscount = supplierSettlementDiscount
                Else
                    DueDate = TransactionDate
                    SettlementDueDate = TransactionDate
                    SettlementDiscount = 0
                End If
            End If
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
                Select Case .OwningColumn.Name.ToLower()
                    Case $"dgvdebit"
                        Dim selectedRow As JournalItemModel
                        Dim amt = .Value
                        selectedRow = DataGridViewJournalItems.Rows(.RowIndex).DataBoundItem
                        If amt <> 0 Then
                            ' must zero out the credit if any value is entered in this cell
                            ' or if negative enter the absolute value on the credit and zero on this cell
                            If amt > 0 Then
                                selectedRow.Credit = 0
                            Else
                                selectedRow.Credit = Math.Abs(amt)
                                selectedRow.Debit = 0
                            End If
                        End If
                        If _journalItemsPresenter.IsInputVatAccount(selectedRow.AccountIdNo) Then
                            DataGridViewJournalItems.Rows(.RowIndex).Cells("ItemVatAmount").Value = selectedRow.Debit - selectedRow.Credit
                        End If
                        UpdateTotals()
                        UpdateTotalVatAmount()
                        SendKeys.Send("{TAB}")
                    Case $"dgvcredit"
                        Dim selectedRow As JournalItemModel
                        Dim amt = .Value
                        selectedRow = DataGridViewJournalItems.Rows(.RowIndex).DataBoundItem
                        If amt <> 0 Then
                            ' must zero out the debit if any value is entered in this cell
                            ' or if negative enter the absolute value on the debit and zero on this cell
                            If amt > 0 Then
                                selectedRow.Debit = 0
                            Else
                                selectedRow.Debit = Math.Abs(amt)
                                selectedRow.Credit = 0
                            End If
                            DataGridViewJournalItems.Refresh()
                        End If
                        Dim nIndex = .RowIndex
                        If _journalItemsPresenter.IsInputVatAccount(selectedRow.AccountIdNo) Then
                            DataGridViewJournalItems.Rows(.RowIndex).Cells("ItemVatAmount").Value = selectedRow.Debit - selectedRow.Credit
                        End If
                        UpdateTotals()
                        UpdateTotalVatAmount()
                    Case $"dgvnotes"
                        SendKeys.Send("{DOWN}")
                    Case $"dgvaccountidno"
                        Dim newValue = DirectCast(DataGridViewJournalItems.CurrentCell, CaDgvComboboxCell).CellEditingControl.GetValue()
                        With DataGridViewJournalItems.CurrentRow
                            Dim currentVatAmount As Decimal
                            If _journalItemsPresenter.IsInputVatAccount(newValue) Then
                                currentVatAmount = .Cells("dgvDebit").Value - .Cells("dgvCredit").Value
                            Else
                                currentVatAmount = 0
                            End If
                            .Cells("ItemVatAmount").Value = currentVatAmount
                        End With
                        UpdateTotalVatAmount()
                End Select
            End With
        End Sub

        Private Sub OnDisplayedRecordChanged() Handles MyBase.DisplayedRecordChanged
            If Not DataGridViewJournalItems.DataBindings Is Nothing Then
                DataGridViewJournalItems.DataInGridChanged = False
            End If
        End Sub

        Private Sub OnInputsTurnedOff() Handles Me.InputsTurnedOff
            DataGridViewJournalItems.StartTrackingChanges = False
            DataGridViewJournalItems.RemoveInsertColumn()
            _journalItemsPresenter.ChangesMadeInJournalItem = False
        End Sub

        Private Sub OnInputsTurnedOn() Handles Me.InputsTurnedOn
            DataGridViewJournalItems.StartTrackingChanges = True
            DataGridViewJournalItems.AddInsertColumn()
            UpdateRowVatAmounts()
            UpdateTotalVatAmount()
            _journalItemsPresenter.ChangesMadeInJournalItem = False
        End Sub

        Private Sub PurchaseJournalEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            KeyPreview = True
            DataGridViewJournalItems.Columns("ItemVatAmount").ValueType = GetType(Decimal)
            DataGridViewJournalItems.Columns("ItemVatAmount").ReadOnly = False
        End Sub

        Private Sub ReSequenceDgvAfterDelete()
            Dim i = DataGridViewJournalItems.CurrentCell.RowIndex()
            For Each item In JournalItems
                If item.Sequence > i + 1 Then
                    item.Sequence = item.Sequence - 1
                End If
            Next
        End Sub

        Private Sub ReSequenceDgvAfterInsert()
            Dim i = DataGridViewJournalItems.CurrentCell.RowIndex()
            For Each item In JournalItems
                If item.Sequence = 0 Then
                    item.Sequence = i
                ElseIf item.Sequence >= i Then
                    item.Sequence = item.Sequence + 1
                End If
            Next
        End Sub

        Private Sub txtAmount_TextChanged(sender As Object, e As EventArgs) Handles txtAmount.TextChanged
            UpdateFirstLine()
        End Sub

        Private Sub txtNotes_Leave(sender As Object, e As EventArgs) Handles txtNotes.Leave
            DataGridViewJournalItems.Focus()
        End Sub

        Private Sub UpdateFirstLine()
            If PresenterObj.EditMode Or PresenterObj.AddMode Then
                If JournalItems IsNot Nothing Then
                    For Each item In JournalItems
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
                    UpdateTotals()
                End If
            End If
        End Sub

        Private Sub UpdateRowVatAmounts()
            Dim vatAmt = 0
            For Each glRow As DataGridViewRow In DataGridViewJournalItems.Rows
                If _journalItemsPresenter.IsInputVatAccount(glRow.Cells("dgvAccountIdNo").Value) Then
                    vatAmt = glRow.Cells("dgvDebit").Value - glRow.Cells("dgvCredit").Value
                    glRow.Cells("ItemVatAmount").Value = vatAmt
                End If
            Next
        End Sub

        Private Sub UpdateTotals()
            TotalDebits = JournalItems.Sum(Function(totals) totals.Debit)
            TotalCredits = JournalItems.Sum(Function(totals) totals.Credit)
        End Sub

        Private Sub UpdateTotalVatAmount()
            Dim tVatAmount As Decimal = 0
            For Each row In DataGridViewJournalItems.Rows
                tVatAmount = tVatAmount + row.cells("ItemVatAmount").Value
            Next
            VatAmount = tVatAmount
        End Sub

        'Private Sub IView_CreateFieldsDictionary() Implements IViewNew.CreateFieldsDictionary
        '    Throw New NotImplementedException()
        'End Sub

        Private Sub UserDeletingRow(ByVal sender As Object,
                                    ByVal e As DataGridViewRowCancelEventArgs) _
            Handles DataGridViewJournalItems.UserDeletingRow
            ' Check if the starting balance row is included in the selected rows
            Dim purchaseJournalRow As DataGridViewRow = DataGridViewJournalItems.Rows(0)

            ' Check if the starting balance row is included in the selected rows
            If DataGridViewJournalItems.SelectedRows.Contains(purchaseJournalRow) Then
                ' Do not allow the user to delete the first row.
                MessageBox.Show("Deletion of the first row is not allowed!")
                ' Cancel the deletion
                e.Cancel = True
            End If
        End Sub

    End Class

End Namespace