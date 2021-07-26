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

        Public Property IdNo As Int32
        Public Property PayrollIdNo As Int16
        Public Property EmployeeCode As String
        Public Property EmployeeIdNo As Int32
        Public Property EmployeeName As String
        Public Property EmployeeNameAra As String
        Public Property PayrollEarnings As List(Of PayrollPayElement)
        Public Property PayrollDeductions As List(Of PayrollPayElement)
        Public Property StartDate As Date
        Public Property EndDate As Date
        Public Property PayPeriodName As String
        Public Property PayPeriodNameAra As String
    End Class

End Namespace