Imports System.Globalization
Imports AATM.Accounts.My.Resources
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Forms

    Public Class CashReceiptJournalEntry
        Implements ICashReceiptJournalView, IJournalItemsView, ICsrOiItemsView

        Protected DtCsrOiInsertTable As New DataTable
        Protected DtCsrOiUpdateTable As New DataTable
        Protected DtInsertTable As New DataTable
        Protected DtUpdateTable As New DataTable
        Private ReadOnly _csrOiItemsPresenter As CsrOiItemsPresenter
        Private ReadOnly _journalItemsPresenter As CashReceiptJournalItemsPresenter
        Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat

        Private ReadOnly _payorOrigWidth As Integer
        Private _accountsByCode

        Private _csrOiItems As List(Of CsrOiItemModel)
        Private _journalItems As List(Of JournalItemModel)
        Private _profitCentersByCode
        Private _totalBalance As Decimal = 0
        Private ReadOnly _advancesToCustomerAccountIdNo As Integer

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

            _advancesToCustomerAccountIdNo = PresenterObj.getCustomerAdvancesAccountIdNo()
            _journalItemsPresenter = New CashReceiptJournalItemsPresenter(Me)
            _csrOiItemsPresenter = New CsrOiItemsPresenter(Me)

            PresenterObj.JournalItemsPresenter = _journalItemsPresenter
            PresenterObj.CsrOiItemsPresenter = _csrOiItemsPresenter

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

            DtCsrOiInsertTable.Columns.Add("Amount", GetType(Decimal))
            DtCsrOiInsertTable.Columns.Add("CsrIdNo", GetType(Int32))
            DtCsrOiInsertTable.Columns.Add("DiscountTaken", GetType(Decimal))
            DtCsrOiInsertTable.Columns.Add("JournalItemIdNo", GetType(Int32))
            DtCsrOiInsertTable.Columns.Add("Sequence", GetType(Int32))

            DtCsrOiUpdateTable.Columns.Add("Amount", GetType(Decimal))
            DtCsrOiUpdateTable.Columns.Add("CsrIdNo", GetType(Int32))
            DtCsrOiUpdateTable.Columns.Add("DiscountTaken", GetType(Decimal))
            DtCsrOiUpdateTable.Columns.Add("IDNo", GetType(Int32))
            DtCsrOiUpdateTable.Columns.Add("JournalItemIdNo", GetType(Int32))
            DtCsrOiUpdateTable.Columns.Add("Sequence", GetType(Int32))

        End Sub

        Public Property AccountIdNo As Integer Implements ICashReceiptJournalView.AccountIdNo
            Get
                Return cboAccountIdNo.GetValue()
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

        Public Property CsrOiItems As IList(Of CsrOiItemModel) Implements ICsrOiItemsView.CsrOiItems
            Get
                Return _csrOiItems
            End Get
            Set(value As IList(Of CsrOiItemModel))
                _csrOiItems = value
                BindCsrOiItem()
            End Set
        End Property

        Public Property DateCreated As DateTime? Implements ICashReceiptJournalView.DateCreated
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

        Public Property DiscountAccountIdNo As Integer Implements ICashReceiptJournalView.DiscountAccountIdNo
            Get
                Return cboDiscountAccountIdNo.GetValue()
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

        Public Property IdNo As Integer Implements ICashReceiptJournalView.IdNo
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

        Public Property PayorIdNo As Integer Implements ICashReceiptJournalView.PayorIdNo
            Get
                Return cboPayorIdNo.GetValue()
            End Get
            Set
                cboPayorIdNo.SetValue(Value)
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
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtTotalCredits.Text), _nfi)
            End Get
            Set
                txtTotalCredits.Text = FormatMoney(Value)
            End Set
        End Property

        Public Property TotalDebits As Decimal Implements ICashReceiptJournalView.TotalDebits
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtTotalDebits.Text), _nfi)
            End Get
            Set
                txtTotalDebits.Text = FormatMoney(Value)
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
            txtJournalCode.Text = AccountStrings.CashReceiptJournalPrefix
            dtpTransactionDate.Value = Date.Now()
            bsJournalItems.Clear()
            Dim item As New JournalItemModel With {
                .JournalIdNo = IdNo,
                .Sequence = 1,
                .AccountIdNo = Nothing,
                .Credit = 0,
                .Debit = Amount,
                .ProfitCenterIdNo = 0,
                .Notes = ""
            }
            bsJournalItems.Add(item)
            DataGridViewJournalItems.Refresh()

            bsCsrOiItems.Clear()
            DataGridViewCsrOiItems.Refresh()

            ResumeLayout()
        End Sub

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If PresenterObj.AddMode Then
                txtJournalCode.Text = AccountStrings.CashReceiptJournalPrefix
            End If
            If ReceiptTypeToEnum(PayorType) <> ReceiptTypeSelection.AccountsReceivable Then
                If bsJournalItems Is Nothing OrElse bsJournalItems.Count() = 0 Then
                    If MessageBox.Show(AccountStrings.JournalEntry_OnBeforeSave_Empty_Journal_Ask_To_Save,
                                       AccountStrings.JournalEntry_OnBeforeSave_Empty_Journal,
                                       MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Question,
                                       MessageBoxDefaultButton.Button2) = DialogResult.No Then
                        PresenterObj.CancelSave = True
                    End If
                End If
            Else
                'If bsCsrOiItems Is Nothing OrElse bsCsrOiItems.Count() = 0 Then
                'If MessageBox.Show(AccountStrings.CREntry_OnBeforeSave_Empty_CsrOiItem_Ask_To_Save,
                '                   AccountStrings.CDEntry_OnBeforeSave_Empty_Journal,
                '                   MessageBoxButtons.YesNo,
                '                   MessageBoxIcon.Question,
                '                   MessageBoxDefaultButton.Button2) = DialogResult.No Then
                '    CancelSave = True
                'End If
                'End If
                MakeJournalItem()
                UpdateTotals()
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
            Dim nRowCount As Integer = 1
            For Each ji In bsJournalItems
                ' loop through the journal entries but ignore zero values (except for first row)
                If ji.Debit = 0 And ji.Credit = 0 And nRowCount <> 1 Then
                    ' ignore zero entries except for the first entry (which is the payment entry)
                    ' allow zero cash amount in cases where adjustments are being made
                Else
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
                End If
            Next
            ' save journal entries
            _journalItemsPresenter.Save(DtInsertTable, DtUpdateTable, IdNo)
            ' save old Open Invoices entry
            Dim oldCsrOiItem As List(Of CsrOiItemModel)
            If Not PresenterObj.AddMode Then
                oldCsrOiItem = _csrOiItemsPresenter.GetCsrOiItems(IdNo)
            Else
                oldCsrOiItem = Nothing
            End If
            If DtCsrOiInsertTable IsNot Nothing Then
                DtCsrOiInsertTable.Clear()
            End If
            If DtCsrOiUpdateTable IsNot Nothing Then
                DtCsrOiUpdateTable.Clear()
            End If
            If ReceiptTypeToEnum(PayorType) = ReceiptTypeSelection.AccountsReceivable Then
                ' if AR Entry generate paid open invoices
                nRowCount = 1
                For Each ji In bsCsrOiItems
                    If ji.Amount <> 0 Or ji.DiscountTaken <> 0 Then
                        Dim workRow As DataRow
                        If ji.IdNo <= 0 Then
                            workRow = DtCsrOiInsertTable.NewRow()
                        Else
                            workRow = DtCsrOiUpdateTable.NewRow()
                            workRow("IdNo") = ji.IdNo
                        End If
                        workRow("CsrIdNo") = IdNo
                        workRow("Sequence") = nRowCount
                        workRow("Amount") = ji.Amount
                        workRow("DiscountTaken") = ji.DiscountTaken
                        workRow("JournalItemIdNo") = ji.JournalItemIdNo
                        If ji.IdNo <= 0 Then
                            DtCsrOiInsertTable.Rows.Add(workRow)
                        Else
                            DtCsrOiUpdateTable.Rows.Add(workRow)
                        End If
                        nRowCount += 1
                    End If
                Next
                ' save the generated open invoices
                _csrOiItemsPresenter.Save(DtCsrOiInsertTable, DtCsrOiUpdateTable, IdNo)
                ' after saving open invoices apply the paid amount
                Dim newCsrOiItem As List(Of CsrOiItemModel)
                If PresenterObj.AddMode Then
                    ' add Mode so just add the payment
                    newCsrOiItem = _csrOiItemsPresenter.GetCsrOiItems(IdNo)
                    For Each item In newCsrOiItem
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
                            If item.AccountIdNo = _advancesToCustomerAccountIdNo Then
                                ji.IdNo = item.IdNo
                                ji.AccountIdNo = item.AccountIdNo
                                ji.JournalIdNo = IdNo
                                PresenterObj.AddArOpenInvoice(ji, "CR")
                                Exit For
                            End If
                        Next
                    Else
                        ' no advance payment
                    End If
                Else
                    'editing mode save the new paid invoices entry
                    newCsrOiItem = _csrOiItemsPresenter.GetCsrOiItems(IdNo)
                    'un-apply the old payments
                    For Each Item In oldCsrOiItem
                        'if new
                        If Item.Amount <> 0 Or Item.DiscountTaken <> 0 Then
                            ' remove old payments
                            PresenterObj.RemoveInvoicePayment(Item.OpenInvoiceIdNo, Item.Amount, Item.DiscountTaken)
                        End If
                    Next
                    ' re-apply the new payments
                    For Each Item In bsCsrOiItems
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
                        ' get the item.IdNo of the last matching advancesToCustomerAccountIdNo if more than one found
                        For Each item In jiItems
                            If item.AccountIdNo = _advancesToCustomerAccountIdNo And item.OriginalAmount > 0 Then
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
                            PresenterObj.AddArOpenInvoice(ji, "CR")
                        Else
                            ' already added, nothing to do
                        End If
                    Else
                        ' get the OpenInvoice IdNo
                        ' check if the AdvancePayment OpenInvoice already created
                        Dim lOpenInvoiceIdNo As Integer
                        lOpenInvoiceIdNo = CInt(PresenterObj.GetCustomerAdvancesOpenIdNo(IdNo))
                        PresenterObj.DeleteArOpenInvoice(lOpenInvoiceIdNo)
                    End If
                End If
            Else
                _csrOiItemsPresenter.Save(DtCsrOiInsertTable, DtCsrOiUpdateTable, IdNo)
                If oldCsrOiItem IsNot Nothing Then
                    For Each Item In oldCsrOiItem
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
            cboAccountIdNo.BeginUpdate()
            cboAccountIdNo.DataSource = PresenterObj.GetAccountTypesList("CS,CK,BA")
            cboAccountIdNo.EndUpdate()
            cboPayorType.BeginUpdate()
            cboPayorType.DataSource = PresenterObj.MakeEnumComboList(Of ReceiptTypeSelection)
            cboPayorType.EndUpdate()
            cboDiscountAccountIdNo.BeginUpdate()
            cboDiscountAccountIdNo.DataSource = PresenterObj.GetAccountTypesList("RD")
            cboDiscountAccountIdNo.EndUpdate()
            'ResourceEnumConverter.MakeResource("MaritalStatusSelection", GetType(MaritalStatusSelection))
            'ResourceEnumConverter.MakeResource("MaleFemaleSelection", GetType(MaleFemaleSelection))
            'ResourceEnumConverter.MakeResource("ReceiptTypeSelection", GetType(ReceiptTypeSelection))
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
         {"DateCreated", txtDateCreated},
         {"DiscountAccountIdNo", cboDiscountAccountIdNo},
         {"DiscountTaken", txtDiscountTaken},
         {"IdNo", TxtIDNo},
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

        Protected Overrides Function DataIsValid() As Boolean
            Dim retValue As Boolean = False
            If MyBase.DataIsValid() Then
                If ReceiptTypeToEnum(PayorType) = ReceiptTypeSelection.AccountsReceivable Then
                    _totalBalance = TotalBalance()
                    If _csrOiItemsPresenter.DataIsValid(bsCsrOiItems, Applied, UnApplied, _totalBalance) Then
                        retValue = True
                    Else
                        Dim index As Int16 = 0
                        For Each item In bsCsrOiItems
                            If item.Errors IsNot Nothing Then
                                DataGridViewCsrOiItems.Rows(index).Cells("dgvAmount").ErrorText = String.Join(",", CsrOiItems(index).Errors)
                            Else
                                DataGridViewCsrOiItems.Rows(index).ErrorText = ""
                            End If
                            index += 1
                        Next
                    End If
                Else
                    If _journalItemsPresenter.DataIsValid(JournalItems, PayorType) Then
                        retValue = True
                    End If
                End If
            End If
            Return retValue
        End Function

        Protected Overrides Sub DisplayView(ByVal idNoOfRecord As Integer)
            MyBase.DisplayView(idNoOfRecord)
            _journalItemsPresenter.Display(idNoOfRecord)
            TotalDebits = 0
            TotalCredits = 0
            For Each item In bsJournalItems
                TotalDebits += item.Debit
                TotalCredits += item.Credit
            Next
            _csrOiItemsPresenter.Display(idNoOfRecord)
            If bsCsrOiItems IsNot Nothing Then
                Applied = 0
                DiscountTaken = 0
                _totalBalance = 0
                For Each item In bsCsrOiItems
                    Applied += item.Amount
                    DiscountTaken += item.DiscountTaken
                    _totalBalance += item.Balance
                Next
            End If
            'PresenterObj.Display(PresenterObj.TargetIdNo)
        End Sub

        Private Function TotalBalance() As Decimal
            'Return bsCadOiItems.Cast (Of Object)().Aggregate (Of Decimal)(0, Function(current, item) current + item.Balance)
            Dim nTotalBalance As Decimal = 0
            For Each item In bsCsrOiItems
                nTotalBalance += item.Balance
            Next
            Return nTotalBalance
        End Function

        Private Sub AddCustomerOpenInvoices()
            Dim unpaidInvoices = _csrOiItemsPresenter.GetCustomerOpenInvoices(PayorIdNo)
            Dim nSeq As Integer
            If PresenterObj.AddMode Then
                bsCsrOiItems.Clear()
            End If
            If _csrOiItems Is Nothing Then
                nSeq = 0
            Else
                nSeq = _csrOiItems.Count()
            End If
            For Each unpaidInvoice In unpaidInvoices
                Dim itemFound = False
                If bsCsrOiItems IsNot Nothing Then
                    For Each item In bsCsrOiItems
                        If item.JournalItemIdNo = unpaidInvoice.JournalItemIdNo And item.JournalCode = unpaidInvoice.JournalCode Then
                            itemFound = True
                        End If
                    Next
                End If
                If Not itemFound Then

                    If unpaidInvoice.JournalCode = "CR" And unpaidInvoice.JournalIdNo = IdNo Then
                        ' ignore advance payments if applied to this entry.
                    Else
                        nSeq = nSeq + 1
                        Dim item As New CsrOiItemModel With {
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
                        bsCsrOiItems.Add(item)
                    End If
                End If
            Next
            DataGridViewCsrOiItems.Refresh()
        End Sub

        Private Sub BindCsrOiItem()
            SuspendLayout()
            bsCsrOiItems.DataSource = CsrOiItems
            bsCsrOiItems.AllowNew = True
            With DataGridViewCsrOiItems
                .Refresh()
                .AutoGenerateColumns = False
                .DataSource = bsCsrOiItems
                .Refresh()
                .AllowUserToAddRows = True
                .AllowUserToDeleteRows = True
            End With
            With DataGridViewCsrOiItems.Columns
                If dgvSequenceCsrOi IsNot Nothing Then
                    dgvSequenceCsrOi.DisplayOnly = True
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

        Private Sub cboAccountIdNo_ValueChanged(sender As Object, e As EventArgs) Handles txtAmount.Validated, cboPayorType.Validated, cboAccountIdNo.Validated
            'cboAccountIdNo.SelectionChangeCommitted, cboAccountIdNo.TextChanged, txtAmount.TextChanged
            UpdateFirstLine()
        End Sub

        Private Sub cboPayorIdNo_ValueChanged(sender As Object, e As EventArgs) Handles cboPayorIdNo.Validated
            If ReceiptTypeToEnum(PayorType) = ReceiptTypeSelection.AccountsReceivable Or ReceiptTypeToEnum(PayorType) = ReceiptTypeSelection.Customer Then
                If ReceiptTypeToEnum(PayorType) = ReceiptTypeSelection.AccountsReceivable Then
                    If cboPayorIdNo.PreviousSelectedIndex <> cboPayorIdNo.SelectedIndex Then
                        bsCsrOiItems.Clear()
                        UpdateOiTotals()
                    End If
                    AddCustomerOpenInvoices()
                End If
            End If
        End Sub

        Private Sub cboPayorType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPayorType.SelectionChangeCommitted
            SetPayorProperty(cboPayorType.SelectedValue)
        End Sub

        Private Sub CashReceiptJournalEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            KeyPreview = True
        End Sub

        Private Sub CsrOiItemDgv_OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewCsrOiItems.CellEndEdit
            With DataGridViewCsrOiItems.CurrentCell
                Select Case .OwningColumn.Name.ToLower()
                    Case $"dgvamount"
                        Dim selectedRow As CsrOiItemModel
                        Dim amt = .Value
                        selectedRow = DataGridViewCsrOiItems.Rows(.RowIndex).DataBoundItem
                        selectedRow.Balance = selectedRow.PreviousBalance - amt - selectedRow.DiscountTaken
                        UpdateOiTotals()
                        'UpdateTotalVatAmount()
                        'SendKeys.Send("{TAB}")
                    Case $"dgvdiscounttaken"
                        Dim selectedRow As CsrOiItemModel
                        Dim amt = .Value
                        selectedRow = DataGridViewCsrOiItems.Rows(.RowIndex).DataBoundItem
                        selectedRow.Balance = selectedRow.PreviousBalance - selectedRow.Amount - amt
                        UpdateOiTotals()
                        'UpdateTotalVatAmount()
                        SendKeys.Send("{HOME}{DOWN}{TAB}{TAB}{TAB}")
                    Case $"dgvbalance"
                        SendKeys.Send("{DOWN}")
                End Select
            End With
        End Sub

        Private Sub DataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) _
            Handles DataGridViewJournalItems.CellClick
            With DataGridViewJournalItems.CurrentCell
                Select Case .OwningColumn.Name.ToLower()
                    Case $"dgvinsertcolumn"
                        _journalItemsPresenter.ChangesMadeInJournalItem = True
                        If PresenterObj.EditMode OrElse PresenterObj.AddMode Then
                            If .RowIndex() = 0 Then
                                MessageBox.Show($"Sorry, insertion on first row not allowed for CashReceipt journal.")
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

        Private Sub DataGridViewCsrOiItems_CellClick(sender As Object, e As DataGridViewCellEventArgs) _
            Handles DataGridViewCsrOiItems.CellClick
            With DataGridViewCsrOiItems.CurrentCell
                Select Case .OwningColumn.Name.ToLower()
                    'Case $"dgvinsertcolumn"
                    '    _CsrOiItemsPresenter.ChangesMadeInCsrOiItem = True
                    '    If PresenterObj.EditMode OrElse PresenterObj.AddMode Then
                    '        Dim newRow As New CsrOiItemModel
                    '        bsCsrOiItems.Insert(.RowIndex(), newRow)
                    '        _CsrOiItemsPresenter.ChangesMadeInCsrOiItem = True
                    '        ReSequenceDgvAfterInsert(DataGridViewCsrOiItems, CsrOiItems)
                    '        SendKeys.Send("{UP}")
                    '    Else
                    '        MessageBox.Show($"Row insertion not allowed while in view mode. Press edit button to enable insertion.")
                    '    End If
                End Select
            End With
        End Sub

        Private Sub DataGridViewCsrOiItems_ChangesMade(sender As Object, e As EventArgs) Handles DataGridViewCsrOiItems.ChangesMade
            _csrOiItemsPresenter.ChangesMadeInCsrOiItem = True
        End Sub

        Private Sub DataGridViewCsrOiItems_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridViewCsrOiItems.UserDeletedRow
            ReSequenceDgvAfterDelete(DataGridViewCsrOiItems, CsrOiItems)
        End Sub

        Private Sub DataGridViewJournalItems_ChangesMade(sender As Object, e As EventArgs) Handles DataGridViewJournalItems.ChangesMade
            _journalItemsPresenter.ChangesMadeInJournalItem = True
        End Sub

        Private Sub DataGridViewJournalItems_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridViewJournalItems.UserDeletedRow
            ReSequenceDgvAfterDelete(DataGridViewJournalItems, bsJournalItems)
            UpdateTotals()
        End Sub

        Private Sub MakeJournalItem()
            If ReceiptTypeToEnum(PayorType) = ReceiptTypeSelection.AccountsReceivable Then
                Dim aAccountIdNo As Integer() = {}
                Dim aAmount() As Decimal = {}
                Dim aAdded() As Boolean = {}
                Dim aDiscountTaken() As Decimal = {}
                Dim nSize As Integer = 0
                Dim nIndex As Integer
                ' summarize paid invoices per account
                For Each item In bsCsrOiItems
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
                ' apply the payment to the cash account (the first entry) and zero out the rest of the existing
                ' journal item entries if there are existing journal entries.
                For Each item In bsJournalItems
                    If nCounter = 0 Then
                        item.JournalIdNo = IdNo
                        item.Sequence = 1
                        item.AccountIdNo = AccountIdNo
                        item.Debit = If(Amount < 0, 0, Amount)
                        item.Credit = If(Amount < 0, Amount * -1, 0)
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
                ' if no existing journal entries, create one for the Cash/Checking account payment.
                If bsJournalItems Is Nothing Or bsJournalItems.Count = 0 Then
                    Dim item As New JournalItemModel With {
                            .JournalIdNo = IdNo,
                            .Sequence = 1,
                            .AccountIdNo = AccountIdNo,
                            .Debit = If(Amount < 0, 0, Amount),
                            .Credit = If(Amount < 0, Amount * -1, 0),
                            .ProfitCenterIdNo = 0,
                            .Notes = ""
                            }
                    bsJournalItems.Add(item)
                End If
                ' apply now the invoice payment summarized above for each existing AR account
                For i = 0 To aAccountIdNo.Count() - 1
                    For Each ji In bsJournalItems
                        ' if account matches then add the payment and discount
                        If ji.AccountIdNo = aAccountIdNo(i) Then
                            Dim nAmount = aAmount(i) + aDiscountTaken(i)
                            ji.Credit = If(nAmount < 0, 0, nAmount)
                            ji.Debit = If(nAmount < 0, nAmount * -1, 0)
                            aAdded(i) = True
                            Exit For
                        End If
                    Next
                Next
                ' find if the discount taken account exist in the old entries, if found save the discountTaken account
                Dim found As Boolean = False
                For Each ji In bsJournalItems
                    ' ignore the first line entry (this is for the cash receipt account)
                    If ji.Sequence <> 1 Then
                        If ji.AccountIdNo = cboDiscountAccountIdNo.SelectedValue Then
                            ji.Credit = If(DiscountTaken < 0, DiscountTaken * -1, 0)
                            ji.Debit = If(DiscountTaken < 0, 0, DiscountTaken)
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
                                .Debit = If(DiscountTaken < 0, 0, DiscountTaken),
                                .Credit = If(DiscountTaken < 0, DiscountTaken * -1, 0),
                                .ProfitCenterIdNo = 0,
                                .Notes = ""
                                }
                        bsJournalItems.Add(item)
                    End If
                End If
                ' find and add AR entries not yet added
                nCounter = 0
                For Each item In aAdded
                    If Not item Then
                        ' if the account is not yet added create a AR journal entry for
                        ' the account
                        Dim nAmount As Decimal
                        nAmount = aAmount(nCounter) + aDiscountTaken(nCounter)
                        Dim ji As New JournalItemModel With {
                                .JournalIdNo = IdNo,
                                .Sequence = 0,
                                .AccountIdNo = aAccountIdNo(nCounter),
                                .Debit = If(nAmount < 0, nAmount * -1, 0),
                                .Credit = If(nAmount < 0, 0, nAmount),
                                .ProfitCenterIdNo = 0,
                                .Notes = ""
                                }
                        bsJournalItems.Add(ji)
                    End If
                    nCounter = nCounter + 1
                Next
                If UnApplied > 0 Then
                    ' if invoice not yet fully applied, then save the
                    ' unApplied amount to the "Advances to Customer" account
                    ' check existing entries for the "Advances to Customer" account
                    Dim unAppliedSwitch As Int16 = 0
                    For Each item In bsJournalItems
                        ' get the last matching idno for accounts with advancestoCustomerAccountIdNo
                        If item.AccountIdNo = _advancesToCustomerAccountIdNo And item.Debit = 0 And item.Credit = 0 And item.OriginalAmount > 0 Then
                            ' debit and credit must be zero otherwise that account has already been used above
                            item.Debit = 0
                            item.Credit = UnApplied
                            unAppliedSwitch = 1
                            Exit For
                        End If
                    Next
                    If unAppliedSwitch = 0 Then
                        ' advance payment journal entry not yet created
                        Dim jiModel As New JournalItemModel With {
                            .JournalIdNo = IdNo,
                            .Sequence = 0,
                            .AccountIdNo = _advancesToCustomerAccountIdNo,
                            .Debit = 0,
                            .Credit = UnApplied,
                            .ProfitCenterIdNo = 0,
                            .Notes = ""
                            }
                        bsJournalItems.Add(jiModel)
                    End If
                Else
                    ' no advance payment so no advances to Customer Account
                End If
            Else
                bsCsrOiItems.Clear()
            End If
        End Sub

        Private Sub OnBeforeDisplayView() Handles MyBase.BeforeDisplayView
            Dim cPayorType = PresenterObj.GetReceiptType(PresenterObj.TargetIdNo)
            SetPayorProperty(cPayorType)
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
                        Dim newValue = DirectCast(DataGridViewJournalItems.CurrentCell, Libraries.CBaseControlsLibrary.CaDgvComboboxCell).CellEditingControl.GetValue()
                        Dim chart As ChartModel
                        chart = PresenterObj.GetChart(newValue)
                        bsJournalItems(nIndex).SpecialAccount = chart.SpecialAccount
                        bsJournalItems(nIndex).payeeType = chart.PayeeType
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

                        UpdateTotals()
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
                        UpdateTotals()
                    Case $"dgvnotes"
                        SendKeys.Send("{DOWN}")
                End Select
            End With
        End Sub

        Private Sub OnDisplayedRecordChanged() Handles MyBase.DisplayedRecordChanged
            If Not DataGridViewJournalItems.DataBindings Is Nothing Then
                DataGridViewJournalItems.DataInGridChanged = False
            End If
            If Not DataGridViewCsrOiItems.DataBindings Is Nothing Then
                DataGridViewCsrOiItems.DataInGridChanged = False
            End If
        End Sub

        Private Sub OnInputsTurnedOff() Handles Me.InputsTurnedOff
            DataGridViewJournalItems.StartTrackingChanges = False
            DataGridViewJournalItems.RemoveInsertColumn()
            _journalItemsPresenter.ChangesMadeInJournalItem = False
            DataGridViewCsrOiItems.StartTrackingChanges = False
            _csrOiItemsPresenter.ChangesMadeInCsrOiItem = False
            If PaymentTypeToEnum(PayorType) = ReceiptTypeSelection.AccountsReceivable Then
                btnViewGL.Visible = True
            Else
                btnViewGL.Visible = False
            End If
        End Sub

        Private Sub OnInputsTurnedOn() Handles Me.InputsTurnedOn
            DataGridViewJournalItems.StartTrackingChanges = True
            DataGridViewJournalItems.AddInsertColumn()
            AddCustomerOpenInvoices()
            DataGridViewCsrOiItems.StartTrackingChanges = True
            _csrOiItemsPresenter.ChangesMadeInCsrOiItem = False
            _journalItemsPresenter.ChangesMadeInJournalItem = False
            btnViewGL.Visible = False
            SetPayorProperty(PayorType)
        End Sub

        Private Sub ReSequenceDgvAfterDelete(ByRef dataGridView As DataGridView, ByRef Items As Object)
            Dim i = dataGridView.CurrentCell.RowIndex()
            For Each item In Items
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

        Private Sub SetPayorProperty(ByVal cPayorType As String)
            SuspendLayout()
            Dim savePayorIdNo = PayorIdNo
            txtPayorName.Visible = False
            txtPayorName.Width = 0
            cboPayorIdNo.Visible = True
            cboPayorIdNo.Width = _payorOrigWidth
            cboPayorIdNo.ValueMember = "IdNo"
            cboPayorIdNo.DisplayMember = "Name"
            Dim cbDataSource = Nothing
            cboPayorIdNo.DataSource = cbDataSource
            Dim payorTypeEnum = ReceiptTypeToEnum(cPayorType)
            If payorTypeEnum = ReceiptTypeSelection.AccountsReceivable Then
                cbDataSource = PresenterObj.GetCustomerListByCode()
                DataGridViewJournalItems.Visible = False
                DataGridViewCsrOiItems.Visible = True
                txtTotalCredits.Visible = False
                txtTotalDebits.Visible = False
                lblTotals.Visible = False
            Else
                DataGridViewJournalItems.Visible = True
                DataGridViewCsrOiItems.Visible = False
                txtTotalCredits.Visible = True
                txtTotalDebits.Visible = True
                lblTotals.Visible = True
                Applied = 0
                UnApplied = 0
                DiscountTaken = 0
                If payorTypeEnum = ReceiptTypeSelection.Customer Then
                    cbDataSource = PresenterObj.GetCustomerListByCode()
                ElseIf payorTypeEnum = ReceiptTypeSelection.Employee Then
                    cbDataSource = PresenterObj.GetEmployeeListByCode()
                ElseIf payorTypeEnum = ReceiptTypeSelection.SupplierRefund Then
                    cbDataSource = PresenterObj.GetSupplierListByCode()
                Else
                    txtPayorName.Visible = True
                    txtPayorName.Width = _payorOrigWidth
                    cboPayorIdNo.SelectedIndex = -1
                    cboPayorIdNo.Width = 0
                    cboPayorIdNo.Visible = False
                End If
            End If
            cboPayorIdNo.DataSource = cbDataSource
            cboPayorIdNo.SelectedValue = savePayorIdNo
            ResumeLayout()
        End Sub

        'Private Sub caCombobox_Leave(sender As Object, e As EventArgs) Handles cboPayorType.Leave
        '    If cboPayorType.SelectedIndex < 0 Then
        '        SetpayorProperty()
        '    End If
        'End Sub
        Private Sub txtAmount_ValueChanged(sender As Object, e As EventArgs) Handles txtAmount.Validated
            If ReceiptTypeToEnum(PayorType) = ReceiptTypeSelection.AccountsReceivable Then
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
            If DataGridViewJournalItems.Visible Then
                DataGridViewJournalItems.CurrentCell = DataGridViewJournalItems(1, 0)
                DataGridViewJournalItems.Focus()
            Else
                DataGridViewCsrOiItems.CurrentCell = DataGridViewCsrOiItems(5, 0)
                DataGridViewCsrOiItems.Focus()
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
                        item.Debit = Amount
                        item.Credit = 0
                        item.ProfitCenterIdNo = 0
                        DataGridViewJournalItems.Refresh()
                        Exit For
                    Next
                    UpdateTotals()
                End If
            End If
        End Sub

        Private Sub UpdateOiTotals()
            If bsCsrOiItems IsNot Nothing Then
                Applied = 0
                DiscountTaken = 0
                For Each item In bsCsrOiItems
                    Applied += item.Amount
                    DiscountTaken += item.DiscountTaken
                Next
                'Applied = cadOiItems.Sum(Function(totals) totals.Amount)
                'DiscountTaken = cadOiItems.Sum(Function(totals) totals.DiscountTaken)
                UnApplied = Amount - Applied
            End If
        End Sub

        Private Sub UpdateTotals()
            TotalDebits = 0
            TotalCredits = 0
            For Each item In bsJournalItems
                TotalDebits += item.Debit
                TotalCredits += item.Credit
            Next
            _totalBalance = 0
            For Each item In bsCsrOiItems
                _totalBalance += item.Balance
            Next
        End Sub

        Private Sub UserDeletingRow(ByVal sender As Object,
                                    ByVal e As DataGridViewRowCancelEventArgs) _
            Handles DataGridViewJournalItems.UserDeletingRow
            ' Check if the starting balance row is included in the selected rows
            Dim cashReceiptRowEntry As DataGridViewRow = DataGridViewJournalItems.Rows(0)

            ' Check if the starting balance row is included in the selected rows
            If DataGridViewJournalItems.SelectedRows.Contains(cashReceiptRowEntry) Then
                ' Do not allow the user to delete the first row.
                MessageBox.Show("Deletion of the first row is not allowed!")
                ' Cancel the deletion
                e.Cancel = True
            End If
        End Sub

        Private _viewGl As Boolean = False

        Private Sub btnViewGL_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnViewGL.ClickButtonArea
            If _viewGl Then
                _viewGl = False
                DataGridViewJournalItems.Visible = False
                DataGridViewCsrOiItems.Visible = True
                txtTotalCredits.Visible = False
                txtTotalDebits.Visible = False
                lblTotals.Visible = False
                btnViewGL.Text = "View Journal Entry"
            Else
                _viewGl = True
                DataGridViewJournalItems.Visible = True
                DataGridViewCsrOiItems.Visible = False
                txtTotalCredits.Visible = True
                txtTotalDebits.Visible = True
                lblTotals.Visible = True
                btnViewGL.Text = "Hide Journal Entry"
            End If
        End Sub

        'Private Sub OnInputsTurnedOn_Sub() Handles Me.InputsTurnedOn
        '    btnViewGL.Visible = False
        '    SetPayorProperty(PayorType)
        'End Sub

        'Private Sub OnInputsTurnedOff_Sub() Handles Me.InputsTurnedOff
        '    If ReceiptTypeToEnum(PayorType) = ReceiptTypeSelection.AccountsReceivable Then
        '        btnViewGL.Visible = True
        '    Else
        '        btnViewGL.Visible = False
        '    End If
        'End Sub

    End Class

End Namespace