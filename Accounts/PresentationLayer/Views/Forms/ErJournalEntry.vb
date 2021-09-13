Imports System.ComponentModel
Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Views.Forms

    Public Class ErJournalEntry
        Implements IErJournalView

        Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat
        Private _accountsByCode
        Private _footer As DgvFooter
        Private _journalItems As List(Of JournalItemView)
        Private _revCostCentersByCode

        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            FirstControl = dtpTransactionDate
            _nfi.NumberDecimalDigits = 2
        End Sub

        '' This event handler provides custom item-creation behavior.
        'Private Sub JiBs_AddingNew(ByVal sender As Object, ByVal e As AddingNewEventArgs) Handles bsJournalItems.AddingNew
        '    e.NewObject = New JournalItemView
        '    ' work around for error on datagrid entry on lastrow please do not remove.
        '    ' The reason it works Is because On a DataGridView where AllowUserToAddRows Is True,
        '    ' it adds an empty row at the end of its rows which if bound to a list creates a null element at the end of the list.
        '    ' The code removes that element And then the AddNew in the BindingList will trigger the DataGridView to add it again
        '    If DataGridViewJournalItems.Rows.Count = bsJournalItems.Count Then
        '        bsJournalItems.RemoveAt(bsJournalItems.Count - 1)
        '    End If
        'End Sub

#Region "Fields"

        Public Property AccountIdNo As Int16? Implements IErJournalView.AccountIdNo
            Get
                Return cboAccountIdNo.GetNullableValue(Of Int16)
            End Get
            Set
                cboAccountIdNo.SetValue(Value)
            End Set
        End Property

        Public Property Amount As Decimal Implements IErJournalView.Amount
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtAmount.Text), _nfi)
            End Get
            Set
                txtAmount.Text = FormatMoney(Value)
            End Set
        End Property

        Public Property Cancelled As Boolean Implements IErJournalView.Cancelled
            Get
                Return chkCancelled.Checked
            End Get
            Set
                chkCancelled.Checked = Value
            End Set
        End Property

        Public Property Approved As Boolean Implements IErJournalView.Approved
            Get
                Return chkApproved.Checked
            End Get
            Set
                chkApproved.Checked = Value
            End Set
        End Property

        Public Property DateCreated As DateTime? Implements IErJournalView.DateCreated
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

        Public Property EmployeeIdNo As Int32? Implements IErJournalView.EmployeeIdNo
            Get
                Return cboEmployeeIdNo.GetNullableValue(Of Int32)
            End Get
            Set
                cboEmployeeIdNo.SetValue(Value)
            End Set
        End Property

        Public Property IdNo As Int32 Implements IErJournalView.IdNo
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

        Public Property JournalItems As List(Of JournalItemView) Implements IErJournalView.JournalItems
            Get
                Return _journalItems
            End Get
            Set
                _journalItems = Value
                BindJournalItem()
            End Set
        End Property

        Public Property Notes As String Implements IErJournalView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = If(Value, "")
            End Set
        End Property

        Public Property Posted As Boolean Implements IErJournalView.Posted
            Get
                Return chkPosted.Checked
            End Get
            Set(value As Boolean)
                chkPosted.Checked = value
            End Set
        End Property

        Public Property ReferenceNo As String Implements IErJournalView.ReferenceNo
            Get
                Return txtReferenceNo.Text
            End Get
            Set
                txtReferenceNo.Text = Value
            End Set
        End Property

        Public ReadOnly Property TotalCredits As Decimal Implements IErJournalView.TotalCredits
            Get
                Return NumParser(Of Decimal)(txtTotalCredits.Text)
            End Get
        End Property

        Public ReadOnly Property TotalDebits As Decimal Implements IErJournalView.TotalDebits
            Get
                Return NumParser(Of Decimal)(txtTotalDebits.Text)
            End Get
        End Property

        Public Property TransactionDate As Date? Implements IErJournalView.TransactionDate
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

        Public Property TransactionType As String Implements IErJournalView.TransactionType
            Get
                Return cboTransactionType.GetValue()
            End Get
            Set
                cboTransactionType.SetValue(Value)
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateDataSources()
            CreateLookupData("Account", NameOf(_accountsByCode), "DetailAccount=1")
            CreateLookupData("RevCostCenter", NameOf(_revCostCentersByCode))
            CreateDataSource("Employee", cboEmployeeIdNo)
            CreateEnumDataSource(Of TransactionTypeSelection)(cboTransactionType)
            CreateSpecialAccountDataSource(Ea, {EnumToCode(SpecialAccountSelection.EmployeeLoan)}, cboAccountIdNo)
        End Sub

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
        {
         {"AccountIdNo", cboAccountIdNo},
         {"Amount", txtAmount},
         {"Cancelled", chkCancelled},
         {"EmployeeIdNo", cboEmployeeIdNo},
         {"DateCreated", dtpDateCreated},
         {"IdNo", TxtIdNo},
         {"Notes", txtNotes},
         {"Posted", chkPosted},
         {"ReferenceNo", txtReferenceNo},
         {"TransactionDate", dtpTransactionDate},
         {"TransactionType", cboTransactionType},
         {"TotalDebits", txtTotalDebits},
         {"TotalCredits", txtTotalCredits}
        }
        End Sub

        Protected Sub OnAfterUpdateView() Handles MyBase.AfterUpdateView
            UpdateTotals()
        End Sub

        Private Sub ErJournalEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            If GlobalVariables.RightToLeftLayout Then
                txtJournalCode.Text = Presenter.GetLocalizedPrefix("ER")
            Else
                txtJournalCode.Text = "ER"
            End If
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

        'Private Sub CboAccountIdNo_Validating(sender As Object, e As CancelEventArgs) Handles cboAccountIdNo.Validating
        '    If PaymentOrDiscountMade() Then
        '        ' revert to previous value
        '        cboAccountIdNo.RevertValue()
        '    End If
        'End Sub

        'Private Sub CboEmployeeIdNo_Validating(sender As Object, e As CancelEventArgs) Handles cboEmployeeIdNo.Validating
        '    If PaymentOrDiscountMade() Then
        '        ' revert to previous value
        '        cboEmployeeIdNo.RevertValue()
        '    End If
        'End Sub

        Private Sub DataGridViewJournalItems_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridViewJournalItems.UserDeletedRow
            UpdateTotals()
        End Sub

        Private Sub NeedUpdateFirstLine(sender As Object, e As EventArgs) Handles cboAccountIdNo.Validated, cboTransactionType.Validated, txtAmount.Validated
            Presenter.UpdateFirstLine()
            UpdateTotals()
            DataGridViewJournalItems.Refresh()
        End Sub

        Private Sub OnCellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) _
            Handles DataGridViewJournalItems.CellBeginEdit
            If DataGridViewJournalItems.CurrentCell.RowIndex() = 0 Then
                With DataGridViewJournalItems.CurrentCell
                    Dim cColumnName = .OwningColumn.Name.ToLower()
                    ' don't allow edits for first line entries account id no and amounts if only single ER
                    If cColumnName = $"dgvaccountidno" Or ((cColumnName = $"dgvdebit" Or cColumnName = $"dgvcredit") AndAlso Presenter.CountErItems() <= 1) Then
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
                Messaging.Show(True, "MsgPaymentCollExistChangeNotAllowed")
            End If
        End Sub

        Private Sub OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewJournalItems.CellEndEdit
            ProcessCellEndEdit(DataGridViewJournalItems, bsJournalItems)
            UpdateTotals()
        End Sub

        'Private Function PaymentOrDiscountMade()
        '    Dim retVal As Boolean = False
        '    If (DataGridViewJournalItems.Rows(0).Cells("dgvPaidAmount").Value <> 0 Or DataGridViewJournalItems.Rows(0).Cells("dgvDiscountTaken").Value <> 0) Then
        '        Messaging.Show(True, "MsgPaymentDiscExistChangeNotAllowed")
        '        retVal = True
        '    End If
        '    Return retVal
        'End Function

        Private Sub TxtNotes_Leave(sender As Object, e As EventArgs) Handles txtNotes.Leave
            MoveToGridView(DataGridViewJournalItems, "dgvRevCostCenterIdNo")
        End Sub

        Private Sub UpdateTotals()
            If _footer IsNot Nothing Then
                _footer.CalculateTotals()
            End If
        End Sub

        Private Sub UserDeletingRow(ByVal sender As Object, ByVal e As DataGridViewRowCancelEventArgs) _
        Handles DataGridViewJournalItems.UserDeletingRow
            Dim erJournalRow As DataGridViewRow = DataGridViewJournalItems.Rows(0)
            If DataGridViewJournalItems.SelectedRows.Contains(erJournalRow) Then
                ' Do not allow the user to delete the first row.
                Messaging.Show(True, "MsgFirstRowDeletionNotAllowed", "Deletion of the first row Is Not allowed!", "Delete Error")
                ' Cancel the deletion
                e.Cancel = True
            End If
        End Sub

    End Class

End Namespace