Imports AATM.Libraries

Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class EmployeeLeaveApprovalItemModel

        Public Property ApprovalNote As String
        Public Property EmployeeIdNo As Int32
        Public Property EmployeeName As String
        Public Property EmployeeNameAra As String
        Public Property EmployeeLeaveApprovalIdNo As Int32
        Public Property EmployeeLeaveIdNo As Int16
        Public Property EndDate As Date
        Public Property EnteredBy As Int32
        Public Property FullDay As Boolean
        Public Property IdNo As Int32
        Public Property LeaveDate As Date
        Public Property LeaveIdNo As Int16
        Public Property LeaveName As String
        Public Property LeaveNameAra As String
        Public Property LeaveReason As String
        Public Property LeaveStatus As String
        Public Property StartDate As Date
        Public Property Status As String
        Public Property SupervisorIdNo As Int32

    End Class

End Namespace