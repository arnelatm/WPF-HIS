Imports AATM.Libraries

Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class EmployeeLeaveApprovalHistoryModel
        Inherits EmployeeLeaveApprovalModel

        Property Note As String
        Property Status As String

    End Class

End Namespace