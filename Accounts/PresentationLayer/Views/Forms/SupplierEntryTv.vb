Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Views.Forms

    Public Class SupplierEntryTv
        Implements ISupplierView

        Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat

        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            _nfi.NumberDecimalDigits = 2
            MainTableName = "Supplier"
            TvMainFieldName = "SupplierName"
            TvSecondaryFieldName = "SupplierCode"
            SortOrderKey = "SupplierName"
            FirstControl = txtSupplierCode
            ' Add any initialization after the InitializeComponent() call.
            PresenterObj = New SupplierPresenter(Me)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)
        End Sub

#Region "Fields"

        Public Property AccountStatus As String Implements ISupplierView.AccountStatus
            Get
                Return cacAccountStatus.GetValue()
                'Return GetEnumCode(cacAccountStatus.Text)
            End Get
            Set
                cacAccountStatus.SetValue(Value)
                'cacAccountStatus.Text = GetEnumCode(value)
            End Set
        End Property

        Public Property Active As Boolean Implements ISupplierView.Active
            Get
                Return chkActive.Checked
            End Get
            Set
                chkActive.Checked = Value
            End Set
        End Property

        Public Property ApAccountIdNo As Int16? Implements ISupplierView.ApAccountIdNo
            Get
                Return cacApAccountIdNo.GetNullableValue(Of Int16)
            End Get
            Set
                cacApAccountIdNo.SetValue(Value)
            End Set
        End Property

        Public Property BankAccountNo As String Implements ISupplierView.BankAccountNo
            Get
                Return txtBankAccountNo.Text
            End Get
            Set
                txtBankAccountNo.Text = Value
            End Set
        End Property

        Public Property BankIdNo As Int16? Implements ISupplierView.BankIdNo
            Get
                Return cacBankIdNo.GetNullableValue(Of Int16)
            End Get
            Set
                cacBankIdNo.SetValue(Value)
            End Set
        End Property

        Public Property ContactDesignation As String Implements ISupplierView.ContactDesignation
            Get
                Return txtContactDesignation.Text
            End Get
            Set
                txtContactDesignation.Text = Value
            End Set
        End Property

        Public Property ContactPerson As String Implements ISupplierView.ContactPerson
            Get
                Return txtContactPerson.Text
            End Get
            Set
                txtContactPerson.Text = Value
            End Set
        End Property

        Public Property CountryCode As String Implements ISupplierView.CountryCode
            Get
                Return cacCountryCode.GetValue()
            End Get
            Set
                cacCountryCode.SetValue(Value)
            End Set
        End Property

        Public Property CreditLimit As Decimal Implements ISupplierView.CreditLimit
            Get
                Return txtCreditLimit.Text.ToDecimalNumber(_nfi)
            End Get
            Set
                txtCreditLimit.Text = Value.ToString("N", _nfi)
            End Set
        End Property

        Public Property CrNumber As String Implements ISupplierView.CrNumber
            Get
                Return txtCrNumber.Text
            End Get
            Set
                txtCrNumber.Text = Value
            End Set
        End Property

        Public Property DateAccountOpen As Date? Implements ISupplierView.DateAccountOpen
            Get
                Return dtpDateAccountOpen.Value
            End Get
            Set
                dtpDateAccountOpen.Value = Value
            End Set
        End Property

        Public Property District As String Implements ISupplierView.District
            Get
                Return txtDistrict.Text
            End Get
            Set
                txtDistrict.Text = Value
            End Set
        End Property

        Public Property Email As String Implements ISupplierView.Email
            Get
                Return txtEmail.Text
            End Get
            Set
                txtEmail.Text = Value
            End Set
        End Property

        Public Property ExpAccountIdNo As Int16? Implements ISupplierView.ExpAccountIdNo
            Get
                Return cacExpAccountIdNo.GetNullableValue(Of Int16)
            End Get
            Set
                cacExpAccountIdNo.SetValue(Value)
            End Set
        End Property

        Public Property Fax As String Implements ISupplierView.Fax
            Get
                Return txtFax.Text
            End Get
            Set
                txtFax.Text = Value
            End Set
        End Property

        Public Property Iban As String Implements ISupplierView.Iban
            Get
                Return txtIban.Text
            End Get
            Set
                txtIban.Text = Value
            End Set
        End Property

        Public Property IdNo As Int32 Implements ISupplierView.IdNo
            Get
                If TxtIdNo.Text <> "" Then
                    Return Convert.ToInt16(TxtIdNo.Text)
                Else
                    Return 0
                End If
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property Mobile As String Implements ISupplierView.Mobile
            Get
                Return txtMobile.Text
            End Get
            Set
                txtMobile.Text = Value
            End Set
        End Property

        Public Property Notes As String Implements ISupplierView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = Value
            End Set
        End Property

        'Public Property Active As Boolean Implements ISupplierView.Active
        '    Get
        '        Return GetEnumCode(tcbActive.Text)
        '    End Get
        '    Set(value As Boolean)
        '        tcbActive.Text = GetEnumCode(value)
        '    End Set
        'End Property
        Public Property OpeningBalance As Decimal Implements ISupplierView.OpeningBalance
            Get
                Return txtOpeningBalance.Text.ToDecimalNumber(_nfi)
            End Get
            Set
                txtOpeningBalance.Text = Value.ToString("N", _nfi)
            End Set
        End Property

        Public Property PaymentDueDays As Int16 Implements ISupplierView.PaymentDueDays
            Get
                Return txtPaymentDueDays.Text.ToInt16Number()
            End Get
            Set
                txtPaymentDueDays.Text = Value
            End Set
        End Property

        Public Property PaymentMethod As String Implements ISupplierView.PaymentMethod
            Get
                Return cacPaymentMethod.GetValue()
            End Get
            Set
                cacPaymentMethod.SetValue(Value)
            End Set
        End Property

        Public Property Phone1 As String Implements ISupplierView.Phone1
            Get
                Return txtPhone1.Text
            End Get
            Set
                txtPhone1.Text = Value
            End Set
        End Property

        Public Property Phone2 As String Implements ISupplierView.Phone2
            Get
                Return txtPhone2.Text
            End Get
            Set
                txtPhone2.Text = Value
            End Set
        End Property

        Public Property PoBox As String Implements ISupplierView.PoBox
            Get
                Return txtPoBox.Text
            End Get
            Set
                txtPoBox.Text = Value
            End Set
        End Property

        Public Property ProvinceState As String Implements ISupplierView.ProvinceState
            Get
                Return txtProvinceState.Text
            End Get
            Set
                txtProvinceState.Text = Value
            End Set
        End Property

        Public Property SettlementDiscount As Decimal Implements ISupplierView.SettlementDiscount
            Get
                Return txtSettlementDiscount.Text.ToDecimalNumber(_nfi)
            End Get
            Set
                txtSettlementDiscount.Text = Value.ToString("N", _nfi)
            End Set
        End Property

        Public Property SettlementDueDays As Int16 Implements ISupplierView.SettlementDueDays
            Get
                Return txtSettlementDueDays.Text.ToInt16Number()
            End Get
            Set
                txtSettlementDueDays.Text = Value
            End Set
        End Property

        Public Property Street As String Implements ISupplierView.Street
            Get
                Return txtStreet.Text
            End Get
            Set
                txtStreet.Text = Value
            End Set
        End Property

        Public Property SupplierCode As String Implements ISupplierView.SupplierCode
            Get
                Return txtSupplierCode.Text
            End Get
            Set
                txtSupplierCode.Text = Value
            End Set
        End Property

        Public Property SupplierName As String Implements ISupplierView.SupplierName
            Get
                Return txtSupplierName.Text
            End Get
            Set
                txtSupplierName.Text = Value
            End Set
        End Property

        Public Property SupplierNameAra As String Implements ISupplierView.SupplierNameAra
            Get
                Return txtSupplierNameAra.Text
            End Get
            Set
                txtSupplierNameAra.Text = Value
            End Set
        End Property

        Public Property TownCity As String Implements ISupplierView.TownCity
            Get
                Return txtTownCity.Text
            End Get
            Set
                txtTownCity.Text = Value
            End Set
        End Property

        Public Property VatNumber As String Implements ISupplierView.VatNumber
            Get
                Return txtVatNumber.Text
            End Get
            Set
                txtVatNumber.Text = Value
            End Set
        End Property

        Public Property Website As String Implements ISupplierView.Website
            Get
                Return txtWebsite.Text
            End Get
            Set
                txtWebsite.Text = Value
            End Set
        End Property

        Public Property ZipCode As String Implements ISupplierView.ZipCode
            Get
                Return txtZipCode.Text
            End Get
            Set
                txtZipCode.Text = Value
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateDataSources()
            cacCountryCode.DataSource = PresenterObj.GetLookup("Country")
            cacBankIdNo.DataSource = PresenterObj.GetLookup("Bank")
            cacApAccountIdNo.DataSource = PresenterObj.GetAccountList()
            cacExpAccountIdNo.DataSource = PresenterObj.GetAccountList()
            cacAccountStatus.DataSource = PresenterObj.MakeEnumComboList(Of AccountStatusSelection)
            cacPaymentMethod.DataSource = PresenterObj.MakeEnumComboList(Of PaymentMethodSelection)
        End Sub

        Protected Overrides Sub CreateFieldsDictionary()
            FieldsDictionary = New Dictionary(Of String, Object) From
                {
                 {"AccountStatus", cacAccountStatus},
                 {"Active", chkActive},
                 {"ApAccountIdNo", cacApAccountIdNo},
                 {"BankAccountNo", txtBankAccountNo},
                 {"BankIdNo", cacBankIdNo},
                 {"ContactDesignation", txtContactDesignation},
                 {"ContactPerson", txtContactPerson},
                 {"CountryCode", cacCountryCode},
                 {"CreditLimit", txtCreditLimit},
                 {"CrNumber", txtCrNumber},
                 {"DateAccountOpen", dtpDateAccountOpen},
                 {"District", txtDistrict},
                 {"Email", txtEmail},
                 {"ExpAccountIdNo", cacExpAccountIdNo},
                 {"Fax", txtFax},
                 {"Iban", txtIban},
                 {"IdNo", TxtIdNo},
                 {"Mobile", txtMobile},
                 {"Notes", txtNotes},
                 {"OpeningBalance", txtOpeningBalance},
                 {"PaymentDueDays", txtPaymentDueDays},
                 {"PaymentMethod", cacPaymentMethod},
                 {"Phone1", txtPhone1},
                 {"Phone2", txtPhone2},
                 {"PoBox", txtPoBox},
                 {"ProvinceState", txtProvinceState},
                 {"SettlementDiscount", txtSettlementDiscount},
                 {"SettlementDueDays", txtSettlementDueDays},
                 {"Street", txtStreet},
                 {"SupplierCode", txtSupplierCode},
                 {"SupplierName", txtSupplierName},
                 {"SupplierNameAra", txtSupplierNameAra},
                 {"TownCity", txtTownCity},
                 {"VatNumber", txtVatNumber},
                 {"Website", txtWebsite},
                 {"ZipCode", txtZipCode}
                }
        End Sub

        Protected Overrides Sub RecordPositionChanged(ByRef e As RecordPositionChanged)
            Dim value As Double
            value = Convert.ToDouble(PresenterObj.GetSupplierBalance(IdNo))
            txtBalance.Text = value.ToString("N", _nfi)
        End Sub

    End Class

End Namespace