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

    Public Class PettyCashClosing
        Implements IDisbursementJournalView, IPcJournalsView
        Public TxtTotalCredits As Decimal
        Public TxtTotalDebits As Decimal

        Private Property MyPresenter As DisbursementJournalPresenter
        Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat
        Private _pcJournals As New List(Of IPcJournalView)
        Private _jiFooter As DgvFooter

        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            MainTableName = "PcJournal"
            SortOrderKey = "IdNo"
            MyPresenter = New DisbursementJournalPresenter(Me, "PcJournal")
            Me.Text = Messaging.TranslateCaption("Petty Cash Disbursement Journal")
            Dim x = New ClosePettyCashPresenter(Me)
            PresenterObj = MyPresenter
            _nfi.NumberDecimalDigits = 2
            Ea = MyPresenter.Ea
            Ea.SubscribeEvent(Me)
            FirstControl = dtpTransactionDate
            SingleData = True
        End Sub

#Region "Field Items"

        Public Property AccountIdNo As Int16? Implements IDisbursementJournalView.AccountIdNo
            Get
                Return cboAccountIdNo.GetNullableValue(Of Int16)
            End Get
            Set
                cboAccountIdNo.SetValue(Value)
            End Set
        End Property

        Public Property Amount As Decimal Implements IDisbursementJournalView.Amount
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtAmount.Text), _nfi)
            End Get
            Set
                txtAmount.Text = FormatMoney(Value)

            End Set
        End Property

        Public Property Applied As Decimal Implements IDisbursementJournalView.Applied
            Get
                Return txtAmount.Text
            End Get
            Set(value As Decimal)

            End Set
        End Property

        Public Property Cancelled As Boolean Implements IDisbursementJournalView.Cancelled
            Get
                Return False
            End Get
            Set

            End Set
        End Property

        Public Property CheckDate As DateTime? Implements IDisbursementJournalView.CheckDate
            Get
                Return dtpTransactionDate.Value
            End Get
            Set

            End Set
        End Property

        Public Property PcClosed As Boolean Implements IDisbursementJournalView.PcClosed
            Get
                Return True
            End Get
            Set
            End Set
        End Property

        Public Property CheckNumber As String Implements IDisbursementJournalView.CheckNumber
            Get
                Return txtCheckNumber.Text
            End Get
            Set
                txtCheckNumber.Text = Value
            End Set
        End Property

        Public Property DateCreated As DateTime? Implements IDisbursementJournalView.DateCreated
            Get
                Return Date.Now()
            End Get
            Set
            End Set
        End Property

        Public Property PayType As String Implements IDisbursementJournalView.PayType
            Get
                Return "1"
            End Get
            Set

            End Set
        End Property

        Public Property DiscountAccountIdNo As Int16? Implements IDisbursementJournalView.DiscountAccountIdNo
            Get
                Return Nothing
            End Get
            Set
                
            End Set
        End Property

        Public Property DiscountTaken As Decimal Implements IDisbursementJournalView.DiscountTaken
            Get
                Return 0
            End Get
            Set

            End Set
        End Property

        Public Property IdNo As Int32 Implements IDisbursementJournalView.IdNo
            Get
                Return 0
            End Get
            Set

            End Set
        End Property

        Public Property JournalItems As List(Of IJournalItemView) Implements IDisbursementJournalView.JournalItems
            Get
                Return _journalItems
            End Get
            Set
            End Set
        End Property

        Public Property Notes As String Implements IDisbursementJournalView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = If(Value, "")
            End Set
        End Property

        Public Property ORNumber As String Implements IDisbursementJournalView.OrNumber
            Get
                Return ""
            End Get
            Set

            End Set
        End Property

        Public Property PayeeIdNo As Int32? Implements IDisbursementJournalView.PayeeIdNo
            Get
                Return 0
            End Get
            Set
            End Set
        End Property

        Public Property PayeeName As String Implements IDisbursementJournalView.PayeeName
            Get
                Return txtPayeeName.Text
            End Get
            Set
                txtPayeeName.Text = Value
            End Set
        End Property

        Public Property PaymentType As String Implements IDisbursementJournalView.PaymentType
            Get
                Return "O"
            End Get
            Set
            End Set
        End Property

        Public Property DjOiItems As List(Of DjOiItemView) Implements IDisbursementJournalView.DjOiItems
            Get
                Return _djOiItems
            End Get
            Set(value As List(Of DjOiItemView))
                _djOiItems = value
                BindDjOiItem()
                'bsJournalItems.ResetBindings(True)
            End Set
        End Property

        Public Property Posted As Boolean Implements IDisbursementJournalView.Posted
            Get
                Return False
            End Get
            Set

            End Set
        End Property

        Public Property ReferenceNo As String Implements IDisbursementJournalView.ReferenceNo
            Get
                Return txtReferenceNo.Text
            End Get
            Set
                txtReferenceNo.Text = Value
            End Set
        End Property

        Public Property TotalCredits As Decimal Implements IDisbursementJournalView.TotalCredits
            Get
                Return txtAmount.Text
            End Get
            Set(value As Decimal)

            End Set
        End Property

        Public Property TotalDebits As Decimal Implements IDisbursementJournalView.TotalDebits
            Get
                Return txtAmount.Text
            End Get
            Set(value As Decimal)

            End Set
        End Property

        Public Property TransactionDate As Date? Implements IDisbursementJournalView.TransactionDate
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

        Public Property UnApplied As Decimal Implements IDisbursementJournalView.UnApplied
            Get
                Return 0D
            End Get
            Set

            End Set
        End Property

        Public Property VatAmount As Decimal Implements IDisbursementJournalView.VatAmount
            Get
                Return 0D
            End Get
            Set

            End Set
        End Property

        Public Property VatNumber As String Implements IDisbursementJournalView.VatNumber
            Get
                Return 0D
            End Get
            Set

            End Set
        End Property

#End Region

        Private Property PcJournals As List(Of IPcJournalView) Implements IPcJournalsView.PcJournals
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
                dgvTransactionDate.ReadOnly = True
                dgvAmount.DisplayOnly = True
                dgvPayeeType.DisplayOnly = True
            End With
            ResumeLayout()
        End Sub


        Private Sub PcClosing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            MyPresenter.UpdateViewDisplay(0)
            DataGridViewPcJournals.Refresh()
            BindPcJournals()
            _jiFooter = New DgvFooter(DataGridViewPcJournals) With {
                .AutoCalc = True
            }
            _jiFooter.ColumnToSum("dgvAmount") = True
            _jiFooter.SetText("DgvPayeeName", "Totals ->")
        End Sub

    End Class

End Namespace