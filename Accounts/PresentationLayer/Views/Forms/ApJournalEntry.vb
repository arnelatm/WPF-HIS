Imports System.ComponentModel
Imports System.Globalization
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.CustomControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Views.Forms

    Public Class ApJournalEntry
        Implements IApJournalView

        Public TxtTotalCredits As Decimal
        Public TxtTotalDebits As Decimal
        Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat
        Private _accountsByCode
        Private _footer As DgvFooter
        Private _journalItems As List(Of IJournalItemView)
        Private _revCostCentersByCode
        Private myPresenter As New ApJournalPresenter(Me)

        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            MainTableName = "ApJournal"
            SortOrderKey = "IdNo"
            FirstControl = txtReferenceNo
            _nfi.NumberDecimalDigits = 2
            PresenterObj = New ApJournalPresenter(Me)
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

        Public Property AccountIdNo As Int16? Implements IApJournalView.AccountIdNo
            Get
                Return cboAccountIdNo.GetNullableValue(Of Int16)
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

        Public Property DueDate As Date? Implements IApJournalView.DueDate
            Get
                Return dtpDueDate.Value
            End Get
            Set
                'If Value.HasValue Then
                '    dtpDueDate.Value = Date.Now()
                'Else
                dtpDueDate.Value = Value
                'End If
            End Set
        End Property

        Public Property IdNo As Int32 Implements IApJournalView.IdNo
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

        Public Property InvoiceDate As Date? Implements IApJournalView.InvoiceDate
            Get
                Return dtpInvoiceDate.Value
            End Get
            Set
                'If String.IsNullOrEmpty(Value) Then
                '    dtpInvoiceDate.Value = Date.Now()
                'Else
                dtpInvoiceDate.Value = Value
                'End If
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

        Public Property JournalItems As List(Of IJournalItemView) Implements IApJournalView.JournalItems
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

        Public Property SupplierIdNo As Int32? Implements IApJournalView.SupplierIdNo
            Get
                Return cboSupplierIdNo.GetNullableValue(Of Int32)
            End Get
            Set
                cboSupplierIdNo.SetValue(Value)
            End Set
        End Property

        Public Property TotalCredits As Decimal Implements IApJournalView.TotalCredits
            Get
                Return TxtTotalCredits
            End Get
            Set(value As Decimal)
                TxtTotalCredits = value
            End Set
        End Property

        Public Property TotalDebits As Decimal Implements IApJournalView.TotalDebits
            Get
                Return TxtTotalDebits
            End Get
            Set(value As Decimal)
                TxtTotalDebits = value
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

#End Region

        Protected Overrides Sub CreateDataSources()
            _accountsByCode = PresenterObj.GetDetailAccountList()
            _revCostCentersByCode = PresenterObj.GetLookup("RevCostCenter")
            cboSupplierIdNo.BeginUpdate()
            cboSupplierIdNo.DataSource = PresenterObj.GetLookup("Supplier")
            cboSupplierIdNo.EndUpdate()
            cboTransactionType.BeginUpdate()
            cboTransactionType.DataSource = PresenterObj.MakeEnumComboList(Of TransactionTypeSelection)
            cboTransactionType.EndUpdate()
            cboAccountIdNo.BeginUpdate()
            cboAccountIdNo.DataSource = PresenterObj.GetAccountTypesList(EnumToCode(SpecialAccountSelection.AccountsPayable))
            cboAccountIdNo.EndUpdate()
        End Sub

        Protected Overrides Sub CreateFieldsDictionary()
            FieldsDictionary = New Dictionary(Of String, Object) From
        {
         {"AccountIdNo", cboAccountIdNo},
         {"Amount", txtAmount},
         {"Cancelled", chkCancelled},
         {"DateCreated", dtpDateCreated},
         {"DueDate", dtpDueDate},
         {"IdNo", TxtIdNo},
         {"InvoiceNo", txtInvoiceNo},
         {"Notes", txtNotes},
         {"Posted", chkPosted},
         {"ReferenceNo", txtReferenceNo},
         {"SettlementDiscount", txtSettlementDiscount},
         {"SettlementDueDate", dtpSettlementDueDate},
         {"SupplierIdNo", cboSupplierIdNo},
         {"TransactionDate", dtpTransactionDate},
         {"TransactionType", cboTransactionType},
         {"VatAmount", txtVatAmount},
         {"VatNumber", txtVatNumber}
        }
        End Sub

        Protected Overrides Sub RecordPositionChanged(ByRef e As RecordPositionChanged)
            'MyBase.RecordPositionChanged(e)
            UpdateTotals()
        End Sub

        Private Sub ApJournalEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            _footer = New DgvFooter(DataGridViewJournalItems) With {
                .AutoCalc = True
            }
            _footer.ColumnToSum("dgvDebit") = True
            _footer.ColumnToSum("dgvCredit") = True
            _footer.SetAlignment("dgvDebit", ContentAlignment.MiddleRight)
            _footer.SetAlignment("dgvCredit", ContentAlignment.MiddleRight)
            _footer.SetText("DgvAccountIdNo", "Totals ->")
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
                dgvRevCostCenterIdNo.DataSource = _revCostCentersByCode
                dgvRevCostCenterIdNo.DisplayMember = "Name"
                dgvRevCostCenterIdNo.ValueMember = "idNo"
                dgvRevCostCenterIdNo.AutoComplete = AutoCompleteMode.SuggestAppend
                dgvRevCostCenterIdNo.DisplayStyleForCurrentCellOnly = True
            End With
            ResumeLayout()
        End Sub

        Private Sub CboAccountIdNo_Validating(sender As Object, e As CancelEventArgs) Handles cboAccountIdNo.Validating
            If PaymentOrDiscountMade() Then
                ' revert to previous value
                cboAccountIdNo.RevertValue()
            End If
        End Sub

        Private Sub CboSupplierIdNo_Validated(sender As Object, e As EventArgs) Handles cboSupplierIdNo.Validated
            UpdateDueDate()
            UpdateEarlySettlementValues()
            UpdateVatNumber()
        End Sub

        Private Sub CboSupplierIdNo_Validating(sender As Object, e As CancelEventArgs) Handles cboSupplierIdNo.Validating
            If PaymentOrDiscountMade() Then
                ' revert to previous value
                cboSupplierIdNo.RevertValue()
            End If
        End Sub

        Private Sub DataGridViewJournalItems_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridViewJournalItems.UserDeletedRow
            UpdateTotals()
            UpdateTotalVatAmount()
        End Sub

        Private Overloads Sub Dispose()
            Close()
            '_footer.Dispose()
        End Sub

        Private Sub NeedUpdateFirstLine(sender As Object, e As EventArgs) Handles cboAccountIdNo.Validated, cboTransactionType.Validated, txtAmount.Validated, cboTransactionType.SelectionChangeCommitted
            PresenterObj.UpdateFirstLine()
            'BindJournalItem()
            UpdateTotals()
            DataGridViewJournalItems.Refresh()
        End Sub

        Private Sub OnCellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) _
            Handles DataGridViewJournalItems.CellBeginEdit
            If DataGridViewJournalItems.CurrentCell.RowIndex() = 0 Then
                With DataGridViewJournalItems.CurrentCell
                    Dim cColumnName = .OwningColumn.Name.ToLower()
                    ' don't allow edits for first line entries account id no and amounts if only single
                    If cColumnName = $"dgvaccountidno" Or ((cColumnName = $"dgvdebit" Or cColumnName = $"dgvcredit") AndAlso PresenterObj.CountApItems() <= 1) Then
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
                Messaging.Show(True, "MsgPaymentDiscExistChangeNotAllowed")
            End If
        End Sub

        Private Sub OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) _
            Handles DataGridViewJournalItems.CellEndEdit
            With DataGridViewJournalItems
                Dim nIndex = DataGridViewJournalItems.CurrentRow.Index
                Select Case .CurrentCell.OwningColumn.Name.ToLower()
                    Case $"dgvaccountidno"
                        Dim newValue = DirectCast(DataGridViewJournalItems.CurrentCell, CaDgvComboboxCell).CellEditingControl.GetValue()
                        If nIndex + 1 <= DataGridViewJournalItems.RowCount() Then
                            If nIndex < bsJournalItems.Count() Then
                                bsJournalItems(nIndex).AccountIdNo = newValue
                                Dim account As AccountModel
                                account = PresenterObj.GetAccount(newValue)
                                With DataGridViewJournalItems.CurrentRow
                                    Dim currentVatAmount As Decimal
                                    If PresenterObj.IsInputVatAccount(newValue) Then
                                        currentVatAmount = .Cells("dgvDebit").Value - .Cells("dgvCredit").Value
                                    Else
                                        currentVatAmount = 0
                                    End If
                                    .Cells("ItemVatAmount").Value = currentVatAmount
                                    bsJournalItems(nIndex).SpecialAccount = account.SpecialAccount
                                    bsJournalItems(nIndex).PayeeType = account.PayeeType
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
                            If PresenterObj.IsInputVatAccount(.CurrentRow.Cells("dgvAccountIdNo").Value) Then
                                .CurrentRow.Cells("ItemVatAmount").Value = .CurrentRow.Cells("dgvDebit").Value - .CurrentRow.Cells("dgvCredit").Value
                            End If
                        End If
                        UpdateTotals()
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
                            If PresenterObj.IsInputVatAccount(.CurrentRow.Cells("dgvAccountIdNo").Value) Then
                                .CurrentRow.Cells("ItemVatAmount").Value = .CurrentRow.Cells("dgvDebit").Value - .CurrentRow.Cells("dgvCredit").Value
                            End If
                        End If
                        If PresenterObj.IsInputVatAccount(.CurrentRow.Cells("dgvAccountIdNo").Value) Then
                            .CurrentRow.Cells("ItemVatAmount").Value = .CurrentRow.Cells("dgvDebit").Value - .CurrentRow.Cells("dgvCredit").Value
                        End If
                        UpdateTotals()
                        UpdateTotalVatAmount()
                    Case $"dgvnotes"
                        SendKeys.Send("{DOWN}")

                End Select
            End With
        End Sub

        Private Sub OnTransactionDateValueChanged(sender As Object, e As EventArgs) Handles dtpTransactionDate.ValueChanged
            UpdateDueDate()
            UpdateEarlySettlementValues()
        End Sub

        Private Function PaymentOrDiscountMade()
            Dim retVal As Boolean = False
            If (DataGridViewJournalItems.Rows(0).Cells("dgvPaidAmount").Value <> 0 Or DataGridViewJournalItems.Rows(0).Cells("dgvDiscountTaken").Value <> 0) Then
                Messaging.Show(True, "MsgPaymentDiscExistChangeNotAllowed")
                retVal = True
            End If
            Return retVal
        End Function

        Private Sub TxtNotes_Leave(sender As Object, e As EventArgs) Handles txtNotes.Leave
            If DataGridViewJournalItems IsNot Nothing Then
                If DataGridViewJournalItems.CurrentCell IsNot Nothing Then
                    DataGridViewJournalItems.Focus()
                    DataGridViewJournalItems.CurrentCell = DataGridViewJournalItems(DataGridViewJournalItems.Columns("dgvRevCostCenterIdNo").Index(), 0)
                End If
            End If
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
            If _footer IsNot Nothing Then
                _footer.CalculateTotals()
                'TotalDebits = _footer.Value("dgvDebit")
                'TotalCredits = _footer.Value("dgvCredit")
            End If
        End Sub

        Private Sub UpdateTotalVatAmount()
            Dim tVatAmount As Decimal = 0
            For Each row In DataGridViewJournalItems.Rows
                tVatAmount += row.cells("ItemVatAmount").Value
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
            Dim apJournalRow As DataGridViewRow = DataGridViewJournalItems.Rows(0)
            If DataGridViewJournalItems.SelectedRows.Contains(apJournalRow) Then
                ' Do not allow the user to delete the first row.
                Messaging.Show(True, "MsgFirstRowDeletionNotAllowed", "Deletion of the first row Is Not allowed!", "Delete Error")
                ' Cancel the deletion
                e.Cancel = True
            ElseIf PresenterObj.EditMode Then
                Dim jiIdNo As Integer
                jiIdNo = DataGridViewJournalItems.CurrentRow.Cells("dgvIdNo").Value
                If PresenterObj.ApPaymentExists("AP", jiIdNo) Then
                    'ElseIf
                    ' Do not allow the user to delete items with existing payments/discounts (prevent orphaned records)
                    Messaging.Show(True, "MsgDeletePaidEntryNotAllowed")
                    ' Cancel the deletion
                    e.Cancel = True
                End If
            End If
        End Sub

    End Class

End Namespace