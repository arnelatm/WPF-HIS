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
                AddRule(New ValidateRequired("ApprovedBy"))
                AddRule(New ValidateRequired("Status"))
            End If
        End Sub

        Public Property DateCreated As DateTime?
        Public Property ApprovedBy As Int32
        Public Property IdNo As Int32
        Public Property EmployeeLeaveApprovalItems As List(Of EmployeeLeaveApprovalItem)

    End Class


    Public Class EmployeeLeaveEarnedApproval
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("ApprovedBy"))
                AddRule(New ValidateRequired("Status"))
            End If
        End Sub

        Public Property DateCreated As DateTime?
        Public Property ApprovedBy As Int32
        Public Property IdNo As Int32
        Public Property EmployeeLeaveEarnedApprovalItems As List(Of EmployeeLeaveEarnedApprovalItem)
    End Class

End Namespace