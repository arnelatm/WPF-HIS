Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms

    Public Class CashReceiptJournalEntry
        Implements ICashReceiptJournalView

        Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat
        Private ReadOnly _payorOrigWidth As Integer

        Private _arFooter As DgvFooter
        Private _contactDataSource As DataTable
        Private _csrOiItems As List(Of CsrOiItemView)
        Private _defaultAccount As Int16
        Private _jiFooter As DgvFooter
        Private _journalItems As List(Of JournalItemView)
        Private _sw As Int32 = 0

        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            FirstControl = cboPayorType
            _nfi.NumberDecimalDigits = 2
            _payorOrigWidth = cboContactIdNo.Width
            SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        End Sub

        Public Event AddCustomerOpenInvoices(bs As BindingSource) Implements ICashReceiptJournalView.AddCustomerOpenInvoices

        Public Event AutoApplyAmountRequested(bsCsrOiItems As BindingSource) Implements ICashReceiptJournalView.AutoApplyAmountRequested

        Public Event ContactIdNoChanged(bs As BindingSource) Implements ICashReceiptJournalView.ContactIdNoChanged

        Public Event CreditAmountChanged(sender As Object, e As DataGridViewCellEventArgs) Implements ICashReceiptJournalView.CreditAmountChanged

        Public Event DebitAccountIdNoChanged(bs As BindingSource) Implements ICashReceiptJournalView.DebitAccountIdNoChanged
        Public Event DebitAmountChanged(sender As Object, e As DataGridViewCellEventArgs) Implements ICashReceiptJournalView.DebitAmountChanged
        Public Event FirstLineUpdateNeeded() Implements ICashReceiptJournalView.FirstLineUpdateNeeded

        Public Event JiAccountIdNoChanged(sender As Object, e As DataGridViewCellEventArgs) Implements ICashReceiptJournalView.JiAccountIdNoChanged
        'Public Event FirstLineUpdateNeeded() Implements ICashReceiptJournalView.FirstLineUpdateNeeded
        Public Event OpenInvoiceDataRequested(bs As BindingSource) Implements ICashReceiptJournalView.OpenInvoiceDataRequested
        Public Event ReceiptAmountChanged(bsJournalItem As BindingSource, bsCsrJournalItem As BindingSource) Implements ICashReceiptJournalView.ReceiptAmountChanged
        Public Event ReceiptTypeChanged(paymentType As String, bsJournalItem As BindingSource, bsCsrOiItems As BindingSource) Implements ICashReceiptJournalView.ReceiptTypeChanged
        Public Event UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Implements ICashReceiptJournalView.UserDeletedRow
#Region "Properties"

        Public Property AccountIdNo As Int16? Implements ICashReceiptJournalView.AccountIdNo
            Get
                Return cboAccountIdNo.GetNullableValue(Of Int16)
            End Get
            Set
                cboAccountIdNo.SetValue(Value)
            End Set
        End Property

        Public Property AccountsByCode Implements ICashReceiptJournalView.AccountsByCode
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

        Public Property CashReceiptAccountCount As Short Implements ICashReceiptJournalView.CashReceiptAccountCount
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

        Public Property ContactDataSource As DataTable Implements ICashReceiptJournalView.ContactDataSource
            Get
                Return _contactDataSource
            End Get
            Set
                _contactDataSource = Value
                cboContactIdNo.DataSource = Nothing
                cboContactIdNo.DataSource = Value
                cboContactIdNo.Refresh()
            End Set
        End Property

        Public Property ContactIdNo As Integer? Implements ICashReceiptJournalView.ContactIdNo
            Get
                Return cboContactIdNo.GetNullableValue(Of Int32)
            End Get
            Set
                cboContactIdNo.SetValue(Value)
            End Set
        End Property

        Public Property CSEIdNo As Integer? Implements ICashReceiptJournalView.CSEIdNo
            Get
                If txtCSEIdNo.Text <> "" Then
                    Return Convert.ToInt32(txtCSEIdNo.Text)
                Else
                    Return 0
                End If
            End Get
            Set
                txtCSEIdNo.Text = Convert.ToString(Value)
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

        Public Property DateCreated As DateTime? Implements ICashReceiptJournalView.DateCreated
            Get
                Return txtDateCreated.Text
            End Get
            Set
                If Value.HasValue Then
                    txtDateCreated.Text = Value
                Else
                    txtDateCreated.Text = Date.Now()
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

        Public Property JournalCode As String Implements ICashReceiptJournalView.JournalCode
        Public Property JournalCodeDisplay As String Implements ICashReceiptJournalView.JournalCodeDisplay
            Get
                Return txtJournalCodeDisplay.GetValue(Of String)
            End Get
            Set(value As String)
                txtJournalCodeDisplay.Text = value
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

        Public Property OpenInvoiceMode As Boolean Implements ICashReceiptJournalView.OpenInvoiceMode

        Public Property ORNumber As String Implements ICashReceiptJournalView.OrNumber
            Get
                Return txtORNumber.Text
            End Get
            Set
                txtORNumber.Text = Value
            End Set
        End Property

        Public Property PayorIdNo As Int32? Implements ICashReceiptJournalView.PayorIdNo

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

        Public Property RevCostCentersByCode Implements ICashReceiptJournalView.RevCostCentersByCode
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
#End Region 'Properties

#Region "Subs"

        Public Overloads Sub Dispose()
            Close()
        End Sub

        Public Overrides Function GetPrintParameters() As Object
            Return Me.FormCulture
        End Function

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
        {
         {"AccountIdNo", cboAccountIdNo},
         {"Amount", txtAmount},
         {"Applied", txtApplied},
         {"Cancelled", chkCancelled},
         {"CheckDate", dtpCheckDate},
         {"CheckNumber", txtCheckNumber},
         {"CSEIdNo", cboContactIdNo},
         {"DateCreated", txtDateCreated},
         {"DiscountAccountIdNo", cboDiscountAccountIdNo},
         {"DiscountTaken", txtDiscountTaken},
         {"IdNo", TxtIdNo},
         {"Notes", txtNotes},
         {"OrNumber", txtORNumber},
         {"PayorType", cboPayorType},
         {"PayorName", txtPayorName},
         {"Posted", chkPosted},
         {"ReferenceNo", txtReferenceNo},
         {"TransactionDate", dtpTransactionDate},
         {"UnApplied", txtUnapplied},
         {"VatAmount", txtVatAmount},
         {"VatNumber", txtVatNumber},
         {"TotalDebits", txtTotalDebits},
         {"TotalCredits", txtTotalCredits}
        }
        End Sub


        Protected Sub OnAfterUpdateView() Handles MyBase.AfterUpdateView
            UpdateDisplay()
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

        Private Sub btnAutoApply_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnAutoApply.ClickButtonArea
            RaiseEvent AutoApplyAmountRequested(bsCsrOiItems)
            UpdateOiTotals()
        End Sub

        Private Sub CashReceiptJournalEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

            If CashReceiptAccountCount = 1 Then
                cboAccountIdNo.DisplayOnly = True
                cboAccountIdNo.TabStop = False
            End If
            If cboAccountIdNo.SelectedValue <= 0 Then
                cboAccountIdNo.SelectedValue = _defaultAccount
            End If
            If CashReceiptAccountCount = 0 Then
                Dim accountName As String
                accountName = Messaging.TranslateCaption("Cash")
                Messaging.ShowPmMessage(True, "MsgNoSpecialAccount", {"specialAccountName", accountName})
                CancelClose = False

            End If
            BindCsrOiItem()
            BindJournalItem()
        End Sub

        Private Sub cboContactIdNo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboContactIdNo.SelectionChangeCommitted
            RaiseEvent ContactidNoChanged(bsCsrOiItems)
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
            RaiseEvent AddCustomerOpenInvoices(bsCsrOiItems)
            bsCsrOiItems.ResetBindings(False)
            UpdateDisplay()
            If OpenInvoiceMode Then
                btnAutoApply.Visible = True
            Else
                btnAutoApply.Visible = False
            End If
        End Sub

        Private Sub SalesJournalEntry_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
            btnPrint.Visible = False
            btnPrintWithArgs.Visible = True
        End Sub
        Private Sub ShowJournalItemDataGrid()
            'UpdateFirstLine()
            UpdateTotals()
            DataGridViewJournalItems.Visible = True
            DataGridViewCsrOiItems.Visible = False
            DataGridViewJournalItems.DataSource = bsJournalItems
        End Sub

        Private Sub ShowOpenInvoicesDataGrid()
            DataGridViewJournalItems.Visible = False
            DataGridViewCsrOiItems.Visible = True
        End Sub

        Private Sub ShowPayor()
            Dim payorTypeEnum = CodeToEnum(Of ReceiptTypeSelection)(cboPayorType.SelectedValue)
            If payorTypeEnum = ReceiptTypeSelection.Others Or payorTypeEnum = ReceiptTypeSelection.NotSpecified Then
                cboContactIdNo.Visible = False
                cboContactIdNo.Width = 0
                txtPayorName.Visible = True
                cboContactIdNo.SelectedIndex = -1
                txtPayorName.Width = _payorOrigWidth
            Else
                cboContactIdNo.Visible = True
                cboContactIdNo.Width = _payorOrigWidth
                txtPayorName.Visible = False
                txtPayorName.Width = 0
            End If
        End Sub

        Private Sub UpdateDisplay()
            SuspendLayout()
            If OpenInvoiceMode Then
                ShowOpenInvoicesDataGrid()
                cboDiscountAccountIdNo.Enabled = True
                btnViewGL.Visible = True
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
            If AddingMode OrElse EditingMode Then
                If OpenInvoiceMode Then
                    btnAutoApply.Visible = True
                Else
                    btnAutoApply.Visible = False
                End If
            End If
            ResumeLayout()
        End Sub

        'Private Sub UpdateFirstLine()
        '    'RaiseEvent FirstLineUpdateNeeded()
        '    If Not OpenInvoiceMode Then
        '        bsJournalItems.ResetBindings(True)
        '        UpdateJiTotals()
        '    End If
        'End Sub

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

        Private Sub UpdateOiTotals()
            If _arFooter IsNot Nothing Then
                _arFooter.CalculateTotals()
                Applied = _arFooter.Value("dgvAmount")
                DiscountTaken = _arFooter.Value("dgvDiscountTaken")
                UnApplied = Amount - Applied
            End If
        End Sub

        Private Sub UpdateOpenInvoicesDisplay()
            If CsrOiItems IsNot Nothing Then
                If AddingMode Or cboContactIdNo.ValueChanged() Then
                    CsrOiItems.Clear()
                End If
                RaiseEvent OpenInvoiceDataRequested(bsCsrOiItems)
                bsCsrOiItems.ResetBindings(True)
                UpdateOiTotals()
            End If
        End Sub

        Private Sub UpdateTotals()
            If OpenInvoiceMode Then
                UpdateOiTotals()
            Else
                UpdateJiTotals()
            End If
        End Sub

        'Private Sub cboPayContactIdNo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboContactIdNo.SelectionChangeCommitted
        '    RaiseEvent ContactidNoChanged(bsCsrOiItems)
        'End Sub
        'Private Sub cboContactIdNo_Validated(sender As Object, e As EventArgs) Handles cboContactIdNo.Validated
        '    If AddingMode OrElse EditingMode Then
        '        RaiseEvent ContactidNoChanged(bsCsrOiItems)
        '    End If
        'End Sub
#End Region


#Region "Event Handlers"

        Private Sub BtnViewGL_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnViewGL.ClickButtonArea
            If DataGridViewJournalItems.Visible Then
                btnViewGL.Text = Messaging.TranslateCaption("View Journal Entry")
                ShowOpenInvoicesDataGrid()
            Else
                btnViewGL.Text = Messaging.TranslateCaption("Show Journal Entry")
                ShowJournalItemDataGrid()
            End If
        End Sub

        Private Sub CboAccountIdNo_Changed(sender As Object, e As EventArgs) Handles cboAccountIdNo.SelectedValueChanged
            If AddingMode OrElse EditingMode Then
                If Not OpenInvoiceMode Then
                    RaiseEvent DebitAccountIdNoChanged(bsJournalItems)
                Else
                    ' nothing to do, values for JournalItem will be auto-generated or computed based on paid invoices
                End If
            End If
        End Sub

        Private Sub CboContactIdNo_ValueChanged(sender As Object, e As EventArgs) Handles cboContactIdNo.SelectedValueChanged
            If AddingMode OrElse EditingMode Then
                If OpenInvoiceMode Then
                    UpdateOpenInvoicesDisplay()
                End If
            End If
        End Sub

        Private Sub CboPayorType_ValueChanged(sender As Object, e As EventArgs) Handles cboPayorType.SelectedValueChanged
            If AddingMode OrElse EditingMode Then
                RaiseEvent ReceiptTypeChanged(PayorType, bsJournalItems, bsCsrOiItems)
                If OpenInvoiceMode Then
                    UpdateOpenInvoicesDisplay()
                    If cboContactIdNo.SelectedIndex = -1 Then
                        bsCsrOiItems.Clear()
                    End If
                Else
                    cboContactIdNo.SelectedIndex = -1
                End If
                'UpdateFirstLine()
                UpdateDisplay()
            End If
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

        Private Sub DataGridViewJournalItems_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridViewJournalItems.UserDeletedRow
            RaiseEvent UserDeletedRow(sender, e)
            UpdateTotals()
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
                            RaiseEvent JiAccountIdNoChanged(sender, e)
                        Case $"dgvdebit"
                            RaiseEvent DebitAmountChanged(sender, e)
                            UpdateJiTotals()
                            SendKeys.Send("{TAB}")
                        Case $"dgvcredit"
                            RaiseEvent CreditAmountChanged(sender, e)
                            UpdateJiTotals()
                        Case $"dgvnotes"
                            SendKeys.Send("{DOWN}")
                    End Select
                End If
            End With
        End Sub

        Private Sub TxtAmount_Validated(sender As Object, e As EventArgs) Handles txtAmount.Validated
            RaiseEvent ReceiptAmountChanged(bsJournalItems, bsCsrOiItems)
            'RaiseEvent ReceiptAmountChanged(bsJournalItems)
            'If OpenInvoiceMode Then
            ' UpdateOiTotals()
            'End If
            'UpdateFirstLine()
        End Sub

        Private Sub TxtNotes_Leave(sender As Object, e As EventArgs) Handles txtNotes.Leave
            If OpenInvoiceMode Then
                MoveToGridView(DataGridViewCsrOiItems, "dgvAmount")
            Else
                MoveToGridView(DataGridViewJournalItems, "dgvRevCostCenterIdNo")
            End If
        End Sub

        Private Sub UserDeletingRow(ByVal sender As Object, ByVal e As DataGridViewRowCancelEventArgs) Handles DataGridViewJournalItems.UserDeletingRow
            Dim crJournalRow As DataGridViewRow = DataGridViewJournalItems.Rows(0)
            If DataGridViewJournalItems.SelectedRows.Contains(crJournalRow) Then
                ' Do not allow the user to delete the first row.
                Messaging.Show(True, "MsgFirstRowDeletionNotAllowed", "Deletion of the first row Is Not allowed!", "Delete Error")
                ' Cancel the deletion
                e.Cancel = True
            End If
        End Sub
#End Region

    End Class

End Namespace