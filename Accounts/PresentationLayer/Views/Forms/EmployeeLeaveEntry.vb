Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class EmployeeLeaveEntry
        Implements IEmployeeLeaveView

        Private ReadOnly _nfi As NumberFormatInfo

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = cboEmployeeIdNo
            _nfi = GlobalVariables.DefaultNumberFormatInfo
            'FormTreeView.Visible = False
        End Sub

#Region "Fields"

        Public Property AppliedBy As Integer Implements IEmployeeLeaveView.AppliedBy
            Get
                Return cboAppliedBy.GetNullableValue(Of Int32)
            End Get
            Set
                cboAppliedBy.SetValue(Value)
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

#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"AppliedBy", cboAppliedBy},
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

        Protected Overrides Sub CreateDataSources()
            CreateDataSource("Employee", cboEmployeeIdNo)
            CreateDataSource("User", cboAppliedBy, {"IdNo", "UserName"})
            CreateDataSource("Leave", cboLeaveIdNo)
            CreateEnumDataSource(Of LeaveStatusSelection)(cboLeaveStatus)
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

    End Class

End Namespace