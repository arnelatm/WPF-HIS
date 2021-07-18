Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Common
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Views.Forms

    Public Class EmployeeEntryTv
        Implements IEmployeeView

        Private _countryTelCodes As List(Of Lookup.LookupData)
        Private _regularEmployeeDeductions As List(Of EmployeePayElementView)
        Private _regularEmployeeEarnings As List(Of EmployeePayElementView)
        Private _employeePhones As List(Of EmployeePhoneView)
        Private _unit As List(Of Lookup.LookupData)

        ' ReSharper disable once UnassignedField.Local
        Private _phoneTypes As List(Of Lookup.LookupData)

        ' ReSharper disable once UnassignedField.Local
        Private _deductionsByName As List(Of Lookup.LookupData)

        ' ReSharper disable once UnassignedField.Local
        Private _earningsByName As List(Of Lookup.LookupData)

        Private ReadOnly _nfi As NumberFormatInfo

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()
            '_presenter = presenter
            ' Add any initialization after the InitializeComponent() call.
            FirstControl = txtEmployeeName
            _nfi = GlobalVariables.DefaultNumberFormatInfo
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

        Public Property Balance As Decimal Implements IEmployeeView.Balance
            Get
                Return NumParser(Of Decimal)(txtBalance.Text)
            End Get
            Set
                txtBalance.Text = Value
            End Set
        End Property

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

        Public Property DutyHours As Decimal Implements IEmployeeView.DutyHours
            Get
                Return NumParser(Of Decimal)(txtDutyHours.Text)
            End Get
            Set
                txtDutyHours.Text = FormatDecimalNumber(Value)
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

        Public Property PayFrequency As PayFrequencySelection Implements IEmployeeView.PayFrequency

        Public Property RegularEmployeeDeductions As List(Of EmployeePayElementView) Implements IEmployeeView.RegularEmployeeDeductions
            Get
                Return _regularEmployeeDeductions
            End Get
            Set
                _regularEmployeeDeductions = Value
                BindEmployeeDeduction()
            End Set
        End Property

        Public Property RegularEmployeeEarnings As List(Of EmployeePayElementView) Implements IEmployeeView.RegularEmployeeEarnings
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
                Return NumParser(Of Decimal)(txtOpeningBalance.Text)
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
                Ea.PublishEvent(New PayCycleIdNoChanged(Value))
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
                dtpReleasedDate.Value = Value
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

        'Public Property EarningsByName As List(Of Lookup.LookupData)
        '    Get
        '        CreateLookupData("PayElement",
        '                      "EarningsByName",
        '                      "PayElementKind = '" + EnumToCode(PayElementKindSelection.Earning) + "' and PayElementType = '" + EnumToCode(PayElementTypeSelection.Regular) + "'")
        '        Return _earningsByName
        '    End Get
        '    Set
        '        _earningsByName = Value
        '    End Set
        'End Property

        'Public Property DeductionsByName As List(Of Lookup.LookupData)
        '    Get
        '        CreateLookupData("PayElement",
        '                      "DeductionsByName",
        '                      "PayElementKind = '" + EnumToCode(PayElementKindSelection.Deduction) + "' and PayElementType = '" + EnumToCode(PayElementTypeSelection.Regular) + "'")
        '        Return _deductionsByName
        '    End Get
        '    Set
        '        _countryTelCodes = Value
        '    End Set
        'End Property

        'Public Property PhoneTypes As List(Of Lookup.LookupData)
        '    Get
        '        CreateLookupData("PhoneType", "PhoneTypes")
        '        Return _phoneTypes
        '    End Get
        '    Set
        '        _phoneTypes = Value
        '    End Set
        'End Property

        Public Property CountryTelCodes As List(Of Lookup.LookupData)
            Get
                MyBase.CreateLookupData("Country", "CountryTelCodes", "CountryName", {"IdNo", "CountryName", "CountryTelCode"})
                Return _countryTelCodes
            End Get
            Set
                _countryTelCodes = Value
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateDataSources()
            CreateEnumDataSource(Of MaleFemaleSelection)(cacGender)
            CreateEnumDataSource(Of MaritalStatusSelection)(cacMaritalStatus)
            CreateEnumDataSource(Of PayrollPaymentMethodSelection)(cboPaymentMethod)
            CreateEnumData(Of PayRateUnitSelection)(_unit)
            CreateDataSource("Bank", cacBankIdNo)
            CreateDataSource("Country", cacCountryCode)
            CreateDataSource("Department", cacDepartmentIdNo)
            CreateDataSource("Designation", cacDesignationIdNo)
            CreateDataSource("Country", cacNationalityCode)
            CreateDataSource("Religion", cacReligionIdNo)
            CreateDataSource("PayCycle", cboPayCycleidNo)
            CreateDataSource("PayGroup", cboPayGroupIdNo)
            CreateLookupData("PhoneType", NameOf(_phoneTypes))
            CreateLookupData("PayElement", NameOf(_deductionsByName), "PayElementKind = '" + EnumToCode(PayElementKindSelection.Deduction) + "' and PayElementType = '" + EnumToCode(PayElementTypeSelection.Regular) + "'")
            CreateLookupData("PayElement", NameOf(_earningsByName), "PayElementKind = '" + EnumToCode(PayElementKindSelection.Earning) + "' and PayElementType = '" + EnumToCode(PayElementTypeSelection.Regular) + "'")
        End Sub

        'Private Sub CreateLookupData(tableName As String, cVariableName As String)
        '    _phoneTypes = GetLookupData(tableName, cVariableName)
        'End Sub

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
        {
         {"Active", chkActive},
         {"Balance", txtBalance},
         {"BankAccountNo", txtBankAccountNo},
         {"BankIdNo", cacBankIdNo},
         {"BirthDate", dtpBirthDate},
         {"CountryCode", cacCountryCode},
         {"DepartmentIdNo", cacDepartmentIdNo},
         {"DesignationIdNo", cacDesignationIdNo},
         {"District", txtDistrict},
         {"DutyHours", txtDutyHours},
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
         {"PayCycleIdNo", cboPayCycleidNo},
         {"PayGroupIdNo", cboPayGroupIdNo},
         {"PaymentMethod", cboPaymentMethod},
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

        'Private Sub EmployeeEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '    'If GlobalVariables.RightToLeftLayout Then
        '    '    SwitchUiLanguage(True)
        '    '    SwitchUiLanguage(False)
        '    'Else
        '    '    SwitchUiLanguage(True)
        '    'End If
        '    DataGridViewEarnings.DgvFooter.ColumnToSum("dgvEarningAmount") = True
        '    DataGridViewEarnings.DgvFooter.SetText("dgvEarningIdNo", "Totals ->")
        '    DataGridViewDeductions.DgvFooter.ColumnToSum("dgvDeductionAmount") = True
        '    DataGridViewDeductions.DgvFooter.SetText("dgvDeductionIdNo", "Totals ->")
        'End Sub

        Private Sub BindEmployeeDeduction()
            'SuspendLayout()
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
                dgvDeductionUnit.DataSource = _unit
                dgvDeductionUnit.ValueMember = "Code"
                dgvDeductionUnit.DisplayMember = "Name"
                dgvDeductionUnit.DisplayStyleForCurrentCellOnly = True
                dgvSequenceDeduction.DisplayOnly = True
                dgvDeductionAmount.DisplayOnly = True
            End With
            'ResumeLayout()
        End Sub

        Private Sub BindEmployeeEarning()
            'SuspendLayout()
            bsEarnings.DataSource = Nothing
            DataGridViewEarnings.Refresh()
            bsEarnings.DataSource = RegularEmployeeEarnings
            bsEarnings.AllowNew = True
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
                dgvEarningUnit.DataSource = _unit
                dgvEarningUnit.ValueMember = "Code"
                dgvEarningUnit.DisplayMember = "Name"
                dgvEarningUnit.DisplayStyleForCurrentCellOnly = True
                dgvSequenceEarning.DisplayOnly = True
                dgvEarningAmount.DisplayOnly = True
            End With
            'ResumeLayout()
        End Sub

        Private Sub BindEmployeePhone()
            'SuspendLayout()
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
                dgvCountryTelIdNo.DataSource = CountryTelCodes
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
            'ResumeLayout()
        End Sub

        Private Sub DataGridViewPhoneDisplay_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewPhoneDisplay.CellContentClick
            DisplayPhoneTab()
        End Sub

        Private Sub DisplayPhoneTab()
            If Not tbcEmployee.Controls.Contains(tbpPhones) Then
                tbpPhones.Parent = tbcEmployee
                'EmployeeTabControl.TabPages.Add(tbpPhones)
                'tbpPhones.Controls.Add(DataGridViewPhones)
            End If
            tbcEmployee.SelectTab(tbpPhones)
        End Sub

        Private Sub OnTbpPhones_Leave(sender As Object, e As EventArgs) Handles tbpPhones.Leave
            tbpPhones.Parent = Nothing
            BindEmployeePhone()
        End Sub

        Private Sub OnEmployeeEntryTvTest_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
            tbpPhones.Parent = Nothing
        End Sub

        Private Sub OnDataGridViewPhones_Enter(sender As Object, e As EventArgs) Handles DataGridViewPhones.Enter
            If btnEdit.Enabled Or btnAdd.Enabled Then
                DataGridViewPhones.EditingMode = False
            Else
                DataGridViewPhones.EditingMode = True
            End If
        End Sub

        Private Sub OnDataGridViewPhones_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewPhones.CellEndEdit
            With DataGridViewPhones
                If .CurrentRow IsNot Nothing Then
                    Select Case .CurrentCell.OwningColumn.Name.ToLower()
                        Case $"dgvphonetypeidno"
                            bsPhones.Current.PhoneTypeName = DataGridViewPhones.GetEditingValue("Code")
                        Case $"dgvcountrytelidno"
                            bsPhones.Current.CountryTelCode = DataGridViewPhones.GetEditingValue("Code")
                    End Select
                End If
            End With
        End Sub

        Private Sub OnDataGridViewPhoneDisplay_Click(sender As Object, e As EventArgs) Handles DataGridViewPhoneDisplay.Click
            DisplayPhoneTab()
        End Sub

        Private Sub DgvEarning_OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewEarnings.CellEndEdit
            ProcessCellEndEdit(DataGridViewEarnings, bsEarnings)
        End Sub

        Private Sub DgvDeduction_OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewDeductions.CellEndEdit
            ProcessCellEndEdit(DataGridViewDeductions, bsDeductions)
        End Sub

    End Class

End Namespace