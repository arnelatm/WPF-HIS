' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class EmployeeLeaveApprovalItem
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("LeaveIdNo"))
                AddRule(New ValidateRequired("Status"))
            End If
        End Sub

        Public Property IdNo As Int32
        Public Property EmployeeLeaveIdNo As Int16
        Public Property Notes As String
        Public Property Status As String
    End Class

End Namespace