Imports AATM.Libraries

Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class EmployeeLeaveApprovalHistoryModel

        Public Property ApprovalIdNo As Int32
        Public Property DateCreated As DateTime?
        Public Property EmployeeLeaveIdNo As Int32
        Public Property ApprovedBy As Int32
        Public Property IdNo As Int32
        Public Property Note As String
        Public Property Status As String

    End Class

End Namespace