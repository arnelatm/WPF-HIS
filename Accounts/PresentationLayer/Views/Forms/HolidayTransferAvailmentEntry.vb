Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class HolidayTransferAvailmentEntry
        Implements IHolidayTransferAvailmentView

        Private ReadOnly _nfi As NumberFormatInfo
        Private _humanResourceUser As Boolean
        Private _approvalHistory As List(Of IHolidayTransferAvailmentApprovalHistoryView)

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = cboEmployeeIdNo
            _nfi = GlobalVariables.DefaultNumberFormatInfo
            'FormTreeView.Visible = False
        End Sub

#Region "Fields"

        Public Property EnteredBy As Integer Implements IHolidayTransferAvailmentView.EnteredBy
            Get
                Return cboenteredBy.GetNullableValue(Of Int32)
            End Get
            Set
                cboenteredBy.SetValue(Value)
            End Set
        End Property

        Public Property DateCreated As DateTime? Implements IHolidayTransferAvailmentView.DateCreated
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

        Public Property EmployeeIdNo As Integer Implements IHolidayTransferAvailmentView.EmployeeIdNo
            Get
                Return cboEmployeeIdNo.GetNullableValue(Of Int32)
            End Get
            Set
                cboEmployeeIdNo.SetValue(Value)
            End Set
        End Property

        Public Property IdNo As Int32 Implements IHolidayTransferAvailmentView.IdNo
            Get
                Return NumParser(Of Int32)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property SupervisorIdNo As Int32 Implements IHolidayTransferAvailmentView.SupervisorIdNo
        Public Property Disapprove As Boolean Implements IHolidayTransferAvailmentView.Disapprove
        Public Property ApprovalNote As String Implements IHolidayTransferAvailmentView.ApprovalNote
        Public Property Approve As Boolean Implements IHolidayTransferAvailmentView.Approve
        Public Property Users As List(Of Lookup.LookupData) Implements IHolidayTransferAvailmentView.Users
        Public Property LeaveStatusList As List(Of Lookup.LookupData) Implements IHolidayTransferAvailmentView.LeaveStatusList

        Public Property ApprovalHistory As List(Of IHolidayTransferAvailmentApprovalHistoryView) Implements IHolidayTransferAvailmentView.ApprovalHistory
            Get
                Return _approvalHistory
            End Get
            Set(value As List(Of IHolidayTransferAvailmentApprovalHistoryView))
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

        Private Sub BtnHistory_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnHistory.ClickButtonArea

        End Sub

        Private Sub BindApprovalLeaveHistory()
            SuspendLayout()
            bsHolidayTransferAvailmentApprovalHistory.DataSource = Nothing
            DataGridViewApprovalHistory.ShowInsertColumnWhenEditing = False
            DataGridViewApprovalHistory.Refresh()
            bsHolidayTransferAvailmentApprovalHistory.DataSource = ApprovalHistory
            bsHolidayTransferAvailmentApprovalHistory.AllowNew = True
            With DataGridViewApprovalHistory
                .AutoGenerateColumns = False
                .DataSource = bsHolidayTransferAvailmentApprovalHistory
                .RemoveInsertColumn()
            End With
            With DataGridViewApprovalHistory.Columns
                dgvEnteredBy.DataSource = Users
                dgvEnteredBy.DisplayMember = "Name"
                dgvEnteredBy.ValueMember = "IdNo"
                dgvEnteredBy.DisplayStyleForCurrentCellOnly = True
                dgvEnteredBy.DisplayOnly = True
                dgvLeaveStatus.DataSource = LeaveStatusList
                dgvLeaveStatus.DisplayMember = "Name"
                dgvLeaveStatus.ValueMember = "Code"
                dgvLeaveStatus.DisplayStyleForCurrentCellOnly = True
                dgvApprovalIdNo.DisplayOnly = True
                dgvDateCreated.DisplayOnly = True
                dgvEnteredBy.DisplayOnly = True
                dgvItemIdNo.DisplayOnly = True
                dgvNote.DisplayOnly = True
                dgvLeaveStatus.DisplayOnly = True
            End With
            ResumeLayout()
        End Sub

    End Class

End Namespace