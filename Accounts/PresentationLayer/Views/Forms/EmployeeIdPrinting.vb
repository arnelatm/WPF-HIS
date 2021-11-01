Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Views.Forms

    Public Class EmployeeIdPrinting
        Implements IEmployeePrinting

        Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat
        Private _pcClosingJournals As New List(Of PcClosingJournalView)
        Private _journalItems As New List(Of JournalItemView)
        Private _defaultAccount As Int16
        Private _pcFooter As DgvFooter
        Private _pcClosed As Boolean = True

        Public Event PcJournalCheckedEvent(sender As Object) Implements IEMployeeIdPrintingView.PcJournalCheckedEvent
        Public Event ClearAllPcJournal(sender As Object, clear As Boolean) Implements IEMployeeIdPrintingView.ClearAllPcJournal

        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            Me.Text = Messaging.TranslateCaption("Petty Cash Closing Journal")
            _nfi.NumberDecimalDigits = 2
            FirstControl = dtpTransactionDate
            SingleData = True
            QuitOnSave = True
        End Sub

#Region "Field Items"

        Public Property JournalItems As List(Of JournalItemView) Implements IEMployeeIdPrintingView.JournalItems
            Get
                Return _journalItems
            End Get
            Set
                'bsJournalItems.ResetBindings(True)
                'BindJournalItem()
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateDataSources()
            CreateSpecialAccountDataSource(Ea, {EnumToCode(SpecialAccountSelection.CheckingAccount), EnumToCode(SpecialAccountSelection.CheckingAccount)}, cboAccountIdNo)
            CreateSpecialAccountDataSource(Ea, {EnumToCode(SpecialAccountSelection.PettyCashAccount)}, cboPcAccountIdNo)
            CreateEnumDataSource(Of PayTypeSelection)(cboPayType)
        End Sub

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"AccountIdNo", cboAccountIdNo},
                {"Amount", txtAmount},
                {"CheckNumber", txtCheckNumber},
                {"PayType", cboPayType},
                {"Notes", txtNotes},
                {"PayeeName", txtPayeeName},
                {"PcAccountIdNo", cboPcAccountIdNo},
                {"ReferenceNo", txtReferenceNo},
                {"TransactionDate", dtpTransactionDate}
                }
        End Sub

        Private Property PcClosingJournals As List(Of PcClosingJournalView) Implements IEMployeeIdPrintingView.PcClosingJournals
            Get
                Return _pcClosingJournals
            End Get
            Set
                _pcClosingJournals = Value
                BindPcJournals()
            End Set
        End Property

        Private Sub BindPcJournals()
            SuspendLayout()
            bsPcJournals.DataSource = Nothing
            DataGridViewPcJournals.Refresh()
            bsPcJournals.DataSource = PcClosingJournals
            bsPcJournals.AllowNew = True
            With DataGridViewPcJournals
                '.Refresh()
                .AutoGenerateColumns = False
                .DataSource = bsPcJournals
                '.Refresh()
            End With
            With DataGridViewPcJournals.Columns
                dgvIdNo.DisplayOnly = True
                dgvNotes.DisplayOnly = True
                dgvPayeeName.DisplayOnly = True
                dgvPayeeNameAra.DisplayOnly = True
                dgvReference.DisplayOnly = True
                dgvTransactionDate.DisplayOnly = True
                dgvAmount.DisplayOnly = True
                dgvPayeeType.DisplayOnly = True
                If DataGridViewPcJournals.DisplayOnly Then
                    dgvPcClosed.DisplayOnly = True
                End If
            End With
            ResumeLayout()
        End Sub

        Private Sub PcClosing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            _defaultAccount = Presenter.DefaultPcAccount()
            'Presenter.UpdateViewData(0)
            DataGridViewPcJournals.Refresh()
            BindPcJournals()
            _pcFooter = New DgvFooter(DataGridViewPcJournals) With {
                .AutoCalc = True
            }
            _pcFooter.ColumnToSum("dgvAmount") = True
            _pcFooter.SetText("DgvPayeeName", "Totals ->")
        End Sub

        Private Sub EmployeeIdPrinting_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
            Presenter.GoAddRecord()
            Presenter.GetOpenPettyCash()
            If cboPcAccountIdNo.SelectedValue Is Nothing Or cboPcAccountIdNo.SelectedValue <= 0 Then
                cboPcAccountIdNo.SelectedValue = _defaultAccount
            End If
            If Presenter.PcAccountCount = 1 Then
                cboPcAccountIdNo.DisplayOnly = True
                cboPcAccountIdNo.TabStop = False
            End If
            bsPcJournals.ResetBindings(True)
            cboPcAccountIdNo.Refresh()
            _pcFooter.CalculateTotals()
        End Sub

        Private Sub btnSelectAll_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnSelectAll.ClickButtonArea
            RaiseEvent ClearAllPcJournal(bsPcJournals, True)
            bsPcJournals.ResetBindings(False)
        End Sub

        Private Sub CButton1_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles CButton1.ClickButtonArea
            RaiseEvent ClearAllPcJournal(bsPcJournals, False)
            bsPcJournals.ResetBindings(False)
        End Sub

        Private Sub DataGridViewPcJournalsCellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewPcJournals.CellContentClick
            If DataGridViewPcJournals.CurrentCell IsNot Nothing AndAlso (Presenter.EditMode Or Presenter.AddMode) Then
                With DataGridViewPcJournals.CurrentCell
                    Select Case .OwningColumn.Name.ToLower()
                        Case $"dgvpcclosed"
                            If Not DataGridViewPcJournals.DisplayOnly Then
                                Dim selectedRow = DataGridViewPcJournals.Rows(.RowIndex).DataBoundItem
                                RaiseEvent PcJournalCheckedEvent(selectedRow)
                            End If
                    End Select
                End With
            End If
        End Sub

    End Class

End Namespace