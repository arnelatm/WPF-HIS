Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IPayrollDetailView
        Inherits IView

        Property BankTransfer As Boolean
        Property EmployeeCode As String
        Property EmployeeIdNo As Int32
        Property EndDate As Date
        Property IdNo As Int32
        Property PayPeriodName As String
        Property PayPeriodNameAra As String
        Property PayrollDeductions As List(Of PayrollPayElementView)
        Property PayrollEarnings As List(Of PayrollPayElementView)
        Property PaymentMethod As String
        Property SponsorType As String
        Property PayrollIdNo As Int16
        Property StartDate As Date
        Property PayEarningsByCode
        Property PayDeductionsByCode
        Property Selected As Boolean

    End Interface

End Namespace