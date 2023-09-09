Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Views.Forms

    Public Class CheckPrinter
        Implements IDisbursementJournalView, ISubscriber(Of BeforeAssignment)

        Public TxtTotalCredits As Decimal
        Public TxtTotalDebits As Decimal

        Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat
        Private _accountsByCode

        Public Event PrintCheck() Implements IDisbursementJournalView.PrintCheck

        Public Event AutoApplyAmount(bsDjOiItem As BindingSource) Implements IDisbursementJournalView.AutoApplyAmount

        Public Event AddSupplierOpenInvoices() Implements IDisbursementJournalView.AddSupplierOpenInvoices

        Public Event UserDeletedRow() Implements IDisbursementJournalView.UserDeletedRow

        Public Event PrintPcReplenishment() Implements IDisbursementJournalView.PrintPcReplenishment

        Public Event FirstLineUpdateNeeded() Implements IDisbursementJournalView.FirstLineUpdateNeeded

        Public Event SetSupplierVatNumber(ByRef currentVatNumber As String, idNo As String, override As Boolean) Implements IDisbursementJournalView.SetSupplierVatNumber
        Public Event PaymentTypeChanged() Implements IDisbursementJournalView.PaymentTypeChanged

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.

        End Sub

        Public Sub New(ByVal tableName As String)
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            EnableDoubleBuff(tlpDisbursement)
            ' Add any initialization after the InitializeComponent() call.
            HideNavigatorButtons = True
            'MainTableName = tableName
            'MyPresenter = New DisbursementJournalPresenter(Me, "CdJournal")
            'MyPresenter.JournalCode = "CD"
            Text = Messaging.TranslateCaption("Check Disbursement Journal")
            btnPrintCheck.Visible = True
            'Presenter = MyPresenter
            'SortOrderKey = "IdNo"
            FirstControl = cboPaymentType
            _nfi.NumberDecimalDigits = 2

        End Sub

#Region "Field Items"

        Public Property AccountIdNo As Int16? Implements IDisbursementJournalView.AccountIdNo

        Public Property Amount As Decimal Implements IDisbursementJournalView.Amount
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtAmount.Text), _nfi)
            End Get
            Set
                txtAmount.Text = FormatMoney(Value)

            End Set
        End Property

        Public Property Applied As Decimal Implements IDisbursementJournalView.Applied
        Public Property Approved As Boolean Implements IDisbursementJournalView.Approved

        Public Property Cancelled As Boolean Implements IDisbursementJournalView.Cancelled

        Public Property CdJournalIdNo As Int32? Implements IDisbursementJournalView.CdJournalIdNo

        Public Property CheckDate As DateTime? Implements IDisbursementJournalView.CheckDate
            Get
                Return dtpCheckDate.Value
            End Get
            Set
                If Value.HasValue Then
                    dtpCheckDate.Value = Value
                Else
                    dtpCheckDate.Value = Date.Now()
                End If
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

        Public Property DiscountTaken As Decimal Implements IDisbursementJournalView.DiscountTaken

        Public Property IdNo As Int32 Implements IDisbursementJournalView.IdNo

        Public Property JournalItems As List(Of JournalItemView) Implements IDisbursementJournalView.JournalItems

        Public Property Notes As String Implements IDisbursementJournalView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = If(Value, "")
            End Set
        End Property

        Public Property ORNumber As String Implements IDisbursementJournalView.OrNumber

        Public Property PayeeIdNo As Int32? Implements IDisbursementJournalView.PayeeIdNo
            Get
                Return cboPayeeIdNo.GetNullableValue(Of Int32)
            End Get
            Set
                If cboPayeeIdNo.DataSource IsNot Nothing Then
                    cboPayeeIdNo.SetValue(Value)
                Else
                    cboPayeeIdNo.SelectedValue = Nothing
                End If
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
                Return cboPaymentType.GetValue()
            End Get
            Set
                cboPaymentType.SetValue(Value)
            End Set
        End Property

        Public Property DjOiItems As List(Of DjOiItemView) Implements IDisbursementJournalView.DjOiItems

        Public Property Posted As Boolean Implements IDisbursementJournalView.Posted

        Public Property ReferenceNo As String Implements IDisbursementJournalView.ReferenceNo

        Public Property TotalCredits As Decimal Implements IDisbursementJournalView.TotalCredits

        Public Property TotalDebits As Decimal Implements IDisbursementJournalView.TotalDebits

        Public Property TransactionDate As Date? Implements IDisbursementJournalView.TransactionDate

        Public Property UnApplied As Decimal Implements IDisbursementJournalView.UnApplied

        Public Property VatAmount As Decimal Implements IDisbursementJournalView.VatAmount

        Public Property VatNumber As String Implements IDisbursementJournalView.VatNumber

        Public Property DiscountAccountIdNo As Short? Implements IDisbursementJournalView.DiscountAccountIdNo

        Public Property PayType As String Implements IDisbursementJournalView.PayType

        Public Property PcClosed As Boolean Implements IDisbursementJournalView.PcClosed

        Public Property AccountsByCode As Object Implements IDisbursementJournalView.AccountsByCode
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As Object)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property EmployeesByName As Object Implements IDisbursementJournalView.EmployeesByName
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As Object)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property SuppliersByName As Object Implements IDisbursementJournalView.SuppliersByName
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As Object)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property CustomersByName As Object Implements IDisbursementJournalView.CustomersByName
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As Object)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property RevCostCentersByCode As Object Implements IDisbursementJournalView.RevCostCentersByCode
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As Object)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property BankTransfer As Boolean Implements IDisbursementJournalView.BankTransfer
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As Boolean)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property PayeeDataSource As Object Implements IDisbursementJournalView.PayeeDataSource
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As Object)
                Throw New NotImplementedException()
            End Set
        End Property

#End Region

        Public Sub OnEventHandler(ByRef eventType As BeforeAssignment) Implements ISubscriber(Of BeforeAssignment).OnEventHandler
            ' need to do this because the Mapping source part of this program maps the PayeeIdNo first before
            ' the DepositType so in order to override this part we need to retrieve the DepositType first
            ' because when assigning the cboPayeeIdNo the dataSource must be correct that is why
            ' we need to set the DataSource part of the cboPayeeIdNo before we can assign the PayeeIdNo
            PaymentType = eventType.Model.PaymentType
            SetPayeeDataSource(PaymentType)
            cboPaymentType.SelectedValue = IIf(PaymentType = Nothing, 0, PaymentType)
            ShowPayee()
        End Sub

        'Protected Overrides Sub CreateDataSources()
        '    cboPaymentType.DataSource = Presenter.MakeEnumComboList(Of PaymentTypeSelection)
        'End Sub

        Private Sub DjJournalEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            dtpCheckDate.Visible = True
            lblCheckDate.Visible = True
            lblCheckNumber.Visible = True
            txtCheckNumber.Visible = True
            btnSave.Visible = False
            btnEdit.Visible = False
            btnDelete.Visible = False
            btnAdd.Visible = False
            btnFind.Visible = False
            dtpCheckDate.Value = Today
            TurnOnInputs()
            ShowPayee()
            Presenter.MakeEnumComboList(Of PaymentTypeSelection)("PaymentType")
        End Sub

        Public Overloads Sub Dispose()
            Close()
        End Sub

        Private Sub CboPaymentType_ValueChanged(sender As Object, e As EventArgs) Handles cboPaymentType.SelectionChangeCommitted, cboPaymentType.Validated
            SetPayeeDataSource(PaymentType)
            txtPayeeName.Text = cboPayeeIdNo.Text
            ShowPayee()
        End Sub

        Private Sub btnPrintCheck_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnPrintCheck.ClickButtonArea
            Dim checkAmountInWords As String
            Dim currencies As New List(Of CurrencyInfo)()
            Dim curCulture = CultureInfo.CurrentCulture
            CultureInfo.CurrentCulture = New CultureInfo("En-GB", False)
            Dim language As String
            Dim reportName As String
            Dim payee As String
            language = Strings.Left(curCulture.Name, curCulture.Name.IndexOf("-", StringComparison.Ordinal))
            currencies.Add(New CurrencyInfo(CurrencyInfo.Currencies.SaudiArabia))
            If language = "ar" Then
                checkAmountInWords = New ToWord(txtAmount.Text, currencies(0)).ConvertToArabic()
            Else
                checkAmountInWords = New ToWord(txtAmount.Text, currencies(0)).ConvertToEnglish()
            End If
            Dim paymentTypeEnum = CodeToEnum(Of PaymentTypeSelection)(cboPaymentType.SelectedValue)
            If paymentTypeEnum = PaymentTypeSelection.Others Then
                payee = txtPayeeName.Text
            Else
                payee = Strings.Left(cboPayeeIdNo.Text, cboPayeeIdNo.Text.IndexOf("|", StringComparison.Ordinal))
            End If
            reportName = "Check Printing.Rpt"
            Dim cForm As New ReportForm(reportName, checkAmountInWords, "CheckAmountInWords", payee, "PayeeName", dtpCheckDate.Value, "CheckDate", Convert.ToDecimal(txtAmount.Text), "CheckAmount", txtNotes.Text, "Notes", language, "Language")
            cForm.Show()
        End Sub

        Private Sub ShowPayee()
            Dim paymentTypeEnum = CodeToEnum(Of PaymentTypeSelection)(cboPaymentType.SelectedValue)
            If paymentTypeEnum <> PaymentTypeSelection.Others Then
                cboPayeeIdNo.Visible = True
                txtPayeeName.Visible = False
                tlpDisbursement.SetCellPosition(txtPayeeName, New TableLayoutPanelCellPosition(0, 5))
                tlpDisbursement.SetCellPosition(cboPayeeIdNo, New TableLayoutPanelCellPosition(1, 3))
            Else
                cboPayeeIdNo.Visible = False
                txtPayeeName.Visible = True
                tlpDisbursement.SetCellPosition(cboPayeeIdNo, New TableLayoutPanelCellPosition(0, 5))
                tlpDisbursement.SetCellPosition(txtPayeeName, New TableLayoutPanelCellPosition(1, 3))
            End If
        End Sub

        Private Sub SetPayeeDataSource(ByVal cPaymentType As String)
            Dim cbDataSource = Nothing
            Dim curValue As Int32? = cboPayeeIdNo.SelectedValue
            cboPayeeIdNo.DataSource = cbDataSource
            Dim paymentTypeEnum = CodeToEnum(Of PaymentTypeSelection)(cPaymentType)
            If paymentTypeEnum = PaymentTypeSelection.Supplier Or paymentTypeEnum = PaymentTypeSelection.AccountsPayable Then
                cbDataSource = Presenter.GetLookup("Supplier")
            ElseIf paymentTypeEnum = PaymentTypeSelection.Employee Then
                cbDataSource = Presenter.GetLookup("Employee")
            ElseIf paymentTypeEnum = PaymentTypeSelection.CustomerRefund Then
                cbDataSource = Presenter.GetLookup("Customer")
            End If
            cboPayeeIdNo.DataSource = cbDataSource
            If curValue IsNot Nothing Then
                cboPayeeIdNo.SelectedValue = curValue
            Else
                cboPayeeIdNo.SelectedValue = -1
            End If
        End Sub

    End Class

End Namespace