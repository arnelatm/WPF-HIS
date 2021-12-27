' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field

Namespace BusinessLayer

    Public Class EmployeeLeaveApprovalHistory

        Public Property ApprovalIdNo As Int32
        Public Property ApprovalNote As String
        Public Property DateCreated As DateTime?
        Public Property EmployeeLeaveIdNo As Int16
        Public Property ApprovedBy As Int32
        Public Property IdNo As Int32       
        Public Property LeaveStatus As String

    End Class

End Namespace