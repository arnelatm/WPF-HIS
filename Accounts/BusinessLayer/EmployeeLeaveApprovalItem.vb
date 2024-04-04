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
                AddRule(New ValidateRequired("EmployeeLeaveIdNo"))
                AddRule(New ValidateRequired("Status"))
            End If
        End Sub

        Public Property ApprovalNote As String
        Public Property DateCreated As DateTime
        Public Property EmployeeLeaveIdNo As Int32
        Public Property EmployeeIdNo As Int32
        Public Property EmployeeName As String
        Public Property EmployeeNameAra As String
        Public Property EmployeeLeaveApprovalIdNo As Int32
        Public Property EndDate As Date
        Public Property EnteredBy As Int32
        Public Property FullDay As Boolean
        Public Property IdNo As Int32
        Public Property LeaveIdNo As Int16
        Public Property LeaveName As String
        Public Property LeaveNameAra As String
        Public Property Reason As String
        Public Property Status As String
        Public Property StartDate As Date
        Public Property SupervisorIdNo As Int32

    End Class

    Public Class EmployeeLeaveEarnedApprovalItem
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("EmployeeLeaveEarnedIdNo"))
                AddRule(New ValidateRequired("Status"))
            End If
        End Sub

        Public Property ApprovalNote As String
        Public Property Approved As Boolean
        Public Property DateCreated As DateTime?
        Public Property DaysEarned As Decimal
        Public Property Disapproved As Boolean
        Public Property EmployeeLeaveEarnedIdNo As Int32
        Public Property EmployeeIdNo As Int32
        Public Property EmployeeName As String
        Public Property EmployeeNameAra As String
        Public Property EmployeeLeaveEarnedApprovalIdNo As Int32
        Public Property EndDate As Date
        Public Property EnteredBy As Int32
        Public Property IdNo As Int32
        Public Property LeaveIdNo As Int16
        Public Property LeaveName As String
        Public Property LeaveNameAra As String
        Public Property Reason As String
        Public Property StartDate As Date
        Public Property SupervisorIdNo As Int32

    End Class

End Namespace