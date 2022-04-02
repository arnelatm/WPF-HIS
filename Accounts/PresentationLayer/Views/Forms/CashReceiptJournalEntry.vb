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

    Public Class CashReceiptJournalEntry
        Implements ICashReceiptJournalView

        Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat
        Private ReadOnly _payorOrigWidth As Integer

        Private _arFooter As DgvFooter
        Private _csrOiItems As List(Of CsrOiItemView)
        Private _jiFooter As DgvFooter
        Private _journalItems As List(Of JournalItemView)
        Private _defaultAccount As Int16

        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            FirstControl = cboPayorType
            _payorOrigWidth = cboPayorIdNo.Width
            _nfi.NumberDecimalDigits = 2
        End Sub

        'Private Sub JournalItemBs_AddingNew(ByVal sender As Object, ByVal e As AddingNewEventArgs) Handles bsJournalItems.AddingNew
        '    e.NewObject = New JournalItemView
        '    ' work arround for error on datagrid entry on lastrow please do not remove.
        '    ' The reason it works Is because On a DataGridView where AllowUserToAddRows Is True,
        '    ' it adds an empty row at the end of its rows which if bound to a list creates a null element at the end of the list.
        '    ' The code removes that element And then the AddNew in the BindingList will trigger the DataGridView to add it again
        '    If DataGridViewJournalItems.Rows.Count = bsJournalItems.Count Then
        '        bsJournalItems.RemoveAt(bsJournalItems.Count - 1)
        '    End If
        'End Sub

        Private ReadOnly Property OpenInvoiceMode As Boolean
            Get
                Dim payorTypeEnum = CodeToEnum(Of ReceiptTypeSelection)(cboPayorType.SelectedValue)
                If payorTypeEnum = ReceiptTypeSelection.AccountsReceivable Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property

#Region "Fields"

        Public Property AccountsByCode Implements ICashReceiptJournalView.AccountsByCode
        Public Property RevCostCentersByCode Implements ICashReceiptJournalView.RevCostCentersByCode
        Public Property EmployeesByName Implements ICashReceiptJournalView.EmployeesByName
        Public Property CustomersByName Implements ICashReceiptJournalView.CustomersByName
        Public Property SuppliersByName Implements ICashReceiptJournalView.SuppliersByName

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

        Public Property Approved As Boolean Implements ICashReceiptJournalView.Approved
            Get
                Return chkApproved.Checked
            End Get
            Set
                chkApproved.Checked = Value
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

        Public Property JournalItems As List(Of JournalItemView) Implements ICashReceiptJournalView.JournalItems
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

        Public ReadOnly Property TotalCredits As Decimal Implements ICashReceiptJournalView.TotalCredits
            Get
                Return NumParser(Of Decimal)(txtTotalCredits.Text)
            End Get
        End Property

        Public ReadOnly Property TotalDebits As Decimal Implements ICashReceiptJournalView.TotalDebits
            Get
                Return NumParser(Of Decimal)(txtTotalDebits.Text)
            End Get
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

        Public Property VatAmount As Decimal Implements ICashReceiptJournalView.VatAmount
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtVatAmount.Text), _nfi)
            End Get
            Set
                txtVatAmount.Text = FormatMoney(Value)
            End Set
        End Property

        Public Property VatNumber As String Implements ICashReceiptJournalView.VatNumber
            Get
                Return txtVatNumber.Text
            End Get
            Set
                txtVatNumber.Text = Value
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
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
         {"UnApplied", txtUnapplied},
         {"VatAmount", txtVatAmount},
         {"VatNumber", txtVatNumber}
        }
        End Sub

        'Public Sub OnEventHandler(ByRef eventType As BeforeAssignment) Implements ISubscriber(Of BeforeAssignment).OnEventHandler
        '    ' need to do this because the Mapping source part of this program maps the PayeeIdNo first before
        '    ' the ReceiptType so in order to override this part we need to retrieve the ReceiptType first
        '    ' because when assigning the cboPayorIdNo the datasource must be correct that is why
        '    ' we need to set the DataSource part of the cboPayorIdNo before we can assign the PayorIdNo
        '    PayorType = eventType.Model.PayorType
        '    SetPayorDataSource(PayorType)
        '    cboPayorType.SelectedValue = IIf(PayorType = Nothing, 0, PayorType)
        'End Sub

        Protected Sub OnAfterUpdateView() Handles MyBase.AfterUpdateView
            UpdateDisplay()
        End Sub

        Private Sub CashReceiptJournalEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            If GlobalVariables.RightToLeftLayout Then
                txtJournalCode.Text = Presenter.GetLocalizedPrefix("CR")
            Else
                txtJournalCode.Text = "CR"
            End If
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

            If Presenter.CrAccountCount = 1 Then
                cboAccountIdNo.DisplayOnly = True
                cboAccountIdNo.TabStop = False
            End If
            If cboAccountIdNo.SelectedValue <= 0 Then
                cboAccountIdNo.SelectedValue = _defaultAccount
            End If
            If Presenter.CrAccountCount = 0 Then
                Dim accountName As String
                accountName = Messaging.TranslateCaption("Cash")
                Messaging.ShowPmMessage(True, "MsgNoSpecialAccount", {"specialAccountName", accountName})
                Presenter.GoQuit()
            End If
            BindCsrOiItem()
            BindJournalItem()
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

        Public Overloads Sub Dispose()
            Close()
        End Sub

        Private Sub UpdateOpenInvoicesDisplay()
            If OpenInvoiceMode Then
                If Presenter.AddMode Or cboPayorIdNo.ValueChanged() Then
                    CsrOiItems.Clear()
                End If
                bsCsrOiItems.DataSource = Presenter.GetCustomerOpenInvoices(CsrOiItems)
                bsCsrOiItems.ResetBindings(True)
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

        Private Sub CboPayorIdNo_ValueChanged(sender As Object, e As EventArgs) Handles cboPayorIdNo.Validated, cboPayorIdNo.SelectionChangeCommitted
            If OpenInvoiceMode Then
                UpdateOpenInvoicesDisplay()
            Else
                If CodeToEnum(Of ReceiptTypeSelection)(PayorType) = ReceiptTypeSelection.SupplierRefund Then
                    Presenter.SetSupplierVatNumber(VatNumber, PayorIdNo, True)
                Else
                    VatNumber = ""
                End If
            End If
        End Sub

        Private Sub CboPayorType_ValueChanged(sender As Object, e As EventArgs) Handles cboPayorType.SelectionChangeCommitted, cboPayorType.Validated
            SetPayorDataSource(PayorType)
            If OpenInvoiceMode Then
                UpdateOpenInvoicesDisplay()
                If cboPayorIdNo.SelectedIndex = -1 Then
                    bsCsrOiItems.Clear()
                End If
            Else
                cboPayorIdNo.SelectedIndex = -1
            End If
            UpdateFirstLine()
            UpdateDisplay()
        End Sub

        Private Sub CboAccountIdNo_Changed(sender As Object, e As EventArgs) Handles cboAccountIdNo.SelectionChangeCommitted, cboAccountIdNo.Validated
            UpdateFirstLine()
        End Sub

        Private Sub TxtNotes_Leave(sender As Object, e As EventArgs) Handles txtNotes.Leave
            If OpenInvoiceMode Then
                MoveToGridView(DataGridViewCsrOiItems, "dgvAmount")
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
                            Dim accountId = DirectCast(DataGridViewJournalItems.CurrentCell, CDgvComboBoxCell).CellEditingControl.GetValue()
                            If DataGridViewJournalItems.CurrentRow.Index = DataGridViewJournalItems.NewRowIndex Then
                                bsJournalItems.AddNew()
                                JournalItems(nIndex).AccountIdNo = accountId
                                ' adding a new row to the bindingsource adds a new empty row at the end with null values
                                ' therefore there is a need to remove that row because it causes errors when moving to that empty row
                                bsJournalItems.RemoveAt(bsJournalItems.Count - 1)
                            End If
                            Presenter.MakePayTypeAndSpecialAccount(JournalItems(nIndex), accountId)
                            UpdateInputVatAmount()
                            bsJournalItems.ResetItem(nIndex)
                            DataGridViewJournalItems.Refresh()
                        Case $"dgvdebit"
                            Presenter.MakeDebitAmount(JournalItems(nIndex), .CurrentCell.Value)
                            UpdateJiTotals()
                            UpdateInputVatAmount()
                            bsJournalItems.ResetItem(nIndex)
                            SendKeys.Send("{TAB}")
                        Case $"dgvcredit"
                            Presenter.MakeCreditAmount(JournalItems(nIndex), .CurrentCell.Value)
                            UpdateJiTotals()
                            UpdateInputVatAmount()
                            bsJournalItems.ResetItem(nIndex)
                        Case $"dgvnotes"
                            SendKeys.Send("{DOWN}")
                    End Select
                End If
            End With
        End Sub

        Private Sub CsrOiItemDgv_OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewCsrOiItems.CellEndEdit
            With DataGridViewCsrOiItems
                If .CurrentRow IsNot Nothing Then
                    Select Case .CurrentCell.OwningColumn.Name.ToLower()
                        Case $"dgvamount"
                            Dim selectedRow As CsrOiItemView
                            Dim amt = .CurrentCell.Value
                            selectedRow = DataGridViewCsrOiItems.Rows(.CurrentCell.RowIndex).DataBoundItem
                            selectedRow.Balance = selectedRow.PreviousBalance - amt - selectedRow.DiscountTaken
                            UpdateOiTotals()
                        Case $"dgvdiscounttaken"
                            Dim selectedRow As CsrOiItemView
                            Dim amt = .CurrentCell.Value
                            selectedRow = DataGridViewCsrOiItems.Rows(.CurrentCell.RowIndex).DataBoundItem
                            selectedRow.Balance = selectedRow.PreviousBalance - selectedRow.Amount - amt
                            UpdateOiTotals()
                        Case $"dgvbalance"
                            SendKeys.Send("{DOWN}")
                    End Select
                End If
            End With
        End Sub

        Private Sub UpdateInputVatAmount()
            VatAmount = Presenter.UpdateInputVatAmount(JournalItems)
        End Sub

        Private Sub UpdateOutputVatAmount()
            VatAmount = Presenter.UpdateOutputVatAmount(JournalItems)
        End Sub

        Private Sub DataGridViewJournalItems_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridViewJournalItems.UserDeletedRow
            UpdateTotals()
            Dim payorTypeEnum = CodeToEnum(Of ReceiptTypeSelection)(cboPayorType.SelectedIndex)
            If payorTypeEnum = ReceiptTypeSelection.AccountsReceivable Or payorTypeEnum = ReceiptTypeSelection.Customer Then
                UpdateOutputVatAmount()
            ElseIf payorTypeEnum = ReceiptTypeSelection.SupplierRefund Then
                UpdateInputVatAmount()
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
            If _arFooter IsNot Nothing Then
                _arFooter.CalculateTotals()
                Applied = _arFooter.Value("dgvAmount")
                DiscountTaken = _arFooter.Value("dgvDiscountTaken")
                UnApplied = Amount - Applied
            End If
        End Sub

        Private Sub UpdateJiTotals()
            If _jiFooter IsNot Nothing Then
                _jiFooter.CalculateTotals()
                txtTotalDebits.Text = _jiFooter.Value("dgvDebit")
                txtTotalCredits.Text = _jiFooter.Value("dgvCredit")
            End If
            Applied = Amount
            UnApplied = 0
            DataGridViewJournalItems.Refresh()
        End Sub

        'Private Sub UpdateVatNumber()
        '    If cboPayorIdNo.Text IsNot Nothing Then
        '        VatNumber = MyPresenter.GetSupplierVatNumber(cboPayorIdNo.SelectedValue)
        '    Else
        '        VatNumber = ""
        '    End If
        'End Sub

        Private Sub UserDeletingRow(ByVal sender As Object, ByVal e As DataGridViewRowCancelEventArgs) Handles DataGridViewJournalItems.UserDeletingRow
            Dim crJournalRow As DataGridViewRow = DataGridViewJournalItems.Rows(0)
            If DataGridViewJournalItems.SelectedRows.Contains(crJournalRow) Then
                ' Do not allow the user to delete the first row.
                Messaging.Show(True, "MsgFirstRowDeletionNotAllowed", "Deletion of the first row Is Not allowed!", "Delete Error")
                ' Cancel the deletion
                e.Cancel = True
            End If
        End Sub

        Private Sub BtnViewGL_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnViewGL.ClickButtonArea
            If DataGridViewJournalItems.Visible Then
                btnViewGL.Text = Messaging.TranslateCaption("View Journal Entry")
                ShowOpenInvoicesDataGrid()
            Else
                btnViewGL.Text = Messaging.TranslateCaption("Show Journal Entry")
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
            ShowPayor()
            UpdateTotals()
            If Presenter.EditMode Or Presenter.AddMode Then
                If OpenInvoiceMode Then
                    btnAutoApply.Visible = True
                Else
                    btnAutoApply.Visible = False
                End If
            End If
            ResumeLayout()
        End Sub

        Private Sub ShowPayor()
            Dim payorTypeEnum = CodeToEnum(Of ReceiptTypeSelection)(cboPayorType.SelectedValue)
            If payorTypeEnum = ReceiptTypeSelection.Others Or payorTypeEnum = ReceiptTypeSelection.NotSpecified Then
                cboPayorIdNo.Visible = False
                txtPayorName.Visible = True
                txtPayorName.Width = _payorOrigWidth
                cboPayorIdNo.SelectedIndex = -1
                cboPayorIdNo.Width = 0
            Else
                cboPayorIdNo.Visible = True
                txtPayorName.Visible = False
                cboPayorIdNo.Width = _payorOrigWidth
                txtPayorName.Width = 0
            End If
        End Sub

        Private Sub OnInputsTurnedOff() Handles MyBase.InputsTurnedOff
            If OpenInvoiceMode Then
                btnViewGL.Visible = True
                btnViewGL.Text = Messaging.TranslateCaption("View Journal Entry")
            Else
                btnViewGL.Visible = False
            End If
            btnAutoApply.Visible = False
        End Sub

        Private Sub OnInputsTurnedOn() Handles MyBase.InputsTurnedOn
            bsJournalItems.ResetBindings(False)
            btnViewGL.Visible = False
            Presenter.AddCustomerOpenInvoices()
            bsCsrOiItems.ResetBindings(False)
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
            DataGridViewCsrOiItems.Visible = False
            DataGridViewJournalItems.DataSource = bsJournalItems
        End Sub

        Private Sub ShowOpenInvoicesDataGrid()
            DataGridViewJournalItems.Visible = False
            DataGridViewCsrOiItems.Visible = True
        End Sub

        Public Sub SetPayorDataSource(cPayorType As String)
            Dim cbDataSource = Nothing
            Dim curValue As Int32? = cboPayorIdNo.SelectedValue
            cboPayorIdNo.DataSource = cbDataSource
            If OpenInvoiceMode Then
                cbDataSource = Presenter.GetLookup("Customer")
            Else
                Dim payorTypeEnum = CodeToEnum(Of ReceiptTypeSelection)(cPayorType)
                If payorTypeEnum = ReceiptTypeSelection.Customer Then
                    cbDataSource = Presenter.GetLookup("Customer")
                ElseIf payorTypeEnum = ReceiptTypeSelection.Employee Then
                    cbDataSource = Presenter.GetLookup("Employee")
                ElseIf payorTypeEnum = ReceiptTypeSelection.SupplierRefund Then
                    cbDataSource = Presenter.GetLookup("Supplier")
                End If
            End If
            cboPayorIdNo.DataSource = cbDataSource
            If curValue IsNot Nothing Then
                cboPayorIdNo.SelectedValue = curValue
            Else
                cboPayorIdNo.SelectedValue = -1
            End If
        End Sub

        Private Sub UpdateFirstLine()
            Presenter.UpdateFirstLine()
            If Not OpenInvoiceMode Then
                bsJournalItems.ResetBindings(True)
                UpdateJiTotals()
            End If
        End Sub

        Private Sub btnAutoApply_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnAutoApply.ClickButtonArea
            Presenter.AutoApplyAmount()
            DataGridViewCsrOiItems.Refresh()
            UpdateOiTotals()
        End Sub

    End Class

End Namespace