Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class EmployeeLeaveEntry
        Implements IEmployeeLeaveView

        Private ReadOnly _nfi As NumberFormatInfo
        Private _humanResourceUser As Boolean
        Private _approvalHistory As List(Of EmployeeLeaveApprovalHistoryView)
        Private _holiday As Boolean

        Public Sub New(ByVal holiday As Boolean)
            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = cboEmployeeIdNo
            _nfi = GlobalVariables.DefaultNumberFormatInfo
            _holiday = holiday
            If holiday Then
                lblLeaveName.Visible = False
                cboLeaveIdNo.Visible = False
            Else
                lblHolidayName.Visible = False
                cboHolidayIdNo.Visible = False
            End If
            'FormTreeView.Visible = False
        End Sub

#Region "Fields"

        Public Property EnteredBy As Integer Implements IEmployeeLeaveView.EnteredBy
            Get
                Return cboenteredBy.GetNullableValue(Of Int32)
            End Get
            Set
                cboenteredBy.SetValue(Value)
            End Set
        End Property

        Public Property DateCreated As DateTime? Implements IEmployeeLeaveView.DateCreated
            Get
                Return Convert.ToDateTime(txtDateCreated.Text)
            End Get
            Set
                If Value.HasValue Then
                    txtDateCreated.Text = Value
                Else
                    txtDateCreated.Text = Date.Now().ToString()
                End If
            End Set
        End Property

        Public Property EmployeeIdNo As Integer Implements IEmployeeLeaveView.EmployeeIdNo
            Get
                Return cboEmployeeIdNo.GetNullableValue(Of Int32)
            End Get
            Set
                cboEmployeeIdNo.SetValue(Value)
            End Set
        End Property

        Public Property EndDate As DateTime Implements IEmployeeLeaveView.EndDate
            Get
                Return dtpEndDate.Value
            End Get
            Set
                dtpEndDate.Value = Value
            End Set
        End Property

        Public Property FullDay As Boolean Implements IEmployeeLeaveView.FullDay
            Get
                Return chkFullDay.Checked
            End Get
            Set(value As Boolean)
                chkFullDay.Checked = value
            End Set
        End Property

        Public Property IdNo As Int32 Implements IEmployeeLeaveView.IdNo
            Get
                Return NumParser(Of Int32)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property LeaveReason As String Implements IEmployeeLeaveView.LeaveReason
            Get
                Return txtLeaveReason.Text
            End Get
            Set(value As String)
                txtLeaveReason.Text = value
            End Set
        End Property

        Public Property LeaveStatus As String Implements IEmployeeLeaveView.LeaveStatus
            Get
                Return cboLeaveStatus.GetValue()
            End Get
            Set
                cboLeaveStatus.SetValue(Value)
            End Set
        End Property

        Public Property StartDate As DateTime Implements IEmployeeLeaveView.StartDate
            Get
                Return dtpStartDate.Value
            End Get
            Set
                dtpStartDate.Value = Value
            End Set
        End Property

        Public Property LeaveIdNo As Int16 Implements IEmployeeLeaveView.LeaveIdNo
            Get
                Return cboLeaveIdNo.GetNullableValue(Of Int16)
            End Get
            Set
                cboLeaveIdNo.SetValue(Value)
            End Set
        End Property

        Public Property HolidayIdNo As Int16 Implements IEmployeeLeaveView.HolidayIdNo
            Get
                Return cboHolidayIdNo.GetNullableValue(Of Int16)
            End Get
            Set
                cboHolidayIdNo.SetValue(Value)
            End Set
        End Property

        Public Property SupervisorIdNo As Int32 Implements IEmployeeLeaveView.SupervisorIdNo
        Public Property Disapprove As Boolean Implements IEmployeeLeaveView.Disapprove
        Public Property ApprovalNote As String Implements IEmployeeLeaveView.ApprovalNote
        Public Property Approve As Boolean Implements IEmployeeLeaveView.Approve
        Public Property Users As List(Of Lookup.LookupData) Implements IEmployeeLeaveView.Users
        Public Property LeaveStatusList As List(Of Lookup.LookupData) Implements IEmployeeLeaveView.LeaveStatusList

        Public Property ApprovalHistory As List(Of EmployeeLeaveApprovalHistoryView) Implements IEmployeeLeaveView.ApprovalHistory
            Get
                Return _approvalHistory
            End Get
            Set(value As List(Of EmployeeLeaveApprovalHistoryView))
                _approvalHistory = value
                BindApprovalLeaveHistory()
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"EnteredBy", cboenteredBy},
                {"EmployeeIdNo", cboEmployeeIdNo},
                {"EndDate", dtpEndDate},
                {"FullDay", chkFullDay},
                {"HolidayIdNo", cboHolidayIdNo},
                {"IdNo", TxtIdNo},
                {"LeaveIdNo", cboLeaveIdNo},
                {"LeaveReason", txtLeaveReason},
                {"LeaveStatus", cboLeaveStatus},
                {"StartDate", dtpStartDate}
                }
        End Sub

        'Protected Overrides Sub CreateDataSources()
        '    CreateDataSource("Employee", cboEmployeeIdNo)
        '    CreateDataSource("User", cboenteredBy, {"IdNo", "UserName"})
        '    CreateDataSource("Leave", cboLeaveIdNo)
        '    CreateEnumDataSource(Of LeaveStatusSelection)(cboLeaveStatus)
        'End Sub

        Private Sub dtpStartDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpStartDate.Validated
            If dtpEndDate.Value Is Nothing OrElse dtpEndDate.Value < dtpStartDate.Value Then
                dtpEndDate.Value = dtpStartDate.Value
            End If
        End Sub

        Private Sub dtpEndDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpEndDate.Validated
            If dtpStartDate.Value Is Nothing OrElse dtpStartDate.Value > dtpEndDate.Value Then
                dtpStartDate.Value = dtpEndDate.Value
            End If
        End Sub

        Private Sub chkFullDay_CheckedChanged(sender As Object, e As EventArgs) Handles chkFullDay.CheckedChanged
            If chkFullDay.Checked Then
                dtpStartDate.ShowTime = False
                dtpEndDate.ShowTime = False
            Else
                dtpStartDate.ShowTime = True
                dtpEndDate.ShowTime = True
            End If
        End Sub

        'Public Overrides Sub UpdateViewDisplay(editMode As Boolean, addMode As Boolean, recordPositionNumber As Integer, targetIdNo As Integer, recordCount As Integer)
        Public Sub OnBeforeLoad() Handles MyBase.BeforeLoad
            If FullDay Then
                dtpEndDate.ShowTime = False
                dtpStartDate.ShowTime = False
            Else
                dtpEndDate.ShowTime = True
                dtpStartDate.ShowTime = True
            End If
        End Sub

        Private Sub BtnHistory_ClickButtonArea(Sender As Object, e As MouseEventArgs)

        End Sub

        Private Sub BindApprovalLeaveHistory()
            SuspendLayout()
            bsEmployeeLeaveApprovalHistory.DataSource = Nothing
            DataGridViewApprovalHistory.ShowInsertColumnWhenEditing = False
            DataGridViewApprovalHistory.Refresh()
            bsEmployeeLeaveApprovalHistory.DataSource = ApprovalHistory
            bsEmployeeLeaveApprovalHistory.AllowNew = True
            With DataGridViewApprovalHistory
                .AutoGenerateColumns = False
                .DataSource = bsEmployeeLeaveApprovalHistory
                .RemoveInsertColumn()
            End With
            With DataGridViewApprovalHistory.Columns
                dgvApprovedBy.DataSource = Users
                dgvApprovedBy.DisplayMember = "Name"
                dgvApprovedBy.ValueMember = "IdNo"
                dgvApprovedBy.DisplayStyleForCurrentCellOnly = True
                dgvLeaveStatus.DataSource = LeaveStatusList
                dgvLeaveStatus.DisplayOnly = True
                dgvLeaveStatus.DisplayMember = "Name"
                dgvLeaveStatus.ValueMember = "Code"
                dgvLeaveStatus.DisplayStyleForCurrentCellOnly = True
                dgvApprovedBy.DisplayOnly = True
                dgvApprovalIdNo.DisplayOnly = True
                dgvApprovalDate.DisplayOnly = True
                dgvApprovedBy.DisplayOnly = True
                dgvItemIdNo.DisplayOnly = True
            End With
            ResumeLayout()
        End Sub

    End Class

End Namespace