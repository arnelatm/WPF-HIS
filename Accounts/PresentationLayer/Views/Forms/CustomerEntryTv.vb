Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class CustomerEntryTv
        Implements ICustomerView ', ISubscriber(Of AddModeChanged)

        Private ReadOnly _nfi As NumberFormatInfo

        Public Sub New()
            'MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = txtCustomerName
            ' Add any initialization after the InitializeComponent() call.

        End Sub

#Region "Field Displays"

        Public Property IdNo As Int32 Implements ICustomerView.IdNo
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

        Public Property CustomerCode As String Implements ICustomerView.CustomerCode
            Get
                Return txtCustomerCode.Text
            End Get
            Set
                txtCustomerCode.Text = Value
            End Set
        End Property

        Public Property CustomerName As String Implements ICustomerView.CustomerName
            Get
                Return txtCustomerName.Text
            End Get
            Set
                txtCustomerName.Text = Value
            End Set
        End Property

        Public Property CustomerNameAra As String Implements ICustomerView.CustomerNameAra
            Get
                Return txtCustomerNameAra.Text
            End Get
            Set
                txtCustomerNameAra.Text = Value
            End Set
        End Property

        Public Property ContactPerson As String Implements ICustomerView.ContactPerson
            Get
                Return txtContactPerson.Text
            End Get
            Set
                txtContactPerson.Text = Value
            End Set
        End Property

        Public Property ContactDesignation As String Implements ICustomerView.ContactDesignation
            Get
                Return txtContactDesignation.Text
            End Get
            Set
                txtContactDesignation.Text = Value
            End Set
        End Property

        Public Property Street As String Implements ICustomerView.Street
            Get
                Return txtStreet.Text
            End Get
            Set
                txtStreet.Text = Value
            End Set
        End Property

        Public Property District As String Implements ICustomerView.District
            Get
                Return txtDistrict.Text
            End Get
            Set
                txtDistrict.Text = Value
            End Set
        End Property

        Public Property TownCity As String Implements ICustomerView.TownCity
            Get
                Return txtTownCity.Text
            End Get
            Set
                txtTownCity.Text = Value
            End Set
        End Property

        Public Property ProvinceState As String Implements ICustomerView.ProvinceState
            Get
                Return txtProvinceState.Text
            End Get
            Set
                txtProvinceState.Text = Value
            End Set
        End Property

        Public Property CountryCode As String Implements ICustomerView.CountryCode
            Get
                Return cacCountryCode.GetValue()
            End Get
            Set
                cacCountryCode.SetValue(Value)
            End Set
        End Property

        Public Property BankIdNo As Int16? Implements ICustomerView.BankIdNo
            Get
                Return cacBankIdNo.GetNullableValue(Of Int16)
            End Get
            Set
                cacBankIdNo.SetValue(Value)
            End Set
        End Property

        Public Property PoBox As String Implements ICustomerView.PoBox
            Get
                Return txtPoBox.Text
            End Get
            Set
                txtPoBox.Text = Value
            End Set
        End Property

        Public Property ZipCode As String Implements ICustomerView.ZipCode
            Get
                Return txtZipCode.Text
            End Get
            Set
                txtZipCode.Text = Value
            End Set
        End Property

        Public Property Phone1 As String Implements ICustomerView.Phone1
            Get
                Return txtPhone1.Text
            End Get
            Set
                txtPhone1.Text = Value
            End Set
        End Property

        Public Property Phone2 As String Implements ICustomerView.Phone2
            Get
                Return txtPhone2.Text
            End Get
            Set
                txtPhone2.Text = Value
            End Set
        End Property

        Public Property Mobile As String Implements ICustomerView.Mobile
            Get
                Return txtMobile.Text
            End Get
            Set
                txtMobile.Text = Value
            End Set
        End Property

        Public Property Fax As String Implements ICustomerView.Fax
            Get
                Return txtFax.Text
            End Get
            Set
                txtFax.Text = Value
            End Set
        End Property

        Public Property Email As String Implements ICustomerView.Email
            Get
                Return txtEmail.Text
            End Get
            Set
                txtEmail.Text = Value
            End Set
        End Property

        Public Property Website As String Implements ICustomerView.Website
            Get
                Return txtWebsite.Text
            End Get
            Set
                txtWebsite.Text = Value
            End Set
        End Property

        Public Property VatNumber As String Implements ICustomerView.VatNumber
            Get
                Return txtVatNumber.Text
            End Get
            Set
                txtVatNumber.Text = Value
            End Set
        End Property

        Public Property CrNumber As String Implements ICustomerView.CrNumber
            Get
                Return txtCrNumber.Text
            End Get
            Set
                txtCrNumber.Text = Value
            End Set
        End Property

        Public Property ArAccountIdNo As Int16? Implements ICustomerView.ArAccountIdNo
            Get
                Return cacArAccountIdNo.GetNullableValue(Of Int16)
            End Get
            Set
                cacArAccountIdNo.SetValue(Value)
            End Set
        End Property

        Public Property RevAccountIdNo As Int16? Implements ICustomerView.RevAccountIdNo
            Get
                Return cacRevAccountIdNo.GetNullableValue(Of Int16)
            End Get
            Set
                cacRevAccountIdNo.SetValue(Value)
            End Set
        End Property

        Public Property DiscountSchemeIdNo As Int16? Implements ICustomerView.DiscountSchemeIdNo
            Get
                Return cacDiscountSchemeIdNo.GetNullableValue(Of Int16)
            End Get
            Set
                cacDiscountSchemeIdNo.SetValue(Value)
            End Set
        End Property

        Public Property CreditLimit As Decimal Implements ICustomerView.CreditLimit
            Get
                Return NumParser(Of Decimal)(txtCreditLimit.Text)
            End Get
            Set
                txtCreditLimit.Text = FormatDecimalNumber(Value)
            End Set
        End Property

        Public Property SettlementDueDays As Int16 Implements ICustomerView.SettlementDueDays
            Get
                Return txtSettlementDueDays.Text.ToInt16Number()
            End Get
            Set
                txtSettlementDueDays.Text = Value
            End Set
        End Property

        Public Property SettlementDiscount As Decimal Implements ICustomerView.SettlementDiscount
            Get
                Return NumParser(Of Decimal)(txtSettlementDiscount.Text)
            End Get
            Set
                txtSettlementDiscount.Text = FormatDecimalNumber(Value)
            End Set
        End Property

        Public Property DateAccountOpen As Date? Implements ICustomerView.DateAccountOpen
            Get
                Return dtpDateAccountOpen.Value
            End Get
            Set
                dtpDateAccountOpen.Value = Value
            End Set
        End Property

        Public Property BankAccountNo As String Implements ICustomerView.BankAccountNo
            Get
                Return txtBankAccountNo.Text
            End Get
            Set
                txtBankAccountNo.Text = Value
            End Set
        End Property

        Public Property Iban As String Implements ICustomerView.Iban
            Get
                Return txtIban.Text
            End Get
            Set
                txtIban.Text = Value
            End Set
        End Property

        Public Property PaymentMethod As String Implements ICustomerView.PaymentMethod
            Get
                Return cacPaymentMethod.GetValue()
            End Get
            Set
                cacPaymentMethod.SetValue(Value)
            End Set
        End Property

        Public Property AccountStatus As String Implements ICustomerView.AccountStatus
            Get
                Return cacAccountStatus.GetValue()
            End Get
            Set
                cacAccountStatus.SetValue(Value)
            End Set
        End Property

        Public Property Active As Boolean Implements ICustomerView.Active
            Get
                Return chkActive.Checked
            End Get
            Set
                chkActive.Checked = Value
            End Set
        End Property

        Public Property Notes As String Implements ICustomerView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = Value
            End Set
        End Property

        Public Property OpeningBalance As Decimal Implements ICustomerView.OpeningBalance
            Get
                Return NumParser(Of Decimal)(txtOpeningBalance.Text)
            End Get
            Set
                txtOpeningBalance.Text = FormatDecimalNumber(Value)
            End Set
        End Property

        Public Property Balance As Decimal Implements ICustomerView.Balance
            Get
                Return NumParser(Of Decimal)(txtBalance.Text)
            End Get
            Set
                txtBalance.Text = FormatDecimalNumber(Value)
            End Set
        End Property

        Public Property PaymentDueDays As Int16 Implements ICustomerView.PaymentDueDays
            Get
                Return txtPaymentDueDays.Text.ToInt16Number()
            End Get
            Set
                txtPaymentDueDays.Text = Value
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateDataSources()
            CreateEnumDataSource(Of PaymentMethodSelection)(cacPaymentMethod)
            CreateEnumDataSource(Of AccountStatusSelection)(cacAccountStatus)
            CreateDataSource("Country", cacCountryCode)
            CreateDataSource("Bank", cacBankIdNo)
            CreateDataSource("DiscountScheme", cacDiscountSchemeIdNo)
            CreateSpecialAccountDataSource(Ea, {EnumToCode(SpecialAccountSelection.AccountsReceivable)}, cacArAccountIdNo)
            CreateDataSource("Account", cacRevAccountIdNo, "DetailAccount=1")
        End Sub

        'Private Sub CreateArDataSource()
        '    Dim commaDelimitedSpecialAccountCodes As String = EnumToCode(SpecialAccountSelection.AccountsReceivable)
        '    Dim lookupFilterKey = CreateSpecialAccountFilterKey(commaDelimitedSpecialAccountCodes)
        '    CreateDataSource("Account", cacArAccountIdNo, lookupFilterKey)
        'End Sub

        'Public Function CreateSpecialAccountFilterKey(specialAccountArray As List(Of SpecialAccountSelection)) As String
        '    Dim lookUpFilterKey = ""
        '    For Each specialAccountCode In specialAccountArray
        '        If lookUpFilterKey <> "" Then
        '            lookUpFilterKey = lookUpFilterKey + " Or "
        '        End If
        '        lookUpFilterKey = lookUpFilterKey + "SpecialAccount = '" & EnumToCode(SpecialAccountSelection.AccountsReceivable) & "'"
        '    Next
        '    Return lookUpFilterKey
        'End Function

        'Public Function CreateSpecialAccountFilterKey(commaDelimitedSpecialAccountCodes As String) As String
        '    Dim specialAccountArray = commaDelimitedSpecialAccountCodes.Split(",")
        '    Dim lookUpFilterKey = ""
        '    For Each specialAccountCode In specialAccountArray
        '        If lookUpFilterKey <> "" Then
        '            lookUpFilterKey = lookUpFilterKey + " Or "
        '        End If
        '        lookUpFilterKey = lookUpFilterKey + "SpecialAccount = '" & specialAccountCode & "'"
        '    Next
        '    Return lookUpFilterKey
        'End Function

        'Private Sub lblContactDesignation_Click(sender As Object, e As EventArgs) Handles lblContactDesignation.Click
        '    ' Create a resource writer.
        '    ' just a test program nothing to do with this program
        '    ' this is just a test on how to access the Resources file using ResourceWriter.
        '    Dim componentResourceManager As New ComponentResourceManager(Me.GetType)
        '    Dim rw As IResourceWriter
        '    rw = New ResourceWriter("CustomerEntryTv.resources")
        '    ' Add resources to the file.
        '    rw.AddResource("lblContactDesignation.Text", "ChangedValue")
        '    MessageBox.Show("changed resource value to changedValue")
        '    rw.Generate()
        '    ' Close the ResourceWriter.
        '    rw.Close()
        '    Dim res As New ResourceReader("CustomerEntryTv.resources")
        '    Dim dict As IDictionaryEnumerator = res.GetEnumerator()
        '    Do While dict.MoveNext()
        '        MessageBox.Show(dict.Key.ToString() + dict.Value.ToString() + dict.Value.GetType().Name.ToString())
        '    Loop
        '    res.Close()
        'End Sub

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {{"IdNo", TxtIdNo},
                {"CustomerCode", txtCustomerCode},
                {"CustomerName", txtCustomerName},
                {"CustomerNameAra", txtCustomerNameAra},
                {"ContactPerson", txtContactPerson},
                {"ContactDesignation", txtContactDesignation},
                {"Street", txtStreet},
                {"District", txtDistrict},
                {"TownCity", txtTownCity},
                {"ProvinceState", txtProvinceState},
                {"CountryCode", cacCountryCode},
                {"PoBox", txtPoBox},
                {"ZipCode", txtZipCode},
                {"Phone1", txtPhone1},
                {"Phone2", txtPhone2},
                {"Mobile", txtMobile},
                {"Fax", txtFax},
                {"Email", txtEmail},
                {"Website", txtWebsite},
                {"VatNumber", txtVatNumber},
                {"CrNumber", txtCrNumber},
                {"AccountStatus", cacAccountStatus},
                {"ArAccountIdNo", cacArAccountIdNo},
                {"RevAccountIdNo", cacRevAccountIdNo},
                {"CreditLimit", txtCreditLimit},
                {"SettlementDueDays", txtSettlementDueDays},
                {"SettlementDiscount", txtSettlementDiscount},
                {"PaymentDueDays", txtPaymentDueDays},
                {"DateAccountOpen", dtpDateAccountOpen},
                {"BankIdNo", cacBankIdNo},
                {"BankAccountNo", txtBankAccountNo},
                {"Iban", txtIban},
                {"PaymentMethod", cacPaymentMethod},
                {"Notes", txtNotes},
                {"OpeningBalance", txtOpeningBalance},
                {"DiscountSchemeIdNo", cacDiscountSchemeIdNo},
                {"Active", chkActive}
                }
        End Sub

        'Protected Overrides Sub RecordPositionChanged(ByRef e As RecordPositionChanged)
        '    MyBase.RecordPositionChanged(e)
        '    Dim value As Double
        '    value = Convert.ToDouble(Presenter.GetCustomerBalance(IdNo))
        '    txtBalance.Text = value.ToString("N", _nfi)
        '    If Not Presenter.AddMode Then
        '        txtOpeningBalance.DisplayOnly = True
        '    Else
        '        txtOpeningBalance.DisplayOnly = False
        '    End If
        'End Sub

        'Public Sub OnAcReconAddModeChanged(ByRef e As AddModeChanged) Implements ISubscriber(Of AddModeChanged).OnEventHandler
        '    MyBase.OnEventHandlerAddModeChanged(e)
        '    If e.AddMode Then
        '        txtOpeningBalance.DisplayOnly = False
        '    Else
        '        txtOpeningBalance.DisplayOnly = True
        '    End If
        'End Sub

    End Class

End Namespace