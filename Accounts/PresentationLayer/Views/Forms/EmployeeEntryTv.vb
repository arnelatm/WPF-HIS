Imports System.Globalization
Imports System.IO
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms

    Public Class EmployeeEntryTv
        Implements IEmployeeView

        Private _countryTelCodes As List(Of Lookup.LookupData)
        Private _regularEmployeeDeductions As List(Of EmployeePayElementView)
        Private _regularEmployeeEarnings As List(Of EmployeePayElementView)
        Private _employeeLeaveCredits As List(Of EmployeeLeaveCreditView)
        Private _employeeDocuments As List(Of EmployeeDocumentView)
        Private _employeePhones As List(Of EmployeePhoneView)

        'Private _unit As List(Of Lookup.LookupData)
        'Private _deductionsByName As List(Of Lookup.LookupData)
        'Private _leaves As List(Of Lookup.LookupData)
        'Private _earningsByName As List(Of Lookup.LookupData)
        Private _fileSizeTooLarge As Boolean = False

        Private ReadOnly _nfi As NumberFormatInfo

        'Public Overrides Property ViewDisplayName as String = "EmployeeEntryTv"

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()
            '_presenter = presenter
            ' Add any initialization after the InitializeComponent() call.

            FirstControl = txtEmployeeName
            _nfi = GlobalVariables.DefaultNumberFormatInfo
        End Sub

#Region "Fields"

        Public Property Documents As List(Of Lookup.LookupData) Implements IEmployeeView.Documents
        Public Property PhoneTypes As List(Of Lookup.LookupData) Implements IEmployeeView.PhoneTypes
        Public Property Leaves As List(Of Lookup.LookupData) Implements IEmployeeView.Leaves
        Public Property DeductionsByName As List(Of Lookup.LookupData) Implements IEmployeeView.DeductionsByName
        Public Property EarningsByName As List(Of Lookup.LookupData) Implements IEmployeeView.EarningsByName
        Public Property Unit As List(Of Lookup.LookupData) Implements IEmployeeView.Unit

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
                If Visible Then
                    Return cacBankIdNo.GetNullableValue(Of Int16)
                Else
                    Return cacBankIdNo.DataValue
                End If
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
                dtpBirthDate.Value = Value
            End Set
        End Property

        Public Property BloodType As String Implements IEmployeeView.BloodType
            Get
                Return cboBloodType.GetValue()
            End Get
            Set
                cboBloodType.SetValue(Value)
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

        Public Property SponsorType As Char Implements IEmployeeView.SponsorType
            Get
                Return cboSponsorType.GetValue()
            End Get
            Set
                cboSponsorType.SetValue(Value)
            End Set
        End Property

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

        Public Property EmployeeDocuments As List(Of EmployeeDocumentView) Implements IEmployeeView.EmployeeDocuments
            Get
                Return _employeeDocuments
            End Get
            Set
                _employeeDocuments = Value
                BindEmployeeDocument()
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

        Public Property Supervisor As Boolean Implements IEmployeeView.Supervisor
            Get
                Return chkSupervisor.Checked
            End Get
            Set
                chkSupervisor.Checked = Value
            End Set
        End Property

        Public Property SupervisorIdNo As Int32 Implements IEmployeeView.SupervisorIdNo
            Get
                Return cboSupervisorIdNo.GetNullableValue(Of Int32)
            End Get
            Set
                cboSupervisorIdNo.SetValue(Value)
            End Set
        End Property

        Public Property Title As String Implements IEmployeeView.Title
            Get
                Return cboTitle.GetNullableValue(Of String)
            End Get
            Set
                cboTitle.SetValue(Value)
            End Set
        End Property

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

        Private ReadOnly _blankImage As Image = GlobalFuncNSub.CreateTextImage("Click" & Environment.NewLine & "to Change" & Environment.NewLine & "Photo", Nothing, Nothing, Nothing, Nothing, Nothing)

        Public Property Picture As Image Implements IEmployeeView.Picture
            Get
                If imgPicture.Image Is Nothing Then
                    Return Nothing
                ElseIf imgPicture.Image.Equals(_blankImage) Then
                    Return Nothing
                End If
                Return imgPicture.Image
            End Get
            Set
                If Value IsNot Nothing Then
                    imgPicture.Image = Value
                Else
                    imgPicture.Image = _blankImage
                End If
            End Set
        End Property

        Public Property CountryTelCodes As List(Of Lookup.LookupData)
            Get
                MyBase.CreateLookupData("Country", "CountryTelCodes", "CountryName", {"IdNo", "CountryName", "CountryTelCode"})
                Return _countryTelCodes
            End Get
            Set
                _countryTelCodes = Value
            End Set
        End Property

        Public Property EmployeeLeaveCredits As List(Of EmployeeLeaveCreditView) Implements IEmployeeView.EmployeeLeaveCredits
            Get
                Return _employeeLeaveCredits
            End Get
            Set
                _employeeLeaveCredits = Value
                BindEmployeeLeaveCredits()
            End Set
        End Property

        Public Property ActualDutyHours As Decimal Implements IEmployeeView.ActualDutyHours
            Get
                Return NumParser(Of Decimal)(txtActualDutyHours.Text)
            End Get
            Set
                txtActualDutyHours.Text = FormatDecimalNumber(Value)
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
        {
         {"Active", chkActive},
         {"ActualDutyHours", txtActualDutyHours},
         {"Balance", txtBalance},
         {"BankAccountNo", txtBankAccountNo},
         {"BankIdNo", cacBankIdNo},
         {"BirthDate", dtpBirthDate},
         {"BloodType", cboBloodType},
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
         {"IdNo", TxtIdNo},
         {"MaritalStatus", cacMaritalStatus},
         {"NationalIdNo", txtNationalIdNo},
         {"NationalityCode", cacNationalityCode},
         {"Notes", txtNotes},
         {"OpeningBalance", txtOpeningBalance},
         {"PayCycleIdNo", cboPayCycleidNo},
         {"PayGroupIdNo", cboPayGroupIdNo},
         {"PaymentMethod", cboPaymentMethod},
         {"Picture", imgPicture},
         {"PoBox", txtPoBox},
         {"ProvinceState", txtProvinceState},
         {"ReleasedDate", dtpReleasedDate},
         {"ReligionIdNo", cacReligionIdNo},
         {"SponsorType", cboSponsorType},
         {"Street", txtStreet},
         {"Supervisor", chkSupervisor},
         {"SupervisorIdNo", cboSupervisorIdNo},
         {"Title", cboTitle},
         {"TownCity", txtTownCity},
         {"ZipCode", txtZipCode}
        }
        End Sub

        Private Sub BindEmployeeDeduction()
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
                dgvDeductionIdNo.DataSource = DeductionsByName
                dgvDeductionIdNo.DisplayMember = "Name"
                dgvDeductionIdNo.ValueMember = "IdNo"
                dgvDeductionIdNo.DisplayStyleForCurrentCellOnly = True
                dgvDeductionUnit.DataSource = Unit
                dgvDeductionUnit.ValueMember = "Code"
                dgvDeductionUnit.DisplayMember = "Name"
                dgvDeductionUnit.DisplayStyleForCurrentCellOnly = True
                dgvSequenceDeduction.DisplayOnly = True
                dgvDeductionAmount.DisplayOnly = True
            End With
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
                dgvEarningIdNo.DataSource = EarningsByName
                dgvEarningIdNo.DisplayMember = "Name"
                dgvEarningIdNo.ValueMember = "IdNo"
                dgvEarningIdNo.DisplayStyleForCurrentCellOnly = True
                dgvEarningUnit.DataSource = Unit
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
                dgvPhoneTypeIdNo.DataSource = PhoneTypes
                dgvPhoneTypeIdNo.DisplayMember = "Name"
                dgvPhoneTypeIdNo.ValueMember = "IdNo"
                dgvCountryTelIdNo.DisplayStyleForCurrentCellOnly = True
                dgvCountryTelIdNo.DataSource = CountryTelCodes
                dgvCountryTelIdNo.DisplayMember = "Name"
                dgvCountryTelIdNo.ValueMember = "IdNo"
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


        Private Sub BindEmployeeDocument()
            'SuspendLayout()
            bsDocuments.DataSource = Nothing
            DataGridViewDocuments.Refresh()
            bsDocuments.DataSource = EmployeeDocuments
            bsDocuments.AllowNew = True
            With DataGridViewDocuments
                .Refresh()
                .AutoGenerateColumns = False
                .DataSource = bsDocuments
                .Refresh()
            End With
            With DataGridViewDocuments.Columns
                dgvDocumentIdNo.DisplayStyleForCurrentCellOnly = True
                dgvDocumentIdNo.DataSource = Documents
                dgvDocumentIdNo.DisplayMember = "Name"
                dgvDocumentIdNo.ValueMember = "IdNo"
                dgvSequenceDocument.DisplayOnly = True
            End With
            'ResumeLayout()
        End Sub

        Private Sub BindEmployeeLeaveCredits()
            bsLeaveCredits.DataSource = Nothing
            DataGridViewLeaveCredits.Refresh()
            bsLeaveCredits.DataSource = EmployeeLeaveCredits
            bsLeaveCredits.AllowNew = True
            With DataGridViewLeaveCredits
                .Refresh()
                .AutoGenerateColumns = False
                .DataSource = bsLeaveCredits
                .Refresh()
            End With
            With DataGridViewLeaveCredits.Columns
                dgvLeaveIdNo.DisplayStyleForCurrentCellOnly = True
                dgvLeaveIdNo.DataSource = Leaves
                dgvLeaveIdNo.DisplayMember = "Name"
                dgvLeaveIdNo.ValueMember = "IdNo"
            End With
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

        Private Sub DataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewDocuments.CellClick
            Try
                With DataGridViewDocuments
                    If .CurrentCell IsNot Nothing Then
                        Dim index As Int16 = .CurrentCell.RowIndex()
                        If .CurrentCell.OwningColumn.Name() = "dgvImageButton" Then
                            If DataGridViewDocuments.EditingMode Then
                                If EmployeeDocuments(index).DataImageIdNo > 0 Then
                                    GetDocumentImage(index, EmployeeDocuments(index).DataImageIdNo)
                                Else
                                    GetDocumentImage(index, EmployeeDocuments(index).DataImageIdNo)
                                End If
                            Else
                                If EmployeeDocuments(index).DataImageIdNo > 0 Then
                                    Dim tempFileName As String = CreateFileFromDataImage(EmployeeDocuments(index).DataImageIdNo)
                                    Dim cPictureViewer As New CPictureViewer(tempFileName, EmployeeName & " " & DataGridViewDocuments.CurrentRow.Cells("dgvDocumentIdNo").EditedFormattedValue)
                                    cPictureViewer.ShowDialog()
                                Else
                                    If Not .EditingMode Then
                                        Messaging.Show(True, "MsgNoImageEntered")
                                    End If
                                End If
                            End If
                        End If
                    End If
                End With

                'With DataGridViewDocuments
                '    If .CurrentCell IsNot Nothing Then
                '        If .CurrentCell.OwningColumn.Name() = "dgvImageButton" Then
                '            If DataGridViewDocuments.EditingMode Then
                '                GetDocumentImage(.CurrentRow.Index, .CurrentCell.Value)
                '            Else
                '                If .CurrentRow.Cells("dgvImage").Value <> 0 Then
                '                    Dim dao = New DataImageDao
                '                    Dim recordIdNo = .CurrentRow.Cells("dgvImage").Value
                '                    Dim dataImage As DataImage = dao.GetRecordByIdNo(recordIdNo)
                '                    'Dim iImage As New Image = dataImage.Image
                '                    Dim tempFileName As String = System.IO.Path.GetRandomFileName()
                '                    tempFileName = tempFileName.Right(tempFileName.Length - 4) + ".jpeg"
                '                    Dim saveImage As New Bitmap(dataImage.Image)
                '                    saveImage.Save(tempFileName, Imaging.ImageFormat.Jpeg)
                '                    Dim cPictureViewer As New CPictureViewer(tempFileName, EmployeeName & " " & DataGridViewDocuments.CurrentRow.Cells("dgvDocumentIdNo").EditedFormattedValue)
                '                    cPictureViewer.ShowDialog()
                '                End If
                '            End If

                '        End If
                '    End If
                'End With
            Catch ex As Exception
                Messaging.Show("error")
            End Try

        End Sub

        Private Function CreateFileFromDataImage(imageIdNo As Short) As String
            Dim dao = New DataImageDao
            Dim dataImage As DataImage = dao.GetRecordByIdNo(imageIdNo)
            Dim tempFileName As String = System.IO.Path.GetRandomFileName()
            tempFileName = tempFileName + ".jpeg"
            Dim saveImage As New Bitmap(dataImage.Image)
            saveImage.Save(tempFileName, Imaging.ImageFormat.Jpeg)
            Return tempFileName
        End Function

        Private Sub GetDocumentImage(index As Int16, value As Object)
            If DataGridViewDocuments.EditingMode Then
                'Dim fd As OpenFileDialog = New OpenFileDialog()
                'Dim strFileName As String = Nothing
                'Dim docimage As Image
                'Dim maxImageSize = 2000000
                If EmployeeDocuments(index).DataImageIdNo > 0 Then
                    EmployeeDocuments(index).ImageFileName = CreateFileFromDataImage(EmployeeDocuments(index).DataImageIdNo)
                End If
                Dim documentFileName = EmployeeDocuments(DataGridViewDocuments.CurrentRow.Index).ImageFileName
                Dim cPictureViewer As New CPictureViewer(documentFileName, EmployeeName & " " & DataGridViewDocuments.CurrentRow.Cells("dgvDocumentIdNo").EditedFormattedValue)
                cPictureViewer.ShowDialog()
                If cPictureViewer.DialogResult = DialogResult.OK Then
                    If cPictureViewer.ImageFileName IsNot Nothing Then
                        'DataGridViewDocuments.CurrentRow.Cells("dgvFileName").Value = cPictureViewer.ImageFileName               
                        EmployeeDocuments(index).ImageFileName = cPictureViewer.ImageFileName
                        'EmployeeDocuments.Item(index).DataImageIdNo = -1
                        'DataGridViewDocuments.CurrentRow.Cells("dgvImage").Value = -1
                    End If

                    'Dim fileInfo As New FileInfo(cPictureViewer.ImageFileName)
                    'Dim fileExtension = fileInfo.Extension
                    'DataGridViewDocuments.CurrentRow.Cells("dgvFileName").Value = fileInfo.FullName
                    'Dim filePathAndName As String = GlobalFuncNSub.GetTempFileName(fileExtension)
                    'docimage = Drawing.Image.FromFile(cPictureViewer.ImageFileName)
                    'Dim fileInfo As New FileInfo(cPictureViewer.ImageFileName)
                    'Dim length As Long = fileInfo.Length
                    'If maxImageSize > 0 Then
                    '    If fileInfo.Length > maxImageSize Then
                    '        docimage.Dispose()
                    '        docimage = Nothing
                    '        Dim fileExtension = fileInfo.Extension
                    '        Dim path As String = GlobalFuncNSub.GetTempFileName(fileExtension)
                    '        Dim resizer As ImageResizer = New ImageResizer(maxImageSize, cPictureViewer.ImageFileName, path)
                    '        If Not resizer.ScaleImage() Then
                    '            MessageBox.Show("Cannot scale image to " & maxImageSize.ToString() & $" bytes size. Either select a smaller file size or resize the image manually to less than or equal to " & maxImageSize.ToString() & " bytes.")
                    '        End If
                    '        docimage = Drawing.Image.FromFile(path)
                    '    End If
                    'End If
                End If

                'Using fd As OpenFileDialog = New OpenFileDialog()
                'fd.Title = $"Open File Dialog"
                'fd.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
                'fd.Filter = $"Image Files(*.BMP;*.JPG;*.GIF;*.JPEG;*.TIFF;*.PNG)|*.BMP;*.JPG;*.JPEG;*.GIF;*.TIFF;*.PNG"
                'fd.FilterIndex = 1
                'fd.RestoreDirectory = True
                'If fd.ShowDialog() = DialogResult.OK Then
                '    strFileName = fd.FileName
                '    docimage = Drawing.Image.FromFile(strFileName)
                '    Dim fileInfo As New FileInfo(strFileName)
                '    Dim length As Long = fileInfo.Length
                '    If MaxImageSize > 0 Then
                '        If fileInfo.Length > MaxImageSize Then
                '            docImage.Dispose()
                '            docImage = Nothing
                '            Dim fileExtension = fileInfo.Extension
                '            Dim path As String = GlobalFuncNSub.GetTempFileName(fileExtension)
                '            Dim resizer As ImageResizer = New ImageResizer(MaxImageSize, strFileName, path)
                '            If Not resizer.ScaleImage() Then
                '                MessageBox.Show("Cannot scale image to " & maxImageSize.ToString() & $" bytes size. Either select a smaller file size or resize the image manually to less than or equal to " & MaxImageSize.ToString() & " bytes.")
                '            End If
                '            docImage = Drawing.Image.FromFile(path)
                '        End If
                '    End If
                'End If
                'End Using
            End If
        End Sub

        Private Sub DgvEarning_OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewEarnings.CellEndEdit
            ProcessCellEndEdit(DataGridViewEarnings, bsEarnings)
        End Sub

        Private Sub DgvDeduction_OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewDeductions.CellEndEdit
            ProcessCellEndEdit(DataGridViewDeductions, bsDeductions)
        End Sub

        Private Sub DgvLeaveCredits_OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewLeaveCredits.CellEndEdit
            ProcessCellEndEdit(DataGridViewLeaveCredits, bsLeaveCredits)
            'With DataGridViewLeaveCredits
            '    If .CurrentRow IsNot Nothing Then
            '        Select Case .CurrentCell.OwningColumn.Name
            '            Case $"LeaveIdNo"
            '                'If leave.LeaveCycle = EnumToCode(LeaveCycleSelection.OnceOnly) Or leave.LeaveCycle = EnumToCode(LeaveCycleSelection.AsNeeded) Then
            '                '    empLeaveCredit.MaxCarryOver = 0
            '                '    empLeaveCredit.MaxLimit = 0
            '                '    empLeaveCredit.NoMaxLimit = False
            '                '    empLeaveCredit.Cumulative = False
            '                '    Beep()
            '                'Else
            '                '    If Not empLeaveCredit.Cumulative Then
            '                '        empLeaveCredit.MaxCarryOver = 0
            '                '        empLeaveCredit.MaxLimit = 0
            '                '        empLeaveCredit.NoMaxLimit = False
            '                '    Else
            '                '        empLeaveCredit.NoMaxLimit = True
            '                '        empLeaveCredit.MaxLimit = 0
            '                '    End If
            '                'End If
            '                'bsLeaveCredits.ResetBindings(False)
            '                'if bsLeaveCredits.Current.Cumulative Then
            '                '    bsLeaveCredits.Current.
            '                'End If
            '        End Select
            '    End If
            'End With
            'bsLeaveCredits.ResetBindings(False)
        End Sub

    End Class

End Namespace