Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Public Class EmployeeLeaveEarnedEntry
    Implements IEmployeeLeaveEarnedView

    Private ReadOnly _nfi As NumberFormatInfo
    Private _humanResourceUser As Boolean
    Public Event DateValuesChanged(itemIdNo As Int16) Implements IEmployeeLeaveEarnedView.DateValuesChanged
    Public Event LeaveIdNoChanged(itemIdNo As Int16) Implements IEmployeeLeaveEarnedView.LeaveIdNoChanged

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FirstControl = cboEmployeeIdNo
        _nfi = GlobalVariables.DefaultNumberFormatInfo

    End Sub


#Region "Fields"

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


#End Region

    Protected Overrides Sub CreateMainFieldsDictionary()
        MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
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
        RaiseEvent DateValuesChanged(IdNo)
    End Sub

    Private Sub dtpEndDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpEndDate.Validated
        If dtpStartDate.Value Is Nothing OrElse dtpStartDate.Value > dtpEndDate.Value Then
            dtpStartDate.Value = dtpEndDate.Value
        End If
        RaiseEvent DateValuesChanged(IdNo)
    End Sub

    Private Sub cboLeaveidNo_ValueChanged(sender As Object, e As EventArgs) Handles cboEmployeeIdNo.Validated, cboLeaveIdNo.Validated
        RaiseEvent LeaveIdNoChanged(LeaveIdNo)
    End Sub


End Class