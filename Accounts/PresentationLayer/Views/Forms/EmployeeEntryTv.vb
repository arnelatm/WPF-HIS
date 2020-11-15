Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Common
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Views.Forms

    Public Class EmployeeEntryTv
        Implements IEmployeeView

        Private _countryTelCodes
        Private _deductionsByName
        Private _earningsByName
        Private _regularEmployeeDeductions As List(Of EmployeeDeductionView)
        Private _regularEmployeeEarnings As List(Of EmployeeEarningView)
        Private _employeePhones As List(Of EmployeePhoneView)
        Private _phoneTypes

        Private ReadOnly _nfi As NumberFormatInfo

        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            MainTableName = "Employee"
            TvMainFieldName = "EmployeeName"
            TvSecondaryFieldName = "EmployeeCode"
            SortOrderKey = "EmployeeName"
            FirstControl = txtEmployeeCode
            _nfi = GlobalVariables.DefaultNumberFormatInfo
            ' Add any initialization after the InitializeComponent() call.
            EmployeeTabControl.RightToLeftLayout = GlobalVariables.RightToLeftLayout
            EmployeeTabControl.RightToLeft = RightToLeft.Inherit
            PresenterObj = New EmployeePresenter(Me)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)
            'DataGridViewEarnings.Ea.SubscribeEvent(Me)
            'DataGridViewDeductions.Ea.SubscribeEvent(Me)
            DataGridViewEarnings.ShowFooter = True
            DataGridViewDeductions.ShowFooter = True

        End Sub

#Region "Fields"

        Public Property Active As Boolean Implements IEmployeeView.Active
            Get
                Return chkActive.Checked
            End Get
            Set
                chkActive.Checked = Value
            End Set
        End Property

        'Public Property Balance As Decimal Implements IEmployeeView.Balance
        '    Get
        '        If txtBalance.Text <> "" Then
        '            Return Convert.ToSingle(txtBalance.Text)
        '        Else
        '            Return 0
        '        End If
        '    End Get
        '    Set
        '        txtBalance.Text = Value
        '    End Set
        'End Property

        Public Property BankAccountNo As String Implements IEmployeeView.BankAccountNo
            Get
                Return txtBankAccountNo.Text
            End Get
            Set
                txtBankAccountNo.Text = Value
            End Set
        End Property

        Public Property BankIdNo As Int16? Implements IEmployeeView.BankIdNo
            Get
                Return cacBankIdNo.GetNullableValue(Of Int16)
            End Get
            Set
                cacBankIdNo.SetValue(Value)
            End Set
        End Property

        Public Property BirthDate As Date? Implements IEmployeeView.BirthDate
            Get
                Return dtpBirthDate.Value
            End Get
            Set
                'If Value Is Nothing Then
                '    dtpBirthDate.Value = Date.Now()
                'Else
                dtpBirthDate.Value = Value
                'End If
            End Set
        End Property

        Public Property CountryCode As String Implements IEmployeeView.CountryCode
            Get
                Return cacCountryCode.GetValue()
            End Get
            Set
                cacCountryCode.SetValue(Value)
            End Set
        End Property

        Public Property DepartmentIdNo As Int16? Implements IEmployeeView.DepartmentIdNo
            Get
                Return cacDepartmentIdNo.GetNullableValue(Of Int16)
            End Get
            Set
                cacDepartmentIdNo.SetValue(Value)
            End Set
        End Property

        Public Property DesignationIdNo As Int16? Implements IEmployeeView.DesignationIdNo
            Get
                Return cacDesignationIdNo.GetNullableValue(Of Int16)
            End Get
            Set
                cacDesignationIdNo.SetValue(Value)
            End Set
        End Property

        Public Property District As String Implements IEmployeeView.District
            Get
                Return txtDistrict.Text
            End Get
            Set
                txtDistrict.Text = Value
            End Set
        End Property

        Public Property Email As String Implements IEmployeeView.Email
            Get
                Return txtEmail.Text
            End Get
            Set
                txtEmail.Text = Value
            End Set
        End Property

        Public Property EmployeeCode As String Implements IEmployeeView.EmployeeCode
            Get
                Return txtEmployeeCode.Text
            End Get
            Set
                txtEmployeeCode.Text = Value
            End Set
        End Property

        Public Property RegularEmployeeDeductions As List(Of EmployeeDeductionView) Implements IEmployeeView.RegularEmployeeDeductions
            Get
                Return _regularEmployeeDeductions
            End Get
            Set
                _regularEmployeeDeductions = Value
                BindEmployeeDeduction()
            End Set
        End Property

        Public Property RegularEmployeeEarnings As List(Of EmployeeEarningView) Implements IEmployeeView.RegularEmployeeEarnings
            Get
                Return _regularEmployeeEarnings
            End Get
            Set
                _regularEmployeeEarnings = Value
                BindEmployeeEarning()
            End Set
        End Property

        Public Property EmployeePhones As List(Of EmployeePhoneView) Implements IEmployeeView.EmployeePhones
            Get
                Return _employeePhones
            End Get
            Set
                _employeePhones = Value
                BindEmployeePhone()
            End Set
        End Property

        Public Property EmployeeName As String Implements IEmployeeView.EmployeeName
            Get
                Return txtEmployeeName.Text
            End Get
            Set
                txtEmployeeName.Text = Value
            End Set
        End Property

        '    Get
        '        Return txtTitle.Text
        '    End Get
        '    Set
        '        txtTitle.Text = Value
        '    End Set
        'End Property
        Public Property EmployeeNameAra As String Implements IEmployeeView.EmployeeNameAra
            Get
                Return txtEmployeeNameAra.Text
            End Get
            Set
                txtEmployeeNameAra.Text = Value
            End Set
        End Property

        Public Property Gender As String Implements IEmployeeView.Gender
            Get
                Return cacGender.GetValue()
            End Get
            Set
                cacGender.SetValue(Value)
            End Set
        End Property

        Public Property HiredDate As Date? Implements IEmployeeView.HiredDate
            Get
                Return dtpHiredDate.Value
            End Get
            Set
                'If Value Is Nothing Then
                '    dtpBirthDate.Value = Date.Now()
                'Else
                dtpHiredDate.Value = Value
                'End If
            End Set
        End Property

        'Public Property BankIdNo As Int16 Implements IEmployeeView.BankIdNo
        '    Get
        '        If tcbBankIdNo.Text <> "" Then
        '            Return Convert.ToInt32(tcbBankIdNo.Text)
        '        Else
        '            Return 0
        '        End If
        '    End Get
        '    Set
        '        tcbBankIdNo.Text = Value
        '    End Set
        'End Property
        Public Property Iban As String Implements IEmployeeView.Iban
            Get
                Return txtIban.Text
            End Get
            Set
                txtIban.Text = Value
            End Set
        End Property

        Public Property IdNo As Int32 Implements IEmployeeView.IdNo
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

        Public Property MaritalStatus As String Implements IEmployeeView.MaritalStatus
            Get
                Return cacMaritalStatus.GetValue()
            End Get
            Set
                cacMaritalStatus.SetValue(Value)
            End Set
        End Property

        Public Property NationalIdNo As String Implements IEmployeeView.NationalIdNo
            Get
                Return txtNationalIdNo.Text
            End Get
            Set
                txtNationalIdNo.Text = Value
            End Set
        End Property

        Public Property NationalityCode As String Implements IEmployeeView.NationalityCode
            Get
                Return cacNationalityCode.GetValue()
            End Get
            Set
                cacNationalityCode.SetValue(Value)
            End Set
        End Property

        Public Property Notes As String Implements IEmployeeView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = Value
            End Set
        End Property

        Public Property OpeningBalance As Decimal Implements IEmployeeView.OpeningBalance
            Get
                If txtOpeningBalance.Text <> "" Then
                    Return Convert.ToSingle(txtOpeningBalance.Text)
                Else
                    Return 0
                End If
            End Get
            Set
                txtOpeningBalance.Text = FormatDecimalNumber(Value)
            End Set
        End Property

        Public Property PayCycleIdNo As Int16? Implements IEmployeeView.PayCycleIdNo
            Get
                Return cboPayCycleidNo.GetNullableValue(Of Int16)
            End Get
            Set
                cboPayCycleidNo.SetValue(Value)
            End Set
        End Property

        Public Property PayGroupIdNo As Int16? Implements IEmployeeView.PayGroupIdNo
            Get
                Return cboPayGroupIdNo.GetNullableValue(Of Int16)
            End Get
            Set
                cboPayGroupIdNo.SetValue(Value)
            End Set
        End Property

        Public Property PaymentMethod As Char Implements IEmployeeView.PaymentMethod
            Get
                Return cboPaymentMethod.GetValue()
            End Get
            Set
                cboPaymentMethod.SetValue(Value)
            End Set
        End Property

        'Public Property PayRateType As String Implements IEmployeeView.PayRateType
        '    Get
        '        Return cboPayRateType.GetValue()
        '    End Get
        '    Set
        '        cboPayRateType.SetValue(Value)
        '    End Set
        'End Property

        'Public Property PaySalariedOrHourly As String Implements IEmployeeView.PaySalariedOrHourly
        '    Get
        '        Return cboPaySalariedOrHourly.GetValue()
        '    End Get
        '    Set
        '        cboPaySalariedOrHourly.SetValue(Value)
        '    End Set
        'End Property

        Public Property PoBox As String Implements IEmployeeView.PoBox
            Get
                Return txtPoBox.Text
            End Get
            Set
                txtPoBox.Text = Value
            End Set
        End Property

        Public Property ProvinceState As String Implements IEmployeeView.ProvinceState
            Get
                Return txtProvinceState.Text
            End Get
            Set
                txtProvinceState.Text = Value
            End Set
        End Property

        Public Property ReleasedDate As Date? Implements IEmployeeView.ReleasedDate
            Get
                Return dtpReleasedDate.Value
            End Get
            Set
                'If Value Is Nothing Then
                '    dtpBirthDate.Value = Date.Now()
                'Else
                dtpReleasedDate.Value = Value
                'End If
            End Set
        End Property

        Public Property ReligionIdNo As Int16? Implements IEmployeeView.ReligionIdNo
            Get
                Return cacReligionIdNo.GetNullableValue(Of Int16)
            End Get
            Set
                cacReligionIdNo.SetValue(Value)
            End Set
        End Property

        Public Property Street As String Implements IEmployeeView.Street
            Get
                Return txtStreet.Text
            End Get
            Set
                txtStreet.Text = Value
            End Set
        End Property

        Public Property Title As String Implements IEmployeeView.Title

        Public Property TownCity As String Implements IEmployeeView.TownCity
            Get
                Return txtTownCity.Text
            End Get
            Set
                txtTownCity.Text = Value
            End Set
        End Property

        Public Property ZipCode As String Implements IEmployeeView.ZipCode
            Get
                Return txtZipCode.Text
            End Get
            Set
                txtZipCode.Text = Value
            End Set
        End Property

#End Region

        'Public Sub OnEventHandler(ByRef eventType As InsertDgvLine) Implements ISubscriber(Of InsertDgvLine).OnEventHandler
        '    If eventType.Name = "DataGridViewEarnings" Then
        '        bsEarnings.Insert(eventType.BsRow, New EmployeeEarningView)
        '    ElseIf eventType.Name = "DataGridViewDeductions" Then
        '        bsDeductions.Insert(eventType.BsRow, New EmployeeDeductionView)
        '    End If
        'End Sub

        Protected Overrides Sub CreateDataSources()
            cacBankIdNo.DataSource = PresenterObj.GetLookup("Bank")
            cacCountryCode.DataSource = PresenterObj.GetLookup("Country")
            cacDepartmentIdNo.DataSource = PresenterObj.GetLookup("Department")
            cacDesignationIdNo.DataSource = PresenterObj.GetLookup("Designation")
            cacGender.DataSource = PresenterObj.MakeEnumComboList(Of MaleFemaleSelection)
            cacMaritalStatus.DataSource = PresenterObj.MakeEnumComboList(Of MaritalStatusSelection)
            cacNationalityCode.DataSource = PresenterObj.GetLookup("Country")
            cacReligionIdNo.DataSource = PresenterObj.GetLookup("Religion")
            cboPayCycleidNo.DataSource = PresenterObj.GetLookup("PayCycle")
            cboPayGroupIdNo.DataSource = PresenterObj.GetLookup("PayGroup")
            cboPaymentMethod.DataSource = PresenterObj.MakeEnumComboList(Of PayrollPaymentMethodSelection)
            _deductionsByName = PresenterObj.GetFilteredLookupListByCodeName("Deduction", "DeductionType='" + GetEnumCode(DeductionTypeSelection.Regular) + "'")
            _earningsByName = PresenterObj.GetFilteredLookupListByCodeName("Earning", "EarningType='" + GetEnumCode(EarningTypeSelection.Regular) + "'")
            _phoneTypes = PresenterObj.GetLookup("PhoneType")
            _countryTelCodes = PresenterObj.GetIntPhoneCodes()
        End Sub

        Protected Overrides Sub CreateFieldsDictionary()
            FieldsDictionary = New Dictionary(Of String, Object) From
        {
         {"Active", chkActive},
         {"BankAccountNo", txtBankAccountNo},
         {"BankIdNo", cacBankIdNo},
         {"BirthDate", dtpBirthDate},
         {"CountryCode", cacCountryCode},
         {"DepartmentIdNo", cacDepartmentIdNo},
         {"DesignationIdNo", cacDesignationIdNo},
         {"District", txtDistrict},
         {"Email", txtEmail},
         {"EmployeeCode", txtEmployeeCode},
         {"EmployeeName", txtEmployeeName},
         {"EmployeeNameAra", txtEmployeeNameAra},
         {"Gender", cacGender},
         {"HiredDate", dtpHiredDate},
         {"Iban", txtIban},
         {"MaritalStatus", cacMaritalStatus},
         {"NationalIdNo", txtNationalIdNo},
         {"NationalityCode", cacNationalityCode},
         {"Notes", txtNotes},
         {"OpeningBalance", txtOpeningBalance},
         {"PoBox", txtPoBox},
         {"ProvinceState", txtProvinceState},
         {"ReleasedDate", dtpReleasedDate},
         {"ReligionIdNo", cacReligionIdNo},
         {"Street", txtStreet},
         {"TownCity", txtTownCity},
         {"ZipCode", txtZipCode},
        {"IdNo", TxtIdNo}
        }
        End Sub

        Private Sub EmployeeEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            DataGridViewEarnings.DgvFooter.ColumnToSum("dgvEarningAmount") = True
            DataGridViewEarnings.DgvFooter.SetText("dgvEarningIdNo", "Totals ->")
            DataGridViewDeductions.DgvFooter.ColumnToSum("dgvDeductionAmount") = True
            DataGridViewDeductions.DgvFooter.SetText("dgvDeductionIdNo", "Totals ->")
            DisplayNetEarnings()
        End Sub

        Protected Overrides Sub RecordPositionChanged(ByRef e As RecordPositionChanged)
            MyBase.RecordPositionChanged(e)
            Dim value As Double
            value = Convert.ToDecimal(PresenterObj.GetEmployeeBalance(IdNo))
            txtBalance.Text = value.ToString("N", _nfi)
            DisplayNetEarnings()
        End Sub

        Private Sub DisplayNetEarnings()
            Dim nTotal As Decimal
            nTotal = DataGridViewEarnings.GetColumnTotal("dgvEarningAmount") -
                     DataGridViewDeductions.GetColumnTotal("dgvDeductionAmount")
            txtNetTotal.Text = nTotal.ToString("N", _nfi)
        End Sub

        Private Sub BindEmployeeDeduction()
            SuspendLayout()
            bsDeductions.DataSource = Nothing
            DataGridViewDeductions.Refresh()
            bsDeductions.DataSource = RegularEmployeeDeductions
            bsDeductions.AllowNew = True
            With DataGridViewDeductions
                .Refresh()
                .AutoGenerateColumns = False
                .DataSource = bsDeductions
                .Refresh()
            End With
            With DataGridViewDeductions.Columns
                dgvDeductionIdNo.DataSource = _deductionsByName
                dgvDeductionIdNo.DisplayMember = "Name"
                dgvDeductionIdNo.ValueMember = "IdNo"
                dgvDeductionIdNo.AutoComplete = AutoCompleteMode.SuggestAppend
                dgvDeductionIdNo.DisplayStyleForCurrentCellOnly = True
            End With
            ResumeLayout()
        End Sub

        Private Sub BindEmployeeEarning()
            SuspendLayout()
            bsEarnings.DataSource = Nothing
            DataGridViewEarnings.Refresh()
            bsEarnings.DataSource = RegularEmployeeEarnings
            bsEarnings.AllowNew = True
            'bsEarnings.Sort = "Sequence"
            With DataGridViewEarnings
                .Refresh()
                .AutoGenerateColumns = False
                .DataSource = bsEarnings
                .Refresh()
            End With
            With DataGridViewEarnings.Columns
                dgvEarningIdNo.DataSource = _earningsByName
                dgvEarningIdNo.DisplayMember = "Name"
                dgvEarningIdNo.ValueMember = "IdNo"
                dgvEarningIdNo.AutoComplete = AutoCompleteMode.SuggestAppend
                dgvEarningIdNo.DisplayStyleForCurrentCellOnly = True
            End With
            ResumeLayout()
        End Sub

        Private Sub BindEmployeePhone()
            SuspendLayout()
            bsPhones.DataSource = Nothing
            DataGridViewPhones.Refresh()
            bsPhones.DataSource = EmployeePhones
            bsPhones.AllowNew = True
            With DataGridViewPhones
                .Refresh()
                .AutoGenerateColumns = False
                .DataSource = bsPhones
                .Refresh()
            End With
            With DataGridViewPhones.Columns
                dgvPhoneTypeIdNo.DisplayStyleForCurrentCellOnly = True
                dgvPhoneTypeIdNo.DataSource = _phoneTypes
                dgvPhoneTypeIdNo.DisplayMember = "Name"
                dgvPhoneTypeIdNo.ValueMember = "IdNo"
                dgvPhoneTypeIdNo.AutoComplete = AutoCompleteMode.SuggestAppend
                dgvCountryTelIdNo.DisplayStyleForCurrentCellOnly = True
                dgvCountryTelIdNo.DataSource = _countryTelCodes
                dgvCountryTelIdNo.DisplayMember = "Name"
                dgvCountryTelIdNo.ValueMember = "IdNo"
                dgvCountryTelIdNo.AutoComplete = AutoCompleteMode.SuggestAppend
                dgvCountryTelIdNo.DisplayStyleForCurrentCellOnly = True
            End With
            If GlobalVariables.RightToLeftLayout Then
                dgvFullPhone.Visible = False
                dgvFullPhoneAra.Visible = True
            Else
                dgvFullPhoneAra.Visible = False
                dgvFullPhone.Visible = True
            End If
            ResumeLayout()
        End Sub

        Private Sub DataGridViewPhoneDisplay_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
            DisplayPhoneTab()
        End Sub

        Private Sub DisplayPhoneTab()
            If Not EmployeeTabControl.Controls.Contains(tbpPhones) Then
                tbpPhones.Parent = EmployeeTabControl
                'EmployeeTabControl.TabPages.Add(tbpPhones)
                'tbpPhones.Controls.Add(DataGridViewPhones)
            End If
            EmployeeTabControl.SelectTab(tbpPhones)
        End Sub

        Private Sub tbpPhones_Leave(sender As Object, e As EventArgs) Handles tbpPhones.Leave
            tbpPhones.Parent = Nothing
            BindEmployeePhone()
        End Sub

        Private Sub EmployeeEntryTvTest_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
            tbpPhones.Parent = Nothing
        End Sub

        Private Sub DataGridViewPhones_Enter(sender As Object, e As EventArgs) Handles DataGridViewPhones.Enter
            If btnEdit.Enabled Or btnAdd.Enabled Then
                DataGridViewPhones.EditingMode = False
            Else
                DataGridViewPhones.EditingMode = True
            End If
        End Sub

        Private Sub OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewPhones.CellEndEdit
            With DataGridViewPhones
                Select Case .CurrentCell.OwningColumn.Name.ToLower()
                    Case $"dgvphonetypeidno"
                        bsPhones.Current.PhoneTypeName = DataGridViewPhones.GetEditingValue("Code")
                    Case $"dgvcountrytelidno"
                        bsPhones.Current.CountryTelCode = DataGridViewPhones.GetEditingValue("Code")
                End Select
            End With
        End Sub

        Private Sub EarningsOnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewEarnings.CellEndEdit
            DisplayNetEarnings()
            'With DataGridViewEarnings
            '    Select Case .CurrentCell.OwningColumn.Name.ToLower()
            '        Case $"dgvearningidno"
            '            bsEarnings.Current.EarningName = DataGridViewEarnings.GetEditingValue("Name")
            '            bsEarnings.Current.EarningCode = DataGridViewEarnings.GetEditingValue("Code")
            '    End Select
            'End With
        End Sub

        Private Sub DeductionsOnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewDeductions.CellEndEdit
            DisplayNetEarnings()
            'With DataGridViewEarnings
            '    Select Case .CurrentCell.OwningColumn.Name.ToLower()
            '        Case $"dgvearningidno"
            '            bsEarnings.Current.EarningName = DataGridViewEarnings.GetEditingValue("Name")
            '            bsEarnings.Current.EarningCode = DataGridViewEarnings.GetEditingValue("Code")
            '    End Select
            'End With
        End Sub

        Private Sub DataGridViewPhoneDisplay_Click(sender As Object, e As EventArgs) Handles DataGridViewPhoneDisplay.Click
            DisplayPhoneTab()
        End Sub

        Private Sub DataGridViewPhoneDisplay_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewPhoneDisplay.CellContentClick
            DisplayPhoneTab()
        End Sub

    End Class

End Namespace