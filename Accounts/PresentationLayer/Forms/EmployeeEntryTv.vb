Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Forms

    Public Class EmployeeEntryTv
        Implements IEmployeeView

        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            MainTableName = "Employee"
            IdFieldName = "IdNo"
            TvMainFieldName = "EmployeeName"
            TvSecondaryFieldName = "EmployeeCode"
            SortOrderKey = "EmployeeName"
            FirstControl = txtEmployeeCode
            ' Add any initialization after the InitializeComponent() call.
            EmployeeTabControl.RightToLeftLayout = GlobalVariables.RightToLeftLayout
            EmployeeTabControl.RightToLeft = RightToLeft.Inherit
            PresenterObj = New EmployeePresenter(Me)

        End Sub

        Public Property Active As Boolean Implements IEmployeeView.Active
            Get
                Return chkActive.Checked
            End Get
            Set
                chkActive.Checked = Value
            End Set
        End Property

        Public Property ArAccountIdNo As Integer Implements IEmployeeView.ArAccountIdNo
            Get
                Return cacArAccountIdNo.GetValue()
            End Get
            Set
                cacArAccountIdNo.SetValue(Value)
            End Set
        End Property

        Public Property Balance As Decimal Implements IEmployeeView.Balance
            Get
                If txtBalance.Text <> "" Then
                    Return Convert.ToSingle(txtBalance.Text)
                Else
                    Return 0
                End If
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

        Private Property BankIdNo As Short Implements IEmployeeView.BankIdNo
            Get
                Return cacBankIdNo.GetValue()
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

        Public Property DepartmentIdNo As Short Implements IEmployeeView.DepartmentIdNo
            Get
                Return cacDepartmentIdNo.GetValue()
            End Get
            Set
                cacDepartmentIdNo.SetValue(Value)
            End Set
        End Property

        Public Property DesignationIdNo As Short Implements IEmployeeView.DesignationIdNo
            Get
                Return cacDesignationIdNo.GetValue()
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

        'Public Property BankIdNo As Integer Implements IEmployeeView.BankIdNo
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

        Public Property IdNo As Integer Implements IEmployeeView.IdNo
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
                txtOpeningBalance.Text = Value
            End Set
        End Property

        Public Property Phone1 As String Implements IEmployeeView.Phone1
            Get
                Return txtPhone1.Text
            End Get
            Set
                txtPhone1.Text = Value
            End Set
        End Property

        Public Property Phone2 As String Implements IEmployeeView.Phone2
            Get
                Return txtPhone2.Text
            End Get
            Set
                txtPhone2.Text = Value
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
                'If Value Is Nothing Then
                '    dtpBirthDate.Value = Date.Now()
                'Else
                dtpReleasedDate.Value = Value
                'End If
            End Set
        End Property

        Public Property ReligionIdNo As Int16 Implements IEmployeeView.ReligionIdNo
            Get
                Return cacReligionIdNo.GetValue()
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

        Protected Overrides Sub CreateFieldsDictionary()
            FieldsDictionary = New Dictionary(Of String, Object) From
        {
         {"Active", chkActive},
         {"ArAccountIdNo", cacArAccountIdNo},
         {"Balance", txtBalance},
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
         {"Phone1", txtPhone1},
         {"Phone2", txtPhone2},
         {"PoBox", txtPoBox},
         {"ProvinceState", txtProvinceState},
         {"ReleasedDate", dtpReleasedDate},
         {"ReligionIdNo", cacReligionIdNo},
         {"Street", txtStreet},
         {"TownCity", txtTownCity},
         {"ZipCode", txtZipCode},
        {"IdNo", TxtIDNo}
        }
        End Sub

        Protected Overrides Sub CreateDataSources()
            cacArAccountIdNo.DataSource = PresenterObj.GetChartList()
            cacBankIdNo.DataSource = PresenterObj.GetBankList()
            cacCountryCode.DataSource = PresenterObj.GetCountryList()
            cacDepartmentIdNo.DataSource = PresenterObj.GetDepartmentListByName()
            cacDesignationIdNo.DataSource = PresenterObj.GetDesignationList()
            cacGender.DataSource = PresenterObj.MakeEnumComboList(Of MaleFemaleSelection)
            cacMaritalStatus.DataSource = PresenterObj.MakeEnumComboList(Of MaritalStatusSelection)
            cacNationalityCode.DataSource = PresenterObj.GetCountryList()
            cacReligionIdNo.DataSource = PresenterObj.GetReligionList()
            'ResourceEnumConverter.MakeResource("MaritalStatusSelection", GetType(MaritalStatusSelection))
            'ResourceEnumConverter.MakeResource("MaleFemaleSelection", GetType(MaleFemaleSelection))
        End Sub


        Private Sub BindingNavigatorMoveNextItem_Click(sender As Object, e As EventArgs) 
            GoNextRecord()
        End Sub

        Private Sub BindingNavigatorMoveFirstItem_Click(sender As Object, e As EventArgs) 
            GoFirstRecord()
        End Sub

        Private Sub EmployeeEntryTv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            'dim ds = PresenterObj.GetTreeViewDataNew()
            'BindingSource1.DataSource = ds
            'txtEmployeeName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmployeeModelBindingSource, "EmployeeName", true))

        End Sub

        'Private Sub BindingNavigatorMovePreviousItem_Click(sender As Object, e As EventArgs) 
        '    GoPreviousRecord()
        'End Sub

        'Private Sub BindingNavigatorMoveLastItem_Click(sender As Object, e As EventArgs) 
        '    GoLastRecord()
        'End Sub

    End Class

End Namespace