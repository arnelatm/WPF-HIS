Imports System.Globalization
Imports System.Windows.Forms
Imports AATM.HIS.Accounts.My.Resources
Imports AATM.HIS.Accounts.PresentationLayer.Models
Imports AATM.HIS.Accounts.PresentationLayer.Presenters
Imports AATM.HIS.Accounts.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Forms

    Public Class CashDisbursementJournalEntry
        Implements ICashDisbursementJournalView, IJournalItemsView, ICadOiItemsView

        Protected DtCadOiInsertTable As New DataTable
        Protected DtCadOiUpdateTable As New DataTable
        Protected DtInsertTable As New DataTable
        Protected DtUpdateTable As New DataTable
        Private ReadOnly _cadOiItemsPresenter As CadOiItemsPresenter
        Private ReadOnly _journalItemsPresenter As CashDisbursementJournalItemsPresenter
        Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat

        Private ReadOnly _payeeOrigWidth As Integer
        Private _accountsByCode

        Private _cadOiItems As List(Of CadOiItemModel)
        Private _journalItems As List(Of JournalItemModel)
        Private _profitCentersByCode
        Private _totalBalance As Decimal = 0
        Private ReadOnly _advancesToSupplierAccountIdNo As Integer

        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            MainTableName = "CashDisbursementJournal"
            IdFieldName = "IdNo"
            SortOrderKey = "IdNo"
            FirstControl = txtReferenceNo

            _payeeOrigWidth = cboPayeeIdNo.Width
            _nfi.NumberDecimalDigits = 2
            PresenterObj = New CashDisbursementJournalPresenter(Me)

            _advancesToSupplierAccountIdNo = PresenterObj.GetadvancesToSupplierAccountIdNo()
            _journalItemsPresenter = New CashDisbursementJournalItemsPresenter(Me)
            _cadOiItemsPresenter = New CadOiItemsPresenter(Me)

            PresenterObj.JournalItemsPresenter = _journalItemsPresenter
            PresenterObj.CadOiItemsPresenter = _cadOiItemsPresenter

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

            DtCadOiInsertTable.Columns.Add("Amount", GetType(Decimal))
            DtCadOiInsertTable.Columns.Add("cadIdNo", GetType(Int32))
            DtCadOiInsertTable.Columns.Add("DiscountTaken", GetType(Decimal))
            DtCadOiInsertTable.Columns.Add("JournalItemIdNo", GetType(Int32))
            DtCadOiInsertTable.Columns.Add("Sequence", GetType(Int32))

            DtCadOiUpdateTable.Columns.Add("Amount", GetType(Decimal))
            DtCadOiUpdateTable.Columns.Add("cadIdNo", GetType(Int32))
            DtCadOiUpdateTable.Columns.Add("DiscountTaken", GetType(Decimal))
            DtCadOiUpdateTable.Columns.Add("IDNo", GetType(Int32))
            DtCadOiUpdateTable.Columns.Add("JournalItemIdNo", GetType(Int32))
            DtCadOiUpdateTable.Columns.Add("Sequence", GetType(Int32))

        End Sub

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

        Public Property cadOiItems As IList(Of CadOiItemModel) Implements ICadOiItemsView.CadOiItems
            Get
                Return _cadOiItems
            End Get
            Set(value As IList(Of CadOiItemModel))
                _cadOiItems = value
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

        Public Property JournalItems As IList(Of JournalItemModel) Implements IJournalItemsView.JournalItems
            Get
                Return _journalItems
            End Get
            Set
                _journalItems = Value
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
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtTotalCredits.Text), _nfi)
            End Get
            Set
                txtTotalCredits.Text = FormatMoney(Value)
            End Set
        End Property

        Public Property TotalDebits As Decimal Implements ICashDisbursementJournalView.TotalDebits
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtTotalDebits.Text), _nfi)
            End Get
            Set
                txtTotalDebits.Text = FormatMoney(Value)
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
            txtJournalCode.Text = AccountStrings.CashDisbursementJournalPrefix
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

            bscadOiItems.Clear()
            DataGridViewCadOiItems.Refresh()

            ResumeLayout()
        End Sub

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If AddMode Then
                txtJournalCode.Text = AccountStrings.CashDisbursementJournalPrefix
            End If
            If PaymentTypeToEnum(PaymentType) <> PaymentTypeSelection.AccountsPayable Then
                If bsJournalItems Is Nothing OrElse bsJournalItems.Count() = 0 Then
                    If MessageBox.Show(AccountStrings.JournalEntry_OnBeforeSave_Empty_Journal_Ask_To_Save,
                                       AccountStrings.JournalEntry_OnBeforeSave_Empty_Journal,
                                       MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Question,
                                       MessageBoxDefaultButton.Button2) = DialogResult.No Then
                        CancelSave = True
                    End If
                End If
            Else
                'If bscadOiItems Is Nothing OrElse bscadOiItems.Count() = 0 Then
                'If MessageBox.Show(AccountStrings.CDEntry_OnBeforeSave_Empty_cadOiItem_Ask_To_Save,
                '                   AccountStrings.CDEntry_OnBeforeSave_Empty_Journal,
                '                   MessageBoxButtons.YesNo,
                '                   MessageBoxIcon.Question,
                '                   MessageBoxDefaultButton.Button2) = DialogResult.No Then
                '    CancelSave = True
                'End If
                'End If
                MakeJournalItem()
            End If
        End Sub

        Public Sub OnParentRecordUpdatedSuccessfully(passedValue As Integer) Handles MyBase.ParentRecordUpdatedSuccessfully, MyBase.ParentRecordAddedSuccessfully

            If AddMode Then
                IdNo = passedValue
            End If
            If DtInsertTable IsNot Nothing Then
                DtInsertTable.Clear()
            End If
            If DtUpdateTable IsNot Nothing Then
                DtUpdateTable.Clear()
            End If
            Dim nRowCount As Integer = 1
            For Each ji In bsJournalItems
                ' loop through the journal entries but ignore zero values (except for first row)
                If ji.Debit = 0 And ji.Credit = 0 And nRowCount <> 1 Then
                    ' ignore zero entries except for the first entry (which is the payment entry)
                    ' allow zero cash amount in cases where adjustments are being made
                Else
                    Dim workRow As DataRow
                    If ji.IdNo = 0 Then
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
                    If ji.IdNo = 0 Then
                        DtInsertTable.Rows.Add(workRow)
                    Else
                        DtUpdateTable.Rows.Add(workRow)
                    End If
                    nRowCount += 1
                End If
            Next
            ' save journal entries
            _journalItemsPresenter.Save(DtInsertTable, DtUpdateTable, IdNo)
            ' save old Open Invoices entry
            Dim oldcadOiItem As List(Of CadOiItemModel)
            If Not AddMode Then
                oldcadOiItem = _cadOiItemsPresenter.GetCadOiItems(IdNo)
            Else
                oldcadOiItem = Nothing
            End If
            If DtCadOiInsertTable IsNot Nothing Then
                DtCadOiInsertTable.Clear()
            End If
            If DtCadOiUpdateTable IsNot Nothing Then
                DtCadOiUpdateTable.Clear()
            End If
            If PaymentTypeToEnum(PaymentType) = PaymentTypeSelection.AccountsPayable Then
                ' if AP Entry generate paid open invoices
                nRowCount = 1
                For Each ji In bscadOiItems
                    If ji.Amount <> 0 Or ji.DiscountTaken <> 0 Then
                        Dim workRow As DataRow
                        If ji.IdNo = 0 Then
                            workRow = DtCadOiInsertTable.NewRow()
                        Else
                            workRow = DtCadOiUpdateTable.NewRow()
                            workRow("IdNo") = ji.IdNo
                        End If
                        workRow("cadIdNo") = IdNo
                        workRow("Sequence") = nRowCount
                        workRow("Amount") = ji.Amount
                        workRow("DiscountTaken") = ji.DiscountTaken
                        workRow("JournalItemIdNo") = ji.JournalItemIdNo
                        If ji.IdNo = 0 Then
                            DtCadOiInsertTable.Rows.Add(workRow)
                        Else
                            DtCadOiUpdateTable.Rows.Add(workRow)
                        End If
                        nRowCount += 1
                    End If
                Next
                ' save the generated open invoices
                _cadOiItemsPresenter.Save(DtCadOiInsertTable, DtCadOiUpdateTable, IdNo)
                ' after saving open invoices apply the paid amount
                Dim newcadOiItem As List(Of CadOiItemModel)
                If AddMode Then
                    ' add Mode so just add the payment
                    newcadOiItem = _cadOiItemsPresenter.GetCadOiItems(IdNo)
                    For Each item In newcadOiItem
                        If item.Amount <> 0 Or item.DiscountTaken <> 0 Then
                            PresenterObj.AddInvoicePayment(item.OpenInvoiceIdNo, item.Amount, item.DiscountTaken)
                        End If
                    Next
                    If UnApplied > 0 Then
                        ' with advance payment
                        Dim items As List(Of JournalItemModel)
                        items = _journalItemsPresenter.GetJournalItems(IdNo)
                        Dim ji As New JournalItemModel
                        For Each item In items
                            If item.AccountIdNo = _advancesToSupplierAccountIdNo And item.OriginalAmount > 0 Then
                                ji.IdNo = item.IdNo
                                ji.AccountIdNo = item.AccountIdNo
                                ji.JournalIdNo = IdNo
                                PresenterObj.AddApOpenInvoice(ji, "CK")
                                Exit For
                            End If
                        Next
                    Else
                        ' no advance payment
                    End If
                Else
                    ' editing mode save the new paid invoices entry
                    newcadOiItem = _cadOiItemsPresenter.GetCadOiItems(IdNo)
                    ' un-apply the old payments
                    For Each Item In oldcadOiItem
                        ' if new
                        If Item.Amount <> 0 Or Item.DiscountTaken <> 0 Then
                            ' remove old payments
                            PresenterObj.RemoveInvoicePayment(Item.OpenInvoiceIdNo, Item.Amount, Item.DiscountTaken)
                        End If
                    Next
                    ' re-apply the new payments
                    For Each Item In bscadOiItems
                        If Item.Amount <> 0 Or Item.DiscountTaken <> 0 Then
                            ' add new payments
                            PresenterObj.AddInvoicePayment(Item.OpenInvoiceIdNo, Item.Amount, Item.DiscountTaken)
                        End If
                    Next
                    If UnApplied > 0 Then
                        ' with advance payment
                        ' get the journalItemIdNo
                        Dim ji As New JournalItemModel
                        Dim jiItems As List(Of JournalItemModel)
                        jiItems = _journalItemsPresenter.GetJournalItems(IdNo)
                        ' get the item.IdNo of the last matching advancesToSupplierAccountIdNo if more than one found
                        For Each item In jiItems
                            If item.AccountIdNo = _advancesToSupplierAccountIdNo And item.OriginalAmount > 0 Then
                                ' if more items found overwrite the old value found and use this one
                                ji.IdNo = item.IdNo
                                ji.AccountIdNo = item.AccountIdNo
                                ji.JournalIdNo = IdNo
                                Exit For
                            End If
                        Next
                        Dim lOpenInvIdNo As Integer
                        ' check if the AdvancePayment OpenInvoice already created
                        lOpenInvIdNo = CInt(_journalItemsPresenter.GetAdvancePaymentOpenInvoice(ji.IdNo))
                        If lOpenInvIdNo = 0 Then
                            ' no previous entry
                            ' add the open invoice
                            PresenterObj.AddApOpenInvoice(ji, "CK")
                        Else
                            ' already added, nothing to do
                        End If
                    Else
                        ' get the OpenInvoice IdNo
                        ' check if the AdvancePayment OpenInvoice already created
                        Dim lOpenInvoiceIdNo As Integer
                        lOpenInvoiceIdNo = CInt(PresenterObj.GetAdvancePaymentOpenIdNo(IdNo))
                        PresenterObj.DeleteApOpenInvoice(lOpenInvoiceIdNo)
                    End If
                End If
            Else
                _cadOiItemsPresenter.Save(DtCadOiInsertTable, DtCadOiUpdateTable, IdNo)
                If oldcadOiItem IsNot Nothing Then
                    For Each Item In oldcadOiItem
                        If Item.Amount <> 0 Or Item.DiscountTaken <> 0 Then
                            PresenterObj.RemoveInvoicePayment(Item.OpenInvoiceIdNo, Item.Amount, Item.DiscountTaken)
                        End If
                    Next
                End If
            End If
        End Sub

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
            'ResourceEnumConverter.MakeResource("MaritalStatusSelection", GetType(MaritalStatusSelection))
            'ResourceEnumConverter.MakeResource("MaleFemaleSelection", GetType(MaleFemaleSelection))
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

        Protected Overrides Function DataIsValid() As Boolean
            Dim retValue As Boolean = False
            If MyBase.DataIsValid() Then
                If PaymentTypeToEnum(PaymentType) = PaymentTypeSelection.AccountsPayable Then
                    _totalBalance = TotalBalance()
                    If _cadOiItemsPresenter.DataIsValid(cadOiItems, DataGridViewCadOiItems, Applied, UnApplied, _totalBalance) Then
                        retValue = True
                    End If
                Else
                    If _journalItemsPresenter.DataIsValid(JournalItems, PaymentType) Then
                        retValue = True
                    End If
                End If
            End If
            Return retValue
        End Function

        Protected Overrides Sub DisplayView()
            MyBase.DisplayView()
            _journalItemsPresenter.Display(TargetIdNo, UndoMode)
            With JournalItems
                TotalDebits = .Sum(Function(totals) totals.Debit)
                TotalCredits = .Sum(Function(totals) totals.Credit)
            End With
            _cadOiItemsPresenter.Display(TargetIdNo, UndoMode)
            If cadOiItems IsNot Nothing Then
                If cadOiItems.Count > 0 Then
                    With cadOiItems
                        Applied = .Sum(Function(totals) totals.Amount)
                        DiscountTaken = .Sum(Function(totals) totals.DiscountTaken)
                    End With
                End If
                _totalBalance = TotalBalance()
            Else
                _totalBalance = 0
            End If
            'PresenterObj.Display(TargetIdNo, UndoMode)
        End Sub

        Private Function TotalBalance() As Decimal
            Return cadOiItems.Sum(Function(totals) totals.Balance)
        End Function

        Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
            If keyData = Keys.F10 Then
                Save()
                Return True
            End If
            Return MyBase.ProcessCmdKey(msg, keyData)
        End Function

        Private Sub AddSupplierOpenInvoices()
            Dim unpaidInvoices = _cadOiItemsPresenter.GetSupplierOpenInvoices(PayeeIdNo)
            Dim newItem As CadOiItemModel
            Dim nSeq As Integer
            If AddMode Then
                bscadOiItems.Clear()
            End If
            If _cadOiItems IsNot Nothing Then
                nSeq = _cadOiItems.Count()
            Else
                nSeq = 0
            End If
            For Each unpaidInvoice In unpaidInvoices
                newItem = _cadOiItems.Find(Function(c) c.JournalItemIdNo = unpaidInvoice.JournalItemIdNo)
                If newItem Is Nothing Then
                    If unpaidInvoice.JournalCode = "CK" And unpaidInvoice.JournalIdNo = IdNo Then
                        ' ignore advance payments if applied to this entry.
                    Else
                        nSeq = nSeq + 1
                        Dim item As New CadOiItemModel With {
                                .AccountIdNo = unpaidInvoice.AccountIdNo,
                                .Amount = unpaidInvoice.Amount,
                                .Balance = unpaidInvoice.Balance,
                                .DiscountTaken = unpaidInvoice.DiscountTaken,
                                .InvoiceNo = unpaidInvoice.InvoiceNo,
                                .JournalCode = unpaidInvoice.JournalCode,
                                .JournalIdNo = unpaidInvoice.JournalIdNo,
                                .JournalItemIdNo = unpaidInvoice.JournalItemIdNo,
                                .OpenInvoiceIdNo = unpaidInvoice.OpenInvoiceIdNo,
                                .PreviousBalance = unpaidInvoice.Balance,
                                .Sequence = nSeq,
                                .TransactionDate = unpaidInvoice.TransactionDate
                                }
                        bscadOiItems.Add(item)
                    End If
                End If
            Next
            DataGridViewCadOiItems.Refresh()

        End Sub

        Private Sub BindCadOiItem()
            SuspendLayout()
            bscadOiItems.DataSource = cadOiItems
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
                    dgvNewBalance.DisplayOnly = True
                    dgvTransactionDate.DisplayOnly = True
                    dgvJournalCode.DisplayOnly = True
                    dgvJournalIdNoJi.DisplayOnly = True
                End If
            End With
            ResumeLayout()
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

        Private Sub cboAccountIdNo_ValueChanged(sender As Object, e As EventArgs) Handles txtAmount.Validated, cboPaymentType.Validated, cboAccountIdNo.Validated
            'cboAccountIdNo.SelectionChangeCommitted, cboAccountIdNo.TextChanged, txtAmount.TextChanged
            UpdateFirstLine()
        End Sub

        Private Sub cboPayeeIdNo_ValueChanged(sender As Object, e As EventArgs) Handles cboPayeeIdNo.Validated
            If PaymentTypeToEnum(PaymentType) = PaymentTypeSelection.AccountsPayable Or PaymentTypeToEnum(PaymentType) = PaymentTypeSelection.Supplier Then
                If PaymentTypeToEnum(PaymentType) = PaymentTypeSelection.AccountsPayable Then
                    If cboPayeeIdNo.PreviousSelectedIndex <> cboPayeeIdNo.SelectedIndex Then
                        bscadOiItems.Clear()
                        UpdateOiTotals()
                    End If
                    AddSupplierOpenInvoices()
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

        Private Sub CashDisbursementJournalEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            KeyPreview = True
            JournalItems = New List(Of JournalItemModel)
            cadOiItems = New List(Of CadOiItemModel)
            BindJournalItem()
            BindCadOiItem()
            DataGridViewJournalItems.Columns("ItemVatAmount").ValueType = GetType(System.Decimal)
            DataGridViewJournalItems.Columns("ItemVatAmount").ReadOnly = False
        End Sub

        Private Sub cadOiItemDgv_OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewCadOiItems.CellEndEdit

            With DataGridViewCadOiItems.CurrentCell
                Select Case .OwningColumn.Name.ToLower()
                    Case $"dgvamount"
                        Dim selectedRow As CadOiItemModel
                        Dim amt = .Value
                        selectedRow = DataGridViewCadOiItems.Rows(.RowIndex).DataBoundItem
                        selectedRow.Balance = selectedRow.PreviousBalance - amt - selectedRow.DiscountTaken
                        UpdateOiTotals()
                        'UpdateTotalVatAmount()
                        'SendKeys.Send("{TAB}")
                    Case $"dgvdiscounttaken"
                        Dim selectedRow As CadOiItemModel
                        Dim amt = .Value
                        selectedRow = DataGridViewCadOiItems.Rows(.RowIndex).DataBoundItem
                        selectedRow.Balance = selectedRow.PreviousBalance - selectedRow.Amount - amt
                        UpdateOiTotals()
                        'UpdateTotalVatAmount()
                        SendKeys.Send("{HOME}{DOWN}{TAB}{TAB}{TAB}")
                    Case $"dgvbalance"
                        SendKeys.Send("{DOWN}")
                End Select
            End With
        End Sub

        Private Sub DataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewJournalItems.CellClick

            With DataGridViewJournalItems.CurrentCell
                Select Case .OwningColumn.Name.ToLower()
                    Case $"dgvinsertcolumn"
                        _journalItemsPresenter.ChangesMadeInJournalItem = True
                        If EditMode OrElse AddMode Then
                            If .RowIndex() = 0 Then
                                MessageBox.Show($"Sorry, insertion on first row not allowed for Cash Disbursement journal.")
                            Else
                                Dim newRow As New JournalItemModel
                                bsJournalItems.Insert(.RowIndex(), newRow)
                                _journalItemsPresenter.ChangesMadeInJournalItem = True
                                ReSequenceDgvAfterInsert(DataGridViewJournalItems, bsJournalItems)
                                SendKeys.Send("{UP}")
                            End If
                        Else
                            MessageBox.Show($"Row insertion not allowed while in view mode. Press edit button to enable insertion.")
                        End If
                End Select
            End With
        End Sub

        Private Sub DataGridViewcadOiItems_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewCadOiItems.CellClick

            With DataGridViewCadOiItems.CurrentCell
                Select Case .OwningColumn.Name.ToLower()
                    'Case $"dgvinsertcolumn"
                    '    _cadOiItemsPresenter.ChangesMadeIncadOiItem = True
                    '    If EditMode OrElse AddMode Then
                    '        Dim newRow As New cadOiItemModel
                    '        bscadOiItems.Insert(.RowIndex(), newRow)
                    '        _cadOiItemsPresenter.ChangesMadeIncadOiItem = True
                    '        ReSequenceDgvAfterInsert(DataGridViewcadOiItems, cadOiItems)
                    '        SendKeys.Send("{UP}")
                    '    Else
                    '        MessageBox.Show($"Row insertion not allowed while in view mode. Press edit button to enable insertion.")
                    '    End If
                End Select
            End With
        End Sub

        Private Sub DataGridViewcadOiItems_ChangesMade(sender As Object, e As EventArgs) Handles DataGridViewCadOiItems.ChangesMade
            _cadOiItemsPresenter.ChangesMadeInCadOiItem = True
        End Sub

        Private Sub DataGridViewcadOiItems_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridViewCadOiItems.UserDeletedRow
            ReSequenceDgvAfterDelete(DataGridViewCadOiItems, cadOiItems)
        End Sub

        Private Sub DataGridViewJournalItems_ChangesMade(sender As Object, e As EventArgs) Handles DataGridViewJournalItems.ChangesMade
            _journalItemsPresenter.ChangesMadeInJournalItem = True
        End Sub

        Private Sub DataGridViewJournalItems_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridViewJournalItems.UserDeletedRow
            ReSequenceDgvAfterDelete(DataGridViewJournalItems, bsJournalItems)
            UpdateTotals()
            UpdateTotalVatAmount()
        End Sub

        Private Sub MakeJournalItem()
            If PaymentTypeToEnum(PaymentType) = PaymentTypeSelection.AccountsPayable Then
                Dim aAccountIdNo As Integer() = {}
                Dim aAmount() As Decimal = {}
                Dim aAdded() As Boolean = {}
                Dim aDiscountTaken() As Decimal = {}
                Dim nSize As Integer = 0
                Dim nIndex As Integer
                ' summarize paid invoices per account
                For Each item In bscadOiItems
                    Dim nAccountIdNo As Integer
                    nAccountIdNo = item.AccountIdNo
                    If item.Amount <> 0 Or item.DiscountTaken <> 0 Then
                        nIndex = Array.IndexOf(aAccountIdNo, nAccountIdNo)
                        If nIndex < 0 Then
                            ReDim Preserve aAccountIdNo(nSize)
                            ReDim Preserve aDiscountTaken(nSize)
                            ReDim Preserve aAmount(nSize)
                            ReDim Preserve aAdded(nSize)
                            aAccountIdNo(nSize) = nAccountIdNo
                            aAmount(nSize) = item.Amount
                            aDiscountTaken(nSize) = item.DiscountTaken
                            nSize = nSize + 1
                        Else
                            aAmount(nIndex) = aAmount(nIndex) + item.Amount
                            aDiscountTaken(nIndex) = aDiscountTaken(nIndex) + item.DiscountTaken
                        End If
                    End If
                Next
                Dim nCounter As Integer = 0
                ' apply the payment to the checking account (the first entry) and zero out the rest of the existing
                ' journal item entries if there are existing journal entries.
                For Each item In bsJournalItems
                    If nCounter = 0 Then
                        item.JournalIdNo = IdNo
                        item.Sequence = 1
                        item.AccountIdNo = AccountIdNo
                        item.Credit = If(Amount < 0, 0, Amount)
                        item.Debit = If(Amount < 0, Amount * -1, 0)
                        item.ProfitCenterIdNo = 0
                        item.Notes = ""
                    Else
                        item.Credit = 0
                        item.Debit = 0
                        item.ProfitCenterIdNo = 0
                        item.Notes = ""
                    End If
                    nCounter = nCounter + 1
                Next
                ' if no existing journal entries, create one for the checking account payment.
                If bsJournalItems Is Nothing Or bsJournalItems.Count = 0 Then
                    Dim item As New JournalItemModel With {
                            .JournalIdNo = IdNo,
                            .Sequence = 1,
                            .AccountIdNo = AccountIdNo,
                            .Credit = If(Amount < 0, 0, Amount),
                            .Debit = If(Amount < 0, Amount * -1, 0),
                            .ProfitCenterIdNo = 0,
                            .Notes = ""
                            }
                    bsJournalItems.Add(item)
                End If
                ' apply now the invoice payment summarized above for each existing AP account
                For i = 0 To aAccountIdNo.Count() - 1
                    For Each ji In bsJournalItems
                        ' if account matches then add the payment and discount
                        If ji.AccountIdNo = aAccountIdNo(i) Then
                            Dim nAmount = aAmount(i) + aDiscountTaken(i)
                            ji.Debit = If(nAmount < 0, 0, nAmount)
                            ji.Credit = If(nAmount < 0, nAmount * -1, 0)
                            aAdded(i) = True
                            Exit For
                        End If
                    Next
                Next
                ' find if the discount taken account exist in the old entries, if found save the discountTaken account
                Dim found As Boolean = False
                For Each ji In bsJournalItems
                    ' ignore the first line entry (this is for the check account)
                    If ji.Sequence <> 1 Then
                        If ji.AccountIdNo = cboDiscountAccountIdNo.SelectedValue Then
                            ji.Debit = If(DiscountTaken < 0, DiscountTaken * -1, 0)
                            ji.Credit = If(DiscountTaken < 0, 0, DiscountTaken)
                            found = True
                        End If
                    End If
                Next
                If Not found Then
                    ' if discount account is not found add a Discount Account Journal Entry and
                    ' add the discount taken amount.
                    If DiscountTaken <> 0 Then
                        Dim item As New JournalItemModel With {
                                .JournalIdNo = IdNo,
                                .Sequence = 0,
                                .AccountIdNo = DiscountAccountIdNo,
                                .Credit = If(DiscountTaken < 0, 0, DiscountTaken),
                                .Debit = If(DiscountTaken < 0, DiscountTaken * -1, 0),
                                .ProfitCenterIdNo = 0,
                                .Notes = ""
                                }
                        bsJournalItems.Add(item)
                    End If
                End If
                ' find and add AP entries not yet added
                nCounter = 0
                For Each item In aAdded
                    If Not item Then
                        ' if the account is not yet added create a AP journal entry for
                        ' the account
                        Dim nAmount As Decimal
                        nAmount = aAmount(nCounter) + aDiscountTaken(nCounter)
                        Dim ji As New JournalItemModel With {
                                .JournalIdNo = IdNo,
                                .Sequence = 0,
                                .AccountIdNo = aAccountIdNo(nCounter),
                                .Credit = If(nAmount < 0, nAmount * -1, 0),
                                .Debit = If(nAmount < 0, 0, nAmount),
                                .ProfitCenterIdNo = 0,
                                .Notes = ""
                                }
                        bsJournalItems.Add(ji)
                    End If
                    nCounter = nCounter + 1
                Next
                If UnApplied > 0 Then
                    ' if invoice not yet fully applied, then save the
                    ' unApplied amount to the "Advances to Supplier" account
                    ' check existing entries for the "Advances to Supplier" account
                    Dim unAppliedSwitch As Int16 = 0
                    For Each item In bsJournalItems
                        ' get the last matching idno for accounts with advancestosupplierAccountIdNo
                        If item.AccountIdNo = _advancesToSupplierAccountIdNo And item.Debit = 0 And item.Credit = 0 And item.OriginalAmount > 0 Then
                            ' debit and credit must be zero otherwise that account has already been used above
                            item.Credit = 0
                            item.Debit = UnApplied
                            unAppliedSwitch = 1
                            Exit For
                        End If
                    Next
                    If unAppliedSwitch = 0 Then
                        ' advance payment journal entry not yet created
                        Dim jiModel As New JournalItemModel With {
                            .JournalIdNo = IdNo,
                            .Sequence = 0,
                            .AccountIdNo = _advancesToSupplierAccountIdNo,
                            .Credit = 0,
                            .Debit = UnApplied,
                            .ProfitCenterIdNo = 0,
                            .Notes = ""
                            }
                        bsJournalItems.Add(jiModel)
                    End If
                Else
                    ' no advance payment so no advances to Supplier Account
                End If
            Else
                bscadOiItems.Clear()
            End If
        End Sub

        Private Sub OnBeforeDisplayView() Handles MyBase.BeforeDisplayView
            Dim cPaymentType = PresenterObj.GetPaymentType(TargetIdNo)
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
                            If _journalItemsPresenter.IsInputVatAccount(newValue) Then
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
                End Select
            End With
        End Sub

        Private Sub OnDisplayedRecordChanged() Handles MyBase.DisplayedRecordChanged
            If Not DataGridViewJournalItems.DataBindings Is Nothing Then
                DataGridViewJournalItems.DataInGridChanged = False
            End If
            If Not DataGridViewCadOiItems.DataBindings Is Nothing Then
                DataGridViewCadOiItems.DataInGridChanged = False
            End If
        End Sub

        Private Sub OnInputsTurnedOff() Handles MyBase.InputsTurnedOff
            DataGridViewJournalItems.StartTrackingChanges = False
            DataGridViewJournalItems.RemoveInsertColumn()
            _journalItemsPresenter.ChangesMadeInJournalItem = False
            DataGridViewCadOiItems.StartTrackingChanges = False
            _cadOiItemsPresenter.ChangesMadeInCadOiItem = False
            If PaymentTypeToEnum(PaymentType) = PaymentTypeSelection.AccountsPayable Then
                btnViewGL.Visible = True
            Else
                btnViewGL.Visible = False
            End If
        End Sub

        Private Sub OnInputsTurnedOn() Handles MyBase.InputsTurnedOn
            DataGridViewJournalItems.StartTrackingChanges = True
            DataGridViewJournalItems.AddInsertColumn()
            AddSupplierOpenInvoices()
            DataGridViewCadOiItems.StartTrackingChanges = True
            _cadOiItemsPresenter.ChangesMadeInCadOiItem = False
            _journalItemsPresenter.ChangesMadeInJournalItem = False
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
                txtTotalCredits.Visible = False
                txtTotalDebits.Visible = False
                lblTotals.Visible = False
            Else
                DataGridViewJournalItems.Visible = True
                DataGridViewCadOiItems.Visible = False
                txtTotalCredits.Visible = True
                txtTotalDebits.Visible = True
                lblTotals.Visible = True
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

        'Private Sub ReSequenceDgvAfterInsert()
        '    Dim i = DataGridViewJournalItems.CurrentCell.RowIndex()
        '    For Each item In JournalItems
        '        If item.Sequence = 0 Then
        '            item.Sequence = i
        '        ElseIf item.Sequence >= i Then
        '            item.Sequence = item.Sequence + 1
        '        End If
        '    Next
        'End Sub
        Private Sub TxtNotes_Leave(sender As Object, e As EventArgs) Handles txtNotes.Leave
            DataGridViewJournalItems.Focus()
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

        Private Sub UpdateOiTotals()
            If cadOiItems IsNot Nothing Then
                Applied = cadOiItems.Sum(Function(totals) totals.Amount)
                DiscountTaken = cadOiItems.Sum(Function(totals) totals.DiscountTaken)
                UnApplied = Amount - Applied
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
            TotalDebits = JournalItems.Sum(Function(totals) totals.Debit)
            TotalCredits = JournalItems.Sum(Function(totals) totals.Credit)
            If cadOiItems IsNot Nothing Then
                _totalBalance = cadOiItems.Sum(Function(totals) totals.Balance)
            Else
                _totalBalance = 0
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
                MessageBox.Show($"Deletion of the first row is not allowed!")
                ' Cancel the deletion
                e.Cancel = True
            End If
        End Sub

        Private _viewGl As Boolean = False

        Private Sub btnViewGL_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnViewGL.ClickButtonArea
            If _viewGl Then
                _viewGl = False
                DataGridViewJournalItems.Visible = False
                DataGridViewCadOiItems.Visible = True
                txtTotalCredits.Visible = False
                txtTotalDebits.Visible = False
                lblTotals.Visible = False
                btnViewGL.Text = "View Journal Entry"
            Else
                _viewGl = True
                DataGridViewJournalItems.Visible = True
                DataGridViewCadOiItems.Visible = False
                txtTotalCredits.Visible = True
                txtTotalDebits.Visible = True
                lblTotals.Visible = True
                btnViewGL.Text = "Hide Journal Entry"
            End If
        End Sub

        Private Sub DataGridViewcadOiItems_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewCadOiItems.CellContentClick

        End Sub

        Private Sub floFullEntryArea_Paint(sender As Object, e As PaintEventArgs) Handles floFullEntryArea.Paint

        End Sub

        'Private Sub OnInputsTurnedOn_Sub() Handles Me.InputsTurnedOn
        '    btnViewGL.Visible = False
        '    SetPayeeProperty(PaymentType)
        'End Sub

        'Private Sub OnInputsTurnedOff_Sub() Handles Me.InputsTurnedOff
        '    If PaymentTypeToEnum(PaymentType) = PaymentTypeSelection.AccountsPayable Then
        '        btnViewGL.Visible = True
        '    Else
        '        btnViewGL.Visible = False
        '    End If
        'End Sub

    End Class

End Namespace