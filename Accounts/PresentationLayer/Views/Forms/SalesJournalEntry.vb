Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
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
        Private _journalItems As List(Of IJournalItemView)
        Private _revCostCenterByCode
        Private _journalMode As Boolean = False

        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            MainTableName = "SalesJournal"
            SortOrderKey = "IdNo"
            FirstControl = dtpTransactionDate

            _nfi.NumberDecimalDigits = 2
            PresenterObj = New SalesJournalPresenter(Me)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)
            If GlobalVariables.RightToLeftLayout Then
                txtJournalCode.Text = PresenterObj.GetLocalizedPrefix("SJ")
            Else
                txtJournalCode.Text = "SJ"
            End If

        End Sub

#Region "Fields"

        Public Property AccountIdNo As Int16? Implements ISalesJournalView.AccountIdNo
            Get
                Return cboAccountIdNo.GetNullableValue(Of Int16)
            End Get
            Set
                cboAccountIdNo.SetValue(Value)
            End Set
        End Property

        Public Property Approved As Boolean Implements ISalesJournalView.Approved
            Get
                Return chkApproved.Checked
            End Get
            Set
                chkApproved.Checked = Value
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

        Public Property JournalItems As List(Of IJournalItemView) Implements ISalesJournalView.JournalItems
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
            _accountsByCode = PresenterObj.GetDetailAccountList()
            _depositTypesByCode = PresenterObj.GetLookup("DepositType")
            _revCostCenterByCode = PresenterObj.GetLookup("RevCostCenter")
            cboAccountIdNo.BeginUpdate()
            cboAccountIdNo.DataSource = PresenterObj.GetAccountTypesList(GlobalFunctions.EnumToCode(SpecialAccountSelection.Sales))
            cboAccountIdNo.EndUpdate()
        End Sub

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
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
            'SuspendLayout()
            'DataGridViewJournalItems.Visible = False
            'DataGridViewSalesDeposits.Visible = True
            'ResumeLayout()
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
            _journalMode = Not _journalMode
            ShowJournalItems()
        End Sub

        Private Sub ShowJournalItems()
            If _journalMode Then
                DataGridViewJournalItems.Visible = True
                DataGridViewSalesDeposits.Visible = False
                btnViewGL.Text = Messaging.TranslateCaption("Hide Journal Entry")
            Else
                DataGridViewJournalItems.Visible = False
                DataGridViewSalesDeposits.Visible = True
                btnViewGL.Text = Messaging.TranslateCaption("Show Journal Entry")
            End If
        End Sub

        Private Sub SalesDepositDgv_OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewSalesDeposits.CellEndEdit
            With DataGridViewSalesDeposits
                If .CurrentRow() IsNot Nothing Then
                    Dim selectedRow As DataGridViewRow
                    Dim updateTotalNeeded As Boolean = True
                    selectedRow = .Rows(.CurrentCell.RowIndex)
                    Select Case .CurrentCell.OwningColumn.Name.ToLower()
                        Case $"dgvdeposittypeidno"
                            Dim value = DirectCast(.CurrentCell, CDgvComboBoxCell).CellEditingControl.GetValue()
                            PresenterObj.RecomputeBankCharges(value, selectedRow.Index)
                        Case $"dgvsaleamount"
                            Dim pDepositTypeIdNo = selectedRow.Cells("dgvDepositTypeIdNo").Value
                            PresenterObj.RecomputeBankCharges(pDepositTypeIdNo, selectedRow.Index)
                        Case Else
                            updateTotalNeeded = False
                    End Select
                    If updateTotalNeeded Then
                        UpdateTotals()
                    End If
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
            _slFooter.ColumnToSum("dgvVatAmount") = True
            _slFooter.ColumnToSum("dgvBankChargeDifference") = True
            _slFooter.ColumnToSum("dgvVatDifference") = True
            _slFooter.SetText("dgvDepositTypeIdNo", "Totals")
        End Sub

        Public Overloads Sub Dispose()
            Close()
        End Sub

        Protected Overrides Sub InputsTurnedOff()
            btnViewGL.Visible = True
            '_journalMode = True
            ShowJournalItems()
        End Sub

        Protected Overrides Sub InputsTurnedOn()
            _journalMode = False
            btnViewGL.Visible = False
            ShowJournalItems()
        End Sub

        Private Sub TxtNotes_Leave(sender As Object, e As EventArgs) Handles txtNotes.Leave
            If DataGridViewSalesDeposits IsNot Nothing Then
                DataGridViewSalesDeposits.Focus()
            End If
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

        Private Sub dataGridView1_CellFormatting(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs) Handles DataGridViewSalesDeposits.CellFormatting
            For Each myRow As DataGridViewRow In DataGridViewSalesDeposits.Rows
                'Here 2 cell is target value and 1 cell is Volume
                If Math.Round(Convert.ToDecimal(myRow.Cells("dgvBankChargeDifference").Value), 2) <> 0 Then
                    myRow.Cells("dgvBankChargeDifference").Style.ForeColor = Color.Red
                    myRow.Cells("dgvBankChargeDifference").Style.BackColor = Color.Yellow
                Else
                    myRow.Cells("dgvBankChargeDifference").Style.ForeColor = OrigForeColor("dgvBankChargeDifference")
                    myRow.Cells("dgvBankChargeDifference").Style.BackColor = OrigBackColor("dgvBankChargeDifference")
                End If
                If Math.Round(Convert.ToDecimal(myRow.Cells("dgvVatDifference").Value), 2) <> 0 Then
                    myRow.Cells("dgvVatDifference").Style.ForeColor = Color.Red
                    myRow.Cells("dgvVatDifference").Style.BackColor = Color.Yellow
                Else
                    myRow.Cells("dgvVatDifference").Style.ForeColor = OrigForeColor("dgvVatDifference")
                    myRow.Cells("dgvVatDifference").Style.BackColor = OrigBackColor("dgvVatDifference")
                End If
            Next
        End Sub

        Private Function OrigForeColor(columnName As String) As Color
            Return DataGridViewSalesDeposits.Columns(columnName).DefaultCellStyle.ForeColor
        End Function

        Private Function OrigBackColor(columnName As String) As Color
            Return DataGridViewSalesDeposits.Columns(columnName).DefaultCellStyle.BackColor
        End Function

    End Class

End Namespace