Imports AATM.Libraries

Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class EmployeeLeaveModel

        Public Property EnteredBy As Int32
        Public Property DateCreated As DateTime?
        Public Property EmployeeIdNo As Int32
        Public Property EndDate As DateTime
        Public Property FullDay As Boolean
        Public Property IdNo As Int32
        Public Property LeaveIdNo As Int16
        Public Property LeaveReason As String
        Public Property LeaveStatus As String
        Public Property StartDate As DateTime
        Public Property SupervisorIdNo As Int32

        'Public Property Approve As Boolean
        'Public Property Disapprove As Boolean
        Public Property ApprovalNote As String

        Public Property ApprovalHistory As List(Of EmployeeLeaveApprovalHistoryModel)
    End Class

End Namespace