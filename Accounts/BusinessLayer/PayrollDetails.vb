Public Class PayrollDetails
    Inherits AATM.BusinessLayer.BusinessObject

    ' ** Enterprise Design Pattern: Identity field pattern
    Public Sub New()
        ' establish business rules
        If GetRules().Count() = 0 Then
            AddRule(New ValidateRequired("PayPeriodName"))
            AddRule(New ValidateRequired("PayPeriodCode"))
        End If
    End Sub

    Public Property IdNo As Int32
    Public Property PayPeriodIdNo As Int16
    Public Property EmployeeIdNo As Int16
    Public Property EmployeeIdNo As Int16

End Class
