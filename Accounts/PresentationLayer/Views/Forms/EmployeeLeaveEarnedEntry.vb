Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Public Class EmployeeLeaveEarnedEntry
    Implements IEmployeeLeaveEarnedView

    Private ReadOnly _nfi As NumberFormatInfo
    Public Event DateValuesChanged() Implements IEmployeeLeaveEarnedView.DateValuesChanged
    Public Event EmployeeIdNoChanged(itemIdNo As Int16) Implements IEmployeeLeaveEarnedView.EmployeeIdNoChanged
    Public Event LeaveIdNoChanged(itemIdNo As Int16) Implements IEmployeeLeaveEarnedView.LeaveIdNoChanged

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FirstControl = cboLeaveIdNo
        _nfi = GlobalVariables.DefaultNumberFormatInfo

    End Sub


#Region "Fields"



    Public Property ApprovalNote As String Implements IEmployeeLeaveEarnedView.ApprovalNote
        Get
            Return txtApprovalNote.Text
        End Get
        Set(value As String)
            txtApprovalNote.Text = value
        End Set
    End Property


    Public Property Approved As Boolean Implements IEmployeeLeaveEarnedView.Approved
        Get
            Return chkApproved.Checked
        End Get
        Set(value As Boolean)
            chkApproved.Checked = value
        End Set
    End Property

    Public Property Disapproved As Boolean Implements IEmployeeLeaveEarnedView.Disapproved
        Get
            Return chkDisapproved.Checked
        End Get
        Set(value As Boolean)
            chkDisapproved.Checked = value
        End Set
    End Property


    Public Property ApprovedBy As Int32? Implements IEmployeeLeaveEarnedView.ApprovedBy
        Get
            Return cboApprovedBy.GetNullableValue(Of Int32)
        End Get
        Set
            cboApprovedBy.SetValue(Value)
        End Set
    End Property

    Public Property EnteredBy As Integer Implements IEmployeeLeaveEarnedView.EnteredBy
        Get
            Return cboenteredBy.GetNullableValue(Of Int32)
        End Get
        Set
            cboenteredBy.SetValue(Value)
        End Set
    End Property

    Public Property DateCreated As DateTime? Implements IEmployeeLeaveEarnedView.DateCreated
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

    Public Property EmployeeIdNo As Integer Implements IEmployeeLeaveEarnedView.EmployeeIdNo
        Get
            Return cboEmployeeIdNo.GetNullableValue(Of Int32)
        End Get
        Set
            cboEmployeeIdNo.SetValue(Value)
        End Set
    End Property

    Public Property EndDate As Date? Implements IEmployeeLeaveEarnedView.EndDate
        Get
            Return dtpEndDate.Value
        End Get
        Set
            dtpEndDate.Value = Value
        End Set
    End Property

    Public Property IdNo As Int32 Implements IEmployeeLeaveEarnedView.IdNo
        Get
            Return NumParser(Of Int32)(TxtIdNo.Text)
        End Get
        Set
            TxtIdNo.Text = Convert.ToString(Value)
        End Set
    End Property

    Public Property Reason As String Implements IEmployeeLeaveEarnedView.Reason
        Get
            Return txtReason.Text
        End Get
        Set(value As String)
            txtReason.Text = value
        End Set
    End Property

    Public Property StartDate As Date? Implements IEmployeeLeaveEarnedView.StartDate
        Get
            Return dtpStartDate.Value
        End Get
        Set
            dtpStartDate.Value = Value
        End Set
    End Property

    Public Property LeaveIdNo As Int16 Implements IEmployeeLeaveEarnedView.LeaveIdNo
        Get
            Return cboLeaveIdNo.GetNullableValue(Of Int16)
        End Get
        Set
            cboLeaveIdNo.SetValue(Value)
        End Set
    End Property

    Public Property DaysEarned As Decimal Implements IEmployeeLeaveEarnedView.DaysEarned
        Get
            Return NumParser(Of Decimal)(txtDaysEarned.Text)
        End Get
        Set
            txtDaysEarned.Text = FormatDecimalNumber(Value)
        End Set
    End Property

    Public Property UserIsASupervisor As Boolean Implements IEmployeeLeaveEarnedView.UserIsASupervisor
    Public Property UserIsASuperAdministrator As Boolean Implements IEmployeeLeaveEarnedView.UserIsASuperAdministrator
    Public Property UserHasHrAccess As Boolean Implements IEmployeeLeaveEarnedView.UserHasHrAccess
    Public Property UserHasHrManagerAccess As Boolean Implements IEmployeeLeaveEarnedView.UserHasHrManagerAccess


#End Region

    Protected Overrides Sub CreateMainFieldsDictionary()
        MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"Approved", chkApproved},
                {"ApprovedBy", cboApprovedBy},
                {"DaysEarned", txtDaysEarned},
                {"EnteredBy", cboenteredBy},
                {"EmployeeIdNo", cboEmployeeIdNo},
                {"EndDate", dtpEndDate},
                {"IdNo", TxtIdNo},
                {"LeaveIdNo", cboLeaveIdNo},
                {"Reason", txtReason},
                {"StartDate", dtpStartDate}
                }
    End Sub

    Private Sub dtpStartDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpStartDate.Validated
        If dtpEndDate.Value Is Nothing OrElse dtpEndDate.Value < dtpStartDate.Value Then
            dtpEndDate.Value = dtpStartDate.Value
        End If
        RaiseEvent DateValuesChanged()
    End Sub

    Private Sub dtpEndDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpEndDate.Validated
        If dtpStartDate.Value Is Nothing OrElse dtpStartDate.Value > dtpEndDate.Value Then
            dtpStartDate.Value = dtpEndDate.Value
        End If
        RaiseEvent DateValuesChanged()
    End Sub

    Private Sub cboEmployeeIdNo_ValueChanged(sender As Object, e As EventArgs) Handles cboEmployeeIdNo.Validated
        RaiseEvent EmployeeIdNoChanged(EmployeeIdNo)
    End Sub

    Private Sub cboLeaveidNo_ValueChanged(sender As Object, e As EventArgs) Handles cboLeaveIdNo.Validated
        RaiseEvent LeaveIdNoChanged(LeaveIdNo)
    End Sub


    Private Sub OnInputsTurnedOn() Handles MyBase.InputsTurnedOn
        SetFirstControl()
    End Sub

    Private Sub SetFirstControl()
        If UserIsASuperAdministrator Or UserHasHrManagerAccess OrElse UserHasHrAccess Then
            cboEmployeeIdNo.DisplayOnly = False
            FirstControl = cboEmployeeIdNo
        ElseIf UserIsASupervisor Then
            cboEmployeeIdNo.DisplayOnly = False
            FirstControl = cboEmployeeIdNo
        Else
            cboEmployeeIdNo.DisplayOnly = True
            FirstControl = cboLeaveIdNo
        End If
    End Sub


End Class