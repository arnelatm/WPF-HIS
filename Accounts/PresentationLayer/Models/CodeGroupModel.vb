Imports AATM.Presentation.Models

Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class CodeGroupModel
        'Implements IModelNew

        Public Property Errors As List(Of String)
        Public Property IdNo As Int16
        Public Property CodeGroupCode As String
        Public Property CodeGroupName As String
        Public Property CodeGroupNameAra As String
        Public Property Notes As String
    End Class

End Namespace