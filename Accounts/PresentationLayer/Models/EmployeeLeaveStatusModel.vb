Imports AATM.Libraries

Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class EmployeeLeaveStatusModel
        Public Property DateCreated As DateTime?
        Public Property EmployeeLeaveIdNo As Int32
        Public Property IdNo As Int32
        Public Property LeaveReason As String
        Public Property LeaveStatus As Char
        Public Property StartDate As DateTime

    End Class

End Namespace