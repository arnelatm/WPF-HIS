Imports AATM.PresentationLayer.Models

Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class InvTransTypeModel
        Public Property AccountIdNo As Int16?
        Public Property Active As Boolean
        Public Property IdNo As Int16
        Public Property InvTransTypeCode As String
        Public Property InvTransTypeName As String
        Public Property InvTransTypeNameAra As String
        Public Property Notes As String
    End Class

End Namespace