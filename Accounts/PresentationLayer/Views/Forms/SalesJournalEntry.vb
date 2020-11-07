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
        Private _depositTypesByCode

        Private _slFooter As DgvFooter
        Private _salesDeposits As List(Of SalesDepositView)
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

        Public Property SalesDeposits As List(Of SalesDepositView) Implements ISalesJournalView.SalesDeposits
            Get
                Return _salesDeposits
            End Get
            Set
                _salesDeposits = Value
                BindSalesDeposit()
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
            _depositTypesByCode = PresenterObj.GetListByCode("DepositType")
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
            DataGridViewSalesDeposits.Visible = True
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

        Private Sub BindSalesDeposit()
            SuspendLayout()
            bsSalesDeposits.DataSource = Nothing
            DataGridViewSalesDeposits.Refresh()
            bsSalesDeposits.DataSource = SalesDeposits
            bsSalesDeposits.AllowNew = True
            With DataGridViewSalesDeposits
                .Refresh()
                .AutoGenerateColumns = False
                .DataSource = bsSalesDeposits
                .Refresh()
            End With
            With DataGridViewSalesDeposits.Columns
                If dgvDepositTypeIdNo IsNot Nothing Then
                    dgvDepositTypeIdNo.DataSource = _depositTypesByCode
                    dgvDepositTypeIdNo.DisplayMember = "Name"
                    dgvDepositTypeIdNo.ValueMember = "IdNo"
                    dgvDepositTypeIdNo.AutoComplete = AutoCompleteMode.SuggestAppend
                    dgvDepositTypeIdNo.DisplayStyleForCurrentCellOnly = True
                    dgvDepositTypeIdNo.AutoComplete = True
                    dgvComputedBankCharge.DisplayOnly = True
                    dgvComputedVat.DisplayOnly = True
                    dgvRate.DisplayOnly = True
                    dgvBankChargeDifference.DisplayOnly = True
                    dgvVatDifference.DisplayOnly = True
                    dgvActualBankCharge.DisplayOnly = True
                End If
            End With
            ResumeLayout()
        End Sub

        Private Sub BtnViewGL_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnViewGL.ClickButtonArea
            If _viewGl Then
                _viewGl = False
                DataGridViewJournalItems.Visible = False
                DataGridViewSalesDeposits.Visible = True
                btnViewGL.Text = Messaging.TranslateCaption("View Journal Entry")
            Else
                _viewGl = True
                DataGridViewJournalItems.Visible = True
                DataGridViewSalesDeposits.Visible = False
                btnViewGL.Text = Messaging.TranslateCaption("Hide Journal Entry")
            End If
        End Sub

        Private Sub SalesDepositDgv_OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewSalesDeposits.CellEndEdit
            With DataGridViewSalesDeposits.CurrentCell
                Dim selectedRow As DataGridViewRow
                Dim updateTotalNeeded As Boolean = True
                selectedRow = DataGridViewSalesDeposits.Rows(.RowIndex)
                Select Case .OwningColumn.Name.ToLower()
                    Case $"dgvdeposittypeidno"
                        Dim nIndex = DataGridViewSalesDeposits.CurrentRow.Index
                        Dim newValue = DirectCast(DataGridViewSalesDeposits.CurrentCell, CaDgvComboboxCell).CellEditingControl.GetValue()
                        If nIndex + 1 <= DataGridViewJournalItems.RowCount() Then
                            If nIndex < SalesDeposits.Count() Then
                                Dim pDepositType = DirectCast(DataGridViewSalesDeposits.CurrentCell, CaDgvComboboxCell).CellEditingControl.SelectedItem.Code
                                Dim pSaleAmount As Decimal = selectedRow.Cells("dgvSaleAmount").Value
                                RecomputeBankCharges(selectedRow, pDepositType, pSaleAmount)
                            End If
                        End If
                    Case $"dgvsaleamount"
                        Dim pDepositType = selectedRow.Cells("dgvDepositTypeIdNo").Value
                        Dim pSaleAmount As Decimal = .Value
                        Dim pDepositAmount As Decimal = selectedRow.Cells("dgvDepositAmount").Value
                        RecomputeBankCharges(selectedRow, pDepositType, pSaleAmount, pDepositAmount)
                    Case $"dgvdepositamount"
                        Dim pDepositType = selectedRow.Cells("dgvDepositTypeIdNo").Value
                        Dim pSaleAmount As Decimal = selectedRow.Cells("dgvSaleAmount").Value
                        Dim pDepositAmount As Decimal = .Value
                        AdjustBankCharge1(selectedRow, pSaleAmount, pDepositAmount)
                    Case $"dgvactualvat"
                        Dim pSaleAmount As Decimal = selectedRow.Cells("dgvSaleAmount").Value
                        Dim pActualVat As Decimal = .Value
                        Dim pRate As Decimal = selectedRow.Cells("dgvRate").Value
                        AdjustBankCharge2(selectedRow, pSaleAmount, pActualVat)
                    Case Else
                        updateTotalNeeded = False
                End Select
                If updateTotalNeeded Then
                    UpdateTotals()
                End If
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

            _slFooter = New DgvFooter(DataGridViewSalesDeposits) With {
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
            _slFooter.SetText("dgvDepositTypeIdNo", "Totals")

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
            DataGridViewSalesDeposits.Focus()
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
            End If
        End Sub

        Private Sub UpdateTotals()
            UpdateJiTotals()
            UpdateSlTotals()
        End Sub

        Private Sub UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridViewSalesDeposits.UserDeletedRow
            UpdateSlTotals()
        End Sub

        Private Sub RecomputeActualBankCharges(selectedRow As DataGridViewRow) ', pSaleAmount As Decimal, pDepositAmount As Decimal, pRate As Decimal)
            Dim nIndex As Integer = 0
            If selectedRow IsNot Nothing Then
                nIndex = selectedRow.Index
            End If
            If nIndex < bsSalesDeposits.Count() Then
                With bsSalesDeposits(nIndex)
                    .ActualBankCharge = .ComputedBankCharge
                    .ActualBankChargeVat = .ComputedBankChargeVat
                End With
            End If
        End Sub

        Private Sub AdjustBankCharge1(selectedRow As DataGridViewRow, pSaleAmount As Decimal, pDepositAmount As Decimal)
            Dim nIndex As Integer = 0
            If selectedRow IsNot Nothing Then
                nIndex = selectedRow.Index
            End If
            If nIndex < bsSalesDeposits.Count() Then
                bsSalesDeposits(nIndex).ActualBankCharge = pSaleAmount - pDepositAmount - bsSalesDeposits(nIndex).ActualBankChargeVat
            End If
        End Sub

        Private Sub AdjustBankCharge2(selectedRow As DataGridViewRow, pSaleAmount As Decimal, pVatAmount As Decimal)
            Dim nIndex As Integer = 0
            If selectedRow IsNot Nothing Then
                nIndex = selectedRow.Index
            End If
            If nIndex < bsSalesDeposits.Count() Then
                bsSalesDeposits(nIndex).ActualBankCharge = pSaleAmount - bsSalesDeposits(nIndex).DepositAmount - pVatAmount
            End If
        End Sub

        Private Sub RecomputeBankCharges(selectedRow As DataGridViewRow, pDepositTypeIdNo As Int16, pSaleAmount As Decimal, pDepositAmount As Decimal)
            If pDepositTypeIdNo <> 0 Then
                Dim depositType As New DepositTypeModel
                For Each item As DepositTypeModel In PresenterObj.DepositTypesModel
                    If item.IdNo = pDepositTypeIdNo Then
                        depositType = item
                        Exit For
                    End If
                Next
                Dim nIndex As Integer = selectedRow.Index
                With bsSalesDeposits(nIndex)
                    .Rate = depositType.Rate
                    .DepositAmount = pSaleAmount - .ComputedBankCharge - .ComputedBankChargeVat
                    RecomputeActualBankCharges(selectedRow)
                End With
                DataGridViewSalesDeposits.Refresh()
            End If
        End Sub

        Private Sub RecomputeBankCharges(selectedRow As DataGridViewRow, pDepositTypeIdNo As Int16, pSaleAmount As Decimal)
            If pDepositTypeIdNo <> 0 Then
                Dim depositType As New DepositTypeModel 
                depositType = PresenterObj.GetDepositType(pDepositTypeIdNo)
                Dim nIndex As Integer = selectedRow.Index
                With bsSalesDeposits(nIndex)
                    .Rate = depositType.Rate
                    .ActualBankCharge = .computedBankCharge
                    .ActualBankChargeVat = .computedBankChargeVat
                    .DepositAmount = pSaleAmount - .actualBankCharge - .actualBankChargeVat
                End With
                DataGridViewSalesDeposits.Refresh()
            End If
        End Sub

    End Class

End Namespace