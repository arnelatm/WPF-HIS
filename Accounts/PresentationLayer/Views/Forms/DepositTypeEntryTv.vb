Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms

    Public Class DepositTypeEntryTv
        Implements IDepositTypeView

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

            MainTableName = "DepositType"
            TvMainFieldName = "DepositTypeName"
            TvSecondaryFieldName = "DepositTypeCode"
            SortOrderKey = "DepositTypeName"
            FirstControl = txtDepositTypeCode
            PresenterObj = New DepositTypePresenter(Me)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)

        End Sub

#Region "Fields"

        Public Property IdNo As Int16 Implements IDepositTypeView.IdNo
            Get
                Return NumParser(Of Int16)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property AccountIdNo As Short Implements IDepositTypeView.AccountIdNo
            Get
                Return cboAccountIdNo.GetValue()
            End Get
            Set
                cboAccountIdNo.SetValue(Value)
            End Set
        End Property

        Public Property BankChargesAccountIdNo As Int16? Implements IDepositTypeView.BankChargesAccountIdNo
            Get
                Return cboBankChargesAccountIdNo.GetNullableValue(Of Int16)
            End Get
            Set
                cboBankChargesAccountIdNo.SetValue(Value)
            End Set
        End Property

        Public Property BankChargesVatAccountIdNo As Int16? Implements IDepositTypeView.BankChargesVatAccountIdNo
            Get
                Return cboBankChargesVatAccountIdNo.GetNullableValue(Of Int16)
            End Get
            Set
                cboBankChargesVatAccountIdNo.SetValue(Value)
            End Set
        End Property

        Public Property DepositTypeCode As String Implements IDepositTypeView.DepositTypeCode
            Get
                Return txtDepositTypeCode.Text
            End Get
            Set
                txtDepositTypeCode.Text = Value
            End Set
        End Property

        Public Property DepositTypeName As String Implements IDepositTypeView.DepositTypeName
            Get
                Return txtDepositTypeName.Text
            End Get
            Set
                txtDepositTypeName.Text = Value
            End Set
        End Property

        Public Property DepositTypeNameAra As String Implements IDepositTypeView.DepositTypeNameAra
            Get
                Return txtDepositTypeNameAra.Text
            End Get
            Set
                txtDepositTypeNameAra.Text = Value
            End Set
        End Property

        Public Property Notes As String Implements IDepositTypeView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = Value
            End Set
        End Property

        Public Property Rate As Decimal Implements IDepositTypeView.Rate
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtRate.Text), _nfi)
            End Get
            Set
                txtRate.Text = Value.ToString("F4")
            End Set
        End Property

        Public Property WithBankCharges As Boolean Implements IDepositTypeView.WithBankCharges
            Get
                Return chkWithBankCharges.Checked
            End Get
            Set
                chkWithBankCharges.Checked = Value
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateDataSources()
            cboAccountIdNo.DataSource = PresenterObj.GetDetailAccountList()
            cboBankChargesAccountIdNo.DataSource = PresenterObj.GetDetailAccountList()
            cboBankChargesVatAccountIdNo.DataSource = PresenterObj.GetDetailAccountList()
        End Sub

        Protected Overrides Sub CreateFieldsDictionary()
            FieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"AccountIdNo", cboBankChargesVatAccountIdNo},
                {"BankChargesAccountIdNo", cboBankChargesAccountIdNo},
                {"BankChargesVatAccountIdNo", cboBankChargesVatAccountIdNo},
                {"DepositTypeCode", txtDepositTypeCode},
                {"DepositTypeName", txtDepositTypeName},
                {"DepositTypeNameAra", txtDepositTypeNameAra},
                {"IdNo", TxtIdNo},
                {"Notes", txtNotes},
                {"Rate", txtRate},
                {"WithBankCharges", chkWithBankCharges}
                }
        End Sub

        Private Sub ChkWithBankCharges_CheckedChanged(sender As Object, e As EventArgs) Handles chkWithBankCharges.CheckedChanged
            tlpPaymentType.Visible = False
            If chkWithBankCharges.Checked Then
                cboBankChargesAccountIdNo.Visible = True
                lblBankChargesAccountIdNo.Visible = True
                cboBankChargesVatAccountIdNo.Visible = True
                lblBankChargesVatAccountIdNo.Visible = True
                lblRate.Visible = True
                txtRate.Visible = True
                lblPercentSign.Visible = True
            Else
                cboBankChargesAccountIdNo.Visible = False
                lblBankChargesAccountIdNo.Visible = False
                cboBankChargesVatAccountIdNo.Visible = False
                lblBankChargesVatAccountIdNo.Visible = False
                lblRate.Visible = False
                txtRate.Visible = False
                lblPercentSign.Visible = False
            End If
            tlpPaymentType.Visible = True
        End Sub

    End Class

End Namespace