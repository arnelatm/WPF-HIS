Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.CustomControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Views.Forms

    Public Class EarningEntry
        Implements IEarningView

        Public TxtTotalCredits As Decimal
        Public TxtTotalDebits As Decimal
        Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat
        Private _accountsByCode
        Private _footer As DgvFooter
        Private _payrollEarnAccounts As New List(Of PayrollEarnAccountView)
        Private _payGroupByCode
        Private ReadOnly _closingEntry As Boolean

        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            Text = Messaging.TranslateCaption("Earning Entry")
            MainTableName = "Earning"

            SortOrderKey = "IdNo"
            FirstControl = txtNotes
            _nfi.NumberDecimalDigits = 2
            PresenterObj = New EarningPresenter(Me)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)

        End Sub

#Region "Fields"

        Public Property PayrollEarnAccountsDataSource As List(Of PayrollEarnAccountModel)

        Public Property IdNo As Int16 Implements IEarningView.IdNo
            Get
                Return NumParser(Of Int16)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property AccountIdNo As Int16 Implements IEarningView.AccountIdNo
            Get
                Return cboAccountIdNo.GetValue()
            End Get
            Set
                cboAccountIdNo.SetValue(Value)
            End Set
        End Property

        Public Property EarningCode As String Implements IEarningView.EarningCode
            Get
                Return txtEarningCode.Text
            End Get
            Set
                txtEarningCode.Text = Value
            End Set
        End Property

        Public Property EarningName As String Implements IEarningView.EarningName
            Get
                Return txtEarningName.Text
            End Get
            Set
                txtEarningName.Text = Value
                'txtName.Text = Value
            End Set
        End Property

        Public Property EarningNameAra As String Implements IEarningView.EarningNameAra
            Get
                Return txtEarningNameAra.Text
            End Get
            Set
                txtEarningNameAra.Text = Value
                'txtNameAra.Text = Value
            End Set
        End Property

        Public Property Frequency As Char Implements IEarningView.Frequency
            Get
                Return cboFrequency.GetValue()
            End Get
            Set
                cboFrequency.SetValue(Value)
            End Set
        End Property

        Public Property EarningType As Char Implements IEarningView.EarningType
            Get
                Return cboEarningType.GetValue()
            End Get
            Set
                cboEarningType.SetValue(Value)
            End Set
        End Property

        Public Property PayrollEarnAccounts As List(Of PayrollEarnAccountView) Implements IEarningView.PayrollEarnAccounts
            Get
                Return _payrollEarnAccounts
            End Get
            Set
                _payrollEarnAccounts = Value
                BindPayrollEarnAccount()
            End Set
        End Property

        Public Property Notes As String Implements IEarningView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = If(Value, "")
            End Set
        End Property

#End Region

#Region "Methods"

        Protected Overrides Sub CreateDataSources()
            _accountsByCode = PresenterObj.GetDetailAccountListByCode()
            _payGroupByCode = PresenterObj.GetPayGroupListByCode()
        End Sub

        Protected Overrides Sub CreateFieldsDictionary()
            FieldsDictionary = New Dictionary(Of String, Object) From
        {
         {"IdNo", TxtIdNo},
         {"Notes", txtNotes}
        }
        End Sub

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
                dgvSequence.DisplayOnly = True
                dgvPayGroupIdNo.DataSource = _payGroupByCode
                dgvPayGroupIdNo.DisplayMember = "Name"
                dgvPayGroupIdNo.ValueMember = "idNo"
                dgvPayGroupIdNo.AutoComplete = AutoCompleteMode.SuggestAppend
                dgvPayGroupIdNo.DisplayStyleForCurrentCellOnly = True
                dgvPayGroupIdNo.AutoComplete = True
                dgvAccountIdNo.DataSource = _accountsByCode
                dgvAccountIdNo.DisplayMember = "Name"
                dgvAccountIdNo.ValueMember = "IdNo"
                dgvAccountIdNo.AutoComplete = AutoCompleteMode.SuggestAppend
                dgvAccountIdNo.DisplayStyleForCurrentCellOnly = True
                dgvAccountIdNo.AutoComplete = True
            End With
            ResumeLayout()
        End Sub

        Private Sub OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) _
                    Handles DataGridViewPayrollEarnAccounts.CellEndEdit
            With DataGridViewPayrollEarnAccounts.CurrentCell
                Select Case .OwningColumn.Name.ToLower()
                    Case $"dgvsequence"
                        SendKeys.Send("{TAB}")
                    Case $"dgvpaygroupid"
                        SendKeys.Send("{DOWN}")
                End Select
                DataGridViewPayrollEarnAccounts.Refresh()
            End With
        End Sub

        'Private Sub TxtNotes_Leave(sender As Object, e As EventArgs)
        '    If DataGridViewPayrollEarnAccounts IsNot Nothing Then
        '        DataGridViewPayrollEarnAccounts.Focus()
        '    End If
        'End Sub

#End Region

    End Class

End Namespace