Imports AATM.Libraries

Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class EmployeeLeaveApprovalModel
        Public Property DateCreated As DateTime?
        Public Property ApprovedBy As Int32
        Public Property IdNo As Int32
        Public Property EmployeeLeaveApprovalItems As List(Of EmployeeLeaveApprovalItemModel)

    End Class

    Public Class EmployeeLeaveEarnedApprovalModel
        Public Property DateCreated As DateTime?
        Public Property ApprovedBy As Int32
        Public Property IdNo As Int32
        Public Property EmployeeLeaveEarnedApprovalItems As List(Of EmployeeLeaveEarnedApprovalItemModel)
    End Class

End Namespace