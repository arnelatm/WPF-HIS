Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class PayCycleModel

        Public Property Errors As List(Of String)
        Public Property IdNo As Int16
        Public Property PayCycleCode As String
        Public Property PayCycleName As String
        Public Property PayCycleNameAra As String
        Public Property Notes As String
    End Class

End Namespace