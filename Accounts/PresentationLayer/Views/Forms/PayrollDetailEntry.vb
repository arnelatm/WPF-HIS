Imports System.Dynamic
Imports AATM.Accounts.BusinessLayer
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
        Private Property MyPresenter As PayrollDetailPresenter

        Private _payrollEarnings As List(Of PayrollPayElementView)
        Private _payrollDeductions As List(Of PayrollPayElementView)
        Private _payEarningsByCode
        Private _payDeductionsByCode
        Private _earningFooter
        Private _deductionFooter

        Public Sub New(ByVal payrollIdNo As Int16)

            ' This call is required by the designer.
            InitializeComponent()
            ' GlobalVariables.EventAggregator.SubscribeEvent(Me)
            ' Add any initialization after the InitializeComponent() call.
            Me.PayrollIdNo = payrollIdNo
            MainTableName = "PayrollDetail_View"
            TvMainFieldName = "EmployeeName"
            TvSecondaryFieldName = "EmployeeCode"
            SortOrderKey = "SortKey"
            FirstControl = cboEmployeeIdNo
            ' Add any initialization after the InitializeComponent() call.
            MyPresenter = New PayrollDetailPresenter(Me)
            PresenterObj = MyPresenter
            MyPresenter.UpdateDataFilter(payrollIdNo)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)
            _earningFooter = New DgvFooter(DataGridViewEarnings) With {.AutoCalc = True}
            _earningFooter.ColumnToSum("dgvEarningAmount") = True
            _earningFooter.SetText("dgvEarningIdNo", "Totals ->")

            _deductionFooter = New DgvFooter(DataGridViewDeductions) With {.AutoCalc = True}
            _deductionFooter.ColumnToSum("dgvDeductionAmount") = True
            _deductionFooter.SetText("dgvDeductionIdNo", "Totals")

            '_employees = PresenterObj.GetLookup("Employee")
            '_payGroups = PresenterObj.GetLookup("PayGroups")
        End Sub

#Region "Fields"

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

        Public Property EmployeeName As String Implements IPayrollDetailView.EmployeeName
            Get
                Return txtEmployeeName.Text
            End Get
            Set
                txtEmployeeName.Text = Value
            End Set
        End Property

        Public Property EmployeeNameAra As String Implements IPayrollDetailView.EmployeeNameAra
            Get
                Return txtEmployeeNameAra.Text
            End Get
            Set
                txtEmployeeNameAra.Text = Value
            End Set
        End Property

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

#End Region

        Protected Overrides Sub CreateDataSources()
            _payEarningsByCode = MyPresenter.GetLookup("PayElement", "PayElementKind = '" & EnumToCode(PayElementKindSelection.Earning) & "' and Summary = 0")
            _payDeductionsByCode = MyPresenter.GetLookup("PayElement", "PayElementKind = '" & EnumToCode(PayElementKindSelection.Deduction) & "' and Summary = 0")
            cboEmployeeIdNo.BeginUpdate()
            cboEmployeeIdNo.DataSource = MyPresenter.GetLookup("Employee")
            cboEmployeeIdNo.EndUpdate()
        End Sub

        Private Sub BindPayrollEarnings()
            SuspendLayout()
            bsEarnings.DataSource = Nothing
            DataGridViewEarnings.Refresh()
            bsEarnings.DataSource = PayrollEarnings
            bsEarnings.AllowNew = True
            With DataGridViewEarnings
                dgvEarningIdNo.DataSource = _payEarningsByCode
                dgvEarningIdNo.DisplayMember = "Name"
                dgvEarningIdNo.ValueMember = "IdNo"
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
                dgvDeductionIdNo.DataSource = _payDeductionsByCode
                dgvDeductionIdNo.DisplayMember = "Name"
                dgvDeductionIdNo.ValueMember = "IdNo"
                dgvDeductionIdNo.DisplayStyleForCurrentCellOnly = True
                .Refresh()
                .AutoGenerateColumns = False
                .DataSource = bsDeductions
                .Refresh()
            End With

        End Sub

        Private Sub PayrollDetailEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            MyPresenter.DisplayPayrollDetails(dtpStartDate.Value, dtpEndDate.Value, txtPayPeriodName.Text)
        End Sub

        Protected Overrides Sub RecordPositionChanged(ByRef e As RecordPositionChanged)
            MyBase.RecordPositionChanged(e)
            UpdateTotals()
        End Sub

        Private Sub UpdateTotals()
            _earningFooter.SumColumn("dgvEarningAmount")
            _deductionFooter.SumColumn("dgvDeductionAmount")
            Dim earning = _earningFooter.GetColumnTotal("dgvEarningAmount")
            Dim deduction = _deductionFooter.GetColumnTotal("dgvDeductionAmount")
            txtTotalEarnings.Text = earning
            txtTotalDeductions.Text = deduction
            txtNetPay.Text = earning - deduction
        End Sub

    End Class

End Namespace