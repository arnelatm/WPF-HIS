Imports System.ComponentModel
Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Libraries
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Views.Forms

    Public Class PettyCashClosingEntry
        Implements IPettyCashClosingView

        Private Property MyPresenter As PettyCashClosingPresenter
        Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat
        Private _pcJournals As New List(Of IPcJournalView)
        Private _journalItems As New List(Of IJournalItemView)
        Private _pcFooter As DgvFooter

        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            MainTableName = "CdJournal"
            SortOrderKey = "IdNo"
            Me.Text = Messaging.TranslateCaption("Petty Cash Closing Journal")
            MyPresenter = New PettyCashClosingPresenter(Me)
            PresenterObj = MyPresenter
            _nfi.NumberDecimalDigits = 2
            Ea = MyPresenter.Ea
            Ea.SubscribeEvent(Me)
            FirstControl = dtpTransactionDate
            SingleData = True
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
                Return "1"
            End Get
            Set

            End Set
        End Property

        Public Property IdNo As Int32 Implements IPettyCashClosingView.IdNo
            Get
                Return 0
            End Get
            Set

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

#End Region

        Protected Overrides Sub CreateDataSources()
            cboAccountIdNo.DataSource = MyPresenter.GetAccountTypesList(EnumToCode(SpecialAccountSelection.Bank) + "," + EnumToCode(SpecialAccountSelection.CheckingAccount))
            cboPayType.DataSource = MyPresenter.MakeEnumComboList(Of PayTypeSelection)
        End Sub

        Private Property PcJournals As List(Of IPcJournalView) Implements IPettyCashClosingView.PcJournals
            Get
                Return _pcJournals
            End Get
            Set
                _pcJournals = Value
                BindPcJournals()
            End Set
        End Property

        Private Sub BindPcJournals()
            SuspendLayout()
            bsPcJournals.DataSource = Nothing
            DataGridViewPcJournals.Refresh()
            bsPcJournals.DataSource = PcJournals
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
            End With
            ResumeLayout()
        End Sub

        Private Sub PcClosing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            MyPresenter.UpdateViewDisplay(0)
            DataGridViewPcJournals.Refresh()
            BindPcJournals()
            _pcFooter = New DgvFooter(DataGridViewPcJournals) With {
                .AutoCalc = True
            }
            _pcFooter.ColumnToSum("dgvAmount") = True
            _pcFooter.SetText("DgvPayeeName", "Totals ->")
        End Sub

        Private Sub PettyCashClosing_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
            MyPresenter.GoAddRecord()
            MyPresenter.GetOpenPettyCash()
            bsPcJournals.ResetBindings(True)
            _pcFooter.CalculateTotals()
        End Sub

        Private Sub btnSelectAll_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnSelectAll.ClickButtonArea
            MyPresenter.SelectChoice(True)
            bsPcJournals.ResetBindings(False)
        End Sub

        Private Sub CButton1_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles CButton1.ClickButtonArea
            MyPresenter.SelectChoice(False)
            bsPcJournals.ResetBindings(False)
        End Sub


        Private Sub Dgv_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewPcJournals.CellClick
            With DataGridViewPcJournals
                If .CurrentRow IsNot Nothing Then
                    Dim nIndex = .CurrentRow.Index
                    Select Case .CurrentCell.OwningColumn.Name.ToLower()
                        Case $"dgvpcclosed"
                            txtAmount.Text = MyPresenter.TotalSelection()
                            txtAmount.Refresh()
                    End Select
                End If
            End With
        End Sub

    End Class

End Namespace