Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class HolidayAvailmentEntry
        Implements IHolidayAvailmentView

        Private ReadOnly _nfi As NumberFormatInfo
        Private _humanResourceUser As Boolean
        Private _approvalHistory As List(Of IHolidayAvailmentApprovalHistoryView)

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = cboEmployeeIdNo
            _nfi = GlobalVariables.DefaultNumberFormatInfo
            'FormTreeView.Visible = False
        End Sub

#Region "Fields"

        Public Property EnteredBy As Integer Implements IHolidayAvailmentView.EnteredBy
            Get
                Return cboenteredBy.GetNullableValue(Of Int32)
            End Get
            Set
                cboenteredBy.SetValue(Value)
            End Set
        End Property

        Public Property DateCreated As DateTime? Implements IHolidayAvailmentView.DateCreated
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

        Public Property EmployeeIdNo As Integer Implements IHolidayAvailmentView.EmployeeIdNo
            Get
                Return cboEmployeeIdNo.GetNullableValue(Of Int32)
            End Get
            Set
                cboEmployeeIdNo.SetValue(Value)
            End Set
        End Property

        Public Property IdNo As Int32 Implements IHolidayAvailmentView.IdNo
            Get
                Return NumParser(Of Int32)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property SupervisorIdNo As Int32 Implements IHolidayAvailmentView.SupervisorIdNo
        Public Property Disapprove As Boolean Implements IHolidayAvailmentView.Disapprove
        Public Property Approve As Boolean Implements IHolidayAvailmentView.Approve
        Public Property Users As List(Of Lookup.LookupData) Implements IHolidayAvailmentView.Users
        Public Property HolidayStatusList As List(Of Lookup.LookupData) Implements IHolidayAvailmentView.HolidayStatusList

        Public Property ApprovalHistory As List(Of IHolidayAvailmentApprovalHistoryView) Implements IHolidayAvailmentView.ApprovalHistory
            Get
                Return _approvalHistory
            End Get
            Set(value As List(Of IHolidayAvailmentApprovalHistoryView))
                _approvalHistory = value
                BindApprovalLeaveHistory()
            End Set
        End Property

        Public Property HolidayTransferIdNo As Integer Implements IHolidayAvailmentView.HolidayTransferIdNo
            Get
                Return cboHolidayTransferIdNo.GetNullableValue(Of Int32)
            End Get
            Set
                cboHolidayTransferIdNo.SetValue(Value)
            End Set
        End Property

        Public Property Status As String Implements IHolidayAvailmentView.Status
            Get
                Return cboStatus.GetNullableValue(Of Int32)
            End Get
            Set
                cboStatus.SetValue(Value)
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"EnteredBy", cboenteredBy},
                {"EmployeeIdNo", cboEmployeeIdNo},
                {"IdNo", TxtIdNo},
                {"HolidayTransferIdNo", cboHolidayTransferIdNo},
                {"LeaveStatus", cboStatus},
                {"StartDate", dtpAvailmentDate}
                }
        End Sub

        'Protected Overrides Sub CreateDataSources()
        '    CreateDataSource("Employee", cboEmployeeIdNo)
        '    CreateDataSource("User", cboenteredBy, {"IdNo", "UserName"})
        '    CreateDataSource("Leave", cboLeaveIdNo)
        '    CreateEnumDataSource(Of LeaveStatusSelection)(cboLeaveStatus)
        'End Sub

        'Private Sub dtpStartDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpAvailmentDate.Validated
        '    If dtpAvailmentDate.Value Is Nothing OrElse dtpAvailmentDate.Value < dtpAvailmentDate.Value Then
        '        dtpAvailmentDate.Value = dtpAvailmentDate.Value
        '    End If
        'End Sub

        'Private Sub dtpEndDate_ValueChanged(sender As Object, e As EventArgs)
        '    If dtpAvailmentDate.Value Is Nothing OrElse dtpAvailmentDate.Value > dtpEndDate.Value Then
        '        dtpAvailmentDate.Value = dtpEndDate.Value
        '    End If
        'End Sub

        'Public Overrides Sub UpdateViewDisplay(editMode As Boolean, addMode As Boolean, recordPositionNumber As Integer, targetIdNo As Integer, recordCount As Integer)
        Public Sub OnBeforeLoad() Handles MyBase.BeforeLoad
        End Sub

        Private Sub BindApprovalLeaveHistory()
            SuspendLayout()
            bsHolidayAvailmentApprovalHistory.DataSource = Nothing
            DataGridViewApprovalHistory.ShowInsertColumnWhenEditing = False
            DataGridViewApprovalHistory.Refresh()
            bsHolidayAvailmentApprovalHistory.DataSource = ApprovalHistory
            bsHolidayAvailmentApprovalHistory.AllowNew = True
            With DataGridViewApprovalHistory
                .AutoGenerateColumns = False
                .DataSource = bsHolidayAvailmentApprovalHistory
                .RemoveInsertColumn()
            End With
            With DataGridViewApprovalHistory.Columns
                dgvEnteredBy.DataSource = Users
                dgvEnteredBy.DisplayMember = "Name"
                dgvEnteredBy.ValueMember = "IdNo"
                dgvEnteredBy.DisplayStyleForCurrentCellOnly = True
                dgvEnteredBy.DisplayOnly = True
                'dgvLeaveStatus.DataSource = LeaveStatusList
                'dgvLeaveStatus.DisplayMember = "Name"
                'dgvLeaveStatus.ValueMember = "Code"
                'dgvLeaveStatus.DisplayStyleForCurrentCellOnly = True
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