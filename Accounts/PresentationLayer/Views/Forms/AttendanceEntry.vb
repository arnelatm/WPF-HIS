Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class AttendanceEntry
        Implements IAttendanceView

        Public Sub New()

            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()

            MainTableName = "Attendance"
            SortOrderKey = "AttendanceName"
            FirstControl = TxtIdNo
            PresenterObj = New AttendancePresenter(Me)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)

        End Sub

#Region "Fields"

        Public Property IdNo As Int32 Implements IAttendanceView.IdNo
            Get
                Return NumParser(Of Int16)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property DaysPresent As Decimal Implements IAttendanceView.DaysPresent
            Get
                Return NumParser(Of Decimal)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property DaysAbsentWithPay As Decimal Implements IAttendanceView.DaysAbsentWithPay
            Get
                Return NumParser(Of Decimal)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property DaysAbsentWithoutPay As Decimal Implements IAttendanceView.DaysAbsentWithoutPay
            Get
                Return NumParser(Of Decimal)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property DaysOff As Decimal Implements IAttendanceView.DaysOff
            Get
                Return NumParser(Of Decimal)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property EmployeeIdNo As Integer Implements IAttendanceView.EmployeeIdNo
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As Integer)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property EmployeeName As String Implements IAttendanceView.EmployeeName
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property EmployeeNameAra As String Implements IAttendanceView.EmployeeNameAra
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property



#End Region

        Protected Overrides Sub CreateFieldsDictionary()
            'FieldsDictionary = New Dictionary(Of String, Object) From
            '    {
            '    {"AttendanceCode", txtAttendanceCode},
            '    {"AttendanceName", txtAttendanceName},
            '    {"AttendanceNameAra", txtAttendanceNameAra},
            '    {"AttendanceAllowed", txtAttendanceAllowed},
            '    {"PaidPercent", txtPaidPercent},
            '    {"Cumulative", chkCumulative},
            '    {"MaxCarryOver", txtMaxCarryOver},
            '    {"MaxLimit", txtMaxLimit},
            '    {"IdNo", TxtIdNo},
            '    {"Notes", txtNotes}
            '    }
        End Sub

    End Class

End Namespace