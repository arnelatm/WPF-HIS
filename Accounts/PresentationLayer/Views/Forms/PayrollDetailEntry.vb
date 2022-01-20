Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Views.Forms

    Public Class PayrollDetailEntry
        Implements IPayrollDetailView

        'Private _bypassSelectedChange As Boolean = False
        'Private _employees
        'Private _payGroups

        Private _payrollEarnings As List(Of PayrollPayElementView)
        Private _payrollDeductions As List(Of PayrollPayElementView)
        Private _earningFooter
        Private _deductionFooter

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub

        Public Sub New(ByVal payrollIdNo As Object)

            ' This call is required by the designer.
            InitializeComponent()
            ' GlobalVariables.EventAggregator.SubscribeEvent(Me)
            ' Add any initialization after the InitializeComponent() call.
            Me.PayrollIdNo = payrollIdNo
            FirstControl = cboEmployeeIdNo
            ' Add any initialization after the InitializeComponent() call.

            _earningFooter = New DgvFooter(DataGridViewEarnings) With {.AutoCalc = True}
            _earningFooter.ColumnToSum("dgvEarningAmount") = True
            _earningFooter.SetText("dgvEarningIdNo", "Totals ->")

            _deductionFooter = New DgvFooter(DataGridViewDeductions) With {.AutoCalc = True}
            _deductionFooter.ColumnToSum("dgvDeductionAmount") = True
            _deductionFooter.SetText("dgvDeductionIdNo", "Totals")

            '_employees = Presenter.GetLookup("Employee")
            '_payGroups = Presenter.GetLookup("PayGroups")
        End Sub

#Region "Fields"

        Public Property PayEarningsByCode As Object Implements IPayrollDetailView.PayEarningsByCode
        Public Property PayDeductionsByCode As Object Implements IPayrollDetailView.PayDeductionsByCode

        Public Property BankTransfer As Boolean Implements IPayrollDetailView.BankTransfer
            Get
                Return chkBankTransfer.Checked
            End Get
            Set
                chkBankTransfer.Checked = Value
            End Set
        End Property

        Public Property IdNo As Int32 Implements IPayrollDetailView.IdNo
            Get
                Return NumParser(Of Int16)(txtIdNo.Text)
            End Get
            Set
                txtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property EmployeeIdNo As Int32 Implements IPayrollDetailView.EmployeeIdNo
            Get
                Return cboEmployeeIdNo.GetNullableValue(Of Int32)
            End Get
            Set
                cboEmployeeIdNo.SetValue(Value)
            End Set
        End Property

        Public Property EmployeeCode As String Implements IPayrollDetailView.EmployeeCode
            Get
                Return txtEmployeeCode.Text
            End Get
            Set
                txtEmployeeCode.Text = Value
            End Set
        End Property

        Private _employeeName As String
        Private _employeeNameAra As String

        'Public Property EmployeeName As String Implements IPayrollDetailView.EmployeeName
        '    Get
        '        Return _employeeName
        '    End Get
        '    Set
        '        _employeeName = Value
        '        If Not GlobalVariables.RightToLeftLayout Then
        '            txtEmployeeName.Text = Value
        '        End If
        '    End Set
        'End Property

        'Public Property EmployeeNameAra As String Implements IPayrollDetailView.EmployeeNameAra
        '    Get
        '        Return _employeeNameAra
        '    End Get
        '    Set
        '        _employeeNameAra = Value
        '        If GlobalVariables.RightToLeftLayout Then
        '            txtEmployeeNameAra.Text = Value
        '        End If
        '    End Set
        'End Property

        Public Property PayrollIdNo As Int16 Implements IPayrollDetailView.PayrollIdNo
            Get
                Return NumParser(Of Int16)(txtPayrollIdNo.Text)
            End Get
            Set
                txtPayrollIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property PayrollEarnings As List(Of PayrollPayElementView) Implements IPayrollDetailView.PayrollEarnings
            Get
                Return _payrollEarnings
            End Get
            Set(value As List(Of PayrollPayElementView))
                _payrollEarnings = value
                BindPayrollEarnings()
            End Set
        End Property

        Public Property PayrollDeductions As List(Of PayrollPayElementView) Implements IPayrollDetailView.PayrollDeductions
            Get
                Return _payrollDeductions
            End Get
            Set(value As List(Of PayrollPayElementView))
                _payrollDeductions = value
                BindPayrollDeductions()
            End Set
        End Property

        Public Property StartDate As Date Implements IPayrollDetailView.StartDate
            Get
                Return dtpStartDate.Value
            End Get
            Set
                dtpStartDate.Value = Value
            End Set
        End Property

        Public Property EndDate As Date Implements IPayrollDetailView.EndDate
            Get
                Return dtpEndDate.Value
            End Get
            Set
                dtpEndDate.Value = Value
            End Set
        End Property

        Private _payPeriodName As String
        Private _payPeriodNameAra As String

        Public Property PayPeriodName As String Implements IPayrollDetailView.PayPeriodName
            Get
                Return _payPeriodName
            End Get
            Set(value As String)
                _payPeriodName = value
                If Not GlobalVariables.RightToLeftLayout Then
                    txtPayPeriodDescription.Text = value
                End If
            End Set
        End Property

        Public Property PayPeriodNameAra As String Implements IPayrollDetailView.PayPeriodNameAra
            Get
                Return _payPeriodNameAra
            End Get
            Set(value As String)
                _payPeriodNameAra = value
                If GlobalVariables.RightToLeftLayout Then
                    txtPayPeriodDescription.Text = value
                End If
            End Set
        End Property

        Public Property PaymentMethod As String Implements IPayrollDetailView.PaymentMethod

        Public Property SponsorType As String Implements IPayrollDetailView.SponsorType

        Public Property Selected As Boolean Implements IPayrollDetailView.Selected

        'Public Property PayPeriodDescription As String

#End Region

        'Public Event UpdateDataFilterEvent(pPayrollIdNo As Int16) Implements IPayrollDetailView.UpdateDataFilterEvent
        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"BankTransfer", chkBankTransfer},
                {"EmployeeCode", txtEmployeeCode},
                {"EmployeeIdNo", cboEmployeeIdNo},
                {"EndDate", dtpEndDate},
                {"IdNo", txtIdNo},
                {"PayrollIdNo", txtPayrollIdNo},
                {"StartDate", dtpStartDate}
                }
        End Sub

        Private Sub BindPayrollEarnings()
            SuspendLayout()
            bsEarnings.DataSource = Nothing
            DataGridViewEarnings.Refresh()
            bsEarnings.DataSource = PayrollEarnings
            bsEarnings.AllowNew = True
            With DataGridViewEarnings
                dgvEarningIdNo.DataSource = _PayEarningsByCode
                dgvEarningIdNo.DisplayMember = "Name"
                dgvEarningIdNo.ValueMember = "IdNo"
                dgvEarningGenerated.DisplayOnly = True
                dgvEarningIdNo.DisplayStyleForCurrentCellOnly = True
                .Refresh()
                .AutoGenerateColumns = False
                .DataSource = bsEarnings
                .Refresh()
            End With
        End Sub

        Private Sub BindPayrollDeductions()
            SuspendLayout()
            bsDeductions.DataSource = Nothing
            DataGridViewDeductions.Refresh()
            bsDeductions.DataSource = PayrollDeductions
            bsDeductions.AllowNew = True
            With DataGridViewDeductions
                dgvDeductionIdNo.DataSource = _PayDeductionsByCode
                dgvDeductionIdNo.DisplayMember = "Name"
                dgvDeductionIdNo.ValueMember = "IdNo"
                dgvDeductionGenerated.DisplayOnly = True
                dgvDeductionIdNo.DisplayStyleForCurrentCellOnly = True
                .Refresh()
                .AutoGenerateColumns = False
                .DataSource = bsDeductions
                .Refresh()
            End With

        End Sub

        'Private Sub PayrollDetailEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '    RaiseEvent UpdateDataFilterEvent(PayrollIdNo)
        '    'MyPresenter.DisplayPayrollDetails(dtpStartDate.Value, dtpEndDate.Value, txtPayPeriodName.Text)
        'End Sub

        Private Sub OnAfterUpdateView() Handles MyBase.AfterUpdateView
            UpdateTotals()
        End Sub

        Private Sub UpdateTotals()
            If _earningFooter IsNot Nothing Then
                _earningFooter.SumColumn("dgvEarningAmount")
                _deductionFooter.SumColumn("dgvDeductionAmount")
                Dim earning = _earningFooter.GetColumnTotal("dgvEarningAmount")
                Dim deduction = _deductionFooter.GetColumnTotal("dgvDeductionAmount")
                txtTotalEarnings.Text = String.Format("{0:#,##0.00}", Double.Parse(earning))
                txtTotalDeductions.Text = String.Format("{0:#,##0.00}", Double.Parse(deduction))
                txtNetPay.Text = String.Format("{0:#,##0.00}", Double.Parse(earning - deduction))
            End If
        End Sub

        Protected Sub OnTextDisplayLanguageChangedHere() Handles MyBase.TextDisplayLanguageChanged
            'MyBase.OnTextDisplayLanguageChanged()
            If GlobalVariables.RightToLeftLayout Then
                txtPayPeriodDescription.Text = PayPeriodNameAra
            Else
                txtPayPeriodDescription.Text = PayPeriodName
            End If
            cboEmployeeIdNo.Refresh()
        End Sub

        Private Sub DataGridView_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewEarnings.CellEndEdit, DataGridViewDeductions.CellEndEdit
            UpdateTotals()
        End Sub

        Private Sub DataGridView_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridViewEarnings.UserDeletedRow, DataGridViewDeductions.UserDeletedRow
            UpdateTotals()
        End Sub

    End Class

End Namespace