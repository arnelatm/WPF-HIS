Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Forms

    Public Class SalaryLoanScheduleEntry
        Implements ISalaryLoanScheduleView

        Private ReadOnly _nfi As NumberFormatInfo

        'Private ReadOnly _ea As New EventAggregator

        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            MainTableName = "SalaryLoanSchedule"
            SortOrderKey = "SalaryLoanScheduleName"
            _nfi = GlobalVariables.DefaultNumberFormatInfo
        End Sub

        Public Property Amount As Decimal Implements ISalaryLoanScheduleView.Amount
            Get
                Return TextBoxNumParser(Of Decimal)(SalaryLoanScheduleView.txtAmount)
                'Return Convert.ToDecimal(NumParser(Of Decimal)(SalaryLoanScheduleView.txtAmount.Text))
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
                If SalaryLoanScheduleView.txtPeriodicPayment.Text <> "" Then
                    Return Convert.ToDouble(SalaryLoanScheduleView.txtPeriodicPayment.Text)
                Else
                    Return 0
                End If
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

        Public Overloads Property Errors As List(Of String) Implements IViewNew.Errors

    End Class

End Namespace