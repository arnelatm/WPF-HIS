Imports System.Globalization
Imports AATM.Accounts.Interfaces
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views
Imports Autofac

Namespace PresentationLayer.Views.Forms

    Public Class SalaryLoanScheduleEntry
        Implements ISalaryLoanScheduleView

        Private ReadOnly _nfi As NumberFormatInfo
        Private _presenter

        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            _nfi = GlobalVariables.DefaultNumberFormatInfo
            _presenter = New SalaryLoanSchedulePresenter(Me)
        End Sub

#Region "Fields"

        Public Property Amount As Decimal Implements ISalaryLoanScheduleView.Amount
            Get
                Return NumParser(Of Decimal)(SalaryLoanScheduleView.txtAmount.Text)
            End Get
            Set
                SalaryLoanScheduleView.txtAmount.Text = Value
            End Set
        End Property

        Public Property DateCreated As Date? Implements ISalaryLoanScheduleView.DateCreated

        Public Property EmployeeIdNo As Integer Implements ISalaryLoanScheduleView.EmployeeIdNo
            Get
                Return SalaryLoanScheduleView.cboEmployeeIdNo.GetNullableValue(Of Int32)
            End Get
            Set
                SalaryLoanScheduleView.cboEmployeeIdNo.SetValue(Value)
            End Set
        End Property

        Public Property IdNo As Integer Implements ISalaryLoanScheduleView.IdNo
            Get
                Return GlobalFunctions.NumParser(Of Int16)(SalaryLoanScheduleView.TxtIdNo.Text)
            End Get
            Set
                SalaryLoanScheduleView.TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property PeriodicPayment As Decimal Implements ISalaryLoanScheduleView.PeriodicPayment
            Get
                Return GlobalFunctions.NumParser(Of Decimal)(SalaryLoanScheduleView.txtPeriodicPayment.Text)
            End Get
            Set
                SalaryLoanScheduleView.txtPeriodicPayment.Text = Value
            End Set
        End Property

        Public Property StartDate As Date? Implements ISalaryLoanScheduleView.StartDate
            Get
                Return SalaryLoanScheduleView.dtpStartDate.Value
            End Get
            Set
                SalaryLoanScheduleView.dtpStartDate.Value = Value
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"Amount", SalaryLoanScheduleView.txtAmount},
                {"EmployeeIdNo", SalaryLoanScheduleView.cboEmployeeIdNo},
                {"IdNo", SalaryLoanScheduleView.TxtIdNo},
                {"PeriodicPayment", SalaryLoanScheduleView.txtPeriodicPayment},
                {"StartDate", SalaryLoanScheduleView.dtpStartDate}
                }
        End Sub

        Protected Overrides Sub CreateDataSources()
            If Ea IsNot Nothing Then
                Ea.PublishEvent(New GetDataSource("Employee", SalaryLoanScheduleView.cboEmployeeIdNo))
            End If
        End Sub

    End Class

End Namespace