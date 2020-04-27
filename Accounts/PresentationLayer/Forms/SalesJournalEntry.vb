Imports System.Globalization
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.My.Resources
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Forms

    Public Class SalesJournalEntry
        Implements ISalesJournalView, IJournalItemsView, ISalesCashItemsView

        Protected DtInsertTable As New DataTable
        Protected DtSalesCashInsertTable As New DataTable
        Protected DtSalesCashUpdateTable As New DataTable
        Protected DtUpdateTable As New DataTable

        Private ReadOnly _journalItemsPresenter As SalesJournalItemsPresenter
        Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat
        Private ReadOnly _salesCashItemsPresenter As SalesCashItemsPresenter
        Private _accountsByCode
        Private _cashCodes
        Private _cashCodesModel As List(Of CashCodeModel)
        Private _journalItems As List(Of JournalItemModel)
        Private _profitCentersByCode
        Private _salesCashItems As List(Of SalesCashItemModel)
        Private _vatRate As Decimal = GetVatPercentage()

        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            MainTableName = "SalesJournal"
            SortOrderKey = "IdNo"
            FirstControl = txtReferenceNo

            _nfi.NumberDecimalDigits = 2
            PresenterObj = New SalesJournalPresenter(Me)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)

            _journalItemsPresenter = New SalesJournalItemsPresenter(Me)
            _salesCashItemsPresenter = New SalesCashItemsPresenter(Me)

            PresenterObj.JournalItemsPresenter = _journalItemsPresenter
            PresenterObj.SalesCashItemsPresenter = _salesCashItemsPresenter

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

            DtSalesCashInsertTable.Columns.Add("CashCode", GetType(String))
            DtSalesCashInsertTable.Columns.Add("DepositAmount", GetType(Decimal))
            DtSalesCashInsertTable.Columns.Add("SaleAmount", GetType(Decimal))
            DtSalesCashInsertTable.Columns.Add("SalesJournalIdNo", GetType(Int32))
            DtSalesCashInsertTable.Columns.Add("Sequence", GetType(Int32))

            DtSalesCashUpdateTable.Columns.Add("CashCode", GetType(String))
            DtSalesCashUpdateTable.Columns.Add("DepositAmount", GetType(Decimal))
            DtSalesCashUpdateTable.Columns.Add("IdNo", GetType(Int32))
            DtSalesCashUpdateTable.Columns.Add("SaleAmount", GetType(Decimal))
            DtSalesCashUpdateTable.Columns.Add("SalesJournalIdNo", GetType(Int32))
            DtSalesCashUpdateTable.Columns.Add("Sequence", GetType(Int32))

        End Sub

#Region "Fields"

        Public Property AccountIdNo As Integer Implements ISalesJournalView.AccountIdNo
            Get
                Return cboAccountIdNo.GetValue()
            End Get
            Set
                cboAccountIdNo.SetValue(Value)
            End Set
        End Property

        Public Property Cancelled As Boolean Implements ISalesJournalView.Cancelled
            Get
                Return chkCancelled.Checked
            End Get
            Set
                chkCancelled.Checked = Value
            End Set
        End Property

        Public Property DateCreated As DateTime? Implements ISalesJournalView.DateCreated
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

        Public Property IdNo As Integer Implements ISalesJournalView.IdNo
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

        Private Sub SalesJournalEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            KeyPreview = True
            'JournalItems = New List(Of JournalItemModel)
            'SalesCashItems = New List(Of SalesCashItemModel)
            'BindJournalItem()
            'BindSalesCashItem()
        End Sub

        Public Property Notes As String Implements ISalesJournalView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = If(Value, "")
            End Set
        End Property

        Public Property Posted As Boolean Implements ISalesJournalView.Posted
            Get
                Return chkPosted.Checked
            End Get
            Set
                chkPosted.Checked = Value
            End Set
        End Property

        Public Property ReferenceNo As String Implements ISalesJournalView.ReferenceNo
            Get
                Return txtReferenceNo.Text
            End Get
            Set
                txtReferenceNo.Text = Value
            End Set
        End Property

        Public Property SalesCashItems As IList(Of SalesCashItemModel) Implements ISalesCashItemsView.SalesCashItems
            Get
                Return _salesCashItems
            End Get
            Set(value As IList(Of SalesCashItemModel))
                _salesCashItems = value
                BindSalesCashItem()
            End Set
        End Property

        Public Property TotalBankCharges As Decimal Implements ISalesJournalView.TotalBankCharges
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtTotalBankCharges.Text), _nfi)
            End Get
            Set
                txtTotalBankCharges.Text = FormatMoney(Value)
            End Set
        End Property

        Public Property TotalBankChargesVat As Decimal Implements ISalesJournalView.TotalBankChargesVat
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtTotalBankChargesVat.Text), _nfi)
            End Get
            Set
                txtTotalBankChargesVat.Text = FormatMoney(Value)
            End Set
        End Property

        Public Property TotalCredits As Decimal Implements ISalesJournalView.TotalCredits
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtTotalCredits.Text), _nfi)
            End Get
            Set
                txtTotalCredits.Text = FormatMoney(Value)
            End Set
        End Property

        Public Property TotalDebits As Decimal Implements ISalesJournalView.TotalDebits
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtTotalDebits.Text), _nfi)
            End Get
            Set
                txtTotalDebits.Text = FormatMoney(Value)
            End Set
        End Property

        Public Property TotalDeposits As Decimal Implements ISalesJournalView.TotalDeposits
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtTotalDeposits.Text), _nfi)
            End Get
            Set
                txtTotalDeposits.Text = FormatMoney(Value)
            End Set
        End Property

        Public Property TotalSales As Decimal Implements ISalesJournalView.TotalSales
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtTotalSales.Text), _nfi)
            End Get
            Set
                txtTotalSales.Text = FormatMoney(Value)
            End Set
        End Property

        Public Property TransactionDate As Date? Implements ISalesJournalView.TransactionDate
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

#End Region

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
            txtJournalCode.Text = AccountStrings.SalesJournalPrefix
            dtpTransactionDate.Value = Date.Now()
            bsJournalItems.Clear()
            Dim item As New SalesCashItem With {
                .Sequence = 1
            }
            bsSalesCashItems.Clear()
            DataGridViewSalesCashItems.Refresh()
            TotalBankCharges = 0
            TotalSales = 0
            TotalBankChargesVat = 0
            TotalDeposits = 0
            TotalCredits = 0
            TotalDebits = 0
            ResumeLayout()
        End Sub

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If PresenterObj.AddMode Then
                txtJournalCode.Text = AccountStrings.SalesJournalPrefix
            End If
            MakeJournalItems()
            UpdateTotals()
        End Sub

        Public Sub OnParentRecordUpdatedSuccessfully(passedValue As Integer) Handles MyBase.ParentRecordUpdatedSuccessfully, MyBase.ParentRecordAddedSuccessfully
            If PresenterObj.AddMode Then
                IdNo = passedValue
            End If
            If DtInsertTable IsNot Nothing Then
                DtInsertTable.Clear()
            End If
            If DtUpdateTable IsNot Nothing Then
                DtUpdateTable.Clear()
            End If
            If DtSalesCashInsertTable IsNot Nothing Then
                DtSalesCashInsertTable.Clear()
            End If
            If DtSalesCashUpdateTable IsNot Nothing Then
                DtSalesCashUpdateTable.Clear()
            End If
            Dim nRowCount As Integer = 1
            For Each ji In bsJournalItems
                ' loop through the journal entries but ignore zero values
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
            ' save JournalItem entries
            _journalItemsPresenter.Save(DtInsertTable, DtUpdateTable, IdNo)
            ' save Sales Cash entries
            nRowCount = 1
            For Each sc In bsSalesCashItems
                If sc.SaleAmount <> 0 Or sc.DepositAmount <> 0 Then
                    Dim workRow As DataRow
                    If sc.IdNo <= 0 Then
                        workRow = DtSalesCashInsertTable.NewRow()
                    Else
                        workRow = DtSalesCashUpdateTable.NewRow()
                        workRow("IdNo") = sc.IdNo
                    End If
                    workRow("CashCode") = sc.CashCode
                    workRow("SalesJournalIdNo") = IdNo
                    workRow("Sequence") = nRowCount
                    workRow("SaleAmount") = sc.SaleAmount
                    workRow("DepositAmount") = sc.DepositAmount
                    If sc.IdNo <= 0 Then
                        DtSalesCashInsertTable.Rows.Add(workRow)
                    Else
                        DtSalesCashUpdateTable.Rows.Add(workRow)
                    End If
                    nRowCount += 1
                End If
            Next
            ' save the generated open invoices
            _salesCashItemsPresenter.Save(DtSalesCashInsertTable, DtSalesCashUpdateTable, IdNo)
        End Sub

        Protected Overrides Sub CreateDataSources()
            _accountsByCode = PresenterObj.GetDetailAccountListByCode()
            _cashCodes = PresenterObj.GetCashCodes()
            _cashCodesModel = PresenterObj.GetCashCodesModel()
            _profitCentersByCode = PresenterObj.GetProfitCenterListByCode()
            cboAccountIdNo.BeginUpdate()
            cboAccountIdNo.DataSource = PresenterObj.GetAccountTypesList("SL")
            cboAccountIdNo.EndUpdate()

            'ResourceEnumConverter.MakeResource("MaritalStatusSelection", GetType(MaritalStatusSelection))
            'ResourceEnumConverter.MakeResource("MaleFemaleSelection", GetType(MaleFemaleSelection))
        End Sub

        Protected Overrides Sub CreateFieldsDictionary()
            FieldsDictionary = New Dictionary(Of String, Object) From
        {
         {"AccountIdNo", cboAccountIdNo},
         {"Cancelled", chkCancelled},
         {"DateCreated", txtDateCreated},
         {"IdNo", TxtIDNo},
         {"Notes", txtNotes},
         {"Posted", chkPosted},
         {"ReferenceNo", txtReferenceNo},
         {"TotalBankCharges", txtTotalBankCharges},
         {"TotalBankChargesVat", txtTotalBankChargesVat},
         {"TotalDeposits", txtTotalDeposits},
         {"TotalCredit", txtTotalCredits},
         {"TotalDebit", txtTotalDebits},
         {"TotalSalesAmount", txtTotalSales},
         {"TransactionDate", dtpTransactionDate}
        }
        End Sub

        Protected Overrides Function DataIsValid() As Boolean
            Dim retValue As Boolean = False
            If MyBase.DataIsValid() Then
                retValue = True
            End If
            Return retValue
        End Function

        Protected Overrides Sub DisplayView(ByVal idNoOfRecord As Integer)
            MyBase.DisplayView(idNoOfRecord)
            _journalItemsPresenter.Display(idNoOfRecord)
            UpdateTotals()
            _salesCashItemsPresenter.Display(idNoOfRecord)
            UpdateSalesDepositsTotal()
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
                If dgvSequence IsNot Nothing Then
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
                End If
            End With
            ResumeLayout()
        End Sub

        Private Sub BindSalesCashItem()
            SuspendLayout()
            bsSalesCashItems.DataSource = SalesCashItems
            bsSalesCashItems.AllowNew = True
            With DataGridViewSalesCashItems
                .Refresh()
                .AutoGenerateColumns = False
                .DataSource = bsSalesCashItems
                .Refresh()
                .AllowUserToAddRows = True
                .AllowUserToDeleteRows = True
            End With
            With DataGridViewSalesCashItems.Columns
                If dgvCashCode IsNot Nothing Then
                    dgvCashCode.DataSource = _cashCodes
                    dgvCashCode.DisplayMember = "Name"
                    dgvCashCode.ValueMember = "Code"
                    dgvCashCode.AutoComplete = AutoCompleteMode.SuggestAppend
                    dgvCashCode.DisplayStyleForCurrentCellOnly = True
                    dgvCashCode.AutoComplete = True
                    dgvComputedBankCharge.DisplayOnly = True
                    dgvComputedVat.DisplayOnly = True
                    dgvRate.DisplayOnly = True
                    dgvActualBankCharge.DisplayOnly = True
                    dgvActualVat.DisplayOnly = True
                    dgvBankChargeDifference.DisplayOnly = True
                    dgvVatDifference.DisplayOnly = True
                End If
            End With
            ResumeLayout()
        End Sub

        Private Sub btnHideJournalEntries_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnHideJournalEntries.ClickButtonArea
            HideJournalItems()
        End Sub

        Private Sub btnViewGL_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnViewGL.ClickButtonArea
            DisplayJournalItems()
        End Sub

        Private Sub DataGridViewSalesCashItems_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewSalesCashItems.CellClick
            With DataGridViewSalesCashItems.CurrentCell
                Select Case .OwningColumn.Name.ToLower()
                    Case $"dgvinsertcolumn"
                        _salesCashItemsPresenter.ChangesMadeInSalesCashItem = True
                        If PresenterObj.EditMode OrElse PresenterObj.AddMode Then
                            Dim newRow As New SalesCashItemModel
                            bsSalesCashItems.Insert(.RowIndex(), newRow)
                            _salesCashItemsPresenter.ChangesMadeInSalesCashItem = True
                            ReSequenceDgvAfterInsert(DataGridViewSalesCashItems, SalesCashItems)
                            SendKeys.Send("{UP}")
                        Else
                            MessageBox.Show($"Row insertion not allowed while in view mode. Press edit button to enable insertion.")
                        End If
                End Select
            End With
        End Sub

        Private Sub DataGridViewSalesCashItems_ChangesMade(sender As Object, e As EventArgs) Handles DataGridViewSalesCashItems.ChangesMade
            _salesCashItemsPresenter.ChangesMadeInSalesCashItem = True
        End Sub

        Private Sub DataGridViewSalesCashItems_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridViewSalesCashItems.UserDeletedRow
            ReSequenceDgvAfterDelete(DataGridViewSalesCashItems, SalesCashItems)
            UpdateSalesDepositsTotal()
        End Sub

        Private Sub DisplayJournalItems()
            DisplayJournalItems(True)
        End Sub

        Private Sub DisplayJournalItems(display As Boolean)
            DataGridViewJournalItems.Visible = display
            DataGridViewSalesCashItems.Visible = Not display
            _floSalesCashItemsFooter.Visible = display
            _floJournalItemsFooter.Visible = Not display
        End Sub

        Private Sub DisplayViewGlButton(display As Boolean)
            btnViewGL.Visible = display
        End Sub

        Private Sub HideJournalItems()
            DisplayJournalItems(False)
        End Sub

        Private Sub MakeJournalItems()
            Dim oldJournalItems = _journalItemsPresenter.GetJournalItems(IdNo)
            Dim counter As Integer = 0
            MakeSalesJournal(oldJournalItems, counter, AccountIdNo, 0, TotalSales, "", "")
            For Each item As SalesCashItemModel In bsSalesCashItems
                If item.CashCode IsNot Nothing Then
                    Dim cashCode = _cashCodesModel.Find(Function(c) c.CashCode.Trim() = item.CashCode.Trim())
                    MakeSalesJournal(oldJournalItems, counter, cashCode.AccountIdNo, item.DepositAmount, 0, cashCode.CashName, cashCode.CashNameAra)
                    MakeSalesJournal(oldJournalItems, counter, cashCode.BankChargesAccountIdNo, item.ActualBankCharge, 0, cashCode.CashName, cashCode.CashNameAra)
                    MakeSalesJournal(oldJournalItems, counter, cashCode.BankChargesVatAccountIdNo, item.ActualBankChargeVat, 0, cashCode.CashName, cashCode.CashNameAra)
                End If
            Next
            If counter < bsJournalItems.Count() Then
                While bsJournalItems.Count() > counter
                    bsJournalItems.RemoveAt(counter)
                End While
            End If
            UpdateTotals()
        End Sub

        Private Sub MakeSalesJournal(ByRef oldJournalItems As List(Of JournalItemModel), ByRef counter As Integer,
                                          pAccountIdNo As Integer, debitAmount As Decimal, creditAmount As Decimal, note As String, noteAra As String)
            If debitAmount <> 0 Or creditAmount <> 0 Then
                counter = counter + 1
                If counter <= oldJournalItems.Count() Then
                    bsJournalItems.Item(counter - 1).AccountIdNo = pAccountIdNo
                    bsJournalItems.Item(counter - 1).Debit = debitAmount
                    bsJournalItems.Item(counter - 1).Credit = creditAmount
                    bsJournalItems.Item(counter - 1).Sequence = counter
                    bsJournalItems.Item(counter - 1).Notes = Strings.RTrim(LTrim(note)) + IIf(note = noteAra, "", "-" + noteAra)
                Else
                    Dim ji As New JournalItemModel With {
                            .AccountIdNo = pAccountIdNo,
                            .Credit = creditAmount,
                            .Debit = debitAmount,
                            .IdNo = 0,
                            .JournalIdNo = IdNo,
                            .Notes = Strings.Trim(note + IIf(note = noteAra, "", "-" + noteAra)),
                            .Sequence = counter
                            }
                    bsJournalItems.Add(ji)
                End If
            End If
        End Sub

        Private Sub OnDisplayedRecordChanged() Handles MyBase.DisplayedRecordChanged
            If Not DataGridViewSalesCashItems.DataBindings Is Nothing Then
                DataGridViewSalesCashItems.DataInGridChanged = False
            End If
        End Sub

        Private Sub OnInputsTurnedOff() Handles MyBase.InputsTurnedOff
            DataGridViewSalesCashItems.RemoveInsertColumn()
            DataGridViewSalesCashItems.StartTrackingChanges = False
            _salesCashItemsPresenter.ChangesMadeInSalesCashItem = False
            HideJournalItems()
            DisplayViewGlButton(True)
        End Sub

        Private Sub OnInputsTurnedOn() Handles MyBase.InputsTurnedOn
            DataGridViewSalesCashItems.AddInsertColumn()
            DataGridViewSalesCashItems.StartTrackingChanges = True
            _salesCashItemsPresenter.ChangesMadeInSalesCashItem = False
            HideJournalItems()
            DisplayViewGlButton(False)
        End Sub

        Private Sub RecomputeActualBankCharges(selectedRow As DataGridViewRow, pCashCode As String, pSaleAmount As Decimal, pDepositAmount As Decimal)
            Dim nIndex As Integer = 0
            If selectedRow IsNot Nothing Then
                nIndex = selectedRow.Index
            End If
            If nIndex < bsSalesCashItems.Count() Then
                bsSalesCashItems(nIndex).ActualBankCharge = _salesCashItemsPresenter.GetActualBankCharge(pSaleAmount, pDepositAmount)
                bsSalesCashItems(nIndex).ActualBankChargeVat = _salesCashItemsPresenter.GetActualBankChargeVat(pSaleAmount, pDepositAmount, bsSalesCashItems(nIndex).ActualBankCharge)
                bsSalesCashItems(nIndex).BankChargeDifference = bsSalesCashItems(nIndex).ActualBankCharge - bsSalesCashItems(nIndex).ComputedBankCharge
                bsSalesCashItems(nIndex).BankChargeVatDifference = bsSalesCashItems(nIndex).ActualBankChargeVat - bsSalesCashItems(nIndex).ComputedBankChargeVat
                UpdateSalesDepositsTotal()
            End If
        End Sub

        Private Sub RecomputeBankCharges(selectedRow As DataGridViewRow, pCashCode As String, pSaleAmount As Decimal, pDepositAmount As Decimal)
            If pCashCode IsNot Nothing Then
                Dim nIndex As Integer = 0
                Dim cashCode As Object
                cashCode = _cashCodesModel.Find(Function(cc As CashCodeModel) cc.CashCode.Trim() = pCashCode.Trim())
                nIndex = selectedRow.Index
                bsSalesCashItems(nIndex).Rate = cashCode.Rate
                bsSalesCashItems(nIndex).ComputedBankCharge = _salesCashItemsPresenter.GetComputedBankCharge(pSaleAmount, cashCode.Rate)
                bsSalesCashItems(nIndex).ComputedBankChargeVat = _salesCashItemsPresenter.GetComputedBankChargeVat(bsSalesCashItems(nIndex).ComputedBankCharge)
                bsSalesCashItems(nIndex).DepositAmount = pSaleAmount - bsSalesCashItems(nIndex).ComputedBankCharge - bsSalesCashItems(nIndex).ComputedBankChargeVat
                RecomputeActualBankCharges(selectedRow, pCashCode, pSaleAmount, bsSalesCashItems(nIndex).DepositAmount)
                DataGridViewSalesCashItems.Refresh()
            End If
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

        Private Sub SalesCashItemDgv_OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewSalesCashItems.CellEndEdit
            With DataGridViewSalesCashItems.CurrentCell
                Dim selectedRow As DataGridViewRow
                selectedRow = DataGridViewSalesCashItems.Rows(.RowIndex)
                Select Case .OwningColumn.Name.ToLower()
                    Case $"dgvcashcode"
                        Dim pCashCode = DirectCast(DataGridViewSalesCashItems.CurrentCell, CaDgvComboboxCell).CellEditingControl.SelectedItem.Code.Trim()
                        Dim pSaleAmount As Decimal = selectedRow.Cells("dgvSaleAmount").Value
                        Dim pDepositAmount As Decimal = selectedRow.Cells("dgvDepositAmount").Value
                        RecomputeBankCharges(selectedRow, pCashCode, pSaleAmount, pDepositAmount)
                    Case $"dgvsaleamount"
                        Dim pCashCode = selectedRow.Cells("dgvCashCode").Value
                        Dim pSaleAmount As Decimal = .Value
                        Dim pDepositAmount As Decimal = selectedRow.Cells("dgvDepositAmount").Value
                        RecomputeBankCharges(selectedRow, pCashCode, pSaleAmount, pDepositAmount)
                    Case $"dgvdepositamount"
                        Dim pCashCode = selectedRow.Cells("dgvCashCode").Value
                        Dim pSaleAmount As Decimal = selectedRow.Cells("dgvSaleAmount").Value
                        Dim pDepositAmount As Decimal = .Value
                        RecomputeActualBankCharges(selectedRow, pCashCode, pSaleAmount, pDepositAmount)
                End Select
            End With
        End Sub

        Private Sub TxtNotes_Leave(sender As Object, e As EventArgs) Handles txtNotes.Leave
            DataGridViewSalesCashItems.Focus()
        End Sub

        Private Sub UpdateSalesDepositsTotal()
            If SalesCashItems IsNot Nothing Then
                TotalBankChargesVat = SalesCashItems.Sum(Function(totals) totals.ActualBankChargeVat)
                TotalBankCharges = SalesCashItems.Sum(Function(totals) totals.ActualBankCharge)
                TotalDeposits = SalesCashItems.Sum(Function(totals) totals.DepositAmount)
                TotalSales = SalesCashItems.Sum(Function(totals) totals.SaleAmount)
            Else
                TotalBankChargesVat = 0
                TotalBankCharges = 0
                TotalDeposits = 0
                TotalSales = 0
            End If
        End Sub

        Private Sub UpdateTotals()
            TotalDebits = JournalItems.Sum(Function(totals) totals.Debit)
            TotalCredits = JournalItems.Sum(Function(totals) totals.Credit)
        End Sub

    End Class

End Namespace