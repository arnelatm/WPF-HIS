Namespace BusinessLayer

    Public Class PayrollDetail
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            'If GetRules().Count() = 0 Then
            '    AddRule(New ValidateRequired("PayrollName"))
            '    AddRule(New ValidateRequired("PayrollCode"))
            'End If
        End Sub

        Public Property BankTransfer As Boolean
        Public Property EmployeeCode As String
        Public Property EmployeeIdNo As Int32
        Public Property EmployeeName As String
        Public Property EmployeeNameAra As String
        Public Property EndDate As Date
        Public Property IdNo As Int32
        Public Property PayPeriodName As String
        Public Property PayPeriodNameAra As String
        Public Property PayrollDeductions As List(Of PayrollPayElement)
        Public Property PayrollEarnings As List(Of PayrollPayElement)
        Public Property PaymentMethod As String
        Public Property SponsorType As String
        Public Property PayrollIdNo As Int16
        Public Property Posted As Boolean
        Public Property StartDate As Date
    End Class

End Namespace