Imports AATM.Libraries

Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class EmployeeLeaveApprovalHistoryModel

        Public Property ApprovalDate As DateTime?
        Public Property ApprovalIdNo As Int32
        Public Property ApprovalNote As String
        Public Property ApprovedBy As Int32
        Public Property EmployeeLeaveIdNo As Int16
        Public Property IdNo As Int32
        Public Property LeaveStatus As String

    End Class

End Namespace