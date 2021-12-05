' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class HolidayAvailmentApprovalHistory

        Public Property ApprovalIdNo As Int32
        Public Property DateCreated As DateTime?
        Public Property EmployeeLeaveIdNo As Int32
        Public Property ApprovedBy As Int32
        Public Property IdNo As Int32
        Public Property Note As String
        Public Property Status As String

    End Class

End Namespace