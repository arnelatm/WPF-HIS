Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class SalaryLoanScheduleEntry
        Implements ISalaryLoanScheduleView

        Private ReadOnly _nfi As NumberFormatInfo

        Public Sub New()
            'MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = cboEmployeeIdNo
            _nfi = GlobalVariables.DefaultNumberFormatInfo
            '_presenter = New SalaryLoanSchedulePresenter(Me)
            FormTreeView.Visible = False
        End Sub

#Region "Fields"

        Public Property Amount As Decimal Implements ISalaryLoanScheduleView.Amount
            Get
                Return NumParser(Of Decimal)(txtAmount.Text)
            End Get
            Set
                txtAmount.Text = Value
            End Set
        End Property

        Public Property DateCreated As Date? Implements ISalaryLoanScheduleView.DateCreated
            Get
                Return txtDateCreated.Text
            End Get
            Set
                txtDateCreated.Text = Value
            End Set
        End Property

        Public Property EmployeeIdNo As Integer Implements ISalaryLoanScheduleView.EmployeeIdNo
            Get
                Return cboEmployeeIdNo.GetNullableValue(Of Int32)
            End Get
            Set
                cboEmployeeIdNo.SetValue(Value)
            End Set
        End Property

        Public Property IdNo As Integer Implements ISalaryLoanScheduleView.IdNo
            Get
                Return GlobalFunctions.NumParser(Of Int16)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property PeriodicPayment As Decimal Implements ISalaryLoanScheduleView.PeriodicPayment
            Get
                Return GlobalFunctions.NumParser(Of Decimal)(txtPeriodicPayment.Text)
            End Get
            Set
                txtPeriodicPayment.Text = Value
            End Set
        End Property

        Public Property StartDate As Date? Implements ISalaryLoanScheduleView.StartDate
            Get
                Return dtpStartDate.Value
            End Get
            Set
                dtpStartDate.Value = Value
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"Amount", txtAmount},
                {"EmployeeIdNo", cboEmployeeIdNo},
                {"IdNo", TxtIdNo},
                {"PeriodicPayment", txtPeriodicPayment},
                {"StartDate", dtpStartDate}
                }
        End Sub

        Protected Overrides Sub CreateDataSources()
            CreateDataSource("Employee", cboEmployeeIdNo)
        End Sub

    End Class

End Namespace