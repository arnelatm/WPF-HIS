Imports AATM.Presentation.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IEmployeeLeaveEarnedView
        Inherits IView

        Property ApprovalNote As String
        Property Approved As Boolean
        Property ApprovedBy As Int32?
        Property DateCreated As DateTime?
        Property DaysEarned As Decimal
        Property Disapproved As Boolean
        Property EmployeeIdNo As Int32
        Property EndDate As Date?
        Property EnteredBy As Int32
        Property IdNo As Int32
        Property LeaveIdNo As Int16
        Property Reason As String
        Property StartDate As Date?
        Property UserIsASuperAdministrator As Boolean
        Property UserIsASupervisor As Boolean
        Property UserHasHrAccess As Boolean
        Property UserHasHrManagerAccess As Boolean
        Event DateValuesChanged()
        Event LeaveIdNoChanged(itemIdNo As Short)
        Event EmployeeIdNoChanged(itemIdNo As Short)
    End Interface

End Namespace