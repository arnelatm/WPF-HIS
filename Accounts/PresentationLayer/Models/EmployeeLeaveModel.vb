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
        Public Property EndDate As Date
        Public Property FullDay As Boolean
        Public Property Holiday As Boolean
        Public Property HolidayIdNo As Int16
        Public Property IdNo As Int32
        Public Property LeaveIdNo As Int16
        Public Property NoOfDays As Int32
        Public Property Reason As String
        Public Property Status As String
        Public Property StartDate As Date
        Public Property SupervisorIdNo As Int32?

        'Public Property Approve As Boolean
        'Public Property Disapprove As Boolean
        Public Property ApprovalNote As String

        Public Property ApprovalHistory As List(Of EmployeeLeaveApprovalHistoryModel)
    End Class

End Namespace