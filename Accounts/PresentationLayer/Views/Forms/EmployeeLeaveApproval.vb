Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Events

Public Class EmployeeLeaveApproval
    Implements IEmployeeLeaveApprovalView

    Private _employeeLeaveList As New List(Of IEmployeeLeaveView)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Property EmployeeLeaveList As List(Of IEmployeeLeaveView) Implements IEmployeeLeaveApprovalView.EmployeeLeaveList
        Get
            Return _employeeLeaveList
        End Get
        Set
            _employeeLeaveList = Value
            BindEmployeeLeaveList()
        End Set
    End Property


    Private Sub BindEmployeeLeaveList()
        SuspendLayout()
        bsEmployeeLeave.DataSource = Nothing
        DataGridViewEmployeeLeave.Refresh()
        bsEmployeeLeave.DataSource = EmployeeLeaveList
        bsEmployeeLeave.AllowNew = True
        With DataGridViewEmployeeLeave
            .AutoGenerateColumns = False
            .DataSource = bsEmployeeLeave
        End With
        With DataGridViewEmployeeLeave.Columns
            dgvEmployeeIdNo.DisplayOnly = True
            dgvEndDate.DisplayOnly = True
            dgvLeaveReason.DisplayOnly = True
            dgvFullDay.DisplayOnly = True
            dgvStartDate.DisplayOnly = True
        End With
        ResumeLayout()
    End Sub

    Private Sub EmployeeIdPrinting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridViewEmployeeLeave.Refresh()
        BindEmployeeLeaveList()
    End Sub

    Private Sub EmployeeLeaveApproval_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        bsEmployeeLeave.ResetBindings(True)
        PublishClickedButton(ButtonClicked.Edit)
    End Sub
End Class
