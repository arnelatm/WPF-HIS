Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.CustomControlsLibrary
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Views.Forms

    Public Class SalesJournalEntry
        Implements ISalesJournalView

        Public TxtTotalCredits As Decimal
        Public TxtTotalDebits As Decimal
        Public TxtTotalBankCharges As Decimal
        Public TxtTotalBankChargesVat As Decimal
        Public TxtTotalDeposits As Decimal
        Public TxtTotalSales As Decimal

        Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat
        Private _accountsByCode

        Private _cashCodes

        Private _slFooter As DgvFooter
        Private _salesCashItems As List(Of SalesCashItemView)
        Private _jiFooter As DgvFooter
        Private _journalItems As List(Of JournalItemView)
        Private _revCostCenterByCode
        Private _viewGl As Boolean = False

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

        End Sub

#Region "Fields"

        Public Property AccountIdNo As Int16? Implements ISalesJournalView.AccountIdNo
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

        Public Property IdNo As Int32 Implements ISalesJournalView.IdNo
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

        Public Property JournalItems As List(Of JournalItemView) Implements ISalesJournalView.JournalItems
            Get
                Return _journalItems
            End Get
            Set
                _journalItems = Value
                BindJournalItem()
            End Set
        End Property

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

        Public Property SalesCashItems As List(Of SalesCashItemView) Implements ISalesJournalView.SalesCashItems
            Get
                Return _salesCashItems
            End Get
            Set
                _salesCashItems = Value
                BindSalesCashItem()
            End Set
        End Property

        Public Property TotalBankCharges As Decimal Implements ISalesJournalView.TotalBankCharges
            Get
                Return TxtTotalBankCharges
            End Get
            Set
                TxtTotalBankCharges = Value
            End Set
        End Property

        Public Property TotalBankChargesVat As Decimal Implements ISalesJournalView.TotalBankChargesVat
            Get
                Return TxtTotalBankChargesVat
            End Get
            Set
                TxtTotalBankChargesVat = Value
            End Set
        End Property

        Public Property TotalCredits As Decimal Implements ISalesJournalView.TotalCredits
            Get
                Return TxtTotalCredits
            End Get
            Set(value As Decimal)
                TxtTotalCredits = value
            End Set
        End Property

        Public Property TotalDebits As Decimal Implements ISalesJournalView.TotalDebits
            Get
                Return TxtTotalDebits
            End Get
            Set(value As Decimal)
                TxtTotalDebits = value
            End Set
        End Property

        Public Property TotalDeposits As Decimal Implements ISalesJournalView.TotalDeposits
            Get
                Return TxtTotalDeposits
            End Get
            Set
                TxtTotalDeposits = Value
            End Set
        End Property

        Public Property TotalSales As Decimal Implements ISalesJournalView.TotalSales
            Get
                Return TxtTotalSales
            End Get
            Set
                TxtTotalSales = Value
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

        Protected Overrides Sub CreateDataSources()
            _accountsByCode = PresenterObj.GetDetailAccountListByCode()
            _cashCodes = PresenterObj.GetListByCode("CashCode")
            _revCostCenterByCode = PresenterObj.GetRevCostCenterListByCode()
            cboAccountIdNo.BeginUpdate()
            cboAccountIdNo.DataSource = PresenterObj.GetAccountTypesList("SL")
            cboAccountIdNo.EndUpdate()
        End Sub

        Protected Overrides Sub CreateFieldsDictionary()
            FieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"AccountIdNo", cboAccountIdNo},
                {"Cancelled", chkCancelled},
                {"DateCreated", dtpDateCreated},
                {"IdNo", TxtIdNo},
                {"Notes", txtNotes},
                {"Posted", chkPosted},
                {"ReferenceNo", txtReferenceNo},
                {"TotalBankCharges", TxtTotalBankCharges},
                {"TotalBankChargesVat", TxtTotalBankChargesVat},
                {"TotalDeposits", TxtTotalDeposits},
                {"TotalCredit", TxtTotalCredits},
                {"TotalDebit", TxtTotalDebits},
                {"TotalSalesAmount", TxtTotalSales},
                {"TransactionDate", dtpTransactionDate}
                }
        End Sub

        Protected Overrides Sub RecordPositionChanged(ByRef e As RecordPositionChanged)
            SuspendLayout()
            DataGridViewJournalItems.Visible = False
            DataGridViewSalesCashItems.Visible = True
            ResumeLayout()
            UpdateTotals()
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
                If dgvSequence IsNot Nothing Then
                    dgvSequence.DisplayOnly = True
                    dgvAccountIdNo.DataSource = _accountsByCode
                    dgvAccountIdNo.DisplayMember = "Name"
                    dgvAccountIdNo.ValueMember = "IdNo"
                    dgvAccountIdNo.AutoComplete = AutoCompleteMode.SuggestAppend
                    dgvAccountIdNo.DisplayStyleForCurrentCellOnly = True
                    dgvAccountIdNo.AutoComplete = True
                    dgvRevCostCenterIdNo.DataSource = _revCostCenterByCode
                    dgvRevCostCenterIdNo.DisplayMember = "Name"
                    dgvRevCostCenterIdNo.ValueMember = "idNo"
                    dgvRevCostCenterIdNo.AutoComplete = AutoCompleteMode.SuggestAppend
                    dgvRevCostCenterIdNo.DisplayStyleForCurrentCellOnly = True
                End If
            End With
            ResumeLayout()
        End Sub

        Private Sub BindSalesCashItem()
            SuspendLayout()
            bsSalesCashItems.DataSource = Nothing
            DataGridViewSalesCashItems.Refresh()
            bsSalesCashItems.DataSource = SalesCashItems
            bsSalesCashItems.AllowNew = True
            With DataGridViewSalesCashItems
                .Refresh()
                .AutoGenerateColumns = False
                .DataSource = bsSalesCashItems
                .Refresh()
            End With
            With DataGridViewSalesCashItems.Columns
                If dgvCashCodeIdNo IsNot Nothing Then
                    dgvCashCodeIdNo.DataSource = _cashCodes
                    dgvCashCodeIdNo.DisplayMember = "Name"
                    dgvCashCodeIdNo.ValueMember = "IdNo"
                    dgvCashCodeIdNo.AutoComplete = AutoCompleteMode.SuggestAppend
                    dgvCashCodeIdNo.DisplayStyleForCurrentCellOnly = True
                    dgvCashCodeIdNo.AutoComplete = True
                    dgvComputedBankCharge.DisplayOnly = True
                    dgvComputedVat.DisplayOnly = True
                    dgvRate.DisplayOnly = True
                    dgvBankChargeDifference.DisplayOnly = True
                    dgvVatDifference.DisplayOnly = True
                    dgvDepositAmount.DisplayOnly = True
                End If
            End With
            ResumeLayout()
        End Sub

        Private Sub BtnViewGL_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnViewGL.ClickButtonArea
            If _viewGl Then
                _viewGl = False
                DataGridViewJournalItems.Visible = False
                DataGridViewSalesCashItems.Visible = True
                btnViewGL.Text = Messaging.TranslateCaption("View Journal Entry")
            Else
                _viewGl = True
                DataGridViewJournalItems.Visible = True
                DataGridViewSalesCashItems.Visible = False
                btnViewGL.Text = Messaging.TranslateCaption("Hide Journal Entry")
            End If
        End Sub

        Private Sub OnCellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridViewJournalItems.CellBeginEdit
            If DataGridViewJournalItems.CurrentCell.RowIndex() = 0 Then
                With DataGridViewJournalItems.CurrentCell
                    Dim selectedRow As DataGridViewRow
                    selectedRow = DataGridViewSalesCashItems.Rows(.RowIndex)
                    '    Select Case .OwningColumn.Name.ToLower()
                    '        Case $"dgvcashcode"
                    'selectedRow.Cells("dgvInteractiveChange").Value = True
                    'If cColumnName = $"dgvsaleamount" Then
                    '    Beep()
                    '    e.Cancel = True
                    '    DataGridViewJournalItems.EndEdit()
                    'End If
                End With
            End If
        End Sub

        'Private Sub SjOnCellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridViewSalesCashItems.CellBeginEdit
        '    If DataGridViewSalesCashItems.CurrentCell.RowIndex() = 0 Then
        '        With DataGridViewJournalItems.CurrentCell
        '            Dim selectedRow As DataGridViewRow
        '            selectedRow = DataGridViewSalesCashItems.Rows(.RowIndex)
        '            '    Select Case .OwningColumn.Name.ToLower()
        '            '        Case $"dgvcashcode"
        '            'selectedRow.Cells("dgvInteractiveChange").Value = True
        '            'If cColumnName = $"dgvsaleamount" Then
        '            '    Beep()
        '            '    e.Cancel = True
        '            '    DataGridViewJournalItems.EndEdit()
        '            'End If
        '        End With
        '    End If
        'End Sub

        Private Sub SalesCashItemDgv_OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewSalesCashItems.CellEndEdit
            UpdateTotals()
            With DataGridViewSalesCashItems.CurrentCell
                Dim selectedRow As DataGridViewRow
                selectedRow = DataGridViewSalesCashItems.Rows(.RowIndex)
                Select Case .OwningColumn.Name.ToLower()
                    Case $"dgvcashcode"
                        Dim nIndex = DataGridViewSalesCashItems.CurrentRow.Index
                        Dim newValue = DirectCast(DataGridViewSalesCashItems.CurrentCell, CaDgvComboboxCell).CellEditingControl.GetValue()
                        If nIndex + 1 <= DataGridViewJournalItems.RowCount() Then
                            If nIndex < SalesCashItems.Count() Then
                                Dim pCashCode = DirectCast(DataGridViewSalesCashItems.CurrentCell, CaDgvComboboxCell).CellEditingControl.SelectedItem.Code
                                Dim pSaleAmount As Decimal = selectedRow.Cells("dgvSaleAmount").Value
                                Dim pDepositAmount As Decimal = selectedRow.Cells("dgvDepositAmount").Value
                                SalesCashItems(nIndex).CashCodeIdNo = newValue
                                RecomputeBankCharges(selectedRow, pCashCode, pSaleAmount, pDepositAmount)
                                UpdateTotals()
                                BindSalesCashItem()
                            End If
                        End If
                    Case $"dgvsaleamount"
                        Dim pCashCode = selectedRow.Cells("dgvCashCode").Value
                        Dim pSaleAmount As Decimal = .Value
                        Dim pDepositAmount As Decimal = selectedRow.Cells("dgvDepositAmount").Value
                        RecomputeBankCharges(selectedRow, pCashCode, pSaleAmount, pDepositAmount)
                        UpdateTotals()
                    Case $"dgvdepositamount"
                        'Dim pCashCode = selectedRow.Cells("dgvCashCode").Value
                        Dim pSaleAmount As Decimal = selectedRow.Cells("dgvSaleAmount").Value
                        Dim pDepositAmount As Decimal = .Value
                        RecomputeActualBankCharges(selectedRow, pSaleAmount, pDepositAmount)
                        UpdateTotals()
                End Select
            End With
        End Sub

        Private Sub SalesJournalEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            KeyPreview = True
            _jiFooter = New DgvFooter(DataGridViewJournalItems) With {
                .AutoCalc = True
            }
            _jiFooter.ColumnToSum("dgvDebit") = True
            _jiFooter.ColumnToSum("dgvCredit") = True
            ' _jiFooter.SetText("DgvAccountIdNo", "Totals ->")

            _slFooter = New DgvFooter(DataGridViewSalesCashItems) With {
                .AutoCalc = True
            }
            _slFooter.ColumnToSum("dgvSaleAmount") = True
            _slFooter.ColumnToSum("dgvDepositAmount") = True
            _slFooter.ColumnToSum("dgvComputedBankCharge") = True
            _slFooter.ColumnToSum("dgvComputedVat") = True
            _slFooter.ColumnToSum("dgvActualBankCharge") = True
            _slFooter.ColumnToSum("dgvActualVat") = True
            _slFooter.ColumnToSum("dgvBankChargeDifference") = True
            _slFooter.ColumnToSum("dgvVatDifference") = True
            _slFooter.SetText("dgvCashCodeIdNo", "Totals")

        End Sub

        Public Overloads Sub Dispose()
            Close()
        End Sub

        Protected Overrides Sub InputsTurnedOff()
            btnViewGL.Visible = True
        End Sub

        Protected Overrides Sub InputsTurnedOn()
            btnViewGL.Visible = False
        End Sub

        Private Sub TxtNotes_Leave(sender As Object, e As EventArgs) Handles txtNotes.Leave
            DataGridViewSalesCashItems.Focus()
        End Sub

        Private Sub UpdateJiTotals()
            If _jiFooter IsNot Nothing Then
                _jiFooter.CalculateTotals()
                TotalDebits = _jiFooter.Value("dgvDebit")
                TotalCredits = _jiFooter.Value("dgvCredit")
            End If
        End Sub

        Private Sub UpdateSlTotals()
            If _slFooter IsNot Nothing Then
                _slFooter.CalculateTotals()
                TotalSales = _slFooter.Value("DgvSaleAmount")
                'Applied = _apFooter.Value("dgvAmount")
                'DiscountTaken = _apFooter.Value("dgvDiscountTaken")
                'UnApplied = Amount - Applied
            End If
        End Sub

        Private Sub UpdateTotals()
            UpdateJiTotals()
            UpdateSlTotals()
        End Sub

        Private Sub UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridViewSalesCashItems.UserDeletedRow
            UpdateSlTotals()
        End Sub

        'Private Sub UpdateSlTotals()
        '    If SalesCashItems IsNot Nothing Then
        '        TotalBankChargesVat = SalesCashItems.Sum(Function(totals) totals.ActualBankChargeVat)
        '        TotalBankCharges = SalesCashItems.Sum(Function(totals) totals.ActualBankCharge)
        '        TotalDeposits = SalesCashItems.Sum(Function(totals) totals.DepositAmount)
        '        TotalSales = SalesCashItems.Sum(Function(totals) totals.SaleAmount)
        '    Else
        '        TotalBankChargesVat = 0
        '        TotalBankCharges = 0
        '        TotalDeposits = 0
        '        TotalSales = 0
        '    End If
        'End Sub

        'Public Sub OnParentRecordUpdatedSuccessfully(passedValue As Integer) Handles MyBase.RecordUpdatedSuccessfully, MyBase.RecordAddedSuccessfully
        '    If PresenterObj.AddMode Then
        '        IdNo = passedValue
        '    End If
        '    ' save JournalItem entries
        '    _journalItemsPresenter.Save(DtInsertTable, DtUpdateTable, IdNo)
        '    ' save Sales Cash entries
        '    nRowCount = 1

        '    ' save the generated open invoices
        '    _salesCashItemsPresenter.Save(DtSalesCashInsertTable, DtSalesCashUpdateTable, IdNo)
        'End Sub

        'Protected Overrides Function DataIsValid() As Boolean
        '    Dim retValue As Boolean = False
        '    If MyBase.DataIsValid() Then
        '        retValue = True
        '    End If
        '    Return retValue
        'End Function

        'Protected Overrides Sub DisplayView(ByVal idNoOfRecord As Integer)
        '    MyBase.DisplayView(idNoOfRecord)
        '    _journalItemsPresenter.Display(idNoOfRecord)
        '    UpdateTotals()
        '    _salesCashItemsPresenter.Display(idNoOfRecord)
        '    UpdateSalesDepositsTotal()
        'End Sub

        'Private Sub DisplayJournalItems()
        '    DisplayJournalItems(True)
        'End Sub

        'Private Sub DisplayJournalItems(display As Boolean)
        '    DataGridViewJournalItems.Visible = display
        '    DataGridViewSalesCashItems.Visible = Not display
        '    _floSalesCashItemsFooter.Visible = display
        '    _floJournalItemsFooter.Visible = Not display
        'End Sub

        Private Sub RecomputeActualBankCharges(selectedRow As DataGridViewRow, pSaleAmount As Decimal, pDepositAmount As Decimal)
            Dim nIndex As Integer = 0
            If selectedRow IsNot Nothing Then
                nIndex = selectedRow.Index
            End If
            If nIndex < bsSalesCashItems.Count() Then
                bsSalesCashItems(nIndex).ActualBankCharge = PresenterObj.GetActualBankCharge(pSaleAmount, pDepositAmount)
                bsSalesCashItems(nIndex).ActualBankChargeVat = PresenterObj.GetActualBankChargeVat(pSaleAmount, pDepositAmount, bsSalesCashItems(nIndex).ActualBankCharge)
                bsSalesCashItems(nIndex).BankChargeDifference = bsSalesCashItems(nIndex).ActualBankCharge - bsSalesCashItems(nIndex).ComputedBankCharge
                bsSalesCashItems(nIndex).BankChargeVatDifference = bsSalesCashItems(nIndex).ActualBankChargeVat - bsSalesCashItems(nIndex).ComputedBankChargeVat
                'UpdateSalesDepositsTotal()
            End If
        End Sub

        Private Sub RecomputeBankCharges(selectedRow As DataGridViewRow, pCashCodeIdNo As Int16, pSaleAmount As Decimal, pDepositAmount As Decimal)
            If pCashCodeIdNo <> 0 Then
                Dim cashCode As New CashCodeModel
                For Each item As CashCodeModel In PresenterObj.cashCodesModel
                    If item.IdNo = pCashCodeIdNo Then
                        cashCode = item
                    End If
                Next
                'cashCode = PresenterObj.cashCodesModel.Find(Function(cc As CashCodeModel) cc.CashCode.Trim() = pCashCode.Trim())
                Dim nIndex As Integer = selectedRow.Index
                bsSalesCashItems(nIndex).Rate = cashCode.Rate
                'bsSalesCashItems(nIndex).ComputedBankCharge = PresenterObj.GetComputedBankCharge(pSaleAmount, cashCode.Rate)
                'bsSalesCashItems(nIndex).ComputedBankChargeVat = PresenterObj.GetComputedBankChargeVat(bsSalesCashItems(nIndex).ComputedBankCharge)
                bsSalesCashItems(nIndex).DepositAmount = pSaleAmount - bsSalesCashItems(nIndex).ComputedBankCharge - bsSalesCashItems(nIndex).ComputedBankChargeVat
                RecomputeActualBankCharges(selectedRow, pSaleAmount, bsSalesCashItems(nIndex).DepositAmount)
                DataGridViewSalesCashItems.Refresh()
            End If
        End Sub

    End Class

End Namespace