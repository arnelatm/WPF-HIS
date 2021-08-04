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
                Return dtpStartDate.Value
            End Get
            Set
                dtpStartDate.Value = Value
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

        Public Property IdNo As Integer Implements IEmployeeLeaveView.IdNo
            Get
                Return NumParser(Of Int16)(TxtIdNo.Text)
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

        Public Property LeaveStatus As Char Implements IEmployeeLeaveView.LeaveStatus

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
                Return cboLeaveIdNo.GetNullableValue(Of Int32)
            End Get
            Set
                cboLeaveIdNo.SetValue(Value)
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"EmployeeIdNo", cboEmployeeIdNo},
                {"IdNo", TxtIdNo},
                {"LeaveIdNo", cboLeaveIdNo},
                {"LeaveReason", txtLeaveReason},
                {"LeaveStatus", cboLeaveStatus},
                {"FullDay", chkFullDay},
                {"StartDate", dtpStartDate},
                {"EndDate", dtpEndDate}
                }
        End Sub

        Protected Overrides Sub CreateDataSources()
            CreateDataSource("Employee", cboEmployeeIdNo)
            CreateDataSource("Leave", cboLeaveIdNo)
            CreateEnumDataSource(Of LeaveStatusSelection)(cboLeaveStatus)
        End Sub

    End Class

End Namespace