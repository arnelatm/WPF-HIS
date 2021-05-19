Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class SalaryLoanScheduleView
        Implements ISalaryLoanScheduleView

        Public Property MainTableName As String = "SalaryLoanSchedule"
        Private ReadOnly _eventAggregator As New EventAggregator

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.

        End Sub

        Public Function GetEventAggregator() As EventAggregator Implements IViewNew.GetEventAggregator
            Return _eventAggregator
        End Function

        Public Property Amount As Decimal Implements ISalaryLoanScheduleView.Amount
            Get
                If txtAmount.Text <> "" Then
                    Return Convert.ToDouble(txtAmount.Text)
                Else
                    Return 0
                End If
            End Get
            Set
                txtAmount.Text = Value
            End Set
        End Property

        Public Property DateCreated As Date? Implements ISalaryLoanScheduleView.DateCreated

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
                If txtPeriodicPayment.Text <> "" Then
                    Return Convert.ToDouble(txtPeriodicPayment.Text)
                Else
                    Return 0
                End If
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

        Public Property Errors As List(Of String) Implements IViewNew.Errors

    End Class

End Namespace