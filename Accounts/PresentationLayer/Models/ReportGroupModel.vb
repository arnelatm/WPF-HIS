Imports AATM.Accounts.BusinessLayer

Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class ReportGroupModel
        Public Property IdNo As Int32
        Public Property ReportGroupCode As String
        Public Property ReportGroupName As String
        Public Property ReportGroupNameAra As String
    End Class

End Namespace