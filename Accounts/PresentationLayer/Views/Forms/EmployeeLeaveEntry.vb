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
        Private _holidayLeave As Boolean
        Private _isASupervisor As Boolean

        Public Sub New(ByVal holidayLeave As Boolean)
            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = cboLeaveIdNo
            _nfi = GlobalVariables.DefaultNumberFormatInfo
            _holidayLeave = holidayLeave
            If holidayLeave Then
                Text = MessagingLibrary.Messaging.TranslateCaption("Employee Holiday Leave Maintenance Form")
                lblLeaveName.Visible = False
                cboLeaveIdNo.Visible = False
            Else
                Text = MessagingLibrary.Messaging.TranslateCaption("Employee Non-Holiday Leave Maintenance Form")
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

        Public Property Reason As String Implements IEmployeeLeaveView.Reason
            Get
                Return txtReason.Text
            End Get
            Set(value As String)
                txtReason.Text = value
            End Set
        End Property

        Public Property Status As String Implements IEmployeeLeaveView.Status
            Get
                Return cboStatus.GetValue()
            End Get
            Set
                cboStatus.SetValue(Value)
                'Dim status As String = value
                'If status Is Nothing Then
                '    status = "0"
                'End If
                'cboStatus.SetValue(status)
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

        Public Property SupervisorIdNo As Int32? Implements IEmployeeLeaveView.SupervisorIdNo
        Public Property Disapprove As Boolean Implements IEmployeeLeaveView.Disapprove
        Public Property ApprovalNote As String Implements IEmployeeLeaveView.ApprovalNote
        Public Property Approve As Boolean Implements IEmployeeLeaveView.Approve
        Public Property Users As DataTable Implements IEmployeeLeaveView.Users
        Public Property StatusList As DataTable Implements IEmployeeLeaveView.StatusList

        Public Property ApprovalHistory As List(Of EmployeeLeaveApprovalHistoryView) Implements IEmployeeLeaveView.ApprovalHistory
            Get
                Return _approvalHistory
            End Get
            Set(value As List(Of EmployeeLeaveApprovalHistoryView))
                _approvalHistory = value
                BindApprovalLeaveHistory()
            End Set
        End Property

        Public Property Holiday As Boolean Implements IEmployeeLeaveView.Holiday

        Public Property UserIsASupervisor As Boolean Implements IEmployeeLeaveView.UserIsASupervisor
            Get
                Return _isASupervisor
            End Get
            Set(value As Boolean)
                _isASupervisor = value
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
                {"Reason", txtReason},
                {"Status", cboStatus},
                {"StartDate", dtpStartDate}
                }
        End Sub

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
            DataGridViewApprovalHistory.Refresh()
            bsEmployeeLeaveApprovalHistory.DataSource = ApprovalHistory
            bsEmployeeLeaveApprovalHistory.AllowNew = True
            With DataGridViewApprovalHistory
                .AutoGenerateColumns = False
                .DataSource = bsEmployeeLeaveApprovalHistory
            End With
            With DataGridViewApprovalHistory.Columns
                dgvStatus.DataSource = StatusList
                dgvStatus.DisplayOnly = True
                dgvStatus.DisplayMember = "Name"
                dgvStatus.ValueMember = "Code"
                dgvStatus.DisplayStyleForCurrentCellOnly = True
                dgvApprovalIdNo.DisplayOnly = True
                dgvApprovalDate.DisplayOnly = True
                dgvItemIdNo.DisplayOnly = True
            End With
            ResumeLayout()
        End Sub

        Protected Sub OnAfterUpdateView() Handles MyBase.AfterUpdateView
            bsEmployeeLeaveApprovalHistory.ResetBindings(False)
            bsEmployeeLeaveApproval.ResetBindings(False)
        End Sub

        Private Sub OnFormShown(sender As Object, e As EventArgs) Handles MyBase.Shown
            If UserIsASuperAdministrator() Or UserIsASupervisor Then
                cboEmployeeIdNo.DisplayOnly = False
                FirstControl = cboEmployeeIdNo
            End If
        End Sub

    End Class

End Namespace