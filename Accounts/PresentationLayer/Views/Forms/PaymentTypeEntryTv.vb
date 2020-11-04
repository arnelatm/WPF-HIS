Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms

    Public Class PaymentTypeEntryTv
        Implements IPaymentTypeView

        Private _accountsByCode
        Private _payrollEarnAccounts As List(Of PayrollEarnAccountView)
        Private _useRevCostCenters As Nullable(Of Boolean)
        Private _useDepartments As Nullable(Of Boolean)
        Private _usePayGroups As Nullable(Of Boolean)
        Private ReadOnly _nfi As NumberFormatInfo = GlobalVariables.DefaultNumberFormatInfo

        Public Sub New()

            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()

            MainTableName = "PaymentType"
            TvMainFieldName = "PaymentTypeName"
            TvSecondaryFieldName = "PaymentTypeCode"
            SortOrderKey = "PaymentTypeName"
            FirstControl = txtPaymentTypeCode
            PresenterObj = New PaymentTypePresenter(Me)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)

        End Sub

#Region "Fields"

        Public Property IdNo As Int16 Implements IPaymentTypeView.IdNo
            Get
                Return NumParser(Of Int16)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property PaymentTypeCode As String Implements IPaymentTypeView.PaymentTypeCode
            Get
                Return txtPaymentTypeCode.Text
            End Get
            Set
                txtPaymentTypeCode.Text = Value
            End Set
        End Property

        Public Property PaymentTypeName As String Implements IPaymentTypeView.PaymentTypeName
            Get
                Return txtPaymentTypeName.Text
            End Get
            Set
                txtPaymentTypeName.Text = Value
            End Set
        End Property

        Public Property PaymentTypeNameAra As String Implements IPaymentTypeView.PaymentTypeNameAra
            Get
                Return txtPaymentTypeNameAra.Text
            End Get
            Set
                txtPaymentTypeNameAra.Text = Value
            End Set
        End Property

        'Public Property Frequency As Char Implements IPaymentTypeView.Frequency
        '    Get
        '        Return cboFrequency.GetValue()
        '    End Get
        '    Set
        '        cboFrequency.SetValue(Value)
        '    End Set
        'End Property

        Public Property PayrollEarnAccounts As List(Of PayrollEarnAccountView) Implements IPaymentTypeView.PayrollEarnAccounts
            Get
                Return _payrollEarnAccounts
            End Get
            Set
                _payrollEarnAccounts = Value
                BindPayrollEarnAccounts()
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateDataSources()
            cboBankChargesAccountIdNo.DataSource = PresenterObj.GetChartList()
            _accountsByCode = PresenterObj.GetDetailAccountListByCode()
        End Sub

        Private Sub BindPayrollEarnAccounts()
            SuspendLayout()
            bsPayrollEarnAccounts.DataSource = Nothing
            DataGridViewPayrollEarnAccounts.Refresh()
            bsPayrollEarnAccounts.DataSource = PayrollEarnAccounts
            'bsPayrollEarnAccounts.AllowNew = True
            With DataGridViewPayrollEarnAccounts
                .Refresh()
                .AutoGenerateColumns = False
                .DataSource = Nothing
                .DataSource = bsPayrollEarnAccounts
                .Refresh()
            End With
            With DataGridViewPayrollEarnAccounts.Columns
                dgvPayGroupIdNo.DataSource = _payGroupsByCode
                dgvPayGroupIdNo.DisplayMember = "Name"
                dgvPayGroupIdNo.ValueMember = "IdNo"
                dgvPayGroupIdNo.AutoComplete = AutoCompleteMode.SuggestAppend
                dgvPayGroupIdNo.DisplayStyleForCurrentCellOnly = True
                dgvAccountIdNo.DataSource = _accountsByCode
                dgvAccountIdNo.DisplayMember = "Name"
                dgvAccountIdNo.ValueMember = "IdNo"
                dgvAccountIdNo.AutoComplete = AutoCompleteMode.SuggestAppend
                dgvAccountIdNo.DisplayStyleForCurrentCellOnly = True
            End With
            ResumeLayout()
        End Sub

        Protected Overrides Sub CreateFieldsDictionary()
            FieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"AccountIdNo", cboBankChargesAccountIdNo},
                {"PaymentTypeCode", txtPaymentTypeCode},
                {"PaymentTypeName", txtPaymentTypeName},
                {"PaymentTypeNameAra", txtPaymentTypeNameAra},
                {"IdNo", TxtIdNo},
                {"Notes", txtNotes}
                }
        End Sub

        'Private Sub OnPaymentTypeTypeSelectedIndexChanged(sender As Object, e As EventArgs)
        '    If GetEnumCodeValue(Of PaymentTypeTypeSelection)(cboPaymentTypeType.SelectedValue) = PaymentTypeTypeSelection.Miscellaneous Then
        '        cboFrequency.SelectedValue = GetEnumCode(PayFrequencySelection.AsNeeded)
        '        cboFrequency.DisplayOnly = True
        '    Else
        '        cboFrequency.DisplayOnly = False
        '    End If
        'End Sub

        Private Sub BindPayrollEarnAccount()
            SuspendLayout()
            bsPayrollEarnAccounts.DataSource = Nothing
            DataGridViewPayrollEarnAccounts.Refresh()
            bsPayrollEarnAccounts.DataSource = PayrollEarnAccounts
            bsPayrollEarnAccounts.AllowNew = True
            With DataGridViewPayrollEarnAccounts
                .Refresh()
                .AutoGenerateColumns = False
                .DataSource = bsPayrollEarnAccounts
                .Refresh()
            End With
            With DataGridViewPayrollEarnAccounts.Columns
                dgvAccountIdNo.DataSource = _accountsByCode
                dgvAccountIdNo.DisplayMember = "Name"
                dgvAccountIdNo.ValueMember = "IdNo"
                dgvAccountIdNo.AutoComplete = AutoCompleteMode.SuggestAppend
                dgvAccountIdNo.DisplayStyleForCurrentCellOnly = True
                dgvAccountIdNo.AutoComplete = True
            End With
            ResumeLayout()
        End Sub

    End Class

End Namespace