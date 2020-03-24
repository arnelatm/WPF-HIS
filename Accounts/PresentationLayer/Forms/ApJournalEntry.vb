Imports System.Globalization
Imports AATM.Accounts.My.Resources
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Forms

    Public Class ApJournalEntry
        Implements IApJournalView, IJournalItemsView

        Protected DtInsertTable As New DataTable
        Protected DtUpdateTable As New DataTable
        Private ReadOnly _journalItemsPresenter As ApJournalItemsPresenter
        Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat
        Private _accountsByCode
        Private _journalItems As List(Of JournalItemModel)
        Private _profitCentersByCode

        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            MainTableName = "ApJournal"
            IdFieldName = "IdNo"
            SortOrderKey = "IdNo"
            FirstControl = txtReferenceNo
            _nfi.NumberDecimalDigits = 2
            PresenterObj = New ApJournalPresenter(Me)

            _journalItemsPresenter = New ApJournalItemsPresenter(Me)

            PresenterObj.JournalItemsPresenter = _journalItemsPresenter

            DtInsertTable.Columns.Add("AccountIdNo", GetType(Int32))
            DtInsertTable.Columns.Add("Credit", GetType(Decimal))
            DtInsertTable.Columns.Add("Debit", GetType(Decimal))
            DtInsertTable.Columns.Add("JournalIdNo", GetType(Int32))
            DtInsertTable.Columns.Add("Notes", GetType(String))
            DtInsertTable.Columns.Add("ProfitCenterIdNo", GetType(Int32))
            DtInsertTable.Columns.Add("Sequence", GetType(Int32))

            DtUpdateTable.Columns.Add("AccountIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("Credit", GetType(Decimal))
            DtUpdateTable.Columns.Add("Debit", GetType(Decimal))
            DtUpdateTable.Columns.Add("IDNo", GetType(Int32))
            DtUpdateTable.Columns.Add("JournalIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("Notes", GetType(String))
            DtUpdateTable.Columns.Add("ProfitCenterIdNo", GetType(Int32))
            DtUpdateTable.Columns.Add("Sequence", GetType(Int32))

        End Sub

        Public Property AccountIdNo As Integer Implements IApJournalView.AccountIdNo
            Get
                Return cboAccountIdNo.GetValue()
            End Get
            Set
                cboAccountIdNo.SetValue(Value)
            End Set
        End Property

        Public Property Amount As Decimal Implements IApJournalView.Amount
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtAmount.Text), _nfi)
            End Get
            Set
                txtAmount.Text = FormatMoney(Value)
            End Set
        End Property

        Public Property Cancelled As Boolean Implements IApJournalView.Cancelled
            Get
                Return chkCancelled.Checked
            End Get
            Set
                chkCancelled.Checked = Value
            End Set
        End Property

        Public Property DateCreated As DateTime? Implements IApJournalView.DateCreated
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

        Public Property DueDate As Date? Implements IApJournalView.DueDate
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

        Public Property IdNo As Integer Implements IApJournalView.IdNo
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

        Public Property InvoiceDate As Date? Implements IApJournalView.InvoiceDate
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
        End Property

        Public Property InvoiceNo As String Implements IApJournalView.InvoiceNo
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

        Public Property Notes As String Implements IApJournalView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = If(Value, "")
            End Set
        End Property

        Public Property Posted As Boolean Implements IApJournalView.Posted
            Get
                Return chkPosted.Checked
            End Get
            Set(value As Boolean)
                chkPosted.Checked = value
            End Set
        End Property

        Public Property ReferenceNo As String Implements IApJournalView.ReferenceNo
            Get
                Return txtReferenceNo.Text
            End Get
            Set
                txtReferenceNo.Text = Value
            End Set
        End Property

        Public Property SettlementDiscount As Decimal Implements IApJournalView.SettlementDiscount
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

        Public Property SettlementDueDate As Date? Implements IApJournalView.SettlementDueDate
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

        Public Property SupplierIdNo As Integer Implements IApJournalView.SupplierIdNo
            Get
                Return cboSupplierIdNo.GetValue()
            End Get
            Set
                cboSupplierIdNo.SetValue(Value)
            End Set
        End Property

        Public Property TotalCredits As Decimal Implements IApJournalView.TotalCredits
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtTotalCredits.Text), _nfi)
            End Get
            Set
                txtTotalCredits.Text = FormatMoney(Value)
            End Set
        End Property

        Public Property TotalDebits As Decimal Implements IApJournalView.TotalDebits
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtTotalDebits.Text), _nfi)
            End Get
            Set
                txtTotalDebits.Text = FormatMoney(Value)
            End Set
        End Property

        Public Property TransactionDate As Date? Implements IApJournalView.TransactionDate
            Get
                Return dtpTransactionDate.Value
            End Get
            Set
                If Value Is Nothing Then
                    dtpTransactionDate.Value = Date.Now()
                Else
                    dtpTransactionDate.Value = Value
                End If
                UpdateDueDate()
            End Set
        End Property

        Public Property TransactionType As String Implements IApJournalView.TransactionType
            Get
                Return cboTransactionType.GetValue()
            End Get
            Set
                cboTransactionType.SetValue(Value)
            End Set
        End Property

        Public Property VatAmount As Decimal Implements IApJournalView.VatAmount
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtVatAmount.Text), _nfi)
            End Get
            Set
                txtVatAmount.Text = FormatMoney(Value)
            End Set
        End Property

        Public Property VatNumber As String Implements IApJournalView.VatNumber
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
            If AddMode Then
                BtnLast.PerformClick()
            End If
        End Sub

        Public Sub OnBeforeAdd() Handles MyBase.BeforeAdd
            SuspendLayout()
            txtJournalCode.Text = AccountStrings.ApJournalPrefix
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
            If AddMode Then
                txtJournalCode.Text = AccountStrings.ApJournalPrefix

            End If
            If bsJournalItems Is Nothing OrElse bsJournalItems.Count() = 0 Then
                If Messaging.Show(True, "AskEmptyJournalSave", "Journal Entry is Empty, do you still want to save this entry?", "Empty Journal", ) Then
                    'AccountStrings.JournalEntry_OnBeforeSave_Empty_Journal,
                    'MessageBoxButtons.YesNo,
                    'MessageBoxIcon.Question,
                    'MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    CancelSave = True
                End If
            End If
        End Sub

        Public Sub OnParentRecordUpdatedSuccessfully(passedValue As Integer) _
            Handles MyBase.ParentRecordUpdatedSuccessfully, MyBase.ParentRecordAddedSuccessfully

            If AddMode Then
                IdNo = passedValue
            End If
            If DtInsertTable IsNot Nothing Then
                DtInsertTable.Clear()
            End If
            If DtUpdateTable IsNot Nothing Then
                DtUpdateTable.Clear()
            End If
            Dim oldJournalItem As List(Of JournalItemModel)
            If Not AddMode Then
                'oldJournalItem = _journalItemsPresenter.GetRecordsWithIdNo(IdNo)
                oldJournalItem = _journalItemsPresenter.ModelPresenter.GetRecordsWithIdNo(Of JournalItemModel)(IdNo, "Sequence")
            Else
                oldJournalItem = Nothing
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
                nRowCount = nRowCount + 1
            Next
            _journalItemsPresenter.Save(DtInsertTable, DtUpdateTable, IdNo)
            Dim newJournalItem As List(Of JournalItemModel)
            If AddMode Then
                newJournalItem = _journalItemsPresenter.ModelPresenter.GetRecordsWithIdNo(Of JournalItemModel)(IdNo, "Sequence")
                For Each item In newJournalItem
                    If _journalItemsPresenter.IsAccountsPayableAccount(item.AccountIdNo) Then
                        PresenterObj.AddApOpenInvoice(item, "AP")
                    End If
                Next
            Else
                newJournalItem = _journalItemsPresenter.ModelPresenter.GetRecordsWithIdNo(Of JournalItemModel)(IdNo, "Sequence")
                Dim newItem
                Dim oldItem
                Dim newIsAp
                Dim oldIsAp
                For Each oldItem In oldJournalItem
                    ' deletion of paid A.P. entries not allowed (see UserDeletingRow - sub  below) therefore all entries here are unpaid
                    ' so no problem on deletion
                    oldIsAp = _journalItemsPresenter.IsAccountsPayableAccount(oldItem.AccountIdNo)
                    If oldIsAp Then
                        ' this item is AP
                        newItem = newJournalItem.Find(Function(c) c.IdNo = oldItem.IdNo)
                        If newItem Is Nothing Then
                            ' item was deleted
                            PresenterObj.DeleteApOpenInvoice(oldItem.OpenInvoiceIdNo)
                        Else
                            ' item is found
                            newIsAp = _journalItemsPresenter.IsAccountsPayableAccount(newItem.AccountIdNo)
                            If newIsAp Then
                                ' nothing to do
                            Else
                                ' new is changed from AP to non-AP
                                PresenterObj.DeleteApOpenInvoice(oldItem.OpenInvoiceIdNo)
                            End If
                        End If
                    Else
                        ' this item is Non-AP
                        newItem = newJournalItem.Find(Function(c) c.IdNo = oldItem.IdNo)
                        If newItem Is Nothing Then
                            ' item is deleted just ignore Non-AP
                        Else
                            ' old item still in new
                            newIsAp = _journalItemsPresenter.IsAccountsPayableAccount(newItem.AccountIdNo)
                            If newIsAp Then
                                PresenterObj.AddApOpenInvoice(newItem, "AP")
                            Else
                                ' new is also Non-AP
                                ' nothing to do
                            End If
                        End If
                    End If
                Next
                For Each newItem In newJournalItem
                    newIsAp = _journalItemsPresenter.IsAccountsPayableAccount(newItem.AccountIdNo)
                    oldItem = oldJournalItem.Find(Function(c) c.IdNo = newItem.IdNo)
                    If oldItem Is Nothing Then
                        ' this item is new
                        If newIsAp Then
                            ' this new item is an AP
                            PresenterObj.AddApOpenInvoice(newItem, "AP")
                        Else
                            ' non - AP nothing to do
                        End If
                    Else
                        ' old item, already taken off in first (oldItem) for-loop
                    End If
                Next
            End If
        End Sub

        Protected Overrides Sub CreateDataSources()
            _accountsByCode = PresenterObj.GetDetailAccountListByCode()
            _profitCentersByCode = PresenterObj.GetProfitCenterListByCode()
            cboSupplierIdNo.BeginUpdate()
            cboSupplierIdNo.DataSource = PresenterObj.GetSupplierListByCode()
            cboSupplierIdNo.EndUpdate()
            cboTransactionType.BeginUpdate()
            cboTransactionType.DataSource = PresenterObj.MakeEnumComboList(Of TransactionTypeSelection)
            cboTransactionType.EndUpdate()
            cboAccountIdNo.BeginUpdate()
            cboAccountIdNo.DataSource = PresenterObj.GetAccountTypesList(EnumToSpecialAccount(SpecialAccountSelection.AccountsPayable))
            cboAccountIdNo.EndUpdate()
            'ResourceEnumConverter.MakeResource("MaritalStatusSelection", GetType(MaritalStatusSelection))
            'ResourceEnumConverter.MakeResource("MaleFemaleSelection", GetType(MaleFemaleSelection))
        End Sub

        Protected Overrides Sub CreateFieldsDictionary()
            FieldsDictionary = New Dictionary(Of String, Object) From
        {
         {"AccountIdNo", cboAccountIdNo},
         {"Amount", txtAmount},
         {"Cancelled", chkCancelled},
         {"DateCreated", txtDateCreated},
         {"DueDate", dtpDueDate},
         {"IdNo", TxtIDNo},
         {"InvoiceNo", txtInvoiceNo},
         {"Notes", txtNotes},
         {"Posted", chkPosted},
         {"ReferenceNo", txtReferenceNo},
         {"SettlementDiscount", txtSettlementDiscount},
         {"SettlementDueDate", dtpSettlementDueDate},
         {"SupplierIdNo", cboSupplierIdNo},
         {"TotalCredits", txtTotalCredits},
         {"TotalDebits", txtTotalDebits},
         {"TransactionDate", dtpTransactionDate},
         {"TransactionType", cboTransactionType},
         {"VatAmount", txtVatAmount},
         {"VatNumber", txtVatNumber}
        }
        End Sub

        Protected Overrides Function DataIsValid() As Boolean
            Dim retValue As Boolean = False
            If MyBase.DataIsValid() Then
                retValue = _journalItemsPresenter.DataIsValid(JournalItems)
            End If
            Return retValue
        End Function

        Protected Overrides Sub DisplayView()
            MyBase.DisplayView()
            _journalItemsPresenter.Display(TargetIdNo, UndoMode)
            TotalDebits = 0
            TotalCredits = 0
            For Each item In bsJournalItems
                TotalDebits += item.Debit
                TotalCredits += item.Credit
            Next
        End Sub

        Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
            If keyData = Keys.F10 Then
                Save()
                Return True
            End If
            Return MyBase.ProcessCmdKey(msg, keyData)
        End Function

        Private Sub ApJournalEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            KeyPreview = True
            'JournalItems = New List(Of JournalItemModel)
            'BindJournalItem()
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
                dgvProfitCenterIdNo.AutoComplete = AutoCompleteMode.SuggestAppend
                dgvProfitCenterIdNo.DisplayStyleForCurrentCellOnly = True
            End With
            ResumeLayout()
        End Sub

        Private Sub NeedUpdateFirstLine(sender As Object, e As EventArgs) Handles cboAccountIdNo.Validated, cboTransactionType.Validated, txtAmount.Validated
            UpdateFirstLine()
        End Sub

        Private Sub cboAccountIdNo_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cboAccountIdNo.Validating
            If PaymentOrDiscountMade() Then
                ' revert to previous value
                cboAccountIdNo.RevertValue()
            End If
        End Sub

        Private Sub cboSupplierIdNo_Validated(sender As Object, e As EventArgs) Handles cboSupplierIdNo.Validated
            UpdateDueDate()
            UpdateEarlySettlementValues()
            UpdateVatNumber()
        End Sub

        Private Sub cboSupplierIdNo_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cboSupplierIdNo.Validating
            If PaymentOrDiscountMade() Then
                ' revert to previous value
                cboSupplierIdNo.RevertValue()
            End If
        End Sub

        Private Sub DataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) _
                                                            Handles DataGridViewJournalItems.CellClick
            With DataGridViewJournalItems.CurrentCell
                Select Case .OwningColumn.Name.ToLower()
                    Case $"dgvinsertcolumn"
                        _journalItemsPresenter.ChangesMadeInJournalItem = True
                        If EditMode OrElse AddMode Then
                            If .RowIndex() = 0 Then
                                MessageBox.Show("Sorry, insertion on first row not allowed for AP journal.")
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
            ElseIf (DataGridViewJournalItems.CurrentRow.Cells("dgvPaidAmount").Value <> 0 Or DataGridViewJournalItems.CurrentRow.Cells("dgvDiscountTaken").Value <> 0) _
                   And DataGridViewJournalItems.CurrentCell.OwningColumn.Name.ToLower() = $"dgvaccountidno" Then
                Beep()
                e.Cancel = True
                DataGridViewJournalItems.EndEdit()
                MessageBox.Show("Sorry, this account payable has already been partially or fully paid/discounted, changing account Not allowed.")
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
                        If _journalItemsPresenter.IsInputVatAccount(selectedRow.AccountIdNo) Then
                            DataGridViewJournalItems.Rows(.RowIndex).Cells("ItemVatAmount").Value = selectedRow.Debit - selectedRow.Credit
                        End If
                        UpdateTotals()
                        UpdateTotalVatAmount()
                    Case $"dgvnotes"
                        SendKeys.Send("{DOWN}")
                    Case $"dgvaccountidno"
                        Dim newValue = DirectCast(DataGridViewJournalItems.CurrentCell, Libraries.CBaseControlsLibrary.CaDgvComboboxCell).CellEditingControl.GetValue()
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

        Private Sub OnTransactionDateValueChanged(sender As Object, e As EventArgs) Handles dtpTransactionDate.ValueChanged
            UpdateDueDate()
            UpdateEarlySettlementValues()
        End Sub

        Private Function PaymentOrDiscountMade()
            Dim retVal As Boolean = False
            If (DataGridViewJournalItems.Rows(0).Cells("dgvPaidAmount").Value <> 0 Or DataGridViewJournalItems.Rows(0).Cells("dgvDiscountTaken").Value <> 0) Then
                Messaging.Show(True, "MsgPaymentDiscountExistChangeDisallowed",
                               "Sorry, this account payable has already been partially or fully paid/discounted, changing account/supplier not allowed. Value will revert to previous value.",
                               "Modification Error")
                retVal = True
            End If
            Return retVal
        End Function

        Private Sub ReSequenceDgvAfterDelete()
            Dim i = DataGridViewJournalItems.CurrentCell.RowIndex()
            For Each item In bsJournalItems
                If item.Sequence > i + 1 Then
                    item.Sequence = item.Sequence - 1
                End If
            Next
        End Sub

        Private Sub ReSequenceDgvAfterInsert()
            Dim i = DataGridViewJournalItems.CurrentCell.RowIndex()
            For Each item In bsJournalItems
                If item.Sequence = 0 Then
                    item.Sequence = i
                ElseIf item.Sequence >= i Then
                    item.Sequence = item.Sequence + 1
                End If
            Next
        End Sub

        Private Sub txtNotes_Leave(sender As Object, e As EventArgs) Handles txtNotes.Leave
            DataGridViewJournalItems.Focus()
        End Sub

        Private Sub UpdateDueDate()
            If cboSupplierIdNo.Text IsNot Nothing Then
                Dim supplierPaymentDueDays =
                        PresenterObj.GetSupplierPaymentDueDays(cboSupplierIdNo.SelectedValue)
                DueDate = DateAdd("d", supplierPaymentDueDays, TransactionDate)
            Else
                dtpDueDate.Value = TransactionDate
            End If
        End Sub

        Private Sub UpdateEarlySettlementValues()
            If cboSupplierIdNo.Text IsNot Nothing Then
                Dim supplierSettlementDueDays =
                        PresenterObj.GetSupplierSettlementDueDays(cboSupplierIdNo.SelectedValue)
                Dim supplierSettlementDiscount As Decimal
                supplierSettlementDiscount = PresenterObj.GetSupplierSettlementDiscount(cboSupplierIdNo.SelectedValue)
                SettlementDueDate = DateAdd("d", supplierSettlementDueDays, TransactionDate)
                txtSettlementDiscount.Text = supplierSettlementDiscount
            Else
                dtpSettlementDueDate.Value = TransactionDate
                txtSettlementDiscount.Text = 0
            End If
        End Sub

        Private Sub UpdateFirstLine()
            If EditMode Or AddMode Then
                If bsJournalItems IsNot Nothing Then
                    For Each item In bsJournalItems
                        item.JournalIdNo = IdNo
                        item.Sequence = 1
                        If cboAccountIdNo.Text Is Nothing Or cboAccountIdNo.Text = "" Then
                            item.AccountIdNo = Nothing
                        Else
                            item.AccountIdNo = AccountIdNo
                        End If
                        Dim tranType As String = TransactionTypeToEnum(TransactionType)
                        If tranType = TransactionTypeSelection.Invoice Or tranType = TransactionTypeSelection.Credit Then
                            item.Credit = Amount
                            item.Debit = 0
                        Else
                            item.Credit = 0
                            item.Debit = Amount
                        End If
                        item.ProfitCenterIdNo = 0
                        DataGridViewJournalItems.Refresh()
                        Exit For
                    Next
                    UpdateTotals()
                End If
            End If
        End Sub

        Private Sub UpdateRowVatAmounts()
            Dim vatAmt As Integer
            For Each glRow As DataGridViewRow In DataGridViewJournalItems.Rows
                If _journalItemsPresenter.IsInputVatAccount(glRow.Cells("dgvAccountIdNo").Value) Then
                    vatAmt = glRow.Cells("dgvDebit").Value - glRow.Cells("dgvCredit").Value
                    glRow.Cells("ItemVatAmount").Value = vatAmt
                End If
            Next
        End Sub

        Private Sub UpdateTotals()
            TotalDebits = 0
            TotalCredits = 0
            For Each item In bsJournalItems
                TotalDebits += item.Debit
                TotalCredits += item.Credit
            Next
        End Sub

        Private Sub UpdateTotalVatAmount()
            Dim tVatAmount As Decimal = 0
            For Each row In DataGridViewJournalItems.Rows
                tVatAmount = tVatAmount + row.cells("ItemVatAmount").Value
            Next
            VatAmount = tVatAmount
        End Sub

        Private Sub UpdateVatNumber()
            If cboSupplierIdNo.Text IsNot Nothing Then
                VatNumber = PresenterObj.GetSupplierVatNumber(cboSupplierIdNo.SelectedValue)
            Else
                VatNumber = ""
            End If
        End Sub

        Private Sub UserDeletingRow(ByVal sender As Object,
                                            ByVal e As DataGridViewRowCancelEventArgs) _
            Handles DataGridViewJournalItems.UserDeletingRow
            ' Check if the starting balance row is included in the selected rows
            Dim apJournalRow As DataGridViewRow = DataGridViewJournalItems.Rows(0)

            ' Check if the starting balance row is included in the selected rows
            If DataGridViewJournalItems.SelectedRows.Contains(apJournalRow) Then
                ' Do not allow the user to delete the first row.
                Messaging.Show("MsgFirstRowDeletionNotAllowed", "Deletion of the first row Is Not allowed!", "Delete Error")
                ' Cancel the deletion
                e.Cancel = True
            ElseIf DataGridViewJournalItems.CurrentRow.Cells("dgvPaidAmount").Value <> 0 Or
                   DataGridViewJournalItems.CurrentRow.Cells("dgvDiscountTaken").Value <> 0 Then
                ' Do not allow the user to delete the first row.
                Messaging.Show("MsgDeletePaidEntryNotAllowed", "You can't delete this row because this entry has an existing payment and/or discount!", "Delete Error")
                ' Cancel the deletion
                e.Cancel = True
            End If
        End Sub

    End Class

End Namespace