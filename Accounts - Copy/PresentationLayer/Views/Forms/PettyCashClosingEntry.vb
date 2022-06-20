Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms

    Public Class PettyCashClosingEntry
        Implements IPettyCashClosingView

        Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat
        Private _pcClosingJournals As New List(Of PcClosingJournalView)
        Private _journalItems As New List(Of JournalItemView)
        Private _defaultAccount As Int16
        Private _pcFooter As DgvFooter
        Private _pcClosed As Boolean = True

        Public Event PcJournalCheckedEvent(sender As Object, all As Boolean, clear As Boolean, dataBindingSource As BindingSource) Implements IPettyCashClosingView.PcJournalCheckedEvent

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

        Public Property AccountIdNo As Int16? Implements IPettyCashClosingView.AccountIdNo
            Get
                Return cboAccountIdNo.GetNullableValue(Of Int16)
            End Get
            Set
                cboAccountIdNo.SetValue(Value)
            End Set
        End Property

        Public Property Amount As Decimal Implements IPettyCashClosingView.Amount
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtAmount.Text), _nfi)
            End Get
            Set
                txtAmount.Text = FormatMoney(Value)
            End Set
        End Property

        Public Property Applied As Decimal Implements IPettyCashClosingView.Applied
            Get
                Return txtAmount.Text
            End Get
            Set(value As Decimal)

            End Set
        End Property

        Public Property Cancelled As Boolean Implements IPettyCashClosingView.Cancelled
            Get
                Return False
            End Get
            Set

            End Set
        End Property

        Public Property CheckDate As DateTime? Implements IPettyCashClosingView.CheckDate
            Get
                Return dtpTransactionDate.Value
            End Get
            Set

            End Set
        End Property

        Public Property PcClosed As Boolean Implements IPettyCashClosingView.PcClosed
            Get
                Return True
            End Get
            Set
                _pcClosed = True
            End Set
        End Property

        Public Property CheckNumber As String Implements IPettyCashClosingView.CheckNumber
            Get
                Return txtCheckNumber.Text
            End Get
            Set
                txtCheckNumber.Text = Value
            End Set
        End Property

        Public Property DateCreated As DateTime? Implements IPettyCashClosingView.DateCreated
            Get
                Return Date.Now()
            End Get
            Set
            End Set
        End Property

        Public Property PayType As String Implements IPettyCashClosingView.PayType
            Get
                Return cboPayType.GetValue()
            End Get
            Set
                cboPayType.SetValue(Value)
            End Set
        End Property

        Public Property IdNo As Int32 Implements IPettyCashClosingView.IdNo
            Get
                Return NumParser(Of Int32)(txtIdNo.Text)
            End Get
            Set
                txtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property Notes As String Implements IPettyCashClosingView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = If(Value, "")
            End Set
        End Property

        Public Property PayeeIdNo As Int32? Implements IPettyCashClosingView.PayeeIdNo
            Get
                Return 0
            End Get
            Set
            End Set
        End Property

        Public Property PayeeName As String Implements IPettyCashClosingView.PayeeName
            Get
                Return txtPayeeName.Text
            End Get
            Set
                txtPayeeName.Text = Value
            End Set
        End Property

        Public Property PaymentType As String Implements IPettyCashClosingView.PaymentType
            Get
                Return "O"
            End Get
            Set
            End Set
        End Property

        Public Property PcAccountIdNo As Int16? Implements IPettyCashClosingView.PcAccountIdNo
            Get
                Return cboPcAccountIdNo.GetNullableValue(Of Int16)
            End Get
            Set
                cboPcAccountIdNo.SetValue(Value)
            End Set
        End Property

        Public Property Posted As Boolean Implements IPettyCashClosingView.Posted
            Get
                Return False
            End Get
            Set

            End Set
        End Property

        Public Property ReferenceNo As String Implements IPettyCashClosingView.ReferenceNo
            Get
                Return txtReferenceNo.Text
            End Get
            Set
                txtReferenceNo.Text = Value
            End Set
        End Property

        Public Property TransactionDate As Date? Implements IPettyCashClosingView.TransactionDate
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

        Public Property JournalItems As List(Of JournalItemView) Implements IPettyCashClosingView.JournalItems
            Get
                Return _journalItems
            End Get
            Set
                'bsJournalItems.ResetBindings(True)
                'BindJournalItem()
            End Set
        End Property

#End Region

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

        Public Property PcClosingJournals As List(Of PcClosingJournalView) Implements IPettyCashClosingView.PcClosingJournals
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

            btnEdit.Visible = False
            btnFilter.Visible = False
            btnDelete.Visible = False
            btnNew.Visible = False
            btnOpen.Visible = False
            TurnOnInputs()

        End Sub

        Private Sub btnSelectAll_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnSelectAll.ClickButtonArea
            RaiseEvent PcJournalCheckedEvent(sender, True, True, bsPcJournals)
        End Sub

        Private Sub CButton1_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnUnselectAll.ClickButtonArea
            RaiseEvent PcJournalCheckedEvent(sender, True, False, bsPcJournals)        
        End Sub

        Private Sub PettyCashClosingEntry_Shown(sender As Object, e As EventArgs) Handles Me.Shown
            Presenter.GoAddRecord()
            Presenter.GetOpenPettyCash()
            cboAccountIdNo.SelectedValue = -1
            txtAmount.Text = 0
            'If cboPcAccountIdNo.SelectedValue Is Nothing Or cboPcAccountIdNo.SelectedValue <= 0 Then
            cboPcAccountIdNo.SelectedValue = _defaultAccount
            'End If
            If Presenter.PcAccountCount = 1 Then
                cboPcAccountIdNo.DisplayOnly = True
                cboPcAccountIdNo.TabStop = False
            End If
            bsPcJournals.ResetBindings(True)
            cboPcAccountIdNo.Refresh()
            _pcFooter.CalculateTotals()
        End Sub

        Private Sub DataGridViewPcJournalsCell_ContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewPcJournals.CellContentClick
            If DataGridViewPcJournals.CurrentCell IsNot Nothing AndAlso (Presenter.EditMode Or Presenter.AddMode) Then
                With DataGridViewPcJournals.CurrentCell
                    Select Case .OwningColumn.Name.ToLower()
                        Case $"dgvpcclosed"
                            If Not DataGridViewPcJournals.DisplayOnly Then
                                Dim selectedRow = DataGridViewPcJournals.Rows(.RowIndex).DataBoundItem
                                RaiseEvent PcJournalCheckedEvent(selectedRow, False, .Value, bsPcJournals)
                            End If
                    End Select
                End With
            End If
        End Sub

    End Class

End Namespace