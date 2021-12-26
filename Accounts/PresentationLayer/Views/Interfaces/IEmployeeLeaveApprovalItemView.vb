Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IEmployeeLeaveApprovalItemView
        Inherits IView

        Property Approve As Boolean
        Property Disapprove As Boolean
        Property EmployeeLeaveIdNo As Int16
        Property EmployeeLeaveApprovalIdNo As Int32
        Property EmployeeName As String
        Property EndDate As Date
        Property FullDay As Boolean
        Property IdNo As Int32
        Property LeaveName As String
        Property Note As String
        Property Reason As String
        Property StartDate As Date
        Property Status As String
    End Interface

End Namespace