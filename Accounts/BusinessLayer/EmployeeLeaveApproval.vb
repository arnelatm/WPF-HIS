' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class EmployeeLeaveApproval
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("LeaveIdNo"))
                AddRule(New ValidateRequired("EnteredBy"))
                AddRule(New ValidateRequired("Status"))
            End If
        End Sub

        Public Property DateCreated As DateTime?
        Public Property EnteredBy As Int32
        Public Property IdNo As Int32
        Public Property EmployeeLeaveIdNo As Int32
        Public Property ApprovalItemIdNo As Int32
        Public Property Notes As String
        Public Property Status As String
    End Class

End Namespace