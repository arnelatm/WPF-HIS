Imports AATM.Libraries

Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class EmployeeLeaveModel

        Public Property AppliedBy As Int32
        Public Property DateCreated As DateTime?
        Public Property EmployeeIdNo As Int32
        Public Property EndDate As DateTime
        Public Property FullDay As Boolean
        Public Property IdNo As Int32
        Public Property LeaveIdNo As Int16
        Public Property LeaveReason As String
        Public Property LeaveStatus As String
        Public Property StartDate As DateTime

    End Class

End Namespace