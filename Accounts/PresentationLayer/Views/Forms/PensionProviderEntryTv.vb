Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Views.Forms

    Public Class PensionProviderEntryTv
        Implements IPensionProviderView

        Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat

        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            _nfi.NumberDecimalDigits = 2
            MainTableName = "PensionProvider"
            TvMainFieldName = "PensionProviderName"
            TvSecondaryFieldName = "PensionProviderCode"
            SortOrderKey = "PensionProviderName"
            FirstControl = txtPensionProviderCode
            ' Add any initialization after the InitializeComponent() call.
            PresenterObj = New PensionProviderPresenter(Me)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)
        End Sub

#Region "Fields"

        Public Property Active As Boolean Implements IPensionProviderView.Active
            Get
                Return chkActive.Checked
            End Get
            Set
                chkActive.Checked = Value
            End Set
        End Property

        Public Property BankAccountNo As String Implements IPensionProviderView.BankAccountNo
            Get
                Return txtBankAccountNo.Text
            End Get
            Set
                txtBankAccountNo.Text = Value
            End Set
        End Property

        Public Property BankIdNo As Int16? Implements IPensionProviderView.BankIdNo
            Get
                Return cacBankIdNo.GetNullableValue(Of Int16)
            End Get
            Set
                cacBankIdNo.SetValue(Value)
            End Set
        End Property

        Public Property ContactDesignation As String Implements IPensionProviderView.ContactDesignation
            Get
                Return txtContactDesignation.Text
            End Get
            Set
                txtContactDesignation.Text = Value
            End Set
        End Property

        Public Property ContactPerson As String Implements IPensionProviderView.ContactPerson
            Get
                Return txtContactPerson.Text
            End Get
            Set
                txtContactPerson.Text = Value
            End Set
        End Property

        Public Property CountryCode As String Implements IPensionProviderView.CountryCode
            Get
                Return cacCountryCode.GetValue()
            End Get
            Set
                cacCountryCode.SetValue(Value)
            End Set
        End Property

        Public Property District As String Implements IPensionProviderView.District
            Get
                Return txtDistrict.Text
            End Get
            Set
                txtDistrict.Text = Value
            End Set
        End Property

        Public Property Email As String Implements IPensionProviderView.Email
            Get
                Return txtEmail.Text
            End Get
            Set
                txtEmail.Text = Value
            End Set
        End Property

        Public Property Fax As String Implements IPensionProviderView.Fax
            Get
                Return txtFax.Text
            End Get
            Set
                txtFax.Text = Value
            End Set
        End Property

        Public Property Iban As String Implements IPensionProviderView.Iban
            Get
                Return txtIban.Text
            End Get
            Set
                txtIban.Text = Value
            End Set
        End Property

        Public Property IdNo As Int32 Implements IPensionProviderView.IdNo
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

        Public Property Mobile As String Implements IPensionProviderView.Mobile
            Get
                Return txtMobile.Text
            End Get
            Set
                txtMobile.Text = Value
            End Set
        End Property

        Public Property Notes As String Implements IPensionProviderView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = Value
            End Set
        End Property

        Public Property PaymentMethod As String Implements IPensionProviderView.PaymentMethod
            Get
                Return cacPaymentMethod.GetValue()
            End Get
            Set
                cacPaymentMethod.SetValue(Value)
            End Set
        End Property

        Public Property Phone1 As String Implements IPensionProviderView.Phone1
            Get
                Return txtPhone1.Text
            End Get
            Set
                txtPhone1.Text = Value
            End Set
        End Property

        Public Property Phone2 As String Implements IPensionProviderView.Phone2
            Get
                Return txtPhone2.Text
            End Get
            Set
                txtPhone2.Text = Value
            End Set
        End Property

        Public Property PoBox As String Implements IPensionProviderView.PoBox
            Get
                Return txtPoBox.Text
            End Get
            Set
                txtPoBox.Text = Value
            End Set
        End Property

        Public Property ProvinceState As String Implements IPensionProviderView.ProvinceState
            Get
                Return txtProvinceState.Text
            End Get
            Set
                txtProvinceState.Text = Value
            End Set
        End Property

        Public Property Street As String Implements IPensionProviderView.Street
            Get
                Return txtStreet.Text
            End Get
            Set
                txtStreet.Text = Value
            End Set
        End Property

        Public Property PensionProviderCode As String Implements IPensionProviderView.PensionProviderCode
            Get
                Return txtPensionProviderCode.Text
            End Get
            Set
                txtPensionProviderCode.Text = Value
            End Set
        End Property

        Public Property PensionProviderName As String Implements IPensionProviderView.PensionProviderName
            Get
                Return txtPensionProviderName.Text
            End Get
            Set
                txtPensionProviderName.Text = Value
            End Set
        End Property

        Public Property PensionProviderNameAra As String Implements IPensionProviderView.PensionProviderNameAra
            Get
                Return txtPensionProviderNameAra.Text
            End Get
            Set
                txtPensionProviderNameAra.Text = Value
            End Set
        End Property

        Public Property TownCity As String Implements IPensionProviderView.TownCity
            Get
                Return txtTownCity.Text
            End Get
            Set
                txtTownCity.Text = Value
            End Set
        End Property

        Public Property Website As String Implements IPensionProviderView.Website
            Get
                Return txtWebsite.Text
            End Get
            Set
                txtWebsite.Text = Value
            End Set
        End Property

        Public Property ZipCode As String Implements IPensionProviderView.ZipCode
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
            cacPaymentMethod.DataSource = PresenterObj.MakeEnumComboList(Of PaymentMethodSelection)
        End Sub

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                 {"Active", chkActive},
                 {"BankAccountNo", txtBankAccountNo},
                 {"BankIdNo", cacBankIdNo},
                 {"ContactDesignation", txtContactDesignation},
                 {"ContactPerson", txtContactPerson},
                 {"CountryCode", cacCountryCode},
                 {"District", txtDistrict},
                 {"Email", txtEmail},
                 {"Fax", txtFax},
                 {"Iban", txtIban},
                 {"IdNo", TxtIdNo},
                 {"Mobile", txtMobile},
                 {"Notes", txtNotes},
                 {"PaymentMethod", cacPaymentMethod},
                 {"Phone1", txtPhone1},
                 {"Phone2", txtPhone2},
                 {"PoBox", txtPoBox},
                 {"ProvinceState", txtProvinceState},
                 {"Street", txtStreet},
                 {"PensionProviderCode", txtPensionProviderCode},
                 {"PensionProviderName", txtPensionProviderName},
                 {"PensionProviderNameAra", txtPensionProviderNameAra},
                 {"TownCity", txtTownCity},
                 {"Website", txtWebsite},
                 {"ZipCode", txtZipCode}
                }
        End Sub

    End Class

End Namespace