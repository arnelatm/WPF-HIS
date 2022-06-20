Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class HolidayEntry
        Implements IHolidayView

        Private ReadOnly _nfi As NumberFormatInfo

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = cboLeaveIdNo
            _nfi = GlobalVariables.DefaultNumberFormatInfo
            'FormTreeView.Visible = False
        End Sub

#Region "Fields"

        Public Property EnteredBy As Int32 Implements IHolidayView.EnteredBy
            Get
                Return cboEnteredBy.GetNullableValue(Of Int32)
            End Get
            Set
                cboEnteredBy.SetValue(Value)
            End Set
        End Property

        Public Property DateCreated As DateTime? Implements IHolidayView.DateCreated
            Get
                If String.IsNullOrEmpty(txtDateCreated.Text) Then
                    Return Now()
                End If
                Return Convert.ToDateTime(txtDateCreated.Text)
            End Get
            Set(value As DateTime?)
                If value Is Nothing Then
                    txtDateCreated.Text = Nothing
                Else
                    txtDateCreated.Text = String.Format(CultureInfo.CurrentCulture, "{0:g}", value)
                End If
            End Set
        End Property

        Public Property LeaveIdNo As Int16 Implements IHolidayView.LeaveIdNo
            Get
                Return cboLeaveIdNo.GetNullableValue(Of Int16)
            End Get
            Set
                cboLeaveIdNo.SetValue(Value)
            End Set
        End Property

        Public Property IdNo As Integer Implements IHolidayView.IdNo
            Get
                Return NumParser(Of Int32)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        'Public Property PayrollIdNo As Int32 Implements IHolidayView.PayrollIdNo
        '    Get
        '        Return cboPayrollIdNo.GetNullableValue(Of Int32)
        '    End Get
        '    Set
        '        cboPayrollIdNo.SetValue(Value)
        '    End Set
        'End Property

        'Public Property PayrollName As String Implements IHolidayView.PayrollName
        '    Get
        '        Return txtPayrollName.Text
        '    End Get
        '    Set(value As String)
        '        txtPayrollName.Text = value
        '    End Set
        'End Property

        'Public Property PayrollCode As String Implements IHolidayView.PayrollCode
        '    Get
        '        Return txtPayrollCode.Text
        '    End Get
        '    Set(value As String)
        '        txtPayrollCode.Text = value
        '    End Set
        'End Property

        Public Property DateEnd As Date Implements IHolidayView.DateEnd
            Get
                Return Convert.ToDateTime(dtpDateEnd.Text)
            End Get
            Set
                dtpDateEnd.Text = Value.ToShortDateString()
            End Set
        End Property

        'Public Property PayrollStartDate As Date Implements IHolidayView.PayrollStartDate
        '    Get
        '        Return Convert.ToDateTime(txtPayrollStartDate.Text)
        '    End Get
        '    Set
        '        txtPayrollStartDate.Text = Value.ToShortDateString()
        '    End Set
        'End Property

        'Public Property PayrollEndDate As Date Implements IHolidayView.PayrollEndDate
        '    Get
        '        Return Convert.ToDateTime(txtPayrollEndDate.Text)
        '    End Get
        '    Set
        '        txtPayrollEndDate.Text = Value.ToShortDateString()
        '    End Set
        'End Property

        Public Property DateStart As Date Implements IHolidayView.DateStart
            Get
                Return Convert.ToDateTime(dtpDateStart.Text)
            End Get
            Set(value As Date)
                dtpDateStart.Text = value.ToShortDateString()
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
               {{"DateCreated", txtDateCreated},
                {"DateEnd", dtpDateEnd},
                {"DateStart", dtpDateStart},
                {"EnteredBy", cboEnteredBy},
                {"IdNo", TxtIdNo},
                {"LeaveIdNo", cboLeaveIdNo}
               }
        End Sub

        'Protected Overrides Sub CreateMainFieldsDictionary()
        '    MainFieldsDictionary = New Dictionary(Of String, Object) From
        '       {{"DateCreated", txtDateCreated},
        '        {"DateEnd", dtpDateEnd},
        '        {"DateStart", dtpDateStart},
        '        {"EnteredBy", cboEnteredBy},
        '        {"IdNo", TxtIdNo},
        '        {"LeaveIdNo", cboLeaveIdNo},
        '        {"PayrollCode", txtPayrollCode},
        '        {"PayrollIdNo", cboPayrollIdNo},
        '        {"PayrollStartDate", txtPayrollStartDate},
        '        {"PayrollEndDate", txtPayrollEndDate}
        '       }
        'End Sub

        Private Sub cboLeaveIdNo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboLeaveIdNo.SelectionChangeCommitted

        End Sub

    End Class

End Namespace