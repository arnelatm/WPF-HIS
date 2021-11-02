Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Views.Forms

    Public Class EmployeeIdPrinting
        Implements IEmployeeView

        Private _employeeIdList As New List(Of EmployeeIdModel)

        Public Event EmployeeCheckedEvent(sender As Object) 'Implements IEmployeeIdPrintingView.EmployeeCheckedEvent

        Public Event ClearAllEmployeeID(sender As Object, clear As Boolean) 'Implements IEmployeeIdPrintingView.ClearAllEmployee

        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            Me.Text = Messaging.TranslateCaption("Employee I.D. Printing")
        End Sub

#Region "Field Items"

        Private Property EmployeeIdList As List(Of EmployeeIdModel) 'Implements IEmployeeIdPrintingView.EmployeeIdListView
            Get
                Return _employeeIdList
            End Get
            Set
                _employeeIdList = Value
                BindEmployeeIdList()
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateDataSources()
            EmployeeIdList = Presenter.GetEmployeeIdList()
        End Sub

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {}
        End Sub

        Private Sub BindEmployeeIdList()
            SuspendLayout()
            bsEmployeeIdList.DataSource = Nothing
            DataGridViewEmployeeIdList.Refresh()
            bsEmployeeIdList.DataSource = EmployeeIdList
            bsEmployeeIdList.AllowNew = True
            With DataGridViewEmployeeIdList
                '.Refresh()
                .AutoGenerateColumns = False
                .DataSource = bsEmployeeIdList
                '.Refresh()
            End With
            With DataGridViewEmployeeIdList.Columns
                dgvIdNo.DisplayOnly = True
                dgvEmployeeName.DisplayOnly = True
                dgvNationalIdNo.DisplayOnly = True
                dgvPicture.ImageLayout = DataGridViewImageCellLayout.Stretch
            End With
            ResumeLayout()
        End Sub

        Private Sub EmployeeIdPrinting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            DataGridViewEmployeeIdList.Refresh()
            BindEmployeeIdList()
        End Sub

        Private Sub EmployeeIdPrinting_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
            bsEmployeeIdList.ResetBindings(True)
        End Sub

        Private Sub SelectAll_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnSelectAll.ClickButtonArea
            RaiseEvent ClearAllEmployeeID(bsEmployeeIdList, True)
            bsEmployeeIdList.ResetBindings(False)
        End Sub

        Private Sub UnselectAll_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnUnSelectAll.ClickButtonArea
            RaiseEvent ClearAllEmployeeID(bsEmployeeIdList, False)
            bsEmployeeIdList.ResetBindings(False)
        End Sub

        Private Sub DataGridViewEmployeeIdListCellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewEmployeeIdList.CellContentClick
            If DataGridViewEmployeeIdList.CurrentCell IsNot Nothing AndAlso (Presenter.EditMode Or Presenter.AddMode) Then
                With DataGridViewEmployeeIdList.CurrentCell
                    Select Case .OwningColumn.Name.ToLower()
                        'Case $"dgvpcclosed"
                        '    If Not DataGridViewEmployeeIdList.DisplayOnly Then
                        '        Dim selectedRow = DataGridViewEmployeeIdList.Rows(.RowIndex).DataBoundItem
                        '        RaiseEvent PcJournalCheckedEvent(selectedRow)
                        '    End If
                    End Select
                End With
            End If
        End Sub

        Public Property Active As Boolean Implements IEmployeeView.Active
        Public Property BankAccountNo As String Implements IEmployeeView.BankAccountNo
        Public Property BankIdNo As Short? Implements IEmployeeView.BankIdNo
        Public Property Balance As Decimal Implements IEmployeeView.Balance
        Public Property BirthDate As Date? Implements IEmployeeView.BirthDate
        Public Property CountryCode As String Implements IEmployeeView.CountryCode
        Public Property DepartmentIdNo As Short? Implements IEmployeeView.DepartmentIdNo
        Public Property DesignationIdNo As Short? Implements IEmployeeView.DesignationIdNo
        Public Property District As String Implements IEmployeeView.District
        Public Property DutyHours As Decimal Implements IEmployeeView.DutyHours
        Public Property Email As String Implements IEmployeeView.Email
        Public Property EmployeeCode As String Implements IEmployeeView.EmployeeCode
        Public Property EmployeeName As String Implements IEmployeeView.EmployeeName
        Public Property EmployeeNameAra As String Implements IEmployeeView.EmployeeNameAra
        Public Property Gender As String Implements IEmployeeView.Gender
        Public Property HiredDate As Date? Implements IEmployeeView.HiredDate
        Public Property Iban As String Implements IEmployeeView.Iban
        Public Property IdNo As Integer Implements IEmployeeView.IdNo
        Public Property MaritalStatus As String Implements IEmployeeView.MaritalStatus
        Public Property NationalIdNo As String Implements IEmployeeView.NationalIdNo
        Public Property NationalityCode As String Implements IEmployeeView.NationalityCode
        Public Property Notes As String Implements IEmployeeView.Notes
        Public Property OpeningBalance As Decimal Implements IEmployeeView.OpeningBalance
        Public Property PayCycleIdNo As Short? Implements IEmployeeView.PayCycleIdNo
        Public Property PayGroupIdNo As Short? Implements IEmployeeView.PayGroupIdNo
        Public Property PaymentMethod As Char Implements IEmployeeView.PaymentMethod
        Public Property PoBox As String Implements IEmployeeView.PoBox
        Public Property ProvinceState As String Implements IEmployeeView.ProvinceState
        Public Property ReleasedDate As Date? Implements IEmployeeView.ReleasedDate
        Public Property ReligionIdNo As Short? Implements IEmployeeView.ReligionIdNo
        Public Property Street As String Implements IEmployeeView.Street
        Public Property Title As String Implements IEmployeeView.Title
        Public Property TownCity As String Implements IEmployeeView.TownCity
        Public Property ZipCode As String Implements IEmployeeView.ZipCode
        Public Property PayFrequency As PayFrequencySelection Implements IEmployeeView.PayFrequency
        Public Property SponsorType As Char Implements IEmployeeView.SponsorType
        Public Property RegularEmployeeDeductions As List(Of EmployeePayElementView) Implements IEmployeeView.RegularEmployeeDeductions
        Public Property RegularEmployeeEarnings As List(Of EmployeePayElementView) Implements IEmployeeView.RegularEmployeeEarnings
        Public Property EmployeePhones As List(Of EmployeePhoneView) Implements IEmployeeView.EmployeePhones
        Public Property EmployeeLeaveCredits As List(Of EmployeeLeaveCreditView) Implements IEmployeeView.EmployeeLeaveCredits
        Public Property Picture As Image Implements IEmployeeView.Picture
    End Class

End Namespace