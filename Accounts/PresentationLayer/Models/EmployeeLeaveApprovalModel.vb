Imports AATM.Libraries

Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class EmployeeLeaveApprovalModel
        Public Property DateCreated As DateTime
        Public Property EnteredBy As Int32
        Public Property IdNo As Int32
        'Public Property EmployeeLeaveIdNo As Int16
        'Public Property Notes As String
        'Public Property Status As String

    End Class

End Namespace