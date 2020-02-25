Imports System.ComponentModel
Imports System.Resources
Imports System.Windows.Forms
Imports AATM.HIS.Accounts.PresentationLayer.Presenters
Imports AATM.HIS.Accounts.PresentationLayer.Views
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Forms

    Public Class CustomerEntryTv
        Implements ICustomerView

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()

            MainTableName = "Customer"
            IdFieldName = "IdNo"
            TvMainFieldName = "CustomerName"
            TvSecondaryFieldName = "CustomerCode"
            SortOrderKey = "CustomerName"
            FirstControl = txtCustomerCode
            ' Add any initialization after the InitializeComponent() call.
            PresenterObj = New CustomerPresenter(Me)

            AddHandler MyBase.TextDisplayLanguageChanged, AddressOf OnTextDisplayLanguageChanged
            'Assign comboboxes datasources
            CreateDataSources()
            'CreateEnumResourceFile()

            'ResourceEnumConverter.MakeResource("DepartmentTypeSelection", GetType(DepartmentTypeSelection))

        End Sub

        Public Sub CreateEnumResourceFile()
            'ResourceEnumConverter.MakeResource("YesNoSelection", GetType(YesNoSelection))
            'ResourceEnumConverter.MakeResource("DepartmentTypeSelection", GetType(DepartmentTypeSelection))
            'ResourceEnumConverter.MakeResource("ImageTypeSelection", GetType(ImageTypeSelection))
        End Sub

        Protected Overrides Sub CreateDataSources()
            cacCountryCode.DataSource = PresenterObj.GetCountryList()
            cacBankIdNo.DataSource = PresenterObj.GetBankList()
            cacArAccountIdNo.DataSource = PresenterObj.GetChartList()
            cacRevAccountIdNo.DataSource = PresenterObj.GetChartList()
            cacPaymentMethod.DataSource = PresenterObj.MakeEnumComboList(Of PaymentMethodSelection)
            cacAccountStatus.DataSource = PresenterObj.MakeEnumComboList(Of AccountStatusSelection)
        End Sub

        Private Shadows Sub OnTextDisplayLanguageChanged()
            CreateDataSources()
        End Sub

#Region "Field Displays"

        Public Property IDNo As Integer Implements ICustomerView.IdNo
            Get
                If TxtIDNo.Text <> "" Then
                    Return Convert.ToInt16(TxtIDNo.Text)
                Else
                    Return 0
                End If
            End Get
            Set
                TxtIDNo.Text = Convert.ToString(Value)
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

        Public Property BankIdNo As Int16 Implements ICustomerView.BankIdNo
            Get
                Return cacBankIdNo.GetValue()
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

        Public Property ArAccountIdNo As Int32 Implements ICustomerView.ArAccountIdNo
            Get
                Return cacArAccountIdNo.GetValue()
            End Get
            Set
                cacArAccountIdNo.SetValue(Value)
            End Set
        End Property

        Public Property RevAccountIdNo As Int32 Implements ICustomerView.RevAccountIdNo
            Get
                Return cacRevAccountIdNo.GetValue()
            End Get
            Set
                cacRevAccountIdNo.SetValue(Value)
            End Set
        End Property

        Public Property DiscountSchemeIdNo As Int16 Implements ICustomerView.DiscountSchemeIdNo
            Get
                Return cacDiscountSchemeIdNo.GetValue()
            End Get
            Set
                cacDiscountSchemeIdNo.SetValue(Value)
            End Set
        End Property

        Public Property CreditLimit As Single Implements ICustomerView.CreditLimit
            Get
                If txtCreditLimit.Text <> "" Then
                    Return Convert.ToSingle(txtCreditLimit.Text)
                Else
                    Return 0
                End If
            End Get
            Set
                txtCreditLimit.Text = Value
            End Set
        End Property

        Public Property SettlementDueDays As Int16 Implements ICustomerView.SettlementDueDays
            Get
                If txtSettlementDueDays.Text <> "" Then
                    Return Convert.ToInt16(txtSettlementDueDays.Text)
                Else
                    Return 0
                End If
            End Get
            Set
                txtSettlementDueDays.Text = Value
            End Set
        End Property

        Public Property SettlementDiscount As Decimal Implements ICustomerView.SettlementDiscount
            Get
                If txtSettlementDiscount.Text <> "" Then
                    Return Convert.ToDecimal(txtSettlementDiscount.Text)
                Else
                    Return 0
                End If
            End Get
            Set
                txtSettlementDiscount.Text = Value
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

        'Public Property Active As Boolean Implements ICustomerView.Active
        '    Get
        '        Return EnumToYesNo(tcbActive.Text)
        '    End Get
        '    Set(value As Boolean)
        '        tcbActive.Text = YesNoToEnum(value)
        '    End Set
        'End Property

        Public Property Notes As String Implements ICustomerView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = Value
            End Set
        End Property

        Public Property OpeningBalance As Single Implements ICustomerView.OpeningBalance
            Get
                If txtOpeningBalance.Text <> "" Then
                    Return Convert.ToSingle(txtOpeningBalance.Text)
                Else
                    Return 0
                End If
            End Get
            Set
                txtOpeningBalance.Text = Value
            End Set
        End Property

        Public Property PaymentDueDays As Int16 Implements ICustomerView.PaymentDueDays
            Get
                If txtPaymentDueDays.Text <> "" Then
                    Return Convert.ToInt16(txtPaymentDueDays.Text)
                Else
                    Return 0
                End If
            End Get
            Set
                txtPaymentDueDays.Text = Value
            End Set
        End Property

#End Region

        Protected Overrides Sub AddMandatoryFieldCheck()
            'Add controls one by one in error provider.
            MyErrorProvider.Controls.AddMandatory(txtCustomerCode, "Customer Code")
            MyErrorProvider.Controls.AddMandatory(txtCustomerName, "Customer Name")
            'Set summary error message
            MyErrorProvider.SummaryMessage = "Following fields are mandatory,"
        End Sub

        Private Sub lblContactDesignation_Click(sender As Object, e As EventArgs) Handles lblContactDesignation.Click
            ' Create a resource writer.
            ' just a test program nothing to do with this program
            ' this is just a test on how to access the Resources file using ResourceWriter.
            Dim componentResourceManager As New ComponentResourceManager(Me.GetType)
            Dim rw As IResourceWriter
            rw = New ResourceWriter("CustomerEntryTv.resources")
            ' Add resources to the file.
            rw.AddResource("lblContactDesignation.Text", "ChangedValue")
            MessageBox.Show("changed resource value to changedValue")
            rw.Generate()
            ' Close the ResourceWriter.
            rw.Close()
            Dim res As New ResourceReader("CustomerEntryTv.resources")
            Dim dict As IDictionaryEnumerator = res.GetEnumerator()
            Do While dict.MoveNext()
                MessageBox.Show(dict.Key.ToString() + dict.Value.ToString() + dict.Value.GetType().Name.ToString())
            Loop
            res.Close()
        End Sub

        Public Property Errors As List(Of String) Implements IView.Errors
    End Class

End Namespace